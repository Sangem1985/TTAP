<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmProductDevelopment.aspx.cs" Inherits="TTAP.UI.Pages.frmProductDevelopment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <asp:PostBackTrigger ControlID="btnNewProductReport" />
            <asp:PostBackTrigger ControlID="btnExpendDocs" />
            <asp:PostBackTrigger ControlID="btnLoanSanction" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Design, Product Development and Diversification</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – XI : Design, Product Development and Diversification</h5>
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
                                            <label class="control-label" id="Labelpolicy1" runat="server">Category of Unit as per T-TAP Policy</label>
                                            <label class="form-control" id="lblCategoryofUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label5" runat="server">Activity of the Unit</label>
                                            <label class="form-control" id="lblActivityoftheUnit" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">New Product / Design Developed / Diversification (not applicable for generic products)</label>
                                            <asp:TextBox ID="txtDesignDeveloped" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Expenditure Incurred in New Product/ Design Development / Diversification (In Rupees)</label>
                                            <asp:TextBox ID="txtExpenditureIncurred" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Earlier Claims made for New Product / Design Development / Diversification</label>
                                            <asp:RadioButtonList ID="RbtnEarlierClaimsMade" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RbtnEarlierClaimsMade_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" id="divEarlierYear" runat="server">
                                            <label class="control-label" id="lblyear" runat="server">Year</label>
                                            <asp:TextBox ID="txtEarlierCliamYear" MaxLength="4" onkeypress="return inputOnlyNumbers(event)" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="divEarlieramount" runat="server">
                                            <label class="control-label" id="lblamountclaimed" runat="server">amount claimed (In Rupees)</label>
                                            <asp:TextBox ID="txtamountclaimed" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblCurrentClaim" runat="server">Current Claim (In Rupees)</label>
                                            <asp:TextBox ID="txtCurrentClaim" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-12 mt-sm-3 text-left">
                                        <p><strong>Note : </strong>Claim - (20% of the annual expenditure limited to Rs 2 lakhs).</p>
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
                                                    <td align="left" style="width: 50%">Report on new product / new design / diversification created</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuNewProductReport" runat="server" />
                                                        <asp:Button ID="btnNewProductReport" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnNewProductReport_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyNewProductReport" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Copies of documents indicating expenditure incurred for new product/design development/diversification</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fluExpendDocs" runat="server"  />
                                                        <asp:Button ID="btnExpendDocs" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnExpendDocs_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyExpendDocs" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Loan sanction order if availed for technology development from Bank / FI</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuLoansanction" runat="server" />
                                                        <asp:Button ID="btnLoanSanction" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnLoanSanction_Click" Text="Upload" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyLoanSanction" runat="server" Target="_blank"></asp:HyperLink>
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
                                        I / We hereby confirm that to the best of my / our knowledge and belief, information given herein before and other papers enclosed are true and correct in all respects. I / We further undertake to substantiate the particulars about promoter(s) and other details with documentary evidence as and when called for.<br />
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
    <script type="text/javascript">
        function pageLoad() {
            $("input[type=text]").attr('autocomplete', 'off');
        }
    </script>
</asp:Content>
