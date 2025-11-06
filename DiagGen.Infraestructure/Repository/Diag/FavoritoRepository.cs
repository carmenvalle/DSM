
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
 * Clase Favorito:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class FavoritoRepository : BasicRepository, IFavoritoRepository
{
public FavoritoRepository() : base ()
{
}


public FavoritoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public FavoritoEN ReadOIDDefault (int idFavorito
                                  )
{
        FavoritoEN favoritoEN = null;

        try
        {
                SessionInitializeTransaction ();
                favoritoEN = (FavoritoEN)session.Get (typeof(FavoritoNH), idFavorito);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return favoritoEN;
}

public System.Collections.Generic.IList<FavoritoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<FavoritoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(FavoritoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<FavoritoEN>();
                        else
                                result = session.CreateCriteria (typeof(FavoritoNH)).List<FavoritoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (FavoritoEN favorito)
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoNH favoritoNH = (FavoritoNH)session.Load (typeof(FavoritoNH), favorito.IdFavorito);


                session.Update (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int MarcarFavorito (FavoritoEN favorito)
{
        FavoritoNH favoritoNH = new FavoritoNH (favorito);

        try
        {
                SessionInitializeTransaction ();
                if (favorito.Usuario != null) {
                        // Argumento OID y no colección.
                        favoritoNH
                        .Usuario = (DiagGen.ApplicationCore.EN.Diag.UsuarioEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.UsuarioEN), favorito.Usuario.IdUsuario);

                        favoritoNH.Usuario.Favoritos
                        .Add (favoritoNH);
                }
                if (favorito.Producto != null) {
                        // Argumento OID y no colección.
                        favoritoNH
                        .Producto = (DiagGen.ApplicationCore.EN.Diag.ProductoEN)session.Load (typeof(DiagGen.ApplicationCore.EN.Diag.ProductoEN), favorito.Producto.IdProducto);

                        favoritoNH.Producto.Favoritos
                        .Add (favoritoNH);
                }

                session.Save (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return favoritoNH.IdFavorito;
}

public void DesmarcarFavorito (int idFavorito
                               )
{
        try
        {
                SessionInitializeTransaction ();
                FavoritoNH favoritoNH = (FavoritoNH)session.Load (typeof(FavoritoNH), idFavorito);
                session.Delete (favoritoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in FavoritoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
