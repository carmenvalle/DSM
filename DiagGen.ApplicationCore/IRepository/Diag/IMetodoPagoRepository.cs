
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IMetodoPagoRepository
{
void setSessionCP (GenericSessionCP session);

MetodoPagoEN ReadOIDDefault (int idMetodo
                             );

void ModifyDefault (MetodoPagoEN metodoPago);

System.Collections.Generic.IList<MetodoPagoEN> ReadAllDefault (int first, int size);



int Guardar (MetodoPagoEN metodoPago);

void Editar (MetodoPagoEN metodoPago);


void Eliminar (int idMetodo
               );
}
}
