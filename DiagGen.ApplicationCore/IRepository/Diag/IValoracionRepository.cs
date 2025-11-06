
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IValoracionRepository
{
void setSessionCP (GenericSessionCP session);

ValoracionEN ReadOIDDefault (int idValoracion
                             );

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);



int Guardar (ValoracionEN valoracion);

void Borrar (int idValoracion
             );
}
}
