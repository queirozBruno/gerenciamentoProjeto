using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gerenciamentoProjeto.Controllers
{
    public class MenuController : Controller
    {
        private AmizadeServico amizadeServico = new AmizadeServico();
        // GET: Menu
        public ActionResult Index()
        {
            ViewBag.Pendentes = amizadeServico.ObterQuantidadeAmizadesPendentes((long)Session["ID"]);
            return View();
        }
    }
}