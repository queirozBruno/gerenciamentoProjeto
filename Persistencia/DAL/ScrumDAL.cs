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
    public class ScrumDAL
    {
        private EFContext context = new EFContext();

        public void GravarScrum(Scrum scrum)
        {
            if (scrum.ScrumId == null)
            {
                context.scrums.Add(scrum);
            }
            else
            {
                context.Entry(scrum).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Scrum ObterScrumPorId(long id)
        {
            return context.scrums.Where(r => r.ScrumId == id).Include(p => p.projeto).First();
        }

        public Scrum EliminarScrumPorId(long id)
        {
            Scrum scrum = ObterScrumPorId(id);
            context.scrums.Remove(scrum);
            context.SaveChanges();
            return scrum;
        }

        public bool VerificarSeExisteScrum(long id)
        {
            if (context.scrums.Where(s => s.ProjetoId == id).Count() > 0)
                return true;
            else return false;            
        }

        public long? RecuperaIdScrum(long id) => context.scrums.Where(p => p.ProjetoId == id).Select(s => s.ScrumId).FirstOrDefault();
    }
}
