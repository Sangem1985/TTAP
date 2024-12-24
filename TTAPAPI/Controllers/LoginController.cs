using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace TTAPAPI.Controllers
{
    public class LoginController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public HttpResponseMessage ValidateLoginNew([FromBody] string UserID, string Password, string encpassword)
        {
            DataSet ds = new DataSet();
            //ds = ValidateLoginNew(UserID, Password, encpassword);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ds);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data Found with the entered UserName and Password");
            }
        }
    }
}