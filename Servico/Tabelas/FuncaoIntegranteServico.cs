using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    class FuncaoIntegranteServico
    {
        private FuncaoIntegranteDAL funcaoIntegranteDAL = new FuncaoIntegranteDAL();

        public void GravarFuncaoIntegrante(FuncaoIntegrante funcaoIntegrante)
        {
            funcaoIntegranteDAL.GravarFuncaoIntegrante(funcaoIntegrante);
        }

        public FuncaoIntegrante ObterFuncaoIntegrantePorId(long id)
        {
            return funcaoIntegranteDAL.ObterFuncaoIntegrantePorId(id);
        }

        public FuncaoIntegrante EliminarFuncaoIntegrantePorId(long id)
        {
            return funcaoIntegranteDAL.EliminarFuncaoIntegrantePorId(id);
        }
    }
}
