using ChatAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatAppProject.Services
{
    public interface IUserChannelService
    {
        public Task<ActionResult<IEnumerable<Userchanneltable>>> GetAllUserChannels();
        public IEnumerable<Userchanneltable> GetUserChannelByChannelId(int id);
        public Userchanneltable AddUserChannel(Userchanneltable userchannel);
        public void DeleteUserChannel(Userchanneltable userchannel);
    }
}
