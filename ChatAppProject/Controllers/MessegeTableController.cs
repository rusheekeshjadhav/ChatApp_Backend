using ChatAppProject.Models;
using ChatAppProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatAppProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessegeTableController : ControllerBase
    {
        private readonly IMessegeService _messegeService;

        public MessegeTableController(IMessegeService messegeService)
        {
            _messegeService = messegeService;
        }


        // GET: api/<MessegeTableController>
        // localhost:{{port}}/api/MessegeTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Messegetable>>> GetAllMesseges()
        {
            return await _messegeService.GetAllMesseges(); 
        }

/*
        // GET api/<MessegeTableController>/ByUser/5
        // localhost:{{port}}/api/MessegeTable/ByUser/{{id}}
        [HttpGet("ByUser/{id}")]
        public IEnumerable<Messegetable> GetMessegesByUserId(int id)
        {
            return _messegeService.GetMessegeByChannelId(id);
        }
*/

        // GET api/<MessegeTableController>/ByChannel/5
        // localhost:{{port}}/api/MessegeTable/ByChannel/{{id}}
        [HttpGet("ByChannel/{id}")]
        public IEnumerable<Messegetable> GetMessegesByChannelId(int id)
        {
            return _messegeService.GetMessegeByChannelId(id);
        }

/*
        // GET api/<MessegeTableController>/1/5
        // localhost:{{port}}/api/MessegeTable/{{uid}}/{{cid}}
        [HttpGet("{uid}/{cid}")]
        public IEnumerable<Messegetable> GetMessegesByUserIdChannelId(int uid, int cid)
        {
            return _messegeService.GetMessegeByChannelId(id);
        }
*/

        // POST api/<MessegeTableController>
        // localhost:{{port}}/api/MessegeTable
        [HttpPost]
        public Messegetable AddMessege(Messegetable messege)
        {
            return _messegeService.AddMessege(messege);
        }

        // PUT api/<MessegeTableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MessegeTableController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
