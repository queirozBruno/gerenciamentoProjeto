using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class Amizade
    {
        [Key]
        public long? AmizadeId { get; set; }
        public long UsuarioId { get; set; }
        public long AmigoId { get; set; }
        public DateTime AmizadeDataSolicitaçao { get; set; }
        public string AmizadeDataAceitacao { get; set; }
        public string AmizadeFlag { get; set; } //P (Pendente), A (Aprovado) ou R (Recusado)

        public Usuario usuario { get; set; }
    }
}
