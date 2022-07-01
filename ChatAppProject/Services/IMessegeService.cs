using ChatAppProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatAppProject.Services
{
    public interface IMessegeService
    {
        public Task<ActionResult<IEnumerable<Messegetable>>> GetAllMesseges();
        public IEnumerable<Messegetable> GetMessegeByChannelId(int id);
        public Messegetable AddMessege(Messegetable messege);
    }
}
