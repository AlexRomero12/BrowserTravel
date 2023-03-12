using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrowserTravel.Models
{
    public class Libro
    {
        [Key]
        public int ISBN { get; set; }
        public string Titulo { get; set; }
        public string Sinopsis { get; set; }
        public string N_Paginas { get; set; }
        public int EditorialId { get; set; }
        public Editorial Editorial { get; set; }
        public ICollection<Autor> Autores { get; set; }
    }
}
