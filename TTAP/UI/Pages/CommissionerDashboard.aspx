<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CommissionerDashboard.aspx.cs" Inherits="TTAP.UI.Pages.CommissionerDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/DashboardCss/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <script src="../../Js/jquery-latest.min.js"></script>
    <script src="../../Js/jquery-ui.min.js"></script>
    <script src="../../Js/jquery.min.js"></script>
    <style>
         #search {
            position: unset !important;
        }

        .SetgridWidth {
            width: 548px;
        }

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
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
            margin: 30px 0px 0px 130px;
            padding: 20px;
            border: 1px solid #888;
            width: 80%;
            height: 80%;
            border: solid #dc3545;
            border-radius: 20px;
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
        function Navigate(obj) {
            var Dist = $('#ContentPlaceHolder1_ddlDistrict').val();
            if ($('#ContentPlaceHolder1_ddlDistrict').val() == "All") {
                Dist = "0";
            }
            if (obj == "P") {
                window.location = "frmDLOApplicationsComm.aspx?Stg=1" + "&DistId=" + parseInt(Dist);
            }
            if (obj == "I") {
                window.location = "frmDLOApplicationsComm.aspx?Stg=2" + "&DistId=" + parseInt(Dist);
            }
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
                            <li runat="server" id="lidashboard" class="breadcrumb-item">DLO Pending Applications DashBoard</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 id="Headerdic" runat="server" class="text-blue mt-1 mb-3 font-SemiBold">DLO Pending Applications</h5>
                        <label class="blink" id="lblnewApps" runat="server" visible="false"></label>
                        <div class="widget-content nopadding">
                            <div class="row" runat="server" visible="false">
                               <div runat="server" id="divCats" class="col-sm-12 mb-3 d-flex">
                                   <table>
                                       <tr>
                                            <td>
                                                <label style="display: block;">
                                                    District : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistrict" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                            </td>
                                       </tr>
                                   </table>
                                   </div>
                            </div>
                            <div class="row" id="trsection1" style="margin-top: 8px;"
                                runat="server" visible="false">
                                <div class="col-sm-6 mb-4">
                                    <div class="list-group">
                                        <a class="list-group-item d-flex justify-content-between align-items-center font-SemiBold text-blue list-heading-bg">
                                            <span><i class="fa fa-fw fa-check"></i>Pending Applications</span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" onclick="return Navigate('P');">
                                            <span><i class="fa fa-fw fa-calendar"></i>No. of Incentives not acted upon within 7 days of receipt of application</span>
                                            <span class="badge badge-pill badge-success">
                                                <asp:Label ID="lblPendingIncentives" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                        <a class="list-group-item d-flex justify-content-between align-items-center list-group-item-action" onclick="return Navigate('I');">
                                            <span><i class="fa fa-fw fa-calendar"></i>No. of Incentives not acted upon within 7 days of Inspection Scheduled</span>
                                            <span class="badge badge-pill badge-warning">
                                                <asp:Label ID="lblPendingInspections" runat="server"></asp:Label>
                                            </span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="divGrid" runat="server">
                                <div id="DivIncentive" class="col-sm-12 table-responsive" runat="server">
                                    <asp:GridView ID="gvDashboard" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" Font-Bold="true" ShowFooter="true"
                                        PageSize="20" GridLines="Both" OnRowDataBound="gvDashboard_RowDataBound">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DISTNAME" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentive Applications Received"
                                                DataTextField="NoofIncentivesRcvd">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No. of Incentives not acted upon within 7 days of receipt of application"
                                                DataTextField="DLOPendingWithin">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center"  CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No. of Incentives not acted upon within 7 days of Inspection Scheduled"
                                                DataTextField="InspectionPendingWithin">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Visible="false" HeaderText="No. of Incentives not acted upon within 7 days of Revised Inspection Scheduled"
                                                DataTextField="ReInspectionPending">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="DistrictId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistrictId" Text='<%#Eval("DISTID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                </div>
                            <asp:HiddenField ID="hdfID" runat="server" />
                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                            <asp:HiddenField ID="hdnDistId" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
           
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
