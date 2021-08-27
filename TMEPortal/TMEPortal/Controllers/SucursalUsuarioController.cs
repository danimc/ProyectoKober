using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMEPortal.DataContext;
using TMEPortal.Global_Objects;

namespace TMEPortal.Controllers
{[Authorize]
    public class SucursalUsuarioController : Controller
    {
        Message send = new Message();
        KoberEntities db = new KoberEntities();
        
        // GET: SucursalUsuario
        public ActionResult Index()
{
            try
            {
            var Sucursales = new List<sp_GetSucursalesCliente_Result>();

            //
                Sucursales  = db.sp_GetSucursalesCliente(Session["User"].ToString()).ToList();

            if (Sucursales.Count == 0)
            {
               
                ViewBag.Message = send.Error("Sucursales no encontradas, consulte a soporte TI");
                return View();
            }
            else
            {
                ViewBag.SucursalesCliente = Sucursales;
            return View();
            }   

            }
            catch (Exception)
            {

                ViewBag.Message = send.Error("Error #5000, consulte a soporte TI");
                return View();
            }
        }

        [HttpPost]
        public ActionResult Go(FormCollection Collection)
        {
            Session["Sucursal"] = Collection["ID"].ToString();
            return RedirectToAction("index", "Home");
        }
    }
}