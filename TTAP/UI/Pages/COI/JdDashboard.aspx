<%@ Page Title="JD Dashboard" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="JdDashboard.aspx.cs" Inherits="TTAP.UI.Pages.COI.JdDashboard" %>

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
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="divdashboardheadername" runat="server">Joint Director Dashboard</h5>
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
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="JdApplications.aspx?Stg=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>No of Applications Received from G.M</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblAppsRcvdFrmGM" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Scrutiny Pending</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=SCRUTINYPENDINGWITHIN">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblScrntyPendingWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=SCRUTINYPENDINGBEYOND">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblScrntyPendingBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=SCRUTINYPENDINGTOTAL">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblScrntypendingTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=QUERIESRESPNDED_PENDINGTOTAL">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Yet to Respond </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblQueryYettoRspnd" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=QUERIESRESPNDEDWITHIN">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Within</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRepliedQueryWITHIN" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=11">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Beyond</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRepliedQueryBEYOND" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=QUERIESRESPNDED">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Queries Responded </span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblTotalQueryRspnd" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                    </div>
                                </div>
                            </div>
                            <div class="row" id="Div1" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Applications Forwarded from AD/DD</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=FWDFROMAD_DDWITHIN">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblFwdFrmADDDWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=FWDFROMAD_BEYOND">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblFwdFrmADDDbeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=FWDFROMAD_DDWITHIN">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblTotalFwdFrmADDD" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=10">
                                            <span><i class="fa fa-fw fa-calendar"></i>Departments Returned Applications-SVC</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblDeptRtrndAppsSVC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=10">
                                            <span><i class="fa fa-fw fa-calendar"></i>Departments Processed Applications (SVC)</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblDeptPrcsdAppsSVC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <%--  <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Incentive (Application Stage)</b> </a>--%>
                                        <%-- <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="frmJDApplications.aspx?Stg=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Auto Rejected</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                            </span>
                                        </a>--%>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Within</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblQueriesRespWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Beyond</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblQueriesRespBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=7">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Queries Responded </span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblTotalQueriesRspndd" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Applications kept Abeyance at Superintendent</span>

                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Abeyance Applications </span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblAbeyance" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="Div6" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg" href="JDApplications.aspx?Stg=ADDLReturned">
                                            <span><i class="fa fa-fw fa-check"></i>Applications Returned from ADDL</span>
                                             <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblADDLReturned" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="Div2" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Scrutiny Completed & Forwarded to Additional Director</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblScrtnyCompFwdtoAddlWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JDApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblScrtnyCompFwdtoAddlBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JDApplications.aspx?Stg=11">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblTotScrtnyCompFwdtoAddl" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected Applications</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRejected" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Status of Applications at Additional Director</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Abeyance Applications </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalAbeyance" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected at Pre-SVC </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRjctedpreSVC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=11">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected at SVC</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRjctedSVC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected at SLC </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRjctdSLC" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                    </div>
                                </div>
                            </div>
                            <div>
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                            <div class="row" id="Div3" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries from Additional Director</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Not Yet Responded by GM</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblQrsNotRespbyGM" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded by GM</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblQrsRespbyGM" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total -Queries Responded by JD</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalQrsRespbyJD" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total - Query Raised by Additional Director</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblQrsRasiedbyADD" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                            <div class="row" id="Div4" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="../SLC/ISLCSactionedApplications.aspx?Stg=8">
                                            <span><i class="fa fa-fw fa-calendar"></i>Approved by SLC</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblApprovedSLC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Releases</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Print SLC Release Proceedings Completed List</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblSLCRlsProceed" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Working Status</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Working Status Updated by Gm's </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblWrkStatusbyGM" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Working Status Not Updated by Gm's</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblWrkStatusNotbyGM" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Approved by DIPC</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblApprovedDIPC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Releases</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Print DIPC Release Proceedings Completed List </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblDIPCRlsProceed" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>UC List</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Working Status Updated by Gm's </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblWrkStatusbyGMDIPC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Working Status Not Updated by Gm's</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblWrkStatusNotbyGMDIPC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="Div5" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Cheque Preparation</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Pending for generating Cheque</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblPndngGenCheque" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Generated Cheque Preparation</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblGenCheque" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Update Cheque Details</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Upload Cheque Details for SLC </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblUploadChequeSLC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Upload Cheque Clearence Details</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblChequeClearence" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Update Cheque Details New</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details Not Uploaded </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblNotUplodedCheques" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details Cheque Number</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblChequeNumber" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Details with UTR Number</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblChequeUTR" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Cheque Preparation</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Pending for generating Cheque for DIPC </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblPndngGenChequeDIPC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Generated Cheque Preparation  </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblGenChequeDIPC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Update Cheque Details</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Upload Cheque Details for DIPC  </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblUploadChequeDIPC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Upload Cheque Clearence Details for DIPC </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblChequeClearenceDIPC" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <br />
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Update Cheque Details</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Enter UTR Details with Cheque No  </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblUTRWithCheque" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Cheque Status  </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblChequeStatus" runat="server"></asp:Label>
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

