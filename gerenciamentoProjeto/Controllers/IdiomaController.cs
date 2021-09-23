using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class IdiomaController : Controller
    {
        private IdiomaServico idiomaServico = new IdiomaServico();

        // GET: Idioma

        public ActionResult Index()
        {
            return View(idiomaServico.ObterIdiomasClassificadosPorNome());
        }

        private ActionResult ObterVisaoIdiomaPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Idioma idioma = idiomaServico.ObterIdiomaPorId((long)id);
            if (idioma == null)
            {
                return HttpNotFound();
            }
            return View(idioma);
        }

        ActionResult GravarIdioma(Idioma idioma)
        {
            try
            {                
                if (ModelState.IsValid)
                {
                    idiomaServico.GravarIdioma(idioma);
                    return RedirectToAction("Index");
                }
                return View(idioma);
            }
            catch
            {
                return View(idioma);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoIdiomaPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Idioma idioma)
        {
            return GravarIdioma(idioma);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoIdiomaPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Idioma idioma)
        {
            return GravarIdioma(idioma);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoIdiomaPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Idioma idioma = idiomaServico.EliminarIdiomaPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}