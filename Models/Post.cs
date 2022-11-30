using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace proyecto_aula.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        [Required]
        public int UsuarioID { get; set; }
        [MaxLength(1024)]
        public string Comentario { get; set; }
        [Required]
        public DateTime FechaAlta { get; set; }
        public int Likes { get; set; }
        
        [ForeignKey("UsuarioID")]
        public Usuario Usuario { get; set; }

        //public int Identificador { get; set; }

    }
}
