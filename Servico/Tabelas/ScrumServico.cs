using Modelo.Tabelas;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class ScrumServico
    {
        private ScrumDAL scrumDAL = new ScrumDAL();
        public void GravarScrum(Scrum scrum) => scrumDAL.GravarScrum(scrum);

        public Scrum ObterScrumPorId(long id) => scrumDAL.ObterScrumPorId(id);

        public Scrum EliminarScrumPorId(long id) => scrumDAL.EliminarScrumPorId(id);

        public bool VerificarSeExisteScrum(long id) => scrumDAL.VerificarSeExisteScrum(id);

        public long? RecuperaIdScrum(long id) => scrumDAL.RecuperaIdScrum(id);
    }
}
