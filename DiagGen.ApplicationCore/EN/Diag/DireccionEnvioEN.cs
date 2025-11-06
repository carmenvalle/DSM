
using System;
// Definición clase DireccionEnvioEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class DireccionEnvioEN
{
/**
 *	Atributo idDireccion
 */
private int idDireccion;



/**
 *	Atributo calle
 */
private string calle;



/**
 *	Atributo ciudad
 */
private string ciudad;



/**
 *	Atributo codigoPostal
 */
private string codigoPostal;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo usuario
 */
private DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario;



/**
 *	Atributo pedidos
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedidos;






public virtual int IdDireccion {
        get { return idDireccion; } set { idDireccion = value;  }
}



public virtual string Calle {
        get { return calle; } set { calle = value;  }
}



public virtual string Ciudad {
        get { return ciudad; } set { ciudad = value;  }
}



public virtual string CodigoPostal {
        get { return codigoPostal; } set { codigoPostal = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> Pedidos {
        get { return pedidos; } set { pedidos = value;  }
}





public DireccionEnvioEN()
{
        pedidos = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.PedidoEN>();
}



public DireccionEnvioEN(int idDireccion, string calle, string ciudad, string codigoPostal, string pais, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedidos
                        )
{
        this.init (IdDireccion, calle, ciudad, codigoPostal, pais, usuario, pedidos);
}


public DireccionEnvioEN(DireccionEnvioEN direccionEnvio)
{
        this.init (direccionEnvio.IdDireccion, direccionEnvio.Calle, direccionEnvio.Ciudad, direccionEnvio.CodigoPostal, direccionEnvio.Pais, direccionEnvio.Usuario, direccionEnvio.Pedidos);
}

private void init (int idDireccion
                   , string calle, string ciudad, string codigoPostal, string pais, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> pedidos)
{
        this.IdDireccion = idDireccion;


        this.Calle = calle;

        this.Ciudad = ciudad;

        this.CodigoPostal = codigoPostal;

        this.Pais = pais;

        this.Usuario = usuario;

        this.Pedidos = pedidos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        DireccionEnvioEN t = obj as DireccionEnvioEN;
        if (t == null)
                return false;
        if (IdDireccion.Equals (t.IdDireccion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdDireccion.GetHashCode ();
        return hash;
}
}
}
