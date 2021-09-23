using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class CompetenciaController : Controller
    {
        private CompetenciaServico competenciaServico = new CompetenciaServico();

        // GET: Competencia
        public ActionResult Index()
        {
            return View(competenciaServico.ObterCompetenciasClassificadasPorNome());
        }

        private ActionResult ObterVisaoCompetenciaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competencia competencia = competenciaServico.ObterCompetenciaPorId((long)id);
            if (competencia == null)
            {
                return HttpNotFound();
            }
            return View(competencia);
        }

        ActionResult GravarCompetencia(Competencia competencia)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    competenciaServico.GravarCompetencia(competencia);
                    return RedirectToAction("Index");
                }
                return View(competencia);
            }
            catch
            {
                return View(competencia);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoCompetenciaPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Competencia competencia)
        {
            return GravarCompetencia(competencia);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCompetenciaPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Competencia competencia)
        {
            return GravarCompetencia(competencia);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCompetenciaPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Competencia competencia = competenciaServico.EliminarCompetenciaPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}