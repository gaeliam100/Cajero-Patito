using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace proyecto_aula.Models
{
    public class Prestamo
    {
        [Key]
        public int PrestamoID { get; set; }
        [Required]    
        public int NumPres { get ; set; }
        [Required]
        public string NomLib { get; set; }
        [Required]
        public DateTime FechaInicio { get; set ; }
        [Required]
        public DateTime Fechadevol { get ; set; }
        [Required]
        public string Fichapdf { get; set; }
        public string Estado { get; set; }
        
        [ForeignKey("UsuarioID")]
        public int UsuarioI { get; set; }

        [ForeignKey("LibroID")]
        public int LibroI { get; set;}

        [ForeignKey("BiblioID")]

        [MaxLength(14)]
        public string BibliotecarioI { get; set; }
    }
}

