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
        public async Task<IEnumerable<PodcastDto>> Get(string url)
        {
            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);
                var xDocument = XDocument.Load(stream);

                var items = xDocument.Descendants("item");

                return items.Select(BuildPodcastDto)
                            .Where(p => p != null);
            }
        }

        private static PodcastDto BuildPodcastDto(XElement item)
        {
            DateTime publicationDate;

            if (DateTime.TryParse(item.Descendants("pubDate").First().Value, out publicationDate))
            {
                var podcastTitle = item.Descendants("title").FirstOrDefault()?.Value;
                var podcastUrl = item.Descendants("enclosure").FirstOrDefault()?.Attribute("url").Value;

                return new PodcastDto(podcastTitle, podcastUrl, publicationDate);
            }

            return null;
        }
    }
}
