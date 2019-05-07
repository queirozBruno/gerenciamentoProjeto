using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Curso
    {
        public long? CursoId { get; set; }
        public string CursoNome { get; set; }
        public string CursoDescricao { get; set; }

        public virtual ICollection<CursoUsuario> CursoUsuarios { get; set; }
    }
}
