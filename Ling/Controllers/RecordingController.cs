using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ling.Controllers
{
    public class RecordingController : Controller
    {
        IConfiguration _configuration;

        public RecordingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Displays all saved recordings
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(string blobUrl, string filename)
        //{
            //Send to blob storage
            //Get Uri back from blob storage
            //Create Recording entry in app's DB
        //    return;
        //}
        //TODO: 
        //Action that receives a clip?
        //Action that sends a clip to API, gets results, saves clip to DB, and displays results to user
        //etc.

    }
}
