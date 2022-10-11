using Client.Models;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Client.Controllers
{
    public class ManKeuController : Controller
    {
        DTSMiniProjectContext myContext;
        public ManKeuController(DTSMiniProjectContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != null)
            {
                if (role.Equals("ManKeu"))
                {
                    int status_waiting = 3;
                    var data = myContext.Pengadaan.Where(q => q.IdStatus == status_waiting).Include(z => z.IdBarangNavigation).
                        Include(x => x.IdSupplierNavigation).Include(y => y.IdDivisiNavigation).
                        Include(p => p.IdStatusNavigation).ToList();

                    return View(data);
                }
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        public ActionResult Terima(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != null)
            {
                if (role.Equals("ManKeu"))
                {
                    var spb = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();
                    spb.IdStatus = 4;
                    var idP = spb.IdBarang;
                    var kuantitas = spb.Kuantitas;
                    var product = myContext.Product.Where(a => a.Id == idP).FirstOrDefault();
                    var stock = product.StockProduct;
                    var stockupdate = kuantitas + stock;
                    product.StockProduct = stockupdate;
                    myContext.Product.Update(product);
                    myContext.Pengadaan.Update(spb);
                    myContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        [HttpGet("Tolak/{id:int}")]
        public ActionResult Tolak(int id)
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != null)
            {
                if (role.Equals("ManKeu"))
                {
                    var spb = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();
                    spb.IdStatus = 5;
                    myContext.Pengadaan.Update(spb);
                    myContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        public IActionResult Riwayat()
        {
            var role = HttpContext.Session.GetString("Role");
            if (role != null)
            {
                if (role.Equals("ManKeu"))
                {
                    int status_waiting = 4;
                    var data = myContext.Pengadaan.Where(q => q.IdStatus == status_waiting).Include(z => z.IdBarangNavigation).
                        Include(x => x.IdSupplierNavigation).Include(y => y.IdDivisiNavigation).
                        Include(p => p.IdStatusNavigation).ToList();

                    return View(data);
                }
            }
            return RedirectToAction("Unauthorized", "ErrorPage");
        }

        //---==== Divisi ====---
        // GET: Mankeu Controller
        public ActionResult Divisi()
        {
            var data = myContext.Divisi.ToList();

            return View(data);
        }
        // GET: MankeuController/CreateDivisi
        public ActionResult CreateDivisi()
        {
            return View();
        }

        // POST: MankeuController/CreateDivisi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDivisi(Divisi divisi)
        {
            if (ModelState.IsValid)
            {
                myContext.Divisi.Add(divisi);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Divisi");
            }
            return View();

        }
        // GET: MankeuController/DeleteDivisi

        [HttpGet("Mankeu/DeleteDivisi/{id:int}")]
        public IActionResult DeleteDivisi(int id)
        {
            var deldiv = myContext.Divisi.Where(a => a.Id == id).FirstOrDefault();
            myContext.Divisi.Remove(deldiv);
            myContext.SaveChanges();
            return RedirectToAction("Divisi");
        }


        //GET :MankeuController/EditDivisi/id
        [HttpGet("Mankeu/EditDivisi/{id:int}")]
        public IActionResult EditDivisi(int id)
        {
            ViewModel viewModel = new ViewModel();
            viewModel.divisi = myContext.Divisi.Where(a => a.Id == id).FirstOrDefault();

            return View(viewModel);
        }

        //POST : MankeuController/EditDivisi/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditDivisi(int id, Divisi divisi)
        {
            if (ModelState.IsValid)
            {
                var data = myContext.Divisi.Where(a => a.Id == id).FirstOrDefault();

                if (data != null)
                {
                    data.Nama = divisi.Nama;
                    data.AnggaraanTetap = divisi.AnggaraanTetap;

                }
                myContext.Divisi.Update(data);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction("Divisi");
            }
            return View();
        }
    }
}
