

using System;
using System.Text;
using System.Collections.Generic;

using DiagGen.ApplicationCore.Exceptions;

using DiagGen.ApplicationCore.EN.Diag;
using DiagGen.ApplicationCore.IRepository.Diag;


namespace DiagGen.ApplicationCore.CEN.Diag
{
/*
 *      Definition of the class RolCEN
 *
 */
public partial class RolCEN
{
private IRolRepository _IRolRepository;

public RolCEN(IRolRepository _IRolRepository)
{
        this._IRolRepository = _IRolRepository;
}

public IRolRepository get_IRolRepository ()
{
        return this._IRolRepository;
}

public int Crear (string p_nombre, string p_descripcion)
{
        RolEN rolEN = null;
        int oid;

        //Initialized RolEN
        rolEN = new RolEN ();
        rolEN.Nombre = p_nombre;

        rolEN.Descripcion = p_descripcion;



        oid = _IRolRepository.Crear (rolEN);
        return oid;
}
}
}
