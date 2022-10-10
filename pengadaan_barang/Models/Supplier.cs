using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Client.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Pengadaan = new HashSet<Pengadaan>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Kota { get; set; }
        public string Email { get; set; }
        public  int Telepon { get; set; }

        public virtual ICollection<Pengadaan> Pengadaan { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
