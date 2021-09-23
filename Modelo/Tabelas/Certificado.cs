using System.Collections.Generic;

namespace Modelo
{
    public class Certificado
    {
        public long? CertificadoId { get; set; }
        public string CertificadoNome { get; set; }

        public virtual ICollection<CertificadoUsuario> CertificadoUsuarios { get; set; }
    }
}
