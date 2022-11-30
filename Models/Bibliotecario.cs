using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_aula.Models
{
    public class Bibliotecario
    {
        [Key]
        [Required]
        [MaxLength(14)]
        [Display(Name = "Numero de empleado")]
        public string BiblioID { get; set; }
        //************
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }
        //************
        [MaxLength(256)]
        [Display(Name = "Imagen del perfil")]
        public string Imagenp { get; set; }
        //************
        [Required, MaxLength(256)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        //************
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        //************
        [Required(ErrorMessage = "El Apellido paterno es obligatorio")]
        public string ApellidoP { get; set; }
        //************
        [Required(ErrorMessage = "El Apellido Materno es obligatorio")]
        public string ApellidoM { get; set; }
        //************
        public int Edad { get; set; }
        //************
        public string Sexo { get; set; }
        //************
        public string FechaAlta { get; set; }
        public string FechaUltimaActualizacion { get; set; }
        //************
        public bool Estado { get; set; }


    }

}
