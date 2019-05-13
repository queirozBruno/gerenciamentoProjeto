using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Funcionalidade
    {
        public long? FuncionalidadeId { get; set; }
        public string FuncionalidadeNome { get; set; }
        public DateTime FuncionalidadeDataIni { get; set; }
        public DateTime FuncionalidadeDataFim { get; set; }
        public string FuncionalidadeObservacao { get; set; }
        public string FuncionalidadeStatus { get; set; }

        public long? ProjetoId { get; set; }

        public Modelo.Projeto projeto { get; set; }

        public virtual ICollection<Responsavel> Responsavels { get; set; }
    }
}
