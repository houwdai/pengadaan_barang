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
            return View();
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
