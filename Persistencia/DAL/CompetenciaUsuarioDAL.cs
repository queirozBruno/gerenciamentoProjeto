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
    public class CompetenciaUsuarioDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterCompetenciaUsuariosClassificadosPorNome()
        {
            return context.competenciaUsuarios.Include(c => c.competencia).Include(u => u.usuario).OrderBy(cu => cu.competencia.CompetenciaNome);
        }

        //Inserção e atualização
        public void GravarCompetenciaUsuario(CompetenciaUsuario competenciaUsuario)
        {
            if (competenciaUsuario.CompetenciaUsuarioId == null)
            {
                context.competenciaUsuarios.Add(competenciaUsuario);
            }
            else
            {
                context.Entry(competenciaUsuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        //Leitura
        public CompetenciaUsuario ObterCompetenciUsuarioaPorId(long id)
        {
            return context.competenciaUsuarios.Where(cu => cu.CompetenciaUsuarioId == id).Include(c => c.competencia).Include(u => u.usuario).First();
        }

        //Delete
        public CompetenciaUsuario EliminarCompetenciaUsuarioPorId(long id)
        {
            CompetenciaUsuario competenciaUsuario = ObterCompetenciUsuarioaPorId(id);
            context.competenciaUsuarios.Remove(competenciaUsuario);
            context.SaveChanges();
            return competenciaUsuario;
        }

        public IQueryable ObterCompetenciaUsuarioPorUsuarioId(long id) => context.competenciaUsuarios.Where(iu => iu.UsuarioId == id).Include(i => i.competencia);
    }
}
