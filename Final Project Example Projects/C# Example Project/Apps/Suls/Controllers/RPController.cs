using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Controllers
{
    public class RPController : Controller
    {
        public HttpResponse Home()
        {
            return this.View();
        }
    }
}
