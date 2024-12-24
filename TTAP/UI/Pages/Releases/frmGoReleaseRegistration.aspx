<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmGoReleaseRegistration.aspx.cs" Inherits="TTAP.UI.Pages.Releases.frmGoReleaseRegistration" %>

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
            background-image: url("../../Images/ajax-loaderblack.gif");
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
            <asp:PostBackTrigger ControlID="btnPaymentProof" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">G.O Registration</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">G.O Registration</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="row">
                        <%-- <div class="col-sm-12 offset-md-1 col-md-10 col-lg-8 offset-lg-2 frm-form box-content py-3 font-medium title5">--%>
                        <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold">G.O - Fund Release Registration</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row" id="divrtgsPaymentDtls" runat="server">
                                      <%--  <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">G.O Registration Details</h6>--%>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label2" runat="server">G.O No</label>
                                            <asp:TextBox ID="txtGONo" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">G.O Date</label>
                                            <asp:TextBox ID="txtGODate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">LOC No</label>
                                            <asp:TextBox ID="txtLOCNo" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label3" runat="server">LOC Date</label>
                                            <asp:TextBox ID="txtLOCDate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Amount</label>
                                            <asp:TextBox ID="txtGOAmountReleased" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                         <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">Remarks</label>
                                            <asp:TextBox ID="txtRemarks" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                <tr align="center">
                                                    <th>Sl.No </th>
                                                    <th>Document Name </th>
                                                    <th>Upload Document </th>
                                                    <th>File</th>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 30%">G.O</td>
                                                    <td align="left" style="width: 30%">
                                                        <asp:FileUpload ID="fuPaymentProof" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                         <asp:Button ID="btnPaymentProof" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnPaymentProof_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyPaymentProof" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 text-center mt-3" runat="server" id="divbuttons">
                                        <asp:Button ID="BtnClear" runat="server" CssClass="btn btn-warning m-2" TabIndex="10" Text="Clear" OnClick="BtnClear_Click" />
                                        <asp:Button ID="BtnSubmit" runat="server" CssClass="btn btn-success m-2" TabIndex="10" Text="Submit" OnClick="BtnSubmit_Click" />
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                        <asp:GridView ID="gvDetails" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                            AutoGenerateColumns="false" OnRowCommand="gvDetails_RowCommand">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="G.O No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGONo" runat="server" Text='<%#Eval("GONo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="G.O Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGODate" runat="server" Text='<%#Eval("GODate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LOC No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLOCNo" runat="server" Text='<%#Eval("LOCNo") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="LOC Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLOCDate" runat="server" Text='<%#Eval("LOCDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Amount Released (In Rs)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTotalSaleValue" runat="server" Text='<%#Eval("AmountReleased") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="GO">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="hyQueryLetter" Text="View" NavigateUrl='<%#Eval("GOLetterPath")%>' Target="_blank" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnlSaleEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnlSaleDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblGOID" runat="server" Text='<%# Bind("GOID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
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
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <link href="../../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtGODate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtLOCDate']").keydown(function () {
            return false;
        });
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtGODate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtLOCDate']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtGODate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtLOCDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });

    </script>

   
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
