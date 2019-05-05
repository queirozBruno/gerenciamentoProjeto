using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class LinguagemUsuario
    {
        public long? LinguagemUsuarioId { get; set; }

        public long? LinguagemId { get; set; }
        public long? UsuarioId { get; set; }

        public Modelo.Linguagem linguagem { get; set; }
        public Modelo.Usuarios usuarios { get; set; }
    }
}
