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
    class LinguagemUsuarioDAL
    {
        private EFContext context = new EFContext();

        public void CriarLinguagemUsuario(LinguagemUsuario linguagemUsuario)
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

        public LinguagemUsuario EliminarLinguagemUsuario(long id)
        {
            LinguagemUsuario linguagemUsuario = ObterLinguagemUsuarioPorId(id);
            context.linguagemUsuarios.Remove(linguagemUsuario);
            context.SaveChanges();
            return linguagemUsuario;
        }
    }
}
