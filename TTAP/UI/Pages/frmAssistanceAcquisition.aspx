<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmAssistanceAcquisition.aspx.cs" Inherits="TTAP.UI.Pages.frmAssistanceAcquisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>
    <%-- <link href="../../Models/bootstrap.css" rel="stylesheet" />--%>
    
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
            <asp:PostBackTrigger ControlID="btnUpload1" />
            <asp:PostBackTrigger ControlID="btnUpload2" />
            <asp:PostBackTrigger ControlID="btnLoansanction" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Acquisition of New Technology</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – IX : Assistance for Acquisition of New Technology(Audit)</h5>
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
                                            <label class="control-label" id="Label13" runat="server">New Technology Developed(In Words)</label>
                                            <asp:TextBox ID="txtNewTechnologyDeveloped" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">Is the Technology Imported</label>
                                            <asp:RadioButtonList ID="RbtnIstheTechnologyImported" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Text="Yes (Imported)" Selected="True" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No (Local)" Value="N"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Value addition for adoption of new technology</label>
                                            <asp:TextBox ID="txtValueadditionnewtechnology" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label10" runat="server">New technology developed for adaptation to local conditions</label>
                                            <asp:TextBox ID="txtNewtechnologydevelopedadaptation" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label11" runat="server">Details of R&D Institutions/Experts and Technology details</label>
                                            <asp:TextBox ID="txtRDDetails" class="form-control"  TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Cost Incurred in Development of New Technology</label>
                                            <asp:TextBox ID="txtCostIncurredinDevelopment" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Current Claim (In Rs)</label>
                                            <asp:TextBox ID="txtCurrentClaim" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Benefit availed under any other State Scheme(In Rs)</label>
                                            <asp:TextBox ID="txtBenefitavailed" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-12 mt-sm-3 text-left">
                                        <p><strong>Note : </strong>Current Claim - (50% of the cost limited to Rs 10 lakhs).</p>
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
                                                    <td align="left" style="width: 50%">Report on the Technology Developed</td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuDocuments1" runat="server" />
                                                        <asp:Button ID="btnUpload1" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnUpload1_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="lblupload1" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2
                                                    </td>
                                                    <td align="left">Copies of documents indicating cost incurred towards development of new technology
                                                    </td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuDocuments2" runat="server" />
                                                        <asp:Button ID="btnUpload2" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnUpload2_Click" />
                                                    </td>
                                                    <td align="left">
                                                        <asp:HyperLink ID="lblUpload2" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3
                                                    </td>
                                                    <td align="left">Loan sanction order if availed for technology development from Bank / FI </td>
                                                    <td align="center">
                                                        <asp:FileUpload ID="fuLoanSanction" runat="server" />
                                                        <asp:Button ID="btnLoansanction" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnLoansanction_Click" />
                                                    </td>
                                                    <td align="left">
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
