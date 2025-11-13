
using System;
using System.Text;
using DiagGen.ApplicationCore.CEN.Diag;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.Exceptions;
using DiagGen.ApplicationCore.IRepository.Diag;
using DiagGen.ApplicationCore.CP.Diag;
using DiagGen.Infraestructure.EN.Diag;


/*
 * Clase PedidoItem:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class PedidoItemRepository : BasicRepository, IPedidoItemRepository
{
public PedidoItemRepository() : base ()
{
}


public PedidoItemRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PedidoItemEN ReadOIDDefault (int idItem
                                    )
{
        PedidoItemEN pedidoItemEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoItemEN = (PedidoItemEN)session.Get (typeof(PedidoItemNH), idItem);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoItemEN;
}

public System.Collections.Generic.IList<PedidoItemEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoItemEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoItemNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoItemEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoItemNH)).List<PedidoItemEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoItemRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoItemEN pedidoItem)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoItemNH pedidoItemNH = (PedidoItemNH)session.Load (typeof(PedidoItemNH), pedidoItem.IdItem);

                pedidoItemNH.Cantidad = pedidoItem.Cantidad;


                pedidoItemNH.PrecioUnitario = pedidoItem.PrecioUnitario;



                session.Update (pedidoItemNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoItemRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int CrearPedidoItem (PedidoItemEN pedidoItem)
{
        PedidoItemNH pedidoItemNH = new PedidoItemNH (pedidoItem);

        try
        {
                SessionInitializeTransaction ();
                if (pedidoItem.Producto != null) {
                        // Argumento OID y no colección.
                        pedidoItemNH
                        .Producto = (DiagGen.ApplicationCore.EN.Diag.ProductoEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.ProductoEN), pedidoItem.Producto.IdProducto);

                        pedidoItemNH.Producto.PedidosItem
                        .Add (pedidoItemNH);
                }
                if (pedidoItem.Pedido != null) {
                        // Argumento OID y no colección.
                        pedidoItemNH
                        .Pedido = (DiagGen.ApplicationCore.EN.Diag.PedidoEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.PedidoEN), pedidoItem.Pedido.IdPedido);

                        pedidoItemNH.Pedido.PedidosItem
                        .Add (pedidoItemNH);
                }

                session.Save (pedidoItemNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoItemRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoItemNH.IdItem;
}

public int New_ (PedidoItemEN pedidoItem)
{
        PedidoItemNH pedidoItemNH = new PedidoItemNH (pedidoItem);

        try
        {
                SessionInitializeTransaction ();
                if (pedidoItem.Producto != null) {
                        // Argumento OID y no colección.
                        pedidoItemNH
                        .Producto = (DiagGen.ApplicationCore.EN.Diag.ProductoEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.ProductoEN), pedidoItem.Producto.IdProducto);

                        pedidoItemNH.Producto.PedidosItem
                        .Add (pedidoItemNH);
                }
                if (pedidoItem.Pedido != null) {
                        // Argumento OID y no colección.
                        pedidoItemNH
                        .Pedido = (DiagGen.ApplicationCore.EN.Diag.PedidoEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.PedidoEN), pedidoItem.Pedido.IdPedido);

                        pedidoItemNH.Pedido.PedidosItem
                        .Add (pedidoItemNH);
                }

                session.Save (pedidoItemNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoItemRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoItemNH.IdItem;
}
}
}
