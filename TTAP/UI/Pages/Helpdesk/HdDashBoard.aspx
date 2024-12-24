<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="HdDashBoard.aspx.cs" Inherits="eTicketingSystem.UI.Pages.Helpdesk.HdDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <!-- Core CSS - Include with every page -->

    <%-- <link href="assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />--%>


    <link href="<%= Page.ResolveUrl("~/assets/plugins/pace/pace-theme-big-counter.css")%>" rel="stylesheet" />
    <%-- <link href="../assets/css/style.css" rel="stylesheet" />--%>
    <link href="<%= Page.ResolveUrl("~/assets/css/main-style.css")%>" rel="stylesheet" />
    <link href="<%= Page.ResolveUrl("~/assets/css/custom.css")%>" rel="stylesheet" />
    <!-- Page-Level CSS -->
    <link href="<%= Page.ResolveUrl("~/assets/plugins/morris/morris-0.4.3.min.css")%>" rel="stylesheet" />
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

        .widget-content {
            padding: 29px 68px !important;
        }
    </style>
    <div id="content">
        <%--<div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="A1" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="a2">Dashboard</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Dashboard</li>
                        </ul>
                    </div>
                   

                </div>--%>
        <div id="content-header">
            <div id="breadcrumb" class="d-none">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Dashboard</a>
            </div>
            <div class="breadcrumb-bg">
                <ul class="breadcrumb font-medium title5 container">
                     <li class="breadcrumb-item"><a href="<%=Page.ResolveClientUrl("~/UI/UserDashBoard.aspx") %>">Home</a></li>
                    <li class="breadcrumb-item">Dashboard</li>
                </ul>
            </div>
            <%--  <h1>Fill Industry Details</h1>--%>
        </div>
        <div class="container mt-4 pb-4" id="Receipt" runat="server">
            <div class="w-100 px-4 frm-form box-content py-4 font-medium title5 mt-sm-5">
                <h5 class="text-blue mt-1 mb-3 font-SemiBold">Dashboard</h5>


                <div class="widget-content">

                    <div class="row">
                        <!--quick info section -->
                        <div class="col-lg-3" style="display: none">
                            <div class="alert alert-danger text-center">
                                <i class="fa fa-calendar fa-3x"></i>&nbsp;<b><asp:Label ID="lblmeetings" runat="server" Text=""></asp:Label>
                                </b>Meetings Sheduled This Month

                            </div>
                        </div>
                        <%--   <div class="col-lg-3">
                                    <div class="alert alert-info text-center">
                                        <i class="fa fa-rss fa-3x"></i>22222<b></b>&nbsp;&nbsp;&nbsp;&nbsp;Total Users Registered

                                    </div>
                                </div>--%>

                        <!--end quick info section -->
                    </div>

                    <div class="row" style="display: none">
                        <div class="col-md-4">
                            <a href="UsersList.aspx?STATUS=2" style="color: black">
                                <div class="panel panel-primary text-center no-boder">
                                    <div class="panel-body yellow">
                                        <i class="fa fa-bar-chart-o fa-3x"></i>
                                        <h3>
                                            <asp:Label ID="lbldailyusersvisit" runat="server" Text=""></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="panel-footer">
                                        <span class="panel-eyecandy-title">Today - User Visits
                                        </span>
                                    </div>
                                </div>

                            </a>

                        </div>
                        <div class="col-md-4">
                            <a href="UsersList.aspx?STATUS=3" style="color: black">
                                <div class="panel panel-primary text-center no-boder">
                                    <div class="panel-body red">
                                        <i class="fa fa-thumbs-up fa-3x"></i>
                                        <h3>
                                            <asp:Label ID="lbltodayreg" runat="server" Text=""></asp:Label>
                                        </h3>
                                    </div>
                                    <div class="panel-footer">
                                        <span class="panel-eyecandy-title">Today -New User Registered
                                        </span>
                                    </div>
                                </div>
                            </a>
                        </div>
                        <div class="col-md-4">
                            <a href="UsersList.aspx?STATUS=1" style="color: black">
                                <div class="panel panel-primary text-center no-boder">
                                    <div class="panel-body blue">

                                        <i class="fa fa-pencil-square-o fa-3x"></i>
                                        <h3>
                                            <asp:Label ID="lbltotalusers" runat="server" Text=""> </asp:Label></h3>
                                    </div>
                                    <div class="panel-footer">
                                        <span class="panel-eyecandy-title">Total Users Registered
                                        </span>
                                    </div>
                                </div>
                            </a>
                        </div>

                    </div>

                    <%--new code--%>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="main-box mb-red">
                                <a href="HdView.aspx?STATUS=3">
                                    <i class="fa fa-bolt fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lbltotaliises" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp;
                                        <span id="spanTotalhds" runat="server">Total ET's Registred </span>
                                    </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=2">
                                    <i class="fa  fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblcompleted" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp;Total ET's Closed </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=1">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblpending" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp; Total ET's Pending </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=4">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblrejected" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp; Total ET's Rejected </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3" id="divDoUser" runat="server" visible="false">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=10">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblTotalHDForwarded" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp; Total ET's Forwarded </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3" id="divDoUserPending" runat="server" visible="false">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=11">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblPendingHDForwarded" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp;  ET's Forwarded - Pending </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3" id="divDoUserClosed" runat="server" visible="false">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=12">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblClosedHDForwarded" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp;  ET's Forwarded - Closed </h5>
                                </a>
                            </div>
                        </div>
                    </div>

                    <div class="row" id="DivTechTeamDashboard" runat="server" visible="false">
                        <div class="col-md-3" id="div1" runat="server">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=20">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblTotalApproval" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp; Total ET's Sent For Approval </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3" id="div2" runat="server">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=21">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblPendinglApproval" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp;  ET's Approval Request - Pending </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3" id="div3" runat="server">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=22">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblReceivedApproval" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp;  ET's Approval Request- Received </h5>
                                </a>
                            </div>
                        </div>
                        <div class="col-md-3" id="div4" runat="server">
                            <div class="main-box mb-dull">
                                <a href="HdView.aspx?STATUS=23">
                                    <i class="fa fa-pencil fa-5x"></i>
                                    <h5>
                                        <asp:Label ID="lblClosedApproval" Font-Bold="true" runat="server" Text=""></asp:Label>
                                        &nbsp;- &nbsp;  ET's Approval Request- Closed </h5>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../assets/plugins/jquery-1.10.2.js"></script>
    <script src="../assets/plugins/bootstrap/bootstrap.min.js"></script>
    <script src="../assets/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../assets/plugins/pace/pace.js"></script>
    <script src="../assets/scripts/siminta.js"></script>
    <!-- Page-Level Plugin Scripts-->
    <script src="../assets/plugins/morris/raphael-2.1.0.min.js"></script>
    <script src="../assets/plugins/morris/morris.js"></script>
    <script src="../assets/scripts/dashboard-demo.js"></script>
</asp:Content>
