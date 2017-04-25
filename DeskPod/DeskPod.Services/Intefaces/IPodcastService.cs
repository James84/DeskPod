using System.Collections.Generic;
using DeskPod.Services.Dtos;

namespace DeskPod.Services.Intefaces
{
    public interface IPodcastService
    {
        IEnumerable<PodcastDto> GetAll();
        void Add(string url);
        void Delete(int id);
    }
}
