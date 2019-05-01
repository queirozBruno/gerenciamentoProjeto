using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class CertificadoUsuario
    {
        public long? CertificadoUsuarioId { get; set; }
        public DateTime CertificadoUsuarioDataEmissao { get; set; }
        public DateTime CertificadoUsuarioDataExpiracao { get; set; }
        public string CertificadoUsuarioCodCredencial { get; set; }
        public string CertificadoUsuarioUrlCredencial { get; set; }
        public string CertificadoUsuarioOrgEmissor { get; set; }

        public long? UsuarioId { get; set; }
        public long? CertificadoId { get; set; }

        public Modelo.Usuarios usuarios { get; set; }
        public Modelo.Certificado certificado { get; set; }
    }
}
