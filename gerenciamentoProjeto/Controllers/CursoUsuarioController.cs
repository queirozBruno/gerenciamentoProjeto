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
    public class CursoUsuarioController : Controller
    {
        private CursoUsuarioServico cursoUsuarioServico = new CursoUsuarioServico();
        private UsuarioServico usuarioServico = new UsuarioServico();

        // GET: Curso
        public ActionResult Index()
        {
            return View(cursoUsuarioServico.ObterVisaoCursoUsuario());
        }

        private ActionResult ObterVisaoCursoUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CursoUsuario cursoUsuario = cursoUsuarioServico.ObterCursoUsuarioPorId((long)id);
            if (cursoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(cursoUsuario);
        }

        private void PopularViewBag(CursoUsuario cursoUsuario = null)
        {
            if (cursoUsuario == null)
            {
                ViewBag.CursoUsuarioId = new SelectList(cursoUsuarioServico.ObterCursoUsuarioClassificadosPorNome(), "CursoUsuarioId", "CursoNome");
                ViewBag.UsuarioId = new SelectList(usuarioServico.ObterUsuariosClassificadosPorNome(), "UsuarioId", "UsuarioNome");
            }
            else
            {
                ViewBag.CursoUsuarioId = new SelectList(cursoUsuarioServico.ObterCursoUsuarioClassificadosPorNome(), "CursoUsuarioId", "CursoNome", cursoUsuario.CursoUsuarioId);
                ViewBag.UsuarioId = new SelectList(usuarioServico.ObterUsuariosClassificadosPorNome(), "UsuarioId", "Nome", cursoUsuario.UsuarioId);
            }
        }

        ActionResult GravarCursoUsuario(CursoUsuario cursoUsuario)
        {
            try
            {
                cursoUsuario.UsuarioId = (long)Session["ID"];
                if (ModelState.IsValid)
                {
                    cursoUsuarioServico.GravarCursoUsuario(cursoUsuario);
                    return RedirectToAction("Details", "Usuario", null);
                }
                return View(cursoUsuario);
            }
            catch
            {
                return View(cursoUsuario);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoCursoUsuarioPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(CursoUsuario cursoUsuario)
        {
            return GravarCursoUsuario(cursoUsuario);
        }

        //GET
        public ActionResult Edit(long? id)
        {  
            return ObterVisaoCursoUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(CursoUsuario cursoUsuario)

        {
            return GravarCursoUsuario(cursoUsuario);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCursoUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                CursoUsuario cursoUsuario = cursoUsuarioServico.EliminarCursoUsuarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}