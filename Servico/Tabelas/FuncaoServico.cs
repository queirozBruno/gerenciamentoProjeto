using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    class FuncaoServico
    {
        private FuncaoDAL funcaoDAL = new FuncaoDAL();

        public void GravarFuncao(Funcao funcao)
        {
            funcaoDAL.GravarFuncao(funcao);
        }

        public Funcao ObterFuncaoPorId(long id)
        {
            return funcaoDAL.ObterFuncaoPorId(id);
        }

        public Funcao EliminarFuncaoPorId(long id)
        {
            return funcaoDAL.EliminarFuncaoPorId(id);
        }
    }
}
