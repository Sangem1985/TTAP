<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="DashboardReport.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.DashboardReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
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

        .HyperClass {
            cursor: pointer;
            color: blue;
        }
    </style>
    <script src="../../../NewCss/js/jquery.min.js"></script>
    <script src="../../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery.floatThead.js"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Applications</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="../frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="frmIncentiveReports.aspx">Reports</a></li>
                            <li class="breadcrumb-item">Total Status Report</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <table id="tblDateSelect" style="margin: 0px 0px 0px 232px;">
                            <tr>
                                <td>From Date</td>
                                <td>
                                    <input type="date" runat="server" id="Fromdate" />
                                </td>
                                <td>To Date</td>
                                <td>
                                    <input type="date" runat="server" id="Todate" />
                                </td>
                                <td>
                                    <asp:Button Text="Get Report" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                </td>
                                <td>
                                    <input type="checkbox" runat="server" id="chkDate" />
                                </td>
                                <td>Date Wise</td>
                            </tr>
                        </table>
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="Header" style="margin: 0px 0px 0px 350px;"
                            runat="server">T-TAP - Total Status Report</h5>
                        <div class="widget-content nopadding">
                            <div class="row" style="width: 47%; margin: 0px 0px 0px 270px;">

                                <div class="col-sm-12 table-responsive">

                                    <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                        <tr>
                                            <td runat="server" width="40%">
                                                <asp:Label runat="server">Total No of Units Applied for Incentives</asp:Label>
                                            </td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalUnitss" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('U')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="40%" >Total Local Employment Provided by the Units</t>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalEmployment" ToolTip="Click here to get Break up Report" onclick="return Navigate('U')" CssClass="font-weight-bold" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td width="40%" >Total Nonlocal Employment Provided by the Units</t>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdNonlocalEmployement" ToolTip="Click here to get Break up Report" onclick="return Navigate('U')" CssClass="font-weight-bold" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="40%">Total Amount Invested by the Units</td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalInvestment" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('U')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="40%">Total No of Incentive Applications Received</td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalIncentives" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('I')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="40%">Total Amount of Subsidy Claimed</td>
                                            <td style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalSubsidyClaimed" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('I')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trSanctionedInc">
                                            <td width="40%">Total No of Incentive Claims Sanctioned</td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalSanctionedInc" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('S')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trSanctionedAmount">
                                            <td width="40%">Total Subsidy Amount Sanctioned</td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalSubsidySanctioned" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('S')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <asp:Button Text="Print" ID="btnprint" runat="server" Style="margin: 0px 0px 0px 522px; background: chartreuse; width: 8%;" OnClientClick="return Print();return false;" />
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnDistName" runat="server" />
            <asp:HiddenField ID="hdnDistId" runat="server" />
            <asp:HiddenField ID="hdnFlag" runat="server" />
            <asp:HiddenField ID="hdnFlagDesc" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery.sticky/1.0.4/jquery.sticky.min.js"></script>--%>


    <script type="text/javascript">

        /*function pageLoad() {
            var CurrentDate = new Date().format('dd-MMM-yyyy HH:mm');
            var Header = "T-TAP - Total Status Report as on " + CurrentDate;
            $("#ContentPlaceHolder1_Header").html(Header);
        }*/
        function Print() {
            $('#tblDateSelect').hide();
            $('#ContentPlaceHolder1_btnprint').hide();
            if ($('#ContentPlaceHolder1_chkDate').is(':checked') == true) {
                $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 215px");
            }
            else {
                $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 280px");
            }
            window.print();
            $('#tblDateSelect').show();
            $('#ContentPlaceHolder1_btnprint').show();
            if ($('#ContentPlaceHolder1_chkDate').is(':checked') == true) {
                $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 286px");
            }
            else {
                $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 350px");
            }
            return false;
        }
        jQuery(document).bind("keyup keydown", function (e) {
            if (e.ctrlKey && e.keyCode == 80) {
                Print();
                return false;
            }
        });
        function Navigate(res) {
            var DateFlag = ""; var FromDt = ""; var ToDt = "";
            if ($('#ContentPlaceHolder1_chkDate').is(':checked') == true) {
                DateFlag = 'D'; FromDt = $('#ContentPlaceHolder1_Fromdate').val(); ToDt = $('#ContentPlaceHolder1_Todate').val();
                if (res == "U") {
                    window.open("FormUnitReport.aspx?DateFlag=" + DateFlag + "&FromDt=" + FromDt + "&ToDt=" + ToDt);
                    return false;
                }
                if (res == "I") {
                    window.open("FormIncentivesReportView.aspx?DateFlag=" + DateFlag + "&FromDt=" + FromDt + "&ToDt=" + ToDt + "&Level=2&Flag=T&DistrictId=0");
                    return false;
                }
                if (res == "S") {
                    window.open("FormIncentivesReportView.aspx?DateFlag=" + DateFlag + "&FromDt=" + FromDt + "&ToDt=" + ToDt + "&Level=2&Flag=S&DistrictId=0");
                    return false;
                }
            }
            else {
                if (res == "U") {
                    window.open("FormUnitReport.aspx");
                    return false;
                }
                if (res == "I") {
                    window.open("FormIncentivesReportView.aspx?Level=2&Flag=T&DistrictId=0");
                    return false;
                }
                if (res == "S") {
                    window.open("FormIncentivesReportView.aspx?Level=2&Flag=S&DistrictId=0");
                    return false;
                }
            }
            //NavigateUrl="FormIncentivesReportView.aspx?Level=2&Flag=T&DistrictId=0"  

        }
    </script>

</asp:Content>
