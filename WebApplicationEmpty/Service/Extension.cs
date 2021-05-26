using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Service
{
    public static class Extension
    {
        public static string CutController(this string a)
        {
            return a.Replace("Controller", "");
        }
    }
}
