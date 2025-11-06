
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IFavoritoRepository
{
void setSessionCP (GenericSessionCP session);

FavoritoEN ReadOIDDefault (int idFavorito
                           );

void ModifyDefault (FavoritoEN favorito);

System.Collections.Generic.IList<FavoritoEN> ReadAllDefault (int first, int size);



int MarcarFavorito (FavoritoEN favorito);

void DesmarcarFavorito (int idFavorito
                        );
}
}
