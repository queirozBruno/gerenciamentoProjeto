using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Integrante
    {
        public long? IntegranteId { get; set; }
        public string IntegranteDescricao { get; set; }

        public long? ProjetoId { get; set; }
        public long? UsuarioId { get; set; }
        public long? CargoId { get; set; }

        public Modelo.Projeto projeto { get; set; }
        public Modelo.Usuarios usuarios { get; set; }
        public Modelo.Cargo cargo { get; set; }
    }
}
