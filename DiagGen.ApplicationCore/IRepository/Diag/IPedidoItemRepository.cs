
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IPedidoItemRepository
{
void setSessionCP (GenericSessionCP session);

PedidoItemEN ReadOIDDefault (int idItem
                             );

void ModifyDefault (PedidoItemEN pedidoItem);

System.Collections.Generic.IList<PedidoItemEN> ReadAllDefault (int first, int size);



int CrearPedidoItem (PedidoItemEN pedidoItem);

int New_ (PedidoItemEN pedidoItem);
}
}
