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
    public class IdiomaDAL
    {
        private EFContext context = new EFContext();

        public void GravarIdioma(Idioma idioma)
        {
            if (idioma.IdiomaId == null)
            {
                context.idiomas.Add(idioma);
            }
            else
            {
                context.Entry(idioma).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Idioma ObterIdiomaPorId(long id)
        {
            return context.idiomas.Where(i => i.IdiomaId == id).First();
        }

        public Idioma EliminarIdiomaPorId(long id)
        {
            Idioma idioma = ObterIdiomaPorId(id);
            context.idiomas.Remove(idioma);
            context.SaveChanges();
            return idioma;
        }
    }
}
