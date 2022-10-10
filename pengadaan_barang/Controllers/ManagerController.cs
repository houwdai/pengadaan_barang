﻿using Client.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Client.Controllers
{
    public class ManagerController : Controller
    {
        DTSMiniProjectContext myContext;
        public ManagerController(DTSMiniProjectContext myContext)
        {
            this.myContext = myContext;
        }
        // GET: Manager
        public ActionResult Index()
        {
            int status_waiting = 1;
            var data = myContext.Pengadaan.Where(q => q.IdStatus == status_waiting).Include(z => z.IdBarangNavigation).
                Include(x => x.IdSupplierNavigation).Include(y => y.IdDivisiNavigation).
                Include(p => p.IdStatusNavigation).ToList();

            return View(data);
        }
        public ActionResult Terima(int id)
        {

            var spb = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();
            spb.IdStatus = 3;
            myContext.Pengadaan.Update(spb);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Tolakk/{id:int}")]
        public ActionResult Tolakk(int id)
        {
            var spb = myContext.Pengadaan.Where(a => a.Id == id).FirstOrDefault();
            spb.IdStatus = 5;
            myContext.Pengadaan.Update(spb);
            myContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Manager
        public ActionResult Riwayat()
        {
            int status_waiting = 1;
            var data = myContext.Pengadaan.Where(q => q.IdStatus != status_waiting).Include(z => z.IdBarangNavigation).
                Include(x => x.IdSupplierNavigation).Include(y => y.IdDivisiNavigation).
                Include(p => p.IdStatusNavigation).ToList();

            return View(data);
        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
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

        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Edit/5
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

        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Delete/5
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
