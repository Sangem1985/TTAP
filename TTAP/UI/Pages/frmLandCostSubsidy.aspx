<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmLandCostSubsidy.aspx.cs" Inherits="TTAP.UI.Pages.frmLandCostSubsidy" %>

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
            <asp:PostBackTrigger ControlID="btnRegisteredLandSaleLeaseTransferConversion" />
            <asp:PostBackTrigger ControlID="btnCertificateFromBank" />
            <asp:PostBackTrigger ControlID="btnApprovalofProjectReport" />
            <asp:PostBackTrigger ControlID="btnLayoutDemarcating" />
            <asp:PostBackTrigger ControlID="btnProjectCompletionCertificate" />
            <asp:PostBackTrigger ControlID="btnSaleInvoice" />
            <asp:PostBackTrigger ControlID="btnEvidencingTechnicalTextileUnit" />
            <asp:PostBackTrigger ControlID="btnFirstTimeClaimPARTA" />
            <asp:PostBackTrigger ControlID="btnSupportingDocuments" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Reimbursement of Land Cost</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – XII: Reimbursement of Land Cost</h5>
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
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label8" runat="server">Nature Of Industry</label>
                                            <label class="form-control" id="lblActivityoftheUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label20" runat="server">Type Of Textile</label>
                                            <label class="form-control" id="lblTextileType" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label12" runat="server">Date Of Incorporation of Unit</label>
                                            <asp:TextBox ID="txtDateofEstablishmentofUnit" Enabled="false" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">Category/Definition of the Unit</label>
                                            <asp:DropDownList ID="ddlUtilizationETPCETP" class="form-control" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Anchor Client</asp:ListItem>
                                                <asp:ListItem Value="2">First Mover</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <label class="control-label" id="Label5" runat="server">Whether the Unit is Located in the Textile/ Apparel park Declared by the Govt Of Telangana</label>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:RadioButtonList ID="RbtnTexttileLocationTS" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server">
                                                    <asp:ListItem Text="Yes" Selected="True" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label label-required" id="Label9" runat="server">Land Allotment Information</label>
                                            <asp:CheckBoxList ID="chkLandAllotmentInformation" runat="server" CssClass="checkbox" RepeatDirection="Vertical">
                                                <asp:ListItem Text="Industrial Plots In The Integrated Textile Parks Developed by TSIIC" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Individual Plots On Standalone Basis That Are Away From The Industrail Park Developed By TSIIC" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Land for Development of Industrial Park/Textile Park/Cluster Projects Developed Through Privately Owned or PPP Modes of Investments" Value="3"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label label-required">Total Plinth Area of Factory Building (In Square Meters)</label>
                                            <asp:TextBox ID="txtTotalPlinthArea" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">Total Extent Of Land Purchased (In Acres)</label>
                                            <asp:TextBox ID="txtTotalExtentOfLandPurchased" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">Rate Per Acre (In Rs)</label>
                                            <asp:TextBox ID="txtRatePerAcre" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">Total Investment in Land (In Rs)</label>
                                            <asp:TextBox ID="txtTotalInvestmentinLand" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Any Other Subsidy from Another Source, if any</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Amount Availed</label>
                                            <asp:TextBox ID="txtAmountAvailed" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Source</label>
                                            <asp:TextBox ID="txtSource" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Date Availed:</label>
                                            <asp:TextBox ID="txtDateAvailed" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Reimbursement Amount Claimed (In Rs)</label>
                                            <asp:TextBox ID="txtCurrentClaim" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 mt-sm-3 text-left">
                                        <p><strong>Note : </strong>Reimbursement Amount Claimed - 50% Rebate on Land Cost Ascertained By TSIIC Upto Rs 10 Lakks Per Acre. In Case Of Technical Textile Units, an Additional Rebate of 25% With a Cap of Rs 10 Lakhs Per Acre Shall be Extended.</p>
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
                                                    <td align="left" style="width: 50%">Registered Land Sale Deed/Lease Deed/Transfer Deed/Land Conversion Documents</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuRegisteredLandSaleLeaseTransferConversion" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnRegisteredLandSaleLeaseTransferConversion" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnRegisteredLandSaleLeaseTransferConversion_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyRegisteredLandSaleLeaseTransferConversion" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr1" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Certificate From Bank/ Financial Institutions(FI) Justifying Payment Proof (If Any)
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCertificateFromBank" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnCertificateFromBank" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnCertificateFromBank_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyCertificateFromBank" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr2" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">3</td>
                                                    <td align="left">Approval of Project Report (in prescribed format) From Bank/ Financial Institutions/DIC etc - (if Applicable)
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuApprovalofProjectReport" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnApprovalofProjectReport" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnApprovalofProjectReport_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyApprovalofProjectReport" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr3" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Layout Demarcating the Built up Space Occupied by The Unit/Enterprise/Industry
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuLayoutDemarcating" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnLayoutDemarcating" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnLayoutDemarcating_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyLayoutDemarcating" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr4" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Project Completion Certificate From Concerned Agencies/ Departments
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuProjectCompletionCertificate" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnProjectCompletionCertificate" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnProjectCompletionCertificate_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyProjectCompletionCertificate" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">6</td>
                                                    <td align="left" style="width: 50%">First Sale Invoice</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuSaleInvoice" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnSaleInvoice" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnSaleInvoice_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hySaleInvoice" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr6" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Documents Evidencing That The Unit is a Technical Textile Unit (in case Applying for Additional Subsidy of Technical Textile)
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuEvidencingTechnicalTextileUnit" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnEvidencingTechnicalTextileUnit" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnEvidencingTechnicalTextileUnit_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyEvidencingTechnicalTextileUnit" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr5" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">All The Required Documents As Per Check- Slip At PART-A, For The First Time of The Claim
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuFirstTimeClaimPARTA" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnFirstTimeClaimPARTA" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnFirstTimeClaimPARTA_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyFirstTimeClaimPARTA" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr7" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">9</td>
                                                    <td align="left">Any Other Supporting Documents (if any)
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuSupportingDocuments" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnSupportingDocuments" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnSupportingDocuments_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hySupportingDocuments" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 py-4">
                                        <b>Note : </b> 1). If any further information/documents required by the department, the same shall be furnished by the entrepreneur. <br />
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
                                        <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-blue m-2" TabIndex="10" Text="Previous" OnClick="BtnPrevious_Click" />
                                        <asp:Button ID="BtnNext" runat="server" CssClass="btn btn-success m-2" Enabled="true" TabIndex="10" Text="Save & Next" ValidationGroup="group" OnClick="BtnNext_Click" />
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
        $("input[id$='ContentPlaceHolder1_txtDateAvailed']").keydown(function () {
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

            $("input[id$='ContentPlaceHolder1_txtDateofEstablishmentofUnit']").datepicker(
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
