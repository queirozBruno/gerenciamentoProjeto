using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class IntegranteServico
    {
        private IntegranteDAL integranteDAL = new IntegranteDAL();

        public void GravarIntegrante(Integrante integrante)
        {
            integranteDAL.GravarIntegrante(integrante);
        }

        public Integrante ObterIntegrantePorId(long id)
        {
            return integranteDAL.ObterIntegrantePorId(id);
        }

        public Integrante EliminarIntegrantePorId(long id)
        {
            return integranteDAL.EliminarIntegrantePorId(id);
        }
    }
}
