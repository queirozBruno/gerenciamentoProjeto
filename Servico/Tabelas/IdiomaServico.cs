using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    class IdiomaServico
    {
        private IdiomaDAL idiomaDAL = new IdiomaDAL();

        public void GravarIdioma(Idioma idioma)
        {
            idiomaDAL.GravarIdioma(idioma);
        }

        public Idioma ObterIdiomaPorId(long id)
        {
            return idiomaDAL.ObterIdiomaPorId(id);
        }

        public Idioma EliminarIdiomaPorId(long id)
        {
            return idiomaDAL.EliminarIdiomaPorId(id);
        }
    }
}
