

using DiagGen.ApplicationCore.IRepository.Diag;
using DiagGen.Infraestructure.Repository.Diag;
using DiagGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiagGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IUsuarioRepository UsuarioRepository {
        get
        {
                this.usuariorepository = new UsuarioRepository ();
                this.usuariorepository.setSessionCP (session);
                return this.usuariorepository;
        }
}

public override IPedidoRepository PedidoRepository {
        get
        {
                this.pedidorepository = new PedidoRepository ();
                this.pedidorepository.setSessionCP (session);
                return this.pedidorepository;
        }
}

public override IRolRepository RolRepository {
        get
        {
                this.rolrepository = new RolRepository ();
                this.rolrepository.setSessionCP (session);
                return this.rolrepository;
        }
}

public override IFavoritoRepository FavoritoRepository {
        get
        {
                this.favoritorepository = new FavoritoRepository ();
                this.favoritorepository.setSessionCP (session);
                return this.favoritorepository;
        }
}

public override IDireccionEnvioRepository DireccionEnvioRepository {
        get
        {
                this.direccionenviorepository = new DireccionEnvioRepository ();
                this.direccionenviorepository.setSessionCP (session);
                return this.direccionenviorepository;
        }
}

public override IMetodoPagoRepository MetodoPagoRepository {
        get
        {
                this.metodopagorepository = new MetodoPagoRepository ();
                this.metodopagorepository.setSessionCP (session);
                return this.metodopagorepository;
        }
}

public override IProductoRepository ProductoRepository {
        get
        {
                this.productorepository = new ProductoRepository ();
                this.productorepository.setSessionCP (session);
                return this.productorepository;
        }
}

public override IPedidoItemRepository PedidoItemRepository {
        get
        {
                this.pedidoitemrepository = new PedidoItemRepository ();
                this.pedidoitemrepository.setSessionCP (session);
                return this.pedidoitemrepository;
        }
}

public override IValoracionRepository ValoracionRepository {
        get
        {
                this.valoracionrepository = new ValoracionRepository ();
                this.valoracionrepository.setSessionCP (session);
                return this.valoracionrepository;
        }
}
}
}

