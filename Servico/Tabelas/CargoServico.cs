using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class CargoServico
    {
        private CargoDAL cargoDAL = new CargoDAL();

        public IQueryable ObterCargosClassificadosPorNome()
        {
            return cargoDAL.ObterCargosClassificadosPorNome();
        }

        public Cargo ObterCargoPorId(long id)
        {
            return cargoDAL.ObterCargoPorId(id);
        }

        public void GravarCargo(Cargo cargo)
        {
            cargoDAL.GravarCargo(cargo);
        }

        public Cargo EliminarCargoPorId(long id)
        {
            return cargoDAL.EliminarCargoPorId(id);
        }
    }
}
