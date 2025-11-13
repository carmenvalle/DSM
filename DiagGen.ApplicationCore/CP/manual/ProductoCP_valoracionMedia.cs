
using System;
using System.Text;

using System.Collections.Generic;
using DiagGen.ApplicationCore.Exceptions;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;
using DiagGen.ApplicationCore.CEN.Diag;



/*PROTECTED REGION ID(usingDiagGen.ApplicationCore.CP.Diag_Producto_valoracionMedia) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DiagGen.ApplicationCore.CP.Diag
{
public partial class ProductoCP : GenericBasicCP
{
public DiagGen.ApplicationCore.EN.Diag.ProductoEN ValoracionMedia (string p_nombre, string p_descripcion, float p_precio, string p_imagenes, int p_stock, double p_valoracion, string p_categoria)
{
        /*PROTECTED REGION ID(DiagGen.ApplicationCore.CP.Diag_Producto_valoracionMedia) ENABLED START*/

        ProductoCEN productoCEN = null;

        DiagGen.ApplicationCore.EN.Diag.ProductoEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                productoCEN = new  ProductoCEN (CPSession.UnitRepo.ProductoRepository);


                int oid;
                //Initialized ProductoEN
                ProductoEN productoEN;
                productoEN = new ProductoEN ();
                productoEN.Nombre = p_nombre;

                productoEN.Descripcion = p_descripcion;

                productoEN.Precio = p_precio;

                productoEN.Imagenes = p_imagenes;

                productoEN.Stock = p_stock;



                if (productoEN == null)
                        throw new Exception ("Producto no encontrado.");

                // Si tiene lista de valoraciones, calculamos la media
                if (productoEN.Valoraciones != null && productoEN.Valoraciones.Count > 0) {
                        double suma = 0;

                        foreach (ValoracionEN v in productoEN.Valoraciones) {
                                suma += v.Puntuacion;
                        }

                        productoEN.Valoracion = suma / productoEN.Valoraciones.Count;
                }

                // Actualizamos el producto con la nueva media
                productoCEN.get_IProductoRepository ().ModifyDefault (productoEN);

                oid = productoCEN.get_IProductoRepository ().ValoracionMedia (productoEN);

                result = productoCEN.get_IProductoRepository ().ReadOIDDefault (oid);



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
