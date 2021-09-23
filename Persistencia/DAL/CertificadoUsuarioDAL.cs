using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contexts;
using Modelo;
using System.Data.Entity;

namespace Persistencia.DAL
{
    public class CertificadoUsuarioDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterCertificadoUsuarioClassificadosPorNome()
        {
            return context.certificadoUsuarios.Include(c => c.certificado).Include(u => u.usuario).OrderBy(n => n.usuario.UsuarioNome);
        }

        //Inserção e atualização
        public void GravarCertificadoUsuario(CertificadoUsuario certificadoUsuario)
        {
            if (certificadoUsuario.CertificadoUsuarioId == null)
            {
                context.certificadoUsuarios.Add(certificadoUsuario);
            }
            else
            {
                context.Entry(certificadoUsuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        //Leitura
        public CertificadoUsuario ObterCertificadoUsuarioPorId(long id)
        {
            return context.certificadoUsuarios.Where(cul => cul.CertificadoUsuarioId == id).Include(c => c.certificado).Include(u => u.usuario).First();
        }

        //Delete
        public CertificadoUsuario EliminarCertificadoUsuarioPorId(long id)
        {
            CertificadoUsuario certificadoUsuario = ObterCertificadoUsuarioPorId(id);
            context.certificadoUsuarios.Remove(certificadoUsuario);
            context.SaveChanges();
            return certificadoUsuario;
        }

        public IQueryable ObterCertificadoUsuarioPorUsuarioId(long id) => context.certificadoUsuarios.Where(iu => iu.UsuarioId == id).Include(i => i.certificado);
    }
}
