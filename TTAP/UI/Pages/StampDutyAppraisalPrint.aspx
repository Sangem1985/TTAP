﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StampDutyAppraisalPrint.aspx.cs" Inherits="TTAP.UI.Pages.StampDutyAppraisalPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Appraisal Note</title>
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

        .auto-style4 {
            height: 34px;
        }

        .auto-style8 {
            width: 38%;
        }

        .auto-style18 {
            height: 34px;
            width: 38%;
        }

        .auto-style19 {
            width: 142px;
        }
    </style>
    <script>
        function PrintScreen() {
            document.getElementById("btnPrint").style.display = 'none';
            print();
            document.getElementById("btnPrint").style.display = 'block';
        }
        document.addEventListener("keydown", function (e) {
            if (e.ctrlKey && e.key === "p") {
                e.preventDefault();
                PrintScreen();
            }
        });
    </script>
</head>
<body style="border: groove;">
    <form id="form1" runat="server">
        <div align="center" style="margin-top: 25px;">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="../../images/favicon.png" width="100px" height="100px" />
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
                            
                            <tr>
                                <td style="text-align: center; vertical-align: middle">
                                    <u><b>Appraisal Note of Reimbursement of Stamp Duty/Transfer Duty/Mortgage and Hypothecation Duty
                                        <br />

                                        <asp:Label ID="lblSancIncentiveName" runat="server"></asp:Label>
                                    </b></u>
                                </td>
                            </tr>
                        </table>
                        <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12"><b></b>
                                </td>
                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                    <b>1. INDUSTRY DETAILS</b> </td>
                                <td class="auto-style25">&nbsp;
                                </td>

                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td style="font: bolder; font-size: small" class="auto-style1">1.1 Unit Name
                                </td>
                                <td>
                                    
                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label> &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.2 Address
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.3 Name of the Proprietor
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblProprietor" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.4 Constitution of Organization
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblConstitutionOfIndustrial" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.5 Social Status
                                </td>
                                <td>
                                    <asp:Label ID="lblSocialStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
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
                                <td class="auto-style1">1.6 Registration Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblRegistrationNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.7 Type of Unit
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofApplicant" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.8 Category of Unit as per Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCategoryofUnit" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.9 Type of Sector
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApplicationDateDIC" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.10 Type of Textile as per Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofTexttile" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.11 Technical Textile Type
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTechnicalTextileType" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.12 Activity of the Unit
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblActivityoftheUnit" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.13 UID Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUIDNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.14 Incentive Application Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCommonApplicationNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.15 Date of Power Connection Release
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPowerConnectionReleaseDate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.16 Commencement of Commercial Production
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDCPdate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.17 Date of Receipt of Claim Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblReceiptDate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">1.18 Promoter Details in case eligible for additional subsidy
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblelbPromoter" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                        </table>


                        <div class="row">
                            <table>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12"><b></b>
                                    </td>
                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                        <b>2. STAMP DUTY</b> </td>
                                    <td class="auto-style25">&nbsp;
                                    </td>

                                </tr>
                            </table>
                            <table style="width: 100%">

                                <tr id="tr4231" runat="server" visible="false">
                                    <td class="auto-style56">20.</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">SCHEME</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblscheme" runat="server" Text="[Scheme]"
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
                                <tr runat="server" visible="false">
                                    <td class="auto-style55">21.</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">Type</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">:</td>
                                    <td class="auto-style55">
                                        <asp:Label ID="lblselect" runat="server" CssClass="form-control txtbox txtcomn"
                                            Height="30px" MaxLength="80" TabIndex="36" Width="150px" Text="[SelectType]"></asp:Label>

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
                                    <td></td>
                                    <td style="padding: 5px; margin: 5px;">Land Measuring in Sq.Mts</td>
                                    <td style="padding: 5px; margin: 5px;">:</td>
                                    <td>&nbsp;
                           <asp:Label ID="lblLandMeasure" runat="server" CssClass="form-control txtbox txtcomn"
                               Height="30px" MaxLength="80" TabIndex="37" Width="150px" Text="[LandMeasuring]"></asp:Label>

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
                                    <td></td>
                                    <td style="padding: 5px; margin: 5px;">Stamp Duty paid by the unit in Rs.</td>
                                    <td style="padding: 5px; margin: 5px;">:</td>
                                    <td>&nbsp;
                           <asp:Label ID="lblstamppaid" runat="server" CssClass="form-control txtbox txtcomn"
                               Height="30px" TabIndex="37" Width="150px" Text="[StampDuty]"></asp:Label>

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
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Building plinth area in Sq.Mts</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblBuildingarea" runat="server" CssClass="form-control txtbox" Text="[Buildingplinth]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Building plinth area 5 times(Sq.Mts.)</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblBuildingarea5" runat="server" CssClass="form-control txtbox" Text="[BuildingPlinth5]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Proportionate value for the area in Rs.</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblProporation" runat="server" CssClass="form-control txtbox" Text="[ProportionateArea]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Value Recommended by G.M. DIC in Rs</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblGMDIC" runat="server" CssClass="form-control txtbox" Text="[RecommendedGM]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Value Commputed in Rs</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblComputedValue" runat="server" CssClass="form-control txtbox" Text="[ValueCommputed]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Eligible Type</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblSelectType" runat="server" CssClass="form-control txtbox" Text="[SelectType]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Eligible Amount in Rs.</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblEligibleAmount" runat="server" CssClass="form-control txtbox" Text="[EligibleAmount]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Remarks</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblRemarks" runat="server" CssClass="form-control txtbox" Text="[Remarks]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Forward To</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblForward" runat="server" CssClass="form-control txtbox" Text="[Forward]"></asp:Label>
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
                        type="button" value="Print" onclick="return PrintScreen();" />
                    &nbsp;&nbsp;&nbsp; <%--<a href="HomeDashboard.aspx">HOME</a>--%>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
