using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelo
{
    public class Usuario
    {
        [Key]
        public long? UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioSobrenome { get; set; }
        public string UsuarioSenha { get; set; }
        public string UsuarioEmail { get; set; }
        public string UsuarioCPF { get; set; }
        public string UsuarioTelefone { get; set; }

        public virtual ICollection<PublicacaoUsuario> PublicacaoUsuarios { get; set; }
        public virtual ICollection<CompetenciaUsuario> CompetenciaUsuarios { get; set; }
        public virtual ICollection<Experiencia> Experiencias { get; set; }
        public virtual ICollection<FormacaoAcademica> FormacaoAcademicas { get; set; }
        public virtual ICollection<CursoUsuario> CursoUsuarios { get; set; }
        public virtual ICollection<CertificadoUsuario> CertificadoUsuarios { get; set; }
        public virtual ICollection<IdiomaUsuario> IdiomaUsuarios { get; set; }
        public virtual ICollection<LinguagemUsuario> LinguagemUsuarios { get; set; }
    }
}
