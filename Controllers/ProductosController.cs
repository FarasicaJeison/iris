using Iris.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iris.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
                return View();
        }

        public JsonResult chargeParameters()

        {
            var repository = new ProductosServicios();
            var listParameters = repository.listaproductos();
            return Json(listParameters, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GuardarPersona(string pasinume, string pasinomb, string pasiapel, DateTime pasifech, string pasidire)
        {
            var GuardarPersonas = new ProductosServicios();
            var pasinume2 = Int32.Parse(pasinume);

            var addPersona = GuardarPersonas.agregarPaciente(pasinume2, pasinomb, pasiapel, pasifech, pasidire);
            return Json(addPersona, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditarPersona(int pasinume)
        {
            var GuardarPersonas = new ProductosServicios();
            var addPersona = GuardarPersonas.listarproductos(pasinume, 3);
            return Json(addPersona, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ultimo(int idpersona)
        {
            var GuardarPersonas = new ProductosServicios();
            var addPersona = GuardarPersonas.listarproductos(0, 5);
            return Json(addPersona, JsonRequestBehavior.AllowGet);
        }

        public JsonResult eliminarPersona(int pasinume)
        {
            var GuardarPersonas = new ProductosServicios();
            var addPersona = GuardarPersonas.eliminarPersona(pasinume);
            return Json(addPersona, JsonRequestBehavior.AllowGet);
        }

    }
}