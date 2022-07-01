using ChatAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppProject.Services
{
    public class UserChannelService : IUserChannelService
    {
        private readonly ChatAppContext _context;

        public UserChannelService(ChatAppContext context)
        {
            _context = context;
        }

        public Userchanneltable AddUserChannel(Userchanneltable userchannel)
        {
            _context.UserchannelList.Add(userchannel);
            _context.SaveChanges();

            return userchannel;
        }

        public void DeleteUserChannel(Userchanneltable userchannel)
        {
            Userchanneltable uct = _context.UserchannelList.Where(element => element.Channelid == userchannel.Channelid && element.Userid == userchannel.Userid).FirstOrDefault();
            _context.UserchannelList.Remove(uct);
            _context.SaveChanges();
        }

        public async Task<ActionResult<IEnumerable<Userchanneltable>>> GetAllUserChannels()
        {
            if (_context.UserchannelList == null)
            {
                return null;
            }
            return await _context.UserchannelList.ToListAsync();
        }

        public IEnumerable<Userchanneltable> GetUserChannelByChannelId(int id)
        {
            if (_context.UserchannelList == null)
            {
                return null;
            }

            var userchannel = _context.UserchannelList.Include("User").Where(u=>u.Channelid == id).ToList();
            //var filterlist = from item in userchannel where item.Channelid == id select item;

            if (userchannel == null)
            {
                return null;
            }

            return userchannel;
        }
    }
}
