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

        public IQueryable ObterIdiomaClassificadosPorNome() => context.idiomas.OrderBy(n => n.IdiomaNome);

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

        public Idioma ObterIdiomaPorId(long id) => context.idiomas.Where(i => i.IdiomaId == id).First();

        public Idioma EliminarIdiomaPorId(long id)
        {
            Idioma idioma = ObterIdiomaPorId(id);
            context.idiomas.Remove(idioma);
            context.SaveChanges();
            return idioma;
        }

        public Idioma ObterIdiomaPorNome(string idioma) => context.idiomas.Where(i => i.IdiomaNome.ToUpper() == idioma.ToUpper()).FirstOrDefault();

        public bool VerificaSeIdiomaExiste(string idioma) => context.idiomas.Where(i => i.IdiomaNome.ToUpper() == idioma.ToUpper()).Any();
    }
}
