using Modelo.Tabelas;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class SprintServico
    {
        private SprintDAL sprintDAL = new SprintDAL();

        public void GravarSprint(Sprint sprint) => sprintDAL.GravarSprint(sprint);

        public IQueryable ObterSprintPorIdScrum(long id) => sprintDAL.ObterSprintPorIdScrum(id);

        public Sprint ObterSprintPorId(long id) => sprintDAL.ObterSprintPorId(id);

        public Sprint EliminarSprintPorId(long id) => sprintDAL.EliminarSprintPorId(id);

        public bool VerificarSeExisteSprint(long id) => sprintDAL.VerificarSeExisteSprint(id);
    }
}
