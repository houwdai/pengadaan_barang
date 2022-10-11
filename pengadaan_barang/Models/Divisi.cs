using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Client.Models
{
    public partial class Divisi
    {
        public Divisi()
        {
            Pengadaan = new HashSet<Pengadaan>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public int AnggaraanTetap { get; set; }


        public virtual ICollection<Pengadaan> Pengadaan { get; set; }
    }
}
