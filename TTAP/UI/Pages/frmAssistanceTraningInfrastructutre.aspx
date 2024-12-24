<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmAssistanceTraningInfrastructutre.aspx.cs" Inherits="TTAP.UI.Pages.frmAssistanceTraningInfrastructutre" %>

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
            <asp:PostBackTrigger ControlID="btnUpload1" />
            <asp:PostBackTrigger ControlID="Button1" />
            <asp:PostBackTrigger ControlID="btnCharteredEngineer" />
            <asp:PostBackTrigger ControlID="btnRegistrationTrainingInstitute" />

        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Assistance towards Training Infrastructure in Apparel Design and Development</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form XVIII : Assistance towards Training Infrastructure in Apparel Design and Development</h5>
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
                                            <label class="control-label" id="Label6" runat="server">Name of Training Centre</label>
                                            <asp:TextBox ID="txtNameofTrainingCentre" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">Type of Training Centre</label>
                                            <asp:DropDownList ID="ddlTypeofTrainingCentre" runat="server" class="form-control" RepeatDirection="Horizontal" TabIndex="1">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Public Sector</asp:ListItem>
                                                <asp:ListItem Value="2">Autonomous</asp:ListItem>
                                                <asp:ListItem Value="3">Private</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Empanelled DH&T</label>
                                            <asp:TextBox ID="txtEmpanelledDHT" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label18" runat="server">Purpose</label>
                                            <asp:DropDownList ID="ddlPurpose" class="form-control" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">New Training Infrastructure Creation</asp:ListItem>
                                                <asp:ListItem Value="2">Up-Gradation of Facilities</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Location of Training Centre</label>
                                            <asp:TextBox ID="txtLocationofTrainingCentre" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Courses offered in the Training Centre</label>
                                            <asp:TextBox ID="txtCoursesoffered" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <asp:Label ID="Label15" runat="server" CssClass="label-required text-blue" Font-Bold="True">
                                              Details of Trainees</asp:Label>
                                        </div>
                                        <div class="row w-100 m-0" id="DivTraineeDetails" runat="server">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Name of the Trainee</label>
                                                <asp:TextBox ID="txtNameoftheTrainee" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label17" runat="server">Type of Training</label>
                                                <asp:DropDownList ID="ddlTypeofTraining" class="form-control" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Skill Up Gradation</asp:ListItem>
                                                    <asp:ListItem Value="2">Training</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label16" runat="server">Trainee Localization</label>
                                                <asp:DropDownList ID="ddlTraineeLocalization" class="form-control" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Local</asp:ListItem>
                                                    <asp:ListItem Value="2">Non Local</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Period of Training - From </label>
                                                <asp:TextBox ID="txtTrainingfromdate" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Period of Training - To</label>
                                                <asp:TextBox ID="txtTrainingtodate" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Expenditure Incurred(in Rs)</label>
                                                <asp:TextBox ID="txtExpenditureIncurred" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                    TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnaddTraineeDtls" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnaddTraineeDtls_Click" />
                                                <asp:Button ID="btnClearTraineeDtls" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="GvTraineeDtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="GvTraineeDtls_RowCommand">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name of the Trainee">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNameoftheTrainee" runat="server" Text='<%# Bind("NameoftheTrainee") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type of Training">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTypeofTraining" runat="server" Text='<%# Bind("TypeofTrainingText") %>'></asp:Label>
                                                            <asp:Label ID="lblTypeofTrainingID" runat="server" Text='<%# Bind("TypeofTraining") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trainee Localization">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTraineeLocalization" runat="server" Text='<%# Bind("TraineeLocalizationText") %>'></asp:Label>
                                                            <asp:Label ID="lblTraineeLocalizationID" runat="server" Text='<%# Bind("TraineeLocalization") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Period of training  (From-to)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPeriodoftraining" runat="server" Text='<%# Bind("Periodoftraining") %>'></asp:Label>
                                                            <asp:Label ID="lblPeriodoftrainingFrom" Visible="false" runat="server" Text='<%# Bind("PeriodoftrainingFrom") %>'></asp:Label>
                                                            <asp:Label ID="lblPeriodoftrainingTo" Visible="false" runat="server" Text='<%# Bind("PeriodoftrainingTo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Expenditure Incurred">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExpenditureIncurred" runat="server" Text='<%# Bind("ExpenditureIncurred") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Trainee" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTrainee_ID" runat="server" Text='<%# Bind("Trainee_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Investments for Setting up of Training Infrastructure (In Rupees)</div>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblyear" runat="server">Building</label>
                                            <asp:TextBox ID="txtBuilding" onkeypress="DecimalOnly()" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtBuilding_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblamountclaimed" runat="server">Plant & Machinery required for demonstration</label>
                                            <asp:TextBox ID="txtPlantMachinery" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtBuilding_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblCurrentClaim" runat="server">Installation Charges</label>
                                            <asp:TextBox ID="txtInstallationCharges" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtBuilding_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Electrification</label>
                                            <asp:TextBox ID="txtElectrification" onkeypress="DecimalOnly()" class="form-control" runat="server" AutoPostBack="True" OnTextChanged="txtBuilding_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label11" runat="server">Training Aids like projector etc</label>
                                            <asp:TextBox ID="txtTrainingAids" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtBuilding_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Furniture</label>
                                            <asp:TextBox ID="txtFurniture" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtBuilding_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label13" runat="server">Total Investment for Setting up of Training Infrastructure (Amount in Rupees)</label>
                                            <label class="form-control" id="lblTotalInvestment" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label14" runat="server">Current Claim (In Rupees)</label>
                                            <asp:TextBox ID="txtCurrentClaim" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 mt-sm-3 text-left">
                                        <p><strong>Note : </strong>Claim - (Reimbursement 50% of their investment towards infrastructure creation subject to a maximum amount of Rs. 20 lakh per centre).</p>
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
                                                    <td align="left" style="width: 50%">Credentials of the Institute setting up infrastructure for Apparel Design and Development</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuDocuments1" runat="server" />
                                                        <asp:Button ID="btnUpload1" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnUpload1_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="lblUpload1" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Certificate from CA on the investments made by the Applicant towards the Training Infrastructure</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="flUploadCACertificate" runat="server" />
                                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="Button1_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Certificate from Chartered Engineer</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCharteredEngineer" runat="server" />
                                                        <asp:Button ID="btnCharteredEngineer" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnCharteredEngineer_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyCharteredEngineer" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">4</td>
                                                    <td align="left">Registration Certificate of the Training Institute</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuRegistrationTrainingInstitute" runat="server" />
                                                        <asp:Button ID="btnRegistrationTrainingInstitute" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnRegistrationTrainingInstitute_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyRegistrationTrainingInstitute" runat="server" Target="_blank"></asp:HyperLink>
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

        $("input[id$='ContentPlaceHolder1_txtTrainingfromdate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtTrainingtodate']").keydown(function () {
            return false;
        });




        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');
            $("input[id$='ContentPlaceHolder1_txtTrainingfromdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtTrainingtodate']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtTrainingfromdate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });

            $("input[id$='ContentPlaceHolder1_txtTrainingtodate']").datepicker(
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
