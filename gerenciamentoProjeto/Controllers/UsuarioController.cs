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
    public class UsuarioController : Controller
    {
        private UsuarioServico usuarioServico = new UsuarioServico();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        private ActionResult ObterVisaoUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = usuarioServico.ObterUsuarioPorId((long)id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        
        ActionResult GravarUsuario(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarioServico.GravarUsuario(usuario);
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch
            {
                return View(usuario);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }

        // POST
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            return GravarUsuario(usuario);
        }

        // GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }

        // POST
        [HttpPost]
        public ActionResult Edit(Usuario usuario)
        {
            return GravarUsuario(usuario);
        }

        // GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoUsuarioPorId(id);
        }

        // POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Usuario usuario = usuarioServico.EliminarUsuarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}