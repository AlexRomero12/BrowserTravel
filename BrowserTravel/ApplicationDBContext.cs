// <copyright file="ApplicationDBContext.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel
{
    using BrowserTravel.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Application Data Base Context.
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
    }
}
