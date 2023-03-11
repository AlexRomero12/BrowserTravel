// <copyright file="Editorial.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Entity Editorial.
    /// </summary>
    public class Editorial
    {
        /// <summary>
        /// Gets or sets identifier.
        /// </summary>
        [Key]
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required]
        [MaxLength(45)]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets ubication.
        /// </summary>
        [Required]
        [MaxLength(45)]
        public string Sede { get; set; }

        public string NombreCompleto => $"{this.Nombre}, {this.Sede}";
    }
}
