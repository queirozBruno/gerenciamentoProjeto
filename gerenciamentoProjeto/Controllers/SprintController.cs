using Modelo.Tabelas;
using Servico.Tabelas;
using System.Net;
using System.Web.Mvc;

namespace gerenciamentoProjeto.Controllers
{
    public class SprintController : Controller
    {
        private SprintServico sprintServico = new SprintServico();

        // GET: Sprint
        public ActionResult Index(long? id)
        {
            if (id == null)
                id = (long?)Session["IDScrum"];
            else
                Session["IDScrum"] = id;
            return View(sprintServico.ObterSprintPorIdScrum((long)id));
        }

        private ActionResult ObterVisaoSprintPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sprint sprint = sprintServico.ObterSprintPorId((long)id);
            if (sprint == null)
            {
                return HttpNotFound();
            }
            return View(sprint);
        }

        ActionResult GravarSprint(Sprint sprint)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    sprint.ScrumId = (long)Session["IDScrum"];
                    sprintServico.GravarSprint(sprint);
                    Session["IDSprint"] = sprint.SprintId;
                    return RedirectToAction("Index");
                }
                return View(sprint);
            }
            catch
            {
                return View(sprint);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoSprintPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(Sprint sprint)
        {
            return GravarSprint(sprint);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoSprintPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(Sprint sprint)
        {
            return GravarSprint(sprint);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoSprintPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                Sprint sprint = sprintServico.EliminarSprintPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}