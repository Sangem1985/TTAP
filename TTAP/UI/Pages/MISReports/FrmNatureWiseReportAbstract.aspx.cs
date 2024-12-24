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

namespace TTAP.UI.Pages.MISReports
{
    public partial class FrmNatureWiseReportAbstract : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        int NoOfUnits;
        int NoOfGinning;
        int NoOfSpinning;
        int NoOfWeaving;
        int NoOfGarmenting;
        int NoOfProcessing;
        int NoOfPressingMills;
        int Others;
        int NoOfUnitsT;
        int NoOfTechnical;
        int NOOfConventional;
        int NoOfUnitsC;
        int A1Category;
        int A2Category;
        int A3Category;
        int A4Category;
        int A5Category;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                        ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        rdbType_SelectedIndexChanged(sender, e);
                        hdnRoleCode.Value = ObjLoginNewvo.Role_Code.ToString();
                        if (hdnRoleCode.Value == "DLO")
                        {
                            GvCategoryGrid.FooterRow.Visible = false;
                            GvTextileGrid.FooterRow.Visible = false;
                            gvdetailsnew.FooterRow.Visible = false;
                        }
                    }
                }
                
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public DataSet GetIncentiveAbstract(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
            pp[1].Value = "";
            Dsnew = caf.GenericFillDs("USP_GET_NATURE_OF_UNIT_ABSTRACT", pp);
            return Dsnew;
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoOfUnits1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnits"));
                NoOfUnits = NoOfUnits1 + NoOfUnits;

                int NoOfGinning1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Ginning"));
                NoOfGinning = NoOfGinning1 + NoOfGinning;

                int NoOfSpinning1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Spinning"));
                NoOfSpinning = NoOfSpinning1 + NoOfSpinning;

                int NoOfWeaving1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Weaving"));
                NoOfWeaving = NoOfWeaving1 + NoOfWeaving;

                int NoOfGarmenting1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Garmenting"));
                NoOfGarmenting = NoOfGarmenting1 + NoOfGarmenting;

                int NoOfProcessing1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Processing"));
                NoOfProcessing = NoOfProcessing1 + NoOfProcessing;

                int NoOfPressingMills1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PressingMills"));
                NoOfPressingMills = NoOfPressingMills1 + NoOfPressingMills;

                int Others1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Others"));
                Others = Others1 + Others;

                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "FormUnitReport.aspx?Level=0&Flag=Z&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "FormUnitReport.aspx?Level=1&Flag=R&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "FormUnitReport.aspx?Level=2&Flag=A&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "FormUnitReport.aspx?Level=3&Flag=D&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "FormUnitReport.aspx?Level=4&Flag=P&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "FormUnitReport.aspx?Level=5&Flag=H&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
                if (h7.Text != "0")
                {
                    h7.NavigateUrl = "FormUnitReport.aspx?Level=6&Flag=H&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
                if (h8.Text != "0")
                {
                    h8.NavigateUrl = "FormUnitReport.aspx?Level=18&Flag=H&DistrictId=" + lblDistrictId.Text.Trim();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoOfUnits.ToString();
                e.Row.Cells[3].Text = NoOfGinning.ToString();
                e.Row.Cells[4].Text = NoOfSpinning.ToString();
                e.Row.Cells[5].Text = NoOfWeaving.ToString();
                e.Row.Cells[6].Text = NoOfGarmenting.ToString();
                e.Row.Cells[7].Text = NoOfProcessing.ToString();
                e.Row.Cells[8].Text = NoOfPressingMills.ToString();
                e.Row.Cells[9].Text = Others.ToString();

                HyperLink h1 = new HyperLink();
                h1.Text = NoOfUnits.ToString();
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "FormUnitReport.aspx?Level=0&Flag=Z&DistrictId=%";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = NoOfGinning.ToString();
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "FormUnitReport.aspx?Level=1&Flag=R&DistrictId=%";
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = NoOfSpinning.ToString();
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "FormUnitReport.aspx?Level=2&Flag=A&DistrictId=%";
                    e.Row.Cells[4].Controls.Add(h3);
                }
                HyperLink h4 = new HyperLink();
                h4.Text = NoOfWeaving.ToString();
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "FormUnitReport.aspx?Level=3&Flag=D&DistrictId=%";
                    e.Row.Cells[5].Controls.Add(h4);
                }
                HyperLink h5 = new HyperLink();
                h5.Text = NoOfGarmenting.ToString();
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "FormUnitReport.aspx?Level=4&Flag=P&DistrictId=%";
                    e.Row.Cells[6].Controls.Add(h5);
                }
                HyperLink h6 = new HyperLink();
                h6.Text = NoOfProcessing.ToString();
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "FormUnitReport.aspx?Level=5&Flag=H&DistrictId=%";
                    e.Row.Cells[7].Controls.Add(h6);
                }
                HyperLink h7 = new HyperLink();
                h7.Text = NoOfPressingMills.ToString();
                if (h7.Text != "0")
                {
                    h7.NavigateUrl = "FormUnitReport.aspx?Level=6&Flag=H&DistrictId=%";
                    e.Row.Cells[8].Controls.Add(h7);
                }
                HyperLink h8 = new HyperLink();
                h8.Text = Others.ToString();
                if (h8.Text != "0")
                {
                    h8.NavigateUrl = "FormUnitReport.aspx?Level=18&Flag=H&DistrictId=%";
                    e.Row.Cells[9].Controls.Add(h8);
                }
            }
        }

        protected void rdbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dss = GetIncentiveAbstract(Session["uid"].ToString());
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = dss;
                    gvdetailsnew.DataBind();
                    GvTextileGrid.DataSource = dss;
                    GvTextileGrid.DataBind();
                    GvCategoryGrid.DataSource = dss;
                    GvCategoryGrid.DataBind();
                }
                if (rdbType.SelectedValue == "T")
                {
                    DivTextile.Visible = true;
                    DivNature.Visible = false;
                    DivCategory.Visible = false;
                }
                 if (rdbType.SelectedValue == "N")
                {
                    DivTextile.Visible = false;
                    DivCategory.Visible = false;
                    DivNature.Visible = true;
                }
                if (rdbType.SelectedValue == "C")
                {
                    DivCategory.Visible = true;
                    DivTextile.Visible = false;
                    DivNature.Visible = false;
                }
                if (hdnRoleCode.Value == "DLO")
                {
                    GvCategoryGrid.FooterRow.Visible = false;
                    GvTextileGrid.FooterRow.Visible = false;
                    gvdetailsnew.FooterRow.Visible = false;
                }
            }
        }
        protected void GvTextileGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoOfUnitsT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnits"));
                NoOfUnitsT = NoOfUnitsT1 + NoOfUnitsT;

                int NoOfTechnical1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Technical"));
                NoOfTechnical = NoOfTechnical1 + NoOfTechnical;

                int NOOfConventional1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Conventional"));
                NOOfConventional = NOOfConventional1 + NOOfConventional;

                

                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "FormUnitReport.aspx?Level=2&Flag=Z&Type=T&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "FormUnitReport.aspx?Level=1&Flag=R&Type=T&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "FormUnitReport.aspx?Level=0&Flag=A&Type=T&DistrictId=" + lblDistrictId.Text.Trim();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoOfUnitsT.ToString();
                e.Row.Cells[3].Text = NoOfTechnical.ToString();
                e.Row.Cells[4].Text = NOOfConventional.ToString();

                HyperLink h1 = new HyperLink();
                h1.Text = NoOfUnitsT.ToString();
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "FormUnitReport.aspx?Level=2&Flag=Z&Type=T&DistrictId=%";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = NoOfTechnical.ToString();
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "FormUnitReport.aspx?Level=1&Flag=R&Type=T&DistrictId=%";
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = NOOfConventional.ToString();
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "FormUnitReport.aspx?Level=0&Flag=A&Type=T&DistrictId=%";
                    e.Row.Cells[4].Controls.Add(h3);
                }
            }
        }

        protected void GvCategoryGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoOfUnitsC1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnits"));
                NoOfUnitsC = NoOfUnitsC1 + NoOfUnitsC;

                int A1Category1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "A1Category"));
                A1Category = A1Category1 + A1Category;

                int A2Category1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "A2Category"));
                A2Category = A2Category1 + A2Category;

                int A3Category1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "A3Category"));
                A3Category = A3Category1 + A3Category;

                int A4Category1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "A4Category"));
                A4Category = A4Category1 + A4Category;

                int A5Category1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "A5Category"));
                A5Category = A5Category1 + A5Category;


                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "FormUnitReport.aspx?Level=0&Flag=Z&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "FormUnitReport.aspx?Level=A1&Flag=CAT&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "FormUnitReport.aspx?Level=A2&Flag=CAT&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "FormUnitReport.aspx?Level=A3&Flag=CAT&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "FormUnitReport.aspx?Level=A4&Flag=CAT&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "FormUnitReport.aspx?Level=A5&Flag=CAT&DistrictId=" + lblDistrictId.Text.Trim();
                }
                
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoOfUnitsC.ToString();
                e.Row.Cells[3].Text = A1Category.ToString();
                e.Row.Cells[4].Text = A2Category.ToString();
                e.Row.Cells[5].Text = A3Category.ToString();
                e.Row.Cells[6].Text = A4Category.ToString();
                e.Row.Cells[7].Text = A5Category.ToString();

                HyperLink h1 = new HyperLink();
                h1.Text = NoOfUnits.ToString();
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "FormUnitReport.aspx?Level=0&Flag=Z&DistrictId=%";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = A1Category.ToString();
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "FormUnitReport.aspx?Level=A1&Flag=CAT&DistrictId=%";
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = A2Category.ToString();
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "FormUnitReport.aspx?Level=A2&Flag=CAT&DistrictId=%";
                    e.Row.Cells[4].Controls.Add(h3);
                }
                HyperLink h4 = new HyperLink();
                h4.Text = A3Category.ToString();
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "FormUnitReport.aspx?Level=A3&Flag=CAT&DistrictId=%";
                    e.Row.Cells[5].Controls.Add(h4);
                }
                HyperLink h5 = new HyperLink();
                h5.Text = A4Category.ToString();
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "FormUnitReport.aspx?Level=A4&Flag=CAT&DistrictId=%";
                    e.Row.Cells[6].Controls.Add(h5);
                }
                HyperLink h6 = new HyperLink();
                h6.Text = A5Category.ToString();
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "FormUnitReport.aspx?Level=A5&Flag=CAT&DistrictId=%";
                    e.Row.Cells[7].Controls.Add(h6);
                }
            }
        }
    }
}