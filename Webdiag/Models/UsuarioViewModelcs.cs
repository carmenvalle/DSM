using System.ComponentModel.DataAnnotations;

namespace Webdiag.Models
{
    public class LoginUsuarioViewModelcs
    {
        [Display(Prompt = "Introduce el Nombre  del Usuario", Description = "Nombre del Usuario", Name = "Nombre")]
        [Required(ErrorMessage = "Debe introducir el Nombre del Usuario")]

        public string Nombre { get; set; }

        [Display(Prompt = "Introduce la Contraseña", Description = "Contraseña del Usuario", Name = "Password")]
        [Required(ErrorMessage = "Debe introducir la contraseña del Usuario")]
        [DataType(DataType.Password)]

        public string Password { get; set; }


    }
}
