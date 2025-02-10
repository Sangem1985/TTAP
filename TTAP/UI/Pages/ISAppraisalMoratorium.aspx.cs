using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TTAP.UI.Pages
{
    public partial class ISAppraisalMoratorium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtLoanAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtROI_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void txtROI_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLoanAmount.Text.Trim() != "" && txtROI.Text.Trim() != "")
                {
                    if (Convert.ToDecimal(txtLoanAmount.Text) != 0)
                    {
                        Decimal InterestDue = Math.Round((Convert.ToDecimal(txtLoanAmount.Text.Trim()) * Convert.ToDecimal(txtROI.Text.Trim())) / 100, 3);

                        txtInterestDue.Text = Convert.ToString(InterestDue);
                        txtInterestDuePM.Text = Convert.ToString( Math.Round((InterestDue / 12),3));
                        txt75Interest.Text = Convert.ToString( Math.Round(Convert.ToDecimal(0.75) * (InterestDue / 12),3));
                        txt8InterestforLoan.Text = Convert.ToString( Math.Round((Convert.ToDecimal(0.08) * Convert.ToDecimal(txtLoanAmount.Text.Trim()) / Convert.ToDecimal(12)),3));
                        txtlowerInterest.Text = Convert.ToString(Math.Round(Math.Min(Convert.ToDecimal(txt75Interest.Text), Convert.ToDecimal(txt8InterestforLoan.Text)),3));
                        txtMortPeriod_TextChanged(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;

            }
        }

        protected void txtMortPeriod_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMortPeriod.Text.Trim() != "" && txtlowerInterest.Text != "")
                {
                    txtTotElgbleInterest.Text = Convert.ToString(Math.Round(Convert.ToDecimal(txtlowerInterest.Text.Trim()) * Convert.ToDecimal(txtMortPeriod.Text.Trim()), 3));
                    if (txtGMRecAmount.Text.Trim() != "")
                    {
                        txtFnlElgbleSbsdy.Text = Convert.ToString(Math.Round(Math.Min(Convert.ToDecimal(txtTotElgbleInterest.Text.Trim()), Convert.ToDecimal(txtGMRecAmount.Text.Trim())), 3));
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;

            }
        }
    }
}