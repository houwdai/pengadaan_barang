using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Client.Models
{
    public partial class Status
    {
        public Status()
        {
            Pengadaan = new HashSet<Pengadaan>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pengadaan> Pengadaan { get; set; }
    }
}
