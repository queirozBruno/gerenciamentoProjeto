using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Modelo;
using Servico.Tabelas;
using System.Web.Security;

namespace gerenciamentoProjeto.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioServico usuarioServico = new UsuarioServico();
        private IdiomaUsuarioServico idiomaUsuarioServico = new IdiomaUsuarioServico();
        private CertificadoUsuarioServico certificadoUsuarioServico = new CertificadoUsuarioServico();
        private CompetenciaUsuarioServico competenciaUsuarioServico = new CompetenciaUsuarioServico();
        private PublicacaoUsuarioServico publicacaoUsuarioServico = new PublicacaoUsuarioServico();
        private LinguagemUsuarioServico linguagemUsuarioServico = new LinguagemUsuarioServico();

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
            Usuario usuario = usuarioServico.ObterTodosOsDadosDoUsuarioPorId((long)id);
            ViewBag.Idioma = idiomaUsuarioServico.ObterIdiomaUsuarioPorUsuarioId((long)id);
            ViewBag.Certificado = certificadoUsuarioServico.ObterCertificadoUsuarioPorUsuarioId((long)id);
            ViewBag.Competencia = competenciaUsuarioServico.ObterCompetenciaUsuarioPorUsuarioId((long)id);
            ViewBag.Publicacao = publicacaoUsuarioServico.ObterPublicacaoUsuarioPorUsuarioId((long)id);
            ViewBag.Linguagem = linguagemUsuarioServico.ObterLinguagemUsuarioPorUsuarioId((long)id);
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
                    usuarioServico.ObterUsuarioPorEmail(usuario);
                    Session["Nome"] = usuario.UsuarioNome;
                    Session["ID"] = usuario.UsuarioId;
                    return RedirectToAction("Index", "Menu");
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
            if (id == null)
                id = (long?)Session["ID"];
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuario usuario, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var vLogin = usuarioServico.ObterUsuarioPorEmail(usuario);
                if (vLogin != null)
                {                    
                    if (Equals(vLogin.UsuarioSenha, usuario.UsuarioSenha))
                    {
                        FormsAuthentication.SetAuthCookie(vLogin.UsuarioEmail, false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        Session["Nome"] = vLogin.UsuarioNome;
                        Session["ID"] = vLogin.UsuarioId;
                        return RedirectToAction("Index", "Menu");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Senha informada inválida!");
                        return View(new Usuario());
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-mail não cadastrado! Digite o e-mail corretamente ou cadastre-se para ter acesso aos dados.");
                    return View(new Usuario());
                }
            }
            return View(usuario);
        }
    }
}