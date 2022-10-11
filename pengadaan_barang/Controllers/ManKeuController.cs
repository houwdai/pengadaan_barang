using Client.Models;
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
    }
}
