using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Catalog
    {
        [Key]
        public int id { get; set; }
        public string namaBarang { get; set; }
        public string satuan { get; set; }
        public int harga { get; set; }
        public string supplier { get; set; }
    }
}
