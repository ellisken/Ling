using Ling.Models;
using Ling.Models.Interfaces;
using Ling.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ling.Controllers
{
    public class RecordingController : Controller
    {
        IConfiguration _configuration;
        IRecording _recordings;
        ILanguage _languages;

        // Store alternate language codes by region
        private Dictionary<string, List<string>> Languages = new Dictionary<string, List<string>>()
        {
            ["Asia"] = new List<string> { "cmn-hans-cn", "ms-my", "ja-jp" },
            ["South Asia"] = new List<string> { "hi-in", "bn-in", "ar-eg" },
            ["Africa"] = new List<string> { "ar-eg", "sw-ke" },
            ["Western Europe"] = new List<string> { "en-us", "de-de", "fr-fr", "es-es" },
            ["Eastern Europe"] = new List<string> { "ru-ru", "pl-pl" },
            ["South/Latin America"] = new List<string> { "es-mx", "pt-br" }
        };


        public RecordingController(IConfiguration configuration, IRecording recordings, ILanguage languages)
        {
            _configuration = configuration;
            _recordings = recordings;
            _languages = languages;
        }

        /// <summary>
        /// Displays all saved recordings
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _recordings.GetRecordings());
        }

        /// <summary>
        /// Create a Recording object with data grabbed from Azure Blob Storage container.
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<TranscriptionViewModel> Create()

        {
            var data = HttpContext.Request.Form.Files[0];
            var langRegion = HttpContext.Request.Form["language_region"];
            Blob blob = new Blob(_configuration["BlobStorageAccountName"], _configuration["BlobStorageKey"], _configuration);
            CloudBlobContainer container = await blob.GetContainer("soundrecording");

            //Send to blob storage
            string path = await CreatePath(data);
            await blob.UploadFile(container, data.FileName, path);


            //Get Uri back from blob storage
            var newBlobURI = blob.GetBlob(data.FileName, container).Uri.AbsoluteUri;
            string defaultLang = Languages[langRegion].First();
            List<string> alts = Languages[langRegion].GetRange(1, Languages[langRegion].Count - 1);
            var result = await _recordings.Transcribe(newBlobURI, defaultLang, alts);

            //TODO: add language result to recording before saving
            Recording recording = new Recording()
            {
                FileName = data.FileName,
                URI = newBlobURI,
                Transcription = result.Transcript,
            };

            if (result.Language != null)
            {
                Language language = await _languages.GetLanguage(result.Language.ToLower());
                recording.Language = language;
                result.Language = language.EnglishName;
            }

            //Create Recording entry in app's DB
            await _recordings.AddRecording(recording);

            return result;

        }

        public async Task<string> CreatePath(IFormFile data)
        {
            string filepath = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString();
            using (var stream = new FileStream(filepath, FileMode.Create))
            {
                await data.CopyToAsync(stream);
            }
            return filepath;
        }

    }
}
