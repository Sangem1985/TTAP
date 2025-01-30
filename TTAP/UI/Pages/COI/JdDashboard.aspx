<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="JdDashboard.aspx.cs" Inherits="TTAP.UI.Pages.COI.JdDashboard" %>
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
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="divdashboardheadername" runat="server" >JD Dashboard</h5>
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
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="JdApplications.aspx">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Proposals Received From GM</span>
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
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="JdApplications.aspx?Stg=3">
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

                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Forwarded from DD</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Applications Fowarded from DD</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Applications Query from DD</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=7">
                                            <span><i class="fa fa-fw fa-calendar"></i>JD Returned</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>

                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>No of Applications Forwarded to Additional Director</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Fowarded to Additional Director</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Recommended to Additional Director</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=7">
                                            <span><i class="fa fa-fw fa-calendar"></i>Query Forwarded to Additional Director</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>


                                </div>

                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Query Yet to Respond</span>
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
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Queries Responded</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblqrsrespnded" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Auto Rejected</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblttlautorejected" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries Responded / Received from DD</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Recommended from DD</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblrspndedrcmndedfromclerk" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Query Raised by Additional Director</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblrspndedtoquerybyClerk" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries Responded / Forwarded to Additional Director</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Forwarded to Additional Director</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblrspndedandfrwdedtoAD" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmJDApplications.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Queries Responded - Query Raised by Additional Director</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblrspndedtoquerybyAD" runat="server"></asp:Label>
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
