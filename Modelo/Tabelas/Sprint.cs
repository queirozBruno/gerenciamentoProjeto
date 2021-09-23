using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class Sprint
    {
        [Key]
        public long? SprintId { get; set; }
        public long ScrumId { get; set; }
        public string SprintNome { get; set; }
        public string SprintMeta { get; set; } //Ex.: "Permitir o código e o login de usuários no sistema"
        public bool SprintMetaAlcancada { get; set; } // Alcançou ou não a meta da sprint
        public string SprintReview { get; set; } //Pontos positivos e negativos da Sprint quando esta for terminada

        public virtual ICollection<SprintBacklog> SprintBacklogs { get; set; }
    }
}
