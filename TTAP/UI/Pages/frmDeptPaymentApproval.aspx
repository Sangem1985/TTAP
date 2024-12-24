<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmDeptPaymentApproval.aspx.cs" Inherits="TTAP.UI.Pages.frmDeptPaymentApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>


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
    </style>


    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
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
                            <li class="breadcrumb-item">Incentive Types</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Payment Details</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="col-sm-12 text-right pr-5">
                                        <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="60%"
                                                PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 alternet-table NewEnterprise" CellSpacing="4">
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
                                                        <ItemStyle Width="70px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="cbIncentive" runat="server" Text='<%#Eval("IncentiveName")%>' />
                                                            <asp:Label ID="lblIncentiveId" runat="server" Text='<%#Eval("IncentiveID") %>' Visible="false" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Application Fee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblApplicationFee" runat="server" Text='<%#Eval("TotalAmount")%>' />
                                                            <asp:Label ID="lblApplicationFeehide" runat="server" Text='<%#Eval("TotalAmount") %>' Visible="false" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="col-sm-12 form-group">
                                            <div class="row py-4">
                                                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="control-label" id="Label10" runat="server">Total Amount</label>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="form-control" id="lblTotalAmount" runat="server"></label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="divrtgspayment">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">NEFT/RTGS Payment Details</h6>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvPaymentDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="80%"
                                                PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 alternet-table NewEnterprise" CellSpacing="4">
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
                                                        <ItemStyle Width="70px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="PaymentMode" HeaderText="Payment Mode" />
                                                    <asp:BoundField DataField="UTRNo" HeaderText="UTR No" />
                                                    <asp:BoundField DataField="DateofRemittance" HeaderText="Date of Remittance" />
                                                    <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                                    <asp:BoundField DataField="NameoftheBank" HeaderText="NameoftheBank" />
                                                    <asp:BoundField DataField="Verified_date" HeaderText="Date Of Verification" />
                                                    <asp:BoundField DataField="VerifiedFlag" HeaderText="Status" />
                                                    <asp:BoundField DataField="VerifiedRemarks" HeaderText="Remarks" />
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("PaymentproofPath")%>' Target="_blank" runat="server" />
                                                            <asp:Label ID="lblOnlineBillerID" runat="server" Visible="false" Text='<%#Eval("OnlineBillerID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="PaymentSelection">
                                        <div class="col-sm-12 form-group">
                                            <div class="row py-4">
                                                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="control-label" id="Label1" runat="server">Payment Status</label>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control"
                                                        Font-Names="Verdana" RepeatDirection="Horizontal" Width="350px">
                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                        <asp:ListItem Value="A">Amount Received</asp:ListItem>
                                                        <asp:ListItem Value="R">Amount Not Received</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="row py-4" runat="server" id="Div1">
                                                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="control-label" id="Label3" runat="server">Remarks</label>
                                                </div>
                                                <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:TextBox ID="txtRemarks" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 text-center mt-3" runat="server" id="divbuttons">
                                        <asp:Button ID="BtnClear" runat="server" CssClass="btn btn-warning m-2" TabIndex="10" Text="Clear" />
                                        <asp:Button ID="BtnSubmit" runat="server" CssClass="btn btn-success m-2" TabIndex="10" Text="Submit" OnClick="BtnSubmit_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        function pageLoad() {
            $("input[type=text]").attr('autocomplete', 'off');
        }
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
</asp:Content>
