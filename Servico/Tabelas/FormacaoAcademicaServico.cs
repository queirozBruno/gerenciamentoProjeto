﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico.Tabelas
{
    public class FormacaoAcademicaServico
    {
        private FormacaoAcademicaDAL formacaoAcademicaDAL = new FormacaoAcademicaDAL();

        public IQueryable ObterFormacoesAcademicasClassificadasPorNome()
        {
            return formacaoAcademicaDAL.ObterFormacaoAcademicasClassificadasPorNome();
        }

        public void GravarFormacaoAcademica(FormacaoAcademica formacaoAcademica)
        {
            formacaoAcademicaDAL.GravarFormacaoAcademica(formacaoAcademica);
        }

        public FormacaoAcademica ObterFormacaoAcademicaPorId(long id)
        {
            return formacaoAcademicaDAL.ObterFormacaoAcademicaPorId(id);
        }

        public FormacaoAcademica EliminarFormacaoAcademicaPorId(long id)
        {
            return formacaoAcademicaDAL.EliminarFormacaoAcademicaPorId(id);
        }
    }
}
