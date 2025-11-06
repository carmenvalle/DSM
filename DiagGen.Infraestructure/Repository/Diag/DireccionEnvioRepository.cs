
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
 * Clase DireccionEnvio:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class DireccionEnvioRepository : BasicRepository, IDireccionEnvioRepository
{
public DireccionEnvioRepository() : base ()
{
}


public DireccionEnvioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public DireccionEnvioEN ReadOIDDefault (int idDireccion
                                        )
{
        DireccionEnvioEN direccionEnvioEN = null;

        try
        {
                SessionInitializeTransaction ();
                direccionEnvioEN = (DireccionEnvioEN)session.Get (typeof(DireccionEnvioNH), idDireccion);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return direccionEnvioEN;
}

public System.Collections.Generic.IList<DireccionEnvioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<DireccionEnvioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(DireccionEnvioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<DireccionEnvioEN>();
                        else
                                result = session.CreateCriteria (typeof(DireccionEnvioNH)).List<DireccionEnvioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (DireccionEnvioEN direccionEnvio)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEnvioNH direccionEnvioNH = (DireccionEnvioNH)session.Load (typeof(DireccionEnvioNH), direccionEnvio.IdDireccion);

                direccionEnvioNH.Calle = direccionEnvio.Calle;


                direccionEnvioNH.Ciudad = direccionEnvio.Ciudad;


                direccionEnvioNH.CodigoPostal = direccionEnvio.CodigoPostal;


                direccionEnvioNH.Pais = direccionEnvio.Pais;



                session.Update (direccionEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Guardar (DireccionEnvioEN direccionEnvio)
{
        DireccionEnvioNH direccionEnvioNH = new DireccionEnvioNH (direccionEnvio);

        try
        {
                SessionInitializeTransaction ();
                if (direccionEnvio.Usuario != null) {
                        // Argumento OID y no colección.
                        direccionEnvioNH
                        .Usuario = (DiagGen.ApplicationCore.EN.Diag.UsuarioEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.UsuarioEN), direccionEnvio.Usuario.IdUsuario);

                        direccionEnvioNH.Usuario.DireccionesEnvio
                        .Add (direccionEnvioNH);
                }

                session.Save (direccionEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return direccionEnvioNH.IdDireccion;
}

public void Editar (DireccionEnvioEN direccionEnvio)
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEnvioNH direccionEnvioNH = (DireccionEnvioNH)session.Load (typeof(DireccionEnvioNH), direccionEnvio.IdDireccion);

                direccionEnvioNH.Calle = direccionEnvio.Calle;


                direccionEnvioNH.Ciudad = direccionEnvio.Ciudad;


                direccionEnvioNH.CodigoPostal = direccionEnvio.CodigoPostal;


                direccionEnvioNH.Pais = direccionEnvio.Pais;

                session.Update (direccionEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Eliminar (int idDireccion
                      )
{
        try
        {
                SessionInitializeTransaction ();
                DireccionEnvioNH direccionEnvioNH = (DireccionEnvioNH)session.Load (typeof(DireccionEnvioNH), idDireccion);
                session.Delete (direccionEnvioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in DireccionEnvioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
