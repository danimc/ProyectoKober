using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMEPortal.DataContext;

namespace TMEPortal.Controllers
{[Authorize]
    public class HomeController : Controller
    {
        KoberEntities db = new KoberEntities();
        public ActionResult Index()
        {

            var a = db.sp_ValidaCliente(User.Identity.Name.ToString()).First();
            if (a == false)
            {

                Session["Error"] = "'LIMITE DE CREDITO EXCEDIDO'";
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



    }
}