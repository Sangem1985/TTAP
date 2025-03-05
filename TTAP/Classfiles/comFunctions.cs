
using System.Xml;
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;
using System.Net;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Data.SqlClient;
//using System.IO;
//using System.Net;
using System.Net.Security;
//using System.Net.Mail;
using System.Text;
using System.Linq;
/// <summary>
/// Summary description for common
/// </summary>
public class comFunctions
{
    //static String username = "cgg-tipass";
    //static String password = "tip@$$@2016";
    //static String senderid = "TiPASS";

    static String username = "TSIPASS";
    static String password = "kcsb@786";
    static String senderid = "TSIPAS";

    HttpWebRequest request;
    static Stream dataStream;

    string responseFromServer = "";
    public comFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region ClearControls
    public void ResetFormControl(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControl(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Text = "";
                        break;

                    case "System.Web.UI.WebControls.DropDownList":

                        if (((DropDownList)c).Items.Count > 0)
                        {
                            ((DropDownList)c).SelectedIndex = 0;
                        }
                        break;
                }
            }
        }
    }
    #endregion

    #region converting dd/mm/yyyy to mm/dd/yyyy

    public DateTime convertDateIndia(string datetoconvert)
    {
        DateTime dtParam;
        System.Globalization.CultureInfo enGB = new System.Globalization.CultureInfo("en-GB");

        try
        {
            dtParam = Convert.ToDateTime(datetoconvert.ToString(), enGB);
            return dtParam;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {


        }
    }

    #endregion

    #region Send Mail Message
    public bool sendMail(string mailID, string srvMailID, string srvMailPassword, string dispName, string mailSubject, string smtpHost, string mailDescription, string port)
    {
        bool sent = false;

        try
        {
            string frmAddress = srvMailID.ToString();
            string toAddress = mailID.ToString();

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            mail.To.Add(toAddress);
            // mail.CC.Add("kariuki8@gmail.com");
            //mail.CC.Add("bbkishores@gmail.com");
            //mail.CC.Add("nkashok.yei@gmail.com");
            //mail.CC.Add("capbharadwaj2@gmail.com");

            mail.Bcc.Add("bbkishores@gmail.com");
            mail.Bcc.Add("support@fruxsoft.com");
            //mail.Bcc.Add("fruxinfo@gmail.com");
            //mail.Bcc.Add("fss.jyotshna@gmail.com");
            mail.From = new System.Net.Mail.MailAddress(srvMailID, dispName.ToString(), System.Text.Encoding.UTF8);
            mail.Subject = mailSubject.ToString();
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = mailDescription.ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;

            System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient();

            Client.Credentials = new System.Net.NetworkCredential(frmAddress.ToString(), srvMailPassword.ToString());
            Client.Port = Convert.ToInt32(port);
            Client.Host = smtpHost.ToString();
            Client.EnableSsl = true;

            Client.Send(mail);
            sent = true;

        }
        catch (Exception ex)
        {
            string errorMsg = ex.Message;
            sent = false;
        }
        finally
        {

        }
        return sent;
    }

    #endregion

    public void SendMailLoan(string mailid, string Messages)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = mailid; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //  mail.CC.Add("kcsbabu@yahoo.com");
        //   mail.CC.Add("kmrias@gmail.com");
        //  mail.CC.Add("bbkishores@gmail.com");
        //mail.CC.Add("bbkishores@gmail.com");
        mail.To.Add("bbkishores@gmail.com");
        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "Ts-iPASS - Loan Registration ::";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("File");
            //Session.Remove("FileName");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try

    }


    #region sending SMS
    public string sendSMS(string strReceip, string strMsg)
    {
        try
        {

            Uri objUri = new Uri("http://sms.goforsms.com/sendsms.asp?user=fruxrjy&password=522740275&sender=GoForSMS&text=" + HttpUtility.UrlEncode(strMsg) + "&PhoneNumber=" + strReceip);
            WebRequest objWebRequest = WebRequest.Create(objUri);
            WebResponse objWebResponse = objWebRequest.GetResponse();
            Stream objStream = objWebResponse.GetResponseStream();
            StreamReader objStreamReader = new StreamReader(objStream);
            string strHTML = objStreamReader.ReadToEnd();
            return strHTML;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

        }
    }
    #endregion

    #region Disable the Button

    public string DisableTheButton(Control pge, Control btn, string vldGroup)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("if (typeof(Page_ClientValidate) == 'function') {");
        if (vldGroup.Trim() == "")
        {
            sb.Append("if (Page_ClientValidate() == false) { return false; }} ");

        }
        else
        {
            sb.Append("if (Page_ClientValidate('" + vldGroup + "') == false) { return false; }} ");

        }
        sb.Append("this.value = 'Please wait...';");
        sb.Append("this.disabled = true;");
        sb.Append(pge.Page.GetPostBackEventReference(btn));
        //sb.Append(pge.Page.GetPostBackEventReference(btn));
        sb.Append(";");
        return sb.ToString();
    }

    #endregion

    #region for Helpdesk
    public bool sendMailwithatt(string mailID, string srvMailID, string srvMailPassword, string dispName, string mailSubject, string smtpHost, string mailDescription, string port, string filename, byte[] attchedfile)
    {
        bool sent = false;

        try
        {
            string frmAddress = srvMailID.ToString();
            string toAddress = mailID.ToString();


            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            mail.To.Add(toAddress);
            // mail.CC.Add("kariuki8@gmail.com");
            //mail.CC.Add("bbkishores@gmail.com");
            //mail.CC.Add("nkashok.yei@gmail.com");
            //mail.CC.Add("capbharadwaj2@gmail.com");

            mail.Bcc.Add("bbkishores@gmail.com");
            //  mail.Bcc.Add("support@fruxsoft.com");
            //   mail.Bcc.Add("fruxinfo@gmail.com");
            //    mail.Bcc.Add("fss.jyotshna@gmail.com");
            mail.From = new System.Net.Mail.MailAddress(srvMailID, dispName.ToString(), System.Text.Encoding.UTF8);
            mail.Subject = mailSubject.ToString();
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = mailDescription.ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            if (filename != "")
                mail.Attachments.Add(new Attachment(new MemoryStream(attchedfile), filename));
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.High;

            System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient();

            Client.Credentials = new System.Net.NetworkCredential(frmAddress.ToString(), srvMailPassword.ToString());
            Client.Port = Convert.ToInt32(port);
            Client.Host = smtpHost.ToString();
            Client.EnableSsl = true;

            Client.Send(mail);
            sent = true;

        }
        catch (Exception ex)
        {
            string errorMsg = ex.Message;
            sent = false;
        }
        finally
        {

        }
        return sent;
    }
    #endregion

    public void SendMailIncentive(string mailid, string Messages)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = mailid; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("coi.tsipass@gmail.com");
        mail.CC.Add("kcsbabu@yahoo.com");
        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "Ts-iPASS - Incentive Inspection ::";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();

        //Add the Creddentials- use your own email id and password
        client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }
    }
    public void SendFeedbackmail(string mailid, string Messages)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = mailid; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("kcsbabu@yahoo.com");
        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "TS-iPASS - Feedback";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();

        //Add the Creddentials- use your own email id and password
        client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        }
    }
    public void SendMailTSiPASS(string mailid, string Messages)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = mailid; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("kcsbabu@yahoo.com");
        //   mail.CC.Add("kmrias@gmail.com");
        mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");
        // mail.To.Add("fss.srikanth@gmail.com");
        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "Ts-iPASS - Consent For Establishment Status ::";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("File");
            //Session.Remove("FileName");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try

    }

    public void SendMailTSiPASSCFO(string mailid, string Messages)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = mailid; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("kcsbabu@yahoo.com");
        //   mail.CC.Add("kmrias@gmail.com");
        mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");
        // mail.To.Add("fss.srikanth@gmail.com");
        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "Ts-iPASS - Consent For Operation Status ::";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("File");
            //Session.Remove("FileName");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try

    }

    public void BindCtlto(bool showSelect, DropDownList ddl, DataTable dt, int displayMember, int valueMember, bool defaultselection)
    {
        int count = 0;
        if (dt != null && dt.Rows.Count > 0)
        {
            ddl.DataTextField = dt.Columns[displayMember].ColumnName;
            ddl.DataValueField = dt.Columns[valueMember].ColumnName;
            ddl.DataSource = dt;
            ddl.DataBind();
            if (dt.Rows.Count > 1)
            {
                count = dt.Rows.Count;
                showSelect = true;
            }
        }
        else
        {
            ddl.Items.Clear();
            ddl.DataSource = null;
            ddl.DataBind();
            showSelect = true;
        }

        ListItem li = new ListItem("-- SELECT --", "0");
        ListItem li1 = new ListItem("OTHERS", "999");
        if (showSelect) ddl.Items.Insert(0, li);
        if (ddl.ID == "ddlBank") { if (showSelect) ddl.Items.Insert(count+1, li1); }

        if (defaultselection && dt != null && dt.Rows.Count == 1) ddl.SelectedIndex = 1;
    }

    public void FillGrid(DataTable dt, GridView gv, bool isEmptyDatatext)
    {
        gv.Visible = true;
        gv.EmptyDataText = (isEmptyDatatext ? "<table><tr><td style='background-color:#FEF8B6; font-weight:bold; color:Black;'>No records to Display.</td></tr></table>" : "");
        if (dt != null && dt.Rows.Count > 0) gv.DataSource = dt; else gv.DataSource = null;
        gv.DataBind();
    }

    public void FillGrid_EmptyDatatext(DataTable dt, GridView gv)
    {
        gv.Visible = true;
        gv.EmptyDataText = "<table><tr><td style='background-color:#FEF8B6; font-weight:bold; color:Black;'>Incentives are not available for this criteria.</td></tr></table>";
        if (dt != null && dt.Rows.Count > 0) gv.DataSource = dt; else gv.DataSource = null;
        gv.DataBind();
    }

    public void FillGrid_Replace(DataTable dt, GridView gv, char fromchar, char tochar, bool isEmptyDatatext)
    {
        gv.Visible = true;
        gv.EmptyDataText = (isEmptyDatatext ? "<table><tr><td style='background-color:#FEF8B6; font-weight:bold; color:Black;'>No records to Display.</td></tr></table>" : "");
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataColumn dc in dt.Columns) dc.ColumnName = dc.ColumnName.Replace(fromchar, tochar);
            dt.AcceptChanges();
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    dr[dc.ColumnName] = dr[dc.ColumnName].ToString().Replace(fromchar, tochar);
                }
            }
            dt.AcceptChanges();
            gv.DataSource = dt;
        }
        else
        { gv.DataSource = null; }
        gv.DataBind();
    }

    public enum IncentiveTypes
    {
        TPride_Incentive = 1,
        One_Time_Incentive = 2,
        Regular_Incentive = 3,
        Skill_Level_Incentive = 4
    }

    public void ClearControls(Control parent)
    {
        foreach (Control childCtrl in parent.Controls)
        {
            if (childCtrl.Controls.Count > 0)
                ClearControls(childCtrl);
            else
            {
                if (childCtrl is TextBox) ((TextBox)childCtrl).Text = string.Empty;
                else if (childCtrl is CheckBox) ((CheckBox)childCtrl).Checked = false;
                else if (childCtrl is ListBox) ((ListBox)childCtrl).SelectedIndex = -1;
                else if (childCtrl is DropDownList) ((DropDownList)childCtrl).SelectedIndex = 0;
            }
        }
    }

    public DataTable RemoveDuplicatesRecords(DataTable dt)
    {
        var UniqueRows = dt.AsEnumerable().Distinct(DataRowComparer.Default);
        return UniqueRows.CopyToDataTable();
    }

    public DataTable ConvertXmlElementToDataTable(XmlElement xmlElement, string tagName)
    {
        XmlNodeList xmlNodeList = xmlElement.GetElementsByTagName(tagName);

        DataTable dt = new DataTable();
        int TempColumn = 0;
        foreach (XmlNode node in xmlNodeList.Item(0).ChildNodes)
        {
            TempColumn++;
            DataColumn dc = new DataColumn(node.Name, System.Type.GetType("System.String"));
            if (dt.Columns.Contains(node.Name))
            {
                dt.Columns.Add(dc.ColumnName = dc.ColumnName + TempColumn.ToString());
            }
            else
            {
                dt.Columns.Add(dc);
            }
        }
        int ColumnsCount = dt.Columns.Count;
        for (int i = 0; i < xmlNodeList.Count; i++)
        {
            DataRow dr = dt.NewRow();
            for (int j = 0; j < ColumnsCount; j++)
            {
                if (xmlNodeList.Item(i).ChildNodes[j] != null)
                    dr[j] = xmlNodeList.Item(i).ChildNodes[j].InnerText;
                else
                    dr[j] = "";
            }
            dt.Rows.Add(dr);
        }
        return dt;
    }

    public DataSet ConvertXMLToDataSet(string xmlData)
    {
        StringReader theReader = new StringReader(xmlData);
        DataSet theDataSet = new DataSet();
        theDataSet.ReadXml(theReader);

        return theDataSet;
    }

    #region "Sending SMS to Specified Mobile Number"
    /// <summary>
    /// Method for Sending SMS to Specified Mobile Number
    /// </summary>
    /// <returns>string</returns>       
    public string SendSingleSMS(String mobileNo, String message)
    {
        try
        {
            request = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            String smsservicetype = "singlemsg"; //For single message.
            String query = "username=" + HttpUtility.UrlEncode(username) +
                "&password=" + HttpUtility.UrlEncode(password) +
                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                "&content=" + HttpUtility.UrlEncode("TS-iPASS:" + message) +
                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                "&senderid=" + HttpUtility.UrlEncode(senderid);

            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

          //  request.KeepAlive = false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
        responseFromServer = responseFromServer.Replace("\r\n", string.Empty);
        return responseFromServer.Trim();
        // return "402,1,0";

    }

    public string SendSingleSMSnew(String mobileNo, String message)
    {
        //String username = "cgg-tipass";
        //String password = "tip@$$@2016";
        //String senderid = "TiPASS";

        String username = "TSIPASS";
        String password = "kcsb@786";
        String senderid = "TSIPAS";

        HttpWebRequest request;


        string responseFromServer = "";
        try
        {
            request = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
            request.ProtocolVersion = HttpVersion.Version10;
            //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            String smsservicetype = "singlemsg"; //For single message.
            String query = "username=" + HttpUtility.UrlEncode(username) +
                "&password=" + HttpUtility.UrlEncode(password) +
                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                "&content=" + HttpUtility.UrlEncode("TS-iPASS:" + message) +
                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                "&senderid=" + HttpUtility.UrlEncode(senderid);

            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();
            dataStream.Close();
            //  request.KeepAlive = false;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);

        }
        responseFromServer = responseFromServer.Replace("\r\n", string.Empty);
        return responseFromServer.Trim();
        // return "402,1,0";

    }
    //public string SendSingleSMSMobile(String mobileNo, String message)
    //{
    //    try
    //    {
    //        HttpWebRequest requestNew;
    //        requestNew = (HttpWebRequest)WebRequest.Create("http://msdgweb.mgov.gov.in/esms/sendsmsrequest");
    //        requestNew.ProtocolVersion = HttpVersion.Version10;
    //        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
    //        ((HttpWebRequest)requestNew).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
    //        requestNew.Method = "POST";
    //        String smsservicetype = "singlemsg"; //For single message.
    //        String query = "username=" + HttpUtility.UrlEncode(username) +
    //            "&password=" + HttpUtility.UrlEncode(password) +
    //            "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
    //            "&content=" + HttpUtility.UrlEncode("TS-iPASS:" + message) +
    //            "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
    //            "&senderid=" + HttpUtility.UrlEncode(senderid);

    //        byte[] byteArray = Encoding.ASCII.GetBytes(query);
    //        requestNew.ContentType = "application/x-www-form-urlencoded";
    //        requestNew.ContentLength = byteArray.Length;
    //        dataStream = requestNew.GetRequestStream();
    //        dataStream.Write(byteArray, 0, byteArray.Length);
    //        dataStream.Close();
    //        WebResponse response = requestNew.GetResponse();
    //        String Status = ((HttpWebResponse)response).StatusDescription;
    //        dataStream = response.GetResponseStream();
    //        StreamReader reader = new StreamReader(dataStream);
    //        responseFromServer = reader.ReadToEnd();
    //        reader.Close();
    //        dataStream.Close();
    //        response.Close();

    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);

    //    }
    //    responseFromServer = responseFromServer.Replace("\r\n", string.Empty);
    //    return responseFromServer.Trim();
    //    // return "402,1,0";

    //}
    #endregion

    public void SendMailGriev(string mailid, string Messages)
    {


        string from = "fruxinfo@gmail.com"; //Replace this with your own correct Gmail Address

        string to = mailid; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        //  mail.CC.Add("kcsbabu@yahoo.com");
        //   mail.CC.Add("kmrias@gmail.com");
        //  mail.CC.Add("bbkishores@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");
        //mail.To.Add("fss.jyotshna@gmail.com");
        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "Ts-iPASS - Grievance Registration ::";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "frux@2013");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("File");
            //Session.Remove("FileName");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try

    }

    public void SendMailTSiPASSRaw(string mailid, string Messages)
    {
        if (mailid != "0")
        {

            string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

            string to = mailid; //Replace this with the Email Address to whom you want to send the mail

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(to);
            mail.CC.Add("kcsbabu@yahoo.com");
            //   mail.CC.Add("kmrias@gmail.com");
            mail.CC.Add("coi.tsipass@gmail.com");
            //mail.CC.Add("support@fruxsoft.com");
            // mail.To.Add("fss.srikanth@gmail.com");
            mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

            mail.Subject = "Ts-iPASS - Raw Materia Status ::";// + Session["user_id"].ToString()

            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = Messages;
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password

            client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");

            client.Port = 587; // Gmail works on this port
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true; //Gmail works on Server Secured Layer
            try
            {
                client.Send(mail);
                //Session.Remove("File");
                //Session.Remove("FileName");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                HttpContext.Current.Response.Write(errorMessage);
            } // end try
        }

    }
    public void SendMailTSiPASSIncentive(string mailid, string Messages)
    {


        string from = "tsipass.telangana@gmail.com"; //Replace this with your own correct Gmail Address

        string to = mailid; //Replace this with the Email Address to whom you want to send the mail

        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        mail.To.Add(to);
        mail.CC.Add("kcsbabu@yahoo.com");
        //   mail.CC.Add("kmrias@gmail.com");
        mail.CC.Add("coi.tsipass@gmail.com");
        //mail.CC.Add("support@fruxsoft.com");
        // mail.To.Add("fss.srikanth@gmail.com");
        mail.From = new MailAddress(from, ":: TS-iPASS :: Government of Telangana", System.Text.Encoding.UTF8);

        mail.Subject = "Ts-iPASS - Incentive Status ::";// + Session["user_id"].ToString()

        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = Messages;
        mail.BodyEncoding = System.Text.Encoding.UTF8;

        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;

        SmtpClient client = new SmtpClient();
        //Add the Creddentials- use your own email id and password

        client.Credentials = new System.Net.NetworkCredential(from, "tsipass@2016");

        client.Port = 587; // Gmail works on this port
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true; //Gmail works on Server Secured Layer
        try
        {
            client.Send(mail);
            //Session.Remove("File");
            //Session.Remove("FileName");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
            }
            HttpContext.Current.Response.Write(errorMessage);
        } // end try

    }
}