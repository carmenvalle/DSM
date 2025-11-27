
using DiagGen.ApplicationCore.CP.Diag;
using DiagGen.ApplicationCore.EN.Diag;
using System;
using System.Collections.Generic;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IValoracionRepository
{
void setSessionCP (GenericSessionCP session);

ValoracionEN ReadOIDDefault (int idValoracion);

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);
IList<ValoracionEN> BuscarPorProducto(int idProducto);


int Guardar (ValoracionEN valoracion);

void Borrar (int idValoracion
             );

}
}
