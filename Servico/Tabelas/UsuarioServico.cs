using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class UsuarioServico
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        //public IQueryable ObterUsuariosClassificadosPorNome()
        //{
        //    return usuarioDAL.ObterUsuariosClassificadosPorNome();
        //}

        public void GravarUsuario(Usuario usuario)
        {
            usuarioDAL.GravarUsuarios(usuario);
        }

        public Usuario ObterUsuarioPorId(long id)
        {
            return usuarioDAL.ObterUsuarioPorId(id);
        }

        public Usuario EliminarUsuarioPorId(long id)
        {
            return usuarioDAL.EliminarUsuarioPorId(id);
        }
    }
}
