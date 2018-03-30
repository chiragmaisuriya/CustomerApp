using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerAPP.Data;

namespace CustomerAPP.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ICustomerAPPUow Uow { get; set; }

    }
}
