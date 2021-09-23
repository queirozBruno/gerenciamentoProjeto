using Modelo.Tabelas;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class SprintBacklogServico
    {
        private SprintBacklogDAL sprintBacklogDAL = new SprintBacklogDAL();

        public void GravarSprintBacklog(SprintBacklog sprintBacklog) => sprintBacklogDAL.GravarSprintBacklog(sprintBacklog);

        public SprintBacklog ObterSprintBacklogPorId(long id) => sprintBacklogDAL.ObterSprintBacklogPorId(id);

        public SprintBacklog EliminarSprintBacklogPorId(long id) => sprintBacklogDAL.EliminarSprintBacklogPorId(id);

        public IQueryable ObterSprintBacklogPorSprintIdOrdenadoPorEstimativa(long id) => sprintBacklogDAL.ObterSprintBacklogPorSprintIdOrdenadoPorEstimativa(id);

        public object ObterProductBacklogPorScrum(long id) => sprintBacklogDAL.ObterProductBacklogPorScrum(id);

    }
}
