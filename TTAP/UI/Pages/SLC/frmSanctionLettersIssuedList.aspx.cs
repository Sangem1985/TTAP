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
using System.IO;


namespace TTAP.UI.Pages.SLC
{
    public partial class frmSanctionLettersIssuedList : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindIncentives();
                BindSLCs();
                GetData();
            }
        }
        public void BindIncentives()
        {
            try
            {
                DataSet ApprovedIncentives = new DataSet();
                ddlIncentives.Items.Clear();
                ApprovedIncentives = GetIncentives();
                if (ApprovedIncentives != null && ApprovedIncentives.Tables.Count > 0 && ApprovedIncentives.Tables[0].Rows.Count > 0)
                {
                    ddlIncentives.DataSource = ApprovedIncentives.Tables[0];
                    ddlIncentives.DataValueField = "IncentiveID";
                    ddlIncentives.DataTextField = "IncentiveName";
                    ddlIncentives.DataBind();
                    AddSelect(ddlIncentives);
                }
                else
                {
                    AddSelect(ddlIncentives);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindSLCs()
        {
            try
            {
                DataSet ApprovedSLCs = new DataSet();
                ddlslc.Items.Clear();
                ApprovedSLCs = GetSLCs();
                if (ApprovedSLCs != null && ApprovedSLCs.Tables.Count > 0 && ApprovedSLCs.Tables[0].Rows.Count > 0)
                {
                    ddlslc.DataSource = ApprovedSLCs.Tables[0];
                    ddlslc.DataValueField = "Meeting_No";
                    ddlslc.DataTextField = "Meeting_No";
                    ddlslc.DataBind();
                    AddSelect(ddlslc);
                }
                else
                {
                    AddSelect(ddlslc);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetIncentives()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVES");
            return Dsnew;
        }
        public DataSet GetSLCs()
        {
            DataSet Dsnew = new DataSet();
            string IsPartial = "B";
            IsPartial=rdbType.SelectedValue.ToString();
            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@PartialSanction", SqlDbType.VarChar)
            };
            pp[0].Value = IsPartial;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_LIST_INCENTIVE_SLCSanctionNO", pp);
            return Dsnew;
        }
        public void GetData()
        {
            DataSet ds = new DataSet();
            string IsPartial = "B";
            IsPartial = rdbType.SelectedValue.ToString();
            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
                new SqlParameter("@DIPCNumer", SqlDbType.VarChar),
                new SqlParameter("@PartialSanction", SqlDbType.VarChar)
            };

            pp[0].Value = ddlIncentives.SelectedValue.ToString();
            pp[1].Value = ddlslc.SelectedValue.ToString();
            pp[2].Value = IsPartial;
            ds = ObjCAFClass.GenericFillDs("USP_GET_ISSUED_SANCTION_LETTERS_LIST", pp);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
                divNoData.Visible = false;

            }
            else
            {
                gvdetailsnew.DataSource = null;
                gvdetailsnew.DataBind();
                divNoData.Visible = true;
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            GetData();
        }
        protected void chkPartial_CheckedChanged(object sender, EventArgs e)
        {
            BindSLCs();
            GetData();
        }
    }
}