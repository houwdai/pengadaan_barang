using Client.Models;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Client.Controllers
{
    public class KabagController : Controller
    {
        DTSMiniProjectContext myContext;

        public KabagController(DTSMiniProjectContext myContext)
        {
            this.myContext = myContext;
        }


        // GET: KabagController -- ALL data Pengajuan Pengadaan
        public ActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role.Equals("Kepala Bagian Produksi"))
            {
                var data = myContext.Pengadaan.Include(x => x.IdSupplierNavigation).
                    Include(y => y.IdBarangNavigation).
                    Include(z => z.IdStatusNavigation).
                    Include(p => p.IdDivisiNavigation)
                    .ToList();

                return View(data);
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }
        // GET: KabagController/CreateSPB 
        public ActionResult CreateSPB()
        {
            ViewModel vm = new ViewModel();
            List<SelectListItem> Product = myContext.Product
                .OrderBy(n => n.NamaProduk)
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.NamaProduk.ToString()
                }).ToList();
            vm.Produck = Product;
            List<SelectListItem> Supplier = myContext.Supplier
                .OrderBy(n => n.Nama)
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Nama.ToString()
                }).ToList();
            vm.Supplier = Supplier;
            return View(vm);
        }

        // POST: KabagController/CreateSPB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSPB(Pengadaan pengadaan)
        {
            if (ModelState.IsValid)
            {
                myContext.Pengadaan.Add(pengadaan);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();

        }
        // GET: KabagController/DeleteSPB

        [HttpGet("Kabag/DeleteSPB/{id:int}")]
        public IActionResult DeleteSPB(int id)
        {
            var pengadaan = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();
            myContext.Pengadaan.Remove(pengadaan);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: KabagController/EditSPB
        [HttpGet("Kabag/EditSPB/{id:int}")]
        public IActionResult EditSPB(int id)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.pengadaan = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();

            List<SelectListItem> product = myContext.Product
                .OrderBy(n => n.NamaProduk)
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.NamaProduk
                }).ToList();
            viewModel.Produck = product;

            List<SelectListItem> supplier = myContext.Supplier
                .OrderBy(n => n.Nama)
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Nama
                }).ToList();
            viewModel.Supplier = supplier;

            return View(viewModel);
        }
        //POST: KabagController/EditSPB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSPB(int id, Pengadaan pengadaan)
        {
            if (ModelState.IsValid)
            {
                var data = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();
                
            if (data != null)
                {
                    //data.IdBarang = pengadaan.IdBarang;
                    data.IdSupplier = pengadaan.IdSupplier;
                    data.Kuantitas = pengadaan.Kuantitas;
                }
                myContext.Pengadaan.Update(data);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Index");
            }
            return View();
        }




        //---==== Barang ====---
        // GET: KabagController
        public ActionResult Barang()
        {
            var data = myContext.Product.Include(x => x.IdSupplierNavigation).Include(y => y.IdSatuanNavigation).ToList();
           
            return View(data);
        }
        // GET: KabagController/CreateBarang
        public ActionResult CreateBarang()
        {
            ViewModel viewModel = new ViewModel();

            List<SelectListItem> supplier = myContext.Supplier
                .OrderBy(n => n.Nama)
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Nama
                }).ToList();
            viewModel.Supplier = supplier;
            List<SelectListItem> satuan = myContext.Satuan
                .OrderBy(n => n.Nama)
                .Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Nama
                }).ToList();
            viewModel.Satuan = satuan;
            return View(viewModel);
        }

        // POST: KabagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBarang(Product product)
        {
            if (ModelState.IsValid)
            {
                myContext.Product.Add(product);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Barang");
            }
            return View();
            
        }

        // GET: KabagController/DeleteSPB

        [HttpGet("Kabag/DeleteBarang/{id:int}")]
        public IActionResult DeleteBarang(int id)
        {
            var delprod = myContext.Product.Where(a => a.Id == id).FirstOrDefault();
            myContext.Product.Remove(delprod);
            myContext.SaveChanges();
            return RedirectToAction("Barang");
        }


       //---==== Supplier ====---
        // GET: KabagController
        public ActionResult Supplier()
        {
            var data = myContext.Supplier.ToList();

            return View(data);
        }
        // GET: KabagController/CreateBarang
        public ActionResult CreateSupplier()
        {
            return View();
        }

        // POST: KabagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSupplier(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                myContext.Supplier.Add(supplier);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Supplier");
            }
            return View();

        }
        // GET: KabagController/DeleteSupllair

        [HttpGet("Kabag/DeleteSupplier/{id:int}")]
        public IActionResult DeleteSupplier(int id)
        {
            var delsup = myContext.Supplier.Where(a => a.Id == id).FirstOrDefault();
            myContext.Supplier.Remove(delsup);
            myContext.SaveChanges();
            return RedirectToAction("Supplier");
        }
        
        
        //---==== Satuan ====---
        // GET: KabagController
        public ActionResult Satuan()
        {
            var data = myContext.Satuan.ToList();

            return View(data);
        }
        // GET: KabagController/CreateSatuan
        public ActionResult CreateSatuan()
        {
            return View();
        }

        // POST: KabagController/CreateSatuan
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSatuan(Satuan satuan)
        {
            if (ModelState.IsValid)
            {
                myContext.Satuan.Add(satuan);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Satuan");
            }
            return View();

        }
        // GET: KabagController/DeleteSatuan

        [HttpGet("Kabag/DeleteSatuan/{id:int}")]
        public IActionResult DeleteSatuan(int id)
        {
            var delsat = myContext.Satuan.Where(a => a.Id == id).FirstOrDefault();
            myContext.Satuan.Remove(delsat);
            myContext.SaveChanges();
            return RedirectToAction("Satuan");
        }


        // GET: KabagController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     

        // GET: KabagController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KabagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KabagController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KabagController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
