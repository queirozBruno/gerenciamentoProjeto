using System.Web.Mvc;
using System.Net;
using Modelo;
using Servico.Tabelas;

namespace gerenciamentoProjeto.Controllers
{
    public class IdiomaUsuarioController : Controller
    {
        private IdiomaUsuarioServico idiomaUsuarioServico = new IdiomaUsuarioServico();
        private IdiomaServico idiomaServico = new IdiomaServico();


        // GET: IdiomaUsuario

        public ActionResult Index()
        {
            return View();
        }

        private ActionResult ObterVisaoIdiomaUsuarioPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdiomaUsuario idiomaUsuario = idiomaUsuarioServico.ObterIdiomaUsuarioPorId((long)id);
            if (idiomaUsuario == null)
            {
                return HttpNotFound();
            }
            return View(idiomaUsuario);
        }

        //Primeiro tem que fazer uma consulta pra ver se já tem. Se tiver só recupera o id e relaciona com usuário (chamar a função idiomaUsuarioServico.GravarIdiomaUsuario). 
        ActionResult GravarIdiomaUsuario(IdiomaUsuario idiomaUsuario)
        {
            try
            {
                bool verificaIdioma = idiomaServico.VerificaSeIdiomaExiste(idiomaUsuario.idioma.IdiomaNome);
                if (verificaIdioma == false) //Não existe
                {                    
                    idiomaServico.GravarIdioma(idiomaUsuario.idioma);
                    idiomaUsuario.IdiomaId = idiomaUsuario.idioma.IdiomaId;
                }
                else
                {
                    Idioma idioma = idiomaServico.ObterIdiomaPorNome(idiomaUsuario.idioma.IdiomaNome);
                    idiomaUsuario.IdiomaId = idioma.IdiomaId;
                }                

                
                idiomaUsuario.idioma = null;
                idiomaUsuario.UsuarioId = (long)Session["ID"];
                if (ModelState.IsValid)
                {
                    idiomaUsuarioServico.GravarUsuarioIdioma(idiomaUsuario);
                    return RedirectToAction("Details", "Usuario", null);
                }
                return View(idiomaUsuario);
            }
            catch
            {
                return View(idiomaUsuario);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoIdiomaUsuarioPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(IdiomaUsuario idiomaUsuario)
        {
            return GravarIdiomaUsuario(idiomaUsuario);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoIdiomaUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(IdiomaUsuario idiomaUsuario)
        {
            return GravarIdiomaUsuario(idiomaUsuario);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoIdiomaUsuarioPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                IdiomaUsuario idiomaUsuario = idiomaUsuarioServico.EliminarIdiomaUsuarioPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}