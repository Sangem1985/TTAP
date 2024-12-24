<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="FormIncentivesReportView.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.FormIncentivesReportView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="A2" />
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
                            <li class="breadcrumb-item">Incentive Applications</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="Header" runat="server">Incentives</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div class="col-sm-12 mb-3 d-flex">
                                    <asp:TextBox ID="txtsearch" runat="server" class="form-control w-sm-50 w-75" Style="max-width: 400px;" placeholder="Type to search"></asp:TextBox>
                                    <asp:Button Text="Search" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                    <asp:Button Text="Reset" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnReset" runat="server" OnClick="btnReset_Click" />
                                    &nbsp  &nbsp  &nbsp
                                    <asp:CheckBox ID="chklistView" Style="margin: 6px 0px 0px 10px;"
                                        AutoPostBack="true" Text="List View" OnCheckedChanged="chklistView_CheckedChanged" runat="server" Visible="false" />
                                   

                                    <label style="margin: 6px 4px 5px 16px; display: none;">
                                        District : 
                                    </label>
                                    <asp:DropDownList ID="ddlDistrict" Style="display: none;" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" runat="server"></asp:DropDownList>
                                </div>
                                <div align="center" class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                        </tr>
                                    </table>
                                </div>
                                <div align="center" class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a id="A2" href="#" class="tags" onserverclick="BtnExportExcel_Click" gloss="Export to Excel" runat="server" style="float: right">
                                                    <img src="../../../images/Excel-icon.png" style="margin: 0px 0px 0px 15px;" width="30px" height="30px"
                                                        alt="Excel" /></a>
                                            </td>
                                            <td>
                                                <label id="lbldistrict" style="color: #e90e0e; font-size: large; font-family: 'Montserrat-SemiBold'; margin-left: 315px; display: block;"
                                                    runat="server">
                                                </label>
                                            </td>
                                            <td>
                                                <label id="lblDesc" style="color: #e90e0e; font-size: large; font-family: 'Montserrat-SemiBold'; margin-left: 118px; display: block;"
                                                    runat="server">
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>

                                <div id="TotalGrid" runat="server" class="col-sm-12 table-responsive">

                                    <div id="container" style="overflow: scroll; overflow-x: hidden;">
                                    </div>
                                    <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" Font-Bold="false"
                                        PageSize="20" GridLines="Both">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DistrictName" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Address" ItemStyle-HorizontalAlign="Center" HeaderText="Address">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCP" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Commencement of Production">
                                                <ItemStyle CssClass="Center" />
                                            </asp:BoundField>
                                            <%--  <asp:BoundField DataField="ApplicationNumber" ItemStyle-HorizontalAlign="Center" HeaderText="Application Number">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Application Number" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="#/" onclick="javascript:Navigate(<%# Eval("IncentiveId") %>);"><%# Eval("ApplicationNumber") %></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SubmissionDate" ItemStyle-HorizontalAlign="Center" HeaderText="Submitted Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Payment Verified Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ScrutinyCompletedDate" ItemStyle-HorizontalAlign="Center" HeaderText="DLO Received Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           <%-- <asp:BoundField DataField="PedingatDLO" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Red" HeaderText="Pending DayCount">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeofTexttileText" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Textile">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ActualRecommendedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Recommended Amount">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SVC_FinalSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sanctioned_Date" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SVC_Meeting_No" ItemStyle-HorizontalAlign="Center" HeaderText="SVC No">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STATUS" ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ClaimAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Claim Amount">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Released_Amount" ItemStyle-HorizontalAlign="Center" HeaderText="Released Amount">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Released_Date" ItemStyle-HorizontalAlign="Center" HeaderText="Released Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="QueryRaisedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="QueryPendingDays" ItemStyle-HorizontalAlign="Center" HeaderText="Pending Days at Applicant">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="RejectedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Rejected Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="RejectedRemarks" ItemStyle-HorizontalAlign="Center" HeaderText="Rejected Remarks">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NoofReminders" ItemStyle-HorizontalAlign="Center" HeaderText="No of Reminders Sent">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="LastReminderDt" ItemStyle-HorizontalAlign="Center" HeaderText="Last Reminder Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center">No Data Found</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                                <div id="divList" visible="false" runat="server" class="col-sm-12 table-responsive">

                                    <div id="container1" style="overflow: scroll; overflow-x: hidden;">
                                    </div>
                                    <asp:GridView ID="gvListView" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" Font-Bold="false"
                                        PageSize="20" GridLines="Both" OnRowDataBound="gvListView_RowDataBound">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="S No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSlno" Text='<%#Eval("SUBSLNO") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Left" HeaderText="Incentive Name/Unit Name" Target="_blank"
                                                DataTextField="IncentiveName">
                                                <FooterStyle HorizontalAlign="Left" Font-Underline="false" Font-Bold="true" CssClass="text-left" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="left" CssClass="text-left" />
                                            </asp:HyperLinkField>
                                            <%--<asp:BoundField DataField="IncentiveName"  ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name/Unit Name ">
                                                 <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                            <%-- <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                            <%--  <asp:BoundField DataField="DistrictName" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                            <%--<asp:BoundField DataField="Address" ItemStyle-HorizontalAlign="Center" HeaderText="Address">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCP" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Commencement of Production">
                                                <ItemStyle CssClass="Center" />
                                            </asp:BoundField>
                                            <%-- <asp:TemplateField HeaderText="Application Number" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="#/" onclick="javascript:Navigate(<%# Eval("IncentiveId") %>);"><%# Eval("ApplicationNumber") %></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SubmissionDate" ItemStyle-HorizontalAlign="Center" HeaderText="Submitted Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Payment Verified Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ScrutinyCompletedDate" ItemStyle-HorizontalAlign="Center" HeaderText="DLO Received Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="PedingatDLO" ItemStyle-HorizontalAlign="Center" ItemStyle-ForeColor="Red" HeaderText="Pending DayCount">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeofTexttileText" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Textile">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="ActualRecommendedAmount"   ItemStyle-HorizontalAlign="Center" HeaderText="Recommended Amount">
                                                 <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SVC_FinalSanctionedAmount"   ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                 <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Sanctioned_Date"  ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                 <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SVC_Meeting_No"  ItemStyle-HorizontalAlign="Center"  HeaderText="SVC No">
                                                 <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STATUS" ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="ClaimAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Claim Amount">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="Released_Amount" ItemStyle-HorizontalAlign="Center" HeaderText="Released Amount">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="Released_Date"  ItemStyle-HorizontalAlign="Center" HeaderText="Released Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                    <asp:Label ID="lblUnitName" Text='<%#Eval("UnitName") %>' runat="server" />
                                                    <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                    <asp:Label ID="lblUnitID" Text='<%#Eval("CreateBy") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center">No Data Found</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnDistName" runat="server" />
            <asp:HiddenField ID="hdnDistId" runat="server" />
            <asp:HiddenField ID="hdnFlag" runat="server" />
            <asp:HiddenField ID="hdnFlagDesc" runat="server" />
            <asp:HiddenField ID="hdnDateFlag" runat="server" />
            <asp:HiddenField ID="hdnFromDate" runat="server" />
            <asp:HiddenField ID="hdnToDate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery.sticky/1.0.4/jquery.sticky.min.js"></script>--%>

    <script src="../../../NewCss/js/jquery.min.js"></script>
    <script src="../../../js/jquery.floatThead.js"></script>
    <script type="text/javascript">
        function pageLoad() {

            var Count1 = $('#ContentPlaceHolder1_TotalGrid').find('.GridviewScrollC1Item').length;
            var Count2 = $('#ContentPlaceHolder1_TotalGrid').find('.GridviewScrollC1Item2').length;
            // var Count=
            var TotalCount = "Total Incentives - " + (parseInt(Count1) + parseInt(Count2));
            if ($('#ContentPlaceHolder1_hdnDateFlag').val() == "D") {
                TotalCount = "Total Incentives - " + (parseInt(Count1) + parseInt(Count2)) + " - From " + $('#ContentPlaceHolder1_hdnFromDate').val() + " - " + $('#ContentPlaceHolder1_hdnToDate').val();
            }
            $('#ContentPlaceHolder1_lblDesc').html(TotalCount);

        }
        function Navigate(Id) {
            window.open("../../frmDLOApplicationDetailsNew.aspx?Id=" + Id + "&Sts=11");
        }

    </script>

    <%--<script src="<%= Page.ResolveUrl("~/Js/jquery.floatThead.js")%>"></script>--%>

    <%-- <script type="text/javascript">
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
    </script>--%>
</asp:Content>
