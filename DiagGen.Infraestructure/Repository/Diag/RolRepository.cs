
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
 * Clase Rol:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class RolRepository : BasicRepository, IRolRepository
{
public RolRepository() : base ()
{
}


public RolRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public RolEN ReadOIDDefault (int idRlol
                             )
{
        RolEN rolEN = null;

        try
        {
                SessionInitializeTransaction ();
                rolEN = (RolEN)session.Get (typeof(RolNH), idRlol);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return rolEN;
}

public System.Collections.Generic.IList<RolEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RolEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RolNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<RolEN>();
                        else
                                result = session.CreateCriteria (typeof(RolNH)).List<RolEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in RolRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RolEN rol)
{
        try
        {
                SessionInitializeTransaction ();
                RolNH rolNH = (RolNH)session.Load (typeof(RolNH), rol.IdRlol);

                rolNH.Nombre = rol.Nombre;


                rolNH.Descripcion = rol.Descripcion;


                session.Update (rolNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in RolRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Crear (RolEN rol)
{
        RolNH rolNH = new RolNH (rol);

        try
        {
                SessionInitializeTransaction ();

                session.Save (rolNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in RolRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rolNH.IdRlol;
}
}
}
