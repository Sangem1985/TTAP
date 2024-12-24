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

namespace TTAP.UI.Pages.SLC
{
    public partial class FormIssueSanctionLetter : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["IncId"] != null)
                    {
                        string IncId = Request.QueryString["IncId"].ToString();
                        string SubIncId = Request.QueryString["SubIncId"].ToString();
                        string TISId = Request.QueryString["TISId"].ToString();
                        string IsPartial = Request.QueryString["IsPartial"].ToString();
                        GetData(IncId, SubIncId, TISId, IsPartial);
                    }
                }       
            }
        }
        public void GetData(string IncId,string SubIncId,string TISId,string IsPartial)
        {
            DataSet ds = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@IncentiveID",SqlDbType.VarChar),
                new SqlParameter("@SubIncId", SqlDbType.VarChar),
                new SqlParameter("@TISId", SqlDbType.VarChar),
                new SqlParameter("@PartialSanction", SqlDbType.VarChar)
            };

            pp[0].Value = IncId;
            pp[1].Value = SubIncId;
            pp[2].Value = TISId;
            pp[3].Value = IsPartial;
            ds = ObjCAFClass.GenericFillDs("USP_GET_PENDING_FOR_ISSUE_SANCTION_LETTERS_BY_ID", pp);

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

        protected void btnSanctionLetter_Click(object sender, EventArgs e)
        {
            ClsFileUpload objClsFileUpload = new ClsFileUpload();
            if (fuSanctionLetter.HasFile)
            {
                string IncentiveId = "", SubIncentiveID = "", MeetingNo = "", Meeting_Date = "";
                foreach (GridViewRow gvrow in gvdetailsnew.Rows)
                {
                    Label lblIncentiveID = ((Label)(gvrow.FindControl("lblIncentiveID")));
                    Label lblSubIncentiveID = ((Label)(gvrow.FindControl("lblSubIncentiveID")));
                    Label lblTISId = ((Label)(gvrow.FindControl("lblTISId")));
                    Label lblMeeting_No = ((Label)(gvrow.FindControl("lblMeeting_No")));
                    Label lblActual_Meeting_Date = ((Label)(gvrow.FindControl("lblActual_Meeting_Date")));
                    IncentiveId = lblIncentiveID.Text.Trim();
                    SubIncentiveID = lblSubIncentiveID.Text.Trim();
                    MeetingNo = lblMeeting_No.Text.Trim();
                    Meeting_Date = GetFromatedDateDDMMYYYY(lblActual_Meeting_Date.Text.Trim());
                }
                string Mimetype = objClsFileUpload.getmimetype(fuSanctionLetter);
                if (Mimetype == "application/pdf")
                {
                    string Investmentid = Request.QueryString[1].ToString();
                    string Filesavepath = "~";// ConfigurationManager.AppSettings["IncentiveUploads"].ToString();
                    Filesavepath = Filesavepath + "\\SLCSanctionOrder";

                    string ServerFlag = "N";//ConfigurationManager.AppSettings["FTPFlag"].ToString();
                    string FilesavepathNew = Filesavepath;
                    if (ServerFlag == "N")
                    {
                        FilesavepathNew = Server.MapPath(Filesavepath);
                    }
                    string SanctionLetter_SavedFileLocation = "";

                    string OutPut = objClsFileUpload.IncentiveSanctionLetterFileUploading(Filesavepath, FilesavepathNew, fuSanctionLetter, lblSanctionLetter, "SLCSanctionOrder", IncentiveId, SubIncentiveID, "911131", Session["uid"].ToString(), "JD", MeetingNo, Meeting_Date, out SanctionLetter_SavedFileLocation);
                    lbtnSanctionLetterDelete.Visible = true;
                    ViewState["SanctionLetter_SavedFileLocation"] = SanctionLetter_SavedFileLocation;
                    hdnFilePath.Value = SanctionLetter_SavedFileLocation;
                    if (OutPut == "1")
                    {
                        string message = "alert('Attachment Uploaded')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string message = "alert('Please Select only pdf file')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
        }
        public string GetFromatedDateDDMMYYYY(string Date)
        {
            string Dateformat = "";
            string[] Ld6 = null;
            string ConvertedDt56 = "";
            if (Date != "")
            {
                Ld6 = Date.Split('/');
                ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                Dateformat = ConvertedDt56;
            }
            else
            {
                Dateformat = null;
            }
            return Dateformat;
        }

        protected void lbtnSanctionLetterDelete_Click(object sender, EventArgs e)
        {
            lblSanctionLetter.NavigateUrl = "";
            lblSanctionLetter.Text = "";
            lbtnSanctionLetterDelete.Visible = false;
            ViewState["SanctionLetter_SavedFileLocation"] = "";
            hdnFilePath.Value = "";
            MessageBox("Attachment Deleted Successfully..!");
        }

        protected void rbtnStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnStatus.SelectedValue == "U")
            {
                divFileUpload.Visible = true;
            }
            else
            {
                divFileUpload.Visible = false;
            }
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtremarks.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Remarks');", true);
                return;
            }
            if (rbtnStatus.SelectedValue == "U")
            {
                if (hdnFilePath.Value == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Upload Sanction Letter');", true);
                    return;
                }
            }
            string IncentiveId = "", SubIncentiveID = "", MeetingNo = "", Meeting_Date = "", TISId = "";
            string IsPartial = Request.QueryString["IsPartial"].ToString();
            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
            {
                Label lblIncentiveID = ((Label)(gvrow.FindControl("lblIncentiveID")));
                Label lblSubIncentiveID = ((Label)(gvrow.FindControl("lblSubIncentiveID")));
                Label lblTISId = ((Label)(gvrow.FindControl("lblTISId")));
                Label lblMeeting_No = ((Label)(gvrow.FindControl("lblMeeting_No")));
                Label lblActual_Meeting_Date = ((Label)(gvrow.FindControl("lblActual_Meeting_Date")));
                IncentiveId = lblIncentiveID.Text.Trim();
                SubIncentiveID = lblSubIncentiveID.Text.Trim();
                TISId = lblTISId.Text.Trim();
                MeetingNo = lblMeeting_No.Text.Trim();
                Meeting_Date = lblActual_Meeting_Date.Text.Trim();
            }
            string SanctionStatus = rbtnStatus.SelectedValue;string IsFileUpload = "N";
            if (rbtnStatus.SelectedValue == "U") { SanctionStatus = "S"; IsFileUpload = "Y";}
            string Remarks = txtremarks.Text;
            string Status = ObjCAFClass.UpdateSanctionStatus(IncentiveId, SubIncentiveID, SanctionStatus, TISId, Remarks, IsPartial,IsFileUpload, hdnFilePath.Value);

            if (Status != "0" || Status != null || Status != "")
            {
                string msg = ""; string SubModule = ""; string TransactionId = "";
                if (rbtnStatus.SelectedValue == "S" || rbtnStatus.SelectedValue == "U") { SubModule = "SANCTIONISSUED"; TransactionId = "15"; }
                if (rbtnStatus.SelectedValue == "R") { SubModule = "SANCTIONREJECTED"; TransactionId = "16"; }
                try
                {
                    ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                    msg = ClsSMSandMailobj.SendSmsWebService(IncentiveId, SubIncentiveID, "Incentives", TransactionId, SubModule);
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                }
                if (rbtnStatus.SelectedValue == "S" || rbtnStatus.SelectedValue == "U")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sanction Letter Issued Successfully');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sanction Letter Rejected');", true);
                }
                btnProcess.Enabled = false;
            }
        }
    }
}