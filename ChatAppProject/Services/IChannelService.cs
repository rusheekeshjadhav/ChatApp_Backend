using ChatAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatAppProject.Services
{
    public interface IChannelService
    {
        public Task<ActionResult<IEnumerable<Channeltable>>> GetAllChannels();
        public Task<ActionResult<Channeltable>> GetChannelById(int id);
        public Channeltable AddChannel(Channeltable channel, int userid);
    }
}
