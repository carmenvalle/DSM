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
 * Clase Producto:
 *
 */

namespace DiagGen.Infraestructure.Repository.Diag
{
public partial class ProductoRepository : BasicRepository, IProductoRepository
{
public ProductoRepository() : base ()
{
}


public ProductoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ProductoEN ReadOIDDefault (int idProducto
                                  )
{
        ProductoEN productoEN = null;

        try
        {
                SessionInitializeTransaction ();
                productoEN = (ProductoEN)session.Get (typeof(ProductoNH), idProducto);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return productoEN;
}

public System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ProductoEN> result = null;
        try
        {
                SessionInitializeTransaction(); // <-- asegurar que session exista y tx esté creado
                if (size > 0)
                        result = session.CreateCriteria (typeof(ProductoNH)).
                                 SetFirstResult (first).SetMaxResults (size).
                                 List<ProductoEN>();
                else
                        result = session.CreateCriteria (typeof(ProductoNH)).List<ProductoEN>();

                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }
                
        finally
        {
                SessionClose ();
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ProductoEN producto)
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), producto.IdProducto);

                productoNH.Nombre = producto.Nombre;


                productoNH.Descripcion = producto.Descripcion;


                productoNH.Precio = producto.Precio;


                productoNH.Imagenes = producto.Imagenes;


                productoNH.Stock = producto.Stock;





                productoNH.Valoracion = producto.Valoracion;


                productoNH.Categoria = producto.Categoria;

                session.Update (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int Publicar (ProductoEN producto)
{
        ProductoNH productoNH = new ProductoNH (producto);

        try
        {
                SessionInitializeTransaction ();

                session.Save (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoNH.IdProducto;
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> Editar ()
{
        System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where FROM ProductoNH";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHeditarHQL");

                result = query.List<DiagGen.ApplicationCore.EN.Diag.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Eliminar (int idProducto
                      )
{
        try
        {
                SessionInitializeTransaction ();
                ProductoNH productoNH = (ProductoNH)session.Load (typeof(ProductoNH), idProducto);
                session.Delete (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> BuscarPorPalabra (string nombre, string descripcion)
{
        System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where select p FROM ProductoNH AS p WHERE p.Nombre LIKE '%'+:nombre+'%' OR p.Descripcion LIKE '%'+:descripcion+'%'";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHbuscarPorPalabraHQL");
                query.SetParameter ("nombre", nombre);
                query.SetParameter ("descripcion", descripcion);

                result = query.List<DiagGen.ApplicationCore.EN.Diag.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> Categoria (string categoria)
{
        System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where SELECT prod FROM ProductoNH prod WHERE prod.Categoria = :categoria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHcategoriaHQL");
                query.SetParameter ("categoria", categoria);

                result = query.List<DiagGen.ApplicationCore.EN.Diag.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> PorPrecio (float ? precio)
{
        System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where select prod FROM ProductoNH as prod where prod.Precio =:precio";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHporPrecioHQL");
                query.SetParameter ("precio", precio);

                result = query.List<DiagGen.ApplicationCore.EN.Diag.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int ValoracionMedia (ProductoEN producto)
{
        ProductoNH productoNH = new ProductoNH (producto);

        try
        {
                SessionInitializeTransaction ();

                session.Save (productoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return productoNH.IdProducto;
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> ValorarPorCategoria (string categoria)
{
        System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ProductoNH self where select prod FROM ProductoNH prod WHERE prod.Categoria = :categoria ORDER BY prod.Valoracion DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ProductoNHvalorarPorCategoriaHQL");
                query.SetParameter ("categoria", categoria);

                result = query.List<DiagGen.ApplicationCore.EN.Diag.ProductoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DiagGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new DiagGen.ApplicationCore.Exceptions.DataLayerException ("Error in ProductoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
