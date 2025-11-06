
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (int idUsuario
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int Registrarse (UsuarioEN usuario);

System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.UsuarioEN> CerrarSesion ();


void EliminarCuenta (int idUsuario
                     );
}
}
