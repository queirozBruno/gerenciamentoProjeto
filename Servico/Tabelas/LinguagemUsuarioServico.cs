using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    class LinguagemUsuarioServico
    {
        private LinguagemUsuarioDAL linguagemUsuarioDAL = new LinguagemUsuarioDAL();

        public void GravarLinguagemUsuario(LinguagemUsuario linguagemUsuario)
        {
            linguagemUsuarioDAL.GravarLinguagemUsuario(linguagemUsuario);
        }

        public LinguagemUsuario ObterLinguagemUsuarioPorId(long id)
        {
            return linguagemUsuarioDAL.ObterLinguagemUsuarioPorId(id);
        }

        public LinguagemUsuario EliminarLinguagemUsuarioPorId(long id)
        {
            return linguagemUsuarioDAL.EliminarLinguagemUsuarioPorId(id);
        }
    }
}
