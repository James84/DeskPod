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
    public class PodcastParser : IPodcastParser
    {
        public async Task<IEnumerable<EpisodeDto>> Get(string url, int take)
        {
            using (var client = new HttpClient())
            {
                var stream = await client.GetStreamAsync(url);
                var xDocument = XDocument.Load(stream);

                var items = xDocument.Descendants("item");

                return items.Select(BuildPodcastDto)
                            .Where(p => p != null)
                            .Take(take);
            }
        }

        private static EpisodeDto BuildPodcastDto(XElement item)
        {
            DateTime publicationDate;

            if (DateTime.TryParse(item.Descendants("pubDate").First().Value, out publicationDate))
            {
                var podcastTitle = item.Descendants("title").FirstOrDefault()?.Value;
                var podcastUrl = item.Descendants("enclosure").FirstOrDefault()?.Attribute("url").Value;

                return new EpisodeDto(podcastTitle, podcastUrl, publicationDate);
            }

            return null;
        }
    }
}
