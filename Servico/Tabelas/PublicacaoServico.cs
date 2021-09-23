using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class PublicacaoServico
    {
        private PublicacaoDAL publicacaoDAL = new PublicacaoDAL();

        public IQueryable ObterPublicacoesClassificadasPorNome()
        {
            return publicacaoDAL.ObterProjetosClassificadosPorNome();
        }

        public void GravarPublicacao(Publicacao publicacao)
        {
            publicacaoDAL.GravarPublicacao(publicacao);
        }

        public Publicacao ObterPublicacaoPorId(long id)
        {
            return publicacaoDAL.ObterPublicacaoPorId(id);
        }

        public Publicacao EliminarPublicacaoPorId(long id)
        {
            return publicacaoDAL.EliminarPublicacaoPorId(id);
        }

        public Publicacao ObterPublicacaoPorNome(string publicacao) => publicacaoDAL.ObterPublicacaoPorNome(publicacao);

        public bool VerificaSePublicacaoExiste(string publicacao) => publicacaoDAL.VerificaSePublicacaoExiste(publicacao);
    }
}
