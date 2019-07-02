using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.SessionState;
using WebApplication5.Filters;

namespace WebApplication5.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("{controler}/Login/{login}/{password}")]
        public void Login([FromUri]string login,string password)
        {
            var session = System.Web.HttpContext.Current.Session;
            session["Login"] = login;
            session["Password"] = password;
            if ((string)session["Login"] == "Login")
                session["Logined"] = true;
            else
                session["Logined"] = false;

        }

        [AuthenticationFilter]
        [HttpGet]
        [Route("{controler}/act")]
        public IHttpActionResult SomeAction()
        {
            return Content(HttpStatusCode.OK,"Some action");
        }
    }
}
