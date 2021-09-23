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

        public IQueryable ObterIntegrantesClassificadosPorNome(long? projetoId) => integranteDAL.ObterIntegrantesClassificadosPorNome(projetoId);

        public Integrante ObterIntegrantePorEmail(string email) => integranteDAL.ObterIntegrantePorEmail(email);

        public object ObterProjetosPorUsuario(long id) => integranteDAL.ObterProjetosPorUsuario(id);

        public void GravarIntegrante(Integrante integrante) => integranteDAL.GravarIntegrante(integrante);        

        public Integrante ObterIntegrantePorId(long id) => integranteDAL.ObterIntegrantePorId(id);

        public Integrante EliminarIntegrantePorId(long id) => integranteDAL.EliminarIntegrantePorId(id);

        public bool VerificarSeProjetoJaTemIntegrante(long id) => integranteDAL.VerificarSeProjetoJaTemIntegrante(id);
    }
}
