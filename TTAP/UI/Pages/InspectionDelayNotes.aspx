<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="InspectionDelayNotes.aspx.cs" Inherits="TTAP.UI.Pages.InspectionDelayNotes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>
    <style type="text/css">
        .blink {
            animation: blinker 1.2s linear infinite;
            color: #ee0f0f;
            /*font-size: 30px;
        font-family: sans-serif;*/
            font-weight: bold;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />

        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Inspection Delay Notes</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Inspection Delay Notes</li>
                        </ul>
                    </div>

                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">

                        <div class="widget-content nopadding">
                            <div>

                                <div class="col-sm-4 form-group">
                                    <table>
                                        <div id="divDtls" runat="server">
                                            <tr runat="server" id="trUnitName">
                                                <td>
                                                    <asp:Label runat="server">Unit Name</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtUnitName" Width="200%" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="trIncentive">
                                                <td>
                                                    <asp:Label runat="server">Incentive Name</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIncentiveName" class="form-control" Width="200%" ReadOnly="true" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Application Numer</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtApplicationNo" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>
                                                    <asp:Label runat="server">Query Raised Date</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtQueryDate" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>

                                        </div>
                                    </table>
                                </div>

                                <div class="col-sm-8 form-group">
                                    <table>
                                        <div id="divSave" runat="server">
                                            <tr runat="server" id="tr1">
                                                <td>
                                                    <asp:Label runat="server">Reminder Description/Remarks</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDesc" class="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button Text="Send Reminder" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnAdd"  runat="server" />
                                                </td>

                                            </tr>
                                            <tr runat="server" id="tr2">
                                            </tr>
                                        </div>

                                    </table>
                                </div>
                                <div id="divReject" runat="server" visible="false">
                                    <div class="col-sm-10 form-group">
                                        <tr runat="server" id="tr4">
                                            <td>
                                                <asp:Label CssClass="blink" ID="lblInfo" runat="server">You can Reject the Incentive Application when Unit holder not responding to Query even after two Reminders</asp:Label>
                                            </td>
                                        </tr>
                                    </div>
                                    <div id="div1" runat="server" class="col-sm-6 form-group">
                                        <table>

                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Rejection Remarks</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRejectRemarks" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Button Text="Reject" Style="background: red;"
                                                        CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnReject"  runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <div id="divGridInsNotes" runat="server" visible="false">
                                    <div class="col-sm-12 text-blue font-SemiBold mb-1">Inspection Delay Notes</div>
                                    <asp:GridView ID="gvGridInsDelayNotes" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" EmptyDataText="No Data Found">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="ReminderNo" HeaderText="Reminder No" />
                                            <asp:BoundField DataField="ReminderDesc" HeaderText="Reminder Description" />
                                            <asp:BoundField DataField="Created_dt" HeaderText="Reminder Sent on" />
                                            <asp:BoundField DataField="ReadStatus" HeaderText="Entrepreneur Read Status" />
                                            <asp:BoundField DataField="Modified_dt" HeaderText="Entrepreneur Last Read on" />--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnIncentiveId" runat="server" />
            <asp:HiddenField ID="hdnSubIncentiveId" runat="server" />
            <asp:HiddenField ID="hdnUserId" runat="server" />
            <asp:HiddenField ID="hdnUnitId" runat="server" />
            <asp:HiddenField ID="hdnRolecode" runat="server" />
            <asp:HiddenField ID="hdnInspectionId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <link href="../../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <style type="text/css">
        
    </style>
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtFromDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtToDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtSanctionedDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtToDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtSanctionedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtToDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtSanctionedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });

    </script>

</asp:Content>

