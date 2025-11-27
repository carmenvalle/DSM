

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
public void EliminarCuenta (string p_nombre
                            )
{
        _IUsuarioRepository.EliminarCuenta (p_nombre);
}

        public string Login(string p_nombre, string p_pass)
        {
            string result = null;
            UsuarioEN en = _IUsuarioRepository.ReadOIDDefault(p_nombre);

            if (en != null && en.Pass.Equals(Utils.Util.GetEncondeMD5(p_pass)))
                result = this.GetToken(en.Nombre);

            return result;
        }




        private string Encode(string p_nombre)
        {
            var payload = new Dictionary<string, object>(){
                { "Nombre", p_nombre }
        };
            string token = Jose.JWT.Encode(payload, Utils.Util.getKey(), Jose.JwsAlgorithm.HS256);

            return token;
        }

        public string GetToken(string p_nombre)
        {
            UsuarioEN en = _IUsuarioRepository.ReadOIDDefault(p_nombre);
            string token = Encode(en.Nombre);

            return token;
        }
        public int CheckToken(string token)
        {
            int result = -1;

            try
            {
                string decodedToken = Utils.Util.Decode(token);

                string nombre = ObtenerNombreUsuario(decodedToken);

                UsuarioEN en = _IUsuarioRepository.ReadOIDDefault(nombre);

                if (en != null && en.Nombre.Equals(nombre))
                {
                    result = en.IdUsuario;
                }
                else throw new ModelException("El token es incorrecto");
            }
            catch (Exception)
            {
                throw new ModelException("El token es incorrecto");
            }

            return result;
        }

        public string ObtenerNombreUsuario(string decodedToken)
        {
            try
            {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object>>(decodedToken);
                string nombre = results["Nombre"].ToString();
                return nombre;
            }
            catch
            {
                throw new Exception("El token enviado no es correcto");
            }
        }
}
}
