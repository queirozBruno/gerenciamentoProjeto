using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class CursoUsuarioServico
    {
        private CursoUsuarioDAL cursoUsuarioDAL = new CursoUsuarioDAL();

        public void GravarCursoUsuario(CursoUsuario cursoUsuario)
        {
            cursoUsuarioDAL.GravarCursoUsuario(cursoUsuario);
        }

        public CursoUsuario ObterCursoUsuarioPorId(long id)
        {
            return cursoUsuarioDAL.ObterCursoUsuarioPorId(id);
        }

        public CursoUsuario EliminarCursoUsuarioPorId(long id)
        {
            return cursoUsuarioDAL.EliminarCursoUsuarioPorId(id);
        }
    }
}
