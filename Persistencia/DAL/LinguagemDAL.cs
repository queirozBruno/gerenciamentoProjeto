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
    public class LinguagemDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterLinguagensClassificadasPorNome()
        {
            return context.linguagems.OrderBy(n => n.LinguagemNome);
        }

        public void GravarLinguagem(Linguagem linguagem)
        {
            if (linguagem.LinguagemId == null)
            {
                context.linguagems.Add(linguagem);
            }
            else
            {
                context.Entry(linguagem).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Linguagem ObterLinguagemPorId(long id)
        {
            return context.linguagems.Where(l => l.LinguagemId == id).First();
        }

        public Linguagem EliminarLinguagemPorId(long id)
        {
            Linguagem linguagem = ObterLinguagemPorId(id);
            context.linguagems.Remove(linguagem);
            context.SaveChanges();
            return linguagem;
        }

        public Linguagem ObterLinguagemPorNome(string linguagem) => context.linguagems.Where(i => i.LinguagemNome.ToUpper() == linguagem.ToUpper()).FirstOrDefault();

        public bool VerificaSeLinguagemExiste(string linguagem) => context.linguagems.Where(i => i.LinguagemNome.ToUpper() == linguagem.ToUpper()).Any();
    }
}
