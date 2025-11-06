
using System;
// Definición clase PedidoItemEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class PedidoItemEN
{
/**
 *	Atributo idItem
 */
private int idItem;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo precioUnitario
 */
private float precioUnitario;



/**
 *	Atributo producto
 */
private DiagGen.ApplicationCore.EN.Diag.ProductoEN producto;



/**
 *	Atributo pedido
 */
private DiagGen.ApplicationCore.EN.Diag.PedidoEN pedido;






public virtual int IdItem {
        get { return idItem; } set { idItem = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual float PrecioUnitario {
        get { return precioUnitario; } set { precioUnitario = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}





public PedidoItemEN()
{
}



public PedidoItemEN(int idItem, int cantidad, float precioUnitario, DiagGen.ApplicationCore.EN.Diag.ProductoEN producto, DiagGen.ApplicationCore.EN.Diag.PedidoEN pedido
                    )
{
        this.init (IdItem, cantidad, precioUnitario, producto, pedido);
}


public PedidoItemEN(PedidoItemEN pedidoItem)
{
        this.init (pedidoItem.IdItem, pedidoItem.Cantidad, pedidoItem.PrecioUnitario, pedidoItem.Producto, pedidoItem.Pedido);
}

private void init (int idItem
                   , int cantidad, float precioUnitario, DiagGen.ApplicationCore.EN.Diag.ProductoEN producto, DiagGen.ApplicationCore.EN.Diag.PedidoEN pedido)
{
        this.IdItem = idItem;


        this.Cantidad = cantidad;

        this.PrecioUnitario = precioUnitario;

        this.Producto = producto;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoItemEN t = obj as PedidoItemEN;
        if (t == null)
                return false;
        if (IdItem.Equals (t.IdItem))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdItem.GetHashCode ();
        return hash;
}
}
}
