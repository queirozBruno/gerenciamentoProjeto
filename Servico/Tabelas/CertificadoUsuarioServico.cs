using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class CertificadoUsuarioServico
    {
        private CertificadoUsuarioDAL certificadoUsuarioDAL = new CertificadoUsuarioDAL();

        public IQueryable ObterCertificadoUsuarioClassificadosPorNome()
        {
            return certificadoUsuarioDAL.ObterCertificadoUsuarioClassificadosPorNome();
        }

        public CertificadoUsuario ObterCertificadoUsuarioPorId(long id)
        {
            return certificadoUsuarioDAL.ObterCertificadoUsuarioPorId(id);
        }

        public void GravarCertificadoUsuario(CertificadoUsuario certificadoUsuario)
        {
            certificadoUsuarioDAL.GravarCertificadoUsuario(certificadoUsuario);
        }

        public CertificadoUsuario EliminarCertificadoUsuarioPorId(long id)
        {
            return certificadoUsuarioDAL.EliminarCertificadoUsuarioPorId(id);
        }

        public IQueryable ObterCertificadoUsuarioPorUsuarioId(long id) => certificadoUsuarioDAL.ObterCertificadoUsuarioPorUsuarioId(id);
    }
}
