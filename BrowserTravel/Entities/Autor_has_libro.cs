// <copyright file="Autor_has_libro.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Autor has libro.
    /// </summary>
    public class Autor_has_libro
    {
        /// <summary>
        /// Gets or sets autor identifier.
        /// </summary>
        [Key]
        [Required]
        public int AutorId { get; set; }

        /// <summary>
        /// Gets or sets libro identifier.
        /// </summary>
        [Key]
        [Required]
        public int LibroId { get; set; }

        /// <summary>
        /// Gets or sets autor entity.
        /// </summary>
        public Autor Autor { get; set; }

        /// <summary>
        /// Gets or sets libro entity.
        /// </summary>
        public Libro Libro { get; set; }
    }
}
