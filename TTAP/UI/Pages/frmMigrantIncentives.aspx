<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmMigrantIncentives.aspx.cs" Inherits="TTAP.UI.Pages.frmMigrantIncentives" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>

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
            <asp:PostBackTrigger ControlID="btnMigrationcompetentauthorities" />
            <asp:PostBackTrigger ControlID="btnPermissionsLineDepartments" />
            <asp:PostBackTrigger ControlID="btnGovtSanctionOrderSITP" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Returning Migrant’s Incentive Scheme</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form XIX : Returning Migrant’s Incentive Scheme</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="LabelS3" runat="server">Common Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <label class="control-label label-required" id="LabSel4" runat="server">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label7" runat="server">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row" id="trFixedcap" runat="server" visible="true">
                                        <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Approved Project Cost(In Rs.)</h5>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                    <th>Sl.No</th>
                                                    <th>Nature of Assets</th>
                                                    <th>Value (in Rs.)</th>
                                                    <th id="trFixedCapitalexpansion" runat="server"
                                                        visible="false">Under Expansion/ Diversification/ Modification Project
                                                    </th>
                                                    <th id="trFixedCapitalexpnPercent" runat="server"
                                                        visible="false">% of increase under
                                                                            <br />
                                                        Expansion/Diversification/Modification
                                                    </th>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td>1</td>
                                                    <td align="left">Land</td>
                                                    <td align="center">
                                                        <asp:Label ID="txtlandexisting" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>
                                                    <td id="trFixedCapitalland" runat="server" align="center" visible="false">
                                                        <asp:Label ID="txtlandcapacity" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>
                                                    <td id="txtbuildcapacityPercet" runat="server" align="center" visible="false">
                                                        <asp:Label ID="txtlandpercentage" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td>2</td>
                                                    <td align="left">Building </td>
                                                    <td align="center">
                                                        <asp:Label ID="txtbuildingexisting" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>

                                                    <td id="trFixedCapitalBuilding" runat="server" align="center" visible="false">
                                                        <asp:Label ID="txtbuildingcapacity" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>

                                                    <td id="trFixedCapitBuildPercent" runat="server" align="center" visible="false">
                                                        <asp:Label ID="txtbuildingpercentage" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td>3</td>
                                                    <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;
                                                    </td>
                                                    <td align="center">
                                                        <asp:Label ID="txtplantexisting" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>
                                                    <td id="trFixedCapitalMach" runat="server" align="center" visible="false">
                                                        <asp:Label ID="txtplantcapacity" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>
                                                    <td id="trFixedCapitMachPercent" runat="server" align="center" visible="false">
                                                        <asp:Label ID="txtplantpercentage" runat="server" CssClass="form-control"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td></td>
                                                    <td align="left" style="text-align: left; font-weight: bold">Total</td>
                                                    <td align="center">
                                                        <asp:Label ID="lblnewinv" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td id="Td3" runat="server" align="center" visible="false">
                                                        <asp:Label ID="lblexpinv" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                    <td id="Td4" runat="server" align="center" visible="false">
                                                        <asp:Label ID="lbltotperinv" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <%--<div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Capital Investment</label>
                                            <asp:TextBox ID="txtCapitalInvestment" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>--%>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Scheme: SITP, GOI MSME Cluster Development</label>
                                            <asp:TextBox ID="txtScheme" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Percentage of Members as Weavers</label>
                                            <asp:TextBox ID="txtWeaversPercentage" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="LabeDl5" runat="server">Contribution to investment by beneficiary groups in Rs.</label>
                                            <asp:TextBox ID="txtContributiontoinvestment" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                         <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">Percentage GOI contribution in Capital Investment</label>
                                            <asp:TextBox ID="txtPercentageGOIContribution" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Investments for Setting up Textile Park  (In Rupees)</div>
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
                                            <label class="control-label" id="Label12" runat="server">Others</label>
                                            <asp:TextBox ID="txtOthers" class="form-control" onkeypress="DecimalOnly()" runat="server" AutoPostBack="True" OnTextChanged="txtBuilding_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label13" runat="server">Total Investment for Setting up of Infrastructure (Amount in Rupees)</label>
                                            <label class="form-control" id="lblTotalInvestment" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label14" runat="server">Current Claim (In Rs)</label>
                                            <asp:TextBox ID="txtCurrentClaim" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Whether any amount claim under skill upgradation of Govt. of India/ State Govt. If yes, the details of amount claimed</h6>
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
                                    <div class="col-sm-12 mt-sm-3 text-left">
                                        <p><strong>Note : </strong>Current Claim - (Reimbursement 50% of their investment towards infrastructure creation subject to a maximum amount of Rs. 2.0 Cr).</p>
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
                                                <tr class="GridviewScrollC1Item" style="display: none">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 50%">Credentials of the Institute setting up Unit</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuDocuments1" runat="server" />
                                                        <asp:Button ID="btnUpload1" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnUpload1_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="lblUpload1" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 50%">Certificate from CA on the investments made by the Applicant</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="flUploadCACertificate" runat="server" />
                                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="Button1_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">2</td>
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
                                                    <td align="center">3</td>
                                                    <td align="left">Migration certificate issued by the competent authorities</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuMigrationcompetentauthorities" runat="server" />
                                                        <asp:Button ID="btnMigrationcompetentauthorities" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnMigrationcompetentauthorities_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyMigrationcompetentauthorities" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">4</td>
                                                    <td align="left">Copy of the Permissions Obtained by the Concern Line Departments</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPermissionsLineDepartments" runat="server" />
                                                        <asp:Button ID="btnPermissionsLineDepartments" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnPermissionsLineDepartments_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyPermissionsLineDepartments" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">5</td>
                                                    <td align="left">Sanction Order of Government of India for Establishment of Textile Parks Under SITP Guidelines as well as MSME Cluster Development Incentive</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuGovtSanctionOrderSITP" runat="server" />
                                                        <asp:Button ID="btnGovtSanctionOrderSITP" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnGovtSanctionOrderSITP_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyGovtSanctionOrderSITP" runat="server" Target="_blank"></asp:HyperLink>
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
