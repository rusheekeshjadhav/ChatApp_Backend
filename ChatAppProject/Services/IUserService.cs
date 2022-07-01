using ChatAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatAppProject.Services
{
    public interface IUserService
    {
        public Task<ActionResult<IEnumerable<Usertable>>> GetAllUsers();
        public Task<ActionResult<Usertable>> GetUserById(int id);
        public Usertable GetUserByName(string name);
        public Usertable AddUser(Usertable user);
    }
}
