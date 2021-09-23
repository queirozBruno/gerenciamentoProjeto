using System.Linq;
using Persistencia.Contexts;
using Modelo;
using System.Data.Entity;

namespace Persistencia.DAL
{
    public class LinguagemUsuarioDAL
    {
        private EFContext context = new EFContext();

        public void GravarLinguagemUsuario(LinguagemUsuario linguagemUsuario)
        {
            if (linguagemUsuario.LinguagemUsuarioId == null)
            {
                context.linguagemUsuarios.Add(linguagemUsuario);
            }
            else
            {
                context.Entry(linguagemUsuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public LinguagemUsuario ObterLinguagemUsuarioPorId(long id)
        {
            return context.linguagemUsuarios.Where(lu => lu.LinguagemUsuarioId == id).Include(l => l.linguagem).Include(u => u.usuario).First();
        }

        public LinguagemUsuario EliminarLinguagemUsuarioPorId(long id)
        {
            LinguagemUsuario linguagemUsuario = ObterLinguagemUsuarioPorId(id);
            context.linguagemUsuarios.Remove(linguagemUsuario);
            context.SaveChanges();
            return linguagemUsuario;
        }

        public IQueryable ObterLinguagemUsuarioPorUsuarioId(long id) => context.linguagemUsuarios.Where(iu => iu.UsuarioId == id).Include(i => i.linguagem);
    }
}
