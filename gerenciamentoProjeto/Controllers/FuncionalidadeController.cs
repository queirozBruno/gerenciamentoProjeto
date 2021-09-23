using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class FuncionalidadeController : Controller
    {
        private FuncionalidadeServico funcionalidadeServico = new FuncionalidadeServico();
        private IntegranteServico integranteServico = new IntegranteServico();
        

        // GET: Funcionalidade

        public ActionResult Index(long? id)
        {
            //id = 1;
            if (id == null)
            {
                id = (long)Session["IDProjeto"];
            }
            else
            {
                Session["IDProjeto"] = id;
            }            
            return View(funcionalidadeServico.ObterFuncionalidadesClassificadasPorNome((long)id));
        }

        public ActionResult Kanban(long? id, string nome)
        {
            if (nome != null)
                Session["NomeProjeto"] = nome;
            if (id == null)
                id = (long?)Session["IDProjeto"];
            else
                Session["IDProjeto"] = id;

            if (id == null)
                return RedirectToAction("Login", "Usuario");
            else
                return View(funcionalidadeServico.ObterFuncionalidadesClassificadasPorNome((long)id));
        }

        private ActionResult ObterVisaoFuncionalidadePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionalidade funcionalidade = funcionalidadeServico.ObterFuncionalidadePorId((long)id);
            if (funcionalidade == null)
            {
                return HttpNotFound();
            }
            return View(funcionalidade);
        }

        ActionResult GravarFuncionalidade(Funcionalidade funcionalidade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    funcionalidade.ProjetoId = (long)Session["IDProjeto"];
                    funcionalidadeServico.GravarFuncionalidade(funcionalidade);
                    return RedirectToAction("Index", funcionalidade.ProjetoId);
                }
                return View(funcionalidade);
            }
            catch
            {
                return View(funcionalidade);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoFuncionalidadePorId(id);
        }

        //GET
        public ActionResult Create()
        {            
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Funcionalidade funcionalidade)
        {
            return GravarFuncionalidade(funcionalidade);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoFuncionalidadePorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Funcionalidade funcionalidade)
        {
            return GravarFuncionalidade(funcionalidade);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoFuncionalidadePorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Funcionalidade funcionalidade = funcionalidadeServico.EliminarFuncionalidadePorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}