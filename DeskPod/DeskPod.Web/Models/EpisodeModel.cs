using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeskPod.Web.Models
{
    public class EpisodeModel
    {
        public string Title { get; }
        public string Url { get; }
        public DateTime PublicationDate { get; set; }

        public EpisodeModel(string title, string url, DateTime publicationDate)
        {
            Title = title;
            Url = url;
            PublicationDate = publicationDate;
        }
    }
}
