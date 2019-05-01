using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Usuarios
    {
        public long? UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioSobrenome { get; set; }
        public string UsuarioSenha { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioCPF { get; set; }
        public string UsuarioTelefone { get; set; }
    }
}
