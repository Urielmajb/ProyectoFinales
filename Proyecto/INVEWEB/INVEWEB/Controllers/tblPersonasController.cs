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

    //[Authorize(Roles = "Administrador, SubAdmin")]

    public class tblPersonasController : Controller
    {

        private tblPersonas Opersonas = new tblPersonas();
        // GET: tblPersonas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult tblPersonasListar()
        {
            return View(Opersonas.Listar());
        }
        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblPersonaVer(int ID)
        {
            return View(Opersonas.Obtener(ID));
        }
        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblPersonaAdd(int ID = 0)
        {
            return View(ID == 0 ? new tblPersonas() : Opersonas.Obtener(ID));
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public JsonResult Guardar(tblPersonas model)
        {
            var rm = new JsonModel();
            if (ModelState.IsValid)
            {
                rm = model.Guardar();
                if (rm.response)
                {
                    rm.href = Url.Content("~/tblPersonas/tblPersonasListar");
                }
            }
            return Json(rm);
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult tblPersonasliminar(int ID)
        {
            Opersonas.IDPersona = ID;
            Opersonas.Eliminar();
            return Redirect("~/tblPersonas/tblPersonasListar");
        }

        public ActionResult ReportePersona()
        {
            return View(Opersonas.Listar());
        }

        [Authorize(Roles = "Administrador, SubAdmin")]

        public ActionResult Print()
        {
            return new ActionAsPdf("tblPersonasListar")
            {
                FileName = Server.MapPath("~/Content/Personas.pdf")
            };
        }

    }
}