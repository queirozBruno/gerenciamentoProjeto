using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class Scrum
    {
        [Key]
        public long? ScrumId { get; set; }
        public long ProjetoId { get; set; }
        public long ScrumPeriodoSprint { get; set; }

        public Modelo.Projeto projeto { get; set; }

        //public virtual ICollection<Sprint> Sprints { get; set; }
    }
}
