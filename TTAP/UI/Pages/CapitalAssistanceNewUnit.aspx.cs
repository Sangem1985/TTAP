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
    public partial class CapitalAssistanceNewUnit : System.Web.UI.Page
    {
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass caf = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                        if (Session["uid"] != null)
                        {
                            string userid = Session["uid"].ToString();

                            if (Session["incentivedata"] != null)
                            {
                                DataSet ds = new DataSet();
                                ds = (DataSet)Session["incentivedata"];
                                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 1);
                                if (drs.Length > 0)
                                {
                                    DataSet dsnew = new DataSet();
                                    BindControls();
                                    if (rdl_Buliding_Type.SelectedIndex == -1)
                                    {
                                        rdl_Buliding_Type.Enabled = true;
                                    }
                                }
                                else
                                {
                                    if (Request.QueryString[0].ToString() == "N")
                                    {
                                        //Response.Redirect("CapitalAssistanceCreationEnergy.aspx?next=" + "N");
                                        Response.Redirect("frmCapitalAssistanceExistingUnit.aspx?next=" + "N");
                                    }
                                    else
                                    {
                                        Response.Redirect("frmIncentiveCAFDetails.aspx");
                                    }
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

        public int ValidateFileUploads()
        {
            int i = 0;

            //if (fuDetailedproject.HasFile == false)
            //{
            //    i = 1;
            //}
            return i;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ////int i = Convert.ToInt32(ValidateFileUploads());
                ////if (i == 1)
                ////{
                ////    lblmsg0.Text = "<font color=Red>Please Upload Mandatory File Uploads</font></br>";
                ////    success.Visible = false;
                ////    Failure.Visible = true;
                ////    lblmsg0.Visible = true;
                ////}
                ////else
                ////{
                //    CapitalAssistanceNewUnitvo objBO = new CapitalAssistanceNewUnitvo();
                //    objBO.IncentiveID =Session["IncentiveID"].ToString();
                //    objBO.TypeofUnit = rbtn_TypeofUnit.SelectedValue;
                //    objBO.FactoryShedsandBuildings = txtFactoryShedsandBuildings.Text.Trim();
                //    objBO.LandnotAllottedbyGov = txtLandnotAllottedbyGov.Text.Trim();
                //    objBO.PlandandMachinery = txtPlandandMachinery.Text.Trim();
                //    objBO.Laboratories = txtLaboratories.Text.Trim();
                //    objBO.Utilities = txtUtilities.Text.Trim();
                //    objBO.OtherFixedAssets = txtOtherFixedAssets.Text.Trim();
                //    objBO.Total = txtTotal.Text.Trim();
                //    objBO.AmountSubsidyClaimed = txtAmountSubsidyClaimed.Text.Trim();
                //    objBO.CreatedBy = Session["uid"].ToString();
                //    objBO.UpdatedBy = Session["uid"].ToString();

                //    General objDAL = new General();
                //    int result = objDAL.insertCapAssNewUnitDB(objBO);
                //    if (result >= 1)
                //    {
                //        lblResult.Visible = true;
                //        lblResult.Text = "Application Submitted Successfully";
                //       // Clear();
                //        btnSubmit.Visible = false;
                //    }
                //    else
                //    {
                //        lblResult.Text = "Submission Failed";
                //    }
                // }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Clear()
        {

        }

        public void GetCapitalAssistanceNewUnit(string uid, string IncentiveID)
        {

        }

        //protected void BtnNext_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("frmCapitalAssistanceExistingUnit.aspx?next=" + "N");
        //}

        protected void btnclear_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmIncentiveCAFDetails.aspx?Previous=" + "P");
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void btnDetailedproject_Click(object sender, EventArgs e)
        {
            if (fuDetailedproject.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDetailedproject);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuDetailedproject);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDetailedproject, hyDetailedproject, "Detailedprojectreport", Session["IncentiveID"].ToString(), "1", "11001", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyDetailedproject.Visible = true;
                        //ViewState["Detailedproject"] = hyDetailedproject.NavigateUrl;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select File!");

            }

        }

        protected void btnApprovalofProject_Click(object sender, EventArgs e)
        {
            if (fuApprovalofProject.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuApprovalofProject);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuApprovalofProject);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuApprovalofProject, hyApprovalofProject, "ApprovalProjectreport", Session["IncentiveID"].ToString(), "1", "11002", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyApprovalofProject.Visible = true;
                        //ViewState["ApprovalofProject"] = hyApprovalofProject.NavigateUrl;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select a File!");
            }
        }

        protected void btnProjectCompletion_Click(object sender, EventArgs e)
        {
            if (fuProjectCompletion.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuProjectCompletion);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuProjectCompletion);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuProjectCompletion, hyProjectCompletion, "ProjectCompletionCertificate", Session["IncentiveID"].ToString(), "1", "11003", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyProjectCompletion.Visible = true;
                        // ViewState["ProjectCompletion"] = hyProjectCompletion.NavigateUrl;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select a File!");
            }
        }

        protected void btnDeclarationstating_Click(object sender, EventArgs e)
        {
            if (fuDeclarationstating.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDeclarationstating);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuDeclarationstating);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDeclarationstating, hyDeclarationstating, "financialAssistanceGovernment ", Session["IncentiveID"].ToString(), "1", "11004", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyDeclarationstating.Visible = true;
                        //ViewState["Declarationstating"] = hyDeclarationstating.NavigateUrl;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select a File!");
            }
        }

        protected void btnlinedepartment_Click(object sender, EventArgs e)
        {
            if (fulinedepartment.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fulinedepartment);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fulinedepartment);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fulinedepartment, hylinedepartment, "DeclarationLinedepartment", Session["IncentiveID"].ToString(), "1", "11005", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hylinedepartment.Visible = true;
                        // ViewState["linedepartment"] = hylinedepartment.NavigateUrl;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select a File!");
            }
        }

        protected void btnDocumentsevidencing_Click(object sender, EventArgs e)
        {

            if (fuDocumentsevidencing.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDocumentsevidencing);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuDocumentsevidencing);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocumentsevidencing, hyDocumentsevidencing, "DocumentsevidencingTechnicalTextileUnit", Session["IncentiveID"].ToString(), "1", "11006", Session["uid"].ToString(), "USER");
                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyDocumentsevidencing.Visible = true;
                        // ViewState["Documentsevidencing"] = hyDocumentsevidencing.NavigateUrl;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select a File!");
            }
        }
        public void DeleteFile(string strFileName)
        {//Delete file from the server
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (txtPLExtent.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Purchased Land Extent\\n";
                slno = slno + 1;
            }
            if (txtPLValue.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Purchased Land Value\\n";
                slno = slno + 1;
            }
            if (txtLLExtent.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Leased Land Extent\\n";
                slno = slno + 1;
            }
            if (txtLLValue.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Leased Land Value\\n";
                slno = slno + 1;
            }
            if (txtILExtent.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Inhertied Land Extent\\n";
                slno = slno + 1;
            }
            if (rdl_Buliding_Type.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Building Type(Constructed/Leased)\\n";
                slno = slno + 1;
            }
            if (txtILValue.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Inhertied Land Value\\n";
                slno = slno + 1;
            }
            if (txtGLExtent.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Govt Land (TSIIC developed IEs/IDA/Industrial Parks) Extent\\n";
                slno = slno + 1;
            }
            if (txtGLValue.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Govt Land (TSIIC developed IEs/IDA/Industrial Parks) Value\\n";
                slno = slno + 1;
            }
            if (txtMFSArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Main Factory Shed Plinth Area In Square Meters\\n";
                slno = slno + 1;
            }
            if (txtMFSCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Main Factory Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtWarehouseArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Warehouse for Raw Material and finished goods Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtWarehouseCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter  Warehouse for Raw Material and finished goods Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtOfficeArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Office room and Lab room Plinth Area In Square Meters\\n";
                slno = slno + 1;
            }
            if (txtOfficeCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Office room and Lab room Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtCWPArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cooling water ponds  Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtCWPCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cooling water ponds Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtBoilerArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Boiler shed and generator room  Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtBoilerCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Boiler shed and generator room Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtETPArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Effluent treatment ponds etc.  Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtETPCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Effluent treatment ponds etc. Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtOTArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Overhead Tank,bore-wells and pump house and sump  Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtOTACost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Overhead Tank,bore-wells and pump house and sump Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtFGArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Fencing and Gate Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtFGCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Fencing and Gate Cost (In Rs)\\n";
                slno = slno + 1;
            }
            //if (txtAFArea.Text.TrimStart().TrimEnd().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter Architect fee and supervision charges Plinth Area In Square Meters \\n";
            //    slno = slno + 1;
            //}
            if (txtAFCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Architect fee and supervision charges Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtCWArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Compound wall Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtCWCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Compound wall Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtWQArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Workers Quarters/ workers housing Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtWQCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Workers Quarters/ workers housing Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtCanteenArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Canteen Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtCanteenCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Canteen Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtRHArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rest House Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtRHCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rest House Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtTOArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Time Office Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtTOCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Time Office Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtCSArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cycle/Vehicle Stand Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtCSCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cycle/Vehicle Stand Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtSSArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Security Shed Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtSSCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Security Shed Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtToiletArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Toilet room and sanitary fittings Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtToiletCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Toilet room and sanitary fittings Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtRoadsArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Roads with in factory premises Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtRoadsCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Roads with in factory premises Cost (In Rs)\\n";
                slno = slno + 1;
            }

            //if (hyDetailedproject.Visible == false)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Upload Detailed Project Report\\n";
            //    slno = slno + 1;
            //}
            //if (hyApprovalofProject.Visible == false)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Upload Approval of Project\\n";
            //    slno = slno + 1;
            //}
            //if (hyProjectCompletion.Visible == false)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Upload Project Completion Report \\n";
            //    slno = slno + 1;
            //}
            //if (hyDeclarationstating.Visible == false)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Upload Declartion of Not Availing Subsidy\\n";
            //    slno = slno + 1;
            //}
            //if (hylinedepartment.Visible == false)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Upload Declaration of Line Departments\\n";
            //    slno = slno + 1;
            //}
            //if (hyDocumentsevidencing.Visible == false)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Upload Declaration of Textile Type\\n";
            //    slno = slno + 1;
            //}
            if (txtCurrentClaimAmount.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Claim Amount\\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                string errormsgAttach = caf.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "1");
                if (errormsgAttach.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsgAttach + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                CapitalAssistanceforNewUnit cafnu = new CapitalAssistanceforNewUnit();
                cafnu.UserId = Session["uid"].ToString();
                cafnu.IncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());
                cafnu.TypeofUnit = rdl_TypeofUnit.SelectedValue;
                cafnu.PurchasedLandExtent = Convert.ToDecimal(GetDecimalNullValue(txtPLExtent.Text));
                cafnu.PurchasedLandValue = Convert.ToDecimal(GetDecimalNullValue(txtPLValue.Text));
                cafnu.LeasedLandExtent = Convert.ToDecimal(GetDecimalNullValue(txtLLExtent.Text));
                cafnu.LeasedLandValue = Convert.ToDecimal(GetDecimalNullValue(txtLLValue.Text));

                cafnu.Buliding_Type = rdl_Buliding_Type.SelectedValue;

                cafnu.InheritedLandExtent = Convert.ToDecimal(GetDecimalNullValue(txtILExtent.Text));
                cafnu.InheritedLandValue = Convert.ToDecimal(GetDecimalNullValue(txtILValue.Text));
                cafnu.GovtLandExtent = Convert.ToDecimal(GetDecimalNullValue(txtGLExtent.Text));
                cafnu.GovtLandValue = Convert.ToDecimal(GetDecimalNullValue(txtGLValue.Text));
                cafnu.MainFactoryShedArea = Convert.ToDecimal(GetDecimalNullValue(txtMFSArea.Text));
                cafnu.MainFactoryShedCost = Convert.ToDecimal(GetDecimalNullValue(txtMFSCost.Text));
                cafnu.WarehouseArea = Convert.ToDecimal(GetDecimalNullValue(txtWarehouseArea.Text));
                cafnu.WarehouseCost = Convert.ToDecimal(GetDecimalNullValue(txtWarehouseCost.Text));
                cafnu.OfficeRoomArea = Convert.ToDecimal(GetDecimalNullValue(txtOfficeArea.Text));
                cafnu.OfficeRoomCost = Convert.ToDecimal(GetDecimalNullValue(txtOfficeCost.Text));
                cafnu.CoolingPondsArea = Convert.ToDecimal(GetDecimalNullValue(txtCWPArea.Text));
                cafnu.CoolingPondsCost = Convert.ToDecimal(GetDecimalNullValue(txtCWPCost.Text));
                cafnu.BoilerShedArea = Convert.ToDecimal(GetDecimalNullValue(txtBoilerArea.Text));
                cafnu.BoilerShedCost = Convert.ToDecimal(GetDecimalNullValue(txtBoilerCost.Text));
                cafnu.EffluentPondsArea = Convert.ToDecimal(GetDecimalNullValue(txtETPArea.Text));
                cafnu.EffluentPondsCost = Convert.ToDecimal(GetDecimalNullValue(txtETPCost.Text));
                cafnu.OverHeadTankArea = Convert.ToDecimal(GetDecimalNullValue(txtOTArea.Text));
                cafnu.OverHeadTankCost = Convert.ToDecimal(GetDecimalNullValue(txtOTACost.Text));
                cafnu.FencingArea = Convert.ToDecimal(GetDecimalNullValue(txtFGArea.Text));
                cafnu.FencingCost = Convert.ToDecimal(GetDecimalNullValue(txtFGCost.Text));
                cafnu.ArchitectFeeArea = Convert.ToDecimal(GetDecimalNullValue(txtAFArea.Text));
                cafnu.ArchitectFeeCost = Convert.ToDecimal(GetDecimalNullValue(txtAFCost.Text));
                cafnu.CompoundWallArea = Convert.ToDecimal(GetDecimalNullValue(txtCWArea.Text));
                cafnu.CompoundWallCost = Convert.ToDecimal(GetDecimalNullValue(txtCWCost.Text));
                cafnu.WorksersHouseArea = Convert.ToDecimal(GetDecimalNullValue(txtWQArea.Text));
                cafnu.WorkersHouseCost = Convert.ToDecimal(GetDecimalNullValue(txtWQCost.Text));
                cafnu.CanteenArea = Convert.ToDecimal(GetDecimalNullValue(txtCanteenArea.Text));
                cafnu.CanteenCost = Convert.ToDecimal(GetDecimalNullValue(txtCanteenCost.Text));
                cafnu.RestHouseArea = Convert.ToDecimal(GetDecimalNullValue(txtRHArea.Text));
                cafnu.RestHouseCost = Convert.ToDecimal(GetDecimalNullValue(txtRHCost.Text));
                cafnu.TimeOfficeArea = Convert.ToDecimal(GetDecimalNullValue(txtTOArea.Text));
                cafnu.TimeOfficeCost = Convert.ToDecimal(GetDecimalNullValue(txtTOCost.Text));
                cafnu.VehicleStandArea = Convert.ToDecimal(GetDecimalNullValue(txtCSArea.Text));
                cafnu.VehicleStandCost = Convert.ToDecimal(GetDecimalNullValue(txtCSCost.Text));
                cafnu.SecurityShedArea = Convert.ToDecimal(GetDecimalNullValue(txtSSArea.Text));
                cafnu.SecurityShedCost = Convert.ToDecimal(GetDecimalNullValue(txtSSCost.Text));
                cafnu.ToiletArea = Convert.ToDecimal(GetDecimalNullValue(txtToiletArea.Text));
                cafnu.ToiletCost = Convert.ToDecimal(GetDecimalNullValue(txtToiletCost.Text));
                cafnu.RoadsArea = Convert.ToDecimal(GetDecimalNullValue(txtRoadsArea.Text));
                cafnu.RoadsCost = Convert.ToDecimal(GetDecimalNullValue(txtRoadsCost.Text));
                //cafnu.Detailedproject = ViewState["Detailedproject"].ToString();
                //cafnu.ApprovalofProject = ViewState["ApprovalofProject"].ToString();
                //cafnu.ProjectCompletion = ViewState["ProjectCompletion"].ToString();
                //cafnu.Declarationstating = ViewState["Declarationstating"].ToString();
                //cafnu.linedepartment = ViewState["linedepartment"].ToString();
                //cafnu.Documentsevidencing = ViewState["Documentsevidencing"].ToString();
                cafnu.CurrentClaimAmount = GetDecimalNullValue(txtCurrentClaimAmount.Text.Trim().TrimStart());

                cafnu.LaboratoriesforResearchQualityControl = GetDecimalNullValue(txtLaboratoriesforResearchQualityControl.Text.Trim().TrimStart());
                cafnu.UtilitiesPowerWater = GetDecimalNullValue(txtUtilitiesPowerWater.Text.Trim().TrimStart());
                cafnu.OtherFixedAssets = GetDecimalNullValue(txtOtherFixedAssets.Text.Trim().TrimStart());
                cafnu.Total = GetDecimalNullValue(txtTotal.Text.Trim().TrimStart());
                cafnu.AmountAvailed = GetDecimalNullValue(txtAmountAvailed.Text.Trim().TrimStart());
                cafnu.SanctionOrderNo = txtSanctionOrderNo.Text.Trim().TrimStart();
                cafnu.DateAvailed = GetFromatedDateDDMMYYYY(txtDateAvailed.Text.Trim().TrimStart());
                cafnu.SavingFrom = "FORM";

                string Validstatus = caf.InsertCapitalAssistanceNewUnit(cafnu);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Successfully');", true);
                    Response.Redirect("frmCapitalAssistanceExistingUnit.aspx?next=" + "N");
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
        public void clearControls()
        {
            txtPLExtent.Text = "";
            txtPLValue.Text = "";
            txtLLExtent.Text = "";
            txtLLValue.Text = "";
            txtILExtent.Text = "";
            txtILValue.Text = "";
            txtGLExtent.Text = "";
            txtGLValue.Text = "";
            txtMFSArea.Text = "";
            txtMFSCost.Text = "";
            txtWarehouseArea.Text = "";
            txtWarehouseCost.Text = "";
            txtOfficeArea.Text = "";
            txtOfficeCost.Text = "";
            txtCWPArea.Text = "";
            txtCWPCost.Text = "";
            txtBoilerArea.Text = "";
            txtBoilerCost.Text = "";
            txtETPArea.Text = "";
            txtETPCost.Text = "";
            txtOTArea.Text = "";
            txtOTACost.Text = "";
            txtFGArea.Text = "";
            txtFGCost.Text = "";
            txtAFArea.Text = "";
            txtAFCost.Text = "";
            txtCWArea.Text = "";
            txtCWCost.Text = "";
            txtWQArea.Text = "";
            txtWQCost.Text = "";
            txtCanteenArea.Text = "";
            txtCanteenCost.Text = "";
            txtRHArea.Text = "";
            txtRHCost.Text = "";
            txtTOArea.Text = "";
            txtTOCost.Text = "";
            txtCSArea.Text = "";
            txtCSCost.Text = "";
            txtSSArea.Text = "";
            txtSSCost.Text = "";
            txtToiletArea.Text = "";
            txtToiletCost.Text = "";
            txtRoadsArea.Text = "";
            txtRoadsCost.Text = "";
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
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA", pp);
            return Dsnew;
        }
        public void BindControls()
        {
            DataSet dsnew = new DataSet();
            dsnew = GetapplicationDtls(Session["uid"].ToString(), Session["IncentiveID"].ToString());
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {
                lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();

                //if (dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString() != "1")
                //{
                //    mainheading.InnerHtml = "Form – II: Capital Assistance for Existing Unit";
                //}

                lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                lblcategory.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                lblProjectCost.InnerHtml = dsnew.Tables[0].Rows[0]["TotalInvestment"].ToString();

                string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                if (TypeOfIndustry == "1")
                {
                    lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                }
                else
                {
                    lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                }

                BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));

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
                        btnDetailedproject.Enabled = false;
                        btnApprovalofProject.Enabled = false;
                        btnProjectCompletion.Enabled = false;
                        btnDeclarationstating.Enabled = false;
                        btnlinedepartment.Enabled = false;
                        btnDocumentsevidencing.Enabled = false;
                        btnCharteredEngineerPM.Enabled = false;
                    }
                    else
                    {
                        EnableDisableForm(Page.Controls, true);
                    }
                }

                if (dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString() != "")
                {
                    rdl_TypeofUnit.Enabled = false;
                    rdl_TypeofUnit.SelectedValue = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();
                }
            }

            DataSet dsData = GetCAFNewUnitData(Session["uid"].ToString(), Convert.ToInt32(Session["IncentiveID"].ToString()));
            if (dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    txtPLExtent.Text = dsData.Tables[0].Rows[0]["PurchasedLandExtent"].ToString();
                    txtPLValue.Text = dsData.Tables[0].Rows[0]["PurchasedLandValue"].ToString();
                    txtLLExtent.Text = dsData.Tables[0].Rows[0]["LeasedLandExtent"].ToString();
                    txtLLValue.Text = dsData.Tables[0].Rows[0]["LeasedLandValue"].ToString();
                    txtILExtent.Text = dsData.Tables[0].Rows[0]["InheritedLandExtent"].ToString();
                    txtILValue.Text = dsData.Tables[0].Rows[0]["InheritedLandValue"].ToString();
                    txtGLExtent.Text = dsData.Tables[0].Rows[0]["GovtLandExtent"].ToString();
                    txtGLValue.Text = dsData.Tables[0].Rows[0]["GovtLandValue"].ToString();

                    BindTotalLandValue("1");
                    BindTotalLandValue("2");
                    BindTotalLandValue("3");
                    BindTotalLandValue("4");

                    if(dsData.Tables[0].Rows[0]["Buliding_Type"].ToString()!="")
                    {
                        rdl_Buliding_Type.SelectedValue = dsData.Tables[0].Rows[0]["Buliding_Type"].ToString();
                    }
                    
                    txtMFSArea.Text = dsData.Tables[0].Rows[0]["MainFactoryShedArea"].ToString();
                    txtMFSCost.Text = dsData.Tables[0].Rows[0]["MainFactoryShedCost"].ToString();
                    txtWarehouseArea.Text = dsData.Tables[0].Rows[0]["WarehouseArea"].ToString();
                    txtWarehouseCost.Text = dsData.Tables[0].Rows[0]["WarehouseCost"].ToString();
                    txtOfficeArea.Text = dsData.Tables[0].Rows[0]["OfficeRoomArea"].ToString();
                    txtOfficeCost.Text = dsData.Tables[0].Rows[0]["OfficeRoomCost"].ToString();
                    txtCWPArea.Text = dsData.Tables[0].Rows[0]["CoolingPondsArea"].ToString();
                    txtCWPCost.Text = dsData.Tables[0].Rows[0]["CoolingPondsCost"].ToString();
                    txtBoilerArea.Text = dsData.Tables[0].Rows[0]["BoilerShedArea"].ToString();
                    txtBoilerCost.Text = dsData.Tables[0].Rows[0]["BoilerShedCost"].ToString();
                    txtETPArea.Text = dsData.Tables[0].Rows[0]["EffluentPondsArea"].ToString();
                    txtETPCost.Text = dsData.Tables[0].Rows[0]["EffluentPondsCost"].ToString();
                    txtOTArea.Text = dsData.Tables[0].Rows[0]["OverHeadTankArea"].ToString();
                    txtOTACost.Text = dsData.Tables[0].Rows[0]["OverHeadTankCost"].ToString();
                    txtFGArea.Text = dsData.Tables[0].Rows[0]["FencingArea"].ToString();
                    txtFGCost.Text = dsData.Tables[0].Rows[0]["FencingCost"].ToString();
                    txtAFArea.Text = dsData.Tables[0].Rows[0]["ArchitectFeeArea"].ToString();
                    txtAFCost.Text = dsData.Tables[0].Rows[0]["ArchitectFeeCost"].ToString();
                    txtCWArea.Text = dsData.Tables[0].Rows[0]["CompoundWallArea"].ToString();
                    txtCWCost.Text = dsData.Tables[0].Rows[0]["CompoundWallCost"].ToString();
                    txtWQArea.Text = dsData.Tables[0].Rows[0]["WorksersHouseArea"].ToString();
                    txtWQCost.Text = dsData.Tables[0].Rows[0]["WorkersHouseCost"].ToString();
                    txtCanteenArea.Text = dsData.Tables[0].Rows[0]["CanteenArea"].ToString();
                    txtCanteenCost.Text = dsData.Tables[0].Rows[0]["CanteenCost"].ToString();
                    txtRHArea.Text = dsData.Tables[0].Rows[0]["RestHouseArea"].ToString();
                    txtRHCost.Text = dsData.Tables[0].Rows[0]["RestHouseCost"].ToString();
                    txtTOArea.Text = dsData.Tables[0].Rows[0]["TimeOfficeArea"].ToString();
                    txtTOCost.Text = dsData.Tables[0].Rows[0]["TimeOfficeCost"].ToString();
                    txtCSArea.Text = dsData.Tables[0].Rows[0]["VehicleStandArea"].ToString();
                    txtCSCost.Text = dsData.Tables[0].Rows[0]["VehicleStandCost"].ToString();
                    txtSSArea.Text = dsData.Tables[0].Rows[0]["SecurityShedArea"].ToString();
                    txtSSCost.Text = dsData.Tables[0].Rows[0]["SecurityShedCost"].ToString();
                    txtToiletArea.Text = dsData.Tables[0].Rows[0]["ToiletArea"].ToString();
                    txtToiletCost.Text = dsData.Tables[0].Rows[0]["ToiletCost"].ToString();
                    txtRoadsArea.Text = dsData.Tables[0].Rows[0]["RoadsArea"].ToString();
                    txtRoadsCost.Text = dsData.Tables[0].Rows[0]["RoadsCost"].ToString();

                    txtCurrentClaimAmount.Text = dsData.Tables[0].Rows[0]["CurrentClaimAmount"].ToString();

                    txtLaboratoriesforResearchQualityControl.Text = dsData.Tables[0].Rows[0]["LaboratoriesforResearchQualityControl"].ToString();
                    txtUtilitiesPowerWater.Text = dsData.Tables[0].Rows[0]["UtilitiesPowerWater"].ToString();
                    txtOtherFixedAssets.Text = dsData.Tables[0].Rows[0]["OtherFixedAssets"].ToString();
                    // txtTotal.Text = dsData.Tables[0].Rows[0]["Total"].ToString();
                    txtLaboratoriesforResearchQualityControl_TextChanged(this, EventArgs.Empty);
                    txtAmountAvailed.Text = dsData.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSanctionOrderNo.Text = dsData.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                    txtDateAvailed.Text = dsData.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();
                }
            }

            if (dsData != null && dsData.Tables.Count > 1 && dsData.Tables[1].Rows.Count > 0)
            {
                try
                {
                    int RowsCount = dsData.Tables[1].Rows.Count;
                    string Path, Docid;
                    for (int i = 0; i < RowsCount; i++)
                    {
                        Path = dsData.Tables[1].Rows[i]["link"].ToString();
                        Docid = dsData.Tables[1].Rows[i]["AttachmentId"].ToString();
                        if (!string.IsNullOrEmpty(Path))
                        {
                            if (Docid == "11001")
                            {
                                objClsFileUpload.AssignPath(hyDetailedproject, Path);
                            }
                            else if (Docid == "11002")
                            {
                                objClsFileUpload.AssignPath(hyApprovalofProject, Path);
                            }
                            else if (Docid == "11003")
                            {
                                objClsFileUpload.AssignPath(hyProjectCompletion, Path);
                            }
                            else if (Docid == "11004")
                            {
                                objClsFileUpload.AssignPath(hyDeclarationstating, Path);
                            }
                            else if (Docid == "11005")
                            {
                                objClsFileUpload.AssignPath(hylinedepartment, Path);
                            }
                            else if (Docid == "11006")
                            {
                                objClsFileUpload.AssignPath(hyDocumentsevidencing, Path);
                            }
                            else if (Docid == "11007")
                            {
                                objClsFileUpload.AssignPath(hyCharteredEngineerPM, Path);
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
        public DataSet GetCAFNewUnitData(string UserId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.NVarChar),
               new SqlParameter("@IncentiveId",SqlDbType.Int)
           };
            pp[0].Value = UserId;
            pp[1].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVE_CAF_NEWUNIT", pp);
            return Dsnew;
        }

        public void BindTotalLandValue(string LandTypeSlno)
        {
            Double Extent = 0, LandValue = 0;
            if (LandTypeSlno == "1")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtPLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtPLValue.Text.TrimStart().TrimEnd()));

                lblPLTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "2")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtLLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtLLValue.Text.TrimStart().TrimEnd()));

                lblLLTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "3")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtILExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtILValue.Text.TrimStart().TrimEnd()));

                lblILTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "4")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtGLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtGLValue.Text.TrimStart().TrimEnd()));

                lblGLTotalValue.Text = (Extent * LandValue).ToString();
            }
        }

        protected void txtPLExtent_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("1");
        }

        protected void txtPLValue_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("1");
        }

        protected void txtLLExtent_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("2");
        }

        protected void txtLLValue_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("2");
        }

        protected void txtILExtent_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("3");
        }

        protected void txtILValue_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("3");
        }

        protected void txtGLExtent_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("4");
        }

        protected void txtGLValue_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("4");
        }

        public void BindPandMGrid(int PMId, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetPandM(PMId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdPandM.DataSource = ds.Tables[0];
                    grdPandM.DataBind();
                    Session["MachineCostSum"] = ds.Tables[1].Rows[0]["MachineCostSum"].ToString();

                    decimal TotalValueofNewMachinery = 0, Secondhandmachinery = 0;
                    foreach (GridViewRow gvrow in grdPandM.Rows)
                    {
                        string Value = (gvrow.FindControl("lblMachineCost") as Label).Text;
                        string lblInstalledMachineryText = (gvrow.FindControl("lblInstalledMachineryText") as Label).Text;
                        if (lblInstalledMachineryText.ToUpper() == "NEW")
                        {
                            TotalValueofNewMachinery = TotalValueofNewMachinery + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else
                        {
                            Secondhandmachinery = Secondhandmachinery + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                    }

                    lblTotalValueofNewMachinery.InnerHtml = TotalValueofNewMachinery.ToString();
                    lblSecondhandmachinery.InnerHtml = Secondhandmachinery.ToString();
                }
                else
                {
                    Session["MachineCostSum"] = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPandM(int PMId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@PMId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = PMId;
            Dsnew = caf.GenericFillDs("USP_GET_PLANTANDMACHINERY", pp);
            return Dsnew;
        }

        protected void btnCharteredEngineerPM_Click(object sender, EventArgs e)
        {
            if (fuCharteredEngineerPM.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCharteredEngineerPM);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCharteredEngineerPM);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCharteredEngineerPM, hyCharteredEngineerPM, "CharteredEngineerPM", Session["IncentiveID"].ToString(), "1", "11007", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyCharteredEngineerPM.Visible = true;
                        // ViewState["linedepartment"] = hylinedepartment.NavigateUrl;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select a File!");
            }
        }

        protected void txtLaboratoriesforResearchQualityControl_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (Convert.ToDecimal(GetDecimalNullValue(txtLaboratoriesforResearchQualityControl.Text)) +
            Convert.ToDecimal(GetDecimalNullValue(txtUtilitiesPowerWater.Text)) +
                Convert.ToDecimal(GetDecimalNullValue(txtOtherFixedAssets.Text))).ToString();
        }
    }
}