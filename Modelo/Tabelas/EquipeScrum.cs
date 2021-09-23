using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Tabelas
{
    public class EquipeScrum
    {
        [Key]
        public long? EquipeScrumId { get; set; }
        public long IntegranteId { get; set; }
        public string EquipeScrumPapel { get; set; } //Product Owner, Scrum Master e Equipe de Desenvolvimento (Definir via programação)        
    }
}
