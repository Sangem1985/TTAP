<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmPaymentPage.aspx.cs" Inherits="TTAP.UI.Pages.frmPaymentPage" %>

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
                                    <h5 class="text-blue mb-3 font-SemiBold">Incentive Details</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row" runat="server" id="divrtgspayment" visible="false">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">NEFT/RTGS Payment Verification Status</h6>
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
                                                    <asp:BoundField DataField="VerifiedFlag" HeaderText="Status" />
                                                    <asp:BoundField DataField="VerifiedRemarks" HeaderText="Remarks" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 table-responsive mt-2">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%"
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
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Application Fee" Visible="false">
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
                                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 table-responsive mt-2" style="border: 1px solid #000; margin: -10px; background: aliceblue; margin-bottom: 16px !important;"  runat="server" visible="false">
                                            <h6 style="font-size: 18px; font-weight: 900; color: blue; margin-top: 12px; padding-bottom: 10px; border-bottom: 1px solid #000;"><strong><span>Payment modes for making the payment</span></strong></h6>
                                            <div class="col-sm-12 form-group">
                                                <h6 style="margin: 5px 0px !important; text-decoration: underline; font-weight: 900; color: blueviolet;">Mode Of Payment: </h6>
                                                <p>
                                                    1) NEFT<br />
                                                    2) RTGS
                                                </p>
                                                <h6 style="margin: 5px 0px !important; text-decoration: underline; font-weight: 900; color: blueviolet;">Bank Details for NEFT & RTGS : </h6>
                                                <ul type="none" style="margin-left: -35px;">
                                                    <li><i class="fa fa-hand-o-right" aria-hidden="true"></i><span class="head1">Bank Name</span>: <span class="head2">Union Bank of India</span>.</li>
                                                    <li><i class="fa fa-hand-o-right" aria-hidden="true"></i><span class="head1">Branch Name</span>: <span class="head2">AP Secretariat Branch</span>.</li>
                                                    <li><i class="fa fa-hand-o-right" aria-hidden="true"></i><span class="head1">Account Name</span>: <span class="head2">Commissioner of Handlooms & Textiles</span>.</li>
                                                    <li><i class="fa fa-hand-o-right" aria-hidden="true"></i><span class="head1">Account Number</span>: <span class="head2">110310100044047</span>.</li>
                                                    <li><i class="fa fa-hand-o-right" aria-hidden="true"></i><span class="head1">IFSC Code</span>: <span class="head2">UBIN0811033</span>.</li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" visible="false">
                                        <div class="col-sm-12 form-group">
                                            <div class="row py-4">
                                                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="control-label" id="Label10" runat="server">Total Amount</label>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="form-control" id="lblTotalAmount" runat="server"></label>
                                                </div>
                                            </div>
                                            <div class="row py-4" runat="server" id="PaymentSelection" visible="false">
                                                <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="control-label" id="Label1" runat="server">Select Payment Mode</label>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12" runat="server" >
                                                    <asp:RadioButtonList ID="rblPaymentMode" runat="server" AutoPostBack="True" Font-Bold="True"
                                                        Font-Names="Verdana" RepeatDirection="Horizontal" Width="350px" OnSelectedIndexChanged="rblPaymentMode_SelectedIndexChanged">
                                                        <asp:ListItem Value="NEFT">NEFT</asp:ListItem>
                                                        <asp:ListItem Value="RTGS">RTGS</asp:ListItem>
                                                        <%-- <asp:ListItem Value="Online">Online</asp:ListItem>--%>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12" runat="server" visible="false">
                                                    <asp:RadioButtonList ID="rdbPaymentType" runat="server" Font-Bold="false"
                                                        Font-Names="Verdana" RepeatDirection="Vertical" AutoPostBack="True" Width="500px" OnSelectedIndexChanged="rdbPaymentType_SelectedIndexChanged">
                                                        <asp:ListItem Value="DC">Debit Card</asp:ListItem>
                                                        <asp:ListItem Value="CC">Credit Card</asp:ListItem>
                                                        <asp:ListItem Value="NB">Net Banking</asp:ListItem>
                                                        <asp:ListItem Value="NBS">SBI Net Banking</asp:ListItem>
                                                        <asp:ListItem Value="NBH">HDFC Net Banking</asp:ListItem>
                                                        <asp:ListItem Value="NBI">ICICI Net Banking</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                  <div class="col-lg-2 col-md-12 col-sm-12 col-xs-12" id="divShowCharges" runat="server">
                                                    <label class="control-label" id="lblTaxes" runat="server"></label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row" id="divrtgsPaymentDtls" runat="server" visible="false">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">RTGS/NEFT Payment Details</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label2" runat="server">UTR No</label>
                                            <asp:TextBox ID="txtUTRNo" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Date of Remittance</label>
                                            <asp:TextBox ID="txtTransferredDate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Amount</label>
                                            <asp:TextBox ID="txtAmountpaid" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Name of the Bank</label>
                                            <asp:TextBox ID="txtNameoftheBank" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label3" runat="server">Branch</label>
                                            <asp:TextBox ID="txtBranch" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <%--<div class="col-sm-12 text-blue font-SemiBold mb-1">Enclosures</div>--%>
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
                                                    <td align="left" style="width: 30%">Payment Proof</td>
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
                                    <div class="col-sm-12 text-center mt-3" runat="server" id="divbuttons" visible="true">
                                        <%--<asp:Button ID="BtnClear" runat="server" CssClass="btn btn-warning m-2" TabIndex="10" Text="Clear" OnClick="BtnClear_Click" />--%>
                                        <asp:Button ID="BtnSubmit" runat="server" CssClass="btn btn-success m-2" TabIndex="10" Text="Submit Application" OnClick="BtnSubmit_Click" />
                                        <asp:Button ID="btnDash" runat="server" CssClass="btn btn-warning m-2" TabIndex="10" Text="Go to Dashboard" OnClick="btnDash_Click" Visible="false" />
                                    </div>
                                    <%--This Button is for Onilne Payment Method--%>
                                    <%--In Tsipass There is No Payment for Incentives, So This is Button hided--%>
                                    <div class="col-sm-12 text-center mt-3" runat="server" id="div1" visible="false">
                                        <asp:Button ID="btnPayment" runat="server" CssClass="btn btn-success m-2" TabIndex="10" Text="Go to Payment" OnClick="btnPayment_Click" />
                                    </div>

                                    <div class="row" id="divcondtions" runat="server" visible="false">
                                        <div class="col-sm-12 form-group">
                                            <b>Terms and Conditions:
                                                            <br />
                                            </b>
                                            <br />
                                            1. Do not press F5 or refresh the page while the transaction is in process.
                                                        <br />
                                            2. Do not press back button while the transaction is in process
                                                        <br />
                                            3. Only the transactions with “Successful” status message will be deemed to be received
                                                        <br />
                                            4. In case the transaction is not “Successful” and the amount has been debited from
                                                        your account and any other queries, please contact the Toll free number: 7306-600-600
                                                        or upload a grievance.
                                                        <br />
                                            5. There is no refund policy for the payment. But if any excess amount is paid,
                                                        it would be adjusted in the future payments.
                                                        <br />
                                            6. All the details regarding the payments are secure and confidential. We do not
                                                        store the bank details entered by the entrepreneur.
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
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtTransferredDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtTransferredDate']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtTransferredDate']").datepicker(
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
