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
    public class ExperienciaDAL
    {
        private EFContext context = new EFContext();

        public void GravarExperiencia(Experiencia experiencia)
        {
            if (experiencia.ExperienciaId == null)
            {
                context.experiencias.Add(experiencia);
            }
            else
            {
                context.Entry(experiencia).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Experiencia ObterExperienciaPorId(long id)
        {
            return context.experiencias.Where(e => e.ExperienciaId == id).Include(u => u.usuario).First();
        }

        public Experiencia EliminarExperienciaPorId(long id)
        {
            Experiencia experiencia = ObterExperienciaPorId(id);
            context.experiencias.Remove(experiencia);
            context.SaveChanges();
            return experiencia;
        }
    }
}
