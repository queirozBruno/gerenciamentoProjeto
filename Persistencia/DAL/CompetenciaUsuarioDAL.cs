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
    class CompetenciaUsuarioDAL
    {
        private EFContext context = new EFContext();

        //Inserção e atualização
        public void CriarCompetenciaUsuario(CompetenciaUsuario competenciaUsuario)
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
            return context.competenciaUsuarios.Where(cu => cu.CompetenciaUsuarioId == id).Include(c => c.competencia).Include(u => u.usuarios).First();
        }

        //Delete
        public CompetenciaUsuario EliminarCompetenciaUsuario(long id)
        {
            CompetenciaUsuario competenciaUsuario = ObterCompetenciUsuarioaPorId(id);
            context.competenciaUsuarios.Remove(competenciaUsuario);
            context.SaveChanges();
            return competenciaUsuario;
        }
    }
}
