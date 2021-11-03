using KERMESSE_MYGRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KERMESSE_MYGRO.Controllers
{
    public class Tbl_Rol_UsuarioController : Controller
    {
        private KERMESSEEntities db = new KERMESSEEntities();
        // GET: Tbl_Rol_Usuario
        public ActionResult Tbl_Rol_Usuario()
        {
            return View(db.tbl_rol_usuario.ToList());
        }


        public ActionResult VistaInsertRolUsuario()
        {
            ViewBag.id_usuario = new SelectList(db.tbl_usuario, "id_usuario", "usuario");
            ViewBag.id_rol = new SelectList(db.tbl_rol, "id_rol", "rol");
            return View();

        }

        public ActionResult InsertRolUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertRolUsuario(tbl_rol_usuario tru)
        {
            if (ModelState.IsValid)
            {
                tbl_rol_usuario tr = new tbl_rol_usuario();
                tr.id_usuario = tru.id_usuario;
                tr.id_rol = tru.id_rol;

                db.tbl_rol_usuario.Add(tr);
                db.SaveChanges();

                ModelState.Clear();
                return RedirectToAction("Tbl_Rol_Usuario");
            }

            ViewBag.id_usuario = new SelectList(db.tbl_usuario, "id_usuario", "usuario");
            ViewBag.id_rol = new SelectList(db.tbl_rol, "id_rol", "rol");
            return View("VistaInsertRolUsuario");
        }


        public ActionResult DeleteRolUsuario(int id)
        {
            tbl_rol_usuario tru = new tbl_rol_usuario();
            tru = db.tbl_rol_usuario.Find(id);
            db.tbl_rol_usuario.Remove(tru);

            db.SaveChanges();
            var list = db.tbl_rol_usuario.ToList();
            return View("Tbl_Rol_Usuario", list);
        }

        public ActionResult VerRolUsuario(int id)
        {
            var vru = db.tbl_rol_usuario.Where(x => x.id_rol_usuario == id).First();
            return View(vru);

        }


    }
}