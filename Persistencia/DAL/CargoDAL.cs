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
    public class CargoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterCargosClassificadosPorNome()
        {
            return context.cargos.OrderBy(n => n.CargoNome);
        }

        //Esta operação serve tanto para inserção quanto para atualização
        public void GravarCargo(Cargo cargo)
        {
            if (cargo.CargoId == null)
            {
                context.cargos.Add(cargo);
            }
            else
            {
                context.Entry(cargo).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        //Leitura (Visualização)
        public Cargo ObterCargoPorId(long id)
        {
            return context.cargos.Where(c => c.CargoId == id).First();
        }

        public Cargo EliminarCargoPorId(long id)
        {
            Cargo cargo = ObterCargoPorId(id);
            context.cargos.Remove(cargo);
            context.SaveChanges();
            return cargo;
        }
    }
}
