using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class CompetenciaUsuario
    {
        public long? CompetenciaUsuarioId { get; set; }

        public long? UsuarioId { get; set; }
        public long? CompetenciaId { get; set; }

        public Modelo.Usuario usuario { get; set; }
        public Modelo.Competencia competencia { get; set; }
    }
}
