using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class FuncionalidadeServico
    {
        private FuncionalidadeDAL funcionalidadeDAL = new FuncionalidadeDAL();

        public IQueryable ObterFuncionalidadesClassificadasPorNome(long ProjetoId)
        {
            return funcionalidadeDAL.ObterFuncionalidadesClassificadasPorNome(ProjetoId);
        }

        public void GravarFuncionalidade(Funcionalidade funcionalidade)
        {
            funcionalidadeDAL.GravarFuncionalidade(funcionalidade);
        }

        public Funcionalidade ObterFuncionalidadePorId(long id)
        {
            return funcionalidadeDAL.ObterFuncionalidadePorId(id);
        }

        public Funcionalidade EliminarFuncionalidadePorId(long id)
        {
            return funcionalidadeDAL.EliminarFuncionalidadePorId(id);
        }
    }
}
