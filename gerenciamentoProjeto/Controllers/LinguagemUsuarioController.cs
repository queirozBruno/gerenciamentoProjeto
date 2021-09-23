using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class LinguagemUsuarioController : Controller
    {
        private LinguagemUsuarioServico linguagemUsuarioServico = new LinguagemUsuarioServico();
        private LinguagemServico linguagemServico = new LinguagemServico();

        // GET: LinguagemUsuario

        public ActionResult Index()
        {
            return View();
        }

        private ActionResult ObterVisaoLinguagemUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinguagemUsuario linguagemUsuario = linguagemUsuarioServico.ObterLinguagemUsuarioPorId((long)id);
            if (linguagemUsuario == null)
            {
                return HttpNotFound();
            }
            return View(linguagemUsuario);
        }

        ActionResult GravarLinguagemUsuario(LinguagemUsuario linguagemUsuario)
        {
            try
            {
                bool verificaLinguagem = linguagemServico.VerificaSeLinguagemExiste(linguagemUsuario.linguagem.LinguagemNome);
                if (verificaLinguagem == false) //Não existe
                {
                    linguagemServico.GravarLinguagem(linguagemUsuario.linguagem);
                    linguagemUsuario.LinguagemId = linguagemUsuario.linguagem.LinguagemId;
                }
                else
                {
                    Linguagem linguagem = linguagemServico.ObterLinguagemPorNome(linguagemUsuario.linguagem.LinguagemNome);
                    linguagemUsuario.LinguagemId = linguagem.LinguagemId;
                }

                linguagemUsuario.linguagem = null;
                linguagemUsuario.UsuarioId = (long)Session["ID"];

                if (ModelState.IsValid)
                {
                    linguagemUsuarioServico.GravarLinguagemUsuario(linguagemUsuario);
                    return RedirectToAction("Details", "Usuario");
                }
                return View(linguagemUsuario);
            }
            catch
            {
                return View(linguagemUsuario);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoLinguagemUsuarioPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(LinguagemUsuario linguagemUsuario)
        {
            return GravarLinguagemUsuario(linguagemUsuario);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoLinguagemUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(LinguagemUsuario linguagemUsuario)
        {
            return GravarLinguagemUsuario(linguagemUsuario);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoLinguagemUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                LinguagemUsuario linguagemUsuario = linguagemUsuarioServico.EliminarLinguagemUsuarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}