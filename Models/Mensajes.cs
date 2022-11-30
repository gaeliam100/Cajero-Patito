using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_aula.Models
{
    public class Mensajes
    {
        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        public string Nombre { get; set; }

    }
}