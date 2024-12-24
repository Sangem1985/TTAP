using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogic;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class TypeOfIncentivesNew1 : System.Web.UI.Page
    {
        General Gen = new General();
        comFunctions objCmf = new comFunctions();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();
        CAFClass ObjCAFClass = new CAFClass();
        

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
                        if (Request.QueryString["NFlag"] == null)
                        {
                            Response.Redirect("frmNewIncentive.aspx");
                            return;
                        }
                        success.Visible = Failure.Visible = false;
                        if (Session["IncentiveID"].ToString() == null || Session["IncentiveID"].ToString() == "")
                        {
                            Session["IncentiveID"] = Session["EntprIncentiveOld"].ToString();
                        }
                        Session["Incentive_GHMC"] = "1";
                        Session["Incentive_Category"] = "1";
                        Session["Incentive_IsWomenEntrprenaur"] = "1";
                        string IncentiveId = Session["IncentiveID"].ToString();

                        string createdby = Session["uid"].ToString();
                        DataSet ds2 = new DataSet();
                        ds2 = GET_ELIGIBLE_INCENTIVES_COMMON_DATA(createdby, IncentiveId);

                        if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                        {
                            Session["Incentive_DateOfCommencement"] = ds2.Tables[0].Rows[0]["DCPNEW"].ToString();
                            Session["Incentive_Caste"] = ds2.Tables[0].Rows[0]["Caste"].ToString();
                            Session["Incentive_Sector"] = ds2.Tables[0].Rows[0]["sector"].ToString();
                            //Session["Incentive_Category"] = ds2.Tables[0].Rows[0]["Category"].ToString();

                            if (ds2.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")
                            {
                                Session["Incentive_PHC"] = Convert.ToBoolean(1);
                            }
                            else if (ds2.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "N")
                            {
                                Session["Incentive_PHC"] = Convert.ToBoolean(0);
                            }
                            Session["Incentive_Zone"] = "0";
                            //Session["Incentive_Zone"] = ds2.Tables[0].Rows[0]["ZoneId"].ToString();
                            ////Session["Incentive_IsWomenEntrprenaur"] = ds2.Tables[0].Rows[0]["IsWomenEntrprenaur"].ToString();
                            ViewState["intstatusid"] = "";
                            if (ds2.Tables[0].Rows[0]["intstatusid"].ToString() != null && ds2.Tables[0].Rows[0]["intstatusid"].ToString() != "")
                            {
                                ViewState["intstatusid"] = ds2.Tables[0].Rows[0]["intstatusid"].ToString();

                                trApplyNew.Visible = true;

                                chkApplyAgainNew.Visible = false;
                                trApplyAgainNote.Visible = false;
                            }
                            else
                            {
                                trApplyNew.Visible = false;
                                chkApplyAgainNew.Visible = false;
                                trApplyAgainNote.Visible = false;
                            }
                        }
                        btnNext.Visible = true;
                        //int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());
                        //if (Session["Incentive_isVehicle"] != null && Convert.ToBoolean(Session["Incentive_isVehicle"])) rblVehicleIncetive.SelectedValue = "1";
                        BindIncentives();
                        //if (ds2.Tables[0].Rows[0]["intstatusid"].ToString() != null && ds2.Tables[0].Rows[0]["intstatusid"].ToString() != "")
                        //{

                        int totalcount = 0;
                        int disableselectedcount = 0;
                        int selectedenablecount = 0;
                        int disableunselectedcount = 0;
                        int unsalectedcount = 0;
                        totalcount = gvSingleTerm.Rows.Count;
                        foreach (GridViewRow Row in gvSingleTerm.Rows)
                        {
                            CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                            if (chk.Checked == false && chk.Enabled == false)
                            {
                                disableunselectedcount = disableunselectedcount + 1;
                            }
                            else if (chk.Checked == true && chk.Enabled == false)
                            {
                                disableselectedcount = disableselectedcount + 1;
                            }
                            else if (chk.Checked == true && chk.Enabled == true)
                            {
                                selectedenablecount = selectedenablecount + 1;
                            }
                            if (chk.Checked == false && chk.Enabled == true)
                            {
                                unsalectedcount = unsalectedcount + 1;
                            }
                        }
                        if (totalcount == disableselectedcount)
                        {
                            chkApplyAgainNew.Visible = false;
                            trApplyAgainNote.Visible = false;
                            trApplyNew.Visible = false;
                        }
                        else if (totalcount == selectedenablecount)
                        {
                            chkApplyAgainNew.Visible = false;
                            trApplyAgainNote.Visible = false;
                            trApplyNew.Visible = false;
                        }
                        else if (totalcount == unsalectedcount)
                        {
                            chkApplyAgainNew.Visible = false;
                            trApplyAgainNote.Visible = false;
                            trApplyNew.Visible = false;
                        }
                        else if (selectedenablecount > 0 && totalcount != selectedenablecount && disableselectedcount > 0)
                        {
                            chkApplyAgainNew.Visible = true;
                            trApplyAgainNote.Visible = true;
                            chkApplyAgainNew.Checked = true;
                            chkApplyAgainNew.Enabled = false;
                            trApplyNew.Visible = true;
                            foreach (GridViewRow Row in gvSingleTerm.Rows)
                            {
                                CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                                if (chk.Checked == false && chk.Enabled == false)
                                {
                                    chk.Enabled = true;
                                }
                            }
                        }
                        else if (disableunselectedcount > 0)
                        {
                            chkApplyAgainNew.Visible = true;
                            trApplyAgainNote.Visible = true;
                            trApplyNew.Visible = true;
                        }
                        //}

                        // If Any NEFT/RTGS Are Pending At Department

                        DataSet ds = new DataSet();
                        ds = GetRTGSNEFTStatus(Session["uid"].ToString(), Session["IncentiveID"].ToString());
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            string PaymentEnableFlag = ds.Tables[0].Rows[0]["PaymentEnableFlag"].ToString();
                            if (PaymentEnableFlag == "N")
                            {
                                trApplyNew.Visible = false;
                                trApplyAgainNote.Visible = false;
                            }
                        }

                        //

                        if (Request.QueryString.Count > 0 && Request.QueryString["ViewType"] != null && Request.QueryString["ViewType"].ToString() != "")
                        {
                            string ViewType= Request.QueryString["ViewType"].ToString();
                            if (ViewType == "V")
                            {
                                trApplyNew.Visible = false;
                                trApplyAgainNote.Visible = false;
                            }
                        }
                    }
                    // Commented by shankar
                    /*if (DateTime.Now.Date > Convert.ToDateTime("2022/03/31")) {
                        trApplyNew.Visible = false;
                    }*/
                    //trApplyNew.Visible = false;
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
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public DataSet GetRTGSNEFTStatus(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("[FetchIncentives_CAF_PAYMENT]", pp);
            return Dsnew;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            int selectedenablecount = 0;
            string IncentiveType = "";

            foreach (GridViewRow Row in gvSingleTerm.Rows)
            {
                CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                Label lblIncentiveType =(Label)Row.FindControl("lblIncentive_Type");
               
                if (chk.Checked == true && chk.Enabled == true)
                {
                    IncentiveType = lblIncentiveType.Text;
                    selectedenablecount = selectedenablecount + 1;
                }
            }
            if (selectedenablecount > 1)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You can apply only one Incentive at a time,So please select only one Incentive')", true);
                return;
            }
           /* if (selectedenablecount==1 && IncentiveType == "2")
            {
                string CheckEligibility = "";
                CheckEligibility = ObjCAFClass.Check_Incentive_Eligibility(Session["IncentiveID"].ToString(), IncentiveType);
                hdnEligibility.Value = CheckEligibility;
                if (CheckEligibility == "N") {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You are not eligible to apply this Incentive')", true);
                    return;
                }
                if (CheckEligibility == "H") {
                    hdnEligibility.Value = CheckEligibility;
                }
            }*/

            try
            {
                SavedataNew();
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void rblSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { BindIncentives(); }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                // Errors.ErrorLog(ex);
            }
        }

        private void BindIncentives()
        {
            try
            {
                if (rblVehicleIncetive.SelectedIndex > -1)
                {
                    int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());
                    int sector = Convert.ToInt32(Session["incentive_Sector"] == null ? "0" : Session["incentive_Sector"].ToString());

                    DataTable dt = new DataTable();
                    //DataTable dtIncentiveType = new DataTable();
                    //dtIncentiveType = objFetch.FetchIncentiveTypes();

                    //trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = trTpride.Visible = false;
                    //gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = gvTpride.DataSource = null;

                    trOnetime.Visible = false;
                    gvSingleTerm.DataSource = null;
                    gvSingleTerm.DataBind();


                    trNoIncentives.Visible = false;

                    string ViewType = "";
                    if (Request.QueryString.Count > 0 && Request.QueryString["ViewType"] != null && Request.QueryString["ViewType"].ToString() != "")
                    {
                        ViewType = Request.QueryString["ViewType"].ToString();
                    }

                    int EntprIncentive = Convert.ToInt32(Session["IncentiveID"].ToString());
                    dt = ObjCAFClass.FetchIncentivesNewINCTypePSRNew(caste,
                                                    sector,
                                                    Convert.ToInt32(Session["Incentive_Category"].ToString()),
                                                    Convert.ToInt32(Session["Incentive_Zone"].ToString()),
                                                    Convert.ToBoolean(Convert.ToInt32(Session["Incentive_IsWomenEntrprenaur"].ToString())),
                                                    2,
                                                    Convert.ToInt32(Session["IncentiveID"].ToString()), ViewType
                                                );

                    if (dt.Rows.Count > 0)
                    {
                        trOnetime.Visible = true;
                        objCmf.FillGrid(dt, gvSingleTerm, false);
                    }

                    if (!(trOnetime.Visible)) trNoIncentives.Visible = true;
                }
                else { trOnetime.Visible = false; }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void rblVehicleIncetive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { BindIncentives(); }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void cbIncentive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gr = (((CheckBox)sender).Parent.Parent as GridViewRow);
                Label lbl = (gr.FindControl("lblIncentiveId") as Label);
                CheckBox cb = (gr.FindControl("cbIncentive") as CheckBox); ;
                if (Convert.ToInt32(lbl.Text) == 2 && cb.Checked)
                {
                    trOnetime.Visible = true;
                    objCmf.FillGrid(objFetch.FetchIncentivesbyID(6), gvSingleTerm, false);
                }
                else
                { rblSelection_SelectedIndexChanged(sender, e); }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                // Errors.ErrorLog(ex);
            }
        }

     

        // added for 2nd time applying   // added newly on 22.11.2017   
        protected void chkApplyAgainNew_CheckedChanged(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (chkApplyAgainNew.Checked == true)
            {
                // one time incentives enabling

                foreach (GridViewRow Row in gvSingleTerm.Rows)
                {
                    CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                    Label lblIncentive_Type = (Label)Row.FindControl("lblIncentive_Type");
                    Label lblSubIncentiveID = (Label)Row.FindControl("lblIncentiveId");

                    if (chk.Checked == false && chk.Enabled == false)
                    {
                        chk.Enabled = true;
                    }
                    else if (chk.Checked == true && chk.Enabled == false && lblIncentive_Type.Text == "3")
                    {
                        string Valid = ObjCAFClass.Check_RegularIncentive(Session["IncentiveID"].ToString(), lblSubIncentiveID.Text,ObjLoginNewvo.uid);
                        if (Valid == "Y")
                        {
                            chk.Enabled = true;
                        }
                        else
                        {
                            chk.Enabled = false;
                        }
                    }
                    if (lblSubIncentiveID.Text == "1")
                    {
                        string Enable = ObjCAFClass.Check_EnableCapital_Subsidy(ObjLoginNewvo.uid);
                        if (Enable == "Y")
                        {
                            chk.Enabled = true;
                        }
                    }
                }

                DataSet dsappstatus = new DataSet();
                dsappstatus = GetRejectedApplicationStatus(Session["IncentiveID"].ToString());
                if (dsappstatus != null && dsappstatus.Tables.Count > 1 && dsappstatus.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < dsappstatus.Tables[1].Rows.Count; i++)
                    {
                        string SubIncentiveID = dsappstatus.Tables[1].Rows[i]["SubIncentiveID"].ToString();

                        foreach (GridViewRow Row in gvSingleTerm.Rows)
                        {
                            CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                            Label lblSubIncentiveID = (Label)Row.FindControl("lblIncentiveId");

                            if (chk.Checked == true && chk.Enabled == false && SubIncentiveID == lblSubIncentiveID.Text)
                            {
                                chk.Enabled = true;
                                break;
                            }
                        }
                    }
                }
                //
                string applicationStatus = "";
                applicationStatus = ViewState["intstatusid"].ToString();

                //if (Convert.ToInt32(applicationStatus) != null)
                //{
                //    EnableDisableForm(Page.Controls, true);
                //}

                Session["EntprIncentiveOld"] = "";
                Session["EntprIncentiveOld"] = Session["IncentiveID"].ToString();

                Session["IncentiveID"] = "";

                //   BindIncentives();
                //BindIncentives2ndTime();
            }
            else if (chkApplyAgainNew.Checked == false)
            {
                Session["IncentiveID"] = Session["EntprIncentiveOld"].ToString();
                BindIncentives();
            }
        }

        public void EnableDisableForm(ControlCollection ctrls, bool status)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                {
                    ((TextBox)ctrl).Enabled = status;
                    ((TextBox)ctrl).Controls.Clear();
                    int c = ((TextBox)ctrl).Controls.Count;

                }

                else if (ctrl is CheckBox)
                {
                    ((CheckBox)ctrl).Enabled = status;
                    ((CheckBox)ctrl).Controls.Clear();
                }

                else if (ctrl is CheckBoxList)
                {
                    ((CheckBoxList)ctrl).Enabled = status;
                    ((CheckBoxList)ctrl).Controls.Clear();
                }

                EnableDisableForm(ctrl.Controls, status);
            }

        }

        

        public string InsertCommonDetailsbyUserid_2NDTime(string userid)
        {
            string valid = "";
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "[USP_INSERT_INCENTIVES_ALL_COMMON_DATA_BY_USERID_2ND_TIME]";

                com.Transaction = transaction;
                com.Connection = connection;

                if (userid != null)
                    com.Parameters.AddWithValue("@CreatedBy", userid);
                else
                    com.Parameters.AddWithValue("@CreatedBy", null);

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }

        protected void gvSingleTerm_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // added on 26.04.2018
            if (trApplyNew.Visible == true && chkApplyAgainNew.Checked == false)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int a = 0; a <= gvSingleTerm.Rows.Count; a++)
                    {
                        CheckBox cbIncentive = (e.Row.FindControl("cbIncentive") as CheckBox);
                        cbIncentive.Enabled = false;
                    }
                }
            }
        }

        public void SavedataNew()
        {
            int SelectedCount = 0;
            foreach (GridViewRow Row in gvSingleTerm.Rows)
            {
                CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                if (chk.Checked == true)
                {
                    SelectedCount = SelectedCount + 1;
                }
            }

            if (SelectedCount > 0)
            {
                List<AppliedIncentiveStatus> lstAppliedIncentiveStatus = new List<AppliedIncentiveStatus>();
                if (chkApplyAgainNew.Checked == false && (Session["IncentiveID"] != null && Session["IncentiveID"].ToString() != "") && chkApplyAgainNew.Visible == false)
                {
                    foreach (GridViewRow Row in gvSingleTerm.Rows)
                    {
                        AppliedIncentiveStatus objAppliedIncentiveStatus = new AppliedIncentiveStatus();
                        CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                        Label lblIncentiveId = (Label)Row.FindControl("lblIncentiveId");

                        objAppliedIncentiveStatus.EnterperIncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());
                        objAppliedIncentiveStatus.MstIncentiveId = Convert.ToInt32(lblIncentiveId.Text.Trim().TrimStart());
                        objAppliedIncentiveStatus.Created_by = Session["uid"].ToString();
                        if (chk.Checked == true && chk.Enabled == true)
                        {
                            objAppliedIncentiveStatus.Isactive = "1";
                        }
                        else if (chk.Enabled == true)
                        {
                            objAppliedIncentiveStatus.Isactive = "0";
                        }
                        if (chk.Enabled == true)
                        {
                            lstAppliedIncentiveStatus.Add(objAppliedIncentiveStatus);
                        }
                    }
                    ObjCAFClass.InsertAppliedIncentives(lstAppliedIncentiveStatus);
                    Response.Redirect("frmIncentiveCAFDetails.aspx");
                    /*Response.Redirect("frmIncentiveCAFDetails.aspx?IncentiveID=" + hdnEligibility.Value);*/
                }
                else if (chkApplyAgainNew.Checked == true && chkApplyAgainNew.Visible == true)
                {
                    int seletedCount = 0;
                    foreach (GridViewRow Row in gvSingleTerm.Rows)
                    {
                        CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                        if (chk.Checked == true && chk.Enabled == true)
                        {
                            seletedCount = seletedCount + 1;
                        }
                    }
                    if (seletedCount > 0)
                    {
                        string incentiveId = InsertCommonDetailsbyUserid_2NDTime(Session["uid"].ToString());
                        if (incentiveId != null && incentiveId != "")
                        {
                            String oldincentiveID = Session["IncentiveID"].ToString();
                            Session["IncentiveID"] = incentiveId;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        string incentiveId = InsertCommonDetailsbyUserid_2NDTime(Session["uid"].ToString());
                        if (incentiveId != null && incentiveId != "")
                        {
                            String oldincentiveID = Session["IncentiveID"].ToString();
                            Session["IncentiveID"] = incentiveId;
                        }
                        else
                        {
                            return;
                        }
                    }
                    foreach (GridViewRow Row in gvSingleTerm.Rows)
                    {
                        AppliedIncentiveStatus objAppliedIncentiveStatus = new AppliedIncentiveStatus();
                        CheckBox chk = (CheckBox)Row.FindControl("cbIncentive");
                        Label lblIncentiveId = (Label)Row.FindControl("lblIncentiveId");
                        objAppliedIncentiveStatus.EnterperIncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());
                        objAppliedIncentiveStatus.MstIncentiveId = Convert.ToInt32(lblIncentiveId.Text.Trim().TrimStart());
                        objAppliedIncentiveStatus.Created_by = Session["uid"].ToString();
                        if (chk.Checked == true && chk.Enabled == true)
                        {
                            objAppliedIncentiveStatus.Isactive = "1";
                            lstAppliedIncentiveStatus.Add(objAppliedIncentiveStatus);
                        }
                        else if (chk.Checked == false && chk.Enabled == true)
                        {
                            objAppliedIncentiveStatus.Isactive = "0";
                            lstAppliedIncentiveStatus.Add(objAppliedIncentiveStatus);
                        }
                    }

                    ObjCAFClass.InsertAppliedIncentives(lstAppliedIncentiveStatus);
                    Response.Redirect("frmIncentiveCAFDetails.aspx");
                    /*Response.Redirect("frmIncentiveCAFDetails.aspx?IncentiveID=" + hdnEligibility.Value);*/
                }
                else if (chkApplyAgainNew.Checked == false && chkApplyAgainNew.Visible == true)
                {
                    Response.Redirect("frmIncentiveCAFDetails.aspx");
                    /*Response.Redirect("frmIncentiveCAFDetails.aspx?IncentiveID=" + hdnEligibility.Value);*/
                }
            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "Please select at least one subsidy";
            }
        }

        public DataSet GetRejectedApplicationStatus(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };

            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_USERAPPLICATIONS_STATUS", pp);
            return Dsnew;
        }


        public DataSet GET_ELIGIBLE_INCENTIVES_COMMON_DATA(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_ELIGIBLE_INCENTIVES_COMMON_DATA", pp);
            return Dsnew;
        }
    }
}