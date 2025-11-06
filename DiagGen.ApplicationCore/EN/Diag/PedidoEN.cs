
using System;
// Definición clase PedidoEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class PedidoEN
{
/**
 *	Atributo idPedido
 */
private int idPedido;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo estado
 */
private DiagGen.ApplicationCore.Enumerated.Diag.EstadoPedidoEnum estado;



/**
 *	Atributo precioTotal
 */
private float precioTotal;



/**
 *	Atributo usuario
 */
private DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario;



/**
 *	Atributo direccionEnvio
 */
private DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN direccionEnvio;



/**
 *	Atributo metodoPago
 */
private DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN metodoPago;



/**
 *	Atributo pedidosItem
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN> pedidosItem;






public virtual int IdPedido {
        get { return idPedido; } set { idPedido = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual DiagGen.ApplicationCore.Enumerated.Diag.EstadoPedidoEnum Estado {
        get { return estado; } set { estado = value;  }
}



public virtual float PrecioTotal {
        get { return precioTotal; } set { precioTotal = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN DireccionEnvio {
        get { return direccionEnvio; } set { direccionEnvio = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN> PedidosItem {
        get { return pedidosItem; } set { pedidosItem = value;  }
}





public PedidoEN()
{
        pedidosItem = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN>();
}



public PedidoEN(int idPedido, Nullable<DateTime> fecha, DiagGen.ApplicationCore.Enumerated.Diag.EstadoPedidoEnum estado, float precioTotal, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario, DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN direccionEnvio, DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN metodoPago, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN> pedidosItem
                )
{
        this.init (IdPedido, fecha, estado, precioTotal, usuario, direccionEnvio, metodoPago, pedidosItem);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.IdPedido, pedido.Fecha, pedido.Estado, pedido.PrecioTotal, pedido.Usuario, pedido.DireccionEnvio, pedido.MetodoPago, pedido.PedidosItem);
}

private void init (int idPedido
                   , Nullable<DateTime> fecha, DiagGen.ApplicationCore.Enumerated.Diag.EstadoPedidoEnum estado, float precioTotal, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario, DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN direccionEnvio, DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN metodoPago, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoItemEN> pedidosItem)
{
        this.IdPedido = idPedido;


        this.Fecha = fecha;

        this.Estado = estado;

        this.PrecioTotal = precioTotal;

        this.Usuario = usuario;

        this.DireccionEnvio = direccionEnvio;

        this.MetodoPago = metodoPago;

        this.PedidosItem = pedidosItem;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (IdPedido.Equals (t.IdPedido))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdPedido.GetHashCode ();
        return hash;
}
}
}
