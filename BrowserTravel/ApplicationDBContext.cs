using BrowserTravel.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BrowserTravel
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }

        public DbSet<Editorial> Editoriales { get; set; }

        public DbSet<Libro> Libros { get; set; }

        public DbSet<Autor_has_libro> Autores_has_libros { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Autor_has_libroConfiguration());
        }

        public class Autor_has_libroConfiguration : IEntityTypeConfiguration<Autor_has_libro>
        {
            public void Configure(EntityTypeBuilder<Autor_has_libro> builder)
            {
                builder.HasKey(al => new { al.AutorId, al.LibroId });

                builder.HasOne(al => al.Autor)
                       .WithMany(a => a.AutoresLibros)
                       .HasForeignKey(al => al.AutorId);

                builder.HasOne(al => al.Libro)
                       .WithMany(l => l.AutoresLibros)
                       .HasForeignKey(al => al.LibroId);
            }
        }
    }
}
