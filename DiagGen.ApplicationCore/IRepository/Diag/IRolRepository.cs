
using System;
using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.CP.Diag;

namespace DiagGen.ApplicationCore.IRepository.Diag
{
public partial interface IRolRepository
{
void setSessionCP (GenericSessionCP session);

RolEN ReadOIDDefault (int idRlol
                      );

void ModifyDefault (RolEN rol);

System.Collections.Generic.IList<RolEN> ReadAllDefault (int first, int size);



int Crear (RolEN rol);
}
}
