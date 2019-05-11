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
    class IdiomaUsuarioDAL
    {
        private EFContext context = new EFContext();

        public void CriarIdiomaUsuario(IdiomaUsuario idiomaUsuario)
        {
            if (idiomaUsuario.IdiomaUsuarioId == null)
            {
                context.idiomaUsuarios.Add(idiomaUsuario);
            }
            else
            {
                context.Entry(idiomaUsuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public IdiomaUsuario ObterIdiomaUsuarioPorId(long id)
        {
            return context.idiomaUsuarios.Where(iu => iu.IdiomaUsuarioId == id).Include(i => i.idioma).Include(u => u.usuarios).First();
        }

        public IdiomaUsuario EliminarIdiomaUsuario(long id)
        {
            IdiomaUsuario idiomaUsuario = ObterIdiomaUsuarioPorId(id);
            context.idiomaUsuarios.Remove(idiomaUsuario);
            context.SaveChanges();
            return idiomaUsuario;
        }
    }
}
