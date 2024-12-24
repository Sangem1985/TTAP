using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmProductDevelopment : System.Web.UI.Page
    {
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";

                if (Session["ObjLoginvo"] != null)
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjLoginNewvo.uid;
                    }
                    else
                    {
                        PageName pageName = new PageName();
                        string Valid = pageName.ValidateUser(hdnUserID.Value, ObjLoginNewvo.uid);
                        if (Valid == "1")
                        {
                            Session.RemoveAll();
                            Session.Clear();
                            Session.Abandon();
                            Response.Redirect("~/LoginReg.aspx");
                        }
                    }
                    if (!IsPostBack)
                    {
                        if (Session["incentivedata"] != null)
                        {
                            string userid = Session["uid"].ToString();
                            string IncentveID = Session["IncentiveID"].ToString();
                            DataSet ds = new DataSet();
                            ds = (DataSet)Session["incentivedata"];
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 10);
                            if (drs.Length > 0)
                            {
                                divEarlierYear.Visible = false;
                                divEarlieramount.Visible = false;
                                DataSet dsnew = new DataSet();
                                GetProductDevelopmentDetails(userid, IncentveID);
                                //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                                //Filldata(dsnew);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmLandCostSubsidy.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmTransportSubsidy.aspx?Previous=" + "P");
                                }
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/LoginReg.aspx");
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string uid = "0";
                if (Session["uid"] != null)
                {
                    uid = Session["uid"].ToString();
                }

                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, uid);
            }
        }
        public void EnableDisableForm(ControlCollection ctrls, bool status)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = status;

                // if (ctrl is Button)      // commented to enable the Button Controls
                //    ((Button)ctrl).Enabled = status;

                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).Enabled = status;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Enabled = status;
                else if (ctrl is RadioButton)
                    ((RadioButton)ctrl).Enabled = status;
                else if (ctrl is RadioButtonList)
                    ((RadioButtonList)ctrl).Enabled = status;
                else if (ctrl is CheckBoxList)
                    ((CheckBoxList)ctrl).Enabled = status;

                EnableDisableForm(ctrl.Controls, status);

            }
        }
        public DataSet GetapplicationDtls(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA", pp);
            return Dsnew;
        }
        public void GetProductDevelopmentDetails(string uid, string incentiveid)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, incentiveid);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    }

                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();

                    string ENABLINGCONTRILS = dsnew.Tables[0].Rows[0]["ENABLINGCONTRILS"].ToString();
                    if ((dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == null || dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == ""))// && ENABLINGCONTRILS == "N")
                    {
                        EnableDisableForm(Page.Controls, true);
                    }
                    else
                    {
                        string applicationStatus = "";
                        applicationStatus = dsnew.Tables[0].Rows[0]["intStatusid"].ToString();
                        if (applicationStatus == "")
                        {
                            applicationStatus = "0";
                        }
                        if (Convert.ToInt32(applicationStatus) >= 2 || ENABLINGCONTRILS == "Y")  //3  changed on 17.11.2017 
                        {
                            EnableDisableForm(Page.Controls, false);

                            btnNewProductReport.Enabled = false;
                            btnExpendDocs.Enabled = false;
                            btnLoanSanction.Enabled = false;

                            //grdPandM.Columns[19].Visible = false;
                            //grdPandM.Columns[18].Visible = false;
                        }
                        else
                        {
                            EnableDisableForm(Page.Controls, true);
                        }
                    }
                }

                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.Int),
                    new SqlParameter("@IncentiveID",SqlDbType.Int)

                };
                p[0].Value = uid;
                p[1].Value = incentiveid;

                ds = Gen.GenericFillDs("USP_GET_Design_Product_Development_Diversification", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0] != null && ds.Tables[0].ToString() != "")
                {

                    txtDesignDeveloped.Text = ds.Tables[0].Rows[0]["DesignDeveloped"].ToString();
                    txtExpenditureIncurred.Text = ds.Tables[0].Rows[0]["ExpenditureIncurred"].ToString();
                    RbtnEarlierClaimsMade.SelectedValue = ds.Tables[0].Rows[0]["EarlierClaimsMade"].ToString();
                    RbtnEarlierClaimsMade_SelectedIndexChanged(this, EventArgs.Empty);
                    txtEarlierCliamYear.Text = ds.Tables[0].Rows[0]["EarlierCliamYear"].ToString();
                    txtamountclaimed.Text = ds.Tables[0].Rows[0]["amountclaimed"].ToString();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    try
                    {
                        int RowsCount = ds.Tables[1].Rows.Count;
                        string Path, Docid;
                        for (int i = 0; i < RowsCount; i++)
                        {
                            Path = ds.Tables[1].Rows[i]["link"].ToString();
                            Docid = ds.Tables[1].Rows[i]["AttachmentId"].ToString();
                            if (!string.IsNullOrEmpty(Path))
                            {
                                if (Docid == "101001")
                                {
                                    objClsFileUpload.AssignPath(hyLoanSanction, Path);

                                }
                                else if (Docid == "101002")
                                {
                                    objClsFileUpload.AssignPath(hyExpendDocs, Path);

                                }
                                else if (Docid == "101003")
                                {
                                    objClsFileUpload.AssignPath(hyNewProductReport, Path);

                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = ex.Message;
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtExpenditureIncurred.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Expenditure Incurred in New Product/ Design Development / Diversification \\n";
                slno = slno + 1;
            }

            if (RbtnEarlierClaimsMade.SelectedValue == "Y")
            {
                if (txtEarlierCliamYear.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Earlier Claims made Year   \\n";
                    slno = slno + 1;
                }
                if (txtamountclaimed.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Earlier Claimed Amount (In Rupees) \\n";
                    slno = slno + 1;
                }
            }

            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Current Claim  Amount (In Rupees)  \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }



        protected void btnExpendDocs_Click(object sender, EventArgs e)
        {

            if (fluExpendDocs.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fluExpendDocs);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fluExpendDocs);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fluExpendDocs, hyExpendDocs, "IndicatingExpenditureIncurredNewProductDesignDevelopmentDiversification", Session["IncentiveID"].ToString(), "10", "101002", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }

                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        protected void btnNewProductReport_Click(object sender, EventArgs e)
        {
            if (fuNewProductReport.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuNewProductReport);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuNewProductReport);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuNewProductReport, hyNewProductReport, "ReportNewProductNewDesignDiversificationCreated", Session["IncentiveID"].ToString(), "10", "101003", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        protected void btnLoanSanction_Click(object sender, EventArgs e)
        {
            if (fuLoansanction.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuLoansanction);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuLoansanction);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLoansanction, hyLoanSanction, "LoansanctionorderBank", Session["IncentiveID"].ToString(), "10", "101001", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = GeneralInformationcheck();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "10");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    ProductDevelopment ObjProduct = new ProductDevelopment();

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    ObjProduct.IncentiveId = Session["IncentiveID"].ToString();

                    ObjProduct.DesignDeveloped = txtDesignDeveloped.Text.Trim().TrimStart();
                    ObjProduct.ExpenditureIncurred = GetDecimalNullValue(txtExpenditureIncurred.Text.Trim().TrimStart());
                    ObjProduct.EarlierClaimsMade = RbtnEarlierClaimsMade.SelectedValue;
                    ObjProduct.EarlierCliamYear = txtEarlierCliamYear.Text.Trim().TrimStart();
                    ObjProduct.amountclaimed = GetDecimalNullValue(txtamountclaimed.Text.Trim().TrimStart());
                    ObjProduct.CurrentClaim = GetDecimalNullValue(txtCurrentClaim.Text.Trim().TrimStart());

                    ObjProduct.CreatedBy = ObjLoginNewvo.uid;
                    string Validstatus = ObjCAFClass.InsertingOfDesignProductDevelopmentDiversificationDtls(ObjProduct);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {

                        Response.Redirect("frmLandCostSubsidy.aspx?next=" + "N");
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());

            }


        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmTransportSubsidy.aspx?Previous=" + "P");
        }

        protected void RbtnEarlierClaimsMade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtnEarlierClaimsMade.SelectedValue == "Y")
            {
                divEarlierYear.Visible = true;
                divEarlieramount.Visible = true;
            }
            else
            {
                divEarlierYear.Visible = false;
                divEarlieramount.Visible = false;
            }
        }
    }
}