<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FormUnitWorkingStatusHO.aspx.cs" Inherits="TTAP.UI.Pages.Releases.FormUnitWorkingStatusHO" %>

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
        <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />

        </Triggers>--%>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Unit Working Status</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Unit Working Status</li>
                        </ul>
                    </div>

                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">

                        <div class="widget-content nopadding">
                            <div>
                                <div id="divDLO" runat="server" visible="false">
                                    <div class="col-sm-12 text-blue font-SemiBold mb-1">Unit Working Status Update</div>
                                    <asp:GridView ID="gvDLO" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                            <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                            <asp:BoundField DataField="ApplicationNumber" HeaderText="Application Number" />
                                            <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" />
                                            <asp:BoundField DataField="WorkingStatus" HeaderText="Working Status as per DLO" />
                                            <asp:BoundField DataField="WorkingStatusRemarks" HeaderText="Working Status Remarks" />
                                            <asp:BoundField DataField="WorkingStatusDate" HeaderText="Working Status Update Date" DataFormatString="{0:dd-MM-yyyy}" />
                                            <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                    <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div id="divUnit" runat="server" visible="false">
                                    <div class="col-sm-12 text-blue font-SemiBold mb-1">Update Bank Account Details</div>
                                    <asp:GridView ID="gvUnit" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowDataBound="gvBank_RowDataBound" EmptyDataText="No Data Found">
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
                                            <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                            <asp:BoundField DataField="ApplicationNumber" HeaderText="Application Number" />
                                            <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name" />
                                            <asp:BoundField DataField="WorkingStatus" HeaderText="Working Status as per DLO" />
                                            <asp:BoundField DataField="WorkingStatusRemarks" HeaderText="Working Status Remarks" />
                                            <asp:BoundField DataField="WorkingStatusDate" HeaderText="Working Status Update Date" DataFormatString="{0:dd-MM-yyyy}"/>
                                            <asp:BoundField DataField="UnitResponseOnWorkingStatus" HeaderText="Unit Response" />
                                            <asp:BoundField DataField="UnitResponseDate" HeaderText="Unit Response Date" DataFormatString="{0:dd-MM-yyyy}" />
                                            <asp:TemplateField HeaderText="Process Application" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnView" runat="server" Text="View" CssClass="btn btn-blue py-1 title7" Enabled='<%# Eval("EnableControl").ToString() == "Y" ? true : false %>' OnClick="btnUpdate_Click"></asp:Button>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                    <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                    <asp:Label ID="lblApplication" Text='<%#Eval("ApplicationNumber") %>' runat="server" />
                                                    <asp:Label ID="lblIncentive" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                    <asp:Label ID="lblBankDetailsUpdStatus" Text='<%#Eval("Bank_Details_Upd_Status") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div runat="server" id="divUpdate" visible="false">
                                    <div class="col-sm-12 text-blue font-SemiBold mb-1">Bank Account Details</div>
                                    <div id="divbank" runat="server">
                                        <div class="row">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label1" runat="server">Application No</label>
                                                <asp:TextBox ID="txtApplication" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label2" runat="server">Incentive</label>
                                                <asp:TextBox ID="txtIncentive" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label14" runat="server">Name of the Bank</label>
                                                <asp:DropDownList ID="ddlBank" runat="server" RepeatDirection="Horizontal" class="form-control" AutoPostBack="true">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label15" runat="server">Branch Name</label>
                                                <asp:TextBox ID="txtBranchName" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label19" runat="server">Account Number</label>
                                                <asp:TextBox ID="txtAccNumber" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label18" runat="server">Account Type</label>
                                                <asp:DropDownList ID="ddlAccountType" runat="server" RepeatDirection="Horizontal" class="form-control" AutoPostBack="true">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label20" runat="server">IFSC Code</label>
                                                <asp:TextBox ID="txtIfscCode" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label13" runat="server">Name of the authorized Person for operating the account </label>
                                                <asp:TextBox ID="txtaccountauthorizedPerson" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label21" runat="server">Designation</label>
                                                <asp:TextBox ID="txtaccountauthorizedPersonDesignation" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
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
            <asp:HiddenField ID="hdnApplication" runat="server" />
            <asp:HiddenField ID="hdnIncentive" runat="server" />
            <asp:HiddenField ID="HiddenField3" runat="server" />
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
        function ClosingCentreDetails() {
            $("#centreDetPopup").hide();
        }
        function OpenCentreDetails() {
            $("#ContentPlaceHolder1_centreDetPopup").show();
        }

    </script>

</asp:Content>
