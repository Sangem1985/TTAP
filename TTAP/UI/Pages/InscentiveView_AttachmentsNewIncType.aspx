<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InscentiveView_AttachmentsNewIncType.aspx.cs" Inherits="TTAP.UI.Pages.InscentiveView_AttachmentsNewIncType" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department of Handlooms & Textiles | Government of Telangana</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--Added by Pramod--%>
    <link rel="stylesheet" href="../../../AssetsNew/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/style.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/media.css" />
    <%--  <link href="../../../AssetsNew/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>

    <style type="text/css">
        .padding {
            margin: 10px 10px 10px 10px;
            padding-left: 10px;
        }

        .style1 {
            height: 41px;
        }

        tr {
            height: 40px;
        }
    </style>
    <style>
        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }
        .main {
            min-height: 595px;
            min-height: 75.4vh;
            /*background: #f3f8ff;*/
        }

        #collapsibleNavbar .navbar-nav.d-flex.w-50.m-auto {
            margin: 0px !important;
        }

        div#ContentPlaceHolder1_Receipt, .container.mt-4.pb-4, .col-sm-12.offset-md-1.col-md-10.col-lg-10.offset-lg-1.p-4.pb-0.mt-3.frm-form.box-content {
            max-width: 1140px !important;
        }
    </style>
    <%-- <script type="text/javascript">
        $(function () {
            $('#datetimepicker').datetimepicker();
        });
        </script>--%>
    <script type="text/javascript">
         $(document).ready(function () {
            $("input[type=text]").attr('autocomplete', 'off');
        });
        function myFunction() {

            //document.getElementById("Div2").style.visibility = "hidden";
            document.getElementById("DivPrint").style.display = "none";
            //$("#Button2").hide();
            window.print();
            // $("#Button2").show();
            document.getElementById("DivPrint").style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <%--  <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Concession on SGST</li>
                        </ul>--%>
                    </div>
                </div>
                <div class="container mt-4 pb-4" runat="server">
                    <%--<div class="w-100 px-3 frm-form box-content py-3 font-medium title5">--%>
                    <div class="w-100 px-3 frm-form py-3 font-medium title5" runat="server" id="divheader">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <div class="row">
                                        <%--<h3 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Form – VII: Concession on SGST</h3>--%>
                                    </div>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <%-- <table border="1" align="center" cellpadding="1" cellspacing="2" style="border-color: Black; width: 100%;">--%>
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr>
                                                    <td align="center">
                                                        <br />
                                                        <img src="../../images/logo.png" width="75px" height="75px" />
                                                        <br />
                                                        <div>
                                                            <font size="2"><strong style="font-family: Arial">Department of Handlooms and Textiles - Telangana <br />Acknowledgement </strong></font>
                                                        </div>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" width="100%">
                                                        <table align="left" border="1" style="width: 100%; border-right: #000000 thin solid; border-top: #000000 thin solid; border-left: #000000 thin solid; border-bottom: #000000 thin solid; border-collapse: collapse; text-align: left;">
                                                            <tr>
                                                                <td align="right" visible="false" style="text-align: left;" class="tdStyle">Application Number</td>
                                                                <td align="left" class="tdStyle">
                                                                    <asp:Label ID="lblapplicationnumber" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="tdStyle" align="right" style="text-align: left;">Date of Application</td>
                                                                <td class="tdStyle" align="left">
                                                                    <asp:Label ID="lblDateofAppln" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" visible="false" style="text-align: left;" class="tdStyle">EIN/IEM/IL Number :
                                                                </td>
                                                                <td align="left" class="tdStyle">
                                                                    <asp:Label ID="lblEmNo" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="tdStyle" align="right" style="text-align: left;">
                                                                    <asp:Label ID="Label2" runat="server" Text="Category :"></asp:Label>
                                                                </td>
                                                                <td class="tdStyle" align="left">
                                                                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tdStyle" align="right" style="text-align: left;">Unit Name:
                                                                </td>
                                                                <td class="tdStyle" align="left">
                                                                    <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                                                </td>

                                                                <td class="tdStyle" align="right" style="text-align: left;">Applicant Name:
                                                                </td>
                                                                <td class="tdStyle" align="left">
                                                                    <asp:Label ID="lblApplicantname" runat="server"></asp:Label>
                                                                </td>

                                                            </tr>


                                                            <tr>
                                                                <td class="tdStyle" align="right" style="text-align: left;">Mobile Number:
                                                                </td>
                                                                <td class="tdStyle" align="left">
                                                                    <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="tdStyle" align="right" style="width: 120px">&nbsp;
                                                                </td>
                                                                <td class="tdStyle" align="left" style="text-align: left">&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="left">
                                                        <div class="row" id="Div2" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Incentives Applied for</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="gvIncetiveTypes" CssClass="table table-bordered title6 pro-detail w-100 NewEnterprise" runat="server" AutoGenerateColumns="False" Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Incentives">
                                                                            <ItemTemplate>
                                                                                <asp:Label Width="100%" ID="lblIncentiveName" runat="server" Text='<%# Eval("IncentiveName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField ItemStyle-Width="16%" DataField="Total_Amount" HeaderText="Amount Paid" />
                                                                        <asp:BoundField ItemStyle-Width="16%" DataField="FDate" Visible="false" HeaderText="From Date" />
                                                                        <asp:BoundField ItemStyle-Width="16%" DataField="TDate" Visible="false" HeaderText="To Date" />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>
                                    <div class="container" id="DivPrint" runat="server" style="text-align: center; vertical-align: bottom">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                                            <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../NewCss/js/excanvas.min.js"></script>
    <script src="../../../NewCss/js/jquery.ui.custom.js"></script>
    <script src="../../../NewCss/js/bootstrap.min.js"></script>
    <script src="../../../NewCss/js/jquery.flot.min.js"></script>
    <script src="../../../NewCss/js/jquery.flot.resize.min.js"></script>
    <script src="../../../NewCss/js/jquery.peity.min.js"></script>
    <script src="../../../NewCss/js/maruti.js"></script>
    <script src="../../../NewCss/js/maruti.dashboard.js"></script>
    <script src="../../../NewCss/js/maruti.chat.js"></script>
    <%-- <script src="Scripts/bootstrap.min.js"></script>
        <script src="../../../Scripts/jquery-3.3.1.min.js"></script>
        <script src="../../../Scripts/jquery-3.3.1.js"></script>
        <script src="../../../AssetsNew/js/bootstrap-datetimepicker.min.js"></script>--%>
    <script type="text/javascript">
        // This function is called from the pop-up menus to transfer to
        // a different page. Ignore if the value returned is a null string:
        function goPage(newURL) {

            // if url is empty, skip the menu dividers and reset the menu selection to default
            if (newURL != "") {

                // if url is "-", it is this page -- reset the menu:
                if (newURL == "-") {
                    resetMenu();
                }
                // else, send page to designated URL            
                else {
                    document.location.href = newURL;
                }
            }
        }

        // resets the menu selection upon entry to this page:
        function resetMenu() {
            document.gomenu.selector.selectedIndex = 2;
        }
    </script>
    <script src="../../../AssetsNew/js/popper.min.js"></script>
    <script src="../../../AssetsNew/js/bootstrap.min.js"></script>
    <script src="../../../AssetsNew/js/floating.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $(function () {
                var url = window.location.pathname,
                    urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");
                // now grab every link from the navigation
                $('.navbar a, footer a').each(function () {
                    // and test its normalized href against the url pathname regexp
                    if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
                        $(this).addClass('active');
                    }
                });
            });
        });
    </script>
</body>
</html>
