using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcCoreGiris.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Compononents
{
    public enum TextColor
    {
        warning,danger, info,primary,secondary,dark,light
    }

    
    public class SansliKisiViewComponent : ViewComponent
    {
        private readonly OkulCoreContext okulCoreContext;

        public SansliKisiViewComponent(OkulCoreContext okulCoreContext)
        {
            this.okulCoreContext = okulCoreContext;
        }
        public async Task<IViewComponentResult> InvokeAsync(TextColor renk)
        {
            var adet =await okulCoreContext.Kisiler.CountAsync();
            var index = new Random().Next(adet);
            var kisi = await okulCoreContext.Kisiler.Skip(index).FirstOrDefaultAsync();

            ViewBag.renk = Enum.GetName(renk.GetType(), renk);

            return View(kisi);
        }
    }
}
