using System;
using System.Collections.Generic;

namespace ChatAppProject.Models
{
    public partial class Channeltable
    {
        public Channeltable()
        {
            Messegetable = new HashSet<Messegetable>();
            Userchanneltable = new HashSet<Userchanneltable>();
        }

        public string Channelname { get; set; }
        public int Channelid { get; set; }

        public virtual ICollection<Messegetable> Messegetable { get; set; }
        public virtual ICollection<Userchanneltable> Userchanneltable { get; set; }
    }
}
