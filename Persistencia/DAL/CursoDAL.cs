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
    class CursoDAL
    {
        private EFContext context = new EFContext();

        //Inserção e atualização
        public void CriarCurso(Curso curso)
        {
            if (curso.CursoId == null)
            {
                context.cursos.Add(curso);
            }
            else
            {
                context.Entry(curso).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        //Leitura
        public Curso ObterCursoPorId(long id)
        {
            return context.cursos.Where(c => c.CursoId == id).First();
        }

        //Delete
        public Curso EliminarCurso (long id)
        {
            Curso curso = ObterCursoPorId(id);
            context.cursos.Remove(curso);
            context.SaveChanges();
            return curso;
        }
    }
}
