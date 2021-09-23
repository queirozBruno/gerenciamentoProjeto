using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    //Esta classe destina-se a cadastrar os fatores que podem ter influenciado nos resultados. Ex.: "Fulano e Cicrano de férias durante toda a sprint"
    public class SprintFator
    {
        [Key]
        public long? SprintFatorId { get; set; }
        public long SprintId { get; set; }
        public string SprintFatorDescricao { get; set; }
    }
}
