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
    public class CursoUsuarioDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterCursoUsuarioClassificadosPorNome()
        {
            return context.cursoUsuarios.OrderBy(n => n.CursoNome);
        }

        public IQueryable ObterVisaoCursoUsuario()
        {
            return context.cursoUsuarios.OrderBy(n => n.CursoNome).OrderBy(nu => nu.usuario.UsuarioNome);
        }

        //Inserção e atualização
        public void GravarCursoUsuario(CursoUsuario cursoUsuario)
        {
            if (cursoUsuario.CursoUsuarioId == null)
            {
                context.cursoUsuarios.Add(cursoUsuario);
            }
            else
            {
                context.Entry(cursoUsuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        //Leitura
        public CursoUsuario ObterCursoUsuarioPorId(long id)
        {
            return context.cursoUsuarios.Where(cu => cu.CursoUsuarioId == id).Include(u => u.usuario).First();
        }

        //Delete
        public CursoUsuario EliminarCursoUsuarioPorId(long id)
        {
            CursoUsuario cursoUsuario = ObterCursoUsuarioPorId(id);
            context.cursoUsuarios.Remove(cursoUsuario);
            context.SaveChanges();
            return cursoUsuario;
        }
    }
}
