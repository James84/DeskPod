using System;

namespace DeskPod.Services.Dtos
{
    public class PodcastDto
    {
        public string Title { get; }
        public string Url { get; }
        public DateTime PublicationDate { get; set; }

        public PodcastDto(){}

        public PodcastDto(string title, string url, DateTime publicationDate)
        {
            Title = title;
            Url = url;
            PublicationDate = publicationDate;
        }
    }
}
