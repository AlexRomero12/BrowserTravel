// <copyright file="Autor.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Entity Autor.
    /// </summary>
    public class Autor
    {
        /// <summary>
        /// Gets or sets indetifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(45)]
        [Remote(action: "ValidateAutorExist", controller: "Autor", AdditionalFields = nameof(Apellido))]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets lastName.
        /// </summary>
        [Required(ErrorMessage = "El {0} es requerido")]
        [StringLength(45)]
        [Remote(action: "ValidateAutorExist", controller: "Autor", AdditionalFields = nameof(Nombre))]
        public string Apellido { get; set; }

        public ICollection<Libro> Libros { get; set; }

        [NotMapped]
        public string NombreCompleto => $"{Nombre}, {Apellido}";

    }
}
