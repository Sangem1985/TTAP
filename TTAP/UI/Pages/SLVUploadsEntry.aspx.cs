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
    public partial class SLVUploadsEntry : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        private SqlConnection ConNew = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        Fetch objFetch = new Fetch();
        General Objgeneral = new General();
        comFunctions cmf = new comFunctions();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        string UID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ObjLoginvo"] != null)
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                UID = ObjLoginNewvo.uid;

                if (!IsPostBack)
                {
                    GetUnits();
                    GetSubIncentives();
                    if (Request.QueryString["SlcNo"] != null)
                    {
                        txtSlcDate.Text = Request.QueryString["Date"];
                        BindSlcDetails(Request.QueryString["SlcNo"]);
                    }
                    txtSlcNo.Text = Request.QueryString["SlcNo"];
                    txtSlcNo.Enabled = false;
                    GetSVSLCAttachements(Request.QueryString["SlcNo"]);
                    if (Request.QueryString.Count > 1)
                    {
                        if (Request.QueryString["Type"] == "V")
                        {
                            divDtls.Visible = false;
                            gvGridSlc.Columns[13].Visible = false;
                            gvGridSlc.Columns[14].Visible = false;
                            fuSVSLCMins.Enabled = false;
                            fuSVSLCAgenda.Enabled = false;
                            fuSLCAgenda.Enabled = false;
                            fuSLCMins.Enabled = false;
                            btnSVSLCAgendaUploads.Enabled = false;
                            btnSVSLCMinsUpload.Enabled = false;
                            btnSLCAgendaUpload.Enabled = false;
                            btnSLCMinsUpload.Enabled = false;
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("~/LoginReg.aspx");
            }
        }
        public void GetUnits()
        {
            dss = GetUnitsList();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                ddlUnits.DataSource = dss;
                ddlUnits.DataTextField = "Unit_Name";
                ddlUnits.DataValueField = "UnitCode";
                ddlUnits.DataBind();
                ddlUnits.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlUnits.Items.Insert(0, "--Select--");
            }
        }
        public void ClearFields()
        {
            ViewState["SlcSubId"] = "0";
            hdnSubSlcId.Value = "0";
            ddlUnits.SelectedIndex = 0;
            ddlIncentive.SelectedIndex = 0;
            txtFromDate.Text = "";
            txtToDate.Text = "";
            txtSanctionedDate.Text = "";
            txtHalf.Text = "";
            txtDloAmount.Text = "";
            txtTextileAmount.Text = "";
            txtIndustriesAmount.Text = "";
            txtSLCAmopunt.Text = "";
            txtReleasedAmount.Text = "";
            txtReleasedDt.Text = "";
            txtLetterNo.Text = "";
        }
        public void GetSubIncentives()
        {
            dss = GetIncentives();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                ddlIncentive.DataSource = dss;
                ddlIncentive.DataTextField = "IncentiveName";
                ddlIncentive.DataValueField = "IncentiveID";
                ddlIncentive.DataBind();
                ddlIncentive.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlIncentive.Items.Insert(0, "--Select--");
            }
        }
        public DataSet GetUnitsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("USP_Get_TTAPUnits");
            return Dsnew;
        }
        public DataSet GetIncentives()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES");
            return Dsnew;
        }
        protected void gvGridSlc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowDelete")
            {
                GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                string SlcId = ((Label)(gr.FindControl("lblSlcId"))).Text;
                string SubSlcId = ((Label)(gr.FindControl("lblSlcSubId"))).Text;
                string Validstatus = DeleteSlcDetails(SubSlcId);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {   
                    BindSlcDetails(txtSlcNo.Text.Trim());
                }
                else
                {   
                    BindSlcDetails(txtSlcNo.Text.Trim());
                }

            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnits.SelectedIndex == 0) {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Unit');", true);
                    return;
                }
                if (ddlIncentive.SelectedIndex == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Incentive');", true);
                    return;
                }
                if (ddlIncentive.SelectedValue != "1" || ddlIncentive.SelectedValue != "19")
                {
                    if (txtFromDate.Text == "")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Period From Date');", true);
                        return;
                    }
                    if (txtToDate.Text == "")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Period To Date');", true);
                        return;
                    }
                }
                if (txtHalf.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Description');", true);
                    return;
                }
                /* if (txtDloAmount.Text == "")
                 {
                     ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter DLO Recommended Amount');", true);
                     return;
                 }*/
                if (txtTextileAmount.Text == "" || txtTextileAmount.Text == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Textile Dept Recommended Amount');", true);
                    return;
                }
                if (txtSLCAmopunt.Text == "" || txtSLCAmopunt.Text == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter SLC Approved Amount');", true);
                    return;
                }
                /* (txtSanctionedDate.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Select Sanctioned Date');", true);
                    return;
                }*/
                int SlcNo = Convert.ToInt32(txtSlcNo.Text.Trim());
                int SubSlcId = Convert.ToInt32(hdnSubSlcId.Value.ToString());
                string SlcDate = txtSlcDate.Text;
                string Year = null;
                string Half = null;
                string UnitId = ddlUnits.SelectedValue;
                int IncentiveId = Convert.ToInt32(ddlIncentive.SelectedValue);
                string PeriodFrom = txtFromDate.Text;
                string PeriodTo = txtToDate.Text;
                string Description = txtHalf.Text;
                string DLORecommendedAmount = txtDloAmount.Text;
                string TextileDeptAmount = txtTextileAmount.Text;
                string IndustriesDeptAmount = txtIndustriesAmount.Text;
                string SLCApprovedAmount = txtSLCAmopunt.Text;
                string SancationedDate = txtSanctionedDate.Text;

                string ReleasedAmount = txtReleasedAmount.Text;
                string ReleasedDate = txtReleasedDt.Text;
                string LetterNo = txtLetterNo.Text;

                if (txtFromDate.Text != "")
                {
                    string[] PeriodFromdate = txtFromDate.Text.Trim().Split('/');
                    PeriodFrom = PeriodFromdate[0] + "-" + PeriodFromdate[1] + "-" + PeriodFromdate[2];
                }
                if (txtToDate.Text != "")
                {
                    string[] PeriodTodate = txtToDate.Text.Trim().Split('/');
                    PeriodTo = PeriodTodate[0] + "-" + PeriodTodate[1] + "-" + PeriodTodate[2];
                }

                if (txtSanctionedDate.Text != "")
                {
                    string[] SancationedDatedate = txtSanctionedDate.Text.Trim().Split('/');
                    SancationedDate = SancationedDatedate[0] + "-" + SancationedDatedate[1] + "-" + SancationedDatedate[2];
                }
                if (txtReleasedDt.Text != "")
                {
                    string[] ReleasedDatedate = txtReleasedDt.Text.Trim().Split('/');
                    ReleasedDate = ReleasedDatedate[0] + "-" + ReleasedDatedate[1] + "-" + ReleasedDatedate[2];
                }

                string TransType = "INS";
                if (SubSlcId != 0) { TransType = "UPD"; }

                string Validstatus =InsertSlcDetails(SlcNo,SlcDate, Year, Half, UnitId, IncentiveId, PeriodFrom, PeriodTo, Description, DLORecommendedAmount, SLCApprovedAmount, SancationedDate, TextileDeptAmount, IndustriesDeptAmount,
                    ReleasedAmount, ReleasedDate,LetterNo, SubSlcId, TransType);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Saved successfully');", true);
                    BindSlcDetails(txtSlcNo.Text.Trim());
                    ClearFields();
                    hdnSubSlcId.Value = "0";
                    ViewState["SlcSubId"] = "0";
                    btnAdd.Text = "Add";
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Failed');", true);
                    BindSlcDetails(txtSlcNo.Text.Trim());
                    ClearFields();
                    hdnSubSlcId.Value = "0";
                    ViewState["SlcSubId"] = "0";
                    btnAdd.Text = "Add";
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public string InsertSlcDetails(int SlcNo,string SlcDate, string Year, string Half, string UnitId,int IncentiveId, string PeriodFrom, string PeriodTo, string Description, string DLORecommendedAmount, string SLCApprovedAmount, string SancationedDate, string TextileDeptAmount, string IndustriesDeptAmount,
           string ReleasedAmount, string ReleasedDate, string LetterNo,int SubSlcId,string TransType)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_Slc_Entry";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@SlcNo", SlcNo);
                com.Parameters.AddWithValue("@SubSlcId", SubSlcId);
                com.Parameters.AddWithValue("@SlcDate", SlcDate);
                com.Parameters.AddWithValue("@Year", Year);
                com.Parameters.AddWithValue("@Half", Half);
                com.Parameters.AddWithValue("@UnitId", UnitId);
                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@PeriodFrom", PeriodFrom);
                com.Parameters.AddWithValue("@PeriodTo", PeriodTo);
                com.Parameters.AddWithValue("@Description", Description);
                com.Parameters.AddWithValue("@DLORecommendedAmount", DLORecommendedAmount);
                com.Parameters.AddWithValue("@TextileDeptAmount", TextileDeptAmount);
                com.Parameters.AddWithValue("@IndustriesDeptAmount", IndustriesDeptAmount);
                com.Parameters.AddWithValue("@SLCApprovedAmount", SLCApprovedAmount);
                com.Parameters.AddWithValue("@SancationedDate", SancationedDate);
                com.Parameters.AddWithValue("@ReleasedAmount", ReleasedAmount);
                com.Parameters.AddWithValue("@ReleasedDate", ReleasedDate);
                com.Parameters.AddWithValue("@LetterNo", LetterNo);
                com.Parameters.AddWithValue("@TransType", TransType);
                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }

        public string DeleteSlcDetails(string SubSlcId)
        {
            string valid = "";
            int SlcSubId = Convert.ToInt32(SubSlcId);
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_Slc_Entry";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@SubSlcId", SlcSubId);
                com.Parameters.AddWithValue("@TransType", "DEL");

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button btnEdits = (Button)sender;
            GridViewRow row = (GridViewRow)btnEdits.NamingContainer;
            Label lblSlcId = (Label)row.FindControl("lblSlcId");
            Label lblSlcSubId = (Label)row.FindControl("lblSlcSubId");
            Button btnEdit = (Button)row.FindControl("btnEdit");

            EditDetails(Convert.ToInt32(txtSlcNo.Text.ToString()), Convert.ToInt32(lblSlcSubId.Text));

            btnAdd.Text = "Update";
        }
        public void EditDetails(int SlcNo, int SubSlcId)
        {
            DataSet ds = new DataSet();
            try
            {
                string PeriodFrom = "", PeriodTo = "", SancationedDate = "", ReleasedDate = "";
                ds = GetSlcDetailsEdit(SlcNo, SubSlcId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {   
                    ViewState["SlcNo"] = ds.Tables[0].Rows[0]["SlcNo"].ToString();
                    ViewState["SlcSubId"] = ds.Tables[0].Rows[0]["SlcSubId"].ToString();
                    hdnSubSlcId.Value= ds.Tables[0].Rows[0]["SlcSubId"].ToString();
                    ddlUnits.SelectedValue= ds.Tables[0].Rows[0]["UnitId"].ToString();
                    ddlIncentive.SelectedValue= ds.Tables[0].Rows[0]["SubIncentiveId"].ToString();
                    if (ds.Tables[0].Rows[0]["PeriodFromDate"].ToString() != "" && ds.Tables[0].Rows[0]["PeriodFromDate"].ToString() != null)
                    {
                        string[] PeriodFromdate = ds.Tables[0].Rows[0]["PeriodFromDate"].ToString().Trim().Split('-');
                        PeriodFrom = PeriodFromdate[0] + "/" + PeriodFromdate[1] + "/" + PeriodFromdate[2];
                    }
                    if (ds.Tables[0].Rows[0]["PeriodToDate"].ToString() != "" && ds.Tables[0].Rows[0]["PeriodToDate"].ToString() != null)
                    {
                        string[] PeriodTodate = ds.Tables[0].Rows[0]["PeriodToDate"].ToString().Trim().Split('-');
                        PeriodTo = PeriodTodate[0] + "/" + PeriodTodate[1] + "/" + PeriodTodate[2];
                    }
                    if (ds.Tables[0].Rows[0]["SanctionedDate"].ToString() != "" && ds.Tables[0].Rows[0]["SanctionedDate"].ToString() != null)
                    {
                        string[] SancationedDatedate = ds.Tables[0].Rows[0]["SanctionedDate"].ToString().Trim().Split('-');
                        SancationedDate = SancationedDatedate[0] + "/" + SancationedDatedate[1] + "/" + SancationedDatedate[2];
                    }
                    if (ds.Tables[0].Rows[0]["ReleasedDate"].ToString() != "" && ds.Tables[0].Rows[0]["ReleasedDate"].ToString() != null)
                    {
                        string[] ReleasedDatedate = ds.Tables[0].Rows[0]["ReleasedDate"].ToString().Trim().Split('-');
                        ReleasedDate = ReleasedDatedate[0] + "/" + ReleasedDatedate[1] + "/" + ReleasedDatedate[2];
                    }

                    txtFromDate.Text= PeriodFrom.ToString();
                    txtToDate.Text= PeriodTo.ToString();
                    txtSanctionedDate.Text = SancationedDate.ToString();
                    txtHalf.Text= ds.Tables[0].Rows[0]["Description"].ToString();
                    txtDloAmount.Text= ds.Tables[0].Rows[0]["Dlo_Recommended_Amount"].ToString();
                    txtTextileAmount.Text = ds.Tables[0].Rows[0]["TextileDeptAmount"].ToString();
                    txtIndustriesAmount.Text = ds.Tables[0].Rows[0]["IndustriesDeptAmount"].ToString();
                    txtSLCAmopunt.Text = ds.Tables[0].Rows[0]["Slc_Approved_Amount"].ToString();
                    txtReleasedAmount.Text = ds.Tables[0].Rows[0]["ReleasedAmount"].ToString();
                    txtReleasedDt.Text = ReleasedDate.ToString();
                    txtLetterNo.Text = ds.Tables[0].Rows[0]["LetterNo"].ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSlcDetailsEdit(int SlcNo, int SubSlcId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@SlcNo",SqlDbType.Int),
               new SqlParameter("@SubSlcId",SqlDbType.Int)
           };
            pp[0].Value = SlcNo;
            pp[1].Value = SubSlcId;
            Dsnew = caf.GenericFillDs("USP_Get_Slc_Unit_Details_Edit", pp);
            return Dsnew;
        }
        protected void BindSlcDetails(string SlcNo)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetSlcDetails(SlcNo);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    txtSlcDate.Text = dsnew.Tables[0].Rows[0]["SlcDate"].ToString();
                    gvGridSlc.DataSource = dsnew.Tables[0];
                    gvGridSlc.DataBind();
                }
                else
                {   
                    gvGridSlc.DataSource = null;
                    gvGridSlc.DataBind();
                    divData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet GetSlcDetails(string SlcNo)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@SlcNo",SqlDbType.VarChar)
           };
            pp[0].Value = SlcNo;
            Dsnew = caf.GenericFillDs("USP_Get_Slc_Unit_Details", pp);
            return Dsnew;
        }
        protected void btnSVSLCAgendaUploads_Click(object sender, EventArgs e)
        {
            string SLCNo = string.Empty;
            SLCNo = txtSlcNo.Text.ToString().Trim();

            if (fuSVSLCAgenda.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuSVSLCAgenda);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuSVSLCAgenda);
                if (Mimetype == "application/pdf")
                {   
                    string OutPut = objClsFileUpload.SlcFileUploading("~\\SLSVCUploads", Server.MapPath("~\\SLSVCUploads"), fuSVSLCAgenda, hySVSLCAgendaUpload, "SLCUploads", SLCNo, "1", UID, "USER", "SVSLCAgenda");
                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        hySVSLCAgendaUpload.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed !");
                }
            }
        }
        protected void btnSVSLCMinsUpload_Click(object sender, EventArgs e)
        {
            string SLCNo = string.Empty;
            SLCNo = txtSlcNo.Text.ToString().Trim();

            if (fuSVSLCMins.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuSVSLCMins);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuSVSLCMins);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.SlcFileUploading("~\\SLSVCUploads", Server.MapPath("~\\SLSVCUploads"), fuSVSLCMins, hySVSLCMinsUpload, "SLCUploads", SLCNo, "2", UID, "USER", "SVSLCMins");
                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        hySVSLCMinsUpload.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed !");
                }
            }
        }
        protected void btnSLCAgendaUpload_Click(object sender, EventArgs e)
        {
            string SLCNo = string.Empty;
            SLCNo = txtSlcNo.Text.ToString().Trim();

            if (fuSLCAgenda.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuSLCAgenda);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuSLCAgenda);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.SlcFileUploading("~\\SLSVCUploads", Server.MapPath("~\\SLSVCUploads"), fuSLCAgenda, hySLCAgendaUpload, "SLCUploads", SLCNo, "3", UID, "USER", "SLCAgenda");
                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        hySLCAgendaUpload.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed !");
                }
            }
        }
        protected void btnSLCMinsUpload_Click(object sender, EventArgs e)
        {
            string SLCNo = string.Empty;
            SLCNo = txtSlcNo.Text.ToString().Trim();

            if (fuSLCMins.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuSLCMins);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuSLCMins);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.SlcFileUploading("~\\SLSVCUploads", Server.MapPath("~\\SLSVCUploads"), fuSLCMins, hySLCMinsUpload, "SLCUploads", SLCNo, "4", UID, "USER", "SLCMins");
                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        hySLCMinsUpload.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed !");
                }
            }
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void GetSVSLCAttachements(string SlcNo)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@SLC_NO",SqlDbType.Int),
                new SqlParameter("@FLAG",SqlDbType.VarChar)
           };
            pp[0].Value = SlcNo;
            dsnew1 = caf.GenericFillDs("[USP_GET_SLC_AGENDA_MINS_DOCS]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string SVSLCAgenda_Path = dsnew1.Tables[0].Rows[0]["Svslc_Agenda_Path"].ToString();
                    string SVSLCMins_Path = dsnew1.Tables[0].Rows[0]["Svslc_Mins_Path"].ToString();
                    string SLCAgenda_Path = dsnew1.Tables[0].Rows[0]["Slc_Agenda_Path"].ToString();
                    string SLCMins_Path = dsnew1.Tables[0].Rows[0]["Slc_Mins_Path"].ToString();

                    objClsFileUpload.AssignPath(hySVSLCAgendaUpload, SVSLCAgenda_Path);
                    objClsFileUpload.AssignPath(hySVSLCMinsUpload, SVSLCMins_Path);
                    objClsFileUpload.AssignPath(hySLCAgendaUpload, SLCAgenda_Path);
                    objClsFileUpload.AssignPath(hySLCMinsUpload, SLCMins_Path);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void txtTextileAmount_TextChanged(object sender, EventArgs e)
        {
            int TextileAmount = 0, IndustriesAmount = 0;
            if (txtTextileAmount.Text != "") {
                TextileAmount = Convert.ToInt32(txtTextileAmount.Text.ToString());
            }
            if (txtIndustriesAmount.Text != "")
            {
                IndustriesAmount = Convert.ToInt32(txtIndustriesAmount.Text.ToString());
            }
            txtSLCAmopunt.Text = (TextileAmount + IndustriesAmount).ToString();
            hdnTotalAmount.Value = (TextileAmount + IndustriesAmount).ToString();
        }
    }
}