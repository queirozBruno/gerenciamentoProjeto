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
    class CompetenciaDAL
    {
        private EFContext context = new EFContext();

        //Inserção e atualização
        public void CriarCompetencia(Competencia competencia)
        {
            if (competencia.CompetenciaId == null)
            {
                context.competencias.Add(competencia);
            }
            else
            {
                context.Entry(competencia).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        //Leitura
        public Competencia ObeterCompetenciaPorId(long id)
        {
            return context.competencias.Where(c => c.CompetenciaId == id).First();
        }

        //Delete
        public Competencia EliminarCompetencia(long id)
        {
            Competencia competencia = ObeterCompetenciaPorId(id);
            context.competencias.Remove(competencia);
            context.SaveChanges();
            return competencia;
        }
    }
}
