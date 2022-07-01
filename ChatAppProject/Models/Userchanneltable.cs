using System;
using System.Collections.Generic;

namespace ChatAppProject.Models
{
    public partial class Userchanneltable
    {
        public int Userid { get; set; }
        public int Channelid { get; set; }
        public int Id { get; set; }

        public virtual Channeltable Channel { get; set; }
        public virtual Usertable User { get; set; }
    }
}
