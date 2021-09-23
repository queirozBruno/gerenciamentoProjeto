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
    public class PublicacaoUsuarioDAL
    {
        private EFContext context = new EFContext();

        public void GravarPublicacaoUsuario(PublicacaoUsuario publicacaoUsuario)
        {
            if (publicacaoUsuario.PublicacaoUsuarioId == null)
            {
                context.publicacaoUsuarios.Add(publicacaoUsuario);
            }
            else
            {
                context.Entry(publicacaoUsuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public PublicacaoUsuario ObterPublicacaoUsuarioPorId(long id)
        {
            return context.publicacaoUsuarios.Where(pu => pu.PublicacaoUsuarioId == id).Include(p => p.publicacao).Include(u => u.usuario).First();
        }

        public PublicacaoUsuario EliminarPublicacaoUsuarioPorId(long id)
        {
            PublicacaoUsuario publicacaoUsuario = ObterPublicacaoUsuarioPorId(id);
            context.publicacaoUsuarios.Remove(publicacaoUsuario);
            context.SaveChanges();
            return publicacaoUsuario;
        }

        public IQueryable ObterPublicacaoUsuarioPorUsuarioId(long id) => context.publicacaoUsuarios.Where(iu => iu.UsuarioId == id).Include(i => i.publicacao);
    }
}
