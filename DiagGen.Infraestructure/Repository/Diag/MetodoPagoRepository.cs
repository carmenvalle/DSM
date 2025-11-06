
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
 * Clase MetodoPago:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class MetodoPagoRepository : BasicRepository, IMetodoPagoRepository
{
public MetodoPagoRepository() : base ()
{
}


public MetodoPagoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public MetodoPagoEN ReadOIDDefault (int idMetodo
                                    )
{
        MetodoPagoEN metodoPagoEN = null;

        try
        {
                SessionInitializeTransaction ();
                metodoPagoEN = (MetodoPagoEN)session.Get (typeof(MetodoPagoNH), idMetodo);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoEN;
}

public System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<MetodoPagoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(MetodoPagoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<MetodoPagoEN>();
                        else
                                result = session.CreateCriteria (typeof(MetodoPagoNH)).List<MetodoPagoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoPago.IdMetodo);

                metodoPagoNH.Tipo = metodoPago.Tipo;


                metodoPagoNH.Numero = metodoPago.Numero;


                metodoPagoNH.FechaExpiracion = metodoPago.FechaExpiracion;



                session.Update (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Guardar (MetodoPagoEN metodoPago)
{
        MetodoPagoNH metodoPagoNH = new MetodoPagoNH (metodoPago);

        try
        {
                SessionInitializeTransaction ();
                if (metodoPago.Usuario != null) {
                        // Argumento OID y no colección.
                        metodoPagoNH
                        .Usuario = (DiagGen.ApplicationCore.EN.Diag.UsuarioEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.UsuarioEN), metodoPago.Usuario.IdUsuario);

                        metodoPagoNH.Usuario.MetodosPago
                        .Add (metodoPagoNH);
                }

                session.Save (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return metodoPagoNH.IdMetodo;
}

public void Editar (MetodoPagoEN metodoPago)
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), metodoPago.IdMetodo);

                metodoPagoNH.Tipo = metodoPago.Tipo;


                metodoPagoNH.Numero = metodoPago.Numero;


                metodoPagoNH.FechaExpiracion = metodoPago.FechaExpiracion;

                session.Update (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int idMetodo
                      )
{
        try
        {
                SessionInitializeTransaction ();
                MetodoPagoNH metodoPagoNH = (MetodoPagoNH)session.Load (typeof(MetodoPagoNH), idMetodo);
                session.Delete (metodoPagoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in MetodoPagoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
