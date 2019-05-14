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
    public class CertificadoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterCertificadosClassificadosPorNome()
        {
            return context.certificados.OrderBy(n => n.CertificadoNome);
        }

        //Inserção e atualização
        public void GravarCertificado(Certificado certificado)
        {
            if (certificado.CertificadoId == null)
            {
                context.certificados.Add(certificado);
            }
            else
            {
                context.Entry(certificado).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        //Leitura
        public Certificado ObterCertificadoPorId(long id)
        {
            return context.certificados.Where(c => c.CertificadoId == id).First();
        }
        
        //Delete
        public Certificado EliminarCertificadoPorId(long id)
        {
            Certificado certificado = ObterCertificadoPorId(id);
            context.certificados.Remove(certificado);
            context.SaveChanges();
            return certificado;
        }
    }
}
