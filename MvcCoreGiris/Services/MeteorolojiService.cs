using MvcCoreGiris.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Services
{
    public class MeteorolojiService : IWeatherService
    {
        public decimal Temperature(string cityName)
        {
            switch (cityName.ToLower())
            {
                case "ankara":
                    return 50;
                case "istanbul":
                    return 51;
                default:
                    return 45;
            }
        }
    }
}
