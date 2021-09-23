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
    public class FormacaoAcademicaController : Controller
    {
        private FormacaoAcademicaServico formacaoAcademicaServico = new FormacaoAcademicaServico();
        private UsuarioServico usuarioServico = new UsuarioServico();

        // GET: FormacaoAcademica
        public ActionResult Index()
        {
            return View(formacaoAcademicaServico.ObterFormacoesAcademicasClassificadasPorNome());
        }

        private ActionResult ObterVisaoFormacaoAcademicaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormacaoAcademica formacaoAcademica = formacaoAcademicaServico.ObterFormacaoAcademicaPorId((long)id);
            if (formacaoAcademica == null)
            {
                return HttpNotFound();
            }
            return View(formacaoAcademica);
        }

        ActionResult GravarFormacaoAcademica(FormacaoAcademica formacaoAcademica)
        {
            try
            {
                formacaoAcademica.UsuarioId = (long)Session["ID"];
                if (ModelState.IsValid)
                {
                    formacaoAcademicaServico.GravarFormacaoAcademica(formacaoAcademica);
                    return RedirectToAction("Details", "Usuario", formacaoAcademica.UsuarioId);
                }
                return View(formacaoAcademica);
            }
            catch
            {
                return View(formacaoAcademica);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoFormacaoAcademicaPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(FormacaoAcademica formacaoAcademica)
        {
            return GravarFormacaoAcademica(formacaoAcademica);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoFormacaoAcademicaPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(FormacaoAcademica formacaoAcademica)
        {
            return GravarFormacaoAcademica(formacaoAcademica);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoFormacaoAcademicaPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                FormacaoAcademica formacaoAcademica = formacaoAcademicaServico.EliminarFormacaoAcademicaPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}