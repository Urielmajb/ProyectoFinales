using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Rotativa;
//using Rotativa;

namespace INVEWEB.Controllers
{
    //[Authorize (Roles ="Administrador, SubAdmin")]
    public class tblEquipoController : Controller
    {

        private tblEquipo Oequipo = new tblEquipo();

        // GET: tblEquipo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tblEquipoListar ()
        {
            return View(Oequipo.Listar());
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblEquipoVer(int ID)
        {
            return View(Oequipo.Obtener(ID));
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblEquiposAdd(int ID = 0)
        {
            return View(ID == 0 ? new tblEquipo() : Oequipo.Obtener(ID));
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public JsonResult Guardar(tblEquipo model)
        {
            var rm = new JsonModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/tblEquipo/tblEquipoListar");
                }
            }
            return Json(rm);
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblEquipoEliminar(int ID)
        {
            Oequipo.ID_Equipo = ID;
            Oequipo.Eliminar();
            return Redirect("~/tblEquipo/tblEquipoListar");
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult PrintListado()
        {
            return new ActionAsPdf("tblEquipoListar")
            {
                FileName = Server.MapPath("~/Content/Equipos.pdf")
            };
        }

        [Authorize(Roles = "Administrador, SubAdmin")]
        public ActionResult Print (int ID)
        {
            return new ActionAsPdf("tblEquipoVer", new { ID = ID })
            {
                FileName = Server.MapPath("~/Content/Equipos.pdf")
            };
        }




    }
}