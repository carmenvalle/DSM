
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IDireccionEnvioRepository
{
void setSessionCP (GenericSessionCP session);

DireccionEnvioEN ReadOIDDefault (int idDireccion
                                 );

void ModifyDefault (DireccionEnvioEN direccionEnvio);

System.Collections.Generic.IList<DireccionEnvioEN> ReadAllDefault (int first, int size);



int Guardar (DireccionEnvioEN direccionEnvio);

void Editar (DireccionEnvioEN direccionEnvio);


void Eliminar (int idDireccion
               );
}
}
