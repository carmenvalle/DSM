
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
public partial class MetodoPagoCP : GenericBasicCP
{
public MetodoPagoCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public MetodoPagoCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
