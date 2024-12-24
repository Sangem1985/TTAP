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
    public partial class frmGoReleaseRegistration : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
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
                        BindFundReleaseDetails();
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
        public DataSet GetFundRegistrationDtls(string USERID, string FundID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = FundID;
            Dsnew = ObjCAFClass.GenericFillDs("", pp);
            return Dsnew;
        }

        protected void btnPaymentProof_Click(object sender, EventArgs e)
        {
            if (fuPaymentProof.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuPaymentProof);
                if (Mimetype == "application/pdf")
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    string Investmentid = DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    string Filesavepath = "~";//
                    Filesavepath = Filesavepath + "\\GOFundReleaseDoc";

                    string ServerFlag = "N";//ConfigurationManager.AppSettings["FTPFlag"].ToString();
                    string FilesavepathNew = Filesavepath;
                    if (ServerFlag == "N")
                    {
                        FilesavepathNew = Server.MapPath(Filesavepath);
                    }
                    string OutPut = objClsFileUpload.IncentiveFileUploadingQuery(Filesavepath, FilesavepathNew, fuPaymentProof, hyPaymentProof, ObjLoginNewvo.Role_Code + "GOFundRelease", "0", Investmentid, "911123", Session["uid"].ToString(), "OFFICER", "0", "GO");
                    if (OutPut != "0")
                    {
                        ViewState["DOCID"] = OutPut;
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
            else
            {
                MessageBox("Select a Pdf File!");
            }
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {

        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
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
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (ViewState["GOID"] == null)
            {
                ViewState["GOID"] = "0";
            }

            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                GOUploads ObjGOUploads = new GOUploads();
                ObjGOUploads.GOID = ViewState["GOID"].ToString();
                ObjGOUploads.TransType = "INS";

                ObjGOUploads.GONo = txtGONo.Text.Trim().TrimStart();
                ObjGOUploads.GODate = GetFromatedDateDDMMYYYY(txtGODate.Text.Trim().TrimStart());
                ObjGOUploads.LOCNo = txtLOCNo.Text.Trim().TrimStart();
                ObjGOUploads.LOCDate = GetFromatedDateDDMMYYYY(txtLOCDate.Text.Trim().TrimStart());
                ObjGOUploads.AmountReleased = GetDecimalNullValue(txtGOAmountReleased.Text.Trim().TrimStart());
                ObjGOUploads.GOPathID = ViewState["DOCID"].ToString();
                ObjGOUploads.CreatedBy = ObjLoginNewvo.uid;
                ObjGOUploads.Remarks = txtRemarks.Text.ToString();

                string OutPut = ObjCAFClass.GOfundRegistration(ObjGOUploads);
                if (OutPut != "0")
                {
                    BtnSubmit.Text = "Submit";
                    ViewState["GOID"] = "0";

                    txtGONo.Text = "";
                    txtGODate.Text = "";
                    txtLOCNo.Text = "";
                    txtLOCDate.Text = "";
                    txtGOAmountReleased.Text = "";

                    BindFundReleaseDetails();

                    string Successmsg = "Submitted Successfully";
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    BindFundReleaseDetails();
                    lblmsg.Text = Successmsg;
                    Failure.Visible = false;
                    success.Visible = true;
                }
                else
                {
                    string message = "alert('Data Not Saved')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
        }

        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtGONo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter G.O No\\n";
                slno = slno + 1;
            }

            if (txtGODate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select G.O Date\\n";
                slno = slno + 1;
            }
            else
            {
                string[] Date = txtGODate.Text.Trim().Split('/');
                DateTime Todate = Convert.ToDateTime(Date[2] + "/" + Date[1] + "/" + Date[0]);
                DateTime fromdate = DateTime.Now;
                if (Todate > fromdate)
                {
                    ErrorMsg = ErrorMsg + slno + ".G.O Date Cannot be Future Date\\n";
                    slno = slno + 1;
                }
            }


            if (txtLOCNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter LOC No\\n";
                slno = slno + 1;
            }

            if (txtLOCDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select LOC Date\\n";
                slno = slno + 1;
            }
            else
            {
                string[] Date = txtLOCDate.Text.Trim().Split('/');
                DateTime Todate = Convert.ToDateTime(Date[2] + "/" + Date[1] + "/" + Date[0]);
                DateTime fromdate = DateTime.Now;
                if (Todate > fromdate)
                {
                    ErrorMsg = ErrorMsg + slno + ". LOC Date Cannot be Future Date\\n";
                    slno = slno + 1;
                }
            }
            if (txtGOAmountReleased.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Released Amount\\n";
                slno = slno + 1;
            }

            if (hyPaymentProof.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload G.O\\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }

        protected void BindFundReleaseDetails()
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetGoFundReleaseDetails();

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = dsnew.Tables[0];
                    gvDetails.DataBind();
                }
                else
                {
                    gvDetails.DataSource = null;
                    gvDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetGoFundReleaseDetails()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_GO_DTLS");
            return Dsnew;
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                txtGONo.Text = ((Label)(gr.FindControl("lblGONo"))).Text;
                txtGODate.Text = ((Label)(gr.FindControl("lblGODate"))).Text;
                txtLOCNo.Text = ((Label)(gr.FindControl("lblLOCNo"))).Text;
                txtLOCDate.Text = ((Label)(gr.FindControl("lblLOCDate"))).Text;
                txtGOAmountReleased.Text = ((Label)(gr.FindControl("lblTotalSaleValue"))).Text;
                hyPaymentProof.NavigateUrl = ((HyperLink)(gr.FindControl("hyQueryLetter"))).NavigateUrl;
                ViewState["GOID"] = ((Label)(gr.FindControl("lblGOID"))).Text;
                BtnSubmit.Text = "Update";

            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                GOUploads objGOUploads = new GOUploads();
                objGOUploads.GOID = ((Label)(gr.FindControl("lblGOID"))).Text;
                objGOUploads.TransType = "DLT";
                objGOUploads.CreatedBy = ObjLoginNewvo.uid;

                string Validstatus = ObjCAFClass.GOfundRegistration(objGOUploads); ;
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    BtnSubmit.Text = "Submit";
                    ViewState["GOID"] = "0";

                    
                    txtGONo.Text = "";
                    txtGODate.Text = "";
                    txtLOCNo.Text = "";
                    txtLOCDate.Text = "";
                    txtGOAmountReleased.Text = "";

                    BindFundReleaseDetails();

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
    }
}