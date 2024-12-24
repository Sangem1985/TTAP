using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TTAP.Classfiles;
using BusinessLogic;
using System.Data.SqlClient;
using System.Net;

namespace TTAP.UI.Pages
{
    public partial class PaymentFailedTransactions : System.Web.UI.Page
    {
        General Gen = new General();
        comFunctions cmf = new comFunctions();
        comFunctions obcmf = new comFunctions();
        Fetch objFetch = new Fetch();
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string OrderId = txtsearch.Text.Trim();
            string Output = "";
            APTONLINEFAILEDPGSERVICE.PGServices FPGService = new APTONLINEFAILEDPGSERVICE.PGServices();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            Output = FPGService.CheckPayment_Reverify(OrderId, "6850");
            string[] RESP = Output.Split('|');
            if (RESP[0].ToUpper().Trim() == "SUCCESS")
            {
                txtStatus.Text = RESP[0].ToString();
                txtRequestId.Text = RESP[1].ToString();
                txtPgRefNo.Text = RESP[2].ToString();
                txtBaseAmount.Text = RESP[3].ToString();
                txtCharges.Text = RESP[4].ToString();
                divSuccess.Visible = true;
                divBtn.Visible = true;
            }
            else
            {
                txtFailStatus.Text = RESP[0].ToString();
                divFailed.Visible = true;
                divBtn.Visible = true;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string TTAPBillerID = txtRequestId.Text.Trim().ToString();
            decimal ApplicationFee = Convert.ToDecimal(txtBaseAmount.Text.Trim().ToString());
            decimal Tax_Amount = Convert.ToDecimal(txtCharges.Text.Trim().ToString());
            string PGRefNo = txtPgRefNo.Text.Trim().ToString();
            int Status = ObjCAFClass.UpdateManualPayment(TTAPBillerID, ApplicationFee, Tax_Amount, PGRefNo);
            if (Status > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Details Updated Successfully');", true);
                divBtn.Visible = false;
            }
        }
    }
}