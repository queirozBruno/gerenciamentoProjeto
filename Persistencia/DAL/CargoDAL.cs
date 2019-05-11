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
    class CargoDAL
    {
        private EFContext context = new EFContext();

        //Esta operação serve tanto para inserção quanto para atualização
        public void CriarCargo(Cargo cargo)
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

        public Cargo EliminarCargo(long id)
        {
            Cargo cargo = ObterCargoPorId(id);
            context.cargos.Remove(cargo);
            context.SaveChanges();
            return cargo;
        }
    }
}
