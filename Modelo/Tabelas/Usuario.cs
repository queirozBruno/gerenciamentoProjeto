using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Modelo.Tabelas;

namespace Modelo
{
    public class Usuario
    {
        [Key]
        public long? UsuarioId { get; set; }

        public string UsuarioNome { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Senha muito fraca!")]
        public string UsuarioSenha { get; set; }

        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "E-mail inválido")]
        public string UsuarioEmail { get; set; }
        
        public string UsuarioCPF { get; set; }

        public string UsuarioTelefone { get; set; }

        //[Column(TypeName = "image")]
        //public byte[] UsuarioImagem { get; set; }
        public string UsuarioImagem { get; set; }
        public virtual ICollection<PublicacaoUsuario> PublicacaoUsuarios { get; set; }
        public virtual ICollection<CompetenciaUsuario> CompetenciaUsuarios { get; set; }
        public virtual ICollection<Experiencia> Experiencias { get; set; }
        public virtual ICollection<FormacaoAcademica> FormacaoAcademicas { get; set; }
        public virtual ICollection<CursoUsuario> CursoUsuarios { get; set; }
        public virtual ICollection<CertificadoUsuario> CertificadoUsuarios { get; set; }
        public virtual ICollection<IdiomaUsuario> IdiomaUsuarios { get; set; }
        public virtual ICollection<LinguagemUsuario> LinguagemUsuarios { get; set; }
        public virtual ICollection<Amizade> Amizades { get; set; }
    }
}
