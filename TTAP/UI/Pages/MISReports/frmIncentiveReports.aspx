<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmIncentiveReports.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.frmIncentiveReports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #reports {
            margin-top: 76px;
        }

        .main {
            min-height: 60vh !important;
        }

        .badge-primary {
            color: #007bff !important;
            background-color: #fff !important;
        }

        .col-md-6 {
            -ms-flex: 0 0 50%;
            flex: 0 0 50%;
            max-width: 100%;
        }

        .column {
            float: left;
            width: 50%;
            padding: 22px;
        }
    </style>
    <section id="reports">

        <div class="container" style="margin: -61px 0px 8px 108px;">
            <div class="row">
                <div class="col-md-12 pb-4" align="center">
                    <h4>MIS Reports</h4>
                </div>
                <div class="col-md-12" style="display: flex; border-style: solid; border-radius: 20px; border: solid #356fc5; margin-top: -20px;" runat="server" id="divAdmn">
                    <div class="column" id="divReport1" runat="server">
                        <div class="col-md-6">
                            <ul class="list-group">
                                <a href="frmIncentiveAbstract.aspx">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R1. District Wise Report
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>

                                <a href="frmInsDetailedReport.aspx">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R2. Submitted Applications - Detailed Report
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>

                                <a href="FormIncentiveWiseAbstract.aspx">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R3. Incentive Wise Detailed Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="FrmUnitWiseReportAbstract.aspx">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R4. Unit/Incentive Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="FormUnitReport.aspx">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R5. Unit Report
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                            </ul>
                        </div>

                    </div>
                    <div class="column" id="divReport2" runat="server">
                        <div class="col-md-6">
                            <ul class="list-group">

                                <a href="RejectedApplicationsDetails.aspx" runat="server" id="lnkR6Report">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R6. Rejected Applications
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="FrmDloPendingReportAbstract.aspx" runat="server" id="lnkR7Report">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R7. Incentives Pending with DLO  Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="FrmNatureWiseReportAbstract.aspx" runat="server" id="lnkR8Report">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R8. Type Of Textile/Nature of Industry/Category Wise Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="DashboardReport.aspx" runat="server" id="lnkR9Report">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R9. Status Report
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="FrmSLCDeatailedReport.aspx" runat="server" id="lnkR10Report">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R10. SLC Detailed Report
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                            </ul>
                        </div>
                    </div>
                    <div class="column" runat="server" id="divReport3">
                        <div class="col-md-6">
                            <ul class="list-group">

                                <a href="AdoDistrictWiseAbstract.aspx" runat="server" id="lnkR11Report">
                                    <li class="list-group-item d-flex justify-content-between align-items-center" runat="server" id="liR11Report">R11. AD Wise Incentive Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="CapitalSubsiyReportAbstract.aspx" runat="server" id="lnkR12Report">
                                    <li class="list-group-item d-flex justify-content-between align-items-center" runat="server" id="liR12Report">R12. Capital Subsidy Applied Units Status Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="FormSanctionReport.aspx" runat="server" visible="false" id="aSanction">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R13. Sanctions Report
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="InspectionsReportAbstract.aspx" runat="server" id="lnkR14Report">
                                    <li class="list-group-item d-flex justify-content-between align-items-center" runat="server" id="liR14Report">R14. Incentive Applications With DLO Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-md-12" style="display: flex; border-style: solid; border-radius: 20px; border: solid #356fc5; margin-top: -20px;" runat="server" visible="false" id="divDLO">
                    <div class="column" runat="server" id="Reportdiv1">
                        <div class="col-md-6">
                            <ul class="list-group">

                                <a href="AdoDistrictWiseAbstract.aspx" runat="server" id="A1">
                                    <li class="list-group-item d-flex justify-content-between align-items-center" runat="server" id="li1">R1.Incentive Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="CapitalSubsiyReportAbstract.aspx" runat="server" id="A2">
                                    <li class="list-group-item d-flex justify-content-between align-items-center" runat="server" id="li2">R2. Capital Subsidy Applied Units Status Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="InspectionsReportAbstract.aspx" runat="server" id="A4">
                                    <li class="list-group-item d-flex justify-content-between align-items-center" runat="server" id="li3">R3. Incentive Applications With DLO Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="FormUnitReport.aspx" runat="server" id="A5">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R4. Unit Report
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                                <a href="FrmNatureWiseReportAbstract.aspx" runat="server" id="A3">
                                    <li class="list-group-item d-flex justify-content-between align-items-center">R5. Type Of Textile/Nature of Industry/Category Wise Abstract
    <span class="badge badge-primary badge-pill"><i class="fa fa-table" aria-hidden="true"></i>

    </span>
                                    </li>
                                </a>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
