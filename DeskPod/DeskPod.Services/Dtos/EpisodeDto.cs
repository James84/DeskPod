using System;

namespace DeskPod.Services.Dtos
{
    public class EpisodeDto
    {
        public string Title { get; }
        public string Url { get; }
        public DateTime PublicationDate { get; set; }

        public EpisodeDto(){}

        public EpisodeDto(string title, string url, DateTime publicationDate)
        {
            Title = title;
            Url = url;
            PublicationDate = publicationDate;
        }
    }
}
