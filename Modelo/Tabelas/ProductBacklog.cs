using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class ProductBacklog
    {
        [Key]
        public long? ProductBacklogId { get; set; }
        public long? ScrumId { get; set; } //Preciso do id do projeto pra filtrar os backlogs relacionados
        public string ProductBacklogNome { get; set; }
        [Required]
        [Range(0,100)]
        public long ProductBacklogPrioridade { get; set; }
        public string ProductBacklogDescricao { get; set; }
        public string ProductBacklogNotas { get; set; } //As notas seriam as anotações que o P.O. tem a fazer para a equipe em relação às tarefas.

        public virtual ICollection<SprintBacklog> SprintBacklogs { get; set; }
    }
}
