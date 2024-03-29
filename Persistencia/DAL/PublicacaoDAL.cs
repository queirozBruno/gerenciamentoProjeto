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
    public class PublicacaoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterProjetosClassificadosPorNome()
        {
            return context.projetos.OrderBy(n => n.ProjetoNome);
        }

        public void GravarPublicacao(Publicacao publicacao)
        {
            if (publicacao.PublicacaoId == null)
            {
                context.publicacaos.Add(publicacao);
            }
            else
            {
                context.Entry(publicacao).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Publicacao ObterPublicacaoPorId(long id)
        {
            return context.publicacaos.Where(p => p.PublicacaoId == id).First();
        }

        public Publicacao EliminarPublicacaoPorId(long id)
        {
            Publicacao publicacao = ObterPublicacaoPorId(id);
            context.publicacaos.Remove(publicacao);
            context.SaveChanges();
            return publicacao;
        }

        public Publicacao ObterPublicacaoPorNome(string publicacao) => context.publicacaos.Where(i => i.PublicacaoTitulo.ToUpper() == publicacao.ToUpper()).FirstOrDefault();

        public bool VerificaSePublicacaoExiste(string publicacao) => context.publicacaos.Where(i => i.PublicacaoTitulo.ToUpper() == publicacao.ToUpper()).Any();
    }
}
