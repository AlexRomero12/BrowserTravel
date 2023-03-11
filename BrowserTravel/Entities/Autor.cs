using System.ComponentModel.DataAnnotations;

namespace BrowserTravel.Entities
{
    public class Autor
    {
        [Key]
        [MaxLength(10)]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        public string Apellido { get; set; }
    }
}
