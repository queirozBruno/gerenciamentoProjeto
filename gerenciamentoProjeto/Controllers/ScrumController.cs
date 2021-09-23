using Modelo.Tabelas;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace gerenciamentoProjeto.Controllers
{
    public class ScrumController : Controller
    {
        // GET: Scrum
        private ScrumServico scrumServico = new ScrumServico();
        private ProductBacklog productBacklog = new ProductBacklog();
        public ActionResult Index()
        {
            //SesioscrumServico.RecuperaIdScrum((long)Session["IDProjeto"])
            if (scrumServico.VerificarSeExisteScrum((long)Session["IDProjeto"]) == true)
                return RedirectToAction("Index/" + scrumServico.RecuperaIdScrum((long)Session["IDProjeto"]), "ProductBacklog");          
            else return View("Index");
        }

        private ActionResult ObterVisaoScrumPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scrum scrum = scrumServico.ObterScrumPorId((long)id);
            if (scrum == null)
            {
                return HttpNotFound();
            }
            return View(scrum);
        }

        ActionResult GravarScrum(Scrum scrum)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    scrumServico.GravarScrum(scrum);
                    return RedirectToAction("Index");
                }
                return View(scrum);
            }
            catch
            {
                return View(scrum);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoScrumPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Scrum scrum, long id)
        {
            scrum.ProjetoId = id;
            return GravarScrum(scrum);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoScrumPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Scrum scrum)
        {
            return GravarScrum(scrum);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoScrumPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Scrum scrum = scrumServico.EliminarScrumPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}