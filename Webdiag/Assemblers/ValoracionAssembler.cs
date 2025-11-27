using DiagGen.ApplicationCore.EN.Diag;
using Webdiag.Models;

namespace Webdiag.Assemblers
{
    public class ValoracionAssembler
    {
        // Convierte de EN a ViewModel
        public ValoracionViewModel ConvertirENToViewModel(ValoracionEN valoracionEN)
        {
            if (valoracionEN == null)
                return null;

            return new ValoracionViewModel
            {
                IdValoracion = valoracionEN.IdValoracion,
                ProductoId = valoracionEN.Producto != null ? valoracionEN.Producto.IdProducto : 0,
                UsuarioId = valoracionEN.Usuario != null ? valoracionEN.Usuario.IdUsuario : 0,
                Puntuacion = valoracionEN.Puntuacion,
                Comentario = valoracionEN.Comentario
            };
        }

        // Convierte de ViewModel a EN
        public ValoracionEN ConvertirViewModelToEN(ValoracionViewModel valoracionVM, ProductoEN producto = null, UsuarioEN usuario = null)
        {
            if (valoracionVM == null)
                return null;

            return new ValoracionEN
            {
                IdValoracion = valoracionVM.IdValoracion,
                Producto = producto, // Se puede pasar desde el CEN o repositorio
                Usuario = usuario,   // Se puede pasar desde el CEN o repositorio
                Puntuacion = valoracionVM.Puntuacion,
                Comentario = valoracionVM.Comentario
            };
        }

        // Convierte una lista de EN a lista de ViewModel
        public IList<ValoracionViewModel> ConvertirListaENToViewModel(IList<ValoracionEN> listaEN)
        {
            IList<ValoracionViewModel> listaVM = new List<ValoracionViewModel>();
            if (listaEN == null) return listaVM;

            foreach (var en in listaEN)
            {
                listaVM.Add(ConvertirENToViewModel(en));
            }

            return listaVM;
        }
    }
}
