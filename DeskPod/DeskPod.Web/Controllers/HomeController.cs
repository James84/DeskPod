using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskPod.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeskPod.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Podcasts(string url)
        {
            if(string.IsNullOrEmpty(url))
                return RedirectToAction("Index");

            var podcastService = new PodcastService();
            var podcasts = podcastService.Get(url);

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

        public IActionResult Error()
        {
            return View();
        }
    }
}
