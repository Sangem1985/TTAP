<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmassistancedevelopment.aspx.cs" Inherits="TTAP.UI.Pages.frmassistancedevelopment" %>

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
            <asp:PostBackTrigger ControlID="btnPaymentProof" />
            <asp:PostBackTrigger ControlID="btnWorkerHousing" />
            <asp:PostBackTrigger ControlID="btnCACertificate" />
            <asp:PostBackTrigger ControlID="btnChartedCertificate" />
            <asp:PostBackTrigger ControlID="btnWorkersDetails" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Assistance for Development of Worker Housing / Dormitories</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – XVI : Assistance for Development of Worker Housing / Dormitories</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="lblTSIPassUID" runat="server">TSIPass-UID Number</label>
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
                                            <asp:TextBox ID="txtDateofEstablishmentofUnit" Enabled="false" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Location of the Worker Housing /Dormitory</label>
                                            <asp:TextBox ID="txtWorkerHousingLocation" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblLandpurchased" runat="server">Land purchased (in Sq. Mtrs.)</label>
                                            <asp:TextBox ID="txtLandpurchased" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Plinth Area of the Building for Worker Housing/Dormitory (in Sq. Mtrs.)</label>
                                            <asp:TextBox ID="txtBuildingPlinthArea" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">Area required for the Building for Worker Housing/Dormitory as per the appraisal (in Sq. Mtrs.)</label>
                                            <asp:TextBox ID="txtBuildingAreaRequired" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Labela1" runat="server">Investment in the land used for ( Worker Housing /Dormitory) (Amount in Rupees)</label>
                                            <asp:TextBox ID="txtLandInvestment" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" id="divEarlierYear" runat="server">
                                            <label class="control-label" id="lblyear" runat="server">In case of Land Conversion Charges(In Rs)</label>
                                            <asp:TextBox ID="txtLandConversionCharges" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="divEarlieramount" runat="server">
                                            <label class="control-label" id="lblamountclaimed" runat="server">In case of lands purchased in IE/IDA/IP’s cost of land(In Rs)</label>
                                            <asp:TextBox ID="txtPurchasedLandCost" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblCurrentClaim" runat="server">Total Occupants load for Worker Housing/Dormitory</label>
                                            <asp:TextBox ID="txtHousingOccupantsLoad" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" id="div1" runat="server">
                                            <label class="control-label" id="Label1323" runat="server">Occupancy rate in the Worker Housing /Dormitory (%)</label>
                                            <asp:TextBox ID="txtOccupancyRate" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div2" runat="server">
                                            <label class="control-label" id="Labelwe2" runat="server">Start Date of usage of Workers Quarters</label>
                                            <asp:TextBox ID="txtQuartersStartDate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Labelsd9" runat="server">End Date of usage of Workers Quarters</label>
                                            <asp:TextBox ID="txtQuartersEndDate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-8 form-group">
                                            <label class="control-label" id="Label9" runat="server">Whether the unit is located in the Textile /Apparel Park declared by the Government of Telangana</label>
                                            <asp:RadioButtonList ID="RbtnTextileOrApparelArea" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                         <div class="col-sm-4 form-group" id="div3" runat="server">
                                            <label class="control-label" id="Label1" runat="server">Total land used for worker housing(in acre)</label>
                                            <asp:TextBox ID="txtTotallandusedworker" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" id="div4" runat="server">
                                            <label class="control-label" id="Label2" runat="server">Land purchased rate per acre(In Rs)</label>
                                            <asp:TextBox ID="txtLandpurchasedrateper" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblClaim" runat="server">Current Claim (In Rupees)</label>
                                            <asp:TextBox ID="txtCurrentClaim" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="col-sm-12 mt-sm-3 text-left">
                                        <p><strong>Note : </strong>Current Claim - 60% of the land cost and land conversion charges with an upper limit of Rs 30 lakhs per acre.</p>
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
                                                    <td align="left" style="width: 50%">Registered Land Sale Deed/Lease Deed/Transfer Deed/Land conversion documents</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuDocuments1" runat="server" />
                                                        <asp:Button ID="btnUpload1" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnUpload1_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="lblSaleDeed" runat="server" Target="_blank"></asp:HyperLink></td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Payment proof</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPaymentProof" runat="server" />
                                                        <asp:Button ID="btnPaymentProof" runat="server" OnClick="btnPaymentProof_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyppaymentProof" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>


                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Credentials of the Industry/Enterprise setting up infrastructure Worker Housing / Dormitories
               
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuWorkingHouse" runat="server" />
                                                        <asp:Button ID="btnWorkerHousing" runat="server" OnClick="btnWorkerHousing_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hypWorkerHousing" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Certificate from CA on the investments made by the Applicant towards the Development of Worker (aaa) Housing / Dormitories
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCACertificate" runat="server" />
                                                        <asp:Button ID="btnCACertificate" runat="server" OnClick="btnCACertificate_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hypCACertificate" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">5</td>
                                                    <td align="left">Certificate from Chartered Engineer</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuChartedCertificate" runat="server" />
                                                        <asp:Button ID="btnChartedCertificate" OnClick="btnChartedCertificate_Click" CssClass="btn btn-info btn-sm mx-2" runat="server" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hypChartedCertificate" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">6</td>
                                                    <td align="left">Details of Workers Along With EPF&ESI Payments per Period of One Year Who are Staying in the Worker Housing/Dormitories</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuWorkersDetails" runat="server" />
                                                        <asp:Button ID="btnWorkersDetails" CssClass="btn btn-info btn-sm mx-2" runat="server" Text="Upload" OnClick="btnWorkersDetails_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyWorkersDetails" runat="server" Target="_blank"></asp:HyperLink>
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

        $("input[id$='ContentPlaceHolder1_txtDateofEstablishmentofUnit']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtQuartersStartDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtQuartersEndDate']").keydown(function () {
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
            $("input[id$='ContentPlaceHolder1_txtQuartersStartDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtQuartersEndDate']").datepicker(
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
            $("input[id$='ContentPlaceHolder1_txtQuartersStartDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtQuartersEndDate']").datepicker(
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
