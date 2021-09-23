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
    public class SprintDAL
    {
        private EFContext context = new EFContext();

        public void GravarSprint(Sprint sprint)
        {
            if (sprint.SprintId == null)
            {
                sprint.SprintMetaAlcancada = false;
                context.sprints.Add(sprint);
            }
            else
            {
                context.Entry(sprint).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Sprint ObterSprintPorId(long id) => context.sprints.Where(s => s.SprintId == id).First();

        public IQueryable ObterSprintPorIdScrum(long id) => context.sprints.Where(s => s.ScrumId == id); //colocar um .Include(new) e passar o MetaAlcançada de char para string (.ToString()), pois não está aparecendo no html

        public Sprint EliminarSprintPorId(long id)
        {
            Sprint sprint = ObterSprintPorId(id);
            context.sprints.Remove(sprint);
            context.SaveChanges();
            return sprint;
        }
        
        public bool VerificarSeExisteSprint(long id)
        {   
            if (context.sprints.Where(s => s.ScrumId == id).Count() > 0)
                return true;
            else return false;
        }
    }
}
