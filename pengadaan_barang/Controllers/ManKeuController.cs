using Client.Models;
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
            int status_waiting = 3;
            var data = myContext.Pengadaan.Where(q => q.IdStatus == status_waiting).Include(z => z.IdBarangNavigation).
                Include(x => x.IdSupplierNavigation).Include(y => y.IdDivisiNavigation).
                Include(p => p.IdStatusNavigation ).ToList();

            return View(data);
        }
        public ActionResult Terima(int id)
        {

            var spb = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();
            spb.IdStatus = 4;
            myContext.Pengadaan.Update(spb);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Tolak/{id:int}")]
        public ActionResult Tolak(int id)
        {

            var spb = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();
            spb.IdStatus = 5;
            myContext.Pengadaan.Update(spb);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Riwayat()
        {

            int status_waiting = 4;
            var data = myContext.Pengadaan.Where(q => q.IdStatus == status_waiting).Include(z => z.IdBarangNavigation).
                Include(x => x.IdSupplierNavigation).Include(y => y.IdDivisiNavigation).
                Include(p => p.IdStatusNavigation).ToList();

            return View(data);
        }
    }
}
