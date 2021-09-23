using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class ProjetoServico
    {
        private ProjetoDAL projetoDAL = new ProjetoDAL();
        
        public long? ObterUltimoProjetoPorId()
        {
            return projetoDAL.ObterUltimoProjetoPorId();
        }

        public IQueryable ObterProjetosClassificadosPorNome()
        {
            return projetoDAL.ObterProjetosClassificadosPorNome();
        }        

        public void GravarProjeto(Projeto projeto)
        {
            projetoDAL.GravarProjeto(projeto);
        }

        public Projeto ObterProjetoPorId(long id)
        {
            return projetoDAL.ObterProjetoPorId(id);
        }

        public Projeto EliminarProjetoPorId(long id)
        {
            return projetoDAL.EliminarProjetoPorId(id);
        }
    }
}
