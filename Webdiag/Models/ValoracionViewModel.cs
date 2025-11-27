using System.ComponentModel.DataAnnotations;

namespace Webdiag.Models
{
    public class ValoracionViewModel
    {
        public int IdValoracion { get; set; }  // Id de la valoración

        [Required(ErrorMessage = "Debe seleccionar un producto")]
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }    // Id del producto

        [Required(ErrorMessage = "Debe seleccionar un usuario")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }     // Id del usuario

        [Required(ErrorMessage = "Debe indicar una puntuación")]
        [Range(1, 5, ErrorMessage = "La puntuación debe estar entre 1 y 5")]
        [Display(Name = "Puntuación")]
        public int Puntuacion { get; set; }    // Valor numérico (1-5)

        [StringLength(500, ErrorMessage = "El comentario no puede superar 500 caracteres")]
        [Display(Name = "Comentario")]
        public string Comentario { get; set; } // Comentario opcional
    }

}
