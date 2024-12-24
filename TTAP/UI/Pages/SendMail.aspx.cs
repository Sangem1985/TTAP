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
using System.Net;
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class SendMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ObjLoginvo"] == null)
            {
                Response.Redirect("~/LoginReg.aspx");
            }
            if (!IsPostBack)
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
            }
        }
        protected void btnRemainderMail_Click(object sender, EventArgs e)
        {
            Sendmessages();
            //SendReminders();
            //SendMessagetoRDDandAdditional();
        }
        public void Sendmessages()
        {
            string msg = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                msg = ClsSMSandMailobj.SendSmsWebService("25", "1", "Incentives", "1", "USERFILLING");
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        public void SendReminders()
        {
            string msg = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "12", "REMINDER1");
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "13", "REMINDER2");
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "14", "FINALNOTICE");
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        public void SendMessagetoRDDandAdditional()
        {
            string msg = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "10", "TORDD");
                //msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "13", "REMINDER2");
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
    }
}