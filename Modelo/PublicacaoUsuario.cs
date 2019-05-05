using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class PublicacaoUsuario
    {
        public long? PublicacaoUsuarioId { get; set; }
        public string PublicacaoDescricao { get; set; }

        public long? PublicacaoId { get; set; }
        public long? UsuarioId { get; set; }

        public Modelo.Publicacao publicacao { get; set; }
        public Modelo.Usuarios usuarios { get; set; }
    }
}
