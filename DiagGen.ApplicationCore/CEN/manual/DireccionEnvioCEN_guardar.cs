
using System;
using System.Text;
using System.Collections.Generic;
using DiagGen.ApplicationCore.Exceptions;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


/*PROTECTED REGION ID(usingDiagGen.ApplicationCore.CEN.Diag_DireccionEnvio_guardar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DiagGen.ApplicationCore.CEN.Diag
{
public partial class DireccionEnvioCEN
{
public int Guardar (string p_calle, string p_ciudad, string p_codigoPostal, string p_pais, int p_usuario)
{
        /*PROTECTED REGION ID(DiagGen.ApplicationCore.CEN.Diag_DireccionEnvio_guardar_customized) START*/

        DireccionEnvioEN direccionEnvioEN = null;

        int oid;

        //Initialized DireccionEnvioEN
        direccionEnvioEN = new DireccionEnvioEN ();
        direccionEnvioEN.Calle = p_calle;

        direccionEnvioEN.Ciudad = p_ciudad;

        direccionEnvioEN.CodigoPostal = p_codigoPostal;

        direccionEnvioEN.Pais = p_pais;


        if (p_usuario != -1) {
                direccionEnvioEN.Usuario = new DiagGen.ApplicationCore.EN.Diag.UsuarioEN ();
                direccionEnvioEN.Usuario.IdUsuario = p_usuario;
        }

        //Call to DireccionEnvioRepository

        oid = _IDireccionEnvioRepository.Guardar (direccionEnvioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
