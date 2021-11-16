using KERMESSE_MYGRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KERMESSE_MYGRO.Controllers
{
    public class Tbl_OpcionesController : Controller
    {
        private KERMESSEEntities db = new KERMESSEEntities();
        // GET: Tbl_Opciones
        public ActionResult Tbl_Opciones()
        {
            return View(db.tbl_opciones.ToList());
        }

        public ActionResult DeleteOpciones(int id)
        {
            tbl_opciones opc = new tbl_opciones();
            opc = db.tbl_opciones.Find(id);
            db.tbl_opciones.Remove(opc);

            db.SaveChanges();
            var list = db.tbl_opciones.ToList();
            return View("Tbl_Opciones", list);
        }
    }
}