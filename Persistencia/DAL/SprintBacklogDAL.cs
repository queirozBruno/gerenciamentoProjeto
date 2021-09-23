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
    public class SprintBacklogDAL
    {
        private EFContext context = new EFContext();

        public void GravarSprintBacklog(SprintBacklog sprintBacklog)
        {
            if (sprintBacklog.SprintBacklogId == null)
            {
                context.sprintBacklogs.Add(sprintBacklog);
            }
            else
            {
                context.Entry(sprintBacklog).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public SprintBacklog ObterSprintBacklogPorId(long id) => context.sprintBacklogs.Where(s => s.SprintBacklogId == id).First();

        public SprintBacklog EliminarSprintBacklogPorId(long id)
        {
            SprintBacklog sprintBacklog = ObterSprintBacklogPorId(id);
            context.sprintBacklogs.Remove(sprintBacklog);
            context.SaveChanges();
            return sprintBacklog;
        }

        public IQueryable ObterSprintBacklogPorSprintIdOrdenadoPorEstimativa(long id) => context.sprintBacklogs.Where(s => s.SprintId == id).OrderBy(sb => sb.SprintBacklogEstimativa);

        public object ObterProductBacklogPorScrum(long id) => context.productBacklogs.Where(s => s.ScrumId == id).Include(sb => sb.SprintBacklogs).ToList();
    }
}