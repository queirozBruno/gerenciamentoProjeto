using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class IdiomaUsuario
    {
        public long? IdiomaUsuarioId { get; set; }
        public string IdiomaProficiencia { get; set; }

        public long? IdiomaId { get; set; }
        public long? UsuarioId { get; set; }

        public Modelo.Idioma idioma { get; set; }
        public Modelo.Usuarios usuarios { get; set; }
    }
}
