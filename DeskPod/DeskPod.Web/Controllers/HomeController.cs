using System.Linq;
using System.Threading.Tasks;
using DeskPod.Services.Intefaces;
using DeskPod.Web.Helpers;
using DeskPod.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DeskPod.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPodcastParser _podcastParser;
        private readonly IPodcastService _podcastService;
        private readonly IConfigurationRoot _configuration;

        public HomeController(IPodcastParser podcastParser, IPodcastService podcastService, IConfigurationRoot configuration)
        {
            _podcastParser = podcastParser;
            _podcastService = podcastService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Podcasts(string url)
        {
            if(string.IsNullOrEmpty(url))
                return RedirectToAction("Index");

            var podcasts = await _podcastParser.Get(url, 5);

            var viewModel = new EpisodesViewModel
            {
                Podcasts = podcasts.Select(pod => pod.ToPodcastModel())
            };

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
