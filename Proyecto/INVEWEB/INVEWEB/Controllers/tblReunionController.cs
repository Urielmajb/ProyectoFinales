using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Rotativa;
//using Rotativa;

namespace INVEWEB.Views
{
    //[Authorize(Roles = "Administrador, SubAdmin")]

    public class tblReunionController : Controller
    {
        private tblReunion Oreunion = new tblReunion();
        private tblEquipo Oequipo = new tblEquipo();
        private tblPersonas Opersonas = new tblPersonas();

        //private IEnumerable<SelectListItem> tblEquipo;

        // GET: tblReunion
        public ActionResult Index()
        {
            return View();
        }

      

        public ActionResult tblReunionListar()
        {
            return View(Oreunion.Listar());
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblReunionVer(int ID)
        {
            ViewBag.Equipo = Oequipo.ListadoCmbEquipo();
            ViewBag.Persona = Opersonas.ListadoCmbPersonas();
            return View(Oreunion.Obtener(ID));
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblReunionAdd(int ID = 0)
        {
            ViewBag.Equipo = Oequipo.ListadoCmbEquipo();
            ViewBag.Persona = Opersonas.ListadoCmbPersonas();

            return View(ID == 0 ? new tblReunion() : Oreunion.Obtener(ID));
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public JsonResult Guardar(tblReunion model)
        {
            var rm = new JsonModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/tblReunion/tblReunionListar");
                }
            }
            return Json(rm);
        }
        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblReunionEliminar(int ID)
        {
            Oreunion.IDReunion = ID;
            Oreunion.Eliminar();
            return Redirect("~/tblReunion/tblReunionListar");
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult Print()
        {
            return new ActionAsPdf("tblReunionListar")
            {
                FileName = Server.MapPath("~/Content/Reuniones.pdf")
            };
        }
    }
}