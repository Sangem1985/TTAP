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
    public partial class frmIncentiveAbstract : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        int IncompleteApplications, NoofapplicationsSubmitted, ScritinyPending ,YetToVerifyPayment, PaymentVerified, PENDINGATDLO, PENDINGATAPPLICANT, PENDINGATHO, REJECTED;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";

                        dss = GetIncentiveAbstract(Session["uid"].ToString());
                        if (dss.Tables.Count > 0)
                        {
                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                gvdetailsnew.DataSource = dss;
                                gvdetailsnew.DataBind();
                            }
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
               new SqlParameter("@USERID",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
          
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVE_ABSTRACT", pp);

            return Dsnew;
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int IncompleteApplications1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IncompleteApplications"));
                IncompleteApplications = IncompleteApplications1 + IncompleteApplications;

                int NoofapplicationsSubmitted1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofapplicationsSubmitted"));
                NoofapplicationsSubmitted = NoofapplicationsSubmitted1 + NoofapplicationsSubmitted;


                int YetToVerifyPayment1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "YetToVerifyPayment"));
                YetToVerifyPayment = YetToVerifyPayment1 + YetToVerifyPayment;

                int ScritinyPending1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ScritinyPending"));
                ScritinyPending = ScritinyPending1 + ScritinyPending;

                int PaymentVerified1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PaymentVerified"));
                PaymentVerified = PaymentVerified1 + PaymentVerified;

                int PENDINGATDLO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDINGATDLO"));
                PENDINGATDLO = PENDINGATDLO1 + PENDINGATDLO;

                int PENDINGATAPPLICANT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDINGATAPPLICANT"));
                PENDINGATAPPLICANT = PENDINGATAPPLICANT1 + PENDINGATAPPLICANT;

                int PENDINGATHO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDINGATHO"));
                PENDINGATHO = PENDINGATHO1 + PENDINGATHO;

                int REJECTED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "REJECTED"));
                REJECTED = REJECTED1 + REJECTED;


                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=1&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=2&DistrictId=" + lblDistrictId.Text.Trim();
                }

                HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=3&DistrictId=" + lblDistrictId.Text.Trim();
                }

                HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=5&DistrictId=" + lblDistrictId.Text.Trim();
                }
                
                HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=4&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=6&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
                if (h7.Text != "0")
                {
                    h7.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=7&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
                if (h8.Text != "0")
                {
                    h8.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=8&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h9 = (HyperLink)e.Row.Cells[10].Controls[0];
                if (h9.Text != "0")
                {
                    h9.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=9&DistrictId=" + lblDistrictId.Text.Trim();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = IncompleteApplications.ToString();
                e.Row.Cells[3].Text = NoofapplicationsSubmitted.ToString();
                e.Row.Cells[4].Text = ScritinyPending.ToString();
                e.Row.Cells[5].Text = YetToVerifyPayment.ToString();
                e.Row.Cells[6].Text = PaymentVerified.ToString();
                e.Row.Cells[7].Text = PENDINGATDLO.ToString();
                e.Row.Cells[8].Text = PENDINGATAPPLICANT.ToString();
                e.Row.Cells[9].Text = PENDINGATHO.ToString();
                e.Row.Cells[10].Text = REJECTED.ToString();

                HyperLink h1 = new HyperLink();
                h1.Text = IncompleteApplications.ToString();
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=1&DistrictId=%";
                    e.Row.Cells[2].Controls.Add(h1);
                }

                HyperLink h2 = new HyperLink();
                h2.Text = NoofapplicationsSubmitted.ToString();
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=2&DistrictId=%";
                    e.Row.Cells[3].Controls.Add(h2);
                }

                HyperLink h3 = new HyperLink();
                h3.Text = YetToVerifyPayment.ToString();
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=3&DistrictId=%";
                    e.Row.Cells[5].Controls.Add(h3);
                }

                HyperLink h5 = new HyperLink();
                h5.Text = ScritinyPending.ToString();
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=5&DistrictId=%";
                    e.Row.Cells[4].Controls.Add(h5);
                }
                
                HyperLink h4 = new HyperLink();
                h4.Text = PaymentVerified.ToString();
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=4&DistrictId=%";
                    e.Row.Cells[6].Controls.Add(h4);
                }

                HyperLink h6 = new HyperLink();
                h6.Text = PENDINGATDLO.ToString();
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=6&DistrictId=%";
                    e.Row.Cells[7].Controls.Add(h6);
                }
                HyperLink h7 = new HyperLink();
                h7.Text = PENDINGATAPPLICANT.ToString();
                if (h7.Text != "0")
                {
                    h7.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=7&DistrictId=%";
                    e.Row.Cells[8].Controls.Add(h7);
                }
                HyperLink h8 = new HyperLink();
                h8.Text = PENDINGATHO.ToString();
                if (h7.Text != "0")
                {
                    h8.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=8&DistrictId=%";
                    e.Row.Cells[9].Controls.Add(h8);
                }
                HyperLink h9 = new HyperLink();
                h9.Text = REJECTED.ToString();
                if (h9.Text != "0")
                {
                    h9.NavigateUrl = "frmIncentiveAbstractDrill.aspx?Level=9&DistrictId=%";
                    e.Row.Cells[10].Controls.Add(h9);
                }
            }
        }
    }
}