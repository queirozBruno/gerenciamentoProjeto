using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class FormacaoAcademica
    {
        [Key]
        public long? FormacaoId { get; set; }
        public string FormacaoInstituicao { get; set; }
        public string FormacaoFormacao { get; set; }
        public string FormacaoArea { get; set; }
        public DateTime FormacaoAnoIni { get; set; }
        public DateTime FormacaoAnoFim { get; set; }
        public string FormacaoDescricao { get; set; }

        public long? UsuarioId { get; set; }

        public Modelo.Usuario usuario { get; set; }
    }
}
