using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class ResponsavelController : Controller
    {
        private ResponsavelServico responsavelServico = new ResponsavelServico();
        private IntegranteServico integranteServico = new IntegranteServico();
        private FuncionalidadeServico funcionalidadeServico = new FuncionalidadeServico();

        // GET: Responsavel
        public ActionResult Index()
        {
            return View();
        }

        private ActionResult ObterVisaoResponsavelPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = responsavelServico.ObterResponsavelPorId((long)id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        ActionResult GravarResponsavel(Responsavel responsavel)
        {
            try
            {
                responsavel.funcionalidade.ProjetoId = (long)Session["IDProjeto"];
                funcionalidadeServico.GravarFuncionalidade(responsavel.funcionalidade);
                if (ModelState.IsValid)
                {
                    responsavel.FuncionalidadeId = responsavel.funcionalidade.FuncionalidadeId;
                    responsavel.IntegranteId = responsavel.integrante.IntegranteId;
                    responsavel.funcionalidade = null;
                    responsavel.integrante = null;
                    responsavelServico.GravarResponsavel(responsavel);                               
                    return RedirectToAction("Kanban", "Funcionalidade", (long?)Session["IDProjeto"]);
                }
                return View(responsavel);
            }
            catch
            {
                return View(responsavel);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoResponsavelPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            ViewBag.Integrantes = integranteServico.ObterIntegrantesClassificadosPorNome((long?)Session["IDProjeto"]);
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Responsavel responsavel)
        {
            return GravarResponsavel(responsavel);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoResponsavelPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Responsavel responsavel)
        {
            return GravarResponsavel(responsavel);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoResponsavelPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Responsavel responsavel = responsavelServico.EliminarResponsavelPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}