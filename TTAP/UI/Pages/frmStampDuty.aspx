<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmStampDuty.aspx.cs" Inherits="TTAP.UI.Pages.frmStampDuty" %>

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
            <asp:PostBackTrigger ControlID="btnRegisteredLandSale" />
            <asp:PostBackTrigger ControlID="btnPaymentProof" />
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – VI : Reimbursement Of Stamp Duty, Transfer duty, Mortgage & Hypothecation Duty</h5>
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
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Nature of Asset</label>
                                            <asp:RadioButtonList ID="ddlNatureofAsset" name="ApplicationType" RepeatDirection="Horizontal" RepeatLayout="Table" runat="server" class="radio-inline">
                                                <asp:ListItem Selected="True" Text="Industrial Plot" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Industrial Shed" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Land Purchased(In sq mtrs)</label>
                                            <asp:TextBox ID="txtLandPurchased" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label22" runat="server">Cost Per Sq mtr</label>
                                            <asp:TextBox ID="txtLandPurchasedCostPersqmtrs" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Plinth Area of the Building(In sq mtrs)</label>
                                            <asp:TextBox ID="txtPlinthAreaoftheBuilding" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtPlinthAreaoftheBuilding_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label4" runat="server">5 times of the Plinth Area of Factory Buildings(In sq mtrs)</label>
                                            <asp:TextBox ID="txtPlinthFactoryBuildings" Enabled="false" class="form-control disabled" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Area required for the Factory as per the appraisal(In sq mtrs)</label>
                                            <asp:TextBox ID="txtFactoryappraisal" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Area required for the Factory as per the norms of TSPCB or any other State Government Department (In sq mtrs)</label>
                                            <asp:TextBox ID="txtTSPCB" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label11" runat="server">Nature of Transaction / Deed Registered for Industrial Use</label>
                                            <asp:DropDownList ID="ddlNatureofTransaction" runat="server" class="form-control" RepeatDirection="Horizontal" TabIndex="1">
                                                <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                <asp:ListItem Value="1">Sale Deed</asp:ListItem>
                                                <asp:ListItem Value="2">Lease or Lease-cum-sale Transfer Deed</asp:ListItem>
                                                <asp:ListItem Value="3">Financial Deeds</asp:ListItem>
                                                <asp:ListItem Value="4">Mortgages</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Date of Registration</label>
                                            <asp:TextBox ID="txtDateofRegistration" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label13" runat="server">Sub-Registrar Office</label>
                                            <asp:TextBox ID="SubRegistrar" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <label class="control-label" id="Label21" runat="server">Line of Activity</label>
                                            <asp:Label ID="txtLineofActivity" class="form-control" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Stamp Duty/Transfer duty / Mortgage and Hypothecations Duty Paid</div>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label14" runat="server">Stamp Duty / Transfer Duty Paid</label>
                                            <asp:TextBox ID="txtStampDutyTransferDutyPaid" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label15" runat="server">Mortgage & Hypothecation Duty Paid</label>
                                            <asp:TextBox ID="txtMortgageHypothecationDutyPaid" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label16" runat="server">Stamp Duty Exemption already Availed as per GO. Ms. No. 59</label>
                                            <asp:TextBox ID="txtStampDutyExemptionalreadyAvailed" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label17" runat="server">Details of the Term loan(s) availed with respect to above</label>
                                            <asp:TextBox ID="Termloan14" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Land Subsidy sanctioned / availed</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Amount Availed</label>
                                            <asp:TextBox ID="txtAmountAvailed" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label20" runat="server">Sanction Order No</label>
                                            <asp:TextBox ID="txtSanctionOrderNo" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Date Availed:</label>
                                            <asp:TextBox ID="txtDateAvailed" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Current Claim (100% Reimbursement)</div>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label18" runat="server">Stamp Duty / Transfer Duty</label>
                                            <asp:TextBox ID="txtCurrentClaimStampTransferDuty" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label19" runat="server">Mortgage & Hypothecation Duty</label>
                                            <asp:TextBox ID="txtCurrentClaimMortgageHypothecationDuty" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12 text-blue font-SemiBold mb-1">Enclosures</div>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                <tr align="center">
                                                    <th>Sl.No </th>
                                                    <th>Document Name </th>
                                                    <th>Upload Document </th>
                                                    <th>File Name </th>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 50%">Registered Land Sale Deed/Lease Deed/Transfer Deed/Land conversion document
                                                    </td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuRegisteredLandSale" runat="server" />
                                                        <asp:Button ID="btnRegisteredLandSale" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnRegisteredLandSale_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="hyRegisteredlandSale" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Payment Proof</td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuPaymentProof" runat="server" />
                                                        <asp:Button ID="btnPaymentProof" runat="server" Text="Upload" CssClass="btn btn-info btn-sm mx-2" OnClick="btnPaymentProof_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="hyPayment" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="4" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" visible="false" class="alert alert-success">

                                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 py-4">
                                        <b>Note : </b>1). If any further information/documents required by the department, the same shall be furnished by the entrepreneur.
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        2). If any errors found in the data, the same will have to be rectified by the entrepreneurs, then only the provisional incentive will be finalized.
                                    </div>
                                    <div class="col-sm-12">
                                        <b>DECLARATION : </b>
                                        <br />
                                        I / We hereby confirm that to the best of my / our knowledge and belief, information given herein before and other papers enclosed are true and correct in all respects. I / We further undertake to substantiate the particulars about promoter(s) and other details with documentary evidence as and when called for.
                                <br />
                                        <br />
                                        I/We hereby agree that I/We shall forthwith repay the amount disbursed to me/us under the scheme, if the amount of Reimbursement is found to be disbursed in excess of the amount actually admissible whatsoever the reason.
                                    </div>
                                    <div class="col-sm-12 text-center mt-3">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success" TabIndex="10" Visible="false" Text="Submit" ValidationGroup="group" />
                                        <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-blue m-2" OnClick="BtnPrevious_Click" TabIndex="10" Text="Previous" />
                                        <asp:Button ID="BtnNext" runat="server" CssClass="btn btn-success m-2" Enabled="true" OnClick="BtnNext_Click" TabIndex="10" Text="Save & Next" ValidationGroup="group" />
                                        <%-- &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Enabled="false" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />--%>
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
        $("input[id$='ContentPlaceHolder1_txtDateAvailed']").keydown(function () {
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
            $("input[id$='ContentPlaceHolder1_txtDateAvailed']").datepicker(
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
            $("input[id$='ContentPlaceHolder1_txtDateAvailed']").datepicker(
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
