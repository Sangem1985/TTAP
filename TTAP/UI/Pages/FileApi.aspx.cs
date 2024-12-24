using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TTAP.UI.Pages
{
    public partial class FileApi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["filepath"] != null)
            {
                module.Value = Request.QueryString["module"].ToString();
                filepath.Value = Request.QueryString["filepath"].ToString();
                cfeid.Value = Request.QueryString["cfeid"].ToString();
            }
        }
    }
}