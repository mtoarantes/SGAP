namespace SGAP.DAL.EntityConfiguration
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Models;
    using Models.Configuracao;

    public partial class EntityConfiguration : DbContext
    {
        public EntityConfiguration()
            : base("name=SGAPDbContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("DBO");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        #region Pessoas
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        #endregion

        #region Perfil
        public virtual DbSet<Perfil> Perfil { get; set; }
        #endregion

        #region ConfiguracaoCentroResultado
        public virtual DbSet<ConfiguracaoCentroResultado> ConfiguracaoCentroResultado { get; set; }
        #endregion

    }
}
