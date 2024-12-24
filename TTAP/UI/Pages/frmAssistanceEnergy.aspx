<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmAssistanceEnergy.aspx.cs" Inherits="TTAP.UI.Pages.frmAssistanceEnergy" %>

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
            <asp:PostBackTrigger ControlID="btnSaleInvoice" />
            <asp:PostBackTrigger ControlID="btnCostIncurred" />
            <asp:PostBackTrigger ControlID="btnAcrreditationDetails" />
            <asp:PostBackTrigger ControlID="btnImplementationEnergy" />
            <asp:PostBackTrigger ControlID="btnLoanSanction" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Assistance for Energy,  Water and Environmental</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – VIII : Assistance for Energy, Water and Environmental Compliance to Existing Units</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2" runat="server">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label3" runat="server">Common Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <label class="control-label label-required" id="Label4" runat="server">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label7" runat="server">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Date Of Incorporation of Unit</label>
                                            <asp:TextBox ID="txtDateofEstablishmentofUnit"  Enabled="false" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label5" runat="server">Is the Unit into Commercial Production for at least three years</label>
                                            <asp:RadioButtonList ID="RbtnCommercialProduction" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Text="Yes" Selected="True" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label label-required" id="Label9" runat="server">Type of Infrastructure Installed</label>
                                            <asp:CheckBoxList ID="chkTypeofInfrastructure" runat="server" CssClass="checkbox" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Energy Conservation" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Water Conservation" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Environmental Conservation" Value="3"></asp:ListItem>
                                                <%--<asp:ListItem Text=" Common Effluent Treatment Plant at Cluster / Industrial Park" Value="4"></asp:ListItem>--%>
                                            </asp:CheckBoxList>
                                        </div>
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label label-required" id="Label1" runat="server">Assistance Required For</label>
                                            <asp:CheckBoxList ID="chkAssistanceRequired" runat="server" CssClass="checkbox" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="chkAssistanceRequired_SelectedIndexChanged">
                                                <asp:ListItem Text="Energy Audit" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Water Audit" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Environmental Compliance" Value="3"></asp:ListItem>
                                                <%--<asp:ListItem Text=" Common Effluent Treatment Plant at Cluster / Industrial Park" Value="4"></asp:ListItem>--%>
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                    <div class="row" id="divEnergyAuditConducted" runat="server">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Energy Audit Conducted</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Date of Audit</label>
                                            <asp:TextBox ID="txtEnergyAuditDateofAudit" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Name of Auditor / Audit Firm</label>
                                            <asp:TextBox ID="txtEnergyAuditNameofAuditorAuditFirm" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Cost Incurred (In Rupees)</label>
                                            <asp:TextBox ID="txtEnergyAuditCostIncurred" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label11" runat="server">Invoice Number</label>
                                            <asp:TextBox ID="txtEnergyAuditInvoiceNumber" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label13" runat="server">Date of Invoice</label>
                                            <asp:TextBox ID="txtEnergyAuditDateofInvoice" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="divWaterAuditConducted" runat="server">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Water Audit Conducted</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label14" runat="server">Date of Audit</label>
                                            <asp:TextBox ID="txtWaterDateofAudit" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label15" runat="server">Name of Auditor / Audit Firm</label>
                                            <asp:TextBox ID="txtWaterNameofAuditorAuditFirm" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label16" runat="server">Cost Incurred (In Rupees)</label>
                                            <asp:TextBox ID="txtWaterCostIncurred" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label17" runat="server">Invoice Number</label>
                                            <asp:TextBox ID="txtWaterInvoiceNumber" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label18" runat="server">Date of Invoice</label>
                                            <asp:TextBox ID="txtWaterDateofInvoice" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="divEnvironmentalCompliance" runat="server">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Environmental Compliance</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label19" runat="server">Date of Receipt of Compliance</label>
                                            <asp:TextBox ID="txtEnvironmentalComplianceDateofAudit" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label20" runat="server">Name of Compliance</label>
                                            <asp:TextBox ID="txtNameofCompliance" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label21" runat="server">Certifying Agency</label>
                                            <asp:TextBox ID="txtCertifyingAgency" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label24" runat="server">Cost Incurred (In Rupees)</label>
                                            <asp:TextBox ID="txtEnvironmentalComplianceCostIncurred" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label22" runat="server">Invoice Number</label>
                                            <asp:TextBox ID="txtEnvironmentalComplianceInvoiceNumber" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label23" runat="server">Date of Invoice</label>
                                            <asp:TextBox ID="txtEnvironmentalComplianceDateofInvoice" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Claims Made So far</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label25" runat="server">Date of Last Claim</label>
                                            <asp:TextBox ID="txtDateofLastClaim" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <label class="control-label" id="Label26" runat="server">Nature of Expenses</label>
                                            <asp:CheckBoxList ID="chkNatureofExpenses" runat="server" CssClass="checkbox" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Energy Audit" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Water Audit" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Environmental Compliance" Value="3"></asp:ListItem>
                                                <%--<asp:ListItem Text=" Common Effluent Treatment Plant at Cluster / Industrial Park" Value="4"></asp:ListItem>--%>
                                            </asp:CheckBoxList>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label27" runat="server">Claim Amount (In Rupees)</label>
                                            <asp:TextBox ID="txtClaimAmount" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label28" runat="server">Reimbursement Received (In Rupees)</label>
                                            <asp:TextBox ID="txtReimbursementReceived" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Government Scheme Availed</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Amount Availed</label>
                                            <asp:TextBox ID="txtGovernmentAmountAvailed" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Date Availed:</label>
                                            <asp:TextBox ID="txtGovernmentDateAvailed" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Current Claim (In Rupees) - (50% limited to Rs 50,000 for each category)</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label31" runat="server">Energy Audit</label>
                                            <asp:TextBox ID="txtCurrentClaimEnergyAudit" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label32" runat="server">Water Audit</label>
                                            <asp:TextBox ID="txtCurrentClaimWaterAudit" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label33" runat="server">Environmental Compliance</label>
                                            <asp:TextBox ID="txtCurrentClaimEnvironmentalCompliance" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
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
                                                    <td align="left" style="width: 50%">First Sale Invoice
                                                    </td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuSaleInvoice" runat="server" />
                                                        <asp:Button ID="btnSaleInvoice" runat="server" Text="Upload" CssClass="btn btn-info btn-sm mx-2" OnClick="btnSaleInvoice_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="hysaleInvoice" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2
                                                    </td>
                                                    <td align="left">Copies of documents indicating cost incurred towards Energy / Water Audit / Environmental Compliance
                                                    </td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuCostincurred" runat="server" />
                                                        <asp:Button ID="btnCostIncurred" runat="server" Text="Upload" CssClass="btn btn-info btn-sm mx-2" OnClick="btnCostIncurred_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="hyCostincurred" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3
                                                    </td>
                                                    <td align="left">Accreditation of Energy / Water Auditor with Details
                                                    </td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuAcrreditationDetails" runat="server" />
                                                        <asp:Button ID="btnAcrreditationDetails" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnAcrreditationDetails_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="hyAcrreditationDetails" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4
                                                    </td>
                                                    <td align="left">Document in support of implementation of Energy Audit / Water Audit / Environmental Compliance Report
                                                    </td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuImplementationEnergy" runat="server" />
                                                        <asp:Button ID="btnImplementationEnergy" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnImplementationEnergy_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="hyImplementationEnergy" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>


                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">5
                                                    </td>
                                                    <td align="left">Loan sanction order if availed for conducting Audit from Bank / FI
                                                    </td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuLoanSanction" runat="server" />
                                                        <asp:Button ID="btnLoanSanction" runat="server" Text="Upload" CssClass="btn btn-info btn-sm mx-2" OnClick="btnLoanSanction_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="hyLoanSanction" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
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

                                        <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-blue m-2" OnClick="BtnPrevious_Click" TabIndex="10" Text="Previous" />
                                        <asp:Button ID="BtnNext" runat="server" CssClass="btn btn-success m-2" Enabled="true" OnClick="BtnNext_Click" TabIndex="10" Text="Save & Next" ValidationGroup="group" />
                                        <%-- &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Enabled="false" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />--%>
                                    </div>
                                    <div class="col-sm-12">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
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
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtDateofEstablishmentofUnit']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtEnergyAuditDateofAudit']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtEnergyAuditDateofInvoice']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtWaterDateofAudit']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtWaterDateofInvoice']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtEnvironmentalComplianceDateofAudit']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtEnvironmentalComplianceDateofInvoice']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtDateofLastClaim']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtGovernmentDateAvailed']").keydown(function () {
            return false;
        });


        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[type=text]").attr('autocomplete', 'off');
            $("input[id$='ContentPlaceHolder1_txtDateofEstablishmentofUnit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtEnergyAuditDateofAudit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtEnergyAuditDateofInvoice']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtWaterDateofAudit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtWaterDateofInvoice']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtEnvironmentalComplianceDateofAudit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtEnvironmentalComplianceDateofInvoice']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtDateofLastClaim']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtGovernmentDateAvailed']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtDateofEstablishmentofUnit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtEnergyAuditDateofAudit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtEnergyAuditDateofInvoice']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtWaterDateofAudit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtWaterDateofInvoice']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtEnvironmentalComplianceDateofAudit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtEnvironmentalComplianceDateofInvoice']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtDateofLastClaim']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtGovernmentDateAvailed']").datepicker(
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
