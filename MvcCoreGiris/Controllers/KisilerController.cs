using System;
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
    }
}
