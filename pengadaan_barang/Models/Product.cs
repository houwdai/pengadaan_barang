using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Client.Models
{
    public partial class Product
    {
        public Product()
        {
            Pengadaan = new HashSet<Pengadaan>();
        }

        public int Id { get; set; }
        public string NamaProduk { get; set; }
        public int? IdSatuan { get; set; }
        public int? HargaProduct { get; set; }
        public int? StockProduct { get; set; }
        public int? IdSupplier { get; set; }

        public virtual Satuan IdSatuanNavigation { get; set; }
        public virtual Supplier IdSupplierNavigation { get; set; }
        public virtual ICollection<Pengadaan> Pengadaan { get; set; }
    }
}
