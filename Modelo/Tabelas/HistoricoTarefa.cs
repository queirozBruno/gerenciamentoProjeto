using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class HistoricoTarefa
    {
        [Key]
        public long? HistoricoTarefaId { get; set; }
        public long SprintBacklogId { get; set; }
        public string HistoricoTarefaDescricao { get; set; }
    }
}
