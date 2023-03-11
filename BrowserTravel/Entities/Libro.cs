// <copyright file="Libro.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Entity Libro.
    /// </summary>
    public class Libro
    {
        /// <summary>
        /// Gets or sets identificator.
        /// </summary>
        [Key]
        [Required]
        [MaxLength(13)]
        public int ISBN { get; set; }

        /// <summary>
        /// Gets or sets editorial ID.
        /// </summary>
        [Required]
        public Editorial EditorialID { get; set; }

        /// <summary>
        /// Gets or sets titulo.
        /// </summary>
        [Required]
        [MaxLength(45)]
        public string Titulo { get; set; }

        /// <summary>
        /// Gets or sets sinopsis.
        /// </summary>
        [Required]
        public string Sinopsis { get; set; }

        /// <summary>
        /// Gets or sets numeber of pages.
        /// </summary>
        [Required]
        [MaxLength(45)]
        public int N_paginas { get; set; }

        public ICollection<Autor_has_libro> AutoresLibros { get; set; }
    }
}
