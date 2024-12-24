using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.ServiceModel;
//using System.ServiceModel.Description;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class IncentiveFormTTap : System.Web.UI.Page
    {
        comFunctions cmf = new comFunctions();
        General Gen = new General();
        Fetch objFetch = new Fetch();

        DataTable dtorg = new DataTable();
        DataSet dsdorg = new DataSet();

        //DataRow dtrdr;
        DataTable myDtNewRecdr = new DataTable();

        // LOA Epan
        //DataRow dtrdr10;
        DataTable myDtNewRecdr10 = new DataTable();

        static DataTable dtMyTable;

        //DataRow dtr;
        //static DataTable dtMyTablepr;
        static DataTable dtMyTableCertificate;

        // LOA expan
        //DataRow dtr10;
        static DataTable dtMyTableCertificate10;

        //DataRow dtrdr1;
        DataTable myDtNewRecdr1 = new DataTable();

        //DataRow dtrdr2;
        DataTable myDtNewRecdr2 = new DataTable();

        //DataRow dtrdr3;
        DataTable myDtNewRecdr3 = new DataTable();

        //DataRow dtrdr4;
        DataTable myDtNewRecdr4 = new DataTable();

       // DataRow dtrdr5;
        DataTable myDtNewRecdr9 = new DataTable();

        Label ProposedEmployement = new Label();

        static DataTable dtMyTable1;

        //DataRow dtr1;
        //static DataTable dtMyTablepr1;
        //static DataTable dtMyTableCertificate1;
        //static DataTable dtMyTableCertificate2;
        //static DataTable dtMyTableCertificate3;
        //static DataTable dtMyTableCertificate5;
        //static DataTable dtMyTableCertificate9;

        IncentivesVOs objvo = new IncentivesVOs();
        IncentiveVosA objvoA = new IncentiveVosA();
        //int orgtypevalue = 0;
        //string orgtypetext = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        //if (Request.QueryString["intApplicationId"] != null)
                        //{
                        //    hdfFlagID.Value = Request.QueryString["intApplicationId"];
                        //}
                        Session["applicationStatus"] = "";
                        Session["IncentveID"] = "0";
                        objvo.User_Id = Session["uid"].ToString();
                        string uname = Session["username"].ToString();
                        if (!IsPostBack)
                        {
                            MainView.ActiveViewIndex = 0;

                            DataSet ds = new DataSet();
                            getstatesUnit();
                            ddlUnitstate.SelectedValue = "31";
                            ddlUnitstate.Enabled = false;
                            ddlUnitstate_SelectedIndexChanged(sender, e);

                            getUdyogAadharType();

                            getstatesOffc();

                            BindConstitutionUnit();
                            BindBankAccountType();

                            cmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
                            cmf.BindCtlto(true, ddlCategory, objFetch.FetchCategory(), 1, 0, false);
                            cmf.BindCtlto(true, ddlintLineofActivity, objFetch.FetchLineofActivity(), 1, 0, false);

                            int i = AssignValuestoControls(objvo.User_Id, null);
                            Session["i"] = "";
                            Session["i"] = i;
                            if (i == 3)
                            {
                                AssignValuesAndSetValuesifExists(objvo.User_Id);
                            }

                            if (ddlIndustryStatus.SelectedItem.Text.ToUpper() == "NEW INDUSTRY")
                            {
                                trexpansion.Visible = false;
                            }

                            dtMyTableCertificate = createtablecrtificate1();
                            Session["CertificateTb2"] = dtMyTableCertificate;

                            // Expansion LOA 
                            dtMyTableCertificate10 = createtablecrtificate1();
                            Session["CertificateTb10"] = dtMyTableCertificate10;

                            dtMyTableCertificate3 = createtablecrtificateDir1();   //createtablecrtificate1();
                            Session["CertificateTb4"] = dtMyTableCertificate3;


                            dtMyTableCertificate9 = createtablecrtificate1();
                            Session["CertificateTb9"] = dtMyTableCertificate9;

                            if (ddlHvuInstalledScndhndMech.SelectedItem.Text.ToUpper() == "NO")
                            {
                                txtsecondhndmachine.Text = Convert.ToInt32("0").ToString();
                                txtnewmachine.Text = Convert.ToInt32("0").ToString();
                                txtTotalvalue12.Text = Convert.ToInt32("0").ToString();
                                txtpercentage12.Text = Convert.ToInt32("0").ToString();
                                txtmachinepucr.Text = Convert.ToInt32("0").ToString();
                                txttotal25.Text = Convert.ToInt32("0").ToString();
                            }

                            tblview3.Visible = true;
                            BtnSave.Visible = false;
                            BtnClear.Visible = false;

                            //rblSector.SelectedValue

                        }
                        rblSector_SelectedIndexChanged(sender, e);
                        if (rblVeh.Visible == true)
                        {
                            rblVeh_SelectedIndexChanged(sender, e);
                        }

                        string applicationStatus = Session["applicationStatus"].ToString();
                        if (applicationStatus.TrimStart().Trim() != "" && Convert.ToInt32(applicationStatus) >= 2)
                        {
                            rblVeh.Enabled = false;
                            rdIaLa_Lst.Enabled = false;
                            txtUdyogAadhaarRegdDate.Enabled = false;
                            ddlIndustryStatus.Enabled = false;
                            trdirectordetails.Visible = false;
                            trLabel12.Visible = false;
                            tblTermLoanDtls.Visible = false;
                        }
                    }
                    //added on 13.02.2019
                    //txtOffcMobileNO.Attributes.Add("onKeyPress", "javascript:return onlyNos(event);");
                    //txtunitmobileno.Attributes.Add("onKeyPress", "javascript:return onlyNos(event);");
                    //txtlandexisting.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
                    txtlandexisting.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtbuildingexisting.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtplantexisting.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    //txtbuildingexisting.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
                    //txtplantexisting.Attributes.Add("onKeyPress", "javascript:return isNumberKey(event);");
                    //txtstaffMale.Attributes.Add("onKeyPress", "javascript:return onlyNos(event,this);");
                    //txtfemale.Attributes.Add("onKeyPress", "javascript:return onlyNos(event,this);");
                    //txtsupermalecount.Attributes.Add("onKeyPress", "javascript:return onlyNos(event);");
                    //txtsuperfemalecount.Attributes.Add("onKeyPress", "javascript:return onlyNos(event);");
                    //txtSkilledWorkersMale.Attributes.Add("onKeyPress", "javascript:return onlyNos(event);");
                    //txtSkilledWorkersFemale.Attributes.Add("onKeyPress", "javascript:return onlyNos(event);");
                    //txtSemiSkilledWorkersMale.Attributes.Add("onKeyPress", "javascript:return onlyNos(event);");
                    //txtSemiSkilledWorkersFemale.Attributes.Add("onKeyPress", "javascript:return onlyNos(event);");

                    txtLand2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtLand3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtLand4.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtLand5.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtLand6.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtLand7.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

                    txtBuilding2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtBuilding3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtBuilding4.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtBuilding5.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtBuilding6.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtBuilding7.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

                    txtPM2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtPM3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtPM4.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtPM5.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtPM6.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtPM7.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

                    txtMCont2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtMCont3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtMCont4.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtMCont5.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtMCont6.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtMCont7.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

                    txtErec2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtErec3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtErec4.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtErec5.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtErec6.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtErec7.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

                    txtTFS2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtTFS3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtTFS4.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtTFS5.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtTFS6.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtTFS7.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");

                    txtWC2.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtWC3.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtWC4.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtWC5.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtWC6.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");
                    txtWC7.Attributes.Add("onKeyPress", "javascript:return ValidateDecimal(event,this);");


                    rblSector_SelectedIndexChanged(sender, e);
                    txtuidno_TextChanged(sender, e);

                    EnableDisableForm(Page.Controls, true);
                }
                //BindBankAccountType();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Total

        protected void ddlPower_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPower.SelectedIndex == 0 || ddlPower.SelectedIndex == 1)
            {
                powertr.Visible = false;
            }
            else
            {
                powertr.Visible = true;
            }
        }
        protected void btnInstalledcap_Click(object sender, EventArgs e)
        {
            int valid = 0;
            try
            {
                if (txtLOActivity.Text == "" || txtLOActivity.Text == null)
                {
                    lblmsg0.Text = "Line Of Activity Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    txtLOActivity.Focus();
                    valid = 1;
                }
                if (txtinstalledccap.Text == "" || txtinstalledccap.Text == null)
                {
                    lblmsg0.Text = "Installed Capacity Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    txtinstalledccap.Focus();
                    valid = 1;
                }
                if (txtvalue.Text == "" || txtvalue.Text == null)
                {
                    lblmsg0.Text = "Value Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    txtvalue.Focus();
                    valid = 1;
                }
                string strunit = "";

                if (ddlquantityin.SelectedItem.Text == "--Select--")
                {
                    lblmsg0.Text = "Please Select Unit" + "<br/>";
                    Failure.Visible = true;
                    ddlquantityin.Focus();
                    valid = 1;
                }
                else
                {
                    strunit = ddlquantityin.SelectedItem.Text;
                }
                if (ddlquantityin.SelectedItem.Text == "Others")
                {
                    if (txtunit.Text == "" || txtunit.Text == null)
                    {
                        lblmsg0.Text = "Unit Cannot be blank" + "<br/>";
                        Failure.Visible = true;
                        txtunit.Focus();
                        valid = 1;
                    }
                    else
                    {
                        strunit = txtunit.Text;
                    }
                }
                if (valid == 0)
                {
                    if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
                    {
                        AddDataToTableCeertificate(txtLOActivity.Text, strunit, txtinstalledccap.Text, txtvalue.Text, Session["uid"].ToString(), "", "", (DataTable)Session["CertificateTb2"]);

                        this.gvInstalledCap.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvInstalledCap.DataBind();
                        ClearTxt();
                    }
                    else
                        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                    {
                        AddDataToTableCeertificate(txtLOActivity.Text, txtunit.Text, txtinstalledccap.Text, txtvalue.Text, Session["uid"].ToString(), "", "", (DataTable)Session["CertificateTb2"]);
                        this.gvInstalledCap.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                        this.gvInstalledCap.DataBind();
                        ClearTxt();
                    }
                    gvInstalledCap.Visible = true;
                    lblmsg0.Text = "";
                    Failure.Visible = false;

                    txtLOActivity.Text = "";
                    txtinstalledccap.Text = "";
                    txtvalue.Text = "";
                    //    ddlquantityin.Items.Clear();

                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        protected void ddlindustryStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                trFixedcap.Visible = true;
                if (ddlIndustryStatus.SelectedItem.Text == "New Industry")
                {
                    Label1.Text = "New Enterprise Line of Activity Details : ";
                    trNewIndustry.Visible = true;
                    trexpansion.Visible = false; trexpansionnew.Visible = false;
                    trFixedcap.Visible = true;
                    divIndustryExpansionType.Visible = false;

                    GridView1.DataSource = null;
                    GridView1.DataBind();


                    gvInstalledCap.DataSource = null;
                    gvInstalledCap.DataBind();


                    gvInstalledCapExpan.DataSource = null;
                    gvInstalledCapExpan.DataBind();


                    dtMyTableCertificate = createtablecrtificate1();
                    Session["CertificateTb2"] = dtMyTableCertificate;

                    dtMyTableCertificate10 = createtablecrtificate1();
                    Session["CertificateTb10"] = dtMyTableCertificate10;

                    // for power 
                    tblpower1.Visible = true;
                    tblpower2.Visible = false;
                    lblpowerHEAD.Text = "New Enterprise ";

                    // for fixed capital grid rows visible false 
                    // Deepakk
                    //tdzxz.Visible = false;
                    trFixedCapitalexpansion.Visible = false;
                    trFixedCapitalland.Visible = false;
                    trFixedCapitalBuilding.Visible = false;
                    trFixedCapitalMach.Visible = false;

                    trFixedCapitalexpnPercent.Visible = false;
                    txtbuildcapacityPercet.Visible = false;
                    trFixedCapitMachPercent.Visible = false;
                    trFixedCapitBuildPercent.Visible = false;


                }
                else if (ddlIndustryStatus.SelectedItem.Text == "Expansion")
                {
                    Label1.Text = "Existing Enterprise Line of Activity Details : ";
                    trNewIndustry.Visible = true; //trNewIndustry.Visible = false;
                    divIndustryExpansionType.Visible = true;

                    trexpansionnew.Visible = true; // tblexpsnsion.Visible = true;


                    gvInstalledCapExpan.DataSource = null;
                    gvInstalledCapExpan.DataBind();

                    gvInstalledCap.DataSource = null;
                    gvInstalledCap.DataBind();

                    dtMyTableCertificate = createtablecrtificate1();
                    Session["CertificateTb2"] = dtMyTableCertificate;

                    dtMyTableCertificate10 = createtablecrtificate1();
                    Session["CertificateTb10"] = dtMyTableCertificate10;

                    // gvInstalledCap.Visible = false;

                    txtLOActivity.Text = "";
                    txtinstalledccap.Text = "";
                    txtvalue.Text = "";
                    txtunit.Text = "";

                    // Deepakk
                    trFixedCapitalexpansion.Visible = true;
                    trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    trFixedCapitalexpnPercent.Visible = true;
                    txtbuildcapacityPercet.Visible = true;
                    trFixedCapitMachPercent.Visible = true;
                    trFixedCapitBuildPercent.Visible = true;

                    //tdzxz.Visible = true;


                    //   trexpansion.Visible = true; 
                    // trexpansionnew.Visible = false;  // LOA Expan
                    lblexpan1.Text = "";
                    lblexpan2.Text = "";
                    lblexpan3.Text = "";
                    lblexpan1.Text = "EXPANSION";
                    lblexpan2.Text = "Expansion";
                    lblexpan3.Text = "Expansion";

                    // for power  grid
                    tblpower2.Visible = true;
                    tblpower1.Visible = false;

                    lblexistingpower.Text = "Existing Enterprise production details";
                    lblexpandiverpower.Text = "Expansion / Diversification details";
                }
                else if (ddlIndustryStatus.SelectedItem.Text == "Diversification")
                {
                    Label1.Text = "Existing Enterprise Line of Activity Details : ";
                    trNewIndustry.Visible = true;   //trNewIndustry.Visible = false;
                                                    //  trIndustryExpansionType.Visible = false;

                    gvInstalledCap.DataSource = null;
                    gvInstalledCap.DataBind();
                    gvInstalledCap.Visible = false;

                    // Deepakk
                    trFixedCapitalexpansion.Visible = true;
                    trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    trFixedCapitalexpnPercent.Visible = true;
                    txtbuildcapacityPercet.Visible = true;
                    trFixedCapitMachPercent.Visible = true;
                    trFixedCapitBuildPercent.Visible = true;
                    //tdzxz.Visible = true;

                    // trexpansion.Visible = true;
                    trexpansionnew.Visible = true;
                    lblexpan1.Text = "";
                    lblexpan2.Text = "";
                    lblexpan3.Text = "";
                    lblexpan1.Text = "DIVERSIFICATION";
                    lblexpan2.Text = "Diversification";
                    lblexpan3.Text = "Diversification";

                    // for power  grid
                    tblpower2.Visible = true;
                    tblpower1.Visible = false;

                    lblexistingpower.Text = "Existing Enterprise production details";
                    lblexpandiverpower.Text = "Expansion / Diversification details";
                }
                else
                {
                    trNewIndustry.Visible = false;
                    trexpansion.Visible = false; trexpansionnew.Visible = false;
                }
                trFixedcap.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlPowerStatus_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (ddlPowerStatus.SelectedItem.Text == "New Industry")
                {
                    tblpower1.Visible = true;
                    tblpower2.Visible = false;
                    lblpowerHEAD.Text = "New Enterprise";
                }
                else if (ddlPowerStatus.SelectedItem.Text == "Expansion/Diversification")
                {
                    tblpower2.Visible = true;
                    tblpower1.Visible = false;

                    lblexistingpower.Text = "Existing Enterprise production details";
                    lblexpandiverpower.Text = "Expansion / Diversification details";
                }
                else
                {

                    tblpower1.Visible = false;
                    tblpower2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
            }
        }
        protected void gvInstalledCap_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if ((hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == ""))
                {
                    ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);

                    this.gvInstalledCap.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                    this.gvInstalledCap.DataBind();
                }
                else
                {
                    if (hdfFlagID.Value.Trim() != "")
                    {
                        try
                        {
                            string traineetradesnames = gvInstalledCap.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                            DataSet dsna = new DataSet();
                            int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                            ((DataTable)Session["CertificateTb2"]).Rows.RemoveAt(e.RowIndex);
                            this.gvInstalledCap.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                            this.gvInstalledCap.DataBind();
                        }
                        catch (Exception eee)
                        {
                            throw eee;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvInstalledCap_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected DataTable createtablecrtificate1()
        {
            dtMyTable1 = new DataTable("CertificateTb1");

            dtMyTable1.Columns.Add("new", typeof(string));
            dtMyTable1.Columns.Add("Column1", typeof(string));
            dtMyTable1.Columns.Add("Column2", typeof(string));
            dtMyTable1.Columns.Add("Column3", typeof(string));
            dtMyTable1.Columns.Add("Column4", typeof(string));
            dtMyTable1.Columns.Add("Column5", typeof(string));
            dtMyTable1.Columns.Add("Column6", typeof(string));
            dtMyTable1.Columns.Add("Column7", typeof(string));
            dtMyTable1.Columns.Add("Created_by", typeof(string));

            dtMyTable1.Columns.Add("intLineofActivityMid", typeof(string));

            return dtMyTable1;
        }
        // DIRECTORS GRID

        protected DataTable createtablecrtificateDir1()
        {
            dtMyTable1 = new DataTable("CertificateDirTb1");

            dtMyTable1.Columns.Add("new", typeof(string));
            dtMyTable1.Columns.Add("Column1", typeof(string));
            dtMyTable1.Columns.Add("Column2", typeof(string));
            dtMyTable1.Columns.Add("Column3", typeof(string));
            dtMyTable1.Columns.Add("Column4", typeof(string));
            dtMyTable1.Columns.Add("Column5", typeof(string));
            dtMyTable1.Columns.Add("Column6", typeof(string));
            dtMyTable1.Columns.Add("Column7", typeof(string));
            dtMyTable1.Columns.Add("Column8", typeof(string));
            dtMyTable1.Columns.Add("Column9", typeof(string));
            dtMyTable1.Columns.Add("Column10", typeof(string));
            dtMyTable1.Columns.Add("Column11", typeof(string));
            dtMyTable1.Columns.Add("Created_by", typeof(string));

            dtMyTable1.Columns.Add("intLineofActivityMid", typeof(string));

            return dtMyTable1;
        }

        // (txtLOActivityExpan.Text, strunit, txtinstalledccapExpan.Text, txtvalueExpan.Text, Session["uid"].ToString(), "Expansion LOA", "", (DataTable)Session["CertificateTb10"]);
        //(txtnamedparter.Text, ddlcommunity.SelectedItem.Text, txtshare.Text, txtpercentage.Text, txtAuthorisedSign.Text, ddlAuthorisedDesignation.SelectedItem.Text, ddlgender2.SelectedItem.Text, (DataTable)Session["CertificateTb4"]);
        //ddlTermLoanNo.SelectedValue, LoanApplnDate, txtnmofinstitution.Text, LoanSanctnDate, "", "", txtsactionedloan.Text, (DataTable)Session["CertificateTb9"]);
        private void AddDataToTableCeertificate(string intQuessionaireid, string intCFEEnterpid, string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, string Manf_Item_Quantity_Per, string OtherItemName, DataTable myTable)
        {
            try
            {

                DataRow Row;
                Row = myTable.NewRow();

                dtMyTable = new DataTable("CertificateTb2");

                Row["new"] = "0";
                Row["Column1"] = intQuessionaireid;
                Row["Column2"] = intCFEEnterpid;
                Row["Column3"] = Manf_ItemName;
                Row["Column4"] = Manf_Item_Quantity;
                Row["Column5"] = Manf_Item_Quantity_In;
                Row["Column6"] = Manf_Item_Quantity_Per;
                Row["Column7"] = OtherItemName;
                Row["Created_by"] = Session["uid"].ToString().Trim();

                Row["intLineofActivityMid"] = "0";
                myTable.Rows.Add(Row);
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }


        // FOR DIRECTOR GRID
        private void AddDataToTableCeertificateDir(string intQuessionaireid, string intCFEEnterpid, string Manf_ItemName, string Manf_Item_Quantity, string Manf_Item_Quantity_In, string Manf_Item_Quantity_Per, string OtherItemName, string OtherItemName2, string DirMobile, string DirEmail, string DirPAN, DataTable myTable)
        {
            try
            {

                DataRow Row;
                Row = myTable.NewRow();

                dtMyTable = new DataTable("CertificateTb4");

                Row["new"] = "0";
                Row["Column1"] = intQuessionaireid;
                Row["Column2"] = intCFEEnterpid;
                Row["Column3"] = Manf_ItemName;
                Row["Column4"] = Manf_Item_Quantity;
                Row["Column5"] = Manf_Item_Quantity_In;
                Row["Column6"] = Manf_Item_Quantity_Per;
                Row["Column7"] = OtherItemName;
                Row["Column8"] = OtherItemName2;
                Row["Column9"] = DirMobile;
                Row["Column10"] = DirEmail;
                Row["Column11"] = DirPAN;

                Row["Created_by"] = Session["uid"].ToString().Trim();

                Row["intLineofActivityMid"] = "0";
                myTable.Rows.Add(Row);
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }



        protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if ((hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == ""))
                {
                    ((DataTable)Session["CertificateTb4"]).Rows.RemoveAt(e.RowIndex);

                    this.GridView3.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                    this.GridView3.DataBind();
                }
                else
                {
                    if (hdfFlagID.Value.Trim() != "")
                    {
                        try
                        {
                            string traineetradesnames = GridView3.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                            DataSet dsna = new DataSet();
                            int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                            ((DataTable)Session["CertificateTb4"]).Rows.RemoveAt(e.RowIndex);
                            this.GridView3.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                            this.GridView3.DataBind();
                        }
                        catch (Exception eee)
                        {
                            throw eee;
                        }
                    }
                }
                if (GridView3.Rows.Count == 0)
                {
                    Button5.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            int valid = 0;
            try
            {
                if (txtnamedparter.Text == "" || txtnamedparter.Text == null)
                {
                    //lblmsg0.Text = "Name Cannot be blank" + "<br/>";
                    //Failure.Visible = true;
                    txtnamedparter.Focus();
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Name Cannot be blank');", true);
                    return;
                }
                if (ddlcommunity.SelectedValue == "0")
                {
                    //lblmsg0.Text = "Please Select Community" + "<br/>";
                    //Failure.Visible = true;
                    ddlcommunity.Focus();
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Community Cannot be blank');", true);
                    return;
                }
                if (txtshare.Text == "" || txtshare.Text == null)
                {
                    //lblmsg0.Text = "Share Cannot be blank" + "<br/>";
                    //Failure.Visible = true;
                    txtshare.Focus();
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Share Cannot be blank');", true);
                    return;
                }
                if (txtpercentage.Visible == true)
                {
                    if (txtpercentage.Text == "" || txtpercentage.Text == null)
                    {
                        //lblmsg0.Text = "% Cannot be blank" + "<br/>";
                        //Failure.Visible = true;
                        txtpercentage.Focus();
                        valid = 1;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Share % Cannot be blank');", true);
                        return;
                    }
                }
                //if (txtAuthorisedSign.Text == "" || txtAuthorisedSign.Text == null)
                //{
                //    lblmsg0.Text = "Ahorised Signatory Cannot be blank" + "<br/>";
                //    Failure.Visible = true;
                //    txtAuthorisedSign.Focus();
                //    valid = 1;
                //}
                if (ddlgender2.Visible == true)
                {
                    if (ddlgender2.SelectedItem.Text == "--Gender--" || ddlgender2.SelectedValue == "0")
                    {
                        //lblmsg0.Text = "Gender Cannot be blank" + "<br/>";
                        //Failure.Visible = true;
                        ddlgender2.Focus();
                        valid = 1;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Gender Cannot be blank');", true);
                        return;
                    }
                }
                if (ddlAuthorisedDesignation.SelectedValue == "0")
                {
                    ddlAuthorisedDesignation.Focus();
                    valid = 1;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Authorised designation Cannot be blank');", true);
                    return;
                }
                else
                {
                    if (ddlAuthorisedDesignation.SelectedValue == "3" && txtdesignationOther.Text.Trim().TrimStart() == "")
                    {
                        txtdesignationOther.Focus();
                        valid = 1;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Authorised designation Cannot be blank');", true);
                        return;
                    }
                }

                string Designation = "";
                if (ddlAuthorisedDesignation.SelectedValue == "3" && txtdesignationOther.Text.Trim().TrimStart() != "")
                {
                    Designation = txtdesignationOther.Text.Trim().TrimStart();

                }
                else
                {
                    Designation = ddlAuthorisedDesignation.SelectedItem.Text;
                }

                if (valid == 0)
                {
                    if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
                    {
                        AddDataToTableCeertificateDir(txtnamedparter.Text, ddlcommunity.SelectedItem.Text, txtshare.Text, txtpercentage.Text, null, Designation, ddlgender2.SelectedItem.Text, "", txtDirectorMobNo.Text, txtDirecEmail.Text, txtDirectPAN.Text, (DataTable)Session["CertificateTb4"]);

                        this.GridView3.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                        this.GridView3.DataBind();
                        ClearTxt();
                    }
                    else if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                    {
                        AddDataToTableCeertificateDir(txtnamedparter.Text, ddlcommunity.SelectedItem.Text, txtshare.Text, txtpercentage.Text, null, Designation, ddlgender2.SelectedItem.Text, "", txtDirectorMobNo.Text, txtDirecEmail.Text, txtDirectPAN.Text, (DataTable)Session["CertificateTb4"]);
                        this.GridView3.DataSource = ((DataTable)Session["CertificateTb4"]).DefaultView;
                        this.GridView3.DataBind();
                        ClearTxt();
                    }
                    GridView3.Visible = true;
                    lblmsg0.Text = "";
                    Failure.Visible = false;
                    if (ddlOrgType.SelectedValue == "1")
                    {
                        Button5.Enabled = false;
                    }
                    else
                    {
                        Button5.Enabled = true;
                    }
                    txtnamedparter.Text = "";
                    ddlcommunity.SelectedValue = "0";
                    txtshare.Text = "";
                    txtpercentage.Text = "";
                    ddlAuthorisedDesignation.SelectedValue = "0";
                    ddlgender2.SelectedValue = "0";
                    txtdesignationOther.Text = "";
                    ddlAuthorisedDesignation_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        public void ClearTxt()
        {
            txtLOActivity.Text = "";
            txtunit.Text = "";
            txtinstalledccap.Text = "";
            txtvalue.Text = "";

            // txtnamedparter.Text = "";
            // txtshare.Text = "";
            // txtpercentage.Text = "";
        }
        public void BindDistricts()
        {
            try
            {
                DataSet dsd = new DataSet();
                ddlUnitDIst.Items.Clear();
                dsd = Gen.GetDistrictsWithoutHYD();
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddlUnitDIst.DataSource = dsd.Tables[0];
                    ddlUnitDIst.DataValueField = "District_Id";
                    ddlUnitDIst.DataTextField = "District_Name";
                    ddlUnitDIst.DataBind();
                    //ddlUnitDIst.Items.Insert(0, "--District--");
                    AddSelect(ddlUnitDIst);
                }
                else
                {
                    //ddlUnitDIst.Items.Insert(0, "--District--");
                    AddSelect(ddlUnitDIst);
                }
            }
            catch (Exception ex)
            {
                //lblerror.Text = ex.Message;
                //lblerror.CssClass = "errormsg";
            }
        }
        public void BindDistricts1()
        {
            try
            {
                DataSet dsd = new DataSet();
                ddlOffcDIst.Items.Clear();
                dsd = Gen.GetDistrictsWithoutHYD();
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddlOffcDIst.DataSource = dsd.Tables[0];
                    ddlOffcDIst.DataValueField = "District_Id";
                    ddlOffcDIst.DataTextField = "District_Name";
                    ddlOffcDIst.DataBind();
                    // ddlOffcDIst.Items.Insert(0, "--District--");
                    AddSelect(ddlOffcDIst);
                }
                else
                {
                    AddSelect(ddlOffcDIst);
                    // ddlOffcDIst.Items.Insert(0, "--District--");
                }
            }
            catch (Exception ex)
            {
                //lblerror.Text = ex.Message;
                //lblerror.CssClass = "errormsg";
            }
        }

        protected void ddldistrictunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUnitDIst.SelectedIndex == 0)
            {
                ddlUnitMandal.Items.Clear();
                // ddlUnitMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlUnitMandal);
            }
            else
            {
                ddlUnitMandal.Items.Clear();
                DataSet dsm = new DataSet();
                // added newly for testing only

                //if (ddlUnitDIst.SelectedValue == "Medchal")
                //{
                //    ddlUnitDIst.SelectedValue = "20";
                //}

                dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlUnitMandal.DataSource = dsm.Tables[0];
                    ddlUnitMandal.DataValueField = "Mandal_Id";
                    ddlUnitMandal.DataTextField = "Manda_lName";
                    ddlUnitMandal.DataBind();
                    // ddlUnitMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlUnitMandal);
                }
                else
                {
                    ddlUnitMandal.Items.Clear();
                    //ddlUnitMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlUnitMandal);
                }
            }
        }
        protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUnitMandal.SelectedIndex == 0)
            {

                ddlVillageunit.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddlVillageunit);
            }
            else
            {
                ddlVillageunit.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlUnitMandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlVillageunit.DataSource = dsv.Tables[0];
                    ddlVillageunit.DataValueField = "Village_Id";
                    ddlVillageunit.DataTextField = "Village_Name";
                    ddlVillageunit.DataBind();
                    AddSelect(ddlVillageunit);
                    //  ddlVillageunit.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlVillageunit.Items.Clear();
                    // ddlVillageunit.Items.Insert(0, "--Village--");
                    AddSelect(ddlVillageunit);
                }
            }
        }
        protected void ddldistrictoffc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOffcDIst.SelectedIndex == 0)
            {
                ddlOffcMandal.Items.Clear();
                // ddlOffcMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlOffcMandal);
                //ChkWater_reg_from.Items.Clear();
                //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlOffcMandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlOffcDIst.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlOffcMandal.DataSource = dsm.Tables[0];
                    ddlOffcMandal.DataValueField = "Mandal_Id";
                    ddlOffcMandal.DataTextField = "Manda_lName";
                    ddlOffcMandal.DataBind();
                    //ddlOffcMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlOffcMandal);
                }
                else
                {
                    ddlOffcMandal.Items.Clear();
                    //ddlOffcMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlOffcMandal);
                }
            }
        }
        protected void ddloffcmandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOffcMandal.SelectedIndex == 0)
            {

                ddlOffcVil.Items.Clear();
                // ddlOffcMandal.Items.Insert(0, "--Village--");
                AddSelect(ddlOffcVil);
            }
            else
            {
                ddlOffcVil.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlOffcMandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlOffcVil.DataSource = dsv.Tables[0];
                    ddlOffcVil.DataValueField = "Village_Id";
                    ddlOffcVil.DataTextField = "Village_Name";
                    ddlOffcVil.DataBind();
                    //ddlOffcVil.Items.Insert(0, "--Village--");
                    AddSelect(ddlOffcVil);
                }
                else
                {
                    ddlOffcVil.Items.Clear();
                    //ddlOffcVil.Items.Insert(0, "--Village--");
                    AddSelect(ddlOffcVil);
                }
            }
        }
        protected void GetNewRectoInsertdr()
        {
            myDtNewRecdr = (DataTable)Session["CertificateTb2"];
            DataView dvdr = new DataView(myDtNewRecdr);
            myDtNewRecdr = dvdr.ToTable();
        }
        // LOA Expan 
        protected void GetNewRectoInsertdr10()
        {
            myDtNewRecdr10 = (DataTable)Session["CertificateTb10"];
            DataView dvdr10 = new DataView(myDtNewRecdr10);
            myDtNewRecdr10 = dvdr10.ToTable();
        }

        protected void GetNewRectoInsertdr1()
        {
            myDtNewRecdr1 = (DataTable)Session["CertificateTb4"];
            DataView dvdr1 = new DataView(myDtNewRecdr1);
            myDtNewRecdr1 = dvdr1.ToTable();

        }
        protected void GetNewRectoInsertdr9()
        {
            myDtNewRecdr9 = (DataTable)Session["CertificateTb9"];
            DataView dvdr9 = new DataView(myDtNewRecdr9);
            myDtNewRecdr9 = dvdr9.ToTable();

        }
        protected void GetNewRectoInsertdr2()
        {
            myDtNewRecdr2 = (DataTable)Session["CertificateTb3"];
            DataView dvdr2 = new DataView(myDtNewRecdr2);
            myDtNewRecdr2 = dvdr2.ToTable();
        }
        protected void GetNewRectoInsertdr3()
        {
            myDtNewRecdr3 = (DataTable)Session["CertificateTb4"];
            DataView dvdr3 = new DataView(myDtNewRecdr3);
            myDtNewRecdr3 = dvdr3.ToTable();
        }
        protected void GetNewRectoInsertdr4()
        {
            myDtNewRecdr4 = (DataTable)Session["CertificateTb5"];
            DataView dvdr4 = new DataView(myDtNewRecdr4);
            myDtNewRecdr4 = dvdr4.ToTable();
        }
        public void SetValuesToControls()
        {
            try
            {
                if (objvo.UnitName != "")
                {
                    txtUser_Id.Text = objvo.UnitName;
                }
                if (objvo.ApplciantName != "")
                {
                    txtApplciantName.Text = objvo.ApplciantName;
                    //txtApplciantName.Enabled = false;
                }
                if (objvo.PanNo != "")
                {
                    txtPanNo.Text = objvo.PanNo;
                    //txtPanNo.Enabled = false;
                }
                if (objvo.UnitState != "")
                {
                    ddlUnitstate.SelectedValue = objvo.UnitState;
                }
                if (objvo.UnitDIst != "")
                {
                    ddlUnitDIst.SelectedValue = objvo.UnitDIstId;
                    //ddlUnitDIst.SelectedValue = Session["unitdistid"].ToString();

                    // ddlUnitDIst.Enabled = false;
                }
                Getmandalsunit();
                if (objvo.UnitMandal != "")
                {
                    ddlUnitMandal.SelectedValue = objvo.UnitMandalId;
                    //ddlUnitMandal.SelectedValue = Session["unitmandalid"].ToString();
                    //   ddlUnitMandal.Enabled = false;
                }
                Getvillagesunit();
                if (objvo.UnitVill != "")
                {
                    ddlVillageunit.SelectedValue = objvo.UnitVillId;
                    //ddlVillageunit.SelectedValue = Session["unitvillageid"].ToString();
                    // ddlVillageunit.Enabled = false;
                    ddlVillageunit_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (objvo.Category != "")
                {
                    ddlCategory.SelectedValue = objvo.Category;
                    // ddlCategory.Enabled = false;
                }
                // added newly 
                if (objvo.OrgType != "")
                {
                    ddlOrgType.SelectedItem.Text = objvo.OrgType;
                    // ddlOrgType.Enabled = false;
                }

                if (objvo.SocialStatus != "")
                {
                    rblCaste.SelectedValue = objvo.SocialStatus;
                    //  rblCaste.Enabled = true;
                }

                if (objvo.AuthorisedSignatory != "")
                {
                    txtAuthorisedSign.Text = objvo.AuthorisedSignatory;
                    //txtAuthorisedSign.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AssignValuesAndSetValuesifExists(string userid)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = Gen.GetIncentivesdata(userid);

                if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    objvo.UnitName = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                    objvo.ApplciantName = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                    objvo.PanNo = ds.Tables[0].Rows[0]["PANcardno"].ToString();
                    objvo.UnitDIst = ds.Tables[0].Rows[0]["District_Name"].ToString();
                    objvo.UnitDIstId = ds.Tables[0].Rows[0]["District_Id"].ToString();
                    //Session["unitdistid"] = objvo.UnitDIstId;
                    objvo.UnitMandal = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                    objvo.UnitMandalId = ds.Tables[0].Rows[0]["Mandal_Id"].ToString();
                    //Session["unitmandalid"] = objvo.UnitMandalId;
                    objvo.UnitVill = ds.Tables[0].Rows[0]["Village_Name"].ToString();
                    objvo.UnitVillId = ds.Tables[0].Rows[0]["Village_Id"].ToString();
                    //Session["unitvillageid"] = objvo.UnitVillId;
                    //objvo1.unithno = ds.Tables[0].Rows[0]["HNO"].ToString();
                    //objvo1.unitstreet = ds.Tables[0].Rows[0]["StreetName"].ToString();
                    objvo.Category = ds.Tables[0].Rows[0]["Category"].ToString();
                    //objvo1.ostatus = ds.Tables[0].Rows[0]["constitutionUnit"].ToString();
                    //objvo1.istatus = ds.Tables[0].Rows[0]["ProposalFor"].ToString();
                    objvo.SocialStatus = ds.Tables[0].Rows[0]["caste"].ToString();

                    // added newly on 15.05.2015
                    objvo.OrgType = ds.Tables[0].Rows[0]["constitutionUnit"].ToString();
                    objvo.UnitState = "31"; // default unit state is Telanagana             

                    SetValuesToControls();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Deepak
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            if (save())
            {
                //lblmsg.Text = "<font color=Black>Application Submitted Sucessfully</font>";
                //success.Visible = true;
                // btnNext.Visible = true;
                //btnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                // Response.Redirect("../../IncentivesCheckSlip.aspx");
                string message = "alert('Application Submitted Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Sucessfully');" + "window.location='IncentivesCheckSlip.aspx';", true);
                BtnSave.Enabled = false;
                BtnSave.Visible = false;
                btnNext.Visible = true;
                BtnClear.Enabled = false;
                Response.Redirect("frmCommonAttachments.aspx");
            }
        }

        public bool save()
        {
            AssignValuestoVosFromcontrols("1l");
            bool val = false;
            string incentiveId = Gen.InsertCommonData(objvo);
            Session["IncentiveID"] = incentiveId;
            if (incentiveId != "")
            {
                objvoA.Incentive_id = incentiveId;
                string out2 = Gen.SaveNameofAssets(objvoA);

                if (out2 == "1")
                {
                    int valid = 0;
                    valid = Convert.ToInt32(SaveIncentiveDetailsFromGridViewToTable(incentiveId));

                    if (valid == 1)
                    {
                        //TIDEA/TPRIDE flag updation
                        string flagupdate = Gen.UpdateTideaTprimeFlag(incentiveId);

                        //objvoA.Incentive_id = incentiveId;
                        //string out2 = Gen.SaveNameofAssets(objvoA);
                        val = true;
                    }

                }

            }
            return val;
        }



        public int SaveIncentiveDetailsFromGridViewToTable(string incentiveId)
        {
            int Value = 0;
            int statuspr = 0;

            if (((DataTable)Session["CertificateTb2"]).Rows.Count > 0)
            {
                GetNewRectoInsertdr();
                statuspr = Gen.bulkInsertNewEnterPrise(myDtNewRecdr, incentiveId);
            }

            // LOA Expan 
            if (((DataTable)Session["CertificateTb10"]).Rows.Count > 0)
            {
                GetNewRectoInsertdr10();
                statuspr = Gen.bulkInsertNewEnterPriseExpanLOA(myDtNewRecdr10, incentiveId);
            }

            if (statuspr == 1)
            {
                statuspr = 0;
                if (((DataTable)Session["CertificateTb4"]).Rows.Count > 0)
                {
                    GetNewRectoInsertdr1();
                    statuspr = Gen.bulkInsertDirectorPartner(myDtNewRecdr1, incentiveId);

                }
            }
            if (statuspr == 1)
            {
                statuspr = 0;
                if (((DataTable)Session["CertificateTb9"]).Rows.Count > 0)
                {
                    GetNewRectoInsertdr9();
                    statuspr = Gen.bulkInsertTermLoanDetails(myDtNewRecdr9, incentiveId);

                }
            }
            return statuspr;
        }

        protected void rblSector_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlintLineofActivity.Visible = true;
                txtBussinessActivity.Visible = false;
                // rblVeh.Items[0].Enabled = false;

                if (rblSector.SelectedValue != "1")  // Not manufacture
                {
                    divrblVeh.Visible = false;
                    divvehicleno.Visible = false;
                    txtregistrationno.Text = "";
                }
                else if (rblSector.SelectedValue == "1")
                {
                    if (rblCaste.SelectedItem.Text.ToUpper() != "SELECT")
                    {
                        if (rblCaste.SelectedValue == "3" || rblCaste.SelectedValue == "4" || cbDiffAbled.Checked == true)
                        {
                            divrblVeh.Visible = true;
                            divvehicleno.Visible = true;
                            rblVeh_SelectedIndexChanged(sender, e);
                        }
                        else
                        {
                            divrblVeh.Visible = true;
                            divvehicleno.Visible = false;
                            txtregistrationno.Text = "";
                            rblVeh_SelectedIndexChanged(sender, e);
                        }
                    }
                }
            }

            catch (Exception ex) { Errors.ErrorLog(ex); }
        }

        protected void cbDiffAbled_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (cbDiffAbled.Checked == true)
                //{
                if (rblSector.SelectedValue == "1")
                {
                    rblCaste_SelectedIndexChanged(sender, e);
                }
                // }
                //if (cbDiffAbled.Checked)
                //{
                //    rblVeh.Visible = true; 
                //    trrblVeh.Visible = true;
                //}
                //else
                //{
                //    rblVeh.Visible = false;
                //    trrblVeh.Visible = false;
                //}
            }
            catch (Exception ex)
            { Errors.ErrorLog(ex); }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = ValidateControls("5");
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    AssignValuestoVosFromcontrols("5");
                }

                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Application Submitted Sucessfully');" + "window.location='frmCommonAttachments.aspx';", true);
                Response.Redirect("frmCommonAttachments.aspx");
            }
            catch (Exception ex)
            { Errors.ErrorLog(ex); }
        }

        protected void txtDateofCommencement_TextChanged(object sender, EventArgs e)
        {
            try
            {
                comFunctions ddd = new comFunctions();
                //DateTime dat = Convert.ToDateTime((txtDateofCommencement.Text).ToString()
                DateTime dat = ddd.convertDateIndia(txtDateofCommencement.Text);

                if (dat > DateTime.Now)
                {
                    txtDateofCommencement.Focus();
                    lblmsg0.Text = "Future Date cannot be selected.";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future Date cannot be selected');", true);
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                txtDateofCommencement.Focus();
                lblmsg0.Text = "Please Select Valid Date(dd-MMM-yyyy).";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Select Valid Date(dd-MMM-yyyy)');", true);
            }
        }
        protected void BtnClear_Click(object sender, EventArgs e)
        {
            try { cmf.ClearControls(this.Page); }
            catch (Exception ex) { Errors.ErrorLog(ex); }
        }



        protected void btntab1next_Click(object sender, EventArgs e)
        {
            DateTime todaysDate = System.DateTime.Today.Date;


            string[] DateOA = txtDateofCommencement.Text.Split('/');

            string strDateOA = DateOA[2].ToString() + "/" + DateOA[1].ToString() + "/" + DateOA[0].ToString();

            if (Convert.ToDateTime(strDateOA) <= todaysDate)
            {
                string errormsg = ValidateControls("1");
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    try
                    {
                        AssignValuestoVosFromcontrols("1");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        return;
                    }
                }

                txtvatno.Text = txtTinNO.Text.TrimStart().TrimEnd();

                lblmsg0.Text = "";
                Failure.Visible = false;
                Tab1.Attributes.Add("class", "");
                Tab2.Attributes.Add("class", "active");
                Tab3.Attributes.Add("class", "");
                Tab4.Attributes.Add("class", "");
                Tab5.Attributes.Add("class", "");
                //Tab6.Attributes.Add("class", "");
                MainView.ActiveViewIndex = 1;
                if (ddlIndustryStatus.SelectedItem.Text.ToUpper() == "NEW INDUSTRY" || ddlIndustryStatus.SelectedItem.Text.ToUpper() == "-- SELECT --")
                {
                    trexpansion.Visible = false;
                }
                else
                {
                    trexpansion.Visible = true;
                }
            }
            else
            {
                Failure.Visible = true;
                lblmsg0.Text = "Future date cannot be selected for Date of commencement of production !!";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Future date cannot be selected for Date of commencement of production !!');", true);
                txtDateofCommencement.Focus();
                txtDateofCommencement.Text = "";
                txtDateofCommencement.Enabled = true;

            }
        }

        public string ValidateControls(string Step)
        {
            int slno = 1;
            string ErrorMsg = "";
            if (Step == "1")
            {
                if (rblSector.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Type of Sector \\n";
                    slno = slno + 1;

                }
                //if (ddlUdyogAadharType.SelectedValue == "0")
                //{
                //    ErrorMsg = ErrorMsg + slno + ". Please Select Udyog Aadhar/EM/IEM/IL/EOU No \\n";
                //    slno = slno + 1;
                //}
                //if (txtudyogAadharNo.Text.TrimStart().TrimEnd().Trim() == "")
                //{
                //    ErrorMsg = ErrorMsg + slno + ". Please Enter Udyog Aadhar No \\n";
                //    slno = slno + 1;
                //}
                //if (txtUdyogAadhaarRegdDate.Text.TrimStart().TrimEnd().Trim() == "")
                //{
                //    ErrorMsg = ErrorMsg + slno + ". Please Enter Date of Registration \\n";
                //    slno = slno + 1;
                //}
                if (txtUser_Id.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Name \\n";
                    slno = slno + 1;
                }
                if (txtApplciantName.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Name \\n";
                    slno = slno + 1;
                }
                if (txtTinNO.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter TIN Number \\n";
                    slno = slno + 1;
                }
                if (txtPanNo.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter PAN Number \\n";
                    slno = slno + 1;
                }
                if (txtDateofCommencement.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Commenecement Date \\n";
                    slno = slno + 1;
                }
                if (ddlgender.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Gender \\n";
                    slno = slno + 1;
                }
                if (rblCaste.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Caste \\n";
                    slno = slno + 1;
                }

                if (ddlsubcaste.SelectedValue == "0" && divsubcaste.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Sub Caste \\n";
                    slno = slno + 1;
                }
                if (rblVeh.SelectedIndex <= -1 && divrblVeh.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Transport allied activities \\n";
                    slno = slno + 1;
                }
                if (txtregistrationno.Text.TrimStart().TrimEnd().Trim() == "" && divvehicleno.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Vehicle Number \\n";
                    slno = slno + 1;
                }

                // Address
                if (ddlUnitstate.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select State Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (ddlUnitDIst.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select District Under Unit Address\\n";
                    slno = slno + 1;
                }


                if (ddlUnitMandal.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Under Unit Address\\n";
                    slno = slno + 1;
                }

                if (ddlVillageunit.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Village Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (txtUnitStreet.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Grampanchayat/IE/IDA Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (txtUnitHNO.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Survey/Plot Number  Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (txtunitmobileno.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (txtunitemailid.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Email ID Under Unit Address\\n";
                    slno = slno + 1;
                }

                if (ddloffcstate.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select State Under Office Address\\n";
                    slno = slno + 1;
                }
                else if (ddloffcstate.SelectedValue == "31")
                {
                    if (ddlOffcDIst.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select District Under Office Address\\n";
                        slno = slno + 1;
                    }
                    if (ddlOffcMandal.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Under Office Address\\n";
                        slno = slno + 1;
                    }
                    if (ddlOffcVil.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Village Under Office Address\\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    if (txtofficedist.Text.TrimStart().TrimEnd().Trim() == "" && txtofficedist.Visible == true)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter District Name  Under Office Address\\n";
                        slno = slno + 1;
                    }

                    if (txtoffcicemandal.Text.TrimStart().TrimEnd().Trim() == "" && txtoffcicemandal.Visible == true)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Mandal Name  Under Office Address\\n";
                        slno = slno + 1;
                    }

                    if (txtofficeviiage.Text.TrimStart().TrimEnd().Trim() == "" && txtofficeviiage.Visible == true)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Village Name  Under Office Address\\n";
                        slno = slno + 1;
                    }
                }
                if (txtOffcStreet.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Street Name  Under Office Address\\n";
                    slno = slno + 1;
                }
                if (txtoffaddhnno.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Survey/Plot Number Under Office Address\\n";
                    slno = slno + 1;
                }
                if (txtOffcMobileNO.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number Under Office Address\\n";
                    slno = slno + 1;
                }
                if (txtOffcEmail.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Email ID Under Office Address\\n";
                    slno = slno + 1;
                }

                if (ddlOrgType.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Type of Organization\\n";
                    slno = slno + 1;
                }
                if (rdIaLa_Lst.SelectedIndex <= -1 && divIsIALA.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please select whether the unit is located in TSIIC or not \\n";
                    slno = slno + 1;
                    rdIaLa_Lst.Enabled = true;
                }
                if (ddlIndustrialParkName.SelectedValue == "0" && divIndusParkList.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please select Industrial Park \\n";
                    slno = slno + 1;
                    ddlIndustrialParkName.Enabled = true;
                }
            }
            if (Step == "2")
            {
                if (ddlIndustryStatus.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please select Industry Status \\n";
                    slno = slno + 1;
                    ddlIndustryStatus.Enabled = true;
                }
                else
                {
                    if (divIndustryExpansionType.Visible == true && ddlInustryExpansionType.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please select Industry Expansion Type \\n";
                        slno = slno + 1;
                        ddlInustryExpansionType.Enabled = true;
                    }
                    if (divIndustryExpansionType.Visible == false && gvInstalledCap.Rows.Count < 1 && gvInstalledCapNew.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add New Enterprise Line of Activity Details \\n";
                        slno = slno + 1;
                        trNewIndustry.Visible = true;
                        trlineofactivityNew.Visible = true;
                        txtLOActivity.Enabled = true;
                        txtinstalledccap.Enabled = true;
                        ddlquantityin.Enabled = true;
                        txtunit.Enabled = true;
                        txtvalue.Enabled = true;
                    }
                    if (divIndustryExpansionType.Visible == true && gvInstalledCap.Rows.Count < 1 && gvInstalledCapNew.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Existing Enterprise Line of Activity Details \\n";
                        slno = slno + 1;
                        trNewIndustry.Visible = true;
                        trlineofactivityNew.Visible = true;
                        txtLOActivity.Enabled = true;
                        txtinstalledccap.Enabled = true;
                        ddlquantityin.Enabled = true;
                        txtunit.Enabled = true;
                        txtvalue.Enabled = true;
                    }
                    if (divIndustryExpansionType.Visible == true && gvInstalledCapExpan.Rows.Count < 1 && gvInstalledCapExpanNew.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Expansion of Enterprise \\n";
                        slno = slno + 1;
                        trexpansionnew.Visible = true;
                        txtLOActivityExpan.Enabled = true;
                        txtinstalledccapExpan.Enabled = true;
                        ddlquantityinExpan.Enabled = true;
                        txtunitExpan.Enabled = true;
                        txtvalueExpan.Enabled = true;
                    }
                }
                if (txtlandexisting.Text == "" && ddlIndustryStatus.SelectedValue == "1")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Investment of New Enterprise Land Value\\n";
                    slno = slno + 1;
                    txtlandexisting.Enabled = true;
                }
                if (txtlandcapacity.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Land Value Of Under Expansion/ Diversification Project \\n";
                    slno = slno + 1;
                    txtlandcapacity.Enabled = true;
                }
                if (txtlandpercentage.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Land Value Of % of increase underExpansion/Diversification \\n";
                    slno = slno + 1;
                    txtlandpercentage.Enabled = true;
                }
                if (txtbuildingexisting.Text == "" && ddlIndustryStatus.SelectedValue == "1")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Investment of New Enterprise Building Value\\n";
                    slno = slno + 1;
                    txtbuildingexisting.Enabled = true;
                }
                if (txtbuildingcapacity.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Building Value Of Under Expansion/ Diversification Project \\n";
                    slno = slno + 1;
                    txtbuildingcapacity.Enabled = true;
                }
                if (txtbuildingpercentage.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Building Value Of % of increase underExpansion/Diversification \\n";
                    slno = slno + 1;
                    txtbuildingpercentage.Enabled = true;
                }

                if (txtplantexisting.Text == "" && ddlIndustryStatus.SelectedValue == "1")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Investment of New Enterprise Plant & Machinery Value\\n";
                    slno = slno + 1;
                    txtplantexisting.Enabled = true;
                }
                if (txtplantcapacity.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & Machinery Value Of Under Expansion/ Diversification Project \\n";
                    slno = slno + 1;
                    txtplantcapacity.Enabled = true;
                }
                if (txtplantpercentage.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & Machinery Value Of % of increase underExpansion/Diversification \\n";
                    slno = slno + 1;
                    txtplantpercentage.Enabled = true;
                }
            }
            else if (Step == "3")
            {
                if (GridView3.Rows.Count < 1 && gvdirector2.Rows.Count < 1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Add " + Label12.Text + " \\n";
                    slno = slno + 1;
                    trdirectordetails.Visible = true;
                    trLabel12.Visible = true;
                    txtnamedparter.Enabled = true;
                    txtshare.Enabled = true;
                    ddlcommunity.Enabled = true;
                    ddlgender2.Enabled = true;
                    ddlAuthorisedDesignation.Enabled = true;
                    txtpercentage.Enabled = true;
                    txtdesignationOther.Enabled = true;
                }
                if (txtAuthorisedSign.Text.TrimStart() == "" || txtAuthorisedSign.Text.TrimStart() == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Authorised Signatory \\n";
                    slno = slno + 1;
                    txtAuthorisedSign.Enabled = true;
                }

                if (ddlAuthorisedSignDesignation.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Authorised Signatory Designation \\n";
                    slno = slno + 1;
                    ddlAuthorisedSignDesignation.Enabled = true;
                }
                else
                {
                    if (ddlAuthorisedSignDesignation.SelectedValue == "3" && txtAuthSignOtherDesignation.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Authorised Signatory Designation \\n";
                        txtAuthSignOtherDesignation.Enabled = true;
                        slno = slno + 1;
                    }
                }

                if (ddlIspowApplicable.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Is power applicable Or Not\\n";
                    slno = slno + 1;
                    ddlIspowApplicable.Enabled = true;
                }
                else
                {
                    if (ddlIspowApplicable.SelectedValue == "1")
                    {
                        if (ddlIndustryStatus.SelectedValue == "1")
                        {
                            if (txtNewPowerReleaseDate.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Power Released Date\\n";
                                slno = slno + 1;
                                txtNewPowerReleaseDate.Enabled = true;
                                tblpower1.Visible = true;
                            }
                            if (txtNewContractedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Contracted load\\n";
                                slno = slno + 1;
                                txtNewContractedLoad.Enabled = true;
                                tblpower1.Visible = true;
                            }
                            if (ddlContractpowerunit.SelectedValue == "0")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Select New Enterprise Contracted load Unit\\n";
                                slno = slno + 1;
                                ddlContractpowerunit.Enabled = true;
                                tblpower1.Visible = true;
                            }
                            if (txtServiceConnectionNumber.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Service Connection Number\\n";
                                slno = slno + 1;
                                txtServiceConnectionNumber.Enabled = true;
                                tblpower1.Visible = true;
                            }
                            if (txtNewConnectedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Connected load\\n";
                                slno = slno + 1;
                                txtNewConnectedLoad.Enabled = true;
                                tblpower1.Visible = true;
                            }
                            if (ddlConnectPowUnit.SelectedValue == "0")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Select New Enterprise Connected load Unit\\n";
                                slno = slno + 1;
                                ddlConnectPowUnit.Enabled = true;
                                tblpower1.Visible = true;
                            }
                        }
                        else if (ddlIndustryStatus.SelectedValue == "2" || ddlIndustryStatus.SelectedValue == "3")
                        {
                            if (txtExistingPowerReleaseDate.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing Enterprise Power Released Date\\n";
                                slno = slno + 1;
                                txtExistingPowerReleaseDate.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (txtExistingContractedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing  Enterprise Contracted load\\n";
                                slno = slno + 1;
                                txtExistingContractedLoad.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (ddlExsitContractPowerUnit.SelectedValue == "0")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Select Existing  Enterprise Contracted load Unit\\n";
                                slno = slno + 1;
                                ddlExsitContractPowerUnit.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (txtExistingServiceConnectionNO.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing  Enterprise Service Connection Number\\n";
                                slno = slno + 1;
                                txtExistingServiceConnectionNO.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (txtExistingConnectedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing  Enterprise Connected load\\n";
                                slno = slno + 1;
                                txtExistingConnectedLoad.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (ddlExistConnectPowerUnit.SelectedValue == "0")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Select Existing  Enterprise Connected load Unit\\n";
                                slno = slno + 1;
                                ddlExistConnectPowerUnit.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (txtExpanDiverPowerReleaseDate.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ".Please Enter Expansion / Diversification Enterprise Power Released Date\\n";
                                slno = slno + 1;
                                txtExpanDiverPowerReleaseDate.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (txtExpanDiverContractedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Expansion / Diversification Enterprise Contracted load\\n";
                                slno = slno + 1;
                                txtExpanDiverContractedLoad.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (ddlDiversPowContrUnit.SelectedValue == "0")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Select Expansion / Diversification Enterprise Contracted load Unit\\n";
                                slno = slno + 1;
                                ddlDiversPowContrUnit.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (txtExpanDiverServiceConnectionNO.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Expansion / Diversification Enterprise Service Connection Number\\n";
                                slno = slno + 1;
                                txtExpanDiverServiceConnectionNO.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (txtExpanDiverConnectedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Expansion / Diversification Enterprise Connected load\\n";
                                slno = slno + 1;
                                txtExpanDiverConnectedLoad.Enabled = true;
                                tblpower2.Visible = true;
                            }
                            if (ddlDiverpowConnectUnit.SelectedValue == "0")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Select Expansion / Diversification Enterprise Connected load Unit\\n";
                                slno = slno + 1;
                                ddlDiverpowConnectUnit.Enabled = true;
                                tblpower2.Visible = true;
                            }
                        }
                    }
                }
                if (txtstaffMale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Male Management & Staff\\n";
                    slno = slno + 1;
                    txtstaffMale.Enabled = true;
                }
                if (txtfemale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Female Management & Staff\\n";
                    slno = slno + 1;
                    txtfemale.Enabled = true;
                }
                if (txtsupermalecount.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Male Supervisory\\n";
                    slno = slno + 1;
                    txtsupermalecount.Enabled = true;
                }
                if (txtsuperfemalecount.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Female Supervisory\\n";
                    slno = slno + 1;
                    txtsuperfemalecount.Enabled = true;
                }
                if (txtSkilledWorkersMale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Male Skilled workers\\n";
                    slno = slno + 1;
                    txtSkilledWorkersMale.Enabled = true;
                }
                if (txtSkilledWorkersFemale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Female Skilled workers\\n";
                    slno = slno + 1;
                    txtSkilledWorkersFemale.Enabled = true;
                }
                if (txtSemiSkilledWorkersMale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Male Semi-skilled workers\\n";
                    slno = slno + 1;
                    txtSemiSkilledWorkersMale.Enabled = true;
                }
                if (txtSemiSkilledWorkersFemale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Female Semi-skilled  workers\\n";
                    slno = slno + 1;
                    txtSemiSkilledWorkersFemale.Enabled = true;
                }
                // ddlAuthorisedSignDesignation
            }
            else if (Step == "4")
            {
                if (ddlIsTermLoanAvailed.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Have you availed Term Loan Or Not \\n";
                    slno = slno + 1;
                    ddlIsTermLoanAvailed.Enabled = true;
                }
                else if (ddlIsTermLoanAvailed.SelectedValue == "1")
                {
                    if (GVTermLoandtls.Rows.Count < 1 && GridView2.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Term Loan details \\n";
                        slno = slno + 1;
                        tblTermLoanDtls.Visible = true;
                        trTermLoanLine1.Visible = true;
                        trTermLoanLine2.Visible = true;
                        trTermLoanLine3.Visible = true;
                        trTermLoanLine4.Visible = true;
                        trTermLoanLine6.Visible = true;
                        ddlTermLoanNo.Enabled = true;
                        txttermload.Enabled = true;
                        txtnmofinstitution.Enabled = true;
                        txtsactionedloan.Enabled = true;
                        txtdatesome.Enabled = true;
                        txtTermLoanReleasedDate.Enabled = true;
                    }
                }
                if (ddlHvuInstalledScndhndMech.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Have you Installed Secondhand machinery Or Not \\n";
                    slno = slno + 1;
                    ddlHvuInstalledScndhndMech.Enabled = true;
                }
                else if (ddlHvuInstalledScndhndMech.SelectedValue == "1")
                {

                    if (txtsecondhndmachine.Text.TrimStart().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Second hand machinery value in Rs \\n";
                        slno = slno + 1;
                        txtsecondhndmachine.Enabled = true;
                        trSecondhandmachinery.Visible = true;
                    }
                    if (txtnewmachine.Text.TrimStart().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter New machinery value in Rs \\n";
                        slno = slno + 1;
                        txtnewmachine.Enabled = true;
                        trSecondhandmachinery.Visible = true;
                    }
                    if (txtpercentage12.Text.TrimStart().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter % of second hand machinery value in total machinery value \\n";
                        slno = slno + 1;
                        txtpercentage12.Enabled = true;
                        trSecondhandmachinery.Visible = true;
                    }
                    if (txtmachinepucr.Text.TrimStart().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Value of the Machinery Purchaced from TSIDC /TSSFC/Bank in Rs  \\n";
                        slno = slno + 1;
                        txtmachinepucr.Enabled = true;
                        trSecondhandmachinery.Visible = true;
                    }
                }
                if (txtvatno.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter TIN/ VAT/ CST/ GST No  \\n";
                    slno = slno + 1;
                    txtvatno.Enabled = true;
                }
                if (txtCSTRegDate.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Registration Date \\n";
                    slno = slno + 1;
                    txtCSTRegDate.Enabled = true;
                }

                if (txtCSTRegAuthority.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Registring Authority  \\n";
                    slno = slno + 1;
                    txtCSTRegAuthority.Enabled = true;
                }
                if (txtCSTRegAuthAddress.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Registering Authority Address \\n";
                    slno = slno + 1;
                    txtCSTRegAuthAddress.Enabled = true;

                }
            }
            else if (Step == "5")
            {
                if (ddlBank.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Name of the Bank \\n";
                    slno = slno + 1;
                    ddlBank.Enabled = true;
                    ddlAccountType.Enabled = true;
                }
                if (txtBranchName.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of The Branch \\n";
                    slno = slno + 1;
                    txtBranchName.Enabled = true;
                }
                if (ddlAccountType.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Account Type \\n";
                    slno = slno + 1;
                    ddlAccountType.Enabled = true;
                }
                if (txtAccountName.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of The Account Holder \\n";
                    slno = slno + 1;
                    txtAccountName.Enabled = true;
                }
                if (txtAccNumber.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Account Number \\n";
                    slno = slno + 1;
                    txtAccNumber.Enabled = true;
                }
                if (txtIfscCode.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter IFSC Code \\n";
                    slno = slno + 1;
                    txtIfscCode.Enabled = true;
                }

            }
            return ErrorMsg;
        }  // Shankar


        public void AssignValuestoVosFromcontrols(string step)
        {
            try
            {
                objvo.AppsLevel = step;
                objvo.IncentveID = Session["IncentveID"].ToString();

                if (objvo.IncentveID == null || objvo.IncentveID == "")
                {
                    objvo.IncentveID = "0";
                }
                objvoA.Incentive_id = objvo.IncentveID;
                objvo.User_Id = Session["uid"].ToString();
                objvoA.created_by = objvo.User_Id;
                objvoA.Modified_by = objvoA.created_by;
                objvoA.User_id = objvo.User_Id;
                if (step == "1")
                {
                    objvo.Uid_NO = txtuidno.Text;
                    objvo.sector = rblSector.SelectedValue;
                    objvo.UdyogAadharType = ddlUdyogAadharType.SelectedValue;
                    objvo.EMiUdyogAadhar = txtudyogAadharNo.Text.ToUpper();
                    //if (txtUdyogAadhaarRegdDate.Text == "" || txtUdyogAadhaarRegdDate.Text == null)
                    //{
                    //    objvo.UdyogAadharRegdDate = null;
                    //}
                    //else
                    //{
                    //    string[] ConvertedDt11 = txtUdyogAadhaarRegdDate.Text.Split('/');
                    //    objvo.UdyogAadharRegdDate = ConvertedDt11[2].ToString() + "/" + ConvertedDt11[1].ToString() + "/" + ConvertedDt11[0].ToString();
                    //}
                    objvo.UnitName = txtUser_Id.Text.ToUpper();
                    objvo.ApplciantName = txtApplciantName.Text.ToUpper();
                    objvo.TinNO = txtTinNO.Text.ToUpper();
                    objvo.PanNo = txtPanNo.Text.ToUpper();
                    if (cbDiffAbled.Checked)
                    {
                        objvo.IsDifferentlyAbled = "Y";
                    }
                    else
                    {
                        objvo.IsDifferentlyAbled = "N";
                    }
                    //if (cbMinority.Visible == true)
                    //{
                    //    if (cbMinority.Checked)
                    //    {
                    //        objvo.IsMinority = "Y";
                    //    }
                    //}
                    //else
                    //{
                    //    objvo.IsMinority = null;
                    //}

                    string[] Ld2 = null;
                    string ConvertedDt5 = "";

                    if (txtDateofCommencement.Text != "")
                    {
                        Ld2 = txtDateofCommencement.Text.Split('/');
                        ConvertedDt5 = Ld2[2].ToString() + "/" + Ld2[1].ToString() + "/" + Ld2[0].ToString();

                        objvo.DateOfComm = ConvertedDt5;
                    }
                    else
                    {
                        objvo.DateOfComm = null;
                    }
                    objvo.Gender = ddlgender.SelectedValue.ToString();
                    objvo.SocialStatus = rblCaste.SelectedValue;
                    if (ddlsubcaste.SelectedItem.Text.ToUpper() != "SELECT")
                    {
                        objvo.SubCaste = ddlsubcaste.SelectedValue;
                    }
                    else
                    {
                        objvo.SubCaste = null;
                    }
                    if (rblVeh.SelectedIndex > -1 && rblSector.SelectedValue == "1")
                    {
                        objvo.isVehicleIncentive = Convert.ToBoolean(Convert.ToInt32(rblVeh.SelectedValue));
                    }
                    else
                    {
                        objvo.isVehicleIncentive = false;
                    }
                    if (txtregistrationno.Text == "" && txtregistrationno.Text == null)
                    {
                        objvo.VehicleNumber = null;
                    }
                    else
                    {
                        objvo.VehicleNumber = txtregistrationno.Text;
                    }



                    // Unit Address

                    objvo.UnitState = ddlUnitstate.SelectedValue;
                    objvo.UnitDIst = ddlUnitDIst.SelectedValue;
                    objvo.UnitMandal = ddlUnitMandal.SelectedValue;
                    objvo.UnitVill = ddlVillageunit.SelectedValue;
                    objvo.UnitStreet = txtUnitStreet.Text.ToUpper();
                    objvo.UnitHNO = txtUnitHNO.Text.ToUpper();
                    objvo.UnitMObileNo = txtunitmobileno.Text.ToUpper();
                    objvo.UnitEmail = txtunitemailid.Text.ToUpper();

                    //Office Address
                    objvo.OffcState = ddloffcstate.SelectedValue;
                    if (ddloffcstate.SelectedValue.ToString() != "31")
                    {
                        objvo.OffcOtherDist = txtofficedist.Text.ToUpper();
                        objvo.OffcOtherVillage = txtoffcicemandal.Text.ToUpper();
                        objvo.OffcOtherMandal = txtofficeviiage.Text.ToUpper();
                    }
                    else
                    {
                        objvo.OffcDIst = ddlOffcDIst.SelectedValue;
                        objvo.OffcMandal = ddlOffcMandal.SelectedValue;
                        objvo.OffcVil = ddlOffcVil.SelectedValue;
                    }

                    objvo.OffcHNO = txtoffaddhnno.Text.ToUpper();
                    objvo.OffcStreet = txtOffcStreet.Text.ToUpper();
                    objvo.OffcEmail = txtOffcEmail.Text.ToUpper();
                    objvo.OffcMobileNO = txtOffcMobileNO.Text.ToUpper();
                    objvo.TypeofOrg = ddlOrgType.SelectedValue;
                    objvo.IsGHMCandOtherMuncpOrp = Convert.ToBoolean(Convert.ToInt32(rblGHMC.SelectedValue));
                    if (rdIaLa_Lst.SelectedValue == "Y")
                    {
                        objvo.isIALA = "Y";
                        objvo.IndusParkList = Convert.ToInt32(ddlIndustrialParkName.SelectedValue);
                    }
                    else
                    {
                        objvo.isIALA = "N";
                        objvo.IndusParkList = 0;
                    }

                    objvo.natureOfAct = ddlintLineofActivity.SelectedValue;
                    objvo.NatureofBussiness = txtBussinessActivity.Text.ToUpper();


                    //-------ADDING OBJECTS FOR TTAP-----

                    string[] Ld6 = null;
                    string ConvertedDt56 = "";

                    if (txtDateOfIncorporation.Text != "")
                    {
                        Ld6 = txtDateOfIncorporation.Text.Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();

                        objvo.DateOfIncorporation = ConvertedDt56;
                    }
                    else
                    {
                        objvo.DateOfIncorporation = null;
                    }
                    objvo.IncorpRegistranNumber = txtIncorpRegistranNumber.Text;
                    objvo.CountryOrigin = txtCountryOrigin.Text;
                    objvo.TextileProcessType = ddlTextileProcessType.SelectedValue.ToString();
                    objvo.YearsOfExpinTexttile = txtYearsOfExpinTexttile.Text;
                    objvo.EducationalQual = txtEducationalQual.Text;

                    try
                    {
                        string Validstatus = InsertIncentivCommonData(objvo);
                        if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                        {
                            objvo.IncentveID = Validstatus;
                            Session["IncentveID"] = objvo.IncentveID;
                            Session["IncentiveID"] = objvo.IncentveID;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                        return;
                    }
                } // Step 1 End
                else if (step == "2")
                {
                    List<IndustryLineofActivities> LstNewInds = new List<IndustryLineofActivities>();

                    List<IndustryLineofActivities> LstExpInds = new List<IndustryLineofActivities>();

                    objvo.IdsustryStatus = ddlIndustryStatus.SelectedValue;

                    if (ddlIndustryStatus.SelectedValue == "2" || ddlIndustryStatus.SelectedValue == "3")
                    {
                        objvo.IndustryExpansionType = ddlInustryExpansionType.SelectedValue;
                    }

                    foreach (GridViewRow RowInd in gvInstalledCap.Rows)
                    {
                        IndustryLineofActivities VosNewInds = new IndustryLineofActivities();
                        VosNewInds.slno = "0";
                        VosNewInds.LineOfActivity = RowInd.Cells[1].Text.ToString();
                        VosNewInds.InstalledCapacity = RowInd.Cells[2].Text.ToString();
                        VosNewInds.Unit = RowInd.Cells[3].Text.ToString();
                        VosNewInds.ValueRs = RowInd.Cells[4].Text.ToString();
                        VosNewInds.Created_by = Session["uid"].ToString();
                        VosNewInds.IncentiveId = Session["IncentveID"].ToString();
                        LstNewInds.Add(VosNewInds);
                    }

                    foreach (GridViewRow RowInd in gvInstalledCapExpan.Rows)
                    {
                        IndustryLineofActivities VosExpInds = new IndustryLineofActivities();
                        VosExpInds.slno = "0";
                        VosExpInds.LineOfActivity = RowInd.Cells[1].Text.ToString();
                        VosExpInds.InstalledCapacity = RowInd.Cells[2].Text.ToString();
                        VosExpInds.Unit = RowInd.Cells[3].Text.ToString();
                        VosExpInds.ValueRs = RowInd.Cells[4].Text.ToString();
                        VosExpInds.Created_by = Session["uid"].ToString();
                        VosExpInds.IncentiveId = Session["IncentveID"].ToString();
                        VosExpInds.LOAType = "Expansion LOA";
                        LstExpInds.Add(VosExpInds);
                    }
                    objvo.Category = HiddenFieldEnterpriseCategory.Value;
                    if (ddlIndustryStatus.SelectedValue == "1")
                    {
                        objvo.ExistingEnterpriseLOA = "0";
                        objvo.ExistingInstalledCapacityinEnter = "0";
                        objvo.ExistingPercentageincreaseunderExpansionORDiversification = "0";

                        objvo.ExpansionDiversificationLOA = "0";
                        objvo.ExpanORDiversInstalledCapacityinEnter = "0";
                        objvo.ExpanORDiversPercentIncreaseunderExpansionORDiversification = "0";

                        objvo.ExistEnterpriseLand = txtlandexisting.Text.ToUpper();
                        objvo.ExpansionDiversificationLand = txtlandcapacity.Text.ToUpper();
                        objvo.LandFixedCapitalInvestPercentage = txtlandpercentage.Text.ToUpper();

                        objvo.ExistEnterpriseBuilding = txtbuildingexisting.Text.ToUpper();
                        objvo.ExpDiversBuilding = txtbuildingcapacity.Text.ToUpper();
                        objvo.BuildingFixedCapitalInvestPercentage = txtbuildingpercentage.Text.ToUpper();

                        objvo.ExistEnterprisePlantMachinery = txtplantexisting.Text.ToUpper();
                        objvo.ExpDiversPlantMachinery = txtplantcapacity.Text.ToUpper();
                        objvo.PlantMachFixedCapitalInvestPercentage = txtplantpercentage.Text.ToUpper();

                        #region Added by Naresh

                        objvo.PlinthArea = txtPlinthArea.Text.Trim();
                        objvo.RateperAcre = txtRateperAcre.Text.Trim();
                        objvo.TotalInvestment = txtTotalInvestment.Text.Trim();
                        objvo.Infrastructure1 = txtInfrastructure1.Text.Trim();
                        objvo.Infrastructure2 = txtInfrastructure2.Text.Trim();
                        objvo.Infrastructure3 = txtInfrastructure3.Text.Trim();
                        objvo.OtherProductive1 = txtOtherProductive1.Text.Trim();
                        objvo.OtherProductive2 = txtOtherProductive2.Text.Trim();
                        objvo.OtherProductive3 = txtOtherProductive3.Text.Trim();
                        objvo.TotalInvestmentBuilding = txtTotalInvestmentBuilding.Text.Trim();
                        objvo.Transportation = txtTransportation.Text.Trim();
                        objvo.Erection = txtErection.Text.Trim();
                        objvo.Electrification = txtElectrification.Text.Trim();
                        objvo.OtherAssets = txtOtherAssets.Text.Trim();
                        objvo.TotalPlantMechinery = txtTotalPlantMechinery.Text.Trim();
                        objvo.TotalCapitalInvestment = txtTotalCapitalInvestment.Text.Trim();

                        #endregion
                    }
                    else
                    {
                        objvo.ExistingEnterpriseLOA = txteeploa.Text.ToUpper();
                        objvo.ExistingInstalledCapacityinEnter = txteepinscap.Text.ToUpper();
                        objvo.ExistingPercentageincreaseunderExpansionORDiversification = txteeppercentage.Text;

                        objvo.ExpansionDiversificationLOA = txtedploa.Text.ToUpper();
                        objvo.ExpanORDiversInstalledCapacityinEnter = txtedpinscap.Text.ToUpper();
                        objvo.ExpanORDiversPercentIncreaseunderExpansionORDiversification = txtedppercentage.Text;


                        objvo.ExistEnterpriseLand = txtlandexisting.Text.ToUpper();
                        objvo.ExpansionDiversificationLand = txtlandcapacity.Text.ToUpper();
                        objvo.LandFixedCapitalInvestPercentage = txtlandpercentage.Text.ToUpper();

                        objvo.ExistEnterpriseBuilding = txtbuildingexisting.Text.ToUpper();
                        objvo.ExpDiversBuilding = txtbuildingcapacity.Text.ToUpper();
                        objvo.BuildingFixedCapitalInvestPercentage = txtbuildingpercentage.Text.ToUpper();

                        objvo.ExistEnterprisePlantMachinery = txtplantexisting.Text.ToUpper();
                        objvo.ExpDiversPlantMachinery = txtplantcapacity.Text.ToUpper();
                        objvo.PlantMachFixedCapitalInvestPercentage = txtplantpercentage.Text.ToUpper();
                    }

                    objvo.Percentge_FixedCapitalInvestment = txtPercentge_FixedCapitalInvestment.Text;
                    objvo.Nature_Industry = txtNature_Industry.Text;
                    objvo.InstalledCapacityperAnnum = txtInstalledCapacityperAnnum.Text;
                    objvo.WhetherAllotedByGovt = rdWhetherAllotedByGovt.SelectedValue.ToString();
                    objvo.CategoryTTAP = ddlCategoryTTAP.SelectedValue.ToString();

                    string InsValid = InsertIncentivCommonDataStep2(objvo, LstNewInds, LstExpInds);
                }
                else if (step == "3")
                {
                    List<IndustryPartnerDtls> LstPatnerDtls = new List<IndustryPartnerDtls>();
                    BackgroundDetails objBckGvo = new BackgroundDetails();
                    foreach (GridViewRow RowInd in GridView3.Rows)
                    {
                        IndustryPartnerDtls VosPartner = new IndustryPartnerDtls();
                        VosPartner.Slno = "0";
                        VosPartner.Name = RowInd.Cells[1].Text.ToString();
                        VosPartner.Community = RowInd.Cells[2].Text.ToString();
                        VosPartner.Gender = RowInd.Cells[3].Text.ToString();
                        VosPartner.Share = RowInd.Cells[4].Text.ToString();
                        VosPartner.Designation = RowInd.Cells[5].Text.ToString();
                        VosPartner.MobileNo = RowInd.Cells[6].Text.ToString();
                        VosPartner.Email = RowInd.Cells[7].Text.ToString();
                        VosPartner.PanNO = RowInd.Cells[8].Text.ToString();

                        VosPartner.Created_by = Session["uid"].ToString();
                        VosPartner.IncentiveId = Session["IncentveID"].ToString();
                        LstPatnerDtls.Add(VosPartner);
                    }

                    objvo.AuthorisedSignatoryDesignationValue = ddlAuthorisedSignDesignation.SelectedValue;
                    if (ddlAuthorisedSignDesignation.SelectedItem.Text.ToUpper() == "OTHER")
                    {
                        objvo.AuthorisedSignatoryDesignation = txtAuthSignOtherDesignation.Text;
                    }
                    else
                    {
                        objvo.AuthorisedSignatoryDesignation = ddlAuthorisedSignDesignation.SelectedItem.Text;
                    }

                    objvo.AuthorisedSignatory = txtAuthorisedSign.Text.Trim();

                    objvo.IsPowerApplicable = ddlIspowApplicable.SelectedItem.Text;
                    objvo.IsPowerApplicableValues = ddlIspowApplicable.SelectedValue;  // Not

                    string[] rd1 = null;
                    string ConvertedDt1 = "";

                    if (txtNewPowerReleaseDate.Text != "")
                    {
                        rd1 = txtNewPowerReleaseDate.Text.Split('/');
                        ConvertedDt1 = rd1[2].ToString() + "/" + rd1[1].ToString() + "/" + rd1[0].ToString();

                        objvo.NewPowerReleaseDate = ConvertedDt1;
                    }
                    else
                    {
                        objvo.NewPowerReleaseDate = null;
                    }
                    objvo.NewConnectedLoad = txtNewContractedLoad.Text.ToUpper();
                    objvo.PowNewContractUnit = ddlContractpowerunit.SelectedItem.Text;
                    objvo.PowNewContractUnitValue = ddlContractpowerunit.SelectedValue; // Not

                    objvo.ServiceConnectionNO = txtServiceConnectionNumber.Text.ToUpper();
                    objvo.NewContractedLoad = txtNewConnectedLoad.Text.ToUpper();
                    objvo.PowNewConnectUnit = ddlConnectPowUnit.SelectedItem.Text;
                    objvo.PowNewConnectUnitValue = ddlConnectPowUnit.SelectedValue;  // Not

                    string[] rd2 = null;
                    string ConvertedDt2 = "";

                    if (txtExistingPowerReleaseDate.Text != "")
                    {
                        rd2 = txtExistingPowerReleaseDate.Text.Split('/');
                        ConvertedDt2 = rd2[2].ToString() + "/" + rd2[1].ToString() + "/" + rd2[0].ToString();
                        objvo.ExistingPowerReleaseDate = ConvertedDt2;
                    }
                    else
                    {
                        objvo.ExistingPowerReleaseDate = null;
                    }
                    objvo.ExistingContractedLoad = txtExistingContractedLoad.Text.ToUpper();
                    objvo.PowExistContractUnit = ddlExsitContractPowerUnit.SelectedItem.Text;
                    objvo.PowExistContractUnitValue = ddlExsitContractPowerUnit.SelectedValue;  // Not

                    objvo.ExistingServiceConnectionNO = txtExistingServiceConnectionNO.Text.ToUpper();
                    objvo.ExistingConnectedLoad = txtExistingConnectedLoad.Text.ToUpper();
                    objvo.PowExistConnectUnit = ddlExistConnectPowerUnit.SelectedItem.Text;
                    objvo.PowExistConnectUnitValue = ddlExistConnectPowerUnit.SelectedValue;  // Not

                    #region Added by Naresh

                    objvo.Source = txtSource.Text.Trim();
                    objvo.Requirement = txtRequirement.Text.Trim();
                    objvo.RateperUnit = txtRateperUnit.Text.Trim();
                    objvo.IsSubsidiesIncentives = rbtnIsSubsidiesIncentives.SelectedValue == "1" ? true : false;
                    objvo.IsSubsidiesIncentivesAmount = txtIsSubsidiesIncentivesAmount.Text.Trim();
                    objvo.NameoftheScheme = txtNameoftheScheme.Text.Trim();

                    objvo.EstablishmentYear = txtEstablishment.Text.Trim();
                    objvo.NumberofEmployees = txtNumberofEmployees.Text.Trim();

                    #endregion

                    string[] rd3 = null;
                    string ConvertedDt3 = "";

                    if (txtExpanDiverPowerReleaseDate.Text != "")
                    {
                        rd3 = txtExpanDiverPowerReleaseDate.Text.Split('/');
                        ConvertedDt3 = rd3[2].ToString() + "/" + rd3[1].ToString() + "/" + rd3[0].ToString();
                        objvo.ExpanDiverPowerReleaseDate = ConvertedDt3;
                    }
                    else
                    {
                        objvo.ExpanDiverPowerReleaseDate = null;
                    }
                    objvo.ExpanDiverContractedLoad = txtExpanDiverContractedLoad.Text.ToUpper();
                    objvo.PowDiversContractUnit = ddlDiversPowContrUnit.SelectedItem.Text;
                    objvo.PowDiversContractUnitValue = ddlDiversPowContrUnit.SelectedValue; // Not

                    objvo.ExpanDiverServiceConnectionNO = txtExpanDiverServiceConnectionNO.Text.ToUpper();
                    objvo.ExpanDiverConnectedLoad = txtExpanDiverConnectedLoad.Text.ToUpper();
                    objvo.PowDiversConnectUnit = ddlDiverpowConnectUnit.SelectedItem.Text;
                    objvo.PowDiversConnectUnitValue = ddlDiverpowConnectUnit.SelectedValue;  // Not

                    objvo.ManagementStaffMale = Convert.ToInt32(txtstaffMale.Text.ToUpper());
                    objvo.ManagementStaffFemale = Convert.ToInt32(txtfemale.Text.ToUpper());
                    objvo.SupervisoryMale = Convert.ToInt32(txtsupermalecount.Text.ToUpper());
                    objvo.SupervisoryFemale = Convert.ToInt32(txtsuperfemalecount.Text.ToUpper());

                    objvo.SkilledWorkersMale = Convert.ToInt32(txtSkilledWorkersMale.Text.ToUpper());
                    objvo.SkilledWorkersFemale = Convert.ToInt32(txtSkilledWorkersFemale.Text.ToUpper());
                    objvo.SemiSkilledWorkersMale = Convert.ToInt32(txtSemiSkilledWorkersMale.Text.ToUpper());
                    objvo.SemiSkilledWorkersFemale = Convert.ToInt32(txtSemiSkilledWorkersFemale.Text.ToUpper());

                    //For TTAP
                    objvo.Products_Manufactured = txtProducts_Manufactured.Text;
                    objvo.NO_OtherEstablishments = txtNO_OtherEstablishments.Text;
                    objvo.Authorized_MobileNo = txtAuthorized_MobileNo.Text;
                    objvo.Authorized_EmailId = txtAuthorized_EmailId.Text;
                    objvo.Authorized_PAN_NO = txtAuthorized_PAN_NO.Text;
                    objvo.Authorized_CorresponAdderess = txtAuthorized_CorresponAdderess.Text;

                    objBckGvo.created_by = Session["uid"].ToString();
                    objBckGvo.Incentive_id = Session["IncentveID"].ToString();
                    objBckGvo.TurnOver_1stYear = txtTurnOver_1stYear.Text;
                    objBckGvo.TurnOver_2ndYear = txtTurnOver_2ndYear.Text;
                    objBckGvo.TurnOver_3rdYear = txtTurnOver_3rdYear.Text;
                    objBckGvo.EBITDA_1stYear = txtEBITDA_1stYear.Text;
                    objBckGvo.EBITDA_2ndYear = txtEBITDA_2ndYear.Text;
                    objBckGvo.EBITDA_3rdYear = txtEBITDA_3rdYear.Text;
                    objBckGvo.Networth_1stYear = txtNetworth_1stYear.Text;
                    objBckGvo.Networth_2ndYear = txtNetworth_2ndYear.Text;
                    objBckGvo.Networth_3rdYear = txtNetworth_3rdYear.Text;
                    objBckGvo.ReservesSurplus_1stYear = txtReservesSurplus_1stYear.Text;
                    objBckGvo.ReservesSurplus_2ndYear = txtReservesSurplus_2ndYear.Text;
                    objBckGvo.ReservesSurplus_3rdYear = txtReservesSurplus_3rdYear.Text;
                    objBckGvo.Share_Capital_1stYear = txtShare_Capital_1stYear.Text;
                    objBckGvo.Share_Capital_2ndYear = txtShare_Capital_2ndYear.Text;
                    objBckGvo.Share_Capital_3rdYear = txtShare_Capital_3rdYear.Text;

                    string ValidStatus = SaveBackgroundDetails(objBckGvo);
                    if (ValidStatus == "1")
                    {
                        string InsValid = InsertIncentivCommonDataStep3(objvo, LstPatnerDtls);
                    }


                }
                else if (step == "4")
                {
                    List<IndustryTermLoanDtls> LstIndustryTermLoanDtls = new List<IndustryTermLoanDtls>();

                    foreach (GridViewRow RowInd in GVTermLoandtls.Rows)
                    {
                        IndustryTermLoanDtls VoTermLoandtls = new IndustryTermLoanDtls();

                        VoTermLoandtls.TermLoanId = "0";
                        VoTermLoandtls.AvailedTermLoan = RowInd.Cells[1].Text.ToString();
                        VoTermLoandtls.TermLoanApplDate = RowInd.Cells[2].Text.ToString();
                        VoTermLoandtls.InstitutionName = RowInd.Cells[3].Text.ToString();
                        VoTermLoandtls.TermloanSandate = RowInd.Cells[4].Text.ToString();
                        VoTermLoandtls.TermLoanSancRefNo = RowInd.Cells[5].Text.ToString();
                        VoTermLoandtls.TermLoanReleaseddate = RowInd.Cells[6].Text.ToString();
                        VoTermLoandtls.Created_by = Session["uid"].ToString();
                        VoTermLoandtls.IncentiveId = Session["IncentveID"].ToString();
                        LstIndustryTermLoanDtls.Add(VoTermLoandtls);

                        if (RowInd.RowIndex == 0)
                        {
                            #region Comment
                            //string[] Ld1 = null;
                            //string ConvertedDt4 = "";

                            //if (txttermload.Text != "")
                            //{
                            //    Ld1 = txttermload.Text.Split('/');
                            //    ConvertedDt4 = Ld1[1].ToString() + "/" + Ld1[0].ToString() + "/" + Ld1[2].ToString();

                            //    objvo.TermLoanApplDate = ConvertedDt4;
                            //}
                            //else
                            //{
                            //    objvo.TermLoanApplDate = null;
                            //}

                            //string[] Ld4 = null;
                            //string ConvertedDt7 = "";
                            //if (txtdatesome.Text != "")
                            //{
                            //    Ld4 = txtdatesome.Text.Split('/');
                            //    ConvertedDt7 = Ld4[1].ToString() + "/" + Ld4[0].ToString() + "/" + Ld4[2].ToString();

                            //    objvo.TermLoanSanDate = ConvertedDt7;
                            //}
                            //else
                            //{
                            //    objvo.TermLoanSanDate = "01/01/1900";
                            //}
                            #endregion
                            objvo.TermLoanApplDate = RowInd.Cells[2].Text.ToString();
                            objvo.InstitutionName = RowInd.Cells[3].Text.ToString();
                            objvo.TermLoanSancRefNo = RowInd.Cells[5].Text.ToString();
                            objvo.TermLoanSanDate = RowInd.Cells[6].Text.ToString();
                        }
                    }

                    objvo.IsTermLoanAvailed = ddlIsTermLoanAvailed.SelectedValue;
                    // objvo.AvailedSubsidyEarlier = ddlsubsidy.SelectedItem.Text;
                    objvoA.LandApprovedProjectCost = txtLand2.Text.ToUpper();
                    objvoA.LandLoanSactioned = txtLand3.Text.ToUpper();
                    objvoA.LandPromotersEquity = txtLand4.Text.ToUpper();
                    objvoA.LandLoanAmountReleased = txtLand5.Text.ToUpper();
                    objvoA.LandAssetsValuebyFinInstitution = txtLand6.Text.ToUpper();
                    objvoA.LandAssetsValuebyCA = txtLand7.Text.ToUpper();//txtLand7

                    objvoA.BuildingApprovedProjectCost = txtBuilding2.Text.ToUpper();
                    objvoA.BuildingLoanSactioned = txtBuilding3.Text.ToUpper();
                    objvoA.BuildingPromotersEquity = txtBuilding4.Text.ToUpper();
                    objvoA.BuildingLoanAmountReleased = txtBuilding5.Text.ToUpper();
                    objvoA.BuildingAssetsValuebyFinInstitution = txtBuilding6.Text.ToUpper();
                    objvoA.BuildingAssetsValuebyCA = txtBuilding7.Text.ToUpper();

                    objvoA.PlantMachineryApprovedProjectCost = txtPM2.Text.ToUpper();
                    objvoA.PlantMachineryLoanSactioned = txtPM3.Text.ToUpper();
                    objvoA.PlantMachineryPromotersEquity = txtPM4.Text.ToUpper();
                    objvoA.PlantMachineryLoanAmountReleased = txtPM5.Text.ToUpper();
                    objvoA.PlantMachineryAssetsValuebyFinInstitution = txtPM6.Text.ToUpper();
                    objvoA.PlantMachineryAssetsValuebyCA = txtPM7.Text.ToUpper();

                    objvoA.MachineryContingenciesApprovedProjectCost = txtMCont2.Text.ToUpper();
                    objvoA.MachineryContingenciesLoanSactioned = txtMCont3.Text.ToUpper();
                    objvoA.MachineryContingenciesPromotersEquity = txtMCont4.Text.ToUpper();
                    objvoA.MachineryContingenciesLoanAmountReleased = txtMCont5.Text.ToUpper();
                    objvoA.MachineryContingenciesAssetsValuebyFinInstitution = txtMCont6.Text.ToUpper();
                    objvoA.MachineryContingenciesAssetsValuebyCA = txtMCont7.Text.ToUpper();

                    objvoA.ErectionApprovedProjectCost = txtErec2.Text.ToUpper();
                    objvoA.ErectionLoanSactioned = txtErec3.Text.ToUpper();
                    objvoA.ErectionPromotersEquity = txtErec4.Text.ToUpper();
                    objvoA.ErectionLoanAmountReleased = txtErec5.Text.ToUpper();
                    objvoA.ErectionAssetsValuebyFinInstitution = txtErec6.Text.ToUpper();
                    objvoA.ErectionAssetsValuebyCA = txtErec7.Text.ToUpper();

                    objvoA.TechnicalfeasibilityApprovedProjectCost = txtTFS2.Text.ToUpper();
                    objvoA.TechnicalfeasibilityLoanSactioned = txtTFS3.Text.ToUpper();
                    objvoA.TechnicalfeasibilityPromotersEquity = txtTFS4.Text.ToUpper();
                    objvoA.TechnicalfeasibilityLoanAmountReleased = txtTFS5.Text.ToUpper();
                    objvoA.TechnicalfeasibilityAssetsValuebyFinInstitution = txtTFS6.Text.ToUpper();
                    objvoA.TechnicalfeasibilityAssetsValuebyCA = txtTFS7.Text.ToUpper();

                    objvoA.WorkingCapitalApprovedProjectCost = txtWC2.Text.ToUpper();
                    objvoA.WorkingCapitalLoanSactioned = txtWC3.Text.ToUpper();
                    objvoA.WorkingCapitalPromotersEquity = txtWC4.Text.ToUpper();
                    objvoA.WorkingCapitalLoanAmountReleased = txtWC5.Text.ToUpper();
                    objvoA.WorkingCapitalAssetsValuebyFinInstitution = txtWC6.Text.ToUpper();
                    objvoA.WorkingCapitalAssetsValuebyCA = txtWC7.Text.ToUpper();

                    objvo.isSecondHandMachVal = ddlHvuInstalledScndhndMech.SelectedItem.Text.ToUpper();
                    objvo.isSecondHandMachValValue = ddlHvuInstalledScndhndMech.SelectedValue;  // Not

                    if (ddlHvuInstalledScndhndMech.SelectedValue == "1")
                    {
                        objvo.SecondHandMachVal = txtsecondhndmachine.Text.ToUpper();
                        objvo.NewMachVal = txtnewmachine.Text.ToUpper();
                        objvo.Newand2ndlMachTotVal = txtTotalvalue12.Text.ToUpper();
                        objvo.PercentageSHMValinTotMachVal = txtpercentage12.Text.ToUpper();
                        objvo.MachValPrchasedfromAPIDCorAPSFCBank = txtmachinepucr.Text.ToUpper();
                        objvo.TotalMachVal = txttotal25.Text.ToUpper();
                    }
                    else
                    {
                        objvo.SecondHandMachVal = "0";
                        objvo.NewMachVal = "0";
                        objvo.Newand2ndlMachTotVal = "0";
                        objvo.PercentageSHMValinTotMachVal = "0";
                        objvo.MachValPrchasedfromAPIDCorAPSFCBank = "0";
                        objvo.TotalMachVal = "0";
                    }

                    objvo.Vatno = txtTinNO.Text.ToUpper(); // txtvatno.Text.ToUpper();
                    objvo.Cstno = txtTinNO.Text.ToUpper(); //txtcstno.Text.ToUpper();

                    string[] Ld3 = null;
                    string ConvertedDt6 = "";

                    if (txtCSTRegDate.Text != "")
                    {
                        Ld3 = txtCSTRegDate.Text.Split('/');
                        ConvertedDt6 = Ld3[2].ToString() + "/" + Ld3[1].ToString() + "/" + Ld3[0].ToString();

                        objvo.CSTRegDate = ConvertedDt6;
                    }
                    else
                    {
                        objvo.CSTRegDate = null;
                    }

                    objvo.CSTRegAuthority = txtCSTRegAuthority.Text.ToUpper();
                    objvo.CSTRegAuthAddress = txtCSTRegAuthAddress.Text.ToUpper();
                    objvo.GSTNO = txtTinNO.Text.ToUpper(); //txtGSTNo.Text.ToUpper();

                    if (txtGSTDate.Text != "" && txtGSTDate.Text != null)
                    {
                        string[] DateFormate = txtGSTDate.Text.Split('/');
                        objvo.GSTDate = DateFormate[2].ToString() + "/" + DateFormate[1].ToString() + "/" + DateFormate[0].ToString();
                    }
                    else
                    {
                        objvo.GSTDate = null;
                    }

                    objvo.ProjectFinance = "";


                    objvoA.created_dt = "";

                    objvoA.Modified_dt = "";
                    objvo.PowerStatus = ddlIndustryStatus.SelectedValue.ToString();

                    //Adding For TTAP
                    objvo.PromotersEquity_MF = txtPromotersEquity_MF.Text;
                    objvo.InstitutionEquity_MF = txtInstitutionEquity_MF.Text;
                    objvo.TermsLoans_MF = txtTermsLoans_MF.Text;
                    objvo.Others_MF = txtOthers_MF.Text;
                    objvo.SeedCapital_MF = txtSeedCapital_MF.Text;
                    objvo.SubsidyGrantsAgencies_MF = txtSubsidyGrantsAgencies_MF.Text;
                    objvo.IncentivesAvaild_StateCentrlGovt = ddlIncentivesAvaild_StateCentrlGovt.SelectedValue.ToString();
                    objvo.NameOfScheme_Agency = txtNameOfScheme_Agency.Text;

                    string ValidStatus = SaveNameofAssets(objvoA);

                    if (ValidStatus == "1")
                    {
                        string ValidStatusNew = InsertIncentivCommonDataStep4(objvo, LstIndustryTermLoanDtls);
                    }
                }
                else if (step == "5")
                {
                    objvo.BankName = ddlBank.SelectedValue;
                    objvo.BranchName = txtBranchName.Text.ToUpper();
                    objvo.BankAccType = ddlAccountType.SelectedValue;
                    objvo.BankAccName = txtAccountName.Text;
                    objvo.AccNo = txtAccNumber.Text.ToUpper();
                    objvo.IFSCCode = txtIfscCode.Text.ToUpper();
                    objvo.WhetherPower = ddlPower.SelectedItem.Text.ToUpper();
                    objvo.RequesttoDept = TxtRequesttoDepartment.Text.ToUpper();
                    string ValidStatusNew = InsertIncentivCommonDataStep5(objvo);
                    string flagupdate = Gen.UpdateTideaTprimeFlag(objvo.IncentveID);


                    // -----------------------------------------------------------------------------------------------------

                    string TypeofOrg = ddlOrgType.SelectedItem.Text.ToUpper();

                    bool PHtest0 = Convert.ToBoolean(0);
                    bool PHtest1 = Convert.ToBoolean(1);

                    if (rblVeh.SelectedIndex > -1 && rblSector.SelectedValue == "1")
                    {
                        objvo.isVehicleIncentive = Convert.ToBoolean(Convert.ToInt32(rblVeh.SelectedValue));
                    }
                    else
                    {
                        objvo.isVehicleIncentive = false;
                    }


                    string[] Ld2 = null;
                    string ConvertedDt5 = "";

                    if (txtDateofCommencement.Text != "")
                    {
                        Ld2 = txtDateofCommencement.Text.Split('/');
                        ConvertedDt5 = Ld2[2].ToString() + "/" + Ld2[1].ToString() + "/" + Ld2[0].ToString();

                        objvo.DateOfComm = ConvertedDt5;
                    }
                    else
                    {
                        objvo.DateOfComm = null;
                    }
                    objvo.IsGHMCandOtherMuncpOrp = Convert.ToBoolean(Convert.ToInt32(rblGHMC.SelectedValue));
                    objvo.SocialStatus = rblCaste.SelectedValue;
                    objvo.sector = rblSector.SelectedValue;
                    objvo.Category = HiddenFieldEnterpriseCategory.Value;

                    Session["Incentive_DateOfCommencement"] = objvo.DateOfComm;
                    Session["Incentive_isVehicle"] = objvo.isVehicleIncentive;
                    Session["Incentive_GHMC"] = objvo.IsGHMCandOtherMuncpOrp;
                    Session["Incentive_Caste"] = Convert.ToInt32(objvo.SocialStatus);
                    Session["Incentive_Sector"] = objvo.sector;
                    Session["Incentive_PHC"] = Convert.ToBoolean(0);
                    Session["Incentive_Category"] = objvo.Category;
                    Session["IndustryStatus"] = ddlIndustryStatus.SelectedValue;

                    if (ddleepinscap.SelectedItem.Text != "-- Select --")
                        objvo.eepinscapUnit = ddleepinscap.SelectedItem.Text.ToUpper();
                    else
                        objvo.eepinscapUnit = "0";

                    if (ddledpinscap.SelectedItem.Text != "-- Select --")
                        objvo.edpinscapUnit = ddledpinscap.SelectedItem.Text.ToUpper();
                    else
                        objvo.edpinscapUnit = "0";
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

        protected void btntab2previous_Click(object sender, EventArgs e)
        {
            lblmsg0.Text = "";
            Failure.Visible = false;
            Tab1.Attributes.Add("class", "active");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");
            //Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 0;
        }

        protected void btntab2next_Click(object sender, EventArgs e)
        {

            string errormsg = ValidateControls("2");
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                AssignValuestoVosFromcontrols("2");
            }

            ddlIspowApplicable_SelectedIndexChanged(sender, e);

            lblmsg0.Text = "";
            Failure.Visible = false;
            // MainView.ActiveViewIndex = 2;
            if (ddlIspowApplicable.SelectedItem.Text != "-- Select --")
            {
                ddlIspowApplicable_SelectedIndexChanged(sender, e);
            }
            if (ddlIndustryStatus.SelectedItem.Text == "New Industry")
            {
                if (trNewIndustry.Visible == true)
                {
                    //if (Session["i"].ToString() == "2")
                    //{
                    //    if (gvInstalledCapNew.Visible == false)
                    //    {
                    //        //if (txtLOActivity.Text != "" && txtunit.Text != "" && txtinstalledccap.Text != "" && txtvalue.Text != "")
                    //        //{
                    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter New Enterprise Details and click on Add button');", true);
                    //        return;
                    //        //}
                    //    }
                    //}
                    //else if (Session["i"].ToString() == "3")
                    //{
                    //    if (gvInstalledCap.Visible == false)
                    //    {
                    //        //if (txtLOActivity.Text != "" && txtunit.Text != "" && txtinstalledccap.Text != "" && txtvalue.Text != "")
                    //        //{
                    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter New Enterprise Details and click on Add button');", true);
                    //        return;
                    //        //}
                    //    }
                    //}
                    Tab1.Attributes.Add("class", "");
                    Tab2.Attributes.Add("class", "");
                    Tab3.Attributes.Add("class", "active");
                    Tab4.Attributes.Add("class", "");
                    Tab5.Attributes.Add("class", "");
                    //Tab6.Attributes.Add("class", "");
                    MainView.ActiveViewIndex = 2;
                    //if (Session["i"].ToString() == "2")
                    //{
                    //    tblview3.Visible = false;
                    //}
                    //else
                    //{
                    //    tblview3.Visible = true;
                    //    tblpower1.Visible = false;

                    //}
                }
            }
            else if (ddlIndustryStatus.SelectedValue == "2" || ddlIndustryStatus.SelectedValue == "3")
            {
                //if (trexpansion.Visible == true)
                //{
                trNewIndustry.Visible = true;
                gvInstalledCap.Visible = true;

                //if (GridView1.Visible == false)
                //{
                //    trNewIndustry.Visible = true;
                //    gvInstalledCap.Visible = false;
                //if (txtplantpercentage.Text == "" || txtplantpercentage.Text == null)
                //{
                //    //if (txtLOActivity.Text != "" && txtunit.Text != "" && txtinstalledccap.Text != "" && txtvalue.Text != "")
                //    //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Existing / Expansion Enterprise Details and click on Add button');", true);
                //    return;
                //    //}
                //    //}
                //}

                Tab1.Attributes.Add("class", "");
                Tab2.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "active");
                Tab4.Attributes.Add("class", "");
                Tab5.Attributes.Add("class", "");
                //Tab6.Attributes.Add("class", "");
                MainView.ActiveViewIndex = 2;
                //if (Session["i"].ToString() == "2")
                //{
                //    tblview3.Visible = false;
                //}
                //else
                //{
                //    tblview3.Visible = true;
                //    tblpower1.Visible = false;

                //}
                MainView.ActiveViewIndex = 2;
                // }
            }

            //if (trNewIndustry.Visible == false)
            //{
            //    tblview3.Visible = false;
            //}

        }

        protected void btntab3previous_Click(object sender, EventArgs e)
        {
            lblmsg0.Text = "";
            Failure.Visible = false;

            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "active");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");
            //Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 1;
            if (ddlIspowApplicable.SelectedItem.Text != "-- Select --")
            {
                ddlIspowApplicable_SelectedIndexChanged(sender, e);
            }
        }

        protected void btntab3next_Click(object sender, EventArgs e)
        {

            string errormsg = ValidateControls("3");
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                AssignValuestoVosFromcontrols("3");
            }


            lblmsg0.Text = "";
            Failure.Visible = false;
            //if (trAuthSignatoryDesignation.Visible == true)
            //{
            //    if (txtAuthSignOtherDesignation.Text == "" || txtAuthSignOtherDesignation.Text == null)
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Authorised Signatory Designation');", true);
            //        return;
            //    }
            //}


            //if (tblview3.Visible == true)
            //{
            //    //if (GridView3.Visible == false)
            //    if (GridView3.Rows.Count <= 0)
            //    {
            //        //if (txtnamedparter.Text != "" && txtcommunity.Text != "" && txtshare.Text != "" && txtpercentage.Text != "")
            //        //{
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter Details of the Director(s)/ Partner(s) and click on Add button');", true);
            //        return;
            //        //}
            //    }
            //}
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "active");
            Tab5.Attributes.Add("class", "");
            //Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 3;
        }

        protected void btntab4previous_Click(object sender, EventArgs e)
        {
            lblmsg0.Text = "";
            Failure.Visible = false;

            //Tab1.Attributes.Add("class", "");
            //Tab2.Attributes.Add("class", "");
            //Tab3.Attributes.Add("class", "active");
            //Tab4.Attributes.Add("class", "");
            //Tab5.Attributes.Add("class", "");
            //Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 2;
        }

        //protected void btntab4next_Click(object sender, EventArgs e)
        //{
        //    lblmsg0.Text = "";
        //    Failure.Visible = false;

        //    BtnSave.Visible = true;
        //    BtnClear.Visible = true;

        //    Tab1.Attributes.Add("class", "");
        //    Tab2.Attributes.Add("class", "");
        //    Tab3.Attributes.Add("class", "");
        //    Tab4.Attributes.Add("class", "");
        //    Tab5.Attributes.Add("class", "active");
        //    //Tab6.Attributes.Add("class", "");
        //    MainView.ActiveViewIndex = 4;

        //    if (btnNext.Text == "Submit")
        //    {
        //        BtnSave.Enabled = false;
        //        BtnSave.Visible = false;
        //        BtnClear.Enabled = true;
        //        btnNext.Visible = true;
        //    }
        //    else
        //    {
        //        BtnSave.Enabled = true;
        //        BtnClear.Enabled = true;
        //        btnNext.Visible = false;
        //    }
        //}

        //protected void btntab5previous_Click(object sender, EventArgs e)
        //{
        //    Tab1.Attributes.Add("class", "");
        //    Tab2.Attributes.Add("class", "");
        //    Tab3.Attributes.Add("class", "");
        //    Tab4.Attributes.Add("class", "active");
        //    Tab5.Attributes.Add("class", "");
        //    Tab6.Attributes.Add("class", "");
        //    MainView.ActiveViewIndex = 3;
        //}

        //protected void btntab5next_Click(object sender, EventArgs e)
        //{
        //    Tab1.Attributes.Add("class", "");
        //    Tab2.Attributes.Add("class", "");
        //    Tab3.Attributes.Add("class", "");
        //    Tab4.Attributes.Add("class", "");
        //    Tab5.Attributes.Add("class", "");
        //    Tab6.Attributes.Add("class", "active");
        //    MainView.ActiveViewIndex = 5;
        //}

        protected void btntab4next_Click(object sender, EventArgs e)
        {

            string errormsg = ValidateControls("4");
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                AssignValuestoVosFromcontrols("4");
            }

            // modified on 11.08.2017 for service and transport GSTNo is not mandatory
            if (rblSector.SelectedItem.Text.ToUpper() != "SERVICE" && rblVeh.SelectedValue != "1")
            {
                if (txtvatno.Text.Trim() == "" && txtvatno.Text.Trim() == string.Empty)
                {
                    string message = "alert('Please enter GST NO')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    lblmsg0.Text = "";
                    Failure.Visible = false;

                    BtnSave.Visible = false;
                    btnNext.Visible = true;
                    BtnClear.Visible = true;

                    Tab1.Attributes.Add("class", "");
                    Tab2.Attributes.Add("class", "");
                    Tab3.Attributes.Add("class", "");
                    Tab4.Attributes.Add("class", "");
                    Tab5.Attributes.Add("class", "active");
                    //Tab6.Attributes.Add("class", "");
                    MainView.ActiveViewIndex = 4;

                    if (btnNext.Text == "Submit")
                    {
                        BtnSave.Enabled = false;
                        BtnSave.Visible = false;
                        BtnClear.Enabled = true;
                        btnNext.Visible = true;
                    }
                    else
                    {
                        BtnSave.Enabled = true;
                        BtnClear.Enabled = true;
                        btnNext.Visible = true;
                    }

                }
            }
            else
            {
                lblmsg0.Text = "";
                Failure.Visible = false;

                BtnSave.Visible = false;
                btnNext.Visible = true;
                BtnClear.Visible = true;

                Tab1.Attributes.Add("class", "");
                Tab2.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "");
                Tab4.Attributes.Add("class", "");
                Tab5.Attributes.Add("class", "active");
                //Tab6.Attributes.Add("class", "");
                MainView.ActiveViewIndex = 4;

                if (btnNext.Text == "Submit")
                {
                    BtnSave.Enabled = false;
                    BtnSave.Visible = false;
                    BtnClear.Enabled = true;
                    btnNext.Visible = true;
                }
                else
                {
                    BtnSave.Enabled = true;
                    BtnClear.Enabled = true;
                    btnNext.Visible = false;
                }

            }

        }

        protected void btntab6previous_Click(object sender, EventArgs e)
        {
            tblview3.Visible = true;
            BtnSave.Visible = false;
            BtnClear.Visible = false;
            btnNext.Visible = false;

            lblmsg0.Text = "";
            Failure.Visible = false;

            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "active");
            Tab5.Attributes.Add("class", "");
            //Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 3;
        }

        protected void ddlHvuInstalledScndhndMech_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHvuInstalledScndhndMech.SelectedItem.Text == "Yes")
            {
                trSecondhandmachinery.Visible = true;
                txtsecondhndmachine.Text = "";
                txtnewmachine.Text = "";
                txtTotalvalue12.Text = "";
                txtpercentage12.Text = "";
                txtmachinepucr.Text = "";
                txttotal25.Text = "";
            }
            else
            {
                trSecondhandmachinery.Visible = false;
                txtsecondhndmachine.Text = "0";
                txtnewmachine.Text = "0";
                txtTotalvalue12.Text = "0";
                txtpercentage12.Text = "0";
                txtmachinepucr.Text = "0";
                txttotal25.Text = "0";
            }
        }

        protected void ddlsubsidy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlsubsidy.SelectedItem.Text == "Yes")
                {
                    //trsubidy1.Visible = true;
                    //trsubidy2.Visible = true;
                    //txtschema.Text = "";
                    //txtamount.Text = "";
                }
                else
                {
                    //trsubidy1.Visible = false;
                    //trsubidy2.Visible = false;
                    //txtschema.Text = "0";
                    //txtamount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindConstitutionUnit()
        {
            try
            {
                dsdorg = objFetch.FetchConstitutionUnit();
                //dsdorg.Tables.Add(dtorg);
                //dsdorg.Tables.Remove(dtorg);
                if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
                {
                    ddlOrgType.DataSource = dsdorg.Tables[0];
                    ddlOrgType.DataValueField = "CunitId";
                    ddlOrgType.DataTextField = "ConstitutionUnit";
                    ddlOrgType.DataBind();
                    ddlOrgType.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlOrgType.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void rblCaste_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (rblCaste.SelectedValue == "2")
                {
                    divsubcaste.Visible = true;
                }
                else
                {
                    divsubcaste.Visible = false;
                }

                rblSector_SelectedIndexChanged(sender, e);

                if (rblSector.SelectedValue == "1")
                {
                    if (rblCaste.SelectedValue == "3" || rblCaste.SelectedValue == "4" || cbDiffAbled.Checked == true)
                    {
                        divrblVeh.Visible = true;
                        rblVeh.Items[0].Enabled = true;
                        //ddlOrgType.SelectedValue = "1";
                        //ddlOrgType.Enabled = false;
                        //ddlOrgType_SelectedIndexChanged(sender, e);
                        rblVeh.SelectedValue = "1";
                        rblVeh_SelectedIndexChanged(sender, e);
                        rblVeh.Enabled = true;
                    }
                    else
                    {
                        divrblVeh.Visible = true;
                        rblVeh.Items[0].Enabled = false;
                        rblVeh.SelectedValue = "0";
                        rblVeh_SelectedIndexChanged(sender, e);
                        ddlOrgType.Enabled = true;
                        rblVeh.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
            }
        }
        public int AssignValuestoControls(string userid, string incentiveid)
        {

            DataSet ds = new DataSet();
            try
            {
                ds = Gen.GETINCENTIVESCAFDATA(userid, incentiveid);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    string applicationStatus1 = "";
                    applicationStatus1 = ds.Tables[0].Rows[0]["intStatusid"].ToString();
                    BtnSave.Visible = false;
                    btnNext.Text = "Submit";
                    // step1

                    Session["IncentveID"] = ds.Tables[0].Rows[0]["IncentveID"].ToString();

                    if (ds.Tables[0].Rows[0]["sector"].ToString() != "")
                    {

                        rblSector.SelectedValue = ds.Tables[0].Rows[0]["sector"].ToString();
                        rblSector.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadharType"].ToString() != "")
                    {
                        ddlUdyogAadharType.SelectedValue = ds.Tables[0].Rows[0]["UdyogAadharType"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString() != "")
                    {
                        txtudyogAadharNo.Text = ds.Tables[0].Rows[0]["EMiUdyogAadhar"].ToString();
                        txtudyogAadharNo.Enabled = false;
                    }

                    if (ds.Tables[0].Rows[0]["Uid_NO"].ToString() != "")
                    {
                        txtuidno.Text = ds.Tables[0].Rows[0]["Uid_NO"].ToString();
                        txtuidno.Enabled = false;
                    }

                    if (ds.Tables[0].Rows[0]["IncentveID"].ToString() != "")
                    {
                        string abc = ds.Tables[0].Rows[0]["IncentveID"].ToString();
                        Session["IncentiveID"] = ds.Tables[0].Rows[0]["IncentveID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != null || ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString() != "")
                    {
                        txtUdyogAadhaarRegdDate.Text = ds.Tables[0].Rows[0]["UdyogAadhaarRegdDateNew"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UnitName"].ToString() != "")
                    {
                        txtUser_Id.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                        txtUser_Id.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["ApplciantName"].ToString() != "")
                    {
                        txtApplciantName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                        txtApplciantName.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["TinNO"].ToString() != "")
                    {
                        txtTinNO.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                        txtTinNO.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["PanNo"].ToString() != "")
                    {
                        txtPanNo.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                        txtPanNo.Enabled = false;
                    }
                    string IsDifferentlyAbled = ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString();
                    string IsMinority = ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString();

                    if (IsDifferentlyAbled == "Y")
                    {
                        cbDiffAbled.Checked = true;
                        cbDiffAbled.Enabled = false;
                    }
                    else
                    {
                        cbDiffAbled.Enabled = false;
                    }

                    //if (IsMinority == "Y")
                    //{
                    //    cbMinority.Checked = true;
                    //    cbMinority.Enabled = false;
                    //}
                    //else
                    //{
                    //    cbMinority.Enabled = false;
                    //}
                    if (ds.Tables[0].Rows[0]["COMMDATE"].ToString() != "")
                    {
                        txtDateofCommencement.Text = ds.Tables[0].Rows[0]["COMMDATE"].ToString();
                        txtDateofCommencement.Enabled = false;
                    }
                    objvo.DateOfComm = txtDateofCommencement.Text;
                    Session["Incentive_DateOfCommencement"] = txtDateofCommencement.Text;

                    if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                    {
                        ddlgender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                        ddlgender.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["Caste"].ToString() != "")
                    {
                        rblCaste.SelectedValue = ds.Tables[0].Rows[0]["Caste"].ToString();
                        if (rblCaste.SelectedValue == "2")
                        {
                            rblCaste_SelectedIndexChanged(this, EventArgs.Empty);
                            divsubcaste.Visible = true;
                            if (ds.Tables[0].Rows[0]["SubCaste"] != null && ds.Tables[0].Rows[0]["SubCaste"].ToString() != "--Select--")
                            {
                                ddlsubcaste.SelectedValue = ds.Tables[0].Rows[0]["SubCaste"].ToString();
                            }
                            else { ddlsubcaste.Enabled = true; }
                        }
                        else
                        {
                            divsubcaste.Visible = false;
                        }

                        if (rblSector.SelectedValue == "1")
                        {
                            rblCaste_SelectedIndexChanged(this, EventArgs.Empty);

                            if (rblCaste.SelectedValue == "3" || rblCaste.SelectedValue == "4")
                            {
                                divrblVeh.Visible = true;
                            }
                            else
                            {
                                divrblVeh.Visible = false;
                            }
                        }
                    }

                    if (ds.Tables[0].Rows[0]["Caste"].ToString() == "2")
                    {
                        if (divsubcaste.Visible == true)
                        {
                            ddlsubcaste.SelectedValue = ds.Tables[0].Rows[0]["SubCaste"].ToString();
                            ddlsubcaste.Enabled = false;
                        }
                    }
                    if (ds.Tables[0].Rows[0]["isVehicleIncentive"].ToString() == "0")
                    {
                        rblVeh.SelectedIndex = 1;
                        //rblVeh.Enabled = false;
                    }
                    else
                    {
                        rblVeh.SelectedIndex = 0;
                        //rblVeh.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["VehicleNumber"].ToString() != null && ds.Tables[0].Rows[0]["VehicleNumber"].ToString() != "")
                    {
                        txtregistrationno.Text = ds.Tables[0].Rows[0]["VehicleNumber"].ToString();
                        divvehicleno.Visible = true;
                    }
                    else
                    {
                        divvehicleno.Visible = true;
                    }
                    if (ds.Tables[0].Rows[0]["UnitState"].ToString() != "")
                    {
                        ddlUnitstate.SelectedValue = ds.Tables[0].Rows[0]["UnitState"].ToString();
                        ddlUnitstate.Enabled = false;
                        ddlUnitstate_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    //Unit District Binding 

                    if (ds.Tables[0].Rows[0]["UnitDIst"].ToString() != "")
                    {
                        ddlUnitDIst.SelectedValue = ds.Tables[0].Rows[0]["UnitDIst"].ToString();
                        ddlUnitDIst.Enabled = false;
                        ddldistrictunit_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    // Getmandalsunit();

                    if (ds.Tables[0].Rows[0]["UnitMandal"].ToString() != "")
                    {
                        ddlUnitMandal.SelectedValue = ds.Tables[0].Rows[0]["UnitMandal"].ToString();
                        ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlUnitMandal.Enabled = false;
                    }
                    //Getvillagesunit();

                    if (ds.Tables[0].Rows[0]["UnitVill"].ToString() != "")
                    {
                        ddlVillageunit.SelectedValue = ds.Tables[0].Rows[0]["UnitVill"].ToString();
                        ddlVillageunit_SelectedIndexChanged(this, EventArgs.Empty);
                        ddlVillageunit.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["UnitHNO"].ToString() != "")
                    {
                        txtUnitHNO.Text = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                        txtUnitHNO.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["UnitStreet"].ToString() != "")
                    {
                        txtUnitStreet.Text = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                        txtUnitStreet.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["UnitMObileNo"].ToString() != "")
                    {
                        txtunitmobileno.Text = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                        txtunitmobileno.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["UnitEmail"].ToString() != "")
                    {
                        txtunitemailid.Text = ds.Tables[0].Rows[0]["UnitEmail"].ToString();
                        txtunitemailid.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["OffcState"].ToString() != "")
                    {
                        ddloffcstate.SelectedValue = ds.Tables[0].Rows[0]["OffcState"].ToString();
                        ddloffcstate.Enabled = false;
                    }
                    //Office District Binding 
                    if (ds.Tables[0].Rows[0]["OffcState"].ToString() == "31")
                    {
                        ddloffcstate_SelectedIndexChanged(this, EventArgs.Empty);
                        if (ds.Tables[0].Rows[0]["OffcDIst"].ToString() != "")
                        {
                            ddlOffcDIst.SelectedValue = ds.Tables[0].Rows[0]["OffcDIst"].ToString();
                            ddlOffcDIst.Enabled = false;
                            ddldistrictoffc_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        // Getmandalsoffc();

                        if (ds.Tables[0].Rows[0]["OffcMandal"].ToString() != "")
                        {
                            ddlOffcMandal.SelectedValue = ds.Tables[0].Rows[0]["OffcMandal"].ToString();
                            ddlOffcMandal.Enabled = false;
                            ddloffcmandal_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        if (ds.Tables[0].Rows[0]["OffcVill"].ToString() != "")
                        {
                            ddlOffcVil.SelectedValue = ds.Tables[0].Rows[0]["OffcVill"].ToString();
                            ddlOffcVil.Enabled = false;
                        }
                    }
                    else
                    {
                        ddloffcstate_SelectedIndexChanged(this, EventArgs.Empty);
                        if (ds.Tables[0].Rows[0]["OffcOtherDist"].ToString() != "")
                        {
                            txtofficedist.Text = ds.Tables[0].Rows[0]["OffcOtherDist"].ToString();
                            txtofficedist.Enabled = false;
                        }
                        if (ds.Tables[0].Rows[0]["OffcOtherMandal"].ToString() != "")
                        {
                            txtoffcicemandal.Text = ds.Tables[0].Rows[0]["OffcOtherMandal"].ToString();
                            txtoffcicemandal.Enabled = false;
                        }
                        if (ds.Tables[0].Rows[0]["OffcOtherVillage"].ToString() != "")
                        {
                            txtofficeviiage.Text = ds.Tables[0].Rows[0]["OffcOtherVillage"].ToString();
                            txtofficeviiage.Enabled = false;
                        }
                    }
                    if (ds.Tables[0].Rows[0]["OffcHNO"].ToString() != "")
                    {
                        txtoffaddhnno.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                        txtoffaddhnno.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["OffcStreet"].ToString() != "")
                    {
                        txtOffcStreet.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                        txtOffcStreet.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["OffcMobileNO"].ToString() != "")
                    {
                        txtOffcMobileNO.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                        txtOffcMobileNO.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["OffcEmail"].ToString() != "")
                    {
                        txtOffcEmail.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();
                        txtOffcEmail.Enabled = false;
                    }

                    if (ds.Tables[0].Rows[0]["OrgType"].ToString() != "")
                    {
                        ddlOrgType.SelectedValue = ds.Tables[0].Rows[0]["OrgType"].ToString();
                        ddlOrgType.Enabled = false;
                        ddlOrgType_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["IsGHMCandOtherMuncpOrp"].ToString() != "")
                    {
                        string ghmc = ds.Tables[0].Rows[0]["IsGHMCandOtherMuncpOrp"].ToString();
                        //GHMC                    
                        rblGHMC.SelectedValue = ds.Tables[0].Rows[0]["IsGHMCandOtherMuncpOrp"].ToString();
                        rblGHMC.Enabled = false;

                        if (ghmc == "0")
                        {
                            divIsIALA.Visible = true;
                            if (ds.Tables[0].Rows[0]["isIALA"].ToString() != "")
                            {
                                rdIaLa_Lst.SelectedValue = ds.Tables[0].Rows[0]["isIALA"].ToString();
                                if (rdIaLa_Lst.SelectedValue == "Y")
                                {
                                    divIndusParkList.Visible = true;
                                    BindIndustrialParks();
                                    if (ds.Tables[0].Rows[0]["IndusParkList"].ToString() != "")
                                    {
                                        ddlIndustrialParkName.SelectedValue = ds.Tables[0].Rows[0]["IndusParkList"].ToString();
                                    }

                                }
                                else
                                {
                                    divIndusParkList.Visible = false;

                                }
                            }

                        }
                        else
                        {
                            divIsIALA.Visible = false;
                            divIndusParkList.Visible = false;
                        }
                    }
                    if (ds.Tables[0].Rows[0]["natureOfAct"].ToString() != "")
                    {
                        ddlintLineofActivity.SelectedValue = ds.Tables[0].Rows[0]["natureOfAct"].ToString();
                        ddlintLineofActivity.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["NatureofBussiness"].ToString() != "")
                    {
                        ddlintLineofActivity.Visible = false;
                        txtBussinessActivity.Visible = true;
                        txtBussinessActivity.Text = ds.Tables[0].Rows[0]["NatureofBussiness"].ToString();
                    }
                    objvo.UnitDIstId = ds.Tables[0].Rows[0]["UnitDist"].ToString();
                    Session["unitdistid"] = objvo.UnitDIstId;
                    objvo.UnitMandalId = ds.Tables[0].Rows[0]["UnitMandal"].ToString();
                    Session["unitmandalid"] = objvo.UnitMandalId;
                    objvo.UnitVillId = ds.Tables[0].Rows[0]["UnitVill"].ToString();
                    Session["unitvillageid"] = objvo.UnitVillId;

                    if (ds.Tables[0].Rows[0]["isVehicleIncentive"].ToString() != "")
                    {
                        rblVeh.SelectedValue = ds.Tables[0].Rows[0]["isVehicleIncentive"].ToString();
                    }
                    if (rblVeh.SelectedIndex > -1)
                    {
                        objvo.isVehicleIncentive = (rblVeh.SelectedValue == "0" ? true : false);
                    }

                    objvo.isVehicleIncentive = Convert.ToBoolean(Convert.ToInt32(rblVeh.SelectedValue));
                    rblVeh_SelectedIndexChanged(this, EventArgs.Empty);  // added on 03.09.2017

                    Session["Incentive_isVehicle"] = objvo.isVehicleIncentive;

                    if (rblGHMC.SelectedIndex > -1)
                    {
                        objvo.IsGHMCandOtherMuncpOrp = (rblGHMC.SelectedValue == "0" ? true : false);
                    }
                    objvo.IsGHMCandOtherMuncpOrp = Convert.ToBoolean(Convert.ToInt32(rblGHMC.SelectedValue));
                    Session["Incentive_GHMC"] = objvo.IsGHMCandOtherMuncpOrp;   // ok

                    objvo.SocialStatus = ds.Tables[0].Rows[0]["caste"].ToString();
                    Session["Incentive_Caste"] = Convert.ToInt32(objvo.SocialStatus);  //ok
                    objvo.sector = rblSector.SelectedValue;
                    Session["Incentive_Sector"] = objvo.sector;   //ok

                    objvo.IsDifferentlyAbled = (cbDiffAbled.Checked == true ? "0" : "1");
                    Session["Incentive_PHC"] = Convert.ToBoolean(0);


                    // --------------------------------------------------------------------------- STEP 1  END ---------------------------------------------------------------------------
                    if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() != "")
                    {
                        ddlIndustryStatus.SelectedValue = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                        Session["IndustryStatus"] = ddlIndustryStatus.SelectedValue;
                        ddlindustryStatus_SelectedIndexChanged(this, EventArgs.Empty);
                        if (ddlIndustryStatus.SelectedValue == "2" || ddlIndustryStatus.SelectedValue == "3")
                        {
                            ddlInustryExpansionType.SelectedValue = ds.Tables[0].Rows[0]["IndusExpanType"].ToString();
                            divIndustryExpansionType.Visible = true;
                            ddlInustryExpansionType.Enabled = false;
                        }
                        else
                        {
                            divIndustryExpansionType.Visible = false;
                        }
                        if (ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString() != "")
                        {
                            txtlandcapacity.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                            txtlandcapacity.Enabled = false;
                        }
                        else
                        {
                            txtlandcapacity.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString() != "")
                        {
                            txtlandexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                            txtlandexisting.Enabled = false;
                        }
                        else
                        {
                            txtlandexisting.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString() != "")
                        {
                            txtlandpercentage.Text = ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();
                            txtlandpercentage.Enabled = false;
                        }
                        else
                        {
                            txtlandpercentage.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString() != "")
                        {
                            txtbuildingcapacity.Text = ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                            txtbuildingcapacity.Enabled = false;
                        }
                        else
                        {
                            txtbuildingcapacity.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString() != "")
                        {
                            txtbuildingexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                            txtbuildingexisting.Enabled = false;
                        }
                        else
                        {
                            txtbuildingexisting.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString() != "")
                        {
                            txtbuildingpercentage.Text = ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();
                            txtbuildingpercentage.Enabled = false;
                        }
                        else
                        {
                            txtbuildingpercentage.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString() != "")
                        {
                            txtplantcapacity.Text = ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                            txtplantcapacity.Enabled = false;
                        }
                        else
                        {
                            txtplantcapacity.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString() != "")
                        {
                            txtplantexisting.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                            txtplantexisting.Enabled = false;
                        }
                        else
                        {
                            txtplantexisting.Enabled = true;
                        }

                        #region Added by naresh

                        if (ds.Tables[0].Rows[0]["PlinthArea"].ToString() != "")
                        {
                            txtPlinthArea.Text = ds.Tables[0].Rows[0]["PlinthArea"].ToString();
                            txtPlinthArea.Enabled = false;
                        }
                        else
                        {
                            txtPlinthArea.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["RateperAcre"].ToString() != "")
                        {
                            txtRateperAcre.Text = ds.Tables[0].Rows[0]["RateperAcre"].ToString();
                            txtRateperAcre.Enabled = false;
                        }
                        else
                        {
                            txtRateperAcre.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["TotalInvestment"].ToString() != "")
                        {
                            txtTotalInvestment.Text = ds.Tables[0].Rows[0]["TotalInvestment"].ToString();
                            txtTotalInvestment.Enabled = false;
                        }
                        else
                        {
                            txtTotalInvestment.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["Infrastructure1"].ToString() != "")
                        {
                            txtInfrastructure1.Text = ds.Tables[0].Rows[0]["Infrastructure1"].ToString();
                            txtInfrastructure1.Enabled = false;
                        }
                        else
                        {
                            txtInfrastructure1.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["Infrastructure2"].ToString() != "")
                        {
                            txtInfrastructure2.Text = ds.Tables[0].Rows[0]["Infrastructure2"].ToString();
                            txtInfrastructure2.Enabled = false;
                        }
                        else
                        {
                            txtInfrastructure2.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["Infrastructure3"].ToString() != "")
                        {
                            txtInfrastructure3.Text = ds.Tables[0].Rows[0]["Infrastructure3"].ToString();
                            txtInfrastructure3.Enabled = false;
                        }
                        else
                        {
                            txtInfrastructure3.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["OtherProductive1"].ToString() != "")
                        {
                            txtOtherProductive1.Text = ds.Tables[0].Rows[0]["OtherProductive1"].ToString();
                            txtOtherProductive1.Enabled = false;
                        }
                        else
                        {
                            txtOtherProductive1.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["OtherProductive2"].ToString() != "")
                        {
                            txtOtherProductive2.Text = ds.Tables[0].Rows[0]["OtherProductive2"].ToString();
                            txtOtherProductive2.Enabled = false;
                        }
                        else
                        {
                            txtOtherProductive2.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["OtherProductive3"].ToString() != "")
                        {
                            txtOtherProductive3.Text = ds.Tables[0].Rows[0]["OtherProductive3"].ToString();
                            txtOtherProductive3.Enabled = false;
                        }
                        else
                        {
                            txtOtherProductive3.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["TotalInvestmentBuilding"].ToString() != "")
                        {
                            txtTotalInvestmentBuilding.Text = ds.Tables[0].Rows[0]["TotalInvestmentBuilding"].ToString();
                            txtTotalInvestmentBuilding.Enabled = false;
                        }
                        else
                        {
                            txtTotalInvestmentBuilding.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["Transportation"].ToString() != "")
                        {
                            txtTransportation.Text = ds.Tables[0].Rows[0]["Transportation"].ToString();
                            txtTransportation.Enabled = false;
                        }
                        else
                        {
                            txtTransportation.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["Erection"].ToString() != "")
                        {
                            txtErection.Text = ds.Tables[0].Rows[0]["Erection"].ToString();
                            txtErection.Enabled = false;
                        }
                        else
                        {
                            txtErection.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["Electrification"].ToString() != "")
                        {
                            txtElectrification.Text = ds.Tables[0].Rows[0]["Electrification"].ToString();
                            txtElectrification.Enabled = false;
                        }
                        else
                        {
                            txtElectrification.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["OtherAssets"].ToString() != "")
                        {
                            txtOtherAssets.Text = ds.Tables[0].Rows[0]["OtherAssets"].ToString();
                            txtOtherAssets.Enabled = false;
                        }
                        else
                        {
                            txtOtherAssets.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["TotalPlantMechinery"].ToString() != "")
                        {
                            txtTotalPlantMechinery.Text = ds.Tables[0].Rows[0]["TotalPlantMechinery"].ToString();
                            txtTotalPlantMechinery.Enabled = false;
                        }
                        else
                        {
                            txtTotalPlantMechinery.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["TotalCapitalInvestment"].ToString() != "")
                        {
                            txtTotalCapitalInvestment.Text = ds.Tables[0].Rows[0]["TotalCapitalInvestment"].ToString();
                            txtTotalCapitalInvestment.Enabled = false;
                        }
                        else
                        {
                            txtTotalCapitalInvestment.Enabled = true;
                        }
                        #endregion


                        if (ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString() != "")
                        {
                            txtplantpercentage.Text = ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();
                            txtplantpercentage.Enabled = false;
                        }
                        else
                        {
                            txtplantpercentage.Enabled = true;
                        }


                        if (ds.Tables[0].Rows[0]["Category"].ToString() != "")
                        {
                            HiddenFieldEnterpriseCategory.Value = "";
                            HiddenFieldEnterpriseCategory.Value = ds.Tables[0].Rows[0]["Category"].ToString();
                            //4	Large  //3	Medium       //5	Mega  //1	Micro     //2	Small
                            if (HiddenFieldEnterpriseCategory.Value == "1")
                            {
                                lblEnterpriseCategoryTTAP.Text = "A1";
                                lblEnterpriseCategory.Text = "Micro";

                            }
                            if (HiddenFieldEnterpriseCategory.Value == "2")
                            {
                                lblEnterpriseCategoryTTAP.Text = "A2";
                                lblEnterpriseCategory.Text = "Small";

                            }
                            else if (HiddenFieldEnterpriseCategory.Value == "3")
                            {
                                lblEnterpriseCategoryTTAP.Text = "A3";
                                lblEnterpriseCategory.Text = "Medium";

                            }
                            else if (HiddenFieldEnterpriseCategory.Value == "4")
                            {
                                lblEnterpriseCategoryTTAP.Text = "A4";
                                lblEnterpriseCategory.Text = "Large";

                            }
                            else if (HiddenFieldEnterpriseCategory.Value == "5")
                            {
                                lblEnterpriseCategoryTTAP.Text = "A5";
                                lblEnterpriseCategory.Text = "Mega";

                            }

                        }
                    }
                    else
                    {
                        ddlIndustryStatus.Enabled = true;
                    }


                    // --------------------------------------------------------------------------STEP 2 END ------------------------------------------------------------------------------------

                    if (ds.Tables[0].Rows[0]["AuthorisedSignatory"].ToString() != null || ds.Tables[0].Rows[0]["AuthorisedSignatory"].ToString() != "")
                    {
                        txtAuthorisedSign.Text = ds.Tables[0].Rows[0]["AuthorisedSignatory"].ToString();
                    }



                    string AuthorisedDes = ds.Tables[0].Rows[0]["AuthorisedSignatoryDesignationValue"].ToString();
                    if (AuthorisedDes == "3")
                    {
                        ddlAuthorisedSignDesignation.SelectedValue = AuthorisedDes;
                        ddlAuthorisedSignDesignation_SelectedIndexChanged(this, EventArgs.Empty);
                        if (ds.Tables[0].Rows[0]["AuthorisedSignatoryDesignation"].ToString() != "")
                        {
                            txtAuthSignOtherDesignation.Text = ds.Tables[0].Rows[0]["AuthorisedSignatoryDesignation"].ToString();  //  No
                        }
                    }
                    else
                    {
                        ddlAuthorisedSignDesignation.SelectedValue = AuthorisedDes;
                    }

                    if (ds.Tables[0].Rows[0]["IsPowerApplicable"].ToString() != "")
                    {
                        ddlIspowApplicable.SelectedValue = ds.Tables[0].Rows[0]["IsPowerApplicableValue"].ToString();
                        //  ddlIspowApplicable.SelectedItem.Text = ds.Tables[0].Rows[0]["IsPowerApplicable"].ToString();
                        ddlIspowApplicable_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
                    {
                        if (ds.Tables[0].Rows[0]["NewPowerReleaseDateNew"].ToString() != "") { txtNewPowerReleaseDate.Text = ds.Tables[0].Rows[0]["NewPowerReleaseDateNew"].ToString(); txtNewPowerReleaseDate.Enabled = false; }
                        else { txtNewPowerReleaseDate.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString() != "") { txtNewConnectedLoad.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString(); txtNewConnectedLoad.Enabled = false; }
                        else { txtNewConnectedLoad.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["NewContractedLoad"].ToString() != "") { txtNewContractedLoad.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString(); txtNewContractedLoad.Enabled = false; }
                        else { txtNewContractedLoad.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["ServiceConnectionNO"].ToString() != "") { txtServiceConnectionNumber.Text = ds.Tables[0].Rows[0]["ServiceConnectionNO"].ToString(); txtServiceConnectionNumber.Enabled = false; }
                        else { txtServiceConnectionNumber.Enabled = true; }
                        //}
                        //if(tblpower2.Visible==true)
                        //{   

                        if (ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString() != "") { txtExistingConnectedLoad.Text = ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString(); txtExistingConnectedLoad.Enabled = false; }
                        else { txtExistingConnectedLoad.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString() != "") { txtExistingContractedLoad.Text = ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString(); txtExistingContractedLoad.Enabled = false; }
                        else { txtExistingContractedLoad.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["ExistingPowerReleaseDateNew"].ToString() != "") { txtExistingPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExistingPowerReleaseDateNew"].ToString(); txtExistingPowerReleaseDate.Enabled = false; }
                        else { txtExistingPowerReleaseDate.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["ExistingServiceConnectionNO"].ToString() != "") { txtExistingServiceConnectionNO.Text = ds.Tables[0].Rows[0]["ExistingServiceConnectionNO"].ToString(); txtExistingServiceConnectionNO.Enabled = false; }
                        else { txtExistingServiceConnectionNO.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString() != "") { txtExpanDiverConnectedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString(); txtExpanDiverConnectedLoad.Enabled = false; }
                        else { txtExpanDiverConnectedLoad.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString() != "") { txtExpanDiverContractedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString(); txtExpanDiverContractedLoad.Enabled = false; }
                        else { txtExpanDiverContractedLoad.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDateNew"].ToString() != "") { txtExpanDiverPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDateNew"].ToString(); txtExpanDiverPowerReleaseDate.Enabled = false; }
                        else { txtExpanDiverPowerReleaseDate.Enabled = true; }

                        if (ds.Tables[0].Rows[0]["ExpanDiverServiceConnectionNO"].ToString() != "") { txtExpanDiverServiceConnectionNO.Text = ds.Tables[0].Rows[0]["ExpanDiverServiceConnectionNO"].ToString(); txtExpanDiverServiceConnectionNO.Enabled = false; }
                        else { txtExpanDiverServiceConnectionNO.Enabled = true; }
                        // }

                        //new power unit type bindings
                        if (ds.Tables[0].Rows[0]["PowNewConnectUnitValue"].ToString() != null) // ddlConnectPowUnit 
                        {
                            ddlConnectPowUnit.SelectedValue = ds.Tables[0].Rows[0]["PowNewConnectUnitValue"].ToString();
                            ddlConnectPowUnit.Enabled = false;
                        }
                        else
                        {
                            ddlConnectPowUnit.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["PowNewContractUnitValue"].ToString() != null)  //ddlContractpowerunit
                        {
                            // ddlContractpowerunit.SelectedItem.Text = ds.Tables[0].Rows[0]["PowNewContractUnit"].ToString();
                            ddlContractpowerunit.SelectedValue = ds.Tables[0].Rows[0]["PowNewContractUnitValue"].ToString();
                            ddlContractpowerunit.Enabled = false;
                        }
                        else
                        {
                            ddlContractpowerunit.Enabled = true;
                        }
                        // existing power
                        if (ds.Tables[0].Rows[0]["PowExistConnectUnitValue"].ToString() != null)
                        {
                            ddlExistConnectPowerUnit.SelectedValue = ds.Tables[0].Rows[0]["PowExistConnectUnitValue"].ToString();
                            ddlExistConnectPowerUnit.Enabled = false;
                        }
                        else
                        {
                            ddlExistConnectPowerUnit.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["PowExistContractUnitValue"].ToString() != null)
                        {
                            ddlExsitContractPowerUnit.SelectedValue = ds.Tables[0].Rows[0]["PowExistContractUnitValue"].ToString();
                            ddlExsitContractPowerUnit.Enabled = false;
                        }
                        else
                        {
                            ddlContractpowerunit.Enabled = true;
                        }
                        // diversification power 
                        if (ds.Tables[0].Rows[0]["PowDiversConnectUnitValue"].ToString() != null)
                        {
                            ddlDiverpowConnectUnit.SelectedValue = ds.Tables[0].Rows[0]["PowDiversConnectUnitValue"].ToString();
                            ddlDiverpowConnectUnit.Enabled = false;
                        }
                        else
                        {
                            ddlDiverpowConnectUnit.Enabled = true;
                        }

                        if (ds.Tables[0].Rows[0]["PowDiversContractUnitValue"].ToString() != null)
                        {
                            ddlDiversPowContrUnit.SelectedValue = ds.Tables[0].Rows[0]["PowDiversContractUnitValue"].ToString();
                            ddlDiversPowContrUnit.Enabled = false;
                        }
                        else
                        {
                            ddlDiversPowContrUnit.Enabled = true;
                        }

                        #region Added by Naresh

                        if (ds.Tables[0].Rows[0]["Source"].ToString() != null)
                        {
                            txtSource.Text = ds.Tables[0].Rows[0]["Source"].ToString();
                            txtSource.Enabled = false;
                        }
                        else
                        {
                            txtSource.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["Requirement"].ToString() != null)
                        {
                            txtRequirement.Text = ds.Tables[0].Rows[0]["Requirement"].ToString();
                            txtRequirement.Enabled = false;
                        }
                        else
                        {
                            txtRequirement.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["RateperUnit"].ToString() != null)
                        {
                            txtRateperUnit.Text = ds.Tables[0].Rows[0]["RateperUnit"].ToString();
                            txtRateperUnit.Enabled = false;
                        }
                        else
                        {
                            txtRateperUnit.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["IsSubsidiesIncentives"].ToString() == "True")
                        {
                            rbtnIsSubsidiesIncentives.SelectedValue = "1";
                            //rbtnIsSubsidiesIncentives.Enabled = false;
                        }
                        else
                        {
                            rbtnIsSubsidiesIncentives.Enabled = true;
                        }
                        if (rbtnIsSubsidiesIncentives.SelectedValue == "1")
                        {
                            if (ds.Tables[0].Rows[0]["IsSubsidiesIncentivesAmount"].ToString() != null)
                            {
                                tdIsSubsidiesIncentiveslabel.Visible = true;
                                tdIsSubsidiesIncentives.Visible = true;

                                txtIsSubsidiesIncentivesAmount.Text = ds.Tables[0].Rows[0]["IsSubsidiesIncentivesAmount"].ToString();
                                txtIsSubsidiesIncentivesAmount.Enabled = false;
                            }
                            else
                            {
                                txtIsSubsidiesIncentivesAmount.Enabled = true;
                                tdIsSubsidiesIncentiveslabel.Visible = false;
                                tdIsSubsidiesIncentives.Visible = false;
                            }
                        }
                        if (ds.Tables[0].Rows[0]["NameoftheScheme"].ToString() != null)
                        {
                            txtNameoftheScheme.Text = ds.Tables[0].Rows[0]["NameoftheScheme"].ToString();
                            txtNameoftheScheme.Enabled = false;
                        }
                        else
                        {
                            txtNameoftheScheme.Enabled = true;
                        }
                    }
                    if (ds.Tables[0].Rows[0]["EstablishmentYear"].ToString() != null)
                    {
                        txtEstablishment.Text = ds.Tables[0].Rows[0]["EstablishmentYear"].ToString();
                        txtEstablishment.Enabled = false;
                    }
                    else
                    {
                        txtEstablishment.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["NumberofEmployees"].ToString() != null)
                    {
                        txtNumberofEmployees.Text = ds.Tables[0].Rows[0]["NumberofEmployees"].ToString();
                        txtNumberofEmployees.Enabled = false;
                    }
                    else
                    {
                        txtNumberofEmployees.Enabled = true;
                    }

                    #endregion
                    //---------------------------------------------------------------------------STEP 3 END---------------------------------------------------------------------------------


                    // workers binding

                    if (ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString() != "") { txtstaffMale.Text = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString(); txtstaffMale.Enabled = false; }
                    else { txtstaffMale.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString() != "") { txtfemale.Text = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString(); txtfemale.Enabled = false; }
                    else { txtfemale.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString() != "") { txtsuperfemalecount.Text = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString(); txtsuperfemalecount.Enabled = false; }
                    else { txtsuperfemalecount.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["SupervisoryMale"].ToString() != "") { txtsupermalecount.Text = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString(); txtsupermalecount.Enabled = false; }
                    else { txtsupermalecount.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString() != "") { txtSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString(); txtSkilledWorkersFemale.Enabled = false; }
                    else { txtSkilledWorkersFemale.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["SkilledWorkersMale"].ToString() != "") { txtSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersMale"].ToString(); txtSkilledWorkersMale.Enabled = false; }
                    else { txtSkilledWorkersMale.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["SemiSkilledWorkersFemale"].ToString() != "") { txtSemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersFemale"].ToString(); txtSemiSkilledWorkersFemale.Enabled = false; }
                    else { txtSemiSkilledWorkersFemale.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["SemiSkilledWorkersMale"].ToString() != "") { txtSemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersMale"].ToString(); txtSemiSkilledWorkersMale.Enabled = false; }
                    else { txtSemiSkilledWorkersMale.Enabled = true; }


                    //view4  
                    //  Implementation Steps Taken - Project Finance  

                    //if (ds.Tables[0].Rows[0]["TermLoanApplDateNew"].ToString() != "") { txttermload.Text = ds.Tables[0].Rows[0]["TermLoanApplDateNew"].ToString(); txttermload.Enabled = false; }
                    //else { txttermload.Enabled = true; }
                    //if (ds.Tables[0].Rows[0]["InstitutionName"].ToString() != "") { txtnmofinstitution.Text = ds.Tables[0].Rows[0]["InstitutionName"].ToString(); txtnmofinstitution.Enabled = false; }
                    //else { txtnmofinstitution.Enabled = true; }

                    //if (ds.Tables[0].Rows[0]["TermLoanSancRefNo"].ToString() != "") { txtsactionedloan.Text = ds.Tables[0].Rows[0]["TermLoanSancRefNo"].ToString(); txtsactionedloan.Enabled = false; }
                    //else { txtsactionedloan.Enabled = true; }
                    //if (ds.Tables[0].Rows[0]["TermLoanSanDateNew"].ToString() != "") { txtdatesome.Text = ds.Tables[0].Rows[0]["TermLoanSanDateNew"].ToString(); txtdatesome.Enabled = false; }
                    //else { txtdatesome.Enabled = true; }

                    //  name of assets table 
                    // Land
                    if (ds.Tables[0].Rows[0]["LandApprovedProjectCost"].ToString() != "") { txtLand2.Text = ds.Tables[0].Rows[0]["LandApprovedProjectCost"].ToString(); txtLand2.Enabled = false; }
                    else { txtLand2.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["LandLoanSactioned"].ToString() != "") { txtLand3.Text = ds.Tables[0].Rows[0]["LandLoanSactioned"].ToString(); txtLand3.Enabled = false; }
                    else { txtLand3.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["LandPromotersEquity"].ToString() != "") { txtLand4.Text = ds.Tables[0].Rows[0]["LandPromotersEquity"].ToString(); txtLand4.Enabled = false; }
                    else { txtLand4.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["LandLoanAmountReleased"].ToString() != "") { txtLand5.Text = ds.Tables[0].Rows[0]["LandLoanAmountReleased"].ToString(); txtLand5.Enabled = false; }
                    else { txtLand5.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["LandAssetsValuebyFinInstitution"].ToString() != "") { txtLand6.Text = ds.Tables[0].Rows[0]["LandAssetsValuebyFinInstitution"].ToString(); txtLand6.Enabled = false; }
                    else { txtLand6.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["LandAssetsValuebyCA"].ToString() != "") { txtLand7.Text = ds.Tables[0].Rows[0]["LandAssetsValuebyCA"].ToString(); txtLand7.Enabled = false; }
                    else { txtLand7.Enabled = true; }

                    // Building
                    if (ds.Tables[0].Rows[0]["BuildingApprovedProjectCost"].ToString() != "") { txtBuilding2.Text = ds.Tables[0].Rows[0]["BuildingApprovedProjectCost"].ToString(); txtBuilding2.Enabled = false; }
                    else { txtBuilding2.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["BuildingLoanSactioned"].ToString() != "") { txtBuilding3.Text = ds.Tables[0].Rows[0]["BuildingLoanSactioned"].ToString(); txtBuilding3.Enabled = false; }
                    else { txtBuilding3.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["BuildingPromotersEquity"].ToString() != "") { txtBuilding4.Text = ds.Tables[0].Rows[0]["BuildingPromotersEquity"].ToString(); txtBuilding4.Enabled = false; }
                    else { txtBuilding4.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["BuildingLoanAmountReleased"].ToString() != "") { txtBuilding5.Text = ds.Tables[0].Rows[0]["BuildingLoanAmountReleased"].ToString(); txtBuilding5.Enabled = false; }
                    else { txtBuilding5.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString() != "") { txtBuilding6.Text = ds.Tables[0].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString(); txtBuilding6.Enabled = false; }
                    else { txtBuilding6.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["BuildingAssetsValuebyCA"].ToString() != "") { txtBuilding7.Text = ds.Tables[0].Rows[0]["BuildingAssetsValuebyCA"].ToString(); txtBuilding7.Enabled = false; }
                    else { txtBuilding7.Enabled = true; }

                    //PM
                    if (ds.Tables[0].Rows[0]["PlantMachineryApprovedProjectCost"].ToString() != "") { txtPM2.Text = ds.Tables[0].Rows[0]["PlantMachineryApprovedProjectCost"].ToString(); txtPM2.Enabled = false; }
                    else { txtPM2.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["PlantMachineryLoanSactioned"].ToString() != "") { txtPM3.Text = ds.Tables[0].Rows[0]["PlantMachineryLoanSactioned"].ToString(); txtPM3.Enabled = false; }
                    else { txtPM3.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["PlantMachineryPromotersEquity"].ToString() != "") { txtPM4.Text = ds.Tables[0].Rows[0]["PlantMachineryPromotersEquity"].ToString(); txtPM4.Enabled = false; }
                    else { txtPM4.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["PlantMachineryLoanAmountReleased"].ToString() != "") { txtPM5.Text = ds.Tables[0].Rows[0]["PlantMachineryLoanAmountReleased"].ToString(); txtPM5.Enabled = false; }
                    else { txtPM5.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString() != "") { txtPM6.Text = ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString(); txtPM6.Enabled = false; }
                    else { txtPM6.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString() != "") { txtPM7.Text = ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString(); txtPM7.Enabled = false; }
                    else { txtPM7.Enabled = true; }

                    // Machinery Contingencies
                    if (ds.Tables[0].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString() != "") { txtMCont2.Text = ds.Tables[0].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString(); txtMCont2.Enabled = false; }
                    else { txtMCont2.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["MachineryContingenciesLoanSactioned"].ToString() != "") { txtMCont3.Text = ds.Tables[0].Rows[0]["MachineryContingenciesLoanSactioned"].ToString(); txtMCont3.Enabled = false; }
                    else { txtMCont3.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["MachineryContingenciesPromotersEquity"].ToString() != "") { txtMCont4.Text = ds.Tables[0].Rows[0]["MachineryContingenciesPromotersEquity"].ToString(); txtMCont4.Enabled = false; }
                    else { txtMCont4.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString() != "") { txtMCont5.Text = ds.Tables[0].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString(); txtMCont5.Enabled = false; }
                    else { txtMCont5.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString() != "") { txtMCont6.Text = ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString(); txtMCont6.Enabled = false; }
                    else { txtMCont6.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString() != "") { txtMCont7.Text = ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString(); txtMCont7.Enabled = false; }
                    else { txtMCont7.Enabled = true; }

                    // Erection
                    if (ds.Tables[0].Rows[0]["ErectionApprovedProjectCost"].ToString() != "") { txtErec2.Text = ds.Tables[0].Rows[0]["ErectionApprovedProjectCost"].ToString(); txtErec2.Enabled = false; }
                    else { txtErec2.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["ErectionLoanSactioned"].ToString() != "") { txtErec3.Text = ds.Tables[0].Rows[0]["ErectionLoanSactioned"].ToString(); txtErec3.Enabled = false; }
                    else { txtErec3.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["ErectionPromotersEquity"].ToString() != "") { txtErec4.Text = ds.Tables[0].Rows[0]["ErectionPromotersEquity"].ToString(); txtErec4.Enabled = false; }
                    else { txtErec4.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["ErectionLoanAmountReleased"].ToString() != "") { txtErec5.Text = ds.Tables[0].Rows[0]["ErectionLoanAmountReleased"].ToString(); txtErec5.Enabled = false; }
                    else { txtErec5.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString() != "") { txtErec6.Text = ds.Tables[0].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString(); txtErec6.Enabled = false; }
                    else { txtErec6.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["ErectionAssetsValuebyCA"].ToString() != "") { txtErec7.Text = ds.Tables[0].Rows[0]["ErectionAssetsValuebyCA"].ToString(); txtErec7.Enabled = false; }
                    else { txtErec7.Enabled = true; }

                    // Technical feasibility
                    if (ds.Tables[0].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString() != "") { txtTFS2.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString(); txtTFS2.Enabled = false; }
                    else { txtTFS2.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString() != "") { txtTFS3.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString(); txtTFS3.Enabled = false; }
                    else { txtTFS3.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString() != "") { txtTFS4.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString(); txtTFS4.Enabled = false; }
                    else { txtTFS4.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString() != "") { txtTFS5.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString(); txtTFS5.Enabled = false; }
                    else { txtTFS5.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString() != "") { txtTFS6.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString(); txtTFS6.Enabled = false; }
                    else { txtTFS6.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString() != "") { txtTFS7.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString(); txtTFS7.Enabled = false; }
                    else { txtTFS7.Enabled = true; }

                    // Working Capital
                    if (ds.Tables[0].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString() != "") { txtWC2.Text = ds.Tables[0].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString(); txtWC2.Enabled = false; }
                    else { txtWC2.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["WorkingCapitalLoanSactioned"].ToString() != "") { txtWC3.Text = ds.Tables[0].Rows[0]["WorkingCapitalLoanSactioned"].ToString(); txtWC3.Enabled = false; }
                    else { txtWC3.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["WorkingCapitalPromotersEquity"].ToString() != "") { txtWC4.Text = ds.Tables[0].Rows[0]["WorkingCapitalPromotersEquity"].ToString(); txtWC4.Enabled = false; }
                    else { txtWC4.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString() != "") { txtWC5.Text = ds.Tables[0].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString(); txtWC5.Enabled = false; }
                    else { txtWC5.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString() != "") { txtWC6.Text = ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString(); txtWC6.Enabled = false; }
                    else { txtWC6.Enabled = true; }

                    if (ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString() != "") { txtWC7.Text = ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString(); txtWC7.Enabled = false; }
                    else { txtWC7.Enabled = true; }
                    // end of Name of Assets

                    if (ds.Tables[0].Rows[0]["isSecondHandMachVal"].ToString() != "")
                    {
                        // ddlHvuInstalledScndhndMech.SelectedItem.Text = ds.Tables[0].Rows[0]["isSecondHandMachVal"].ToString();
                        ddlHvuInstalledScndhndMech.SelectedValue = ds.Tables[0].Rows[0]["isSecondHandMachValValue"].ToString();
                        ddlHvuInstalledScndhndMech.Enabled = false;
                    }
                    else
                    {
                        ddlHvuInstalledScndhndMech.Enabled = false;
                    }

                    if (ddlHvuInstalledScndhndMech.SelectedValue == "1")
                    {
                        ddlHvuInstalledScndhndMech.Enabled = false;
                        trSecondhandmachinery.Visible = true;

                        if (ds.Tables[0].Rows[0]["SecondHandMachVal"].ToString() != "")
                        {
                            txtsecondhndmachine.Text = ds.Tables[0].Rows[0]["SecondHandMachVal"].ToString();
                            txtsecondhndmachine.Enabled = false;
                        }
                        else
                        {
                            txtsecondhndmachine.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["NewMachVal"].ToString() != "")
                        {
                            txtnewmachine.Text = ds.Tables[0].Rows[0]["NewMachVal"].ToString();
                            txtnewmachine.Enabled = false;
                        }
                        else
                        {
                            txtnewmachine.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["Newand2ndlMachTotVal"].ToString() != "")
                        {
                            txtTotalvalue12.Text = ds.Tables[0].Rows[0]["Newand2ndlMachTotVal"].ToString();
                            txtTotalvalue12.Enabled = false;
                        }
                        else
                        {
                            txtTotalvalue12.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["PercentageSHMValinTotMachVal"].ToString() != "")
                        {
                            txtpercentage12.Text = ds.Tables[0].Rows[0]["PercentageSHMValinTotMachVal"].ToString();
                            txtpercentage12.Enabled = false;
                        }
                        else
                        {
                            txtpercentage12.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["MachValPrchasedfromAPIDCorAPSFCBank"].ToString() != "")
                        {
                            txtmachinepucr.Text = ds.Tables[0].Rows[0]["MachValPrchasedfromAPIDCorAPSFCBank"].ToString();
                            txtmachinepucr.Enabled = false;
                        }
                        else
                        {
                            txtmachinepucr.Enabled = true;
                        }
                        if (ds.Tables[0].Rows[0]["TotalMachVal"].ToString() != "")
                        {
                            txttotal25.Text = ds.Tables[0].Rows[0]["TotalMachVal"].ToString();
                            txttotal25.Enabled = false;
                        }
                        else
                        {
                            txttotal25.Enabled = true;
                        }
                    }
                    else
                    {
                        trSecondhandmachinery.Visible = false;
                        ddlHvuInstalledScndhndMech.Enabled = true;
                    }

                    // Registration with Commercial taxes Department Registration
                    if (ds.Tables[0].Rows[0]["CSTNo"].ToString() != "")
                    {
                        txtcstno.Text = ds.Tables[0].Rows[0]["CSTNo"].ToString();
                        txtcstno.Enabled = false;
                    }
                    else
                    {
                        txtcstno.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["VATNo"].ToString() != "")
                    {
                        txtvatno.Text = ds.Tables[0].Rows[0]["VATNo"].ToString();
                        txtvatno.Enabled = false;
                    }
                    else
                    {
                        txtvatno.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["CSTRegAuthority"].ToString() != "")
                    {
                        txtCSTRegAuthority.Text = ds.Tables[0].Rows[0]["CSTRegAuthority"].ToString();
                        txtCSTRegAuthority.Enabled = false;
                    }
                    else
                    {
                        txtCSTRegAuthority.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["CSTRegAuthAddress"].ToString() != "")
                    {
                        txtCSTRegAuthAddress.Text = ds.Tables[0].Rows[0]["CSTRegAuthAddress"].ToString();
                        txtCSTRegAuthAddress.Enabled = false;
                    }
                    else
                    {
                        txtCSTRegAuthAddress.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["CSTRegDate"].ToString() != "")
                    {
                        txtCSTRegDate.Text = ds.Tables[0].Rows[0]["CSTRegDate"].ToString();
                        txtCSTRegDate.Enabled = false;
                    }
                    else
                    {
                        txtCSTRegDate.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["EMPartNo"].ToString() != "")
                    {
                        txtEmpart.Text = ds.Tables[0].Rows[0]["EMPartNo"].ToString();
                        txtEmpart.Enabled = false;
                    }
                    else
                    {
                        txtEmpart.Enabled = true;
                    }

                    // Bank details binding
                    if (ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                    {
                        ddlBank.SelectedValue = ds.Tables[0].Rows[0]["BankName"].ToString();
                        ddlBank.Enabled = false;
                    }
                    else
                    {
                        ddlBank.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["BranchName"].ToString() != "")
                    {
                        txtBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        txtBranchName.Enabled = false;
                    }
                    else
                    {
                        txtBranchName.Enabled = false;
                    }
                    if (ds.Tables[0].Rows[0]["AccNo"].ToString() != "")
                    {
                        txtAccNumber.Text = ds.Tables[0].Rows[0]["AccNo"].ToString();
                        txtAccNumber.Enabled = false;
                    }
                    else
                    {
                        txtAccNumber.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["IFSCCode"].ToString() != "")
                    {
                        txtIfscCode.Text = ds.Tables[0].Rows[0]["IFSCCode"].ToString();
                        txtIfscCode.Enabled = false;
                    }
                    else
                    {
                        txtIfscCode.Enabled = true;
                    }
                    if (ds.Tables[0].Rows[0]["WhetherPower"].ToString() != "")
                    {
                        ddlPower.SelectedItem.Text = ds.Tables[0].Rows[0]["WhetherPower"].ToString();
                        ddlPower.Enabled = false;
                    }
                    else
                    {
                        ddlPower.Enabled = true;
                    }
                    if (ddlPower.SelectedItem.Text == "YES")
                    {
                        TxtRequesttoDepartment.Visible = true;
                        if (ds.Tables[0].Rows[0]["RequesttoDept"].ToString() != "")
                        {
                            TxtRequesttoDepartment.Text = ds.Tables[0].Rows[0]["RequesttoDept"].ToString();
                            TxtRequesttoDepartment.Enabled = false;
                        }
                        else
                        {
                            TxtRequesttoDepartment.Enabled = false;
                        }

                    }
                    else
                    {
                        TxtRequesttoDepartment.Visible = false;
                    }

                    //adde newly    

                    Session["Incentive_DateOfCommencement"] = txtDateofCommencement.Text;
                    Session["Incentive_isVehicle"] = Convert.ToBoolean(Convert.ToInt32(rblVeh.SelectedValue));
                    Session["Incentive_GHMC"] = Convert.ToBoolean(Convert.ToInt32(rblGHMC.SelectedValue));
                    Session["Incentive_Caste"] = ds.Tables[0].Rows[0]["caste"].ToString();
                    Session["Incentive_Sector"] = rblSector.SelectedValue;
                    Session["Incentive_Category"] = ds.Tables[0].Rows[0]["Category"].ToString();
                    Session["Incentive_PHC"] = (cbDiffAbled.Checked == true ? "0" : "1");
                    Session["IndustryStatus"] = ddlIndustryStatus.SelectedValue;
                    // objvo.IsDifferentlyAbled = Convert.ToBoolean(objvo.IsDifferentlyAbled.));

                    // end

                    //BtnSave.Enabled = false;
                    //BtnClear.Enabled = false;
                    //btnNext.Visible = true;

                    // added on 18.06.2017


                    if (ds.Tables[0].Rows[0]["GSTNO"].ToString() != null)
                    {
                        txtGSTNo.Text = ds.Tables[0].Rows[0]["GSTNO"].ToString();
                        txtGSTNo.Enabled = false;
                    }
                    else
                    {
                        txtGSTNo.Enabled = true;
                    }

                    // added newly
                    if (ds.Tables[0].Rows[0]["GSTDateNew"].ToString() != null)
                    {
                        txtGSTDate.Text = ds.Tables[0].Rows[0]["GSTDateNew"].ToString();
                        txtGSTDate.Enabled = false;
                    }
                    else
                    {
                        txtGSTDate.Enabled = true;
                    }

                    //if (ds.Tables[0].Rows[0]["IndusExpanType"].ToString() != null && ds.Tables[0].Rows[0]["IndusExpanType"].ToString() != "-- Select --" && ds.Tables[0].Rows[0]["IndusExpanType"].ToString() != "")
                    //{
                    //    ddlInustryExpansionType.SelectedItem.Text = ds.Tables[0].Rows[0]["IndusExpanType"].ToString();
                    //    ddlInustryExpansionType.Enabled = false;
                    //}
                    //else
                    //{
                    //    ddlInustryExpansionType.Enabled = true;
                    //}








                    if (ds.Tables[0].Rows[0]["IsTermLoanAvailed"].ToString() != null && ds.Tables[0].Rows[0]["IsTermLoanAvailed"].ToString() != "")
                    {
                        ddlIsTermLoanAvailed.SelectedValue = ds.Tables[0].Rows[0]["IsTermLoanAvailed"].ToString();
                        ddlIsTermLoanAvailed_SelectedIndexChanged(this, EventArgs.Empty);
                    }

                    if (ds.Tables[0].Rows[0]["BankAccountName"].ToString() != null && ds.Tables[0].Rows[0]["BankAccountName"].ToString() != "")
                    {
                        txtAccountName.Text = ds.Tables[0].Rows[0]["BankAccountName"].ToString();
                    }

                    BindBankAccountType();
                    if (ds.Tables[0].Rows[0]["BankAccType"].ToString() != null && ds.Tables[0].Rows[0]["BankAccType"].ToString() != "")
                    {
                        ddlAccountType.SelectedValue = ds.Tables[0].Rows[0]["BankAccType"].ToString();

                    }

                    objvo.Category = ds.Tables[0].Rows[0]["Category"].ToString();
                    if (objvo.Category != "")
                    {
                        Session["Incentive_Category"] = Convert.ToInt32(objvo.Category);  // ok 
                    }

                    #region TTAP
                    // ----------------------------------------Added For TTAP-------Binding-----
                    if (ds.Tables[0].Rows[0]["DateOfIncorporation"].ToString() != null && ds.Tables[0].Rows[0]["DateOfIncorporation"].ToString() != "")
                    {
                        txtDateOfIncorporation.Text = ds.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString() != null && ds.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString() != "")
                    {
                        txtIncorpRegistranNumber.Text = ds.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["TextileProcessType"].ToString() != null && ds.Tables[0].Rows[0]["TextileProcessType"].ToString() != "")
                    {
                        ddlTextileProcessType.SelectedValue = ds.Tables[0].Rows[0]["TextileProcessType"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["CountryOrigin"].ToString() != null && ds.Tables[0].Rows[0]["CountryOrigin"].ToString() != "")
                    {
                        txtCountryOrigin.Text = ds.Tables[0].Rows[0]["CountryOrigin"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["YearsOfExpinTexttile"].ToString() != null && ds.Tables[0].Rows[0]["YearsOfExpinTexttile"].ToString() != "")
                    {
                        txtYearsOfExpinTexttile.Text = ds.Tables[0].Rows[0]["YearsOfExpinTexttile"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EducationalQual"].ToString() != null && ds.Tables[0].Rows[0]["EducationalQual"].ToString() != "")
                    {
                        txtEducationalQual.Text = ds.Tables[0].Rows[0]["EducationalQual"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Percentge_FixedCapitalInvestment"].ToString() != null && ds.Tables[0].Rows[0]["Percentge_FixedCapitalInvestment"].ToString() != "")
                    {
                        txtPercentge_FixedCapitalInvestment.Text = ds.Tables[0].Rows[0]["Percentge_FixedCapitalInvestment"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Nature_Industry"].ToString() != null && ds.Tables[0].Rows[0]["Nature_Industry"].ToString() != "")
                    {
                        txtNature_Industry.Text = ds.Tables[0].Rows[0]["Nature_Industry"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["InstalledCapacityperAnnum"].ToString() != null && ds.Tables[0].Rows[0]["InstalledCapacityperAnnum"].ToString() != "")
                    {
                        txtInstalledCapacityperAnnum.Text = ds.Tables[0].Rows[0]["InstalledCapacityperAnnum"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["WhetherAllotedByGovt"].ToString() != null && ds.Tables[0].Rows[0]["WhetherAllotedByGovt"].ToString() != "")
                    {
                        rdWhetherAllotedByGovt.Text = ds.Tables[0].Rows[0]["WhetherAllotedByGovt"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["CategoryTTAP"].ToString() != null && ds.Tables[0].Rows[0]["CategoryTTAP"].ToString() != "")
                    {
                        ddlCategoryTTAP.SelectedValue = ds.Tables[0].Rows[0]["CategoryTTAP"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Products_Manufactured"].ToString() != null && ds.Tables[0].Rows[0]["Products_Manufactured"].ToString() != "")
                    {
                        txtProducts_Manufactured.Text = ds.Tables[0].Rows[0]["Products_Manufactured"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["NO_OtherEstablishments"].ToString() != null && ds.Tables[0].Rows[0]["NO_OtherEstablishments"].ToString() != "")
                    {
                        txtNO_OtherEstablishments.Text = ds.Tables[0].Rows[0]["NO_OtherEstablishments"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Authorized_MobileNo"].ToString() != null && ds.Tables[0].Rows[0]["Authorized_MobileNo"].ToString() != "")
                    {
                        txtAuthorized_MobileNo.Text = ds.Tables[0].Rows[0]["Authorized_MobileNo"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Authorized_EmailId"].ToString() != null && ds.Tables[0].Rows[0]["Authorized_EmailId"].ToString() != "")
                    {
                        txtAuthorized_EmailId.Text = ds.Tables[0].Rows[0]["Authorized_EmailId"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Authorized_PAN_NO"].ToString() != null && ds.Tables[0].Rows[0]["Authorized_PAN_NO"].ToString() != "")
                    {
                        txtAuthorized_PAN_NO.Text = ds.Tables[0].Rows[0]["Authorized_PAN_NO"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Authorized_CorresponAdderess"].ToString() != null && ds.Tables[0].Rows[0]["Authorized_CorresponAdderess"].ToString() != "")
                    {
                        txtAuthorized_CorresponAdderess.Text = ds.Tables[0].Rows[0]["Authorized_CorresponAdderess"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PromotersEquity_MF"].ToString() != null && ds.Tables[0].Rows[0]["PromotersEquity_MF"].ToString() != "")
                    {
                        txtPromotersEquity_MF.Text = ds.Tables[0].Rows[0]["PromotersEquity_MF"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["InstitutionEquity_MF"].ToString() != null && ds.Tables[0].Rows[0]["InstitutionEquity_MF"].ToString() != "")
                    {
                        txtInstitutionEquity_MF.Text = ds.Tables[0].Rows[0]["InstitutionEquity_MF"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["TermsLoans_MF"].ToString() != null && ds.Tables[0].Rows[0]["TermsLoans_MF"].ToString() != "")
                    {
                        txtTermsLoans_MF.Text = ds.Tables[0].Rows[0]["TermsLoans_MF"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["Others_MF"].ToString() != null && ds.Tables[0].Rows[0]["Others_MF"].ToString() != "")
                    {
                        txtOthers_MF.Text = ds.Tables[0].Rows[0]["Others_MF"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["SeedCapital_MF"].ToString() != null && ds.Tables[0].Rows[0]["SeedCapital_MF"].ToString() != "")
                    {
                        txtSeedCapital_MF.Text = ds.Tables[0].Rows[0]["SeedCapital_MF"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["SubsidyGrantsAgencies_MF"].ToString() != null && ds.Tables[0].Rows[0]["SubsidyGrantsAgencies_MF"].ToString() != "")
                    {
                        txtSubsidyGrantsAgencies_MF.Text = ds.Tables[0].Rows[0]["SubsidyGrantsAgencies_MF"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["IncentivesAvaild_StateCentrlGovt"].ToString() != null && ds.Tables[0].Rows[0]["IncentivesAvaild_StateCentrlGovt"].ToString() != "")
                    {
                        ddlIncentivesAvaild_StateCentrlGovt.SelectedValue = ds.Tables[0].Rows[0]["IncentivesAvaild_StateCentrlGovt"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["NameOfScheme_Agency"].ToString() != null && ds.Tables[0].Rows[0]["NameOfScheme_Agency"].ToString() != "")
                    {
                        txtNameOfScheme_Agency.Text = ds.Tables[0].Rows[0]["NameOfScheme_Agency"].ToString();
                    }


                    if (ds.Tables[0].Rows[0]["TurnOver_1stYear"].ToString() != null && ds.Tables[0].Rows[0]["TurnOver_1stYear"].ToString() != "")
                    {
                        txtTurnOver_1stYear.Text = ds.Tables[0].Rows[0]["TurnOver_1stYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["TurnOver_2ndYear"].ToString() != null && ds.Tables[0].Rows[0]["TurnOver_2ndYear"].ToString() != "")
                    {
                        txtTurnOver_2ndYear.Text = ds.Tables[0].Rows[0]["TurnOver_2ndYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["TurnOver_3rdYear"].ToString() != null && ds.Tables[0].Rows[0]["TurnOver_3rdYear"].ToString() != "")
                    {
                        txtTurnOver_3rdYear.Text = ds.Tables[0].Rows[0]["TurnOver_3rdYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EBITDA_1stYear"].ToString() != null && ds.Tables[0].Rows[0]["EBITDA_1stYear"].ToString() != "")
                    {
                        txtEBITDA_1stYear.Text = ds.Tables[0].Rows[0]["EBITDA_1stYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EBITDA_2ndYear"].ToString() != null && ds.Tables[0].Rows[0]["EBITDA_2ndYear"].ToString() != "")
                    {
                        txtEBITDA_2ndYear.Text = ds.Tables[0].Rows[0]["EBITDA_2ndYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EBITDA_3rdYear"].ToString() != null && ds.Tables[0].Rows[0]["EBITDA_3rdYear"].ToString() != "")
                    {
                        txtEBITDA_3rdYear.Text = ds.Tables[0].Rows[0]["EBITDA_3rdYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Networth_1stYear"].ToString() != null && ds.Tables[0].Rows[0]["Networth_1stYear"].ToString() != "")
                    {
                        txtNetworth_1stYear.Text = ds.Tables[0].Rows[0]["Networth_1stYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Networth_2ndYear"].ToString() != null && ds.Tables[0].Rows[0]["Networth_2ndYear"].ToString() != "")
                    {
                        txtNetworth_2ndYear.Text = ds.Tables[0].Rows[0]["Networth_2ndYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Networth_3rdYear"].ToString() != null && ds.Tables[0].Rows[0]["Networth_3rdYear"].ToString() != "")
                    {
                        txtNetworth_3rdYear.Text = ds.Tables[0].Rows[0]["Networth_3rdYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["ReservesSurplus_1stYear"].ToString() != null && ds.Tables[0].Rows[0]["ReservesSurplus_1stYear"].ToString() != "")
                    {
                        txtReservesSurplus_1stYear.Text = ds.Tables[0].Rows[0]["ReservesSurplus_1stYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["ReservesSurplus_2ndYear"].ToString() != null && ds.Tables[0].Rows[0]["ReservesSurplus_2ndYear"].ToString() != "")
                    {
                        txtReservesSurplus_2ndYear.Text = ds.Tables[0].Rows[0]["ReservesSurplus_2ndYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["ReservesSurplus_3rdYear"].ToString() != null && ds.Tables[0].Rows[0]["ReservesSurplus_3rdYear"].ToString() != "")
                    {
                        txtReservesSurplus_3rdYear.Text = ds.Tables[0].Rows[0]["ReservesSurplus_3rdYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Share_Capital_1stYear"].ToString() != null && ds.Tables[0].Rows[0]["Share_Capital_1stYear"].ToString() != "")
                    {
                        txtShare_Capital_1stYear.Text = ds.Tables[0].Rows[0]["Share_Capital_1stYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Share_Capital_2ndYear"].ToString() != null && ds.Tables[0].Rows[0]["Share_Capital_2ndYear"].ToString() != "")
                    {
                        txtShare_Capital_2ndYear.Text = ds.Tables[0].Rows[0]["Share_Capital_2ndYear"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Share_Capital_3rdYear"].ToString() != null && ds.Tables[0].Rows[0]["Share_Capital_3rdYear"].ToString() != "")
                    {
                        txtShare_Capital_3rdYear.Text = ds.Tables[0].Rows[0]["Share_Capital_3rdYear"].ToString();
                    }

                    #endregion
                    //END-------------------------- -

                    Session["applicationStatus"] = ds.Tables[0].Rows[0]["intStatusid"].ToString();
                    if (ds.Tables[0].Rows[0]["intStatusid"].ToString() == null || ds.Tables[0].Rows[0]["intStatusid"].ToString() == "")
                    {
                        EnableDisableForm(Page.Controls, true);
                        UpdateComonFormdetails(ds);

                    }
                    else
                    {
                        string applicationStatus = "";
                        applicationStatus = ds.Tables[0].Rows[0]["intStatusid"].ToString();

                        if (Convert.ToInt32(applicationStatus) >= 2)  //3  changed on 17.11.2017 
                        {
                            //EnableDisableForm(Page.Controls, false);
                            // DontUpdateComonFormdetails(ds);
                            UpdateComonFormdetails(ds);
                            ddlIndustrialParkName.Enabled = true;
                            ddlContractpowerunit.Enabled = true;
                            ddlConnectPowUnit.Enabled = true;
                        }
                        else
                        {
                            EnableDisableForm(Page.Controls, true);
                            UpdateComonFormdetails(ds);
                            ddlIndustrialParkName.Enabled = true;
                            ddlContractpowerunit.Enabled = true;
                            ddlConnectPowUnit.Enabled = true;
                        }
                    }

                    return 2;
                }
                else
                {
                    BtnSave.Enabled = true;
                    BtnClear.Enabled = true;

                    if (ddlIndustryStatus.SelectedItem.Text.ToUpper() == "NEW INDUSTRY")
                    {
                        trNewIndustry.Visible = true;
                        trexpansionnew.Visible = false;
                    }
                    else
                    {
                        trexpansionnew.Visible = false;
                    }
                    // trexpansion.Visible = true;

                    // Term Loan details TAB
                    trTermLoanLine1.Visible = true;
                    trTermLoanLine2.Visible = true;
                    trTermLoanLine3.Visible = true;
                    trTermLoanLine4.Visible = true;
                    trTermLoanLine5.Visible = true;
                    trTermLoanLine6.Visible = true;

                    return 3;
                }
                //   return 3;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Deepak
        public void Getmandalsunit()
        {
            if (ddlUnitDIst.SelectedIndex == 0)
            {
                ddlUnitMandal.Items.Clear();
                AddSelect(ddlUnitMandal);
                //ddlUnitMandal.Items.Insert(0, "--Mandal--");
                //ChkWater_reg_from.Items.Clear();
                //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlUnitMandal.Items.Clear();

                // added newly for testing only 
                //if (ddlUnitDIst.SelectedValue == "Medchal")
                //{
                //    ddlUnitDIst.SelectedValue = "20";
                //}
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlUnitDIst.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlUnitMandal.DataSource = dsm.Tables[0];
                    ddlUnitMandal.DataValueField = "Mandal_Id";
                    ddlUnitMandal.DataTextField = "Manda_lName";
                    ddlUnitMandal.DataBind();
                    AddSelect(ddlUnitMandal);
                    //ddlUnitMandal.Items.Insert(0, "--Mandal--");
                }
                else
                {
                    ddlUnitMandal.Items.Clear();
                    //ddlUnitMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlUnitMandal);
                }
            }
        }
        public void Getvillagesunit()
        {
            // if (ddlUnitMandal.SelectedIndex == 0)
            if (ddlUnitMandal.SelectedItem.Text == "--Mandal--")    // modified ob 09.07.2017
            {

                ddlVillageunit.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddlVillageunit);
            }
            else
            {
                ddlVillageunit.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlUnitMandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlVillageunit.DataSource = dsv.Tables[0];
                    ddlVillageunit.DataValueField = "Village_Id";
                    ddlVillageunit.DataTextField = "Village_Name";
                    ddlVillageunit.DataBind();
                    AddSelect(ddlVillageunit);
                    //ddlVillageunit.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlVillageunit.Items.Clear();
                    //ddlVillageunit.Items.Insert(0, "--Village--");
                    AddSelect(ddlVillageunit);
                }
            }
        }
        public void Getmandalsoffc()
        {
            if (ddlOffcDIst.SelectedIndex == 0)
            {
                ddlOffcMandal.Items.Clear();
                AddSelect(ddlOffcMandal);
            }
            else
            {
                ddlOffcMandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Gen.GetMandals(ddlOffcDIst.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlOffcMandal.DataSource = dsm.Tables[0];
                    ddlOffcMandal.DataValueField = "Mandal_Id";
                    ddlOffcMandal.DataTextField = "Manda_lName";
                    ddlOffcMandal.DataBind();
                    //ddlOffcMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlOffcMandal);
                }
                else
                {
                    ddlOffcMandal.Items.Clear();
                    // ddlOffcMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlOffcMandal);
                }
            }
        }
        public void Getvillagesoffc()
        {
            if (ddlOffcMandal.SelectedIndex == 0)
            {
                ddlOffcVil.Items.Clear();
                //ddlOffcMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlOffcVil);
            }
            else
            {
                ddlOffcVil.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Gen.GetVillages(ddlOffcMandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlOffcVil.DataSource = dsv.Tables[0];
                    ddlOffcVil.DataValueField = "Village_Id";
                    ddlOffcVil.DataTextField = "Village_Name";
                    ddlOffcVil.DataBind();
                    //ddlOffcVil.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlOffcVil.Items.Clear();
                    //ddlOffcVil.Items.Insert(0, "--Village--");
                    AddSelect(ddlOffcVil);
                }
            }
        }
        void getstatesUnit()
        {
            DataSet ds = new DataSet();
            ds = Gen.getStates();

            ddlUnitstate.DataSource = ds.Tables[0];
            ddlUnitstate.DataTextField = "State_Name";
            ddlUnitstate.DataValueField = "State_id";
            ddlUnitstate.DataBind();
            // ddlUnitstate.Items.Insert(0, "--Select--");
            AddSelect(ddlUnitstate);
        }
        void getstatesOffc()
        {
            DataSet ds = new DataSet();
            ds = Gen.getStates();

            ddloffcstate.DataSource = ds.Tables[0];
            ddloffcstate.DataTextField = "State_Name";
            ddloffcstate.DataValueField = "State_id";
            ddloffcstate.DataBind();
            //ddloffcstate.Items.Insert(0, "--Select--");
            AddSelect(ddloffcstate);
        }
        protected void getdistrictsUnit()
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.GetDistrictsbystate(ddlUnitstate.SelectedValue.ToString());
            ddlUnitDIst.DataSource = dsnew.Tables[0];
            ddlUnitDIst.DataTextField = "District_Name";
            ddlUnitDIst.DataValueField = "District_Id";
            ddlUnitDIst.DataBind();
            // ddlUnitDIst.Items.Insert(0, "--Select--");
            AddSelect(ddlUnitDIst);

        }
        protected void getdistrictsOffc()
        {
            DataSet dsnew = new DataSet();

            dsnew = Gen.GetDistrictsbystate(ddlOffcDIst.SelectedValue.ToString());
            ddlOffcDIst.DataSource = dsnew.Tables[0];
            ddlOffcDIst.DataTextField = "District_Name";
            ddlOffcDIst.DataValueField = "District_Id";
            ddlOffcDIst.DataBind();
            //ddlOffcDIst.Items.Insert(0, "--Select--");
            AddSelect(ddlOffcDIst);
        }
        protected void ddlUnitstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitstate.SelectedValue.ToString() != "--Select--")
                {
                    getdistrictsUnit();

                    ddlUnitDIst.Visible = true;
                    ddlUnitMandal.Visible = true;
                    ddlVillageunit.Visible = true;
                }
                else
                {
                    ddlUnitstate.Items.Clear();
                    ddlUnitstate.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddloffcstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddloffcstate.SelectedValue.ToString() != "--Select--")
                {
                    if (ddloffcstate.SelectedValue.ToString() == "31")
                    {
                        //getdistrictsOffc();
                        BindDistricts1();

                        txtofficedist.Visible = false;
                        txtoffcicemandal.Visible = false;
                        txtofficeviiage.Visible = false;

                        ddlOffcDIst.Visible = true;
                        ddlOffcMandal.Visible = true;
                        ddlOffcVil.Visible = true;
                    }
                    else
                    {
                        txtofficedist.Visible = true;
                        txtoffcicemandal.Visible = true;
                        txtofficeviiage.Visible = true;

                        ddlOffcDIst.Visible = false;
                        ddlOffcMandal.Visible = false;
                        ddlOffcVil.Visible = false;
                    }
                }
                else
                {
                    ddlUnitstate.Items.Clear();
                    //  ddlUnitstate.Items.Insert(0, "--Select--");
                    AddSelect(ddlUnitstate);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlquantityin.SelectedValue.ToString() == "Others")
            {
                txtunit.Visible = true;
                ddlquantityin.Visible = true;
            }
            else
            {
                txtunit.Visible = false;
                ddlquantityin.Visible = true;
            }

        }
        protected void ddlquantityinExpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlquantityinExpan.SelectedValue.ToString() == "Others")
            {
                txtunitExpan.Visible = true;
                ddlquantityinExpan.Visible = true;
            }
            else
            {
                txtunitExpan.Visible = false;
                ddlquantityinExpan.Visible = true;
            }

        }
        // End




        // added newly for enable the all controls on 18.06.2017
        public void EnableDisableForm(ControlCollection ctrls, bool status)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = status;

                // if (ctrl is Button)      // commented to enable the Button Controls
                //    ((Button)ctrl).Enabled = status;

                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).Enabled = status;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Enabled = status;
                else if (ctrl is RadioButton)
                    ((RadioButton)ctrl).Enabled = status;

                else if (ctrl is CheckBoxList)
                    ((CheckBoxList)ctrl).Enabled = status;

                EnableDisableForm(ctrl.Controls, status);

            }
        }



        protected void ddlVillageunit_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                // rblGHMC.Items.Clear();
                if (ddlVillageunit.SelectedIndex != 0)
                {
                    DataSet dsss = new DataSet();
                    DataSet dscess = Gen.GetUnderLimitsOfVillage(ddlVillageunit.SelectedValue);
                    string Muncipal_Flag = "", GHMC_FLG = "", HMR_FLG = "", HMDA_FLG = "", KUDA_FLAG = "", DTCPFLAG = "", YTDA = "", Hmwssbflg = "";

                    if (dscess.Tables[0].Rows.Count > 0)
                    {
                        Muncipal_Flag = dscess.Tables[0].Rows[0]["Muncipal_Flag"].ToString();
                        GHMC_FLG = dscess.Tables[0].Rows[0]["GHMC_FLG"].ToString();
                        HMR_FLG = dscess.Tables[0].Rows[0]["HMR_FLG"].ToString();
                        HMDA_FLG = dscess.Tables[0].Rows[0]["HMDA_FLG"].ToString();
                        KUDA_FLAG = dscess.Tables[0].Rows[0]["KUDA_FLAG"].ToString();
                        DTCPFLAG = dscess.Tables[0].Rows[0]["DTCPFLAG"].ToString();
                        YTDA = dscess.Tables[0].Rows[0]["YTD"].ToString();
                        Hmwssbflg = dscess.Tables[0].Rows[0]["Hmwssb_Flg"].ToString();

                        if ((GHMC_FLG != null && GHMC_FLG == "Y") || (Muncipal_Flag != null && Muncipal_Flag == "Y"))
                        {
                            rblGHMC.SelectedValue = "1";
                            rblGHMC.Enabled = false;
                        }
                        else
                        {
                            rblGHMC.SelectedValue = "0";
                            rblGHMC.Enabled = false;
                        }
                        rblGHMC_SelectedIndexChanged(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }

        }


        protected void ddlLoc_of_unit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlIspowApplicable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "NO")
            {
                trpower.Visible = false;
                tblpower1.Visible = false;
                tblpower2.Visible = false;
            }
            if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
            {
                trpower.Visible = true;
                if (ddlIndustryStatus.SelectedItem.ToString() == "New Industry")
                {
                    tblpower1.Visible = true;
                    tblpower2.Visible = false;
                }
                if (ddlIndustryStatus.SelectedItem.ToString() == "Expansion" || ddlIndustryStatus.SelectedItem.ToString() == "Diversification")
                {
                    tblpower1.Visible = false;
                    tblpower2.Visible = true;
                }

            }
        }
        protected void btnTermloanAdd_Click(object sender, EventArgs e)
        {

            int valid = 0;
            try
            {
                if (ddlTermLoanNo.SelectedValue == "0")
                {
                    lblmsg0.Text = "Please Select Term Loan No" + "<br/>";
                    Failure.Visible = true;
                    ddlTermLoanNo.Focus();
                    valid = 1;
                }
                if (txttermload.Text == "" || txttermload == null)
                {
                    lblmsg0.Text = "Please enter term loan application date " + "<br/>";
                    Failure.Visible = true;
                    txttermload.Focus();
                    valid = 1;
                }
                if (txtnmofinstitution.Text == "" || txtnmofinstitution.Text == null)
                {
                    lblmsg0.Text = "Please enter name of the institution" + "<br/>";
                    Failure.Visible = true;
                    txtnmofinstitution.Focus();
                    valid = 1;
                }

                if (txtdatesome.Text == "" || txtdatesome.Text == null)
                {
                    lblmsg0.Text = "Please enter term loan sanctioned date" + "<br/>";
                    Failure.Visible = true;
                    txtdatesome.Focus();
                    valid = 1;
                }
                if (txtsactionedloan.Text == "" || txtsactionedloan.Text == null)
                {
                    lblmsg0.Text = "Please enter term loan sanctioned reference no" + "<br/>";
                    Failure.Visible = true;
                    txtsactionedloan.Focus();
                    valid = 1;
                }
                if (txtTermLoanReleasedDate.Text == "" && txtTermLoanReleasedDate.Text == null)
                {
                    lblmsg0.Text = "Please enter term loan Released date" + "<br/>";
                    Failure.Visible = true;
                    txtTermLoanReleasedDate.Focus();
                    valid = 1;
                }
                if (valid == 0)
                {
                    string[] Termlanapplndate = txttermload.Text.Split('/');  // DD/MM//YYYY  ---> yyyy/MM/DD
                    string LoanApplnDate = Termlanapplndate[2].ToString() + "/" + Termlanapplndate[1].ToString() + "/" + Termlanapplndate[0].ToString();

                    string[] TermlanSanctndate = txtdatesome.Text.Split('/');
                    string LoanSanctnDate = TermlanSanctndate[2].ToString() + "/" + TermlanSanctndate[1].ToString() + "/" + TermlanSanctndate[0].ToString();

                    string[] TermLoanReleasedDate = txtTermLoanReleasedDate.Text.Split('/');
                    string TermLoanReleasedDate1 = TermLoanReleasedDate[2].ToString() + "/" + TermLoanReleasedDate[1].ToString() + "/" + TermLoanReleasedDate[0].ToString();

                    if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
                    {
                        AddDataToTableCeertificate(ddlTermLoanNo.SelectedValue, LoanApplnDate, txtnmofinstitution.Text, LoanSanctnDate, "", TermLoanReleasedDate1, txtsactionedloan.Text, (DataTable)Session["CertificateTb9"]);

                        this.GVTermLoandtls.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
                        this.GVTermLoandtls.DataBind();
                        ClearTxt();
                    }
                    else if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                    {
                        AddDataToTableCeertificate(ddlTermLoanNo.SelectedValue, LoanApplnDate, txtnmofinstitution.Text, LoanSanctnDate, "", TermLoanReleasedDate1, txtsactionedloan.Text, (DataTable)Session["CertificateTb9"]);
                        this.GVTermLoandtls.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
                        this.GVTermLoandtls.DataBind();
                        ClearTxt();
                    }
                    GVTermLoandtls.Visible = true;
                    lblmsg0.Text = "";
                    Failure.Visible = false;
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        protected void GVTermLoandtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void GVTermLoandtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if ((hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == ""))
                {
                    ((DataTable)Session["CertificateTb9"]).Rows.RemoveAt(e.RowIndex);

                    this.GVTermLoandtls.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
                    this.GVTermLoandtls.DataBind();
                }
                else
                {
                    if (hdfFlagID.Value.Trim() != "")
                    {
                        try
                        {
                            string traineetradesnames = GVTermLoandtls.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                            DataSet dsna = new DataSet();
                            int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                            ((DataTable)Session["CertificateTb9"]).Rows.RemoveAt(e.RowIndex);
                            this.GVTermLoandtls.DataSource = ((DataTable)Session["CertificateTb9"]).DefaultView;
                            this.GVTermLoandtls.DataBind();
                        }
                        catch (Exception eee)
                        {
                            throw eee;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlOrgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrgType.SelectedValue != "0")
            {
                ddlAuthorisedDesignation.Items.Clear();
                //1	Proprietary
                //2	Partnership
                //3	Pvt Ltd
                //4	Public Limited
                //5	Co-Operative
                //6	LLP
                //7	Trust

                Button5.Enabled = true;
                txtshare.Enabled = true;
                DataSet ds = new DataSet();
                ds = Gen.GetAuthorisedSignatory(ddlOrgType.SelectedValue);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlAuthorisedDesignation.DataSource = ds.Tables[0];
                    ddlAuthorisedDesignation.DataTextField = "Disignation";
                    ddlAuthorisedDesignation.DataValueField = "ID";
                    ddlAuthorisedDesignation.DataBind();

                    ListItem li = new ListItem();
                    li.Value = "0";
                    li.Text = "--Select--";
                    ddlAuthorisedDesignation.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Value = "0";
                    li.Text = "--Select--";
                    ddlAuthorisedDesignation.Items.Insert(0, li);
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ddlAuthorisedSignDesignation.DataSource = ds.Tables[1];
                    ddlAuthorisedSignDesignation.DataTextField = "Disignation";
                    ddlAuthorisedSignDesignation.DataValueField = "ID";
                    ddlAuthorisedSignDesignation.DataBind();

                    ListItem li = new ListItem();
                    li.Value = "0";
                    li.Text = "--Select--";
                    ddlAuthorisedSignDesignation.Items.Insert(0, li);
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Value = "0";
                    li.Text = "--Select--";
                    ddlAuthorisedSignDesignation.Items.Insert(0, li);
                }
                if (ddlOrgType.SelectedValue == "1")
                {
                    Label12.Text = "Details of the Proprietor :";

                    //ddlAuthorisedDesignation.Items.Clear();
                    //ddlAuthorisedDesignation.Items.Add("Proprietor");
                    //ddlAuthorisedDesignation.Items.Add("Proprietrix");
                    //ddlAuthorisedDesignation.Items.Add("Other");

                    //ddlAuthorisedSignDesignation.Items.Clear();
                    //ddlAuthorisedSignDesignation.Items.Add("Proprietor");
                    //ddlAuthorisedSignDesignation.Items.Add("Proprietrix");
                    //ddlAuthorisedSignDesignation.Items.Add("GM");
                    //ddlAuthorisedSignDesignation.Items.Add("AGM");
                    //ddlAuthorisedSignDesignation.Items.Add("Other");

                    txtshare.Text = "100";
                    txtshare.Enabled = false;

                }
                else if (ddlOrgType.SelectedValue == "2")
                {
                    Label12.Text = "Details of the Partner(s) :";

                    //ddlAuthorisedDesignation.Items.Clear();
                    //ddlAuthorisedDesignation.Items.Add("Managing partner");
                    //ddlAuthorisedDesignation.Items.Add("Partner");
                    //ddlAuthorisedDesignation.Items.Add("Other");

                    //ddlAuthorisedSignDesignation.Items.Clear();
                    //ddlAuthorisedSignDesignation.Items.Add("Managing partner");
                    //ddlAuthorisedSignDesignation.Items.Add("Partner");
                    //ddlAuthorisedSignDesignation.Items.Add("GM");
                    //ddlAuthorisedSignDesignation.Items.Add("AGM");
                    //ddlAuthorisedSignDesignation.Items.Add("Other");
                }
                else if (ddlOrgType.SelectedValue == "3")
                {
                    Label12.Text = "Details of the Pvt Ltd :";

                    //ddlAuthorisedDesignation.Items.Clear();
                    //ddlAuthorisedDesignation.Items.Add("Managing Director");
                    //ddlAuthorisedDesignation.Items.Add("Director");
                    //ddlAuthorisedDesignation.Items.Add("Other");

                    //ddlAuthorisedSignDesignation.Items.Clear();
                    //ddlAuthorisedSignDesignation.Items.Add("Managing Director");
                    //ddlAuthorisedSignDesignation.Items.Add("Director");
                    //ddlAuthorisedSignDesignation.Items.Add("GM");
                    //ddlAuthorisedSignDesignation.Items.Add("AGM");
                    //ddlAuthorisedSignDesignation.Items.Add("Other");
                }
                else if (ddlOrgType.SelectedValue == "4")
                {
                    Label12.Text = "Details of the Public Limited :";

                    //ddlAuthorisedDesignation.Items.Clear();
                    //ddlAuthorisedDesignation.Items.Add("Managing Director");
                    //ddlAuthorisedDesignation.Items.Add("Director");
                    //ddlAuthorisedDesignation.Items.Add("Other");

                    //ddlAuthorisedSignDesignation.Items.Clear();
                    //ddlAuthorisedSignDesignation.Items.Add("Managing Director");
                    //ddlAuthorisedSignDesignation.Items.Add("Director");
                    //ddlAuthorisedSignDesignation.Items.Add("GM");
                    //ddlAuthorisedSignDesignation.Items.Add("AGM");
                    //ddlAuthorisedSignDesignation.Items.Add("Other");
                }
                else if (ddlOrgType.SelectedValue == "5")
                {
                    Label12.Text = "Details of the 	Co-Operative Limited :";
                    //ddlAuthorisedDesignation.Items.Clear();
                    //ddlAuthorisedDesignation.Items.Add("Managing Director");
                    //ddlAuthorisedDesignation.Items.Add("Director");
                    //ddlAuthorisedDesignation.Items.Add("Other");

                    //ddlAuthorisedSignDesignation.Items.Clear();
                    //ddlAuthorisedSignDesignation.Items.Add("Managing Director");
                    //ddlAuthorisedSignDesignation.Items.Add("Director");
                    //ddlAuthorisedSignDesignation.Items.Add("GM");
                    //ddlAuthorisedSignDesignation.Items.Add("AGM");
                    //ddlAuthorisedSignDesignation.Items.Add("Other");
                }
                else if (ddlOrgType.SelectedValue == "6")
                {
                    Label12.Text = "Details of the LLP :";

                    //ddlAuthorisedDesignation.Items.Clear();
                    //ddlAuthorisedDesignation.Items.Add("President");
                    //ddlAuthorisedDesignation.Items.Add("Vise President");
                    //ddlAuthorisedDesignation.Items.Add("Secretary");
                    //ddlAuthorisedDesignation.Items.Add("Other");

                    //ddlAuthorisedSignDesignation.Items.Clear();
                    //ddlAuthorisedSignDesignation.Items.Add("President");
                    //ddlAuthorisedSignDesignation.Items.Add("Vise President");
                    //ddlAuthorisedSignDesignation.Items.Add("Secretary");
                    //ddlAuthorisedSignDesignation.Items.Add("Other");
                }
                else if (ddlOrgType.SelectedValue == "7")
                {
                    Label12.Text = "Details of the Trust :";

                    //ddlAuthorisedDesignation.Items.Clear();
                    //ddlAuthorisedDesignation.Items.Add("President");
                    //ddlAuthorisedDesignation.Items.Add("Vise President");
                    //ddlAuthorisedDesignation.Items.Add("Secretary");
                    //ddlAuthorisedDesignation.Items.Add("Other");

                    //ddlAuthorisedSignDesignation.Items.Clear();
                    //ddlAuthorisedSignDesignation.Items.Add("President");
                    //ddlAuthorisedSignDesignation.Items.Add("Vise President");
                    //ddlAuthorisedSignDesignation.Items.Add("Secretary");
                    //ddlAuthorisedSignDesignation.Items.Add("Other");
                }
            }
        }
        protected void btnInstalledcapExpan_Click(object sender, EventArgs e)
        {
            int valid = 0;
            try
            {
                if (txtLOActivityExpan.Text == "" || txtLOActivityExpan.Text == null)
                {
                    lblmsg0.Text = "Line Of Activity of Expansion Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    txtLOActivityExpan.Focus();
                    valid = 1;
                }
                if (txtinstalledccapExpan.Text == "" || txtinstalledccapExpan.Text == null)
                {
                    lblmsg0.Text = "Installed Capacity  of Expansion Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    txtinstalledccap.Focus();
                    valid = 1;
                }
                if (txtvalueExpan.Text == "" || txtvalueExpan.Text == null)
                {
                    lblmsg0.Text = "Value  of Expansion Cannot be blank" + "<br/>";
                    Failure.Visible = true;
                    txtvalueExpan.Focus();
                    valid = 1;
                }
                string strunit = "";

                if (ddlquantityinExpan.SelectedItem.Text == "--Select--")
                {
                    lblmsg0.Text = "Please Select Unit  of Expansion" + "<br/>";
                    Failure.Visible = true;
                    ddlquantityinExpan.Focus();
                    valid = 1;
                }
                else
                {
                    strunit = ddlquantityinExpan.SelectedItem.Text;
                }
                if (ddlquantityinExpan.SelectedItem.Text == "Others")
                {
                    if (txtunitExpan.Text == "" || txtunitExpan.Text == null)
                    {
                        lblmsg0.Text = "Unit  of Expansion Cannot be blank" + "<br/>";
                        Failure.Visible = true;
                        txtunitExpan.Focus();
                        valid = 1;
                    }
                    else
                    {
                        strunit = txtunitExpan.Text;
                    }
                }
                if (valid == 0)
                {
                    if ((hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfID.Value.Trim() == "" && hdfFlagID.Value == ""))
                    {
                        AddDataToTableCeertificate(txtLOActivityExpan.Text, strunit, txtinstalledccapExpan.Text, txtvalueExpan.Text, //ddlquantityper.SelectedValue.ToString(), 
                            Session["uid"].ToString(), "Expansion LOA", "", (DataTable)Session["CertificateTb10"]);

                        this.gvInstalledCapExpan.DataSource = ((DataTable)Session["CertificateTb10"]).DefaultView;
                        this.gvInstalledCapExpan.DataBind();
                        ClearTxt();
                    }
                    else
                        if (hdfID.Value.Trim() != "" && hdfFlagID.Value == "2")
                    {
                        AddDataToTableCeertificate(txtLOActivityExpan.Text, txtunitExpan.Text, txtinstalledccapExpan.Text, txtvalueExpan.Text, // ddlquantityper.SelectedValue.ToString(),
                            Session["uid"].ToString(), "Expansion LOA", "", (DataTable)Session["CertificateTb10"]);
                        this.gvInstalledCapExpan.DataSource = ((DataTable)Session["CertificateTb10"]).DefaultView;
                        this.gvInstalledCapExpan.DataBind();
                        ClearTxt();
                    }
                    gvInstalledCapExpan.Visible = true;
                    lblmsg0.Text = "";
                    Failure.Visible = false;
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {

        }
        protected void gvInstalledCapExpan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if ((hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == "0") || (hdfFlagID.Value.Trim() == "" && hdfFlagID.Value == ""))
                {
                    ((DataTable)Session["CertificateTb10"]).Rows.RemoveAt(e.RowIndex);

                    this.gvInstalledCapExpan.DataSource = ((DataTable)Session["CertificateTb10"]).DefaultView;
                    this.gvInstalledCapExpan.DataBind();
                }
                else
                {
                    if (hdfFlagID.Value.Trim() != "")
                    {
                        try
                        {
                            string traineetradesnames = gvInstalledCapExpan.DataKeys[e.RowIndex].Values["intLineofActivityMid"].ToString();
                            DataSet dsna = new DataSet();
                            int i1 = Gen.deleteGroupSavingData1(traineetradesnames);

                            ((DataTable)Session["CertificateTb10"]).Rows.RemoveAt(e.RowIndex);
                            this.gvInstalledCapExpan.DataSource = ((DataTable)Session["CertificateTb10"]).DefaultView;
                            this.gvInstalledCapExpan.DataBind();
                        }
                        catch (Exception eee)
                        {
                            throw eee;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvInstalledCapExpan_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        protected void txtplantexisting_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise();
        }

        //public void CalculatationEnterprise()
        //{
        //    try
        //    {
        //        decimal PlantMachValexisting = 0;
        //        decimal PlantMachValexpansion = 0;
        //        decimal PlantMachValFinal = 0;


        //        decimal landexisting = 0, landcapacity = 0;

        //        decimal buildingexisting = 0, buildingcapacity = 0;

        //        if (txtlandexisting.Text != null && txtlandexisting.Text != "" && txtlandexisting.Text != string.Empty)
        //        {
        //            landexisting = Convert.ToDecimal(txtlandexisting.Text.Trim());   // exiting Plant Mach value
        //        }
        //        else
        //        {
        //            landexisting = 0;
        //        }
        //        if (txtbuildingexisting.Text != null && txtbuildingexisting.Text != "" && txtbuildingexisting.Text != string.Empty)
        //        {
        //            buildingexisting = Convert.ToDecimal(txtbuildingexisting.Text.Trim());   // exiting Plant Mach value
        //        }
        //        else
        //        {
        //            buildingexisting = 0;
        //        }

        //        //--------------------------------
        //        if (txtlandcapacity.Text != null && txtlandcapacity.Text != "" && txtlandcapacity.Text != string.Empty)
        //        {
        //            landcapacity = Convert.ToDecimal(txtlandcapacity.Text.Trim());   // exiting Plant Mach value
        //        }
        //        else
        //        {
        //            landcapacity = 0;
        //        }
        //        if (txtbuildingcapacity.Text != null && txtbuildingcapacity.Text != "" && txtbuildingcapacity.Text != string.Empty)
        //        {
        //            buildingcapacity = Convert.ToDecimal(txtbuildingcapacity.Text.Trim());   // exiting Plant Mach value
        //        }
        //        else
        //        {
        //            buildingcapacity = 0;
        //        }

        //        // -------------------------------
        //        if (txtplantexisting.Text != null && txtplantexisting.Text != "" && txtplantexisting.Text != string.Empty)
        //        {
        //            PlantMachValexisting = Convert.ToDecimal(txtplantexisting.Text.Trim());   // exiting Plant Mach value
        //        }
        //        else
        //        {
        //            PlantMachValexisting = 0;
        //        }

        //        if (txtplantcapacity.Text != null && txtplantcapacity.Text != "" && txtplantcapacity.Text != string.Empty)
        //        {
        //            PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.Text.Trim());  // expansion Plant Mach value   
        //        }
        //        else
        //        {
        //            PlantMachValexpansion = 0;
        //        }

        //        PlantMachValFinal = (PlantMachValexisting + PlantMachValexpansion + landexisting + landcapacity + buildingexisting + buildingcapacity) / 100000;

        //        DataSet dsEnter = new DataSet();
        //        string sectorid = rblSector.SelectedValue;
        //        if (sectorid == "1")
        //        {
        //            sectorid = "2";
        //        }
        //        else if (sectorid == "2" || sectorid == "3") // 3 is texttile same as manufacture
        //        {
        //            sectorid = "1";
        //        }

        //        dsEnter = Gen.GetEnterPriseIs_Incentive(Convert.ToString(PlantMachValFinal), sectorid);   // 1 for Manufacture

        //        if (dsEnter != null && dsEnter.Tables.Count > 0 && dsEnter.Tables[0].Rows.Count > 0)
        //        {
        //            if (dsEnter.Tables[0].Rows[0]["EnterpriseType"] != null && dsEnter.Tables[0].Rows[0]["EnterpriseType"] != "" && dsEnter.Tables[0].Rows[0]["EnterpriseType"] != string.Empty)
        //            {
        //                //  ddlCategory.SelectedValue = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
        //                ddlCategory.SelectedItem.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
        //                ddlCategory.Enabled = true;
        //                HiddenFieldEnterpriseCategory.Value = "";
        //                if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Micro")
        //                {
        //                    lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
        //                    HiddenFieldEnterpriseCategory.Value = "1";
        //                }
        //                else if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Small")
        //                {
        //                    lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
        //                    HiddenFieldEnterpriseCategory.Value = "2";
        //                }
        //                else if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Medium")
        //                {
        //                    lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
        //                    HiddenFieldEnterpriseCategory.Value = "3";
        //                }
        //                else if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Large")
        //                {
        //                    lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
        //                    HiddenFieldEnterpriseCategory.Value = "4";
        //                }
        //                else if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Mega")
        //                {
        //                    lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
        //                    HiddenFieldEnterpriseCategory.Value = "5";
        //                }
        //                //4	Large  //3	Medium       //5	Mega  //1	Micro     //2	Small
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        lblmsg0.Text = ex.Message;
        //        Failure.Visible = true;
        //        success.Visible = false;
        //    }
        //}

        public void CalculatationEnterprise()   //changed JD Sir instructions calc only m/c value - 18.2.2019
        {
            try
            {
                if (ddlIndustryStatus.SelectedItem.Text.ToString() != "-- Select --")
                {
                    btntab2next.Enabled = true;
                    Failure.Visible = false;
                    decimal PlantMachValexisting = 0;
                    decimal PlantMachValexpansion = 0;
                    decimal PlantMachValFinal = 0;


                    decimal landexisting = 0, landcapacity = 0;

                    decimal buildingexisting = 0, buildingcapacity = 0;


                    DataSet dsEnter = new DataSet();
                    string sectorid = rblSector.SelectedValue;
                    //if (sectorid == "1")
                    //{
                    //    sectorid = "2";
                    //}
                    //else if (sectorid == "2" || sectorid == "3") // 3 is texttile same as manufacture
                    //{
                    //    sectorid = "1";
                    //}

                    // 1 for Manufacture

                    if (ddlIndustryStatus.SelectedItem.Text.ToString() != "New Industry")
                    {
                        PlantMachValFinal = '0';
                        dsEnter = null;

                        if ((txtlandexisting.Text != null && txtlandexisting.Text != "" && txtlandexisting.Text != string.Empty) && (txtbuildingexisting.Text != null && txtbuildingexisting.Text != "" && txtbuildingexisting.Text != string.Empty) && (txtplantexisting.Text != null && txtplantexisting.Text != "" && txtplantexisting.Text != string.Empty) &&
                            (txtlandcapacity.Text != null && txtlandcapacity.Text != "" && txtlandcapacity.Text != string.Empty) && (txtbuildingcapacity.Text != null && txtbuildingcapacity.Text != "" && txtbuildingcapacity.Text != string.Empty) &&
                            (txtplantcapacity.Text != null && txtplantcapacity.Text != "" && txtplantcapacity.Text != string.Empty)
                            )
                        {
                            PlantMachValexisting = Convert.ToDecimal(txtplantexisting.Text.ToString());
                            PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.Text.ToString());
                            PlantMachValFinal = PlantMachValexpansion + PlantMachValexisting;
                            if (rblSector.SelectedIndex.ToString() == "1")
                            {
                                rblSector.SelectedIndex = 2;
                            }
                            else if (rblSector.SelectedIndex.ToString() == "2" || rblSector.SelectedIndex.ToString() == "3")
                            {
                                rblSector.SelectedIndex = 1;
                            }
                            dsEnter = Gen.GetEnterPriseIs_Incentive(Convert.ToString(PlantMachValFinal), rblSector.SelectedIndex.ToString());
                        }
                    }

                    else if (ddlIndustryStatus.SelectedItem.Text.ToString() == "New Industry")
                    {
                        PlantMachValFinal = '0';
                        dsEnter = null;

                        if ((txtlandexisting.Text != null && txtlandexisting.Text != "" && txtlandexisting.Text != string.Empty) && (txtbuildingexisting.Text != null && txtbuildingexisting.Text != "" && txtbuildingexisting.Text != string.Empty) && (txtplantexisting.Text != null && txtplantexisting.Text != "" && txtplantexisting.Text != string.Empty))
                        {
                            PlantMachValexisting = Convert.ToDecimal(txtplantexisting.Text.ToString());
                            if (rblSector.SelectedIndex.ToString() == "1")
                            {
                                rblSector.SelectedIndex = 2;
                            }
                            else if (rblSector.SelectedIndex.ToString() == "2" || rblSector.SelectedIndex.ToString() == "3")
                            {
                                rblSector.SelectedIndex = 1;
                            }
                            dsEnter = Gen.GetEnterPriseIs_Incentive(Convert.ToString(PlantMachValexisting), rblSector.SelectedIndex.ToString());
                        }
                    }

                    if (dsEnter != null && dsEnter.Tables.Count > 0 && dsEnter.Tables[0].Rows.Count > 0)
                    {
                        if (dsEnter.Tables[0].Rows[0]["EnterpriseType"] != null && dsEnter.Tables[0].Rows[0]["EnterpriseType"] != "" && dsEnter.Tables[0].Rows[0]["EnterpriseType"] != string.Empty)
                        {
                            //  ddlCategory.SelectedValue = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                            ddlCategory.SelectedItem.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString().Trim();
                            ddlCategory.Enabled = true;
                            HiddenFieldEnterpriseCategory.Value = "";
                            if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Micro")
                            {
                                lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
                                HiddenFieldEnterpriseCategory.Value = "1";
                                lblEnterpriseCategoryTTAP.Text = "A1";
                            }
                            else if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Small")
                            {
                                lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
                                HiddenFieldEnterpriseCategory.Value = "2";
                                lblEnterpriseCategoryTTAP.Text = "A2";
                            }
                            else if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Medium")
                            {
                                lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
                                HiddenFieldEnterpriseCategory.Value = "3";
                                lblEnterpriseCategoryTTAP.Text = "A3";
                            }
                            else if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Large")
                            {
                                lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
                                HiddenFieldEnterpriseCategory.Value = "4";
                                lblEnterpriseCategoryTTAP.Text = "A4";
                            }
                            else if (dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString() == "Mega")
                            {
                                lblEnterpriseCategory.Text = dsEnter.Tables[0].Rows[0]["EnterpriseType"].ToString();
                                HiddenFieldEnterpriseCategory.Value = "5";
                                lblEnterpriseCategoryTTAP.Text = "A5";
                            }
                            //4	Large  //3	Medium       //5	Mega  //1	Micro     //2	Small
                        }
                    }
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "Please select Industry Status";
                    ddlIndustryStatus.Focus();
                    btntab2next.Enabled = false;

                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }


        protected void ddlAuthorisedDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAuthorisedDesignation.SelectedItem.Text.ToUpper() == "OTHER")
            {
                trdesignation.Visible = true;
            }
            else
            {
                trdesignation.Visible = false;
            }
        }

        void getUdyogAadharType()
        {
            DataSet ds = new DataSet();
            ds = Gen.getUdyogAadharType();

            ddlUdyogAadharType.DataSource = ds.Tables[0];
            ddlUdyogAadharType.DataTextField = "Name";
            ddlUdyogAadharType.DataValueField = "Slno";
            ddlUdyogAadharType.DataBind();
            AddSelect(ddlUdyogAadharType);
            // ddlUdyogAadharType.Items.Insert(0, "-- Select Udyog Aadhar/EM/IEM/IL/EOU No --");
        }

        // added on 08.07.2017  for edit & update common form details
        public void UpdateComonFormdetails(DataSet ds)
        {
            string str = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
            if (str == "1")
            {
                ddlIndustryStatus.SelectedItem.Text = "New Industry";
                ddlIndustryStatus.Enabled = true;

                trNewIndustry.Visible = true;
                trexpansion.Visible = false;
                trexpansionnew.Visible = false;
                trFixedcap.Visible = true;

                gvInstalledCap.Visible = false;
                gvInstalledCapNew.Visible = true;
                gvInstalledCapNew.DataSource = null;
                gvInstalledCapNew.DataBind();

                gvInstalledCapNew.DataSource = ds.Tables[1];
                gvInstalledCapNew.DataBind();

                trlineofactivityNew.Visible = false;
                if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
                {
                    tblpower1.Visible = true;
                    tblpower2.Visible = false;
                    lblpowerHEAD.Text = "New Enterprise";
                    ddlIspowApplicable_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else
                {
                    tblpower1.Visible = false;
                    tblpower2.Visible = false;
                }

                //tblpower1.Visible = true;
                //tblpower2.Visible = false;
                //lblpowerHEAD.Text = "New Enterprise";
            }
            if (str == "2")
            {
                trlineofactivityNew.Visible = true;
                ddlIndustryStatus.SelectedItem.Text = "Expansion";
                ddlIndustryStatus.Enabled = false;
                ddlInustryExpansionType.Enabled = false;

                trNewIndustry.Visible = true;   //trNewIndustry.Visible = false;
                                                //trexpansion.Visible = true;
                trexpansionnew.Visible = true;

                gvInstalledCapNew.DataSource = ds.Tables[1];
                gvInstalledCapNew.DataBind();
                gvInstalledCapNew.Visible = true;

                gvInstalledCapExpanNew.DataSource = ds.Tables[4];
                gvInstalledCapExpanNew.DataBind();
                gvInstalledCapExpanNew.Visible = true;
                if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
                {
                    tblpower1.Visible = true;
                    tblpower2.Visible = false;
                    ddlIspowApplicable_SelectedIndexChanged(this, EventArgs.Empty);
                    lblpowerHEAD.Text = "New Enterprise";

                    // for power 
                    tblpower2.Visible = true;
                    tblpower1.Visible = false;

                    lblexistingpower.Text = "Existing Enterprise production details";
                    lblexpandiverpower.Text = "Expansion / Diversification details";
                }
                else
                {
                    tblpower1.Visible = false;
                    tblpower2.Visible = false;
                }

                lblexpan1.Text = "";
                lblexpan2.Text = "";
                lblexpan3.Text = "";
                lblexpan1.Text = "EXPANSION";
                lblexpan2.Text = "Expansion";
                lblexpan3.Text = "Expansion";


            }
            if (str == "3")
            {
                trlineofactivityNew.Visible = true;    //trlineofactivityNew.Visible = false;
                ddlIndustryStatus.SelectedItem.Text = "Diversification";
                ddlIndustryStatus.Enabled = false;

                trNewIndustry.Visible = true;// trNewIndustry.Visible = false;
                                             // trexpansion.Visible = true;
                trexpansionnew.Visible = true;

                // for power
                if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
                {
                    lblpowerHEAD.Text = "New Enterprise";
                    tblpower2.Visible = true;
                    tblpower1.Visible = false;
                    ddlIspowApplicable_SelectedIndexChanged(this, EventArgs.Empty);

                    lblexistingpower.Text = "Existing Enterprise production details";
                    lblexpandiverpower.Text = "Expansion / Diversification details";
                }
                else
                {
                    tblpower1.Visible = false;
                    tblpower2.Visible = false;
                }

                lblexpan1.Text = "";
                lblexpan2.Text = "";
                lblexpan3.Text = "";
                lblexpan1.Text = "DIVERSIFICATION";
                lblexpan2.Text = "Diversification";
                lblexpan3.Text = "Diversification";
            }



            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                //GridView3.DataSource = null;  //gvdirector2.DataSource = null;
                //GridView3.DataBind();  //gvdirector2.DataBind();

                //GridView3.DataSource = ds.Tables[2];  //gvdirector2.DataSource = ds.Tables[2];
                //GridView3.DataBind();  //gvdirector2.DataBind();

                if (ddlIndustryStatus.SelectedItem.Text == "Expansion" || ddlIndustryStatus.SelectedItem.Text == "Diersification")
                {
                    //GridView1.DataSource = null;
                    //GridView1.DataBind();

                    //GridView1.DataSource = ds.Tables[1];
                    //GridView1.DataBind();

                    gvInstalledCapExpan.DataSource = null;
                    gvInstalledCapExpan.DataBind();

                    //gvInstalledCapExpan.DataSource = ds.Tables[1];
                    //gvInstalledCapExpan.DataBind();
                }

                // trlineofactivityNew.Visible = false;
            }
            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
            {
                //gvInstalledCap1.DataSource = null;
                //gvInstalledCap1.DataBind();

                //gvInstalledCap1.DataSource = ds.Tables[1];
                //gvInstalledCap1.DataBind();
                gvdirector2.DataSource = null;
                gvdirector2.DataBind();

                gvdirector2.DataSource = ds.Tables[2];
                gvdirector2.DataBind();
                gvdirector2.Visible = true;
                tblview3.Visible = false;
                //trdirectordetails.Visible = false;
                lblpartner.Text = "Details of the Director(s)/ Partner(s) :";
            }

            GridView2.DataSource = null;
            GridView2.DataBind();

            GridView2.DataSource = ds.Tables[3];
            GridView2.DataBind();
            GridView2.Visible = true;

            //trTermLoanLine1.Visible = false;
            //trTermLoanLine2.Visible = false;
            //trTermLoanLine3.Visible = false;
            //trTermLoanLine4.Visible = false;
            //trTermLoanLine6.Visible = false;
        }

        public void DontUpdateComonFormdetails(DataSet ds)
        {
            string str = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
            if (str == "1")
            {
                ddlIndustryStatus.SelectedItem.Text = "New Industry";
                ddlIndustryStatus.Enabled = false;

                trNewIndustry.Visible = true;
                trexpansion.Visible = false;
                trexpansionnew.Visible = false;
                trFixedcap.Visible = true;

                gvInstalledCap.Visible = false;
                gvInstalledCapNew.Visible = true;
                gvInstalledCapNew.DataSource = null;
                gvInstalledCapNew.DataBind();

                gvInstalledCapNew.DataSource = ds.Tables[1];
                gvInstalledCapNew.DataBind();

                trlineofactivityNew.Visible = false;

                if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
                {
                    tblpower1.Visible = true;
                    tblpower2.Visible = false;
                    lblpowerHEAD.Text = "New Enterprise";
                    ddlIspowApplicable_SelectedIndexChanged(this, EventArgs.Empty);
                }
                else
                {
                    tblpower1.Visible = false;
                    tblpower2.Visible = false;
                }

            }
            if (str == "2")
            {
                trlineofactivityNew.Visible = true;
                ddlIndustryStatus.SelectedItem.Text = "Expansion";
                ddlIndustryStatus.Enabled = false;
                ddlInustryExpansionType.Enabled = false;
                trNewIndustry.Visible = true;   //trNewIndustry.Visible = false;
                                                //trexpansion.Visible = true;
                trexpansionnew.Visible = true;

                if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
                {
                    // for power 
                    tblpower2.Visible = true;
                    tblpower1.Visible = false;

                    lblexistingpower.Text = "Existing Enterprise production details";
                    lblexpandiverpower.Text = "Expansion / Diversification details";
                }

                lblexpan1.Text = "";
                lblexpan2.Text = "";
                lblexpan3.Text = "";
                lblexpan1.Text = "EXPANSION";
                lblexpan2.Text = "Expansion";
                lblexpan3.Text = "Expansion";


            }
            if (str == "3")
            {
                trlineofactivityNew.Visible = true;    //trlineofactivityNew.Visible = false;
                ddlIndustryStatus.SelectedItem.Text = "Diversification";
                ddlIndustryStatus.Enabled = false;

                trNewIndustry.Visible = true;// trNewIndustry.Visible = false;
                                             // trexpansion.Visible = true;
                trexpansionnew.Visible = true;
                if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
                {
                    // for power
                    tblpower2.Visible = true;
                    tblpower1.Visible = false;
                }

                lblexistingpower.Text = "Existing Enterprise production details";
                lblexpandiverpower.Text = "Expansion / Diversification details";

                lblexpan1.Text = "";
                lblexpan2.Text = "";
                lblexpan3.Text = "";
                lblexpan1.Text = "DIVERSIFICATION";
                lblexpan2.Text = "Diversification";
                lblexpan3.Text = "Diversification";
            }



            if (ds != null && ds.Tables.Count == 3 && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
            {
                GridView3.DataSource = null;  //gvdirector2.DataSource = null;
                GridView3.DataBind();  //gvdirector2.DataBind();

                GridView3.DataSource = ds.Tables[2];  //gvdirector2.DataSource = ds.Tables[2];
                GridView3.DataBind();  //gvdirector2.DataBind();

                if (ddlIndustryStatus.SelectedItem.Text == "Expansion" || ddlIndustryStatus.SelectedItem.Text == "Diersification")
                {
                    //GridView1.DataSource = null;
                    //GridView1.DataBind();

                    //GridView1.DataSource = ds.Tables[1];
                    //GridView1.DataBind();

                    gvInstalledCapExpan.DataSource = null;
                    gvInstalledCapExpan.DataBind();

                    gvInstalledCapExpan.DataSource = ds.Tables[1];
                    gvInstalledCapExpan.DataBind();
                }

                // trlineofactivityNew.Visible = false;
            }
            if (ds != null && ds.Tables.Count == 4 && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
            {
                //gvInstalledCap1.DataSource = null;
                //gvInstalledCap1.DataBind();

                //gvInstalledCap1.DataSource = ds.Tables[1];
                //gvInstalledCap1.DataBind();

                gvdirector2.DataSource = null;
                gvdirector2.DataBind();

                gvdirector2.DataSource = ds.Tables[2];
                gvdirector2.DataBind();
                gvdirector2.Visible = true;
                tblview3.Visible = false;
                //trdirectordetails.Visible = false;
                lblpartner.Text = "Details of the Director(s)/ Partner(s) :";
            }

            GridView2.DataSource = null;
            GridView2.DataBind();

            GridView2.DataSource = ds.Tables[3];
            GridView2.DataBind();
            GridView2.Visible = true;

            trTermLoanLine1.Visible = false;
            trTermLoanLine2.Visible = false;
            trTermLoanLine3.Visible = false;
            trTermLoanLine4.Visible = false;
            trTermLoanLine6.Visible = false;

        }


        protected void txtLand7_TextChanged(object sender, EventArgs e)
        {
            decimal valueland1 = 0;
            decimal valueland2 = 0;
            if (txtlandexisting.Text.Trim() != "" && txtlandexisting.Text.Trim() != "0")
            {
                valueland1 = Convert.ToDecimal(txtlandexisting.Text.Trim());
            }
            if (txtLand7.Text.Trim() != "" && txtLand7.Text.Trim() != "0")
            {
                valueland2 = Convert.ToDecimal(txtLand7.Text.Trim());
            }
            //if (valueland1 != valueland2)
            //{
            //    txtLand7.Text = "";
            //    lblmsg0.Text = "Tha land value  you mentioned in fixed capital investment should be same with estimated projected cost land value";
            //    Failure.Visible = true;
            //    lblmsg0.Focus();
            //    return;
            //}
        }
        protected void txtBuilding7_TextChanged(object sender, EventArgs e)
        {
            decimal valueland1 = 0;
            decimal valueland2 = 0;
            if (txtbuildingexisting.Text.Trim() != "" && txtbuildingexisting.Text.Trim() != "0")
            {
                valueland1 = Convert.ToDecimal(txtbuildingexisting.Text.Trim());
            }
            if (txtBuilding7.Text.Trim() != "" && txtBuilding7.Text.Trim() != "0")
            {
                valueland2 = Convert.ToDecimal(txtBuilding7.Text.Trim());
            }
            //if (valueland1 != valueland2)
            //{
            //    txtLand7.Text = "";
            //    lblmsg0.Text = "Tha buliding value  you mentioned in fixed capital investment should be same with estimated projected cost buliding value";
            //    Failure.Visible = true;
            //    lblmsg0.Focus();
            //    return;
            //}
        }
        protected void txtPM7_TextChanged(object sender, EventArgs e)
        {
            decimal valueland1 = 0;
            decimal valueland2 = 0;
            if (txtplantexisting.Text.Trim() != "" && txtplantexisting.Text.Trim() != "0")
            {
                valueland1 = Convert.ToDecimal(txtplantexisting.Text.Trim());
            }
            if (txtPM7.Text.Trim() != "" && txtPM7.Text.Trim() != "0")
            {
                valueland2 = Convert.ToDecimal(txtPM7.Text.Trim());
            }
            //if (valueland1 != valueland2)
            //{
            //    txtLand7.Text = "";
            //    lblmsg0.Text = "Tha plant/machinary value  you mentioned in fixed capital investment should be same with estimated projected cost plant/machinary value";
            //    Failure.Visible = true;
            //    lblmsg0.Focus();
            //    return;
            //}
        }
        protected void txtplantcapacity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtplantexisting_TextChanged(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void txtTinNO_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTinNO.Text.Trim() != null && txtTinNO.Text.Trim() != "" && txtTinNO.Text.Trim() != string.Empty)
                {
                    txtvatno.Text = txtTinNO.Text;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void BindBankAccountType()
        {
            DataSet ds = new DataSet();
            ds = Gen.getBankAccountTypeMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAccountType.DataSource = ds.Tables[0];
                ddlAccountType.DataTextField = "AccountTypeName";
                ddlAccountType.DataValueField = "AccountTypeID";
                ddlAccountType.DataBind();
            }
            // ddlAccountType.Items.Insert(0, "-- Select Account Type--")
        }




        protected void ddlIsTermLoanAvailed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIsTermLoanAvailed.SelectedItem.Text.ToUpper() == "YES")
            {
                tblTermLoanDtls.Visible = true;
                trTermLoanLine1.Visible = true;
                trTermLoanLine2.Visible = true;
                trTermLoanLine3.Visible = true;
                trTermLoanLine4.Visible = true;
                trTermLoanLine6.Visible = true;
            }
            else
            {
                tblTermLoanDtls.Visible = false;
                tblTermLoanDtls.Visible = false;
                trTermLoanLine1.Visible = false;
                trTermLoanLine2.Visible = false;
                trTermLoanLine3.Visible = false;
                trTermLoanLine4.Visible = false;
                trTermLoanLine6.Visible = false;
            }
        }
        protected void rblVeh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblVeh.SelectedValue == "1")
                {
                    divvehicleno.Visible = true;
                }
                else
                {
                    divvehicleno.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlAuthorisedSignDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAuthorisedSignDesignation.SelectedItem.Text.ToUpper() == "OTHER")
            {
                trAuthSignatoryDesignation.Visible = true;
            }
            else trAuthSignatoryDesignation.Visible = false;
        }
        protected void rblGHMC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblSector.SelectedValue != "1")   // sector is not service 
            {
                if (rblGHMC.SelectedValue == "0")
                {
                    divIsIALA.Visible = true;
                }
                else
                {
                    divIsIALA.Visible = false;
                }
            }
            else
            {
                divIsIALA.Visible = false;
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
        protected void rdIaLa_Lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdIaLa_Lst.SelectedValue == "Y")
            {
                divIndusParkList.Visible = true;
                BindIndustrialParks();
                //rblGHMC.SelectedValue = "0";
            }
            else
            {
                divIndusParkList.Visible = false;
                ddlIndustrialParkName.Items.Clear();
                // rblGHMC.SelectedValue = "1";
            }
        }

        private void BindIndustrialParks()
        {
            try
            {
                DataSet dsParks = new DataSet();
                int DistrictCd = Convert.ToInt32(ddlUnitDIst.SelectedValue);
                ddlIndustrialParkName.Items.Clear();
                dsParks = Gen.GetIALAParks_Incentives(0, DistrictCd);
                if (dsParks != null && dsParks.Tables.Count > 0 && dsParks.Tables[0].Rows.Count > 0)
                {
                    ddlIndustrialParkName.DataSource = dsParks.Tables[0];
                    ddlIndustrialParkName.DataValueField = "IALA_Cd";
                    ddlIndustrialParkName.DataTextField = "NameofIALA";
                    ddlIndustrialParkName.DataBind();
                    AddSelect(ddlIndustrialParkName);
                }
                else
                {
                    ddlIndustrialParkName.Items.Clear();
                    AddSelect(ddlIndustrialParkName);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }


        //public string InsertCommonDataUpdate(IncentivesVOs objvo1)
        //{
        //    string str = ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString;
        //    string valid = "";
        //    SqlConnection connection = new SqlConnection(str);
        //    SqlTransaction transaction = null;
        //    connection.Open();
        //    transaction = connection.BeginTransaction();

        //    try
        //    {
        //        SqlCommand com = new SqlCommand();
        //        com.CommandType = CommandType.StoredProcedure;
        //        com.CommandText = "[USP_INSERT_INCENTIVES_DATA_COMMON]";
        //        com.Transaction = transaction;
        //        com.Connection = connection;
        //        // Level 1 Page
        //        com.Parameters.AddWithValue("@SectorID", objvo1.sector);
        //        com.Parameters.AddWithValue("@UdyogAadharType", objvo1.UdyogAadharType);
        //        com.Parameters.AddWithValue("@EMiUdyogAadhar", objvo1.EMiUdyogAadhar);
        //        com.Parameters.AddWithValue("@UdyogAadharRegdDate", objvo1.UdyogAadharRegdDate);
        //        com.Parameters.AddWithValue("@UnitName", objvo1.UnitName);
        //        com.Parameters.AddWithValue("@ApplicantName", objvo1.ApplciantName);
        //        com.Parameters.AddWithValue("@TinNO", objvo1.TinNO);
        //        com.Parameters.AddWithValue("@PanNo", objvo1.PanNo);
        //        com.Parameters.AddWithValue("@IsDifferentlyAbled", objvo1.IsDifferentlyAbled);
        //        com.Parameters.AddWithValue("@IsMinority", objvo1.IsMinority);
        //        com.Parameters.AddWithValue("@DCP", objvo1.DateOfComm);
        //        com.Parameters.AddWithValue("@Gender", objvo1.Gender);
        //        com.Parameters.AddWithValue("@SocialStatus", Convert.ToInt32(objvo1.SocialStatus));
        //        com.Parameters.AddWithValue("@SubCaste", objvo1.SubCaste);
        //        com.Parameters.AddWithValue("@isVehicleIncentive", objvo1.isVehicleIncentive);
        //        com.Parameters.AddWithValue("@VehicleNumber", objvo1.VehicleNumber);
        //        com.Parameters.AddWithValue("@UnitState", objvo1.UnitState);
        //        com.Parameters.AddWithValue("@UnitDIst", objvo1.UnitDIst);
        //        com.Parameters.AddWithValue("@UnitMandal", objvo1.UnitMandal);
        //        com.Parameters.AddWithValue("@UnitVill", objvo1.UnitVill);
        //        com.Parameters.AddWithValue("@UnitStreet", objvo1.UnitStreet);
        //        com.Parameters.AddWithValue("@UnitHNO", objvo1.UnitHNO);
        //        com.Parameters.AddWithValue("@UnitMObileNo", objvo1.UnitMObileNo);
        //        com.Parameters.AddWithValue("@UnitEmail", objvo1.UnitEmail);
        //        com.Parameters.AddWithValue("@OffcState", objvo1.OffcState);
        //        com.Parameters.AddWithValue("@OffcOtherDist", objvo1.OffcOtherDist);
        //        com.Parameters.AddWithValue("@OffcOtherMandal", objvo1.OffcOtherMandal);
        //        com.Parameters.AddWithValue("@OffcOtherVillage", objvo1.OffcOtherVillage);
        //        com.Parameters.AddWithValue("@OffcDIst", objvo1.OffcDIst);
        //        com.Parameters.AddWithValue("@OffcMandal", objvo1.OffcMandal);
        //        com.Parameters.AddWithValue("@OffcVill", objvo1.OffcVil);
        //        com.Parameters.AddWithValue("@OffcHNO", objvo1.OffcHNO);
        //        com.Parameters.AddWithValue("@OffcStreet", objvo1.OffcStreet);
        //        com.Parameters.AddWithValue("@OffcEmail", objvo1.OffcEmail);
        //        com.Parameters.AddWithValue("@OffcMobileNO", objvo1.OffcMobileNO);
        //        com.Parameters.AddWithValue("@OrgType", objvo1.TypeofOrg);
        //        com.Parameters.AddWithValue("@IsGHMCandOtherMuncpOrp", objvo1.IsGHMCandOtherMuncpOrp);
        //        com.Parameters.AddWithValue("@isIALA", objvo1.isIALA);
        //        com.Parameters.AddWithValue("@IndusParkList", objvo1.IndusParkList);
        //        com.Parameters.AddWithValue("@NatureOfActivity", objvo1.natureOfAct);
        //        com.Parameters.AddWithValue("@NatureofBussiness", objvo1.NatureofBussiness);
        //        com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
        //        com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);

        //        com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
        //        com.Parameters["@Valid"].Direction = ParameterDirection.Output;
        //        com.ExecuteNonQuery();

        //        valid = com.Parameters["@Valid"].Value.ToString();

        //        transaction.Commit();
        //        connection.Close();
        //        // End Level 1 Page


        //        //Level 2 Page
        //        #region Commented Code
        //        //com.Parameters.AddWithValue("@Category", objvo1.Category);

        //        //com.Parameters.AddWithValue("@IdsustryStatus", objvo1.IdsustryStatus);
        //        //com.Parameters.AddWithValue("@ExistingPercentageincreaseunderExpansionORDiversification", objvo1.ExistingPercentageincreaseunderExpansionORDiversification);
        //        //com.Parameters.AddWithValue("@ExpansionDiversificationLOA", objvo1.ExpansionDiversificationLOA);
        //        //com.Parameters.AddWithValue("@ExistingInstalledCapacityinEnter", objvo1.ExistingInstalledCapacityinEnter);
        //        //com.Parameters.AddWithValue("@ExpanORDiversInstalledCapacityinEnter", objvo1.ExpanORDiversInstalledCapacityinEnter);
        //        //com.Parameters.AddWithValue("@ExpanORDiversPercentIncreaseunderExpansionORDiversification", objvo1.ExpanORDiversPercentIncreaseunderExpansionORDiversification);
        //        //com.Parameters.AddWithValue("@ExistEnterpriseLand", objvo1.ExistEnterpriseLand);
        //        //com.Parameters.AddWithValue("@ExistEnterpriseBuilding", objvo1.ExistEnterpriseBuilding);
        //        //com.Parameters.AddWithValue("@ExistEnterprisePlantMachinery", objvo1.ExistEnterprisePlantMachinery);
        //        //com.Parameters.AddWithValue("@ExpansionDiversificationLand", objvo1.ExpansionDiversificationLand);
        //        //com.Parameters.AddWithValue("@ExpDiversBuilding", objvo1.ExpDiversBuilding);
        //        //com.Parameters.AddWithValue("@ExpDiversPlantMachinery", objvo1.ExpDiversPlantMachinery);
        //        //com.Parameters.AddWithValue("@LandFixedCapitalInvestPercentage", objvo1.LandFixedCapitalInvestPercentage);
        //        //com.Parameters.AddWithValue("@LandFixedCapitalInvestPercentage", null);
        //        //com.Parameters.AddWithValue("@BuildingFixedCapitalInvestPercentage", objvo1.BuildingFixedCapitalInvestPercentage);
        //        //com.Parameters.AddWithValue("@PlantMachFixedCapitalInvestPercentage", objvo1.PlantMachFixedCapitalInvestPercentage);

        //        //com.Parameters.AddWithValue("@NewPowerReleaseDate", objvo1.NewPowerReleaseDate);
        //        //com.Parameters.AddWithValue("@NewConnectedLoad", objvo1.NewConnectedLoad);
        //        //com.Parameters.AddWithValue("@NewContractedLoad", objvo1.NewContractedLoad);
        //        //com.Parameters.AddWithValue("@ServiceConnectionNO", objvo1.ServiceConnectionNO);
        //        //com.Parameters.AddWithValue("@ExistingConnectedLoad", objvo1.ExistingConnectedLoad);
        //        //com.Parameters.AddWithValue("@ExistingContractedLoad", objvo1.ExistingContractedLoad);
        //        //com.Parameters.AddWithValue("@ExistingPowerReleaseDate", objvo1.ExistingPowerReleaseDate);
        //        //com.Parameters.AddWithValue("@ExistingServiceConnectionNO", objvo1.ExistingServiceConnectionNO);
        //        //com.Parameters.AddWithValue("@ExpanDiverConnectedLoad", objvo1.ExpanDiverConnectedLoad);
        //        //com.Parameters.AddWithValue("@ExpanDiverContractedLoad", objvo1.ExpanDiverContractedLoad);
        //        //com.Parameters.AddWithValue("@ExpanDiverPowerReleaseDate", objvo1.ExpanDiverPowerReleaseDate);
        //        //com.Parameters.AddWithValue("@ExpanDiverServiceConnectionNO", objvo1.ExpanDiverServiceConnectionNO);
        //        //com.Parameters.AddWithValue("@ManagementStaffMale", objvo1.ManagementStaffMale);
        //        //com.Parameters.AddWithValue("@ManagementStaffFemale", objvo1.ManagementStaffFemale);
        //        //com.Parameters.AddWithValue("@SupervisoryMale", objvo1.SupervisoryMale);
        //        //com.Parameters.AddWithValue("@SupervisoryFemale", objvo1.SupervisoryFemale);
        //        //com.Parameters.AddWithValue("@SkilledWorkersMale", objvo1.SkilledWorkersMale);
        //        //com.Parameters.AddWithValue("@SkilledWorkersFemale", objvo1.SkilledWorkersFemale);
        //        //com.Parameters.AddWithValue("@SemiSkilledWorkersMale", objvo1.SemiSkilledWorkersMale);
        //        //com.Parameters.AddWithValue("@SemiSkilledWorkersFemale", objvo1.SemiSkilledWorkersFemale);
        //        //com.Parameters.AddWithValue("@ProjectFinance", objvo1.ProjectFinance);
        //        //com.Parameters.AddWithValue("@TermLoanApplDate", objvo1.TermLoanApplDate);
        //        //com.Parameters.AddWithValue("@InstitutionName", objvo1.InstitutionName);
        //        //com.Parameters.AddWithValue("@TermLoanSancRefNo", objvo1.TermLoanSancRefNo);
        //        //com.Parameters.AddWithValue("@SecondHandMachVal", objvo1.SecondHandMachVal);
        //        //com.Parameters.AddWithValue("@ExistingEnterpriseLOA", objvo1.ExistingEnterpriseLOA);
        //        //com.Parameters.AddWithValue("@NewMachVal", objvo1.NewMachVal);
        //        //com.Parameters.AddWithValue("@Newand2ndlMachTotVal", objvo1.Newand2ndlMachTotVal);
        //        //com.Parameters.AddWithValue("@PercentageSHMValinTotMachVal", objvo1.PercentageSHMValinTotMachVal);
        //        //com.Parameters.AddWithValue("@MachValPrchasedfromAPIDCorAPSFCBank", objvo1.MachValPrchasedfromAPIDCorAPSFCBank);
        //        //com.Parameters.AddWithValue("@TotalMachVal", objvo1.TotalMachVal);
        //        //com.Parameters.AddWithValue("@BankName", objvo1.BankName);
        //        //com.Parameters.AddWithValue("@AccNo", objvo1.AccNo);
        //        //com.Parameters.AddWithValue("@BranchName", objvo1.BranchName);
        //        //com.Parameters.AddWithValue("@IFSCCode", objvo1.IFSCCode);
        //        //com.Parameters.AddWithValue("@WhetherPower", objvo1.WhetherPower);
        //        //com.Parameters.AddWithValue("@RequesttoDept", objvo1.RequesttoDept);






        //        //com.Parameters.AddWithValue("@VATNo", objvo1.Vatno);
        //        //com.Parameters.AddWithValue("@CSTNo", objvo1.Cstno);

        //        //com.Parameters.AddWithValue("@CSTRegDate", objvo1.CSTRegDate);
        //        //com.Parameters.AddWithValue("@CSTRegAuthority", objvo1.CSTRegAuthority);
        //        //com.Parameters.AddWithValue("@CSTRegAuthAddress", objvo1.CSTRegAuthAddress);
        //        //com.Parameters.AddWithValue("@PowerType", Convert.ToInt32(objvo1.PowerStatus));

        //        //com.Parameters.AddWithValue("@isSecondHandMachVal", objvo1.isSecondHandMachVal);
        //        //com.Parameters.AddWithValue("@TermLoanSanDate", objvo1.TermLoanApplDate);
        //        //com.Parameters.AddWithValue("@eepinscapUnit", objvo1.eepinscapUnit);
        //        //com.Parameters.AddWithValue("@edpinscapUnit", objvo1.edpinscapUnit);



        //        //com.Parameters.AddWithValue("@EMPartNo", objvo1.EMPart);

        //        //com.Parameters.AddWithValue("@GSTNO", objvo1.GSTNO);
        //        //com.Parameters.AddWithValue("@GSTDate", objvo1.GSTDate);
        //        //com.Parameters.AddWithValue("@IndusExpanType", objvo1.IndustryExpansionType);
        //        //com.Parameters.AddWithValue("@PowNewConnectUnit", objvo1.PowNewConnectUnit);
        //        //com.Parameters.AddWithValue("@PowNewContractUnit", objvo1.PowNewContractUnit);
        //        //com.Parameters.AddWithValue("@PowExistConnectUnit", objvo1.PowExistConnectUnit);
        //        //com.Parameters.AddWithValue("@PowExistContractUnit", objvo1.PowExistContractUnit);
        //        //com.Parameters.AddWithValue("@PowDiversConnectUnit", objvo1.PowDiversConnectUnit);
        //        //com.Parameters.AddWithValue("@PowDiversContractUnit", objvo1.PowDiversContractUnit);
        //        //com.Parameters.AddWithValue("@IsPowerApplicable", objvo1.IsPowerApplicable);
        //        //com.Parameters.AddWithValue("@AuthorisedSignatory", objvo1.AuthorisedSignatory);

        //        //com.Parameters.AddWithValue("@IsTermLoanAvailed", objvo1.IsTermLoanAvailed);
        //        //com.Parameters.AddWithValue("@BankAccType", objvo1.BankAccType);
        //        //com.Parameters.AddWithValue("@BankAccountName", objvo1.BankAccName);

        //        //com.Parameters.AddWithValue("@AuthorisedSignatoryDesignation", objvo1.AuthorisedSignatoryDesignation);

        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        transaction.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //        connection.Dispose();
        //    }
        //    return valid;
        //}


        public string InsertIncentivCommonData(IncentivesVOs objvo1)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSERT_INCENTIVES_DATA_COMMON_New";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);
                if (objvo1.sector != null)
                    com.Parameters.AddWithValue("@SectorID", objvo1.sector);
                else
                    com.Parameters.AddWithValue("@SectorID", null);
                if (objvo1.Uid_NO != null)
                    com.Parameters.AddWithValue("@Uid_NO", objvo1.Uid_NO);
                else
                    com.Parameters.AddWithValue("@Uid_NO", null);

                if (objvo1.UdyogAadharType != null)
                    com.Parameters.AddWithValue("@UdyogAadharType", objvo1.UdyogAadharType);
                else
                    com.Parameters.AddWithValue("@UdyogAadharType", null);

                if (objvo1.EMiUdyogAadhar != null)
                    com.Parameters.AddWithValue("@EMiUdyogAadhar", objvo1.EMiUdyogAadhar);
                else
                    com.Parameters.AddWithValue("@EMiUdyogAadhar", null);
                if (objvo1.UdyogAadharRegdDate != null)
                    com.Parameters.AddWithValue("@UdyogAadharRegdDate", objvo1.UdyogAadharRegdDate);
                else
                    com.Parameters.AddWithValue("@UdyogAadharRegdDate", null);


                if (objvo1.UnitName != null)
                    com.Parameters.AddWithValue("@UnitName", objvo1.UnitName);
                else
                    com.Parameters.AddWithValue("@UnitName", null);
                if (objvo1.ApplciantName != null)
                    com.Parameters.AddWithValue("@ApplicantName", objvo1.ApplciantName);
                else
                    com.Parameters.AddWithValue("@ApplicantName", null);
                if (objvo1.TinNO != null)
                    com.Parameters.AddWithValue("@TinNO", objvo1.TinNO);
                else
                    com.Parameters.AddWithValue("@TinNO", null);
                if (objvo1.PanNo != null)
                    com.Parameters.AddWithValue("@PanNo", objvo1.PanNo);
                else
                    com.Parameters.AddWithValue("@PanNo", null);

                if (objvo1.IsDifferentlyAbled != null)
                    com.Parameters.AddWithValue("@IsDifferentlyAbled", objvo1.IsDifferentlyAbled);
                else
                    com.Parameters.AddWithValue("@IsDifferentlyAbled", null);

                if (objvo1.IsMinority != null)
                    com.Parameters.AddWithValue("@IsMinority", objvo1.IsMinority);
                else
                    com.Parameters.AddWithValue("@IsMinority", null);
                if (objvo1.DateOfComm != null)
                    com.Parameters.AddWithValue("@DCP", objvo1.DateOfComm);
                else
                    com.Parameters.AddWithValue("@DCP", null);
                if (objvo1.Gender != null)
                    com.Parameters.AddWithValue("@Gender", objvo1.Gender);
                else
                    com.Parameters.AddWithValue("@Gender", null);

                if (objvo1.SocialStatus != null)
                    com.Parameters.AddWithValue("@SocialStatus", Convert.ToInt32(objvo1.SocialStatus));
                else
                    com.Parameters.AddWithValue("@SocialStatus", null);
                if (objvo1.SubCaste != null)
                    com.Parameters.AddWithValue("@SubCaste", objvo1.SubCaste);
                else
                    com.Parameters.AddWithValue("@SubCaste", null);
                if (objvo1.isVehicleIncentive != null)
                    com.Parameters.AddWithValue("@isVehicleIncentive", objvo1.isVehicleIncentive);
                else
                    com.Parameters.AddWithValue("@isVehicleIncentive", null);

                if (objvo1.VehicleNumber != null)
                    com.Parameters.AddWithValue("@VehicleNumber", objvo1.VehicleNumber);
                else
                    com.Parameters.AddWithValue("@VehicleNumber", null);
                if (objvo1.User_Id != null)
                    com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                else
                    com.Parameters.AddWithValue("@CreatedBy", null);
                if (objvo1.UnitState != null)
                    com.Parameters.AddWithValue("@UnitState", objvo1.UnitState);
                else
                    com.Parameters.AddWithValue("@UnitState", null);

                if (objvo1.UnitDIst != null)
                    com.Parameters.AddWithValue("@UnitDIst", objvo1.UnitDIst);
                else
                    com.Parameters.AddWithValue("@UnitDIst", null);
                if (objvo1.UnitMandal != null)
                    com.Parameters.AddWithValue("@UnitMandal", objvo1.UnitMandal);
                else
                    com.Parameters.AddWithValue("@UnitMandal", null);
                if (objvo1.UnitVill != null)
                    com.Parameters.AddWithValue("@UnitVill", objvo1.UnitVill);
                else
                    com.Parameters.AddWithValue("@UnitVill", null);
                if (objvo1.UnitStreet != null)
                    com.Parameters.AddWithValue("@UnitStreet", objvo1.UnitStreet);
                else
                    com.Parameters.AddWithValue("@UnitStreet", null);
                if (objvo1.UnitHNO != null)
                    com.Parameters.AddWithValue("@UnitHNO", objvo1.UnitHNO);
                else
                    com.Parameters.AddWithValue("@UnitHNO", null);
                if (objvo1.UnitMObileNo != null)
                    com.Parameters.AddWithValue("@UnitMObileNo", objvo1.UnitMObileNo);
                else
                    com.Parameters.AddWithValue("@UnitMObileNo", null);
                if (objvo1.UnitEmail != null)
                    com.Parameters.AddWithValue("@UnitEmail", objvo1.UnitEmail);
                else
                    com.Parameters.AddWithValue("@UnitEmail", null);
                if (objvo1.OffcState != null)
                    com.Parameters.AddWithValue("@OffcState", objvo1.OffcState);
                else
                    com.Parameters.AddWithValue("@OffcState", null);

                if (objvo1.OffcOtherDist != null)
                    com.Parameters.AddWithValue("@OffcOtherDist", objvo1.OffcOtherDist);
                else
                    com.Parameters.AddWithValue("@OffcOtherDist", null);

                if (objvo1.OffcOtherMandal != null)
                    com.Parameters.AddWithValue("@OffcOtherMandal", objvo1.OffcOtherMandal);
                else
                    com.Parameters.AddWithValue("@OffcOtherMandal", null);

                if (objvo1.OffcOtherVillage != null)
                    com.Parameters.AddWithValue("@OffcOtherVillage", objvo1.OffcOtherVillage);
                else
                    com.Parameters.AddWithValue("@OffcOtherVillage", null);
                if (objvo1.OffcDIst != null)
                    com.Parameters.AddWithValue("@OffcDIst", objvo1.OffcDIst);
                else
                    com.Parameters.AddWithValue("@OffcDIst", null);
                if (objvo1.OffcMandal != null)
                    com.Parameters.AddWithValue("@OffcMandal", objvo1.OffcMandal);
                else
                    com.Parameters.AddWithValue("@OffcMandal", null);
                if (objvo1.OffcVil != null)
                    com.Parameters.AddWithValue("@OffcVill", objvo1.OffcVil);
                else
                    com.Parameters.AddWithValue("@OffcVill", null);
                if (objvo1.OffcHNO != null)
                    com.Parameters.AddWithValue("@OffcHNO", objvo1.OffcHNO);
                else
                    com.Parameters.AddWithValue("@OffcHNO", null);
                if (objvo1.OffcStreet != null)
                    com.Parameters.AddWithValue("@OffcStreet", objvo1.OffcStreet);
                else
                    com.Parameters.AddWithValue("@OffcStreet", null);
                if (objvo1.OffcEmail != null)
                    com.Parameters.AddWithValue("@OffcEmail", objvo1.OffcEmail);
                else
                    com.Parameters.AddWithValue("@OffcEmail", null);
                if (objvo1.OffcMobileNO != null)
                    com.Parameters.AddWithValue("@OffcMobileNO", objvo1.OffcMobileNO);
                else
                    com.Parameters.AddWithValue("@OffcMobileNO", null);

                if (objvo1.TypeofOrg != null)
                    com.Parameters.AddWithValue("@OrgType", objvo1.TypeofOrg);
                else
                    com.Parameters.AddWithValue("@OrgType", null);

                if (objvo1.IsGHMCandOtherMuncpOrp != null)
                    com.Parameters.AddWithValue("@IsGHMCandOtherMuncpOrp", objvo1.IsGHMCandOtherMuncpOrp);
                else
                    com.Parameters.AddWithValue("@IsGHMCandOtherMuncpOrp", null);

                if (objvo1.isIALA != null)
                    com.Parameters.AddWithValue("@isIALA", objvo1.isIALA);
                else
                    com.Parameters.AddWithValue("@isIALA", null);

                if (objvo1.IndusParkList != null)
                    com.Parameters.AddWithValue("@IndusParkList", objvo1.IndusParkList);
                else
                    com.Parameters.AddWithValue("@IndusParkList", null);

                //if (objvo1.natureOfAct != null)
                //    com.Parameters.AddWithValue("@NatureOfActivity", objvo1.natureOfAct);
                //else
                //    com.Parameters.AddWithValue("@NatureOfActivity", null);
                if (objvo1.NatureofBussiness != null)
                    com.Parameters.AddWithValue("@NatureofBussiness", objvo1.NatureofBussiness);
                else
                    com.Parameters.AddWithValue("@NatureofBussiness", null);
                if (objvo1.AppsLevel != null)
                    com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
                else
                    com.Parameters.AddWithValue("@AppsLevel", null);

                //Added for TTap
                if (objvo1.DateOfIncorporation != null)
                    com.Parameters.AddWithValue("@DateOfIncorporation", objvo1.DateOfIncorporation);
                else
                    com.Parameters.AddWithValue("@DateOfIncorporation", null);
                if (objvo1.IncorpRegistranNumber != null)
                    com.Parameters.AddWithValue("@IncorpRegistranNumber", objvo1.IncorpRegistranNumber);
                else
                    com.Parameters.AddWithValue("@IncorpRegistranNumber", null);
                if (objvo1.CountryOrigin != null)
                    com.Parameters.AddWithValue("@CountryOrigin", objvo1.CountryOrigin);
                else
                    com.Parameters.AddWithValue("@CountryOrigin", null);
                if (objvo1.TextileProcessType != null)
                    com.Parameters.AddWithValue("@TextileProcessType", objvo1.TextileProcessType);
                else
                    com.Parameters.AddWithValue("@TextileProcessType", null);
                if (objvo1.YearsOfExpinTexttile != null)
                    com.Parameters.AddWithValue("@YearsOfExpinTexttile", objvo1.YearsOfExpinTexttile);
                else
                    com.Parameters.AddWithValue("@YearsOfExpinTexttile", null);
                if (objvo1.EducationalQual != null)
                    com.Parameters.AddWithValue("@EducationalQual", objvo1.EducationalQual);
                else
                    com.Parameters.AddWithValue("@EducationalQual", null);

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
                //string message = "alert('" + ex.Message+ "')";
                //ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", message, true);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }

        public string InsertIncentivCommonDataStep2(IncentivesVOs objvo1, List<IndustryLineofActivities> LstNewInds, List<IndustryLineofActivities> LstExpInds)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSERT_INCENTIVES_DATA_COMMON_New";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);

                if (objvo1.IdsustryStatus != null)
                    com.Parameters.AddWithValue("@IdsustryStatus", objvo1.IdsustryStatus);
                else
                    com.Parameters.AddWithValue("@IdsustryStatus", null);

                if (objvo1.IndustryExpansionType != null)
                    com.Parameters.AddWithValue("@IndusExpanType", objvo1.IndustryExpansionType);
                else
                    com.Parameters.AddWithValue("@IndusExpanType", null);
                if (objvo1.Category != null)
                    com.Parameters.AddWithValue("@Category", objvo1.Category);
                else
                    com.Parameters.AddWithValue("@Category", null);


                if (objvo1.ExistingEnterpriseLOA != null)
                    com.Parameters.AddWithValue("@ExistingEnterpriseLOA", objvo1.ExistingEnterpriseLOA);
                else
                    com.Parameters.AddWithValue("@ExistingEnterpriseLOA", null);
                if (objvo1.ExistingInstalledCapacityinEnter != null)
                    com.Parameters.AddWithValue("@ExistingInstalledCapacityinEnter", objvo1.ExistingInstalledCapacityinEnter);
                else
                    com.Parameters.AddWithValue("@ExistingInstalledCapacityinEnter", null);
                if (objvo1.ExistingPercentageincreaseunderExpansionORDiversification != null)
                    com.Parameters.AddWithValue("@ExistingPercentageincreaseunderExpansionORDiversification", objvo1.ExistingPercentageincreaseunderExpansionORDiversification);
                else
                    com.Parameters.AddWithValue("@ExistingPercentageincreaseunderExpansionORDiversification", null);

                if (objvo1.ExpansionDiversificationLOA != null)
                    com.Parameters.AddWithValue("@ExpansionDiversificationLOA", objvo1.ExpansionDiversificationLOA);
                else
                    com.Parameters.AddWithValue("@ExpansionDiversificationLOA", null);
                if (objvo1.ExpanORDiversInstalledCapacityinEnter != null)
                    com.Parameters.AddWithValue("@ExpanORDiversInstalledCapacityinEnter", objvo1.ExpanORDiversInstalledCapacityinEnter);
                else
                    com.Parameters.AddWithValue("@ExpanORDiversInstalledCapacityinEnter", null);
                if (objvo1.ExpanORDiversPercentIncreaseunderExpansionORDiversification != null)
                    com.Parameters.AddWithValue("@ExpanORDiversPercentIncreaseunderExpansionORDiversification", objvo1.ExpanORDiversPercentIncreaseunderExpansionORDiversification);
                else
                    com.Parameters.AddWithValue("@ExpanORDiversPercentIncreaseunderExpansionORDiversification", null);
                if (objvo1.ExistEnterpriseLand != null)
                    com.Parameters.AddWithValue("@ExistEnterpriseLand", objvo1.ExistEnterpriseLand);
                else
                    com.Parameters.AddWithValue("@ExistEnterpriseLand", null);
                if (objvo1.ExpansionDiversificationLand != null)
                    com.Parameters.AddWithValue("@ExpansionDiversificationLand", objvo1.ExpansionDiversificationLand);
                else
                    com.Parameters.AddWithValue("@ExpansionDiversificationLand", null);
                if (objvo1.LandFixedCapitalInvestPercentage != null)
                    com.Parameters.AddWithValue("@LandFixedCapitalInvestPercentage", objvo1.LandFixedCapitalInvestPercentage);
                else
                    com.Parameters.AddWithValue("@LandFixedCapitalInvestPercentage", null);
                if (objvo1.ExistEnterpriseBuilding != null)
                    com.Parameters.AddWithValue("@ExistEnterpriseBuilding", objvo1.ExistEnterpriseBuilding);
                else
                    com.Parameters.AddWithValue("@ExistEnterpriseBuilding", null);
                if (objvo1.ExpDiversBuilding != null)
                    com.Parameters.AddWithValue("@ExpDiversBuilding", objvo1.ExpDiversBuilding);
                else
                    com.Parameters.AddWithValue("@ExpDiversBuilding", null);
                if (objvo1.BuildingFixedCapitalInvestPercentage != null)
                    com.Parameters.AddWithValue("@BuildingFixedCapitalInvestPercentage", objvo1.BuildingFixedCapitalInvestPercentage);
                else
                    com.Parameters.AddWithValue("@BuildingFixedCapitalInvestPercentage", null);

                if (objvo1.ExistEnterprisePlantMachinery != null)
                    com.Parameters.AddWithValue("@ExistEnterprisePlantMachinery", objvo1.ExistEnterprisePlantMachinery);
                else
                    com.Parameters.AddWithValue("@ExistEnterprisePlantMachinery", null);

                if (objvo1.ExpDiversPlantMachinery != null)
                    com.Parameters.AddWithValue("@ExpDiversPlantMachinery", objvo1.ExpDiversPlantMachinery);
                else
                    com.Parameters.AddWithValue("@ExpDiversPlantMachinery", null);
                if (objvo1.PlantMachFixedCapitalInvestPercentage != null)
                    com.Parameters.AddWithValue("@PlantMachFixedCapitalInvestPercentage", objvo1.PlantMachFixedCapitalInvestPercentage);
                else
                    com.Parameters.AddWithValue("@PlantMachFixedCapitalInvestPercentage", null);

                if (objvo1.User_Id != null)
                    com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                else
                    com.Parameters.AddWithValue("@CreatedBy", null);
                if (objvo1.AppsLevel != null)
                    com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
                else
                    com.Parameters.AddWithValue("@AppsLevel", null);
                if (objvo1.Percentge_FixedCapitalInvestment != null)
                    com.Parameters.AddWithValue("@Percentge_FixedCapitalInvestment", objvo1.Percentge_FixedCapitalInvestment);
                else
                    com.Parameters.AddWithValue("@Percentge_FixedCapitalInvestment", null);
                if (objvo1.Nature_Industry != null)
                    com.Parameters.AddWithValue("@Nature_Industry", objvo1.Nature_Industry);
                else
                    com.Parameters.AddWithValue("@Nature_Industry", null);
                if (objvo1.InstalledCapacityperAnnum != null)
                    com.Parameters.AddWithValue("@InstalledCapacityperAnnum", objvo1.InstalledCapacityperAnnum);
                else
                    com.Parameters.AddWithValue("@InstalledCapacityperAnnum", null);
                if (objvo1.WhetherAllotedByGovt != null)
                    com.Parameters.AddWithValue("@WhetherAllotedByGovt", objvo1.WhetherAllotedByGovt);
                else
                    com.Parameters.AddWithValue("@WhetherAllotedByGovt", null);
                if (objvo1.CategoryTTAP != null)
                    com.Parameters.AddWithValue("@CategoryTTAP", objvo1.CategoryTTAP);
                else
                    com.Parameters.AddWithValue("@CategoryTTAP", null);

                #region Added by Naresh

                com.Parameters.AddWithValue("@PlinthArea", objvo1.PlinthArea);
                com.Parameters.AddWithValue("@RateperAcre", objvo1.RateperAcre);
                com.Parameters.AddWithValue("@TotalInvestment", objvo1.TotalInvestment);
                com.Parameters.AddWithValue("@Infrastructure1", objvo1.Infrastructure1);
                com.Parameters.AddWithValue("@Infrastructure2", objvo1.Infrastructure2);
                com.Parameters.AddWithValue("@Infrastructure3", objvo1.Infrastructure3);
                com.Parameters.AddWithValue("@OtherProductive1", objvo1.OtherProductive1);
                com.Parameters.AddWithValue("@OtherProductive2", objvo1.OtherProductive2);
                com.Parameters.AddWithValue("@OtherProductive3", objvo1.OtherProductive3);
                com.Parameters.AddWithValue("@TotalInvestmentBuilding", objvo1.TotalInvestmentBuilding);
                com.Parameters.AddWithValue("@Transportation", objvo1.Transportation);
                com.Parameters.AddWithValue("@Erection", objvo1.Erection);
                com.Parameters.AddWithValue("@Electrification", objvo1.Electrification);
                com.Parameters.AddWithValue("@OtherAssets", objvo1.OtherAssets);
                com.Parameters.AddWithValue("@TotalPlantMechinery", objvo1.TotalPlantMechinery);
                com.Parameters.AddWithValue("@TotalCapitalInvestment", objvo1.TotalCapitalInvestment);

                #endregion


                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                if (valid != "0")
                {
                    foreach (IndustryLineofActivities LstNewIndsNew in LstNewInds)
                    {
                        SqlCommand COMNew = new SqlCommand();
                        COMNew.CommandType = CommandType.StoredProcedure;
                        COMNew.CommandText = "USP_INS_LINEOFACTIVITY_NEWINDUSTRY";
                        COMNew.Transaction = transaction;
                        COMNew.Connection = connection;
                        COMNew.Parameters.AddWithValue("@slno", LstNewIndsNew.slno);
                        COMNew.Parameters.AddWithValue("@LineOfActivity", LstNewIndsNew.LineOfActivity);
                        COMNew.Parameters.AddWithValue("@InstalledCapacity", LstNewIndsNew.InstalledCapacity);
                        COMNew.Parameters.AddWithValue("@Unit", LstNewIndsNew.Unit);
                        COMNew.Parameters.AddWithValue("@ValueRs", LstNewIndsNew.ValueRs);
                        COMNew.Parameters.AddWithValue("@IncentiveId", LstNewIndsNew.IncentiveId);
                        COMNew.Parameters.AddWithValue("@Created_by", LstNewIndsNew.Created_by);
                        COMNew.ExecuteNonQuery();
                    }

                    foreach (IndustryLineofActivities LstExpIndsNew in LstExpInds)
                    {
                        SqlCommand COMNExp = new SqlCommand();
                        COMNExp.CommandType = CommandType.StoredProcedure;
                        COMNExp.CommandText = "USP_INS_LINEOFACTIVITY_NEWINDUSTRY";
                        COMNExp.Transaction = transaction;
                        COMNExp.Connection = connection;
                        COMNExp.Parameters.AddWithValue("@slno", LstExpIndsNew.slno);
                        COMNExp.Parameters.AddWithValue("@LineOfActivity", LstExpIndsNew.LineOfActivity);
                        COMNExp.Parameters.AddWithValue("@InstalledCapacity", LstExpIndsNew.InstalledCapacity);
                        COMNExp.Parameters.AddWithValue("@Unit", LstExpIndsNew.Unit);
                        COMNExp.Parameters.AddWithValue("@ValueRs", LstExpIndsNew.ValueRs);
                        COMNExp.Parameters.AddWithValue("@IncentiveId", LstExpIndsNew.IncentiveId);
                        COMNExp.Parameters.AddWithValue("@Created_by", LstExpIndsNew.Created_by);
                        COMNExp.Parameters.AddWithValue("@LOAType", LstExpIndsNew.LOAType);
                        COMNExp.ExecuteNonQuery();
                    }
                }
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

        public string InsertIncentivCommonDataStep3(IncentivesVOs objvo1, List<IndustryPartnerDtls> LstPatnerDtls)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSERT_INCENTIVES_DATA_COMMON_New";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);

                if (objvo1.AuthorisedSignatoryDesignation != null)
                    com.Parameters.AddWithValue("@AuthorisedSignatoryDesignation", objvo1.AuthorisedSignatoryDesignation);
                else
                    com.Parameters.AddWithValue("@AuthorisedSignatoryDesignation", null);

                if (objvo1.AuthorisedSignatoryDesignation != null)
                    com.Parameters.AddWithValue("@AuthorisedSignatoryDesignationValue", objvo1.AuthorisedSignatoryDesignationValue);
                else
                    com.Parameters.AddWithValue("@AuthorisedSignatoryDesignationValue", null);

                if (objvo1.AuthorisedSignatory != null)
                    com.Parameters.AddWithValue("@AuthorisedSignatory", objvo1.AuthorisedSignatory);
                else
                    com.Parameters.AddWithValue("@AuthorisedSignatory", null);
                if (objvo1.IsPowerApplicable != null)
                    com.Parameters.AddWithValue("@IsPowerApplicable", objvo1.IsPowerApplicable);
                else
                    com.Parameters.AddWithValue("@IsPowerApplicable", null);

                if (objvo1.IsPowerApplicable != null)
                    com.Parameters.AddWithValue("@IsPowerApplicableValue", objvo1.IsPowerApplicableValues);
                else
                    com.Parameters.AddWithValue("@IsPowerApplicableValue", null);


                if (objvo1.NewPowerReleaseDate != null)
                    com.Parameters.AddWithValue("@NewPowerReleaseDate", objvo1.NewPowerReleaseDate);
                else
                    com.Parameters.AddWithValue("@NewPowerReleaseDate", null);
                if (objvo1.NewConnectedLoad != null)
                    com.Parameters.AddWithValue("@NewConnectedLoad", objvo1.NewConnectedLoad);
                else com.Parameters.AddWithValue("@NewConnectedLoad", null);

                if (objvo1.PowNewContractUnit != null)
                    com.Parameters.AddWithValue("@PowNewContractUnit", objvo1.PowNewContractUnit);
                else
                    com.Parameters.AddWithValue("@PowNewContractUnit", null);

                if (objvo1.PowNewContractUnit != null)
                    com.Parameters.AddWithValue("@PowNewContractUnitValue", objvo1.PowNewContractUnitValue);
                else
                    com.Parameters.AddWithValue("@PowNewContractUnitValue", null);

                if (objvo1.ServiceConnectionNO != null)
                    com.Parameters.AddWithValue("@ServiceConnectionNO", objvo1.ServiceConnectionNO);
                else
                    com.Parameters.AddWithValue("@ServiceConnectionNO", null);
                if (objvo1.NewContractedLoad != null)
                    com.Parameters.AddWithValue("@NewContractedLoad", objvo1.NewContractedLoad);
                else
                    com.Parameters.AddWithValue("@NewContractedLoad", null);
                if (objvo1.PowNewConnectUnit != null)
                    com.Parameters.AddWithValue("@PowNewConnectUnit", objvo1.PowNewConnectUnit);
                else
                    com.Parameters.AddWithValue("@PowNewConnectUnit", null);

                if (objvo1.PowNewConnectUnit != null)
                    com.Parameters.AddWithValue("@PowNewConnectUnitValue", objvo1.PowNewConnectUnitValue);
                else
                    com.Parameters.AddWithValue("@PowNewConnectUnitValue", null);

                if (objvo1.ExistingPowerReleaseDate != null)
                    com.Parameters.AddWithValue("@ExistingPowerReleaseDate", objvo1.ExistingPowerReleaseDate);
                else
                    com.Parameters.AddWithValue("@ExistingPowerReleaseDate", null);
                if (objvo1.ExistingContractedLoad != null)
                    com.Parameters.AddWithValue("@ExistingContractedLoad", objvo1.ExistingContractedLoad);
                else
                    com.Parameters.AddWithValue("@ExistingContractedLoad", null);
                if (objvo1.PowExistContractUnit != null)
                    com.Parameters.AddWithValue("@PowExistContractUnit", objvo1.PowExistContractUnit);
                else
                    com.Parameters.AddWithValue("@PowExistContractUnit", null);

                if (objvo1.PowExistContractUnit != null)
                    com.Parameters.AddWithValue("@PowExistContractUnitValue", objvo1.PowExistContractUnitValue);
                else
                    com.Parameters.AddWithValue("@PowExistContractUnitValue", null);

                if (objvo1.ExistingServiceConnectionNO != null)
                    com.Parameters.AddWithValue("@ExistingServiceConnectionNO", objvo1.ExistingServiceConnectionNO);
                else
                    com.Parameters.AddWithValue("@ExistingServiceConnectionNO", null);

                if (objvo1.ExistingConnectedLoad != null)
                    com.Parameters.AddWithValue("@ExistingConnectedLoad", objvo1.ExistingConnectedLoad);
                else com.Parameters.AddWithValue("@ExistingConnectedLoad", null);
                if (objvo1.PowExistConnectUnit != null)
                    com.Parameters.AddWithValue("@PowExistConnectUnit", objvo1.PowExistConnectUnit);
                else
                    com.Parameters.AddWithValue("@PowExistConnectUnit", null);

                if (objvo1.PowExistConnectUnit != null)
                    com.Parameters.AddWithValue("@PowExistConnectUnitValue", objvo1.PowExistConnectUnitValue);
                else
                    com.Parameters.AddWithValue("@PowExistConnectUnitValue", null);

                if (objvo1.ExpanDiverPowerReleaseDate != null)
                    com.Parameters.AddWithValue("@ExpanDiverPowerReleaseDate", objvo1.ExpanDiverPowerReleaseDate);
                else
                    com.Parameters.AddWithValue("@ExpanDiverPowerReleaseDate", null);

                if (objvo1.ExpanDiverContractedLoad != null)
                    com.Parameters.AddWithValue("@ExpanDiverContractedLoad", objvo1.ExpanDiverContractedLoad);
                else
                    com.Parameters.AddWithValue("@ExpanDiverContractedLoad", null);
                if (objvo1.PowDiversContractUnit != null)
                    com.Parameters.AddWithValue("@PowDiversContractUnit", objvo1.PowDiversContractUnit);
                else
                    com.Parameters.AddWithValue("@PowDiversContractUnit", null);

                if (objvo1.PowDiversContractUnit != null)
                    com.Parameters.AddWithValue("@PowDiversContractUnitValue", objvo1.PowDiversContractUnitValue);
                else
                    com.Parameters.AddWithValue("@PowDiversContractUnitValue", null);


                if (objvo1.ExpanDiverServiceConnectionNO != null)
                    com.Parameters.AddWithValue("@ExpanDiverServiceConnectionNO", objvo1.ExpanDiverServiceConnectionNO);
                else
                    com.Parameters.AddWithValue("@ExpanDiverServiceConnectionNO", null);
                if (objvo1.ExpanDiverConnectedLoad != null)
                    com.Parameters.AddWithValue("@ExpanDiverConnectedLoad", objvo1.ExpanDiverConnectedLoad);
                else com.Parameters.AddWithValue("@ExpanDiverConnectedLoad", null);
                if (objvo1.PowDiversConnectUnit != null)
                    com.Parameters.AddWithValue("@PowDiversConnectUnit", objvo1.PowDiversConnectUnit);
                else
                    com.Parameters.AddWithValue("@PowDiversConnectUnit", null);


                if (objvo1.PowDiversConnectUnit != null)
                    com.Parameters.AddWithValue("@PowDiversConnectUnitValue", objvo1.PowDiversConnectUnitValue);
                else
                    com.Parameters.AddWithValue("@PowDiversConnectUnitValue", null);

                // Emp
                if (objvo1.ManagementStaffMale != null)
                    com.Parameters.AddWithValue("@ManagementStaffMale", objvo1.ManagementStaffMale);
                else
                    com.Parameters.AddWithValue("@ManagementStaffMale", null);
                if (objvo1.ManagementStaffFemale != null)
                    com.Parameters.AddWithValue("@ManagementStaffFemale", objvo1.ManagementStaffFemale);
                else
                    com.Parameters.AddWithValue("@ManagementStaffFemale", null);
                if (objvo1.SupervisoryMale != null)
                    com.Parameters.AddWithValue("@SupervisoryMale", objvo1.SupervisoryMale);
                else
                    com.Parameters.AddWithValue("@SupervisoryMale", null);
                if (objvo1.SupervisoryFemale != null)
                    com.Parameters.AddWithValue("@SupervisoryFemale", objvo1.SupervisoryFemale);
                else com.Parameters.AddWithValue("@SupervisoryFemale", null);
                if (objvo1.SkilledWorkersMale != null)
                    com.Parameters.AddWithValue("@SkilledWorkersMale", objvo1.SkilledWorkersMale);
                else
                    com.Parameters.AddWithValue("@SkilledWorkersMale", null);
                if (objvo1.SkilledWorkersFemale != null)
                    com.Parameters.AddWithValue("@SkilledWorkersFemale", objvo1.SkilledWorkersFemale);
                else
                    com.Parameters.AddWithValue("@SkilledWorkersFemale", null);

                if (objvo1.SemiSkilledWorkersMale != null)
                    com.Parameters.AddWithValue("@SemiSkilledWorkersMale", objvo1.SemiSkilledWorkersMale);
                else
                    com.Parameters.AddWithValue("@SemiSkilledWorkersMale", null);
                if (objvo1.SemiSkilledWorkersFemale != null)
                    com.Parameters.AddWithValue("@SemiSkilledWorkersFemale", objvo1.SemiSkilledWorkersFemale);
                else
                    com.Parameters.AddWithValue("@SemiSkilledWorkersFemale", null);

                if (objvo1.User_Id != null)
                    com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                else
                    com.Parameters.AddWithValue("@CreatedBy", null);
                if (objvo1.AppsLevel != null)
                    com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
                else
                    com.Parameters.AddWithValue("@AppsLevel", null);

                if (objvo1.Products_Manufactured != null)
                    com.Parameters.AddWithValue("@Products_Manufactured", objvo1.Products_Manufactured);
                else
                    com.Parameters.AddWithValue("@Products_Manufactured", null);
                if (objvo1.NO_OtherEstablishments != null)
                    com.Parameters.AddWithValue("@NO_OtherEstablishments", objvo1.NO_OtherEstablishments);
                else
                    com.Parameters.AddWithValue("@NO_OtherEstablishments", null);
                if (objvo1.Authorized_MobileNo != null)
                    com.Parameters.AddWithValue("@Authorized_MobileNo", objvo1.Authorized_MobileNo);
                else
                    com.Parameters.AddWithValue("@Authorized_MobileNo", null);
                if (objvo1.Authorized_EmailId != null)
                    com.Parameters.AddWithValue("@Authorized_EmailId", objvo1.Authorized_EmailId);
                else
                    com.Parameters.AddWithValue("@Authorized_EmailId", null);
                if (objvo1.Authorized_PAN_NO != null)
                    com.Parameters.AddWithValue("@Authorized_PAN_NO", objvo1.Authorized_PAN_NO);
                else
                    com.Parameters.AddWithValue("@Authorized_PAN_NO", null);
                if (objvo1.Authorized_CorresponAdderess != null)
                    com.Parameters.AddWithValue("@Authorized_CorresponAdderess", objvo1.Authorized_CorresponAdderess);
                else
                    com.Parameters.AddWithValue("@Authorized_CorresponAdderess", null);

                #region Added by Naresh
                com.Parameters.AddWithValue("@Source", objvo1.Source);
                com.Parameters.AddWithValue("@Requirement", objvo1.Requirement);
                com.Parameters.AddWithValue("@RateperUnit", objvo1.RateperUnit);
                com.Parameters.AddWithValue("@IsSubsidiesIncentives", objvo1.IsSubsidiesIncentives);
                com.Parameters.AddWithValue("@IsSubsidiesIncentivesAmount", objvo1.IsSubsidiesIncentivesAmount);
                com.Parameters.AddWithValue("@NameoftheScheme", objvo1.NameoftheScheme);

                com.Parameters.AddWithValue("@EstablishmentYear", objvo1.EstablishmentYear);
                com.Parameters.AddWithValue("@NumberofEmployees", objvo1.NumberofEmployees);

                #endregion

                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                if (valid != "0")
                {
                    foreach (IndustryPartnerDtls LstNewIndsNew in LstPatnerDtls)
                    {
                        SqlCommand COMNew = new SqlCommand();
                        COMNew.CommandType = CommandType.StoredProcedure;
                        COMNew.CommandText = "USP_INS_DIRECTORDTLS";
                        COMNew.Transaction = transaction;
                        COMNew.Connection = connection;
                        COMNew.Parameters.AddWithValue("@slno", LstNewIndsNew.Slno);
                        COMNew.Parameters.AddWithValue("@Name", LstNewIndsNew.Name);
                        COMNew.Parameters.AddWithValue("@Community", LstNewIndsNew.Community);
                        COMNew.Parameters.AddWithValue("@Gender", LstNewIndsNew.Gender);
                        COMNew.Parameters.AddWithValue("@Share", LstNewIndsNew.Share);
                        COMNew.Parameters.AddWithValue("@MobileNo", LstNewIndsNew.MobileNo);
                        COMNew.Parameters.AddWithValue("@Email", LstNewIndsNew.Email);
                        COMNew.Parameters.AddWithValue("@PanNO", LstNewIndsNew.PanNO);

                        COMNew.Parameters.AddWithValue("@Designation", LstNewIndsNew.Designation);
                        COMNew.Parameters.AddWithValue("@IncentiveId", LstNewIndsNew.IncentiveId);
                        COMNew.Parameters.AddWithValue("@Created_by", LstNewIndsNew.Created_by);
                        COMNew.ExecuteNonQuery();
                    }
                }
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

        public string InsertIncentivCommonDataStep4(IncentivesVOs objvo1, List<IndustryTermLoanDtls> VoIndustryTermLoanDtls)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSERT_INCENTIVES_DATA_COMMON_New";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);
                if (objvo1.IsTermLoanAvailed != null)
                    com.Parameters.AddWithValue("@IsTermLoanAvailed", objvo1.IsTermLoanAvailed);
                else
                    com.Parameters.AddWithValue("@IsTermLoanAvailed", null);
                //-----------------------------------------------------------------------------------------------------------------
                if (objvo1.isSecondHandMachVal != null)
                    com.Parameters.AddWithValue("@isSecondHandMachVal", objvo1.isSecondHandMachVal);
                else
                    com.Parameters.AddWithValue("@isSecondHandMachVal", null);

                if (objvo1.isSecondHandMachValValue != null)
                    com.Parameters.AddWithValue("@isSecondHandMachValValue", objvo1.isSecondHandMachValValue);
                else
                    com.Parameters.AddWithValue("@isSecondHandMachValValue", null);
                if (objvo1.SecondHandMachVal != null)
                    com.Parameters.AddWithValue("@SecondHandMachVal", objvo1.SecondHandMachVal);
                else
                    com.Parameters.AddWithValue("@SecondHandMachVal", null);
                if (objvo1.NewMachVal != null)
                    com.Parameters.AddWithValue("@NewMachVal", objvo1.NewMachVal);
                else
                    com.Parameters.AddWithValue("@NewMachVal", null);
                if (objvo1.Newand2ndlMachTotVal != null)
                    com.Parameters.AddWithValue("@Newand2ndlMachTotVal", objvo1.Newand2ndlMachTotVal);
                else
                    com.Parameters.AddWithValue("@Newand2ndlMachTotVal", null);
                if (objvo1.PercentageSHMValinTotMachVal != null)
                    com.Parameters.AddWithValue("@PercentageSHMValinTotMachVal", objvo1.PercentageSHMValinTotMachVal);
                else
                    com.Parameters.AddWithValue("@PercentageSHMValinTotMachVal", null);
                if (objvo1.MachValPrchasedfromAPIDCorAPSFCBank != null)
                    com.Parameters.AddWithValue("@MachValPrchasedfromAPIDCorAPSFCBank", objvo1.MachValPrchasedfromAPIDCorAPSFCBank);
                else
                    com.Parameters.AddWithValue("@MachValPrchasedfromAPIDCorAPSFCBank", null);
                if (objvo1.TotalMachVal != null)
                    com.Parameters.AddWithValue("@TotalMachVal", objvo1.TotalMachVal);
                else
                    com.Parameters.AddWithValue("@TotalMachVal", null);
                if (objvo1.Vatno != null)
                    com.Parameters.AddWithValue("@VATNo", objvo1.Vatno);
                else
                    com.Parameters.AddWithValue("@VATNo", null);

                if (objvo1.Cstno != null)
                    com.Parameters.AddWithValue("@CSTNo", objvo1.Cstno);
                else
                    com.Parameters.AddWithValue("@CSTNo", null);
                if (objvo1.CSTRegDate != null)
                    com.Parameters.AddWithValue("@CSTRegDate", objvo1.CSTRegDate);
                else
                    com.Parameters.AddWithValue("@CSTRegDate", null);
                if (objvo1.CSTRegAuthority != null)
                    com.Parameters.AddWithValue("@CSTRegAuthority", objvo1.CSTRegAuthority);
                else
                    com.Parameters.AddWithValue("@CSTRegAuthority", null);
                if (objvo1.CSTRegAuthAddress != null)
                    com.Parameters.AddWithValue("@CSTRegAuthAddress", objvo1.CSTRegAuthAddress);
                else
                    com.Parameters.AddWithValue("@CSTRegAuthAddress", null);
                if (objvo1.GSTNO != null)
                    com.Parameters.AddWithValue("@GSTNO", objvo1.GSTNO);
                else
                    com.Parameters.AddWithValue("@GSTNO", null);
                if (objvo1.GSTDate != null)
                    com.Parameters.AddWithValue("@GSTDate", objvo1.GSTDate);
                else
                    com.Parameters.AddWithValue("@GSTDate", null);
                if (objvo1.PowerStatus != null)
                    com.Parameters.AddWithValue("@PowerType", Convert.ToInt32(objvo1.PowerStatus));
                else
                    com.Parameters.AddWithValue("@PowerType", null);
                if (objvo1.TermLoanApplDate != null)
                    com.Parameters.AddWithValue("@TermLoanApplDate", objvo1.TermLoanApplDate);
                else
                    com.Parameters.AddWithValue("@TermLoanApplDate", null);
                if (objvo1.InstitutionName != null)
                    com.Parameters.AddWithValue("@InstitutionName", objvo1.InstitutionName);
                else
                    com.Parameters.AddWithValue("@InstitutionName", null);
                if (objvo1.TermLoanSancRefNo != null)
                    com.Parameters.AddWithValue("@TermLoanSancRefNo", objvo1.TermLoanSancRefNo);
                else
                    com.Parameters.AddWithValue("@TermLoanSancRefNo", null);
                if (objvo1.TermLoanSanDate != null)
                    com.Parameters.AddWithValue("@TermLoanSanDate", objvo1.TermLoanSanDate);
                else
                    com.Parameters.AddWithValue("@TermLoanSanDate", null);
                //-----------------------------------------------------------------------------------------------------------------
                if (objvo1.User_Id != null)
                    com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                else
                    com.Parameters.AddWithValue("@CreatedBy", null);
                if (objvo1.AppsLevel != null)
                    com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
                else
                    com.Parameters.AddWithValue("@AppsLevel", null);

                if (objvo1.PromotersEquity_MF != null)
                    com.Parameters.AddWithValue("@PromotersEquity_MF", objvo1.PromotersEquity_MF);
                else
                    com.Parameters.AddWithValue("@PromotersEquity_MF", null);
                if (objvo1.InstitutionEquity_MF != null)
                    com.Parameters.AddWithValue("@InstitutionEquity_MF", objvo1.InstitutionEquity_MF);
                else
                    com.Parameters.AddWithValue("@InstitutionEquity_MF", null);
                if (objvo1.TermsLoans_MF != null)
                    com.Parameters.AddWithValue("@TermsLoans_MF", objvo1.TermsLoans_MF);
                else
                    com.Parameters.AddWithValue("@TermsLoans_MF", null);
                if (objvo1.Others_MF != null)
                    com.Parameters.AddWithValue("@Others_MF", objvo1.Others_MF);
                else
                    com.Parameters.AddWithValue("@Others_MF", null);
                if (objvo1.SeedCapital_MF != null)
                    com.Parameters.AddWithValue("@SeedCapital_MF", objvo1.SeedCapital_MF);
                else
                    com.Parameters.AddWithValue("@SeedCapital_MF", null);
                if (objvo1.SubsidyGrantsAgencies_MF != null)
                    com.Parameters.AddWithValue("@SubsidyGrantsAgencies_MF", objvo1.SubsidyGrantsAgencies_MF);
                else
                    com.Parameters.AddWithValue("@SubsidyGrantsAgencies_MF", null);
                if (objvo1.IncentivesAvaild_StateCentrlGovt != null)
                    com.Parameters.AddWithValue("@IncentivesAvaild_StateCentrlGovt", objvo1.IncentivesAvaild_StateCentrlGovt);
                else
                    com.Parameters.AddWithValue("@IncentivesAvaild_StateCentrlGovt", null);
                if (objvo1.NameOfScheme_Agency != null)
                    com.Parameters.AddWithValue("@NameOfScheme_Agency", objvo1.NameOfScheme_Agency);
                else
                    com.Parameters.AddWithValue("@NameOfScheme_Agency", null);



                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                if (valid != "0")
                {
                    foreach (IndustryTermLoanDtls VoIndustryTermLoanDtlsVo in VoIndustryTermLoanDtls)
                    {
                        SqlCommand COMNew = new SqlCommand();
                        COMNew.CommandType = CommandType.StoredProcedure;
                        COMNew.CommandText = "USP_INS_TERMLOANDTLS";
                        COMNew.Transaction = transaction;
                        COMNew.Connection = connection;
                        COMNew.Parameters.AddWithValue("@slno", VoIndustryTermLoanDtlsVo.TermLoanId);
                        COMNew.Parameters.AddWithValue("@TermLoanNo", VoIndustryTermLoanDtlsVo.AvailedTermLoan);
                        COMNew.Parameters.AddWithValue("@TermLoanApplDate", VoIndustryTermLoanDtlsVo.TermLoanApplDate);
                        COMNew.Parameters.AddWithValue("@InstitutionName", VoIndustryTermLoanDtlsVo.InstitutionName);
                        COMNew.Parameters.AddWithValue("@TermloanSandate", VoIndustryTermLoanDtlsVo.TermloanSandate);
                        COMNew.Parameters.AddWithValue("@TermLoanSancRefNo", VoIndustryTermLoanDtlsVo.TermLoanSancRefNo);
                        COMNew.Parameters.AddWithValue("@TermLoanReleaseddate", VoIndustryTermLoanDtlsVo.TermLoanReleaseddate);
                        COMNew.Parameters.AddWithValue("@IncentiveId", VoIndustryTermLoanDtlsVo.IncentiveId);
                        COMNew.Parameters.AddWithValue("@Created_by", VoIndustryTermLoanDtlsVo.Created_by);
                        COMNew.ExecuteNonQuery();
                    }
                }
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

        public string InsertIncentivCommonDataStep5(IncentivesVOs objvo1)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSERT_INCENTIVES_DATA_COMMON_New";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentveID", objvo1.IncentveID);


                if (objvo1.BankName != null)
                    com.Parameters.AddWithValue("@BankName", objvo1.BankName);
                else
                    com.Parameters.AddWithValue("@BankName", null);
                if (objvo1.BranchName != null)
                    com.Parameters.AddWithValue("@BranchName", objvo1.BranchName);
                else
                    com.Parameters.AddWithValue("@BranchName", null);
                if (objvo1.BankAccType != null)
                    com.Parameters.AddWithValue("@BankAccType", objvo1.BankAccType);
                else
                    com.Parameters.AddWithValue("@BankAccType", null);
                if (objvo1.BankAccName != null)
                    com.Parameters.AddWithValue("@BankAccountName", objvo1.BankAccName);
                else
                    com.Parameters.AddWithValue("@BankAccountName", null);
                if (objvo1.AccNo != null)
                    com.Parameters.AddWithValue("@AccNo", objvo1.AccNo);
                else
                    com.Parameters.AddWithValue("@AccNo", null);
                if (objvo1.IFSCCode != null)
                    com.Parameters.AddWithValue("@IFSCCode", objvo1.IFSCCode);
                else
                    com.Parameters.AddWithValue("@IFSCCode", null);

                if (objvo1.WhetherPower != null)
                    com.Parameters.AddWithValue("@WhetherPower", objvo1.WhetherPower);
                else
                    com.Parameters.AddWithValue("@WhetherPower", null);

                if (objvo1.RequesttoDept != null)
                    com.Parameters.AddWithValue("@RequesttoDept", objvo1.RequesttoDept);
                else
                    com.Parameters.AddWithValue("@RequesttoDept", null);
                if (objvo1.User_Id != null)
                    com.Parameters.AddWithValue("@CreatedBy", objvo1.User_Id);
                else
                    com.Parameters.AddWithValue("@CreatedBy", null);
                if (objvo1.AppsLevel != null)
                    com.Parameters.AddWithValue("@AppsLevel", objvo1.AppsLevel);
                else
                    com.Parameters.AddWithValue("@AppsLevel", null);

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
        public string SaveNameofAssets(IncentiveVosA objvoA)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INSERT_INCENTIVES_ApprovedEstimated_ProjectCost_PSR";

                com.Transaction = transaction;
                com.Connection = connection;

                if (objvoA.User_id != "" && objvoA.User_id != null)
                    com.Parameters.AddWithValue("@User_id", objvoA.User_id);
                else
                    com.Parameters.AddWithValue("@User_id", null);

                if (objvoA.Incentive_id != "" && objvoA.Incentive_id != null)
                    com.Parameters.AddWithValue("@Incentive_id", objvoA.Incentive_id);
                else
                    com.Parameters.AddWithValue("@Incentive_id", null);

                if (objvoA.CfeQuid != "" && objvoA.CfeQuid != null)
                    com.Parameters.AddWithValue("@CfeQuid", objvoA.CfeQuid);
                else
                    com.Parameters.AddWithValue("@CfeQuid", null);

                if (objvoA.CfoQuid != "" && objvoA.CfoQuid != null)
                    com.Parameters.AddWithValue("@CfoQuid", objvoA.CfoQuid);
                else
                    com.Parameters.AddWithValue("@CfoQuid", null);

                if (objvoA.LandApprovedProjectCost != "" && objvoA.LandApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@LandApprovedProjectCost", objvoA.LandApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@LandApprovedProjectCost", null);

                if (objvoA.LandLoanSactioned != "" && objvoA.LandLoanSactioned != null)
                    com.Parameters.AddWithValue("@LandLoanSactioned", objvoA.LandLoanSactioned);
                else
                    com.Parameters.AddWithValue("@LandLoanSactioned", null);

                if (objvoA.LandPromotersEquity != "" && objvoA.LandPromotersEquity != null)
                    com.Parameters.AddWithValue("@LandPromotersEquity", objvoA.LandPromotersEquity);
                else
                    com.Parameters.AddWithValue("@LandPromotersEquity", null);

                if (objvoA.LandLoanAmountReleased != "" && objvoA.LandLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@LandLoanAmountReleased", objvoA.LandLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@LandLoanAmountReleased", null);

                if (objvoA.LandAssetsValuebyFinInstitution != "" && objvoA.LandAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@LandAssetsValuebyFinInstitution", objvoA.LandAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@LandAssetsValuebyFinInstitution", null);

                if (objvoA.LandAssetsValuebyCA != "" && objvoA.LandAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@LandAssetsValuebyCA", objvoA.LandAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@LandAssetsValuebyCA", null);

                if (objvoA.BuildingApprovedProjectCost != "" && objvoA.BuildingApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@BuildingApprovedProjectCost", objvoA.BuildingApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@BuildingApprovedProjectCost", null);

                if (objvoA.BuildingLoanSactioned != "" && objvoA.BuildingLoanSactioned != null)
                    com.Parameters.AddWithValue("@BuildingLoanSactioned", objvoA.BuildingLoanSactioned);
                else
                    com.Parameters.AddWithValue("@BuildingLoanSactioned", null);

                if (objvoA.BuildingPromotersEquity != "" && objvoA.BuildingPromotersEquity != null)
                    com.Parameters.AddWithValue("@BuildingPromotersEquity", objvoA.BuildingPromotersEquity);
                else
                    com.Parameters.AddWithValue("@BuildingPromotersEquity", null);

                if (objvoA.BuildingLoanAmountReleased != "" && objvoA.BuildingLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@BuildingLoanAmountReleased", objvoA.BuildingLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@BuildingLoanAmountReleased", null);

                if (objvoA.BuildingAssetsValuebyFinInstitution != "" && objvoA.BuildingAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@BuildingAssetsValuebyFinInstitution", objvoA.BuildingAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@BuildingAssetsValuebyFinInstitution", null);

                if (objvoA.BuildingAssetsValuebyCA != "" && objvoA.BuildingAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@BuildingAssetsValuebyCA", objvoA.BuildingAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@BuildingAssetsValuebyCA", null);

                if (objvoA.PlantMachineryApprovedProjectCost != "" && objvoA.PlantMachineryApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@PlantMachineryApprovedProjectCost", objvoA.PlantMachineryApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@PlantMachineryApprovedProjectCost", null);

                if (objvoA.PlantMachineryLoanSactioned != "" && objvoA.PlantMachineryLoanSactioned != null)
                    com.Parameters.AddWithValue("@PlantMachineryLoanSactioned", objvoA.PlantMachineryLoanSactioned);
                else
                    com.Parameters.AddWithValue("@PlantMachineryLoanSactioned", null);

                if (objvoA.PlantMachineryPromotersEquity != "" && objvoA.PlantMachineryPromotersEquity != null)
                    com.Parameters.AddWithValue("@PlantMachineryPromotersEquity", objvoA.PlantMachineryPromotersEquity);
                else
                    com.Parameters.AddWithValue("@PlantMachineryPromotersEquity", null);

                if (objvoA.PlantMachineryLoanAmountReleased != "" && objvoA.PlantMachineryLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@PlantMachineryLoanAmountReleased", objvoA.PlantMachineryLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@PlantMachineryLoanAmountReleased", null);

                if (objvoA.PlantMachineryAssetsValuebyFinInstitution != "" && objvoA.PlantMachineryAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyFinInstitution", objvoA.PlantMachineryAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyFinInstitution", null);

                if (objvoA.PlantMachineryAssetsValuebyCA != "" && objvoA.PlantMachineryAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyCA", objvoA.PlantMachineryAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@PlantMachineryAssetsValuebyCA", null);

                if (objvoA.MachineryContingenciesApprovedProjectCost != "" && objvoA.MachineryContingenciesApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesApprovedProjectCost", objvoA.MachineryContingenciesApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesApprovedProjectCost", null);

                if (objvoA.MachineryContingenciesLoanSactioned != "" && objvoA.MachineryContingenciesLoanSactioned != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesLoanSactioned", objvoA.MachineryContingenciesLoanSactioned);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesLoanSactioned", null);

                if (objvoA.MachineryContingenciesPromotersEquity != "" && objvoA.MachineryContingenciesPromotersEquity != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesPromotersEquity", objvoA.MachineryContingenciesPromotersEquity);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesPromotersEquity", null);

                if (objvoA.MachineryContingenciesLoanAmountReleased != "" && objvoA.MachineryContingenciesLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesLoanAmountReleased", objvoA.MachineryContingenciesLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesLoanAmountReleased", null);

                if (objvoA.MachineryContingenciesAssetsValuebyFinInstitution != "" && objvoA.MachineryContingenciesAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyFinInstitution", objvoA.MachineryContingenciesAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyFinInstitution", null);

                if (objvoA.MachineryContingenciesAssetsValuebyCA != "" && objvoA.MachineryContingenciesAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyCA", objvoA.MachineryContingenciesAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@MachineryContingenciesAssetsValuebyCA", null);

                if (objvoA.ErectionApprovedProjectCost != "" && objvoA.ErectionApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@ErectionApprovedProjectCost", objvoA.ErectionApprovedProjectCost);
                else com.Parameters.AddWithValue("@ErectionApprovedProjectCost", null);

                if (objvoA.ErectionLoanSactioned != "" && objvoA.ErectionLoanSactioned != null)
                    com.Parameters.AddWithValue("@ErectionLoanSactioned", objvoA.ErectionLoanSactioned);
                else
                    com.Parameters.AddWithValue("@ErectionLoanSactioned", null);

                if (objvoA.ErectionLoanAmountReleased != "" && objvoA.ErectionLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@ErectionLoanAmountReleased", objvoA.ErectionLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@ErectionLoanAmountReleased", null);

                if (objvoA.ErectionPromotersEquity != "" && objvoA.ErectionPromotersEquity != null)
                    com.Parameters.AddWithValue("@ErectionPromotersEquity", objvoA.ErectionPromotersEquity);
                else
                    com.Parameters.AddWithValue("@ErectionPromotersEquity", null);

                if (objvoA.ErectionAssetsValuebyFinInstitution != "" && objvoA.ErectionAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@ErectionAssetsValuebyFinInstitution", objvoA.ErectionAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@ErectionAssetsValuebyFinInstitution", null);

                if (objvoA.ErectionAssetsValuebyCA != "" && objvoA.ErectionAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@ErectionAssetsValuebyCA", objvoA.ErectionAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@ErectionAssetsValuebyCA", null);

                if (objvoA.TechnicalfeasibilityApprovedProjectCost != "" && objvoA.TechnicalfeasibilityApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityApprovedProjectCost", objvoA.TechnicalfeasibilityApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityApprovedProjectCost", null);

                if (objvoA.TechnicalfeasibilityLoanSactioned != "" && objvoA.TechnicalfeasibilityLoanSactioned != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityLoanSactioned", objvoA.TechnicalfeasibilityLoanSactioned);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityLoanSactioned", null);

                if (objvoA.TechnicalfeasibilityPromotersEquity != "" && objvoA.TechnicalfeasibilityPromotersEquity != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityPromotersEquity", objvoA.TechnicalfeasibilityPromotersEquity);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityPromotersEquity", null);

                if (objvoA.TechnicalfeasibilityLoanAmountReleased != "" && objvoA.TechnicalfeasibilityLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityLoanAmountReleased", objvoA.TechnicalfeasibilityLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityLoanAmountReleased", null);

                if (objvoA.TechnicalfeasibilityAssetsValuebyFinInstitution != "" && objvoA.TechnicalfeasibilityAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyFinInstitution", objvoA.TechnicalfeasibilityAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyFinInstitution", null);

                if (objvoA.TechnicalfeasibilityAssetsValuebyCA != "" && objvoA.TechnicalfeasibilityAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyCA", objvoA.TechnicalfeasibilityAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@TechnicalfeasibilityAssetsValuebyCA", null);

                if (objvoA.WorkingCapitalApprovedProjectCost != "" && objvoA.WorkingCapitalApprovedProjectCost != null)
                    com.Parameters.AddWithValue("@WorkingCapitalApprovedProjectCost", objvoA.WorkingCapitalApprovedProjectCost);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalApprovedProjectCost", null);

                if (objvoA.WorkingCapitalLoanSactioned != "" && objvoA.WorkingCapitalLoanSactioned != null)
                    com.Parameters.AddWithValue("@WorkingCapitalLoanSactioned", objvoA.WorkingCapitalLoanSactioned);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalLoanSactioned", null);

                if (objvoA.WorkingCapitalPromotersEquity != "" && objvoA.WorkingCapitalPromotersEquity != null)
                    com.Parameters.AddWithValue("@WorkingCapitalPromotersEquity", objvoA.WorkingCapitalPromotersEquity);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalPromotersEquity", null);

                if (objvoA.WorkingCapitalLoanAmountReleased != "" && objvoA.WorkingCapitalLoanAmountReleased != null)
                    com.Parameters.AddWithValue("@WorkingCapitalLoanAmountReleased", objvoA.WorkingCapitalLoanAmountReleased);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalLoanAmountReleased", null);

                if (objvoA.WorkingCapitalAssetsValuebyFinInstitution != "" && objvoA.WorkingCapitalAssetsValuebyFinInstitution != null)
                    com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyFinInstitution", objvoA.WorkingCapitalAssetsValuebyFinInstitution);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyFinInstitution", null);

                if (objvoA.WorkingCapitalAssetsValuebyCA != "" && objvoA.WorkingCapitalAssetsValuebyCA != null)
                    com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyCA", objvoA.WorkingCapitalAssetsValuebyCA);
                else
                    com.Parameters.AddWithValue("@WorkingCapitalAssetsValuebyCA", null);

                if (objvoA.created_by != "" && objvoA.created_by != null)
                    com.Parameters.AddWithValue("@created_by", objvoA.created_by);
                else
                    com.Parameters.AddWithValue("@created_by", null);

                if (objvoA.created_dt != "" && objvoA.created_dt != null)
                    com.Parameters.AddWithValue("@created_dt", objvoA.created_dt);
                else
                    com.Parameters.AddWithValue("@created_dt", null);

                if (objvoA.Modified_by != "" && objvoA.Modified_by != null)
                    com.Parameters.AddWithValue("@Modified_by", objvoA.Modified_by);
                else
                    com.Parameters.AddWithValue("@Modified_by", null);

                if (objvoA.Modified_dt != "" && objvoA.Modified_dt != null)
                    com.Parameters.AddWithValue("@Modified_dt", objvoA.Modified_dt);
                else
                    com.Parameters.AddWithValue("@Modified_dt", null);

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

        public string SaveBackgroundDetails(BackgroundDetails objvoA)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();

            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "sp_BackGroundDetails";

                com.Transaction = transaction;
                com.Connection = connection;



                if (objvoA.Incentive_id != "" && objvoA.Incentive_id != null)
                    com.Parameters.AddWithValue("@IncentiveId", objvoA.Incentive_id);
                else
                    com.Parameters.AddWithValue("@@IncentiveId", null);

                if (objvoA.TurnOver_1stYear != "" && objvoA.TurnOver_1stYear != null)
                    com.Parameters.AddWithValue("@TurnOver_1stYear", objvoA.TurnOver_1stYear);
                else
                    com.Parameters.AddWithValue("@TurnOver_1stYear", null);

                if (objvoA.TurnOver_2ndYear != "" && objvoA.TurnOver_2ndYear != null)
                    com.Parameters.AddWithValue("@TurnOver_2ndYear", objvoA.TurnOver_2ndYear);
                else
                    com.Parameters.AddWithValue("@TurnOver_2ndYear", null);

                if (objvoA.TurnOver_3rdYear != "" && objvoA.TurnOver_3rdYear != null)
                    com.Parameters.AddWithValue("@TurnOver_3rdYear", objvoA.TurnOver_3rdYear);
                else
                    com.Parameters.AddWithValue("@TurnOver_3rdYear", null);

                if (objvoA.EBITDA_1stYear != "" && objvoA.EBITDA_1stYear != null)
                    com.Parameters.AddWithValue("@EBITDA_1stYear", objvoA.EBITDA_1stYear);
                else
                    com.Parameters.AddWithValue("@EBITDA_1stYear", null);

                if (objvoA.EBITDA_2ndYear != "" && objvoA.EBITDA_2ndYear != null)
                    com.Parameters.AddWithValue("@EBITDA_2ndYear", objvoA.EBITDA_2ndYear);
                else
                    com.Parameters.AddWithValue("@EBITDA_2ndYear", null);

                if (objvoA.EBITDA_3rdYear != "" && objvoA.EBITDA_3rdYear != null)
                    com.Parameters.AddWithValue("@EBITDA_3rdYear", objvoA.EBITDA_3rdYear);
                else
                    com.Parameters.AddWithValue("@EBITDA_3rdYear", null);

                if (objvoA.Networth_1stYear != "" && objvoA.Networth_1stYear != null)
                    com.Parameters.AddWithValue("@Networth_1stYear", objvoA.Networth_1stYear);
                else
                    com.Parameters.AddWithValue("@Networth_1stYear", null);

                if (objvoA.Networth_2ndYear != "" && objvoA.Networth_2ndYear != null)
                    com.Parameters.AddWithValue("@Networth_2ndYear", objvoA.Networth_2ndYear);
                else
                    com.Parameters.AddWithValue("@Networth_2ndYear", null);

                if (objvoA.Networth_3rdYear != "" && objvoA.Networth_3rdYear != null)
                    com.Parameters.AddWithValue("@Networth_3rdYear", objvoA.Networth_3rdYear);
                else
                    com.Parameters.AddWithValue("@Networth_3rdYear", null);

                if (objvoA.ReservesSurplus_1stYear != "" && objvoA.ReservesSurplus_1stYear != null)
                    com.Parameters.AddWithValue("@ReservesSurplus_1stYear", objvoA.ReservesSurplus_1stYear);
                else
                    com.Parameters.AddWithValue("@ReservesSurplus_1stYear", null);

                if (objvoA.ReservesSurplus_2ndYear != "" && objvoA.ReservesSurplus_2ndYear != null)
                    com.Parameters.AddWithValue("@ReservesSurplus_2ndYear", objvoA.ReservesSurplus_2ndYear);
                else
                    com.Parameters.AddWithValue("@ReservesSurplus_2ndYear", null);

                if (objvoA.ReservesSurplus_3rdYear != "" && objvoA.ReservesSurplus_3rdYear != null)
                    com.Parameters.AddWithValue("@ReservesSurplus_3rdYear", objvoA.ReservesSurplus_3rdYear);
                else
                    com.Parameters.AddWithValue("@ReservesSurplus_3rdYear", null);

                if (objvoA.Share_Capital_1stYear != "" && objvoA.Share_Capital_1stYear != null)
                    com.Parameters.AddWithValue("@Share_Capital_1stYear", objvoA.Share_Capital_1stYear);
                else
                    com.Parameters.AddWithValue("@Share_Capital_1stYear", null);

                if (objvoA.Share_Capital_2ndYear != "" && objvoA.Share_Capital_2ndYear != null)
                    com.Parameters.AddWithValue("@Share_Capital_2ndYear", objvoA.Share_Capital_2ndYear);
                else
                    com.Parameters.AddWithValue("@Share_Capital_2ndYear", null);

                if (objvoA.Share_Capital_3rdYear != "" && objvoA.Share_Capital_3rdYear != null)
                    com.Parameters.AddWithValue("@Share_Capital_3rdYear", objvoA.Share_Capital_3rdYear);
                else
                    com.Parameters.AddWithValue("@Share_Capital_3rdYear", null);


                if (objvoA.created_by != "" && objvoA.created_by != null)
                    com.Parameters.AddWithValue("@CreatedBy", objvoA.created_by);
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

        protected void txtlandexisting_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise();
        }
        protected void txtlandcapacity_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise();
        }
        protected void txtbuildingexisting_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise();
        }
        protected void txtbuildingcapacity_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise();
        }
        protected void txtsecondhndmachine_TextChanged(object sender, EventArgs e)
        {
            SumofSecondaryMachineValues("1");
        }
        protected void txtnewmachine_TextChanged(object sender, EventArgs e)
        {
            SumofSecondaryMachineValues("1");
        }
        protected void txtTotalvalue12_TextChanged(object sender, EventArgs e)
        {
            SumofSecondaryMachineValues("2");
        }
        protected void txtmachinepucr_TextChanged(object sender, EventArgs e)
        {
            SumofSecondaryMachineValues("2");
        }

        public void SumofSecondaryMachineValues(string Levels)
        {
            if (Levels == "1")
            {
                decimal secondhndmachine = 0;
                decimal newmachine = 0;
                if (txtsecondhndmachine.Text.TrimStart().Trim() != "")
                {
                    secondhndmachine = Convert.ToDecimal(txtsecondhndmachine.Text.TrimStart().Trim());
                }
                if (txtnewmachine.Text.TrimStart().Trim() != "")
                {
                    newmachine = Convert.ToDecimal(txtnewmachine.Text.TrimStart().Trim());
                }

                txtTotalvalue12.Text = (secondhndmachine + newmachine).ToString();

                txtTotalvalue12_TextChanged(this, EventArgs.Empty);
            }
            else if (Levels == "2")
            {
                decimal machinepucr = 0;
                decimal Totalvalue12 = 0;
                if (txtmachinepucr.Text.TrimStart().Trim() != "")
                {
                    machinepucr = Convert.ToDecimal(txtmachinepucr.Text.TrimStart().Trim());
                }
                if (txtTotalvalue12.Text.TrimStart().Trim() != "")
                {
                    Totalvalue12 = Convert.ToDecimal(txtTotalvalue12.Text.TrimStart().Trim());
                }
                txttotal25.Text = (machinepucr + Totalvalue12).ToString();
            }
        }

        protected void txtuidno_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TSIPASSSERVICE.DepartmentApprovalSystem tsipass = new TSIPASSSERVICE.DepartmentApprovalSystem();

                string output = tsipass.GetCFEEnterprenuerDetailsNew(txtuidno.Text.Trim(), Session["uid"].ToString());
                StringReader str1 = new StringReader(output);
                DataSet ds = new DataSet();
                ds.ReadXml(str1);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    txtUser_Id.Text = ds.Tables[0].Rows[0]["NameofIndustrialUnder"].ToString();
                    txtuidno.Text = ds.Tables[0].Rows[0]["UID_No"].ToString();
                    txtApplciantName.Text = ds.Tables[0].Rows[0]["NameofthePromoter"].ToString();
                    txtOffcEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                    if (ddloffcstate.SelectedValue == "31")
                    {

                        ddlOffcDIst.Visible = true;
                        txtofficedist.Visible = false;
                        ddlOffcDIst.SelectedValue = ds.Tables[0].Rows[0]["distid"].ToString();
                        getdistrictsOffc();
                        ddlOffcMandal.Visible = true;
                        txtoffcicemandal.Visible = false;
                        ddlOffcMandal.SelectedValue = ds.Tables[0].Rows[0]["mandid"].ToString();
                        Getmandalsoffc();
                        ddlOffcVil.Visible = true;
                        txtofficeviiage.Visible = false;
                        ddlOffcVil.SelectedValue = ds.Tables[0].Rows[0]["villid"].ToString();

                    }
                    else
                    {

                        ddlOffcDIst.Visible = false;
                        ddlOffcMandal.Visible = false;
                        ddlOffcVil.Visible = false;
                        txtofficedist.Visible = true;
                        txtoffcicemandal.Visible = true;
                        txtofficeviiage.Visible = true;

                        txtofficedist.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();
                        txtoffcicemandal.Text = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                        txtofficeviiage.Text = ds.Tables[0].Rows[0]["Village_Name"].ToString();


                    }


                    if (ddlUnitstate.SelectedValue == "31")
                    {

                        if (ds.Tables[3].Rows[0]["District_Id"].ToString() != "")
                        {

                            ddlUnitDIst.SelectedValue = ds.Tables[3].Rows[0]["District_Id"].ToString();
                            Getmandalsunit();
                            ddlUnitMandal.SelectedValue = ds.Tables[3].Rows[0]["Mandal_Id"].ToString();

                            Getvillagesunit();
                            ddlVillageunit.SelectedValue = ds.Tables[3].Rows[0]["Village_Id"].ToString();

                        }

                    }

                    txtunitemailid.Text = ds.Tables[3].Rows[0]["Land_Email"].ToString();
                    txtUnitStreet.Text = ds.Tables[3].Rows[0]["Name_Gramapachayat"].ToString();
                    ddlUdyogAadharType.SelectedValue = ds.Tables[0].Rows[0]["intCategoryofReg"].ToString();

                    txtoffaddhnno.Text = ds.Tables[0].Rows[0]["Door_No"].ToString();
                    txtUnitHNO.Text = ds.Tables[3].Rows[0]["SurveyNo"].ToString();
                    if (ds.Tables[0].Rows[0]["MobileNumber"].ToString() != "")
                    {
                        txtOffcMobileNO.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();

                    }
                    rblCaste.SelectedValue = ds.Tables[0].Rows[0]["caste"].ToString();

                    if (ds.Tables[3].Rows[0]["Land_TelephoneNumber"].ToString() != "")
                    {
                        txtunitmobileno.Text = ds.Tables[3].Rows[0]["Land_TelephoneNumber"].ToString();
                    }

                    txtOffcStreet.Text = ds.Tables[0].Rows[0]["StreetName"].ToString();
                    txtlandexisting.Text = ds.Tables[0].Rows[0]["Land_Value"].ToString();
                    txtbuildingexisting.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();

                    txtplantexisting.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();

                    if (ds.Tables[0].Rows[0]["Val_LandExpansion"].ToString() != " " && ds.Tables[0].Rows[0]["Val_LandExpansion"].ToString() == null)
                    {
                        txtlandcapacity.Text = ds.Tables[0].Rows[0]["Val_LandExpansion"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Val_BuildExpansion"].ToString() != "" && ds.Tables[0].Rows[0]["Val_BuildExpansion"].ToString() == null)
                    {
                        txtbuildingcapacity.Text = ds.Tables[0].Rows[0]["Val_BuildExpansion"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Val_PlantExpansion"].ToString() != "" && ds.Tables[0].Rows[0]["Val_PlantExpansion"].ToString() == null)
                    {
                        txtplantcapacity.Text = ds.Tables[0].Rows[0]["Val_PlantExpansion"].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        trNewIndustry.Visible = true;
                        gvInstalledCap.Visible = true;
                        gvInstalledCap.DataSource = ds.Tables[1];
                        gvInstalledCap.DataBind();

                    }
                    if (ds.Tables[0].Rows[0]["Reg_No"].ToString() != "" && ds.Tables[0].Rows[0]["Reg_No"].ToString() != null)
                    {
                        txtudyogAadharNo.Text = ds.Tables[0].Rows[0]["Reg_No"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Reg_Date"].ToString() != "" && ds.Tables[0].Rows[0]["Reg_Date"].ToString() != null)
                    {
                        txtUdyogAadhaarRegdDate.Text = ds.Tables[0].Rows[0]["Reg_Date"].ToString();

                    }
                }


            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        protected void IsSubsidiesIncentives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnIsSubsidiesIncentives.SelectedValue == "1")
            {
                tdIsSubsidiesIncentives.Visible = true;
                tdIsSubsidiesIncentiveslabel.Visible = true;
            }
            else
            {
                tdIsSubsidiesIncentives.Visible = false;
                tdIsSubsidiesIncentiveslabel.Visible = false;
            }
        }

        #endregion
    }
}
