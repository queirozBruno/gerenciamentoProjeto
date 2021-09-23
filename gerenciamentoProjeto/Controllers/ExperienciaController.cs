using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class ExperienciaController : Controller
    {
        private ExperienciaServico experienciaServico = new ExperienciaServico();
        private UsuarioServico usuarioServico = new UsuarioServico();

        // GET: Experiencia
        public ActionResult Index()
        {
            return View(experienciaServico.ObterExperinciasClassificadasPorNome());
        }

        private ActionResult ObterVisaoExperienciaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Experiencia experiencia = experienciaServico.ObterExperienciaPorId((long)id);
            if (experiencia == null)
            {
                return HttpNotFound();
            }
            return View(experiencia);
        }

        ActionResult GravarExperiencia(Experiencia experiencia)
        {
            try
            {
                long id = (long)Session["ID"];
                experiencia.UsuarioId = (long)Session["ID"];
                if (ModelState.IsValid)
                {
                    experienciaServico.GravarExperiencia(experiencia);
                    return RedirectToAction("Details", "Usuario", id);
                }
                return View(experiencia);
            }
            catch
            {
                return View(experiencia);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoExperienciaPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Experiencia experiencia)
        {
            return GravarExperiencia(experiencia);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoExperienciaPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Experiencia experiencia)
        {
            return GravarExperiencia(experiencia);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoExperienciaPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Experiencia experiencia = experienciaServico.EliminarExperienciaPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}