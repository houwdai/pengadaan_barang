using Client.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Client.ViewModels
{
    public class ViewModel
    {
        public Product product { get; set; }
        public Pengadaan pengadaan { get; set; }
        public Supplier supplier { get; set; }
        public Satuan satuan { get; set; }
        public Divisi divisi {get; set; }
        public IEnumerable<SelectListItem> Satuan { get; set; }
        public IEnumerable<SelectListItem> Supplier  { get; set; }
        public IEnumerable<SelectListItem> Produck { get; set; }
        public IEnumerable<SelectListItem> Divisi { get; set; }

    }
}
