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
    class FormacaoAcademicaDAL
    {
        private EFContext context = new EFContext();

        public void CriarFormacaoAcademica(FormacaoAcademica formacaoAcademica)
        {
            if (formacaoAcademica.FormacaoId == null)
            {
                context.formacaoAcademicas.Add(formacaoAcademica);
            }
            else
            {
                context.Entry(formacaoAcademica).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public FormacaoAcademica ObterFormacaoAcademicaPorId(long id)
        {
            return context.formacaoAcademicas.Where(fa => fa.FormacaoId == id).Include(u => u.usuario).First();
        }

        public FormacaoAcademica EliminarFormacaoAcademica(long id)
        {
            FormacaoAcademica formacaoAcademica = ObterFormacaoAcademicaPorId(id);
            context.formacaoAcademicas.Remove(formacaoAcademica);
            context.SaveChanges();
            return formacaoAcademica;
        }
    }
}
