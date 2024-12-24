<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FormCreateAgenda.aspx.cs" Inherits="TTAP.UI.Pages.FormCreateAgenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="../../AssetsNew/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/style.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/media.css" />

    <script src="../../NewCss/js/jquery.min.js"></script>
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

        .main {
            min-height: 595px;
            min-height: 75.4vh;
            /*background: #f3f8ff;*/
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        #collapsibleNavbar .navbar-nav.d-flex.w-50.m-auto {
            margin: 0px !important;
        }

        .table-responsive {
            overflow-x: unset !important;
            width: 99% !important;
        }

        @media print {
            body {
                visibility: hidden;
            }

            #ContentPlaceHolder1_MainDiv {
                visibility: visible;
                position: absolute;
                left: 0;
                top: 0;
            }
        }
        /*div#ContentPlaceHolder1_Receipt, .container.mt-4.pb-4, .col-sm-12.offset-md-1.col-md-10.col-lg-10.offset-lg-1.p-4.pb-0.mt-3.frm-form.box-content {
            max-width: 1165px !important;
        }*/
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>

            <%--<asp:PostBackTrigger ControlID="Button1" />--%>
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">SLC Entry</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">SLC Entry</li>
                        </ul>
                    </div>

                </div>
                <div class="main">
                    <div id="content">
                        <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                            <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">

                                <div runat="server" id="divSelection">
                                    <div class="col-sm-12 mb-3 d-flex" runat="server">
                                        <table>
                                            <tr>
                                                <td>Application No </td>

                                                <td>
                                                    <asp:TextBox ID="txtApplicationNo" CssClass="form-control" runat="server"></asp:TextBox></td>
                                                <td>
                                                    <asp:Button Text="Get Incentives" CssClass="btn btn-blue ml-2 px-4 py-1 title5" OnClick="btnGetIncentives_Click" ID="btnGetIncentives" runat="server" />
                                                </td>
                                                <td></td>
                                                <td>Incentive</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlIncentive" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Button Text="Get Data" CssClass="btn btn-blue ml-2 px-4 py-1 title5" OnClick="btnGetData_Click" ID="btnGetData" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div>
                                </div>
                                <div class="container mt-4 pb-4" runat="server" id="MainDiv">
                                    <div class="w-100 px-3 frm-form py-3 font-medium title5" runat="server" id="divheader">
                                        <div class="row-fluid">
                                            <div class="widget-box">
                                                <div class="widget-title">
                                                    <span class="icon">
                                                        <i class="icon-info-sign"></i>
                                                    </span>
                                                    <div class="row">
                                                        <h5 class="text-black mb-3 col font-SemiBold text-left" style="margin: 0px 0px 0px 92px;"
                                                            runat="server" id="h3heading">AGENDA NO - </h5>
                                                    </div>
                                                    <div class="row">
                                                        <h5 class="text-black mb-3 col font-SemiBold text-left" style="margin: 0px 0px 0px 92px;"
                                                            runat="server" id="AgendaHead"></h5>
                                                    </div>
                                                    <div class="row" id="divInputFileNo" runat="server" visible="true" style="margin: 0px 0px 5px 92px;">
                                                        <asp:TextBox ID="txtFileNo" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="row" id="divBindFileNo" runat="server" visible="false">
                                                        <h5 class="text-black mb-3 col font-SemiBold text-left" style="margin: 0px 0px 0px 92px;"
                                                            runat="server" id="HeaderFileNo"></h5>
                                                    </div>
                                                </div>
                                                <div class="widget-content">
                                                    <div class="row">
                                                        <h5 class="text-black font-SemiBold mb-1" style="font-size: small;"></h5>
                                                        <div class="col-sm-10 table-responsive">
                                                            <table class="table table-bordered title6  w-100 NewEnterprise" style="margin: 0px 0px 0px 91px;">
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td align="center" style="width: 3%">1</td>
                                                                    <td align="left" style="width: 10%">Name of the Unit</td>
                                                                    <td align="left" style="width: 25%">
                                                                        <label class="control-label" id="lblUnitName" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">2</td>
                                                                    <td align="left">Address of the Unit </td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblAddress" runat="server"></label>
                                                                    </td>

                                                                </tr>

                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">3</td>
                                                                    <td align="left">Name of the Proprietor </td>
                                                                    <td align="left">
                                                                        <label class="control-label" runat="server" id="lblNameoftheProprietor"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">4</td>
                                                                    <td align="left">Constitution of Organization (Proprietoary/Partnership/Pvt.Ltd/Limited/Coop.)</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblConstitution" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">5</td>
                                                                    <td align="left">Gender</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblGender" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">6</td>
                                                                    <td align="left">Social Status</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblSocialStatus" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">7</td>
                                                                    <td align="left">Incorporation Registration No & Date</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblIncorporationNo" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">8</td>
                                                                    <td align="left">Type of Unit/Enterprise(New/Expansion/Diversification)</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblTypeofUnit" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">9</td>
                                                                    <td align="left">Category of  Unit</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblCategory" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">10</td>
                                                                    <td align="left">Type of Sector</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblTypeofSector" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">11</td>
                                                                    <td align="left">Type of Textiles</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblTypeofTextiles" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">12</td>
                                                                    <td align="left">Nature of Industry</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblNatureofIndustry" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2" runat="server">
                                                                    <td align="center">13</td>
                                                                    <td align="left">Type of Product</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblTypeofProduct" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">14</td>
                                                                    <td align="left">TSiPASS UID Number</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblUIDNo" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">15</td>
                                                                    <td align="left">Common Application Number</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblApplicationNo" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">16</td>
                                                                    <td align="left">GST Registration Number</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblGSTRegistrationNumber" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">17</td>
                                                                    <td align="left">Date of New Power Connection Released</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblPowerConnectionDt" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">18</td>
                                                                    <td align="left">Date of Commencement of Commercial Production</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblDCP" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">19</td>
                                                                    <td align="left">Date of Receipt of Application</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblAppliedDt" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">20</td>
                                                                    <td align="left">Date of Issue of notice calling for shortfall documents</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblDOQ" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">21</td>
                                                                    <td align="left">Date of receipt of reply</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblResponse" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">22</td>
                                                                    <td align="left">Date(s) of Inspection</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblInspectionDt" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td align="center">23</td>
                                                                    <td align="left">Name of the Financing Institutions in case of aided Units</td>
                                                                    <td align="left">
                                                                        <label class="control-label" id="lblBank" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div class="col-sm-10 table-responsive">

                                                            <table class="table table-bordered title6  w-100 NewEnterprise" id="tblInputInvestment" visible="true" style="margin: 10px 0px 0px 91px;" runat="server">

                                                                <h6 class="col-sm-12 text-black font-SemiBold mb-1" style="margin: 10px 0px 0px 91px;">24. Fixed Capital Investment</h6>
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Components</th>
                                                                    <th>Approved Project Cost as per DPR</th>
                                                                    <th>Investment of the Unit</th>
                                                                    <th>Investment Recommended by the AD/DLO</th>
                                                                    <th>Eligible Investment Computed</th>
                                                                    <th>Remarks</th>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="left">Land</td>
                                                                    <td align="center" id="thExistingLandActual" runat="server">
                                                                        <label id="lblDPRLand" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" style="width: 3%" runat="server">
                                                                        <label id="lblUnitInvLand" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td style="width: 3%" runat="server" align="center">
                                                                        <asp:TextBox ID="txtDLOInvLand" class="control-textbox" AutoPostBack="True" OnTextChanged="txtDLOInvTotal_TextChanged" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td id="Td1" runat="server" style="width: 3%" align="center">
                                                                        <asp:TextBox ID="txtCompInvLand" class="control-textbox" AutoPostBack="True" OnTextChanged="txtDLOInvTotal_TextChanged" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td id="Td2" runat="server" style="width: 3%" align="center">
                                                                        <asp:TextBox ID="txtRemarksLand" class="control-textbox" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>2</td>
                                                                    <td align="left">Building</td>
                                                                    <td align="center" runat="server">
                                                                        <label id="lblDPRBuilding" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" style="width: 3%" id="Td4" runat="server">
                                                                        <label id="lblUnitInvBuilding" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td5" style="width: 3%" runat="server" align="center">
                                                                        <asp:TextBox ID="txtDLOInvBuilding" class="control-textbox" AutoPostBack="True" OnTextChanged="txtDLOInvTotal_TextChanged" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td id="Td6" runat="server" style="width: 3%" align="center">
                                                                        <asp:TextBox ID="txtCompInvBuilding" class="control-textbox" AutoPostBack="True" OnTextChanged="txtDLOInvTotal_TextChanged" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td id="Td7" runat="server" style="width: 3%" align="center">
                                                                        <asp:TextBox ID="txtRemarksBuilding" class="control-textbox" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left">Plant & Machinary</td>
                                                                    <td align="center" id="Td8" runat="server">
                                                                        <label id="lblDPRPM" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" style="width: 3%" id="Td9" runat="server">
                                                                        <label id="lblUnitInvPM" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td10" style="width: 3%" runat="server" align="center">
                                                                        <asp:TextBox ID="txtDLOInvPM" class="control-textbox" AutoPostBack="True" OnTextChanged="txtDLOInvTotal_TextChanged" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td id="Td11" runat="server" style="width: 3%" align="center">
                                                                        <asp:TextBox ID="txtCompInvPM" class="control-textbox" AutoPostBack="True" OnTextChanged="txtDLOInvTotal_TextChanged" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td id="Td12" runat="server" style="width: 3%" align="center">
                                                                        <asp:TextBox ID="txtRemarksPM" class="control-textbox" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td></td>
                                                                    <td align="left">Total</td>
                                                                    <td align="center" runat="server">
                                                                        <label id="lblDPRTotal" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" style="width: 3%" id="Td14" runat="server">
                                                                        <label id="lblUnitInvTotal" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td15" style="width: 3%" runat="server" align="center">
                                                                        <label id="lblDLOInvTotal" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td16" runat="server" style="width: 3%" align="center">
                                                                        <label id="lblCompInvTotal" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td runat="server" style="width: 3%" align="center"></td>
                                                                </tr>
                                                            </table>
                                                            <table class="table table-bordered title6  w-100 NewEnterprise" id="tblBindInvestment" style="margin: 10px 0px 0px 91px;" visible="false" runat="server">

                                                                <h6 class="col-sm-12 text-black font-SemiBold mb-1" style="margin: 10px 0px 0px 91px;">24. Fixed Capital Investment</h6>
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Components</th>
                                                                    <th>Approved Project
                                                                        <br />
                                                                        Cost as per DPR</th>
                                                                    <th>Investment of the Unit</th>
                                                                    <th>Investment Recommended by the AD/DLO</th>
                                                                    <th>Eligible Investment Computed</th>
                                                                    <th>Remarks</th>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="left">Land</td>
                                                                    <td align="center" id="Td3" runat="server">
                                                                        <label id="lblDPRLandPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" style="width: 3%" runat="server">
                                                                        <label id="lblUnitInvLandPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td style="width: 3%" runat="server" align="center">
                                                                        <label id="lblDLOInvLandPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td13" runat="server" style="width: 3%" align="center">
                                                                        <label id="lblCompInvLandPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td17" runat="server" style="width: 3%" align="center">
                                                                        <label id="lblRemarksLandPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>2</td>
                                                                    <td align="left">Building</td>
                                                                    <td align="center" runat="server">
                                                                        <label id="lblDPRBuildingPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" style="width: 3%" id="Td18" runat="server">
                                                                        <label id="lblUnitInvBuildingPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td19" style="width: 3%" runat="server" align="center">
                                                                        <label id="lblDLOInvBuildingPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td20" runat="server" style="width: 3%" align="center">
                                                                        <label id="lblCompInvBuildingPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td21" runat="server" style="width: 3%" align="center">
                                                                        <label id="lblRemarksBuildingPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left">Plant & Machinary</td>
                                                                    <td align="center" id="Td22" runat="server">
                                                                        <label id="lblDPRPMPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" style="width: 3%" id="Td23" runat="server">
                                                                        <label id="lblUnitInvPMPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td24" style="width: 3%" runat="server" align="center">
                                                                        <label id="lblDLOInvPMPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td25" runat="server" style="width: 3%" align="center">
                                                                        <label id="lblCompInvPMPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td26" runat="server" style="width: 3%" align="center">
                                                                        <label id="lblRemarksPMPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td></td>
                                                                    <td align="left">Total</td>
                                                                    <td align="center" runat="server">
                                                                        <label id="lblDPRTotalPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" style="width: 3%" id="Td27" runat="server">
                                                                        <label id="lblUnitInvTotalPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td28" style="width: 3%" runat="server" align="center">
                                                                        <label id="lblDLOInvTotalPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="Td29" runat="server" style="width: 3%" align="center">
                                                                        <label id="lblCompInvTotalPrint" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td runat="server" style="width: 3%" align="center"></td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div class="col-sm-10 table-responsive" runat="server" id="divCapital" visible="false">
                                                            <div id="divtblInputOthers" runat="server" visible="true">
                                                                <h6 class="col-sm-12 text-black font-SemiBold mb-1" style="margin: 10px 0px 0px 8px;">24. Fixed Capital Investment</h6>
                                                                <table class="table table-bordered title6  w-100 NewEnterprise" id="tblInputOthers" style="margin: 10px 0px 0px 91px;">
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">25</td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:TextBox ID="txt25" Width="100%" class="control-textbox" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">26</td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:TextBox ID="txt26" Width="100%" class="control-textbox" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">1)</td>
                                                                        <td align="left" style="width: 22%">Eligible Fixed Capital Investment</td>
                                                                        <td align="left" style="width: 25%">
                                                                            <asp:TextBox ID="txtEFCI" class="control-textbox" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">2)</td>
                                                                        <td align="left" style="width: 22%">25% of Fixed Capital Investment</td>
                                                                        <td align="left" style="width: 25%">
                                                                            <asp:TextBox ID="txt25FCI" class="control-textbox" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">3)</td>
                                                                        <td align="left" style="width: 22%">Addl.subsidy for Women Enterpreneurs@5%</td>
                                                                        <td align="left" style="width: 25%">
                                                                            <asp:TextBox ID="txtAddlWE5" class="control-textbox" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">4)</td>
                                                                        <td align="left" style="width: 22%">Total Eligible Capital Subsidy</td>
                                                                        <td align="left" style="width: 25%">
                                                                            <asp:TextBox ID="txtTECS" class="control-textbox" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">27</td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:TextBox ID="txt27" Width="100%" class="control-textbox" TextMode="MultiLine" runat="server">Conditions fulfilled by the Unit</asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">28</td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:TextBox ID="txt28" Width="100%" class="control-textbox" TextMode="MultiLine" runat="server">Remarks :</asp:TextBox>
                                                                        </td>
                                                                </table>
                                                            </div>
                                                            <div id="divtblBindOthers" runat="server" visible="false">
                                                                <table class="table table-bordered title6  w-100 NewEnterprise" id="tblBindOthers" style="margin: 10px 0px 0px 91px;" visible="false">
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">25</td>
                                                                        <td align="left" colspan="2">
                                                                            <label id="lbl25Prints" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">26</td>
                                                                        <td align="left" colspan="2">
                                                                            <label id="lbl26Prints" runat="server" class="control-label"></label>

                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">1)</td>
                                                                        <td align="left" style="width: 22%">Eligible Fixed Capital Investment</td>
                                                                        <td align="left" style="width: 25%">
                                                                            <label id="lblEFCIPrint" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">2)</td>
                                                                        <td align="left" style="width: 22%">25% of Fixed Capital Investment</td>
                                                                        <td align="left" style="width: 25%">
                                                                            <label id="lbl25FCIprint" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">3)</td>
                                                                        <td align="left" style="width: 22%">Addl.subsidy for Women Enterpreneurs@5%</td>
                                                                        <td align="left" style="width: 25%">
                                                                            <label id="lblAddlWE5Print" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">4)</td>
                                                                        <td align="left" style="width: 22%">Total Eligible Capital Subsidy</td>
                                                                        <td align="left" style="width: 25%">
                                                                            <label id="lblTECSPrint" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">27</td>
                                                                        <td align="left" colspan="2">
                                                                            <label id="lbl27Print" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">28</td>
                                                                        <td align="left" colspan="2">
                                                                            <label id="lbl28Print" runat="server" class="control-label"></label>
                                                                        </td>
                                                                </table>
                                                            </div>
                                                        </div>
                                                        <div runat="server" id="divMainInterest" style="margin: 10px 0px 0px 91px;" visible="false">
                                                            <div runat="server" visible="true" id="divInputInterest" width="50%">
                                                                <h6 class="col-sm-12 text-black font-SemiBold mb-1" style="margin: 10px 0px 0px 8px;">25. Details of Term Loan availed by the Unit duly by the financial Institution</h6>
                                                                <div class="row">
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Financial Year & Half year</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtYear" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Bank / FI</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtBank" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Loan A/C No.</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtLoanAcNo" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Sanction Order No& Date</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtSanctionOrder" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Amount Sanctioned</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtAmountSanctioned" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Rate of Interest(%)</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtRateofInterest" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Term Loan Disbursed</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtTermLoanDisbursed" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Term Loan Outstanding Balance</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtTermLoanOutstandingBalance" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Term Loan Paid as per Certificate</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtTermLoanPaidCertificate" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-12 text-center">
                                                                        <asp:Button Text="Add" CssClass="btn btn-blue ml-2 px-4 py-1 title5" OnClick="btnAddInterest_Click" ID="btnAddInterest" runat="server" /></td>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div runat="server" id="divInputInterestGrid" class="col-sm-10 table-responsive">
                                                                <h6 class="col-sm-12 text-black font-SemiBold mb-1" style="margin: 10px 0px 0px 8px;">25. Details of Term Loan availed by the Unit duly by the financial Institution</h6>
                                                                <asp:GridView runat="server" ID="GVTermLoandtls" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                                <asp:Label ID="lblAvailedTermLoan" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date of Application for Term Loan </br>(3)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanApplDate" runat="server" Text='<%# Bind("Bank") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Institution Name </br>(4)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstitutionName" runat="server" Text='<%# Bind("LoanACNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Term Loan Sanc RefNo </br> (5)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanSancRefNo" runat="server" Text='<%# Bind("SanctionOrderNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Term Loan Sanction Date </br> (6)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermloanSandate" runat="server" Text='<%# Bind("AmountSanctioned") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sanctioned Amount </br>(7)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSanctionedAmount" runat="server" Text='<%# Bind("RateofInterest") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Term Loan Account No. </br>(8)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermAccountNo" Text='<%# Bind("Disbursed") %>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Term Loan First Release Date </br>(9)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanReleaseddate" runat="server" Text='<%# Bind("OutstandingBalance") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Term Loan First Release Amount </br>(10)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanReleaseddate" Text='<%# Bind("Paidaspercertificate") %>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>

                                                                </asp:GridView>
                                                            </div>
                                                            <div runat="server" visible="true" id="divInterestSanctionInput" width="50%">
                                                                <h6 class="col-sm-12 text-black font-SemiBold mb-1" style="margin: 10px 0px 0px 8px;">26. Details of Interest Subsidy already Sanctioned</h6>
                                                                <div class="row">
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Financial Year
                                                                        </label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtYearSancioned" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Half Year</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtHalf" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Amount</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtAmount" Width="80%" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-12 text-center">
                                                                        <asp:Button Text="Add" CssClass="btn btn-blue ml-2 px-4 py-1 title5" OnClick="btnAddSanctionIntrest_Click" ID="btnAddSanctionIntrest" runat="server" /></td>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div runat="server" id="divInterestSanctionInputGrid" class="col-sm-10 table-responsive">
                                                                <h6 class="col-sm-12 text-black font-SemiBold mb-1" style="margin: 10px 0px 0px 8px;">26. Details of Interest Subsidy already Sanctioned</h6>
                                                                <asp:GridView runat="server" ID="gvIntSanction" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                        <asp:TemplateField HeaderText="Year </br>(2)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAvailedTermLoan" runat="server" Text='<%# Bind("Year") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Half Year </br>(3)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanApplDate" runat="server" Text='<%# Bind("HalYear") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sanctioned Amount </br>(4)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstitutionName" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>

                                                                </asp:GridView>
                                                            </div>
                                                            <div id="divInputIntExtraFileds" runat="server" visible="true" style="width: 88%;">
                                                                <table class="table table-bordered title6  w-100 NewEnterprise" id="tblInputIntExtraFileds" style="margin: 10px 0px 0px 6px;">
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">27</td>
                                                                        <td align="left" colspan="2">
                                                                            <asp:TextBox ID="txtIntExtra" Width="100%" class="control-textbox" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div id="divIntExtraFiledsPrint" runat="server" visible="false" style="width: 88%;">
                                                                <table class="table table-bordered title6  w-100 NewEnterprise" id="tblBindInputIntExtraFileds" style="margin: 10px 0px 0px 6px;" visible="false">
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 3%">27</td>
                                                                        <td align="left" colspan="2">
                                                                            <label id="lblIntExtraPrint" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-10 table-responsive" runat="server" id="divMainPower" style="margin: 10px 0px 0px 0px;" visible="false">

                                                            <table class="table table-bordered title6  w-100 NewEnterprise" style="margin: 0px 0px 0px 91px;">
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td align="center" style="width: 3%">25</td>
                                                                    <td align="left" style="width: 10%">Date of Power Consumption Released</td>
                                                                    <td align="left" style="width: 25%">
                                                                        <label class="control-label" id="lblPowerCnsptionRlsd" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td align="center" style="width: 3%">26</td>
                                                                    <td align="left" style="width: 10%">Service Connection No.</td>
                                                                    <td align="left" style="width: 25%">
                                                                        <label class="control-label" id="lblServiceConnectionNo" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td align="center" style="width: 3%">27</td>
                                                                    <td align="left" style="width: 10%">Connected Load</td>
                                                                    <td align="left" style="width: 25%">
                                                                        <label class="control-label" id="lblConnectedLoad" runat="server"></label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button Text="Generate Apprasial" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnCreateAppraisal" OnClick="btnCreateAppraisal_Click" runat="server" />
                                                    <asp:HiddenField runat="server" ID="hdnIncentiveId" Value="0" />
                                                    <%--<asp:Button Text="Print" CssClass="btn btn-blue ml-2 px-4 py-1 title5"  ID="BtnPrint" Visible="false" runat="server" />--%>
                                                    <%--<asp:Button Text="PRT" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="Button1" OnClientClick="return Print();" runat="server" />--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        
    </style>
    <script type="text/javascript">

        jQuery(document).bind("keyup keydown", function (e) {
            if (e.ctrlKey && e.keyCode == 80) {
                $('#ContentPlaceHolder1_btnCreateAppraisal').hide();
                print();
                $('#ContentPlaceHolder1_btnCreateAppraisal').show();
                return false;
            }
        });

        function Print() {
            $('#ContentPlaceHolder1_divSelection').hide();
            $('#content-header').hide();
            $('.header').hide();
            $('#ContentPlaceHolder1_BtnPrint').hide();
            $('.container').hide();
            print();
            $('#ContentPlaceHolder1_divSelection').show();
            $('#content-header').show();
            $('.header').show();
            $('#ContentPlaceHolder1_BtnPrint').show();
            $('.container').show();
            return false;
        }


        var AppTemp = []; var AppTempSanction = [];
        function AddApplication() {
            var ObjApp = { Year: '', Bank: '', LoanACNo: '', SanctionOrderNo: '', AmountSanctioned: '', RateofInterest: '', Disbursed: '', OutstandingBalance: '', Paidaspercertificate: '' };
            ObjApp.Year = $('#ContentPlaceHolder1_txtYear').val();
            ObjApp.Bank = $('#ContentPlaceHolder1_txtBank').val();
            ObjApp.LoanACNo = $('#ContentPlaceHolder1_txtLoanAcNo').val();
            ObjApp.SanctionOrderNo = $('#ContentPlaceHolder1_txtSanctionOrder').val();
            ObjApp.AmountSanctioned = $('#ContentPlaceHolder1_txtAmountSanctioned').val();
            ObjApp.RateofInterest = $('#ContentPlaceHolder1_txtRateofInterest').val();
            ObjApp.Disbursed = $('#ContentPlaceHolder1_txtTermLoanDisbursed').val();
            ObjApp.OutstandingBalance = $('#ContentPlaceHolder1_txtTermLoanOutstandingBalance').val();
            ObjApp.Paidaspercertificate = $('#ContentPlaceHolder1_txtTermLoanPaidCertificate').val();
            AppTemp.push(ObjApp);
            $('#ContentPlaceHolder1_txtYear').val('');
            $('#ContentPlaceHolder1_txtLoanAcNo').val('');
            $('#ContentPlaceHolder1_txtSanctionOrder').val('');
            $('#ContentPlaceHolder1_txtAmountSanctioned').val('');
            $('#ContentPlaceHolder1_txtRateofInterest').val('');
            $('#ContentPlaceHolder1_txtTermLoanDisbursed').val('');
            $('#ContentPlaceHolder1_txtTermLoanOutstandingBalance').val('');
            $('#ContentPlaceHolder1_txtTermLoanPaidCertificate').val('');
            CreateAppAddTables();
            return false;
        }
        function AddApplicationSanction() {
            var ObjApp = { Year: '', HY: '', Amount: '' };
            ObjApp.Year = $('#ContentPlaceHolder1_txtYearSancioned').val();
            ObjApp.HY = $('#ContentPlaceHolder1_txtHalf').val();
            ObjApp.Amount = $('#ContentPlaceHolder1_txtAmount').val();
            AppTempSanction.push(ObjApp);
            $('#ContentPlaceHolder1_txtYearSancioned').val('');
            $('#ContentPlaceHolder1_txtHalf').val('');
            $('#ContentPlaceHolder1_txtAmount').val('');
            CreateAppAddTablesSan();
            return false;
        }

        function CreateAppAddTables() {
            var Sno = "0"; ClearTable();
            $.each(AppTemp, function (i, j) {
                Sno = parseFloat(Sno) + parseFloat(1);
                var _Tr = '<tr class=\"GridviewScrollC1Item\" id=' + i + '><td>' + AppTemp[i].Year + '</td><td>' + AppTemp[i].Bank + '</td><td>' + AppTemp[i].LoanACNo + '</td><td>' + AppTemp[i].SanctionOrderNo +
                    '</td><td>' + AppTemp[i].AmountSanctioned + '</td><td>' + AppTemp[i].RateofInterest + '</td><td>' + AppTemp[i].Disbursed + '</td><td>' + AppTemp[i].OutstandingBalance +
                    '</td><td>' + AppTemp[i].Paidaspercertificate + '</td><td><input type="button" value="Delete" class=\"alert-danger\" style=\"cursor:pointer\" title=\"Delete\"  onclick=\"RemoveData(' + i + ')\"  /> </td></tr>';
                $('#tempGrd tbody').append(_Tr);

                var _Tr1 = '<tr class=\"GridviewScrollC1Item\" id=' + i + '><td>' + AppTemp[i].Year + '</td><td>' + AppTemp[i].Bank + '</td><td>' + AppTemp[i].LoanACNo + '</td><td>' + AppTemp[i].SanctionOrderNo +
                    '</td><td>' + AppTemp[i].AmountSanctioned + '</td><td>' + AppTemp[i].RateofInterest + '</td><td>' + AppTemp[i].Disbursed + '</td><td>' + AppTemp[i].OutstandingBalance +
                    '</td><td>' + AppTemp[i].Paidaspercertificate + '</td></tr>';
                $('#InterestGridPrint tbody').append(_Tr1);

            });

        }

        function CreateAppAddTablesSan() {
            var Sno = "0"; ClearTableSan();
            $.each(AppTempSanction, function (i, j) {
                Sno = parseFloat(Sno) + parseFloat(1);
                var _Tr = '<tr class=\"GridviewScrollC1Item\" id=' + i + '><td>' + Sno + '</td><td>' + AppTempSanction[i].Year + '</td><td>' + AppTempSanction[i].HY + '</td><td>' + AppTempSanction[i].Amount +
                    '</td><td><input type="button" value="Delete" class=\"alert-danger\" style=\"cursor:pointer\" title=\"Delete\"  onclick=\"RemoveDataSan(' + i + ')\"  /> </td></tr>';
                $('#tblInterestSanctionedGrid tbody').append(_Tr);

                var _Tr1 = '<tr class=\"GridviewScrollC1Item\" id=' + i + '><td>' + Sno + '</td><td>' + AppTempSanction[i].Year + '</td><td>' + AppTempSanction[i].HY + '</td><td>' + AppTempSanction[i].Amount +
                    '</td></tr>';
                $('#tblInterestSanctionedGridPrint tbody').append(_Tr1);

            });

        }

        var RemoveData = function (obj) {
            $('table#tempGrd tr#' + obj).remove();
            $('table#InterestGridPrint tr#' + obj).remove();
            AppTemp.splice(obj, 1);
            CreateAppAddTables();
            return false;

        }
        var RemoveDataSan = function (obj) {
            $('table#tblInterestSanctionedGrid tr#' + obj).remove();
            $('table#tblInterestSanctionedGridPrint tr#' + obj).remove();
            AppTemp.splice(obj, 1);
            CreateAppAddTables();
            return false;

        }
        var ClearTable = function () {
            var GvBin = document.getElementById('tempGrd');
            if (GvBin != null) {
                for (var i = GvBin.rows.length; i > 1; i--)
                    GvBin.deleteRow(i - 1);
            }
            var GvBin = document.getElementById('InterestGridPrint');
            if (GvBin != null) {
                for (var i = GvBin.rows.length; i > 1; i--)
                    GvBin.deleteRow(i - 1);
            }
        }
        var ClearTableSan = function () {
            var GvBin = document.getElementById('tblInterestSanctionedGrid');
            if (GvBin != null) {
                for (var i = GvBin.rows.length; i > 1; i--)
                    GvBin.deleteRow(i - 1);
            }
            var GvBin = document.getElementById('tblInterestSanctionedGridPrint');
            if (GvBin != null) {
                for (var i = GvBin.rows.length; i > 1; i--)
                    GvBin.deleteRow(i - 1);
            }
        }
        function Generate() {
            /*for (var i = 0; i < AppTemp.length; i++) {
                var ApplicationNo = AppTemp[i].AppNo;
                GetUnitData(ApplicationNo);
            }
            $.each(AppTemp, function (i, j) {
                var ApplicationNo = AppTemp[i].AppNo;
                GetUnitData(ApplicationNo);
               
            });*/

            for (key in AppTemp) {
                if (key < AppTemp.length) {
                    var ApplicationNo = AppTemp[key].AppNo;
                    GetUnitData(ApplicationNo);
                }
            }

        }
        //JSON.stringify({'ApplicationNo':Id}),
        /* function GetUnitData(Id) {
             $.ajax({
                 type: "POST",
                 url: "FormCreateAgenda.aspx/GetData",
                 data: JSON.stringify({'ApplicationNo':Id}),
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: CreateAgenda,
                 failure: function (response) {
                     alert(response.d);
                 },
                 error: function (response) {
                     alert(response.d);
                 }
             });
         }*/

        var DataTemp = [];
        function GetUnitData(Id) {
            GetAsync("FormCreateAgenda.aspx/GetData",
                { ApplicationNo: Id },
                function (jdata) {
                    var input = jQuery.parseJSON(jdata.d);
                    var ObjData = { UnitName: '' };
                    ObjData.UnitName = input[0].UnitName;
                    DataTemp.push(ObjData);
                    //$('#ContentPlaceHolder1_btnTable').show();
                },
                function () {
                });
        }
        function GenerateTable1() {
            /*$.each(DataTemp, function (i, j) {
                var _Tr = '<tr class=\"GridviewScrollC1Item\" id=1><td>1</td><td>Unit Name</td><td>' + DataTemp[i].UnitName + '</td></tr>';
                $('#tblAgend').append(_Tr);
            });*/
        }

        function GenerateTable() {
            var tbl = document.getElementById("tblAgend")
            var table_data = '';
            for (i = 0; i < DataTemp.length; i++) {
                table_data += '';
                table_data += '' + DataTemp[i].UnitName + '';
                /*table_data += '' + DataTemp[i].Description + '';
                table_data += '' + 'R' + DataTemp[i].Price + '';*/
                table_data += '';
            }
            tbl.insertAdjacentHTML('afterbegin', table_data);
        }
        function GetNonAsync(_url, params, csuccess, cfail) {
            $.ajax({
                type: "POST",
                url: _url,
                dataType: "json",
                async: false,
                data: JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                error: function (jqXHR, textStatus, errorThrown) {
                    cfail(jqXHR, textStatus, errorThrown);
                },
                success: function (JData) {
                    csuccess(JData);
                }
            });
        };
        function GetAsync(_url, params, csuccess, cfail) {
            $.ajax({
                type: "POST",
                url: _url,
                dataType: "json",
                data: JSON.stringify(params),
                contentType: "application/json; charset=utf-8",
                error: function (jqXHR, textStatus, errorThrown) {
                    cfail(jqXHR, textStatus, errorThrown);
                },
                success: function (JData) {
                    csuccess(JData);
                }
            });
        };
    </script>

</asp:Content>
