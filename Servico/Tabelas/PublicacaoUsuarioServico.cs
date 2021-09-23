using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class PublicacaoUsuarioServico
    {
        private PublicacaoUsuarioDAL publicacaoUsuarioDAL = new PublicacaoUsuarioDAL();

        public void GravarPublicacaoUsuario(PublicacaoUsuario publicacaoUsuario)
        {
            publicacaoUsuarioDAL.GravarPublicacaoUsuario(publicacaoUsuario);
        }

        public PublicacaoUsuario ObterPublicacaoUsuarioPorId(long id)
        {
            return publicacaoUsuarioDAL.ObterPublicacaoUsuarioPorId(id);
        }

        public PublicacaoUsuario EliminarPublicacaoUsuarioPorId(long id)
        {
            return publicacaoUsuarioDAL.EliminarPublicacaoUsuarioPorId(id);
        }

        public IQueryable ObterPublicacaoUsuarioPorUsuarioId(long id) => publicacaoUsuarioDAL.ObterPublicacaoUsuarioPorUsuarioId(id);
    }
}
