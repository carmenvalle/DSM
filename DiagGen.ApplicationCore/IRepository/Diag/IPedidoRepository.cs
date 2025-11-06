
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IPedidoRepository
{
void setSessionCP (GenericSessionCP session);

PedidoEN ReadOIDDefault (int idPedido
                         );

void ModifyDefault (PedidoEN pedido);

System.Collections.Generic.IList<PedidoEN> ReadAllDefault (int first, int size);



int RealizarPedido (PedidoEN pedido);

PedidoEN VerPedido (int idPedido
                    );


int CancelarPedido (PedidoEN pedido);

System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> DamePedidoPorItem ();
}
}
