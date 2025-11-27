using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Webdiag.Models
{
    public class ProductoViewModel
    {
        [ScaffoldColumn(false)]

        public int idProducto { get; set; }

        [Display(Prompt = "Nombre del producto", Description = "Nombre del producto", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede tener más de 200 caracteres")]

        public string Nombre { get; set; }

        [Display(Prompt = "Describe el producto", Description = "Descripcion del producto", Name = "Descripción")]
        [Required(ErrorMessage = "Debe indicar una descripción para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripción no puede tener más de 200 caracteres")]

        public string Descripcion { get; set; }

        [Display(Prompt = "Introduce el precio del producto", Description = "Precio del producto", Name = "Precio")]
        [Required(ErrorMessage = "Debe indicar el precio del prodcuto")]
        [DataType(DataType.Currency, ErrorMessage = "El precio debe ser un valor numérico")]
        [Range(minimum: 0, maximum:1000000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 1000000")]

        public float Precio { get; set; }

        [Display(Prompt = "Imagen del producto", Description = "Imagen del producto", Name = "Imagen")]
        [Required(ErrorMessage = "Debe indicar una imagen para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "La imagen no puede tener más de 200 caracteres")]

        public string Imagenes { get; set; }

        [Display(Prompt = "Introduce el stock del producto", Description = "Stock del producto", Name = "Stock")]
        [Required(ErrorMessage = "Debe indicar el stock del prodcuto")]
        [Range(minimum: 0, maximum: 1000000, ErrorMessage = "El precio debe ser mayor que 0 y menor que 1000000")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Por favor introduce un número entero para el stock" )]

        public int Stock { get; set; }

        [Display(Prompt = "Introduce la valoración del producto", Description = "Valoración del producto", Name = "Valoración")]
        [Required(ErrorMessage = "Debe indicar una valoración para el producto")]
        [Range(0.0, 5.0, ErrorMessage = "La valoración debe estar entre 0 y 5")]
        public double Valoracion { get; set; }


        [Display(Prompt = "Categoría del producto", Description = "Categoría del producto", Name = "Categoria")]
        [Required(ErrorMessage = "Debe indicar una categoría para el producto")]
        [StringLength(maximumLength: 200, ErrorMessage = "La categoría no puede tener más de 200 caracteres")]

        public string Categoria { get; set; }
    }

}
