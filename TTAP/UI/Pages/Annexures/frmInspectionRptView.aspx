<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInspectionRptView.aspx.cs" Inherits="TTAP.UI.Pages.Annexures.frmInspectionRptView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department of Handlooms & Textiles | Government of Telangana</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--Added by Pramod--%>
    <link rel="stylesheet" href="../../../AssetsNew/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/style.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/media.css" />
    <%--  <link href="../../../AssetsNew/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>

    <script src="../../../Js/jquery-latest.min.js"></script>
    <script src="../../../Js/jquery-ui.min.js"></script>
    <script src="../../../Js/jquery.min.js"></script>
    <script src="../../../Js/table2excel.js"></script>
    <style>
        .main {
            min-height: 595px;
            min-height: 75.4vh;
            /*background: #f3f8ff;*/
        }

        #collapsibleNavbar .navbar-nav.d-flex.w-50.m-auto {
            margin: 0px !important;
        }

        div#ContentPlaceHolder1_Receipt, .container.mt-4.pb-4, .col-sm-12.offset-md-1.col-md-10.col-lg-10.offset-lg-1.p-4.pb-0.mt-3.frm-form.box-content {
            max-width: 1210px !important;
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        .table-responsive {
            display: block;
            width: 100%;
            /* overflow-x: auto; */
            -webkit-overflow-scrolling: touch;
        }
    </style>
    <%-- <script type="text/javascript">
        $(function () {
            $('#datetimepicker').datetimepicker();
        });
        </script>--%>
    <script type="text/javascript">

        function myFunction() {
            document.getElementById("DivPrint").style.display = "none";
            window.print();
            document.getElementById("DivPrint").style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <%--  <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Concession on SGST</li>
                        </ul>--%>
                    </div>
                </div>
                <div class="container mt-4 pb-4" runat="server">
                    <%--<div class="w-100 px-3 frm-form box-content py-3 font-medium title5">--%>
                    <div class="w-100 px-4 frm-form py-4 font-medium title5" runat="server" id="divheader">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <div class="row">
                                        <h4 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="HMainheading"></h4>
                                    </div>
                                </div>
                                <div id="divChk">
                                    <asp:CheckBox runat="server" ID="chkShow" onclick="return ShowHide(this);" Text="Show System Calculted" />
                                </div>

                                <div class="widget-content nopadding" style="width: 100%;">
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise" border="1">
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="left" class="font-SemiBold">Name of The Enterprise</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtUnitName" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="left" class="font-SemiBold">UID Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTSIPassUIDNumber" runat="server"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Common Application Number </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblCommonApplicationNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="left" class="font-SemiBold">Category of Unit as per Application </td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblCategoryofUnit"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Type of Textile as per Application</td>
                                                    <td align="left">
                                                        <label class="control-label" id="TypeofTexttile" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="trInsFlag" runat="server" visible="false">
                                                    <td align="left" class="font-SemiBold">Revised Category of Unit as per DLO Inspection </td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblRevisedCategory"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Revised Type of Textile as per DLO Inspection</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblRevisedTypeTextile" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="left" class="font-SemiBold">Type of Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTypeofApplicant" runat="server"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Commencement of Commercial Production </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblDCPdate" runat="server"></label>
                                                    </td>

                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="left" class="font-SemiBold">Activity/Production of the Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblActivityoftheUnit"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Promoter details in case eligible for additional subsidy </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblcategory" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <%--<tr style="height: 40px">
                                                    <td align="left" colspan="4" class="font-SemiBold"></td>
                                                </tr>--%>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="left" class="font-SemiBold">Date of Receipt of Claim Application</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="lblReceiptDate" runat="server"></label>
                                                    </td>

                                                </tr>
                                                <%-- <tr style="height: 40px">
                                                    <td align="left" colspan="4" class="font-SemiBold"></td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="left" style="width: 25%" class="font-SemiBold">Name and Designation of the Inspecting Officer</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="lblInspectingOfficerName" runat="server"></label>
                                                    </td>
                                                    <td align="left" style="width: 25%" class="font-SemiBold">Date of Inspection</td>
                                                    <td align="left" style="width: 25%">
                                                        <label id="txtAppDateofInspection" runat="server" class="control-label"></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="font-SemiBold">Inspection Schduled Date</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblInspectionSchduledDate" runat="server"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">
                                                        <span id="Capitalsub" runat="server">Person from the Industry present at the time of Inspection</span></td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblIndustryPersonName"></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="font-SemiBold">Date of issue of Regd. Notice calling shortfall documents/information</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblquerydate" runat="server"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Date of Receipt of shortfall Documents / Information</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblresponsedate" runat="server"></label>
                                                    </td>
                                                </tr>

                                                <tr id="trStampDuty" runat="server" visible="false">
                                                    <td align="left" class="font-SemiBold">Nature of Asset</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblNatureofAsset" runat="server"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Whether the Enterprise has already availed any exemption on purchase of land, if so amount in Rs</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblavailedamount" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr id="trAssistanceforEnergyWaterEnvironmental" runat="server" visible="false">
                                                    <td align="left">Nature of Claim</td>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="chkAssistanceRequired" runat="server" CssClass="checkbox" Enabled="false" RepeatDirection="Vertical">
                                                            <asp:ListItem Text="Energy Audit" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Water Audit" Value="2"></asp:ListItem>
                                                            <asp:ListItem Text="Environmental Compliance" Value="3"></asp:ListItem>
                                                            <%--<asp:ListItem Text=" Common Effluent Treatment Plant at Cluster / Industrial Park" Value="4"></asp:ListItem>--%>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                    <td align="left">If the Unit is into Commercial Production for a minimum period of 3 years</td>
                                                    <td align="left">
                                                        <label class="control-label" id="RbtnCommercialProduction" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr id="trAssistanceforEnergyWaterEnvironmental1" runat="server" visible="false">
                                                    <td align="left">Whether the Enterprise has already availed assistance under T-TAP for Energy Audit / Water Audit / Environmental Compliance.</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtReimbursementReceived" runat="server"></label>
                                                    </td>
                                                </tr>

                                                <tr id="trTrainingSubsidy" runat="server" visible="false">
                                                    <td align="left">Number of total employees</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNumberofEmployees" runat="server"></label>
                                                    </td>
                                                    <td align="left">Number of Employees Trained</td>
                                                    <td align="left">

                                                        <label class="control-label" id="txtNumberofEmployeesTrained" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr id="trTrainingSubsidy1" runat="server" visible="false">
                                                    <td align="left">Training Cost per Employee Incurred</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtExpenditureIncurredTraining" runat="server"></label>
                                                    </td>
                                                </tr>

                                                <tr id="trTrainingInfrastructureSubsidy1" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <h6 class="text-black font-SemiBold">Investments for Setting up of Training Infrastructure</h6>
                                                    </td>
                                                </tr>
                                                <tr id="trTrainingInfrastructureSubsidy2" runat="server" visible="false">
                                                    <td align="left">Building</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtBuilding" runat="server"></label>
                                                    </td>
                                                    <td align="left">Plant & Machinery required for demonstration</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtPlantMachinery" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr id="trTrainingInfrastructureSubsidy3" runat="server" visible="false">
                                                    <td align="left">Installation Charges</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtInstallationCharges" runat="server"></label>
                                                    </td>
                                                    <td align="left">Electrification</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtElectrification" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr id="trTrainingInfrastructureSubsidy4" runat="server" visible="false">
                                                    <td align="left">Training Aids like projector etc</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtTrainingAids" runat="server"></label>
                                                    </td>
                                                    <td align="left">Furniture</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtFurniture" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr id="trTrainingInfrastructureSubsidy5" runat="server" visible="false">
                                                    <td align="left">Total Investment for Setting up of Training Infrastructure (Amount in Rupees)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTotalInvestment" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="font-SemiBold">Amount of Subsidy Claimed By Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblSubsidyClaimedUnit" runat="server"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold" id="tdsysSubsidy" style="display: none;" runat="server">Amount of Subsidy Recommended(System Calculated) as per DLO Inspection</td>
                                                    <td align="left" id="tdsysSubsidy1" style="display: none;" runat="server">
                                                        <label class="control-label" id="SubsidySystemRecommended" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="tr1" visible="false">
                                                    <td align="left" class="font-SemiBold">Claim Period</td>
                                                    <td align="left" colspan="3">
                                                        <label id="lblClaimPeriod" runat="server" class="control-label"></label>
                                                    </td>
                                                </tr>
                                                <tr id="trInsAmount" runat="server" visible="false">
                                                    <td align="left" class="font-SemiBold" id="td2" runat="server">Amount of Subsidy Recommended(System Calculated) as per TTAP Policy</td>
                                                    <td align="left" id="td4" runat="server">
                                                        <label class="control-label" id="lblInsAmount" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr id="trInspectingRecomAmount" runat="server" visible="false">
                                                    <td align="left" class="font-SemiBold">Amount of Subsidy Recommended by Inspecting Officer</td>
                                                    <td align="left">
                                                        <label id="txtAmountSubsidyRecommended" runat="server" class="control-label"></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="font-SemiBold">Remarks</td>
                                                    <td align="left" colspan="3">
                                                        <label id="txtRemarks" runat="server" class="control-label"></label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trIndustryDeptDtls" visible="false">
                                                    <td align="left" class="font-SemiBold">Name of the Industries Department Person who Updated the Report</td>
                                                    <td align="left">
                                                        <label id="lblIndustriesPerosnName" runat="server" class="control-label"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Industries Department Report Submitted Date</td>
                                                    <td align="left">
                                                        <label id="lblIndustryReportDate" runat="server" class="control-label"></label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trIndustryDeptRemarks" visible="false">
                                                    <td align="left" class="font-SemiBold">Industries Department Remarks</td>
                                                    <td align="left" colspan="3">
                                                        <label id="txtIndustriesRemarks" runat="server" class="control-label"></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="font-SemiBold">Verification Certificate</td>
                                                    <td align="left" colspan="3">Certified that contents of the claim under Part-A along with required documents of this claim application were 
                                                        verified and found correct. The Plant and Machinery and equipment was physically verified as per the statement of
                                                        machinery and found them fully installed and put on work. Further certified that the fixed assets claimed for 
                                                        incentives are essentially required for carrying the production in which the industry is engaged in.
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trApprovedProject" visible="false">
                                                    <td align="left" colspan="4">
                                                        <%--<div class="text-blue font-SemiBold col col-sm-12 mt-3">Approved Project Cost(In Rs.)</div>--%>
                                                        <div class="col-sm-12 text-black font-SemiBold mb-1">1. Approved Project Cost(In Rs.)</div>
                                                        <div class="col-sm-10 table-responsive">
                                                            <table class="table table-bordered title6 w-100 NewEnterprise" border="1">
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Nature of Assets</th>
                                                                    <th>Value (in Rs.)</th>
                                                                    <th id="trFixedCapitalexpansion" runat="server"
                                                                        visible="false">Under Expansion/ Diversification/ Modification Project
                                                                    </th>
                                                                    <th id="trFixedCapitalexpnPercent" runat="server"
                                                                        visible="false">% of increase under
                                                                            <br />
                                                                        Expansion/Diversification/Modification
                                                                    </th>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="left">Land</td>
                                                                    <td align="center">
                                                                        <label id="txtlandexisting" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                    <td id="Td5" runat="server" align="center" visible="false">
                                                                        <label id="txtlandcapacity" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                    <td id="txtbuildcapacityPercet" runat="server" align="center" visible="false">
                                                                        <label id="txtlandpercentage" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>2</td>
                                                                    <td align="left">Building </td>
                                                                    <td align="center">
                                                                        <label id="txtbuildingexisting" runat="server" cssclass="control-label"></label>
                                                                    </td>

                                                                    <td id="trFixedCapitalBuilding" runat="server" align="center" visible="false">
                                                                        <label id="txtbuildingcapacity" runat="server" cssclass="control-label"></label>
                                                                    </td>

                                                                    <td id="trFixedCapitBuildPercent" runat="server" align="center" visible="false">
                                                                        <label id="txtbuildingpercentage" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="center">
                                                                        <label id="txtplantexisting" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                    <td id="trFixedCapitalMach" runat="server" align="center" visible="false">
                                                                        <label id="txtplantcapacity" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                    <td id="trFixedCapitMachPercent" runat="server" align="center" visible="false">
                                                                        <label id="txtplantpercentage" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td></td>
                                                                    <td align="left" style="text-align: left; font-weight: bold">Total</td>
                                                                    <td align="center">
                                                                        <label id="lblnewinv" runat="server" font-bold="True"></label>
                                                                    </td>
                                                                    <td id="Td6" runat="server" align="center" visible="false">
                                                                        <label id="lblexpinv" runat="server" font-bold="True"></label>
                                                                    </td>
                                                                    <td id="Td7" runat="server" align="center" visible="false">
                                                                        <label id="lbltotperinv" runat="server" font-bold="True"></label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trActualInvestment" visible="false">
                                                    <td align="left" colspan="4">
                                                        <%-- <div class="text-blue font-SemiBold col col-sm-12 mt-3">Actual Investment(In Rs.)</div>--%>
                                                        <div class="col-sm-12 text-black font-SemiBold mb-1">2. Actual Investment(In Rs.)</div>
                                                        <div class="col-sm-10 table-responsive">
                                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>S.No</th>
                                                                    <th>Nature of Assets</th>
                                                                    <th id="thExistingActual" runat="server">Existing Enterprise Value (in Rs.)</th>
                                                                    <th id="thExpansionActual" runat="server">Enterprise Value (in Rs.)</th>
                                                                    <th id="trActualCapitalexpnPercent" runat="server" visible="false">% of increase under
                                                                            Expansion/Diversification/Modification
                                                                    </th>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="left">Land</td>
                                                                    <td align="center" id="thExistingLandActual" runat="server">
                                                                        <label id="txtcurrInvLandValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionLandActual" runat="server">
                                                                        <label id="txtExpansionLandValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionLandActualPer" runat="server" align="center">
                                                                        <label id="txtExpansionLandPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>2</td>
                                                                    <td align="left">Building </td>
                                                                    <td align="center" id="thExistingBuildingActual" runat="server">
                                                                        <label id="txtcurrInvBuldvalue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionBuildingActual" runat="server">
                                                                        <label id="txtExpansionBuildingValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionBuildingPer" runat="server" align="center">
                                                                        <label id="txtExpansionBuildingPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;</td>
                                                                    <td align="center" id="thExistingPMActual" runat="server">
                                                                        <label id="txtcurrInvplantMechValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionPMActual" runat="server">
                                                                        <label id="txtExpansionplantMechValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionPMPer" runat="server" align="center">
                                                                        <label id="txtExpansionPMPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>4</td>
                                                                    <td align="left" style="text-align: left">Others &nbsp;&nbsp;&nbsp;</td>
                                                                    <td align="center" id="thExistingOthersActual" runat="server">
                                                                        <label id="txtcurrentInvothers" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionOthersActual" runat="server">
                                                                        <label id="txtExpansionInvothers" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionOthersPer" runat="server" align="center">
                                                                        <label id="txtExpansionOthersPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="left" style="text-align: left; font-weight: bold">Total</td>
                                                                    <td align="center" id="thExistingTotalActual" runat="server">
                                                                        <label id="lblCurrInvTot" runat="server" style="font-weight: bold" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionTotalActual" runat="server">
                                                                        <label id="lblExpansionInvTot" runat="server" style="font-weight: bold" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionTotalPer" runat="server" align="center">
                                                                        <label id="txtExpansionTotalPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trLandDetails" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="row" id="Div1" runat="server">
                                                            <%--<h6 class="col-sm-12 text-black font-SemiBold mb-1">Land Details</h6>--%>
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">3. Land Details as per Application</div>
                                                            <div class="col-sm-11 table-responsive">
                                                                <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>S.No</th>
                                                                        <th>Type of Land</th>
                                                                        <th>Extent in Acre</th>
                                                                        <th>Cost Per Acre (In Rs)</th>
                                                                        <th>Value Of Land (In Rs)</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center"></td>
                                                                        <td align="center">1</td>
                                                                        <td align="center">2</td>
                                                                        <td align="center">3</td>
                                                                        <td align="center">4</td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td align="left">Purchased Land </td>
                                                                        <td align="center">
                                                                            <asp:TextBox ID="txtPLExtent" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:TextBox ID="txtPLValue" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblPLTotalValue" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="left">Leased Land</td>
                                                                        <td align="center">
                                                                            <asp:TextBox ID="txtLLExtent" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:TextBox ID="txtLLValue" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblLLTotalValue" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>3</td>
                                                                        <td align="left">Inhertied Land</td>
                                                                        <td align="center">
                                                                            <asp:TextBox ID="txtILExtent" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:TextBox ID="txtILValue" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblILTotalValue" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>4</td>
                                                                        <td align="left">Govt Land (TSIIC developed IEs/IDA/Industrial Parks)</td>
                                                                        <td align="center">
                                                                            <asp:TextBox ID="txtGLExtent" Enabled="false" runat="server" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:TextBox ID="txtGLValue" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblGLTotalValue" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trCalcLandBuilding" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="row" id="Div2" runat="server">
                                                            <%--<h6 class="col-sm-12 text-black font-SemiBold mb-1">Land Details</h6>--%>
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">4 Computation of Fixed capital Investment</div>
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">4.1 Land Details</div>
                                                            <div class="col-sm-11 table-responsive">
                                                                <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>S.No</th>
                                                                        <th>Description</th>
                                                                        <th>As per Approved Cost</th>
                                                                        <th>As per Actual Investment</th>
                                                                        <th>As per Document Verification(Sale Deed)</th>
                                                                        <th>Eligibility Computed</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center"></td>
                                                                        <td align="center">1</td>
                                                                        <td align="center">2</td>
                                                                        <td align="center">3</td>
                                                                        <td align="center">4</td>
                                                                        <td align="center">5</td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td align="left">Land Extent (in Acres)</td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblExtentApproved" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblExtentActual" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblExtentSaledeed" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblExtentDLO" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="left">Cost/Acre(in Rs.)</td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblAcreCostApproved" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblAcreCostActual" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblAcreCostSaledeed" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblAcreCostDLO" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>3</td>
                                                                        <td align="left">Total Land Cost(in Rs.)</td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblTotalLanndCostApproved" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblTotalLanndCostActual" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblLandCostSaledeed" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:Label ID="lblTotalLanndCostDLO" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trBuildingDetails" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="col-sm-12 text-black font-SemiBold mb-1">4.2 Building Details</div>
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <asp:GridView ID="GvBuildingDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                CssClass="table table-bordered title6 w-100 NewEnterprise" OnRowDataBound="GvBuildingDetails_RowDataBound">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="S.No">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                            <asp:Label ID="lblBUILDINGID" Visible="false" runat="server" Text='<%# Bind("BUILDINGID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Item of Civil works <br/> (1)">
                                                                        <ItemTemplate>

                                                                            <asp:Label ID="lblCivilworks" runat="server" Text='<%# Bind("Civilworks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Plinth Area(in Sq.Meter) as per Application <br/> (2)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPlinthArea" runat="server" Text='<%# Bind("PlinthArea") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Value as per Application (in Rs.) <br/> (3)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblValueRs" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DLO Recommended Plinth Area(in Sq.Meter) as per the APSFC norms <br/> (4)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDLOPlinthArea" runat="server" Text='<%# Bind("DLORecommendedPlinthArea") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DLO Recommended Rate/Sq.Meter as per the APSFC norms <br/> (5)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDLOSqmterValue" runat="server" Text='<%# Bind("DLOSqmterValue") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DLO Recommended Amount as per the APSFC norms(in Rs.) <br/> (6)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDLOAmount" runat="server" Text='<%# Bind("DLORecommendedAmount") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks <br/> (7)">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtDLORemarks" Enabled="false" TextMode="MultiLine" runat="server" Text='<%# Bind("DLORemarks") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <div class="row mt-4">
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label2" runat="server">Total Plinth Area of Civil Works item No.1 to 7 (in Sq meters) : </label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lbl1to7Plinth"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label5" runat="server">Total Value of Civil Works item No. 1 to 9 (in Rs.) : </label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lbl1to9Value"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label7" runat="server">Total Value of item No. 8 to 17 (Not exceeding 10% of total value Civil works items 1 to 9) (in Rs.) : </label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lbl8to17Value"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>


                                                <tr id="divplantmachinary" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="col-sm-12 text-black font-SemiBold mb-1">4.3 Plant and Machinery Details</div>
                                                        <a id="A2" href="#" class="tags" onclick="return Export();" title="Export to Excel" gloss="Export to Excel" runat="server" style="float: right">
                                                            <img src="../../../images/Excel-icon.png" style="margin: -34px 768px 12px 0px;" width="30px" height="30px"
                                                                alt="Excel" /></a>
                                                        <%--<div class="row my-4">--%>
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <asp:GridView runat="server" ID="grdPandM" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                                CssClass="table table-bordered title6 w-100 NewEnterprise" OnRowDataBound="grdPandM_RowDataBound">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="5%">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="P&M Id <br/> (1)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPMId" Text='<%#Eval("PMId") %>' runat="server" />
                                                                            <asp:Label ID="lblIncentiveId" Visible="false" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Machine Name <br/> (2)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMachineName" Text='<%#Eval("MachineName") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField HeaderText="Vendor Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVendorName" Text='<%#Eval("VendorName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderText="Type of Machine <br/> (3)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblTypeofMachine" Text='<%#Eval("TypeofMachine") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Invoice Number <br/> (4)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInvoiceNo" Text='<%#Eval("InvoiceNo") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Acutal Machine Cost (In Rs) <br/> (5)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMachineCost" Text='<%#Eval("MachineCost") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DLO Recommended Machine Cost (In Rs) <br/> (6)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDLOMachineCost" Text='<%#Eval("DLOFinalRecommendedMachineCost") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Classification of Machinery <br/> (7)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblClassificationofMachinery" Text='<%#Eval("ClassificationMachineryText") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Availability of the Machine in Running Condition <br/> (8)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMachinesavailability" Text='<%#Eval("MachineAvailabilityText") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle CssClass="text-center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks <br/> (9)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="txtremarks" Text='<%#Eval("Remarks") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <%-- </div>--%>

                                                        <div class="row mt-4">
                                                            <%-- <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label3" runat="server">Actual Machinery Total Value (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="Label6"></label>
                                                                    </div>
                                                                </div>
                                                            </div>--%>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label10" runat="server">Availabile Machinery Total Value (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lblTotalValueofAvailabile"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label4" runat="server">Non Availabile Machinery Total Value (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lblTotalValueofNonAvailabile"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label1" runat="server">Total Value of Machinery (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lblTotalValueMachinery"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trEqiupment" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="col-sm-12 text-black font-SemiBold mb-1">Equiment Details</div>
                                                        <a id="A1" href="#" class="tags" onclick="return ExportEq();" title="Export to Excel" gloss="Export to Excel" runat="server" style="float: right">
                                                            <img src="../../../images/Excel-icon.png" style="margin: -34px 768px 12px 0px;" width="30px" height="30px"
                                                                alt="Excel" /></a>
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <asp:GridView runat="server" ID="gvEquipments" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                                CssClass="table table-bordered title6 w-100 NewEnterprise" OnRowDataBound="gvEquipments_RowDataBound">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S.No" ItemStyle-Width="5%">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField Visible="false" HeaderText="P&M Id <br/> (1)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEquipmentId" Text='<%#Eval("Equipment_ID") %>' runat="server" />
                                                                            <asp:Label ID="lblIncentiveId" Visible="false" Text='<%#Eval("Incentive_id") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Category <br/> (1)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCategory" Text='<%#Eval("CategoryName") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="NameoftheEquipment <br/> (2)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEquipment" Text='<%#Eval("NameoftheEquipment") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Invoice No <br/> (3)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInvoiceNo" Text='<%#Eval("EquipmentInvoiceNo") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Invoice Date <br/> (4)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInvoiceDate" Text='<%#Eval("EquipmentInvoiceDate") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Acutal Equipment Cost (In Rs) <br/> (5)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAcutalEquipmentCost" Text='<%#Eval("Total") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DLO Recommended Equipment Cost (In Rs) <br/> (6)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDLORecommendedEqipmentCost" Text='<%#Eval("DLORecommendedEqipmentCost") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField HeaderText="Classification of Machinery <br/> (7)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblClassificationofMachinery" Text='<%#Eval("ClassificationMachineryText") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Availability of the Equipment in Running Condition <br/> (7)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEqipmentAvailability" Text='<%#Eval("EqipmentAvailability") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle CssClass="text-center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks <br/> (8)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="txtremarks" Text='<%#Eval("Remarks") %>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <%-- </div>--%>

                                                        <div class="row mt-4">
                                                            <%-- <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label3" runat="server">Actual Machinery Total Value (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="Label6"></label>
                                                                    </div>
                                                                </div>
                                                            </div>--%>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="lblTotal" runat="server">Availabile Equipment Total Value (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lblTotalValueofAvailabileEq"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label8" runat="server">Non Availabile Equipment Total Value (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lblTotalValueofNonAvailabileEq"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label11" runat="server">Total Value of Equipment (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lblTotalValueEquipment"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <div runat="server" visible="false" id="divIntrestSubsidy">
                                                        <tr runat="server">
                                                            <td align="left" colspan="4">
                                                                <div class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Term Loan Sanctioned & availed .</div>
                                                                <div class="row">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                        <asp:GridView runat="server" ID="GVTermLoandtls" AutoGenerateColumns="False" CellPadding="4"
                                                                            PageSize="50" ShowFooter="true" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" CellSpacing="4" OnRowDataBound="GVTermLoandtls_RowDataBound">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sl.No </br>(1)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan </br>(2)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAvailedTermLoan" runat="server" Text='<%# Bind("AvailedTermLoan") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Date of Application for Term Loan </br>(3)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermLoanApplDate" runat="server" Text='<%# Bind("TermLoanApplDate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Institution Name </br>(4)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblInstitutionName" runat="server" Text='<%# Bind("BankName") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan Sanc RefNo </br> (5)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermLoanSancRefNo" runat="server" Text='<%# Bind("TermLoanSancRefNo") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan Sanction Date </br> (6)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermloanSandate" runat="server" Text='<%# Bind("TermloanSandate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Sanctioned Amount </br>(7)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSanctionedAmount" runat="server" Text='<%# Bind("SanctionedAmount") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan Account No. </br>(8)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermAccountNo" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan First Release Date </br>(9)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermLoanReleaseddate" runat="server" Text='<%# Bind("TermLoanReleaseddate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan First Release Amount </br>(10)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermLoanReleaseddate" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                            <%--<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                    <RowStyle BackColor="White" ForeColor="#003399" />--%>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                        <asp:GridView runat="server" ID="GVTermLoandtls2" AutoGenerateColumns="False" CellPadding="4"
                                                                            PageSize="50" ShowFooter="true" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4" OnRowDataBound="GVTermLoandtls2_RowDataBound">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAvailedTermLoan" runat="server" Text='<%# Bind("AvailedTermLoan") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="No.Of Installments </br>(11)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermLoanInstallments" runat="server" Text='<%# Bind("Installments") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Rate Of Interest (%) </br>(12)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRateOfInterest" runat="server" Text='<%# Bind("RateOfInterest") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan Repayment Period </br>(From - To) </br>(13)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRateOfInterest" runat="server" Text='<%# Bind("TLRP") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan Disbursed as on  </br>(14)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRateOfInterest" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan Outstanding as on </br>(15)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRateOfInterest" runat="server"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--<asp:TemplateField HeaderText="TermLoan Period From Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanPeriodFromDate" runat="server" Text='<%# Bind("TermLoanPeriodFromDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="TermLoan Period To Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanPeriodToDate" runat="server" Text='<%# Bind("TermLoanPeriodToDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                                <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblInstitutionNameid" runat="server" Visible="false" Text='<%# Bind("InstitutionName") %>'></asp:Label>
                                                                                        <asp:Label ID="lblTermLoanId" runat="server" Text='<%# Bind("TermLoanId") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="4">
                                                                <div class="text-blue font-SemiBold col col-sm-12 mt-3">Claim Period Details</div>
                                                                <div class="row">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                        <asp:GridView runat="server" ID="GvInterestSubsidyPeriod" AutoGenerateColumns="False" CellPadding="4"
                                                                            PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 w-75 NewEnterprise" CellSpacing="4">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                            <Columns>
                                                                                <%--  <asp:TemplateField HeaderText="S No. </br> (1)">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>--%>
                                                                                <asp:TemplateField HeaderText="Financial Year </br> (1)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFinancialYear" runat="server" Text='<%#Eval("FinancialYearText") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="1st/2nd half Year </br> (2)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField Visible="false" HeaderText="Amount (In Rupees) </br> (4)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmountPaid" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" visible="true">
                                                            <td align="left" colspan="4">
                                                                <div class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Term loan repaid during Current Claim Period</div>
                                                                <div class="row">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                        <asp:GridView runat="server" ID="grdTermLoanRepaid" AutoGenerateColumns="False" CellPadding="4"
                                                                            PageSize="50" ShowFooter="true" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4" OnRowDataBound="grdTermLoanRepaid_RowDataBound">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No </br> (1)" ItemStyle-Width="6%">
                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                    <ItemTemplate>
                                                                                        <%# Container.DataItemIndex + 1%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan </br> (2)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermLoanNo" Text='<%#Eval("TermLoanNo") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bank Name </br> (3)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Loan Account Number </br> (4)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAccountNo" Text='<%#Eval("AccountNo") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Opening Balance at the Starting of Half Year </br> (5)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblOpeningBalanceStartofHalfYear" Text='<%#Eval("OpeningBalanceStartofHalfYear") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Closing Balance at the End of Half Year </br> (6)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblClosingBalanceEndofHalfYear" Text='<%#Eval("ClosingBalanceEndofHalfYear") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Principal Amount Repaid for the Period </br> (7)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPrincipalAmt" Text='<%#Eval("PrincipalAmt") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Rate of Interest (%) </br> (8)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRateOfInterest" Text='<%#Eval("RateOfInterest") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Interest Amount Paid for the Period </br> (9)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblInterestAmt" Text='<%#Eval("InterestAmt") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Payment Date  </br> (10)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblPaymentDate" Text='<%#Eval("PaymentDate") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%-- <asp:TemplateField HeaderText="Payment Date" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPaymentDate" Text='<%#Eval("PaymentDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                            </Columns>

                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>

                                                            </td>
                                                        </tr>
                                                        <tr runat="server" visible="true">
                                                            <td align="left" colspan="4">
                                                                <div class="text-blue font-SemiBold col col-sm-12 mt-3">Month wise & Bank wise Details of Current Claim Period</div>
                                                                <div class="row">
                                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                        <asp:GridView runat="server" ID="gvAdditionalInformation" AutoGenerateColumns="False" CellPadding="4"
                                                                            PageSize="50" ShowFooter="true" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4" OnRowDataBound="gvAdditionalInformation_RowDataBound">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S No. </br> (1)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Term Loan </br> (2)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTermloan" runat="server" Text='<%#Eval("TermLoan") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Month </br> (3)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAmountDueDate" runat="server" Text='<%#Eval("TLMonthName") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bank Name </br> (4)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblBankName" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Account No. </br> (5)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAccountNo" runat="server" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%-- <asp:TemplateField Visible="false" HeaderText="1st/2nd half Year">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTypeOfFinancialYearText" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                                <asp:TemplateField HeaderText="Opening Balance (In Rupees) </br> (6)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTearmLoanAmount" runat="server" Text='<%#Eval("TearmLoanAmount") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Installment Number </br> (7)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblNoOfInstallments" runat="server" Text='<%#Eval("InstallmentNo") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Rate of interest for the Month(%) </br> (8)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRateofInterestAmountDue" runat="server" Text='<%#Eval("RateofInterestAmountDue") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Interest Paid </br> (9)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblInterestDue" runat="server" Text='<%#Eval("InterestPaid") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Closing Balance (In Rupees) </br> (10)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblClosingBalance" runat="server" Text='<%#Eval("ClosingBalance") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%-- <asp:TemplateField  Visible="false" HeaderText="Unit holder contribution </br> (9)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnitHolderContribution" runat="server" Text='<%#Eval("UnitHolderContribution") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                                <asp:TemplateField HeaderText="Eligible rate of interest </br> (11)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEligibleRateInterest" runat="server" Text='<%#Eval("EligibleRateInterest") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Eligible interest Amount Claimed by the Unit</br> (12)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblEligibleInterest" runat="server" Text='<%#Eval("EligibleInterest") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DLO Recommended Eligible Interest Amount</br> (13)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDLOEligibleInterest" runat="server" Text='<%#Eval("DLORecommendedInterest") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="DLO Remarks</br> (14)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDLORemarks" runat="server" Text='<%#Eval("DLORemarks") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>

                                                            </td>
                                                        </tr>
                                                        <tr runat="server" visible="false">
                                                            <td align="left" colspan="2">
                                                                <div class="text-blue font-SemiBold col col-sm-12 mt-3">DLO Manual Recommended Amount : </div>
                                                            </td>
                                                            <td>
                                                                <div class="font-SemiBold col col-sm-12 mt-3">
                                                                    <asp:Label runat="server" ID="lblDLOSuggestedAmount"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <div class="text-blue font-SemiBold col col-sm-12 mt-3">Whether the Unit has availed Interest Subsidy from GOI or any other Agency</div>
                                                            </td>
                                                            <td align="left" colspan="1">
                                                                <asp:Label runat="server" ID="lblGOAgency">Yes</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <div runat="server" id="divGOAgency" visible="false">
                                                            <tr>
                                                                <td align="left">Amount Availed 
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblAmountAvailed"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Sanction Order No 
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblSanctionOrderNo"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">Date Availed
                                                                </td>
                                                                <td>
                                                                    <asp:Label runat="server" ID="lblDateAvailed">NA</asp:Label>
                                                                </td>
                                                            </tr>
                                                        </div>
                                                        <tr>
                                                            <td align="left" colspan="3">
                                                                <div class="text-blue font-SemiBold col col-sm-12 mt-3">Whether the Unit has availed Mortorium period for repayment of Loan</div>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label runat="server" ID="lblMoratoriumYesNo">No</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr runat="server" id="trMoratorium" visible="false">
                                                            <td align="left" colspan="4">
                                                                <div class="text-blue font-SemiBold col col-sm-12 mt-3">Moratorium Period for RePayment of Loan</div>
                                                                <div class="row">
                                                                    <div class="col-lg-14 col-md-14 col-sm-14 col-xs-14 table-responsive mt-2">
                                                                        <asp:GridView ID="GvMoratoriumPeriod" runat="server" CssClass="table table-bordered title6 w-100 NewEnterprise"
                                                                            AutoGenerateColumns="false">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="S No. </br> (1)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="1st/2nd half Year </br> (2)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From Date </br> (3)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("FromDate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To Date </br> (4)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblToDate" runat="server" Text='<%#Eval("ToDate") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Bank Name </br> (5)" HeaderStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Rate Of Interest (%) </br> (6)">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblMoratoriumRateOfInterest" runat="server" Text='<%# Bind("RateOfInterest") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </div>
                                                </tr>

                                                <tr id="trAmountofSubsidyRecommendedAbstract" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="row" id="Div4" runat="server">
                                                            <%--<h6 class="col-sm-12 text-black font-SemiBold mb-1">Land Details</h6>--%>
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">4.4 Total Cost Computed</div>
                                                            <div class="col-sm-11 table-responsive">
                                                                <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>S.No</th>
                                                                        <th>Description</th>
                                                                        <th>Calculated Value</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center"></td>
                                                                        <td align="center">1</td>
                                                                        <td align="center">2</td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td align="left">Land Value </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblCalcLandValue" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="left">Building Value</td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblCalcBuildingValue" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>3</td>
                                                                        <td align="left">Plant & Machinary Value</td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblCalcPMValue" runat="server" class="form-control"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trcapitalsubsidy" runat="server" style="display: none;">
                                                    <td colspan="4">
                                                        <div class="row" id="Div3" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">4.5 Amount of Subsidy Recommended</div>
                                                            <div class="col-sm-8 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise" border="1">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>Sl.No</th>
                                                                        <th>Subsidy</th>
                                                                        <th>System Calculated (in Rs.)</th>
                                                                        <th>Amount of Subsidy Recommended By Inspcting Officer(in Rs.)</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center"></td>
                                                                        <td align="center">1</td>
                                                                        <td align="center">2</td>
                                                                        <td align="center">3</td>

                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td align="left">Capital Subsidy</td>
                                                                        <td align="center">
                                                                            <label id="lblSystemSubsidy" runat="server" cssclass="control-label"></label>
                                                                        </td>
                                                                        <td id="trFixedCapitalland" runat="server" align="center">
                                                                            <label id="txtInspectingOfficerSubsidy" runat="server" cssclass="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="left">Additional Capital Subsidy for SC/ST, Women entrepreneurs or PWD (in Rs.)</td>
                                                                        <td align="center">
                                                                            <label id="lblSystemAdditionalCapitalSubsidy" runat="server" cssclass="control-label"></label>
                                                                        </td>
                                                                        <td id="Td1" runat="server" align="center">
                                                                            <label id="txtInspectingOfficerAdditionalCapitalSubsidy" runat="server" cssclass="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <td align="left" style="text-align: left; font-weight: bold">Total Capital Subsidy (in Rs.)</td>
                                                                        <td align="center">
                                                                            <label id="lblSystemTotal" runat="server" font-bold="True"></label>
                                                                        </td>
                                                                        <td id="Td3" runat="server" align="center">
                                                                            <label id="lblInspectingOfficerTotal" runat="server" font-bold="True"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left" colspan="4">

                                                        <div class="col-sm-12 text-black font-bold mb-1">Documents Enclosed by the Applicant</div>
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                                                CssClass="table table-bordered title6 w-100 NewEnterprise"
                                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="gvSubsidy_RowDataBound">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments <br/> (1)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                    </asp:TemplateField>--%>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date <br/> (2)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="130px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Verify Status <br/> (3)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblverifiedstatus" Text='<%#Eval("VerifyStatus")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="130px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        <span class="pull-left pt-2">The claim application of the captioned Enterprise/Industry is verified as per the operational guidelines. 
                                                             The Enterprise/Industry is eligible for availing incentives under T-TAP. The Enterprise/Industry did not add or remove any Plant & Machinery 
                                                             and there is no change in line of activity and capacity. Further, the Enterprise/Industry is in continuous operation, 
                                                             there is no break-in-production (if not the details of the break- in-production) and
                                                             I recommend the above incentives to the captioned Enterprise/Industry</span>
                                                        <span class="pull-left pt-4" id="divSLCFIle" runat="server" visible="false">We 
                                                        <asp:Label ID="lblDLORDOName" runat="server" Text=""></asp:Label>, 
                                                        hereby certify that the incentive application has been processed in accordance with the operational 
                                                        guidelines under T-TAP, if any deviation from guidelinesis foundout, 
                                                        we shall be held responsible for any action deemed fit. 
                                                        </span>
                                                        <span class="col-sm-12 pull-left pt-2">This is to verify that there is no break in production since commencement of production
                                                        </span>
                                                        <span class="pull-left pt-5">
                                                            <asp:Label ID="lblplace" runat="server">Date</asp:Label><br />

                                                        </span>
                                                        <span id="spnRDD" runat="server" visible="false" class="pull-right pt-5  pl-3"><span style="font-weight: bold" id="spnRDDname" runat="server">Yours faithfully,</span><br />
                                                            <asp:Label ID="lblRDDname" runat="server"></asp:Label><br />
                                                        </span>

                                                        <span class="pull-right pt-5 pr-3"><span style="font-weight: bold; padding-left: 150px;" id="spnDLO" runat="server">Yours faithfully,</span><br />
                                                            <asp:Label ID="lblGMname" runat="server"></asp:Label><br />
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="container" id="DivPrint" runat="server" style="text-align: center; vertical-align: bottom">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                                            <%--<input id="Button3" type="button" value="Print" class="btn btn-warning btn-lg" onclick="return Print();" />--%>
                                            <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="window.print();" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnUserRole" runat="server" />
        <asp:HiddenField ID="hdnSubIncentiveId" runat="server" />
    </form>

    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../NewCss/js/excanvas.min.js"></script>
    <script src="../../../NewCss/js/jquery.ui.custom.js"></script>
    <script src="../../../NewCss/js/bootstrap.min.js"></script>
    <script src="../../../NewCss/js/jquery.flot.min.js"></script>
    <script src="../../../NewCss/js/jquery.flot.resize.min.js"></script>
    <script src="../../../NewCss/js/jquery.peity.min.js"></script>
    <script src="../../../NewCss/js/maruti.js"></script>
    <script src="../../../NewCss/js/maruti.dashboard.js"></script>
    <script src="../../../NewCss/js/maruti.chat.js"></script>

    <%-- <script src="Scripts/bootstrap.min.js"></script>
        <script src="../../../Scripts/jquery-3.3.1.min.js"></script>
        <script src="../../../Scripts/jquery-3.3.1.js"></script>
        <script src="../../../AssetsNew/js/bootstrap-datetimepicker.min.js"></script>--%>
    <script type="text/javascript">
        // This function is called from the pop-up menus to transfer to
        // a different page. Ignore if the value returned is a null string:
        function goPage(newURL) {

            // if url is empty, skip the menu dividers and reset the menu selection to default
            if (newURL != "") {

                // if url is "-", it is this page -- reset the menu:
                if (newURL == "-") {
                    resetMenu();
                }
                // else, send page to designated URL            
                else {
                    document.location.href = newURL;
                }
            }
        }

        // resets the menu selection upon entry to this page:
        function resetMenu() {
            document.gomenu.selector.selectedIndex = 2;
        }
    </script>
    <script src="../../../AssetsNew/js/popper.min.js"></script>
    <script src="../../../AssetsNew/js/bootstrap.min.js"></script>
    <script src="../../../AssetsNew/js/floating.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $(function () {
                var url = window.location.pathname,
                    urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");
                // now grab every link from the navigation
                $('.navbar a, footer a').each(function () {
                    // and test its normalized href against the url pathname regexp
                    if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
                        $(this).addClass('active');
                    }
                });
            });
        });
        function ShowHide(res) {
            if (res.checked == true) {
                $('#tdsysSubsidy').show();
                $('#tdsysSubsidy1').show();
                if ($('#hdnSubIncentiveId').val() == "1") {
                    $('#trcapitalsubsidy').show();
                }
            }
            else {
                $('#tdsysSubsidy').hide();
                $('#tdsysSubsidy1').hide();
                $('#trcapitalsubsidy').hide();
            }
        }
        function Print() {
            $('#divChk').hide();
            var divContents = '';
            divContents = document.getElementById("divheader").innerHTML;
            var a = window.open('', '', 'height=500, width=500');
            a.document.write('<html>');
            a.document.write('<body > <h1 align="center"> Inspection Report <br>');
            a.document.write(divContents);
            a.document.write('</body></html>');
            a.document.close();
            a.print();
            $('#divChk').show();
            return false;
        }
        function Export() {
            $("[id*=grdPandM]").table2excel({
                filename: "PlantandMachinary.xls"
            });
        }
        function ExportEq() {
            $("[id*=gvEquipments]").table2excel({
                filename: "EquipmentList.xls"
            });
        }
    </script>
</body>
</html>
