using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;

namespace eTicketingSystem.UI
{
    public partial class UserDashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/LoginReg.aspx");
            }

            if (!IsPostBack)
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();

                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                if (ObjLoginNewvo.userlevel == "13")
                {
                    Response.Redirect("~/UI/ApplicantDashBaord.aspx");
                }
                else if (ObjLoginNewvo.userlevel == "2")
                {
                    if (ObjLoginNewvo.Role_Code == "DO")
                    {
                        Response.Redirect("~/UI/HdDashBoard.aspx");
                    }
                    else if (ObjLoginNewvo.Role_Code == "DEPT")
                    {
                        Response.Redirect("~/UI/frmStateDashboard.aspx");
                    }
                    else
                    {
                        Response.Redirect("~/UI/HdDashBoard.aspx");
                    }
                }
            }
        }
    }
}