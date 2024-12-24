<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="SLVUploadsEntry.aspx.cs" Inherits="TTAP.UI.Pages.SLVUploadsEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="btnSVSLCAgendaUploads" />
            <asp:PostBackTrigger ControlID="btnSVSLCMinsUpload" />
            <asp:PostBackTrigger ControlID="btnSLCAgendaUpload" />
            <asp:PostBackTrigger ControlID="btnSLCMinsUpload" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">SLC Entry</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">SLC Entry</li>
                        </ul>
                    </div>

                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">

                        <div class="widget-content nopadding">
                            <div>

                                <div class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                            <td>SLC No </td>
                                            <td>
                                                <asp:TextBox ID="txtSlcNo" runat="server"></asp:TextBox></td>
                                            <td>SLC Date</td>
                                            <td>
                                                <asp:TextBox Enabled="false" ID="txtSlcDate" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <div id="divDtls" runat="server">
                                            <tr runat="server" id="trUnitName">
                                                <td>Unit Name </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlUnits" runat="server">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <br />
                                            <tr runat="server" id="trIncentive">
                                                <td>Incentive</td>
                                                <td>
                                                    <asp:DropDownList ID="ddlIncentive" runat="server">
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr runat="server" id="trYear">
                                                <td>Period From</td>
                                                <td>
                                                    <asp:TextBox placeholder="Click Here" ID="txtFromDate" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Period To</td>
                                                <td>
                                                    <asp:TextBox placeholder="Click Here" ID="txtToDate" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Description</td>
                                                <td>
                                                    <asp:TextBox ID="txtHalf" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>DLO Recommended Amount
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtDloAmount" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>Textile Dept Recommended Amount
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTextileAmount" onkeypress="return inputOnlyNumbers(event)" AutoPostBack="true" OnTextChanged="txtTextileAmount_TextChanged" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>Industries Recommended Amount
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtIndustriesAmount" onkeypress="return inputOnlyNumbers(event)" AutoPostBack="true" OnTextChanged="txtTextileAmount_TextChanged" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>SLC Approved Amount
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSLCAmopunt" ReadOnly="true" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                              <tr>
                                                <td>Sancationed Date
                                                </td>
                                                <td>
                                                    <asp:TextBox placeholder="Click Here" ID="txtSanctionedDate" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>Released Amount
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtReleasedAmount" onkeypress="return inputOnlyNumbers(event)"  runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>Released Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtReleasedDt"  runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td>Letter No. & Date
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtLetterNo" TextMode="MultiLine" runat="server"></asp:TextBox>
                                                </td>
                                                  <td>
                                                    <asp:Button Text="Add" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnAdd" OnClick="btnAdd_Click" runat="server" />
                                                </td>
                                            </tr>
                                          
                                        </div>
                                    </table>
                                </div>
                                <div>
                                    <asp:GridView ID="gvGridSlc" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="gvGridSlc_RowCommand">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Footer" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnitName" runat="server" Text='<%# Bind("UnitName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Incentive">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentive" runat="server" Text='<%# Bind("IncentiveName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Textile Dept Recommended Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTextileDeptAmount" runat="server" Text='<%# Bind("TextileDeptAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Industries Dept Recommended Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIndustriesDeptAmount" runat="server" Text='<%# Bind("IndustriesDeptAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Slc Approved Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSlcApprovedAmount" runat="server" Text='<%# Bind("Slc_Approved_Amount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false" HeaderText="Sanctioned Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSanctionedDate" runat="server" Text='<%# Bind("SanctionedDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Period From Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPeriodFromDate" runat="server" Text='<%# Bind("PeriodFromDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Period To Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPeriodToDate" runat="server" Text='<%# Bind("PeriodToDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Released Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReleasedAmount" runat="server" Text='<%# Bind("ReleasedAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Released Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReleasedDate" runat="server" Text='<%# Bind("ReleasedDate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Letter No & Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLetterNo" runat="server" Text='<%# Bind("LetterNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning" OnClick="btnEdit_Click"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" CommandName="RowDelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SlcId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSlcId" runat="server" Text='<%# Bind("SlcId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SlcSubId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSlcSubId" runat="server" Text='<%# Bind("SlcSubId") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div id="divData" visible="false" style="margin: 0px 0px 0px 570px; font-size: large; color: red; font-family: revert;"
                                    runat="server">
                                    No Data Found
                                </div>
                                <div class="row" id="card">
                                    <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Agenda/Minutes Uploads</h5>
                                    <div class="row w-100 m-0" id="Div2" runat="server">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">SVSLC Agenda (Pdf Only)</label>
                                            <asp:FileUpload ID="fuSVSLCAgenda" runat="server" CssClass="file-browse" />
                                        </div>
                                        <div class="col-sm-3 form-group  text-left">
                                            <br />
                                            <asp:Button ID="btnSVSLCAgendaUploads" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnSVSLCAgendaUploads_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hySVSLCAgendaUpload" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                        </div>

                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">SVSLC Minutes (Pdf Only)</label>
                                            <asp:FileUpload ID="fuSVSLCMins" runat="server" CssClass="file-browse" />
                                        </div>
                                        <div class="col-sm-3 form-group  text-left">
                                            <br />
                                            <asp:Button ID="btnSVSLCMinsUpload" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnSVSLCMinsUpload_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hySVSLCMinsUpload" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                        </div>

                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">SLC Agenda (Pdf Only)</label>
                                            <asp:FileUpload ID="fuSLCAgenda" runat="server" CssClass="file-browse" />
                                        </div>
                                        <div class="col-sm-3 form-group  text-left">
                                            <br />
                                            <asp:Button ID="btnSLCAgendaUpload" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnSLCAgendaUpload_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hySLCAgendaUpload" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                        </div>

                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">SLC Minutes (Pdf Only)</label>
                                            <asp:FileUpload ID="fuSLCMins" runat="server" CssClass="file-browse" />
                                        </div>
                                        <div class="col-sm-3 form-group  text-left">
                                            <br />
                                            <asp:Button ID="btnSLCMinsUpload" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnSLCMinsUpload_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hySLCMinsUpload" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                        </div>

                                        <div class="col-sm-12 mt-sm-3 text-left">
                                            <p><strong>Note : </strong>File Size should be 1MB only.</p>
                                        </div>
                                    </div>
                                </div>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <h1 class="page-subhead-line">
                                                    <asp:HiddenField ID="hdnfldtsiic" runat="server" />
                                                </h1>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="hdfID" runat="server" />
                                            <asp:HiddenField ID="hdnTotalAmount" Value="0" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" />
                                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="child" />
                                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="group1" />
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hdnSubSlcId" Value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
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
        $("input[id$='ContentPlaceHolder1_txtReleasedDt']").keydown(function () {
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
            $("input[id$='ContentPlaceHolder1_txtReleasedDt']").datepicker(
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
            $("input[id$='ContentPlaceHolder1_txtReleasedDt']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });

        function Calculate() {
            var TextileAmount = 0, IndustriesAmount = 0;
            if ($('#ContentPlaceHolder1_txtTextileAmount').val() != "") {
                TextileAmount = parseFloat($('#ContentPlaceHolder1_txtTextileAmount').val());
            }
            if ($('#ContentPlaceHolder1_txtIndustriesAmount').val() != "") {
                IndustriesAmount = parseFloat($('#ContentPlaceHolder1_txtIndustriesAmount').val());
            }
            $('#ContentPlaceHolder1_txtSLCAmopunt').val(TextileAmount + IndustriesAmount);
            $('#ContentPlaceHolder1_hdnTotalAmount').val(TextileAmount + IndustriesAmount);
        }

    </script>

</asp:Content>
