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
    public class UserChannelController : ControllerBase
    {
        private readonly IUserChannelService _userChannelService;

        public UserChannelController(IUserChannelService userChannelService)
        {
            _userChannelService = userChannelService;
        }


        // GET: api/<UserChannelController>
        // localhost:{{port}}/api/UserChannel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userchanneltable>>> GetAllUserChannel()
        {
            return await _userChannelService.GetAllUserChannels();
        }

/*
        // GET api/<UserChannelController>/ByUser/5
        // localhost:{{port}}/api/UserChannel/ByUser/{{id}}
        [HttpGet("ByUser/{id}")]
        public IEnumerable<Userchanneltable> GetUserChannelByUserId(int id)
        {
            return _userChannelService.GetUserChannelByChannelId(id);
        }
*/

        // GET api/<UserChannelController>/ByChannel/5
        // localhost:{{port}}/api/UserChannel/ByChannel/{{id}}
        [HttpGet("ByChannel/{id}")]
        public IEnumerable<Userchanneltable> GetUserChannelByChannelId(int id)
        {
            return _userChannelService.GetUserChannelByChannelId(id);
        }

        // POST api/<UserChannelController>
        // localhost:{{port}}/api/UserChannel
        [HttpPost]
        public Userchanneltable AddUserChannel(Userchanneltable userchannel)
        {
            return _userChannelService.AddUserChannel(userchannel);
        }

        // PUT api/<UserChannelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserChannelController>/5
        [HttpPost("delete")]
        public void Delete(Userchanneltable userchannel)
        {
            _userChannelService.DeleteUserChannel(userchannel);
        }
    }
}
