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
    class FuncaoDAL
    {
        private EFContext context = new EFContext();

        public void CriarFuncao (Funcao funcao)
        {
            if (funcao.FuncaoId == null)
            {
                context.funcaos.Add(funcao);
            }
            else
            {
                context.Entry(funcao).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Funcao ObterFuncaoPorId(long id)
        {
            return context.funcaos.Where(f => f.FuncaoId == id).First();
        }

        public Funcao EliminarFuncao(long id)
        {
            Funcao funcao = ObterFuncaoPorId(id);
            context.funcaos.Remove(funcao);
            context.SaveChanges();
            return funcao;
        }
    }
}
