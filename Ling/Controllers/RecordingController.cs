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
            ["Asia"] = new List<string> { "cmn", "ja", "ms" },
            ["South Asia"] = new List<string> { "hi", "bn", "ar" },
            ["Africa"] = new List<string> { "ar", "sw" },
            ["Western Europe"] = new List<string> { "en", "de", "fr", "es" },
            ["Eastern Europe"] = new List<string> { "ru", "pl-pl" },
            ["South/Latin America"] = new List<string> { "es", "pt" }
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
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<TranscriptionViewModel> Create()
        {
            // FormData sent by XHR on the front-end. Script can be found in site.js
            var data = HttpContext.Request.Form.Files[0];
            // Language Region selected by user
            var langRegion = HttpContext.Request.Form["language_region"];
            // Create Blob instance
            Blob blob = new Blob(_configuration["BlobStorageAccountName"], _configuration["BlobStorageKey"], _configuration);
            // Grab container that holds all audio blobs
            CloudBlobContainer container = await blob.GetContainer("soundrecording");

            // Send to blob storage
            string path = await CreatePathAsync(data);
            await blob.UploadFile(container, data.FileName, path);

            // Get Uri back from blob storage
            var newBlobURI = blob.GetBlob(data.FileName, container).Uri.AbsoluteUri;
            // Set default language to first string in alt languages List for selected region
            string defaultLang = Languages[langRegion].First();
            // Set alternate languages to remaining items in List
            List<string> alts = Languages[langRegion].GetRange(1, Languages[langRegion].Count - 1);
            // Transcribe audio blob with best guess(es) per selected region
            var result = await _recordings.Transcribe(newBlobURI, defaultLang, alts);

            // Initialize Recording object and set properties
            Recording recording = new Recording()
            {
                FileName = data.FileName,
                URI = newBlobURI,
                Transcription = result.Transcript,
            };

            // Get language of transcribed result and set it as prop of transcription view model
            if (result.Language != null && result.Language.Length > 0)
            {
                Language language = await _languages.GetLanguage(result.Language.ToLower());
                if (language != null) {
                    recording.Language = language;
                    result.Language = language.EnglishName;
                }
                else
                {
                    result.Language = result.Language;
                }

                //Create Recording entry in app's DB
                await _recordings.AddRecording(recording);
            }
            //If API returned an empty response, set result.Language equal to error
            else
            {
                result.Language = "Language detection failed, try again.";
            }


            // Return transcription view model
            return result;
        }

        /// <summary>
        /// This action creates a temporary file path where the wav blob will live. This is necessary in order to upload it to Blob storage.
        /// </summary>
        /// <param name="data">Audio blob sent over from FormData</param>
        /// <returns>A temporary file path</returns>
        private async Task<string> CreatePathAsync(IFormFile data)
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
