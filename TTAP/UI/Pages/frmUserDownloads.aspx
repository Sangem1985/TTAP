<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmUserDownloads.aspx.cs" Inherits="TTAP.UI.Pages.frmUserDownloads" %>

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

        .badge-success {
            color: #fff;
            background-color: #28a745;
            padding: 12px 25px;
            font-size: small !important;
        }

        .list-group {
            box-shadow: 1px 0px 6px -3px #000;
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
                            <li class="breadcrumb-item">User Download</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Downloads</h5>
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
                                        <%--  <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold list-group-item-action" href="frmDLOApplications.aspx?Stg=1">
                                            <span><i class="fa fa-fw fa-calendar"></i>Total Proposals Received From Applicant</span>
                                            <span class="badge badge-pill badge-primary bg-blue">
                                                <asp:Label ID="lblAppl" runat="server"></asp:Label>
                                            </span>
                                        </a>--%>

                                        <div class="list-group-item d-flex justify-content-between align-items-center font-SemiBold  list-heading-bg" href="../../DeptDocs/G.O.MS.NO.14 IND AND COM DEPT - MODIFIED OPERATIONAL GUIDELINES_TTAP.pdf">
                                            <span><i class="fa fa-fw fa-check"></i>G.O.MS.NO.59</span>
                                            <a href="../../DeptDocs/G.O.MS.NO.59 DT 18-8-2017_0001.pdf" style="border: 1px solid transparent; padding: .375rem .75rem; font-size: 1rem; line-height: 1.5;"><span class="badge badge-pill badge-success">
                                                <i class="fa fa-cloud-download"></i>Download
                                            </span></a>
                                        </div>
                                        <div class="list-group-item d-flex justify-content-between align-items-center text-blue list-group-item-action">
                                            <span><i class="fa fa-fw fa-check"></i>G.O.MS.NO.14</span>
                                            <a href="../../DeptDocs/G.O.MS.NO.14 IND AND COM DEPT - MODIFIED OPERATIONAL GUIDELINES_TTAP.pdf" style="border: 1px solid transparent; padding: .375rem .75rem; font-size: 1rem; line-height: 1.5;">
                                                <span class="badge badge-pill badge-success">
                                                    <i class="fa fa-cloud-download"></i>Download
                                                </span></a>
                                        </div>
                                        <div class="list-group-item d-flex justify-content-between align-items-center text-blue list-group-item-action">
                                            <span><i class="fa fa-fw fa-check"></i>Extension of Time Period for Submission of TTAP Incentive Claim Applications</span>
                                            <a href="../../DeptDocs/TTAP EXTENSION UPTO 30.09.2021_1.jpg" style="border: 1px solid transparent; padding: .375rem .75rem; font-size: 1rem; line-height: 1.5;">
                                                <span class="badge badge-pill badge-success">
                                                    <i class="fa fa-cloud-download"></i>Download
                                                </span></a>
                                        </div>
                                        <div class="list-group-item d-flex justify-content-between align-items-center text-blue list-group-item-action">
                                            <span><i class="fa fa-fw fa-check"></i>Extension of Time Period for Submission of TTAP Incentive Claim Applications(31-12-2021)</span>
                                            <a href="../../DeptDocs/Extension_of_Time_Period_for_Submission_of_TTAP_Incentive_Claim_Applications.pdf" style="border: 1px solid transparent; padding: .375rem .75rem; font-size: 1rem; line-height: 1.5;">
                                                <span class="badge badge-pill badge-success">
                                                    <i class="fa fa-cloud-download"></i>Download
                                                </span></a>
                                        </div>
                                        <div class="list-group-item d-flex justify-content-between align-items-center text-blue list-group-item-action">
                                            <span><i class="fa fa-fw fa-check"></i>The Limit for Submission of Query Replies by the Units/Enterprises</span>
                                            <a href="../../DeptDocs/Limit_for_Submission_of_Query_Replies_by_the_Units.pdf" style="border: 1px solid transparent; padding: .375rem .75rem; font-size: 1rem; line-height: 1.5;">
                                                <span class="badge badge-pill badge-success">
                                                    <i class="fa fa-cloud-download"></i>Download
                                                </span></a>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <div class="list-group-item d-flex justify-content-between align-items-center font-SemiBold  list-heading-bg" href="../../DeptDocs/Annexures.zip">
                                            <span><i class="fa fa-fw fa-check"></i>All Annexures</span>
                                            <a href="../../DeptDocs/Annexures.zip" style="border: 1px solid transparent; padding: .375rem .75rem; font-size: 1rem; line-height: 1.5;"><span class="badge badge-pill badge-success">
                                                <i class="fa fa-cloud-download"></i>Download
                                            </span></a>
                                        </div>
                                        <div class="list-group-item d-flex justify-content-between align-items-center text-blue list-group-item-action">
                                            <span><i class="fa fa-fw fa-check"></i>ANNEXURE XX DPR FORMAT</span>
                                            <a href="../../DeptDocs/ANNEXURE XX DPR FORMAT.pdf" style="border: 1px solid transparent; padding: .375rem .75rem; font-size: 1rem; line-height: 1.5;">
                                                <span class="badge badge-pill badge-success">
                                                    <i class="fa fa-cloud-download"></i>Download
                                                </span></a>
                                        </div>

                                        <%--<div class="list-group-item d-flex justify-content-between align-items-center font-SemiBold  list-heading-bg" href="../../DeptDocs/ANNEXURE XX DPR FORMAT.pdf">
                                            <span><i class="fa fa-fw fa-check"></i>ANNEXURE XX DPR FORMAT</span>
                                            <a href="../../DeptDocs/ANNEXURE XX DPR FORMAT.pdf" style="border: 1px solid transparent; padding: .375rem .75rem; font-size: 1rem; line-height: 1.5;"><span class="badge badge-pill badge-success">
                                                <i class="fa fa-cloud-download"></i>Download
                                            </span></a>
                                        </div>--%>
                                    </div>
                                </div>
                                <%--<div class="col-sm-4 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center text-blue font-SemiBold list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Queries</span>
                                        </a>
                                        
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=5">
                                            <span><i class="fa fa-fw fa-calendar"></i>Awaiting for Response</span>
                                            <span class="badge badge-pill badge-primary bg-warning">
                                                <asp:Label ID="lblOpenQuery" runat="server"></asp:Label>
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
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" href="frmDLOApplications.aspx?Stg=4">
                                            <span><i class="fa fa-fw fa-calendar"></i>Query Raised</span>
                                            <span class="badge badge-pill badge-primary bg-success">
                                                <asp:Label ID="lblTotalQuery" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>--%>
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
