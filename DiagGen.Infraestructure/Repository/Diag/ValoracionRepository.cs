
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
 * Clase Valoracion:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class ValoracionRepository : BasicRepository, IValoracionRepository
{
public ValoracionRepository() : base ()
{
}


public ValoracionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ValoracionEN ReadOIDDefault (int idValoracion
                                    )
{
        ValoracionEN valoracionEN = null;

        try
        {
                SessionInitializeTransaction ();
                valoracionEN = (ValoracionEN)session.Get (typeof(ValoracionNH), idValoracion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ValoracionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ValoracionEN>();
                        else
                                result = session.CreateCriteria (typeof(ValoracionNH)).List<ValoracionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ValoracionEN valoracion)
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load (typeof(ValoracionNH), valoracion.IdValoracion);

                valoracionNH.Puntuacion = valoracion.Puntuacion;


                valoracionNH.Comentario = valoracion.Comentario;



                session.Update (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Guardar (ValoracionEN valoracion)
{
        ValoracionNH valoracionNH = new ValoracionNH (valoracion);

        try
        {
                SessionInitializeTransaction ();
                if (valoracion.Producto != null) {
                        // Argumento OID y no colección.
                        valoracionNH
                        .Producto = (DiagGen.ApplicationCore.EN.Diag.ProductoEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.ProductoEN), valoracion.Producto.IdProducto);

                        valoracionNH.Producto.Valoraciones
                        .Add (valoracionNH);
                }
                if (valoracion.Usuario != null) {
                        // Argumento OID y no colección.
                        valoracionNH
                        .Usuario = (DiagGen.ApplicationCore.EN.Diag.UsuarioEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.UsuarioEN), valoracion.Usuario.IdUsuario);

                        valoracionNH.Usuario.Valoraciones
                        .Add (valoracionNH);
                }

                session.Save (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return valoracionNH.IdValoracion;
}

public void Borrar (int idValoracion
                    )
{
        try
        {
                SessionInitializeTransaction ();
                ValoracionNH valoracionNH = (ValoracionNH)session.Load (typeof(ValoracionNH), idValoracion);
                session.Delete (valoracionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ValoracionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
