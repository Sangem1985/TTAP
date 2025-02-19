<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaxAppraisalPrint.aspx.cs" Inherits="TTAP.UI.Pages.TaxAppraisalPrint" %>

<!DOCTYPE html>

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

        

        .auto-style2 {
            height: 50px;
        }

        .auto-style4 {
            height: 34px;
        }

        .auto-style8 {
            width: 100% !important;
        }

        .auto-style18 {
            height: 34px;
           width:100% !important;
        }

        .auto-style19 {
            width: 142px;
        }
      table {
    width: 100%;
    padding: 0px 135px;
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
                </div>
                <br />
                <div>
                    <div>
                        <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;" class="Apprialtable">
                            <tr id="tideaTr" runat="server">
                                <td style="text-align: left; font-weight: bold;text-align:center;">
                                    <asp:Label ID="lblTideaTpride" runat="server" Visible="false" Text="Label"></asp:Label>
                                    Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO
                                29, Industries &amp; Commerce (IP &amp; INF) Department,
                                <br />
                                    Dated : 29/11/2014
                                </td>
                            </tr>
                            <tr id="tprideTr" runat="server">
                                <td style="text-align: center; font-weight: bold;">T-PRIDE -
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
                        <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;" class="Apprialtable">
                            <%-- <tr>
                            <td style="width: 2%">
                            </td>
                            <td class="auto-style1">
                                Application no
                            </td>
                            <td>
                                <asp:Label ID="lblApplication_no" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>--%>
                            <tr>
                                 
                                <td style="font: bolder; font-size: small" class="auto-style1">
                                    <b>1. Unit Name</b>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="lblUnitName" runat="server"></asp:Label></b> &nbsp;
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">2. Address
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">3. Name of the Proprietor
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblProprietor" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">4. Constitution of Organization
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblOrganization" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">5. Social Status
                                </td>
                                <td>
                                    <asp:Label ID="lblSocialStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">6. Share of SC/ST/Women Enterpreneur
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblShareofSCSTWomenEnterprenue" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">7. Registration Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblRegistrationNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">8. Type of Unit
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofApplicant" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                            <tr>
                                 
                                <td class="auto-style1">9. Category of Unit as per Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCategoryofUnit" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">10. Type of Sector
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofSector" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">11. Type of Textile as per Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTypeofTexttile" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                            <tr>
                                 
                                <td class="auto-style1">12. Technical Textile Type
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblTechnicalTextileType" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                            <tr>
                                 
                                <td class="auto-style1">13.  Activity of the Unit
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblActivityoftheUnit" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">14. UID Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblUIDNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>

                            <tr>
                                 
                                <td class="auto-style1">15.  Incentive Application Number
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCommonApplicationNumber" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">16.  Date of Power Connection Release
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPowerConnectionReleaseDate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">17.  Commencement of Commercial Production
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDCPdate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                 
                                <td class="auto-style1">18.  Date of Receipt of Claim Application
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblReceiptDate" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                          <%--  <tr>
                                 
                                <td class="auto-style1">19.  Promoter details in case eligible for additional subsidy
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblcategoryes" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>--%>

                        </table>
                        <div align="center">
                            <table style="font-family: Verdana; font-size: small; width: 60%" border="1">
                                <tr>
                                     
                                    <td align="center" colspan="4" style="text-align:center">
                                        <b>Fixed Capital Investment</b>
                                    </td>
                                    <td style="text-align: center">
                                        <b>(In Rupees)</b>
                                    </td>
                                     
                                         
                                    
                                </tr>
                                <tr>
                                    <td> 
                                     Details of Fixed Assets
                                    </td>
                                     <td>
                                        <b>As per Approved project cost </b>
                                    </td>
                                     <td>
                                        <b>As per GM Recommendation</b>
                                    </td>
                                     <td>
                                        <b>Computed as per Guidelines</b>
                                    </td>
                                     <td>
                                        <b>Reasons for variation between GM Recommended value and computed value</b>
                                    </td>
                                     
                                </tr>
                                <tr>
                                     
                                    <td colspan="1px">a. Land
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
                                     
                                    <td>b. Building
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
                                     
                                    <td>c. Plant & M/C
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
                                     
                                    <td colspan="1.5px">d.Tech.Knows -how feasibility study & turn key charges
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
                                     
                                    <td>e.Vehicles
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
                                     
                                    <td>f.Other eligible
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
                                <tr style="text-align: center">
                                     
                                    <td>Total
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
                                    
                                </tr>
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
                                    <td colspan="4" style="color: black; font-weight: bold;" class="auto-style8">19. <u>SALES TAX </u>
                                    </td>
                                </tr>
                               <%-- <tr>
                                     
                                    <td class="auto-style8">a) SCHEME
                                    </td>
                                    <td>
                                        <asp:Label ID="lblscheme" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                     
                                    <td class="auto-style8">a)Select Type
                                    </td>
                                    <td>
                                        <asp:Label ID="lblType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">b) Production
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblProduct" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">c) Tax Paid(SGST)
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblGST" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">d) Base Production
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblBaseProc" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">e) Eligible Production Qty over and above base Production
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblQty" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">f) Proportinate SGST value on eligible production
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblSGSTEligible" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                     
                                    <td class="auto-style18">g) Category
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                     
                                    <td class="auto-style18">h) AMOUNT
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblamount" runat="server"></asp:Label>
                                    </td>
                                </tr>


                                <tr>
                                     
                                    <td class="auto-style18">i) Select Type
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblSelectType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">j) GM Recommendedd Amount 
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblGMAmounted" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">k) Eligible Amount
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblEligibleamount" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">l)Final Subsidy Amount
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblSubsidyAmount" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                     
                                    <td class="auto-style18">m) Remark
                                    </td>
                                    <td class="auto-style4">
                                        <asp:Label ID="lblRemark" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                  <tr id="worksheet" runat="server" visible="false">
                                     
                                    <td class="auto-style18">n) Works Sheet
                                    </td>
                                    <td class="auto-style4">
                                        <%--<asp:Label ID="lblSheet" runat="server"></asp:Label>--%>
                                        <asp:HyperLink ID="hypsheet" Text="View" runat="server"></asp:HyperLink>
                                    </td>
                                </tr>


                            </table>
                        </div>
                        <br />
                        <br />
                        <br />
                        <input id="btnPrint" onclick="window.print()" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                            type="button" value="Print" />
                        &nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx">HOME</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
