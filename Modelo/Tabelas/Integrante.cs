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

        public long? ProjetoId { get; set; }
        public long? UsuarioId { get; set; }
        public long? CargoId { get; set; }

        public Modelo.Projeto projeto { get; set; }
        public Modelo.Usuario usuario { get; set; }
        public Modelo.Cargo cargo { get; set; }

        public virtual ICollection<FuncaoIntegrante> FuncaoIntegrantes { get; set; }
        public virtual ICollection<Responsavel> Responsavels { get; set; }
    }
}
