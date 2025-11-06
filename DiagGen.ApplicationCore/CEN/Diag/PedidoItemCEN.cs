

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class PedidoItemCEN
 *
 */
public partial class PedidoItemCEN
{
private IPedidoItemRepository _IPedidoItemRepository;

public PedidoItemCEN(IPedidoItemRepository _IPedidoItemRepository)
{
        this._IPedidoItemRepository = _IPedidoItemRepository;
}

public IPedidoItemRepository get_IPedidoItemRepository ()
{
        return this._IPedidoItemRepository;
}
}
}
