<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmacknowledgement.aspx.cs" Inherits="TTAP.UI.Pages.frmacknowledgement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department of Handlooms & Textiles | Government of Telangana</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--Added by Pramod--%>
    <link rel="stylesheet" href="../../AssetsNew/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/style.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/media.css" />


    <style type="text/css">
        .leftalign {
            text-align: left;
        }

        .rightalign {
            text-align: right;
        }

        .floatleft {
            float: left;
        }

        body {
            background-color: #ffffff;
        }
    </style>
    <style type="text/css">
        .auto-style3 {
            text-align: justify;
        }

        .auto-style4 {
            text-align: left;
        }

        .auto-style5 {
            text-align: center;
        }

        .auto-style6 {
            text-decoration: underline;
        }

        .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
            border: 1px solid #000000 !important;
            padding: 2px !important;
        }
    </style>
    <%--  <link href="../../AssetsNew/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>

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
                                            <div class="container" id="Receipt" runat="server" style="border: 1px solid #000000; text-align: center;">

                                                <img src="../../images/logo.png" style="width: 75px; height: 75px;" alt="" />
                                                <asp:Label ID="lblheadTPRIDE" Font-Bold="true" Font-Size="12pt" runat="server"> 
                                                <h5 style="color: #0000FF;">
                                                Office Of The Director of Handlooms and Textiles<br />
                                                Government of Telangana</h5>

                                                </asp:Label>
                                                <h6 style="font-weight: bold">Acknowledgement</h6>
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                                                    <div class="row">
                                                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                                            <span style="float: left;"><span style="float: left;"><b>To</b></span><br />
                                                                M/s. 
                                                                 <asp:Label ID="lblUnitName" runat="server"></asp:Label>,<br />
                                                                UID No :
                                                                <asp:Label ID="lblUidNO" runat="server"></asp:Label>,<br />
                                                                CAF No :
                                                                <asp:Label ID="lblapplicationnumber" runat="server"></asp:Label>
                                                            </span>
                                                        </div>
                                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2"></div>
                                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                                            <span style="float: right;"><span style="float: left;"><b>Date : </b>
                                                                <asp:Label ID="lblDateofAppln" runat="server"></asp:Label>
                                                            </span>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 30px">
                                                            <span class="floatleft auto-style3"><span style="font-weight: bold">Subject :-</span>
                                                                Information for Incentive Processing
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 30px">
                                                            <span class="floatleft" style="font-weight: bold">Dear Sir/Madam,</span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px;">
                                                            <span class="floatleft auto-style3">This is to acknowledge that the information for pre-processing your application(s) for Incentives/Subsidies as furnished by you on the online portal has been received. The information is under examination by the concerned authority of the department. Any other clarification, if required from you will be notified through email, the address of which is provided in your application
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 30px">
                                                            <span class="floatleft" style="font-weight: bold">This is a System Generated Letter Which Requires No Signature</span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 25px; padding-bottom: 10px; text-align: left">
                                                            <span class=" pull-left"><span style="font-weight: bold">Thanking you,</span><br />
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; padding-bottom: 10px; text-align: left">
                                                            <span class=" pull-left"><span style="font-weight: bold">Your Sincerely,</span><br />
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 25px; padding-bottom: 10px; text-align: left">
                                                            <span class=" pull-left"><span style="font-weight: bold">System In-Charge</span><br />
                                                                T-TAP Online
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="container" id="DivPrint" runat="server" style="text-align: center; vertical-align: bottom">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                                             <asp:Button ID="btnInstalledcap" runat="server" CssClass="btn btn-blue btn-lg"  Text="Home" OnClick="btnInstalledcap_Click" />
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
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../NewCss/js/excanvas.min.js"></script>
    <script src="../../NewCss/js/jquery.ui.custom.js"></script>
    <script src="../../NewCss/js/bootstrap.min.js"></script>
    <script src="../../NewCss/js/jquery.flot.min.js"></script>
    <script src="../../NewCss/js/jquery.flot.resize.min.js"></script>
    <script src="../../NewCss/js/jquery.peity.min.js"></script>
    <script src="../../NewCss/js/maruti.js"></script>
    <script src="../../NewCss/js/maruti.dashboard.js"></script>
    <script src="../../NewCss/js/maruti.chat.js"></script>
    <%-- <script src="Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/jquery-3.3.1.min.js"></script>
        <script src="../../Scripts/jquery-3.3.1.js"></script>
        <script src="../../AssetsNew/js/bootstrap-datetimepicker.min.js"></script>--%>
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
    <script src="../../AssetsNew/js/popper.min.js"></script>
    <script src="../../AssetsNew/js/bootstrap.min.js"></script>
    <script src="../../AssetsNew/js/floating.js"></script>
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
