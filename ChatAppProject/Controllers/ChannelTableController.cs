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
    public class ChannelTableController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelTableController(IChannelService channelService)
        {
            _channelService = channelService;
        }


        // GET: api/<ChannelTableController>
        // localhost:{{port}}/api/ChannelTable
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Channeltable>>> GetAllChannels()
        {
            return await _channelService.GetAllChannels();
        }

        // GET api/<ChannelTableController>/5
        // localhost:{{port}}/api/ChannelTable/{{id}}
        [HttpGet("{id}")]
        public async Task<ActionResult<Channeltable>> GetChannelById(int id)
        {
            return await _channelService.GetChannelById(id);
        }

        // POST api/<ChannelTableController>
        // localhost:{{port}}/api/ChannelTable
        [HttpPost("{id}")]
        public Channeltable AddChannel(Channeltable channel, int id)
        {
            return _channelService.AddChannel(channel, id);
        }
/*
        // PUT api/<ChannelTableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ChannelTableController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
*/
    }
}
