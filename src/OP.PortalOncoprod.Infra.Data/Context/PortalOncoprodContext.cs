using System;
using System.Data.Entity;
using System.Linq;
using SistemaIndexador.Domain.Entities;

namespace SistemaIndexador.Infra.Data.Context
{
    public class PortalOncoprodContext : DbContext
    {
        public PortalOncoprodContext() : base("DefaultConnection")
        {
            
        }

        ////public DbSet<TabelaPrecoOncoprod> TabelaPrecoOncoprods { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        //public DbSet<PerfilAcesso> PerfilAcessos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //// General Custom Context Properties
            //modelBuilder.Properties()
            //    .Where(p => p.Name == p.ReflectedType.Name + "Id")
            //    .Configure(p => p.IsKey());

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasColumnType("varchar"));

            //modelBuilder.Properties<string>()
            //    .Configure(p => p.HasMaxLength(100));

            //modelBuilder.Configurations.Add(new ClienteConfig());
            //modelBuilder.Configurations.Add(new EnderecoConfig());
            //modelBuilder.Configurations.Add(new TabelaPrecoOncoprodConfig());

            //base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

    }

    // Classe para trocar a ConnectionString do EF em tempo de execução.
    public static class ChangeDb
    {
        public static void ChangeConnection(this PortalOncoprodContext context, string cn)
        {
            context.Database.Connection.ConnectionString = cn;
        }
    }
}