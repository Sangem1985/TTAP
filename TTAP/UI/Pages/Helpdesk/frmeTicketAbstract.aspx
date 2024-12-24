<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmeTicketAbstract.aspx.cs" Inherits="TTAP.UI.frmeTicketAbstract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../Js/validations.js"></script>
    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
    </style>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <!-- Core CSS - Include with every page -->

    <%-- <link href="assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />--%>
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <link href="../assets/plugins/pace/pace-theme-big-counter.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <link href="../assets/css/main-style.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />
    <!-- Page-Level CSS -->
    <link href="../assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <style>
        /*#content {
            margin-top: 27px !important;
        }*/
        .row {
            margin-right: -15px;
            margin-left: -15px;
        }

        /*a {
            color: black !important;
        }*/

        .panel-footer {
            padding: 10px 15px;
            background-color: #f5f5f5;
            border-top: 1px solid #ddd;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
        }

        .panel-body {
            padding: 15px;
        }



        .panel {
            margin-bottom: 20px;
            background-color: #fff;
            border: 1px solid transparent;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, .05);
            box-shadow: 0 1px 1px rgba(0, 0, 0, .05);
        }

        @media (min-width: 992px) {
            .col-md-1, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-md-10, .col-md-11, .col-md-12 {
                float: left;
            }

            .col-md-12 {
                width: 100%;
            }

            .col-md-11 {
                width: 91.66666667%;
            }

            .col-md-10 {
                width: 83.33333333%;
            }

            .col-md-9 {
                width: 75%;
            }

            .col-md-8 {
                width: 66.66666667%;
            }

            .col-md-7 {
                width: 58.33333333%;
            }

            .col-md-6 {
                width: 50%;
            }

            .col-md-5 {
                width: 41.66666667%;
            }

            .col-md-4 {
                width: 30%;
            }

            .col-md-3 {
                width: 21% !important;
            }

            .col-md-2 {
                width: 16.66666667%;
            }

            .col-md-1 {
                width: 8.33333333%;
            }

            .col-md-pull-12 {
                right: 100%;
            }

            .col-md-pull-11 {
                right: 91.66666667%;
            }

            .col-md-pull-10 {
                right: 83.33333333%;
            }

            .col-md-pull-9 {
                right: 75%;
            }

            .col-md-pull-8 {
                right: 66.66666667%;
            }

            .col-md-pull-7 {
                right: 58.33333333%;
            }

            .col-md-pull-6 {
                right: 50%;
            }

            .col-md-pull-5 {
                right: 41.66666667%;
            }

            .col-md-pull-4 {
                right: 33.33333333%;
            }

            .col-md-pull-3 {
                right: 25%;
            }

            .col-md-pull-2 {
                right: 16.66666667%;
            }

            .col-md-pull-1 {
                right: 8.33333333%;
            }

            .col-md-pull-0 {
                right: 0;
            }

            .col-md-push-12 {
                left: 100%;
            }

            .col-md-push-11 {
                left: 91.66666667%;
            }

            .col-md-push-10 {
                left: 83.33333333%;
            }

            .col-md-push-9 {
                left: 75%;
            }

            .col-md-push-8 {
                left: 66.66666667%;
            }

            .col-md-push-7 {
                left: 58.33333333%;
            }

            .col-md-push-6 {
                left: 50%;
            }

            .col-md-push-5 {
                left: 41.66666667%;
            }

            .col-md-push-4 {
                left: 33.33333333%;
            }

            .col-md-push-3 {
                left: 25%;
            }

            .col-md-push-2 {
                left: 16.66666667%;
            }

            .col-md-push-1 {
                left: 8.33333333%;
            }

            .col-md-push-0 {
                left: 0;
            }

            .col-md-offset-12 {
                margin-left: 100%;
            }

            .col-md-offset-11 {
                margin-left: 91.66666667%;
            }

            .col-md-offset-10 {
                margin-left: 83.33333333%;
            }

            .col-md-offset-9 {
                margin-left: 75%;
            }

            .col-md-offset-8 {
                margin-left: 66.66666667%;
            }

            .col-md-offset-7 {
                margin-left: 58.33333333%;
            }

            .col-md-offset-6 {
                margin-left: 50%;
            }

            .col-md-offset-5 {
                margin-left: 41.66666667%;
            }

            .col-md-offset-4 {
                margin-left: 33.33333333%;
            }

            .col-md-offset-3 {
                margin-left: 25%;
            }

            .col-md-offset-2 {
                margin-left: 16.66666667%;
            }

            .col-md-offset-1 {
                margin-left: 8.33333333%;
            }

            .col-md-offset-0 {
                margin-left: 0;
            }
        }

        @media (min-width: 1200px) {
            .col-lg-1, .col-lg-2, .col-lg-3, .col-lg-4, .col-lg-5, .col-lg-6, .col-lg-7, .col-lg-8, .col-lg-9, .col-lg-10, .col-lg-11, .col-lg-12 {
                float: left;
            }

            .col-lg-12 {
                width: 100%;
            }

            .col-lg-11 {
                width: 91.66666667%;
            }

            .col-lg-10 {
                width: 83.33333333%;
            }

            .col-lg-9 {
                width: 75%;
            }

            .col-lg-8 {
                width: 66.66666667%;
            }

            .col-lg-7 {
                width: 58.33333333%;
            }

            .col-lg-6 {
                width: 50%;
            }

            .col-lg-5 {
                width: 41.66666667%;
            }

            .col-lg-4 {
                width: 33.33333333%;
            }

            .col-lg-3 {
                width: 21% !important;
            }

            .col-lg-2 {
                width: 16.66666667%;
            }

            .col-lg-1 {
                width: 8.33333333%;
            }

            .col-lg-pull-12 {
                right: 100%;
            }

            .col-lg-pull-11 {
                right: 91.66666667%;
            }

            .col-lg-pull-10 {
                right: 83.33333333%;
            }

            .col-lg-pull-9 {
                right: 75%;
            }

            .col-lg-pull-8 {
                right: 66.66666667%;
            }

            .col-lg-pull-7 {
                right: 58.33333333%;
            }

            .col-lg-pull-6 {
                right: 50%;
            }

            .col-lg-pull-5 {
                right: 41.66666667%;
            }

            .col-lg-pull-4 {
                right: 33.33333333%;
            }

            .col-lg-pull-3 {
                right: 25%;
            }

            .col-lg-pull-2 {
                right: 16.66666667%;
            }

            .col-lg-pull-1 {
                right: 8.33333333%;
            }

            .col-lg-pull-0 {
                right: 0;
            }

            .col-lg-push-12 {
                left: 100%;
            }

            .col-lg-push-11 {
                left: 91.66666667%;
            }

            .col-lg-push-10 {
                left: 83.33333333%;
            }

            .col-lg-push-9 {
                left: 75%;
            }

            .col-lg-push-8 {
                left: 66.66666667%;
            }

            .col-lg-push-7 {
                left: 58.33333333%;
            }

            .col-lg-push-6 {
                left: 50%;
            }

            .col-lg-push-5 {
                left: 41.66666667%;
            }

            .col-lg-push-4 {
                left: 33.33333333%;
            }

            .col-lg-push-3 {
                left: 25%;
            }

            .col-lg-push-2 {
                left: 16.66666667%;
            }

            .col-lg-push-1 {
                left: 8.33333333%;
            }

            .col-lg-push-0 {
                left: 0;
            }

            .col-lg-offset-12 {
                margin-left: 100%;
            }

            .col-lg-offset-11 {
                margin-left: 91.66666667%;
            }

            .col-lg-offset-10 {
                margin-left: 83.33333333%;
            }

            .col-lg-offset-9 {
                margin-left: 75%;
            }

            .col-lg-offset-8 {
                margin-left: 66.66666667%;
            }

            .col-lg-offset-7 {
                margin-left: 58.33333333%;
            }

            .col-lg-offset-6 {
                margin-left: 50%;
            }

            .col-lg-offset-5 {
                margin-left: 41.66666667%;
            }

            .col-lg-offset-4 {
                margin-left: 33.33333333%;
            }

            .col-lg-offset-3 {
                margin-left: 25%;
            }

            .col-lg-offset-2 {
                margin-left: 16.66666667%;
            }

            .col-lg-offset-1 {
                margin-left: 8.33333333%;
            }

            .col-lg-offset-0 {
                margin-left: 0;
            }
        }

        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }
    </style>
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .style10 {
            width: 9px;
            height: 28px;
        }

        .style11 {
            width: 210px;
            height: 28px;
        }

        .style12 {
            width: 212px;
            height: 28px;
        }

        .style13 {
            width: 210px;
            height: 21px;
        }

        .style14 {
            width: 9px;
            height: 21px;
        }

        .style15 {
            height: 21px;
        }

        .style16 {
            width: 212px;
            height: 21px;
        }

        .style17 {
            height: 28px;
        }

        #ContentPlaceHolder1_Button8 {
            background: none !important;
            border: 0px !important;
            color: #fff !important;
            font-weight: 900;
            font-family: revert !important;
        }
    </style>

    <div id="content">
        <div id="content-header">
            <div id="breadcrumb" class="d-none">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <%--<a href="#" class="current">Total HD's Registered</a>--%>
                <%--<a href="#" class="current" runat="server" id="acurrentpage">Preview</a>--%>
            </div>
            <%--<asp:Label ID="acurrentpage" runat="server" Text=""></asp:Label>--%>
            <div class="breadcrumb-bg">
                <ul class="breadcrumb font-medium title5 container">
                    <li class="breadcrumb-item"><a href="<%=Page.ResolveClientUrl("~/UI/UserDashBoard.aspx") %>">Home</a></li>
                    <li class="breadcrumb-item"><a href="#" class="current" runat="server" id="acurrentpage">Preview</a></li>
                </ul>
            </div>
        </div>
        <div class="container mt-4 pb-4" id="Receipt" runat="server">
            <div class="w-100 px-4 frm-form box-content py-4 font-medium title5 mt-sm-5">
                <h5 class="text-blue mt-1 mb-3 font-SemiBold">e - Ticket Abstract</h5>

                <div class="widget-content nopadding">
                    <div class="row">
                        <div class="col-sm-2 form-group">
                            <label class="control-label" id="Label5" runat="server">From Date</label>
                            <asp:TextBox ID="txtFromDate" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2 form-group">
                            <label class="control-label" id="Label3" runat="server">To Date</label>
                            <asp:TextBox ID="txtToDate" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-3" style="padding-top: 30px;">
                            <div class="btn btn-success btn-sm">
                                <asp:Button ID="Button8" runat="server" Class="empty" TabIndex="10" Text="Get Report" OnClick="Button8_Click" />
                                <i class="fa fa-search"></i>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 form-group">
                            <div class="col-sm-12 text-black font-SemiBold mb-1">Total Applications Pending - Application Wise</div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                    CellPadding="4" Height="62px" ShowFooter="True"
                                    PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound">
                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle Font-Bold="true" BackColor="#e9f0fc" Height="30px" CssClass="GridviewScrollC1Header" />
                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                                 <asp:Label ID="lblApplication_code" runat="server" Text='<%# Eval("Application_code") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Application_Name" HeaderText="Application"></asp:BoundField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pending" DataTextField="PENDING">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="col-sm-6 form-group">
                            <div class="col-sm-12 text-black font-SemiBold mb-1">Total Applications Pending - Issue Category Wise</div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                <asp:GridView ID="gvdetailsCategory" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                    CellPadding="4" Height="62px" ShowFooter="True"
                                    PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvdetailsCategory_RowDataBound">
                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle Font-Bold="true" BackColor="#e9f0fc" Height="30px" CssClass="GridviewScrollC1Header" />
                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                                <asp:Label ID="lblintfb_id" runat="server" Text='<%# Eval("intfb_id") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Fb_Type" HeaderText="Issue Category"></asp:BoundField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pending" DataTextField="PENDING">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 form-group">
                            <div class="col-sm-12 text-black font-SemiBold mb-1">Total Applications Pending - Module Wise</div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                <asp:GridView ID="gvdetailsModule" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                    CellPadding="4" Height="62px" ShowFooter="True"
                                    PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvdetailsModule_RowDataBound">
                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle Font-Bold="true" BackColor="#e9f0fc" Height="30px" CssClass="GridviewScrollC1Header" />
                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                                 <asp:Label ID="lblGroupID" runat="server" Text='<%# Eval("GroupID") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="GroupName" HeaderText="Module"></asp:BoundField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pending" DataTextField="PENDING">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="col-sm-6 form-group">
                            <div class="col-sm-12 text-black font-SemiBold mb-1" runat="server" id="divuserHeading">Total Issues Addressed - User Wise</div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                <asp:GridView ID="gvUserWise" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                    CellPadding="4" Height="62px" ShowFooter="True"
                                    PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvUserWise_RowDataBound">
                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle Font-Bold="true" BackColor="#e9f0fc" Height="30px" CssClass="GridviewScrollC1Header" />
                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                                <asp:Label ID="lblUser_id" runat="server" Text='<%# Eval("User_id") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="User_id" HeaderText="Name"></asp:BoundField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Count" DataTextField="SOLCOUNT">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6 form-group">
                            <div class="col-sm-12 text-black font-SemiBold mb-1" runat="server" id="divTicketsHistoryHeading">Total Tickets History</div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                <asp:GridView ID="gvTicketsHistory" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                    CellPadding="4" Height="62px" ShowFooter="True"
                                    PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both" OnRowDataBound="gvTicketsHistory_RowDataBound">
                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle Font-Bold="true" BackColor="#e9f0fc" Height="30px" CssClass="GridviewScrollC1Header" />
                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex +1 %>
                                                <asp:Label ID="lblApplication_codeHistory" runat="server" Text='<%# Eval("APPLICATIONCODE") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="APPLICATION" HeaderText="Application"></asp:BoundField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total Registered" DataTextField="TOTAL_RAISED">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Closed" DataTextField="TOTAL_CLOSED">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pending" DataTextField="TOTAL_PENDING">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Need Approval" DataTextField="NEEDAPPROVAL">
                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                        </asp:HyperLinkField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="<%= Page.ResolveUrl("~/assets/plugins/jquery-1.10.2.js")%>"></script>
    <%--<script src="../assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="../assets/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../assets/plugins/pace/pace.js"></script>
    <script src="../assets/scripts/siminta.js"></script>
  
    <script src="../assets/plugins/morris/raphael-2.1.0.min.js"></script>
    <script src="../assets/plugins/morris/morris.js"></script>
    <script src="../assets/scripts/dashboard-demo.js"></script>--%>

    <link href="<%= Page.ResolveUrl("~/assets/css/jquery-ui-1.8.19.custom.css")%>" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtFromDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtToDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='ContentPlaceHolder1_txtToDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='ContentPlaceHolder1_txtToDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        });


    </script>

    <style type="text/css">
        font- 8pt; i o; d n 0 2 em x e8 {
            x;
        }

        11 {
            ;
            6;
        }

        .auto- e12 {
            height:;
        }

        {
            width: 175p .auo-stye1 wid h: 250;
    </style>
    <style type="text/css">
        .ui-da font-size: 8pt !important; padding: 0.2em 0.2em 0; width: 250px; color: Black;
        }

        select {
            color: Black !important;
        }

        .auto-style1 {
            height: 26px;
        }

        .auto-style2 {
            height: 22px;
        }
    </style>
</asp:Content>
