
using System;
// Definición clase UsuarioEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class UsuarioEN
{
/**
 *	Atributo idUsuario
 */
private int idUsuario;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo correo
 */
private string correo;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo rol
 */
private DiagGen.ApplicationCore.EN.Diag.RolEN rol;



/**
 *	Atributo pedidos
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedidos;



/**
 *	Atributo favoritos
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.FavoritoEN> favoritos;



/**
 *	Atributo direccionesEnvio
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN> direccionesEnvio;



/**
 *	Atributo metodosPago
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN> metodosPago;



/**
 *	Atributo valoraciones
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ValoracionEN> valoraciones;



/**
 *	Atributo pass
 */
private String pass;






public virtual int IdUsuario {
        get { return idUsuario; } set { idUsuario = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Correo {
        get { return correo; } set { correo = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.RolEN Rol {
        get { return rol; } set { rol = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> Pedidos {
        get { return pedidos; } set { pedidos = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.FavoritoEN> Favoritos {
        get { return favoritos; } set { favoritos = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN> DireccionesEnvio {
        get { return direccionesEnvio; } set { direccionesEnvio = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN> MetodosPago {
        get { return metodosPago; } set { metodosPago = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ValoracionEN> Valoraciones {
        get { return valoraciones; } set { valoraciones = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public UsuarioEN()
{
        pedidos = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.PedidoEN>();
        favoritos = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.FavoritoEN>();
        direccionesEnvio = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN>();
        metodosPago = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN>();
        valoraciones = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.ValoracionEN>();
}



public UsuarioEN(int idUsuario, string nombre, string correo, string direccion, DiagGen.ApplicationCore.EN.Diag.RolEN rol, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedidos, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.FavoritoEN> favoritos, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN> direccionesEnvio, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN> metodosPago, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ValoracionEN> valoraciones, String pass
                 )
{
        this.init (IdUsuario, nombre, correo, direccion, rol, pedidos, favoritos, direccionesEnvio, metodosPago, valoraciones, pass);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.IdUsuario, usuario.Nombre, usuario.Correo, usuario.Direccion, usuario.Rol, usuario.Pedidos, usuario.Favoritos, usuario.DireccionesEnvio, usuario.MetodosPago, usuario.Valoraciones, usuario.Pass);
}

private void init (int idUsuario
                   , string nombre, string correo, string direccion, DiagGen.ApplicationCore.EN.Diag.RolEN rol, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedidos, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.FavoritoEN> favoritos, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.DireccionEnvioEN> direccionesEnvio, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.MetodoPagoEN> metodosPago, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ValoracionEN> valoraciones, String pass)
{
        this.IdUsuario = idUsuario;


        this.Nombre = nombre;

        this.Correo = correo;

        this.Direccion = direccion;

        this.Rol = rol;

        this.Pedidos = pedidos;

        this.Favoritos = favoritos;

        this.DireccionesEnvio = direccionesEnvio;

        this.MetodosPago = metodosPago;

        this.Valoraciones = valoraciones;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (IdUsuario.Equals (t.IdUsuario))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdUsuario.GetHashCode ();
        return hash;
}
}
}
