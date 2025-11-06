
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
 * Clase Usuario:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class UsuarioRepository : BasicRepository, IUsuarioRepository
{
public UsuarioRepository() : base ()
{
}


public UsuarioRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public UsuarioEN ReadOIDDefault (int idUsuario
                                 )
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioNH), idUsuario);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UsuarioNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<UsuarioEN>();
                        else
                                result = session.CreateCriteria (typeof(UsuarioNH)).List<UsuarioEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), usuario.IdUsuario);

                usuarioNH.Nombre = usuario.Nombre;


                usuarioNH.Correo = usuario.Correo;


                usuarioNH.Direccion = usuario.Direccion;








                usuarioNH.Pass = usuario.Pass;

                session.Update (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Registrarse (UsuarioEN usuario)
{
        UsuarioNH usuarioNH = new UsuarioNH (usuario);

        try
        {
                SessionInitializeTransaction ();
                if (usuario.Rol != null) {
                        // Argumento OID y no colección.
                        usuarioNH
                        .Rol = (DiagGen.ApplicationCore.EN.Diag.RolEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.RolEN), usuario.Rol.IdRlol);

                        usuarioNH.Rol.Usuarios
                        .Add (usuarioNH);
                }

                session.Save (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioNH.IdUsuario;
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.UsuarioEN> CerrarSesion ()
{
        System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioNH self where FROM UsuarioNH";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioNHcerrarSesionHQL");

                result = query.List<DiagGen.ApplicationCore.EN.Diag.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void EliminarCuenta (int idUsuario
                            )
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioNH usuarioNH = (UsuarioNH)session.Load (typeof(UsuarioNH), idUsuario);
                session.Delete (usuarioNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in UsuarioRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
