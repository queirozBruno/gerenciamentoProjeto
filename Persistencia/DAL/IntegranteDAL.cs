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
    public class IntegranteDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterIntegrantesClassificadosPorNome(long? projetoId)
        {
            return context.integrantes.Where(p => p.ProjetoId == projetoId).Include(u => u.usuario).OrderBy(n => n.usuario.UsuarioNome);
        }

        public Integrante ObterIntegrantePorEmail(string email) => context.integrantes.Where(u => u.usuario.UsuarioEmail == email).FirstOrDefault();

        public object ObterProjetosPorUsuario(long id) => context.integrantes.Where(i => i.UsuarioId == id).Include(p => p.projeto).OrderBy(n => n.projeto.ProjetoId).ToList();

        public void GravarIntegrante(Integrante integrante)
        {
            if (integrante.IntegranteId == null)
            {
                context.integrantes.Add(integrante);
            }
            else
            {
                context.Entry(integrante).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Integrante ObterIntegrantePorId(long id)
        {
            return context.integrantes.Where(i => i.IntegranteId == id).Include(p => p.projeto).Include(u => u.usuario).First();
        }

        public Integrante EliminarIntegrantePorId(long id)
        {
            Integrante integrante = ObterIntegrantePorId(id);
            context.integrantes.Remove(integrante);
            context.SaveChanges();
            return integrante;
        }

        public bool VerificarSeProjetoJaTemIntegrante(long id) 
        {
            if (context.integrantes.Where(i => i.ProjetoId == id).Count() > 0)
                return true;
            else
                return false;            
        }
    }
}
