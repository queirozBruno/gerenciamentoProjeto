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
    class FuncionalidadeDAL
    {
        private EFContext context = new EFContext();

        public void CriarFuncionalidade(Funcionalidade funcionalidade)
        {
            if (funcionalidade.FuncionalidadeId == null)
            {
                context.funcionalidades.Add(funcionalidade);
            }
            else
            {
                context.Entry(funcionalidade).State = EntityState.Modified;
            }
        }

        public Funcionalidade ObterFuncionalidadePorId(long id)
        {
            return context.funcionalidades.Where(f => f.FuncionalidadeId == id).Include(p => p.projeto).First();
        }

        public Funcionalidade EliminarFuncionalidade(long id)
        {
            Funcionalidade funcionalidade = ObterFuncionalidadePorId(id);
            context.funcionalidades.Remove(funcionalidade);
            context.SaveChanges();
            return funcionalidade;
        }
    }
}
