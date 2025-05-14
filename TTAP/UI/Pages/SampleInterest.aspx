<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="SampleInterest.aspx.cs" Inherits="TTAP.UI.Pages.SampleInterest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function isDecimal(event) {
            let char = String.fromCharCode(event.which);
            let regex = /^[0-9.]$/;

            if (!regex.test(char)) {
                return false;
            }
            let input = event.target.value;
            if (char === '.' && input.includes('.')) {
                return false;
            }
            return true;
        }
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Reimbursement of TAX Inspection Report</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-4 frm-form box-content py-4 font-medium title5">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Reimbursement of TAX Inspection Report</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <table runat="server" visible="false">
                                        <tr>
                                            <td>

                                                <asp:TextBox ID="txtIncID" runat="server" TextMode="Number"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_schemetide" class="form-control txtbox" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button runat="server" Text="Search" CssClass="btn-blue" ID="btnsub" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Unit Name</label>
                                            <label class="form-control" id="lblUnitName" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label26" runat="server">Address</label>
                                            <label class="form-control" id="lblAddress" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label27" runat="server">Name of the Proprietor</label>
                                            <label class="form-control" id="lblProprietor" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label28" runat="server">Constitution of Organization</label>
                                            <label class="form-control" id="lblOrganization" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Social Status</label>
                                            <label class="form-control" id="lblSocialStatus" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Share of SC/ST/Women Enterprenuer</label>
                                            <label class="form-control" id="lblShareofSCSTWomenEnterprenue" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label31" runat="server">Registration Number</label>
                                            <label class="form-control" id="lblRegistrationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label3" runat="server">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label19" runat="server">Category of Unit as per Application</label>
                                            <label class="form-control" id="lblCategoryofUnit" runat="server"></label>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label32" runat="server">Type of Sector</label>
                                            <label class="form-control" id="lblTypeofSector" runat="server">Textiles</label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label18" runat="server">Type of Textile as per Application</label>
                                            <label class="form-control" id="lblTypeofTexttile" runat="server"></label>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label33" runat="server">Technical Textile Type</label>
                                            <label class="form-control" id="lblTechnicalTextileType" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Activity of the Unit</label>
                                            <label class="form-control" id="lblActivityoftheUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label2" runat="server">Incentive Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label34" runat="server">Date of Power Connection Release</label>
                                            <label class="form-control" id="lblPowerConnectionReleaseDate" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label7" runat="server">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label6" runat="server">Date of Receipt of Claim Application</label>
                                            <label class="form-control" id="lblReceiptDate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Promoter details in case eligible for additional subsidy</label>
                                            <label class="form-control" id="lblcategory" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row" id="divClaimPeroid" runat="server" visible="false">
                                       <%-- <h5><b>Claim Period Details</b></h5>--%>
                                        <table style="width: 100%">
                                            <tr>
                                                <asp:GridView ID="GvInterestSubsidyPeriod" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false"
                                                    AllowPaging="true" ShowHeaderWhenEmpty="true" ShowFooter="true" EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;" PageSize="50">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                S.No
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                Claim Period
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hf_claimperiodofloanaddIncentiveId" Value='<%# Eval("IncentiveId") %>' runat="server" />
                                                                <asp:HiddenField ID="hf_claimperiodofloanaddFinancialYear" Value='<%# Eval("FinancialYear") %>' runat="server" />
                                                                <asp:HiddenField ID="hf_claimperiodofloanadd_ID" Value='<%# Eval("FinancialYearID") %>' runat="server" />
                                                                <asp:HiddenField ID="hf_Fin1stOr2ndHalfYear" Value='<%# Eval("Fin1stOr2ndHalfYear") %>' runat="server" />
                                                                <asp:Label ID="lbl_claimperiodofloanaddname" Text='<%# Eval("FinancialYearName") %>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                No of Loans Applied for this Claim
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txt_claimperiodofloanaddNumber" runat="server" class="form-control txtbox" Height="28px" onkeypress="DecimalOnly()"
                                                                    TabIndex="10" Width="180px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="gridview"></PagerStyle>
                                                </asp:GridView>
                                            </tr>
                                            <tr>
                                                <asp:Button ID="BtnAdd" runat="server" align="center" OnClick="BtnAdd_Click" CssClass="btn btn-primary"
                                                    Text="Submit to Add More Details" />
                                            </tr>
                                        </table>

                                    </div>
                                    <div class="row" id="div1" runat="server" visible="false">
                                        <table style="width: 100%">
                                            <tr>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row" id="divNewMonth" runat="server">
                                        <table style="width: 100%">
                                            <tr>

                                                <td colspan="4">
                                                    <asp:Repeater ID="rpt_eglibilepallavaddi" runat="server">
                                                        <ItemTemplate>
                                                            <table runat="server" class="table table-small-font table-bordered table-striped">
                                                                <tr>
                                                                    <th>
                                                                        <%# Container.ItemIndex + 1 %> .Claim Period :
                                                                        <asp:Label ID="lbl_FYname" Text='<%# Eval("FinancialYearName") %>' runat="server"></asp:Label>
                                                                        <asp:HiddenField ID="hf_grdeglibilepallavaddiFY_ID" Value='<%# Eval("FinancialYearId") %>' runat="server" />
                                                                    </th>
                                                                    <th style="font-family: Calibri">&nbsp;</th>
                                                                    <th style="font-family: Calibri">Loan -
                                                                    <asp:Label ID="lbl_LoanID" Text='<%# Eval("LoanNumber") %>' runat="server"></asp:Label>
                                                                    </th>
                                                                    <th style="font-family: Calibri"></th>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>Date of Commencement of activity</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txtRptDCP" runat="server" Text='<%# Eval("Dcp") %>'
                                                                            class="form-control txtbox" Height="28px"
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Loan installment start Date</b></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRptLoanInstallmentStartDt" runat="server"
                                                                            class="form-control txtbox" Height="28px" OnTextChanged="txtRptLoanInstallmentStartDt_TextChanged"
                                                                            AutoPostBack="true" TabIndex="10" Width="180px"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>Total Term Loan Availed(In Rs.)</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txtRptTermLoanAvailed" runat="server"
                                                                            class="form-control txtbox" Height="28px"
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b> Period of installment</b></td>
                                                                    <td>
                                                                        <asp:DropDownList ID="ddlRptPeriodOfInstallment" runat="server" class="form-control txtbox" AutoPostBack="true"
                                                                            TabIndex="4" Height="33px" Width="180px" OnSelectedIndexChanged="ddlRptPeriodOfInstallment_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                            <asp:ListItem Value="1">Yearly</asp:ListItem>
                                                                            <asp:ListItem Value="2">Halfyearly</asp:ListItem>
                                                                            <asp:ListItem Value="3">Quartely</asp:ListItem>
                                                                            <asp:ListItem Value="4">Monthly</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>No of installments</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txtRptNoofInstallments" runat="server"
                                                                            class="form-control txtbox" Height="28px"
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b> Installment amount</b></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRptInstallmentAmount" runat="server"
                                                                            class="form-control txtbox" Height="28px"
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>No of installments completed</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txtRptNoofInstallmentsCompleted" runat="server"
                                                                            class="form-control txtbox" Height="28px"
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b> PrincipalAmount become DUE before this HALFYEAR</b></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtRptPrincipalAmountDUE" runat="server"
                                                                            class="form-control txtbox" Height="28px"
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>No of installments completed Months</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:HiddenField ID="txtRptInstallmentsCompletedMonths" runat="server" />
                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true"
                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                        <br />
                                                                    </td>
                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>For Previous Financial Year is Moratorium Applicable</b>
                                                                        <asp:CheckBox ID="chkRptClaimEglibleIncenloanwisepreviousfymot" Enabled="false" AutoPostBack="true" runat="server" />
                                                                    </td>
                                                                    <td style="font-family: Calibri">
                                                                        <b>Moratorium Applicable for this claim Period</b>
                                                                        <asp:CheckBox ID="chkRptMoratiumApplforthisclaimperiod" Enabled="false" AutoPostBack="true" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri">
                                                                        <b>Rows Installment is not applicable</b>
                                                                    </td>
                                                                    <td style="font-family: Calibri" colspan="3">
                                                                        <asp:CheckBoxList ID="chkRptClaimegliblerowstodisable" AutoPostBack="true" Enabled="false" TextAlign="Right" RepeatDirection="Horizontal" runat="server">
                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                                        </asp:CheckBoxList>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:Repeater ID="rptMonths" runat="server" DataSource='<%# Eval("Months") %>'>
                                                                            <HeaderTemplate>
                                                                                <table class="table table-bordered">
                                                                                    <tr>
                                                                                        <th>Period of Claim</th>
                                                                                        <th>Principal amount due</th>
                                                                                        <th>No of Installment</th>
                                                                                        <th>Rate of Interest</th>
                                                                                        <th>Interest due</th>
                                                                                        <th>75% on interest due</th>
                                                                                        <th>interest due @ 8%</th>
                                                                                        <th>Eligible Interest Amount</th>
                                                                                    </tr>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPeriodofClaim" Enabled="false" runat="server" Text='<%# Eval("MonthYear") %>' CssClass="form-control"></asp:Label></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPrincipalAmountDue" ReadOnly="true" runat="server" CssClass="form-control"></asp:Label></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblInstallmentNo" CssClass="form-control" runat="server"></asp:Label></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtRateofInterest" AutoPostBack="true" OnTextChanged="txtRateofInterest_TextChanged" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblInterestDue" CssClass="form-control" runat="server"></asp:Label></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lbl75onInterestDue" CssClass="form-control" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblInterestDue8" CssClass="form-control" AutoPostBack="true" runat="server"></asp:Label></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblEligibleInterestAmount" runat="server" CssClass="form-control"></asp:Label></td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <tr>
                                                                                    <td style="text-align: left; font-weight: bold;">Total Eligible Amount:</td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblTotalEligibleAmount" runat="server" CssClass="form-control" Font-Bold="true"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:Repeater>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>Eligible period in months</b>
                                                                    </td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiEligibleperiodinmonths" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="font-family: Calibri"><b>Intrest Amount to be paid as per calculations</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>Actual interest amount paid</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiActualinterestamountpaid" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="font-family: Calibri"><b>Rate of Interest</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseRateofInterest" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                        </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>Eligible rate of reimbursement</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="font-family: Calibri"><b>Considered Amount for Interest 75%</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>Considered Amount for Interest 8%</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest8" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                    <td style="font-family: Calibri"><b>Interst reimbursement calculated</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiInsertreimbursementcalculated" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="font-family: Calibri"><b>Eligible Type</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:RadioButtonList ID="rbtgrdeglibilepallavaddi_isbelated" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Height="33px" 
                                                                            TabIndex="1" Width="200px">
                                                                            <asp:ListItem Value="Y">Regular</asp:ListItem>
                                                                            <asp:ListItem Value="N">Belated</asp:ListItem>
                                                                            <asp:ListItem Value="0">1 Year</asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </td>
                                                                     <td style="font-family: Calibri"><b>Interst reimbursement(After selecting the eglible Type)</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <%--<td style="font-family: Calibri"><b>GM recommended amount</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiGMrecommendedamount" 
                                                                            Enabled="false" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" 
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>--%>
                                                                    <td style="font-family: Calibri"><b>Eligible amount</b></td>
                                                                    <td style="font-family: Calibri">
                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiEligibleamount" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <table>
                                            <tr>
                                                <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                                <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">WorkSheet
                                                </td>
                                                <td class="style21" style="padding: 5px; margin: 5px">:
                                                </td>
                                                <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                                    <asp:FileUpload ID="fuWorksheet" runat="server" CssClass="CS" Height="28px" />
                                                    <asp:HyperLink ID="hypWorksheet" runat="server" CssClass="LBLBLACK" Width="165px"
                                                        Visible="false" Target="_blank"></asp:HyperLink>
                                                    <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                                    <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" />
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row">
                                        <table width="100%;">
                                            <tr id="trsubmit" runat="server" visible="true" align="center">
                                                <td colspan="9">

                                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" />
                                                    &nbsp; &nbsp;<asp:Button ID="btnback" runat="server"
                                                        CssClass="btn btn-warning" TabIndex="10"
                                                        Text="Go to Dashboard" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="9">
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
                                                    <asp:HiddenField ID="lblAllwomen" runat="server" />

                                                    <%--<asp:Label ID="lblAllwomen" runat="server" Visible="true" Text="Industry Status"></asp:Label>--%>
                                                </td>

                                            </tr>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hdnApplication" />
            <asp:HiddenField runat="server" ID="hdnActualCategory" />
            <asp:HiddenField runat="server" ID="hdnActualTextile" />
            <asp:HiddenField runat="server" ID="hdnTypeOfIndustry" />
            <asp:HiddenField ID="HiddenFieldEnterpriseCategory" runat="server" />
            <asp:HiddenField ID="hdnAlert" Value="N" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
