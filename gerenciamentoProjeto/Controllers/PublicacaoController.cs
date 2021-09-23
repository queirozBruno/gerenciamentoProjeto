using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class PublicacaoController : Controller
    {
        private PublicacaoServico publicacaoServico = new PublicacaoServico();

        // GET: Publicacao
        public ActionResult Index()
        {
            return View(publicacaoServico.ObterPublicacoesClassificadasPorNome());
        }

        private ActionResult ObterVisaoPublicacaoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacao publicacao = publicacaoServico.ObterPublicacaoPorId((long)id);
            if (publicacao == null)
            {
                return HttpNotFound();
            }
            return View(publicacao);
        }

        ActionResult GravarPublicacao(Publicacao publicacao)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    publicacaoServico.GravarPublicacao(publicacao);
                    return RedirectToAction("Index");
                }
                return View(publicacao);
            }
            catch
            {
                return View(publicacao);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoPublicacaoPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Publicacao publicacao)
        {
            return GravarPublicacao(publicacao);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoPublicacaoPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Publicacao publicacao)
        {
            return GravarPublicacao(publicacao);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoPublicacaoPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Publicacao publicacao = publicacaoServico.EliminarPublicacaoPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}