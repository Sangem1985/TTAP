<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRevisedInspectionRptViewaspx.aspx.cs" Inherits="TTAP.UI.Pages.Annexures.frmRevisedInspectionRptViewaspx" %>
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
                                <asp:CheckBox runat="server" ID="chkShow" onclick="return ShowHide(this);" Text="Show System Calculted" />
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
                                                    <td align="left" class="font-SemiBold" id="tdsysSubsidy" style="display:none;" runat="server">Amount of Subsidy Recommended(System Calculated) as per DLO Inspection</td>
                                                    <td align="left" id="tdsysSubsidy1" style="display:none;" runat="server">
                                                        <label class="control-label" id="SubsidySystemRecommended" runat="server"></label>
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
                                                 <tr id="trLandDetails" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                         <div class="row" id="Div1" runat="server">
                                                               <%--<h6 class="col-sm-12 text-black font-SemiBold mb-1">Land Details</h6>--%>
                                                             <div class="col-sm-12 text-black font-SemiBold mb-1">Land Details</div>
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
                                                            <td>1</td>
                                                            <td align="left">Purchased Land </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtPLExtent" runat="server"  ReadOnly="true" class="form-control" ></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtPLValue" runat="server" ReadOnly="true" class="form-control" ></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblPLTotalValue" runat="server" class="form-control"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item2">
                                                            <td>2</td>
                                                            <td align="left">Leased Land</td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtLLExtent" runat="server" ReadOnly="true" class="form-control" ></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtLLValue" runat="server" ReadOnly="true" class="form-control" ></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblLLTotalValue" runat="server" class="form-control"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>3</td>
                                                            <td align="left">Inhertied Land</td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtILExtent" runat="server" ReadOnly="true" class="form-control" ></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtILValue" runat="server" ReadOnly="true" class="form-control" ></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblILTotalValue" runat="server" class="form-control"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item2">
                                                            <td>4</td>
                                                            <td align="left">Govt Land (TSIIC developed IEs/IDA/Industrial Parks)</td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtGLExtent" Enabled="false" runat="server" class="form-control" ></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtGLValue" runat="server" Enabled="false" class="form-control" ></asp:TextBox>
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
                                                <tr id="trBuildingDetails" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <%--<h6 class="col-sm-12 text-black font-SemiBold mb-1">Building Details</h6>--%>
                                                              <div class="col-sm-12 text-black font-SemiBold mb-1">Building Details</div>
                                                            <asp:GridView ID="GvBuildingDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
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
                                                                            <asp:Label ID="lblBUILDINGID" Visible="false" runat="server" Text='<%# Bind("BUILDINGID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Item of Civil works">
                                                                        <ItemTemplate>
                                                                            
                                                                            <asp:Label ID="lblCivilworks" runat="server" Text='<%# Bind("Civilworks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Plinth Area">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPlinthArea" runat="server" Text='<%# Bind("PlinthArea") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Value (in Rs.)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblValueRs" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="divplantmachinary" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="col-sm-12 text-black font-SemiBold mb-1">Plant and Machinery Details</div>
                                                        <div class="row my-4">
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="grdPandM" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowDataBound="grdPandM_RowDataBound">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" ItemStyle-Width="5%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="P&M Id">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMId" Text='<%#Eval("PMId") %>' runat="server" />
                                                                                <asp:Label ID="lblIncentiveId" Visible="false" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineName" Text='<%#Eval("MachineName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Vendor Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVendorName" Text='<%#Eval("VendorName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Type of Machine">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTypeofMachine" Text='<%#Eval("TypeofMachine") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Invoice Number">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInvoiceNo" Text='<%#Eval("InvoiceNo") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Cost (In Rs)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineCost" Text='<%#Eval("MachineCost") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="DLO Recommended Machine Cost (In Rs)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDLOMachineCost" Text='<%#Eval("DLOFinalRecommendedMachineCost_ReInsp") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Availability of the Machine in Running Condition">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachinesavailability" Text='<%#Eval("MachineAvailabilityText_ReInsp") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle CssClass="text-center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remarks">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="txtremarks" Text='<%#Eval("Remarks_ReInsp") %>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>

                                                        <div class="row mt-4">
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
                                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label4" runat="server">Non Availabile Machinery Total Value (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lblTotalValueofNonAvailabile"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label1" runat="server">Total Value of Machinery (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lblTotalValueMachinery"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trcapitalsubsidy" runat="server" style="display:none;">
                                                    <td colspan="4">
                                                        <div class="row" id="Div3" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Amount of Subsidy Recommended</div>
                                                            <div class="col-sm-8 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>Sl.No</th>
                                                                        <th>Subsidy</th>
                                                                        <th>System Calculated (in Rs.)</th>
                                                                        <th>Amount of Subsidy Recommended By Inspcting Officer(in Rs.)</th>
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
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Verify Status">
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
                                            <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
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
                $('#trcapitalsubsidy').show();
            }
            else {
                $('#tdsysSubsidy').hide();
                $('#tdsysSubsidy1').hide();
                $('#trcapitalsubsidy').hide();
            }
        }
    </script>
</body>
</html>
