using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_aula.Models
{
    public class Libro
    {
        [Key]
        public int LibroID { get; set; }
        [Required]
        public string NomLib { get; set; }
        [Required]
        public string Editorial { get; set; }
        [Required]
        public string NomAut { get; set; }
        [Required]
        public string ApePaut { get; set; }
        [Required]
        public string ApeMaut { get; set; }
        [Required]
        public string Genero { get; set; }
        [Required]
        public int NumPaginas { get; set; }
        [Required]
        public string AñoEdicion { get; set; }

        [Required]
        public string Portada { get; set; }
    }
}

