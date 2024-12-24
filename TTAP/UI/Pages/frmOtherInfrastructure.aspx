<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmOtherInfrastructure.aspx.cs" Inherits="TTAP.UI.Pages.frmOtherInfrastructure" %>

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
            <asp:PostBackTrigger ControlID="btnCertificationLineDepartments" />
            <asp:PostBackTrigger ControlID="btnUndertakingContinuationoperation" />

            <asp:PostBackTrigger ControlID="btnCharteredEngineerCertificate" />
            <asp:PostBackTrigger ControlID="btnCharteredEngineerCertificate" />
            <asp:PostBackTrigger ControlID="btnDepartmentsNodepartmentalFunds" />
            
            <asp:PostBackTrigger ControlID="btnFinancialAssistance" />
            
            
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Other Infrastructure Support</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – XIV : Other Infrastructure Support</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="lbltsipass">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label3">Common Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <label class="control-label label-required" id="Label4">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label7">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Whether it is located in Industrial Area declared by the Government</label>
                                            <asp:RadioButtonList ID="RbtnIndustrialArea" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6e" runat="server">Category of Business</label>
                                            <asp:TextBox ID="txtCategoryofBusiness" ReadOnly="true" Enabled="false" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Years of Operation from Date of Commencement</label>
                                            <asp:TextBox ID="txtYearsofOperation" MaxLength="4" onkeypress="return inputOnlyNumbers(event)" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label" id="lblyear" runat="server">Justification for the location of Enterprise/Industry, if it is located outside the Industrial Area declared by the Government.(Location beyond 10 KM from existing IE / IDS)</label>
                                            <asp:TextBox ID="txtJustificationforlocation" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label2">How the proposed infrastructure is critical to the Industrial Enterprise.</label>
                                            <asp:TextBox ID="txtProposedInfrastructureJustification" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblamountclaimed" runat="server">Source of Finance</label>
                                            <asp:TextBox ID="txtSourceOfFinance" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Description of the infrastructure facilities required and its objective</div>
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="lblCurrentClaim" runat="server">Roads, Power, Water</label>
                                            <asp:TextBox ID="txtRoadsPowerWaterDescription" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label1">Support Infrastructure</label>
                                            <asp:TextBox ID="txtSupportInfrastructureDescription" class="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" id="div2" runat="server">
                                            <label class="control-label" id="Labelw2">Estimate Cost of Infrastructure facilities (Roads)</label>
                                            <asp:TextBox ID="txtEstimateCostRoadsPowerWater" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtEstimateCostRoadsPowerWater_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div8" runat="server">
                                            <label class="control-label" id="Labelw3">Estimate Cost of Infrastructure facilities (Power)</label>
                                            <asp:TextBox ID="txtEstimateCostPower" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtEstimateCostRoadsPowerWater_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div9" runat="server">
                                            <label class="control-label" id="Labelw4">Estimate Cost of Infrastructure facilities (Water)</label>
                                            <asp:TextBox ID="txtEstimateCostWater" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtEstimateCostRoadsPowerWater_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div10" runat="server">
                                            <label class="control-label" id="Labelw5">Estimate Cost of Infrastructure facilities (Drainage Line)</label>
                                            <asp:TextBox ID="txtEstimateCostDrainageLine" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtEstimateCostRoadsPowerWater_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div1" runat="server">
                                            <label class="control-label" id="lblYearoftheClaim" runat="server">Estimate Cost of Infrastructure facilities (Total)</label>
                                            <asp:TextBox ID="txtSupportEstimateCost" Enabled="false" ReadOnly="true" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Labela3">Name of the Chartered Engineer/Agency who prepared the Estimates</label>
                                            <asp:TextBox ID="txtCharteredEngineerName" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" id="div3" runat="server">
                                            <label class="control-label" id="Labels5" runat="server">15 % Estimate Cost of Infrastructure facilities (Total)</label>
                                            <asp:TextBox ID="txtEstimateCostSupport15" Enabled="false" MaxLength="4" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div4" runat="server">
                                            <label class="control-label" id="Labelav2">15 % Estimate Cost of Infrastructure facilities (Roads)</label>
                                            <asp:TextBox ID="txtEstimateCostRoadsPowerWater15" Enabled="false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div11" runat="server">
                                            <label class="control-label" id="Labelav1">15 % Estimate Cost of Infrastructure facilities (Power)</label>
                                            <asp:TextBox ID="txtEstimateCostPower15" Enabled="false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div12" runat="server">
                                            <label class="control-label" id="Labelav3">15 % Estimate Cost of Infrastructure facilities (Water)</label>
                                            <asp:TextBox ID="txtEstimateCostWater15" Enabled="false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Labeler3">Duration of the Project</label>
                                            <asp:TextBox ID="txtProjectDuration" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" id="div6" runat="server">
                                            <label class="control-label" id="Labddel5" runat="server">Measures proposed to maintain the infrastructure created</label>
                                            <asp:TextBox ID="txtMeasuresproposed" MaxLength="4" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div5" runat="server">
                                            <label class="control-label" id="lbll5" runat="server">its maintenance cost per annum</label>
                                            <asp:TextBox ID="txtmaintenancecost" MaxLength="4" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div7" runat="server">
                                            <label class="control-label" id="Label5" runat="server">Whether financial assistance availed earlier from any other schemes of the State or Central Govt</label>
                                            <asp:RadioButtonList ID="RbtnAssistanceAvailed" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RbtnAssistanceAvailed_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row" id="divSubsidyAvailed" runat="server" visible="false">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Subsidy Sanctioned / Availed so far with sanction order no & date, if any from Govt. of India or any other Agency</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Amount Availed</label>
                                            <asp:TextBox ID="txtAmountAvailed" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Sanction Order No</label>
                                            <asp:TextBox ID="txtSanctionOrderNo" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Date Availed:</label>
                                            <asp:TextBox ID="txtDateAvailed" class="form-control" runat="server"></asp:TextBox>
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
                                                    <td align="left" style="width: 50%">Copy of the Project & its approval report</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuNewProductReport" runat="server" />
                                                        <asp:Button ID="btnNewProductReport" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnNewProductReport_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyNewProductReport" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">2</td>
                                                    <td align="left" style="width: 50%">Certification from the Concerned Line Departments, Stating that the project is not covered in the budgetary estimates of current year. </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCertificationLineDepartments" runat="server" />
                                                        <asp:Button ID="btnCertificationLineDepartments" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnCertificationLineDepartments_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyCertificationLineDepartments" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">3</td>
                                                    <td align="left" style="width: 50%">Undertaking for Continuation in operation for the 6/10 years</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuUndertakingContinuationoperation" runat="server" />
                                                        <asp:Button ID="btnUndertakingContinuationoperation" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnUndertakingContinuationoperation_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyUndertakingContinuationoperation" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Chartered Engineer Certificate with Stamp & Registration Number</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCharteredEngineerCertificate" runat="server" />
                                                        <asp:Button ID="btnCharteredEngineerCertificate" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnCharteredEngineerCertificate_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyCharteredEngineerCertificate" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">As an Evidence of Financial Assistance Availed Copy of Bank Statement</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuFinancialAssistance" runat="server" />
                                                        <asp:Button ID="btnFinancialAssistance" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnFinancialAssistance_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyFinancialAssistance" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">6</td>
                                                    <td align="left" style="width: 50%">Certification from the Concerned Line Departments, Stating that no departmental funds are available for this purpose</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuDepartmentsNodepartmentalFunds" runat="server" />
                                                        <asp:Button ID="btnDepartmentsNodepartmentalFunds" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnDepartmentsNodepartmentalFunds_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyDepartmentsNodepartmentalFunds" runat="server" Target="_blank"></asp:HyperLink>
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

    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">


        $("input[id$='ContentPlaceHolder1_txtDateAvailed']").keydown(function () {
            return false;
        });


        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');

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
