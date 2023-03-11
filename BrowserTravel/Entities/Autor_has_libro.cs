namespace BrowserTravel.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Autor has libro.
    /// </summary>
    public class Autor_has_libro
    {
        [Key]
        [Required]
        public int AutorId { get; set; }

        [Key]
        [Required]
        public int LibroId { get; set; }

        public Autor Autor { get; set; }

        public Libro Libro { get; set; }
    }
}
