using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    class ExperienciaServico
    {
        private ExperienciaDAL experienciaDAL = new ExperienciaDAL();

        public void GravarExperiencia(Experiencia experiencia)
        {
            experienciaDAL.GravarExperiencia(experiencia);
        }

        public Experiencia ObterExperienciaPorId(long id)
        {
            return experienciaDAL.ObterExperienciaPorId(id);
        }

        public Experiencia EliminarExperienciaPorId(long id)
        {
            return experienciaDAL.EliminarExperienciaPorId(id);
        }
    }
}
