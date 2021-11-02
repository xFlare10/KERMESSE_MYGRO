using KERMESSE_MYGRO.Models;
using System;
using System.Collections.Generic;
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
    }
}