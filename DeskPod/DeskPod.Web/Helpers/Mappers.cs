using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeskPod.Services.Dtos;
using DeskPod.Web.Models;

namespace DeskPod.Web.Helpers
{
    public static class Mappers
    {
        public static EpisodeModel ToPodcastModel(this EpisodeDto podcastDto)
        {
            return new EpisodeModel(podcastDto.Title, podcastDto.Url, podcastDto.PublicationDate);
        }
    }
}
