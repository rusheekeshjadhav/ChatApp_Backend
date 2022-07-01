using ChatAppProject.Models;
using ChatAppProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTableController : ControllerBase
    {
        /*private readonly ChatAppContext _context;*/

        private readonly IUserService _userService;

        public UserTableController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<UserTableController>
        // localhost:{{port}}/api/UserTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usertable>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }


        // GET api/<UserTableController>/5
        // localhost:{{port}}/api/UserTable/{{id}}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usertable>> GetUserById(int id)
        {
            return await _userService.GetUserById(id);
        }


        // GET api/<UserTableController>/ByName/xyz
        // localhost:{{port}}/api/UserTable/ByName/{{name}}
        [HttpGet("ByName/{name}")]
        public Usertable GetUserByName(string name)
        {
            return _userService.GetUserByName(name);
        }


        // POST api/<UserTableController>
        // localhost:{{port}}/api/UserTable
        [HttpPost]
        public Usertable AddUser(Usertable user)
        {
            return _userService.AddUser(user);
        }

/*
        // PUT api/<UserTableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserTableController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
*/
    }
}
