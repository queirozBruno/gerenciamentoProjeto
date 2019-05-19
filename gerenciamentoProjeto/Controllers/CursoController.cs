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
    public class CursoController : Controller
    {
        private CursoServico cursoServico = new CursoServico();

        // GET: Curso
        public ActionResult Index()
        {
            return View(cursoServico.ObterCursosClassificadosPorNome());
        }

        private ActionResult ObterVisaoCursoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = cursoServico.ObterCursoPorId((long)id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        ActionResult GravarCurso(Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cursoServico.GravarCurso(curso);
                    return RedirectToAction("Index");
                }
                return View(curso);
            }
            catch
            {
                return View(curso);                
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoCursoPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Curso curso)
        {
            return GravarCurso(curso);
        }
        
        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoCursoPorId(id);
        }

        //POST
        public ActionResult Edit(Curso curso)
        {
            return GravarCurso(curso);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoCursoPorId(id);
        }

        //POST
        public ActionResult Delete(long id)
        {
            try
            {
                Curso curso = cursoServico.EliminarCursoPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}