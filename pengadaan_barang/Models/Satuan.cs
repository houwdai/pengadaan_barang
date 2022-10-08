using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Client.Models
{
    public partial class Satuan
    {
        public Satuan()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
