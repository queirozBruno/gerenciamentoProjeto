using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Integrante
    {
        public long? IntegranteId { get; set; }
        public string IntegranteDescricao { get; set; }
        public string IntegranteFuncao { get; set; }

        public long? ProjetoId { get; set; }
        public long? UsuarioId { get; set; }

        public Projeto projeto { get; set; }
        public Usuario usuario { get; set; }

        public virtual ICollection<Responsavel> Responsaveis { get; set; }
    }
}
