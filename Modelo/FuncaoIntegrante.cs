using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class FuncaoIntegrante
    {
        public long? FuncaoIntegranteId { get; set; }

        public long? IntegranteId { get; set; }
        public long? FuncaoId { get; set; }

        public Modelo.Integrante integrante { get; set; }
        public Modelo.Funcao funcao { get; set; }
    }
}
