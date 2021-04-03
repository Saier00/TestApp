using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TestApp.Models
{
    public class TestContext : DbContext
    {
        public TestContext() : base("DefaultConnection")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Bind primary key
            modelBuilder.Entity<Catalog>().HasKey(p => p.Id);
            modelBuilder.Entity<Aggregate>().HasKey(p => p.Id);
            modelBuilder.Entity<Model>().HasKey(p => p.Id);
            modelBuilder.Entity<CatalogLevel>().HasKey(p => p.Id);

            //Change table names to expected
            modelBuilder.Entity<Catalog>().ToTable("Catalog");
            modelBuilder.Entity<Aggregate>().ToTable("Aggregate");
            modelBuilder.Entity<Model>().ToTable("Model");
            modelBuilder.Entity<CatalogLevel>().ToTable("catalog_level");
            //One to many rls 
            modelBuilder.Entity<Catalog>().HasMany(c => c.Aggregates).WithRequired(a => a.Catalog).HasForeignKey(m => m.CatalogId);
            modelBuilder.Entity<Aggregate>().HasMany(c => c.Models).WithRequired(a => a.Aggregate).HasForeignKey(m => m.AggregateId);
            //One to one rls for TPH models
            modelBuilder.Entity<CatalogMap>().HasRequired(c => c.Catalog).WithRequiredPrincipal(c => c.CatalogMap);
            modelBuilder.Entity<AggregateMap>().HasRequired(c => c.Aggregate).WithRequiredPrincipal(c => c.AggregateMap);
            modelBuilder.Entity<ModelMap>().HasRequired(c => c.Model).WithRequiredPrincipal(c => c.ModelMap);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Aggregate> Aggregates { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<CatalogLevel> CatalogLevels { get; set; }
        public DbSet<CatalogMap> CatalogMaps { get; set; }
        public DbSet<AggregateMap> AggregateMaps { get; set; }
        public DbSet<ModelMap> ModelMaps { get; set; }

    }
}