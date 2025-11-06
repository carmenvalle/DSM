
using System;
// Definición clase RolEN
namespace DiagGen.ApplicationCore.EN.Diag
{
public partial class RolEN
{
/**
 *	Atributo idRlol
 */
private int idRlol;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo usuarios
 */
private System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.UsuarioEN> usuarios;






public virtual int IdRlol {
        get { return idRlol; } set { idRlol = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.UsuarioEN> Usuarios {
        get { return usuarios; } set { usuarios = value;  }
}





public RolEN()
{
        usuarios = new System.Collections.Generic.List<DiagGen.ApplicationCore.EN.Diag.UsuarioEN>();
}



public RolEN(int idRlol, string nombre, string descripcion, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.UsuarioEN> usuarios
             )
{
        this.init (IdRlol, nombre, descripcion, usuarios);
}


public RolEN(RolEN rol)
{
        this.init (rol.IdRlol, rol.Nombre, rol.Descripcion, rol.Usuarios);
}

private void init (int idRlol
                   , string nombre, string descripcion, System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.UsuarioEN> usuarios)
{
        this.IdRlol = idRlol;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Usuarios = usuarios;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RolEN t = obj as RolEN;
        if (t == null)
                return false;
        if (IdRlol.Equals (t.IdRlol))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.IdRlol.GetHashCode ();
        return hash;
}
}
}
