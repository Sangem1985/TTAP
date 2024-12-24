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

namespace TTAP.UI.Pages.Releases
{
    public partial class frmReleasesList : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("~/loginReg.aspx");
            }

            if (!IsPostBack)
            {
                string Stage = "";
                string ApplicationMode = "";
                string Category = "";
                string SubIncentiveID = "";
                string IncentiveID = "";
                string GOID = "";

                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["ApplicationMode"] != null)
                    {
                        ApplicationMode = Request.QueryString["ApplicationMode"].ToString();
                        if (ApplicationMode.ToUpper() == "1")
                        {
                            lblTypeofApplication.InnerText = "SLC";
                        }
                        else if (ApplicationMode.ToUpper() == "2")
                        {
                            lblTypeofApplication.InnerText = "DLC";
                        }
                        else
                        {
                            lblTypeofApplication.InnerText = "SLC & DLC";
                        }
                    }
                    if (Request.QueryString["Stage"] != null)
                    {
                        Stage = Request.QueryString["Stage"].ToString();
                    }
                    if (Request.QueryString["Category"] != null)
                    {
                        Category = Request.QueryString["Category"].ToString();
                    }
                    if (Request.QueryString["GOID"] != null)
                    {
                        GOID = Request.QueryString["GOID"].ToString();
                    }
                    if (Request.QueryString["SubIncentiveID"] != null)
                    {
                        SubIncentiveID = Request.QueryString["SubIncentiveID"].ToString();
                    }
                    if (Request.QueryString["IncentiveID"] != null)
                    {
                        IncentiveID = Request.QueryString["IncentiveID"].ToString();
                    }
                    DataSet dsg = new DataSet();
                    dsg = GetFundGos();
                    ViewState["dsgos"] = dsg;
                    if (dsg != null && dsg.Tables.Count > 0 && dsg.Tables[0].Rows.Count > 0)
                    {
                        ddlgos.DataSource = dsg.Tables[0];
                        ddlgos.DataValueField = "GOID";
                        ddlgos.DataTextField = "GONodate";
                        ddlgos.DataBind();
                        AddSelectNew(ddlgos);
                    }
                    DataSet ds = new DataSet();
                    ds = ObjCAFClass.GetReleaseList(Stage, ApplicationMode, Category, SubIncentiveID, GOID, IncentiveID);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        //tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
                        //h1heading.InnerHtml = ds.Tables[1].Rows[0]["SocialStatusText"].ToString() + " Category";
                        gvdetailsnew.DataSource = ds.Tables[0];
                        gvdetailsnew.DataBind();
                        trbalance.Visible = true;
                        trProcedinginfo.Visible = true;
                        trProcedingdoc.Visible = true;
                        btnSubmit.Visible = true;
                        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            lblIncentives.InnerHtml = ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
                            lblIncCategory.InnerHtml = ds.Tables[1].Rows[0]["SocialStatusText"].ToString();
                        }
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                        trbalance.Visible = false;
                        trProcedinginfo.Visible = false;
                        trProcedingdoc.Visible = false;
                    }
                }
                btnSubmit.Enabled = false;
            }
        }
        protected void btnDLCProceedings_Click(object sender, EventArgs e)
        {

            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (txtReleaseProcedingDate.Text.Trim() == null || txtReleaseProcedingDate.Text.Trim() == "")
            {
                string message = "alert('Please Select Release Proceeding Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            if (txtReleaseProcedingNo.Text.Trim().TrimStart() == null || txtReleaseProcedingNo.Text.Trim().TrimStart() == "")
            {
                string message = "alert('Please Enter Release Proceeding Number')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            ClsFileUpload objClsFileUpload = new ClsFileUpload();
            if (fuDLCProceedings.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuDLCProceedings);
                if (Mimetype == "application/pdf")
                {
                    string Investmentid = Request.QueryString[1].ToString();
                    string Filesavepath = "~";// ConfigurationManager.AppSettings["IncentiveUploads"].ToString();
                    Filesavepath = Filesavepath + "\\ReleaseProceedings";

                    string ServerFlag = "N";//ConfigurationManager.AppSettings["FTPFlag"].ToString();
                    string FilesavepathNew = Filesavepath;
                    if (ServerFlag == "N")
                    {
                        FilesavepathNew = Server.MapPath(Filesavepath);
                    }
                    string SavedFileLocation = "";
                    // string OutPut = objClsFileUpload.IncentiveCAFFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments1, lblUpload1, "CommCharteredEngineersArchitectsCertificate", Session["EntprIncentive"].ToString(), "53", "200053", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveProceedingsFileUploading(Filesavepath, FilesavepathNew, fuDLCProceedings, lblDLCProceedings, "ReleaseProceedings", "0", Investmentid, "911125", Session["uid"].ToString(), ObjLoginNewvo.Role_Code, txtReleaseProcedingNo.Text, GetFromatedDateDDMMYYYY(txtReleaseProcedingDate.Text.Trim()), out SavedFileLocation);
                    lbtnDLCProceedingsDelete.Visible = true;
                    ViewState["SavedFileLocation"] = SavedFileLocation;
                    if (OutPut == "1")
                    {

                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            fuDLCProceedings.Focus();
        }
        protected void lbtnDLCProceedingsDelete_Click(object sender, EventArgs e)
        {
            General Gen = new General();
            string Result = "";
            //Result = Gen.DeleteFilefromDB("0", "911125", Session["uid"].ToString());

            if (Result == "1")
            {
                lblDLCProceedings.NavigateUrl = "";
                lblDLCProceedings.Text = "";
                lbtnDLCProceedingsDelete.Visible = false;
                ViewState["SavedFileLocation"] = "";
                MessageBox("Attachment Deleted Successfully..!");
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
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ddlgos.SelectedValue == "0")
            {
                string message = "alert('Please Select Release GO')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                ddlgos.Focus();
                return;
            }
            if (txtReleaseProcedingDate.Text.Trim() == null || txtReleaseProcedingDate.Text.Trim() == "")
            {
                string message = "alert('Please Select Release Proceeding Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            if (txtReleaseProcedingNo.Text.Trim().TrimStart() == null || txtReleaseProcedingNo.Text.Trim().TrimStart() == "")
            {
                string message = "alert('Please Enter Release Proceeding Number')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            if (lblDLCProceedings.Text.Trim().TrimStart() == "")
            {
                string message = "alert('Please Upload Release Proceeding Copy')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            string valid = "0";
            List<ReleaseProceedingStatus> lstApplicationStatus = new List<ReleaseProceedingStatus>();
            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
            {
                CheckBox chkcheck = ((CheckBox)gvrow.FindControl("chkRow"));
                if (chkcheck.Checked == true)
                {
                    ReleaseProceedingStatus objApplicationStatus = new ReleaseProceedingStatus();
                    int rowIndex = gvrow.RowIndex;
                    objApplicationStatus.IncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                    objApplicationStatus.SubIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveID")).Text.ToString();
                    objApplicationStatus.ReleasedAmount = ((Label)gvrow.FindControl("lblAllotedAmount")).Text.Trim();
                    objApplicationStatus.ReleaseFlag = ((Label)gvrow.FindControl("lblReleaseFlag")).Text.Trim();

                    objApplicationStatus.FilePath = ViewState["SavedFileLocation"].ToString();

                    string[] datett = txtReleaseProcedingDate.Text.Trim().Split('/');
                    objApplicationStatus.ReleaseProcedingDate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    objApplicationStatus.ReleaseProcedingNo = txtReleaseProcedingNo.Text.Trim().TrimStart();
                    objApplicationStatus.GOID = ddlgos.SelectedValue.ToString();
                    objApplicationStatus.CreatedBy = Session["uid"].ToString();
                    objApplicationStatus.TransType = "UPDATE";
                    lstApplicationStatus.Add(objApplicationStatus);

                }
            }
            valid = ObjCAFClass.ReleaseProceedingsInsert(lstApplicationStatus);
            if (valid == "1")
            {
                btnSubmit.Enabled = false;
                string message = "alert('Application Details Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
        }

        protected void txtreleaseamount_TextChanged(object sender, EventArgs e)
        {
            decimal Totalamount = 0; decimal Balance = 0;
            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
            {
                CheckBox chkcheck = ((CheckBox)gvrow.FindControl("chkRow"));
                TextBox TextRelease = ((TextBox)gvrow.FindControl("txtreleaseamount"));
                Label Sanction = ((Label)gvrow.FindControl("lblSanctionedAmount"));
                Label AllottedAmount = ((Label)gvrow.FindControl("lblAllotedAmount"));
                Label ReleaseType = ((Label)gvrow.FindControl("lblReleaseType"));
                Label ReleaseFlag = ((Label)gvrow.FindControl("lblReleaseFlag"));
                if (ddlgos.SelectedValue == "0")
                {
                    string message = "alert('Please select GO')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    TextRelease.Text = Sanction.Text;
                    ddlgos.Focus();
                    return;
                }
                if (chkcheck.Checked == true)
                {
                    Totalamount += Convert.ToDecimal(TextRelease.Text);
                }
                if (Convert.ToDecimal(TextRelease.Text) > Convert.ToDecimal(Sanction.Text.Trim()))
                {
                    string message = "alert('Released Amount cannot greater than Sanctioned Amount')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    TextRelease.Text = Sanction.Text;
                    return;
                }
                if (Convert.ToDecimal(TextRelease.Text.Trim()) > Convert.ToDecimal(hdnActualBalance.Value.Trim()))
                {
                    string message = "alert('Released Amount should not higher than Go's Balance Amount')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    TextRelease.Text = Sanction.Text;
                    return;
                }
                if (Convert.ToDecimal(TextRelease.Text) < Convert.ToDecimal(Sanction.Text.Trim())) {
                    ReleaseType.Text = "Partial Release";
                    ReleaseFlag.Text = "P";
                }
                if (Convert.ToDecimal(TextRelease.Text) == Convert.ToDecimal(Sanction.Text.Trim()))
                {
                    ReleaseType.Text = "Complete Release";
                    ReleaseFlag.Text = "C";
                }
                AllottedAmount.Text = TextRelease.Text;
            }
            Balance= Convert.ToDecimal(hdnActualBalance.Value) - Totalamount;
            lblbalanceamount.InnerHtml = Balance.ToString();
        }
        public DataSet GetFundGos()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_GO_Fund_Dtls");
            return Dsnew;
        }
        public void AddSelectNew(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
        protected void ddlgos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string AmountReleasing = "";
            foreach (GridViewRow Row in gvdetailsnew.Rows)
            {
                TextBox ReleasingAmount = (TextBox)Row.FindControl("txtreleaseamount");
                AmountReleasing = ReleasingAmount.Text;
            }

            if (ddlgos.SelectedValue != "0")
            {
                DataSet ds = new DataSet();
                ds = (DataSet)ViewState["dsgos"];
                DataRow[] drs = ds.Tables[0].Select("GOID = " + ddlgos.SelectedValue);
                if (drs.Length > 0)
                {
                    string AmountReleased = drs[0]["AmountReleased"].ToString();
                    string BalanceAmont = drs[0]["BalanceAmont"].ToString();
                    lblbalanceamount.InnerText = BalanceAmont;
                    hdnActualBalance.Value = BalanceAmont;
                    lblTotalGOamount.InnerText = AmountReleased;

                    if (Convert.ToDecimal(BalanceAmont) < Convert.ToDecimal(AmountReleasing.Trim()))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Releasing amount should not higher than GO's Balance amount,Please change the GO or reduce the Releasing amount')", true);
                        btnSubmit.Enabled = false;
                        return;
                    }
                    else
                    {
                        txtreleaseamount_TextChanged(sender, e);
                        btnSubmit.Enabled = true;
                    }
                }
            }

        }
    }
}