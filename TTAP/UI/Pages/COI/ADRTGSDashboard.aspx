<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="ADRTGSDashboard.aspx.cs" Inherits="TTAP.UI.Pages.COI.ADRTGSDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../../css/DashboardCss/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <style>
        .page-head-linenew {
            font-size: 2px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 2px;
            border-bottom: 4px solid #00CA79;
            margin-bottom: 35px;
        }

        .page-subhead-linenew {
            font-size: 14px;
            padding-top: 5px;
            padding-bottom: 20px;
            font-style: italic;
            margin-bottom: 30px;
            border-bottom: 1px dashed #00CA79;
        }
    </style>

    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>

            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">DashBoard</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">DashBoard</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="divdashboardheadername" runat="server">Dashboard</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 mb-4 d-none">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-blue" Font-Size="Small" NavigateUrl="~/UI/Pages/frmDashBoard.aspx"><i class="fa fa-angle-left"></i> Back</asp:HyperLink>
                                </div>
                            </div>

                            <div class="row" id="trsection1" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <%--  <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Incentive (Application Stage)</b> </a>--%>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_Approved&Type=SLC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Approved by SLC</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblSLC_Approved" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Releases</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_ReleaseProcCompleted&Type=SLC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Print SLC Release Proceedings Completed List</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSLC_ReleaseProcCompleted" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>

                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>UC List</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_UCUpdated&Type=SLC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Print-UC Updated List</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSLC_UCUpdated" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_UCNotUpdated">
                                            <span><i class="fa fa-fw fa-calendar"></i>Print-UC Not Updated List</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSLC_UCNotUpdated" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                    </div>

                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Cheque Preparation List</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_ToGenerateCheque&Type=SLC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Generate Cheque Preparation List</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSLC_ToGenerateCheque" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_GeneratedCheque&Type=SLC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Generated Cheque Preparation List</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSLC_GeneratedCheque" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Update Cheque Details New</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_ChequeNotUploaded&Type=SLC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details Not Uploaded</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSLC_ChequeNotUploaded" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_Cheque_withNo&Type=SLC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details Cheque Number</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSLC_Cheque_withNo" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=SLC_Cheque_withUTR&Type=SLC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details with UTR Number</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSLC_Cheque_withUTR" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>

                                </div>

                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <%--  <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Incentive (Application Stage)</b> </a>--%>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_Approved&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Approved by DIPC</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblDIPC_Approved" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Releases</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_ReleaseProcCompleted&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Print DIPC Release Proceedings Completed List</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPC_ReleaseProcCompleted" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>

                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>UC List</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_UCUpdated&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Print-UC Updated List</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPC_UCUpdated" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_UCNotUpdated&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Print-UC Not Updated List</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblDIPC_UCNotUpdated" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                    </div>

                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Cheque Preparation List</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_ToGenerateCheque&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Generate Cheque Preparation List</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblDIPC_ToGenerateCheque" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_GeneratedCheque&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Generated Cheque Preparation List</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPC_GeneratedCheque" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Update Cheque Details New</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_ChequeNotUploaded&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details Not Uploaded</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblDIPC_ChequeNotUploaded" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_Cheque_withNo&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details Cheque Number</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPC_Cheque_withNo" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ADRTGSDashboardDrilldown.aspx?status=DIPC_Cheque_withUTR&Type=DIPC">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details with UTR Number</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPC_Cheque_withUTR" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hdfID" runat="server" />
                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
