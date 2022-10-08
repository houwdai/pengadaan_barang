using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    public class KabagController : Controller
    {
        // GET: KabagController
        public ActionResult Index()
        {
            return View();
        }


        // GET: KabagController
        public ActionResult Barang()
        {
            return View();
        }

        // GET: KabagController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KabagController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KabagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
