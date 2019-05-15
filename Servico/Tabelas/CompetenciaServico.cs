using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class CompetenciaServico
    {
        private CompetenciaDAL competenciaDAL = new CompetenciaDAL();

        public void GravarCompetencia(Competencia competencia)
        {
            competenciaDAL.GravarCompetencia(competencia);
        }

        public Competencia ObterCompetenciaPorId(long id)
        {
            return competenciaDAL.ObeterCompetenciaPorId(id);
        }

        public Competencia EliminarCompetenciaPorId(long id)
        {
            return competenciaDAL.EliminarCompetenciaPorId(id);
        }
    }
}
