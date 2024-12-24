<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmPartialReleasesList.aspx.cs" Inherits="TTAP.UI.Pages.Releases.frmPartialReleasesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../Js/validations.js"></script>

    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .fa.fa-hand-o-right {
            margin-right: 12px;
        }

        .head2 {
            font-weight: bold;
            color: tomato;
            font-size: 16px;
        }
    </style>


    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDLCProceedings" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Incentive Types</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Partial Released Incentives</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="row">
                        <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold">List of Cases Partial Released Incentives</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label3" runat="server">Incentive</label>
                                            <label class="form-control" id="lblIncentives" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2" runat="server">Type of Application</label>
                                            <label class="form-control" id="lblTypeofApplication" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label1" runat="server">Category</label>
                                            <label class="form-control" id="lblIncCategory" runat="server"></label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CssClass="table table-bordered mb-0 alternet-table w-100 NewEnterprise"
                                                PageSize="20" GridLines="Both">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Header" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkRow" Enabled="false" runat="server" Checked="true" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApplicationNumber" ItemStyle-HorizontalAlign="Center" HeaderText="Application Number">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="UnitName" HeaderText="Name of Unit">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Address" HeaderText="Address">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FinalSanctionedAmount" HeaderText="Sanctioned Amount">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Sanctioned_Date" Visible="false" HeaderText="Sanctioned Date">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RELEASEDAMOUNT" HeaderText="Previous Released Amount">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PreviousReleaseDt" HeaderText="Previous Released Date">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="AllotedAmount" HeaderText="Balance Release Amount">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Amount Released">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtreleaseamount" runat="server" AutoPostBack="true" OnTextChanged="txtreleaseamount_TextChanged" Text='<%# Eval("AllotedAmount") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Balance Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnextbalance" Text='<%# Eval("AllotedAmount") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Release Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblReleaseType" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SLCDLCNumer" HeaderText="SLC Or DLC Numer">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Ids" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblAllotedAmount" Text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                            <asp:Label ID="lblBalanceAmount" Text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                            <asp:Label ID="lblNextBalAmount" Text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                            <asp:Label ID="lblSanctionedAmount" Text='<%#Eval("FinalSanctionedAmount") %>' runat="server" />
                                                            <asp:Label ID="lblReleaseFlag" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row pt-4" id="trbalance" runat="server">

                                        <div class="col-sm-6 form-group">
                                            <label class="control-label font-bold" id="Label6" runat="server">GO Number</label>
                                            <asp:DropDownList ID="ddlgos" runat="server" RepeatDirection="Horizontal" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlgos_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                         <div class="col-sm-6 form-group">
                                            <label class="control-label font-bold text-success" id="Label8" runat="server">Total Amount(In Rs.)</label>
                                            <label class="form-control font-bold  text-success" id="lblTotalGOamount" runat="server"></label>
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label font-bold text-success" id="Label4" runat="server">Balance Amount(In Rs.)</label>
                                            <label class="form-control font-bold  text-success" id="lblbalanceGOamount" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row" id="trProcedinginfo" runat="server">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label font-bold" id="Label5" runat="server">Release Proceding No</label>
                                            <asp:TextBox ID="txtReleaseProcedingNo" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label font-bold" id="Label7" runat="server">Release Proceding Date</label>
                                            <asp:TextBox ID="txtReleaseProcedingDate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="trProcedingdoc" runat="server">
                                        <div class="col-sm-12 text-blue font-SemiBold mb-1">Release Proceedings to be uploaded</div>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                <tr align="center">
                                                    <th>Sl.No </th>
                                                    <th>Document Name </th>
                                                    <th>Upload Document </th>
                                                    <th>File Name </th>
                                                </tr>
                                                <tr class="GridviewScrollC1Item" id="trDocrent" runat="server">
                                                    <td align="center" style="width: 5%" id="trslno1" runat="server">1</td>
                                                    <td align="left" style="width: 50%">Release Proceedings Copy</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuDLCProceedings" runat="server" TabIndex="64" />
                                                        <asp:Button ID="btnDLCProceedings" TabIndex="65" CssClass="btn btn-info btn-sm mx-2" runat="server" Text="Upload" OnClick="btnDLCProceedings_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="lblDLCProceedings" runat="server" Target="_blank"></asp:HyperLink>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lbtnDLCProceedingsDelete" Text="Delete" runat="server" Visible="false" OnClick="lbtnDLCProceedingsDelete_Click"
                                                                    OnClientClick="if (!confirm('Are you sure you want delete?')) return false;"></asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="col-sm-12 form-group">
                                            <span style="color: red">Note : </span>
                                            <br />
                                            Upload “PDF” files only <%--Max size of each file 2 MB--%>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12 text-center">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-blue" OnClientClick="ClientSideClick(this)"
                                                TabIndex="10" Text="SUBMIT" OnClick="btnSubmit_Click" ValidationGroup="group" />
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnActualBalance" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <link href="../../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        function ClientSideClick(myButton) {
            // Client side validation
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false) { return false; }
            }

            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // diable the button
                myButton.disabled = true;
                myButton.className = "btn-inactive";
                myButton.value = "Processing...";
            }
            return true;
        }

        $("input[id$='ContentPlaceHolder1_txtReleaseProcedingDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtReleaseProcedingDate']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtReleaseProcedingDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });

    </script>

    <style type="text/css">
        font- 8pt; i o; d n 0 2 em x e8 {
            x;
        }

        11 {
            ;
            6;
        }

        .auto- e12 {
            height:;
        }

        {
            width: 175p .auo-stye1 wid h: 250;
        }
    </style>
    <style type="text/css">
        .ui-da font-size: 8pt !important; padding: 0.2em 0.2em 0; width: 250px; color: Black;
        }

        select {
            color: Black !important;
        }

        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
