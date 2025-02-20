<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PowerSubsidyAppraisalPrint.aspx.cs" Inherits="TTAP.UI.Pages.PowerSubsidyAppraisalPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Capital Appraisal Note</title>
    <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            border: 2px solid ActiveCaptionText;
            padding: 8px;
        }

        }

        .auto-style1 {
            width: 333px;
        }

        .auto-style2 {
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="../../../images/logo.png" width="75px" height="75px" />
                    </center>
                    <%--<h3>TTAP CAPITAL APPRAISAL NOTE FORM</h3>--%>
                </div>
                <br />
                <div>
                    <div>
                        <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                            <tr id="tideaTr" runat="server" visible="false">
                                <td style="text-align: left; font-weight: bold;">
                                    <asp:Label ID="lblTideaTpride" runat="server" Visible="false" Text="Label"></asp:Label>
                                    Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO
                                29, Industries &amp; Commerce (IP &amp; INF) Department,
                                <br />
                                    Dated : 29/11/2014
                                </td>
                            </tr>
                            <tr id="tprideTr" runat="server" visible="false">
                                <td style="text-align: center; font-weight: bold;">T-PRIDE -
                                <asp:Label ID="lblCaste" runat="server" Visible="false" Text="Label"></asp:Label>
                                    - G.O M.S. NO 29, Industries &amp; Commerce (IP &amp; INF) Department,
                                <br />
                                    Dated : 29/11/2014
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; vertical-align: middle">
                                    <u><b>
                                        <%--Telangana State Industrial Development and Entrepreneur Advancement - GO MS. NO 28, Industries & Commerce (IP & INF) Department, Dated : 29/11/2014--%>
                                   Power Subsidy Appraisal Note<br />

                                        <asp:Label ID="lblSancIncentiveName" runat="server"></asp:Label>
                                    </b></u>
                                </td>
                            </tr>
                        </table>
                        <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">

                            <tr>
                                <td style="width: 2%"></td>
                                <td style="font: bolder; font-size: small" class="auto-style1">
                                    <b>1. Unit Name</b>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label></b> &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">2. Address
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">3. Name of the Proprietor
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblProprietor" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">4. Constitution of Organization
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblConstitutionOfIndustrial" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">5. Social Status
                                </td>
                                <td>
                                    <asp:Label ID="lblSocialStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">6. Share of SC/ST/Women Enterpreneur
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblShareofSCSTWomenEnterprenue" runat="server"></asp:Label>

                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">7. Registration Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblRegistrationNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">8. Type of Unit
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofApplicant" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">9. Category of Unit as per Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCategoryofUnit" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">10. Type of Sector
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApplicationDateDIC" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">11. Type of Textile as per Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofTexttile" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">12. Technical Textile Type
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTechnicalTextileType" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">13.  Activity of the Unit
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblActivityoftheUnit" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">14. UID Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUIDNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">15.  Incentive Application Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCommonApplicationNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">16.  Date of Power Connection Release
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPowerConnectionReleaseDate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">17.  Commencement of Commercial Production
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDCPdate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">18.  Date of Receipt of Claim Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblReceiptDate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">19. Promoter Details in case eligible for additional subsidy
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblelbPromoter" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                        </table>


                        <div align="center" id="EligibleINC" runat="server" visible="false">
                            <table style="font-family: Verdana; font-size: small; width: 60%" border="1">
                                <tr>                                   
                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                        <b>ELEGIBLE INCENTIVES</b></td>

                                </tr>

                                <tr>
                                    <td>Month-year
                                    </td>
                                    <td>
                                        <b>Units Consumed In Nos </b>
                                    </td>
                                    <td>
                                        <b>Amount Paid as Per Bill in Rs.</b>
                                    </td>
                                    <td>
                                        <b>Eligible rate Re-imbursement per units</b>
                                    </td>
                                    <td>
                                        <b>Eligible amount Re-imbursement per units</b>
                                    </td>

                                </tr>
                                <tr>

                                    <td colspan="1px">
                                        <asp:Label runat="server" ID="lblMonth1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="lblLand_ProjectCost"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="lblLand_ValueRecommendedByGM"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="lblLandComputed"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="lblLand_GMRec"></asp:Label>
                                    </td>

                                </tr>
                                <tr>

                                    <td>
                                        <asp:Label runat="server" ID="lblMonth2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBuilding_ProjectCost"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBuilding_ValueRecommendedByGM"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBuildingComputed"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblBuilding_GMRec"></asp:Label>
                                    </td>

                                </tr>
                                <tr>

                                    <td>
                                        <asp:Label runat="server" ID="lblMonth3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPlantMachry_ProjectCost"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPlantMachry_ValueRecommendedByGM"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPlantMachryComputed"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPlantMachry_GMRec"></asp:Label>
                                    </td>

                                </tr>
                                <tr>

                                    <td colspan="1.5px">
                                        <asp:Label runat="server" ID="lblMonth4"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFeasibilityStudyCharges_ProjectCost"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFeasibilityStudyCharges_ValueRecommendedByGM"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFeasibilityStudyChargesComputed"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFeasibilityStudyCharges_GMRec"></asp:Label>
                                    </td>

                                </tr>
                                <tr>

                                    <td>
                                        <asp:Label runat="server" ID="lblMonth5"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblVehicles_ProjectCost"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblVehicles_ValueRecommendedByGM"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblVehiclesComputed"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblVehicles_GMRec"></asp:Label>
                                    </td>

                                </tr>
                                <tr>

                                    <td>
                                        <asp:Label runat="server" ID="lblMonth6"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblOthersEligible_ProjectCost"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblOthersEligible_ValueRecommendedByGM"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblOthersEligibleComputed"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblOthersEligible_GMRec"></asp:Label>
                                    </td>

                                </tr>

                            </table>
                        </div>

                        <br />
                        <div align="center" id="Claimperiod" runat="server" visible="false">
                            <table style="font-family: Verdana; font-size: small; width: 60%" border="1">
                                <tr>
                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                        <b>Last Three Years Details</b>
                                    </td>


                                </tr>

                                <tr>

                                    <td>
                                        <b>Financial Year </b>
                                    </td>
                                    <td>
                                        <b>No of Units Utilised</b>
                                    </td>
                                    <td>
                                        <b>Rate per Unit</b>
                                    </td>
                                    <td>
                                        <b>Total Paid by the unit in Rs</b>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="Year1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="Unit1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="RateUnit1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="Total1"></asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server" ID="Year2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Unit2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="RateUnit2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Total2"></asp:Label>
                                    </td>

                                </tr>
                                <tr>

                                    <td>
                                        <asp:Label runat="server" ID="Year3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Unit3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="RateUnit3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Total3"></asp:Label>
                                    </td>

                                </tr>
                              
                            </table>
                        </div>

                        <div class="row" id="units" runat="server" visible="false">
                            <table style="width: 100%">
                                <tr id="tr1" runat="server" visible="true">                                   
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Total units consumed prior to 3 Years</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblConsume3year" runat="server" Text="[Total Unit]"
                                            Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                </tr>
                                <tr id="tr2" runat="server" visible="true">                                   
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Average units EM</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblEMUnits" runat="server" Text="[Average units EM]"
                                            Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                </tr>
                                <tr id="tr3" runat="server" visible="true">                                   
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Base power consumption fixed per year</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblFixedYear" runat="server" Text="[Base power consumption fixed per year]"
                                            Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                </tr>
                                <tr id="tr4" runat="server" visible="true">                                   
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Per month</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblMonth" runat="server" Text="[Per month]"
                                            Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                </tr>



                            </table>
                        </div>

                        <div align="center" id="MonthWise" runat="server" visible="false">
                            <table style="font-family: Verdana; font-size: small; width: 60%" border="1">
                                <tr>
                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                        <b>Month Wise Details</b></td>

                                </tr>
                                <tr>
                                    <td>Month
                                    </td>
                                    <td>
                                        <b>Financial Year </b>
                                    </td>
                                    <td>
                                        <b>Units Consumed in Nos.</b>
                                    </td>
                                    <td>
                                        <b>Amount Paid as per Bill in Rs.</b>
                                    </td>
                                    <td>
                                        <b>Base fixed per month in units</b>
                                    </td>
                                    <td>
                                        <b>Eligible Units i.e over & above Base</b>
                                    </td>
                                    <td>
                                        <b>Eligible rate Re-imbursement per units</b>
                                    </td>
                                    <td>
                                        <b>Eligible amount Re-imbursement per units</b>
                                    </td>

                                </tr>

                                <tr>
                                       <td class="auto-style2">
                                        <asp:Label runat="server" ID="Month1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="Financial1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="ConsumedNO1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="AmountBill1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="FixedMonth1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="EligibleUnits1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="Reimbursement1"></asp:Label>
                                    </td>
                                    <td class="auto-style2">
                                        <asp:Label runat="server" ID="Eligibleamount1"></asp:Label>
                                    </td>
                                 

                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" ID="Month2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Financial2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="ConsumedNO2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="AmountBill2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="FixedMonth2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="EligibleUnits2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Reimbursement2"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Eligibleamount2"></asp:Label>
                                    </td>
                                   

                                </tr>
                                <tr>
                                      <td>
                                        <asp:Label runat="server" ID="Month3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Financial3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="ConsumedNO3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="AmountBill3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="FixedMonth3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="EligibleUnits3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Reimbursement3"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Eligibleamount3"></asp:Label>
                                    </td>
                                  

                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" ID="Month4"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Financial4"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="ConsumedNO4"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="AmountBill4"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="FixedMonth4"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="EligibleUnits4"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Reimbursement4"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Eligibleamount4"></asp:Label>
                                    </td>
                                   

                                </tr>
                                <tr>
                                     <td>
                                        <asp:Label runat="server" ID="Month5"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Financial5"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="ConsumedNO5"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="AmountBill5"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="FixedMont5"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="EligibleUnits5"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Reimbursement5"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Eligibleamount5"></asp:Label>
                                    </td>
                                   

                                </tr>
                                <tr>
                                      <td>
                                        <asp:Label runat="server" ID="Month6"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Financial6"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="ConsumedNO6"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="AmountBill6"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="FixedMonth6"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="EligibleUnits6"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Reimbursement6"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="Eligibleamount6"></asp:Label>
                                    </td>
                                  

                                </tr>





                            </table>
                        </div>


                        <div class="row">
                            <table style="width: 100%">


                                <tr id="tr4231" runat="server" visible="true">
                                    <td class="auto-style56">21.</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Total Amount</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblAmount" runat="server" Text="[Guideline Value]"
                                            Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style55">22.</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">Is Belated</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">:</td>
                                    <td class="auto-style55">
                                        <asp:Label ID="lblBelated" runat="server" CssClass="form-control txtbox txtcomn"
                                            Height="30px" MaxLength="80" TabIndex="36" Width="150px" Text="[TSSFC Norms]"></asp:Label>

                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>23.</td>
                                    <td style="padding: 5px; margin: 5px;">TOTAL Eligible Amount</td>
                                    <td style="padding: 5px; margin: 5px;">:</td>
                                    <td>&nbsp;
                           <asp:Label ID="lblEligibletotal" runat="server" CssClass="form-control txtbox txtcomn"
                               Height="30px" MaxLength="80" TabIndex="37" Width="150px" Text="[Value 424]"></asp:Label>

                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>24.</td>
                                    <td style="padding: 5px; margin: 5px;">GM Recommended Amount</td>
                                    <td style="padding: 5px; margin: 5px;">:</td>
                                    <td>&nbsp;
                           <asp:Label ID="lblGMRecommend" runat="server" CssClass="form-control txtbox txtcomn"
                               Height="30px" TabIndex="37" Width="150px" Text="[Remarks]"></asp:Label>

                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">25.</td>
                                    <td style="padding: 5px; margin: 5px;">If Amount is belated then total Eligible amount for Relembursement in Rs:</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblDepartment" runat="server" CssClass="form-control txtbox" Text="[Department]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>
                                <tr id="worksheet" runat="server" visible="false">
                                     <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">25.</td>
                                    <td style="padding: 5px; margin: 5px;">Work Sheet </td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:HyperLink ID="hypworksheet" Text="View" runat="server"></asp:HyperLink>
                                    </td>

                                     <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                </div>
                <br />
                <div>
                    <br />
                    <br />
                    <input id="btnPrint" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                    &nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx">HOME</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
