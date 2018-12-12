using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ling.Models;
using Microsoft.Extensions.Configuration;
using Ling.Models.Interfaces;

namespace Ling.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _configuration;
        IRecording _recording;

        public HomeController(IConfiguration configuration, IRecording recording)
        {
            _configuration = configuration;
            _recording = recording;
        }

        public IActionResult Index()
        {
            //string [] alts = new string[] { "pt-BR", "ru-RU", "cmn-Hant-TW" };
            //var results = await _recording.Transcribe("http://www.signalogic.com/melp/EngSamples/eng_m1.wav", "en-US", alts);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
