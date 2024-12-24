<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAssistanceforAcquisitionAnnexure.aspx.cs" Inherits="TTAP.UI.Pages.Annexures.frmAssistanceforAcquisitionAnnexure" %>

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


    <style>
        .main {
            min-height: 595px;
            min-height: 75.4vh;
            /*background: #f3f8ff;*/
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
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
                                        <h3 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Form – IX : Assistance for Acquisition of New Technology(Audit)</h3>
                                    </div>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 50%">Name of The Enterprise</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtUnitName" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">2</td>
                                                    <td align="left" style="width: 50%">UID Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTSIPassUIDNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">3</td>
                                                    <td align="left">Common Application Number </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblCommonApplicationNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Type of Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTypeofApplicant" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Commencement of Commercial Production </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblDCPdate" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">6</td>
                                                    <td align="left">Category of New Unit as per T-TAP Policy </td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblCategoryofUnit"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Activity of the Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblActivityoftheUnit"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">New Technology Developed</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNewTechnologyDeveloped" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">9</td>
                                                    <td align="left">Is the Technology Imported</td>
                                                    <td align="left">
                                                        <label class="control-label" id="RbtnIstheTechnologyImported" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">10</td>
                                                    <td align="left">Value addition for adoption of new technology</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtValueadditionnewtechnology" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">11</td>
                                                    <td align="left">New technology developed for adaptation to local conditions</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNewtechnologydevelopedadaptation" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">12</td>
                                                    <td align="left">Details of R&D Institutions/Experts and Technology details</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtRDDetails" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">13</td>
                                                    <td align="left">Cost Incurred in Development of New Technology</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtCostIncurredinDevelopment" runat="server"></label>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">14</td>
                                                    <td align="left">Current Claim (In Rupees) (50% of the cost limited to Rs 10 lakhs)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtCurrentClaim" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">15</td>
                                                    <td align="left">Benefit availed under any other State Scheme (In Rupees)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtBenefitavailed" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="2">
                                                        <div class="row" id="Div4" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">List of Enclosures Attached</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                                    HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="gvSubsidy_RowDataBound">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="60px" CssClass="text-center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Status" ItemStyle-Width="200px" ControlStyle-Width="200px">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNoofmachines" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <div class="col-sm-12 py-4">
                                                            <b>Note : </b>1). If any further information/documents required by the department, the same shall be furnished by the entrepreneur.
                                                            <br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        2). If any errors found in the data, the same will have to be rectified by the entrepreneurs, then only the provisional incentive will be finalized.
                                                        </div>
                                                        <div class="col-sm-12">
                                                            <b>DECLARATION : </b>
                                                            <br />
                                                            I / We hereby confirm that to the best of my / our knowledge and belief, information given herein before and other papers enclosed are true and correct in all respects. I / We further undertake to substantiate the particulars about promoter(s) and other details with documentary evidence as and when called for.<br />
                                                            <br />
                                                            I/We hereby agree that I/We shall forthwith repay the amount disbursed to me/us under the scheme, if the amount of Reimbursement is found to be disbursed in excess of the amount actually admissible whatsoever the reason.
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
