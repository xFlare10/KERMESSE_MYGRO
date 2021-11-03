using KERMESSE_MYGRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KERMESSE_MYGRO.Controllers
{
    public class Tbl_Rol_OpcionController : Controller
    {
        private KERMESSEEntities db = new KERMESSEEntities();
        // GET: Tbl_Rol_Opcion
        public ActionResult Tbl_Rol_Opcion()
        {
            return View(db.tbl_rol_opcion.ToList());
        }


        public ActionResult VistaInsertRolOpciones()
        {
            ViewBag.id_opcion = new SelectList(db.tbl_opciones, "id_opciones", "opcion");
            ViewBag.id_rol = new SelectList(db.tbl_rol, "id_rol", "rol");
            return View();

        }

        public ActionResult InsertRolOpciones()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertRolOpciones(tbl_rol_opcion tro)
        {
            if (ModelState.IsValid)
            {
                tbl_rol_opcion ro = new tbl_rol_opcion();
                ro.id_opcion = tro.id_opcion;
                ro.id_rol = tro.id_rol;

                db.tbl_rol_opcion.Add(ro);
                db.SaveChanges();

                ModelState.Clear();
                return RedirectToAction("Tbl_Rol_Opcion");
            }

            ViewBag.id_opcion = new SelectList(db.tbl_opciones, "id_opciones", "opcion");
            ViewBag.id_rol = new SelectList(db.tbl_rol, "id_rol", "rol");
            return View("VistaInsertRolOpciones");
        }


        public ActionResult DeleteRolOpciones(int id)
        {
            tbl_rol_opcion tro = new tbl_rol_opcion();
            tro = db.tbl_rol_opcion.Find(id);
            db.tbl_rol_opcion.Remove(tro);

            db.SaveChanges();
            var list = db.tbl_rol_opcion.ToList();
            return View("Tbl_Rol_Opcion", list);
        }

        public ActionResult VerRolOpciones(int id)
        {
            var vro = db.tbl_rol_opcion.Where(x => x.id_rol_opcion == id).First();
            return View(vro);

        }


    }
}