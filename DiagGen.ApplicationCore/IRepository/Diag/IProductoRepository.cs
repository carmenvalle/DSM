
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IProductoRepository
{
void setSessionCP (GenericSessionCP session);

ProductoEN ReadOIDDefault (int idProducto
                           );

void ModifyDefault (ProductoEN producto);

System.Collections.Generic.IList<ProductoEN> ReadAllDefault (int first, int size);



int Publicar (ProductoEN producto);

System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> Editar ();


void Eliminar (int idProducto
               );


System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> BuscarPorPalabra (string p_idProducto);


System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> Categoria (int ? p_idProducto);


System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> PorPrecio (int ? p_idProducto);


int ValoracionMedia (ProductoEN producto);

System.Collections.Generic.IList<DiagGen.ApplicationCore.EN.Diag.ProductoEN> ValorarPorCategoria (int ? p_idProducto);
}
}
