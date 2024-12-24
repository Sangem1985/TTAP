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
using BusinessLogic;
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class FormslsvcDetails : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ObjLoginvo"] != null)
            {
                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];
                if (!IsPostBack)
                {
                    GetSlcs();
                    if (ObjLoginvo.Role_Code != "JD") {
                        grdDetails.Columns[3].Visible = false;
                    }
                }
            }
            
            else
            {
                Response.Redirect("~/LoginReg.aspx");
            }
        }
        public void GetSlcs()
        {
            DataSet dss = new DataSet();
            dss = GetSlcList();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                grdDetails.DataSource = dss.Tables[0];
                grdDetails.DataBind();
            }
            else
            {
                grdDetails.DataSource = null;
                grdDetails.DataBind();
            }
        }
        public DataSet GetSlcList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("USP_Get_Slc_List_Details");
            return Dsnew;
        }
        protected void grdDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            string SLCNO = ((Label)(gr.FindControl("lblSlc_No"))).Text;
            string SLCDate = ((Label)(gr.FindControl("lblSlcDate"))).Text;
            if (e.CommandName == "RowAdd")
            {
                Response.Redirect("SLVUploadsEntry.aspx?SlcNo=" + SLCNO + "&Date="+ SLCDate);
            }
            else if (e.CommandName == "RowView")
            {   
                Response.Redirect("SLVUploadsEntry.aspx?SlcNo=" + SLCNO + "&Date=" + SLCDate + "&Type=V");
            }
        }
    }
}