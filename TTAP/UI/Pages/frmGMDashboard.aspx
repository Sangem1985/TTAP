<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmGMDashboard.aspx.cs" Inherits="TTAP.UI.Pages.frmGMDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <link href="../../NewCss/css/bootstrap.min.css" rel="stylesheet" />--%>
    <%-- <link href="../../css/bootstrap.min.css" rel="stylesheet" />--%>
    <%-- <link href="../../css/DashboardCss/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../css/DashboardCss/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script src="../../Js/jquery-latest.min.js"></script>
    <script src="../../Js/jquery-ui.min.js"></script>
    <script src="../../Js/jquery.min.js"></script>
    <style>
        .blink {
            animation: blinker 0.6s linear infinite;
            color: #d71111;
            /*font-size: 30px;
        font-family: sans-serif;*/
            font-weight: bold;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }

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

        .modal {
            display: none; /* Hidden by default */
            position: fixed; /* Stay in place */
            z-index: 1; /* Sit on top */
            padding-top: 50px; /* Location of the box */
            left: 0;
            top: 0;
            width: 100%; /* Full width */
            height: 100%; /* Full height */
            overflow: auto; /* Enable scroll if needed */
            background-color: rgb(0,0,0); /* Fallback color */
            background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
        }

        /* Modal Content */
        .modal-content {
            background-color: #fefefe;
            margin: 0px 0px 0px 130px;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
            height: 95%;
            border: solid #33d816;
            border-radius: 15px;
            border-style: solid;
        }

        /* The Close Button */
        .close {
            color: #aaaaaa;
            float: right;
            font-size: 28px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: #000;
                text-decoration: none;
                cursor: pointer;
            }
    </style>
    <script type="text/javascript">
        

    </script>

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
                            <li runat="server" id="lidashboard" class="breadcrumb-item">GM DashBoard</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 id="Headerdic" runat="server" class="text-blue mt-1 mb-3 font-SemiBold">GM Dashboard</h5>
                        <label class="blink" id="lblnewApps" runat="server" visible="false"></label>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 mb-4 d-none">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-blue" Font-Size="Small" NavigateUrl="~/UI/Pages/frmDashBoard.aspx"><i class="fa fa-angle-left"></i> Back</asp:HyperLink>
                                </div>
                            </div>
                            <div class="row" id="trsection1" style="margin-top: 8px;"
                                runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="frmGMApplications.aspx?Stg=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Proposals Received From Applicant</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblAppl" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Yet to Assigned</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblYetotoAssignWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblPendingBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblpendingTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Query Details - Before Assigned to Inspecting Officer</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Query Raised With in 7 Days</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalQueryWithIn" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                          <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Query Raised Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalQueryBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRepliedQueryWithIn" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Awaiting for Response</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblOpenQuery" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="Div1" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Scrutiny Completed - Assigned to Inspecting Officer</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblAssignedWithIn" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblAssignedBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-primary bg-danger">
                                                <asp:Label ID="lblAssignedTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Rejected - Before Assigned to Inspecting Officer</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=8">
                                            <span><i class="fa fa-fw fa-calendar"></i>Auto Rejected</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=7">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected by GM</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblRejectedByGM" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=10">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-primary bg-danger">
                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>

                            </div>
                            <div id="divline1" runat="server">
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                            <div class="row" id="trsection2" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries From Inspecting Officer</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" runat="server" id="AncWithInInsPending" href="frmGMApplications.aspx?Stg=8">
                                            <span><i class="fa fa-fw fa-calendar"></i>Query Raised</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblIPOQueries" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" runat="server" id="AncBeyondInsPending" href="frmGMApplications.aspx?Stg=9">
                                            <span><i class="fa fa-fw fa-calendar"></i>Forwarded to Applicant</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblIPOQueryFwdtoApp" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" runat="server" id="AncTotalInsPending" href="frmGMApplications.aspx?Stg=10">
                                            <span><i class="fa fa-fw fa-calendar"></i>Query Response form the Applicant</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblAppResptoIPOQry" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries from COI</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="AncWithInInsCompleted" runat="server" href="frmGMApplications.aspx?Stg=15">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded by GM to COI</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblInspectionCompletedWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="AncBeyondInsCompleted" runat="server" href="frmGMApplications.aspx?Stg=16">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Raised by GM(after Applicant Response)</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblInspectionCompletedBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="AnctotalInsCompleted" runat="server" href="frmGMApplications.aspx?Stg=17">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded by Applicant(GM yet to Respond)</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblInspectionCompletedTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="A1" runat="server" href="frmGMApplications.aspx?Stg=17">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries yet to Respond</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="A2" runat="server" href="frmGMApplications.aspx?Stg=17">
                                            <span><i class="fa fa-fw fa-calendar"></i> Total - Query Raised </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="A3" runat="server" href="frmGMApplications.aspx?Stg=17">
                                            <span><i class="fa fa-fw fa-calendar"></i> SSC Inspection Completed (GM yet to Forward) </span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div id="divline2" runat="server">
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                            <div class="row" id="Div3" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Pending to be Reffered(COI/DIPC)</span>
                                        </a>
                                        <a id="revisedpending" class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=30">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblPendingDIPCWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a  class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=30">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblPendingDIPCBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                         <a  class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=30">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected Applications</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPCTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Query Details - After Inspection</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=31">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total-Query Responded</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblReInspectionCompleted" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=31">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label10" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=31">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                         <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=31">
                                            <span><i class="fa fa-fw fa-calendar"></i>No. of Applications Awaiting Query Response</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label12" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div id="divline3" runat="server">
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                            <div class="row" id="trsection6" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Recommended to COI</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=19">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblpendingtoberefferdW" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=20">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblpendingtoberefferdB" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                      
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Recommended to DIPC</span>
                                        </a>

                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=29">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalQueryafterInspection" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=27">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRepliedQueryWITHINafterInspection" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>

                            </div>
                            <div class="row" id="Div2" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Rejected Applications at COI</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=22">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected By JD </span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblcompletedtoberefferdW" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=23">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected by Additional Director </span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblcompletedtoberefferdB" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=24">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected at SVC</span>
                                            <span class="badge badge-pill badge-danger">
                                                <asp:Label ID="lblrejectedafterinsp" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=25">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected at SLC</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblCompletedtoreffer" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="Div4" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Abeyanced Applications at COI</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=22">
                                            <span><i class="fa fa-fw fa-calendar"></i>Abeyanced Applications at J.D Level </span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label13" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmGMApplications.aspx?Stg=23">
                                            <span><i class="fa fa-fw fa-calendar"></i>Abeyanced Applications at Additional Director </span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="Label14" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div id="divline4" runat="server">
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                            <div class="row" runat="server" id="TableSVC">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Fund Released Stage</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Sanctioned within 30 Days </span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSVCAgendaWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Sanctioned Beyond 30 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSVCAgendaBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Sanctioned Incentives</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="Label15" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>JD Rejected Incentives</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="Label16" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                         <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Released within 180 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="Label17" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Released Beyond 180 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="Label18" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>

                            <div id="divline5" runat="server">
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
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
