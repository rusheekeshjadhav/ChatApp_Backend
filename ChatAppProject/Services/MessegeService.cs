using ChatAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppProject.Services
{
    public class MessegeService : IMessegeService
    {
        private readonly ChatAppContext _context;

        public MessegeService(ChatAppContext context)
        {
            _context = context;
        }

        public Messegetable AddMessege(Messegetable messege)
        {
            _context.MessegeList.Add(messege);
            _context.SaveChanges();

            return messege;
        }

        public async Task<ActionResult<IEnumerable<Messegetable>>> GetAllMesseges()
        {
            if(_context.MessegeList == null)
            {
                return null;
            }
            return await _context.MessegeList.ToListAsync();
        }

        public IEnumerable<Messegetable> GetMessegeByChannelId(int id)
        {
            if (_context.MessegeList == null)
            {
                return null;
            }
            var messege = _context.MessegeList.ToList();
            var filterlist = from item in messege where item.Channelid == id select item;

            if (filterlist == null)
            {
                return null;
            }

            return filterlist;
        }
    }
}
