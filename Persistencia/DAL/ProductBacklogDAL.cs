using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class ProductBacklogDAL
    {
        private EFContext context = new EFContext();

        public void GravarProductBacklog(ProductBacklog productBacklog)
        {
            if (productBacklog.ProductBacklogId == null)
            {
                context.productBacklogs.Add(productBacklog);
            }
            else
            {
                context.Entry(productBacklog).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public ProductBacklog ObterProductBacklogPorId(long id)
        {
            return context.productBacklogs.Where(p => p.ProductBacklogId == id).First();
        }

        public ProductBacklog EliminarProductBacklogPorId(long id)
        {
            ProductBacklog productBacklog = ObterProductBacklogPorId(id);
            context.productBacklogs.Remove(productBacklog);
            context.SaveChanges();
            return productBacklog;
        }

        public IQueryable ObterProductBacklogPorScrumId(long id) => context.productBacklogs.Where(s => s.ScrumId == id).OrderBy(pb => pb.ProductBacklogPrioridade);
    }
}
