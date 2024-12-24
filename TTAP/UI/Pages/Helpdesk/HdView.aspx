<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="HdView.aspx.cs" Inherits="eTicketingSystem.UI.Pages.Helpdesk.HdView" %>

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
                <h5 class="text-blue mt-1 mb-3 font-SemiBold">Ticket Information</h5>

                <div class="widget-content nopadding">
                    <div class="row">
                        <div class="col-sm-2 form-group">
                            <label class="control-label" id="tdunitdeptname" runat="server">District</label>
                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="false" class="form-control">
                                <asp:ListItem Value="0">--All--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2 form-group">
                            <label class="control-label" id="Label1" runat="server">Application</label>
                            <asp:DropDownList ID="ddlApplication" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlApplication_SelectedIndexChanged">
                                <asp:ListItem Value="0">--All--</asp:ListItem>
                                <asp:ListItem Value="1">MCC</asp:ListItem>
                                <asp:ListItem Value="2">DCC</asp:ListItem>
                                <asp:ListItem Value="3">Chenchu</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2 form-group">
                            <label class="control-label label-required" id="Label6" runat="server">Main Module</label>
                            <asp:DropDownList ID="ddlModule" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                                <asp:ListItem Value="0">--All--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2 form-group">
                            <label class="control-label label-required" id="Label5" runat="server">Sub Module</label>
                            <asp:DropDownList ID="ddlSubModule" runat="server" class="form-control">
                                <asp:ListItem Value="0">--All--</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-2 form-group" id="divPriorityInput" runat="server">
                            <label class="control-label" id="Label20" runat="server">Priority</label>
                            <asp:DropDownList ID="ddlPriorityInput" runat="server" class="form-control"
                                TabIndex="1" ValidationGroup="group">
                                <asp:ListItem Value="0">--All--</asp:ListItem>
                                <asp:ListItem Value="1"> Critical </asp:ListItem>
                                <asp:ListItem Value="2"> High </asp:ListItem>
                                <asp:ListItem Value="3"> Medium </asp:ListItem>
                                <asp:ListItem Value="4"> Low </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--</div>
                    <div class="row">--%>
                        <div class="col-sm-2 text-center mt-4">
                            <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-blue mx-2" TabIndex="10"
                                Text="Search" ToolTip="To Get data" OnClick="BtnSearch_Click" />
                            <asp:Button ID="BtnClosebatchClear" runat="server" Visible="false" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                TabIndex="10" Text="Clear All" ToolTip="To Clear  the Screen" OnClick="BtnClear_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-12 mb-3 d-flex pt-5">
                            <input type="text" id="search" class="form-control w-sm-50 w-75" style="max-width: 400px;" placeholder="Type to search" />
                            <input type="button" value="Clear" id="clear" class="btn btn-blue ml-2 px-4 py-1 title5" />
                        </div>
                    </div>
                    <table align="center" cellpadding="10" cellspacing="5" style="width: 100%">
                        <tr>
                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                <asp:GridView ID="gvdetailsnew" CssClass="floatingTable1" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                    CellPadding="4" Height="62px"
                                    PageSize="20" Width="100%" Font-Names="Verdana" Font-Size="12px" GridLines="Both">
                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="REQID" ItemStyle-HorizontalAlign="Left" HeaderText="HD Reference No">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Left" HeaderText="District">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Manda_lName" ItemStyle-HorizontalAlign="Left" HeaderText="Mandal">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="APPLICANTNAME" ItemStyle-HorizontalAlign="Left" HeaderText="User Name">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SUBMITIONDATE" ItemStyle-HorizontalAlign="Left" HeaderText="Date of Submission">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fb_Type" ItemStyle-HorizontalAlign="Left" HeaderText="Request Type">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Application" ItemStyle-HorizontalAlign="Left" HeaderText="Application">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="GroupName" ItemStyle-HorizontalAlign="Left" HeaderText="Main Module">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Status" ItemStyle-HorizontalAlign="Left" HeaderText="Status">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Pending_with" ItemStyle-HorizontalAlign="Left" HeaderText="Request Pending With" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Solved_Date" ItemStyle-HorizontalAlign="Left" HeaderText="Date of Response" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SOLVEDBY" ItemStyle-HorizontalAlign="Left" HeaderText="Closed By" Visible="false">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PriorityName" ItemStyle-HorizontalAlign="Left" HeaderText="Priority">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="View" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="anchortaglink" runat="server" Text='<%#Eval("distext")%>' NavigateUrl='<%#Eval("path")%>' Font-Bold="true" ForeColor="Green" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr id="Tr1" runat="server">
                            <td align="left" style="padding: 5px; margin: 5px" valign="top">
                                <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Names="verdana" Font-Size="13px"
                                    ForeColor="#006600"></asp:Label>
                            </td>
                        </tr>
                    </table>

                    <div class="row">
                        <div class="col-sm-12 text-center mt-3">
                            <div id="success" runat="server" visible="false" class="alert alert-success m-0 mt-3">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <strong>Success!</strong><asp:Label ID="Label3" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger m-0 mt-3">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
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



    <script src="<%= Page.ResolveUrl("~/NewCss/js/jquery.min.js")%>"></script>
    <script src="<%= Page.ResolveUrl("~/Js/jquery.floatThead.js")%>"></script>

    <script type="text/javascript">
        $(function () {
            $('#search').val('');
            $('#search1').val('');



            if ($('table.floatingTable1').not('thead')) {
                var len = $('table.floatingTable1 tr').has('th').length;
                $('table.floatingTable1').prepend('<thead></thead>')
                for (i = 0; i < len; i += 1) {
                    $('table.floatingTable1').find('thead').append($('table.floatingTable1').find("tr:eq(" + i + ")"));
                }
            }



            var $table = $('table.floatingTable1');
            $table.floatThead();
            $table.floatThead({ position: 'fixed' });
            $table.floatThead({ autoReflow: 'true' });


        });

        $('#search').keyup(function () {
            var value = $(this).val();
            var patt = new RegExp(value, "i");

            $('#ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                if (!($(this).find('td').text().search(patt) >= 0)) {
                    $(this).not('thead').hide();
                }
                if (($(this).find('td').text().search(patt) >= 0)) {
                    $(this).show();
                }
            });

        });

        $('#clear').click(function () {

            $('#search').val('');
            $('#ContentPlaceHolder1_gvdetailsnew tbody tr').show();
        });
    </script>


</asp:Content>
