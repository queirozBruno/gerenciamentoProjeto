using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Competencia
    {
        public long? CompetenciaId { get; set; }
        public string CompetenciaNome { get; set; }

        public virtual ICollection<CompetenciaUsuario> CompetenciaUsuarios { get; set; }
    }
}
