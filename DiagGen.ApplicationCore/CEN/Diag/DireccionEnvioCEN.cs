

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class DireccionEnvioCEN
 *
 */
public partial class DireccionEnvioCEN
{
private IDireccionEnvioRepository _IDireccionEnvioRepository;

public DireccionEnvioCEN(IDireccionEnvioRepository _IDireccionEnvioRepository)
{
        this._IDireccionEnvioRepository = _IDireccionEnvioRepository;
}

public IDireccionEnvioRepository get_IDireccionEnvioRepository ()
{
        return this._IDireccionEnvioRepository;
}

public void Editar (int p_DireccionEnvio_OID, string p_calle, string p_ciudad, string p_codigoPostal, string p_pais)
{
        DireccionEnvioEN direccionEnvioEN = null;

        //Initialized DireccionEnvioEN
        direccionEnvioEN = new DireccionEnvioEN ();
        direccionEnvioEN.IdDireccion = p_DireccionEnvio_OID;
        direccionEnvioEN.Calle = p_calle;
        direccionEnvioEN.Ciudad = p_ciudad;
        direccionEnvioEN.CodigoPostal = p_codigoPostal;
        direccionEnvioEN.Pais = p_pais;
        //Call to DireccionEnvioRepository

        _IDireccionEnvioRepository.Editar (direccionEnvioEN);
}

public void Eliminar (int idDireccion
                      )
{
        _IDireccionEnvioRepository.Eliminar (idDireccion);
}
}
}
