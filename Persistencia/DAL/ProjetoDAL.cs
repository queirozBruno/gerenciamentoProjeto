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
    class ProjetoDAL
    {
        private EFContext context = new EFContext();

        public void CriarProjeto(Projeto projeto)
        {
            if (projeto.ProjetoId == null)
            {
                context.projetos.Add(projeto);
            }
            else
            {
                context.Entry(projeto).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Projeto ObterProjetoPorId(long id)
        {
            return context.projetos.Where(p => p.ProjetoId == id).First();
        }

        public Projeto EliminarProjeto(long id)
        {
            Projeto projeto = ObterProjetoPorId(id);
            context.projetos.Remove(projeto);
            context.SaveChanges();
            return projeto;
        }
    }
}
