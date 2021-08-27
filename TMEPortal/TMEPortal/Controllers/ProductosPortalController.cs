using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TMEPortal.DataContext;
using TMEPortal.Models;
using OfficeOpenXml;

namespace TMEPortal.Controllers
{
    public class ProductosPortalController : Controller
    {
        KoberEntities db = new KoberEntities();
        // GET: ProductosPortal
        public ActionResult Index(Guid? id)
        {
            
            //si es un pedido nuevo instanciamos la vista con el modelo vacio
            if (id == null)
            {
                Session["PedidoEstilo"] = null;
                return View(new Pedidos());

            }
         
          
        
            // obtenemos la logica de consulta en la base de datos desde el arbol
            var propNodo = db.GetPropProductoNodo1(id).ToList().First();

            // obtenemos el nodo padre 
            var nodoPadre = (from ab in db.ArbolMenu
                             where ab.IdArbolMenu == id
                             from abm in db.ArbolMenu
                             where abm.IdArbolMenu == ab.IdArbolMenuPadre
                             select new
                             {
                                 abm.Descripcion,
                                 abm.Complemento
                             }).FirstOrDefault();

            Session["NodoPadre"] = nodoPadre.Descripcion;
            Session["Complemento"] = nodoPadre.Complemento;
            // llenamos variable de sesion con el dato si es estilo o Diseño
            Session["PedidoEstilo"] = propNodo.descripcion;


            // si el articulo no tiene Color, Ancho y largo se agrega directamente
            var codigoArticulo = (from ab in db.ArbolMenu
                                  join a in db.Art on ab.IdArticulo.Trim() equals a.Articulo.Trim()
                                  where ab.IdArbolMenu == id
                                  select new
                                  {
                                      codigoArticulo = ab.IdArticulo,
                                      descripcion = a.Descripcion1,
                                      clasificacion = a.TMEClasificacion,
                                      modelo = a.TMEModelo

                                  }).FirstOrDefault();
         
            if (codigoArticulo != null)
            {
                if (Session["PedidoD"] == null)
                {
                    Session["PedidoD"] = new List<PedidosDetalle>();
                }
                
                List<PedidosDetalle> Detalle = new List<PedidosDetalle>();
                Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;
                Detalle.Add(new PedidosDetalle
                {
                    Articulo = codigoArticulo.codigoArticulo,
                    Cantidad = 1,
                    Desripcion=codigoArticulo.descripcion,
                    Modelo=codigoArticulo.modelo,
                    Clasificacion=codigoArticulo.clasificacion
                    
                });
                Session["PedidoD"] = Detalle;
                return View("Index");
            }

            // si el detalle de pedidos esta vacio instanciamos uno nuevo
            if (Session["PedidoD"] == null)
            {
                Session["PedidoD"] = new List<PedidosDetalle>();               
            }
            // llenamos variable de sesion con el id del nodo
            Session["stiloId"] = id;

            ViewBag.PropColor = false;
            // Logica de los complementos
            if (propNodo.Color)
            {
                ViewBag.PropColor = true;

            }

           

            return View();
        }
        [HttpPost]
        public ActionResult GridEdit(PedidosDetalle Data)
        {
            // si el detalle de pedidos esta vacio instanciamos uno nuevo
            if (Session["PedidoD"] == null)
            {

                Session["PedidoD"] = new List<PedidosDetalle>();
            }
            List<PedidosDetalle> Detalle = new List<PedidosDetalle>();
            // obtenemos los datos del etalle de pedido
            Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;

            if (Detalle.Where(x => x.Articulo == Data.Articulo).ToList().Count() > 0)
            {
                Detalle.Find(d => d.Articulo == Data.Articulo).Cantidad = Data.Cantidad;
                Session["PedidoD"] = Detalle;
            }

            return Json(Detalle, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RowDeleted(PedidosDetalle Data)
        {
            if (Session["PedidoD"] == null)
            {

                Session["PedidoD"] = new List<PedidosDetalle>();
            }
            List<PedidosDetalle> Detalle = new List<PedidosDetalle>();
            // obtenemos los datos del etalle de pedido
            Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;

            if (Detalle.Where(x => x.Articulo == Data.Articulo).ToList().Count() > 0)
            {
                Detalle = Detalle.Where(p => p.Articulo != Data.Articulo).ToList();
                Session["PedidoD"] = Detalle;
            }



            return Json(Data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(FormCollection formCollection)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] fileBytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                    var ArticulosList = new List<Articulos>();
                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfCol = workSheet.Dimension.End.Column;
                        var noOfRow = workSheet.Dimension.End.Row;

                        List<PedidosDetalle> Detalle = new List<PedidosDetalle>();
                        if (Session["PedidoD"] == null)
                        {
                            Session["PedidoD"] = new List<PedidosDetalle>();
                        }

                        Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;
                        for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                        {
                            var articulo = new Articulos();
                            articulo.Codigo = workSheet.Cells[rowIterator, 1].Value.ToString();
                            articulo.Cantidad = workSheet.Cells[rowIterator, 2].Value.ToString();
                            ArticulosList.Add(articulo);
                            var Arts = db.GetArticuloExcel(articulo.Codigo).First();
                            Detalle.Add(new PedidosDetalle
                            {
                                Articulo = Arts.Articulo,
                                Ancho = Arts.TMEAncho,
                                Cantidad = decimal.Parse(articulo.Cantidad),
                                Clasificacion = Arts.tmeclasflam,
                                Color = Arts.tmecolor,
                                ColorCodigo = Arts.tmecolor,
                                Desripcion = Arts.Descripcion1,
                                Largo = Arts.TMELargo                               
                            });
                        }
                        // obtenemos los datos del etalle de pedido
                        Session["PedidoD"] = Detalle;

                        // obtenemos el articulo que se selecciono en los combos
                        // vaalidamos que no sea vacio

                    }
                }
            }
            return View("Index");
        }

        // POST: ProductosPortal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {

                // instanciamos la sesion del error en null
                Session["Error"] = null;

                List<PedidosDetalle> Detalle = new List<PedidosDetalle>();
                // obtenemos los datos del etalle de pedido
                Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;
                string tipo = collection[1].ToString().Trim();


                var ancho = collection[4].ToString().Trim();
                var modelo = Session["PedidoEstilo"].ToString();
                if (ancho == "065 - Ancho Est")
                    ancho = "065";
                if ((tipo == "Enchapes HPL" || tipo == "Enchapes Full Color") && (modelo == "ESSENCE-FUSSION"))                
                    ancho = "012";
                else if ((tipo == "Enchapes HPL" || tipo == "Enchapes Full Color") && (modelo == "ORIGINAL-ORIGINAL Q-SLIM" || modelo.Contains("BASI-K")))
                    ancho = "046";



                if (collection[1].ToString().Trim() == "Enchapes HPL" || collection[1].ToString().Trim() == "Enchapes Full Color")         
                     modelo = Session["PedidoEstilo"].ToString() == "ESSENCE-FUSSION" ? "ESSENCE" : Session["PedidoEstilo"].ToString() == "ORIGINAL-ORIGINAL Q-SLIM" ? "ORIGINAL" : "BASI-K";

                     
                
                if (collection[1].ToString().Trim() == "Barra")
                {
                    tipo = "B";
                }
                else if (collection[1].ToString().Trim() == "Cubierta")
                {
                    tipo = "C";
                }
                else
                {
                    tipo = "x";
                }

               

                // obtenemos el articulo que se selecciono en los combos
                var Arts = db.GetArticulo(tipo, collection[2].ToString().Trim(), ancho, collection[3].ToString().Trim(), modelo.Trim(), collection[6].ToString().Trim(), collection[5].ToString().Trim()).ToList();
                // vaalidamos que no sea vacio
                if (Arts.Count == 0)
                {
                    
                    Session["Error"] = "'.ooops!','no se encontro el articulo','warning'";
                    return RedirectToAction("Index", new { id = Guid.Parse(Session["stiloId"].ToString()) });
                   
                }
                var Art = Arts[0]; 
                // Validamos Complementos Full Color
                if (collection[1].ToString().Contains("Full Color"))
                {
                    Art= Arts.Where(x => x.TMESubModelo == "FULL COLOR").FirstOrDefault();
                }
                else
                {
                    Art = Arts.Where(x => x.TMESubModelo != "FULL COLOR").FirstOrDefault();
                }

            
                // validamos que no se coloque cantidad en 0 o menor
                    if (decimal.Parse(collection[0].ToString()) <= 0)
                {
                    Session["Error"] = "'Error','Debe colocar una cantidad','error'";
                    return RedirectToAction("Index", new { id = Guid.Parse(Session["stiloId"].ToString()) });

                };

                if (Detalle.Where(x => x.Articulo == Art.Articulo).ToList().Count() > 0)
                {
                    Detalle.Find(d => d.Articulo == Art.Articulo).Cantidad = Detalle.Find(d => d.Articulo == Art.Articulo).Cantidad + decimal.Parse(collection[0].ToString());
                    Session["PedidoD"] = Detalle;

                    return RedirectToAction("Index", new { id = Guid.Parse(Session["stiloId"].ToString()) });


                }





                Detalle.Add(new PedidosDetalle
                {
                    Ancho = collection[4].ToString(),
                    Largo = collection[3].ToString(),
                    Cantidad = decimal.Parse(collection[0].ToString()),
                    Articulo = Art.Articulo,
                    Color = collection[2].ToString(),
                    ColorCodigo = Art.tmecolor,
                    Desripcion = Art.Descripcion1,
                    Modelo = Session["PedidoEstilo"].ToString(),
                    Clasificacion = Art.tmeclasflam

                });
                Session["PedidoD"] = Detalle;



                return RedirectToAction("Index", new { id = Guid.Parse(Session["stiloId"].ToString()) });
            }
            catch (Exception )
            {
                return View();
            }
        }


        [Route("CrearPedido")]
        [HttpPost]
        public ActionResult CrearPedido(string id)
        {
            int idEncabezado = Convert.ToInt32(id);
            var cte = db.Cte.Find(User.Identity.Name);
            var cteEnviara = -1;
            if (int.Parse(Session["Sucursal"].ToString())!=0)
                 cteEnviara = db.CteEnviarA.Find(cte.Cliente,int.Parse(Session["Sucursal"].ToString())).ID;
            

            var tipoCambio = db.Get_TipoDeCambio(cte.DefMoneda).First();
            var oc = (from ec in db.CarritoEncabezado
                      where ec.Id == idEncabezado
                      select ec.OrdenCompra).FirstOrDefault();          
            db.Database.BeginTransaction();
            var PedidoId = db.spRegistrarVentaEncabezado("TME", "Pedido", "INTERNET", "GTPPT", cte.DefMoneda, tipoCambio, cte.Descuento, 0, cte.Cliente, cte.FormaEnvio, cte.Condicion, "", "VENTAS POR INTERNET", 0, cte.Agente, cteEnviara, "", DateTime.Now, oc, oc,1, cte.ListaPreciosEsp).First();
            Session["PedidoID"] = PedidoId;
            //var Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;
            var detalleCarrito = (from cd in db.CarritoDetalle
                       where cd.idEncabezado == idEncabezado
                       select new
                       {
                           cd.articulo,
                           cd.cantidad,
                           cd.importe
                       }).ToList();
            int Renglon = 1024;
            int RenglonID = 1;
            foreach (var item in detalleCarrito)
            {
                db.spRegistrarVentaDetalle(PedidoId, Renglon, item.articulo, "PIEZA", "", "N",Double.Parse(item.cantidad.ToString()), 0, item.importe, 16, 0, 0, 0, "", "", "",1, RenglonID);

                Renglon += 1024;
                RenglonID += 1;
            }
           
            db.Database.CurrentTransaction.Commit();

            var credito = db.sp_ValidaCliente(User.Identity.Name.ToString()).First();

            if (credito == true)
                Session["Error"] = null;
            else
                Session["Error"] = "'LIMITE DE CREDITO EXCEDIDO'";

            var query = from c in db.CarritoEncabezado
                        where c.Id == idEncabezado
            select c;
            foreach (CarritoEncabezado c in query) c.ModuloID = PedidoId;
            db.SaveChanges();

            if (PedidoId != null)
            {
                if (Session["Error"]!=null)
                {

                    try
                    {
                        db.spAfectarMov(PedidoId, "CONSECUTIVO");
                    }
                    catch (Exception e)
                    {
                        return View();
                    }
                }
                else
                {
                    db.spAfectarMov(PedidoId, "CONSECUTIVO"); //AFECTAR
                }
               
            }

            Session["PedidoD"] = new List<PedidosDetalle>();           
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("PedidoMovID")]
        public ActionResult PedidoMovID(int id)
        {

            var movID = db.spGetMovIDPedido(id).FirstOrDefault();           
            return Json(movID, JsonRequestBehavior.AllowGet);
        }

        [Route("EliminarCarrito")]
        [HttpPost]
        public ActionResult EliminarCarrito(string id)
        {
            int IDCarrito = Convert.ToInt32(id);
            db.Database.BeginTransaction();
            db.spEliminarCarrito(IDCarrito);
            db.Database.CurrentTransaction.Commit();
            return RedirectToAction("Index");
        }

        [Route("ActualizaOCCarrito")]
        [HttpPost]
        public ActionResult ActualizaOCCarrito(int id,string oc)
        {
            db.Database.BeginTransaction();
            db.SetOCCarrito(id, oc);
            db.Database.CurrentTransaction.Commit();
            return RedirectToAction("Index");

        }


        [Route("ActualizaCantDetalleCarrito")]
        [HttpPost]
        public ActionResult ActualizaCantDetalleCarrito(int id, int? cantidad,double renglon)
        {
            if(cantidad==null || cantidad < 1)
            {
                EliminaDetalleCarrito(id, renglon);
            }
            db.Database.BeginTransaction();
            db.SetCantCarritoDetalle(id, cantidad,renglon);
            db.Database.CurrentTransaction.Commit();
            return RedirectToAction("Index");

        }

        [Route("EliminaDetalleCarrito")]
        [HttpPost]
        public ActionResult EliminaDetalleCarrito(int id,  double renglon)
        {
            db.Database.BeginTransaction();
            db.SetElimnaCarritoDetalle(id, renglon);
            db.Database.CurrentTransaction.Commit();
            return RedirectToAction("Index");

        }

        [Route("EnviarCarrito")]
        [HttpPost]
        public ActionResult EnviarCarrito()
        {

            var cte = db.Cte.Find(User.Identity.Name);


            var IdFirst = (from c in db.CarritoEncabezado
                           where c.Cliente == cte.Cliente.Trim()
                           && c.ModuloID == 0
                           select c.Id).FirstOrDefault();


            if (IdFirst > 0)
            {
                db.Database.BeginTransaction();
                var MaxRenglon = (from c in db.CarritoEncabezado
                                  join d in db.CarritoDetalle on c.Id equals d.idEncabezado
                                  where c.Cliente == cte.Cliente.Trim() && d.idEncabezado == IdFirst
                                  select d.renglon).Max();

                if (MaxRenglon == null)
                    MaxRenglon = 1024;
                else
                    MaxRenglon += 1024;
                var Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;
               
                foreach (var item in Detalle)
                {
                    db.sp_SetCarritoDetalle(IdFirst, item.Articulo, Convert.ToInt32(item.Cantidad), cte.Cliente, MaxRenglon, item.Desripcion);
                    MaxRenglon += 1024;
                }
                db.Database.CurrentTransaction.Commit();

            }
            else
            {
                db.Database.BeginTransaction();
                var Id = db.sp_SetCarritoEncabezado(cte.Cliente, cte.Nombre, cte.Condicion, cte.Descuento).First();
                var Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;
                int Renglon = 1024;
                foreach (var item in Detalle)
                {
                    db.sp_SetCarritoDetalle(Id, item.Articulo, Convert.ToInt32(item.Cantidad), cte.Cliente, Renglon, item.Desripcion);
                    Renglon += 1024;
                }
                db.Database.CurrentTransaction.Commit();
            }

            Session["PedidoD"] = new List<PedidosDetalle>();
            return RedirectToAction("Index", Session["PedidoD"] = new List<PedidosDetalle>());
        }


        [HttpGet]
        [Route("GetColores")]
        public ActionResult GetColores(string id)
        {
            string tipo = "";
            if (id == "Barra")
            {
                tipo = "B";
            }
            else if (id == "Cubierta")
            {
                tipo = "C";
            }
            else
            {
                tipo = "x";

            }
            var d = db.Cte.Find(Session["User"].ToString()).webEstilo;
            Session["TipoId"] = tipo;
            var colores = db.GetColorProductoNodo1(Guid.Parse(Session["stiloId"].ToString()),"", tipo, Convert.ToBoolean(d)).ToList().Select(x => new Colores { Color = x.color, Descripcion = x.descripcion, RutaImagen = x.RutaImagen }).ToList();

            return Json(colores, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Route("GetLargo")]
        public ActionResult GetLargo(string id)
        {
            Session["Color"] = id;
            var largo = db.GetLargoProductoNodo(Guid.Parse(Session["stiloId"].ToString()), id, Session["TipoId"].ToString()).ToList();
            return Json(largo, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Route("GetAncho")]
        public ActionResult GetAncho(string id)
        {
            var Ancho = db.GetAnchoProductoNodo(Guid.Parse(Session["stiloId"].ToString()), Session["Color"].ToString(), Session["TipoId"].ToString(), id).ToList();

            return Json(Ancho, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Route("GetGrid")]
        public ActionResult GetGrid()
        {
            List<PedidosDetalle> Detalle = new List<PedidosDetalle>();
            if (Session["PedidoD"] != null)
            {
                Detalle = (List<PedidosDetalle>)Session["PedidoD"] as List<PedidosDetalle>;

            }

            return Json(Detalle, JsonRequestBehavior.AllowGet);
        }


        public ActionResult FacturasPorPagarCTE()
        {
            
            return View();

        }

        [HttpGet]
        public ActionResult ComprasConcluidas(DateTime FechaD, DateTime FechaA)
        {

            var fac = db.sp_GetFacturasPorPagarCliente(User.Identity.Name,FechaD,FechaA).ToList().Select(x => new FacturasPorPagarCliente
            {
                importe = x.Total,
                impuestos = x.Impuestos,
                movid = x.MovID,
                Orden_de_compra = x.OrdenCompra,
                saldo = x.Saldo,
                FechaEmision = x.FechaEmision,
                Detalle = db.sp_GetFacturasxPagarClienteDet(x.ID).ToList().Select(y => new FacturaDetalle { Articulo = y.Articulo, Cantidad = y.Cantidad, Descripcion1 = y.Descripcion1, Precio = y.Precio, Total = y.importe }).ToList()
            }).OrderByDescending(x => x.FechaEmision).ToList();
            
            
            return Json(fac, JsonRequestBehavior.AllowGet);

        }

        public ActionResult PedidosCTE()
        {
            var fac = db.sp_GetPedidosCliente(User.Identity.Name).ToList().Select(x => new FacturasPorPagarCliente
            {
                importe =Convert.ToDouble(x.importe),
                impuestos = x.importe,
                movid = x.movid,
                Orden_de_compra = x.Orden_de_compra,
                referencia = x.referencia,
                saldo = Convert.ToDouble(x.saldo),
                FechaEmision = x.FechaEmision,
                PedidoId = x.VentaId,
                Detalle = db.sp_GetFacturasxPagarClienteDet(x.VentaId).ToList().Select(y => new FacturaDetalle { Articulo = y.Articulo, Cantidad = y.Cantidad, Descripcion1 = y.Descripcion1, Precio = y.Precio, Total = y.importe }).ToList()
            }).ToList();
            return View(fac);


        }
        public ActionResult PedidosPendientesCte()
        {
            var fac = db.sp_GetPedidosPendientesPorCliente(User.Identity.Name).ToList().Select(x => new PedidosPendientesPorCliente
            {
          
                movID = x.MovID,
                FechaEmision = x.FechaEmision,
                Concepto = x.Concepto,
                Referencia = x.Referencia,
                Observaciones = x.Observaciones,
                OrdenCompra = x.OrdenCompra,
                Condicion = x.Condicion,
                Vencimiento = x.Vencimiento,
                Descuento=x.Descuento,
                subTotal=x.subTotal,
                saldo = x.Saldo,
                importe = x.Importe,
        
                impuestos = x.Impuestos,
                FechaRequerida = x.FechaRequerida,
                Detalle = db.sp_GetFacturasxPagarClienteDet(x.ID).ToList().Select(y => new PedidosPendientesPorCliente.FacturaDetalle { Articulo = y.Articulo, Cantidad = y.Cantidad, Descripcion1 = y.Descripcion1, Precio = y.Precio,SubTotal=(y.Precio*y.Cantidad), Total = y.importe }).ToList()

            }).OrderByDescending(x=>x.FechaEmision).ToList();
            return View(fac);
        }
        public ActionResult DetalleCarrito()
        {
            var pedido = db.spGetEncabezadoCarrito(User.Identity.Name).ToList().Select(x => new DetalleCarrito
            {
                id=x.Id,
                cliente = User.Identity.Name,
                Nombre = x.Nombre,
                FechaEmision = x.FechaEmision,
                Condicion = x.Condicion,
                Descuento = x.Descuento,
                OrdenCompra=x.OrdenCompra,
                Detalle = db.spGetDetalleCarrito(x.Id).ToList().Select(y => new DetalleCarrito.FacturaDetalle {id=y.id,idEncabezado=y.idEncabezado,renglon=y.renglon, Cantidad = y.cantidad, Articulo = y.articulo, Descripcion = y.descripcion, importe = y.importe, descuento=y.descuento,impuesto = y.impuesto,ImporteTotal=y.importe+y.impuesto}).ToList()

            }).ToList();
            return View(pedido);
        }

        public ActionResult PedidoMedidasEstandar(Guid? id)
        {

            Session["PedidoEstilo"] = "";
            if (id != null)
            {
                var propNodo = db.GetPropProductoNodo1(id).ToList().First();
                Session["PedidoEstilo"] = propNodo.descripcion;
            }
            
            var ColoresEstandar = db.GetColoresMedidasEstandar(id).ToList().Select(x=> new Models.PedidoMedidasEstandar
            {
                Color=x.color,
                Descripcion=x.descripcion

            });

            return View(ColoresEstandar);
        }
        
        public ActionResult GetEqArtGen(string color,string descripcion,int cb240,int cb300,int cb360,int ba240,int ba360,int ba90 ) 
        {
            var linea = Session["PedidoEstilo"].ToString();

            var Arts = new List<sp_GetEqArtGen_Result2>();

            //var Arts = db.sp_GetEqArtGen(linea, color, descripcion, cb240, cb300, cb360, ba240, ba360, ba90).ToList();
              var Art = new List<sp_GetEqArtGen_Result2>();
            // var cantidad = cb240 > 0 ? cb240 : cb300 > 0 ? cb300 : cb360 > 0 ? cb360 : ba240 > 0 ? ba240 : ba360 > 0 ? ba360 : ba90;

            int[] medidas = { cb240, cb300, cb360, ba240, ba360, ba90 };
            int i = 0;
            foreach(int m in medidas)
            {
                
                if (i == 0 && m > 0)
                     Arts = db.sp_GetEqArtGen(linea, color, descripcion, m, 0, 0, 0, 0, 0).ToList();
                if (i == 1 && m > 0)
                    Arts = db.sp_GetEqArtGen(linea, color, descripcion, 0, m, 0, 0, 0, 0).ToList();
                if (i == 2 && m > 0)
                    Arts = db.sp_GetEqArtGen(linea, color, descripcion, 0, 0, m, 0, 0, 0).ToList();
                if (i == 3 && m > 0)
                    Arts = db.sp_GetEqArtGen(linea, color, descripcion, 0, 0, 0, m, 0, 0).ToList();
                if (i == 4 && m > 0)
                    Arts = db.sp_GetEqArtGen(linea, color, descripcion, 0, 0, 0, 0, m, 0).ToList();
                if (i == 5 && m > 0)
                    Arts = db.sp_GetEqArtGen(linea, color, descripcion, 0, 0, 0, 0, 0, m).ToList();


                




                if (m > 0)
                {
                    EnviarCarritoEstandar(Arts[0].articulo, Arts[0].descripcion, m);
                    
                }
                i++;
            }

            return Json(Arts[0].articulo, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        private void EnviarCarritoEstandar(string art,string descripcion,int cantidad)
        {
            db.Database.BeginTransaction();
            var cte = db.Cte.Find(User.Identity.Name);
            

            var IdFirst = (from c in db.CarritoEncabezado
                      where c.Cliente == cte.Cliente.Trim()
                      && c.ModuloID==0
                      select c.Id).FirstOrDefault();


            if (IdFirst >0)
            {


                var MaxRenglon = (from c in db.CarritoEncabezado
                                  join d in db.CarritoDetalle on c.Id equals d.idEncabezado
                                  where c.Cliente == cte.Cliente.Trim() && d.idEncabezado == IdFirst
                                  select d.renglon).Max();

                if (MaxRenglon == null)
                    MaxRenglon = 1024;
                else
                    MaxRenglon +=  1024;

                db.sp_SetCarritoDetalle(IdFirst, art, cantidad, cte.Cliente, MaxRenglon, descripcion);
            }
            else
            {
                double Renglon = 1024;
                var Id = db.sp_SetCarritoEncabezado(cte.Cliente, cte.Nombre, cte.Condicion, cte.Descuento).First();   
                db.sp_SetCarritoDetalle(Id, art, cantidad, cte.Cliente, Renglon, descripcion);
              
            }
            db.Database.CurrentTransaction.Commit();
           
        }
        public ActionResult PedidoAfectado()
        {
     
            var mov = db.spPEdidoAfectado(Convert.ToInt32(Session["PedidoID"].ToString())).ToList().Select(x => new PedidoAfectado
            {

                movID = x.MovID,
                FechaEmision = x.FechaEmision,
                Concepto = x.Concepto,
                Referencia = x.Referencia,
                Observaciones = x.Observaciones,
                OrdenCompra = x.OrdenCompra,
                Condicion = x.Condicion,
                Vencimiento = x.Vencimiento,
                saldo = x.Saldo,
                importe = x.Importe,
                impuestos = x.Impuestos,
                FechaRequerida = x.FechaRequerida,
                Detalle = db.sp_GetFacturasxPagarClienteDet(x.ID).ToList().Select(y => new PedidoAfectado.FacturaDetalle { Articulo = y.Articulo, Cantidad = y.Cantidad, Descripcion1 = y.Descripcion1, Precio = y.Precio, Total = y.importe }).ToList()
            }).ToList();

            return View(mov);
        }


    }
}