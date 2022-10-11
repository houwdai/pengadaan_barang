using System.Collections.Generic;

namespace API.Models
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
        public int Telepon { get; set; }

        public virtual ICollection<Pengadaan> Pengadaan { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
