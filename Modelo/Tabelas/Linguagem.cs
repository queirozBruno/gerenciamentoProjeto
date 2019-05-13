using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Linguagem
    {
        public long? LinguagemId { get; set; }
        public string LinguagemNome { get; set; }

        public virtual ICollection<LinguagemUsuario> LinguagemUsuarios { get; set; }
    }
}
