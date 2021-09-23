using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class LinguagemController : Controller
    {
        private LinguagemServico linguagemServico = new LinguagemServico();


        // GET: Linguagem

        public ActionResult Index()
        {
            return View(linguagemServico.ObterLinguagensClassificadasPorNome());
        }

        private ActionResult ObterVisaoLinguagemPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Linguagem linguagem = linguagemServico.ObterLinguagemPorId((long)id);
            if (linguagem == null)
            {
                return HttpNotFound();
            }
            return View(linguagem);
        }

        ActionResult GravarLinguagem(Linguagem linguagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    linguagemServico.GravarLinguagem(linguagem);
                    return RedirectToAction("Index");
                }
                return View(linguagem);
            }
            catch
            {
                return View(linguagem);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoLinguagemPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Linguagem linguagem)
        {
            return GravarLinguagem(linguagem);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoLinguagemPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Linguagem linguagem)
        {
            return GravarLinguagem(linguagem);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoLinguagemPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Linguagem linguagem = linguagemServico.EliminarLinguagemPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}