using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages.Releases
{
    public partial class ReleaseProceedingStep2 : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        decimal TotalSanctioned = 0;
        decimal TotalAllotted = 0;
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    string Category = Request.QueryString["Category"].ToString().Trim();
                    string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString().Trim();
                    string GOAmount = Request.QueryString["GOAmount"].ToString().Trim();
                    string GoNo = Request.QueryString["Category"].ToString().Trim();
                    string GoDate = Request.QueryString["Category"].ToString().Trim();
                    string txtLOCNo = Request.QueryString["Category"].ToString().Trim();
                    string LocDate = Request.QueryString["Category"].ToString().Trim();
                    GetYettoReleaseIncentives(Category, SubIncentiveId, GOAmount);
                }

            }
        }
        public void GetYettoReleaseIncentives(string Category, string SubIncentiveId, string GOAmount)
        {
            DataSet ds = new DataSet();
            ds = ObjCAFClass.GetYettoReleaseIncentives(Category, SubIncentiveId, GOAmount);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
            }
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSanctionedAmount = (e.Row.FindControl("lblSanctionedAmount") as Label);
                TextBox txtReleaseAmount = (e.Row.FindControl("txtReleaseAmount") as TextBox);

                decimal TotalSanctioned1 = Convert.ToDecimal(lblSanctionedAmount.Text);
                TotalSanctioned = TotalSanctioned + TotalSanctioned1;

                decimal TotalAllotted1 = Convert.ToDecimal(txtReleaseAmount.Text);
                TotalAllotted = TotalAllotted + TotalAllotted1;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[2].Text = "Total";
                e.Row.Cells[3].Text = TotalSanctioned.ToString("N2");
                e.Row.Cells[5].Text = TotalAllotted.ToString("N2");
            }
            decimal RemainingAmount = Convert.ToDecimal(Request.QueryString["GOAmount"].ToString().Trim()) - TotalAllotted;
            lblRemainingAmount.Text = RemainingAmount.ToString();
        }

        protected void txtReleaseAmount_TextChanged(object sender, EventArgs e)
        {
            decimal totalAllotted = 0;
            decimal totalSanctioned = 0;

            TextBox txtBox = sender as TextBox;
            if (txtBox != null)
            {
                GridViewRow row = (GridViewRow)txtBox.NamingContainer;
                string ReleaseAmount = txtBox.Text;
                Label lblNameofUnit = (Label)row.FindControl("lblNameofUnit");
                Label lblSanctionedAmount = (Label)row.FindControl("lblSanctionedAmount");
                string sanctionedAmount = lblSanctionedAmount?.Text;
                if (Convert.ToDecimal(ReleaseAmount) > Convert.ToDecimal(sanctionedAmount))
                {
                    string message = $"Release Amount Should not more than Sanctioned Amount";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);
                    txtBox.Text = sanctionedAmount;
                    return;
                }
            }

            foreach (GridViewRow row in gvdetailsnew.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Label lblSanctionedAmount = row.FindControl("lblSanctionedAmount") as Label;
                    TextBox txtReleaseAmount = row.FindControl("txtReleaseAmount") as TextBox;

                    if (lblSanctionedAmount != null && decimal.TryParse(lblSanctionedAmount.Text, out decimal sanctioned))
                    {
                        totalSanctioned += sanctioned;
                    }

                    if (txtReleaseAmount != null && decimal.TryParse(txtReleaseAmount.Text, out decimal released))
                    {
                        totalAllotted += released;
                    }
                }
            }

            ViewState["TotalSanctioned"] = totalSanctioned;
            ViewState["TotalAllotted"] = totalAllotted;
            decimal RemainingAmount = Convert.ToDecimal(Request.QueryString["GOAmount"].ToString().Trim()) - totalAllotted;
            lblRemainingAmount.Text = RemainingAmount.ToString();
            RebindGridFooter();
        }
        private void RebindGridFooter()
        {
            if (gvdetailsnew.Rows.Count > 0)
            {
                GridViewRow footer = gvdetailsnew.FooterRow;
                if (footer != null)
                {
                    footer.Font.Bold = true;
                    footer.Cells[2].Text = "Total";

                    if (ViewState["TotalSanctioned"] != null)
                        footer.Cells[3].Text = ((decimal)ViewState["TotalSanctioned"]).ToString("N2");

                    if (ViewState["TotalAllotted"] != null)
                        footer.Cells[5].Text = ((decimal)ViewState["TotalAllotted"]).ToString("N2");
                }
            }
        }

        protected void btnGovermentOrder_Click(object sender, EventArgs e)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\GoCOIIncentiveAttachments");
            General t1 = new General();
            BusinessLogic.DML objDml = new BusinessLogic.DML();

            string MstIncentiveId = "";
            string IncentiveID = "";
            string SLCNumer = string.Empty;

            if (fuGovermentOrder.HasFile)
            {
                if ((fuGovermentOrder.PostedFile != null) && (fuGovermentOrder.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fuGovermentOrder.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fuGovermentOrder.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
                            {
                                SLCNumer = ((Label)gvrow.FindControl("lblSLCNumber")).Text;
                                newPath = System.IO.Path.Combine(sFileDir, SLCNumer);

                                if (!Directory.Exists(newPath))

                                    System.IO.Directory.CreateDirectory(newPath);
                                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);

                                fuGovermentOrder.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            }

                            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
                            {
                                MstIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveId")).Text;
                                IncentiveID = ((Label)gvrow.FindControl("lblIncentiveId")).Text;
                                SLCNumer = ((Label)gvrow.FindControl("lblSLCNumber")).Text;
                                newPath = System.IO.Path.Combine(sFileDir, SLCNumer);
                                if (MstIncentiveId != "" && IncentiveID != "" && SLCNumer != "")
                                {
                                    objDml.InsUpdCOI_Incentive_Attachments(2, Convert.ToInt32(IncentiveID), Convert.ToInt32(MstIncentiveId), Convert.ToInt32(SLCNumer), sFileName, newPath, Convert.ToInt32(Session["uid"].ToString()));
                                }
                            }

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            hyGovermentOrder.Text = fuGovermentOrder.FileName;
                            hyGovermentOrder.NavigateUrl = "~\\GoCOIIncentiveAttachments" + "/" + SLCNumer + "/" + sFileName;
                            success.Visible = true;
                            Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
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
                List<ReleasingProceedings> lstincentives = new List<ReleasingProceedings>();

                foreach (GridViewRow gvrow in gvdetailsnew.Rows)
                {
                    ReleasingProceedings objrp = new ReleasingProceedings();
                    string lblSubIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveId")).Text;
                    string lblIncentiveId = ((Label)gvrow.FindControl("lblIncentiveId")).Text;
                    string lblSanctionedAmount = ((Label)gvrow.FindControl("lblSanctionedAmount")).Text;
                    string lblSLCNumber = ((Label)gvrow.FindControl("lblSLCNumber")).Text;
                    string txtReleaseAmount = ((TextBox)gvrow.FindControl("txtReleaseAmount")).Text;
                    string lblIsPartial = ((Label)gvrow.FindControl("lblIsPartial")).Text;
                    string IsPartial = "";
                    if (lblIsPartial == "N")
                    {
                        if (Convert.ToDecimal(txtReleaseAmount) < Convert.ToDecimal(lblSanctionedAmount))
                        {
                            IsPartial = "Y";
                        }
                    }
                    else
                    {
                        IsPartial = "Y";
                    }
                    objrp.EnterperIncentiveID = lblIncentiveId;
                    objrp.MstIncentiveId = lblSubIncentiveId;
                    objrp.CreatedByid = Session["uid"].ToString();
                    objrp.SantionedAmount = lblSanctionedAmount;
                    objrp.AllotedAmount = txtReleaseAmount;
                    objrp.SLCNo = lblSLCNumber;
                    objrp.IsPartial = IsPartial;

                    string txtGoNo = Session["GoNo"].ToString();
                    string txtGodate = Session["Godate"].ToString();
                    string txtLocno = Session["Locno"].ToString();
                    string txtLocdate = Session["Locdate"].ToString();

                    string[] godatett = txtGodate.Split('/');
                    string[] locdate = txtLocdate.Split('/');
                    string[] releaseProDate = txtReleaseProceedingDate.Text.Split('/');

                    objrp.Godate = godatett[2] + "/" + godatett[1] + "/" + godatett[0];
                    objrp.Locdate = locdate[2] + "/" + locdate[1] + "/" + locdate[0];
                    objrp.Gono = txtGoNo;
                    objrp.Locno = txtLocno;
                    objrp.ReleaseProcedingNo = txtReleaseProceedingNumber.Text.Trim();
                    objrp.ReleaseProcedingDate = releaseProDate[2] + "/" + releaseProDate[1] + "/" + releaseProDate[0];
                    objrp.Caste = Request.QueryString["Category"].ToString().Trim();
                    objrp.RemaningAmt = lblRemainingAmount.Text;
                    objrp.GoReleaseAmt = Request.QueryString["GOAmount"].ToString().Trim();
                    if (chkIsSpecialUnit.Checked==true)
                    {
                        objrp.SplCase = "Y";
                    }

                    lstincentives.Add(objrp);
                }

                int valid = ObjCAFClass.InsertFinalProceedingsStep2(lstincentives);

                if (valid == 1)
                {
                    string message = "alert('Amount alloted Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    trprint.Visible = true;
                    btnSubmit.Enabled = false;
                    Failure.Visible = false;
                    /* foreach (GridViewRow gvrow1 in GVIncentive.Rows)
                     {
                         string mobileNumber = ((Label)gvrow1.FindControl("lblUnitMObileNo")).Text;
                         string Applicationno = ((Label)gvrow1.FindControl("lblApplicationno")).Text;
                         string ApplicantName = ((Label)gvrow1.FindControl("lblApplicantName")).Text;
                         string incentiveNo = ((Label)gvrow1.FindControl("lblIncentiveID")).Text;
                         string Mstid = ((Label)gvrow1.FindControl("lblMstIncentiveId")).Text;

                         if (mobileNumber != "NA" && mobileNumber != "1234567890")
                         {
                             string checkingVal = MsgMobile(mobileNumber, Applicationno, ApplicantName);
                             if (checkingVal.Contains("402"))
                             {
                                 SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString);
                                 osqlConnection.Open();
                                 SqlCommand cmd = new SqlCommand("USP_releaseDocSMS_slc", osqlConnection);
                                 cmd.CommandType = CommandType.StoredProcedure;
                                 cmd.Parameters.AddWithValue("@mstid", Mstid);
                                 cmd.Parameters.AddWithValue("@incid", incentiveNo);
                                 cmd.ExecuteNonQuery();
                                 osqlConnection.Close();
                             }
                         }
                     }*/

                }
                else
                {
                    trprint.Visible = false;
                    btnSubmit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.ToString();
                success.Visible = false;
                Failure.Visible = true;
            }
        }

        protected void chkIsSpecialUnit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsSpecialUnit.Checked == true)
                {
                    divSpecialCase.Visible = true;
                    divSacnctionINC.Visible = false;
                    divReleaseProceeding.Visible = false;
                    divRemaining.Visible = false;
                    BindDistricts();
                    BindSlcNos(ddlSLCNO);
                    divReleaseAmount.Visible = true;

                    string GOAmount = Request.QueryString["GOAmount"] != null
                        ? Request.QueryString["GOAmount"].Trim()
                        : string.Empty;

                    lblSpecialcaseRelease.Text = GOAmount;


                }
                else
                {
                    divSpecialCase.Visible = false;
                    divReleaseAmount.Visible = false;
                    divSacnctionINC.Visible = true;
                    divReleaseProceeding.Visible = true;
                    divRemaining.Visible = true;
                    trUnitresult.Visible = false;
                    trselectedcases.Visible = false;
                    trprint.Visible = false;
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.ToString();
                success.Visible = false;
                Failure.Visible = true;
            }
        }
        public void BindDistricts()
        {
            dss = GetDistrictsList();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dss;
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataBind();
                AddSelect(ddlDistrict);
            }
            else
            {
                AddSelect(ddlDistrict);
            }
        }
        public DataSet GetDistrictsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("GetDistrictsHYD");
            return Dsnew;
        }
        public void AddSelect(DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
        private void BindSlcNos(DropDownList ddlSLCNO)
        {
            try
            {
                ddlSLCNO.Items.Clear();
                string Cast = Request.QueryString["Category"].ToString().Trim();
                string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString().Trim();
                dss = ObjCAFClass.GetIncentiveSLCNO(Cast, SubIncentiveId);
                if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                {
                    ddlSLCNO.DataSource = dss.Tables[0];
                    ddlSLCNO.DataValueField = "Meeting_No";
                    ddlSLCNO.DataTextField = "Meeting_No";
                    ddlSLCNO.DataBind();
                    ddlSLCNO.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlSLCNO.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.ToString();
                success.Visible = false;
                Failure.Visible = true;
            }
        }

        protected void chkSameUnit_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
                BindSecondaryGrid();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.ToString();
                success.Visible = false;
                Failure.Visible = true;
            }
        }

        protected void btnSpecialCase_Click(object sender, EventArgs e)
        {
            try
            {
                int valid = 0;
                string Category = Request.QueryString["Category"].ToString().Trim();
                string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString().Trim();

                if (txtUnitName.Text.Trim() == "")
                {
                    lblmsg0.Text += "Please enter Unit Name" + "<br/>";
                    valid = 1;
                }
                if (ddlDistrict.SelectedItem.Text == "--Select--")
                {
                    lblmsg0.Text += "Please Select District" + "<br/>";
                    valid = 1;
                }
                if (ddlSLCNO.SelectedItem.Text == "--Select--")
                {
                    lblmsg0.Text += "Please Select SLC No" + "<br/>";
                    valid = 1;
                }

                if (valid == 0)
                {
                    dss = ObjCAFClass.GetIncentiveReleaseProcess(ddlSLCNO.SelectedValue, ddlDistrict.SelectedValue, txtUnitName.Text.Trim(), SubIncentiveId, Category);
                    if (dss != null && dss.Tables.Count > 0)
                    {
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            GVSpecialCase.DataSource = dss.Tables[0];
                            GVSpecialCase.DataBind();
                            trUnitresult.Visible = true;
                            divSpecialCase.Visible = true;
                            divReleaseAmount.Visible = true;
                            Failure.Visible=false;
                        }
                        else
                        {
                            GVSpecialCase.DataSource = dss.Tables[0];
                            GVSpecialCase.DataBind();
                            Failure.Visible = true;
                            lblmsg0.Text = "No Details Found ";
                            divSpecialCase.Visible = true;
                            divReleaseAmount.Visible = true;
                            trUnitresult.Visible = false;

                        }
                    }
                    else
                    {
                        GVSpecialCase.DataSource = null;
                        GVSpecialCase.DataBind();
                        // grdDetails.DataSource = null;
                        // grdDetails.DataBind();
                        Failure.Visible = true;
                        lblmsg0.Text = "No Details Found ";
                        divSpecialCase.Visible = true;
                        divReleaseAmount.Visible = true;
                        trUnitresult.Visible = false;
                    }

                }
                else
                {
                    Failure.Visible = true;
                    GVSpecialCase.DataSource = null;
                    GVSpecialCase.DataBind();
                    //grdDetails.DataSource = null;
                    //grdDetails.DataBind();
                    Failure.Visible = true;
                    divSpecialCase.Visible = true;
                    divReleaseAmount.Visible = true;
                    trUnitresult.Visible = false;
                }
                ddlDistrict.ClearSelection();
                ddlSLCNO.ClearSelection();
                txtUnitName.Text = "";
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.ToString();
                success.Visible = false;
                Failure.Visible = true;
            }
        }

        protected void GVSpecialCase_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if ((e.Row.RowType == DataControlRowType.DataRow))
                {
                    Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                    Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);

                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
        private void GetData()
        {
            DataTable dt;
            if (ViewState["SelectedRecords"] != null)
                dt = (DataTable)ViewState["SelectedRecords"];
            else
                dt = CreateDataTable();
            // CheckBox chkAll = (CheckBox)gvData2.HeaderRow.Cells[0].FindControl("chkAll");
            for (int i = 0; i < GVSpecialCase.Rows.Count; i++)
            {

                decimal enterid = Convert.ToDecimal(GVSpecialCase.Rows[i].Cells[5].Text.ToString());
                CheckBox chk = (CheckBox)GVSpecialCase.Rows[i]
                                .Cells[0].FindControl("chkSameUnit");
                if (chk.Checked)
                {
                    decimal GORelAmt = Convert.ToDecimal(Request.QueryString[2].ToString());
                    if (lblSpecialcaseRelease.Text == "")
                    {
                        lblSpecialcaseRelease.Text = GORelAmt.ToString();
                    }
                    decimal SanAmt = enterid;

                    dt = AddRow(GVSpecialCase.Rows[i], dt);
                    if (AddStatus == 1)
                    {
                        if (lblSpecialcaseRelease.Text != "")
                        {
                            lblSpecialcaseRelease.Text = (Convert.ToDecimal(lblSpecialcaseRelease.Text) - enterid).ToString();
                        }
                    }

                }
                else
                {
                    dt = RemoveRow(GVSpecialCase.Rows[i], dt);
                    if (RemoveStatus == 1)
                    {
                        if (lblSpecialcaseRelease.Text != "")
                        {
                            lblSpecialcaseRelease.Text = (Convert.ToDecimal(lblSpecialcaseRelease.Text) + enterid).ToString();
                        }
                    }
                }
            }
            ViewState["SelectedRecords"] = dt;
        }
        int AddStatus = 0;
        int RemoveStatus = 0;
        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NameofUnit");
            dt.Columns.Add("Address");
            dt.Columns.Add("SanctionedAmount");
            dt.Columns.Add("DCP");
            dt.Columns.Add("SanctionedDate");
            dt.Columns.Add("SLCNumer");
            dt.Columns.Add("EnterperIncentiveID");
            dt.Columns.Add("MstIncentiveId");
            dt.Columns.Add("IsPartial");
            dt.Columns.Add("IncentiveName");
            //dt.Columns.Add("FinalSanctionedAmount");     
            //dt.Columns.Add("IsPartial");
            //dt.Columns.Add("IncentiveName");
            //here only 11 are there

            dt.AcceptChanges();
            return dt;

        }
        private DataTable AddRow(GridViewRow gvRow, DataTable dt)
        {

            Label enterid = (gvRow.FindControl("lblIncentiveID") as Label);
            Label lblMstIncentiveId = (gvRow.FindControl("lblMstIncentiveId") as Label);
            Label lblIncentiveID = (gvRow.FindControl("lblIncentiveID") as Label);
            Label lblSLCNumer = (gvRow.FindControl("lblSLCNumer") as Label);
            Label lblUnitMObileNo = (gvRow.FindControl("lblUnitMObileNo") as Label);
            Label lblApplicationno = (gvRow.FindControl("lblApplicationno") as Label);
            Label lblApplicantName = (gvRow.FindControl("lblApplicantName") as Label);
          //  TextBox txtRelaseamount = (gvRow.FindControl("txtReleaseAmount") as TextBox);
           Label lblpartial = (gvRow.FindControl("lblIsPartial") as Label);
            Label lblINCName = (gvRow.FindControl("lblINCName") as Label);

            DataRow[] dr = dt.Select("EnterperIncentiveID = '" + enterid.Text + "'");
            if (dr.Length <= 0)
            {
                dt.Rows.Add();
                dt.Rows[dt.Rows.Count - 1]["NameofUnit"] = gvRow.Cells[2].Text;
                dt.Rows[dt.Rows.Count - 1]["Address"] = gvRow.Cells[3].Text;
                dt.Rows[dt.Rows.Count - 1]["DCP"] = gvRow.Cells[4].Text;

                dt.Rows[dt.Rows.Count - 1]["SanctionedAmount"] = gvRow.Cells[5].Text;
                dt.Rows[dt.Rows.Count - 1]["SanctionedDate"] = gvRow.Cells[6].Text;

                //dt.Rows[dt.Rows.Count - 1]["SanctionedAmount"] = txtRelaseamount.Text;
               // dt.Rows[dt.Rows.Count - 1]["AllotedAmount"] = gvRow.Cells[5].Text;


                dt.Rows[dt.Rows.Count - 1]["MstIncentiveId"] = lblMstIncentiveId.Text;
                dt.Rows[dt.Rows.Count - 1]["EnterperIncentiveID"] = lblIncentiveID.Text;
                dt.Rows[dt.Rows.Count - 1]["SLCNumer"] = lblSLCNumer.Text;
                dt.Rows[dt.Rows.Count - 1]["IncentiveName"] = lblINCName.Text; //gvRow.Cells[8].Text;//lblINCName.Text;
                dt.Rows[dt.Rows.Count - 1]["IsPartial"] = lblpartial.Text;
              // dt.Rows[dt.Rows.Count - 1]["ApplicantName"] = lblApplicantName.Text;




                dt.AcceptChanges();
                AddStatus = 1;
            }
            else
            {
                AddStatus = 0;
            }

            return dt;
        }

        private DataTable RemoveRow(GridViewRow gvRow, DataTable dt)
        {
            Label enterid = (gvRow.FindControl("lblIncentiveID") as Label);
            DataRow[] dr = dt.Select("EnterperIncentiveID = '" + enterid.Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
                RemoveStatus = 1;
            }
            else
            {
                RemoveStatus = 0;
            }
            return dt;
        }
        private void BindSecondaryGrid()
        {
            DataTable dt = (DataTable)ViewState["SelectedRecords"];

            if (dt.Rows.Count > 0)
            {
                btnNext.Visible = true;
                GVSpecialCase2.DataSource = dt;
                GVSpecialCase2.DataBind();
                trselectedcases.Visible = true;
                btnNext.Visible = true;
                trprint.Visible = true;
            }
            else
            {
                GVSpecialCase2.DataSource = null;
                GVSpecialCase2.DataBind();
                btnNext.Visible = false;
                trselectedcases.Visible = false;
                btnNext.Visible = false;
                trprint.Visible = false;

            }
        }

        protected void GVSpecialCase2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label lblIncentiveID = GVSpecialCase2.Rows[e.RowIndex].FindControl("lblIncentiveID") as Label;
            decimal enterid = Convert.ToDecimal(GVSpecialCase2.Rows[e.RowIndex].Cells[4].Text.ToString());
            DataTable dt = (DataTable)ViewState["SelectedRecords"];

            DataRow[] dr = dt.Select("IncentiveID = '" + lblIncentiveID.Text + "'");
            if (dr.Length > 0)
            {
                dt.Rows.Remove(dr[0]);
                dt.AcceptChanges();
                ViewState["SelectedRecords"] = dt;
                uncheck(lblIncentiveID.Text);
                if (lblSpecialcaseRelease.Text != "")
                {
                    lblSpecialcaseRelease.Text = (Convert.ToDecimal(lblSpecialcaseRelease.Text) + enterid).ToString();
                }
            }
            BindSecondaryGrid();
        }
        public void uncheck(string str)
        {
            for (int i = 0; i < GVSpecialCase.Rows.Count; i++)
            {
                Label lblIncentiveID = GVSpecialCase.Rows[i].Cells[0].FindControl("lblIncentiveID") as Label;
                CheckBox chk = (CheckBox)GVSpecialCase.Rows[i].Cells[0].FindControl("chkSameUnit");
                if (lblIncentiveID.Text == str)
                {
                    if (chk.Checked)
                    {
                        chk.Checked = false;
                    }
                }
            }

        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();

                dt1 = ViewState["SelectedRecords"] as DataTable;

                string Category = Request.QueryString["Category"].ToString().Trim();
                string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString().Trim();
                // string GOAmount = Request.QueryString["GOAmount"].ToString().Trim();
                string GOAmount = string.Format("{0:C0}", lblSpecialcaseRelease.Text);
                // Label lblIncentiveID = FindControl("lblIncentiveID") as Label;


                h1heading.InnerText = Category + " Category";
                // DataSet ds = new DataSet();
                dss = ObjCAFClass.GetReleaseProceedingsStep2(Category, SubIncentiveId, GOAmount);
                if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0 && chkIsSpecialUnit.Checked == false)
                {
                    dt2 = dss.Tables[0];
                    string incentivename = dss.Tables[0].Rows[0][3].ToString();

                    //foreach (DataRow row in dt1.Rows)
                    //{
                    //    row["IncentiveName"] = incentivename;
                    //}
                    //dt1.AcceptChanges();
                    if (!chkIsSpecialUnit.Checked)
                    {
                        dt1.Merge(dt2, true, MissingSchemaAction.Ignore);
                        lblRemainingAmount.Text = dss.Tables[1].Rows[0]["RemainingAmount"].ToString();
                    }
                    tdinvestments.InnerHtml = "--> " + dss.Tables[0].Rows[0]["IncentiveName"].ToString();

                    gvdetailsnew.DataSource = dt1;
                    gvdetailsnew.DataBind();

                    dt1.Clear();
                    dt2.Clear();
                    divSacnctionINC.Visible = true;
                    divSpecialCase.Visible = false;
                    trselectedcases.Visible = true;
                    divReleaseAmount.Visible = false;

                    chkIsSpecialUnit.Enabled = false;

                    foreach (GridViewRow row in GVSpecialCase2.Rows)
                    {
                        row.FindControl("anchortaglinkDelete").Visible = false;
                    }
                    btnNext.Visible = false;
                    trUnitresult.Visible = false;

                }
                else if (chkIsSpecialUnit.Checked == true)
                {
                    //string incentivename = "";
                    int rowIndex = 0;
                    Label lblIncentivename = gvdetailsnew.Rows[rowIndex].FindControl("lblINCName") as Label;

                    dss = ObjCAFClass.GetIncentiveNamebyId(SubIncentiveId);
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                    {
                        SubIncentiveId = dss.Tables[0].Rows[0]["IncentiveName"].ToString();

                    }
                    //foreach (DataRow row in dt1.Rows)
                    //{
                    //    row["IncentiveName"] = lblIncentivename;
                    //}
                    //dt1.AcceptChanges();


                    tdinvestments.InnerText = "--> " + dss.Tables[0].Rows[0]["IncentiveName"].ToString();
                    gvdetailsnew.DataSource = dt1;
                    gvdetailsnew.DataBind();

                    lblRemainingAmount.Text = lblSpecialcaseRelease.Text;

                    dt1.Clear();
                    divSacnctionINC.Visible = true;
                    divSpecialCase.Visible = false;
                    trselectedcases.Visible = true;
                    divReleaseAmount.Visible = false;

                    chkIsSpecialUnit.Enabled = false;

                    foreach (GridViewRow row in GVSpecialCase2.Rows)
                    {
                        row.FindControl("anchortaglinkDelete").Visible = false;
                    }
                    btnNext.Visible = false;
                    trUnitresult.Visible = false;
                    divReleaseProceeding.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }

        protected void GVSpecialCase2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            decimal GOAmount = Convert.ToDecimal(Request.QueryString["GOAmount"].ToString().Trim());
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
              
            }
        }

        /* protected void btnReleaseProceding_Click(object sender, EventArgs e)
         {
             try
             {
                 List<ReleasingProceedings> lstincentives = new List<ReleasingProceedings>();
                 foreach (GridViewRow gvrow in GVIncentive.Rows)
                 {
                     ReleasingProceedings frmvo = new ReleasingProceedings();

                     string lblMstIncentiveId = ((Label)gvrow.FindControl("lblMstIncentiveId")).Text;
                     string lblIncentiveID = ((Label)gvrow.FindControl("IncentiveID")).Text;
                     string lblAllotedAmount = Request.QueryString["GOAmount"].ToString().Trim();
                     //((Label)gvrow.FindControl("lblAllotedAmount")).Text;
                     string lblSLCNumer = ((Label)gvrow.FindControl("lblSLCNumer")).Text;
                     string mobileNumber = ((Label)gvrow.FindControl("lblUnitMObileNo")).Text;

                     frmvo.EnterperIncentiveID = lblIncentiveID;
                     frmvo.MstIncentiveId = lblMstIncentiveId;
                     frmvo.CreatedByid = Session["uid"].ToString();
                     frmvo.AllotedAmount = lblAllotedAmount;
                     frmvo.SLCNo = lblSLCNumer;

                     string txtGoNo = Session["txtGoNo"].ToString();
                     string txtGodate = Session["txtGodate"].ToString();
                     string txtLocno = Session["txtLocno"].ToString();
                     string txtLocdate = Session["txtLocdate"].ToString();

                     string[] godatett = txtGodate.Split('/');
                     string[] locdate = txtLocdate.Split('/');
                     string[] releaseProDate = txtRelProDate.Text.Split('/');

                     frmvo.Godate = godatett[2] + "/" + godatett[1] + "/" + godatett[0];
                     frmvo.Locdate = locdate[2] + "/" + locdate[1] + "/" + locdate[0];
                     frmvo.Gono = txtGoNo;
                     frmvo.Locno = txtLocno;
                     frmvo.ReleaseProcedingNo = txtRelProNo.Text.Trim();
                     frmvo.ReleaseProcedingDate = releaseProDate[2] + "/" + releaseProDate[1] + "/" + releaseProDate[0];
                     frmvo.Caste = Request.QueryString["Category"].ToString().Trim();
                     frmvo.SubIncTypeId = Request.QueryString["SubIncentiveId"].ToString().Trim();
                     frmvo.RemaningAmt = lblremaingAmount.Text;
                     frmvo.GoReleaseAmt = Request.QueryString["GOAmount"].ToString().Trim();

                     if (chkIsSpecialUnit.Checked == true)
                     {
                         frmvo.SplCase = "Y";
                     }
                     lstincentives.Add(frmvo);
                 }

                 int valid = ObjCAFClass.InsertFinalProceedingsStep2(lstincentives);


                 if (valid == 1)
                 {
                     //lblmsg.Text = "<font color='green'>Application Submitted Successfully..!</font>";
                     //success.Visible = true;
                     //Failure.Visible = false;
                     //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Successfully');", true);
                     string message = "alert('Amount alloted Successfully')";
                     ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                     trprint.Visible = true;
                     btnReleaseProceding.Enabled = false;
                     /* foreach (GridViewRow gvrow1 in GVIncentive.Rows)
                      {
                          string mobileNumber = ((Label)gvrow1.FindControl("lblUnitMObileNo")).Text;
                          string Applicationno = ((Label)gvrow1.FindControl("lblApplicationno")).Text;
                          string ApplicantName = ((Label)gvrow1.FindControl("lblApplicantName")).Text;
                          string incentiveNo = ((Label)gvrow1.FindControl("lblIncentiveID")).Text;
                          string Mstid = ((Label)gvrow1.FindControl("lblMstIncentiveId")).Text;

                          if (mobileNumber != "NA" && mobileNumber != "1234567890")
                          {
                              string checkingVal = MsgMobile(mobileNumber, Applicationno, ApplicantName);
                              if (checkingVal.Contains("402"))
                              {
                                  SqlConnection osqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[""].ConnectionString);
                                  osqlConnection.Open();
                                  SqlCommand cmd = new SqlCommand("USP_releaseDocSMS_slc", osqlConnection);
                                  cmd.CommandType = CommandType.StoredProcedure;
                                  cmd.Parameters.AddWithValue("@mstid", Mstid);
                                  cmd.Parameters.AddWithValue("@incid", incentiveNo);
                                  cmd.ExecuteNonQuery();
                                  osqlConnection.Close();
                              }
                          }
                      }

                 }
                 else
                 {
                     trprint.Visible = false;
                     btnReleaseProceding.Enabled = true;
                 }
             }
             catch (Exception ex)
             {
                 lblmsg0.Text = ex.Message;
                 Failure.Visible = true;
                 success.Visible = false;
             }
         } */
    }
}