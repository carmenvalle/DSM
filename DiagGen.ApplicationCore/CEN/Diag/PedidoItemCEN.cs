

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class PedidoItemCEN
 *
 */
public partial class PedidoItemCEN
{
private IPedidoItemRepository _IPedidoItemRepository;

public PedidoItemCEN(IPedidoItemRepository _IPedidoItemRepository)
{
        this._IPedidoItemRepository = _IPedidoItemRepository;
}

public IPedidoItemRepository get_IPedidoItemRepository ()
{
        return this._IPedidoItemRepository;
}

public int New_ (int p_cantidad, float p_precioUnitario, int p_producto, int p_pedido)
{
        PedidoItemEN pedidoItemEN = null;
        int oid;

        //Initialized PedidoItemEN
        pedidoItemEN = new PedidoItemEN ();
        pedidoItemEN.Cantidad = p_cantidad;

        pedidoItemEN.PrecioUnitario = p_precioUnitario;


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids idItem
                pedidoItemEN.Producto = new DiagGen.ApplicationCore.EN.Diag.ProductoEN ();
                pedidoItemEN.Producto.IdProducto = p_producto;
        }


        if (p_pedido != -1) {
                // El argumento p_pedido -> Property pedido es oid = false
                // Lista de oids idItem
                pedidoItemEN.Pedido = new DiagGen.ApplicationCore.EN.Diag.PedidoEN ();
                pedidoItemEN.Pedido.IdPedido = p_pedido;
        }



        oid = _IPedidoItemRepository.New_ (pedidoItemEN);
        return oid;
}
}
}
