using ChatAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAppProject.Services
{
    public class UserService: IUserService
    {
        private readonly ChatAppContext _context;

        public UserService(ChatAppContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Usertable>>> GetAllUsers() {
            if (_context.UserList == null)
            {
                return null;
            }
            return await _context.UserList.ToListAsync();
        }

        public async Task<ActionResult<Usertable>> GetUserById(int id) {
            if (_context.UserList == null)
            {
                return null;
            }
            var user = await _context.UserList.FindAsync(id);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public Usertable GetUserByName(string name)
        {
            if (_context.UserList == null)
            {
                return null;
            }
            var user = _context.UserList.ToList().Find(element => element.Username == name);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public Usertable AddUser(Usertable user) {
            _context.UserList.Add(user);
            _context.SaveChanges();

            Userchanneltable uc = new Userchanneltable();
            uc.Userid = user.Userid;
            uc.Channelid = 27;
            _context.UserchannelList.Add(uc);
            _context.SaveChanges();

            return user;
        }
    }
}
