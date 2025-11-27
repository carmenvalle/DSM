using DiagGen.ApplicationCore.EN.Diag;
using Webdiag.Models;
namespace Webdiag.Assemblers
{
    public class ProductoAssembler
    {
        public ProductoViewModel ConvertirENToViewModel (ProductoEN en)
        {
            ProductoViewModel pr = new ProductoViewModel();
            pr.idProducto = en.IdProducto;
            pr.Nombre = en.Nombre;
            pr.Descripcion = en.Descripcion;
            pr.Precio = en.Precio;
            pr.Imagenes = en.Imagenes;
            pr.Stock = en.Stock;
            pr.Valoracion = en.Valoracion;
            pr.Categoria = en.Categoria;

            return pr;
        }

        public IList<ProductoViewModel> ConvertirListaENToViewModel (IList<ProductoEN> ens)
        {
            IList<ProductoViewModel> lista = new List<ProductoViewModel>();
            foreach (ProductoEN en in ens)
            {
                lista.Add(ConvertirENToViewModel(en));
            }
            return lista;
        }
    }
}
