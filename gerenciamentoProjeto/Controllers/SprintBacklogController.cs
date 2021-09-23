using Modelo.Tabelas;
using Servico.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace gerenciamentoProjeto.Controllers
{
    public class SprintBacklogController : Controller
    {
        private SprintBacklogServico sprintBacklogServico = new SprintBacklogServico();

        // GET: SprintBacklog
        public ActionResult Index(long? id)
        {
            if (id == null)
                id = (long?)Session["IDSprint"];
            else
                Session["IDSprint"] = id;
            return View(sprintBacklogServico.ObterSprintBacklogPorSprintIdOrdenadoPorEstimativa((long)id));
        }

        private ActionResult ObterVisaoSprintBacklogPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SprintBacklog sprintBacklog = sprintBacklogServico.ObterSprintBacklogPorId((long)id);
            if (sprintBacklog == null)
            {
                return HttpNotFound();
            }
            return View(sprintBacklog);
        }

        ActionResult GravarSprintBacklog(SprintBacklog sprintBacklog)
        {
            try
            {
                sprintBacklog.SprintId = (long)Session["IDSprint"];
                if (ModelState.IsValid)
                {                    
                    long id = (long)Session["IDSprint"];
                    sprintBacklogServico.GravarSprintBacklog(sprintBacklog);
                    return RedirectToAction("Create");
                }
                return View(sprintBacklog);
            }
            catch
            {
                return View();
            }
        }

        ActionResult GravarEditarSprintBacklog(SprintBacklog sprintBacklog)
        {
            try
            {
                sprintBacklog.SprintId = (long)Session["IDSprint"];
                if (ModelState.IsValid)
                {
                    long id = (long)Session["IDSprint"];
                    sprintBacklogServico.GravarSprintBacklog(sprintBacklog);
                     return RedirectToAction("index", id);
                }
                return View(sprintBacklog);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoSprintBacklogPorId(id);
        }

        //GET
        public ActionResult Create()
        {            
            ViewBag.SprintBacklog = sprintBacklogServico.ObterSprintBacklogPorSprintIdOrdenadoPorEstimativa((long)Session["IDSprint"]);
            ViewBag.ProductBacklog = sprintBacklogServico.ObterProductBacklogPorScrum((long)Session["IDScrum"]);
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(SprintBacklog sprintBacklog)
        {
            return GravarSprintBacklog(sprintBacklog);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoSprintBacklogPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(SprintBacklog sprintBacklog)
        {
            return GravarEditarSprintBacklog(sprintBacklog);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoSprintBacklogPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                SprintBacklog sprintBacklog = sprintBacklogServico.EliminarSprintBacklogPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}