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
    public class FuncaoIntegranteDAL
    {
        private EFContext context = new EFContext();

        public void GravarFuncaoIntegrante(FuncaoIntegrante funcaoIntegrante)
        {
            if (funcaoIntegrante.FuncaoIntegranteId == null)
            {
                context.funcaoIntegrantes.Add(funcaoIntegrante);
            }
            else
            {
                context.Entry(funcaoIntegrante).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public FuncaoIntegrante ObterFuncaoIntegrantePorId(long id)
        {
            return context.funcaoIntegrantes.Where(fi => fi.FuncaoIntegranteId == id).Include(f => f.funcao).Include(i => i.integrante).First();
        }

        public FuncaoIntegrante EliminarFuncaoIntegrantePorId(long id)
        {
            FuncaoIntegrante funcaoIntegrante = ObterFuncaoIntegrantePorId(id);
            context.funcaoIntegrantes.Remove(funcaoIntegrante);
            context.SaveChanges();
            return funcaoIntegrante;
        }
    }
}
