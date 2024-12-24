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
using BusinessLogic;
namespace TTAP.UI.Pages
{
    public partial class frmPlantandMachinery : System.Web.UI.Page
    {
        General Gen = new General();
        Fetch objFetch = new Fetch();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass caf = new CAFClass();
        DataSet dsEligibility = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["IncentiveID"] = "0";
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        BindEligibility();
                        BindPandMGrid(0,Convert.ToInt32(Session["IncentiveID"].ToString()));
                    }
                }
           
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void RegisterPostBackControl()
        {
            foreach (GridViewRow row in grdPandM.Rows)
            {
                Button lnkFull = row.FindControl("btnDelete") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull);
            }
        }

        public void BindEligibility()
        {
            dsEligibility = caf.getEligibilityList();
            if (dsEligibility.Tables.Count > 0)
            {
                if (dsEligibility.Tables[0].Rows.Count > 0)
                {
                    ddlEligibility.DataSource = dsEligibility;
                    ddlEligibility.DataTextField = "EligibilityType";
                    ddlEligibility.DataValueField = "EligibilityId";
                    ddlEligibility.DataBind();
                    ddlEligibility.Items.Insert(0, new ListItem("--Select--", "0"));

                }
            }
        }

        protected void btnPandMAdd_Click(object sender, EventArgs e)
        {
            string errormsg = ValidatePlantMachinaryControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                PlantandMachinery pm = new PlantandMachinery();
                if (ViewState["PMID"] != null)
                    pm.PMId = Convert.ToInt32(ViewState["PMID"].ToString());
                else
                    pm.PMId = 0;
                pm.IncentiveID =Convert.ToInt32(Session["IncentiveID"].ToString());
                pm.MachineName = txtMachineName.Text;
                pm.VendorName = txtVendorName.Text;
                pm.TypeofMachineId = Convert.ToInt32(rdlMachineType.SelectedItem.Value);
                pm.ManufacturerName = txtManufacturerName.Text;
                pm.InvoiceNo = txtInvoiceNo.Text;
                pm.MachineLandingDate = txtMachineLoadingDate.Text;
                pm.VaivleNo = txtVaivleNo.Text;
                pm.VaivleDate = txtVaivleDate.Text;
                pm.IntiationDate = txtInitiationDate.Text;
                pm.MachineCost = Convert.ToDecimal(txtCostofMachine.Text);
                pm.EligilbiltyId = Convert.ToInt32(ddlEligibility.SelectedItem.Value);
                int result = caf.InsertPlantandMachinery(pm,out string error);
                if (result > 0)
                {
                    //Add to Grid Method
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Successfully');", true);
                    BindPandMGrid(0,Convert.ToInt32(Session["IncentiveID"].ToString()));
                    clearControls();
                   
                }

            }

        }
        public string ValidatePlantMachinaryControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (txtMachineName.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Machine Name\\n";
                slno = slno + 1;
            }
            if (txtVendorName.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Vendor Name\\n";
                slno = slno + 1;
            }
            if (txtManufacturerName.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Manufacturer Name\\n";
                slno = slno + 1;
            }
            if (txtInvoiceNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Invoice Number\\n";
                slno = slno + 1;
            }
            if (txtMachineLoadingDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter MachineLoading Date\\n";
                slno = slno + 1;
            }
            if (txtVaivleNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Vaivle Number\\n";
                slno = slno + 1;
            }
            if (txtVaivleDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Vaivle Date\\n";
                slno = slno + 1;
            }
            if (txtInitiationDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Initiation Date\\n";
                slno = slno + 1;
            }
            if (txtCostofMachine.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cost of the Machine\\n";
                slno = slno + 1;
            }
            if (ddlEligibility.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Eligibilty Type\\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public void BindPandMGrid(int PMId,int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {
               
                ds = GetPandM(PMId,IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
                {
                    grdPandM.DataSource = ds.Tables[0];
                    grdPandM.DataBind();
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPandM(int PMId,int IncentiveId)
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

        protected void grdPandM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblPM_Id = (Label)row.FindControl("lblPMId");
            Label lblIncentive_Id = (Label)row.FindControl("lblIncentiveId");
            Button btnEdit = (Button)row.FindControl("btnEdit");
            EditDetails(Convert.ToInt32(lblIncentive_Id.Text), Convert.ToInt32(lblPM_Id.Text));

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblPM_Id = (Label)row.FindControl("lblPMId");
            Label lblIncentive_Id = (Label)row.FindControl("lblIncentiveId");
            Button btnDelete = (Button)row.FindControl("btnDelete");
            int result = caf.DeletePlantandMachinery(Convert.ToInt32(lblPM_Id.Text),Convert.ToInt32(lblIncentive_Id.Text));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "Deleted Successfully", true);
                BindPandMGrid(0,Convert.ToInt32(Session["IncentiveID"].ToString()));
              
            }

        }

        protected void grdPandM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    Button lb = e.Row.FindControl("btnDelete") as Button;
            //    ScriptManager.GetCurrent(this).RegisterPostBackControl(lb);
            //}
        }
        public void EditDetails(int IncentiveId,int PMId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetPandM(PMId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["PMID"] = ds.Tables[0].Rows[0]["PMId"].ToString();
                    txtMachineName.Text = ds.Tables[0].Rows[0]["MachineName"].ToString();
                    txtVendorName.Text = ds.Tables[0].Rows[0]["VendorName"].ToString();
                    rdlMachineType.SelectedValue = ds.Tables[0].Rows[0]["TypeofMachineId"].ToString();
                    txtManufacturerName.Text = ds.Tables[0].Rows[0]["ManufacturerName"].ToString();
                    txtInvoiceNo.Text = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    txtMachineLoadingDate.Text = ds.Tables[0].Rows[0]["MahineLandingDate"].ToString();
                    txtVaivleNo.Text = ds.Tables[0].Rows[0]["VaivleNo"].ToString();
                    txtVaivleDate.Text = ds.Tables[0].Rows[0]["VaivleDate"].ToString();
                    txtInitiationDate.Text = ds.Tables[0].Rows[0]["IntiationDate"].ToString();
                    txtCostofMachine.Text = ds.Tables[0].Rows[0]["MachineCost"].ToString();
                    ddlEligibility.SelectedValue = ds.Tables[0].Rows[0]["EligibilityId"].ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void clearControls()
        {
            ViewState["PMID"] = null;
            txtMachineName.Text = "";
            txtVendorName.Text = "";
            rdlMachineType.SelectedValue = "1";
            txtManufacturerName.Text = "";
            txtInvoiceNo.Text = "";
            txtMachineLoadingDate.Text = "";
            txtVaivleNo.Text = "";
            txtVaivleDate.Text = "";
            txtInitiationDate.Text = "";
            txtCostofMachine.Text = "";
            ddlEligibility.SelectedValue = "0";
        }
    }
}