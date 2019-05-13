using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Experiencia
    {
        public long? ExperienciaId { get; set; }
        public string ExperienciaCargo { get; set; }
        public string ExperienciaEmpresa { get; set; }
        public string ExperienciaLocalidade { get; set; }
        public DateTime ExperienciaDataIni { get; set; }
        public DateTime ExperienciaDataFim { get; set; }
        public string ExperienciaDescricao { get; set; }

        public long? UsuarioId { get; set; }

        public Modelo.Usuario usuario { get; set; }
    }
}
