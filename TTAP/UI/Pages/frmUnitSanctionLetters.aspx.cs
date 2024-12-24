using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class frmUnitSanctionLetters : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        string UID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ObjLoginvo"] != null)
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                hdnUserId.Value = ObjLoginNewvo.uid;
            }
            else
            {
                Response.Redirect("~/LoginReg.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
        }
        public void GetData()
        {
            DataSet ds = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@UnitId",SqlDbType.VarChar)
            };
            pp[0].Value = hdnUserId.Value;
            ds = ObjCAFClass.GenericFillDs("USP_GET_ISSUED_SANCTION_LETTERS_LIST_UNIT", pp);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
                divNoData.Visible = false;

            }
            else
            {
                gvdetailsnew.DataSource = null;
                gvdetailsnew.DataBind();
                divNoData.Visible = true;
            }
        }
        
    }
}