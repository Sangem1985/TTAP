<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="InspectionsDetailedReport.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.InspectionsDetailedReport" %>

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
                            <li class="breadcrumb-item">R14.Pending with DLO Incentive Applications Report</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <table runat="server" id="tblHead">
                            <tr>
                                <td>
                                    <h5 class="text-blue mt-1 mb-3 font-SemiBold">R14. Pending with DLO Incentive Applications Report</h5>
                                </td>
                                <td runat="server" visible="false">
                                    <asp:Label ID="Label1" Style="margin: 0px 0px 0px 30px;"
                                        runat="server">District : </asp:Label>
                                </td>
                                <td runat="server" visible="false">
                                    <asp:DropDownList ID="ddlDistrict" class="form-control" Style="display: none;" runat="server"></asp:DropDownList>
                                </td>
                                 <td runat="server" visible="false">
                                    <asp:DropDownList ID="ddlIncentives" class="form-control" Style="display: none;" runat="server"></asp:DropDownList>
                                </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                <td runat="server" visible="true" id="trExcel"></td>
                            </tr>
                        </table>

                        <div class="widget-content nopadding">
                            <div class="row">
                               <%-- <div class="col-sm-12 text-right pr-5">
                                    
                                </div>--%>
                                <div id="TotalGrid" runat="server" class="col-sm-12 mb-4 table-flex">
                                    <div class="row">
                                        <div class="tableFixHead" style="overflow: auto">
                                            <div style="text-align-last: center; font-size: large; font-weight: 900; color: orangered;" runat="server" id="divGridHead">
                                                <tr>
                                                    <td>
                                                        <label runat="server" id="lblDesc"></label>
                                                        <a id="A2" href="#" runat="server" onserverclick="BtnExportExcel_Click">
                                                            <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                                                alt="Excel" title="Export to Excel" /></a>
                                                         <a id="A1" href="~/UI/Pages/MISReports/InspectionsReportAbstract.aspx" runat="server" style="float:right;margin-right:15px;">
                                                            <img src="../../../images/BackArrow1.png" width="50px" height="20px"
                                                                alt="Excel" title="Go to Previous Page" /></a>
                                                        <%--<asp:LinkButton ID="lbtnback"  CssClass="text-right" style="float:right;margin-right:15px;"  runat="server" >Back</asp:LinkButton>--%>
                                                    </td>
                                                </tr>
                                                <br />
                                                <tr>
                                                    <td>
                                                        <label runat="server" id="lblIncName"></label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div id="DivGridView" class="col-sm-12 table-responsive" runat="server" style="width: 98%;">
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
                                                        <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TypeofTexttileText" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Textile">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Application Number" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <a href="#/" onclick="javascript:Navigate(<%# Eval("IncentiveId") %>);"><%# Eval("ApplicationNumber") %></a>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="FinancialYear" ItemStyle-HorizontalAlign="Center" HeaderText="Financial Year">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="TypeOfFinancialYear" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Financial Year">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                          <asp:BoundField DataField="ClaimAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Claim Amount">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SubmissionDate" ItemStyle-HorizontalAlign="Center" HeaderText="Submitted Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Payment Verified Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ScrutinyCompletedDate" ItemStyle-HorizontalAlign="Center" HeaderText="DLO Received Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InspectionCreatedDt" ItemStyle-HorizontalAlign="Center" HeaderText="Inspection Created Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InspectionScheduedDt" ItemStyle-HorizontalAlign="Center" HeaderText="Inspection Scheduled Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="InspectionCompletedDt" ItemStyle-HorizontalAlign="Center" HeaderText="Inspection Completed Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RevisedInspectionScheduedDt" ItemStyle-HorizontalAlign="Center" HeaderText="Revised Inspection Scheduled Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RevisedInspectionCompletedDt" ItemStyle-HorizontalAlign="Center" HeaderText="Revised Inspection Completed Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RecommendedtoHODt" ItemStyle-HorizontalAlign="Center" HeaderText="Recommended to DLC/Head Office Date">
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="STATUS" ItemStyle-HorizontalAlign="Center" HeaderText="Current Status">
                                                            <ItemStyle HorizontalAlign="Center" />
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
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnDistName" runat="server" />
            <asp:HiddenField ID="hdnDistId" runat="server" />
            <asp:HiddenField ID="hdnSubIncentiveId" runat="server" />
            <asp:HiddenField ID="hdnFlag" runat="server" />
            <asp:HiddenField ID="hdnFlagDesc" runat="server" />
            <asp:HiddenField ID="hdnHeader" runat="server" />
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

            /*var Count1 = $('#ContentPlaceHolder1_TotalGrid').find('.GridviewScrollC1Item').length;
            var Count2 = $('#ContentPlaceHolder1_TotalGrid').find('.GridviewScrollC1Item2').length;
            // var Count=
            var TotalCount = "Total Incentives - " + (parseInt(Count1) + parseInt(Count2));
            if ($('#ContentPlaceHolder1_hdnDateFlag').val() == "D") {
                TotalCount = "Total Incentives - " + (parseInt(Count1) + parseInt(Count2)) + " - From " + $('#ContentPlaceHolder1_hdnFromDate').val() + " - " + $('#ContentPlaceHolder1_hdnToDate').val();
            }
            $('#ContentPlaceHolder1_lblDesc').html(TotalCount);*/

        }
        function Navigate(Id) {
            window.open("../../frmDLOApplicationDetailsNew.aspx?Id=" + Id + "&Sts=11");
        }

    </script>
</asp:Content>
