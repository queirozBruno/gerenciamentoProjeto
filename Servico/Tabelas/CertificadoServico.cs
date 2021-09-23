using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class CertificadoServico
    {
        private CertificadoDAL certificadoDAL = new CertificadoDAL();

        public IQueryable ObterCertificadosClassificadosPorNome()
        {
            return certificadoDAL.ObterCertificadosClassificadosPorNome();
        }

        public Certificado ObterCertificadoPorId(long id)
        {
            return certificadoDAL.ObterCertificadoPorId(id);
        }

        public void GravarCertificado(Certificado certificado)
        {
            certificadoDAL.GravarCertificado(certificado);
        }

        public Certificado EliminarCertificadoPorId(long id)
        {
            return certificadoDAL.EliminarCertificadoPorId(id);
        }

        public Certificado ObterCertificadoPorNome(string certificado) => certificadoDAL.ObterCertificadoPorNome(certificado);
        public bool VerificaSeCertificadoExiste(string certificado) => certificadoDAL.VerificaSeCertificadoExiste(certificado);
    }
}
