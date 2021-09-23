using Modelo.Tabelas;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class ProductBacklogServico
    {
        private ProductBacklogDAL productBacklogDAL = new ProductBacklogDAL();

        public void GravarProductBacklog(ProductBacklog productBacklog) => productBacklogDAL.GravarProductBacklog(productBacklog);

        public ProductBacklog ObterProductBacklogPorId(long id) => productBacklogDAL.ObterProductBacklogPorId(id);

        public ProductBacklog EliminarProductBacklogPorId(long id) => productBacklogDAL.EliminarProductBacklogPorId(id);

        public IQueryable ObterProductBacklogPorScrumId(long id) => productBacklogDAL.ObterProductBacklogPorScrumId(id);
    }
}
