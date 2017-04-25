using System.Collections.Generic;
using System.Threading.Tasks;
using DeskPod.Services.Dtos;

namespace DeskPod.Services.Intefaces
{
    public interface IPodcastParser
    {
        Task<IEnumerable<EpisodeDto>> Get(string url, int take);
    }
}
