using System.Collections.Generic;

namespace DeskPod.Web.Models
{
    public class PodcastViewModel
    {
        public IList<PodcastModel> Podcasts { get; set; }

        public PodcastViewModel()
        {
            Podcasts = new List<PodcastModel>();
        }
    }
}
