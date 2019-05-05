using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CursoUsuario
    {
        public long? CursoId { get; set; }
        public long? UsuarioId { get; set; }

        public Modelo.Curso curso { get; set; }
        public Modelo.Usuarios usuarios { get; set; }
    }
}
