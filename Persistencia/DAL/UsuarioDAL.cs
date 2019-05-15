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
    public class UsuarioDAL
    {
        private EFContext context = new EFContext();

        //public IQueryable ObterUsuariosClassificadosPorNome()
        //{
        //    return context.usuarios.OrderBy(n => n.UsuarioNome);
        //}

        public void GravarUsuarios(Usuario usuario)
        {
            if (usuario.UsuarioId == null)
            {
                context.usuarios.Add(usuario);
            }
            else
            {
                context.Entry(usuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Usuario ObterUsuarioPorId(long id)
        {
            return context.usuarios.Where(u => u.UsuarioId == id).First();
        }

        public Usuario EliminarUsuarioPorId(long id)
        {
            Usuario usuario = ObterUsuarioPorId(id);
            context.usuarios.Remove(usuario);
            context.SaveChanges();
            return usuario;
        }
    }
}
