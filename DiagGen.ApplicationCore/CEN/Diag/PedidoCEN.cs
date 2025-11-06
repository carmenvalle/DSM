

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public PedidoEN VerPedido (int idPedido
                           )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoRepository.VerPedido (idPedido);
        return pedidoEN;
}

public System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.PedidoEN> DamePedidoPorItem ()
{
        return _IPedidoRepository.DamePedidoPorItem ();
}
}
}
