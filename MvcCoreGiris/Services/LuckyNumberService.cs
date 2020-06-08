using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreGiris.Services
{
    public class LuckyNumberService
    {
        private readonly static Random rnd = new Random();
        public int LuckyNumber { get; set; }

        public LuckyNumberService()
        {
            LuckyNumber = rnd.Next(10);
        }
    }
}
