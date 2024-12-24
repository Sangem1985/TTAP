<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmReInspectionReport.aspx.cs" Inherits="TTAP.UI.Pages.frmReInspectionReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>
    <%-- <link href="../../Models/bootstrap.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function ValidateRemove(x) {
            var result = confirm('Are you sure want to delete Record?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }

        function ValidateSubmit(x) {
            var result = confirm('Are you sure want Submit the Report?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>
    <style>
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        .radio, .checkbox {
            display: block;
            min-height: 20px;
            padding-left: 20px;
            margin-top: 10px;
            margin-bottom: 10px;
        }

            .radio input[type="radio"], .radio-inline input[type="radio"], .checkbox input[type="checkbox"], .checkbox-inline input[type="checkbox"] {
                float: left;
                margin-left: 20px;
            }

        input[type="radio"], input[type="checkbox"] {
            margin: 4px 0 0;
            line-height: normal;
        }

        input[type="checkbox"], input[type="radio"] {
            box-sizing: border-box;
            padding: 0;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="BtnSave" />
            <asp:PostBackTrigger ControlID="btndraft" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Revised Inspection Report</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Revised Inspection Report</h5>
                                </div>
                                <div class="widget-content nopadding">
                                   <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Unit Name</label>
                                            <label class="form-control" id="lblUnitName" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label26" runat="server">Address</label>
                                            <label class="form-control" id="lblAddress" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label27" runat="server">Name of the Proprietor</label>
                                            <label class="form-control" id="lblProprietor" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label28" runat="server">Constitution of Organization</label>
                                            <label class="form-control" id="lblOrganization" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Social Status</label>
                                            <label class="form-control" id="lblSocialStatus" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Share of SC/ST/Women Enterprenuer</label>
                                            <label class="form-control" id="lblShareofSCSTWomenEnterprenue" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label31" runat="server">Registration Number</label>
                                            <label class="form-control" id="lblRegistrationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label3" runat="server">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                         <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label19" runat="server">Category of Unit as per Application</label>
                                            <label class="form-control" id="lblCategoryofUnit" runat="server"></label>
                                        </div>
                                       
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label32" runat="server">Type of Sector</label>
                                            <label class="form-control" id="lblTypeofSector" runat="server">Textiles</label>
                                        </div>
                                         <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label18" runat="server">Type of Textile as per Application</label>
                                            <label class="form-control" id="lblTypeofTexttile" runat="server"></label>
                                        </div>
                                       
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label33" runat="server">Technical Textile Type</label>
                                            <label class="form-control" id="lblTechnicalTextileType" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Activity of the Unit</label>
                                            <label class="form-control" id="lblActivityoftheUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label2" runat="server">Incentive Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label34" runat="server">Date of Power Connection Release</label>
                                            <label class="form-control" id="lblPowerConnectionReleaseDate" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label7" runat="server">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label6" runat="server">Date of Receipt of Claim Application</label>
                                            <label class="form-control" id="lblReceiptDate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                         <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Promoter details in case eligible for additional subsidy</label>
                                            <label class="form-control" id="lblcategory" runat="server"></label>
                                        </div>
                                        <div runat="server" id="divChangerequest" class="col-sm-8 form-group" visible="false">
                                            <label class="control-label" id="Label10" runat="server">Change Request(If you want to change Category and Type of Textile as per your Inspection Click on Change Request Option)</label>
                                            <%-- <label class="form-control" id="Label11" runat="server"></label>--%>

                                            <asp:CheckBox Style="width: 9%;"
                                                class="form-control" AutoPostBack="true"  ID="ChkChangeReqest" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row" runat="server" visible="true" id="divChangerequestNote">
                                        <div>
                                            <label style="font-family: 'Montserrat-SemiBold'; margin: 0px 0px 0px 15px;color:red;"
                                                class="control-label" id="Label13" runat="server">
                                                Note: If you want to change Category and Type of Textile as per your Inspection Please Change below.
                                            </label>
                                        </div>
                                    </div>
                                     <div class="row">
                                     <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label4" runat="server">Category of Unit as per DLO Verifcation</label>
                                            <%--<label class="form-control" id="lblCategoryofUnit" runat="server"></label>--%>
                                            <asp:DropDownList class="form-control" Enabled="true" AutoPostBack="true" ID="ddlCategory" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                                                <asp:ListItem Value="A1">A1</asp:ListItem>
                                                <asp:ListItem Value="A2">A2</asp:ListItem>
                                                <asp:ListItem Value="A3">A3</asp:ListItem>
                                                <asp:ListItem Value="A4">A4</asp:ListItem>
                                                <asp:ListItem Value="A5">A5</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                     <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Type of Textile as per DLO Verifcation</label>
                                            <%--<label class="form-control" id="TypeofTexttile" runat="server"></label>--%>
                                            <asp:DropDownList class="form-control" Enabled="true" AutoPostBack="true" ID="ddlTypeofTextile" runat="server" OnSelectedIndexChanged="ddlTypeofTextile_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Conventional Textile Unit</asp:ListItem>
                                                <asp:ListItem Value="1">Technical Textile Unit</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                         </div>
                                    <%--<div class="row" style="height: 40px">
                                        <div class="col-sm-4 form-group">
                                        </div>
                                    </div>--%>
                                    <div class="row my-4">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr>
                                                    <td align="left" style="width: 25%" class="font-SemiBold">Name and Designation of the Inspecting Officer</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="lblInspectingOfficerName" runat="server"></label>
                                                    </td>
                                                    <td align="left" style="width: 25%" class="font-SemiBold">Inspection Schduled Date</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="lblInspectionSchduledDate" runat="server"></label>
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
                                                <tr>
                                                    <td align="left" class="font-SemiBold">Date of Inspection</td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtAppDateofInspection" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">Amount of Subsidy Claimed By Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblSubsidyClaimedUnit" runat="server"></label>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td align="left" class="font-SemiBold" id="tdsysSubsidy" runat="server">Amount of Subsidy Recommended(System Calculated)</td>
                                                    <td align="left" id="tdsysSubsidy1" runat="server">
                                                        <label class="control-label" id="SubsidySystemRecommended" runat="server"></label>
                                                    </td>
                                                    <td align="left" class="font-SemiBold" id="tdIORecommended" runat="server" visible="false">Amount of Subsidy Recommended</td>
                                                    <td align="left" id="tdIORecommended1" runat="server" visible="false">
                                                        <asp:TextBox ID="txtAmountSubsidyRecommended" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="font-SemiBold">
                                                        <span id="Capitalsub" runat="server">Person from the Industry present at the time of Inspection</span></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtIndustryPersonName" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trIndustryDeptPerson">
                                                    <td align="left" class="font-SemiBold">
                                                        <span id="Span1" runat="server">Name of the Industries Department Person who Updated the Report</span></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtIndDeptName" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">
                                                        <span id="spnIndLastUpdatedon" runat="server">Industries Department Person Report Updated Date</span></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtDateofIndustriesDept" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trIndustryDeptPerson1">
                                                    <td align="left" class="font-SemiBold">
                                                        <span id="Span2" runat="server">Industry Department Remarks</span></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtIndustryRemarks" Enabled="false" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                    </td>
                                                    <td align="left" class="font-SemiBold">
                                                        <span id="Span3" runat="server">Industry Department Report Status</span></td>
                                                    <td align="left">
                                                        <asp:TextBox ID="txtIndustryDepartmentReportStatus" Style="background: darkseagreen; color: black;"
                                                            Enabled="false" runat="server" class="form-control"></asp:TextBox>
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
                                                <tr runat="server" visible="false" id="trApprovedProjectCost">
                                                    <td align="left" colspan="4">
                                                        <%--<div class="text-blue font-SemiBold col col-sm-12 mt-3">Approved Project Cost(In Rs.)</div>--%>
                                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">1.Approved Project Cost(In Rs.)</h6>
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
                                                                    <td id="Td2" runat="server" align="center" visible="false">
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
                                                                    <td id="Td4" runat="server" align="center" visible="false">
                                                                        <label id="lblexpinv" runat="server" font-bold="True"></label>
                                                                    </td>
                                                                    <td id="Td5" runat="server" align="center" visible="false">
                                                                        <label id="lbltotperinv" runat="server" font-bold="True"></label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false" id="trActualInvestment">
                                                    <td align="left" colspan="4" >
                                                        <%-- <div class="text-blue font-SemiBold col col-sm-12 mt-3">Actual Investment(In Rs.)</div>--%>
                                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">2.Actual Investment(In Rs.)</h6>
                                                        <div class="col-sm-10 table-responsive">
                                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
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
                                                        <div id="Div1" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">3.Eligible Fixed Capital Investment</h6>
                                                            <%--<h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Land Details</h6>--%>
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">3.1 Land Details</div>
                                                            <div class="col-sm-10 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>S.No</th>
                                                                        <th>Type of Land</th>
                                                                        <th>Extent in Acre</th>
                                                                        <th>Cost Per Acre (In Rs)</th>
                                                                        <th>Value Of Land (In Rs)</th>
                                                                        <th>Extent in Acre as per DLO Verification</th>
                                                                        <th>Cost Per Acre as Per DLO Verification(In Rs)</th>
                                                                        <th>DLO Remarks</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 5%">1</td>
                                                                        <td align="left">Purchased Land </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtPLExtent" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtPLValue" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblPLTotalValue" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDLOExtent" onkeypress="return DecimalOnly(event)" class="form-control" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDLOLandRecomendAmountPerAcre" AutoPostBack="true" onkeypress="return DecimalOnly(event)" OnTextChanged="txtDLOAmount_TextChanged" class="form-control" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="txtDLOLandRemarks" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td align="center">2</td>
                                                                        <td align="left">Leased Land</td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtLLExtent" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtLLValue" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblLLTotalValue" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox7" Enabled="false" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox4" runat="server" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center">3</td>
                                                                        <td align="left">Inhertied Land</td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtILExtent" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtILValue" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblILTotalValue" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox8" Enabled="false" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox2" runat="server" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox5" runat="server" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td align="center">4</td>
                                                                        <td align="left">Govt Land (TSIIC developed IEs/IDA/Industrial Parks)</td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtGLExtent" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtGLValue" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblGLTotalValue" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox3" runat="server" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox9" Enabled="false" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:TextBox ID="TextBox6" runat="server" Enabled="false"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2" runat="server" visible="false">
                                                                        <td align="center"></td>
                                                                        <td align="left">Total</td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="lblTotalExtentinAcre" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="Label11" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblTotalValueOfLand" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trcapitalsubisdy" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div runat="server" id="divBuildingDtls" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <%--<h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Building Details</h6>--%>
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">3.2 Building Details</div>
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
                                                                            <asp:CheckBox CssClass="incsize" ID="CHKIncentive" runat="server" AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("SELECTED")) %>' Enabled="false" OnCheckedChanged="CHKIncentive_CheckedChanged" />
                                                                            <asp:Label ID="lblCivilworks" runat="server" Text='<%# Bind("Civilworks") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Plinth Area as per Application">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPlinthArea" runat="server" Text='<%# Bind("PlinthArea") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Value as per Application(in Rs.)">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblValueRs" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DLO Recommended Plinth Area as per Verification">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtDLOPlinthArea" CssClass="form-control" OnTextChanged="txtDLOPlinthArea_TextChanged" AutoPostBack="true" runat="server" onkeypress="return DecimalOnly(event)" Text='<%# Bind("DLORecommendedPlinthArea") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DLO Recommended Amount/Sq.Meter as per Verification">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtDLOSqmterValue" CssClass="form-control" OnTextChanged="txtDLOPlinthArea_TextChanged" AutoPostBack="true" runat="server" onkeypress="return DecimalOnly(event)" Text='<%# Bind("DLOSqmterValue") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="DLO Recommended Amount as per Verification(in Rs.)">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtDLOAmount" CssClass="form-control" Enabled="false" OnTextChanged="txtDLOPlinthArea_TextChanged" AutoPostBack="true" runat="server" Text='<%# Bind("DLORecommendedAmount") %>'></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox TextMode="MultiLine" CssClass="form-control" ID="txtBuildingRemarks" Text='<%# Bind("DLORemarks") %>' runat="server"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="DLO Recoommendation">
                                                                            <ItemTemplate>
                                                                                <asp:RadioButtonList ID="rbtnBuilding" runat="server" AutoPostBack="true" RepeatDirection="Vertical"
                                                                                     CssClass="radiostyle">
                                                                                    <asp:ListItem Value="Y" Selected="True" Text="Yes"></asp:ListItem>
                                                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                                    <asp:ListItem Value="A" Text="Admissible Amount"></asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                                <asp:TextBox ID="txtAdmissibleAmountBuilding" Visible="true" Enabled="false" Text='<%#Eval("Value") %>' Style="height: 34px; width: 190px;" class="form-control" OnTextChanged="txtAdmissibleAmount_TextChanged" AutoPostBack="true" runat="server" Height="100px"></asp:TextBox>
                                                                                <asp:Label ID="lblremarks" runat="server"> Remarks : </asp:Label>
                                                                                <asp:TextBox ID="txtremarksBuilding" Visible="true"  class="form-control" TextMode="MultiLine" runat="server" Height="100px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle CssClass="text-center" />
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="280px" />
                                                                        </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <div class="row mt-4">
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label14" runat="server">Total Plinth Area of Civil Works item No.1 to 7 (in Sq meters) : </label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lbl1to7Plinth"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label15" runat="server">Total Value of Civil Works item No. 1 to 9 (in Rs.) : </label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lbl1to9Value"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label16" runat="server">Total Value of item No. 8 to 17 (Not exceeding 10% of total value of Civil works items 1 to 9) (in Rs.) : </label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="form-control" runat="server" id="lbl8to17Value"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group" runat="server" id="divExceed" visible="false">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label style="color: red;"
                                                                            class="control-label label" id="Label17" runat="server">
                                                                            Total Value of item No. 8 to 17 is exceeded 10% of total value of Civil works items 1 to 9
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr id="divplantmachinary" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="col-sm-12 text-black font-SemiBold mb-1">3.3 Plant and Machinery Details</div>
                                                        <asp:TextBox ID="txtSearch" Visible="false" Style="padding: 3px; border-radius: 4px;" onkeyup="return FilterService(this,'SG');" runat="server"></asp:TextBox>
                                                        <a id="A2" href="#" class="tags" onserverclick="BtnExportExcel_Click" gloss="Export to Excel" visible="true" runat="server">
                                                            <img src="../../../images/Excel-icon.png" style="margin: 0px 0px 0px 15px;" width="30px" height="30px"
                                                                alt="Excel" /></a>
                                                        <div class="row my-4">
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="grdPandM" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowDataBound="grdPandM_RowDataBound">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <%-- <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />--%>
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
                                                                                <asp:Label CssClass="pmid" ID="lblPMId" Text='<%#Eval("PMId") %>' runat="server" />
                                                                                <asp:Label ID="lblIncentiveId" Visible="false" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Name" HeaderStyle-Width="5%">
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
                                                                        <asp:TemplateField HeaderText="Foreign Machine Cost">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblForeignMachineCost" Text='<%#Eval("ForeignMachineCost") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Invoice">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="hyFilePathMerge2" Text="view" NavigateUrl='<%#Eval("FilePathMerge2")%>' Target="_blank" runat="server" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Classification of Machinery" Visible="true">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblClassificationofMachinery" Text='<%#Eval("ClassificationMachineryText") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Availability of the Machine in Running Condition & Recommended Amount">
                                                                            <ItemTemplate>
                                                                                <asp:RadioButtonList ID="rbtnmachinesavailableYes" runat="server" AutoPostBack="true" RepeatDirection="Vertical"
                                                                                    OnSelectedIndexChanged="rbtnmachinesavailableYes_SelectedIndexChanged" CssClass="radiostyle">
                                                                                    <asp:ListItem Value="Y" Selected="True" Text="Yes"></asp:ListItem>
                                                                                    <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                                    <asp:ListItem Value="A" Text="Admissible Amount"></asp:ListItem>
                                                                                    <%--<asp:ListItem Value="R" Text="Need Clarification"></asp:ListItem>--%>
                                                                                </asp:RadioButtonList>
                                                                                <asp:TextBox ID="txtAdmissibleAmount" Visible="true" Enabled="false" Text='<%#Eval("DLORecommendedMachineCost_ReInsp") %>' Style="height: 34px; width: 190px;" class="form-control" OnTextChanged="txtAdmissibleAmount_TextChanged" AutoPostBack="true" onkeypress="return DecimalOnly(event)" runat="server" Height="100px"></asp:TextBox>
                                                                                <asp:Label ID="lblremarks" runat="server"> Remarks : </asp:Label>
                                                                                <asp:TextBox ID="txtremarks" Visible="true" Text='<%#Eval("Remarks_ReInsp") %>' class="form-control" TextMode="MultiLine" runat="server" Height="100px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle CssClass="text-center" />
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="280px" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trAmountofSubsidyRecommendedAbstract" runat="server" visible="false">
                                                    <td align="left" colspan="4">
                                                        <div class="row" id="Div2" runat="server">
                                                            <%--<h6 class="col-sm-12 text-black font-SemiBold mb-1">Land Details</h6>--%>
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">3.4 Eligible Fixed Capital Investment - Abstract</div>
                                                            <div class="col-sm-11 table-responsive">
                                                                <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>S.No</th>
                                                                        <th>Description</th>
                                                                        <th>Calculated Value</th>
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
                                                <tr id="trcapitalsubsidy" runat="server" visible="false">
                                                    <td colspan="4">
                                                        <div class="row" id="Div3" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">3.5 Amount of Subsidy Recommended</div>
                                                            <div class="col-sm-10 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>Sl.No</th>
                                                                        <th>Subsidy</th>
                                                                        <th>System Calculated (in Rs.)</th>
                                                                        <th runat="server" id="thRecommendedDLO" visible="false">Amount of Subsidy Recommended By Inspcting Officer(in Rs.)</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td align="left">Capital Subsidy</td>
                                                                        <td align="center">
                                                                            <label id="lblSystemSubsidy" runat="server" cssclass="control-label"></label>
                                                                        </td>
                                                                        <td id="trFixedCapitalland" runat="server" align="center" visible="false">
                                                                            <asp:TextBox ID="txtInspectingOfficerSubsidy" onkeypress="DecimalOnly()" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="txtInspectingOfficerSubsidy_TextChanged"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="left">Additional Capital Subsidy for SC/ST, Women entrepreneurs or PWD (in Rs.)</td>
                                                                        <td align="center">
                                                                            <label id="lblSystemAdditionalCapitalSubsidy" runat="server" cssclass="control-label"></label>
                                                                        </td>
                                                                        <td id="Td1" runat="server" align="center" visible="false">
                                                                            <asp:TextBox ID="txtInspectingOfficerAdditionalCapitalSubsidy" onkeypress="DecimalOnly()" runat="server" class="form-control" AutoPostBack="True" OnTextChanged="txtInspectingOfficerSubsidy_TextChanged"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>
                                                                        <td align="left" style="text-align: left; font-weight: bold">Total Capital Subsidy (in Rs.)</td>
                                                                        <td align="center" style="font-weight: bold">
                                                                            <label id="lblSystemTotal" runat="server" font-bold="True"></label>
                                                                        </td>
                                                                        <td id="Td3" runat="server" align="center" visible="false">
                                                                            <label id="lblInspectingOfficerTotal" runat="server" font-bold="True"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
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
                                                                        <%--<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                    <RowStyle BackColor="White" ForeColor="#003399" />--%>
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            <div class="text-blue font-SemiBold col col-sm-12 mt-3">Current Claim Amount : </div>
                                                        </td>
                                                        <td>
                                                            <div class="font-SemiBold col col-sm-12 mt-3">
                                                                <asp:Label runat="server" ID="lblCCA"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" visible="true">
                                                        <td align="left" colspan="4">
                                                            <div class="text-blue font-SemiBold col col-sm-12 mt-3">Month wise & Bank wise Details of Current Claim Period</div>
                                                            <div class="row">
                                                                <div class="col-lg-14 col-md-14 col-sm-14 col-xs-14 table-responsive mt-2">
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
                                                                            <asp:TemplateField HeaderText="DLO Recommended Eligible interest Amount</br> (13)">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtDLOEligibleInterest" OnTextChanged="txtDLOEligibleInterest_TextChanged" AutoPostBack="true" runat="server" Text='<%#Eval("DLORecommendedInterest") %>'></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Remarks</br> (14)">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtDLORemarks" runat="server"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Additional Id" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAdditionalinformationId" runat="server" Text='<%#Eval("AdditionalinformationId") %>'></asp:Label>
                                                                                    <asp:Label ID="lblIncentiveId" runat="server" Text='<%#Eval("Incentive_id") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>

                                                        </td>
                                                    </tr>
                                                    <tr>
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
                                                <tr runat="server" id="trSanctionedIncentives">
                                                    <td align="left" colspan="4">
                                                        <div class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Incentive Subsidy already Sanctioned</div>
                                                        <div class="row">
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="grdSLCData" runat="server" CssClass="table table-bordered title6 w-75 NewEnterprise" CellSpacing="4"
                                                                    AutoGenerateColumns="false" CellPadding="4">
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
                                                                        <asp:TemplateField HeaderText="Period From Date </br> (2)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("PeriodFromDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Period To Date </br> (3)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("PeriodToDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Slc Approved Amount </br> (4)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblToDate" runat="server" Text='<%#Eval("Slc_Approved_Amount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="1" class="font-SemiBold">Remarks of DLO if any</td>
                                                    <td align="left" colspan="3">
                                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="4">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Documents Enclosed by the Applicant</h6>
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
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Verified or Not">
                                                                        <ItemTemplate>
                                                                            <asp:RadioButtonList ID="rbtVerify" runat="server" Visible='<%# Eval("AttachmentName").ToString() == "Y" ? false : true %>' RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="radiostyle">
                                                                                <asp:ListItem Value="Y" Selected="True" Text="Yes"></asp:ListItem>
                                                                                <asp:ListItem Value="N" Text="No"></asp:ListItem>
                                                                                <asp:ListItem Value="R" Text="N.A"></asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle CssClass="text-center" />
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="280px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Attachment Name" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAttachmentName" Text='<%#Eval("AttachmentName") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Attachment Id" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAttachmentId" Text='<%#Eval("AttachmentId") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="MstIncentiveId" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trInspectionReportFileUpload">
                                                    <td align="left" class="font-SemiBold">Inspection Report (Including Calculation Work Sheet)</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fpdSpecimen" runat="server" CssClass="file-browse" />

                                                    </td>
                                                    <td align="left" colspan="2" style="vertical-align: middle">
                                                        <asp:HyperLink ID="hyplreportview" Font-Bold="true" runat="server">Click Here to View Uploaded Inspection Report</asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trIndCheckBox" visible="false">
                                                    <td align="left" class="font-SemiBold">Check the Checkbox if you are sending the Final Report to DLO</td>
                                                    <td align="left">
                                                        <asp:CheckBox ID="chkind" AutoPostBack="true" OnCheckedChanged="chkind_CheckedChanged" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trImage1" visible="false">
                                                    <td align="left" class="font-SemiBold">Photo of Name Plate of Unit </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuNamePlate" runat="server" CssClass="file-browse" />

                                                    </td>
                                                    <td align="left" colspan="2" style="vertical-align: middle">
                                                        <asp:Button ID="btnImgNamePlate" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload"  />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hypNamePlate" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trImage2" visible="false">
                                                    <td align="left" class="font-SemiBold">Photo of Plant & Machinary-1 </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPM1" runat="server" CssClass="file-browse" />

                                                    </td>
                                                    <td align="left" colspan="2" style="vertical-align: middle">
                                                        <asp:Button ID="btnImgPM1" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload"  />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hypPM1" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trImage3" visible="false">
                                                    <td align="left" class="font-SemiBold">Photo of Plant & Machinary-2 </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPM2" runat="server" CssClass="file-browse" />

                                                    </td>
                                                    <td align="left" colspan="2" style="vertical-align: middle">
                                                        <asp:Button ID="btnImgPM2" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload"  />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hypPM2" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trImage4" visible="false">
                                                    <td align="left" class="font-SemiBold">Photo of Plant & Machinary-3 </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPM3" runat="server" CssClass="file-browse" />

                                                    </td>
                                                    <td align="left" colspan="2" style="vertical-align: middle">
                                                        <asp:Button ID="btnImgPM3" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload"  />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hypPM3" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="4">
                                                        <div class="col-sm-12 mt-sm-3 text-left">
                                                            <p><strong>Note : </strong>File Size should be 1MB only.</p>
                                                        </div>
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 text-center mt-3">
                                        <asp:Button ID="btndraft" runat="server" CssClass="btn btn-success  m-2" Text="Save Details" OnClick="btndraft_Click" />
                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success  m-2" OnClientClick="if (!confirm('Are you sure want Submit the Report?')) return false;" Text="Submit Inspection Report" OnClick="BtnSave_Click" />
                                    </div>
                                    <div>
                                        <div class="col-sm-12 form-group">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hdnIncentiveId" />
            <asp:HiddenField runat="server" ID="hdnSubIncentiveId" />
            <asp:HiddenField runat="server" ID="hdnDistrictId" />
            <asp:HiddenField runat="server" ID="hdnTypeOfIndustry" />
            <asp:HiddenField runat="server" ID="hdnSubsidySystemRecommended" />
            <asp:HiddenField runat="server" ID="hdnSystemSubsidy" />
            <asp:HiddenField runat="server" ID="hdnSystemAdditionalCapitalSubsidy" />
            <asp:HiddenField runat="server" ID="hdnSystemTotal" />
            <asp:HiddenField runat="server" ID="hdnActualCategory" />
            <asp:HiddenField runat="server" ID="hdnActualTextile" />
            <asp:HiddenField runat="server" ID="hdnUserId" />
            <asp:HiddenField runat="server" ID="hdnrUserRole" />
            <asp:HiddenField runat="server" ID="hdnApplication" />
            <asp:HiddenField runat="server" ID="hdnLandValue" />
            <asp:HiddenField runat="server" ID="hdnBuildingValue" />
            <asp:HiddenField runat="server" ID="hdnPMValue" />
            <asp:HiddenField runat="server" ID="hdnOthersValue" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtAppDateofInspection']").keydown(function () {
            return false;
        });


        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[type=text]").attr('autocomplete', 'off');
            $("input[id$='ContentPlaceHolder1_txtAppDateofInspection']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtAppDateofInspection']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
        });
    </script>

    <style type="text/css">
        font- 8pt; i o; d n 0 2 em x e8 {
            x;
        }

        11 {
            ;
            6;
        }

        .auto- e12 {
            height:;
        }

        {
            width: 175p .auo-stye1 wid h: 250;
    </style>
    <style type="text/css">
        .ui-da font-size: 8pt !important; padding: 0.2em 0.2em 0; width: 250px; color: Black;
        }

        select {
            color: Black !important;
        }

        .auto-style1 {
            height: 26px;
        }
    </style>
    <style>
        .radiostyle {
            height: auto;
        }

            .radiostyle label {
                margin-left: 3px !important;
                margin-right: 10px !important;
            }
    </style>

</asp:Content>

