using System;
using System.Collections.Generic;

namespace ChatAppProject.Models
{
    public partial class Usertable
    {
        public Usertable()
        {
            Messegetable = new HashSet<Messegetable>();
            Userchanneltable = new HashSet<Userchanneltable>();
        }

        public string Username { get; set; }
        public string Passwords { get; set; }
        public int Userid { get; set; }

        public virtual ICollection<Messegetable> Messegetable { get; set; }
        public virtual ICollection<Userchanneltable> Userchanneltable { get; set; }
    }
}
