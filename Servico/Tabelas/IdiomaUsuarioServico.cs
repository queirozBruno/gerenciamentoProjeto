using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class IdiomaUsuarioServico
    {
        private IdiomaUsuarioDAL idiomaUsuarioDAL = new IdiomaUsuarioDAL();

        public void GravarUsuarioIdioma(IdiomaUsuario idiomaUsuario)
        {
            idiomaUsuarioDAL.GravarIdiomaUsuario(idiomaUsuario);
        }

        public IdiomaUsuario ObterIdiomaUsuarioPorId(long id)
        {
            return idiomaUsuarioDAL.ObterIdiomaUsuarioPorId(id);
        }

        public IdiomaUsuario EliminarIdiomaUsuarioPorId(long id)
        {
            return idiomaUsuarioDAL.EliminarIdiomaUsuarioPorId(id);
        }
    }
}
