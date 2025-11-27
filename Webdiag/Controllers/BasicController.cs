using Microsoft.AspNetCore.Mvc;
using NHibernate;
using DiagGen.Infraestructure.CP;
using DiagGen.Infraestructure.Repository.Diag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webdiag.Controllers
{
    public class BasicController:Controller
    {
        private NHibernate.ISession sessionInside;


        protected SessionCPNHibernate session;

        protected BasicController()
        {
        }

        protected void SessionInitialize()
        {
            if (session == null)
            {
                sessionInside = NHibernateHelper.OpenSession();
                session = new SessionCPNHibernate(sessionInside);
            }
        }


        protected void SessionClose()
        {
            if (session != null && sessionInside.IsOpen)
            {
                sessionInside.Close();
                sessionInside.Dispose();
                session = null;
            }
        }
    }
}


