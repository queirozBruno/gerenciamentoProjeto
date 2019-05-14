using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    class ResponsavelServico
    {
        private ResponsavelDAL responsavelDAL = new ResponsavelDAL();

        public void GravarResponsavel(Responsavel responsavel)
        {
            responsavelDAL.GravarResponsavel(responsavel);
        }

        public Responsavel ObterResponsavelPorId(long id)
        {
            return responsavelDAL.ObterResponsavelPorId(id);
        }

        public Responsavel EliminarResponsavelPorId(long id)
        {
            return responsavelDAL.EliminarResponsavelPorId(id);
        }
    }
}
