<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmResptoIncQry.aspx.cs" Inherits="TTAP.UI.Pages.frmResptoIncQry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>
    <%-- <link href="../../Models/bootstrap.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function ValidateRemove(x) {
            var result = confirm('Are you sure want to delete Record?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
    <style>
        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        .radio, .checkbox {
            display: block;
            min-height: 20px;
            padding-left: 20px;
            margin-top: 10px;
            margin-bottom: 10px;
        }

            .radio input[type="radio"], .radio-inline input[type="radio"], .checkbox input[type="checkbox"], .checkbox-inline input[type="checkbox"] {
                float: left;
                margin-left: 20px;
            }

        input[type="radio"], input[type="checkbox"] {
            margin: 4px 0 0;
            line-height: normal;
        }

        input[type="checkbox"], input[type="radio"] {
            box-sizing: border-box;
            padding: 0;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload1" />

        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Stamp Duty Reimbursement</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold">Response to the Query</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label1" runat="server">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2" runat="server">Common Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <label class="control-label label-required" id="Label3" runat="server">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label7" runat="server">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label4" runat="server">Category of Unit as per T-TAP Policy</label>
                                            <label class="form-control" id="lblCategoryofUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label5" runat="server">Activity of the Unit</label>
                                            <label class="form-control" id="lblActivityoftheUnit" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row" id="DivQueryDetails" runat="server">
                                        <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details</div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="grdQueries" runat="server" AutoGenerateColumns="False"
                                                CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                Width="100%" Font-Names="Verdana" Font-Size="12px">
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
                                                        <ItemStyle Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                    <asp:BoundField DataField="Query" HeaderText="Query" />
                                                    <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                    <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Query Letter">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hyQueryLetter" Text="View" NavigateUrl='<%#Eval("QueryLetterPath")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label label-required">Query Response</label>
                                            <asp:TextBox ID="txtdiscription" runat="server" CssClass="form-control"
                                                TabIndex="1" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 form-group" id="DivIncentiveList" runat="server" visible="false">
                                            <label class="control-label label-required">Incentive</label>
                                            <asp:DropDownList ID="ddlAppliedIncenties" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">File Name/Description</label>
                                            <asp:TextBox ID="txtfileDescription" runat="server" CssClass="form-control"
                                                MaxLength="40" TabIndex="1"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Upload Attachment</label>
                                            <asp:FileUpload ID="fuDocuments1" runat="server" CssClass="form-control" />
                                        </div>
                                        <div class="col-sm-2 form-group text-left">
                                            <asp:Button ID="btnUpload1" runat="server" CssClass="btn btn-blue py-2 title7 mt-4" OnClick="btnUpload1_Click" Text="Upload" />
                                        </div>
                                    </div>
                                    <div class="row" id="DivAttachments" runat="server" visible="false">
                                        <div class="col-sm-12 text-black font-SemiBold mb-1">Uploaded Attachments</div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowCommand="gvSubsidy_RowCommand">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-Width="50%" HeaderText="Incentive">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" runat="server" Text='<%# Eval("IncentiveName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" ItemStyle-Width="50%" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlSaleDelete" OnClientClick="if (!confirm('Are You Sure Want to Delete Record?')) return false;" CommandName="RowDdelete" CssClass=" btn btn-danger mx-2 px-4 py-1 title5" runat="server" Text="Delete" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="150px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="ids" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAttachmentId" Text='<%#Eval("AttachmentId")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId")%>' runat="server"></asp:Label>
                                                            <asp:Label ID="lblUploadedID" Text='<%#Eval("UploadedID")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 text-center mt-3">
                                            <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success m-2" Enabled="true" Text="Submit" OnClick="BtnSave_Click" />
                                            <%-- &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Enabled="false" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />--%>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong></strong>
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
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtDateofRegistration']").keydown(function () {
            return false;
        });


        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');

            $("input[id$='ContentPlaceHolder1_txtDateofRegistration']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtDateofRegistration']").datepicker(
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
