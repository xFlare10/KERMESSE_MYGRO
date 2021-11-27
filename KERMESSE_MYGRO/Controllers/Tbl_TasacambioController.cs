using KERMESSE_MYGRO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KERMESSE_MYGRO.Controllers
{
    public class Tbl_TasacambioController : Controller
    {
        private KERMESSEEntities db = new KERMESSEEntities();
        // GET: Tbl_Tasacambio
        public ActionResult Tbl_Tasacambio()
        {
            return View(db.tbl_tasacambio.Where(model=>model.estado != 3));
        }

        void Combobox()
        {
            ViewBag.id_monedaO = new SelectList(db.tbl_moneda.Where(model => model.estado != 3), "id_moneda", "nombre");
            ViewBag.id_monedaC = new SelectList(db.tbl_moneda.Where(model => model.estado != 3), "id_moneda", "nombre");
        }

        public ActionResult InsertTasaCambio()
        {
            Combobox();
            return View();
        }

     
        public ActionResult InsertTasaCambioA(int monedaO, int monedaC, int mes, int anio, tbl_tasacambio_det[] tcdet)
        {
            ViewBag.id_monedaO = new SelectList(db.tbl_moneda.Where(model => model.estado != 3), "id_moneda", "nombre");
            ViewBag.id_monedaC = new SelectList(db.tbl_moneda.Where(model => model.estado != 3), "id_moneda", "nombre");
            string result = "Error! Order Is Not Complete!";

            tbl_tasacambio tc = new tbl_tasacambio();

                tc.id_monedaO = monedaO;
                tc.id_monedaC = monedaC;
                tc.mes = mes;
                tc.anio = anio;
                tc.estado = 1;
                db.tbl_tasacambio.Add(tc);

                foreach(var item in tcdet)
                {
                    tbl_tasacambio_det det = new tbl_tasacambio_det();
                    det.id_tasacambio = tc.id_tasacambio;
                    det.fecha = item.fecha;
                    det.tipo_cambio = item.tipo_cambio;
                    det.estado = 1;
                    db.tbl_tasacambio_det.Add(det);
                }
                db.SaveChanges();

            result = "Success! Order Is Complete!";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteTasaCambio(int id)
        {
            tbl_tasacambio tc = new tbl_tasacambio();
            tc = db.tbl_tasacambio.Find(id);
            this.DeleteLogTasaCambio(tc);

            return RedirectToAction("Tbl_Tasacambio");
        }

        public ActionResult DeleteDet(int id)
        {
            //Esto borra de forma directa
            //Si se quiere borrar de manera logica hay que ajustar el parametro de la vista para que no muestre los estados 3
            // y claramente cambiar el codigo de abajo con el de DeleteTasaCambio
            tbl_tasacambio_det tde = new tbl_tasacambio_det();
            tde = db.tbl_tasacambio_det.Find(id);
            db.tbl_tasacambio_det.Remove(tde);

            db.SaveChanges();
            var list = db.vw_tasacambiodet.ToList();
            return RedirectToAction("VerTasaCambio/"+id);
        }

        public ActionResult DeleteLogTasaCambio(tbl_tasacambio ttc)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ttc.estado = 3;
                    db.Entry(ttc).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Tbl_Tasacambio");
            }
            catch (Exception)
            {
                return View();
                throw;
            }
        }

        public ActionResult EditTasaCambioM(int id)
        {
            Combobox();
            tbl_tasacambio tcc = db.tbl_tasacambio.Find(id);

            if (tcc == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tcc);
            }

        }

        public ActionResult EditTasaCambioD (int id)
        {
            Combobox();
            tbl_tasacambio_det tbd = db.tbl_tasacambio_det.Find(id);

            if (tbd == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(tbd);
            }
        }

        [HttpPost]
        public ActionResult UpdateTasaCambioM(tbl_tasacambio tbc)
        {
            Combobox();
            try
            {
                if (ModelState.IsValid)
                {
                    tbc.estado = 2;
                    db.Entry(tbc).State = EntityState.Modified;
                    db.SaveChanges();

                }
                return RedirectToAction("Tbl_Tasacambio");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateDet(tbl_tasacambio_det tde)
        {
            Combobox();
            try
            {
                if (ModelState.IsValid)
                {
                    tde.estado = 2;
                    db.Entry(tde).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("VerTasaCambio/"+tde.id_tasacambio);
            }
            catch
            {
                return null;
            }
        }

        public ActionResult InsertDet(tbl_tasacambio_det det, int id)
        {
            if (ModelState.IsValid)
            {
                tbl_tasacambio_det tde = new tbl_tasacambio_det();
                tde.id_tasacambio = id;
                tde.fecha = det.fecha;
                tde.tipo_cambio = det.tipo_cambio;
                tde.estado = 1;

                db.tbl_tasacambio_det.Add(tde);
                db.SaveChanges();
            }

            ModelState.Clear();


            return View("VerTasaCambio/"+id);
        }

        public ActionResult VerTasacambio(int id)
        {
            var tasa = db.vw_tasacambiodet.Where(x => x.id_tasaCambio == id);
            return View(tasa);

        }
    }

}

