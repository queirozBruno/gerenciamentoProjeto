﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class CompetenciaUsuarioServico
    {
        private CompetenciaUsuarioDAL competenciaUsuarioDAL = new CompetenciaUsuarioDAL();

        public IQueryable ObterCompetenciaUsuariosClassificadosPorNome()
        {
            return competenciaUsuarioDAL.ObterCompetenciaUsuariosClassificadosPorNome();
        }

        public void GravarCompetenciaUsuario(CompetenciaUsuario competencia)
        {
            competenciaUsuarioDAL.GravarCompetenciaUsuario(competencia);
        }

        public CompetenciaUsuario ObterCompetenciaUsuarioPorId(long id)
        {
            return competenciaUsuarioDAL.ObterCompetenciUsuarioaPorId(id);
        }

        public CompetenciaUsuario EliminarCompetenciaUsuarioPorId(long id)
        {
            return competenciaUsuarioDAL.EliminarCompetenciaUsuarioPorId(id);
        }

        public IQueryable ObterCompetenciaUsuarioPorUsuarioId(long id) => competenciaUsuarioDAL.ObterCompetenciaUsuarioPorUsuarioId(id);
    }
}
