using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using DeskPod.Services.Dtos;
using DeskPod.Services.Intefaces;

namespace DeskPod.Services.Services
{
    public class PodcastService : IPodcastService
    {
        private IList<PodcastDto> _podcasts;

        public PodcastService()
        {
            _podcasts = new List<PodcastDto>();
        }

        public async Task Load(string url)
        {
            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);
                var xDocument = XDocument.Load(stream);

                var items = xDocument.Descendants("item");

                foreach (var item in items)
                {
                    ProcessItem(item);
                }

                _podcasts = _podcasts.OrderByDescending(p => p.PublicationDate)
                                     .ToList();
            }
        }

        public IList<PodcastDto> GetAll()
        {
            return _podcasts;
        }

        private void ProcessItem(XElement item)
        {
            DateTime publicationDate;

            if (DateTime.TryParse(item.Descendants("pubDate").First().Value, out publicationDate))
            {
                var podcastTitle = item.Descendants("title").FirstOrDefault()?.Value;
                var podcastUrl = item.Descendants("enclosure").FirstOrDefault()?.Attribute("url").Value;

                _podcasts.Add(new PodcastDto(podcastTitle, podcastUrl, publicationDate));
            }
        }
    }
}
