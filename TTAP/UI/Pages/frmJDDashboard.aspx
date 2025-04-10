<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmJDDashboard.aspx.cs" Inherits="TTAP.UI.Pages.frmJDDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <link href="../../NewCss/css/bootstrap.min.css" rel="stylesheet" />--%>
    <%-- <link href="../../css/bootstrap.min.css" rel="stylesheet" />--%>
    <%-- <link href="../../css/DashboardCss/bootstrap.min.css" rel="stylesheet" />--%>

    <link href="../../css/DashboardCss/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <style>
        .collapsible {
            background-color: #ddecfd;
            /* color: white; */
            cursor: pointer;
            padding: 12px 12px;
            width: 100%;
            border: 1px solid;
            text-align: left;
            outline: none;
            font-size: 15px;
        }

            .active, .collapsible:hover {
                background-color: #ddecfd;
                color: azure;
            }

        .content {
            padding: 0 18px;
            display: none;
            overflow: hidden;
            background-color: #f1f1f1;
        }

        button:focus {
            outline: 0px dotted;
            /* outline: 5px auto -webkit-focus-ring-color; */
        }
    </style>
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
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="frmJDApplications.aspx?Stg=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Proposals Received From JD</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblAppl" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Yet to Process</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblPendingWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblPendingBeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=7">
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
                                            <span><i class="fa fa-fw fa-check"></i>Scrutiny Completed and Forwarded To Commissioner</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=8">
                                            <span><i class="fa fa-fw fa-calendar"></i>Within  Days</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblcomWithin" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=9">
                                            <span><i class="fa fa-fw fa-calendar"></i>Beyond  Days</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblcombeyond" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=10">
                                            <span><i class="fa fa-fw fa-calendar"></i>Rejected</span>
                                            <span class="badge badge-pill badge-primary bg-danger">
                                                <asp:Label ID="lblDLrejected" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group" runat="server" visible="false">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Query Raised</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalQuery" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Within</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblRepliedQueryWITHIN" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=11">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Beyond</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblRepliedQueryBEYOND" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Awaiting for Response</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblOpenQuery" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="Div1" runat="server">
                            </div>
                            <div>
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                            <div id="divNew" runat="server" visible="false">
                                <div class="row" runat="server" id="Div3">
                                    <div class="col-sm-6 mb-4">
                                        <div class="list-group">
                                            <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                <span><i class="fa fa-fw fa-check"></i>Referred to SVC (SVC Dashboard)</span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/ISVCSactionedApplications.aspx?Stg=9&ALLAPPSTATUS=ALL">
                                                <span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Received</b></span>
                                                <span class="badge badge-pill badge-primary bg-blue">
                                                    <asp:Label ID="lblNoofSVCRcvd" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                <span><i class="fa fa-fw fa-check"></i>Generate Agenda</span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGenerateAgenda.aspx?Stage=1">
                                                <span><i class="fa fa-fw fa-calendar"></i>Within time limits </span>
                                                <span class="badge badge-pill badge-success">
                                                    <asp:Label ID="lblSVCGenerateAgendaWithin" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGenerateAgenda.aspx?Stage=2">
                                                <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSVCGenerateAgendaBeyond" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGenerateAgenda.aspx?Stage=3">
                                                <span><i class="fa fa-fw fa-calendar"></i><b>Total</b></span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSVCGenerateAgendaTotal" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <%--<a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGeneratedAgendaAbstract.aspx?Stage=3&TransType=PRINTAGENDA">
                                                <span><i class="fa fa-fw fa-calendar"></i><b>Print Generated SVC Agenda</b></span>
                                                <span class="badge badge-pill badge-primary bg-blue">
                                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                                </span>
                                            </a>--%>
                                            <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                <span><i class="fa fa-fw fa-check"></i>Upload SVC Proceedings</span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGeneratedAgendaAbstract.aspx?Stage=1&TransType=AGENDAUPDATE">
                                                <span><i class="fa fa-fw fa-calendar"></i>Within time limits</span>
                                                <span class="badge badge-pill badge-success">
                                                    <asp:Label ID="lblSVCUploadProceedingWithin" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGeneratedAgendaAbstract.aspx?Stage=2&TransType=AGENDAUPDATE">
                                                <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSVCUploadProceedingBeyond" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGeneratedAgendaAbstract.aspx?Stage=3&TransType=AGENDAUPDATE">
                                                <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSVCUploadProceedingTotal" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 mb-4">
                                        <div class="list-group">
                                            <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                <span><i class="fa fa-fw fa-check"></i>Uploaded SVC Proceedings (Completed)</span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/ISVCSactionedApplications.aspx?Stg=5">
                                                <span><i class="fa fa-fw fa-calendar"></i>Within</span>
                                                <span class="badge badge-pill badge-success">
                                                    <asp:Label ID="lblSVCCompletedWithin" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/ISVCSactionedApplications.aspx?Stg=6">
                                                <span><i class="fa fa-fw fa-calendar"></i>Beyond</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSVCCompletedBeyond" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/ISVCSactionedApplications.aspx?Stg=7">
                                                <span><i class="fa fa-fw fa-calendar"></i>Rejected</span>
                                                <span class="badge badge-pill badge-danger">
                                                    <asp:Label ID="lblSVCRejectedList" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/ISVCSactionedApplications.aspx?Stg=8">
                                                <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSVCTotal" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                        </div>
                                    </div>
                                </div>

                                <div>
                                    <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                                </div>

                                <div class="row" runat="server" id="Div4">
                                    <div class="col-sm-6 mb-4">
                                        <div class="list-group">
                                            <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                <span><i class="fa fa-fw fa-check"></i>Referred to SLC (SLC Dashboard)</span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/ISLCSactionedApplications.aspx?Stg=9&ALLAPPSTATUS=ALL">
                                                <span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Received</b></span>
                                                <span class="badge badge-pill badge-primary bg-blue">
                                                    <asp:Label ID="lblNoofSLCRcvd" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                <span><i class="fa fa-fw fa-check"></i>Generate Agenda</span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGenerateAgenda.aspx?Stage=1">
                                                <span><i class="fa fa-fw fa-calendar"></i>Within time limits </span>
                                                <span class="badge badge-pill badge-success">
                                                    <asp:Label ID="lblSLCGenerateAgendaWithin" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGenerateAgenda.aspx?Stage=2">
                                                <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSLCGenerateAgendaBeyond" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGenerateAgenda.aspx?Stage=3">
                                                <span><i class="fa fa-fw fa-calendar"></i><b>Total</b></span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSLCGenerateAgendaTotal" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <%-- <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGeneratedAgendaAbstract.aspx?Stage=3&TransType=PRINTAGENDA">
                                                <span><i class="fa fa-fw fa-calendar"></i><b>Print Generated SLC Agenda</b></span>
                                                <span class="badge badge-pill badge-primary bg-blue">
                                                    <asp:Label ID="Label17" runat="server"></asp:Label>
                                                </span>
                                            </a>--%>
                                            <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                <span><i class="fa fa-fw fa-check"></i>Upload SLC Proceedings</span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGeneratedAgendaAbstract.aspx?Stage=1&TransType=AGENDAUPDATE">
                                                <span><i class="fa fa-fw fa-calendar"></i>Within time limits</span>
                                                <span class="badge badge-pill badge-success">
                                                    <asp:Label ID="lblSLCUploadProceedingWithin" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGeneratedAgendaAbstract.aspx?Stage=2&TransType=AGENDAUPDATE">
                                                <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSLCUploadProceedingBeyond" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGeneratedAgendaAbstract.aspx?Stage=3&TransType=AGENDAUPDATE">
                                                <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSLCUploadProceedingTotal" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col-sm-6 mb-4">
                                        <div class="list-group">
                                            <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                <span><i class="fa fa-fw fa-check"></i>Uploaded SLC Proceedings (Completed)</span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/ISLCSactionedApplications.aspx?Stg=5">
                                                <span><i class="fa fa-fw fa-calendar"></i>Within</span>
                                                <span class="badge badge-pill badge-success">
                                                    <asp:Label ID="lblSLCCompletedWithin" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/ISLCSactionedApplications.aspx?Stg=6">
                                                <span><i class="fa fa-fw fa-calendar"></i>Beyond</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSLCCompletedBeyond" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/ISLCSactionedApplications.aspx?Stg=7">
                                                <span><i class="fa fa-fw fa-calendar"></i>Rejected</span>
                                                <span class="badge badge-pill badge-danger">
                                                    <asp:Label ID="lblSLCRejected" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                            <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/ISLCSactionedApplications.aspx?Stg=8">
                                                <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                                <span class="badge badge-pill badge-warning">
                                                    <asp:Label ID="lblSLCTotal" runat="server"></asp:Label>
                                                </span>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div>
                                        <h5 class="page-head-linenew" align="left" style="font-size: smaller"></h5>
                                    </div>
                            <button type="button" class="collapsible text-blue font-SemiBold list-heading-bg">View Handloom Department SLC Completed Applications <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span></button>
                            <div class="content">
                                <br />
                                <%--<h5>TTAP OLD APPLICATIONS</h5>--%>
                                <div id="divOld" runat="server">
                                    <div class="row" runat="server" id="TableSVC">
                                        <div class="col-sm-6 mb-4">
                                            <div class="list-group">
                                                <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                    <span><i class="fa fa-fw fa-check"></i>Referred to SVC (SVC Dashboard)</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSLSVCSactionedApplications.aspx?Stg=9&ALLAPPSTATUS=ALL">
                                                    <span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Received</b></span>
                                                    <span class="badge badge-pill badge-primary bg-blue">
                                                        <asp:Label ID="lblSVCReceived" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                    <span><i class="fa fa-fw fa-check"></i>Generate Agenda</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGenerateAgenda.aspx?Stage=1">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Within time limits </span>
                                                    <span class="badge badge-pill badge-success">
                                                        <asp:Label ID="lblSVCAgendaWithin" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGenerateAgenda.aspx?Stage=2">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblSVCAgendaBeyond" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGenerateAgenda.aspx?Stage=3">
                                                    <span><i class="fa fa-fw fa-calendar"></i><b>Total</b></span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblSVCTotalYettogenerateAgenda" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGeneratedAgendaAbstract.aspx?Stage=3&TransType=PRINTAGENDA">
                                                    <span><i class="fa fa-fw fa-calendar"></i><b>Print Generated SVC Agenda</b></span>
                                                    <span class="badge badge-pill badge-primary bg-blue">
                                                        <asp:Label ID="lblSVCPrintGeneratedDLCAgenda" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                    <span><i class="fa fa-fw fa-check"></i>Upload SVC Proceedings</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGeneratedAgendaAbstract.aspx?Stage=1&TransType=AGENDAUPDATE">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Within time limits</span>
                                                    <span class="badge badge-pill badge-success">
                                                        <asp:Label ID="lblSVCUploadProcWithin" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGeneratedAgendaAbstract.aspx?Stage=2&TransType=AGENDAUPDATE">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblSVCUploadProcBeyond" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSVCGeneratedAgendaAbstract.aspx?Stage=3&TransType=AGENDAUPDATE">
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
                                                    <span><i class="fa fa-fw fa-check"></i>Uploaded SVC Proceedings (Completed)</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSLSVCSactionedApplications.aspx?Stg=5">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Within</span>
                                                    <span class="badge badge-pill badge-success">
                                                        <asp:Label ID="lblSVCReleasePendingsWithin" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSLSVCSactionedApplications.aspx?Stg=6">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Beyond</span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblSVCReleasePendingsBeyond" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSLSVCSactionedApplications.aspx?Stg=7">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Rejected</span>
                                                    <span class="badge badge-pill badge-danger">
                                                        <asp:Label ID="lblSVCrejected" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SVC/frmSLSVCSactionedApplications.aspx?Stg=8">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblSVCCompleted" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>

                                    <div>
                                        <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                                    </div>

                                    <div class="row" runat="server" id="Table2">
                                        <div class="col-sm-6 mb-4">
                                            <div class="list-group">
                                                <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                    <span><i class="fa fa-fw fa-check"></i>Referred to SLC (SLC Dashboard)</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCSactionedApplications.aspx?Stg=9&ALLAPPSTATUS=ALL">
                                                    <span><i class="fa fa-fw fa-calendar"></i><b>No of Applications Received</b></span>
                                                    <span class="badge badge-pill badge-primary bg-blue">
                                                        <asp:Label ID="lblDLCReceived" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                    <span><i class="fa fa-fw fa-check"></i>Generate Agenda</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGenerateAgenda.aspx?Stage=1">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Within time limits </span>
                                                    <span class="badge badge-pill badge-success">
                                                        <asp:Label ID="lblDIPCAgendaWithin" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGenerateAgenda.aspx?Stage=2">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblDIPCAgendaBeyond" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGenerateAgenda.aspx?Stage=3">
                                                    <span><i class="fa fa-fw fa-calendar"></i><b>Total</b></span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblTotalYettogenerateAgenda" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGeneratedAgendaAbstract.aspx?Stage=3&TransType=PRINTAGENDA">
                                                    <span><i class="fa fa-fw fa-calendar"></i><b>Print Generated SLC Agenda</b></span>
                                                    <span class="badge badge-pill badge-primary bg-blue">
                                                        <asp:Label ID="lblPrintGeneratedDLCAgenda" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                    <span><i class="fa fa-fw fa-check"></i>Upload SLC Proceedings</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGeneratedAgendaAbstract.aspx?Stage=1&TransType=AGENDAUPDATE">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Within time limits</span>
                                                    <span class="badge badge-pill badge-success">
                                                        <asp:Label ID="lblDIPCUploadProcWithin" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGeneratedAgendaAbstract.aspx?Stage=2&TransType=AGENDAUPDATE">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Beyond time limits</span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblDIPCUploadProcBeyond" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCGeneratedAgendaAbstract.aspx?Stage=3&TransType=AGENDAUPDATE">
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
                                                    <span><i class="fa fa-fw fa-check"></i>Uploaded SLC Proceedings (Completed)</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCSactionedApplications.aspx?Stg=5">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Within</span>
                                                    <span class="badge badge-pill badge-success">
                                                        <asp:Label ID="lblDIPCReleasePendingsWithin" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCSactionedApplications.aspx?Stg=6">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Beyond</span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblDIPCReleasePendingsBeyond" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCSactionedApplications.aspx?Stg=7">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Rejected</span>
                                                    <span class="badge badge-pill badge-danger">
                                                        <asp:Label ID="DLCrejected" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSLCSactionedApplications.aspx?Stg=8">
                                                    <span><i class="fa fa-fw fa-calendar"></i>Total</span>
                                                    <span class="badge badge-pill badge-warning">
                                                        <asp:Label ID="lblDLCCompleted" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                            </div>
                                            <div>
                                                <h5 class="page-head-linenew" align="left" style="font-size: smaller"></h5>
                                            </div>

                                            <div class="list-group" runat="server" visible="false">
                                                <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                                    <span><i class="fa fa-fw fa-check"></i>Sanction Letters</span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSanctionLettersPendingList.aspx">
                                                    <span><i class="fa fa-fw fa-check"></i>Pending</span>
                                                    <span class="badge badge-pill badge-success">
                                                        <asp:Label ID="lblPendingIssueSanctions" runat="server">0</asp:Label>
                                                    </span>
                                                </a>
                                                <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="SLC/frmSanctionLettersIssuedList.aspx">
                                                    <span><i class="fa fa-fw fa-check"></i>Issued</span>
                                                    <span class="badge badge-pill badge-success">
                                                        <asp:Label ID="lblIssuedSanctionLetters" runat="server"></asp:Label>
                                                    </span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <asp:HiddenField ID="hdfID" runat="server" />
                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                        </div>
                    </div>
                </div>
            </div>


            <script>
                var coll = document.getElementsByClassName("collapsible");
                var i;

                for (i = 0; i < coll.length; i++) {
                    coll[i].addEventListener("click", function () {
                        this.classList.toggle("active");
                        var content = this.nextElementSibling;
                        if (content.style.display === "block") {
                            content.style.display = "none";
                        } else {
                            content.style.display = "block";
                        }
                    });
                }
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
