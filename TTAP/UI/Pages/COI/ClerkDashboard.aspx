<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="ClerkDashboard.aspx.cs" Inherits="TTAP.UI.Pages.COI.ClerkDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <link href="../../NewCss/css/bootstrap.min.css" rel="stylesheet" />--%>
    <%-- <link href="../../css/bootstrap.min.css" rel="stylesheet" />--%>
    <%-- <link href="../../css/DashboardCss/bootstrap.min.css" rel="stylesheet" />--%>
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
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="divdashboardheadername" runat="server">Clerk Dashboard</h5>
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
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="ClerkApplications.aspx?status=TOTALNOOFAPPLICATIONS">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Proposals Received From GM</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblGMTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Yet to Process</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=PSCPENDINGWITHIN">
                                            <span><i class="fa fa-fw fa-calendar"></i>Scrutiny Pending Within</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblPendingWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=PSCPENDINGBEYOND">
                                            <span><i class="fa fa-fw fa-calendar"></i>Scrutiny Pending Beyond</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblPendingBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=PSCPENDINGTOTAL">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblpendingTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=TOTALAPPLRETURNEDFROMSUPDT">
                                            <span><i class="fa fa-fw fa-calendar"></i>Superitendent Returned</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="SUPDTRETURNED" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRAISEDBYJD">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Yet to Respond</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblQueryRes" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRESPNDEDWITHIN">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Within</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblQueryWITHIN" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRESPNDEDBEYOND">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Beyond</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblQueryBEYOND" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRESPNDED">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Queries Responded</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblTotalQueryRes" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=TOTALAUTOREJECTED">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Auto Rejected</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblTotalRejected" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>

                            <div class="row" id="Div1" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Scrutiny Completed and Forwarded</span>
                                        </a>
                                        <%--    <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=TOTALAPPLRECOMMENDTOSUPDT">
                                            <span><i class="fa fa-fw fa-calendar"></i>Recommended to Superintendent</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblrmdtosupdnt" runat="server"></asp:Label>
                                            </span>
                                        </a>--%>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=TOTALAPPLFORWARDEDTOSUPDT">
                                            <span><i class="fa fa-fw fa-calendar"></i>Send to Superintendent</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSendSUPDT" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                      <%--  <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=TOTALAPPLQUERYTOSUPDT" id="total" runat="server" visible="false">
                                            <span><i class="fa fa-fw fa-calendar"></i>Query Forwarded to Superintendent</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblfrwdedtosupdnt" runat="server"></asp:Label>
                                            </span>
                                        </a>--%>

                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries Responded and Received</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRESPNDED_PENDINGWITHIN">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Scrutiny Pending within</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblQRSPW" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRESPNDED_PENDINGBEYOND">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Scrutiny Pending Beyond</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblQRSPB" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRESPNDED_PENDINGTOTAL">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Scrutiny Pending Total</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblQRSPTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRESPNDED_RETURNEDFROMSUPDT">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Returned form SUPDT/ADDL</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblQRRSUPDT" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>

                                    <br />
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries Responded / Forwarded</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="ClerkApplications.aspx?status=QUERIESRESPNDED_FORWARDEDTOSUPDT">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Forwarded to Superintentdent</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblQRForwardSUPDT" runat="server"></asp:Label>
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
