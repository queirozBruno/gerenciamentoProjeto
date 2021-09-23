using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class PublicacaoUsuarioController : Controller
    {
        private PublicacaoUsuarioServico publicacaoUsuarioServico = new PublicacaoUsuarioServico();
        private PublicacaoServico publicacaoServico = new PublicacaoServico();

        // GET: PublicacaoUsuario
        public ActionResult Index()
        {
            return View();
        }

        private ActionResult ObterVisaoPublicacaoUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicacaoUsuario publicacaoUsuario = publicacaoUsuarioServico.ObterPublicacaoUsuarioPorId((long)id);
            if (publicacaoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(publicacaoUsuario);
        }

        ActionResult GravarPublicacaoUsuario(PublicacaoUsuario publicacaoUsuario)
        {
            try
            {
                bool verificaPublicacao = publicacaoServico.VerificaSePublicacaoExiste(publicacaoUsuario.publicacao.PublicacaoTitulo);
                if (verificaPublicacao == false) //Não existe
                {
                    publicacaoServico.GravarPublicacao(publicacaoUsuario.publicacao);
                    publicacaoUsuario.PublicacaoId = publicacaoUsuario.publicacao.PublicacaoId;
                }
                else
                {
                    Publicacao publicacao = publicacaoServico.ObterPublicacaoPorNome(publicacaoUsuario.publicacao.PublicacaoTitulo);
                    publicacaoUsuario.PublicacaoId = publicacao.PublicacaoId;
                }

                publicacaoUsuario.publicacao = null;
                publicacaoUsuario.UsuarioId = (long)Session["ID"];

                if (ModelState.IsValid)
                {
                    publicacaoUsuarioServico.GravarPublicacaoUsuario(publicacaoUsuario);
                    return RedirectToAction("Details", "Usuario");
                }
                return View(publicacaoUsuario);
            }
            catch
            {
                return View(publicacaoUsuario);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoPublicacaoUsuarioPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(PublicacaoUsuario publicacaoUsuario)
        {
            return GravarPublicacaoUsuario(publicacaoUsuario);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoPublicacaoUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(PublicacaoUsuario publicacaoUsuario)
        {
            return GravarPublicacaoUsuario(publicacaoUsuario);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoPublicacaoUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                PublicacaoUsuario publicacaoUsuario = publicacaoUsuarioServico.EliminarPublicacaoUsuarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}