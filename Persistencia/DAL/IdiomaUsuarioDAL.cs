﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Contexts;
using Modelo;
using System.Data.Entity;

namespace Persistencia.DAL
{
    public class IdiomaUsuarioDAL
    {
        private EFContext context = new EFContext();

        public void GravarIdiomaUsuario(IdiomaUsuario idiomaUsuario)
        {
            if (idiomaUsuario.IdiomaUsuarioId == null)
            {
                context.idiomaUsuarios.Add(idiomaUsuario);
            }
            else
            {
                context.Entry(idiomaUsuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public IdiomaUsuario ObterIdiomaUsuarioPorId(long id)
        {
            return context.idiomaUsuarios.Where(iu => iu.IdiomaUsuarioId == id).Include(i => i.idioma).Include(u => u.usuario).First();
        }

        public IdiomaUsuario EliminarIdiomaUsuarioPorId(long id)
        {
            IdiomaUsuario idiomaUsuario = ObterIdiomaUsuarioPorId(id);
            context.idiomaUsuarios.Remove(idiomaUsuario);
            context.SaveChanges();
            return idiomaUsuario;
        }

        public IQueryable ObterIdiomaUsuarioPorUsuarioId(long id) => context.idiomaUsuarios.Where(iu => iu.UsuarioId == id).Include(i => i.idioma);
    }
}
