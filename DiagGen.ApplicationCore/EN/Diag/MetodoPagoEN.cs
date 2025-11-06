
using System;
// Definición clase MetodoPagoEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class MetodoPagoEN
{
/**
 *	Atributo idMetodo
 */
private int idMetodo;



/**
 *	Atributo tipo
 */
private string tipo;



/**
 *	Atributo numero
 */
private string numero;



/**
 *	Atributo fechaExpiracion
 */
private Nullable<DateTime> fechaExpiracion;



/**
 *	Atributo usuario
 */
private DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedido;






public virtual int IdMetodo {
        get { return idMetodo; } set { idMetodo = value;  }
}



public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Numero {
        get { return numero; } set { numero = value;  }
}



public virtual Nullable<DateTime> FechaExpiracion {
        get { return fechaExpiracion; } set { fechaExpiracion = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}





public MetodoPagoEN()
{
        pedido = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.PedidoEN>();
}



public MetodoPagoEN(int idMetodo, string tipo, string numero, Nullable<DateTime> fechaExpiracion, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedido
                    )
{
        this.init (IdMetodo, tipo, numero, fechaExpiracion, usuario, pedido);
}


public MetodoPagoEN(MetodoPagoEN metodoPago)
{
        this.init (metodoPago.IdMetodo, metodoPago.Tipo, metodoPago.Numero, metodoPago.FechaExpiracion, metodoPago.Usuario, metodoPago.Pedido);
}

private void init (int idMetodo
                   , string tipo, string numero, Nullable<DateTime> fechaExpiracion, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedido)
{
        this.IdMetodo = idMetodo;


        this.Tipo = tipo;

        this.Numero = numero;

        this.FechaExpiracion = fechaExpiracion;

        this.Usuario = usuario;

        this.Pedido = pedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MetodoPagoEN t = obj as MetodoPagoEN;
        if (t == null)
                return false;
        if (IdMetodo.Equals (t.IdMetodo))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdMetodo.GetHashCode ();
        return hash;
}
}
}
