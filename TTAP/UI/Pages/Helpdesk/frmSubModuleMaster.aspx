<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmSubModuleMaster.aspx.cs" Inherits="TTAP.UI.frmSubModuleMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

        .widget-content {
            padding: 29px 68px !important;
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        #ContentPlaceHolder1_Button8 {
            background: none !important;
            border: 0px !important;
            color: #fff !important;
            font-weight: 900;
            font-family: revert !important;
        }

        .table td, .table th {
            padding: 0.25rem !important;
        }

        .table tbody td {
            padding: 5px .25rem !important;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%-- <Triggers>
            <asp:PostBackTrigger ControlID="Button8" />
        </Triggers>--%>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" title="Go to Home" class="tip-bottom" runat="server" id="ehome"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current">Module Entry</a>
                    </div>
                    Module Entry
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="<%=Page.ResolveClientUrl("~/UI/UserDashBoard.aspx") %>">Home</a></li>
                            <li class="breadcrumb-item">Module Entry</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <%-- <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">--%>
                    <div class="col-sm-12 offset-md-1 col-md-10 col-lg-10 offset-lg-1 frm-form box-content py-3 font-medium title5">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold">Module Entry</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label3" runat="server">Application</label>
                                            <asp:DropDownList ID="ddlApplication" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlApplication_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label1" runat="server">Module</label>
                                            <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="true" class="form-control">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label6" runat="server">Sub Module</label>
                                            <asp:TextBox ID="txtSubModule" runat="server" class="form-control"
                                                MaxLength="200"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 text-center mt-4">
                                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-blue mx-2" TabIndex="10"
                                                Text="Add New" ToolTip="To Save  the data" ValidationGroup="group" OnClick="BtnSave_Click" />
                                            <asp:Button ID="BtnClosebatchClear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                TabIndex="10" Text="Clear All" ToolTip="To Clear  the Screen" OnClick="BtnClosebatchClear_Click" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvDetails" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="gvDetails_RowCommand">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Application">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplication_Name" runat="server" Text='<%#Eval("Application_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Main Module">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblGroupName" runat="server" Text='<%#Eval("GroupName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sub Module">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblModule_Desc" runat="server" Text='<%#Eval("Module_Desc") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlSaleEdit" CommandName="Rowedit" CssClass="btn btn-warning btn-sm" runat="server" Text="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlSaleDelete" CommandName="RowDdelete" CssClass="btn btn-danger btn-sm" runat="server" Text="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Ids" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplicationId" runat="server" Visible="false" Text='<%# Bind("ApplicationId") %>'></asp:Label>
                                                            <asp:Label ID="lblMainModule_Code" runat="server" Visible="false" Text='<%# Bind("GroupID") %>'></asp:Label>
                                                            <asp:Label ID="lblModule_Code" runat="server" Visible="false" Text='<%# Bind("Module_Code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <table align="center" class="w-100">
                                    <tr>
                                        <td align="center">
                                            <%--<b style="color: rgb(255, 0, 0); font-family: arial, sans-serif; font-size: medium; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
                                            Your Helpdesk will be redressed within 24 hours. In case of any delay kindly 
                                            contact to Toll Free No: 7306-600-600.</b>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <div id="success" runat="server" visible="false" class="alert alert-success m-0 mt-3">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger m-0 mt-3">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                                <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </div>
                        </div>
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
