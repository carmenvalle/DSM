

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionRepository _IValoracionRepository;

public ValoracionCEN(IValoracionRepository _IValoracionRepository)
{
        this._IValoracionRepository = _IValoracionRepository;
}

public IValoracionRepository get_IValoracionRepository ()
{
        return this._IValoracionRepository;
}

public int Guardar (int p_puntuacion, string p_comentario, int p_producto, int p_usuario)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Puntuacion = p_puntuacion;

        valoracionEN.Comentario = p_comentario;


        if (p_producto != -1) {
                // El argumento p_producto -> Property producto es oid = false
                // Lista de oids idValoracion
                valoracionEN.Producto = new DiagGen.ApplicationCore.EN.Diag.ProductoEN ();
                valoracionEN.Producto.IdProducto = p_producto;
        }


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids idValoracion
                valoracionEN.Usuario = new DiagGen.ApplicationCore.EN.Diag.UsuarioEN ();
                valoracionEN.Usuario.IdUsuario = p_usuario;
        }



        oid = _IValoracionRepository.Guardar (valoracionEN);
        return oid;
}

public void Borrar (int idValoracion
                    )
{
        _IValoracionRepository.Borrar (idValoracion);
}
}
}
