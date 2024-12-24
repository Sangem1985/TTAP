using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages.MISReports
{
    public partial class frmIncentiveReports : System.Web.UI.Page
    {
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass caf = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ObjLoginvo"] != null)
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                if (ObjLoginNewvo.Role_Code == "JD")
                {
                    aSanction.Visible = true;
                }
                if (ObjLoginNewvo.Role_Code == "DLO")
                {
                    divDLO.Visible = true;
                    divAdmn.Visible = false;
                }
                if (ObjLoginNewvo.user_id == "RDD-Warangal" || ObjLoginNewvo.user_id == "RDD-Hyderabad")
                {
                    divDLO.Visible = true;
                    li1.InnerText = "R1.AD Wise Incentive Abstract";
                    A2.Visible = false;
                    A3.Visible = false;
                    A4.Visible = false;
                    A5.Visible = false;
                    divAdmn.Visible = false;
                }
            }
        }
    }
}