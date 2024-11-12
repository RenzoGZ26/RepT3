using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace T3_Grupo1.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Titulo de Libro es obligatorio")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El Autor es obligatorio")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El Tema es obligatorio")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "La Editorial es obligatoria")]
        public string Editorial { get; set; }

        [Required(ErrorMessage = "El año de obligacion es obligatorio")]
        [Range(1900, 3000, ErrorMessage = "El año de publicacion debe estar en el rango 1900 a 3000")]
        public int AnioPublicacion { get; set; }

        [Required(ErrorMessage = "Las paginas son obligatorias")]
        [Range(10, 1000, ErrorMessage = "Las paginas deben estar en el rango 10 a 1000")]
        public int Paginas { get; set; }

        [Required(ErrorMessage = "La Categoria es obligatoria")]
        public string Categoria { get; set; }

    }
}


