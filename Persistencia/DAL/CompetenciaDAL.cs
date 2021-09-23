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
    public class CompetenciaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterCompetenciaClassificadasPorNome()
        {
            return context.competencias.OrderBy(n => n.CompetenciaNome);
        }

        //Inserção e atualização
        public void GravarCompetencia(Competencia competencia)
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
        public Competencia EliminarCompetenciaPorId(long id)
        {
            Competencia competencia = ObeterCompetenciaPorId(id);
            context.competencias.Remove(competencia);
            context.SaveChanges();
            return competencia;
        }

        public Competencia ObterCompetenciaPorNome(string competencia) => context.competencias.Where(i => i.CompetenciaNome.ToUpper() == competencia.ToUpper()).FirstOrDefault();

        public bool VerificaSeCompetenciaExiste(string competencia) => context.competencias.Where(i => i.CompetenciaNome.ToUpper() == competencia.ToUpper()).Any();
    }
}
