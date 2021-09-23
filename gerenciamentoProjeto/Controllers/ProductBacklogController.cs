using Modelo.Tabelas;
using Servico.Tabelas;
using System.Net;
using System.Web.Mvc;

namespace gerenciamentoProjeto.Controllers
{
    public class ProductBacklogController : Controller
    {        
        private ProductBacklogServico productBacklogServico = new ProductBacklogServico();

        // GET: ProductBacklog
        public ActionResult Index(long? id)
        {
            if (id == null) 
                id = (long?)Session["IDScrum"];
            else
                Session["IDScrum"] = id;
            return View(productBacklogServico.ObterProductBacklogPorScrumId((long)id));
        }

        private ActionResult ObterVisaoProductBacklogPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBacklog productBacklog = productBacklogServico.ObterProductBacklogPorId((long)id);
            if (productBacklog == null)
            {
                return HttpNotFound();
            }
            return View(productBacklog);
        }

        ActionResult GravarProductBacklog(ProductBacklog productBacklog)
        {
            try
            {
                productBacklog.ScrumId = (long)Session["IDScrum"];
                if (ModelState.IsValid)
                {  
                    long id = (long)Session["IDScrum"];
                    productBacklogServico.GravarProductBacklog(productBacklog);
                    return RedirectToAction("Index", id);
                }
                return View(productBacklog);
            }
            catch
            {
                return View(productBacklog);
            }
        }

        public ActionResult Details(long? id)
        {
            return ObterVisaoProductBacklogPorId(id);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(ProductBacklog productBacklog)
        {
            return GravarProductBacklog(productBacklog);
        }

        //GET
        public ActionResult Edit(long? id)
        {
            return ObterVisaoProductBacklogPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Edit(ProductBacklog productBacklog)
        {
            return GravarProductBacklog(productBacklog);
        }

        //GET
        public ActionResult Delete(long? id)
        {
            return ObterVisaoProductBacklogPorId(id);
        }

        //POST
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                ProductBacklog productBacklog = productBacklogServico.EliminarProductBacklogPorId(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}