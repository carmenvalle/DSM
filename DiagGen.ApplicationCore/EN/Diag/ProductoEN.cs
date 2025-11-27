
using System;
// Definición clase ProductoEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class ProductoEN
{
/**
 *	Atributo idProducto
 */
private int idProducto;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo precio
 */

private float precio;



/**
 *	Atributo imagenes
 */
private string imagenes;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo favoritos
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.FavoritoEN> favoritos;



/**
 *	Atributo valoraciones
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ValoracionEN> valoraciones;



/**
 *	Atributo pedidosItem
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN> pedidosItem;



/**
 *	Atributo valoracion
 */
private double valoracion;



/**
 *	Atributo categoria
 */
private string categoria;






public virtual int IdProducto {
        get { return idProducto; } set { idProducto = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual float Precio {
        get { return precio; } set { precio = value;  }
}



public virtual string Imagenes {
        get { return imagenes; } set { imagenes = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.FavoritoEN> Favoritos {
        get { return favoritos; } set { favoritos = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ValoracionEN> Valoraciones {
        get { return valoraciones; } set { valoraciones = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN> PedidosItem {
        get { return pedidosItem; } set { pedidosItem = value;  }
}



public virtual double Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual string Categoria {
        get { return categoria; } set { categoria = value;  }
}





public ProductoEN()
{
        favoritos = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.FavoritoEN>();
        valoraciones = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.ValoracionEN>();
        pedidosItem = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN>();
}



public ProductoEN(int idProducto, string nombre, string descripcion, float precio, string imagenes, int stock, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.FavoritoEN> favoritos, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ValoracionEN> valoraciones, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN> pedidosItem, double valoracion, string categoria
                  )
{
        this.init (IdProducto, nombre, descripcion, precio, imagenes, stock, favoritos, valoraciones, pedidosItem, valoracion, categoria);
}


public ProductoEN(ProductoEN producto)
{
        this.init (producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio, producto.Imagenes, producto.Stock, producto.Favoritos, producto.Valoraciones, producto.PedidosItem, producto.Valoracion, producto.Categoria);
}

private void init (int idProducto
                   , string nombre, string descripcion, float precio, string imagenes, int stock, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.FavoritoEN> favoritos, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ValoracionEN> valoraciones, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN> pedidosItem, double valoracion, string categoria)
{
        this.IdProducto = idProducto;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Precio = precio;

        this.Imagenes = imagenes;

        this.Stock = stock;

        this.Favoritos = favoritos;

        this.Valoraciones = valoraciones;

        this.PedidosItem = pedidosItem;

        this.Valoracion = valoracion;

        this.Categoria = categoria;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
        if (t == null)
                return false;
        if (IdProducto.Equals (t.IdProducto))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdProducto.GetHashCode ();
        return hash;
}
}
}
