
using System;
using System.Text;
using System.Collections.Generic;
using DiagGen.ApplicationCore.Exceptions;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


/*PROTECTED REGION ID(usingDiagGen.ApplicationCore.CEN.Diag_Pedido_cancelarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DiagGen.ApplicationCore.CEN.Diag
{
public partial class PedidoCEN
{
public int CancelarPedido (Nullable<DateTime> p_fecha, DiagGen.ApplicationCore.Enumerated.Diag.EstadoPedidoEnum p_estado, float p_precioTotal, int p_usuario, int p_direccionEnvio, int p_metodoPago)
{
        /*PROTECTED REGION ID(DiagGen.ApplicationCore.CEN.Diag_Pedido_cancelarPedido_customized) START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Fecha = p_fecha;

        pedidoEN.Estado = p_estado;

        pedidoEN.PrecioTotal = p_precioTotal;


        if (p_usuario != -1) {
                pedidoEN.Usuario = new DiagGen.ApplicationCore.EN.Diag.UsuarioEN ();
                pedidoEN.Usuario.IdUsuario = p_usuario;
        }


        if (p_direccionEnvio != -1) {
                pedidoEN.DireccionEnvio = new DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN ();
                pedidoEN.DireccionEnvio.IdDireccion = p_direccionEnvio;
        }


        if (p_metodoPago != -1) {
                pedidoEN.MetodoPago = new DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN ();
                pedidoEN.MetodoPago.IdMetodo = p_metodoPago;
        }

        //Call to PedidoRepository

        oid = _IPedidoRepository.CancelarPedido (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
