using System.Collections.Generic;
using System.Threading.Tasks;
using DeskPod.Services.Dtos;

namespace DeskPod.Services.Intefaces
{
    public interface IPodcastService
    {
        Task<IEnumerable<PodcastDto>> Get(string url);
    }
}
