using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class AmizadeDAL
    {
        private EFContext context = new EFContext();

        public void GravarAmizade(Amizade amizade)
        {
            if (amizade.AmizadeId == null)
            {
                context.amizades.Add(amizade);
            }
            else
            {
                context.Entry(amizade).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Amizade ObterAmizadePorId(long id) => context.amizades.Where(a => a.AmizadeId == id).Include(u => u.usuario).First();

        public Amizade EliminarAmizadePorId(long id)
        {
            Amizade amizade = ObterAmizadePorId(id);
            context.amizades.Remove(amizade);
            context.SaveChanges();
            return amizade;
        }

        //Lista de Amizades
        public IQueryable ObterAmizadePorUsuarioId(long id) => context.amizades.Where(a => a.AmigoId == id && a.AmizadeFlag == "A").Include(u => u.usuario);

        public IQueryable ObterAmizadesPendentes(long id) => context.amizades.Where(a => a.AmigoId == id && a.AmizadeFlag == "P").Include(u => u.usuario);

        public string ObterQuantidadeAmizadesPendentes(long id) => context.amizades.Where(a => a.UsuarioId == id && a.AmizadeFlag == "P").Include(u => u.usuario).Count().ToString();

        //Lista de usuários, ainda não adicionados, exceto o usuário logado
        public IQueryable ObterUsuariosExcetoUsuarioId(long id) => context.usuarios.Where(u => u.UsuarioId != id).Include(l => l.LinguagemUsuarios);
    }
}
