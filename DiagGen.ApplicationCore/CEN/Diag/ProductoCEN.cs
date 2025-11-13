

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class ProductoCEN
 *
 */
public partial class ProductoCEN
{
private IProductoRepository _IProductoRepository;

public ProductoCEN(IProductoRepository _IProductoRepository)
{
        this._IProductoRepository = _IProductoRepository;
}

public IProductoRepository get_IProductoRepository ()
{
        return this._IProductoRepository;
}

public int Publicar (string p_nombre, string p_descripcion, float p_precio, string p_imagenes, int p_stock, double p_valoracion, string p_categoria)
{
        ProductoEN productoEN = null;
        int oid;

        //Initialized ProductoEN
        productoEN = new ProductoEN ();
        productoEN.Nombre = p_nombre;

        productoEN.Descripcion = p_descripcion;

        productoEN.Precio = p_precio;

        productoEN.Imagenes = p_imagenes;

        productoEN.Stock = p_stock;

        productoEN.Valoracion = p_valoracion;

        productoEN.Categoria = p_categoria;



        oid = _IProductoRepository.Publicar (productoEN);
        return oid;
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> Editar ()
{
        return _IProductoRepository.Editar ();
}
public void Eliminar (int idProducto
                      )
{
        _IProductoRepository.Eliminar (idProducto);
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> BuscarPorPalabra (string nombre, string descripcion)
{
        return _IProductoRepository.BuscarPorPalabra (nombre, descripcion);
}
public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> Categoria (string categoria)
{
        return _IProductoRepository.Categoria (categoria);
}
public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> PorPrecio (float ? precio)
{
        return _IProductoRepository.PorPrecio (precio);
}
public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> ValorarPorCategoria (string categoria)
{
        return _IProductoRepository.ValorarPorCategoria (categoria);
}
}
}
