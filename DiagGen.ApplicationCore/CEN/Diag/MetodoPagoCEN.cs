

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class MetodoPagoCEN
 *
 */
public partial class MetodoPagoCEN
{
private IMetodoPagoRepository _IMetodoPagoRepository;

public MetodoPagoCEN(IMetodoPagoRepository _IMetodoPagoRepository)
{
        this._IMetodoPagoRepository = _IMetodoPagoRepository;
}

public IMetodoPagoRepository get_IMetodoPagoRepository ()
{
        return this._IMetodoPagoRepository;
}

public int Guardar (string p_tipo, string p_numero, Nullable<DateTime> p_fechaExpiracion, int p_usuario)
{
        MetodoPagoEN metodoPagoEN = null;
        int oid;

        //Initialized MetodoPagoEN
        metodoPagoEN = new MetodoPagoEN ();
        metodoPagoEN.Tipo = p_tipo;

        metodoPagoEN.Numero = p_numero;

        metodoPagoEN.FechaExpiracion = p_fechaExpiracion;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids idMetodo
                metodoPagoEN.Usuario = new DiagGen.ApplicationCore.EN.Diag.UsuarioEN ();
                metodoPagoEN.Usuario.IdUsuario = p_usuario;
        }



        oid = _IMetodoPagoRepository.Guardar (metodoPagoEN);
        return oid;
}

public void Editar (int p_MetodoPago_OID, string p_tipo, string p_numero, Nullable<DateTime> p_fechaExpiracion)
{
        MetodoPagoEN metodoPagoEN = null;

        //Initialized MetodoPagoEN
        metodoPagoEN = new MetodoPagoEN ();
        metodoPagoEN.IdMetodo = p_MetodoPago_OID;
        metodoPagoEN.Tipo = p_tipo;
        metodoPagoEN.Numero = p_numero;
        metodoPagoEN.FechaExpiracion = p_fechaExpiracion;
        //Call to MetodoPagoRepository

        _IMetodoPagoRepository.Editar (metodoPagoEN);
}

public void Eliminar (int idMetodo
                      )
{
        _IMetodoPagoRepository.Eliminar (idMetodo);
}
}
}
