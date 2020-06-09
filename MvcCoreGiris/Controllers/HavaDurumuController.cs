using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcCoreGiris.Interfaces;

namespace MvcCoreGiris.Controllers
{
    public class HavaDurumuController : Controller
    {
        private readonly IWeatherService weatherService;

        public HavaDurumuController(IWeatherService weatherService)
        {
            this.weatherService = weatherService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SicaklikGetir(string sehirAd)
        {
            try
            {
                return Json(new { sicaklik = weatherService.Temperature(sehirAd) });

            }
            catch (Exception)
            {
                return StatusCode(503);
            }
        }
    }
}
