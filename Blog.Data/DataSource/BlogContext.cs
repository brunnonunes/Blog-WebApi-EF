using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Blog.Data.Entities;

namespace Blog.Data.DataSource
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base(ConfigurationManager.ConnectionStrings["BlogDB"].ConnectionString)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
               .HasMany(t => t.Tags)
               .WithMany(t => t.Posts)
               .Map(m =>
               {    
                   m.ToTable("PostTag");
                   m.MapLeftKey("PostId");
                   m.MapRightKey("TagId");
               });

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
        }

    }
}
