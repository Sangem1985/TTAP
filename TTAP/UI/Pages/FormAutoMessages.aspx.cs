using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class FormAutoMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sendmessages();

            SendReminder1();
            SendReminder2();
            SendReminder3();
            SendMessagetoRDD();
            SendMessagetoAdditional();
        }
        public void SendReminder1()
        {
            string msg = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "12", "REMINDER1");
            }
            catch (Exception ex)
            {
                hdnReminder1.Value = "N";
                string errorMsg = ex.Message;
                LogError(ex);
            }
        }
        public void SendReminder2()
        {
            string msg = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "13", "REMINDER2");
            }
            catch (Exception ex)
            {
                hdnReminder2.Value = "N";
                string errorMsg = ex.Message;
                LogError(ex);
            }
        }
        public void SendReminder3()
        {
            string msg = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "14", "FINALNOTICE");
            }
            catch (Exception ex)
            {
                hdnReminder3.Value = "N";
                string errorMsg = ex.Message;
                LogError(ex);
            }
        }
        public void SendMessagetoRDD()
        {
            string msg = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "10", "TORDD");
            }
            catch (Exception ex)
            {
                hdnRDD.Value = "N";
                string errorMsg = ex.Message;
                LogError(ex);
            }
        }
        public void SendMessagetoAdditional()
        {
            string msg = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                msg = ClsSMSandMailobj.SendSmsWebService("", "", "Incentives", "11", "TOADDITIONAL");
            }
            catch (Exception ex)
            {
                hdnADD.Value = "N";
                string errorMsg = ex.Message;
                LogError(ex);
            }
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
                hdnMSG.Value = "N";
                string errorMsg = ex.Message;
            }
        }
        public static void LogError(Exception ex)
        {
            string filename = "ErrorLog_" + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy");

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog/" + filename + ".txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
           /* Sendmessages();
            if (hdnMSG.Value == "N") { Sendmessages(); }*/

            SendReminder1();
            SendReminder2();
            SendReminder3();
            SendMessagetoRDD();
            SendMessagetoAdditional();
        }
    }
}