
using System;
using System.Text;
using System.Collections.Generic;
using DiagGen.ApplicationCore.Exceptions;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


/*PROTECTED REGION ID(usingDiagGen.ApplicationCore.CEN.Diag_Pedido_realizarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DiagGen.ApplicationCore.CEN.Diag
{
public partial class PedidoCEN
{
public int RealizarPedido (Nullable<DateTime> p_fecha, float p_precioTotal, int p_usuario, int p_direccionEnvio, int p_metodoPago)
{
        /*PROTECTED REGION ID(DiagGen.ApplicationCore.CEN.Diag_Pedido_realizarPedido_customized) ENABLED START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Fecha = p_fecha;

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

        pedidoEN.Estado = Enumerated.Diag.EstadoPedidoEnum.PENDIENTE;

        //Call to PedidoRepository

        oid = _IPedidoRepository.RealizarPedido (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
