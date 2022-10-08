using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Client.Models
{
    public partial class Pengadaan
    {
        public string PengaadanGuid { get; set; }
        public int Id { get; set; }
        public int? IdBarang { get; set; }
        public int? IdSupplier { get; set; }
        public int? Kuantitas { get; set; }
        public int? Totals { get; set; }
        public int? IdDivisi { get; set; }
        public int? IdStatus { get; set; }

        public virtual Product IdBarangNavigation { get; set; }
        public virtual Divisi IdDivisiNavigation { get; set; }
        public virtual Status IdStatusNavigation { get; set; }
        public virtual Supplier IdSupplierNavigation { get; set; }
    }
}
