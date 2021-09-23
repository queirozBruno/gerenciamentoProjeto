using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoServico projetoServico = new ProjetoServico();
        private IntegranteServico integranteServico = new IntegranteServico();

        // GET: Projeto
        public ActionResult Index()
        {
            //return View(projetoServico.ObterProjetosClassificadosPorNome());
            return RedirectToAction("Projetos", "Integrante");
        }

        private ActionResult ObterVisaoProjetoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Projeto projeto = projetoServico.ObterProjetoPorId((long)id);
            Session["NomeProjeto"] = projeto.ProjetoNome;
            Session["IDProjeto"] = projeto.ProjetoId;
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        ActionResult GravarProjeto(Projeto projeto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    projetoServico.GravarProjeto(projeto);
                    Session["NomeProjeto"] = projeto.ProjetoNome;
                    Session["IDProjeto"] = projeto.ProjetoId;
                    return RedirectToAction("Create", "Integrante");
                }
                return View(projeto);
            }
            catch
            {
                return View(projeto);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoProjetoPorId(id);

        }

        //GET
        public ActionResult Create()
        {
            //PopularViewBag();
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Projeto projeto)
        {
            //PopularViewBag();
            
            return GravarProjeto(projeto);

        }

        //GET
        public ActionResult Edit(long? id)
        {
            //PopularViewBag(projetoServico.ObterProjetoPorId((long)id));
            return ObterVisaoProjetoPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Projeto projeto)
        {
            return GravarProjeto(projeto);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoProjetoPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Projeto projeto = projetoServico.EliminarProjetoPorId(id);
                return RedirectToAction("Index", "Integrante");
            }
            catch
            {
                return View();
            }
        }
    }
}