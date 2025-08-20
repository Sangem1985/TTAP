using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class GMUnitWorkingStatusUpdation : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Cast = Request.QueryString[0].ToString();
                string Status = Request.QueryString[1].ToString();
                string IncentiveId = Request.QueryString[2].ToString();
                string SubIncentiveid = Convert.ToInt32(Request.QueryString[3]).ToString();
                string Distid = Convert.ToInt64(Request.QueryString[4]).ToString();

                ds = ObjCAFClass.GetUnitWorkingStatusUpdation(Cast, Status, IncentiveId, SubIncentiveid, Distid);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                {
                    tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveName"].ToString();
                    GVDetails.DataSource = ds.Tables[1];
                    GVDetails.DataBind();
                }
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlworkingstatus.DataSource = ds;
                    ddlworkingstatus.DataTextField = "WORKINGSTATUS_DESC";
                    ddlworkingstatus.DataValueField = "WORKINGSTATUS_ID";
                    ddlworkingstatus.DataBind();
                    AddSelect(ddlworkingstatus);
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    lblbankname.Text = ds.Tables[1].Rows[0]["BankAccountName"].ToString();
                    lblBranchName.Text = ds.Tables[1].Rows[0]["BranchName"].ToString();
                    lblAccountNumber.Text = ds.Tables[1].Rows[0]["AccNo"].ToString();
                    lblaccounttype.Text = ds.Tables[1].Rows[0]["BankAccType"].ToString();
                    lblIFSC.Text = ds.Tables[1].Rows[0]["IFSCCode"].ToString();
                    //if (ds.Tables[1].Rows[0]["LoanAggrementAcNo"].ToString() != "")
                    //{
                    //    lblLoanAggrementAcNo.Text = ds.Tables[1].Rows[0]["LoanAggrementAcNo"].ToString();
                    //}
                    //else
                    lblLoanAggrementAcNo.Text = "Not Available";
                    ViewState["BankAccType"] = ds.Tables[1].Rows[0]["BankAccType"].ToString();
                    ViewState["Id"] = ds.Tables[2].Rows[0]["Id"].ToString();

                }
                else
                {
                    rblBankDetails.SelectedValue = "2";
                    rblBankDetails.Enabled = false;
                    rblBankDetails_SelectedIndexChanged(sender, e);
                }
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[2].Rows.Count > 0)
                {
                    ddlBank.DataSource = ds.Tables[2];
                    ddlBank.DataTextField = "BankName";
                    ddlBank.DataValueField = "Id";
                    ddlBank.DataBind();

                    AddSelect(ddlBank);
                }
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        protected void rblBankDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblBankDetails.SelectedValue == "Y")
            {
                ddlBank.SelectedValue = ViewState["Id"].ToString();
                txtBranchName.Text = lblBranchName.Text;
                txtAccNumber.Text = lblAccountNumber.Text;
                txtIfscCode.Text = lblIFSC.Text;
                ddlaccounttype.SelectedValue = ViewState["BankAccType"].ToString();

                ddlBank.Enabled = false;
                txtBranchName.Enabled = false;
                txtAccNumber.Enabled = false;
                txtIfscCode.Enabled = false;
                ddlaccounttype.Enabled = false;

            }
            else
            {
                ddlBank.Enabled = true;
                txtBranchName.Enabled = true;
                txtAccNumber.Enabled = true;
                txtIfscCode.Enabled = true;
                ddlaccounttype.Enabled = true;

                ddlBank.SelectedIndex = 0;
                txtBranchName.Text = "";
                txtAccNumber.Text = "";
                txtIfscCode.Text = "";
                ddlaccounttype.SelectedIndex = 0;
            }
        }

        protected void ddlBank_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (ddlworkingstatus.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select Working Status.');", true);
                    ddlworkingstatus.Focus();
                    ddlBank.ClearSelection();
                }
                if (ddlworkingstatus.SelectedValue == "1")
                {
                    //if (RBTYESORNO.SelectedValue != "Y" && RBTYESORNO.SelectedValue != "N")
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select weather you want to continue with above rollbacked working status details.');", true);
                    //    RBTYESORNO.Focus();
                    //    ddlBank.ClearSelection();

                    //}

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlBank.SelectedValue.ToString() == "196")
                {
                    trNBFC.Visible = true;

                }
                else
                {
                    trNBFC.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnBankAccountDet_Click(object sender, EventArgs e)
        {
            /* string newPath = "";
             string sFileDir = Server.MapPath("~\\GoCOIIncentiveAttachments");
             General t1 = new General();
             BusinessLogic.DML objDml = new BusinessLogic.DML();

             string MstIncentiveId = "";
             string IncentiveID = "";
             string SLCNumer = string.Empty;

             if (fupBankDet.HasFile)
             {
                 if ((fupBankDet.PostedFile != null) && (fupBankDet.PostedFile.ContentLength > 0))
                 {
                     string sFileName = System.IO.Path.GetFileName(fupBankDet.PostedFile.FileName);
                     try
                     {
                         string[] fileType = fupBankDet.PostedFile.FileName.Split('.');
                         int i = fileType.Length;
                         if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                         {
                             foreach (GridViewRow gvrow in GVDetails.Rows)
                             {
                                 SLCNumer = ((Label)gvrow.FindControl("lblSLCNumber")).Text;
                                 newPath = System.IO.Path.Combine(sFileDir, SLCNumer);

                                 if (!Directory.Exists(newPath))

                                     System.IO.Directory.CreateDirectory(newPath);
                                 System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);

                                 fupBankDet.PostedFile.SaveAs(newPath + "\\" + sFileName);
                             }

                             foreach (GridViewRow gvrow in GVDetails.Rows)
                             {
                                 MstIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveID")).Text;
                                 IncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
                                 SLCNumer = ((Label)gvrow.FindControl("lblSLCNumber")).Text;
                                 newPath = System.IO.Path.Combine(sFileDir, SLCNumer);
                                 if (MstIncentiveId != "" && IncentiveID != "" && SLCNumer != "")
                                 {
                                     objDml.InsUpdCOI_Incentive_Attachments(2, Convert.ToInt32(IncentiveID), Convert.ToInt32(MstIncentiveId), Convert.ToInt32(SLCNumer), sFileName, newPath, Convert.ToInt32(Session["uid"].ToString()));
                                 }
                             }

                             lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                             hypBankDet.Text = fupBankDet.FileName;
                             hypBankDet.NavigateUrl = "~\\GoCOIIncentiveAttachments" + "/" + SLCNumer + "/" + sFileName;
                             hypBankDet.Visible = true;
                             btnSubmit.Enabled = true;
                             success.Visible = true;
                             Failure.Visible = false;
                         }
                         else
                         {
                             lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                             btnSubmit.Enabled = false;
                             success.Visible = false;
                             Failure.Visible = true;
                         }

                     }
                     catch (Exception)
                     {
                         DeleteFile(newPath + "\\" + sFileName);
                     }
                 }
             }
             else
             {
                 lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                 success.Visible = false;
                 Failure.Visible = true;
             }*/


            string newPath = "";
            string sFileDir = Server.MapPath("~\\GoCOIIncentiveAttachments");
            General t1 = new General();
            BusinessLogic.DML objDml = new BusinessLogic.DML();

            string MstIncentiveId = "";
            string IncentiveID = "";
            string SLCNumer = string.Empty;

            if (fupBankDet.HasFile)
            {
                if ((fupBankDet.PostedFile != null) && (fupBankDet.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fupBankDet.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fupBankDet.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            foreach (GridViewRow gvrow in GVDetails.Rows)
                            {
                                SLCNumer = ((Label)gvrow.FindControl("lblSLCNumber")).Text;
                                newPath = System.IO.Path.Combine(sFileDir, SLCNumer);

                                if (!Directory.Exists(newPath))

                                    System.IO.Directory.CreateDirectory(newPath);
                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);

                                fupBankDet.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }

                            foreach (GridViewRow gvrow in GVDetails.Rows)
                            {
                                MstIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveID")).Text;
                                IncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text;
                                SLCNumer = ((Label)gvrow.FindControl("lblSLCNumber")).Text;
                                newPath = System.IO.Path.Combine(sFileDir, SLCNumer);
                                if (MstIncentiveId != "" && IncentiveID != "" && SLCNumer != "")
                                {
                                    objDml.InsUpdCOI_Incentive_Attachments(2, Convert.ToInt32(IncentiveID), Convert.ToInt32(MstIncentiveId), Convert.ToInt32(SLCNumer), sFileName, newPath, Convert.ToInt32(Session["uid"].ToString()));
                                }
                            }

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hypBankDet.Text = fupBankDet.FileName;
                            hypBankDet.NavigateUrl = "~\\GoCOIIncentiveAttachments" + "/" + SLCNumer + "/" + sFileName;
                            hypBankDet.Visible = true;
                            btnSubmit.Enabled = true;
                            success.Visible = true;
                            Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            btnSubmit.Enabled = false;
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }

        }
        public void DeleteFile(string strFileName)
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                if (ddlworkingstatus.SelectedValue != "2" && ddlworkingstatus.SelectedValue != "3")
                {
                    if (ddlworkingstatus.SelectedItem.Text.ToUpper() != "--SELECT--" && ddlBank.SelectedItem.Text.ToUpper() != "--SELECT--" && ddlaccounttype.SelectedItem.Text.ToUpper() != "--SELECT--")
                    {
                        if (ddlworkingstatus.SelectedValue != "2" && ddlworkingstatus.SelectedValue != "3")
                        {
                            if ((txtBranchName.Text.Trim() != null && txtBranchName.Text.Trim() != "") && (txtAccNumber.Text.Trim() != null && txtAccNumber.Text.Trim() != "") && (txtIfscCode.Text.Trim() != null && txtIfscCode.Text.Trim() != ""))
                            {
                                i = 1;
                            }
                            else
                            {
                                i = 0;
                                lblmsg0.Text = "";
                                lblmsg0.Text = "Please enter all fields, all fields are mandatory";
                                lblmsg0.Visible = true;
                                Failure.Visible = true;
                                return;
                            }
                        }
                        else
                        {
                            i = 1;
                        }
                    }
                    else
                    {
                        i = 0;
                        lblmsg0.Text = "";
                        lblmsg0.Text = "Please enter all fields, all fields are mandatory";
                        lblmsg0.Visible = true;
                        Failure.Visible = true;
                        return;
                    }
                }
                else if (ddlworkingstatus.SelectedValue == "2")
                {
                    if (txtremarks.Text.Trim() != null && txtremarks.Text.Trim() != "")
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                        lblmsg0.Text = "";
                        lblmsg0.Text = "Please enter Remarks";
                        lblmsg0.Visible = true;
                        Failure.Visible = true;
                        return;
                    }

                }
                else if (ddlworkingstatus.SelectedValue == "3")
                {
                    if (txtremarks.Text.Trim() != null && txtremarks.Text.Trim() != "")
                    {
                        i = 1;
                    }
                    else
                    {
                        i = 0;
                        lblmsg0.Text = "";
                        lblmsg0.Text = "Please enter Remarks";
                        lblmsg0.Visible = true;
                        Failure.Visible = true;
                        return;
                    }

                }
                if (i == 1)
                {
                    if (ddlworkingstatus.SelectedValue == "2")
                    {
                        GmfinalProceedings GmfinalProceeding = new GmfinalProceedings();

                        GmfinalProceeding.SubIncentiveId = ((Label)GVDetails.Rows[0].FindControl("lblSubIncentiveID")).Text;
                        GmfinalProceeding.IncentiveID = ((Label)GVDetails.Rows[0].FindControl("lblIncentiveID")).Text;
                        GmfinalProceeding.SLCNumer = ((Label)GVDetails.Rows[0].FindControl("lblSLCNumber")).Text;
                        GmfinalProceeding.WorkingStatus = ddlworkingstatus.SelectedValue;
                        GmfinalProceeding.Newbankname = "0";
                        GmfinalProceeding.NewBranchname = "0";
                        GmfinalProceeding.NewIFSCcode = "0";
                        GmfinalProceeding.AccountNumber = "0";
                        GmfinalProceeding.NewAccountType = "0";
                        GmfinalProceeding.Remarks = txtremarks.Text;
                        GmfinalProceeding.AccNoConfirmationFlg = "0";
                        GmfinalProceeding.LoanAggrementAccountNo = "0";
                        GmfinalProceeding.CreatedByid = Session["uid"].ToString();
                        GmfinalProceeding.SubIncTypeId = Request.QueryString[3].ToString();
                        GmfinalProceeding.nbfcName = txtNBFCName.Text;

                        string Validstatus = ObjCAFClass.INSUnitWorkingStatusUpdation(GmfinalProceeding);

                        if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                        {
                            string message = "alert('Working Status Updated Successfully')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            btnSubmit.Enabled = false;
                            Response.Redirect("~/UI/Pages/frmGMDashboard.aspx");
                        }
                    }
                    else if (ddlworkingstatus.SelectedValue == "3")
                    {
                        GmfinalProceedings GmfinalProceeding = new GmfinalProceedings();

                        GmfinalProceeding.SubIncentiveId = ((Label)GVDetails.Rows[0].FindControl("lblSubIncentiveID")).Text;
                        GmfinalProceeding.IncentiveID = ((Label)GVDetails.Rows[0].FindControl("lblIncentiveID")).Text;
                        GmfinalProceeding.SLCNumer = ((Label)GVDetails.Rows[0].FindControl("lblSLCNumber")).Text;
                        GmfinalProceeding.WorkingStatus = ddlworkingstatus.SelectedValue;
                        GmfinalProceeding.Newbankname = "0";
                        GmfinalProceeding.NewBranchname = "0";
                        GmfinalProceeding.NewIFSCcode = "0";
                        GmfinalProceeding.AccountNumber = "0";
                        GmfinalProceeding.NewAccountType = "0";
                        GmfinalProceeding.Remarks = txtremarks.Text;
                        GmfinalProceeding.AccNoConfirmationFlg = "0";
                        GmfinalProceeding.LoanAggrementAccountNo = "0";
                        GmfinalProceeding.CreatedByid = Session["uid"].ToString();
                        GmfinalProceeding.SubIncTypeId = Request.QueryString[3].ToString();
                        GmfinalProceeding.nbfcName = txtNBFCName.Text;

                        string Validstatus = ObjCAFClass.INSUnitWorkingStatusUpdation(GmfinalProceeding);

                        if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                        {
                            string message = "alert('Working Status Updated to Abeyance Successfully')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            btnSubmit.Enabled = false;
                            Response.Redirect("~/UI/Pages/frmGMDashboard.aspx");
                        }
                    }
                    else if (txtLoanAggrementAcNo.Text != "" && ddlworkingstatus.SelectedValue != "2" && ddlworkingstatus.SelectedValue != "3")
                    {
                        GmfinalProceedings GmfinalProceeding = new GmfinalProceedings();

                        GmfinalProceeding.SubIncentiveId = ((Label)GVDetails.Rows[0].FindControl("lblSubIncentiveID")).Text;
                        GmfinalProceeding.IncentiveID = ((Label)GVDetails.Rows[0].FindControl("lblIncentiveID")).Text;
                        GmfinalProceeding.SLCNumer = ((Label)GVDetails.Rows[0].FindControl("lblSLCNumber")).Text;
                        GmfinalProceeding.WorkingStatus = ddlworkingstatus.SelectedValue;
                        GmfinalProceeding.Newbankname = ddlBank.SelectedItem.Text;
                        GmfinalProceeding.NewBranchname = txtBranchName.Text;
                        GmfinalProceeding.NewIFSCcode = txtIfscCode.Text;
                        GmfinalProceeding.AccountNumber = txtAccNumber.Text;
                        GmfinalProceeding.NewAccountType = ddlaccounttype.SelectedItem.Text;
                        GmfinalProceeding.Remarks = txtremarks.Text;
                        GmfinalProceeding.AccNoConfirmationFlg = rblBankDetails.SelectedValue;
                        GmfinalProceeding.LoanAggrementAccountNo = txtLoanAggrementAcNo.Text.ToString();
                        GmfinalProceeding.CreatedByid = Session["uid"].ToString();
                        GmfinalProceeding.nbfcName = txtNBFCName.Text;

                        GmfinalProceeding.SubIncTypeId = Request.QueryString[3].ToString();

                        string Validstatus = ObjCAFClass.INSUnitWorkingStatusUpdation(GmfinalProceeding);

                        if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                        {
                            string message = "alert('Working Status Updated Successfully')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            btnSubmit.Enabled = false;
                            Response.Redirect("~/UI/Pages/frmGMDashboard.aspx");
                        }

                    }
                    else if (txtLoanAggrementAcNo.Text == "" && ddlworkingstatus.SelectedValue != "2" && ddlworkingstatus.SelectedValue != "3")
                    {
                        string message = "alert('Please enter Loan/Aggrement Account Number !')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       /* protected void ddlworkingstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlworkingstatus.SelectedValue == "2" || ddlworkingstatus.SelectedValue == "3")
            {
                //Button6.Enabled = true;

                btnSubmit.Enabled = true;
                trBankDetails1.Visible = false;
                trBankDetails2.Visible = false;
                trBankDetails3.Visible = false;
                //tdROLL1.Visible = false;
                //tdROLL2.Visible = false;
                //tdROLL3.Visible = false;
                txtremarks.Text = "";
            }
            else
            {
                trBankDetails1.Visible = true;
                trBankDetails2.Visible = true;
                trBankDetails3.Visible = true;
                troptpbutton.Visible = false;
                //if (trrollbackeddata.Visible == true && trrollbackedgrid.Visible == true)
                //{
                //    if (ddlworkingstatus.SelectedValue == "1")
                //    {
                //        tdROLL1.Visible = true;
                //        tdROLL2.Visible = true;
                //        tdROLL3.Visible = true;
                //        RadioButtonList1.Enabled = false;
                //    }
                //    else
                //    {
                //        tdROLL1.Visible = false;
                //        tdROLL2.Visible = false;
                //        tdROLL3.Visible = false;
                //    }
                //}

            }
        }*/
    }
}