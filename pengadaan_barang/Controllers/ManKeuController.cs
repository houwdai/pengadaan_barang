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
            int status_waiting = 2;
            var data = myContext.Pengadaan.Where(q => q.IdStatus == status_waiting).Include(z => z.IdBarangNavigation).
                Include(x => x.IdSupplierNavigation).Include(y => y.IdDivisiNavigation).
                Include(p => p.IdStatusNavigation ).ToList();

            return View(data);
        }

        public IActionResult Division()
        {

            return View();
        }
    }
}
