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
        public string ExperienciaDescricao { get; set; }
        public long? UsuarioId { get; set; }
        public string ExperienciaDataInicio { get; set; }
        public string ExperienciaDataFinal { get; set; }
        public string ExperienciaLocal { get; set; }
        public string ExperienciaCargo {get; set;}
        public bool ExperienciaAtual { get; set; }
        public string ExperienciaTipo { get; set; }
        public string ExperienciaEmpresa { get; set; }

        public Usuario usuario { get; set; }
    }
}