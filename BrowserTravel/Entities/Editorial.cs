namespace BrowserTravel.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Entity Editorial.
    /// </summary>
    public class Editorial
    {
        /// <summary>
        /// Gets or sets identification.
        /// </summary>
        [Key]
        [Required]
        [MaxLength(10)]
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
    }
}
