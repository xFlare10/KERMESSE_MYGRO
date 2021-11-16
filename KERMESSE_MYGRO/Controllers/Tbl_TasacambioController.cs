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

        public ActionResult InsertTasaCambio()
        {
            ViewBag.id_monedaO = new SelectList(db.tbl_moneda.Where(model=>model.estado != 3), "id_moneda", "nombre");
            ViewBag.id_monedaC = new SelectList(db.tbl_moneda.Where(model => model.estado != 3), "id_moneda", "nombre");
            return View();
        }

     
        public ActionResult InsertTasaCambioA(int monedaO, int monedaC, int mes, int anio, tbl_tasacambio_det[] tcdet)
        {
            ViewBag.id_monedaO = new SelectList(db.tbl_moneda, "id_moneda", "nombre");
            ViewBag.id_monedaC = new SelectList(db.tbl_moneda, "id_moneda", "nombre");
            string result = "Error! Order Is Not Complete!";
            tbl_tasacambio tc = new tbl_tasacambio();

                tc.id_monedaO = monedaO;
                tc.id_monedaC = monedaC;
                tc.mes = mes;
                tc.anio = anio;
                tc.estado = 1;

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
            
    }

}

