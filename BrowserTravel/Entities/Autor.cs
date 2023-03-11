// <copyright file="Autor.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Entity Autor.
    /// </summary>
    public class Autor
    {
        /// <summary>
        /// Gets or sets indetifier.
        /// </summary>
        [Key]
        [MaxLength(10)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets lastName.
        /// </summary>
        [Required]
        [StringLength(45)]
        public string Apellido { get; set; }

        public ICollection<Autor_has_libro> AutoresLibros { get; set; }
    }
}
