using System;
using System.Collections.Generic;

namespace ChatAppProject.Models
{
    public partial class Messegetable
    {
        public int Channelid { get; set; }
        public int Senderid { get; set; }
        public string Messege { get; set; }
        public DateTime? Time { get; set; }
        public int Id { get; set; }

        public virtual Channeltable Channel { get; set; }
        public virtual Usertable Sender { get; set; }
    }
}
