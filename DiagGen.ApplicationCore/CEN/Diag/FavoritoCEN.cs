

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class FavoritoCEN
 *
 */
public partial class FavoritoCEN
{
private IFavoritoRepository _IFavoritoRepository;

public FavoritoCEN(IFavoritoRepository _IFavoritoRepository)
{
        this._IFavoritoRepository = _IFavoritoRepository;
}

public IFavoritoRepository get_IFavoritoRepository ()
{
        return this._IFavoritoRepository;
}

public int MarcarFavorito (int p_usuario, int p_producto)
{
        FavoritoEN favoritoEN = null;
        int oid;

        //Initialized FavoritoEN
        favoritoEN = new FavoritoEN ();

        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids idFavorito
                favoritoEN.Usuario = new DiagGen.ApplicationCore.EN.Diag.UsuarioEN ();
                favoritoEN.Usuario.IdUsuario = p_usuario;
        }


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids idFavorito
                favoritoEN.Producto = new DiagGen.ApplicationCore.EN.Diag.ProductoEN ();
                favoritoEN.Producto.IdProducto = p_producto;
        }



        oid = _IFavoritoRepository.MarcarFavorito (favoritoEN);
        return oid;
}
}
}
