
using System;
// Definición clase FavoritoEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class FavoritoEN
{
/**
 *	Atributo idFavorito
 */
private int idFavorito;



/**
 *	Atributo usuario
 */
private DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario;



/**
 *	Atributo producto
 */
private DiagGen.ApplicationCore.EN.Diag.ProductoEN producto;






public virtual int IdFavorito {
        get { return idFavorito; } set { idFavorito = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual DiagGen.ApplicationCore.EN.Diag.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}





public FavoritoEN()
{
}



public FavoritoEN(int idFavorito, DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario, DiagGen.ApplicationCore.EN.Diag.ProductoEN producto
                  )
{
        this.init (IdFavorito, usuario, producto);
}


public FavoritoEN(FavoritoEN favorito)
{
        this.init (favorito.IdFavorito, favorito.Usuario, favorito.Producto);
}

private void init (int idFavorito
                   , DiagGen.ApplicationCore.EN.Diag.UsuarioEN usuario, DiagGen.ApplicationCore.EN.Diag.ProductoEN producto)
{
        this.IdFavorito = idFavorito;


        this.Usuario = usuario;

        this.Producto = producto;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FavoritoEN t = obj as FavoritoEN;
        if (t == null)
                return false;
        if (IdFavorito.Equals (t.IdFavorito))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdFavorito.GetHashCode ();
        return hash;
}
}
}
