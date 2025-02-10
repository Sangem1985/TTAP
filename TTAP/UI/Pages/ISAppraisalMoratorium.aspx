<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="ISAppraisalMoratorium.aspx.cs" Inherits="TTAP.UI.Pages.ISAppraisalMoratorium" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Js/validations.js"></script>
    <script type="text/javascript">       

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[type=text]").attr('autocomplete', 'off');
            $("input[id$='ContentPlaceHolder1_txtDisbtoDCPdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        }
    </script>
    <div id="content">
        <div id="content-header" class="d-none">
            <
            <%--  <h1>Fill Industry Details</h1>--%>
        </div>
        <div class="breadcrumb-bg">
            <ul class="breadcrumb font-medium title5 container">
                <li class="breadcrumb-item"><i class="fa fa-home title4" aria-hidden="true"></i>Home</li>
                <li class="breadcrumb-item">Moratorium Process Flow Chart</li>
            </ul>
        </div>
        <div>
            <div class="row">
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label12" runat="server">1) Date of Disbursement to DCP Date</label>
                    <asp:TextBox class="form-control" ID="txtDisbtoDCPdate" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label26" runat="server">2) Loan Amount Disbursed</label>
                    <asp:TextBox class="form-control" ID="txtLoanAmount" onkeypress="DecimalOnly()" AutoPostBack="true" runat="server" OnTextChanged="txtLoanAmount_TextChanged"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label27" runat="server">3) Rate of Interest</label>
                    <asp:TextBox class="form-control" ID="txtROI" runat="server" onkeypress="DecimalOnly()" AutoPostBack="true" OnTextChanged="txtROI_TextChanged"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label28" runat="server">4) Interest Due per Annum</label>
                    <asp:TextBox class="form-control" ID="txtInterestDue" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label29" runat="server">5) Interest Due per Month</label>
                    <asp:TextBox class="form-control" ID="txtInterestDuePM" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label30" runat="server">6) 75% of Monthly Interest</label>
                    <asp:TextBox class="form-control" ID="txt75Interest" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label31" runat="server">7) 8% of Monthly Interest of Loan AMount</label>
                    <asp:TextBox class="form-control" ID="txt8InterestforLoan" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label3" runat="server">8) Lower amount among 6 and 7</label>
                    <asp:TextBox class="form-control" ID="txtlowerInterest" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label19" runat="server">9) Moratorium period in months</label>
                    <asp:TextBox class="form-control" ID="txtMortPeriod" runat="server" onkeypress="NumberOnly()" AutoPostBack="true" OnTextChanged="txtMortPeriod_TextChanged"></asp:TextBox>
                </div>

                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label32" runat="server">10) Total Eligible Reimbursement of Interest</label>
                    <asp:TextBox class="form-control" ID="txtTotElgbleInterest" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label18" runat="server">11) Recommendation by GM/DLO</label>
                    <asp:TextBox class="form-control" ID="txtGMRecAmount" runat="server"></asp:TextBox>
                </div>

                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label33" runat="server">12) Final Eligible Subsidy</label>
                    <asp:TextBox class="form-control" ID="txtFnlElgbleSbsdy" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label1" runat="server">13) Remarks</label>
                    <asp:TextBox class="form-control" ID="txtRemarks" runat="server"></asp:TextBox>
                </div>
                <div class="col-sm-4 form-group">
                    <label class="control-label" id="Label2" runat="server">14) Upload Document</label><br />
                    <asp:FileUpload class="form-control" ID="fupDoc" runat="server"></asp:FileUpload>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
