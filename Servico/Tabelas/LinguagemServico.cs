using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    class LinguagemServico
    {
        private LinguagemDAL linguagemDAL = new LinguagemDAL();

        public void GravarLinguagem(Linguagem linguagem)
        {
            linguagemDAL.GravarLinguagem(linguagem);
        }

        public Linguagem ObterLinguagemPorId(long id)
        {
            return linguagemDAL.ObterLinguagemPorId(id);
        }

        public Linguagem EliminarLinguagemPorId(long id)
        {
            return linguagemDAL.EliminarLinguagemPorId(id);
        }
    }
}
