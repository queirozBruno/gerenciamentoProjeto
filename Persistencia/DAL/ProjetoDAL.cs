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
    public class ProjetoDAL
    {
        private EFContext context = new EFContext();

        public long? ObterUltimoProjetoPorId()
        {
            return context.projetos.Max(p => p.ProjetoId);
        }

        public IQueryable ObterProjetosClassificadosPorNome()
        {
            return context.projetos.OrderBy(n => n.ProjetoNome);
        }

        public IQueryable ObterProjetosPorUsuario(long id)
        {
            return context.integrantes.Where(i => i.UsuarioId == id).Include(p => p.projeto).OrderBy(n => n.projeto.ProjetoId);
        }

        public Projeto ObterProjetoPorId(long id)
        {
            return context.projetos.Where(p => p.ProjetoId == id).First();
        }

        public void GravarProjeto(Projeto projeto)
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

        public Projeto EliminarProjetoPorId(long id)
        {
            Projeto projeto = ObterProjetoPorId(id);
            context.projetos.Remove(projeto);
            context.SaveChanges();
            return projeto;
        }
    }
}
