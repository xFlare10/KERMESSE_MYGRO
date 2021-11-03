using KERMESSE_MYGRO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KERMESSE_MYGRO.Controllers
{
    public class Tbl_UsuarioController : Controller
    {
        private KERMESSEEntities db = new KERMESSEEntities();
        // GET: Tbl_Usuario
        public ActionResult Tbl_Usuario()
        {
            return View(db.tbl_usuario.ToList());
        }

        public ActionResult InsertUsuario()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertUsuario(tbl_usuario usr)
        {
            if (ModelState.IsValid)
            {
                tbl_usuario tbu = new tbl_usuario();
                tbu.usuario = usr.usuario;
                tbu.nombres = usr.nombres;
                tbu.apellidos = usr.apellidos;
                tbu.email = usr.email;
                tbu.pwd = usr.pwd;
                tbu.estado = 1;

                db.tbl_usuario.Add(tbu);
                db.SaveChanges();
            }

            ModelState.Clear();

            var list = db.tbl_usuario.ToList();

            return View("Tbl_Usuario", list);
        }


        public ActionResult DeleteUsuario(int id)
        {
            tbl_usuario user = new tbl_usuario();
            user = db.tbl_usuario.Find(id);
            db.tbl_usuario.Remove(user);

            db.SaveChanges();
            var list = db.tbl_usuario.ToList();
            return View("Tbl_Usuario", list);
        }

        public ActionResult VerUsuario(int id)
        {
            var user = db.tbl_usuario.Where(x => x.id_usuario == id).First();
            return View(user);

        }

        public ActionResult EditUsuario(int id)
        {
            tbl_usuario tbu = db.tbl_usuario.Find(id);

            if (tbu == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tbu);
            }

        }

        [HttpPost]
        public ActionResult UpdateUsuario(tbl_usuario tbu)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbu.estado = 2;
                    db.Entry(tbu).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Tbl_Usuario");
            }
            catch
            {
                return View();
            }
        }
    }

}