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
    class CertificadoUsuarioDAL
    {
        private EFContext context = new EFContext();


        //Inserção e atualização
        public void CriarCertificadoUsuario(CertificadoUsuario certificadoUsuario)
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
        public CertificadoUsuario ObterCertificadoUsuarioPorId(long id) //Tem que ser IQueryable no lugar de CertificadoUsuario, mas dá erro
        {
            return context.certificadoUsuarios.Where(cul => cul.CertificadoUsuarioId == id).Include(c => c.certificado).Include(u => u.usuario).First();
        }

        //Delete
        public CertificadoUsuario EliminarCertificadoUsuario(long id)
        {
            CertificadoUsuario certificadoUsuario = ObterCertificadoUsuarioPorId(id);
            context.certificadoUsuarios.Remove(certificadoUsuario);
            context.SaveChanges();
            return certificadoUsuario;
        }
    }
}
