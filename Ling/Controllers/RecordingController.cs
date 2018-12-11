using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ling.Controllers
{
    public class RecordingController : Controller
    {
        /// <summary>
        /// Displays all saved recordings
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        //TODO: 
        //Action that receives a clip?
        //Action that sends a clip to API, gets results, saves clip to DB, and displays results to user
        //etc.

    }
}
