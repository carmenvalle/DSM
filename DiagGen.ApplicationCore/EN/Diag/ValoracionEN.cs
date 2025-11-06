
using System;
// Definición clase ValoracionEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class ValoracionEN
{
/**
 *	Atributo idValoracion
 */
private int idValoracion;



/**
 *	Atributo puntuacion
 */
private int puntuacion;



/**
 *	Atributo comentario
 */
private string comentario;



/**
 *	Atributo producto
 */
private DiagGen.ApplicationCore.EN.Diag.ProductoEN producto;



/**
 *	Atributo usuario
 */
private DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario;






public virtual int IdValoracion {
        get { return idValoracion; } set { idValoracion = value;  }
}



public virtual int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}



public virtual string Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int idValoracion, int puntuacion, string comentario, DiagGen.ApplicationCore.EN.Diag.ProductoEN producto, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario
                    )
{
        this.init (IdValoracion, puntuacion, comentario, producto, usuario);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.IdValoracion, valoracion.Puntuacion, valoracion.Comentario, valoracion.Producto, valoracion.Usuario);
}

private void init (int idValoracion
                   , int puntuacion, string comentario, DiagGen.ApplicationCore.EN.Diag.ProductoEN producto, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario)
{
        this.IdValoracion = idValoracion;


        this.Puntuacion = puntuacion;

        this.Comentario = comentario;

        this.Producto = producto;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
        if (t == null)
                return false;
        if (IdValoracion.Equals (t.IdValoracion))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdValoracion.GetHashCode ();
        return hash;
}
}
}
