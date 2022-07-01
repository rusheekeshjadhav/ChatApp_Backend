using ChatAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatAppProject.Services
{
    public class ChannelService: IChannelService
    {
        private readonly ChatAppContext _context;

        public ChannelService(ChatAppContext context)
        {
            _context = context;
        }

        
        public async Task<ActionResult<IEnumerable<Channeltable>>> GetAllChannels()
        {
            if (_context.ChannelList == null)
            {
                return null;
            }
            return await _context.ChannelList.ToListAsync();
        }

        public async Task<ActionResult<Channeltable>> GetChannelById(int id)
        {
            if (_context.ChannelList == null)
            {
                return null;
            }
            var channel = await _context.ChannelList.FindAsync(id);

            if (channel == null)
            {
                return null;
            }

            return channel;
        }

        public Channeltable AddChannel(Channeltable channel, int userid)
        {
            _context.ChannelList.Add(channel);
            _context.SaveChanges();

            Userchanneltable uc = new Userchanneltable();
            uc.Userid = userid;
            uc.Channelid = channel.Channelid;
            _context.UserchannelList.Add(uc);
            _context.SaveChanges();

            return channel;
        }
    }
}
