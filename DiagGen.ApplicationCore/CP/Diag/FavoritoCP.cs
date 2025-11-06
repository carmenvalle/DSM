
using System;
using System.Text;
using System.Collections.Generic;
using DiagGen.ApplicationCore.Exceptions;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;
using DiagGen.ApplicationCore.CEN.Diag;
using DiagGen.ApplicationCore.Utils;



namespace DiagGen.ApplicationCore.CP.Diag
{
public partial class FavoritoCP : GenericBasicCP
{
public FavoritoCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public FavoritoCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
