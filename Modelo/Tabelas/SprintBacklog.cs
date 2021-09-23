using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class SprintBacklog
    {
        [Key]
        public long? SprintBacklogId { get; set; }
        public long SprintId { get; set; }
        public long ProductBacklogId { get; set; }
        public long? EquipeScrumId { get; set; }
        public string SprintBacklogNome { get; set; }
        public string SprintBacklogDescricao { get; set; }
        public long SprintBacklogEstimativa { get; set; }
        public string SprintBacklogStatus { get; set; }

        public ProductBacklog productBacklog { get; set; }
        public Sprint sprint { get; set; }
    }
}
