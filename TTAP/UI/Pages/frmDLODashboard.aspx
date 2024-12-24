<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmDLODashboard.aspx.cs" Inherits="TTAP.UI.Pages.frmDLODashboard" %>

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
        $(document).ready(function () {
            if ($('#ContentPlaceHolder1_lblReInspectionPending').html() > 0) {
                $('#revisedpending').addClass("blink");
            }
            $('#myModal').show();
        });
        function Close() {
            $('#myModal').hide();
        }

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
                            <li runat="server" id="lidashboard" class="breadcrumb-item">DLO DashBoard</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 id="Headerdic" runat="server" class="text-blue mt-1 mb-3 font-SemiBold">District Level Officer Dashboard</h5>
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
                                        <%--  <a class="list-group-item"><i class="fa fa-fw fa-check"></i><b>Incentive (Application Stage)</b> </a>--%>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="frmDLOApplications.aspx?Stg=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Proposals Received From Applicant</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblAppl" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Yet to Process</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblPendingWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblPendingBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=7">
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
                                            <span><i class="fa fa-fw fa-check"></i>Queries</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Query Raised</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalQuery" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Within</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRepliedQueryWITHIN" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=11">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Beyond</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblRepliedQueryBEYOND" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=5">
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
                                            <span><i class="fa fa-fw fa-check"></i>Scrutiny Completed and Inspections Scheduled</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=8">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblcomWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=9">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblcombeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=10">
                                            <span><i class="fa fa-fw fa-calendar"></i>DLO Rejected</span>
                                            <span class="badge badge-pill badge-primary bg-danger">
                                                <asp:Label ID="lblDLrejected" runat="server"></asp:Label>
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
                                            <span><i class="fa fa-fw fa-check"></i>Yet To Update Scheduled Inspection Reports</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" runat="server" id="AncWithInInsPending" href="frmDLOApplications.aspx?Stg=12">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblInspectionPendingWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>

                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" runat="server" id="AncBeyondInsPending" href="frmDLOApplications.aspx?Stg=13">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblInspectionPendingBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" runat="server" id="AncTotalInsPending" href="frmDLOApplications.aspx?Stg=14">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Pending</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblInspectionPendingTotal" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Completed Inspection Reports</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="AncWithInInsCompleted" runat="server" href="frmDLOApplications.aspx?Stg=15">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 7 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblInspectionCompletedWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="AncBeyondInsCompleted" runat="server" href="frmDLOApplications.aspx?Stg=16">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 7 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblInspectionCompletedBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" id="AnctotalInsCompleted" runat="server" href="frmDLOApplications.aspx?Stg=17">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblInspectionCompletedTotal" runat="server"></asp:Label>
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
                                            <span><i class="fa fa-fw fa-check"></i>Yet To Update Revised Inspection Reports</span>
                                        </a>
                                        <a id="revisedpending" class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=30">
                                            <span><i class="fa fa-fw fa-calendar"></i>Pending</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblReInspectionPending" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Completed Revised Inspection Reports</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=31">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblReInspectionCompleted" runat="server"></asp:Label>
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
                                            <span><i class="fa fa-fw fa-check"></i>Pending for Reference to DLC/Head Office</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=19">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 3 Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblpendingtoberefferdW" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=20">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblpendingtoberefferdB" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=21">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblpendingtoreffer" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries After Inspection</span>
                                        </a>

                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=29">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Query Raised</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalQueryafterInspection" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=27">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Within</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRepliedQueryWITHINafterInspection" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=28">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Beyond</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblRepliedQueryBEYONDafterInspection" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=26">
                                            <span><i class="fa fa-fw fa-calendar"></i>Awaiting for Response</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblOpenQueryafterInspection" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>

                            </div>
                            <div class="row" id="Div2" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Forwarded to DLC/Head Office</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=22">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within 3 Days </span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblcompletedtoberefferdW" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=23">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond 3 Days </span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblcompletedtoberefferdB" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=24">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected Applications</span>
                                            <span class="badge badge-pill badge-danger">
                                                <asp:Label ID="lblrejectedafterinsp" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=25">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblCompletedtoreffer" runat="server"></asp:Label>
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
                                            <span><i class="fa fa-fw fa-check"></i>Referred to DL-SVC (DL-SVC Dashboard)</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmSVCSactionedApplications.aspx?Stg=9&ALLAPPSTATUS=ALL">
                                            <span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Received</b></span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblSVCReceived" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Generate Agenda</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within time limits </span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSVCAgendaWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSVCAgendaBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGenerateAgenda.aspx?Stage=3">
                                            <span><i class="fa fa-fw fa-calendar"></i><b>Total</b></span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSVCTotalYettogenerateAgenda" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGeneratedAgendaAbstract.aspx?Stage=3&TransType=PRINTAGENDA">
                                            <span><i class="fa fa-fw fa-calendar"></i><b>Print Generated DL-SVC Agenda</b></span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblSVCPrintGeneratedDLCAgenda" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Upload DL-SVC Proceedings</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGeneratedAgendaAbstract.aspx?Stage=1&TransType=AGENDAUPDATE">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within time limits</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSVCUploadProcWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGeneratedAgendaAbstract.aspx?Stage=2&TransType=AGENDAUPDATE">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSVCUploadProcBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmDLSVCGeneratedAgendaAbstract.aspx?Stage=3&TransType=AGENDAUPDATE">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSVCUploadProc" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Uploaded DL-SVC Proceedings (Completed)</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmSVCSactionedApplications.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblSVCReleasePendingsWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmSVCSactionedApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSVCReleasePendingsBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmSVCSactionedApplications.aspx?Stg=7">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected</span>
                                            <span class="badge badge-pill badge-danger">
                                                <asp:Label ID="lblSVCrejected" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLSVC/frmSVCSactionedApplications.aspx?Stg=8">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblSVCCompleted" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>

                            <div id="divline5" runat="server">
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                            <div class="row" runat="server" id="Table2">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Referred to DLC (DLC Dashboard)</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmDLCSactionedApplications.aspx?Stg=9&ALLAPPSTATUS=ALL">
                                            <span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Received</b></span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblDLCReceived" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Generate Agenda</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmGenerateAgenda.aspx?Stage=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within time limits </span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPCAgendaWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmGenerateAgenda.aspx?Stage=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblDIPCAgendaBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmGenerateAgenda.aspx?Stage=3">
                                            <span><i class="fa fa-fw fa-calendar"></i><b>Total</b></span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblTotalYettogenerateAgenda" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmGeneratedAgendaAbstract.aspx?Stage=3&TransType=PRINTAGENDA">
                                            <span><i class="fa fa-fw fa-calendar"></i><b>Print Generated DLC Agenda</b></span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblPrintGeneratedDLCAgenda" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Upload DLC Proceedings</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmGeneratedAgendaAbstract.aspx?Stage=1&TransType=AGENDAUPDATE">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within time limits</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPCUploadProcWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmGeneratedAgendaAbstract.aspx?Stage=2&TransType=AGENDAUPDATE">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblDIPCUploadProcBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmGeneratedAgendaAbstract.aspx?Stage=3&TransType=AGENDAUPDATE">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblDIPCUploadProc" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Uploaded DLC Proceedings (Completed)</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmDLCSactionedApplications.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblDIPCReleasePendingsWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmDLCSactionedApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblDIPCReleasePendingsBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmDLCSactionedApplications.aspx?Stg=7">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected</span>
                                            <span class="badge badge-pill badge-danger">
                                                <asp:Label ID="DLCrejected" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="DLC/frmDLCSactionedApplications.aspx?Stg=8">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblDLCCompleted" runat="server"></asp:Label>
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
            <div id="myModal" class="modal">


                <!-- Modal content -->
                <div class="modal-content">
                    <h4 align="center" class="blink" style="text-decoration-line: underline; font-family: 'Montserrat-SemiBold'; color: orangered;">TIMELINES FOR T-TAP INCENTIVE APPLICATIONS</h4>
                    <div style="margin: 20px 0px 0px 10px;" runat="server" visible="false">
                        <p style="font-family: 'Montserrat-SemiBold';">
                            <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>&nbsp 1. Raise Query if it is in incomplete shape within 7 days.
                        </p>
                        <p style="font-family: 'Montserrat-SemiBold';">
                            <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>&nbsp 2. Raise 1st reminder query if reply not received within 15 days
                        </p>
                        <p style="font-family: 'Montserrat-SemiBold';">
                            <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>&nbsp 3. Raise final Reminder Notice if reply not received within 15 days
                        </p>
                        <p style="font-family: 'Montserrat-SemiBold';">
                            <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>&nbsp 4. Schedule Inspection after receipt of application in full shape within 7 days
                        </p>
                        <p style="font-family: 'Montserrat-SemiBold';">
                            <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>&nbsp 5. Submit Inspection report within 7 days after inspection
                        </p>
                        <p style="font-family: 'Montserrat-SemiBold';">
                            <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>&nbsp 6. If the query reply not received even after issue of reminders and with final notice application will be rejected.
                        </p>
                        <p style="font-family: 'Montserrat-SemiBold';">
                            <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>&nbsp 7. If the Inspection is not scheduled within 7 days or Inspecton report not submitted in another 7 days  Penalty will be imposed &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp on DLO.

                        </p>
                    </div>
                    <div>
                        <table class="table table-bordered title6  w-100">
                            <tr align="center" runat="server" visible="false">
                                <th>S.No</th>
                                <th>Description</th>
                                <th>Description</th>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
                                    <h6 style="font-family: 'Montserrat-SemiBold';">The DLO shall complete the scrutiny of the application within 7 days soon after receipt of application.</h6>
                                </td>
                                <%--<td align="left"></td>
                                <td align="center"></td>--%>
                            </tr>
                            <tr>
                                <td align="center" style="font-family: 'Montserrat-SemiBold';">Action to be taken, if the application is in full shape</td>
                                <td align="center"  style="font-family: 'Montserrat-SemiBold';">Action to be taken, if the application is not in full shape</td>
                                <td>No.of Days</td>
                            </tr>
                            <tr>
                                <td>If the application is in full shape, the DLO shall schedule the Inspection date on the portal and complete physical inspection within (7) days.</td>
                                <td align="left">If the application is not in complete shape, the DLO shall raise query within 7 days from the date of receipt, by giving 14 days time to submit the information/ shortfall documents.</td>
                                <td align="center">14 days</td>
                            </tr>
                             <tr>
                                <td>After completion of physical inspection, the DLO shall submit Inspection Report within (7) days to the Head office in case of claims above Rs.25.00 lakhs</td>
                                <td align="left">If the response is not received from the Applicant within time period, the DLO shall raise 1st Reminder Notice by giving 7 more days time to submit the requested information.</td>
                                <td align="center">7 days</td>
                            </tr>
                            <tr>
                                <td>If the claims are below Rs.25.00 lakhs, the DLO shall place the claim in the District Level SVC meeting for recommendation to the District Level Committee.</td>
                                <td align="left">If the response is not received again within the prescribed time, the DLO shall raise 2nd Reminder Notice by giving 7 more days time to submit the documents called for.</td>
                                <td align="center">7 days</td>
                            </tr>
                             <tr>
                                <td>After recommendation of claim by the District Level SVC, the claim shall be placed before the District Level Committee (DLC) for approval.</td>
                                <td align="left">Again if the response is not received, then raise Final Notice by giving 7 working days time duly intimating that in case of not receipt of information/ documents, the application shall be rejected.</td>
                                <td align="center">7 days</td>
                            </tr>
                            <tr>
                                <td>Record Minutes of the meeting and issue Sanction Letter</td>
                                <td align="left" colspan="2">Reject the Application with valid reasons</td>
                                <%--<td align="center"></td>--%>
                            </tr>

                        </table>
                    </div>
                    <input align="center" type="button" value="CLOSE" style="width: 100%;color: #d61e1e;border: none;background: bottom;font-weight: 800;"
                        id="btnClose" onclick="Close();" />
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
