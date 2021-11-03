using KERMESSE_MYGRO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KERMESSE_MYGRO.Controllers
{
    public class Tbl_RolController : Controller
    {
        private KERMESSEEntities db = new KERMESSEEntities();
        // GET: Tbl_Rol
        public ActionResult Tbl_Rol()
        {
            return View(db.tbl_rol.ToList());
        }

        public ActionResult InsertRol()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertRol(tbl_rol rld)
        {
            if (ModelState.IsValid)
            {
                tbl_rol tbr = new tbl_rol();
                tbr.rol = rld.rol;
                tbr.estado = 1;

                db.tbl_rol.Add(tbr);
                db.SaveChanges();

                ModelState.Clear();
            }

            

            var list = db.tbl_rol.ToList();

            return View("Tbl_Rol", list);
        }


        public ActionResult DeleteRol(int id)
        {
            tbl_rol rol = new tbl_rol();
            rol = db.tbl_rol.Find(id);
            db.tbl_rol.Remove(rol);

            db.SaveChanges();
            var list = db.tbl_rol.ToList();
            return View("Tbl_Rol", list);
        }

        public ActionResult VerRol(int id)
        {
            var rol = db.tbl_rol.Where(x => x.id_rol== id).First();
            return View(rol);

        }

        public ActionResult EditRol(int id)
        {
            tbl_rol tbr = db.tbl_rol.Find(id);

            if (tbr == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tbr);
            }

        }

        [HttpPost]
        public ActionResult UpdateRol(tbl_rol tbr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tbr.estado = 2;
                    db.Entry(tbr).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Tbl_Rol");
            }
            catch
            {
                return View();
            }
        }
    }

}