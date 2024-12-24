<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FormWorkingStatusDashboard.aspx.cs" Inherits="TTAP.UI.Pages.Releases.FormWorkingStatusDashboard" %>

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
                            <li class="breadcrumb-item">Units Working Status DashBoard</li>
                        </ul>
                    </div>
                   
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="divdashboardheadername" runat="server">Units Working Status Dashboard</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 mb-4 d-none">
                                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-blue" Font-Size="Small" NavigateUrl="~/UI/Pages/frmDashBoard.aspx"><i class="fa fa-angle-left"></i> Back</asp:HyperLink>
                                </div>
                            </div>
                        
                              <div>
                                <h1 class="page-head-linenew" align="left" style="font-size: smaller"></h1>
                            </div>
                               <div class="row" id="Div2" runat="server">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Unit Working Status Details</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="FormUnitWorkingStatusHO.aspx?Flag=DLO">
                                            
                                            <span><i class="fa fa-fw fa-calendar"></i>DLO Updates</span>
                                            <span class="badge badge-pill badge-success" style="display:none;">
                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                          <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="FormUnitWorkingStatusHO.aspx?Flag=UNIT">
                                            
                                            <span><i class="fa fa-fw fa-calendar"></i>Unit Responses</span>
                                            <span class="badge badge-pill badge-success" style="display:none;">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
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

