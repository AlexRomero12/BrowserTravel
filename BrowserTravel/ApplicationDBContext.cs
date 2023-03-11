// <copyright file="ApplicationDBContext.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel
{
    using BrowserTravel.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Application DB Context.
    /// </summary>
    public class ApplicationDBContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDBContext"/> class.
        /// </summary>
        /// <param name="options">DbContextOptions.</param>
        public ApplicationDBContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets autores DbSet.
        /// </summary>
        public DbSet<Autor> Autores { get; set; }

        /// <summary>
        /// Gets or sets editoriales DbSet.
        /// </summary>
        public DbSet<Editorial> Editoriales { get; set; }

        /// <summary>
        /// Gets or sets libros DbSet.
        /// </summary>
        public DbSet<Libro> Libros { get; set; }

        /// <summary>
        /// Gets or sets autores_has_libros DbSet.
        /// </summary>
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
