

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;
using Newtonsoft.Json;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}

public int Registrarse (string p_nombre, string p_correo, string p_direccion, int p_rol, String p_pass)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Correo = p_correo;

        usuarioEN.Direccion = p_direccion;


        if (p_rol != -1) {
                // El argumento p_rol -> Property rol es oid = false
                // Lista de oids idUsuario
                usuarioEN.Rol = new DiagGen.ApplicationCore.EN.Diag.RolEN ();
                usuarioEN.Rol.IdRlol = p_rol;
        }

        usuarioEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);



        oid = _IUsuarioRepository.Registrarse (usuarioEN);
        return oid;
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.UsuarioEN> CerrarSesion ()
{
        return _IUsuarioRepository.CerrarSesion ();
}
public void EliminarCuenta (int idUsuario
                            )
{
        _IUsuarioRepository.EliminarCuenta (idUsuario);
}

public string Login (int p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.IdUsuario);

        return result;
}




private string Encode (int idUsuario)
{
        var payload = new Dictionary<string, object>(){
                { "idUsuario", idUsuario }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (int idUsuario)
{
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (idUsuario);
        string token = Encode (en.IdUsuario);

        return token;
}
public int CheckToken (string token)
{
        int result = -1;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                int id = (int)ObtenerIDUSUARIO (decodedToken);

                UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (id);

                if (en != null && ((long)en.IdUsuario).Equals (ObtenerIDUSUARIO (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public long ObtenerIDUSUARIO (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                long idusuario = (long)results ["idUsuario"];
                return idusuario;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
