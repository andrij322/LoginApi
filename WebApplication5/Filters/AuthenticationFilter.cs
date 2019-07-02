using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Web.Http.Results;

namespace WebApplication5.Filters
{
    public class AuthenticationFilter:Attribute,IAuthenticationFilter
    {
        public Task AuthenticateAsync(HttpAuthenticationContext context,CancellationToken token)
        {
            var logined = System.Web.HttpContext.Current.Session["Logined"];
            if (logined==null||(bool)logined==false)
                context.ErrorResult = new StatusCodeResult(HttpStatusCode.Unauthorized,context.Request);
            return Task.FromResult<object>(null);
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }
        public bool AllowMultiple
        {
            get { return false; }
        }
    }
}