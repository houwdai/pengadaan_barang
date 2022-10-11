using API.Context;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class KabagRepository
    {
        MyContext myContext;

        public KabagRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //public Pengadaan Get()
        //{
        //    var data = myContext.Pengadaan.Include(x => x.IdSupplierNavigation).
        //                Include(y => y.IdBarangNavigation).
        //                Include(z => z.IdStatusNavigation).
        //                Include(p => p.IdDivisiNavigation)
        //                .ToList();
        //    return data;
        //    //List<PengadaanVM> pengadaanVM = new List<PengadaanVM>();
        //    //foreach (Pengadaan pengadaan in data)
        //    //{
        //    //    pengadaanVM.Add(new PengadaanVM()
        //    //    {
        //    //        Id = pengadaan.Id,

        //    //    });
        //    //}
        //    //return pengadaanVM;
        //}

        public Pengadaan Get(int id)
        {
            var data = myContext.Pengadaan.Find(id);
            return data;
        }

        public int EditSPB(Pengadaan pengadaan)
        {
            var data = Get(pengadaan.Id);
            data.Id = pengadaan.Id;
            data.IdBarangNavigation.NamaProduk = pengadaan.IdBarangNavigation.NamaProduk;
            data.IdSupplierNavigation.Nama = pengadaan.IdSupplierNavigation.Nama;
            data.Kuantitas = pengadaan.Kuantitas;
            data.Totals = pengadaan.Totals;
            data.IdDivisiNavigation.Nama = pengadaan.IdDivisiNavigation.Nama;
            data.IdStatusNavigation.Name = pengadaan.IdStatusNavigation.Name;
            
            myContext.Pengadaan.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

    }
}
