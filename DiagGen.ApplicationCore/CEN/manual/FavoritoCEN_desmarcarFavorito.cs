
using System;
using System.Text;
using System.Collections.Generic;
using DiagGen.ApplicationCore.Exceptions;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


/*PROTECTED REGION ID(usingDiagGen.ApplicationCore.CEN.Diag_Favorito_desmarcarFavorito) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DiagGen.ApplicationCore.CEN.Diag
{
public partial class FavoritoCEN
{
public void DesmarcarFavorito (int idFavorito
                               )
{
        /*PROTECTED REGION ID(DiagGen.ApplicationCore.CEN.Diag_Favorito_desmarcarFavorito_customized) START*/

        _IFavoritoRepository.DesmarcarFavorito (idFavorito);

        /*PROTECTED REGION END*/
}
}
}
