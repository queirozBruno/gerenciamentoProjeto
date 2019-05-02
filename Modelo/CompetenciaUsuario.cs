using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class CompetenciaUsuario
    {
        public long? CompetenciaUsuarioId { get; set; }

        public long? UsuarioId { get; set; }
        public long? CompetenciaId { get; set; }

        public Modelo.Usuarios usuarios { get; set; }
        public Modelo.Competencia competencia { get; set; }
    }
}
