using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trabalho_pratrico_MVC.Models;

namespace trabalho_pratrico_MVC.Controllers
{
    public class RegistarController : Controller
    {
        RegistarBD bd = new RegistarBD();

        // GET: Utilizadores
        public ActionResult Index()
        {  
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegistarModel dados)
        {
            if (ModelState.IsValid)
            {
                bd.adicionarUtilizador(dados);
                return RedirectToAction("Index");
            }
            return View(dados);
        }
    }
}