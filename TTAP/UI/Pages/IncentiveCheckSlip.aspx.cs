using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP
{
    public partial class IncentiveCheckSlip : System.Web.UI.Page
    {
        General objDAL = new General();
        EnclosuresBO objBO = new EnclosuresBO();
        //string attachValue = "0";
        DataSet ds = new DataSet();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        //string IncentiveId = "123";
        //string createdby = "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            try
            {
                //Session["IncentiveID"] = IncentiveId;

                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        if (Session["incentivedata"] != null)
                        {
                            string userid = Session["uid"].ToString();
                            string IncentveID = Session["IncentiveID"].ToString();
                            ds = objDAL.IncentiveEnclosures_ChecklistDB(Convert.ToInt32(userid), Convert.ToInt32(IncentveID));
                            FillDetails(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        public void FillDetails(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //BtnNext.Enabled = true;
                //BtnSave.Enabled = false;
                ddlIncorporation.SelectedValue = ds.Tables[0].Rows[0]["CSbillsofinstitutfinancedEnterpriseindustries"].ToString().Trim();
                ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedValue = ds.Tables[0].Rows[0]["CSbillandpymtproofrespectofselffinancedEnterprisesindustries"].ToString().Trim();
                ddlCSCasteCertificatesSCST.SelectedValue = ds.Tables[0].Rows[0]["CSCasteCertificatesSCST"].ToString().Trim();
                ddlCSEntrepreneurAadhar.SelectedValue = ds.Tables[0].Rows[0]["CSEntrepreneurAadhar"].ToString().Trim();
                ddlCSEntrepreneurPANCard.SelectedValue = ds.Tables[0].Rows[0]["CSEntrepreneurPANCard"].ToString().Trim();
                ddlCSCertificateofCA.SelectedValue = ds.Tables[0].Rows[0]["CSCertificateofCA"].ToString().Trim();
                ddlCSRegdPartnershipDeedArticles.SelectedValue = ds.Tables[0].Rows[0]["CSRegdPartnershipDeedArticles"].ToString().Trim();
                ddlCSApprovalDirectorFactories.SelectedValue = ds.Tables[0].Rows[0]["CSApprovalDirectorFactories"].ToString().Trim();
                ddlCSBoilersCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSBoilersCertificate"].ToString().Trim();
                ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue = ds.Tables[0].Rows[0]["CSApprovalDirectorTownCountryPlanningUDA"].ToString().Trim();
                ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue = ds.Tables[0].Rows[0]["CSRegularbuildingplansapprovalofMunicipalityGramPanchayat"].ToString().Trim();
                ddlCSOperationTSPCBAcknowledgementGM.SelectedValue = ds.Tables[0].Rows[0]["CSOperationTSPCBAcknowledgementGM"].ToString().Trim();
                ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue = ds.Tables[0].Rows[0]["CSPowerreleaseCertificatefrmTSTRANSCODISCOM"].ToString().Trim();
                ddlCSEnvironmentalclearance.SelectedValue = ds.Tables[0].Rows[0]["CSEnvironmentalclearance"].ToString().Trim();
                ddlCSOtherstatutoryapprovalsspecif.SelectedValue = ds.Tables[0].Rows[0]["CSOtherstatutoryapprovalsspecif"].ToString().Trim();
                ddlCSEMPartIfullsetIEMIL.SelectedValue = ds.Tables[0].Rows[0]["CSEMPartIfullsetIEMIL"].ToString().Trim();
                // ddlCSEMPartIIfullsetIEMIL.SelectedValue = ds.Tables[0].Rows[0]["IncentveID"].ToString(); objvoA.CSEMPartIIfullsetIEMIL
                ddlCSUdyogAadhar.SelectedValue = ds.Tables[0].Rows[0]["CSUdyogAadhar"].ToString().Trim();
                ddlCSProjectReport.SelectedValue = ds.Tables[0].Rows[0]["CSProjectReport"].ToString().Trim();
                ddlCSTermloansanctionletters.SelectedValue = ds.Tables[0].Rows[0]["CSTermloansanctionletters"].ToString().Trim();
                ddlCSBoardResolutionauthorizing.SelectedValue = ds.Tables[0].Rows[0]["CSBoardResolutionauthorizing"].ToString().Trim();
                ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedValue = ds.Tables[0].Rows[0]["CSRegisteredlandSaledeedPremisesLeasedeed"].ToString().Trim();
                ddlCSCACECertificateregarding2handplantmachinery.SelectedValue = ds.Tables[0].Rows[0]["CSCACECertificateregarding2handplantmachinery"].ToString().Trim();
                ddlCSCECertificateSelffabricatedmachinery.SelectedValue = ds.Tables[0].Rows[0]["CSCECertificateSelffabricatedmachinery"].ToString().Trim();

                ddlCSBISCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSBISCertificate"].ToString().Trim();
                ddlCSDrugLicense.SelectedValue = ds.Tables[0].Rows[0]["CSDrugLicense"].ToString().Trim();
                ddlCSExplosiveLicense.SelectedValue = ds.Tables[0].Rows[0]["CSExplosiveLicense"].ToString().Trim();
                ddlCSVATCSTSGSTCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSVATCSTSGSTCertificate"].ToString().Trim();
                ddlCSFormA.SelectedValue = ds.Tables[0].Rows[0]["CSFormA"].ToString().Trim();
                ddlCSFormB.SelectedValue = ds.Tables[0].Rows[0]["CSFormB"].ToString().Trim();

                ddlProductionParticulars3Years.SelectedValue = ds.Tables[0].Rows[0]["CSProductionParticulars3Years"].ToString().Trim();
                ddlRTACertificate.SelectedValue = ds.Tables[0].Rows[0]["CSRTACertificate"].ToString().Trim();
                ddlPHCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSPHCertificate"].ToString().Trim();
                ddlUntertakingForm.SelectedValue = ds.Tables[0].Rows[0]["CSUndertakingForm"].ToString().Trim();

                ddlApplicantVehiclePhoto.SelectedValue = ds.Tables[0].Rows[0]["ApplicantVehPhoto"].ToString().Trim();
                ddlfirstsalebill.SelectedValue = ds.Tables[0].Rows[0]["Fisrsalebill"].ToString().Trim();
                ddlCOBORROWER.SelectedValue = ds.Tables[0].Rows[0]["COBORROWER"].ToString().Trim();

                ddlcopyofpan.SelectedValue = ds.Tables[0].Rows[0]["CopyofPan"].ToString().Trim();
                DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["DocFirstInvestment"].ToString().Trim();
                DropDownList2.SelectedValue = ds.Tables[0].Rows[0]["InvestmentCertificate"].ToString().Trim();
                DropDownList3.SelectedValue = ds.Tables[0].Rows[0]["EngineersCertificate"].ToString().Trim();
                DropDownList4.SelectedValue = ds.Tables[0].Rows[0]["CopyofReceipts"].ToString().Trim();
                DropDownList5.SelectedValue = ds.Tables[0].Rows[0]["ExpenditureCertificate"].ToString().Trim();

                #region  " ddl selected change events"

                if (ddlIncorporation.SelectedValue == "Y")
                {
                    ddlIncorporation_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedValue == "Y")
                {
                    ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSCasteCertificatesSCST.SelectedValue == "Y")
                {
                    ddlCSCasteCertificatesSCST_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ddlCSEntrepreneurAadhar.SelectedValue == "Y")
                {
                    ddlCSEntrepreneurAadhar_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSEntrepreneurPANCard.SelectedValue == "Y")
                {
                    ddlCSEntrepreneurPANCard_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSCertificateofCA.SelectedValue == "Y")
                {
                    ddlCSCertificateofCA_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSRegdPartnershipDeedArticles.SelectedValue == "Y")
                {
                    ddlCSRegdPartnershipDeedArticles_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSApprovalDirectorFactories.SelectedValue == "Y")
                {
                    ddlCSApprovalDirectorFactories_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSBoilersCertificate.SelectedValue == "Y")
                {
                    ddlCSBoilersCertificate_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue == "Y")
                {
                    ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue == "Y")
                {
                    ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSOperationTSPCBAcknowledgementGM.SelectedValue == "Y")
                {
                    ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue == "Y")
                {
                    ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ddlCSEnvironmentalclearance.SelectedValue == "Y")
                {
                    ddlCSEnvironmentalclearance_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSOtherstatutoryapprovalsspecif.SelectedValue == "Y")
                {
                    ddlCSOtherstatutoryapprovalsspecif_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSEMPartIfullsetIEMIL.SelectedValue == "Y")
                {
                    ddlCSEMPartIfullsetIEMIL_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSUdyogAadhar.SelectedValue == "Y")
                {
                    ddlCSUdyogAadhar_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSProjectReport.SelectedValue == "Y")
                {
                    ddlCSProjectReport_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSTermloansanctionletters.SelectedValue == "Y")
                {
                    ddlCSTermloansanctionletters_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSBoardResolutionauthorizing.SelectedValue == "Y")
                {
                    ddlCSBoardResolutionauthorizing_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedValue == "Y")
                {
                    ddlCSRegisteredlandSaledeedPremisesLeasedeed_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSCACECertificateregarding2handplantmachinery.SelectedValue == "Y")
                {
                    ddlCSCACECertificateregarding2handplantmachinery_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSCECertificateSelffabricatedmachinery.SelectedValue == "Y")
                {
                    ddlCSCECertificateSelffabricatedmachinery_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSBISCertificate.SelectedValue == "Y")
                {
                    ddlCSBISCertificate_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSDrugLicense.SelectedValue == "Y")
                {
                    ddlCSDrugLicense_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSExplosiveLicense.SelectedValue == "Y")
                {
                    ddlCSExplosiveLicense_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ddlCSVATCSTSGSTCertificate.SelectedValue == "Y")
                {
                    ddlCSVATCSTSGSTCertificate_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ddlCSFormA.SelectedValue == "Y")
                {
                    ddlCSFormA_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ddlCSFormB.SelectedValue == "Y")
                {
                    ddlCSFormB_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ddlProductionParticulars3Years.SelectedValue == "Y")
                {
                    ddlProductionParticulars3Years_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ddlRTACertificate.SelectedValue == "Y")
                {
                    ddlRTACertificate_SelectedIndexChanged(this, EventArgs.Empty);
                }

                if (ddlPHCertificate.SelectedValue == "Y")
                {
                    ddlPHCertificate_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlUntertakingForm.SelectedValue == "Y")
                {
                    ddlUntertakingForm_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlfirstsalebill.SelectedValue == "Y")
                {
                    ddlfirstsalebill_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCOBORROWER.SelectedValue == "Y")
                {
                    ddlCOBORROWER_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlcopyofpan.SelectedValue == "Y")
                {
                    ddlcopyofpan_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (DropDownList1.SelectedValue == "Y")
                {
                    DropDownList1_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (DropDownList2.SelectedValue == "Y")
                {
                    DropDownList2_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (DropDownList3.SelectedValue == "Y")
                {
                    DropDownList3_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (DropDownList4.SelectedValue == "Y")
                {
                    DropDownList4_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (DropDownList5.SelectedValue == "Y")
                {
                    DropDownList5_SelectedIndexChanged(this, EventArgs.Empty);
                }
                #endregion

                //BtnSave.Enabled = false;

            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable table = ds.Tables[1];
                string sen, sen1, sen2;

                foreach (DataRow dr in table.Rows)
                {
                    string attachmentid = dr["AttachmentId"].ToString();
                    sen2 = dr["link"].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (attachmentid == "1")
                    {
                        hyprlnkIncorporation.NavigateUrl = sen;
                        hyprlnkIncorporation.Text = dr["FileNm"].ToString(); // hyperlink 
                        lblIncorporation.Text = dr["FileNm"].ToString(); // label   
                        hyprlnkIncorporation.Visible = true;
                        lblIncorporation.Visible = false;
                    }
                    if (attachmentid == "2")
                    {
                        HyperLink101.NavigateUrl = sen;
                        HyperLink101.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label101.Text = dr["FileNm"].ToString(); // label        
                        HyperLink101.Visible = true;
                        Label101.Visible = false;

                    }
                    if (attachmentid == "3")
                    {
                        hyprlnkcopyofpan.NavigateUrl = sen;
                        hyprlnkcopyofpan.Text = dr["FileNm"].ToString();  // hyperlink 
                        lblcopyofpan.Text = dr["FileNm"].ToString(); // label        
                        hyprlnkcopyofpan.Visible = true;
                        lblcopyofpan.Visible = false;

                    }
                    if (attachmentid == "4")
                    {
                        HyperLink106.NavigateUrl = sen;
                        HyperLink106.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label106.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink106.Visible = true;
                        Label106.Visible = false;
                    }
                    if (attachmentid == "5")
                    {
                        HyperLink102.NavigateUrl = sen;
                        HyperLink102.Text = dr["FileNm"].ToString();// hyperlink 
                        Label102.Text = dr["FileNm"].ToString(); // label       
                        HyperLink102.Visible = true;
                        Label102.Visible = false;

                    }
                    if (attachmentid == "6")
                    {
                        HyperLink103.NavigateUrl = sen;
                        HyperLink103.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label103.Text = dr["FileNm"].ToString(); // label 

                        HyperLink103.Visible = true;
                        Label103.Visible = false;

                    }
                    if (attachmentid == "7")
                    {
                        //HyperLink105.NavigateUrl = sen;
                        HyperLink105.NavigateUrl = dr["FileNm"].ToString();
                        HyperLink105.Text = dr["FileNm"].ToString(); // hyperlink 
                        HyperLink105.Visible = true;
                        Label105.Text = dr["FileNm"].ToString();  // label  

                        HyperLink105.Visible = true;
                        Label105.Visible = false;
                    }
                    if (attachmentid == "8")
                    {
                        HyperLink104.NavigateUrl = sen;
                        HyperLink104.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label104.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink104.Visible = true;
                        Label104.Visible = false;
                    }
                    if (attachmentid == "9")
                    {
                        HyperLink210.NavigateUrl = sen;
                        HyperLink210.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label210.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink210.Visible = true;
                        Label210.Visible = false;
                    }
                    if (attachmentid == "10")
                    {
                        HyperLink211.NavigateUrl = sen;
                        HyperLink211.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label211.Text = dr["FileNm"].ToString(); // label                  

                        HyperLink211.Visible = true;
                        Label211.Visible = false;
                    }
                    if (attachmentid == "11")
                    {
                        HyperLink215.NavigateUrl = sen;
                        HyperLink215.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label215.Text = dr["FileNm"].ToString(); // label                  

                        HyperLink215.Visible = true;
                        Label215.Visible = false;
                    }
                    if (attachmentid == "12")
                    {
                        HyperLink216.NavigateUrl = sen;
                        HyperLink216.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label216.Text = dr["FileNm"].ToString();// label                  

                        HyperLink216.Visible = true;
                        Label216.Visible = false;
                    }
                    if (attachmentid == "13")
                    {
                        HyperLink217.NavigateUrl = sen;
                        HyperLink217.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label208.Text = dr["FileNm"].ToString(); // label                  

                        HyperLink217.Visible = true;
                        Label217.Visible = false;
                    }
                    if (attachmentid == "14")
                    {
                        HyperLink218.NavigateUrl = sen;
                        HyperLink218.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label218.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink218.Visible = true;
                        Label218.Visible = false;
                    }
                    if (attachmentid == "15")
                    {
                        HyperLink219.NavigateUrl = sen;
                        HyperLink219.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label219.Text = dr["FileNm"].ToString(); // label                  

                        HyperLink219.Visible = true;
                        Label219.Visible = false;
                    }
                    if (attachmentid == "16")
                    {
                        HyperLink220.NavigateUrl = sen;
                        HyperLink220.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label220.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink220.Visible = true;
                        Label220.Visible = false;
                    }

                    if (attachmentid == "19")
                    {
                        HyperLink221.NavigateUrl = sen;
                        HyperLink221.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label221.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink221.Visible = true;
                        Label221.Visible = false;
                    }
                    if (attachmentid == "20")
                    {
                        HyperLink214.NavigateUrl = sen;
                        HyperLink214.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label214.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink214.Visible = true;
                        Label214.Visible = false;
                    }
                    if (attachmentid == "21")
                    {
                        HyperLink223.NavigateUrl = sen;
                        HyperLink223.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label223.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink223.Visible = true;
                        Label223.Visible = false;
                    }
                    if (attachmentid == "22")
                    {
                        HyperLink222.NavigateUrl = sen;
                        HyperLink222.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label222.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink222.Visible = true;
                        Label222.Visible = false;
                    }
                    if (attachmentid == "23")
                    {
                        HyperLink224.NavigateUrl = sen;
                        HyperLink224.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label224.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink224.Visible = true;
                        Label224.Visible = false;
                    }
                    if (attachmentid == "24")
                    {
                        HyperLink225.NavigateUrl = sen;
                        HyperLink225.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label225.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink223.Visible = true;
                        Label223.Visible = false;
                    }
                    if (attachmentid == "25")
                    {
                        HyperLink226.NavigateUrl = sen;
                        HyperLink226.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label226.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink226.Visible = true;
                        Label226.Visible = false;
                    }
                    if (attachmentid == "27")
                    {
                        HyperLink227.NavigateUrl = sen;
                        HyperLink227.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label227.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink227.Visible = true;
                        Label227.Visible = false;
                    }
                    if (attachmentid == "28")
                    {
                        HyperLink212.NavigateUrl = sen;
                        HyperLink212.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label212.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink212.Visible = true;
                        Label212.Visible = false;
                    }
                    if (attachmentid == "29")
                    {
                        HyperLink201.NavigateUrl = sen;
                        HyperLink201.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label201.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink201.Visible = true;
                        Label201.Visible = false;
                    }
                    if (attachmentid == "30")
                    {
                        HyperLink202.NavigateUrl = sen;
                        HyperLink202.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label202.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink202.Visible = true;
                        Label202.Visible = false;
                    }
                    if (attachmentid == "31")
                    {
                        HyperLink203.NavigateUrl = sen;
                        HyperLink203.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label203.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink203.Visible = true;
                        Label203.Visible = false;
                    }
                    if (attachmentid == "32")
                    {
                        HyperLink204.NavigateUrl = sen;
                        HyperLink204.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label204.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink204.Visible = true;
                        Label204.Visible = false;
                    }
                    if (attachmentid == "33")
                    {
                        HyperLink205.NavigateUrl = sen;
                        HyperLink205.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label205.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink205.Visible = true;
                        Label205.Visible = false;
                    }
                    if (attachmentid == "34")
                    {
                        HyperLink206.NavigateUrl = sen;
                        HyperLink206.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label206.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink206.Visible = true;
                        Label206.Visible = false;
                    }
                    if (attachmentid == "35")
                    {
                        HyperLink207.NavigateUrl = sen;
                        HyperLink207.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label207.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink207.Visible = true;
                        Label207.Visible = false;
                    }
                    if (attachmentid == "36")
                    {
                        HyperLink208.NavigateUrl = sen;
                        HyperLink208.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label208.Text = dr["FileNm"].ToString(); // label                  

                        HyperLink208.Visible = true;
                        Label208.Visible = false;
                    }
                    if (attachmentid == "37")
                    {
                        HyperLink213.NavigateUrl = sen;
                        HyperLink213.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label213.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink213.Visible = true;
                        Label213.Visible = false;
                    }
                    if (attachmentid == "38")
                    {
                        HyperLink228.NavigateUrl = sen;
                        HyperLink228.Text = dr["FileNm"].ToString();  // hyperlink
                        Label228.Text = dr["FileNm"].ToString();  // label                 
                        HyperLink228.Visible = true;
                        Label228.Visible = false;
                    }
                    if (attachmentid == "39")
                    {
                        HyperLink209.NavigateUrl = sen;
                        HyperLink209.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label209.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink209.Visible = true;
                        Label209.Visible = false;
                    }

                    if (attachmentid == "42")
                    {
                        HyperLink1.NavigateUrl = sen;
                        HyperLink1.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label1.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink1.Visible = true;
                        Label1.Visible = false;
                    }

                    if (attachmentid == "45")
                    {
                        HyperLink2.NavigateUrl = sen;
                        HyperLink2.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label2.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink2.Visible = true;
                        Label2.Visible = false;
                    }
                    if (attachmentid == "46")
                    {
                        HyperLink3.NavigateUrl = sen;
                        HyperLink3.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label3.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink3.Visible = true;
                        Label3.Visible = false;
                    }
                    if (attachmentid == "47")
                    {
                        HyperLink4.NavigateUrl = sen;
                        HyperLink4.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label4.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink4.Visible = true;
                        Label4.Visible = false;
                    }
                    if (attachmentid == "48")
                    {
                        HyperLink5.NavigateUrl = sen;
                        HyperLink5.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label5.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink5.Visible = true;
                        Label5.Visible = false;
                    }


                    if (attachmentid == "1094")
                    {
                        HyperLink229.NavigateUrl = sen;
                        HyperLink229.Text = dr["FileNm"].ToString();  // hyperlink
                        Label229.Text = dr["FileNm"].ToString();  // label                 
                        HyperLink229.Visible = true;
                        Label229.Visible = false;
                        attachValue = "1";
                    }
                    if (attachmentid == "100019")
                    {
                        HyperLink229.NavigateUrl = sen;
                        HyperLink229.Text = dr["FileNm"].ToString();  // hyperlink
                        Label229.Text = dr["FileNm"].ToString();  // label                 
                        HyperLink229.Visible = true;
                        Label229.Visible = false;
                    }
                }


            }

        }

        public int ValidateFileUploads()
        {
            int i = 0;

            if (ddlIncorporation.SelectedItem.Text.ToUpper() == "YES")
            {
                if (lblIncorporation.Text == "" || lblIncorporation.Text == null || lblIncorporation.Text == string.Empty)
                {
                    i = 1;
                }

            }

            if (ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label101.Text == "" || Label101.Text == null || Label101.Text == string.Empty)
                {
                    i = 1;
                }


            }
            if (ddlCSCasteCertificatesSCST.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label102.Text == "" || Label102.Text == null || Label102.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSEntrepreneurAadhar.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label103.Text == "" || Label103.Text == null || Label103.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSEntrepreneurPANCard.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label104.Text == "" || Label104.Text == null || Label104.Text == string.Empty)
                {
                    i = 1;
                }


            }
            if (ddlCSCertificateofCA.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label105.Text == "" || Label105.Text == null || Label105.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSRegdPartnershipDeedArticles.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label106.Text == "" || Label106.Text == null || Label106.Text == string.Empty)
                {
                    i = 1;
                }


            }
            if (ddlCSApprovalDirectorFactories.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label201.Text == "" || Label201.Text == null || Label201.Text == string.Empty)
                {
                    i = 1;
                }


            }
            if (ddlCSBoilersCertificate.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label202.Text == "" || Label202.Text == null || Label202.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label203.Text == "" || Label203.Text == null || Label203.Text == string.Empty)
                {
                    i = 1;
                }

            }

            if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label204.Text == "" || Label204.Text == null || Label204.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSOperationTSPCBAcknowledgementGM.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label205.Text == "" || Label205.Text == null || Label205.Text == string.Empty)
                {
                    i = 1;
                }
            }


            if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label206.Text == "" || Label206.Text == null || Label206.Text == string.Empty)
                {
                    i = 1;
                }
            }

            if (ddlCSEnvironmentalclearance.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label207.Text == "" || Label207.Text == null || Label207.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSOtherstatutoryapprovalsspecif.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label208.Text == "" || Label208.Text == null || Label208.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSEMPartIfullsetIEMIL.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label209.Text == "" || Label209.Text == null || Label209.Text == string.Empty)
                {
                    i = 1;
                }
            }

            if (ddlCSUdyogAadhar.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label210.Text == "" || Label210.Text == null || Label210.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSProjectReport.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label211.Text == "" || Label211.Text == null || Label211.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSTermloansanctionletters.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label212.Text == "" || Label212.Text == null || Label212.Text == string.Empty)
                {
                    i = 1;
                }
            }

            if (ddlCSBoardResolutionauthorizing.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label213.Text == "" || Label213.Text == null || Label213.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label214.Text == "" || Label214.Text == null || Label214.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSCACECertificateregarding2handplantmachinery.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label215.Text == "" || Label215.Text == null || Label215.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSCECertificateSelffabricatedmachinery.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label216.Text == "" || Label216.Text == null || Label216.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSBISCertificate.SelectedItem.Text.ToUpper() == "YES")
            {
                if (HyperLink217.Text == "" || HyperLink217.Text == null || HyperLink217.Text == string.Empty)
                {
                    i = 1;
                }

                //if (Label217.Text == "" || Label217.Text == null || Label217.Text == string.Empty)
                //{
                //    i = 1;
                //}
            }
            if (ddlCSDrugLicense.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label218.Text == "" || Label218.Text == null || Label218.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSExplosiveLicense.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label219.Text == "" || Label219.Text == null || Label219.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSVATCSTSGSTCertificate.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label220.Text == "" || Label220.Text == null || Label220.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSFormA.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label221.Text == "" || Label221.Text == null || Label221.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSFormB.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label222.Text == "" || Label222.Text == null || Label222.Text == string.Empty)
                {
                    i = 1;
                }

            }

            if (ddlProductionParticulars3Years.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label223.Text == "" || Label223.Text == null || Label223.Text == string.Empty)
                {
                    i = 1;
                }

            }

            if (ddlRTACertificate.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label224.Text == "" || Label224.Text == null || Label224.Text == string.Empty)
                {
                    i = 1;
                }

            }

            if (ddlPHCertificate.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label225.Text == "" || Label225.Text == null || Label225.Text == string.Empty)
                {
                    i = 1;
                }

            }

            if (ddlUntertakingForm.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label226.Text == "" || Label226.Text == null || Label226.Text == string.Empty)
                {
                    i = 1;
                }

            }

            if (ddlApplicantVehiclePhoto.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label227.Text == "" || Label227.Text == null || Label227.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCOBORROWER.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label229.Text == "" || Label229.Text == null || Label229.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlcopyofpan.SelectedItem.Text.ToUpper() == "YES")
            {

                if (lblcopyofpan.Text == "" || lblcopyofpan.Text == null || lblcopyofpan.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (DropDownList1.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label1.Text == "" || Label1.Text == null || Label1.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (DropDownList2.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label2.Text == "" || Label2.Text == null || Label2.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (DropDownList3.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label3.Text == "" || Label3.Text == null || Label3.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (DropDownList4.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label4.Text == "" || Label4.Text == null || Label4.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (DropDownList5.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label5.Text == "" || Label5.Text == null || Label5.Text == string.Empty)
                {
                    i = 1;
                }

            }
            return i;
        }

        #region Uploding Document

        protected void btnIncorporation_Click(object sender, EventArgs e)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (fupIncorporation.HasFile)
            {
                if ((fupIncorporation.PostedFile != null) && (fupIncorporation.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fupIncorporation.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fupIncorporation.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\1");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupIncorporation.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupIncorporation.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            string path = newPath + "\\" + sFileName;
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 1, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblIncorporation.Text = fupIncorporation.FileName;
                            hyprlnkIncorporation.Text = fupIncorporation.FileName;
                            hyprlnkIncorporation.NavigateUrl = path;
                            hyprlnkIncorporation.Visible = true;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception ex)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                        throw ex;
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

        protected void Button101_Click(object sender, EventArgs e)
        {

            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload101.HasFile)
            {
                if ((FileUpload101.PostedFile != null) && (FileUpload101.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload101.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload101.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\2");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload101.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload101.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 2, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));

                            string path = newPath + "\\" + sFileName;

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label101.Text = FileUpload101.FileName;
                            HyperLink101.NavigateUrl = path;
                            HyperLink101.Text = FileUpload101.FileName;
                            HyperLink101.Visible = true;

                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button102_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload102.HasFile)
            {
                if ((FileUpload102.PostedFile != null) && (FileUpload102.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload102.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload102.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\5");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload102.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload102.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 5, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label102.Text = FileUpload102.FileName;
                            // Label102.Visible = true;
                            HyperLink102.NavigateUrl = path;
                            HyperLink102.Text = FileUpload102.FileName;
                            HyperLink102.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button103_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload103.HasFile)
            {
                if ((FileUpload103.PostedFile != null) && (FileUpload103.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload103.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload103.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\6");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload103.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload103.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 6, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label103.Text = FileUpload103.FileName;
                            // Label103.Visible = true;
                            HyperLink103.NavigateUrl = path;
                            HyperLink103.Text = FileUpload103.FileName;
                            HyperLink103.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button104_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload104.HasFile)
            {
                if ((FileUpload104.PostedFile != null) && (FileUpload104.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload104.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload104.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\8");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload104.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload104.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 8, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label104.Text = FileUpload104.FileName;
                            HyperLink104.Text = FileUpload104.FileName;
                            HyperLink104.NavigateUrl = path;
                            // Label104.Visible = true;
                            HyperLink104.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button105_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload105.HasFile)
            {
                if ((FileUpload105.PostedFile != null) && (FileUpload105.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload105.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload105.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\7");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload105.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload105.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 7, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label105.Text = FileUpload105.FileName;
                            //Label105.Visible = true;
                            HyperLink105.NavigateUrl = path;
                            HyperLink105.Text = FileUpload105.FileName;
                            HyperLink105.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button106_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload106.HasFile)
            {
                if ((FileUpload106.PostedFile != null) && (FileUpload106.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload106.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload106.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\4");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload106.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload106.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 4, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label106.Text = FileUpload106.FileName;
                            // Label106.Visible = true;
                            HyperLink106.NavigateUrl = path;
                            HyperLink106.Text = FileUpload106.FileName;
                            HyperLink106.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button201_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload201.HasFile)
            {
                if ((FileUpload201.PostedFile != null) && (FileUpload201.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload201.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload201.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\29");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload201.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload201.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 29, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label201.Text = FileUpload201.FileName;
                            //  Label201.Visible = true;
                            HyperLink201.NavigateUrl = path;
                            HyperLink201.Text = FileUpload201.FileName;
                            HyperLink201.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button202_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload202.HasFile)
            {
                if ((FileUpload202.PostedFile != null) && (FileUpload202.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload202.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload202.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\30");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload202.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload202.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 30, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label202.Text = FileUpload202.FileName;
                            // Label202.Visible = true;
                            HyperLink202.NavigateUrl = path;
                            HyperLink202.Text = FileUpload202.FileName;
                            HyperLink202.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button203_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload203.HasFile)
            {
                if ((FileUpload203.PostedFile != null) && (FileUpload203.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload203.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload203.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\31");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload203.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload203.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 31, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label203.Text = FileUpload203.FileName;
                            // Label203.Visible = true;
                            HyperLink203.NavigateUrl = path;
                            HyperLink203.Text = FileUpload203.FileName;
                            HyperLink203.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button204_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload204.HasFile)
            {
                if ((FileUpload204.PostedFile != null) && (FileUpload204.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload204.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload204.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\32");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload204.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload204.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 32, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label204.Text = FileUpload204.FileName;
                            //Label204.Visible = true;
                            HyperLink204.NavigateUrl = path;
                            HyperLink204.Text = FileUpload204.FileName;
                            HyperLink204.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button205_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload205.HasFile)
            {
                if ((FileUpload205.PostedFile != null) && (FileUpload205.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload205.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload205.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\33");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload205.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload205.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 33, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label205.Text = FileUpload205.FileName;
                            // Label205.Visible = true;
                            HyperLink205.NavigateUrl = path;
                            HyperLink205.Text = FileUpload205.FileName;
                            HyperLink205.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button206_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload206.HasFile)
            {
                if ((FileUpload206.PostedFile != null) && (FileUpload206.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload206.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload206.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\34");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload206.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload206.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 34, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label206.Text = FileUpload206.FileName;
                            //Label206.Visible = true;
                            HyperLink206.NavigateUrl = path;
                            HyperLink206.Text = FileUpload206.FileName;
                            HyperLink206.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button207_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload207.HasFile)
            {
                if ((FileUpload207.PostedFile != null) && (FileUpload207.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload207.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload207.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\35");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload207.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload207.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 35, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label207.Text = FileUpload207.FileName;
                            //Label207.Visible = true;
                            HyperLink207.NavigateUrl = path;
                            HyperLink207.Text = FileUpload207.FileName;
                            HyperLink207.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }


        }

        protected void Button208_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload208.HasFile)
            {
                if ((FileUpload208.PostedFile != null) && (FileUpload208.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload208.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload208.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\36");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload208.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload208.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 36, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label208.Text = FileUpload208.FileName;
                            //Label208.Visible = true;
                            HyperLink208.NavigateUrl = path;
                            HyperLink208.Text = FileUpload208.FileName;
                            HyperLink208.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button209_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload209.HasFile)
            {
                if ((FileUpload209.PostedFile != null) && (FileUpload209.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload209.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload209.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\39");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload209.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload209.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 39, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label209.Text = FileUpload209.FileName;
                            // Label209.Visible = true;
                            HyperLink209.NavigateUrl = path;
                            HyperLink209.Text = FileUpload209.FileName;
                            HyperLink209.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }


        }

        protected void Button210_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload210.HasFile)
            {
                if ((FileUpload210.PostedFile != null) && (FileUpload210.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload210.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload210.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\9");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload210.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload210.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 9, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label210.Text = FileUpload210.FileName;
                            // Label210.Visible = true;
                            HyperLink210.NavigateUrl = path;
                            HyperLink210.Text = FileUpload210.FileName;
                            HyperLink210.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button211_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload211.HasFile)
            {
                if ((FileUpload211.PostedFile != null) && (FileUpload211.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload211.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload211.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\10");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload211.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload211.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 10, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label211.Text = FileUpload211.FileName;
                            //Label211.Visible = true;
                            HyperLink211.NavigateUrl = path;
                            HyperLink211.Text = FileUpload211.FileName;
                            HyperLink211.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button212_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload212.HasFile)
            {
                if ((FileUpload212.PostedFile != null) && (FileUpload212.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload212.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload212.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\28");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload212.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload212.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 28, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label212.Text = FileUpload212.FileName;
                            //Label212.Visible = true;
                            HyperLink212.NavigateUrl = path;
                            HyperLink212.Text = FileUpload212.FileName;
                            HyperLink212.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button213_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload213.HasFile)
            {
                if ((FileUpload213.PostedFile != null) && (FileUpload213.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload213.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload213.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\37");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload213.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload213.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 37, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label213.Text = FileUpload213.FileName;
                            //Label213.Visible = true;
                            HyperLink213.NavigateUrl = path;
                            HyperLink213.Text = FileUpload213.FileName;
                            HyperLink213.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button214_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload214.HasFile)
            {
                if ((FileUpload214.PostedFile != null) && (FileUpload214.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload214.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload214.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\20");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload214.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload214.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 20, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label214.Text = FileUpload214.FileName;
                            //Label214.Visible = true;
                            HyperLink214.NavigateUrl = path;
                            HyperLink214.Text = FileUpload214.FileName;
                            HyperLink214.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button215_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload215.HasFile)
            {
                if ((FileUpload215.PostedFile != null) && (FileUpload215.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload215.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload215.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\11");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload215.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload215.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 11, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label215.Text = FileUpload215.FileName;
                            //Label215.Visible = true;
                            HyperLink215.NavigateUrl = path;
                            HyperLink215.Text = FileUpload215.FileName;
                            HyperLink215.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }


        }

        protected void Button216_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload216.HasFile)
            {
                if ((FileUpload216.PostedFile != null) && (FileUpload216.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload216.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload216.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\12");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload216.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload216.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 12, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label216.Text = FileUpload216.FileName;
                            // Label216.Visible = true;
                            HyperLink216.NavigateUrl = path;
                            HyperLink216.Text = FileUpload216.FileName;
                            HyperLink216.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button217_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload217.HasFile)
            {
                if ((FileUpload217.PostedFile != null) && (FileUpload217.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload217.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload217.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\13");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload217.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload217.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 13, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label217.Text = FileUpload217.FileName;
                            // Label217.Visible = true;
                            HyperLink217.NavigateUrl = path;
                            HyperLink217.Text = FileUpload217.FileName;
                            HyperLink217.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button218_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload218.HasFile)
            {
                if ((FileUpload218.PostedFile != null) && (FileUpload218.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload218.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload218.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\14");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload218.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload218.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 14, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label218.Text = FileUpload218.FileName;
                            // Label218.Visible = true;
                            HyperLink218.NavigateUrl = path;
                            HyperLink218.Text = FileUpload218.FileName;
                            HyperLink218.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }


        }

        protected void Button219_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload219.HasFile)
            {
                if ((FileUpload219.PostedFile != null) && (FileUpload219.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload219.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload219.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\15");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload219.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload219.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 15, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label219.Text = FileUpload219.FileName;
                            // Label219.Visible = true;
                            HyperLink219.NavigateUrl = path;
                            HyperLink219.Text = FileUpload219.FileName;
                            HyperLink219.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button220_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload220.HasFile)
            {
                if ((FileUpload220.PostedFile != null) && (FileUpload220.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload220.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload220.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\16");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload220.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload220.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 16, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label220.Text = FileUpload220.FileName;
                            // Label220.Visible = true;
                            HyperLink220.NavigateUrl = path;
                            HyperLink220.Text = FileUpload220.FileName;
                            HyperLink220.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button221_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload221.HasFile)
            {
                if ((FileUpload221.PostedFile != null) && (FileUpload221.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload221.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload221.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\19");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload221.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload221.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 19, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label221.Text = FileUpload221.FileName;
                            // Label221.Visible = true;
                            HyperLink221.NavigateUrl = path;
                            HyperLink221.Text = FileUpload221.FileName;
                            HyperLink221.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button222_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload222.HasFile)
            {
                if ((FileUpload222.PostedFile != null) && (FileUpload222.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload222.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload222.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\22");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload222.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload222.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 22, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label222.Text = FileUpload222.FileName;
                            // Label222.Visible = true;
                            HyperLink222.NavigateUrl = path;
                            HyperLink222.Text = FileUpload222.FileName;
                            HyperLink222.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button223_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload223.HasFile)
            {
                if ((FileUpload223.PostedFile != null) && (FileUpload223.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload223.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload223.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\21");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload223.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload223.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 21, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label223.Text = FileUpload223.FileName;
                            // Label222.Visible = true;
                            HyperLink223.NavigateUrl = path;
                            HyperLink223.Text = FileUpload223.FileName;
                            HyperLink223.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button224_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload224.HasFile)
            {
                if ((FileUpload224.PostedFile != null) && (FileUpload224.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload224.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload224.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\23");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload224.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload224.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 23, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label224.Text = FileUpload224.FileName;
                            // Label222.Visible = true;
                            HyperLink224.NavigateUrl = path;
                            HyperLink224.Text = FileUpload224.FileName;
                            HyperLink224.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }

        }

        protected void Button225_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload225.HasFile)
            {
                if ((FileUpload225.PostedFile != null) && (FileUpload225.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload225.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload225.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\24");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload225.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload225.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 24, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label225.Text = FileUpload225.FileName;
                            // Label222.Visible = true;
                            HyperLink225.NavigateUrl = path;
                            HyperLink225.Text = FileUpload225.FileName;
                            HyperLink225.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button226_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload226.HasFile)
            {
                if ((FileUpload226.PostedFile != null) && (FileUpload226.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload226.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload226.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\25");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload226.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload226.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 25, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label226.Text = FileUpload226.FileName;
                            // Label222.Visible = true;
                            HyperLink226.NavigateUrl = path;
                            HyperLink226.Text = FileUpload226.FileName;
                            HyperLink226.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button227_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload227.HasFile)
            {
                if ((FileUpload227.PostedFile != null) && (FileUpload227.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload227.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload227.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\27");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload227.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload227.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 27, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label227.Text = FileUpload227.FileName;
                            // Label222.Visible = true;
                            HyperLink227.NavigateUrl = path;
                            HyperLink227.Text = FileUpload227.FileName;
                            HyperLink227.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button228_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload228.HasFile)
            {
                if ((FileUpload228.PostedFile != null) && (FileUpload228.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload228.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload228.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\38");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))
                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload228.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);
                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload228.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 38, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label228.Text = FileUpload228.FileName;
                            // Label222.Visible = true;
                            HyperLink228.NavigateUrl = path;
                            HyperLink228.Text = FileUpload228.FileName;
                            HyperLink228.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }
                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim();
            }
        }

        protected void Button229_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload229.HasFile)
            {
                if ((FileUpload229.PostedFile != null) && (FileUpload229.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload229.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload229.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\100019");
                            // Create the subfolder
                            if (!Directory.Exists(newPath))
                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload229.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);
                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload229.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 1001, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));

                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label229.Text = FileUpload229.FileName;
                            // Label222.Visible = true;
                            HyperLink229.Text = FileUpload229.FileName;
                            HyperLink229.Visible = true;
                            Button229.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }
                    }
                    catch (Exception)//in case of an error
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
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim();
            }
        }

        protected void btncopyofpan_Click(object sender, EventArgs e)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (fupcopyofpan.HasFile)
            {
                if ((fupcopyofpan.PostedFile != null) && (fupcopyofpan.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(fupcopyofpan.PostedFile.FileName);
                    try
                    {
                        string[] fileType = fupcopyofpan.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\3");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                fupcopyofpan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    fupcopyofpan.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 3, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            lblcopyofpan.Text = fupcopyofpan.FileName;
                            hyprlnkcopyofpan.NavigateUrl = path;
                            hyprlnkcopyofpan.Text = fupcopyofpan.FileName;
                            hyprlnkcopyofpan.Visible = true;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload1.HasFile)
            {
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\42");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload1.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 42, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            //objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()),
                            //                          1001,
                            //                          sFileName,
                            //                          newPath,
                            //                          Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label1.Text = FileUpload1.FileName;
                            HyperLink1.NavigateUrl = path;
                            HyperLink1.Text = FileUpload1.FileName;
                            HyperLink1.Visible = true;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload2.HasFile)
            {
                if ((FileUpload2.PostedFile != null) && (FileUpload2.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload2.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload2.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\45");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload2.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 45, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label2.Text = FileUpload2.FileName;
                            HyperLink2.Text = FileUpload2.FileName;
                            HyperLink2.NavigateUrl = path;
                            HyperLink2.Visible = true;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload3.HasFile)
            {
                if ((FileUpload3.PostedFile != null) && (FileUpload3.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload3.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload3.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\46");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload3.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 46, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label3.Text = FileUpload3.FileName;
                            HyperLink3.Text = FileUpload3.FileName;
                            HyperLink3.NavigateUrl = path;
                            HyperLink3.Visible = true;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload4.HasFile)
            {
                if ((FileUpload4.PostedFile != null) && (FileUpload4.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload4.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload4.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\47");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload4.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 47, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label4.Text = FileUpload4.FileName;
                            HyperLink4.Text = FileUpload4.FileName;
                            HyperLink4.NavigateUrl = path;
                            HyperLink4.Visible = true;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            string newPath = "";
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload5.HasFile)
            {
                if ((FileUpload5.PostedFile != null) && (FileUpload5.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload5.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload5.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\48");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload5.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDml.InsUpdDeltd_Incentive_UploadsIncentives(Convert.ToInt32(Session["IncentiveID"].ToString()), 48, sFileName,  newPath, Convert.ToInt32(Session["uid"].ToString()));
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label5.Text = FileUpload5.FileName;
                            HyperLink5.Text = FileUpload5.FileName;
                            HyperLink5.NavigateUrl = path;
                            HyperLink5.Visible = true;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
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
        {//Delete file from the server
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        #endregion

        #region File upload visibility based on dropdown selection

        protected void ddlIncorporation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIncorporation.SelectedItem.Text.ToUpper() == "YES")
            {
                fupIncorporation.Visible = true;
                btnIncorporation.Visible = true;
                lblIncorporation.Visible = false;
                hyprlnkIncorporation.Visible = true;
            }
            else
            {
                fupIncorporation.Visible = false;
                btnIncorporation.Visible = false;
                hyprlnkIncorporation.Visible = false;
                lblIncorporation.Visible = false;
            }
        }

        public void FUPVisible(Boolean str, FileUpload fuDocuments, Button btnUpload, Label lblAttachedFileName, Label lblupload)
        {
            fuDocuments.Visible = str;
            btnUpload.Visible = str;
            lblAttachedFileName.Visible = str;
            lblupload.Visible = str;
        }

        protected void ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Failure.Visible = false;
            if (ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload101.Visible = true;
                Button101.Visible = true;
                HyperLink101.Visible = true;
                Label101.Visible = false;
            }
            else
            {

                FileUpload101.Visible = false;
                Button101.Visible = false;
                HyperLink101.Visible = false;
                Label101.Visible = false;
            }
        }

        protected void ddlCSEntrepreneurAadhar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Failure.Visible = false;
            if (ddlCSEntrepreneurAadhar.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload103.Visible = true;
                Button103.Visible = true;
                HyperLink103.Visible = true;
                Label103.Visible = false;
            }
            else
            {
                FileUpload103.Visible = false;
                Button103.Visible = false;
                HyperLink103.Visible = false;
                Label103.Visible = false;
            }
        }

        protected void ddlCSEntrepreneurPANCard_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Failure.Visible = false;
            if (ddlCSEntrepreneurPANCard.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload104.Visible = true;
                Button104.Visible = true;
                HyperLink104.Visible = true;
                Label104.Visible = false;
            }
            else
            {

                FileUpload104.Visible = false;
                Button104.Visible = false;
                HyperLink104.Visible = false;
                Label104.Visible = false;
            }
        }

        protected void ddlCSCertificateofCA_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Failure.Visible = false;
            if (ddlCSCertificateofCA.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload105.Visible = true;
                Button105.Visible = true;
                HyperLink105.Visible = true;
                Label105.Visible = false;
            }
            else
            {
                FileUpload105.Visible = false;
                Button105.Visible = false;
                HyperLink105.Visible = false;
                Label105.Visible = false;
            }
        }

        protected void ddlCSRegdPartnershipDeedArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Failure.Visible = false;
            if (ddlCSRegdPartnershipDeedArticles.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload106.Visible = true;
                Button106.Visible = true;
                HyperLink106.Visible = true;
                Label106.Visible = false;
            }
            else
            {
                FileUpload106.Visible = false;
                Button106.Visible = false;
                HyperLink106.Visible = false;
                Label106.Visible = false;
            }


        }

        protected void ddlCSApprovalDirectorFactories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSApprovalDirectorFactories.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload201.Visible = true;
                Button201.Visible = true;
                HyperLink201.Visible = true;
                Label201.Visible = false;
            }
            else
            {
                FileUpload201.Visible = false;
                Button201.Visible = false;
                HyperLink201.Visible = false;
                Label201.Visible = false;
            }

        }

        protected void ddlCSBoilersCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSBoilersCertificate.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload202.Visible = true;
                Button202.Visible = true;
                HyperLink202.Visible = true;
                Label202.Visible = false;
            }
            else
            {
                FileUpload202.Visible = false;
                Button202.Visible = false;
                HyperLink202.Visible = false;
                Label202.Visible = false;
            }
        }

        protected void ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload203.Visible = true;
                Button203.Visible = true;
                HyperLink203.Visible = true;
                Label203.Visible = false;
            }
            else
            {
                FileUpload203.Visible = false;
                Button203.Visible = false;
                HyperLink203.Visible = false;
                Label203.Visible = false;
            }

        }

        protected void ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload204.Visible = true;
                Button204.Visible = true;
                HyperLink204.Visible = true;
                Label204.Visible = false;
            }
            else
            {
                FileUpload204.Visible = false;
                Button204.Visible = false;
                HyperLink204.Visible = false;
                Label204.Visible = false;
            }

        }

        protected void ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSOperationTSPCBAcknowledgementGM.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload205.Visible = true;
                Button205.Visible = true;
                HyperLink205.Visible = true;
                Label205.Visible = false;
            }
            else
            {
                FileUpload205.Visible = false;
                Button205.Visible = false;
                HyperLink205.Visible = false;
                Label205.Visible = false;
            }

        }

        protected void ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Failure.Visible = false;
            if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload206.Visible = true;
                Button206.Visible = true;
                HyperLink206.Visible = true;
                Label206.Visible = false;
            }
            else
            {
                FileUpload206.Visible = false;
                Button206.Visible = false;
                HyperLink206.Visible = false;
                Label206.Visible = false;
            }
        }

        protected void ddlCSEnvironmentalclearance_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSEnvironmentalclearance.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload207.Visible = true;
                Button207.Visible = true;
                HyperLink207.Visible = true;
                Label207.Visible = false;
            }
            else
            {
                FileUpload207.Visible = false;
                Button207.Visible = false;
                HyperLink207.Visible = false;
                Label207.Visible = false;
            }

        }

        protected void ddlCSOtherstatutoryapprovalsspecif_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Failure.Visible = false;
            if (ddlCSOtherstatutoryapprovalsspecif.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload208.Visible = true;
                Button208.Visible = true;
                HyperLink208.Visible = true;
                Label208.Visible = false;
            }
            else
            {
                FileUpload208.Visible = false;
                Button208.Visible = false;
                HyperLink208.Visible = false;
                Label208.Visible = false;
            }

        }

        protected void ddlCSEMPartIfullsetIEMIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSEMPartIfullsetIEMIL.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload209.Visible = true;
                Button209.Visible = true;
                HyperLink209.Visible = true;
                Label209.Visible = false;
            }
            else
            {
                FileUpload209.Visible = false;
                Button209.Visible = false;
                HyperLink209.Visible = false;
                Label209.Visible = false;
            }

        }

        protected void ddlCSUdyogAadhar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSUdyogAadhar.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload210.Visible = true;
                Button210.Visible = true;
                HyperLink210.Visible = true;
                Label210.Visible = false;
            }
            else
            {
                FileUpload210.Visible = false;
                Button210.Visible = false;
                HyperLink210.Visible = false;
                Label210.Visible = false;
            }

        }

        protected void ddlCSProjectReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Failure.Visible = false;
            if (ddlCSProjectReport.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload211.Visible = true;
                Button211.Visible = true;
                HyperLink211.Visible = true;
                Label211.Visible = false;
            }
            else
            {
                //FUPVisible(false, fuDocuments1, btnUpload1, lblAttachedFileName1, lblupload1);
                // FUPVisible(false, fuDocuments1, btnUpload1, lblAttachedFileName1, lblupload1);
                FileUpload211.Visible = false;
                Button211.Visible = false;
                HyperLink211.Visible = false;
                Label211.Visible = false;
            }

        }

        protected void ddlCSTermloansanctionletters_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSTermloansanctionletters.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload212.Visible = true;
                Button212.Visible = true;
                HyperLink212.Visible = true;
                Label212.Visible = false;
            }
            else
            {
                FileUpload212.Visible = false;
                Button212.Visible = false;
                HyperLink212.Visible = false;
                Label212.Visible = false;
            }
        }

        protected void ddlCSBoardResolutionauthorizing_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSBoardResolutionauthorizing.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload213.Visible = true;
                Button213.Visible = true;
                HyperLink213.Visible = true;
                Label213.Visible = false;
            }
            else
            {
                FileUpload213.Visible = false;
                Button213.Visible = false;
                HyperLink213.Visible = false;
                Label213.Visible = false;
            }

        }

        protected void ddlCSRegisteredlandSaledeedPremisesLeasedeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Failure.Visible = false;
            if (ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload214.Visible = true;
                Button214.Visible = true;
                HyperLink214.Visible = true;
                Label214.Visible = false;
            }
            else
            {
                FileUpload214.Visible = false;
                Button214.Visible = false;
                HyperLink214.Visible = false;
                Label214.Visible = false;
            }

        }

        protected void ddlCSCACECertificateregarding2handplantmachinery_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSCACECertificateregarding2handplantmachinery.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload215.Visible = true;
                Button215.Visible = true;
                HyperLink215.Visible = true;
                Label215.Visible = false;
            }
            else
            {
                FileUpload215.Visible = false;
                Button215.Visible = false;
                HyperLink215.Visible = false;
                Label215.Visible = false;
            }

        }

        protected void ddlCSCECertificateSelffabricatedmachinery_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Failure.Visible = false;
            if (ddlCSCECertificateSelffabricatedmachinery.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload216.Visible = true;
                Button216.Visible = true;
                HyperLink216.Visible = true;
                Label216.Visible = false;
            }
            else
            {
                FileUpload216.Visible = false;
                Button216.Visible = false;
                HyperLink216.Visible = false;
                Label216.Visible = false;
            }


        }

        protected void ddlCSBISCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSBISCertificate.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload217.Visible = true;
                Button217.Visible = true;
                HyperLink217.Visible = true;
                Label217.Visible = false;
            }
            else
            {
                //FUPVisible(false, fuDocuments1, btnUpload1, lblAttachedFileName1, lblupload1);
                // FUPVisible(false, fuDocuments1, btnUpload1, lblAttachedFileName1, lblupload1);
                FileUpload217.Visible = false;
                Button217.Visible = false;
                HyperLink217.Visible = false;
                Label217.Visible = false;
            }

        }

        protected void ddlCSDrugLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSDrugLicense.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload218.Visible = true;
                Button218.Visible = true;
                HyperLink218.Visible = true;
                Label218.Visible = false;
            }
            else
            {
                FileUpload218.Visible = false;
                Button218.Visible = false;
                HyperLink218.Visible = false;
                Label218.Visible = false;
                Failure.Visible = false;
            }

        }

        protected void ddlCSExplosiveLicense_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSExplosiveLicense.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload219.Visible = true;
                Button219.Visible = true;
                HyperLink219.Visible = true;
                Label219.Visible = false;
            }
            else
            {
                FileUpload219.Visible = false;
                Button219.Visible = false;
                HyperLink219.Visible = false;
                Label219.Visible = false;
            }

        }

        protected void ddlCSVATCSTSGSTCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSVATCSTSGSTCertificate.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload220.Visible = true;
                Button220.Visible = true;
                HyperLink220.Visible = true;
                Label220.Visible = false;
            }
            else
            {
                FileUpload220.Visible = false;
                Button220.Visible = false;
                HyperLink220.Visible = false;
                Label220.Visible = false;
            }

        }

        protected void ddlCSFormA_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSFormA.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload221.Visible = true;
                Button221.Visible = true;
                HyperLink221.Visible = true;
                Label221.Visible = false;
            }
            else
            {
                FileUpload221.Visible = false;
                Button221.Visible = false;
                HyperLink221.Visible = false;
                Label221.Visible = false;
            }


        }

        protected void ddlCSFormB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Failure.Visible = false;
            if (ddlCSFormB.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload222.Visible = true;
                Button222.Visible = true;
                HyperLink222.Visible = true;
                Label222.Visible = false;
            }
            else
            {
                FileUpload222.Visible = false;
                Button222.Visible = false;
                HyperLink222.Visible = false;
                Label222.Visible = false;
            }

        }

        protected void ddlCSCasteCertificatesSCST_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSCasteCertificatesSCST.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload102.Visible = true;
                Button102.Visible = true;
                HyperLink102.Visible = true;
                Label102.Visible = false;
            }
            else
            {
                FileUpload102.Visible = false;
                Button102.Visible = false;
                HyperLink102.Visible = false;
                Label102.Visible = false;
            }

        }

        protected void ddlProductionParticulars3Years_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlProductionParticulars3Years.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload223.Visible = true;
                Button223.Visible = true;
                HyperLink223.Visible = true;
                Label223.Visible = false;
            }
            else
            {
                FileUpload223.Visible = false;
                Button223.Visible = false;
                HyperLink223.Visible = false;
                Label223.Visible = false;
            }

        }

        protected void ddlRTACertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRTACertificate.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload224.Visible = true;
                Button224.Visible = true;
                HyperLink224.Visible = true;
                Label224.Visible = false;
            }
            else
            {
                FileUpload224.Visible = false;
                Button224.Visible = false;
                HyperLink224.Visible = false;
                Label224.Visible = false;
            }
        }

        protected void ddlPHCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Failure.Visible = false;
            if (ddlPHCertificate.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload225.Visible = true;
                Button225.Visible = true;
                HyperLink225.Visible = true;
                Label225.Visible = false;
            }
            else
            {
                FileUpload225.Visible = false;
                Button225.Visible = false;
                HyperLink225.Visible = false;
                Label225.Visible = false;
            }
        }

        protected void ddlUntertakingForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlUntertakingForm.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload226.Visible = true;
                Button226.Visible = true;
                HyperLink226.Visible = true;
                Label226.Visible = false;
            }
            else
            {
                FileUpload226.Visible = false;
                Button226.Visible = false;
                HyperLink226.Visible = false;
                Label226.Visible = false;
            }
        }

        protected void ddlApplicantVehiclePhoto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlApplicantVehiclePhoto.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload227.Visible = true;
                Button227.Visible = true;
                HyperLink227.Visible = true;
                Label227.Visible = false;
            }
            else
            {
                FileUpload227.Visible = false;
                Button227.Visible = false;
                HyperLink227.Visible = false;
                Label227.Visible = false;
            }
        }

        protected void ddlfirstsalebill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlfirstsalebill.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload228.Visible = true;
                Button228.Visible = true;
                HyperLink228.Visible = true;
                Label228.Visible = false;
            }
            else
            {
                FileUpload228.Visible = false;
                Button228.Visible = false;
                HyperLink228.Visible = false;
                Label228.Visible = false;
            }
        }

        protected void ddlCOBORROWER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCOBORROWER.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload229.Visible = true;
                Button229.Visible = true;
                HyperLink229.Visible = true;
                Label229.Visible = false;
            }

            else
            {
                FileUpload229.Visible = false;
                Button229.Visible = false;
                HyperLink229.Visible = false;
                Label229.Visible = false;
            }
        }

        protected void ddlcopyofpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlcopyofpan.SelectedItem.Text.ToUpper() == "YES")
            {
                fupcopyofpan.Visible = true;
                btncopyofpan.Visible = true;
                hyprlnkcopyofpan.Visible = true;
                lblcopyofpan.Visible = false;
            }
            else
            {
                fupcopyofpan.Visible = false;
                btncopyofpan.Visible = false;
                hyprlnkcopyofpan.Visible = false;
                lblcopyofpan.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload1.Visible = true;
                Button1.Visible = true;
                HyperLink1.Visible = true;
                Label1.Visible = false;
            }
            else
            {
                FileUpload1.Visible = false;
                Button1.Visible = false;
                HyperLink1.Visible = false;
                Label1.Visible = false;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload2.Visible = true;
                Button2.Visible = true;
                HyperLink2.Visible = true;
                Label2.Visible = false;
            }
            else
            {
                FileUpload2.Visible = false;
                Button2.Visible = false;
                HyperLink2.Visible = false;
                Label2.Visible = false;
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload3.Visible = true;
                Button3.Visible = true;
                HyperLink3.Visible = true;
                Label3.Visible = false;
            }
            else
            {
                FileUpload3.Visible = false;
                Button3.Visible = false;
                HyperLink3.Visible = false;
                Label3.Visible = false;
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList4.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload4.Visible = true;
                Button4.Visible = true;
                HyperLink4.Visible = true;
                Label4.Visible = false;
            }
            else
            {
                FileUpload4.Visible = false;
                Button4.Visible = false;
                HyperLink4.Visible = false;
                Label4.Visible = false;
            }
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList5.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload5.Visible = true;
                Button5.Visible = true;
                HyperLink5.Visible = true;
                Label5.Visible = false;
            }
            else
            {
                FileUpload5.Visible = false;
                Button5.Visible = false;
                HyperLink5.Visible = false;
                Label5.Visible = false;
            }
        }
        #endregion

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int valid = 0;
            try
            {
                int i = Convert.ToInt32(ValidateFileUploads());
                if (i == 1)
                {
                    lblmsg0.Text = "<font color=Red>Please Upload Mandatory File Uploads</font></br>";
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Visible = true;
                }
                else
                {
                    AssignValuesToVosFromControls();
                    valid = objDAL.InsertCheckListDB(objBO);

                    if (valid >= 1)
                    {
                        string message = "alert('Checkslips Uploaded Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        //BtnNext.Enabled = true;
                        //BtnSave.Enabled = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color=Red>Submission Failed</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        //BtnNext.Visible = false;
                    }
                }

            }

            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        public void AssignValuesToVosFromControls()
        {
            try
            {
                objBO.CSCreatedBy = Convert.ToInt32(Session["uid"].ToString());
                objBO.CSIncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                objBO.CSbillsofinstitutfinancedEnterpriseindustries = ddlIncorporation.SelectedValue.Trim();
                objBO.CSbillandpymtproofrespectofselffinancedEnterprisesindustries = ddlCSbillandpymtproofrespectofselffinancedEnterprisesindustries.SelectedValue.Trim();
                objBO.CasteCertificatesSCST = ddlCSCasteCertificatesSCST.SelectedValue.Trim();
                objBO.CSEntrepreneurAadhar = ddlCSEntrepreneurAadhar.SelectedValue.Trim();
                objBO.CSEntrepreneurPANCard = ddlCSEntrepreneurPANCard.SelectedValue.Trim();
                objBO.CSCertificateofCA = ddlCSCertificateofCA.SelectedValue.Trim();
                objBO.CSRegdPartnershipDeedArticles = ddlCSRegdPartnershipDeedArticles.SelectedValue.Trim();
                objBO.CSApprovalDirectorFactories = ddlCSApprovalDirectorFactories.SelectedValue.Trim();
                objBO.CSBoilersCertificate = ddlCSBoilersCertificate.SelectedValue.Trim();
                objBO.CSApprovalDirectorTownCountryPlanningUDA = ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue.Trim();
                objBO.CSRegularbuildingplansapprovalofMunicipalityGramPanchayat = ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue.Trim();
                objBO.CSOperationTSPCBAcknowledgementGM = ddlCSOperationTSPCBAcknowledgementGM.SelectedValue.Trim();
                objBO.CSPowerreleaseCertificatefrmTSTRANSCODISCOM = ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue.Trim();
                objBO.CSEnvironmentalclearance = ddlCSEnvironmentalclearance.SelectedValue.Trim();
                objBO.CSOtherstatutoryapprovalsspecif = ddlCSOtherstatutoryapprovalsspecif.SelectedValue.Trim();
                objBO.CSEMPartIfullsetIEMIL = ddlCSEMPartIfullsetIEMIL.SelectedValue.Trim();
                objBO.CSUdyogAadhar = ddlCSUdyogAadhar.SelectedValue.Trim();
                objBO.CSProjectReport = ddlCSProjectReport.SelectedValue.Trim();
                objBO.CSTermloansanctionletters = ddlCSTermloansanctionletters.SelectedValue.Trim();
                objBO.CSBoardResolutionauthorizing = ddlCSBoardResolutionauthorizing.SelectedValue.Trim();
                objBO.CSRegisteredlandSaledeedPremisesLeasedeed = ddlCSRegisteredlandSaledeedPremisesLeasedeed.SelectedValue.Trim();
                objBO.CSCACECertificateregarding2handplantmachinery = ddlCSCACECertificateregarding2handplantmachinery.SelectedValue.Trim();
                objBO.CSCECertificateSelffabricatedmachinery = ddlCSCECertificateSelffabricatedmachinery.SelectedValue.Trim();
                objBO.CSBISCertificate = ddlCSBISCertificate.SelectedValue.Trim();
                objBO.CSDrugLicense = ddlCSDrugLicense.SelectedValue.Trim();
                objBO.CSExplosiveLicense = ddlCSExplosiveLicense.SelectedValue.Trim();
                objBO.CSVATCSTSGSTCertificate = ddlCSVATCSTSGSTCertificate.SelectedValue.Trim();
                objBO.CSFormA = ddlCSFormA.SelectedValue.Trim();
                objBO.CSFormB = ddlCSFormB.SelectedValue.Trim();
                objBO.CSProductionParticulars3Years = ddlProductionParticulars3Years.SelectedValue.Trim();
                objBO.CSRTACertificate = ddlRTACertificate.SelectedValue.Trim();
                objBO.CSPHCertificate = ddlPHCertificate.SelectedValue.Trim();
                objBO.CSUndertakingForm = ddlUntertakingForm.SelectedValue.Trim();
                objBO.ApplicantVehPhoto = ddlApplicantVehiclePhoto.SelectedValue.Trim();
                objBO.firstsalebill = ddlfirstsalebill.SelectedValue.Trim();
                objBO.COBORROWER = ddlCOBORROWER.SelectedValue.Trim();

                objBO.CopyofPan = ddlcopyofpan.SelectedValue.Trim();
                objBO.DocFirstInvestment = DropDownList1.SelectedValue.Trim();
                objBO.InvestmentCertificate = DropDownList2.SelectedValue.Trim();
                objBO.EngineersCertificate = DropDownList3.SelectedValue.Trim();
                objBO.CopyofReceipts = DropDownList4.SelectedValue.Trim();
                objBO.ExpenditureCertificate = DropDownList5.SelectedValue.Trim();

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {

            //BtnNext.PostBackUrl = "../../UI/Tsipass/IncetivesNewForm2.aspx";
            BtnNext.PostBackUrl = "~/UI/Pages/IncentiveFormTTap.aspx";
            Response.Redirect(BtnNext.PostBackUrl, false);
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                int valid = 0;


                int i = Convert.ToInt32(ValidateFileUploads());
                if (i == 1)
                {
                    lblmsg0.Text = "<font color=Red>Please Upload Mandatory File Uploads</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                    BtnNext.Visible = false;
                    lblmsg0.Visible = true;
                }
                else
                {
                    AssignValuesToVosFromControls();
                    valid = objDAL.InsertCheckListDB(objBO);

                    if (valid >= 1)
                    {
                        //lblmsg.Text = "<font color=black>application submitted sucessfully</font>";
                        //success.Visible = true;

                        string message = "alert('Checkslips Uploaded Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        BtnNext.Enabled = true;
                        BtnSave.Enabled = false;
                        //BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                        BtnNext.PostBackUrl = "~/UI/Pages/TypeOfIncentivesNew.aspx";
                        Response.Redirect(BtnNext.PostBackUrl, false);
                    }
                    else
                    {
                        lblmsg0.Text = "<font color=Red>Submission Failed</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        BtnNext.Visible = false;
                        //BtnNext.PostBackUrl = "../../UI/Tsipass/TypeOfIncentivesNew.aspx";
                    }
                }


            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
            }

        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../IncentivesCheckSlip.aspx");
        }
    }
}