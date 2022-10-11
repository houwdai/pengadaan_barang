namespace API.Models
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
