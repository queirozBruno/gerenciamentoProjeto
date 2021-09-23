using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class IdiomaServico
    {
        private IdiomaDAL idiomaDAL = new IdiomaDAL();

        public IQueryable ObterIdiomasClassificadosPorNome()
        {
            return idiomaDAL.ObterIdiomaClassificadosPorNome();
        }

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

        public Idioma ObterIdiomaPorNome(string idioma) => idiomaDAL.ObterIdiomaPorNome(idioma);

        public bool VerificaSeIdiomaExiste(string idioma) => idiomaDAL.VerificaSeIdiomaExiste(idioma);
    }
}
