<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="ApplicantIncentivesHistory.aspx.cs" Inherits="TTAP.UI.Pages.ApplicantIncentivesHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
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
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <%--<script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Dashboard</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Dashboard</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Applicant Incentive Dashboard</h5>
                        <div class="widget-content nopadding">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr id="trhd1" runat="server">
                                            <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                align="center">&nbsp;
                                            </td>
                                        </tr>

                                        <tr id="trhd2" runat="server">
                                            <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                valign="top">&nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trhd3" runat="server">
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Height="62px" OnRowDataBound="grdDetails_RowDataBound" Width="100%" Font-Names="Verdana"
                                                    Font-Size="12px">
                                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Application No">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagApplicationNo" runat="server" Text='<%#Eval("ApplicationNo") %>' Font-Bold="true" ForeColor="Green"  />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <%-- <asp:BoundField DataField="ApplicationNo" ItemStyle-HorizontalAlign="Left" HeaderText="Application No" />--%>
                                                        <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Left"
                                                            HeaderText="Applied Date" />
                                                        <asp:TemplateField HeaderText="ApplicationNo" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApplicationNo" Text='<%#Eval("ApplicationNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ApplicationNo" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApplicationFiledDate" Text='<%#Eval("ApplicationFiledDate") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View Application">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglink" runat="server" Text="View" Font-Bold="true" ForeColor="Green"
                                                                    Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View Acknowledgement">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkAcknowledgement" runat="server" Text="Acknowledgement"
                                                                    Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:BoundField DataField="PendingQueries" ItemStyle-HorizontalAlign="Center" HeaderText="Pending Queries" />--%>
                                                        <asp:TemplateField HeaderText="Pending Queries">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPendingQueries" Text='<%#Eval("PendingQueries") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkPendingQueriesAtLevel" runat="server" Text='<%#Eval("QueryAt") %>'
                                                                    Width="150px" Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Respond to query" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkPendingQueries" runat="server" Text="Respond to query"
                                                                    Width="150px" Font-Bold="true" ForeColor="Green" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Payment Details">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagpaymentDetails" runat="server" Text="View" Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkStatus" runat="server" Text="Track" Font-Bold="true"
                                                                    ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No Incentives Applied">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkIncentives" runat="server" Text='<%#Eval("NoOfIncentives") %>' Font-Bold="true"
                                                                    ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="No of Reminders Received">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkReminder" runat="server" Text='<%#Eval("ReminderQueries") %>' Font-Bold="true"
                                                                    ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Working Status Query">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkWorkingStatus" runat="server" Text='<%#Eval("WorkingStatus") %>' Font-Bold="true"
                                                                    ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="Reminder Queries" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblReminderQueries" Text='<%#Eval("ReminderQueries") %>' runat="server" />
                                                                <asp:Label ID="lblWorkingStatus" Text='<%#Eval("WorkingStatus") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr id="trhd4" runat="server">
                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                            </td>
                                        </tr>
                                        <tr id="trApplyAgainNote" runat="server" visible="false">
                                            <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;<b>Note:</b> To Apply Again for another claim application, Please Click on
                                                    &#39;Apply Again&#39; and click on Next, Next..&nbsp;&nbsp; no need to fill common
                                                    form again. And in the incentives list shown page, please click on &#39;Apply Again&#39;
                                                    check box and continue as a fresh application in the final page you will get new application
                                                    number and new acknowledgement.
                                            </td>
                                        </tr>
                                        <tr align="center" id="trApplyAgainbtn" runat="server" visible="false">
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: left;" valign="middle">&nbsp;
                                                    <asp:Button ID="btnApplyAgain" runat="server" CssClass="btn btn-primary" Height="32px"
                                                        TabIndex="10" Text="Apply Again" Width="150px" OnClick="btnApplyAgain_Click" />
                                            </td>
                                        </tr>
                                        <tr id="trprintack" runat="server" visible="false">
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">&nbsp;
                                            </td>
                                        </tr>
                                        <tr id="tradminqueris" runat="server" visible="false">
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                <asp:GridView ID="gvcommqueries" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    Height="62px" OnRowDataBound="gvcommqueries_RowDataBound" Width="100%" Font-Names="Verdana"
                                                    Font-Size="12px">
                                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                                <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Application No">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagApplicationNo" runat="server" Text='<%#Eval("ApplicationNo") %>' Font-Bold="true" ForeColor="Green"  />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                      <%--  <asp:BoundField DataField="ApplicationNo" ItemStyle-HorizontalAlign="Left" HeaderText="Application No" />--%>

                                                        <asp:TemplateField HeaderText="ApplicationNo" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApplicationNo" Text='<%#Eval("ApplicationNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ApplicationNo" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblApplicationFiledDate" Text='<%#Eval("ApplicationFiledDate") %>'
                                                                    runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <%--<asp:BoundField DataField="PendingQueries" ItemStyle-HorizontalAlign="Center" HeaderText="Pending Queries" />--%>
                                                        <asp:TemplateField HeaderText="Pending Queries">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPendingQueries" Text='<%#Eval("PendingQueries") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="" Visible="false">
                                                            <ItemTemplate>
                                                                 <asp:Label ID="lblQueryAtPendingQueries" Text='<%#Eval("QueryAt") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Respond to query" Visible="true">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkPendingQueries" runat="server" Text="Respond to query"
                                                                    Width="150px" Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="No Incentives Submitted">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkSubmittedIncentives" runat="server" Text='<%#Eval("NoOfIncentives") %>' Font-Bold="true"
                                                                    ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Payment Details">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagpaymentDetails" runat="server" Text="View" Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr id="tr1" runat="server" visible="false">
                                            <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">&nbsp;<b> There are no incentives applied by you</b>
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
