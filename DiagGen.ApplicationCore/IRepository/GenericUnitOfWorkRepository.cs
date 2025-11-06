
using System;
using System.Collections.Generic;
using System.Text;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public abstract class GenericUnitOfWorkRepository
{
protected IUsuarioRepository usuariorepository;
protected IPedidoRepository pedidorepository;
protected IRolRepository rolrepository;
protected IFavoritoRepository favoritorepository;
protected IDireccionEnvioRepository direccionenviorepository;
protected IMetodoPagoRepository metodopagorepository;
protected IProductoRepository productorepository;
protected IPedidoItemRepository pedidoitemrepository;
protected IValoracionRepository valoracionrepository;


public abstract IUsuarioRepository UsuarioRepository {
        get;
}
public abstract IPedidoRepository PedidoRepository {
        get;
}
public abstract IRolRepository RolRepository {
        get;
}
public abstract IFavoritoRepository FavoritoRepository {
        get;
}
public abstract IDireccionEnvioRepository DireccionEnvioRepository {
        get;
}
public abstract IMetodoPagoRepository MetodoPagoRepository {
        get;
}
public abstract IProductoRepository ProductoRepository {
        get;
}
public abstract IPedidoItemRepository PedidoItemRepository {
        get;
}
public abstract IValoracionRepository ValoracionRepository {
        get;
}
}
}
