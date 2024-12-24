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
    public partial class TypeOfIncentivesNew : System.Web.UI.Page
    {
        General Gen = new General();
        comFunctions objCmf = new comFunctions();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        BusinessLogic.Fetch objFetch = new BusinessLogic.Fetch();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.Count <= 0)
                {
                    Response.Redirect("~/Index.aspx", false);
                    return;
                }
               

                success.Visible = Failure.Visible = false;
                if (!IsPostBack)
                {
                    // added newly on 28.07.2017

                    if (Session["IncentiveID"].ToString() == null || Session["IncentiveID"].ToString() == "")
                    {
                        Session["IncentiveID"] = Session["EntprIncentiveOld"].ToString();
                    }
                    string IncentiveId = Session["IncentiveID"].ToString();
                    Session["IncentiveId"] = IncentiveId;
                    string createdby = Session["uid"].ToString();
                    DataSet ds2 = new DataSet();
                    ds2 = Gen.GET_ELIGIBLE_INCENTIVES_COMMON_DATA(createdby, IncentiveId);

                    if (ds2 != null && ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
                    {
                        Session["Incentive_DateOfCommencement"] = ds2.Tables[0].Rows[0]["DCPNEW"].ToString(); // txtDateofCommencement.Text;
                        Session["Incentive_isVehicle"] = Convert.ToBoolean(Convert.ToInt32(ds2.Tables[0].Rows[0]["isVehicleIncentive"].ToString()));
                        // Convert.ToBoolean(Convert.ToInt32(rblVeh.SelectedValue));
                        Session["Incentive_GHMC"] = Convert.ToBoolean(Convert.ToInt32(ds2.Tables[0].Rows[0]["IsGHMCandOtherMuncpOrp"].ToString()));
                        // Convert.ToBoolean(Convert.ToInt32(rblGHMC.SelectedValue));
                        Session["Incentive_Caste"] = ds2.Tables[0].Rows[0]["Caste"].ToString();  // ds.Tables[0].Rows[0]["caste"].ToString();
                        Session["Incentive_Sector"] = ds2.Tables[0].Rows[0]["sector"].ToString();  // rblSector.SelectedValue;
                        Session["Incentive_Category"] = ds2.Tables[0].Rows[0]["Category"].ToString(); // ds.Tables[0].Rows[0]["Category"].ToString();
                                                                                                      //   Session["Incentive_PHC"] = ds2.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString();  //(cbDiffAbled.Checked == true ? "0" : "1");
                        if (ds2.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "Y")
                        {
                            Session["Incentive_PHC"] = Convert.ToBoolean(1);
                        }
                        else if (ds2.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() == "N")
                        {
                            Session["Incentive_PHC"] = Convert.ToBoolean(0);
                        }

                        // added newly on 26.11.2017  
                        ViewState["intstatusid"] = "";
                        if (ds2.Tables[0].Rows[0]["intstatusid"].ToString() != null && ds2.Tables[0].Rows[0]["intstatusid"].ToString() != "")
                        {
                            ViewState["intstatusid"] = ds2.Tables[0].Rows[0]["intstatusid"].ToString();

                            if (Session["uid"].ToString() == "2384" || Session["uid"].ToString() == "31357" || Session["uid"].ToString() == "5780" || Session["uid"].ToString() == "12696"
                                || Session["uid"].ToString() == "11050" || Session["uid"].ToString() == "3483" || Session["uid"].ToString() == "30759" || Session["uid"].ToString()  == "17083" )  //
                            {
                                trApplyNew.Visible = true;
                                chkApplyAgainNew.Visible = true;
                                trApplyAgainNote.Visible = true;
                            }
                            else
                            {
                                trApplyNew.Visible = false;
                                chkApplyAgainNew.Visible = false;
                                trApplyAgainNote.Visible = false;
                            }

                            trApplyNew.Visible = true;
                            chkApplyAgainNew.Visible = true;
                            trApplyAgainNote.Visible = true;



                        }
                        else
                        {
                            trApplyNew.Visible = false;
                            chkApplyAgainNew.Visible = false;
                            trApplyAgainNote.Visible = false;
                        }

                    }

                    btnNext.Visible = true;
                    int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());

                    //trVehIncentive.Visible = false;
                    //if (Convert.ToBoolean(Session["Incentive_PHC"].ToString()) || caste == 3 || caste == 4) trVehIncentive.Visible = true;

                    //if (Session["Incentive_NewOrExisting"] != null && Session["Incentive_NewOrExisting"].ToString() != "0") rblSelection.SelectedValue = Session["Incentive_NewOrExisting"].ToString();

                    rblSelection.SelectedValue = "1";
                    rblSelection.Visible = false;

                    if (Session["Incentive_isVehicle"] != null && Convert.ToBoolean(Session["Incentive_isVehicle"])) rblVehicleIncetive.SelectedValue = "1";

                    BindIncentives();

                }
            }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }

        //private void Incentiveslist(bool IsNewEnterp)
        //{
        //    try 
        //    {
        //        int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());
        //        int sector = Convert.ToInt32(Session["incentive_Sector"] == null ? "0" : Session["incentive_Sector"].ToString());

        //        DataTable dt = new DataTable();
        //        DataTable dtIncentiveType = new DataTable();
        //        dtIncentiveType = objFetch.FetchIncentiveTypes();

        //        //trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = trTpride.Visible = false;
        //        //gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = gvTpride.DataSource = null;

        //        trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = false;
        //        gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = null;

        //        gvRepetitive.DataBind();
        //        gvSingleTerm.DataBind();
        //        gvskillSet.DataBind();
        //        //gvTpride.DataBind();

        //        if (dtIncentiveType != null)
        //        {
        //            for (int i = 0; i < dtIncentiveType.Rows.Count; i++)
        //            {                    
        //                dt = objFetch.FetchIncentivesyCasterSector(caste, sector, i + 1,Convert.ToInt32(Session["IncentiveID"].ToString()));
        //                switch (i + 1)
        //                {
        //                    case 1:
        //                        if (dt.Rows.Count > 0)
        //                        {
        //                            //trTpride.Visible = true;
        //                            //objCmf.FillGrid(dt, gvTpride, false);
        //                        }
        //                        break;
        //                    case 2:
        //                        if (dt.Rows.Count > 0 && IsNewEnterp)
        //                        {
        //                            trOnetime.Visible = true;
        //                            objCmf.FillGrid(dt, gvSingleTerm, false);
        //                        }
        //                        break;
        //                    case 3:
        //                        if (dt.Rows.Count > 0)
        //                        {
        //                            trRegularIncentive.Visible = true;
        //                            objCmf.FillGrid(dt, gvRepetitive, false);
        //                        }
        //                        break;
        //                    case 4:
        //                        if (dt.Rows.Count > 0)
        //                        {
        //                            trSkillset.Visible = true;
        //                            objCmf.FillGrid(dt, gvskillSet, false);
        //                        }
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex) { Errors.ErrorLog(ex); }
        //}

        private DataTable dtYear()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Year");
            dt.Rows.Add(1, "April-2015");
            dt.Rows.Add(2, "October-2015");
            //for (int yr = (DateTime.Now.Year - 1); yr <= (DateTime.Now.Year); yr++) dt.Rows.Add(yr);
            return dt;
        }

        private DataTable dtYear1()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Year");
            dt.Rows.Add(1, "September-2015");
            dt.Rows.Add(2, "March-2016");
            //for (int yr = (DateTime.Now.Year - 1); yr <= (DateTime.Now.Year); yr++) dt.Rows.Add(yr);
            return dt;
        }

        // need to comment for 2nd time applying  dt: 26.11.2017
        #region 'gvRepetitive_RowDataBound'
        //protected void gvRepetitive_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {

        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            //DropDownList ddlfrom=(e.Row.FindControl("ddlPassingYearFrom") as DropDownList);
        //            //DropDownList ddlto = (e.Row.FindControl("ddlPassingYearTo") as DropDownList);
        //            //objCmf.BindCtlto(true,ddlfrom , dtYear(), 1, 0, false);
        //            //objCmf.BindCtlto(true, ddlto, dtYear1(), 1, 0, false);

        //            TextBox txtFrom = (e.Row.FindControl("txtFrom") as TextBox);
        //            TextBox txtTo = (e.Row.FindControl("txtTo") as TextBox);

        //            Label lbl = (e.Row.FindControl("lblDropdown") as Label);
        //            if (lbl.Text.Trim() == "" || lbl.Text.Trim() == "0" || lbl.Text.ToLower() == "01-jan-1900") txtFrom.Text = ""; else txtFrom.Text = Convert.ToDateTime(lbl.Text).ToString("dd-MMM-yyyy");
        //            if (lbl.ToolTip.Trim() == "" || lbl.ToolTip.Trim() == "0" || lbl.ToolTip.ToLower() == "01-jan-1900") txtTo.Text = ""; else txtTo.Text = Convert.ToDateTime(lbl.ToolTip).ToString("dd-MMM-yyyy");

        //            lbl = (e.Row.FindControl("lbl") as Label);
        //            //RadioButtonList rbl = (e.Row.FindControl("rblYesNo") as RadioButtonList);
        //            //if (lbl.Text.Trim() == "" || lbl.Text.Trim() == "0") rbl.SelectedIndex = -1; else rbl.SelectedValue = lbl.Text.Trim();

        //            (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = (lbl.ToolTip.Trim() == "" || lbl.ToolTip.Trim() == "0" ? false : true);

        //            if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim() == "3")
        //            {

        //                DataSet dsA = objFetch.FetchIncentivesApplied(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim(), Convert.ToString(Session["IncentiveID"].ToString()));

        //                if (dsA.Tables[0].Rows.Count > 0)
        //                {


        //                    (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = false;
        //                }
        //                else
        //                {
        //                    (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = true;
        //                    //(e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = false;  // 22/06/2017
        //                }
        //            }
        //            else
        //            {
        //                (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = false;
        //                //(e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = true;    // 22/06/2017
        //            }
        //        }
        //    }
        //    catch (Exception ex) { Errors.ErrorLog(ex); }
        //}
        #endregion

        // need to comment for 2nd time applying  dt: 26.11.2017
        #region 'save click'
        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string ApplicationStatus = "";
        //        DataSet ds = new DataSet();
        //        ds = Gen.GetIncetiveApplicationStatus(Session["IncentiveID"].ToString());

        //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            if (ds.Tables[0].Rows[0]["intStatusid"] != null && ds.Tables[0].Rows[0]["intStatusid"] != "")
        //            {
        //                ApplicationStatus = ds.Tables[0].Rows[0]["intStatusid"].ToString();

        //                //if (ApplicationStatus == null || ApplicationStatus == "2" || ApplicationStatus == string.Empty || ApplicationStatus == "6")
        //                if (ApplicationStatus == null || ApplicationStatus == string.Empty)
        //                {
        //                    //save();
        //                    if (save())
        //                    {
        //                        string message = "alert('Please click on Next and fill the concerned forms to get the acknowledgment.')";
        //                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
        //                        btnNext.Enabled = true;
        //                        success.Visible = false;
        //                    }
        //                }
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Errors.ErrorLog(ex);
        //        lblmsg0.Text = ex.Message;
        //        Failure.Visible = true;
        //    }
        //}
        #endregion

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string ApplicationStatus = "";
                DataSet ds = new DataSet(); 
                 ds = Gen.GetIncetiveApplicationStatus(Session["IncentiveId"].ToString());//Session["IncentiveID"].ToString());

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["intStatusid"] != null && ds.Tables[0].Rows[0]["intStatusid"].ToString() != "")
                    {
                        ApplicationStatus = ds.Tables[0].Rows[0]["intStatusid"].ToString();

                        if (ApplicationStatus == null || ApplicationStatus == "2" || ApplicationStatus == string.Empty)
                        {
                            if (Session["IncentiveID"].ToString() != "11615")
                            {
                                save();
                            }

                        }
                    }

                }

                //  if (save())    
                // string btnNextPostBackUrl = ViewState["BntnNextPostBackURL"].ToString();  frmIncentiveCAFDetails
                // btnNext.PostBackUrl = btnNextPostBackUrl.ToString();
                btnNext.PostBackUrl = "../../UI/Pages/frmIncentiveCAFDetails.aspx";
                Response.Redirect(btnNext.PostBackUrl, false);
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        private bool save()
        {
            try
            {
                lblmsg0.Text = "";
                success.Visible = Failure.Visible = false;

                DataTable dt = new DataTable();
                dt.Columns.Add("IncentiveId");
                dt.Columns.Add("AlreadyApplied");
                dt.Columns.Add("FromYear");
                dt.Columns.Add("ToYear");

                DataTable dtIncentiveTypes = new DataTable();
                dtIncentiveTypes.Columns.Add("IncentiveType", typeof(int));
                
                //string str1 = Session["Incentive_DateOfCommencement"].ToString();


                string[] str1 = Session["Incentive_DateOfCommencement"].ToString().Split('/');

                string strDateOA = str1[2].ToString() + "/" + str1[1].ToString() + "/" + str1[0].ToString();

                //DateTime dcp = Convert.ToDateTime(Session["Incentive_DateOfCommencement"].ToString());
                DateTime dcp = Convert.ToDateTime(strDateOA);
                // DateTime dcp = Convert.ToDateTime(dcp1);         

                foreach (GridViewRow gr in gvRepetitive.Rows) gr.BackColor = System.Drawing.Color.FromName((gr.RowIndex % 2 == 0 ? "#EFF3FB" : "#FFFFFF"));

                bool valid = true;
                foreach (GridViewRow gr in gvRepetitive.Rows)
                {
                    if ((gr.FindControl("cbIncentiveCheck") as CheckBox).Checked == true && (gr.FindControl("cbIncentiveCheck") as CheckBox).Enabled == true)
                    {
                        //DropDownList ddlfrm = (gr.FindControl("ddlPassingYearFrom") as DropDownList);
                        //DropDownList ddlto = (gr.FindControl("ddlPassingYearTo") as DropDownList);
                        TextBox txtFrom = (gr.FindControl("txtFrom") as TextBox);
                        TextBox txtTo = (gr.FindControl("txtTo") as TextBox);

                        DateTime dtfrom, dtto;

                        if ((txtFrom == null || txtTo == null))
                        {
                            break;
                        }
                        else
                        {
                            if (txtFrom.Text == "")
                            {
                                valid = false;
                                Failure.Visible = true;
                                gr.BackColor = System.Drawing.Color.Pink;
                                lblmsg0.Text = "Please select From Date";
                                txtFrom.Focus();
                                return false;
                            }

                            if (txtTo.Text == "")
                            {
                                Failure.Visible = true;
                                valid = false;
                                gr.BackColor = System.Drawing.Color.Pink;
                                lblmsg0.Text = "Please select To Date";
                                txtTo.Focus();
                                return false;
                            }
                        }

                        try
                        {
                            dtfrom = Convert.ToDateTime(txtFrom.Text);
                        }
                        catch (Exception)
                        {
                            Failure.Visible = true;
                            txtFrom.Focus();
                            lblmsg0.Text = "Please select Valid Date"; ;
                            break;
                        }

                        try { dtto = Convert.ToDateTime(txtTo.Text); }
                        catch (Exception)
                        {
                            Failure.Visible = true;
                            txtTo.Focus();
                            lblmsg0.Text = "Please select Valid Date"; ;
                            break;
                        }

                        if (dtto < dtfrom)
                        {
                            Failure.Visible = true;
                            //txtTo.Focus();
                            lblmsg0.Text = "To Date cannot be Less than From date";
                            break;
                        }

                        //if (dtto < dcp)incentive change
                        //{
                        //    Failure.Visible = true;
                        //    //txtTo.Focus();
                        //    lblmsg0.Text = "To Date cannot be Less than Date of Commencement of production Date (" + dcp.ToString("dd-MMM-yyyy") + ")";
                        //    break;
                        //}

                        //if (dtfrom < dcp) {incentive change
                        //    Failure.Visible = true;
                        //    txtFrom.Focus();
                        //    lblmsg0.Text = "From date cannot be Less than Date of Commencement of production Date (" + dcp.ToString("dd-MMM-yyyy") + ")" ;
                        //    break;
                        //}

                        DateTime ddtt = dcp.AddYears(9);

                        if (dtto > dcp.AddYears(9))
                        {
                            Failure.Visible = true;
                            txtTo.Focus();
                            lblmsg0.Text = "From date cannot be Greater than (" + dcp.AddYears(9).ToString("dd-MMM-yyyy") + ")";
                            break;
                        }

                        if (dtto.AddDays(1) < dtfrom.AddMonths(6))
                        {
                            Failure.Visible = true;
                            txtTo.Focus();
                            lblmsg0.Text = "To date should be Greater than (" + dtfrom.AddMonths(6).ToString("dd-MMM-yyyy") + ")";
                            break;
                        }

                        dtIncentiveTypes.Rows.Add(3);

                        dt.Rows.Add(
                                    (gr.FindControl("lblIncentiveId") as Label).Text,
                                    "0",
                                    Convert.ToDateTime(txtFrom.Text).ToString("yyyy-MM-dd"),
                                    Convert.ToDateTime(txtTo.Text).ToString("yyyy-MM-dd")
                                    );
                    }
                }
                if (valid)
                {
                    foreach (GridViewRow gr in gvSingleTerm.Rows)
                    {
                        //if ((gr.FindControl("cbIncentive") as CheckBox).Checked == true)  // commented on 30.11.2017 for avoiding duplicate records for one time incentives
                        if ((gr.FindControl("cbIncentive") as CheckBox).Checked == true && (gr.FindControl("cbIncentive") as CheckBox).Enabled == true)
                        {
                            dt.Rows.Add((gr.FindControl("lblIncentiveId") as Label).Text, "", 0, 0);
                            dtIncentiveTypes.Rows.Add(2);
                        }
                    }

                    //foreach (GridViewRow gr in gvTpride.Rows)
                    //{
                    //    if ((gr.FindControl("cbIncentive") as CheckBox).Checked == true)
                    //    {
                    //        dt.Rows.Add((gr.FindControl("lblIncentiveId") as Label).Text, "", 0, 0);
                    //        dtIncentiveTypes.Rows.Add(1);
                    //    }
                    //}

                    foreach (GridViewRow gr in gvskillSet.Rows)
                    {
                        if ((gr.FindControl("cbIncentive") as CheckBox).Checked == true)
                        {
                            dt.Rows.Add((gr.FindControl("lblIncentiveId") as Label).Text, "", 0, 0);
                            dtIncentiveTypes.Rows.Add(4);
                        }
                    }
                }
                else
                {
                    dt = null; dtIncentiveTypes = null;
                }

                string msg = "";
                if (dt != null && dt.Rows.Count > 0 && rblSelection.SelectedIndex > -1)
                {
                    //msg = objDml.InsincentiveDtl(Convert.ToInt32(Session["IncentiveID"]),
                    //                            Convert.ToInt32(rblSelection.SelectedValue),
                    //                           Convert.ToInt32(Session["uid"]),
                    //                           dt);


                    msg = objDml.InsincentiveDtlNew(Convert.ToInt32(Session["IncentiveId"].ToString()),//Session["IncentiveID"]
                                               Convert.ToInt32(rblSelection.SelectedValue),
                                               Convert.ToBoolean(rblVehicleIncetive.SelectedValue == "0" ? false : true),
                                              Convert.ToInt32(Session["uid"]),
                                              dt);

                    var UniqueRows = dtIncentiveTypes.AsEnumerable().Distinct(DataRowComparer.Default);
                    Session["dtIncentiveTypes"] = dtIncentiveTypes = UniqueRows.AsEnumerable().OrderBy(r => r.Field<int>("IncentiveType")).CopyToDataTable();
                    // lblmsg.Text = " Incentives applied successfully, Please click Next for Uploading Documents.";

                    btnNext.Visible = true;
                    btnNext.PostBackUrl = "../../UI/Pages/frmIncentiveCAFDetails.aspx";

                    //btnNext.PostBackUrl = "../../UI/Tsipass/IncentiveSingleUploadsNew.aspx?q=" + dtIncentiveTypes.Rows[0]["IncentiveType"].ToString();
                    // string RedirectURL="../../UI/Tsipass/IncentiveSingleUploadsNew.aspx?q=" + dtIncentiveTypes.Rows[0]["IncentiveType"].ToString();
                    // ViewState["BntnNextPostBackURL"] = RedirectURL.ToString();

                    // btnNext.PostBackUrl = "../../UI/Tsipass/IncentiveSingleUploadsNew.aspx?q=" + dtIncentiveTypes.Rows[0]["IncentiveType"].ToString();
                    //btnNext.PostBackUrl = "../../UI/Tsipass/frmIncentiveCAFDetails.aspx?q=" + Request.QueryString["q"].ToString().Trim();

                    ViewState["IncentiveType"] = "";
                    ViewState["IncentiveType"] = dtIncentiveTypes.Rows[0]["IncentiveType"].ToString();
                    success.Visible = true;
                    //  lblmsg.Text = " Incentives applied successfully, Please click Next for Uploading Documents."; // commented on 28.10.2017

                    lblmsg.Text = "Please click on Next and fill the concerned forms to get the acknowledgment";

                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Incentives applied successfully, Please click Next for Uploading Documents');", true);  
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Please click on Next and fill the concerned forms to get the acknowledgment');", true);
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please select Incentive type (if applicable please select valid Dates).";
                    btnNext.Visible = false;
                }
                return btnNext.Visible;
            }
            catch (Exception ex) { Errors.ErrorLog(ex); return false; }
        }

        protected void rblSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { BindIncentives(); }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }

        private void BindIncentives()
        {
            try
            {
                if (rblVehicleIncetive.SelectedIndex > -1 && rblSelection.SelectedIndex > -1)
                {
                    int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());
                    int sector = Convert.ToInt32(Session["incentive_Sector"] == null ? "0" : Session["incentive_Sector"].ToString());

                    DataTable dt = new DataTable();
                    DataTable dtIncentiveType = new DataTable();
                    dtIncentiveType = objFetch.FetchIncentiveTypes();

                    //trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = trTpride.Visible = false;
                    //gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = gvTpride.DataSource = null;

                    trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = false;
                    gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = null;

                    gvRepetitive.DataBind();
                    gvSingleTerm.DataBind();
                    gvskillSet.DataBind();
                    //gvTpride.DataBind();

                    if (dtIncentiveType != null)
                    {
                        trNoIncentives.Visible = false;
                        for (int i = 0; i < dtIncentiveType.Rows.Count; i++)
                        {
                            //dt = objFetch.FetchIncentivesyCasterSector(caste, sector, i + 1, Convert.ToInt32(Session["IncentiveID"].ToString()));
                            //dt = objFetch.FetchIncentives(caste, sector,true,Convert.ToBoolean(rblSelection.SelectedValue),1,false,false, i + 1, Convert.ToInt32(Session["IncentiveID"].ToString()));

                            bool ghmc = false;
                            if (Session["Incentive_GHMC"].ToString() == "1")
                            {
                                ghmc = Convert.ToBoolean(0);             //Convert.ToBoolean(Session["Incentive_GHMC"]);
                            }
                            else if (Session["Incentive_GHMC"].ToString() == "0")
                            {
                                ghmc = Convert.ToBoolean(1);
                            }
                            // bool ghmc = Convert.ToBoolean(Session["Incentive_GHMC"]);
                            int r1 = Convert.ToInt32(rblSelection.SelectedValue);
                            int category = Convert.ToInt32(Session["Incentive_Category"]);
                            //   bool phc = Convert.ToBoolean(Session["Incentive_PHC"]);
                            bool phc = Convert.ToBoolean(0);
                            bool isveh = Convert.ToBoolean(Session["Incentive_isVehicle"]);
                            //  bool isveh = Convert.ToBoolean(0);
                            int count = i + 1;
                            int EntprIncentive = Convert.ToInt32(Session["IncentiveID"].ToString());

                            dt = objFetch.FetchIncentivesNewINCType(caste,
                                                            sector,
                                                            Convert.ToBoolean(Session["Incentive_GHMC"]),
                                                            //  Convert.ToBoolean(0),
                                                            Convert.ToInt32(rblSelection.SelectedValue),
                                                            Convert.ToInt32(Session["Incentive_Category"]),
                                                       Convert.ToBoolean(Session["Incentive_PHC"]),  // Convert.ToBoolean(0),   // PH
                                                            isveh,
                                                            i + 1,
                                                            Convert.ToInt32(Session["IncentiveID"].ToString())
                                                        );
                            switch (i + 1)
                            {
                                case 1:
                                    if (dt.Rows.Count > 0)
                                    {
                                        //trTpride.Visible = true;
                                        //objCmf.FillGrid(dt, gvTpride, false);
                                    }
                                    break;
                                case 2:
                                    if (dt.Rows.Count > 0)
                                    {
                                        trOnetime.Visible = true;
                                        objCmf.FillGrid(dt, gvSingleTerm, false);

                                        //btnSave.Enabled = false;
                                        //BtnClear.Enabled = false;
                                    }
                                    break;
                                case 3:
                                    if (dt.Rows.Count > 0)
                                    {

                                        trRegularIncentive.Visible = true;
                                        objCmf.FillGrid(dt, gvRepetitive, false);
                                        //btnSave.Enabled = false;
                                        //BtnClear.Enabled = false;
                                    }
                                    break;
                                case 4:
                                    if (dt.Rows.Count > 0)
                                    {
                                        trSkillset.Visible = true;
                                        objCmf.FillGrid(dt, gvskillSet, false);
                                        //btnSave.Enabled = false;
                                        //BtnClear.Enabled = false;
                                    }
                                    break;
                            }
                        }
                        if (!(trOnetime.Visible || trRegularIncentive.Visible || trSkillset.Visible)) trNoIncentives.Visible = true;

                        //btnSave.Enabled = false;
                        //btnNext.Enabled = true;
                    }
                }
                else { trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = false; }
            }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }

        protected void rblVehicleIncetive_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { BindIncentives(); }
            catch (Exception ex) { Errors.ErrorLog(ex); }
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

                    trRegularIncentive.Visible = true;
                    objCmf.FillGrid(objFetch.FetchIncentivesbyID(1), gvRepetitive, false);
                }
                else
                { rblSelection_SelectedIndexChanged(sender, e); }
            }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }

        protected void txtFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {

                GridViewRow gr = (((TextBox)sender).Parent.Parent as GridViewRow);
                TextBox txtFrom = (gr.FindControl("txtFrom") as TextBox);
                try
                {
                    if (txtFrom.Text.Trim() != "")
                    {
                        Failure.Visible = false;
                        DateTime dtFrom = Convert.ToDateTime(txtFrom.Text);
                        string abc = Session["Incentive_DateOfCommencement"].ToString();

                        string[] str = Session["Incentive_DateOfCommencement"].ToString().Split('/');
                        string dcp2 = str[1].ToString() + "/" + str[0].ToString() + "/" + str[2].ToString();

                        //  DateTime dt = Convert.ToDateTime(Session["Incentive_DateOfCommencement"].ToString());
                        DateTime dt = Convert.ToDateTime(dcp2);

                        if (dtFrom > dt.AddYears(9)) //if (dtFrom < dt || dtFrom > dt.AddYears(9)) incentive change
                        {
                            Failure.Visible = true;
                            lblmsg0.Text = "Please select Date between " + dt.ToString("dd-MMM-yyyy") + " and " + dt.AddYears(9).ToString("dd-MMM-yyyy");
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select Date between '" + dt.ToString("dd-MMM-yyyy") + " and " + dt.AddYears(9).ToString("dd-MMM-yyyy") + "');", true);
                        }
                    }
                }
                catch (Exception)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select valid Date (dd-MMM-yyyy).');", true);
                    Failure.Visible = true;
                    lblmsg0.Text = "Please select valid Date (dd-MMM-yyyy)";
                    txtFrom.Focus();
                    return;
                }


            }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }

        protected void txtTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gr = (((TextBox)sender).Parent.Parent as GridViewRow);
                TextBox txtTo = (gr.FindControl("txtTo") as TextBox);
                TextBox txtFrom = (gr.FindControl("txtFrom") as TextBox);

                string abcd = Session["Incentive_DateOfCommencement"].ToString();

                string[] str2 = Session["Incentive_DateOfCommencement"].ToString().Split('/');
                string dcp3 = str2[1].ToString() + "/" + str2[0].ToString() + "/" + str2[2].ToString();

                //    DateTime dt = Convert.ToDateTime(Session["Incentive_DateOfCommencement"].ToString());
                DateTime dt = Convert.ToDateTime(dcp3);


                if (txtFrom.Text.Trim() != "" && txtTo.Text.Trim() != "")
                {
                    txtFrom_TextChanged(sender, e);
                }
                try
                {
                    if (txtTo.Text.Trim() != "")
                    {
                        DateTime dtTo = Convert.ToDateTime(txtTo.Text);
                        DateTime dtfrom = Convert.ToDateTime(txtFrom.Text);

                        Failure.Visible = false;
                        if (dtTo < dtfrom)
                        {
                            Failure.Visible = true;
                            lblmsg0.Text = "To Date cannot be less than " + dtfrom.AddMonths(6).ToString("dd-MMM-yyyy");
                            System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('To Date cannot be less than" + dtfrom.AddMonths(6).ToString("dd-MMM-yyyy") + "');", true);
                        }
                        else if (dtTo > dt.AddYears(9))
                        {
                            Failure.Visible = true;
                            lblmsg0.Text = "To Date cannot be greater than " + dtfrom.AddYears(9).ToString("dd-MMM-yyyy");
                        }
                    }
                }
                catch (Exception)
                {
                    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please select valid Date (dd-MMM-yyyy).');", true);
                    Failure.Visible = true;
                    lblmsg0.Text = "Please select valid Date (dd-MMM-yyyy)";
                    txtTo.Focus();
                    return;
                }
            }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }



        // added for 2nd time applying   // added newly on 22.11.2017   
        protected void chkApplyAgainNew_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApplyAgainNew.Checked == true)
            {
                string applicationStatus = "";
                applicationStatus = ViewState["intstatusid"].ToString();

                if (Convert.ToInt32(applicationStatus) != null)
                {
                    EnableDisableForm(Page.Controls, true);
                }

                Session["EntprIncentiveOld"] = "";
                Session["EntprIncentiveOld"] = Session["IncentiveID"].ToString();

                Session["IncentiveID"] = "";

                //   BindIncentives();
                BindIncentives2ndTime();
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

        private void BindIncentives2ndTime()
        {
            try
            {
                if (rblVehicleIncetive.SelectedIndex > -1 && rblSelection.SelectedIndex > -1)
                {
                    int caste = Convert.ToInt32(Session["Incentive_Caste"] == null ? "0" : Session["Incentive_Caste"].ToString());
                    int sector = Convert.ToInt32(Session["incentive_Sector"] == null ? "0" : Session["incentive_Sector"].ToString());

                    DataTable dt = new DataTable();
                    DataTable dtIncentiveType = new DataTable();
                    dtIncentiveType = objFetch.FetchIncentiveTypes();

                    //trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = trTpride.Visible = false;
                    //gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = gvTpride.DataSource = null;

                    trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = false;
                    gvRepetitive.DataSource = gvSingleTerm.DataSource = gvskillSet.DataSource = null;

                    gvRepetitive.DataBind();
                    gvSingleTerm.DataBind();
                    gvskillSet.DataBind();
                    //gvTpride.DataBind();

                    if (dtIncentiveType != null)
                    {
                        trNoIncentives.Visible = false;
                        for (int i = 0; i < dtIncentiveType.Rows.Count; i++)
                        {
                            //dt = objFetch.FetchIncentivesyCasterSector(caste, sector, i + 1, Convert.ToInt32(Session["IncentiveID"].ToString()));
                            //dt = objFetch.FetchIncentives(caste, sector,true,Convert.ToBoolean(rblSelection.SelectedValue),1,false,false, i + 1, Convert.ToInt32(Session["IncentiveID"].ToString()));

                            bool ghmc = false;
                            if (Session["Incentive_GHMC"].ToString() == "1")
                            {
                                ghmc = Convert.ToBoolean(0);             //Convert.ToBoolean(Session["Incentive_GHMC"]);
                            }
                            else if (Session["Incentive_GHMC"].ToString() == "0")
                            {
                                ghmc = Convert.ToBoolean(1);
                            }
                            // bool ghmc = Convert.ToBoolean(Session["Incentive_GHMC"]);
                            int r1 = Convert.ToInt32(rblSelection.SelectedValue);
                            int category = Convert.ToInt32(Session["Incentive_Category"]);
                            //   bool phc = Convert.ToBoolean(Session["Incentive_PHC"]);
                            bool phc = Convert.ToBoolean(0);
                            bool isveh = Convert.ToBoolean(Session["Incentive_isVehicle"]);
                            //  bool isveh = Convert.ToBoolean(0);
                            int count = i + 1;
                            int EntprIncentive = Convert.ToInt32(Session["EntprIncentiveOld"].ToString());

                            dt = objFetch.FetchIncentivesNewINCType(caste,
                                                            sector,
                                                            Convert.ToBoolean(Session["Incentive_GHMC"]),
                                                            //  Convert.ToBoolean(0),
                                                            Convert.ToInt32(rblSelection.SelectedValue),
                                                            Convert.ToInt32(Session["Incentive_Category"]),
                                                       Convert.ToBoolean(Session["Incentive_PHC"]),  // Convert.ToBoolean(0),   // PH
                                                            isveh,
                                                            i + 1,
                                                            Convert.ToInt32(Session["EntprIncentiveOld"].ToString())
                                                        );
                            switch (i + 1)
                            {
                                case 1:
                                    if (dt.Rows.Count > 0)
                                    {
                                        //trTpride.Visible = true;
                                        //objCmf.FillGrid(dt, gvTpride, false);
                                    }
                                    break;
                                case 2:
                                    if (dt.Rows.Count > 0)
                                    {
                                        trOnetime.Visible = true;
                                        objCmf.FillGrid(dt, gvSingleTerm, false);
                                        //btnSave.Enabled = false;
                                        //BtnClear.Enabled = false;                                  

                                    }
                                    break;
                                case 3:
                                    if (dt.Rows.Count > 0)
                                    {

                                        trRegularIncentive.Visible = true;

                                        dt.Rows[0][4] = "";
                                        dt.Rows[0][5] = "";

                                        if (dt.Rows.Count > 1)
                                        {
                                            dt.Rows[1][4] = "";
                                            dt.Rows[1][5] = "";
                                        }

                                        if (dt.Rows.Count > 2)
                                        {
                                            dt.Rows[2][4] = "";
                                            dt.Rows[2][5] = "";
                                        }

                                        objCmf.FillGrid(dt, gvRepetitive, false);    // Commented for clear the regular incentives gridview                                  

                                        //btnSave.Enabled = false;
                                        //BtnClear.Enabled = false;
                                    }
                                    break;
                                case 4:
                                    if (dt.Rows.Count > 0)
                                    {
                                        trSkillset.Visible = true;
                                        objCmf.FillGrid(dt, gvskillSet, false);
                                        //btnSave.Enabled = false;
                                        //BtnClear.Enabled = false;
                                    }
                                    break;
                            }
                        }
                        if (!(trOnetime.Visible || trRegularIncentive.Visible || trSkillset.Visible)) trNoIncentives.Visible = true;

                        //btnSave.Enabled = false;
                        //btnNext.Enabled = true;
                    }
                }
                else { trOnetime.Visible = trRegularIncentive.Visible = trSkillset.Visible = false; }
            }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }

        public string InsertCommonDetailsbyUserid_2NDTime(string userid)
        {
            string valid = "";
            string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
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

        // need to uncomment for 2nd time applying
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ApplicationStatus = "";
                if (chkApplyAgainNew.Checked != true && (Session["IncentiveID"] != null && Session["IncentiveID"].ToString() != ""))
                {
                    DataSet ds = new DataSet();
                    ds = Gen.GetIncetiveApplicationStatus(Session["IncentiveID"].ToString());

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["intStatusid"] != null && ds.Tables[0].Rows[0]["intStatusid"].ToString() != "")
                        {
                            ApplicationStatus = ds.Tables[0].Rows[0]["intStatusid"].ToString();

                            //if (ApplicationStatus == null || ApplicationStatus == "2" || ApplicationStatus == string.Empty || ApplicationStatus == "6")
                            if (ApplicationStatus == null || ApplicationStatus == string.Empty || ApplicationStatus == "32")
                            {
                                //save();
                                if (save())
                                {
                                    string message = "alert('Please click on Next and fill the concerned forms to get the acknowledgment.')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    btnNext.Enabled = true;
                                    success.Visible = false;
                                }
                            }
                        }

                    }
                }
                // ADDED NEWLY ON 23.11.2017
                else if (chkApplyAgainNew.Visible == true && chkApplyAgainNew.Checked == true) // && (Session["uid"].ToString() == "2384" || Session["uid"].ToString() == "31357" || Session["uid"].ToString() == "5780" || Session["uid"].ToString() == "12696" || Session["uid"].ToString() == "11050" || Session["uid"].ToString() == "3483"))   // 
                {
                    string userid = "";
                    userid = Session["uid"].ToString();

                    string incentiveId = InsertCommonDetailsbyUserid_2NDTime(userid);

                    if (incentiveId != null && incentiveId != "")
                    {
                        Session["IncentiveID"] = incentiveId;
                        if (save())
                        {
                            string message = "alert('Please click on Next and fill the concerned forms to get the acknowledgment.')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            btnNext.Enabled = true;
                            success.Visible = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        // need to uncomment for 2nd time applying
        protected void gvRepetitive_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (chkApplyAgainNew.Checked == true)
                {
                    return;
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //DropDownList ddlfrom=(e.Row.FindControl("ddlPassingYearFrom") as DropDownList);
                    //DropDownList ddlto = (e.Row.FindControl("ddlPassingYearTo") as DropDownList);
                    //objCmf.BindCtlto(true,ddlfrom , dtYear(), 1, 0, false);
                    //objCmf.BindCtlto(true, ddlto, dtYear1(), 1, 0, false);

                    TextBox txtFrom = (e.Row.FindControl("txtFrom") as TextBox);
                    TextBox txtTo = (e.Row.FindControl("txtTo") as TextBox);

                    Label lbl = (e.Row.FindControl("lblDropdown") as Label);
                    if (lbl.Text.Trim() == "" || lbl.Text.Trim() == "0" || lbl.Text.ToLower() == "01-jan-1900") txtFrom.Text = ""; else txtFrom.Text = Convert.ToDateTime(lbl.Text).ToString("dd-MMM-yyyy");
                    if (lbl.ToolTip.Trim() == "" || lbl.ToolTip.Trim() == "0" || lbl.ToolTip.ToLower() == "01-jan-1900") txtTo.Text = ""; else txtTo.Text = Convert.ToDateTime(lbl.ToolTip).ToString("dd-MMM-yyyy");

                    lbl = (e.Row.FindControl("lbl") as Label);
                    //RadioButtonList rbl = (e.Row.FindControl("rblYesNo") as RadioButtonList);
                    //if (lbl.Text.Trim() == "" || lbl.Text.Trim() == "0") rbl.SelectedIndex = -1; else rbl.SelectedValue = lbl.Text.Trim();

                    (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = (lbl.ToolTip.Trim() == "" || lbl.ToolTip.Trim() == "0" ? false : true);

                    // if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim() == "3")
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim() == "3" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim() == "5" || Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim() == "1")
                    {
                        // commented on 26.11.2017
                        // DataSet dsA = objFetch.FetchIncentivesApplied(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim(), Convert.ToString(Session["IncentiveID"].ToString()));


                        // added on 26.11.2017 
                        DataSet dsA = objFetch.FetchIncentivesAppliedNewly(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveID")).Trim(), Convert.ToString(Session["IncentiveID"].ToString()));

                        if (dsA.Tables[0].Rows.Count > 0)
                        {


                            (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = false;
                            (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = true; // added newly on 26.11.2017
                        }

                        // else    // commented on 26.11.2017
                        //{
                        //    (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = true;
                        //    //(e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = false;  // 22/06/2017
                        //}

                        else // added newly on 26.11.2017
                        {
                            (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = false;
                            (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = true;
                        }
                    }
                    else
                    {
                        (e.Row.FindControl("cbIncentiveCheck") as CheckBox).Checked = false;
                        //(e.Row.FindControl("cbIncentiveCheck") as CheckBox).Enabled = true;    // 22/06/2017
                    }
                }

                // added on 26.04.2018
                if (trApplyNew.Visible == true && chkApplyAgainNew.Checked == false)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                        for (int a = 0; a <= gvRepetitive.Rows.Count; a++)
                        {
                            TextBox txtFrom = (e.Row.FindControl("txtFrom") as TextBox);
                            txtFrom.Enabled = false;
                            TextBox txtTo = (e.Row.FindControl("txtTo") as TextBox);
                            txtTo.Enabled = false;
                            CheckBox cbIncentiveCheck = (e.Row.FindControl("cbIncentiveCheck") as CheckBox);
                            cbIncentiveCheck.Enabled = false;
                        }
                    }
                }

                //
            }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }


        // added on 26.04.2018
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

        // added on 26.04.2018
        protected void gvskillSet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // added on 26.04.2018
            if (trApplyNew.Visible == true && chkApplyAgainNew.Checked == false)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    for (int a = 0; a <= gvskillSet.Rows.Count; a++)
                    {
                        CheckBox cbIncentive = (e.Row.FindControl("cbIncentive") as CheckBox);
                        cbIncentive.Enabled = false;
                    }
                }
            }
        }
    }
}