using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CursoUsuario
    {
        public long? CursoUsuarioId { get; set; }

        public long? UsuarioId { get; set; }
        public String CursoNome { get; set; }
        public String CursoDescricao { get; set; }

        public Modelo.Usuario usuario { get; set; }
    }
}
