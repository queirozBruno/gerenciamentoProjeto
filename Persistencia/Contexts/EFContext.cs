using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Modelo;


namespace Persistencia.Contexts
{
    class EFContext:DbContext
    {
        public EFContext():base("Asp_Net_MVC_CS")
        {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>() //Faz com que o BD seja recriado toda vez que uma modificação acontecer
                );
        }

        public DbSet<Cargo> cargos { get; set; }
        public DbSet<Certificado> certificados { get; set; }
        public DbSet<CertificadoUsuario> certificadoUsuarios { get; set; }
        public DbSet<Competencia> competencias { get; set; }
        public DbSet<CompetenciaUsuario> competenciaUsuarios { get; set; }
        public DbSet<Curso> cursos { get; set; }
        public DbSet<CursoUsuario> cursoUsuarios { get; set; }
        public DbSet<Experiencia> experiencias { get; set; }
        public DbSet<FormacaoAcademica> formacaoAcademicas { get; set; }
        public DbSet<Funcao> funcaos { get; set; }
        public DbSet<FuncaoIntegrante> funcaoIntegrantes { get; set; }
        public DbSet<Funcionalidade> funcionalidades { get; set; }
        public DbSet<Idioma> idiomas { get; set; }
        public DbSet<IdiomaUsuario> idiomaUsuarios { get; set; }
        public DbSet<Integrante> integrantes { get; set; }
        public DbSet<Linguagem> linguagems { get; set; }
        public DbSet<LinguagemUsuario> linguagemUsuarios { get; set; }
        public DbSet<Projeto> projetos { get; set; }
        public DbSet<Publicacao> publicacaos { get; set; }
        public DbSet<PublicacaoUsuario> publicacaoUsuarios { get; set; }
        public DbSet<Responsavel> responsavels { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
