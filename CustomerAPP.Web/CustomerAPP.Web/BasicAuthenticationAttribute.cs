using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;

namespace CustomerAPP.Web
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Gets header parameters  
                string authenticationString = actionContext.Request.Headers.Authorization.Parameter;
                string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                // Gets username and password  
                string usrename = originalString.Split(':')[0];
                string password = originalString.Split(':')[1];

                // Validate username and password  
                if (!ApiSecurity.VaidateUser(usrename, password))
                {
                    // returns unauthorized error  
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

            base.OnAuthorization(actionContext);
        }
    }

    public class ApiSecurity
    {
        public static bool VaidateUser(string username, string password)
        {
            // Check if it is valid credential  
            if (username == "test" && password == "test")//CheckUserInDB(username, password))  
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}