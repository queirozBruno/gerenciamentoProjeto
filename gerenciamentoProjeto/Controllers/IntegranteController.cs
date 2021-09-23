using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;
using Modelo.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class IntegranteController : Controller
    {
        private IntegranteServico integranteServico = new IntegranteServico();
        private ProjetoServico projetoServico = new ProjetoServico();
        private UsuarioServico usuarioServico = new UsuarioServico();
        private AmizadeServico amizadeServico = new AmizadeServico();

        public ActionResult Projetos()
        {
            return View(integranteServico.ObterProjetosPorUsuario((long)Session["ID"]));
        }

        // GET: Integrante
        public ActionResult Index()
        {
            return View(integranteServico.ObterIntegrantesClassificadosPorNome((long)Session["IDProjeto"]));
        }

        public void ObterIntegrantePorEmail(string email)
        {
            Integrante e_email = integranteServico.ObterIntegrantePorEmail(email);
            string nome = e_email.IntegranteDescricao;            
        }

        private ActionResult ObterVisaoIntegrantePorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Integrante integrante = integranteServico.ObterIntegrantePorId((long)id);
            if (integrante == null)
            {
                return HttpNotFound();
            }
            return View(integrante);
        }

        ActionResult GravarIntegrante(Integrante integrante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    integrante.ProjetoId = (long?)Session["IDProjeto"];
                    integranteServico.GravarIntegrante(integrante);
                    return RedirectToAction("Index");
                }
                return View(integrante);
            }
            catch
            {
                return View(integrante);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoIntegrantePorId(id);
        }

        //GET
        public ActionResult MeusContatos()
        {
            return View(amizadeServico.ObterAmizadePorUsuarioId((long)Session["ID"]));
        }

        [HttpPost]
        public ActionResult MeusContatos(Amizade amizade)
        {
            return RedirectToAction("Create");
        }


        //GET
        public ActionResult Create(long? id)
        {
            if (integranteServico.VerificarSeProjetoJaTemIntegrante((long)Session["IDProjeto"]) == false)
            {
                Integrante integrante = new Integrante();
                integrante.IntegranteFuncao = "Dono";
                integrante.IntegranteDescricao = "";
                integrante.ProjetoId = (long)Session["IDProjeto"];
                integrante.UsuarioId = (long)Session["ID"];
                GravarIntegrante(integrante);
                return RedirectToAction("Index");
            }
            else if (id == null)
            {
                return RedirectToAction("MeusContatos");
            }
            else
            {
                Integrante integrante = new Integrante();
                integrante.UsuarioId = id;
                return View(integrante);
            }
                          
        }

        //POST
        [HttpPost]
        public ActionResult Create(Integrante integrante)
        {
            return GravarIntegrante(integrante);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoIntegrantePorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Integrante integrante)
        {
            return GravarIntegrante(integrante);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoIntegrantePorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Integrante integrante = integranteServico.EliminarIntegrantePorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult Search(string cpf)
        {
            var result = usuarioServico.ObterUsuarioPorCPF(cpf);
            return (ActionResult)result;
        }
    }
}