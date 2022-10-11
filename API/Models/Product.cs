using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public partial class Product
    {
        public Product()
        {
            Pengadaan = new HashSet<Pengadaan>();
        }
        [Key]
        public int Id { get; set; }
        public string NamaProduk { get; set; }
        [ForeignKey("Satuan")]
        public int? IdSatuan { get; set; }
        public int? HargaProduct { get; set; }
        public int? StockProduct { get; set; }
        [ForeignKey("Supplier")]
        public int? IdSupplier { get; set; }

        public virtual Satuan IdSatuanNavigation { get; set; }
        public virtual Supplier IdSupplierNavigation { get; set; }
        public virtual ICollection<Pengadaan> Pengadaan { get; set; }



    }
}
