
using System;
using System.Text;

using System.Collections.Generic;
using DiagGen.ApplicationCore.Exceptions;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;
using DiagGen.ApplicationCore.CEN.Diag;



/*PROTECTED REGION ID(usingDiagGen.ApplicationCore.CP.Diag_PedidoItem_crearPedidoItem) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DiagGen.ApplicationCore.CP.Diag
{
public partial class PedidoItemCP : GenericBasicCP
{
public DiagGen.ApplicationCore.EN.Diag.PedidoItemEN CrearPedidoItem (int p_cantidad, float p_precioUnitario, int p_producto, int p_pedido)
{
        /*PROTECTED REGION ID(DiagGen.ApplicationCore.CP.Diag_PedidoItem_crearPedidoItem) ENABLED START*/

        PedidoItemCEN pedidoItemCEN = null;

        DiagGen.ApplicationCore.EN.Diag.PedidoItemEN result = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                pedidoItemCEN = new  PedidoItemCEN (CPSession.UnitRepo.PedidoItemRepository);


                PedidoCEN pedidoCEN = new PedidoCEN (CPSession.UnitRepo.PedidoRepository);

                int oid;
                //Initialized PedidoItemEN
                PedidoItemEN pedidoItemEN;
                pedidoItemEN = new PedidoItemEN ();

                pedidoItemEN.Cantidad = p_cantidad;

                pedidoItemEN.PrecioUnitario = p_precioUnitario;


                if (p_producto != -1) {
                        pedidoItemEN.Producto = new DiagGen.ApplicationCore.EN.Diag.ProductoEN ();
                        pedidoItemEN.Producto.IdProducto = p_producto;
                }


                if (p_pedido != -1) {
                        pedidoItemEN.Pedido = new DiagGen.ApplicationCore.EN.Diag.PedidoEN ();
                        pedidoItemEN.Pedido.IdPedido = p_pedido;
                }

                PedidoEN pedidoEN = pedidoCEN.get_IPedidoRepository ().ReadOIDDefault (p_pedido);

                pedidoEN.PrecioTotal += pedidoItemEN.Cantidad * pedidoItemEN.PrecioUnitario;

                pedidoCEN.get_IPedidoRepository ().ModifyDefault (pedidoEN);

                oid = pedidoItemCEN.get_IPedidoItemRepository ().CrearPedidoItem (pedidoItemEN);

                result = pedidoItemCEN.get_IPedidoItemRepository ().ReadOIDDefault (oid);



                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
