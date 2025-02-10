<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterestSubsidyAppraisalNote.aspx.cs" Inherits="TTAP.UI.Pages.InterestSubsidyAppraisalNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
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
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <div align="center" style="text-align: center">
            <div align="center">
                <center>
                    <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                </center>
                <%--<h3>TS-iPASS APPLICATION FORM</h3>--%>
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
                            <td style="text-align: center; font-weight: bold;">
                                T-PRIDE -
                                <asp:Label ID="LBLCASTE" runat="server" Visible="false" Text="Label"></asp:Label>
                                - G.O M.S. NO 29, Industries &amp; Commerce (IP &amp; INF) Department,
                                <br />
                                Dated : 29/11/2014
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; vertical-align: middle">
                                <u><b>
                                    <%--Telangana State Industrial Development and Entrepreneur Advancement - GO MS. NO 28, Industries & Commerce (IP & INF) Department, Dated : 29/11/2014--%>
                                    Appraisal Note<br />
                                    
                                    <asp:Label ID="lblSancIncentiveName" runat="server"></asp:Label>
                                </b></u>
                            </td>
                        </tr>
                    </table>
                    <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                Application no
                            </td>
                            <td>
                                <asp:Label ID="lblApplication_no" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td style="font: bolder; font-size: small" class="auto-style1">
                                <b>1 Name of Industrial Concern</b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label ID="lblUnitname" runat="server"></asp:Label></b> &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                2 Location of the Industrial concern
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblLocaddress" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                3 Name of Promoter
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblPromoterName" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                4 Constitution of the Industrial Concern
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblConstitutionOfIndustrial" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                5 Social Status
                            </td>
                            <td>
                                <asp:Label ID="lblSocialStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                6 Share of SC/ST/Women Enterpreneur
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblEntrprName" runat="server"></asp:Label>
                                    <b>
                                        <asp:Label ID="lblwomen" runat="server" Visible="false"></asp:Label></b>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                7 PMT SSI Registration. No. &amp; Date
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblSSIRegn" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                8 New/Expansion/Diversification Unit
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblNewExpnDiver" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                9 Date of commencement of production
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblCommencmentOfCommrclProdcn_Date" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                10 Date of filing of claim application in DIC
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblApplicationDateDIC" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                11 Name of Financing Institution in case of Aided Units
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblFinInstn" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr id="TRCLAIMPERIOD" runat="server" visible="false">
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                12 Claim Period
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblclaimperiod" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr id="TRSCHEME" runat="server" visible="false">
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                13 Scheme
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="LBLSCHEME" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                Confirmed Details by GM
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblDetailsConfirmed" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr id="clerkattachment" runat="server" visible="false">
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                Clerk Worksheet
                            </td>
                            <td>
                                <span>
                                    <asp:HyperLink ID="hylinkattachment" runat="server" Visible="false">Attachment</asp:HyperLink>
                                </span>
                            </td>
                        </tr>
                        <div>
                            <%--//style="font-family: Verdana; font-size: small;"--%>
                            <table style="width: 100%; font-family: Verdana; font-size: small">
                                <tr>
                                    <td style="width: 2%">
                                    </td>
                                    <td>
                                        <u><b>Line of Activity</b></u>
                                    </td>
                                </tr>
                                <%-- <tr>
                                <td>Line of Activity
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLOA" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Capacity
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCapacity" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Units
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUnitNumbers" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Value in Rs
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblValue" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>--%><tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    <asp:GridView ID="gvInstalledCap" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" GridLines="Both" Width="90%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                            <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                        </Columns>
                                        <RowStyle ForeColor="#333333" Font-Names="Arial" Font-Size="12px" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                            Font-Names="Arial" Font-Size="9px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            </table>
                        </div>
                        
                    </table>
                    <div align="center">
                        <table style="font-family: Verdana; font-size: small; width: 100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td align="center" colspan="4">
                                    <b>Fixed Capital Investment</b>
                                </td>
                                <td style="text-align: right">
                                    <b>(In Rupees)</b>
                                </td>
                                <td align="center">
                                    <b></b>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td align="center">
                                    Details of Fixed Assets
                                </td>
                                <td align="center">
                                    <b>As per Approved project cost </b>
                                </td>
                                <td align="center">
                                    <b>As per GM Recommendation</b>
                                </td>
                                <td align="center">
                                    <b>Computed as per Guidelines</b>
                                </td>
                                <td align="center">
                                    <b>Reasons for variation between GM Recommended value and computed value</b>
                                </td>
                                <td align="center">
                                    <b></b>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="1px">
                                    a. Land
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
                                <td class="auto-style2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    b. Building
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    c. Plant & M/C
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td colspan="1.5px">
                                    d.Tech.Knows -how feasibility study & turn key charges
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    e.Vehicles
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td>
                                    f.Other eligible
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
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="text-align: center">
                                <td style="width: 2%">
                                </td>
                                <td>
                                    Total
                                </td>
                                <td>
                                    <b>
                                        <asp:Label runat="server" ID="lblTotal_ProjectCost"></asp:Label></b>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label runat="server" ID="lblTotal_ValueRecommendedByGM"></asp:Label></b>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label runat="server" ID="lblTotalComputed"></asp:Label></b>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label runat="server" ID="lblTotal_GMRec"></asp:Label></b>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                        </table>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div>
                    <div align="center" id="Div3" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td colspan="4" style="color: black; font-weight: bold;" class="auto-style8">
                                    12 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    a) Investment Subsidy @ Eligible %
                                </td>
                                <td>
                                    <asp:Label ID="lblPercent" runat="server"></asp:Label><b>%</b>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    b) State Investment Subsidy in Rs.
                                </td>
                                <td>
                                    <asp:Label ID="lblStateInvesSubsidy" runat="server"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    c) Additional Women Percentage(%).
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblpercentage_is" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    d) Addl Sub. for Women in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblAddlSubWomen" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    e) Application Type
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblapplicationtype_IS" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    f) Is LMV or NONLMV
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbllmvornonlmv" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    g) Is Men or Women
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblmenorwomen" runat="server"></asp:Label>
                                </td>
                            </tr>
                           
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    h) Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLREMARKS" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY</b>
                                </td>
                                <td>
                                    <asp:Label ID="lblEligi_TotalSubsidy" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <b>CONDITIONS TO BE FULFILLED BY THE UNIT</b>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lblConditionsFulfil" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trgmremarks">
                                <td colspan="1">
                                    <b><u>REMARKS</u></b>
                                </td>
                                <td colspan="2" style="text-align: justify">
                                    The GM,DIC -
                                    <asp:Label ID="LblDICName" runat="server"></asp:Label>
                                    &nbsp;District has recommended the claim application along with all required documents/certificates
                                    as per the Guidelines. The unit has submitted the claim application within the stipulated
                                    period in the office of the GM,DIC, as such there is no delay in submitting the
                                    claim application and the line of activity is eligible of Investment subsidy under
                                    <b>
                                        <asp:Label ID="lblFinalSchemeName" runat="server"></asp:Label>
                                        <asp:Label ID="LBLCASTE2" runat="server" Visible="false"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="divLandconversion" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Land measuring in Square meters
                                </td>
                                <td>
                                    <asp:Label ID="lblLConLandMeasure" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 Land Conversion Charges Paid:
                                </td>
                                <td>
                                    <asp:Label ID="LblLconPurchaseValue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 Building plinth Area in Square meters
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconBuildingPlnth" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Five Times plinth area:
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblfietimesplintharea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Land Area Considered:
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconLandValueComputed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Proportionate Land Conversion Charges
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconProportionate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.7 (25 %) on computed value in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconTwntyFveComputed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.8 Value Recommended by GM
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconValueGMRecom" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.9 Elegible Land conversion charges in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLConEligibleLandConversion" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.10 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLconClaimType" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.11 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLREMARKS_LANDCONVERSION" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr2" runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="divmortgage" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Name of the Financial Institution
                                </td>
                                <td>
                                    <asp:Label ID="lblMortFinancialIns" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 Term Loan Sacnctioned
                                </td>
                                <td>
                                    <asp:Label ID="lblMortTermLoan" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 Mortgage Duty Paid
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortMortgageDutyPaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Term Loan availed by Unit
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortTermloanAvailed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Proportionate Mortgage Duty
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortProportionateMortgage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Mortgage Duty Recommended by GM
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortMortgageDuty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.7 Elegible for Reimbursement of Mortgage Duty in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortElgibleReimbursement" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.8 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblMortTypeofClaim" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.9 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_mortegage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="divlandcost" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Land Purchase in Sq. Mts.
                                </td>
                                <td>
                                    <asp:Label ID="lblLcLandPurchase" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 Land Value in Rs
                                </td>
                                <td>
                                    <asp:Label ID="lblLCLandvalue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 Plinth Area in Sq.Mts.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCPlnthArea" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Five times of Builtup Area (Sq.Mts.)
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCfiveTimes" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Proportionate value in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCProportionate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Value recommended by G.M., DIC. in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCValueRecmGM" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.7 Eligible Land Cost in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblLCEligibleLandCost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.8 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltypeofclainlandcost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.9 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_landcost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="divStampduty" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Land measuring in Sq. Mts.
                                </td>
                                <td>
                                    <asp:Label ID="lblSDLandmeasuring" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 Stamp duty paid by the unit in Rs.
                                </td>
                                <td>
                                    <asp:Label ID="lblSDStampduty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 Building plinth area in Sq.Mts.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDBuildingPlinth" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Building plinth area 5 times (Sq.Mts.)
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDBuildingplnthfvTimes" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Proportionate value for the area in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDProportionateVAlue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Value recommended by G.M., DIC. in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDValueRecomndGM" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.7 Value Computed in Rs.
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblSDValueComputed" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.8 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLTYPEOFCLAIM_STAMPDUTY" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.9 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_stampduty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="DIVQUALITYCERTIFICATION" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>QUALITY CERTIFICATION </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Quality certification charges paid
                                </td>
                                <td>
                                    <asp:Label ID="lblqualitycertificationcgargespaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 50% of amount of certification charges paid
                                </td>
                                <td>
                                    <asp:Label ID="lblfiftypercentage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 G.M Recommended Amount
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblgmrecomamount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Eligible amount whichever is less
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbllesselegibleamount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltypeofclaim_quality" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_qualitycertification" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr1" runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table id="tblNewUnit" runat="server" visible="false" style="font-family: Verdana;
                            font-size: small;" bgcolor="White" width="100%">
                            <tr>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Financial Year
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Month-year
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Units Consumed
                                    <br />
                                    in Nos.
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Rate per
                                    <br />
                                    Units
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Amount Paid as per Bill in Rs.
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Eligible rate Re-imbursement per units
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Eligible amount Re-imbursement per units
                                </td>
                                <th style="padding: 10px; margin: 5px; font-weight: bold;">
                                    &nbsp;
                                </th>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear1New" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear1NewFinyear" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox23" AutoPostBack="true" Text='<%#Eval("rateperunit") %>' runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox24" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox25" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox21" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox28" runat="server"></asp:Label>
                                </td>
                                <td rowspan="5" style="padding: 10px; margin: 5px; font-weight: bold;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear2New" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear2NewFinyear" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox50" AutoPostBack="true" Text='<%#Eval("rateperunit") %>' runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox51" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox52" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox22" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox29" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear3New" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear3NewFinyear" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox63" Text='<%#Eval("rateperunit") %>' runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox64" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox65" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox26" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox49" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear4New" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear4NewFinyear" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox71" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox72" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox73" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox27" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox53" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear5New" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear5NewFinyear" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox79" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox80" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox81" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox95" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox54" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear6New" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear6NewFinyear" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox87" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox88" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox89" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox96" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox55" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;" colspan="7">
                                    <br />
                                    Total amount :
                                    <asp:Label ID="lblGmAmount0" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Is Belated&nbsp;:
                                    <asp:Label ID="lblTotalEligibleAm0" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Total Eliglible amount :
                                    <asp:Label ID="lblTotalEligibleAm" runat="server"></asp:Label>
                                    <br />
                                    <%-- <asp:Label runat="server" CssClass="form-control" ID="lbl_grdtoteligibleamount"></asp:Label>--%>
                                    <br />
                                    GM Recommended Amount :
                                    <asp:Label ID="lblGmAmount" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Remarks:
                                    <asp:Label ID="lblremarks_powernew" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table id="tblNewUnitBoth" runat="server" visible="false" style="font-family: Verdana;
                            font-size: small;" bgcolor="White" width="100%">
                            <tr>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Financial Year
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Month-year
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Units Consumed
                                    <br />
                                    in Nos.
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Rate per
                                    <br />
                                    Units
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Amount Paid as per Bill in Rs.
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Eligible rate Re-imbursement per units
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Eligible amount Re-imbursement per units
                                </td>
                                <th style="padding: 10px; margin: 5px; font-weight: bold;">
                                    &nbsp;
                                </th>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear1NewBoth" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear1NewFinyearBoth" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox23Both" AutoPostBack="true" Text='<%#Eval("rateperunit") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox24Both" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox25Both" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox21Both" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox28Both" runat="server"></asp:Label>
                                </td>
                                <td rowspan="5" style="padding: 10px; margin: 5px; font-weight: bold;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear2NewBoth" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear2NewFinyearBoth" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox50Both" AutoPostBack="true" Text='<%#Eval("rateperunit") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox51Both" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox52Both" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox22Both" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox29Both" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear3NewBoth" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear3NewFinyearBoth" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox63Both" Text='<%#Eval("rateperunit") %>' runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox64Both" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox65Both" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox26Both" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox49Both" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear4NewBoth" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear4NewFinyearBoth" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox71Both" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox72Both" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox73Both" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox27Both" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox53Both" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear5NewBoth" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear5NewFinyearBoth" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox79Both" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox80Both" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox81Both" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox95Both" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox54Both" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear6NewBoth" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="txt_grdmonthyear6NewFinyearBoth" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox87Both" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox88Both" AutoPostBack="true" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox89Both" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                        runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox96Both" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="TextBox55Both" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;" colspan="7">
                                    <br />
                                    Total amount :
                                    <asp:Label ID="lblGmAmount0Both" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Is Belated&nbsp;:
                                    <asp:Label ID="lblTotalEligibleAm0Both" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Total Eliglible amount :
                                    <asp:Label ID="lblTotalEligibleAmBoth" runat="server"></asp:Label>
                                    <br />
                                    <%-- <asp:Label runat="server" CssClass="form-control" ID="lbl_grdtoteligibleamount"></asp:Label>--%>
                                    <br />
                                    GM Recommended Amount :
                                    <asp:Label ID="lblGmAmountBoth" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Remarks:
                                    <asp:Label ID="lblremarks_powernewBoth" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <table id="tbl_monthyeardataExpansion" runat="server" visible="false" bgcolor="White"
                                        width="100%" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Financial Year
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Month-year
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Units Consumed
                                                <br />
                                                in Nos.
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Rate per Units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Amount Paid as per Bill in Rs.
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Base fixed per month in units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible Units i.e over & above Base
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible Rate for
                                                <br />
                                                Reimbursement per units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible amount for
                                                <br />
                                                Reiembursement in Rs.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdmonthyear1" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear1unitsconsumed" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear1rateperunit" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear1amountpaid" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear1basefixedunitspermonth" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear1eligibleunits" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear1eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear1eligibleamountforreimbursement" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="TextBox75" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdmonthyear2" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear2unitsconsumed" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear2rateperunit" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear2amountpaid" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear2basefixedunitspermonth" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear2eligibleunits" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear2eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear2eligibleamountforreimbursement" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="TextBox76" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdmonthyear3" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear3unitsconsumed" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear3rateperunit" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear3amountpaid" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear3basefixedunitspermonth" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear3eligibleunits" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear3eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear3eligibleamountforreimbursement" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="TextBox77" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdmonthyear4" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear4unitsconsumed" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear4rateperunit" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear4amountpaid" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear4basefixedunitspermonth" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear4eligibleunits" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear4eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear4eligibleamountforreimbursement" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="TextBox78" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdmonthyear5" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear5unitsconsumed" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear5rateperunit" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear5amountpaid" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear5basefixedunitspermonth" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear5eligibleunits" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear5eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear5eligibleamountforreimbursement" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="TextBox82" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdmonthyear6" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear6unitsconsumed" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear6rateperunit" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear6amountpaid" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear6basefixedunitspermonth" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear6eligibleunits" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear6eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="txt_grdyear6eligibleamountforreimbursement" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="TextBox83" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="9">
                                                <br />
                                                Total amount :
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Is Belated : &nbsp;
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Total Eliglible amount :&nbsp;
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                                <br />
                                                <%-- <asp:Label runat="server" CssClass="form-control" ID="lbl_grdtoteligibleamount"></asp:Label>--%>
                                                <br />
                                                GM Recommended Amount :
                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Remarks:
                                                <asp:Label ID="lblremarks_monthyearexp" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <table id="tbl_monthyeardataExpansionBoth" runat="server" visible="false" bgcolor="White"
                                        width="100%" style="font-family: Verdana; font-size: small;">
                                        <tr>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Financial Year
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Month-year
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Units Consumed
                                                <br />
                                                in Nos.
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Rate per Units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Amount Paid as per Bill in Rs.
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Base fixed per month in units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible Units i.e over & above Base
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible Rate for
                                                <br />
                                                Reimbursement per units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible amount for
                                                <br />
                                                Reiembursement in Rs.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label117" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label118" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label119" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label120" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label121" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label122" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label123" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label124" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label125" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label126" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label127" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label128" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label129" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label130" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label131" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label132" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label133" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label134" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label135" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label136" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label137" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label138" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label139" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label140" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label141" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label142" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label143" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label144" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label145" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label146" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label147" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label148" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label149" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label150" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label151" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label152" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label153" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label154" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label155" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label156" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label157" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label158" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label159" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label160" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label161" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label162" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label163" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label164" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label165" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label166" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label167" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label168" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label169" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label170" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="9">
                                                <br />
                                                Total amount :
                                                <asp:Label ID="Label171" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Is Belated : &nbsp;
                                                <asp:Label ID="Label172" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Total Eliglible amount :&nbsp;
                                                <asp:Label ID="Label173" runat="server"></asp:Label>
                                                <br />
                                                <%-- <asp:Label runat="server" CssClass="form-control" ID="lbl_grdtoteligibleamount"></asp:Label>--%>
                                                <br />
                                                GM Recommended Amount :
                                                <asp:Label ID="Label174" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Remarks:
                                                <asp:Label ID="Label175" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <table id="Table1" runat="server" visible="false" bgcolor="White" width="100%" style="font-family: Verdana;
                                        font-size: small;">
                                        <tr>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Financial Year
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Month-year
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Units Consumed
                                                <br />
                                                in Nos.
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Rate per Units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Amount Paid as per Bill in Rs.
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Base fixed per month in units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible Units i.e over & above Base
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible Rate for
                                                <br />
                                                Reimbursement per units
                                            </td>
                                            <td style="border: solid thin black; font-weight: bold;">
                                                Eligible amount for
                                                <br />
                                                Reiembursement in Rs.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label58" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label59" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label60" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label61" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label62" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label63" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label64" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label65" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label66" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label67" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label68" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label69" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label70" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label71" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label72" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label73" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label74" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label75" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label76" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label77" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label78" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label79" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label80" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label81" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label82" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label83" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label84" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label85" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label86" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label87" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label88" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label89" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label90" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label91" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label92" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label93" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label94" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label95" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label96" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label97" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label98" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label99" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label100" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label101" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label102" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label103" Enabled="false" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label104" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label105" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label106" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label107" Enabled="false" Text='<%#Eval("basefixedunitspermonth") %>'
                                                    runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label108" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label109" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label110" AutoPostBack="true" runat="server"></asp:Label>
                                            </td>
                                            <td style="border: solid thin black;">
                                                <asp:Label ID="Label111" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="9">
                                                <br />
                                                Total amount :
                                                <asp:Label ID="Label112" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Is Belated : &nbsp;
                                                <asp:Label ID="Label113" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Total Eliglible amount :&nbsp;
                                                <asp:Label ID="Label114" runat="server"></asp:Label>
                                                <br />
                                                <%-- <asp:Label runat="server" CssClass="form-control" ID="lbl_grdtoteligibleamount"></asp:Label>--%>
                                                <br />
                                                GM Recommended Amount :
                                                <asp:Label ID="Label115" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                                Remarks:
                                                <asp:Label ID="Label116" runat="server"></asp:Label>
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="Div1" runat="server" align="left" Visible="false">
                        <asp:Label ID="lblfinalsubsidyamount" runat="server" Text="Final Subsidy Amount" Visible="false"></asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblamount" runat="server"></asp:Label>
                    </div>
                    <div align="center" id="DIVSALESTAX" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>ELIGIBLE INCENTIVES </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    i. Scheme Type
                                </td>
                                <td>
                                    <asp:Label ID="LBLSCHEMETYPE" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    ii. Application Type
                                </td>
                                <td>
                                    <asp:Label ID="lblapplicationtype" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    iii. Production
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblproduction" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    iv. Tax Paid
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltaxpaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    v. Base Production
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblbaseproduction" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    vi. Eligible Production Quantity over and the above base production
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblelgprodqty" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    vii. Proportionate SGST value on eligible prodution
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblproportionatesgst" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    viii. Category
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblcategory" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    ix. Percentage
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblpercentage" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trcapitaleligibleinvestment">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    x. Total Capital Eligible Investment
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblcapitalelginvestment" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false" id="trsalestaxsanctionedonthisclaim">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xi. Total Sales Tax Already Sanctioned Prior to This Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblsalestaxsanctioned" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xii. GM Recommended Value
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblgmrecommendedvalue" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xiii. Eligible Amount
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbleligibleamount" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xiv. Type of claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltypeofclaim" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    xv. Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_salestax" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="div_pallavaddi" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td colspan="4" style="color: black; font-weight: bold;" class="auto-style8">
                                    <u>ELIGIBLE INCENTIVES </u>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:GridView ID="grd_claimperiodofloanadd" runat="server" CssClass="table table-small-font table-bordered table-striped"
                                        AutoGenerateColumns="false" AllowPaging="false" ShowHeaderWhenEmpty="true" ShowFooter="true"
                                        EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Sr.#
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    Claim Period
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%--<asp:HiddenField ID="hf_claimperiodofloanaddIncentiveId" Value='<%# Eval("Incentiveid") %>' runat="server" />
                                                         <asp:HiddenField ID="hf_claimperiodofloanaddFinancialYear" Value='<%# Eval("FinancialYear") %>' runat="server" />
                                                        <asp:HiddenField ID="hf_claimperiodofloanadd_ID" Value='<%# Eval("ClaimPeriodID") %>' runat="server" />--%>
                                                    <%# Eval("ClaimPeriodName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    No of Loans Applied for this Claim
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Eval("LoanCount") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="gridview"></PagerStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:GridView ID="grd_eglibilepallavaddi" runat="server" CssClass="table table-small-font table-bordered table-striped"
                                        AutoGenerateColumns="false" AllowPaging="false" ShowHeaderWhenEmpty="true" ShowFooter="true"
                                        EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hf_grdeglibilepallavaddiFY_ID" Value='<%# Eval("ClaimPeriodID") %>'
                                                        runat="server" />
                                                    <table>
                                                        <tr>
                                                            <th style="font-family: Calibri">
                                                                <%#Container.DataItemIndex+1 %>
                                                                Claim Period:
                                                                <asp:Label ID="lbl_grdeglibilepallavaddiFYname" Text='<%# Eval("ClaimPeriodName") %>'
                                                                    runat="server"></asp:Label>
                                                            </th>
                                                            <th style="font-family: Calibri">
                                                            </th>
                                                            <th style="font-family: Calibri">
                                                                &nbsp;&nbsp;&nbsp; &nbsp; Loan-
                                                                <asp:Label ID="lbl_claimeglibleincentivesloanwiseLoanID" Text='<%# Eval("LoanNumber") %>'
                                                                    runat="server"></asp:Label>
                                                            </th>
                                                            <th style="font-family: Calibri">
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Date of Commencement of activity:</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <%# Eval("dcpdate") %>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                &nbsp;&nbsp;&nbsp; &nbsp;<b>Loan installment start Date</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <%# Eval("loaninstallmentstartdate") %>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Total Term Loan Availed(In Rs.)</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <%# Eval("tottermloanavil") %>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                &nbsp;&nbsp;&nbsp; &nbsp;<b>Period of installment</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <%# Eval("Periodofinstallmentname") %>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>No of installment</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <%# Eval("Noofinstallmentforloan") %>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                &nbsp;&nbsp;&nbsp; &nbsp;<b>Installment amount</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <%# Eval("Installmentamountforloan") %>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>No of installments completed</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <%# Eval("NoofinstallmentcompletedfortheloanFY") %>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                &nbsp;&nbsp;&nbsp; &nbsp;<b>PrincipalAmount become DUE before this HALFYEAR</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <%# Eval("principalamountdueforhalfyrFY") %>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4">
                                                                <table border="1" width="100%" align="center" cellpadding="10" cellspacing="5">
                                                                    <tr style="column-rule-style: solid">
                                                                        <th style="font-family: Calibri">
                                                                            Sr.#
                                                                        </th>
                                                                        <th style="font-family: Calibri">
                                                                            Period of Claim
                                                                        </th>
                                                                        <th style="font-family: Calibri">
                                                                            Principal amounnt due
                                                                        </th>
                                                                        <th style="font-family: Calibri">
                                                                            No of Installment
                                                                        </th>
                                                                        <th style="font-family: Calibri">
                                                                            Rate of Interest
                                                                        </th>
                                                                        <th style="font-family: Calibri">
                                                                            Interest due
                                                                        </th>
                                                                        <th style="font-family: Calibri">
                                                                            Unit Holder Contribution
                                                                        </th>
                                                                        <th style="font-family: Calibri">
                                                                            Eligible Rate of interest
                                                                        </th>
                                                                        <th style="font-family: Calibri">
                                                                            Eligible Interest Amount
                                                                        </th>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-family: Calibri">
                                                                            1
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:HiddenField ID="hfgrd_monthoneid" Value='<%# Eval("PeriodofClaimMonth1ID") %>'
                                                                                runat="server" />
                                                                            <asp:Label ID="lbl_grd_monthonename" Text='<%# Eval("PeriodofClaimMonth1Name") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthnonePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth1") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthoneNoofInstallment" Text='<%# Eval("NoofInstallmentMonth1") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthoneRateofinterest" Text='<%# Eval("rateofinterestMonth1") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthoneInterestamount" Text='<%# Eval("interestamountMonth1") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthoneUnitHolderContribution" Text='<%# Eval("unitholdercontMonth1") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthoneEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth1") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthoneEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth1") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-family: Calibri">
                                                                            2
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:HiddenField ID="hfgrd_monthtwoid" Value='<%# Eval("PeriodofClaimMonth2ID") %>'
                                                                                runat="server" />
                                                                            <asp:Label ID="lbl_grd_monthtwoname" Text='<%# Eval("PeriodofClaimMonth2Name") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthtwoPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth2") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthtwoNoofInstallment" Text='<%# Eval("NoofInstallmentMonth2") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthtwoRateofinterest" Text='<%# Eval("rateofinterestMonth2") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthtwoInterestamount" Text='<%# Eval("interestamountMonth2") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthtwoUnitHolderContribution" Text='<%# Eval("unitholdercontMonth2") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthtwoEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth2") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthtwoEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth2") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-family: Calibri">
                                                                            3
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:HiddenField ID="hfgrd_monththreeid" Value='<%# Eval("PeriodofClaimMonth3ID") %>'
                                                                                runat="server" />
                                                                            <asp:Label ID="lbl_grd_monththreename" Text='<%# Eval("PeriodofClaimMonth3Name") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monththreePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth3") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monththreeNoofInstallment" Text='<%# Eval("NoofInstallmentMonth3") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monththreeRateofinterest" Text='<%# Eval("rateofinterestMonth3") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monththreeInterestamount" Text='<%# Eval("interestamountMonth3") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monththreeUnitHolderContribution" Text='<%# Eval("unitholdercontMonth3") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monththreeEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth3") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monththreeEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth3") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-family: Calibri">
                                                                            4
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:HiddenField ID="hfgrd_monthfourid" Value='<%# Eval("PeriodofClaimMonth4ID") %>'
                                                                                runat="server" />
                                                                            <asp:Label ID="lbl_grd_monthfourname" Text='<%# Eval("PeriodofClaimMonth4Name") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfourPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth4") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfourNoofInstallment" Text='<%# Eval("NoofInstallmentMonth4") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfourRateofinterest" Text='<%# Eval("rateofinterestMonth4") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfourInterestamount" Text='<%# Eval("interestamountMonth4") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfourUnitHolderContribution" Text='<%# Eval("unitholdercontMonth4") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfourEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth4") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfourEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth4") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-family: Calibri">
                                                                            5
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:HiddenField ID="hfgrd_monthfiveid" Value='<%# Eval("PeriodofClaimMonth5ID") %>'
                                                                                runat="server" />
                                                                            <asp:Label ID="lbl_grd_monthfivename" Text='<%# Eval("PeriodofClaimMonth5Name") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfivePrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth5") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfiveNoofInstallment" Text='<%# Eval("NoofInstallmentMonth5") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfiveRateofinterest" Text='<%# Eval("rateofinterestMonth5") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfiveInterestamount" Text='<%# Eval("interestamountMonth5") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfiveUnitHolderContribution" Text='<%# Eval("unitholdercontMonth5") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfiveEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth5") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthfiveEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth5") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-family: Calibri">
                                                                            6
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:HiddenField ID="hfgrd_monthsixid" Value='<%# Eval("PeriodofClaimMonth6ID") %>'
                                                                                runat="server" />
                                                                            <asp:Label ID="lbl_grd_monthsixname" Text='<%# Eval("PeriodofClaimMonth6Name") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthsixPrincipalamounntdue" Text='<%# Eval("PrincipalamountdueMonth6") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthsixNoofInstallment" Text='<%# Eval("NoofInstallmentMonth6") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthsixRateofinterest" Text='<%# Eval("rateofinterestMonth6") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthsixInterestamount" Text='<%# Eval("interestamountMonth6") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthsixUnitHolderContribution" Text='<%# Eval("unitholdercontMonth6") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthsixEligibleRateofinterest" Text='<%# Eval("eligiblerateofintersetMonth6") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_monthsixEligibleInterestAmount" Text='<%# Eval("eligibleinterestamountMonth6") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="font-family: Calibri">
                                                                            6
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            Total Interest Amount:
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_totmonthsInterestamount" Text='<%# Eval("totmonthsinterestamountMonth") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            Total Eligible Interest Amount:
                                                                        </td>
                                                                        <td style="font-family: Calibri">
                                                                            <asp:Label ID="lbl_grd_totmonthsEligibleInterestAmount" Text='<%# Eval("totmonthseligibleinterestamount") %>'
                                                                                runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Eligible period in months</b>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <br />
                                                                <asp:Label ID="txt_grdeglibilepallavaddiEligibleperiodinmonths" Text='<%# Eval("eligibleperiodinmonths") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Insert amount to be paid as per calculations</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations" Text='<%# Eval("CPL_interestamountpaidaspercal") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Actual interest amount paid</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_grdeglibilepallavaddiActualinterestamountpaid" Text='<%# Eval("CPL_actualinterestamountpaid") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Rate of Interest</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_claimeglibleincentivesloanwiseRateofInterest" Text='<%# Eval("Rateofinterestforloan") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                &nbsp;&nbsp;&nbsp; &nbsp;<b>Eligible rate of reimbursement</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement" Text='<%# Eval("Eligibleratereimbursementforlaon") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Considered Amount for Interest</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest" Text='<%# Eval("CPL_Conamountforcalintreimberest") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Interst reimbursement calculated</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_grdeglibilepallavaddiInsertreimbursementcalculated" Text='<%# Eval("CPL_interestreimbersementcal") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Eligible Type</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="rbtgrdeglibilepallavaddi_isbelated" Text='<%# Eval("CPL_ELIGIBLETYPEName") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Interst reimbursement(After selecting the eglible Type)</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype"
                                                                    Text='<%# Eval("CPL_interestreimbersementcal_finaleligibletype") %>' runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>GM recommended amount</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_grdeglibilepallavaddiGMrecommendedamount" Text='<%# Eval("CPL_gmrecommendedamount") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                                <b>Eligible amount</b>
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                                <asp:Label ID="txt_grdeglibilepallavaddiEligibleamount" Text='<%# Eval("CPL_FINALELIGIBLEAMOUNT") %>'
                                                                    runat="server"></asp:Label>
                                                                <br />
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                            <td style="font-family: Calibri">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="gridview"></PagerStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Interest amount to be paid as per calculations
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Insertamounttobepaidaspercalculations" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Actual interest amount paid
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Actualinterestamountpaid" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Considered Amount of Interest
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_ConsideredAmountofInterest" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Interst reimbursement calculated
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Insertreimbursementcalculated" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Interst reimbursement(After selecting the eglible Type)
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_eglibleamountofreimbursementbyeglibletype" runat="server" RepeatDirection="Horizontal"
                                        Height="33px" Width="200px">
                                    </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    GM recommended amount
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_GMrecommendedamount" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible amount
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Eligibleamount" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Remarks given by Clerk
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="lbl_pavallavaddiremarksbyclerk" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <%--  <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td colspan="4" style="color: black; font-weight: bold;" class="auto-style8">
                                    <u>ELIGIBLE INCENTIVES </u>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                    1.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Total Term Loan Availed(Value in Rs.)
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_eglsacamountinterestreimbursement" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    2.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Date of Commencement of activity
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_DateofCommencementofactivity" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>3.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Period of installment
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="ddl_periodofinstallment" runat="server" Height="33px" Width="180px">
                                    </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    4.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Date from which installment starts
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_installmentstartdate" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                    5.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    No of installment
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_noofinstallment" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>6.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Installment amount
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="txt_Installmentamount" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>7.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Rate of Interest
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="txt_RateofInterest" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                    8.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible rate of reimbursement
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Eligiblerateofreimbursement" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>9.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    Claim Period
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="ddl_ClaimPeriod" runat="server" Height="33px" Visible="true" Width="180px">
                              
                                    </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong>10.</strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                    No of installments completed
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                    <asp:Label ID="txt_Noofinstallmentscompleted" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                    11.&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Principal amount become DUE before this HALF YEAR
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_PrincipalamountbecomeDUEbeforethisHALFYEAR" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td>
                                </td>
                                <td colspan="4">
                                    <asp:GridView ID="grd_financalyeargrid" runat="server" CssClass="table table-small-font table-bordered table-striped"
                                        AutoGenerateColumns="false" OnRowDataBound="grd_financalyeargrid_RowDataBound"
                                        GridLines="Both" ShowHeader="false" ShowHeaderWhenEmpty="false" ShowFooter="false"
                                        EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;">
                                        <Columns>
                                            <%--  <asp:BoundField ItemStyle-Width="150px" DataField="CLAIMPERIODName_Grid" HeaderText="Finaincal" />--%>
                        <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <b>
                                                        <asp:Label ID="lbl_data" Text='<%# Eval("CLAIMPERIODName_Grid") %>' runat="server"></asp:Label></b>
                                                    <br />
                                                    <asp:GridView ID="grd_Addclaimperiod" runat="server" CssClass="table table-small-font table-bordered table-striped"
                                                        AutoGenerateColumns="false" AllowPaging="true" ShowHeaderWhenEmpty="false" ShowFooter="false"
                                                        EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;" PageSize="50">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Sr.#
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%#Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Claim Period
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("CLAIMPERIODName_Grid") %>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Period of Claim/Month wise
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("PERIODOFCLAIM_MONTHWISE_VALUE_GRID") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Principal amounnt due
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("PRINCIPALAMOUNTDUE_GRID") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    No of Installment
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("NOOFINSTALLMENT_GRID") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                    Interest amount
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%# Eval("INTERESTAMOUNT_GRID") %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <%-- <PagerStyle CssClass="gridview"></PagerStyle>--%>
                        <%--  </asp:GridView>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>--%>
                        <%-- <table style="width: 100%">
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible period in months
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Eligibleperiodinmonths" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Insert amount to be paid as per calculations
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Insertamounttobepaidaspercalculations" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Actual interest amount paid
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Actualinterestamountpaid" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Interst reimbursement calculated
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Insertreimbursementcalculated" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible Type
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="rbtgrd_isbelated" runat="server" RepeatDirection="Horizontal" Height="33px"
                                        Width="200px">
                                    </asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Interst reimbursement(After selecting the eglible Type)
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_eglibleamountofreimbursementbyeglibletype" runat="server" Height="28px"
                                        Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    GM recommended amount
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_GMrecommendedamount" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    Eligible amount
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    :
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="txt_Eligibleamount" runat="server" Height="28px" Width="180px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20">
                                    <strong></strong>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>--%>
                    </div>
                    <div align="center" id="divcoal" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    <u>REIMBURSEMENT OF COAL </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    Coal Quantity
                                </td>
                                <td>
                                    <asp:Label ID="lblcoalquantity" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    Eligible Amount
                                </td>
                                <td>
                                    <asp:Label ID="lbleligibleamount_coal" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    GM Recommended Value
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblgmrecommendedvalue_coal" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    Final Subsidy Amount
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblfinalsubsidyamount_coal" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremark_coal" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr3" runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="DIVWOOD" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                     <u>REIMBURSEMENT OF WOOD  </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                     WOOD Quantity
                                </td>
                                <td>
                                    <asp:Label ID="LBLQUANTITY_WOOD" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    Eligible Amount
                                </td>
                                <td>
                                    <asp:Label ID="LBLELIGIBLEAMOUNT_WOOD" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    GM Recommended Value
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLGMRECOMMENDEDVALUE_WOOD" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    Final Subsidy Amount
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLFINALSUBSIDYAMOUNT_WOOD" runat="server"></asp:Label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                     Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="LBLREMARKS_WOOD" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr4" runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label15" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="DIVTRANSPORTDUTY" visible="false" runat="server" style="padding-left:40px">
                        <table  runat="server"  style="font-family: Verdana;
                            font-size: small;" bgcolor="White" width="100%">
                            <tr>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Month
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Financial-year
                                </td>
                                <td style="border: solid thin black; font-weight: bold;">
                                    Units Consumed
                                    <br />
                                    in Nos.
                                </td>
                               
                                <td style="border: solid thin black; font-weight: bold;">
                                    Eligible amount Re-imbursement in Rs.
                                </td>
                                <th style="padding: 10px; margin: 5px; font-weight: bold;">
                                    &nbsp;
                                </th>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblmonth1" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblfinyear1"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblunitsconsumed1"  runat="server"></asp:Label>
                                </td>
                                
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblelegamount1" runat="server"></asp:Label>
                                </td>
                                <td rowspan="5" style="padding: 10px; margin: 5px; font-weight: bold;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblmonth2" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblfinyear2"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblunitsconsumed2"   runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblelegamount2"  runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblmonth3" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblfinyear3"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblunitsconsumed3" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblelegamount3" runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblmonth4" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblfinyear4"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblunitsconsumed4"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblelegamount4"  runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblmonth5" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblfinyear5"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblunitsconsumed5"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black;">
                                    <asp:Label ID="lblelegamount5"  runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td style="border: solid thin black; width:250px">
                                    <asp:Label ID="lblmonth6" Enabled="false" runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black; width:300px">
                                    <asp:Label ID="lblfinyear6"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black; width:300px">
                                    <asp:Label ID="lblunitsconsumed6"  runat="server"></asp:Label>
                                </td>
                                <td style="border: solid thin black; width:250px">
                                    <asp:Label ID="lblelegamount6"  runat="server"></asp:Label>
                                </td>
                                
                            </tr>
                            <tr style="width:80px">
                                <td style="border: solid thin black;" colspan="4">
                                    <br />
                                    Total amount :
                                    <asp:Label ID="lbltotalmaount" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Type&nbsp;:
                                    <asp:Label ID="lbltype" runat="server"></asp:Label>
                                    <br />
                                    
                                    
                                    <%-- <asp:Label runat="server" CssClass="form-control" ID="lbl_grdtoteligibleamount"></asp:Label>--%>
                                    <br />
                                    GM Recommended Amount :
                                    <asp:Label ID="lblGMreconamount" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Total Eliglible amount :
                                    <asp:Label ID="lblfinanelgamount" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                    Remarks:
                                    <asp:Label ID="lblremarks_TRDUTY" runat="server"></asp:Label>
                                    <br />
                                    <br />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                      <div align="center" id="divspecificcleaner" visible="false" runat="server" >
                            <table bgcolor="White"  style="font-family: Verdana; font-size: small;"
                                width="100%">
                                <tr>
                                     <td style="width:2%">

                                    </td>
                                    <td style="color: black; font-weight: bold;" class="auto-style8">
                                        <u>ELIGIBLE INCENTIVES </u>
                                    </td>
                                    <td>

                                    </td>
                                </tr>
                                      <tr>
                                     <td style="width:2%">

                                    </td>
                                    <td class="auto-style8" >Expenditure Incurred.
                                    </td>
                                    <td >
                                        <asp:Label ID="lblExpenditure" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     <td style="width:2%">

                                    </td>
                                    <td class="auto-style8" >25% Expenditure Incurred.
                                    </td>
                                    <td >
                                        <asp:Label ID="lblExpenditure25" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                   <tr>
                                     <td style="width:2%">

                                    </td>
                                    <td class="auto-style18" >Value recommended by G.M., DIC. in Rs.
                                    </td>
                                    <td class="auto-style4" >
                                        <asp:Label ID="lblgmspecific" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                  <tr>
                                     <td style="width:2%">

                                    </td>
                                    <td class="auto-style18" >Final Value Computed in Rs.
                                    </td>
                                    <td class="auto-style4" >
                                        <asp:Label ID="lvlfinalpecific" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false">
                                     <td style="width:2%">

                                    </td>
                                    <td class="auto-style8" ><b>TOTAL SUBSIDY(4.2 + 4.3)</b></td>
                                    <td >
                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                    </td>
                                </tr>


                            </table>
                        </div>
                          <br />
                    <div align="center" id="DIVSKILLUPGRADE" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                    4.0 <u>Reimbursement of cost involved in skill upgradation and training </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.1 Skill Upgradation charges paid
                                </td>
                                <td>
                                    <asp:Label ID="lblskillupchargespaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    4.2 50% of amount of skill upgradation charges paid
                                </td>
                                <td>
                                    <asp:Label ID="lbl50perskillupchargespaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.3 G.M Recommended Amount
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblgmrecomamount_skillupgrade" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.4 Eligible amount whichever is less
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblelegamountless_skillupgrade" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.5 Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltypeofclaim_skillupgrade" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    4.6 Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_skillupgrade" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr5" runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label20" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div align="center" id="DIVIIDF" visible="false" runat="server">
                        <table bgcolor="White" style="font-family: Verdana; font-size: small;" width="100%">
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td style="color: black; font-weight: bold;" class="auto-style8">
                                     <u>Industrial Infrastructure Development Fund(IIDF) </u>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    a. IIDF  charges paid
                                </td>
                                <td>
                                    <asp:Label ID="lbliidfchargespaid" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    b. 50% of amount of IIDF  charges paid
                                </td>
                                <td>
                                    <asp:Label ID="lbl50perofiidf" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    c. 15% of amount of computed cost
                                </td>
                                <td>
                                    <asp:Label ID="lbl15perofcompcost" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    d. G.M Recommended Amount
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblgmrecomamount_iidf" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    e. Eligible amount whichever is less
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblelegamountless_iidf" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    f. Type of Claim
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lbltypeofclaim_iidf" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style18">
                                    g. Remarks
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblremarks_iidf" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr id="Tr6" runat="server" visible="false">
                                <td style="width: 2%">
                                </td>
                                <td class="auto-style8">
                                    <b>TOTAL SUBSIDY(4.2 + 4.3)</b>
                                </td>
                                <td>
                                    <asp:Label ID="Label21" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br />
                    <br />
                    <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid;
                        border-left: thin solid; border-bottom: thin solid" type="button" value="Print" />
                    &nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx">HOME</a>
                </div>
            </div>
        </div>
    </form>
</body>