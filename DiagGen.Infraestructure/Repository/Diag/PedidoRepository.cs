
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
 * Clase Pedido:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class PedidoRepository : BasicRepository, IPedidoRepository
{
public PedidoRepository() : base ()
{
}


public PedidoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PedidoEN ReadOIDDefault (int idPedido
                                )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoNH), idPedido);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PedidoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PedidoEN>();
                        else
                                result = session.CreateCriteria (typeof(PedidoNH)).List<PedidoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PedidoEN pedido)
{
        try
        {
                SessionInitializeTransaction ();
                PedidoNH pedidoNH = (PedidoNH)session.Load (typeof(PedidoNH), pedido.IdPedido);

                pedidoNH.Fecha = pedido.Fecha;


                pedidoNH.Estado = pedido.Estado;


                pedidoNH.PrecioTotal = pedido.PrecioTotal;





                session.Update (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int RealizarPedido (PedidoEN pedido)
{
        PedidoNH pedidoNH = new PedidoNH (pedido);

        try
        {
                SessionInitializeTransaction ();
                if (pedido.Usuario != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .Usuario = (DiagGen.ApplicationCore.EN.Diag.UsuarioEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.UsuarioEN), pedido.Usuario.IdUsuario);

                        pedidoNH.Usuario.Pedidos
                        .Add (pedidoNH);
                }
                if (pedido.DireccionEnvio != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .DireccionEnvio = (DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN), pedido.DireccionEnvio.IdDireccion);

                        pedidoNH.DireccionEnvio.Pedidos
                        .Add (pedidoNH);
                }
                if (pedido.MetodoPago != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .MetodoPago = (DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN), pedido.MetodoPago.IdMetodo);

                        pedidoNH.MetodoPago.Pedido
                        .Add (pedidoNH);
                }

                session.Save (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoNH.IdPedido;
}

//Sin e: VerPedido
//Con e: PedidoEN
public PedidoEN VerPedido (int idPedido
                           )
{
        PedidoEN pedidoEN = null;

        try
        {
                SessionInitializeTransaction ();
                pedidoEN = (PedidoEN)session.Get (typeof(PedidoNH), idPedido);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return pedidoEN;
}

public int CancelarPedido (PedidoEN pedido)
{
        PedidoNH pedidoNH = new PedidoNH (pedido);

        try
        {
                SessionInitializeTransaction ();
                if (pedido.Usuario != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .Usuario = (DiagGen.ApplicationCore.EN.Diag.UsuarioEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.UsuarioEN), pedido.Usuario.IdUsuario);

                        pedidoNH.Usuario.Pedidos
                        .Add (pedidoNH);
                }
                if (pedido.DireccionEnvio != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .DireccionEnvio = (DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN), pedido.DireccionEnvio.IdDireccion);

                        pedidoNH.DireccionEnvio.Pedidos
                        .Add (pedidoNH);
                }
                if (pedido.MetodoPago != null) {
                        // Argumento OID y no colección.
                        pedidoNH
                        .MetodoPago = (DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN), pedido.MetodoPago.IdMetodo);

                        pedidoNH.MetodoPago.Pedido
                        .Add (pedidoNH);
                }

                session.Save (pedidoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pedidoNH.IdPedido;
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> DamePedidoPorItem (int ? p_idItem)
{
        System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PedidoNH self where select ped FROM PedidoNH as ped join ped.PedidosItem as linea where linea.IdItem = :p_idItem";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PedidoNHdamePedidoPorItemHQL");
                query.SetParameter ("p_idItem", p_idItem);

                result = query.List<DiagGen.ApplicationCore.EN.Diag.PedidoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in PedidoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
