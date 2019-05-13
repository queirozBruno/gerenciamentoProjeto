using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contexts;
using Modelo;
using System.Data.Entity;

namespace Persistencia.DAL
{
    public class ResponsavelDAL
    {
        private EFContext context = new EFContext();

        public void GravarResponsavel(Responsavel responsavel)
        {
            if (responsavel.ResponsavelId == null)
            {
                context.responsavels.Add(responsavel);
            }
            else
            {
                context.Entry(responsavel).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Responsavel ObterResponsavelPorId(long id)
        {
            return context.responsavels.Where(r => r.ResponsavelId == id).Include(i => i.integrante).Include(f => f.funcionalidade).First();
        }

        public Responsavel EliminarResponsavelPorId(long id)
        {
            Responsavel responsavel = ObterResponsavelPorId(id);
            context.responsavels.Remove(responsavel);
            context.SaveChanges();
            return responsavel;
        }
    }
}
