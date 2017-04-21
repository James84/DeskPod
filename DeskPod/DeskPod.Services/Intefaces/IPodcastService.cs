using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeskPod.Services.Intefaces
{
    public interface IPodcastService
    {
        Task Load(string url);
    }
}
