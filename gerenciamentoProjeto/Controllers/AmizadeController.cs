using Modelo;
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
    public class AmizadeController : Controller
    {
        private UsuarioServico usuarioServico = new UsuarioServico();
        private IdiomaUsuarioServico idiomaUsuarioServico = new IdiomaUsuarioServico();
        private CertificadoUsuarioServico certificadoUsuarioServico = new CertificadoUsuarioServico();
        private CompetenciaUsuarioServico competenciaUsuarioServico = new CompetenciaUsuarioServico();
        private PublicacaoUsuarioServico publicacaoUsuarioServico = new PublicacaoUsuarioServico();
        private LinguagemUsuarioServico linguagemUsuarioServico = new LinguagemUsuarioServico();
        private AmizadeServico amizadeServico = new AmizadeServico();
        // GET: Amizade
        public ActionResult Index()
        {
            return View(amizadeServico.ObterAmizadePorUsuarioId((long)Session["ID"]));
        }

        public ActionResult Usuarios()
        {
            return View(amizadeServico.ObterUsuariosExcetoUsuarioId((long)Session["ID"]));
        }

        ActionResult GravarAmizade(Amizade amizade)
        {
            try
            {
                amizade.AmizadeFlag = "P";
                amizade.UsuarioId = (long)Session["ID"];
                amizade.AmigoId = (long)Session["IDAmigo"];
                amizade.AmizadeDataSolicitaçao = DateTime.Now;
                if (ModelState.IsValid)
                {
                    //Pegar ID do usuário e do "amigo"   ,
                    amizadeServico.GravarAmizade(amizade);
                    amizade = null;
                    amizade = new Amizade();
                    amizade.AmizadeFlag = "P";
                    amizade.UsuarioId = (long)Session["IDAmigo"];
                    amizade.AmigoId = (long)Session["ID"];
                    amizade.AmizadeDataSolicitaçao = DateTime.Now;
                    amizadeServico.GravarAmizade(amizade);
                    return RedirectToAction("Index");
                }
                return View(amizade);
            }
            catch
            {
                return View(amizade);
            }
        }

        ActionResult GravarAmizade2(Amizade amizade)
        {
            try
            {
                long id = (long)amizade.AmizadeId + 1;
                amizade.AmizadeFlag = "A";
                amizade.AmizadeDataAceitacao = DateTime.Now.ToString();
                if (ModelState.IsValid)
                {
                    //Pegar ID do usuário e do "amigo"   ,
                    amizadeServico.GravarAmizade(amizade);
                    amizade = null;
                    amizade = amizadeServico.ObterAmizadePorId(id);
                    amizade.AmizadeFlag = "A";
                    amizade.AmizadeDataAceitacao = DateTime.Now.ToString();
                    amizadeServico.GravarAmizade(amizade);
                    return RedirectToAction("Pendentes");
                }
                return View(amizade);
            }
            catch
            {
                return View(amizade);
            }
        }

        //GET
        public ActionResult Create(long? id)
        {
            Session["IDAmigo"] = id;
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Amizade amizade)
        {
            return GravarAmizade(amizade);
        }

        //GET
        public ActionResult Edit(long? id)
        {            
            Amizade amizade = amizadeServico.ObterAmizadePorId((long)id);
            return GravarAmizade2(amizade);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Amizade amizade) 
        {
            return GravarAmizade(amizade);
        }

        public ActionResult VerPerfil(long? id)
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

        public ActionResult Pendentes()
        {
            ViewBag.Pendentes = amizadeServico.ObterQuantidadeAmizadesPendentes((long)Session["ID"]);
            return View(amizadeServico.ObterAmizadesPendentes((long)Session["ID"]));
        }
    }
}