<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmQueryDashboard.aspx.cs" Inherits="TTAP.UI.Pages.QueryGeneration.frmQueryDashboard" %>

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
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Query Letter - Dashboard</h5>
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
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="frmApllicationsforQuery.aspx?Stg=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Generate New Query Letter</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblAppl" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Generated Query Letters</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmApllicationsforQuery.aspx?Stg=2">
                                            <span><i class="fa fa-fw fa-calendar"></i>Draft Query Letters</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lbldraftQueryletters" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Status - Query Letters</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmApllicationsforQuery.aspx?Stg=3">
                                            <span><i class="fa fa-fw fa-calendar"></i>Pending Query Letters</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblPendingQueryletters" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmApllicationsforQuery.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Approved Query Letters</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblTotalApprovedQueryletters" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="divForwardedQ" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Forwarded - Query Letters</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmApllicationsforQuery.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Yet to Verify</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblYettoVerify" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmApllicationsforQuery.aspx?Stg=7">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Verified</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblTotalVerified" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmApllicationsforQuery.aspx?Stg=6">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Approved</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblTotalApproved" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
