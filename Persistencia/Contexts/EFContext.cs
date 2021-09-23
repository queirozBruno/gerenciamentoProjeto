using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Modelo;
using Modelo.Tabelas;

namespace Persistencia.Contexts
{
    class EFContext:DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>() //Faz com que o BD seja recriado toda vez que uma modificação acontecer
                );
        }

        public DbSet<Certificado> certificados { get; set; }
        public DbSet<CertificadoUsuario> certificadoUsuarios { get; set; }
        public DbSet<Competencia> competencias { get; set; }
        public DbSet<CompetenciaUsuario> competenciaUsuarios { get; set; }
        public DbSet<CursoUsuario> cursoUsuarios { get; set; }
        public DbSet<Experiencia> experiencias { get; set; }
        public DbSet<FormacaoAcademica> formacaoAcademicas { get; set; }
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
        public DbSet<Scrum> scrums { get; set; }
        public DbSet<SprintBacklog> sprintBacklogs { get; set; }
        public DbSet<Sprint> sprints { get; set; }
        public DbSet<SprintFator> sprintFators { get; set; }
        public DbSet<ProductBacklog> productBacklogs { get; set; }
        public DbSet<HistoricoTarefa> historicoTarefas { get; set; }
        public DbSet<EquipeScrum> equipeScrums { get; set; }
        public DbSet<Amizade> amizades { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
