using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Responsavel
    {
        public long? ResponsavelId { get; set; }

        public long? FuncionalidadeId { get; set; }
        public long? IntegranteId { get; set; }

        public Modelo.Funcionalidade funcionalidade { get; set; }
        public Modelo.Integrante integrante { get; set; }
    }
}
