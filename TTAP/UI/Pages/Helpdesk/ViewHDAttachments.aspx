<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="ViewHDAttachments.aspx.cs" Inherits="eTicketingSystem.UI.Pages.Helpdesk.ViewHDAttachments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div id="content">
        <%--<div id="content-header">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Helpdesk Attachemnts</a>
            </div>
            <h1>Fill Industry Details</h1>
        </div>--%>
        <div id="content-header">
            <div id="breadcrumb" class="d-none">
                <a href="#" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Helpdesk Attachemnts</a>
            </div>
            <div class="breadcrumb-bg">
                <ul class="breadcrumb font-medium title5 container">
                    <li class="breadcrumb-item"><a href="<%=Page.ResolveClientUrl("~/UI/UserDashBoard.aspx") %>">Home</a></li>
                    <li class="breadcrumb-item">Helpdesk Attachemnts</li>
                </ul>
            </div>
            <%--  <h1>Fill Industry Details</h1>--%>
        </div>
        <div class="container mt-4 pb-4" id="Div1" runat="server">
            <div class="w-100 px-4 frm-form box-content py-4 font-medium title5 mt-sm-5">



                <asp:UpdatePanel ID="upd1" runat="server">
                    <ContentTemplate>
                        <h5 class="text-black mt-1 mb-3 font-SemiBold">Attachments Uploaded by User </h5>

                        <div class="widget-content nopadding">
                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td style="padding: 5px; margin: 5px" align="left"></td>
                                </tr>
                                <tr id="Trqueryresponceattachemnts" runat="server" visible="false">
                                    <td style="padding-left: 100px; margin: 5px;" colspan="8">
                                        <asp:GridView ID="gvqueryresponse" runat="server" AutoGenerateColumns="False"
                                            Width="80%" HorizontalAlign="Left" ShowHeader="true">
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="50px" HorizontalAlign="center" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="REQID" HeaderText="Request ID">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Created_dt" HeaderText="Date of Uploaded">
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLinkSubsidy" Text='<%#Eval("FileName")%>' NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>


                            </table>

                        </div>



                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget-box">
                                    <div class="widget-title">
                                        <span class="icon">
                                            <i class="icon-info-sign"></i>
                                        </span>
                                          <h5 class="text-black mt-1 mb-3 font-SemiBold">Attachments Uploaded by Department </h5>
                                      
                                    </div>
                                    <div class="widget-content nopadding">
                                        <table cellpadding="4" cellspacing="5" style="width: 100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px" align="left"></td>
                                            </tr>
                                            <tr id="trdeptattachments" runat="server" visible="false">
                                                <td style="padding-left: 100px; margin: 5px;" colspan="8">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                                        Width="80%" HorizontalAlign="Left" ShowHeader="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" HorizontalAlign="center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="REQID" HeaderText="Request ID">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="OfficerName" HeaderText="Replied by">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Created_dt" HeaderText="Date of Uploaded">
                                                                <ItemStyle HorizontalAlign="Left" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLinkSubsidy" Text='<%#Eval("FileName")%>' NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                                </ItemTemplate>

                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>

                            <table align="center" cellpadding="10" cellspacing="5" style="width: 80%">
                                <tr>
                                    <td align="center" style="padding: 5px; margin: 5px">

                                        <div id="success" runat="server" class="alert alert-success" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                        <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                            <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>

                            </table>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upd1">
                                <ProgressTemplate>
                                    <div class="update">
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                    </ContentTemplate>
                </asp:UpdatePanel>

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
