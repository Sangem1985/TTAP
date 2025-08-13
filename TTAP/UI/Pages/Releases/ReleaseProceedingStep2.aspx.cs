using System;
using System.Collections.Generic;
using System.Data;
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

                    lstincentives.Add(objrp);
                }

                int valid = ObjCAFClass.InsertFinalProceedingsStep2(lstincentives);
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

            }
            catch(Exception ex)
            {
                lblmsg0.Text = ex.ToString();
                success.Visible = false;
                Failure.Visible = true;
            }
        }
    }
}