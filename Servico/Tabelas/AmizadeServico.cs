using Modelo.Tabelas;
using Persistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Tabelas
{
    public class AmizadeServico
    {
        private AmizadeDAL amizadeDAL = new AmizadeDAL();

        public void GravarAmizade(Amizade amizade) => amizadeDAL.GravarAmizade(amizade);

        public Amizade ObterAmizadePorId(long id) => amizadeDAL.ObterAmizadePorId(id);

        public Amizade EliminarAmizadePorId(long id) => amizadeDAL.EliminarAmizadePorId(id);

        public IQueryable ObterAmizadePorUsuarioId(long id) => amizadeDAL.ObterAmizadePorUsuarioId(id);

        public IQueryable ObterAmizadesPendentes(long id) => amizadeDAL.ObterAmizadesPendentes(id);

        public string ObterQuantidadeAmizadesPendentes(long id) => amizadeDAL.ObterQuantidadeAmizadesPendentes(id);

        public IQueryable ObterUsuariosExcetoUsuarioId(long id) => amizadeDAL.ObterUsuariosExcetoUsuarioId(id);
    }
}
