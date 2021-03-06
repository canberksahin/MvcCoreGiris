﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreGiris.Models;

namespace MvcCoreGiris.Controllers
{
    public class KisilerController : Controller
    {
        private readonly OkulCoreContext db;
        public KisilerController(OkulCoreContext okulcoreContext)
        {
            db = okulcoreContext;
        }

        public IActionResult Index()
        {
            return View(db.Kisiler.ToList());
        }


        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Yeni(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                db.Add(kisi);
                db.SaveChanges();
                TempData["mesaj"] = $"{kisi.KisiAd} adlı kişi başarıyla oluşturulmuştur.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        
        public IActionResult Duzenle(int? id)
        {
            if (id == null || !db.Kisiler.Any(x => x.Id == id))
            {
                return NotFound();
            }
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                return NotFound();
            }

            return View(kisi);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Duzenle(Kisi kisi)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(kisi).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.Update(kisi);
                db.SaveChanges();

                TempData["mesaj"] = $"{kisi.KisiAd} adlı kişi başarıyla güncellenmiştir.";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Sil(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                return NotFound();
            }
            db.Remove(kisi);
            db.SaveChanges();

            TempData["mesaj"] = $"{kisi.KisiAd} adlı kişi başarıyla silinmiştir.";
            return RedirectToAction(nameof(Index));
        }
    }
}
