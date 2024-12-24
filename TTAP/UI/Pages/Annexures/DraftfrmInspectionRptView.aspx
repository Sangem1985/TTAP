<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DraftfrmInspectionRptView.aspx.cs" Inherits="TTAP.UI.Pages.Annexures.DraftfrmInspectionRptView" %>

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
            max-width: 1140px !important;
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        .box {
            border: 1px solid #212529;
            height: 1418px;
            box-sizing: border-box;
        }

        .newpage {
            page-break-before: always
        }
    </style>
    <%-- <script type="text/javascript">
        $(function () {
            $('#datetimepicker').datetimepicker();
        });
        </script>--%>
    <script type="text/javascript">

        function myFunction() {

            //document.getElementById("Div2").style.visibility = "hidden";
            document.getElementById("DivPrint").style.display = "none";
            //$("#Button2").hide();
            debugger;
            window.print();
            // $("#Button2").show();
            document.getElementById("DivPrint").style.display = "block";
        }
    </script>
</head>

<body>

    <form id="form1" runat="server">
        <%-- <div class="main">--%>
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
                <div class="w-100 px-3 frm-form py-3 font-medium title5" runat="server" id="divheader">
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
                            <div class="widget-content nopadding">
                                <div class="row">
                                    <div class="col-sm-12 table-responsive">
                                        <table class="table table-bordered title6  w-100 NewEnterprise">
                                            <tr class="GridviewScrollC1Item">
                                                <td align="left">Name of The Enterprise</td>
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
                                                <td align="left" class="font-SemiBold">Commencement of Commercial Production </td>
                                                <td align="left">
                                                    <label class="control-label" id="lblDCPdate" runat="server"></label>
                                                </td>
                                                <td align="left" class="font-SemiBold">Category of Unit as per T-TAP Policy </td>
                                                <td align="left">
                                                    <label class="control-label" runat="server" id="lblCategoryofUnit"></label>
                                                </td>
                                            </tr>
                                            <tr class="GridviewScrollC1Item2">
                                                <td align="left" class="font-SemiBold">Type of Unit</td>
                                                <td align="left">
                                                    <label class="control-label" id="lblTypeofApplicant" runat="server"></label>
                                                </td>
                                                <td align="left" class="font-SemiBold">Type of Textile</td>
                                                <td align="left">
                                                    <label class="control-label" id="TypeofTexttile" runat="server"></label>
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
                                            <tr style="height: 40px">
                                                <td align="left" colspan="4" class="font-SemiBold"></td>
                                            </tr>
                                            <tr class="GridviewScrollC1Item2">
                                                <td align="left" class="font-SemiBold">Date of Receipt of Claim Application</td>
                                                <td align="left" colspan="3">
                                                    <label class="control-label" id="lblReceiptDate" runat="server"></label>
                                                </td>

                                            </tr>
                                            <tr style="height: 40px">
                                                <td align="left" colspan="4" class="font-SemiBold"></td>
                                            </tr>
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
                                                <%-- <td align="left" class="font-SemiBold">Amount of Subsidy Recommended(System Calculated)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="SubsidySystemRecommended" runat="server"></label>
                                                    </td>--%>
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
                                            <tr>
                                                <td align="left" colspan="4" class="font-SemiBold">Documents Enclosed by the Applicant</td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="4">
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                        <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                                            CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
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
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
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
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
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
                                        <div>
                                            <table class="table title6  w-100 NewEnterprise">
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        <h5 style="text-align: center"><b>CHECK LIST FOR T-TAP INCENTIVES  </b></h5>
                                                    </td>
                                                </tr>

                                            </table>
                                            <div id="DivIncentiveID_1" runat="server" visible="false">
                                                <table width="100%">
                                                    <tr>
                                                        <td align="left" colspan="4">
                                                            <h6><b><u>ASSESSMENT OF FIXED CAPITAL INVESTMENTOR ELIGIBLE INVESTMENT:
                                                            </u></b></h6>
                                                            <span>(a)	<b><u>NEW UNITS :</u></b>
                                                                <br />
                                                                <ul>
                                                                    <li><b>Fixed Capital Investment or Eligible Investment shall include : </b></li>

                                                                    <ol>
                                                                        <li><b><i>Investment in land, Building, Plant& Machinery, Laboratory equipment, R&D facility, Testing labs and machinery.</i></b>
                                                                        </li>
                                                                    </ol>
                                                                    <br />
                                                                    <li>The computation of Eligible Investment shall be location specific and shall consider <b>only those investments which are made by the enterprise at the location</b> where it is setting up a new unit. 
                                                                    
                                                                    </li>
                                                                    <br />
                                                                    <li>The detailed list of items considered as Fixed Capital Investment or Eligible Investment as indicated in Section 10.
                                                                    </li>
                                                                </ul>
                                                                (b)	<b><u>EXISTING UNITS:</u> </b>

                                                                <ul>
                                                                    <li><b>Gross Fixed Capital Investment</b> means investment in
                                                                     <ol>
                                                                         <li><i><b>Land, Building, Civil Works, Plant and Machinery</b> (as defined in Section 10) </i>
                                                                         </li>
                                                                     </ol>
                                                                        before a unit commences Expansion/ Diversification/Modernization and or obtains sanction of financial assistance 
                                                                        from Banks/Financial institutions.

                                                                    </li>
                                                                </ul>
                                                                <b>Note</b>: <i>The Gross Fixed Capital Investment shall be taken into consideration <i><b><u>for evaluating the category</u></b></i> of an Industry/ Enterprise Units</i>.
                                                            </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="1">
                                                    <tbody>
                                                        <tr>
                                                            <td width="102">
                                                                <p><strong>Para No. of Guidelines</strong></p>
                                                            </td>
                                                            <td width="267">
                                                                <p><strong>Item</strong></p>
                                                            </td>
                                                            <td width="520">
                                                                <p><strong>Eligible items </strong></p>
                                                            </td>
                                                            <td colspan="2" width="486">
                                                                <p><strong>Ineligible Items</strong></p>
                                                            </td>
                                                            <td width="124">
                                                                <p><strong>Remarks</strong></p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="102" style="vertical-align: top;">

                                                                <p><strong>10.1</strong></p>
                                                            </td>
                                                            <td width="267" style="vertical-align: top;">

                                                                <p><strong>LAND</strong></p>
                                                            </td>
                                                            <td width="520" style="vertical-align: top;">
                                                                <p>Cost of land purchased from private or TSIIC undeveloped land (Govt. rate) computed to (5) times of the plinth area of factory building constructed and not exceeding the Approved Project Cost.</p>
                                                                <p>&nbsp;(Sale deed should be registered in the name of Enterprise/ Industry/&nbsp; Proprietor).</p>
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td colspan="2" width="486">
                                                                <p>(i)&nbsp;&nbsp;&nbsp; Cost of site leveling, clearance, laying of roads, etc.</p>
                                                                <p>(ii)&nbsp; Leased land</p>
                                                                <p>(iii)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; lands purchased in IEs/IDA/Industrial Parks (this will be considered for assessment of Category only)</p>
                                                                <p>(iv) Lands inherited</p>
                                                                <p>(v)&nbsp;&nbsp; Stamp duty and Transfer duty (this be considered for assessment of Category only)</p>
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td width="124">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="102" style="vertical-align: top;">

                                                                <p><strong>10.2</strong></p>
                                                            </td>
                                                            <td width="267" style="vertical-align: top;">
                                                                <p><strong>Building</strong><strong> Eligibility elements:</strong></p>

                                                            </td>
                                                            <td width="520">
                                                                <p>&nbsp;&nbsp; &middot; The value of Factory Building constructions will be limited to theApproved Project Cost</p>

                                                                <p>&nbsp;&nbsp; &middot;&nbsp;&nbsp; Cost of buildings will be computed as per the TSFC approved rates of construction / year of construction (OR) the actual cost, whichever is lower.</p>

                                                                <p>&middot;&nbsp;&nbsp; The items of civil works which are permitted for <strong>computation of costs are:</strong></p>
                                                            </td>
                                                            <td colspan="2" width="486" style="vertical-align: top;">
                                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Building taken on lease are ineligible for computation of Fixed Capital investment.</p>
                                                            </td>
                                                            <td width="124">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="6" width="1499">

                                                                <table width="70%" border="1" align="center">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p><strong>(i)</strong></p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><strong>Main FactoryShed.</strong></p>
                                                                            </td>
                                                                            <td rowspan="7" width="295">
                                                                                <p>&nbsp;</p>
                                                                                <p>Plinth Area of <strong>Civil Works*</strong> of Item No. (i) to (vii) will be considered based on the construction made by the Industry/ Unit, as Building eligibility.</p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p><strong>(ii)</strong></p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><strong>Warehouse for Raw Material and finished goods</strong></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p><strong>(iii)</strong></p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><strong>Office room and Labroom.</strong></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p><strong>(iv)</strong></p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><strong>Cooling waterponds.</strong></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p><strong>(v)</strong></p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><strong>Boiler shed and generatorroom.</strong></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p><strong>(vi)</strong></p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><strong>Effluent treatment ponds,etc.</strong></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p><strong>(vii)</strong></p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><strong>Overhead Tank, borewells, &amp; pump house &amp;sump.</strong></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(viii)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>Fencing andGate</em></p>
                                                                            </td>
                                                                            <td rowspan="10" width="295">
                                                                                <p>&nbsp;</p>
                                                                                <p>&nbsp;</p>
                                                                                <p>&nbsp;</p>
                                                                                <p><em>The cost of civil works of Item No. (viii) to (xvii) shall not exceed 10% of the <strong>total value of civil works*. </strong></em></p>
                                                                                <p>&nbsp;</p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(ix)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>Architect fee and supervisioncharges.</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(x)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>Compoundwall.</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(xi)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>Workers quarters/workers housing</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(xii)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>Canteen.</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(xiii)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>RestHouse.</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(xiv)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>TimeOffice.</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(xv)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>Cycle / VehicleStand.</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(xvi)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>Security Shedand</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p>(xvii)</p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><em>Toilet room and sanitaryfittings.</em></p>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="76">
                                                                                <p><strong>(xviii)</strong></p>
                                                                            </td>
                                                                            <td width="573">
                                                                                <p><strong>Roads within factory premises.</strong></p>
                                                                            </td>
                                                                            <td width="295">
                                                                                <p>&nbsp;</p>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <p>&nbsp;</p>

                                                                <p style="text-align: center;"><strong>*Note: Total value of the civil works means items (i) to (ix) only (within the approved project cost).</strong></p>

                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td width="102">
                                                                <p><strong>Para No. of Guidelines</strong></p>
                                                            </td>
                                                            <td width="267">
                                                                <p><strong>Item</strong></p>
                                                            </td>
                                                            <td width="520">
                                                                <p><strong>Eligible items </strong></p>
                                                            </td>
                                                            <td colspan="2" width="486">
                                                                <p><strong>Ineligible Items</strong></p>
                                                            </td>
                                                            <td width="124">
                                                                <p><strong>Remarks</strong></p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="102" style="vertical-align: top;">

                                                                <p><strong>10.3</strong></p>
                                                            </td>
                                                            <td width="267" style="vertical-align: top;">
                                                                <p><strong>Plant &amp; Machinery</strong></p>
                                                            </td>
                                                            <td width="520">
                                                                <p>The value of Plant and Machinery shall be <strong><u>limited to the Approved Project Cost</u></strong>.</p>
                                                                <p>&nbsp;</p>
                                                                <p>The items of Plant and Machinery considered for Eligible Investment shall include:</p>
                                                                <p>(i)&nbsp; P&amp;M for manufacturing</p>
                                                                <p>(ii) P&amp;M for Climate Control</p>
                                                                <p>(iii)&nbsp;&nbsp;&nbsp; P&amp;M for Effluent Management</p>
                                                                <p>(iv)&nbsp;&nbsp;&nbsp; P&amp;M for Electrical system including Panel, Transformers, Cables, Central Temperature control machines, etc.</p>
                                                                <p>&nbsp;</p>
                                                                <p>(v) Plant and Machinery for captive power generation/ cogeneration, renewable power system including solar and wind energy, biogas, etc, limited to a maximum installed capacity as per solar policy of Telangana and as modified by Telangana Energy Dept., from time to time<strong>. </strong></p>
                                                                <p><strong>&nbsp;</strong></p>
                                                                <p><strong>[However, if the cost of this is included in the eligible fixed&nbsp; capital investment then the unit will be eligible for availing the power cost reimbursement subsidy only for the power purchased from the State Distribution Companies (DISCOMs)]</strong></p>
                                                                <p>&nbsp;</p>
                                                                <p>vi) Utilities for Fuel, Water supply, Fresh water and waste water management, etc.</p>
                                                                <p>vii) Boilers, Fuel Handling system, Waste Handling system, etc.</p>
                                                                <p>viii) Material handling equipment.</p>
                                                                <p>ix) Mechanized warehouse including warehouse of storage of raw-materials and finished goods</p>
                                                                <p>x) Vehicles used for transportation only within the premises of the industrial unit, and material handling equipment exclusively used in transporting goods within such premises;</p>
                                                                <p>xi) Plant for purification of water;</p>
                                                                <p>xii) Plant for pollution control measures, including facility for collection, treatment, disposal of effluent or solid/hazardous waste;</p>
                                                                <p>xiii) Diesel Generating sets of capacity not more than 50% of the connected electric load;</p>
                                                                <p>xiv) Any Other Plant and Machinery approved by DLO/IEC.</p>
                                                                <p><strong>(a)&nbsp;&nbsp; </strong><strong>If new industry setup in the premises belonging to the disposed Enterprises</strong> from any Financial Institution / disposed enterprises/industries, if the earlier Enterprises availed incentives, <strong><u>only new assets created with fresh investment would be eligible for incentives irrespective of the earlier enterprise has availed incentives or not.</u></strong></p>
                                                                <p><strong><u>Note: </u></strong><strong>Undertaking to be furnished &ndash; Whether the Disposed Unit have availed the incentives or not for consideration of P&amp;M cost. (To be included in T-TAP Application Part-A)</strong></p>
                                                                <p>(b)&nbsp;&nbsp; <strong>Value of self-fabricated machinery</strong> by the new industrial Enterprise/Industry will have <strong>to be certified by a Chartered Engineer or Engineer of the term lending institution</strong> concerned for the purpose of computing the eligible fixed capital investment.</p>
                                                                <p>(c)&nbsp;&nbsp;&nbsp; <strong>Cost of plant and machinery would also include amount paid</strong>, if any towards design, patents, and services towards charges in relation to such machinery including installation. Amount spent towards insurance premium and tax for procurement of such assets will also be taken into account. In case of <strong>importedmachinery, import duty, shipping, charges, custom clearance charges, GST/ statutory taxes paid </strong>thereon will also be taken into consideration.</p>
                                                                <p>(d)&nbsp;&nbsp; The <strong>cost involved in installation &amp; erection of plant &amp; machinery and utilities</strong> etc. will be taken into account for assessment.</p>
                                                                <p>&nbsp;</p>
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td colspan="2" width="486" style="vertical-align: top;">

                                                                <p>(a)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Working capital, raw material, stores and all consumables including spare tools, etc.</p>
                                                                <p>(b)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Value of the Motor Vehicles outside the premises of the manufacturing facility.</p>
                                                                <p>(c)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Pre-operative expenses, advances, expenditure not supported by payment proof of bills wherever necessary.</p>
                                                                <p><strong>(d)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><strong>New Industrial Enterprise/industry established with Plant and Machinery on lease is not eligible for incentives/concessions.</strong></p>
                                                                <p>(e)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; New Industrial Enterprise/industry established with second hand machinery is not eligible for incentives/concessions except where the cost of such machinery does not exceed 25% of the total cost of plant and machinery.</p>
                                                                <p>(f)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Investment made outside the approved project cost and items not covered by approved project.</p>
                                                                <p>(g)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Expenditure on technical consultancy / feasibility study / EIA etc.</p>
                                                                <p>(h)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; In case of self-financed Enterprise/industry, the fixed assets created after the date of commencement of Commercial Production and also payment made after date of commencement of Commercial Production are not considered.</p>
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td width="124">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="102">
                                                                <p><strong>&nbsp;</strong></p>
                                                            </td>
                                                            <td width="267">
                                                                <p><strong>Laboratory Equipment</strong></p>
                                                            </td>
                                                            <td width="520">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td colspan="2" width="486">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td width="124">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="102">
                                                                <p><strong>&nbsp;</strong></p>
                                                            </td>
                                                            <td width="267">
                                                                <p><strong>R&amp;D FacilitTeb </strong></p>
                                                            </td>
                                                            <td width="520">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td colspan="2" width="486">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td width="124">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="102">
                                                                <p><strong>&nbsp;</strong></p>
                                                            </td>
                                                            <td width="267">
                                                                <p><strong>testing labs &amp; Machinery </strong></p>
                                                            </td>
                                                            <td width="520">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td colspan="2" width="486">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                            <td width="124">
                                                                <p>&nbsp;</p>
                                                            </td>
                                                        </tr>
                                                </table>
                                            </div>
                                            <div id="DivIncentiveID_19" runat="server" visible="false">
                                                <h5><b>Reimbursement of Capital Subsidy (ONE TIME CLAIM) FORM-II</b></h5>
                                                <h6><b><u>Eligible items :-</u></b></h6>
                                                <p>(a)&nbsp; The Unit shall be eligible for Capital subsidy as per the category mentioned in the following table showing the &ldquo;Extent of Financial Assistance under Capital Subsidy Policy Provisions<strong>&rdquo; after</strong><strong> Date of Commencement of Commercial Production.</strong></p>
                                                <p><u><b>Extent of Financial Assistance under Capital Subsidy</b> </u></p>
                                                <table width="90%" border="1" align="center">
                                                    <thead align="center">
                                                        <tr>
                                                            <td width="71">
                                                                <p>Category of Unit</p>
                                                            </td>
                                                            <td width="225">
                                                                <p>Capital Subsidy for <strong>Convectional Textiles</strong></p>
                                                            </td>
                                                            <td width="226">
                                                                <p>Capital Subsidy for <strong>Technical Textiles</strong></p>
                                                            </td>
                                                        </tr>
                                                    </thead>
                                                    <tbody align="center">
                                                        <tr>
                                                            <td width="71">
                                                                <p>A1</p>
                                                            </td>
                                                            <td width="225">
                                                                <p>25% of eligible project cost with a CAP of Rs 1 Cr</p>
                                                            </td>
                                                            <td width="226">
                                                                <p>35% of eligible project cost with a C of Rs 2 Cr</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="71">
                                                                <p>A2</p>
                                                            </td>
                                                            <td width="225">
                                                                <p>25% of eligible project cost with a CAP of Rs 3 Cr</p>
                                                            </td>
                                                            <td width="226">
                                                                <p>35% of eligible project cost with a CAP ofRs 5 Cr</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="71">
                                                                <p>A3</p>
                                                            </td>
                                                            <td width="225">
                                                                <p>25% of eligible project cost with a CAP of Rs 5 Cr</p>
                                                            </td>
                                                            <td width="226">
                                                                <p>35% of eligible project cost with a CAP ofRs10 Cr</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="71">
                                                                <p>A4</p>
                                                            </td>
                                                            <td width="225">
                                                                <p>25% of eligible project cost with a CAP of Rs 10 Cr</p>
                                                            </td>
                                                            <td width="226">
                                                                <p>35% of eligible project cost with a CAP of Rs 20 Cr</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="71">
                                                                <p>A5</p>
                                                            </td>
                                                            <td width="225">
                                                                <p>25% of eligible project cost with a CAP of Rs 20 Cr</p>
                                                            </td>
                                                            <td width="226">
                                                                <p>35% of eligible project cost with a CAP of Rs 40 Cr</p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <p>(d) <strong>Additional 5% capital subsidy</strong> subject to the above caps (also increased by 5 %) to the SC / ST /Women entrepreneurs and persons with disability (PWD)</p>
                                                <p>(e) For <strong>Existing Industry</strong>/Enterprises - P<strong>rocurement of plant and machinery for modernisation, adoption of advanced technologies in Textile processing and Spinning, expansion of capacities or diversification</strong><strong>is eligible.</strong></p>
                                                <p>(f) <strong>Capital subsidy of 20% of the cost of P&amp;M subject to ceiling of Rs.5 Crore is eligible to the existing enterprises who undertakes expansion/diversification and modernization.</strong></p>

                                                <p><strong><u>DEFINITIONS:</u></strong></p>
                                                <p><strong>4.1&nbsp; </strong><strong><u>New Industry/Enterprises:</u></strong></p>

                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; New Industrial Enterprise/Industry which have been established in the State <strong><u>with new Machinery/equipment and commenced commercial production after 18/08/2017 and before 17/08/2022</u></strong> .</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Obtained Udyog Aadhaar Memorandum (UAM) /Industrial Entrepreneur&rsquo;s Memorandum (IEM) / (IL) from Government of India (GoI).</p>

                                                <p><strong>4.2&nbsp; </strong><strong><u>Existing Industry/Enterprises:</u></strong></p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Existing Industry/ that have <strong><u>filed Udyog Aadhar Registration (UAR)</u></strong> / Industrial Entrepreneur&rsquo;s Memorandum (IEM) <strong><u>with the concerned District Industries Centre (DIC)</u></strong> or Industrial Entrepreneur&rsquo;s Memorandum with the Government of India and</p>

                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; <strong><u>commenced commercial production or operation before the announcement of the T-TAP policy i.e on 18/08/2017.</u></strong></p>

                                                <p><strong>4.3&nbsp; </strong><strong><u>Expansion:</u></strong></p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Expansion of Existing Industry/Enterprises with or without forward and backward integration, with investment more than 25% of its existing Fixed Capital Investment and</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; enhancement of the existing installed capacity by at least 25% <strong><u>in</u></strong> the same production lines as on the date of initiating expansion and commencing production during the operative period of the scheme shall be treated as expansion.</p>

                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; The units which have commenced the commercial production on or after 01.04.2017 will be eligible for incentives under T-TAP subject to condition that their plant and machinery shall have landed at site on 01.01.2017 will be considered for incentives.</p>

                                                <p><strong>4.4&nbsp; </strong><strong><u>Diversification:</u></strong></p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Existing Industry/Enterprises in eligible areas, making investment in a new product other than those listed in the ineligible list,</p>

                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Iinvolving Diversification with an enhancement of at least by 25% of the existing Gross Fixed Capital Investment as well as</p>

                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Enhancement of turnover by 25% in value terms as on the date of initiating diversification and commencing production during the operative period of the scheme.</p>

                                                <p><strong>4.5&nbsp; </strong><strong><u>Modernization:</u></strong></p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Existing Industry/Enterprises undergoing modernization, in case they have plant &amp; machineries of certain specifications and they have brought in plant &amp; machineries of an upgraded version or acquired new technologies for capacity augmentation within the Industry/Enterprises.</p>
                                            </div>
                                            <div id="DivIncentiveID_2" runat="server" visible="false">
                                                <h5><b>Reimbursement on creation of Energy Water &amp; Environmental conservation infrastructure<br />
                                                    (FORM-III) One time</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible industrial Enterprises shall submit their claims in the prescribed online application <strong>Form-III </strong>for subsidy on specific cleaner production measures within six months from the date of commencement of commercial production along with required documents mentioned in Application,</p>
                                                <p>(b)&nbsp; Capital subsidy for creation of energy, water and environmental conservation infrastructure is available at both individual unit level and cluster level .Both new and existing enterprises are eligible for claiming subsidy.</p>
                                                <p>(c)&nbsp; An industry/Enterprise has to submit sufficient document of proof in order to justify the claim for subsidy/incentives under the category of creation of Energy, Water and Environmental Infrastructure. The final decision shall be taken by the SLC.</p>

                                                <p>(d)&nbsp; <strong>On Cost of Equipment</strong> &ndash; Assistance available <strong>upto 40% of the cost of equipments with a ceiling of Rs 50 lakhs</strong> which shall be applicable for energy, water and environmental conservation infrastructure separately under each category of energy, water and environment .</p>
                                                <p>(e)&nbsp; <strong>On Common Effluent Treatment Plants (CETPs) / Effluent Treatment Plants (ETPs)</strong> &ndash; Assistance in form of credit linked back end subsidy to both cluster and individual unit <strong>up to 50% of project cost or Rs 10 crores whichever is less</strong>.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; In case of handloom clusters, assistance <strong>to a maximum of 70% subject to a ceiling of Rs 2 crores</strong>. Assistance is available only once during the policy period .&nbsp;</p>
                                                <p>(f)Disbursement of sanctioned amount, in two equal installments</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i)&nbsp; First instalment after creation of the infrastructure and commencement of operation of the industrial enterprise i.e. Date of Commercial production (DCP).</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii)&nbsp; Second instalment after completion of one year of continuous operation (from the date of claim of incentive) of ETP/CETP or infrastructure equipments proposed for incentives.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iii)&nbsp; The Industry/Enterprise shall obtain and furnish certificates from the concerned authorities/department such as (TSPCB/ TNREDCL etc) on the cost of the equipment involved and the relevance of the equipment purchased.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_3" runat="server" visible="false">
                                                <h5><b>Interest Subsidy Form IV 8 Years &ndash; half yearly basis</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; The new enterprises &amp; industries availing term loan from Scheduled Commercial Banks / Financial Institutions recognized by Reserve Bank of India, Telangana State&nbsp; Financial Corporation (TSFC) and Small Industrial Development Bank of India (SIDBI) <strong>only are eligible under this scheme.</strong></p>
                                                <p>(b)&nbsp; All eligible units shall submit <strong>Form-IV</strong> online application within 6 months after completion of every&nbsp; Half-year i.e., last date for filing claim application is <strong>31st of March</strong> for first half year and <strong>30th of September </strong>for second half year.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; Considering the fact that the banks or Financial Institutions would have sanctioned the loan to the units after conducting appropriate due diligence like verifying the legal documents and examining the proposals in detail with reference to location of industry, sanction of electric power, approval of building plan, approval of factories and boilers &amp; other statutory requirements only .</p>
                                                <p>(c)&nbsp; Reimbursement of Interest Subsidy shall be provided to units in addition to the TUF Scheme (Technology Up gradation Fund Scheme of Ministry of Textile, Government of India) or any other Interest reimbursement scheme of Government of India.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; The total Interest Subsidy including under TUF <strong><u>Scheme should not exceed the rate of interest levied by Financial Institutions</u></strong> on the sanctioned and disbursed term loan to the unit.</p>
                                                <p>(d)&nbsp; The Interest amount paid by the new eligible enterprises &amp; industries as well as existing eligible enterprises &amp; industries pertaining to expansion/ diversification to the Financial Institutions/Banks on the term loan availed <strong><u>will be reimbursed with a maximum limit of 75% of the interest rate applicable on the loans</u></strong> <strong><u>availed by the unit, subject to a cap of 8% per annum</u></strong> for all eligible activities as defined under Clause 5.</p>
                                                <p>(e)&nbsp; The assistance shall be <strong><u>provided for a period of 8 years</u></strong> (including construction / moratorium period of 2 year) <strong><u>or the period of repayment of the loan whichever is earlier.</u></strong></p>
                                                <p>(f)The reimbursement of interest for the moratorium period or regular loan period will be extended only after the commencement of commercial production. The interest subsidy for the moratorium period shall be claimed by the enterprise within six months from the date of commercial production. Further, the claims from the DCP onwards for the eligible period shall be filed half yearly basis. <strong>Thi</strong><strong>s reimbursement to the Industry shall not include penal interest, liquidated damages etc. paid to the Financial Institutions / Banks.</strong></p>
                                                <p>(g)&nbsp; The total Interest Subsidy including any similar benefit availed under any other scheme of Central / State Government <strong><u>should not exceed the rate of interest </u></strong>levied by Financial Institutions on the sanctioned and disbursed term loan to the unit.</p>
                                                <p>(h)&nbsp; The Interest Subsidy will be <strong><u>payable every half year subject to submission of a statement / certificate (in annexure-A)</u></strong> by the lending Bank /Financial Institution to substantiate <strong><u>that the unit has paid the due interest to the institutions on the due dates and has not defaulted in payment of interest at any time during the period.</u></strong></p>
                                                <p>(i)&nbsp; The <strong><u>sanctioned term loan disbursed within six months from the date of commencement of commercial production</u></strong> has to be part and parcel of original Term Loan sanctioned.</p>
                                                <p>(j)&nbsp; The <strong><u>benefit shall be extended only to the eligible industries which are regularly repaying the Loan instalments of principal &amp; interest</u></strong>.</p>
                                                <p>(k)&nbsp; The <strong><u>loan accounts that are classified as overdue in the books of the bank at the time of half- yearly closing and that which are classified as Non-performing Assets at year-end closing are ineligible</u></strong>. However, if they resume on-time repayments and regularize the arrears, they are eligible for the incentive in the next half-yearly period. For this purpose the banker has to certify that the repayment is regular and the Account is standard and the same certificate is to be enclosed along with claim application.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_4" runat="server" visible="false">
                                                <h5><b>Reimbursement of Power Consumption charges Form &ndash;V 5 years period &ndash; half yearly basis</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; The Reimbursement of power cost under T-TAP shall be applicable to all eligible (a) new industrial Enterprises and (b) Expansion/Diversification/Modernization Projects, <u>subject to fulfilment of the conditions stipulated at Para No. 4.5(Expansion), 4.6(Diversification) &amp; 4.7(Modernization).</u></p>
                                                <p>(b)&nbsp; The benefits/concessions of the Policy will be applicable to the eligible units which have <u>gone into commercial production during the operational period of the Policy</u>.</p>
                                                <p>(c)&nbsp; The power subsidy shall be applicable to the industrial units, which are <strong><u>utilizing power from DISCOM only</u></strong> and <strong><u>power connection should be in the name of the Enterprise / Unit.</u></strong></p>
                                                <p>(d)&nbsp; This subsidy is <strong><u>only on the energy consumption (energy charge) ( KVAH) charges but not on Maximum Demand or any other charges (service connection, miscellaneous charges etc)</u></strong> levied by DISCOMs. <u>Residential &amp; Colony power consumption are not eligible for Reimbursement of Power Cost</u>.</p>
                                                <p>(e)&nbsp; In case of existing units undergoing expansion / diversification / modernisation, the <u>Power Subsidy shall be allowed on power consumption made over and above the base annual power consumption of the original unit</u> <u>i.e. before expansion / diversification / modernisation</u>. The base annual power consumption is the average power consumption in the previous three financial years of the Expansion/Diversification/Modernization project as <u>certified by Chartered Accountant or power consumption</u>. Power consumed over and above the base consumption will be eligible for reimbursement of power cost. If the Enterprise/Industry taken up expansion/diversification/modernization in the same year, the base power consumption will be calculated proportionately.</p>
                                                <p>(f)&nbsp; In case of actual power consumed during the year is less than annual base consumption, reimbursement made during any previous period will be adjusted in future reimbursement. If excess is paid and could not be adjusted in future claims, will be recovered under Revenue Recovery Act.</p>
                                                <p>(g)&nbsp; All eligible industrial Enterprises / industries shall submit their claims in the prescribed online Application <strong>Form&ndash;V </strong>for reimbursement of Power cost along with documents mentioned in the Application within six months after completion of every Half-year i.e., last date for filing claim application is 31st of March for first half year and 30th of September for second half year along with all documents mentioned in the Application Online on a half &ndash;yearly basis.</p>
                                                <p>(h)&nbsp; <strong>Ginning and Pressing Mills &ndash; </strong>The Power Tariff Subsidy is provided at Re 1 per unit for a period of 5 years from the date of commencement of commercial production.</p>
                                                <p>(i)&nbsp; <strong>For all units engaged in other e</strong><strong>ligible activities as per clause 5 excluding Ginning and Pressing Mills</strong>. <strong>&nbsp;&ndash;</strong> Power Tariff Subsidy is provided as per following scheme for a period of 5 years from the date of commencement of commercial production.</p>
                                                <p>&nbsp;</p>

                                                <p style="text-align: center; font-weight: bold;"><u>Power Tariff Subsidy (Conventional Textiles)</u></p>
                                                <table width="30%" border="1" align="center">
                                                    <tbody align="center">
                                                        <tr>
                                                            <td width="99">
                                                                <p><strong>Category</strong></p>
                                                            </td>
                                                            <td width="270">
                                                                <p style="text-align: center;">
                                                                    <strong>Power Tariff Subsidy<br />
                                                                        (Rs per Unit)</strong>
                                                                </p>
                                                                <p><strong></strong></p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="99">
                                                                <p>A1, A2</p>
                                                            </td>
                                                            <td width="270">
                                                                <p>1.00</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="99">
                                                                <p>A3</p>
                                                            </td>
                                                            <td width="270">
                                                                <p>1.50</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="99">
                                                                <p>A4</p>
                                                            </td>
                                                            <td width="270">
                                                                <p>1.75</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="99">
                                                                <p>A5</p>
                                                            </td>
                                                            <td width="270">
                                                                <p>2.00</p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <p>&nbsp;</p>
                                                <p>(j)&nbsp; <strong>Technical Textiles &ndash; </strong>An extra Power Tariff Subsidy benefit of Rs 0.50 per unit across all above categories for Technical Textile Units.</p>
                                                <p style="text-align: center; font-weight: bold;"><u>Power Tariff Subsidy for Technical Textiles</u></p>
                                                <table width="30%" border="1" align="center">
                                                    <thead align="center">
                                                        <tr>
                                                            <td width="98">
                                                                <p><strong>Category</strong></p>
                                                            </td>
                                                            <td width="296">
                                                                <p><strong>Power Tariff Subsidy for Technical Textiles (Rs per Unit)</strong></p>
                                                            </td>
                                                        </tr>
                                                    </thead>
                                                    <tbody align="center">
                                                        <tr>
                                                            <td width="98">
                                                                <p>A1, A2</p>
                                                            </td>
                                                            <td width="296">
                                                                <p>1.50</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="98">
                                                                <p>A3</p>
                                                            </td>
                                                            <td width="296">
                                                                <p>2.00</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="98">
                                                                <p>A4</p>
                                                            </td>
                                                            <td width="296">
                                                                <p>2.25</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="98">
                                                                <p>A5</p>
                                                            </td>
                                                            <td width="296">
                                                                <p>2.50</p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <p>&nbsp;</p>
                                                <p>(k)&nbsp; <strong>Complete Value Chain &ndash; </strong>An extra Power Tariff Subsidy benefit of 5% in addition to all above categories</p>
                                                <p>(l)&nbsp; <strong>Fibre to Fabric incentive:- </strong>Any entity that establishes a production chain that starts with production of textile fibre to fabric i.e from ginning, pressing Spinning , weaving , processing, garmenting/made ups as an integrated family <u>will be eligible for an additional 5% subsidy on capital investment and power tariff than what is provided in the above table.</u></p>
                                            </div>
                                            <div id="DivIncentiveID_5" runat="server" visible="false">
                                                <h5><b>Reimbursement of stamp duty, Transfer duty, Mortgage &amp; Hypothication Duty<br />
                                                    [Form-VI] [One Time &ndash; after availing capital subsidy ]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible industrial Enterprises shall submit their claims in the prescribed online application form given at <strong>Form-VI</strong> within six months from the date of commencement of commercial production, to the District Level Office concerned through&nbsp; Online application.</p>
                                                <p>(b)&nbsp; <strong><u>100% reimbursement of Stamp duty and transfer duty paid by the industry on purchase of land</u></strong>/shed/building meant for industrial use.</p>
                                                <p>(c)&nbsp; <strong><u>100% reimbursement of Stamp duty for Lease of Land/Shed/ Buildings and also mortgages and hypothecations deeds</u></strong>.</p>
                                                <p>(m) The Stamp duty, Transfer duty, mortgages and hypothecations benefits shall be applicable to all eligible (a) new industrial Enterprises and (b) Expansion/Diversification/Modernization projects, subject to fulfilment of the conditions stipulated at Para No. <u>4.5(Expansion), 4.6(Diversification) &amp; 4.7(Modernization).</u></p>
                                                <p>(d)&nbsp; The above <strong><u>incentive shall be admissible to eligible Enterprises on the land area upto five times of the plinth area of the factory building constructed within the approved project cost</u></strong>.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&middot; However, in respect of industries where the open land requirements would be larger due to the specific nature of industry, Sate Level Approval Committee (SLC) may consider allowing land in excess of five times plinth area on case to case basis.</p>
                                                <p>(e)&nbsp; <u>Mortgages and hypothecations duty paid</u> by an enterprise for availing Term loan from the financial institutions on assessed fixed capital investment <u>would only be eligible</u>.</p>
                                                <p>(f)&nbsp; <u>If </u>any industrial enterprise had <u>already availed stamp duty or transfer duty concession on land </u>under G.O.Ms.No.59, Industries &amp; Commerce (IP) Department, dated: 18.8.2017, <u>the concession would be reduced proportionately.</u></p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_6" runat="server" visible="false">
                                                <h5><b>Reimbursement of Tax [Form-VII] [7 Years &ndash; half yearly basis]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible Enterprises shall submit their claims in the prescribed online application <strong>Form-VII</strong> for Reimbursement of <strong><u>net State Goods and Services Tax (SGST) within six months</u></strong> <strong><u>after completion of every half-year</u></strong> i.e., last date for filing claim application is 31st of March for first half year and 30th of September for second half year along with the documents mentioned in the Application to the DLO through Online portal.</p>
                                                <p>(b)&nbsp; <strong><u>100% Reimbursement of net SGST will be granted for SGST collected on end product / intermediate product within the entire value chain, and paid to the state government by way of cash or through utilization of SGST / IGST credits, for a period of 7 years from the date of commencement of commercial production, or up to realization of 100% eligible Gross Fixed Capital Investment, whichever is earlier.</u></strong></p>
                                                <p>(c)&nbsp; Reimbursement on net State Goods and Services Tax (SGST) will be <u>allowed in case of Expansion/ Diversification/ Modernization Projects over and above base annual production capacity or base turn over.</u> For the purpose of reimbursement, annual production or turn over will be taken into account. The reimbursement will be made every six months, but in case of actual production or turn over during the year is less than annual base annual production capacity or base turn over, reimbursement made during any previous period will be adjusted in future reimbursement. If excess is paid and could not be adjusted in future claims, will be recovered under Revenue Recovery Act, 1864.</p>
                                                <p>(d)&nbsp; The Expansion / Diversification / Modernization Projects will be <strong><u>allowed reimbursement on net State Goods and Services Tax (SGST) paid on production made over and above the base annual production capacity or base turn over as per applicability of the original Enterprise/Industry</u></strong> i.e. before Expansion / Diversification. The base annual production is average annual production of previous three financial years even in case of manufacturing single product (as certified by Financial Institution/ Chartered Accountant). If the Enterprise/Industry taken up expansion/diversification in the same year, the base capacity will be calculated proportionately. In case of multi products, the average annual sales turnover of previous three financial years will be taken as base turnover (as certified by Chartered Accountant).</p>
                                                <p>(e)&nbsp; The enterprise/industry shall obtain the <strong><u>details of the net SGST paid</u></strong> <strong><u>during the every Half-year</u></strong> i.e., last date for filing claim application is 31st of March for first half year and 30th of September for second half year for which the claim is being made <strong><u>duly certified by Commercial Tax authorities in form prescribed at Form-A</u></strong> for original/expansion / Diversification Enterprise/Industry separately as the case may be.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_7" runat="server" visible="false">
                                                <h5><b>Assistance for Energy, Water and Environmental Compliance to Existing Units</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; For Assistance for Energy, Water and Environmental Compliance, the Applicants shall submit <strong>Form-VIII </strong>online along with the documents mentioned in the Application to the District Level Office (DLO) through online .The assistance shall be provided only once during the operative period of the policy on approval of SLAC.</p>
                                                <p>(b)&nbsp; The eligible units shall file Application for claiming Assistance for Energy, Water and Environmental Compliance within one year of completion of successful implementation Energy Audit / Water Audit / Environmental Compliance.</p>
                                                <p>(c)&nbsp; The extent of support available under the Policy for Energy Audit / Water Audit / Environmental Compliances is upto 50%, subject to a maximum amount of Rs 50,000 separately for each category. The assistance shall be available for all existing units that have installed Energy, Water and Environmental Conservation Infrastructure and are into commercial production for a minimum period of 3 years.</p>
                                                <p>(d)&nbsp; Claim for reimbursement may be considered on successful implementation of Energy Audit and Environmental Compliances resulted in reduction in energy expenses &amp; carbon foot print.</p>
                                                <p>(e)&nbsp; Claim for reimbursement of cost of Energy Audit / Water Audit / Environmental Compliances shall not include / cover cost of change over assets like acquisition of energy saving equipment, new installations, remodelling, up gradation of existing, replacement of obsolete machineries etc.</p>
                                                <p>(f)&nbsp;&nbsp; if he unit has availed incentives under any scheme of State Government or the Central Government (Gol) or Government Agencies or any Financial Institutions it shall be eligible for the differential amount of benefit only.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_8" runat="server" visible="false">
                                                <h5><b>Assistance for Acquisition of New Technology [From-IX]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; For Assistance for Acquisition of New Technology, the Applicants shall submit <strong>Form-IX </strong>online along with the documents mentioned in the&nbsp; Application to the District Level Office (DLO) through online portal.</p>
                                                <p>(b)&nbsp; The eligible units shall file Application for claiming Assistance for Acquisition of New Technology within six months from the date of commencement of commercial production with new technology.</p>
                                                <p>(c)&nbsp; T-TAP provides financial assistance upto 50% of the investment in technology development, subject to a maximum of Rs 10 lakh per process / product, only once during the operative period of the Policy.</p>
                                                <p>(d)&nbsp; Eligible unit developing specialized or new technology shall apply for this assistance under the Policy.</p>
                                                <p>(e)&nbsp; Individual enterprise either individually or making collaborative efforts towards technology development through R&amp;D institutions or by engaging experts and consulting firms are eligible for assistance.</p>
                                                <p>(f)&nbsp; Import of technology and then further development for adaptation to local conditions by the unit shall also be considered as &ldquo;Technology development&rdquo; and be eligible for assistance towards procurement of imported technology including the license fee and associated duties.</p>
                                                <p>(g)&nbsp; Import of technology and machinery without any further development on it by the unit shall not be covered under the Policy.</p>
                                                <p>(h)&nbsp; Enterprises availing benefit for the same purpose from any other Scheme of State Government is not eligible to claim Assistance for Acquisition of New Technology under the Policy.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_9" runat="server" visible="false">
                                                <h5><b>Transport Subsidy to Export Intensive Textile Units [Form-x]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible industrial Enterprises /industries shall submit <strong>Form-X</strong> online to claim their Reimbursement of Transportation Subsidy within six months after completion of every Half-year i.e., last date for filing claim application is 31st of March for first half year and 30th of September for second half year along with the documents mentioned in the Application to the DLO concerned for a period of 5 years from the commencement of commercial production.</p>

                                                <p>
                                                    (b)&nbsp; Reimbursement of freight charges towards import of raw materials and export of finished products either by rail / road, 
                                                    from the project location to the port / dry port in the following scale:-
                                                </p>
                                                <p style="text-align: center; font-weight: bold;"><u>Rates for Reimbursement of Transport Subsidy</u></p>
                                                <table width="30%" border="1" align="center">
                                                    <tbody align="center">
                                                        <tr>
                                                            <td width="194">
                                                                <p>Year 1 &amp; Year 2</p>
                                                            </td>
                                                            <td width="79">
                                                                <p>75%</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="194">
                                                                <p>Year 3 &amp; Year 4</p>
                                                            </td>
                                                            <td width="79">
                                                                <p>50%</p>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="194">
                                                                <p>Year 5</p>
                                                            </td>
                                                            <td width="79">
                                                                <p>25%</p>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <p>(c)&nbsp; Further, the Government will provide transport subsidy at above rates for 5 years, for &ldquo;Deemed Exports", i.e. supply of goods from within the state to other textile and apparel units within or outside the state provided the goods supplied are ultimately exported after value addition.</p>

                                                <p>(d)&nbsp; Transport Subsidy under T-TAP 2017-22 is available for all export oriented (where total exports is more than 30% of total revenue of the unit) new units. Existing units undertaking expansion / diversification / modernization will be eligible for transport subsidy provided that minimum 30% of their incremental revenue post expansion / diversification / modernization is derived from exports.</p>

                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i) Average of total Revenue for the last 3 years will be considered as base revenue for the purpose of calculating incremental revenue.</p>
                                                <p>&nbsp;</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;(ii) Average of total freight charges for last 3 years will be considered as base for calculating incremental freight charges</p>

                                                <p><u>Formula: - </u></p>
                                                <p>Average Revenue (last 3 years) = A</p>
                                                <p>Revenue after Expansion / Diversification / Modernization = B</p>
                                                <p>Incremental Revenue = B &ndash;(minus) A</p>

                                                <p>Criteria for transport subsidy &ndash; 30% of (B &ndash; A) must be revenue from exports</p>

                                                <p>Average Freight charges (last 3 years) = X</p>
                                                <p>Total Freight charges after Expansion / Diversification / Modernization = Y</p>
                                                <p>Eligible Freight Charges for subsidy = Y &ndash; X</p>
                                                <p>&nbsp;</p>
                                                <p>If&nbsp; in a given year, the criteria of 30% revenue from exports is not met, the unit will not be eligible for transport subsidy for that year.</p>
                                                <p>(e)&nbsp; The unit must clearly exhibit a direct linkage with the exports. The units should also not duplicate the efforts of any existing organization in the same field.</p>

                                                <p>(f)&nbsp; The transportation subsidy shall be applicable to the industrial enterprises, which are importing/ exporting from/to Indian sea ports / airports only by rail/road either directly or through any dry Port. Transport Subsidy shall be only for the Transportation incurred by the Unit from the Sea Port/Airport to the Unit Location.</p>

                                                <p>(g)&nbsp; The Transport Subsidy shall be available for all units who are involved in direct exports, merchant exports and deemed exports and the units shall exhibit linkages with exports in form of shipping invoices / bills. In case of deemed exports, the unit should supply to EOU / SEZ / against advance license / EPCG license wherein endorsement is available.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_10" runat="server" visible="false">
                                                <h5><b>Design product Development and Diversification [FORM-XI]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; For Design, Product Development and Diversification Assistance, the Applicants shall submit <strong>Form-XI </strong>online along with the documents mentioned in the Application to the DLO concerned within six months from the date of commencement of commercial production through Online Portal.</p>
                                                <p>(b)&nbsp; This assistance is available only for A1 segment of Industry/Enterprise in Textiles and Garment manufacturing for investments made towards design and product development.</p>
                                                <p>(c)&nbsp; The Assistance for Design, Product Development and Diversification is not available for processing units with generic products as output with no scope for design and diversification.</p>
                                                <p>(d)&nbsp; The Policy shall provide eligible A1 units with financial assistance upto 20% of the annual expenditure spent on design and product development limited to Rs 2 lakhs per year.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_11" runat="server" visible="false">
                                                <h5><b>Reimbursement of Land Cost [Form-XII]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; Government of Telangana has created an industrial land bank and earmarked significant portion of land for development of Textiles and Apparel industry proximal to traditional processing regions. Land allotment shall be carried out across three categories.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i) Industrial plots in the Integrated Textile Parks developed by TSIIC &ndash; Plots with common facilities including ETP, infrastructure and R&amp;D facilities etc. These plots can either be purchased or leased in by the industrial units. However, in respect of <strong><u>the units for which the land was allotted at a concessional rate for such units the land rebate shall not be applicable.</u></strong></p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii)  Individual plots on standalone basis that are away from the industrial park developed by TSIIC.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iii) Land for development of Industrial Park / Textile Park / Cluster Projects developed through privately owned or PPP modes of investments will be made available. Land allotment for the purpose shall follow stipulated guidelines issued by TSIIC.</p>
                                                <p>(b)&nbsp; Rebate on Basic Land Cost to Textiles and Apparel Units &ndash; <strong><u>Anchor Client(s) and first movers of every new Textile / Apparel/ Industrial Park Parks shall be eligible for a 50% rebate on land cost ascertained by TSIIC upto Rs 20 lakhs per acre</u></strong>.</p>
                                                <p>In case of <strong><u>Technical Textile units, an additional rebate of 25% with a cap of Rs. 10 lakhs per acre shall be extended</u></strong>. <strong><u>The land extent to be considered will be equivalent to five times of plinth area of the factory building constructed and not exceeding the project cost.</u></strong></p>
                                                <p>(c)&nbsp; All eligible industrial Enterprises shall submit their claims in the prescribed online application <strong>Form-XII</strong> for rebate on land cost within six months of Date of Commercial Production.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i) <strong><u>The benefit is available only if the Applicant purchases land directly from TSIIC. </u></strong></p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii) <strong><u>Rebate on land cost is available only for Anchor</u></strong><u> Unit(s) and <strong>First Movers</strong> of each Textile</u><u> / Apparel / Industrial Park developed by TSIIC.</u></p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&bull; The first tenant industry (minimum 51% stake of the prime mover industry in case of joint venture for infrastructure development) in a designated Textile /Apparel Park who is a reputed investor and would stimulate and facilitate further investment.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_12" runat="server" visible="false">
                                                <h5><b>Rental/Lease subsidy for Built Up Space: [Form-XIII]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>a.&nbsp; Built-up spaces shall be developed in Textiles / Apparel parks by the State Government to support A1 category of Industry/Enterprise segment and a rental subsidy of 25% for the first five years of operation shall be offered under the T-TAP Policy.</p>
                                                <p>b.&nbsp; All new as well as existing A1 category of Industry/Enterprise engaged in eligible activities and are undertaking expansion / diversification / modernization and leasing/renting built up area in textile and Apparel Park shall be eligible to get this assistance.</p>
                                                <p>c.&nbsp; The benefits/concessions of T-TAP will be applicable to the Enterprises/Industries which have gone into registered lease/rental deed on or after August 18, 2017.</p>
                                                <p>d.&nbsp; All eligible industrial Enterprises / industries shall submit their claims in the prescribed online application <strong>Form-XIII</strong> for Reimbursement of rental subsidy&nbsp; within six months after completion&nbsp; of every half-year along with the documents mentioned in the Application to the DLO concerned on a half-yearly basis for a period of five (5) years from the commencement of commercial production.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_13" runat="server" visible="false">
                                                <h5><b>Other Infrastructure Support [Form-IV]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible industrial Enterprises shall submit their claims in the prescribed online application <strong>Form-XIV </strong>for financial assistance within six months from the date of commencement of commercial production along with required documents, to the DLO through Online application.</p>
                                                <p>(b)&nbsp; Support infrastructure like roads, power and water shall be provided at the door step of the industry for standalone units by contributing 50% of the cost of infrastructure with a ceiling of Rs 1 Crore in case.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i) The location is beyond 10 km from the existing Industrial Estates / IDS&rsquo;s having vacant land / shed for allotment.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii) Cost of the support infrastructure is limited to 15% of the eligible fixed capital investment made in the industry.</p>
                                                <p>(c)&nbsp; The District level Officer will recommend the applications after placing before the Investment Evaluation Committee (IEC) with his specific remarks/ recommendation on the proposed Infrastructure to be developed together with the following information.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i) The Enterprise/Industry should give a declaration stating that they have not availed any financial assistance from the Government earlier for the proposed Infrastructure to be developed:</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii) Declaration from the line department concerned shall be obtained stating that the project is not covered in the budgetary estimates of current year.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iii) The Infrastructure estimates are to be confirmed by District Level officer of the line department concerned with certificate that no departmental funds are available for this purpose.</p>
                                                <p>(d)&nbsp; Support will be available for the following components:</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i) Drinking Water and Industrial Water.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii) Electricity &ndash; Power connection.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iii) Laying of drainage line from the Enterprise/Industry/Industrial Estate to the existing Point or to the natural drainage point:</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iv) Approach Road to the Enterprise/Industry.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(v) Any other infrastructure facilities as approved by the SLAC.</p>
                                                <p>(e)&nbsp; This assistance would be available for all eligible Units under A3, A4 &amp; A5 category only.</p>
                                                <p>(f)&nbsp; Before release of incentives amount, the District Level Officer concerned has to ascertain the working condition of the enterprise/industry.</p>
                                                <p>(g)&nbsp; The Enterprise/Industry should be in operation for at least six (6) years in respect of Micro &amp; Small A and A2 category, ten (10) years in respect of A3,A4 and A5 category from the Date of Commencement of Commercial Production, if not, the grant will be recovered. In this regard, the District Level Officer should monitor the progress of these Enterprises and submit report to the Department of Handloom and Textile (DH&amp;T) on half-yearly basis.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_14" runat="server" visible="false">
                                                <h5><b>Environmental Infrastructure: Rebate in O&amp;M Charges for CETP/ETP [Form-XV]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible units shall submit <strong>Form-XV </strong>along with&nbsp; all required documents mentioned in the Online Application for claiming</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i) Capital subsidy for environmental infrastructure shall submit application to the DLO concerned within one year of completion of ETP / CETP.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii) To claim Rebate on O&amp;M Charges the applicant shall submit application within six months after completion&nbsp; of&nbsp; every Half-year i.e., last date for filing claim application is 31st of March for first half year and 30th of September for second half year, with the documents mentioned in the Application to the District Nodal Agency concerned for a period of 5 years from the commencement of commercial production.</p>
                                                <p>(b)&nbsp; Eligible units for claiming support under environmental infrastructure subsidy shall have the following attributes.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(i) Existing units engaged in eligible activities and which are into commercial production for a minimum period of 3 years before the date of Application shall be eligible</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ii) Existing units having their own captive ETP and Common ETP and is operational for at least 1 year before the date of application.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iii) Existing units in Textile / Apparel Park connected to CETP constructed by Government / SPV and which have commenced commercial production for a minimum period of 3 months before the date of application.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(iv) Claim for reimbursement may be considered on successful implementation of ETP/CETP after necessary clearances from PCB / MoEF or any other statutory authority</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(v) If the unit has availed incentives under any scheme of State Government or the Central Government (Gol) or Government Agencies or any Financial Institutions it shall be eligible for the differential amount of benefit only.</p>
                                                <p>(c)&nbsp; In the Textile / Apparel Parks developed by the Government, the Government will take complete responsibility for providing a Common Effluent Treatment Plant (CETP) which will be developed in a PPP mode by engaging experienced and reputed firms. The individual units located in that Park will be required to take their effluents discharge to the CETP on pay-per-use basis.</p>
                                                <p>(d)&nbsp; In other cases, where a unit develops its own ETP or waste treatment plant or water recycling plant, the Government will provide a capital subsidy of 50% of the project cost with a cap of Rs 10 crore.</p>
                                                <p>(e)&nbsp; For a CETP or an ETP, Government will also provide a rebate in the O&amp;M charges in the following scale:</p>
                                                <p><a name="_Toc509822621"></a>For units availing CETP in a Textile / Apparel / Industrial Parks, the O&amp;M cost charged by CETP operator will be reimbursable as follows: -</p>
                                                <p>Year 1 and 2: - 75% reimbursement</p>
                                                <p>Year 3 and 4: - 50% reimbursement</p>
                                                <p>Year 5: - 25% reimbursement</p>
                                                <p>For units setting up their own ETP and for which they have availed capital subsidy under Clause 30(e), only the following O&amp;M components, at actuals, will be eligible for reimbursement (as per the % reimbursement above): -&nbsp;</p>
                                                <p>-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Chemical Cost</p>
                                                <p>-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Power Cost</p>
                                                <p>-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Maintenance Cost</p>
                                                <p>-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Manpower Cost</p>
                                                <p>-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lab Testing Cost</p>
                                                <p>-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Store &amp; Expenses</p>
                                                <p>-&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RO Reject Handling Cost</p>
                                                <p><strong>&nbsp;</strong></p>
                                                <p><strong>For the purpose of O&amp;M subsidy calculation, the maximum O&amp;M cost (sum of all above components) shall not exceed Rs 150 per KL</strong></p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_15" runat="server" visible="false">
                                                <h5><b>Assistance for Development of Worker Housing / Dormitories: [Form-XVI]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; For Assistance for Development of Worker Housing / Dormitories, the Applicants shall submit <strong>Form-XVI </strong>along with required documents mentioned in the Online Application, within one year of completion of Development of Worker Housing / Dormitories and with at least 30% occupancy for at least 6 months to the District Level Officer through Online portal. The DLO should confirm the occupancy level recommending the proof of the claim.</p>
                                                <p>(b)&nbsp; To encourage the Textile / Apparel units in developing housing facilities for workers in the vicinity of work place, Government shall ensure availability of land in proposed Textile /Apparel parks. Assistance in form of rebate of 60%&nbsp; on the land cost and land conversion charges with an upper limit of Rs 30 lakhs per acre shall be provided under the Policy.&nbsp;</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_16" runat="server" visible="false">
                                                <h5><b>Reimbursement of cost in skill upgradation and Training [Form-XVII]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible industrial Enterprises shall submit their claims in the prescribed online application <strong>Form-XVII </strong>for reimbursement of cost involved in skill up gradation and training the local manpower within six months after completion of such training program along with required documents mentioned in Application, to the DLO concerned through Online Portal.</p>

                                                <p>(b)&nbsp; As per T-TAP, the State Government shall provide a training subsidy of Rs 3000 per employee to the companies as a reimbursement towards cost incurred in skill up-gradation and training of local manpower. The extent of subsidy shall be Rs 5000 per employee for units employing more than 1000 persons. For the benefit to be passed on, the Policy makes it mandatory for the trained employees to remain in continuous employment for at least one year.</p>

                                                <p>(c)&nbsp; The Training Subsidy shall be reimbursed only once for each trainee either for training of newly recruited trainee or for skill upgradation of existing employee.</p>
                                                <p>(d)&nbsp; Units availing this incentive are also eligible to avail training benefits under other GoI schemes.</p>
                                                <p>(e)&nbsp; Both new and existing eligible units undertaking expansion / diversification / modernization are eligible for Training Subsidy under the Policy.</p>
                                                <p>(f)&nbsp; The training should be aimed at up gradation of skill, which should be useful to the organization.</p>
                                                <p>(g)&nbsp; The training should be more practical oriented rather than pure theoretical one.</p>
                                                <p>(h)&nbsp; The eligible units have to inform the concerned DLO well in advance of the commencement of training program. The District Level Officer concerned shall monitor the skill development training program.</p>
                                                <p>(i)&nbsp; After recruitment of the local candidates, in-plant training to be organized.</p>
                                                <p>(j)&nbsp; Reputed/Accreditation Agencies both Government and Private shall be engaged.</p>
                                                <p>(k)&nbsp; The Enterprise/industry should submit the list of employees trained along with their appointment letters duly certified by the promoter.</p>
                                                <p>(l)&nbsp; This facility should be utilized for training the local manpower so that the local manpower will be readily suitable for employment.</p>
                                                <p>(m)&nbsp; The unit will be eligible for training subsidy for each employee upon furnishing proof of one (1) year of continuous employment of the employee by way of PF and ESI, etc. Each year, only the incremental number of employees added by the unit, over and above the total number of employees in the previous year, will be considered for training subsidy.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_17" runat="server" visible="false">
                                                <h5><b>Assistance towards Training Infrastructure in Apparel Design and Development [Form-XVIII]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible industrial Enterprises shall submit their claims in the prescribed online application <strong>Form-XVIII</strong> for reimbursement of cost towards Training Infrastructure in Apparel Design and Development within six months after completion of first training programme along with required documents mentioned in Application, to the DLO concerned through Online Portal.</p>
                                                <p>(b)&nbsp; The Policy provides financial assistance to new and existing autonomous institution promoted by Government / Public Sector Undertakings or Private sector as below:</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (i)  <strong>For New Training Infrastructure Creation &ndash; </strong>Assistance available upto 75%, subject to a maximum amount of Rs.1 crore towards infrastructure creation. An institution with substantial background in Textile and Apparel design development will be supported under the Policy.</p>
                                                <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (ii) <strong>For Up-Gradation of Facilities</strong> &ndash; New or existing centres that intend to upgrade their facilities in order to provide apparel training shall be eligible for an assistance upto 50% of their investment towards infrastructure creation subject to a maximum amount of Rs.20 lakhs per centre.</p>
                                                <p>(c)&nbsp; Eligible components for subsidy are buildings, plant and machinery for demonstration purposes including the cost of installation, electrification, furniture, training aids like projectors etc.</p>
                                                <p>(d)&nbsp; Cost of land and recurring expenditure for training will not be covered under the Policy.</p>
                                                <p>(e)&nbsp; Autonomous institution promoted by Government / Public Sector Undertakings or Private sector setting up new training infrastructure for Apparel Design and Development shall be eligible for the assistance .</p>
                                                <p>(f)&nbsp; Existing Centres promoted by Government / Public Sector Undertakings or Private sector intending to upgrade their training infrastructure for Apparel Design and Development shall also be eligible for the assistance .</p>
                                                <p>(g)&nbsp; Only institution with substantial background in Textile and Apparel design development shall be supported under the scheme for creation of new training infrastructure.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="DivIncentiveID_18" runat="server" visible="false">
                                                <h5><b>Returning Migrant&rsquo;s Incentive Scheme [FORM-XIX]</b></h5>
                                                <h6><b><u>Eligible items:-</u></b></h6>
                                                <p>(a)&nbsp; All eligible migrants shall submit the prescribed online application <strong>Form-XIX </strong>in order to claim subsidy along with required documents mentioned in Application, through Online Portal.</p>
                                                <p>(b)&nbsp; Under this scheme the Government shall provide 50% of the capital investment required to be borne by the weaver group to develop Textile Parks as per the scheme guidelines of SITP, Government of India as well as MSME Cluster Development Incentive / Scheme of Government India.</p>
                                                <p>(c)&nbsp; Only those groups will be eligible for such subsidy support that has at least 60% of members as weavers who have migrated to other States. The capital investment subsidy will be limited to Rs 2.0 Cr or 50% of the required beneficiary group contribution, whichever is lower.</p>
                                                <p>The Government of Telangana may review and modify these incentives and operational guidelines from time to time.</p>
                                                <p>&nbsp;</p>
                                            </div>
                                            <div id="Div1" runat="server" class="py-1">
                                            </div>
                                            <div id="DivGeneralTermsCondition" runat="server" class="py-4" style="border: 1px solid; padding: 10px">
                                                <h5 style="text-align: center;"><b><u>GENERAL TERMS AND CONDITIONS FOR INCENTIVES</u></b></h5>
                                                <p class="py-3">(a)	All eligible industrial Enterprises shall submit their claims in the prescribed online application forms in Annexure 1 for investment subsidy within six months from the date of commercial production to District Level Officer concerned.</p>
                                                <p>(b)	The claim applications filed after six months but before one year from the date of commercial production will be treated as belated claims and are eligible for 50% of all the incentives. All claims filed beyond one year from the date of commercial production or by end of half year for periodical claim are not eligible for anyincentives. However, the unit which already commenced operation before the issue of guidelines are eligible for applying to file their pending incentives claims within six (6) months from the date of issue of guidelines.</p>
                                                <p>(c)	All eligible Industry/Enterprise under A1, A2 category established in leased premises should furnish a registered lease deed for a minimum period of ten (10) years covering the first six (6) years production period from the date of commencement ofproduction.</p>
                                                <p>(d)	All eligible Industry/Enterprise under A3,A4, A5 category should furnish a registered lease deed for a minimum period of ten (10) years covering the first six (6) years of production period from the date of commencement ofproduction.</p>
                                                <p>
                                                    (e)	In case of existing Industrial Enterprise setting up a new industrial Enterprise with separate identifiable investment, the words 'SEPARATE IDENTIFIABLE INVESTMENT’ shall means that the Enterprise/Industry should not have any production linkage with the existing manufacturing process and the product should be a separate product itself with independent marketability. The new Enterprise/Industry should be in a separate building, should maintain separate books of accounts and the project should be appraised independently by financial institution as a viable project. A new project will not, however, be regarded as a "Separate Identifiable Investment" if the utilities of the existing Enterprise/Industry like water, electricity, steam and pollution control systems are extended to the new Enterprise/Industry .<br />
                                                    <br />
                                                    If any existing Industrial Enterprise setting up a new industrial Enterprise with separate identifiable investment for the same end product/new product at different location in the same name it will be treated as new Enterprise/Industry (separately identifiable investment),even though there is no separate Goods and Services Tax registration number (GST) and separate marketability, since the Tax Department is issuing only one Goods and Services Tax registration number (GST) for one dealer even though they have more than one Enterprises/Industries within the state. However they have to maintain separate books of accounts for each location.
                                                </p>

                                                <p>&nbsp;</p>
                                                <h5 style="text-align: center"><b><u>Annexure – II</u></b></h5>
                                                <h5><b><u>New Industry/Enterprises:</u></b></h5>
                                                <p>
                                                    New Industrial Enterprise/Industry means and includes all eligible manufacturing/service industrial Enterprise/Industries which have been <b>established</b> in the State with
                                                    <b>new Machinery/equipment</b> and <b>commenced commercial production after 18/08/2017 and before 17/08/2022 (inclusive both dates)</b> and have <b>obtained UdyogAadhaar Memorandum 
                                                    (UAM)</b> /Industrial Entrepreneur’s Memorandum <b>(IEM)</b> / <b>(IL)</b> from Government of India (GoI).
                                                </p>


                                                <p>&nbsp;</p>
                                                <h5><b><u>Existing Industry/Enterprises:</u></b></h5>
                                                <p>
                                                    Existing Industry/Enterprises shall refer to Industry/Enterprises that have filed 
                                                    UdyogAadhar Registration <b>(UAR)</b> / Industrial Entrepreneur’s Memorandum <b>(IEM)</b> with the 
                                                    concerned District Industries Centre (DIC) or Industrial Entrepreneur’s Memorandum with the Government of 
                                                    India and <b><u>have commenced commercial production or operation before the announcement of the T-TAP policy i.e on 18/08/2017.</u></b>
                                                </p>

                                                <p>&nbsp;</p>
                                                <h5><b><u>Expansion:</u></b></h5>
                                                <p>
                                                    Expansion of Existing Industry/Enterprises with or without forward and backward integration, with <b>investment more than 25% of 
                                                    its existing Gross Fixed Capital Investment</b> and <b>enhancement of the existing installed capacity by at least 25% in the same production
                                                    lines</b> as on the date of initiating expansion and <b>commencing production during the operative period of the scheme shall be treated as expansion</b>.<br />
                                                    <b>Note:</b> The units which have commenced the commercial production on or after 01.04 .2017 will be eligible for incentives under T-TAP subject to condition
                                                    that their plant and machinery shall have landed at site on 01.01.2017 will be considered for incentives.
                                                </p>

                                                <p>&nbsp;</p>
                                                <h5><b><u>Diversification:</u></b></h5>
                                                <p>
                                                    Existing Industry/Enterprises in eligible areas, making <b>investment in a new product other than those listed in the ineligible list</b>, 
                                                    involving Diversification with <b>an enhancement of at least by 25% of the existing gross fixed capital investmentas well as enhancement
                                                    of turnover by 25% in value terms</b> as on the date of initiating diversification and commencing production during the operative period 
                                                    of the scheme shall be treated as diversification.
                                                </p>

                                                <p>&nbsp;</p>
                                                <h5><b><u>Modernization:</u></b></h5>
                                                <p>
                                                    (a)	Existing Industry/Enterprises shall be considered as Industry/Enterprises undergoing modernization, in case <b>they have plant
                                                    & machineries of certain specifications and they have brought in plant & machineries of an upgraded version or acquired new technologies 
                                                    for capacity augmentation</b> within the Industry/Enterprises.
                                                </p>
                                                <p>(b)	<b>An Existing Unit shall be covered under the Policy if </b>:</p>
                                                <p>&nbsp;</p>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div id="Div2" runat="server" class="py-1">
                                </div>
                                <div class="box newpage" id="calculationpart">
                                    <div class="row">
                                        <h4 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="HCalHeading">PART B
                                                <br />
                                            </h4>
                                    </div>
                                </div>
                                <div class="container" id="DivPrint" runat="server" style="text-align: center; vertical-align: bottom">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                                        <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--  </div>--%>
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
    </script>

</body>
</html>
