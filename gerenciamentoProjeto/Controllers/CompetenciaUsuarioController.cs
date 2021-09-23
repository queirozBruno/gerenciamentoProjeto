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
    public class CompetenciaUsuarioController : Controller
    {
        private CompetenciaUsuarioServico competenciaUsuarioServico = new CompetenciaUsuarioServico();
        private CompetenciaServico competenciaServico = new CompetenciaServico();
        private UsuarioServico usuarioServico = new UsuarioServico();

        // GET: CompetenciaUsuario
        public ActionResult Index()
        {
            return View(competenciaUsuarioServico.ObterCompetenciaUsuariosClassificadosPorNome());
        }

        private ActionResult ObterVisaoCompetenciaUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompetenciaUsuario competenciaUsuario = competenciaUsuarioServico.ObterCompetenciaUsuarioPorId((long)id);
            if (competenciaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(competenciaUsuario);
        }

        ActionResult GravarCompetenciaUsuario(CompetenciaUsuario competenciaUsuario)
        {
            try
            {
                bool verificaCompetencia = competenciaServico.VerificaSeCompetenciaExiste(competenciaUsuario.competencia.CompetenciaNome);
                if (verificaCompetencia == false) //Não existe
                {
                    competenciaServico.GravarCompetencia(competenciaUsuario.competencia);
                    competenciaUsuario.CompetenciaId = competenciaUsuario.competencia.CompetenciaId;
                }
                else
                {
                    Competencia competencia = competenciaServico.ObterCompetenciaPorNome(competenciaUsuario.competencia.CompetenciaNome);
                    competenciaUsuario.CompetenciaId = competencia.CompetenciaId;
                }


                competenciaUsuario.competencia = null;
                competenciaUsuario.UsuarioId = (long)Session["ID"];

                if (ModelState.IsValid)
                {
                    competenciaUsuarioServico.GravarCompetenciaUsuario(competenciaUsuario);
                    return RedirectToAction("Details", "Usuario");
                }
                return View(competenciaUsuario);
            }
            catch
            {
                return View(competenciaUsuario);
            }
        }

        private void PopularViewBag(CompetenciaUsuario competenciaUsuario = null)
        {
            if (competenciaUsuario == null)
            {
                ViewBag.CompetenciaId = new SelectList(competenciaServico.ObterCompetenciasClassificadasPorNome(), "CompetenciaId", "CompetenciaNome");
                ViewBag.UsuarioId = new SelectList(usuarioServico.ObterUsuariosClassificadosPorNome(), "UsuarioId", "UsuarioNome");
            }
            else
            {
                ViewBag.CursoId = new SelectList(competenciaServico.ObterCompetenciasClassificadasPorNome(), "CompetenciaId", "CompetenciaNome", competenciaUsuario.CompetenciaId);
                ViewBag.UsuarioId = new SelectList(usuarioServico.ObterUsuariosClassificadosPorNome(), "UsuarioId", "Nome", competenciaUsuario.UsuarioId);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoCompetenciaUsuarioPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(CompetenciaUsuario competenciaUsuario)
        {
            return GravarCompetenciaUsuario(competenciaUsuario);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            PopularViewBag(competenciaUsuarioServico.ObterCompetenciaUsuarioPorId((long)id));
            return ObterVisaoCompetenciaUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(CompetenciaUsuario competenciaUsuario)
        {
            return GravarCompetenciaUsuario(competenciaUsuario);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCompetenciaUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                CompetenciaUsuario competenciaUsuario = competenciaUsuarioServico.EliminarCompetenciaUsuarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}