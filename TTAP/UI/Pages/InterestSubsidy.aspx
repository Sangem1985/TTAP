<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="InterestSubsidy.aspx.cs" Inherits="TTAP.UI.Pages.InterestSubsidy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>

    <style>
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        .tags {
            display: inline;
            position: relative;
        }

            .tags:hover:after {
                background: #333;
                background: rgba(0, 0, 0, .8);
                border-radius: 5px;
                bottom: -34px;
                color: #fff;
                content: attr(title);
                left: 20%;
                padding: 5px 15px;
                position: absolute;
                z-index: 98;
                width: 150px;
            }

            .tags:hover:before {
                border: solid;
                border-color: #333 transparent;
                border-width: 0 6px 6px 6px;
                bottom: -4px;
                content: "";
                left: 50%;
                position: absolute;
                z-index: 99;
            }
    </style>
    <script type="text/javascript">

        function ValidateGSTIN(Obj) {
            if (Obj == null) Obj = window.event.srcElement;
            var gstResult = checksum(Obj.value);
            alert(gstResult);
            if (gstResult == false) {
                Obj.value = "";
                Obj.focus();
                alert("Invalid GST No");
                return false;
            }
        }
        function checksum(g) {
            let a = 65, b = 55, c = 36;
            return Array['from'](g).reduce((i, j, k, g) => {
                p = (p = (j.charCodeAt(0) < a ? parseInt(j) : j.charCodeAt(0) - b) * (k % 2 + 1)) > c ? 1 + (p - c) : p;
                return k < 14 ? i + p : j == ((c = (c - (i % c))) < 10 ? c : String.fromCharCode(c + b));
            }, 0);
        }
        function IsMobileNumber(obj) {
            var mob = /^[1-9]{1}[0-9]{9}$/;
            var txtMobile = obj;
            if (mob.test(txtMobile.value) == false && obj.value != "") {
                obj.value = "";
                alert("Please enter valid mobile number.");
                obj.focus();
                return false;
            }
            return true;
        }
        function inputOnlyDecimals(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 47) {
                return true;
            }
            return false;
        }
        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false && emailField.value != "") {
                emailField.value = "";
                alert('Invalid Email Address');
                return false;
            }
            return true;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Always">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnLoanCertificate" />
            <asp:PostBackTrigger ControlID="btnCertification" />
            <asp:PostBackTrigger ControlID="btnCopyoftheloan" />
            <asp:PostBackTrigger ControlID="btnDocuments" />
            <asp:PostBackTrigger ControlID="btnStatementofactual" />
            <asp:PostBackTrigger ControlID="btnBankCertificateOverdue" />
            <asp:PostBackTrigger ControlID="btnLoanStatement" />
        </Triggers>
        <ContentTemplate>
            <div id="innerpagew">
                <div class="breadcrumb-bg">
                    <ul class="breadcrumb font-medium title5 container" id="innerpagew1">
                        <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                        <li class="breadcrumb-item">Incentive Application</li>
                    </ul>
                </div>
                <div class="container mt-4 pb-4">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget-box">
                                    <div class="widget-title">
                                        <span class="icon">
                                            <i class="icon-info-sign"></i>
                                        </span>
                                        <h5 class="text-blue mb-3 font-SemiBold">Form – IV: Interest Subsidy Details</h5>
                                    </div>
                                    <div class="widget-content nopadding">
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label1" runat="server">TSIPass-UID Number</label>
                                                <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label2" runat="server">Incentive Application Number</label>
                                                <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                            </div>
                                            <div class="col-sm-2 form-group">
                                                <label class="control-label label-required" id="Label3" runat="server">Type of Applicant</label>
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
                                        <div class="row" style="display: none">
                                            <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Term Loan availed with Amount, Date FI/Bank wise</h5>
                                            <div class="row w-100 m-0" id="DivTermLoanavailedwithAmountDetails" runat="server">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Bank Name / Financial Institution</label>
                                                    <asp:DropDownList ID="ddlBankAvail" runat="server" class="form-control"
                                                        AutoPostBack="True" TabIndex="2">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Branch</label>
                                                    <asp:TextBox ID="txtTLABranch" runat="server" class="form-control"
                                                        TabIndex="3"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">IFS Code</label>
                                                    <asp:TextBox ID="txtTLAIFSCode" runat="server" class="form-control"
                                                        TabIndex="3"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Loan A/C No.</label>
                                                    <asp:TextBox ID="txtTLALACNo" runat="server" class="form-control"
                                                        TabIndex="3"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Sanction Order No</label>
                                                    <asp:TextBox ID="txtTLASONo" runat="server" class="form-control"
                                                        TabIndex="3"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Sanction Order Date</label>
                                                    <asp:TextBox ID="txtTLASODate" runat="server" class="form-control"
                                                        TabIndex="3"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Amount Sanctioned (Rs.)</label>
                                                    <asp:TextBox ID="txtTLASAmount" runat="server" class="form-control"
                                                        MaxLength="10" onkeypress="return inputOnlyDecimals(event)" TabIndex="3"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Release Date</label>
                                                    <asp:TextBox ID="txtTLAReleasedDate" runat="server" class="form-control"
                                                        TabIndex="3"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button Text="Add" CssClass="btn btn-blue px-4 title5" ID="btnAddBankDetails" runat="server" OnClick="btnAddBankDetails_Click" />
                                                </div>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView runat="server" ID="grdTermLoanAvailed" AutoGenerateColumns="False" CellPadding="4"
                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 alternet-table w-100 NewEnterprise" CellSpacing="4" OnRowCommand="grdTermLoanAvailed_RowCommand">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No" ItemStyle-Width="6%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbla" Text='<%#Eval("BankName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Branch Name" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblb" Text='<%#Eval("BranchName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IFS Code" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblc" Text='<%#Eval("IFSCode") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Loan Account No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbld" Text='<%#Eval("LoanAccNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sanction Order No" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lble" Text='<%#Eval("SanctionOrderNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sanction Order Date" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblf" Text='<%#Eval("SanctionOrderDate") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblg" Text='<%#Eval("SanctionedAmount") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Released Date" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblh" Text='<%#Eval("ReleasedDate") %>' runat="server" />
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
                                                        <asp:TemplateField HeaderText="ISId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblISId" Text='<%#Eval("ISId") %>' runat="server" />
                                                                <asp:Label ID="lblBankId" Text='<%#Eval("BankId") %>' runat="server" />
                                                                <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Term Loan availed with Amount, Date FI/Bank wise</h5>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="GVTermLoandtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No </br>(1)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Term Loan </br>(2)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAvailedTermLoan" runat="server" Text='<%# Bind("AvailedTermLoan") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date of Application for Term Loan </br>(3)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanApplDate" runat="server" Text='<%# Bind("TermLoanApplDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="InstitutionName </br>(4)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInstitutionName" runat="server" Text='<%# Bind("BankName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TermLoanSancRefNo </br>(5)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanSancRefNo" runat="server" Text='<%# Bind("TermLoanSancRefNo") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TermloanSandate </br>(5)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermloanSandate" runat="server" Text='<%# Bind("TermloanSandate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sanctioned Amount </br>(6)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSanctionedAmount" runat="server" Text='<%# Bind("SanctionedAmount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Term Loan Account No. </br>(7)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSanctionedAmount" runat="server" Text='<%# Bind("SanctionedAmount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TermLoan First Release Date </br>(8)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanReleaseddate" runat="server" Text='<%# Bind("TermLoanReleaseddate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TermLoan First Release Amount </br>(9)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanReleaseddate" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No.Of Installments </br>(10)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanInstallments" runat="server" Text='<%# Bind("Installments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Rate Of Interest (%) </br>(11)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRateOfInterest" runat="server" Text='<%# Bind("RateOfInterest") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TermLoan Period From Date </br>(12)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanPeriodFromDate" runat="server" Text='<%# Bind("TermLoanPeriodFromDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TermLoan Period To Date </br>(13)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanPeriodToDate" runat="server" Text='<%# Bind("TermLoanPeriodToDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInstitutionNameid" runat="server" Visible="false" Text='<%# Bind("InstitutionName") %>'></asp:Label>
                                                                <asp:Label ID="lblTermLoanId" runat="server" Text='<%# Bind("TermLoanId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Current Claim Period</h6>
                                            <div class="row w-100 m-0" id="DivCurrentClaimPeriod" runat="server">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label" id="Label6" runat="server">Financial Year</label>
                                                    <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label" id="Label16" runat="server">1st/2nd half Year</label>
                                                    <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" OnSelectedIndexChanged="ddlFin1stOr2ndHalfyear_SelectedIndexChanged" AutoPostBack="true" runat="server" class="form-control txtbox">
                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group" runat="server" visible="false">
                                                    <label class="control-label" id="Label15" runat="server">Amount(In Rupees)</label>
                                                    <asp:TextBox ID="txtAmountPaid" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button ID="btnInterestSubsidyPeriodAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                        TabIndex="5" Text="Add New" OnClick="btnInterestSubsidyPeriodAdd_Click" />
                                                    <asp:Button ID="Button3" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                        TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="GvInterestSubsidyPeriod" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    AutoGenerateColumns="false" OnRowCommand="GvInterestSubsidyPeriod_RowCommand">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S No. </br>(1)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Financial Year </br>(2)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFinancialYear" runat="server" Text='<%#Eval("FinancialYearText") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="1st/2nd half Year </br>(3)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblISFinancialYearID" runat="server" Visible="false" Text='<%# Bind("FinancialYear") %>'></asp:Label>
                                                                <asp:Label ID="lblTypeOfFinancialYear" runat="server" Visible="false" Text='<%# Bind("TypeOfFinancialYear") %>'></asp:Label>
                                                                <asp:Label ID="lblISClaimPeriod_ID" runat="server" Text='<%# Bind("ISClaimPeriod_ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Term loan repaid (Financial year-wise) FI/Bank wise - Current Claim Period</h5>
                                            <div class="row w-100 m-0" id="DivTermloanrepaidDetails" runat="server">
                                                <div class="col-sm-4 form-group" runat="server" visible="false">
                                                    <label class="control-label label-required">Year</label>
                                                    <%-- <asp:TextBox ID="txtTLRFInYear" runat="server" class="form-control"></asp:TextBox>--%>
                                                    <asp:DropDownList ID="lblFinYearRepaid" runat="server" class="form-control txtbox">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group" runat="server" visible="false">
                                                    <label class="control-label" id="Label18" runat="server">1st/2nd half Year</label>
                                                    <asp:DropDownList ID="ddlhalfYearRepaid" onchange="return ChangeHalfYear();" runat="server" class="form-control txtbox">
                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group" runat="server">
                                                    <label class="control-label" id="Label19" runat="server">Term Loan</label>
                                                    <asp:DropDownList ID="ddlTermLoan" runat="server" class="form-control txtbox">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Bank Name / Financial Institution</label>
                                                    <asp:DropDownList ID="ddlBankrepaid" runat="server" AutoPostBack="true" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                 <div class="col-sm-4 form-group" id="divSingleAccount" runat="server" visible="false">
                                                    <label class="control-label label-required">No of Accounts</label>
                                                    <asp:DropDownList ID="ddlAccountsNo" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountsNo_SelectedIndexChanged" runat="server">
                                                        <asp:ListItem Selected="True" Value="1">Single Account</asp:ListItem>
                                                        <asp:ListItem Value="2">Multiple Accounts</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Account Number</label>
                                                    <asp:TextBox ID="txtAccountNo" runat="server" class="form-control" MaxLength="30"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Opening Balance at the Start of Half Year</label>
                                                    <asp:TextBox ID="txtOpeningBal" runat="server" onkeypress="return inputOnlyDecimals(event)" class="form-control" MaxLength="30"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Closing Balance at the End of Half Year</label>
                                                    <asp:TextBox ID="txtClosingBal" onpaste="return false" ondrop="return false" runat="server" onkeypress="return inputOnlyDecimals(event)" class="form-control" MaxLength="30"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Principal Amount Repaid for the Period(Rs.)</label>
                                                    <asp:TextBox ID="txtPrincipal" onpaste="return false" ondrop="return false" runat="server" onkeypress="return inputOnlyDecimals(event)" class="form-control" MaxLength="30"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Rate Of Interest (%)</label>
                                                    <asp:TextBox ID="txtRateofInterest" onpaste="return false" ondrop="return false" runat="server" onkeypress="return inputOnlyDecimals(event)" class="form-control"
                                                        TabIndex="4"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Interest Amount Paid for the Period(Rs.)</label>
                                                    <asp:TextBox ID="txtInterest" runat="server" onpaste="return false" ondrop="return false" onkeypress="return inputOnlyDecimals(event)" class="form-control"
                                                        TabIndex="4"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Date of Payment</label>
                                                    <asp:TextBox ID="txtDOP" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button Text="Add" CssClass="btn btn-blue px-4 title5" ID="btnRepaymentAdd" runat="server" OnClick="btnRepaymentAdd_Click" />
                                                </div>

                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView runat="server" ID="grdTermLoanRepaid" AutoGenerateColumns="False" CellPadding="4"
                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 alternet-table w-100 NewEnterprise" CellSpacing="4" OnRowCommand="grdTermLoanRepaid_RowCommand">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No </br>(1)" ItemStyle-Width="6%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Term Loan </br>(2)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanNo" Text='<%#Eval("TermLoanNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank Name </br>(3)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Loan Account Number </br>(4)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLoanAccountNumber" Text='<%#Eval("AccountNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Opening Balance at the Starting of Half Year </br>(5)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBalanceattheStarting" Text='<%#Eval("OpeningBalanceStartofHalfYear") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Closing Balance at the End of Half Year </br>(6)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBalanceattheEnd" Text='<%#Eval("ClosingBalanceEndofHalfYear") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Principal Amount Repaid for the Period</br>(7)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPrincipalAmt" Text='<%#Eval("PrincipalAmt") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Rate of Interest (%) </br>(8)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRateOfInterest" Text='<%#Eval("RateOfInterest") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Interest Amount Paid for the Period </br>(9)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInterestAmt" Text='<%#Eval("InterestAmt") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Payment Date </br>(10)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaymentDate" Text='<%#Eval("PaymentDate") %>' runat="server" />
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
                                                        <asp:TemplateField HeaderText="TLRId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTLRId" Text='<%#Eval("TLRId") %>' runat="server" />
                                                                <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                <asp:Label ID="lblbankidrp" Text='<%#Eval("BankId") %>' runat="server" />
                                                                <asp:Label ID="lblISRepaidFinancialYearID" runat="server" Visible="false" Text='<%# Bind("FinYear") %>'></asp:Label>
                                                                <asp:Label ID="lblRepaidTypeOfFinancialYear" runat="server" Visible="false" Text='<%# Bind("HalfFinYear") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="row">
                                            <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Month wise & Bank wise Details of Current Claim Period</h6>
                                            <div class="row w-100 m-0" id="DivAdditionalinformation" visible="false" runat="server">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label22" runat="server">Term Loan</label>
                                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" ReadOnly="true">TermLoan1</asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label4" runat="server">Month</label>
                                                    <asp:DropDownList ID="ddlMonthTL1" runat="server" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">Bank Name / Financial Institution</label>
                                                    <asp:DropDownList ID="ddlBankTL" runat="server" AutoPostBack="true" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label20" runat="server">Account Number</label>
                                                    <asp:TextBox ID="txtAcNo" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label8" runat="server">T.L. Amount/ O.B(In Rupees)</label>
                                                    <asp:TextBox ID="txtTearmLoanAmount" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label9" runat="server">Installment No</label>
                                                    <asp:TextBox ID="txtNoOfInstallments" onpaste="return false" ondrop="return false" class="form-control" onkeypress="return inputOnlyNumbers(event)" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label10" runat="server">Rate of Interest for the Month(%)</label>
                                                    <asp:TextBox ID="txtRateofInterestAmountDue" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group" runat="server" visible="false">
                                                    <label class="control-label" id="Label11" runat="server">Interest Due (In Rupees)</label>
                                                    <asp:TextBox ID="txtInterestDue" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label5" runat="server">Interest Paid (In Rupees)</label>
                                                    <asp:TextBox ID="txtInterstPaid" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group" runat="server" visible="false">
                                                    <label class="control-label" id="Label13" runat="server">Unit Holder Contribution (In Rupees)</label>
                                                    <asp:TextBox ID="txtUnitHolderContribution" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label21" runat="server">Closing Balance (InRupees)</label>
                                                    <asp:TextBox ID="txtClosingBalance" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label14" runat="server">Eligible Rate of Interest</label>
                                                    <asp:TextBox ID="txtEligibleRateInterest" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label17" runat="server">Eligible Interest Amount</label>
                                                    <asp:TextBox ID="txtEligibleInterest" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button ID="btnadditionalInformationAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                        TabIndex="5" Text="Add New" OnClick="btnadditionalInformationAdd_Click" />
                                                    <asp:Button ID="btnadditionalInformationClear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                        TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                                </div>
                                                <div runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                    <asp:GridView ID="gvAdditionalInformation" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                        AutoGenerateColumns="false" ShowFooter="true" OnRowCommand="gvAdditionalInformation_RowCommand" OnRowDataBound="gvAdditionalInformation_RowDataBound">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Term Loan">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTermLoan" runat="server" Text='<%#Eval("TermLoan") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Month">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("TLMonthName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bank Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBank" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Account Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAccountNo" runat="server" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="T.L. Amount/ O.B (In Rupees)">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTearmLoanAmount" runat="server" Text='<%#Eval("TearmLoanAmount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Installment No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInstallmentNo" runat="server" Text='<%#Eval("InstallmentNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rate of interest (%) for the Month">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRateofInterestAmountDue" runat="server" Text='<%#Eval("RateofInterestAmountDue") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Interest Paid">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInterestPaid" runat="server" Text='<%#Eval("InterestPaid") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Closing Balance">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblClosingBal" runat="server" Text='<%#Eval("ClosingBalance") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Eligible rate of interest">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEligibleRateInterest" runat="server" Text='<%#Eval("EligibleRateInterest") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Eligible interest">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEligibleInterest" runat="server" Text='<%#Eval("EligibleInterest") %>'></asp:Label>
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
                                                            <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBankId" runat="server" Visible="false" Text='<%# Bind("BankId") %>'></asp:Label>
                                                                    <asp:Label ID="lblMonthId" runat="server" Visible="false" Text='<%# Bind("Months") %>'></asp:Label>
                                                                    <asp:Label ID="lblAdditionalinformationId" runat="server" Text='<%# Bind("AdditionalinformationId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div class="row w-100 m-0" id="DivTerm2" visible="false" runat="server">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label23" runat="server">Term Loan</label>
                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" ReadOnly="true">TermLoan2</asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label24" runat="server">Month</label>
                                                    <asp:DropDownList ID="ddlMonthTL2" runat="server" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">Bank Name / Financial Institution</label>
                                                    <asp:DropDownList ID="ddlBankTL2" runat="server" AutoPostBack="true" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label25" runat="server">Account Number</label>
                                                    <asp:TextBox ID="txtAcNo2" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label26" runat="server">T.L. Amount/ O.B(In Rupees)</label>
                                                    <asp:TextBox ID="txtTearmLoanAmount2" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label27" runat="server">Installment No</label>
                                                    <asp:TextBox ID="txtNoOfInstallments2" onpaste="return false" ondrop="return false" class="form-control" onkeypress="return inputOnlyNumbers(event)" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label28" runat="server">Rate of Interest for the Month(%)</label>
                                                    <asp:TextBox ID="txtRateofInterestAmountDue2" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group" runat="server" visible="false">
                                                    <label class="control-label" id="Label31" runat="server">Interest Due (In Rupees)</label>
                                                    <asp:TextBox ID="txtInterestDue2" class="form-control" onpaste="return false" ondrop="return false" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label32" runat="server">Interest Paid (In Rupees)</label>
                                                    <asp:TextBox ID="txtInterstPaid2" class="form-control" onpaste="return false" ondrop="return false" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group" runat="server" visible="false">
                                                    <label class="control-label" id="Label33" runat="server">Unit Holder Contribution (In Rupees)</label>
                                                    <asp:TextBox ID="txtUnitHolderContribution2" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label34" runat="server">Closing Balance (InRupees)</label>
                                                    <asp:TextBox ID="txtClosingBalance2" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label35" runat="server">Eligible Rate of Interest</label>
                                                    <asp:TextBox ID="txtEligibleRateInterest2" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label36" runat="server">Eligible Interest Amount</label>
                                                    <asp:TextBox ID="txtEligibleInterest2" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button ID="btnadditionalInformationAdd2" runat="server" CssClass="btn btn-blue mx-2"
                                                        TabIndex="5" Text="Add New" OnClick="btnadditionalInformationAdd2_Click" />
                                                    <asp:Button ID="Button4" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                        TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                                </div>
                                                <div runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                    <asp:GridView ID="gvAdditionalInformation2" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                        AutoGenerateColumns="false" ShowFooter="true" OnRowCommand="gvAdditionalInformation2_RowCommand" OnRowDataBound="gvAdditionalInformation2_RowDataBound">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Term Loan">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTermLoan" runat="server" Text='<%#Eval("TermLoan") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Month">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("TLMonthName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bank Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBank" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Account Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAccountNo" runat="server" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="T.L. Amount/ O.B (In Rupees)">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTearmLoanAmount" runat="server" Text='<%#Eval("TearmLoanAmount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Installment No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInstallmentNo" runat="server" Text='<%#Eval("InstallmentNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rate of interest (%) for the Month">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRateofInterestAmountDue" runat="server" Text='<%#Eval("RateofInterestAmountDue") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Interest Paid">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInterestPaid" runat="server" Text='<%#Eval("InterestPaid") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Closing Balance">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblClosingBal" runat="server" Text='<%#Eval("ClosingBalance") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Eligible rate of interest">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEligibleRateInterest" runat="server" Text='<%#Eval("EligibleRateInterest") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Eligible interest">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEligibleInterest" runat="server" Text='<%#Eval("EligibleInterest") %>'></asp:Label>
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
                                                            <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBankId" runat="server" Visible="false" Text='<%# Bind("BankId") %>'></asp:Label>
                                                                    <asp:Label ID="lblMonthId" runat="server" Visible="false" Text='<%# Bind("Months") %>'></asp:Label>
                                                                    <asp:Label ID="lblAdditionalinformationId" runat="server" Text='<%# Bind("AdditionalinformationId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                            <div class="row w-100 m-0" id="DivTerm3" visible="false" runat="server">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label37" runat="server">Term Loan</label>
                                                    <asp:TextBox ID="TextBox13" runat="server" class="form-control" ReadOnly="true">TermLoan3</asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label38" runat="server">Month</label>
                                                    <asp:DropDownList ID="ddlMonthTL3" runat="server" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">Bank Name / Financial Institution</label>
                                                    <asp:DropDownList ID="ddlBankTL3" runat="server" AutoPostBack="true" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label39" runat="server">Account Number</label>
                                                    <asp:TextBox ID="txtAcNo3" class="form-control" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label40" runat="server">T.L. Amount/ O.B(In Rupees)</label>
                                                    <asp:TextBox ID="txtTearmLoanAmount3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label41" runat="server">Installment No</label>
                                                    <asp:TextBox ID="txtNoOfInstallments3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="return inputOnlyNumbers(event)" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label42" runat="server">Rate of Interest for the Month(%)</label>
                                                    <asp:TextBox ID="txtRateofInterestAmountDue3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group" runat="server" visible="false">
                                                    <label class="control-label" id="Label43" runat="server">Interest Due (In Rupees)</label>
                                                    <asp:TextBox ID="txtInterestDue3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label44" runat="server">Interest Paid (In Rupees)</label>
                                                    <asp:TextBox ID="txtInterstPaid3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group" runat="server" visible="false">
                                                    <label class="control-label" id="Label45" runat="server">Unit Holder Contribution (In Rupees)</label>
                                                    <asp:TextBox ID="txtUnitHolderContribution3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label46" runat="server">Closing Balance (InRupees)</label>
                                                    <asp:TextBox ID="txtClosingBalance3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label47" runat="server">Eligible Rate of Interest</label>
                                                    <asp:TextBox ID="txtEligibleRateInterest3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label48" runat="server">Eligible Interest Amount</label>
                                                    <asp:TextBox ID="txtEligibleInterest3" onpaste="return false" ondrop="return false" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button ID="btnadditionalInformationAdd3" runat="server" CssClass="btn btn-blue mx-2"
                                                        TabIndex="5" Text="Add New" OnClick="btnadditionalInformationAdd3_Click" />
                                                    <asp:Button ID="Button6" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                        TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                                </div>
                                                <div runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                    <asp:GridView ID="gvAdditionalInformation3" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                        AutoGenerateColumns="false" OnRowCommand="gvAdditionalInformation3_RowCommand" ShowFooter="true" OnRowDataBound="gvAdditionalInformation3_RowDataBound">
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Term Loan">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTermLoan" runat="server" Text='<%#Eval("TermLoan") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Month">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("TLMonthName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bank Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBank" runat="server" Text='<%#Eval("BankName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Account Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAccountNo" runat="server" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="T.L. Amount/ O.B (In Rupees)">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTearmLoanAmount" runat="server" Text='<%#Eval("TearmLoanAmount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Installment No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInstallmentNo" runat="server" Text='<%#Eval("InstallmentNo") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Rate of interest (%) for the Month">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRateofInterestAmountDue" runat="server" Text='<%#Eval("RateofInterestAmountDue") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Interest Paid">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInterestPaid" runat="server" Text='<%#Eval("InterestPaid") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Closing Balance">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblClosingBal" runat="server" Text='<%#Eval("ClosingBalance") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Eligible rate of interest">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEligibleRateInterest" runat="server" Text='<%#Eval("EligibleRateInterest") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Eligible interest">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEligibleInterest" runat="server" Text='<%#Eval("EligibleInterest") %>'></asp:Label>
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
                                                            <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBankId" runat="server" Visible="false" Text='<%# Bind("BankId") %>'></asp:Label>
                                                                    <asp:Label ID="lblMonthId" runat="server" Visible="false" Text='<%# Bind("Months") %>'></asp:Label>
                                                                    <asp:Label ID="lblAdditionalinformationId" runat="server" Text='<%# Bind("AdditionalinformationId") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>

                                        </div>
                                         <div class="row">
                                            <div class="col-sm-8 text-left form-group">
                                                <label class="control-label" style="font-weight: bold">
                                                    Current Total Claim Amount (Rs).<br />
                                                </label>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <asp:Label ID="txtCCA" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-sm-12 py-4">
                                            <b>Note : </b>Current Claim Amount (75% of the interest rate applicable on the loans with a cap of 8% per annum).
                                        </div>

                                        <div class="row">
                                            <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Total Loan Amount Repaid</h5>
                                            <div class="row w-100 m-0" id="DivTotalLoanAmountRepaid" runat="server">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Bank Name / Financial Institution</label>
                                                    <asp:DropDownList ID="ddlbankTotalrepaid" runat="server" AutoPostBack="true" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="label-required">Total No of Installments</label>
                                                    <asp:TextBox ID="txtInstallments" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                        MaxLength="40" onpaste="return false" ondrop="return false" TabIndex="5"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Installment Amount (Rs.)</label>
                                                    <asp:TextBox ID="txtInstallmentAmount" onpaste="return false" ondrop="return false" runat="server" onkeypress="return inputOnlyDecimals(event)" class="form-control" MaxLength="30"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Total Amount Repaid (Interest + Principal) (Rs.)</label>
                                                    <asp:TextBox ID="txtTotalAmountRepaid" onpaste="return false" ondrop="return false" runat="server" onkeypress="return inputOnlyDecimals(event)" class="form-control"
                                                        TabIndex="4"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button Text="Add" CssClass="btn btn-blue px-4 title5" ID="btnTotalLoanAmountRepayment" runat="server" OnClick="btnTotalLoanAmountRepayment_Click" />
                                                </div>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView runat="server" ID="grdTotalTermLoanRepaid" AutoGenerateColumns="False" CellPadding="4"
                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 alternet-table w-100 NewEnterprise" CellSpacing="4" OnRowCommand="grdTotalTermLoanRepaid_RowCommand">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No </br>(1)" ItemStyle-Width="6%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank Name </br>(2)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total No.Of Installments </br>(3)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTermLoanInstallments" runat="server" Text='<%# Bind("TotalNoofInstallments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Installment Amount (Rs.) </br>(4)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInstallmentAmount" Text='<%#Eval("InstallmentAmount") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Amount Repaid (Interest + Principal) (Rs.) </br>(5)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalAmountRepaid" Text='<%#Eval("TotalAmountRepaid") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit </br>(6)">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete </br>(7)">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TLRId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTTLRId" Text='<%#Eval("TTLRId") %>' runat="server" />
                                                                <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                <asp:Label ID="lblbankidrp" Text='<%#Eval("BankId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Interest Subsidy sanctioned / availed so far with sanction order no & date, if any from Govt. of India or any other Agency</h6>
                                             <div class="col-sm-4 form-group">
                                                <asp:RadioButtonList runat="server" OnSelectedIndexChanged="rbtnOtherAgency_SelectedIndexChanged" AutoPostBack="true" ID="rbtnOtherAgency" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="row w-100 m-0" runat="server" id="divOtherAgency">
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
                                        </div>
                                        <div class="row" id="divMoratorium" runat="server">
                                            <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Moratorium Period for RePayment of Loan</h6>
                                            <div class="col-sm-4 form-group">
                                                <asp:RadioButtonList runat="server" OnSelectedIndexChanged="rbtnMoratoriumYesNo_SelectedIndexChanged" AutoPostBack="true" ID="rbtnMoratoriumYesNo" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="2">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="row w-100 m-0" id="DivMoratoriumPeriod" runat="server">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">First/Second Half Year</label>
                                                    <asp:DropDownList ID="ddlCCPType" runat="server" class="form-control"
                                                        AutoPostBack="True" TabIndex="2">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="1">First Half year</asp:ListItem>
                                                        <asp:ListItem Value="2">Second Half year</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">From</label>
                                                    <asp:TextBox ID="txtCCPFrom" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">To</label>
                                                    <asp:TextBox ID="txtCCPTo" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Bank Name / Financial Institution</label>
                                                    <asp:DropDownList ID="ddlMoratoriumBank" runat="server" AutoPostBack="true" class="form-control"
                                                        TabIndex="4" Visible="true">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required">Rate Of Interest (%)</label>
                                                    <asp:TextBox ID="txtMoratoriumRateOfInterest" runat="server" onkeypress="return inputOnlyDecimals(event)" class="form-control"
                                                        TabIndex="4"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-12 text-center">
                                                    <asp:Button ID="btnMoratoriumPeriodAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                        TabIndex="5" Text="Add New" OnClick="btnMoratoriumPeriodAdd_Click" />
                                                    <asp:Button ID="btnMoratoriumPeriodClear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                        TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                                </div>
                                                <div class="col-sm-12 text-left">
                                                    <p>
                                                        <strong>Note : </strong>1) 1st Half Year: April 1st to September 30th
                                                        <br />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2). 2nd Half Year: October 1st to March 31st
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="GvMoratoriumPeriod" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    AutoGenerateColumns="false" OnRowCommand="GvMoratoriumPeriod_RowCommand">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S No. </br>(1)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="1st/2nd half Year </br>(2)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="From Date </br>(3)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("FromDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="To Date </br>(4)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblToDate" runat="server" Text='<%#Eval("ToDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank Name </br>(5)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Rate Of Interest (%) </br>(6)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMoratoriumRateOfInterest" runat="server" Text='<%# Bind("RateOfInterest") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit </br>(7)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete </br>(8)" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTypeOfFinancialYear" runat="server" Visible="false" Text='<%# Bind("TypeOfFinancialYear") %>'></asp:Label>
                                                                <asp:Label ID="lblMoratoriumPeriod_ID" runat="server" Text='<%# Bind("MoratoriumPeriod_ID") %>'></asp:Label>
                                                                <asp:Label ID="lblbankidrp" Text='<%#Eval("BankId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
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
                                                        <td align="left" style="width: 50%">Loan Certificate from Bank / FI stating Loan details in the prescribed format</td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuLoanCertificate" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                          <asp:Button ID="btnLoanCertificate" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnLoanCertificate_Click" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:HyperLink ID="hyLoanCertificate" runat="server" Text="View" CssClass="LBLBLACK" Visible="false" Target="_blank"></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item2">
                                                        <td align="center">2</td>
                                                        <td align="left">Certification from the Bank / FI indicating that Interest Obligations are met on time as per agreed terms in the prescribed format.</td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuCertification" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnCertification" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnCertification_Click" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:HyperLink ID="hyCertification" runat="server" Text="View" CssClass="LBLBLACK" Visible="false" Target="_blank"></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item2">
                                                        <td align="center">3</td>
                                                        <td align="left">Copy of the loan appraisal report of the concerned bank/ financial institution</label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuCopyoftheloan" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                           <asp:Button ID="btnCopyoftheloan" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnCopyoftheloan_Click" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:HyperLink ID="hyCopyoftheloan" runat="server" Text="View" CssClass="LBLBLACK" Visible="false" Target="_blank"></asp:HyperLink>

                                                        </td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item2">
                                                        <td align="center">4</td>
                                                        <td align="left">Documents in support of interest subsidy availed if any from Govt. of India under TUF scheme or any other scheme
                                                        </td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuDocuments" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                    <asp:Button ID="btnDocuments" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnDocuments_Click" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:HyperLink ID="hyDocuments" runat="server" Text="View" CssClass="LBLBLACK" Visible="false" Target="_blank"></asp:HyperLink>

                                                        </td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item2">
                                                        <td align="center">5</td>
                                                        <td align="left">Statement of actual interest paid to the bank/financial institutions/NBFC during the period of claim, Certified by the Bank.</label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuStatementofactual" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                            <asp:Button ID="btnStatementofactual" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnStatementofactual_Click" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:HyperLink ID="hyStatementofactual" runat="server" Text="View" CssClass="LBLBLACK" Visible="false" Target="_blank"></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item2">
                                                        <td align="center">6</td>
                                                        <td align="left">Bank Certificate in case of Overdue/NPA, certifying that the repayment is regular and account is standard.</label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuBankCertificateOverdue" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                             <asp:Button ID="btnBankCertificateOverdue" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnBankCertificateOverdue_Click" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:HyperLink ID="hyBankCertificateOverdue" runat="server" Text="View" CssClass="LBLBLACK" Visible="false" Target="_blank"></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item2">
                                                        <td align="center">7</td>
                                                        <td align="left">Loan Statement for the claim period certified by the banker.</label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuLoanStatement" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                             <asp:Button ID="btnLoanStatement" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnLoanStatement_Click" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:HyperLink ID="hyLoanStatement" runat="server" Text="View" CssClass="LBLBLACK" Visible="false" Target="_blank"></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
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
                                <asp:Button Text="Previous" CssClass="btn btn-blue px-4 title5" ID="BtnPrevious" runat="server" OnClick="BtnPrevious_Click" />
                                <asp:Button Text="Save & Next" CssClass="btn btn-blue px-4 title5" ID="btnISNext" runat="server" OnClick="btnISNext_Click" />
                            </div>

                            <div class="row">
                                <div class="col-sm-4 text-right">
                                </div>
                            </div>

                            <%-- <div class="row">
                                                <div class="col-sm-4 text-right">
                                                   
                                                </div>
                                                <div class="col-sm-4 text-center">
                                                  
                                                </div>
                                                 <div class="col-sm-4 text-left">
                                                    <asp:Button Text="Next" CssClass="btn btn-blue px-4 title5" ID="btnNext" runat="server" OnClick="BtnNext_Click" />
                                                </div>
                                            </div>--%>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <asp:HiddenField ID="hdnHalfYear" runat="server" />
            </div>
            <table style="width: 100%">
                <tr>
                    <td style="width: 100%">
                        <table style="width: 100%">
                            <tr>
                                <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div>
                            <h1 class="page-subhead-line">
                                <asp:HiddenField ID="hdnfldtsiic" runat="server" />
                            </h1>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:HiddenField ID="hdnTerm1Amount" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnTerm2Amount" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnTerm3Amount" Value="0" runat="server" />
                        <asp:HiddenField ID="hdnTermloan1Active"  runat="server" />
                        <asp:HiddenField ID="hdnTermloan2Active"  runat="server" />
                        <asp:HiddenField ID="hdnTermloan3Active"  runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" />
                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="child" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="group1" />
                    </td>
                </tr>
            </table>
            <%--<table>
                <tr>
                    <td style="font-weight: bold">Instructions to the applicant :
                    </td>
                </tr>
                <tr>
                    <td>Fields marked by asterisk (<span class="label-required"></span>) are mandatory
                    </td>
                </tr>
            </table>--%>
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

        var IdHalf1 = ["1", "2", "3", "4", "5", "6"];
        var IdHalf2 = ["7", "8", "9", "10", "11", "12"];

        var Half1 = ["April", "May", "June", "July", "August", "September"];
        var Half2 = ["October", "November", "December", "January", "Febreaury", "March"];

        function ChangeHalfYear11() {
            if ($('#ContentPlaceHolder1_ddlFin1stOr2ndHalfyear').val() == "1") {
                $('#ContentPlaceHolder1_txtMonth1').val('April');
                $('#ContentPlaceHolder1_txtMonth2').val('May');
                $('#ContentPlaceHolder1_txtMonth3').val('June');
                $('#ContentPlaceHolder1_txtMonth4').val('July');
                $('#ContentPlaceHolder1_txtMonth5').val('August');
                $('#ContentPlaceHolder1_txtMonth6').val('September');
            }
            else {
                $('#ContentPlaceHolder1_txtMonth1').val('October');
                $('#ContentPlaceHolder1_txtMonth2').val('November');
                $('#ContentPlaceHolder1_txtMonth3').val('December');
                $('#ContentPlaceHolder1_txtMonth4').val('January');
                $('#ContentPlaceHolder1_txtMonth5').val('February');
                $('#ContentPlaceHolder1_txtMonth6').val('March');
            }
        }


        function ChangeHalfYear() {

            $('#ContentPlaceHolder1_ddlMonthTL1').empty();
            $('#ContentPlaceHolder1_ddlMonthTL2').empty();
            $('#ContentPlaceHolder1_ddlMonthTL3').empty();


            $('#ContentPlaceHolder1_ddlMonthTL1').append($("<option></option>").val("0").html("--Select--"));
            $('#ContentPlaceHolder1_ddlMonthTL2').append($("<option></option>").val("0").html("--Select--"));
            $('#ContentPlaceHolder1_ddlMonthTL3').append($("<option></option>").val("0").html("--Select--"));

            var option = "";
            if ($('#ContentPlaceHolder1_ddlFin1stOr2ndHalfyear').val() == "1") {
                for (var i = 0; i < Half1.length; i++) {
                    option += '<option value="' + IdHalf1[i] + '">' + Half1[i] + "</option>"
                }
            }
            if ($('#ContentPlaceHolder1_ddlFin1stOr2ndHalfyear').val() == "2") {
                for (var i = 0; i < Half1.length; i++) {
                    option += '<option value="' + IdHalf2[i] + '">' + Half2[i] + "</option>"
                }
            }
            $("#ContentPlaceHolder1_ddlMonthTL1").append(option);
            $("#ContentPlaceHolder1_ddlMonthTL2").append(option);
            $("#ContentPlaceHolder1_ddlMonthTL3").append(option);


        }

        function ddlHover(res) {
            var Id = res.id;
            var Data = $("#" + Id).find(":selected").text();
            $("#" + Id).attr('title', Data);
            $("#" + Id).addClass("tags")
        }

        $("input[id$='ContentPlaceHolder1_txtTLASODate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtTLAReleasedDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtDOP']").keydown(function () {
            return false;
        });

        $("input[id$='ContentPlaceHolder1_txtCCPFrom']").keydown(function () {
            return false;
        });


        $("input[id$='ContentPlaceHolder1_txtCCPTo']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtDateAvailed']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtAmountDueDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');

            $("input[id$='ContentPlaceHolder1_txtAmountDueDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='ContentPlaceHolder1_txtTLASODate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtTLAReleasedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='ContentPlaceHolder1_txtDOP']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtCCPFrom']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtCCPTo']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback   
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

            $("input[id$='ContentPlaceHolder1_txtAmountDueDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='ContentPlaceHolder1_txtTLASODate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtTLAReleasedDate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='ContentPlaceHolder1_txtDOP']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback   



            $("input[id$='ContentPlaceHolder1_txtCCPFrom']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback   
            $("input[id$='ContentPlaceHolder1_txtCCPTo']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                })
            $("input[id$='ContentPlaceHolder1_txtDateAvailed']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });


    </script>




</asp:Content>
