<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="IneterestSubsidyAppraisalNoteNew.aspx.cs" Inherits="TTAP.UI.Pages.IneterestSubsidyAppraisalNoteNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Interest Subsidy Appraisal Note</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Interest Subsidy Appraisal Note</h5>
                                </div>
                                 <div class="widget-content nopadding">
                                      <table runat="server" Visible="false">
                                        <tr>
                                            <td>

                                                <asp:TextBox ID="txtIncID" runat="server" TextMode="Number" ></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_schemetide" class="form-control txtbox" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button runat="server" Text="Search" CssClass="btn-blue" ID="btnsub" OnClick="btnsub_Click" />
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
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label4" runat="server">GM-Recommended Amount</label>
                                            <label class="form-control" id="lblRecommended" runat="server"></label>
                                        </div>

                                    </div>
                                     <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr runat="server" visible="false" id="trApprovedProjectCost">
                                                    <td align="left" colspan="4">
                                                        <%--<div class="text-blue font-SemiBold col col-sm-12 mt-3">Approved Project Cost(In Rs.)</div>--%>
                                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">1.Approved Project Cost(In Rs.)</h6>
                                                        <div class="col-sm-10 table-responsive">
                                                            <table class="table table-bordered title6 w-100 NewEnterprise" border="1">
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
                                                                        <label id="txtlandexisting" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                    <td id="Td2" runat="server" align="center" visible="false">
                                                                        <label id="txtlandcapacity" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                    <td id="txtbuildcapacityPercet" runat="server" align="center" visible="false">
                                                                        <label id="txtlandpercentage" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>2</td>
                                                                    <td align="left">Building </td>
                                                                    <td align="center">
                                                                        <label id="txtbuildingexisting" runat="server" cssclass="control-label"></label>
                                                                    </td>

                                                                    <td id="trFixedCapitalBuilding" runat="server" align="center" visible="false">
                                                                        <label id="txtbuildingcapacity" runat="server" cssclass="control-label"></label>
                                                                    </td>

                                                                    <td id="trFixedCapitBuildPercent" runat="server" align="center" visible="false">
                                                                        <label id="txtbuildingpercentage" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;
                                                                    </td>
                                                                    <td align="center">
                                                                        <label id="txtplantexisting" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                    <td id="trFixedCapitalMach" runat="server" align="center" visible="false">
                                                                        <label id="txtplantcapacity" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                    <td id="trFixedCapitMachPercent" runat="server" align="center" visible="false">
                                                                        <label id="txtplantpercentage" runat="server" cssclass="control-label"></label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td></td>
                                                                    <td align="left" style="text-align: left; font-weight: bold">Total</td>
                                                                    <td align="center">
                                                                        <label id="lblnewinv" runat="server" font-bold="True"></label>
                                                                    </td>
                                                                    <td id="Td4" runat="server" align="center" visible="false">
                                                                        <label id="lblexpinv" runat="server" font-bold="True"></label>
                                                                    </td>
                                                                    <td id="Td5" runat="server" align="center" visible="false">
                                                                        <label id="lbltotperinv" runat="server" font-bold="True"></label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false" id="trActualInvestment">
                                                    <td align="left" colspan="4">
                                                        <%-- <div class="text-blue font-SemiBold col col-sm-12 mt-3">Actual Investment(In Rs.)</div>--%>
                                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">2.Actual Investment(In Rs.)</h6>
                                                        <div class="col-sm-10 table-responsive">
                                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Nature of Assets</th>
                                                                    <th id="thExistingActual" runat="server">Existing Enterprise Value (in Rs.)</th>
                                                                    <th id="thExpansionActual" runat="server">Enterprise Value (in Rs.)</th>
                                                                    <th id="trActualCapitalexpnPercent" runat="server" visible="false">% of increase under
                                                                            Expansion/Diversification/Modification
                                                                    </th>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="left">Land</td>
                                                                    <td align="center" id="thExistingLandActual" runat="server">
                                                                        <label id="txtcurrInvLandValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionLandActual" runat="server">
                                                                        <label id="txtExpansionLandValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionLandActualPer" runat="server" align="center">
                                                                        <label id="txtExpansionLandPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>2</td>
                                                                    <td align="left">Building </td>
                                                                    <td align="center" id="thExistingBuildingActual" runat="server">
                                                                        <label id="txtcurrInvBuldvalue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionBuildingActual" runat="server">
                                                                        <label id="txtExpansionBuildingValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionBuildingPer" runat="server" align="center">
                                                                        <label id="txtExpansionBuildingPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;</td>
                                                                    <td align="center" id="thExistingPMActual" runat="server">
                                                                        <label id="txtcurrInvplantMechValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionPMActual" runat="server">
                                                                        <label id="txtExpansionplantMechValue" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionPMPer" runat="server" align="center">
                                                                        <label id="txtExpansionPMPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>4</td>
                                                                    <td align="left" style="text-align: left">Others &nbsp;&nbsp;&nbsp;</td>
                                                                    <td align="center" id="thExistingOthersActual" runat="server">
                                                                        <label id="txtcurrentInvothers" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionOthersActual" runat="server">
                                                                        <label id="txtExpansionInvothers" runat="server" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionOthersPer" runat="server" align="center">
                                                                        <label id="txtExpansionOthersPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="left" style="text-align: left; font-weight: bold">Total</td>
                                                                    <td align="center" id="thExistingTotalActual" runat="server">
                                                                        <label id="lblCurrInvTot" runat="server" style="font-weight: bold" class="control-label"></label>
                                                                    </td>
                                                                    <td align="center" id="thExpansionTotalActual" runat="server">
                                                                        <label id="lblExpansionInvTot" runat="server" style="font-weight: bold" class="control-label"></label>
                                                                    </td>
                                                                    <td id="thExpansionTotalPer" runat="server" align="center">
                                                                        <label id="txtExpansionTotalPer" runat="server" class="control-label"></label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>
                                     <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">

                                        <tr>
                                            <td style="width: 200px;">Type of Claim<font
                                                color="red">*</font>
                                            </td>
                                            <td style="padding: 5px; margin: 5px">
                                                <asp:RadioButtonList ID="rbtclaimtype" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Height="33px" OnSelectedIndexChanged="rbtclaimtype_SelectedIndexChanged"
                                                    TabIndex="1" Width="200px">
                                                    <asp:ListItem Value="R">Regular</asp:ListItem>
                                                    <asp:ListItem Value="M">Moratorium</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtDCP_unit"
                                                ErrorMessage="Please Enter Date of Commencement of Commercial production" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>--%>
                                            </td>
                                            <td style="padding: 5px; margin: 5px"></td>
                                        </tr>
                                    </table>
                                      <table align="center" id="Moratoriumtr" runat="server" visible="false" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr>
                                            <td>
                                                <div class="row">
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label8" runat="server">1) Date of Disbursement to DCP Date</label>
                                                        <asp:TextBox class="form-control" ID="txtDisbtoDCPdate" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label10" runat="server">2) Loan Amount Disbursed</label>
                                                        <asp:TextBox class="form-control" ID="txtLoanAmount" onkeypress="DecimalOnly()" AutoPostBack="true" runat="server" OnTextChanged="txtLoanAmount_TextChanged"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label11" runat="server">3) Rate of Interest</label>
                                                        <asp:TextBox class="form-control" ID="txtROI" runat="server" onkeypress="DecimalOnly()" AutoPostBack="true" OnTextChanged="txtROI_TextChanged"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label13" runat="server">4) Interest Due per Annum</label>
                                                        <asp:TextBox class="form-control" ID="txtInterestDue" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label14" runat="server">5) Interest Due per Month</label>
                                                        <asp:TextBox class="form-control" ID="txtInterestDuePM" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label15" runat="server">6) 75% of Monthly Interest</label>
                                                        <asp:TextBox class="form-control" ID="txt75Interest" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label16" runat="server">7) 8% of Monthly Interest of Loan AMount</label>
                                                        <asp:TextBox class="form-control" ID="txt8InterestforLoan" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label17" runat="server">8) Lower amount among 6 and 7</label>
                                                        <asp:TextBox class="form-control" ID="txtlowerInterest" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label20" runat="server">9) Moratorium period in months</label>
                                                        <asp:TextBox class="form-control" ID="txtMortPeriod" runat="server" onkeypress="NumberOnly()" AutoPostBack="true" OnTextChanged="txtMortPeriod_TextChanged"></asp:TextBox>
                                                    </div>

                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label21" runat="server">10) Total Eligible Reimbursement of Interest</label>
                                                        <asp:TextBox class="form-control" ID="txtTotElgbleInterest" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label22" runat="server">11) Recommendation by GM/DLO</label>
                                                        <asp:TextBox class="form-control" ID="txtGMRecAmount" runat="server"></asp:TextBox>
                                                    </div>

                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label23" runat="server">12) Final Eligible Subsidy</label>
                                                        <asp:TextBox class="form-control" ID="txtFnlElgbleSbsdy" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label24" runat="server">13) Remarks</label>
                                                        <asp:TextBox class="form-control" ID="txtRemarks" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="col-sm-4 form-group">
                                                        <label class="control-label" id="Label25" runat="server">14) Upload Document</label><br />
                                                        <asp:FileUpload class="form-control" ID="fupDoc" runat="server"></asp:FileUpload>
                                                    </div>

                                                </div>
                                            </td>
                                        </tr>
                                    </table>

                                    <table align="center" id="regulartr" runat="server" visible="false" cellpadding="10" cellspacing="5" style="width: 90%">

                                        <tr>
                                            <td colspan="5">

                                                <table style="width: 100%">
                                                    <tr style="height: 30px">
                                                        <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; vertical-align: middle;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; font-weight: bold; width: 20px">21
                                                        </td>
                                                        <td colspan="4" style="padding: 5px; margin: 5px;">
                                                            <b>ELEGIBLE INCENTIVES</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="4">
                                                            <asp:GridView ID="GvInterestSubsidyPeriod" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false"
                                                                AllowPaging="true" ShowHeaderWhenEmpty="true" ShowFooter="true" EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;" PageSize="50">
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            Sr.#
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
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator101" runat="server" ControlToValidate="txt_claimperiodofloanaddNumber"
                                                                                ErrorMessage="Please Enter No of Loans Applied for this Claim " Display="Dynamic"></asp:RequiredFieldValidator>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <PagerStyle CssClass="gridview"></PagerStyle>
                                                            </asp:GridView>

                                                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                              &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                              &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                             <asp:Button ID="btn_savegrdclaimperiodofloanadd" runat="server" CssClass="btn btn-primary" Height="32px"
                                                 OnClick="btn_savegrdclaimperiodofloanadd_Click" Text="Submit to Add More Details" Width="180px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>


                                        <tr>
                                            <td colspan="5">Note:
                                                    <font color="red">1.For a Claim Period Moratorium is applicable when the installment start date started before the claim period or in that Claim Period.
                                                    <br />
                                                        2.No of installments completed,No of installments completed Months is enabled,if  For Previous Financial Year is Moratorium Applicable.
                                                        No of installments completed be less than actual installment completed
                                                    <br />
                                                        3.Rows Installment is not applicable for the claim Period is enabled,if Moratorium Applicable for this claim Period selected
                                                    <br />
                                                        4.Aleast One Rows Installment should be selected for applying Moratorium.
                                                    <br />

                                                    </font>
                                                <table style="width: 100%">

                                                    <tr>
                                                        <td></td>
                                                        <td colspan="4">
                                                            <asp:GridView ID="grd_eglibilepallavaddi" runat="server" CssClass="table table-small-font table-bordered table-striped" AutoGenerateColumns="false"
                                                                AllowPaging="false" ShowHeaderWhenEmpty="true" ShowFooter="true" EmptyDataText="&lt;b&gt;No Data Available&lt;/b&gt;">
                                                                <Columns>

                                                                    <asp:TemplateField>

                                                                        <ItemTemplate>
                                                                            <asp:HiddenField ID="hf_grdeglibilepallavaddiIncentiveId" Value='<%# Eval("IncentiveId") %>' runat="server" />
                                                                            <asp:HiddenField ID="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" Value='<%# Eval("FinancialYear") %>' runat="server" />
                                                                            <asp:HiddenField ID="hf_grdeglibilepallavaddiFY_ID" Value='<%# Eval("FinancialYearID") %>' runat="server" />
                                                                            <table>
                                                                                <tr>
                                                                                    <th style="font-family: Calibri"><%#Container.DataItemIndex+1 %> Claim Period:   
                                                                     <asp:Label ID="lbl_grdeglibilepallavaddiFYname" Text='<%# Eval("FinancialYearName") %>' runat="server"></asp:Label>
                                                                                    </th>
                                                                                    <th style="font-family: Calibri"></th>
                                                                                    <th style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;  Loan-
                                                                     <asp:Label ID="lbl_claimeglibleincentivesloanwiseLoanID" Text='<%# Eval("LoanNumber") %>' runat="server"></asp:Label></th>
                                                                                    <th style="font-family: Calibri"></th>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Date of Commencement of activity:</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseDateofCommencementofactivity" Text='<%# Eval("DCPDATE") %>' runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseDateofCommencementofactivity_TextChanged"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseDateofCommencementofactivity"
                                                                                            ErrorMessage="Please Enter Date of Commencement of activity" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Loan installment start Date</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseinstallmentstartdate" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseinstallmentstartdate_TextChanged"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseinstallmentstartdate"
                                                                                            ErrorMessage="Please Enter Month from which installment starts" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Total Term Loan Availed(In Rs.)</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement" runat="server" class="form-control txtbox" Height="28px"
                                                                                            onkeypress="DecimalOnly()" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement_TextChanged"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement"
                                                                                            ErrorMessage="Please Enter Total Term Loan Availed(Value in Rs.)" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Period of installment</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:DropDownList ID="ddl_claimeglibleincentivesloanwiseperiodofinstallment" runat="server" class="form-control txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_claimeglibleincentivesloanwiseperiodofinstallment_SelectedIndexChanged"
                                                                                            TabIndex="4" Height="33px" Width="180px">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="1">Yearly</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Halfyearly</asp:ListItem>
                                                                                            <asp:ListItem Value="3">Quartely</asp:ListItem>
                                                                                            <asp:ListItem Value="4">Monthly</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="ddl_claimeglibleincentivesloanwiseperiodofinstallment"
                                                                                            ErrorMessage="Please select Period of installment" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>No of installment</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwisenoofinstallment" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwisenoofinstallment_TextChanged"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwisenoofinstallment"
                                                                                            ErrorMessage="Please Enter No of installment" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Installment amount</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseInstallmentamount" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseInstallmentamount_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator109" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseInstallmentamount"
                                                                                            ErrorMessage="Please Enter Installment amount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>

                                                                                </tr>

                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>No of installments completed</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:HiddenField ID="hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted" runat="server" />
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator110" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted"
                                                                                            ErrorMessage="Please Enter No of installments completed" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>PrincipalAmount become DUE before this HALFYEAR</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:HiddenField ID="hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR" runat="server" />
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR" runat="server" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR_TextChanged"
                                                                                            Enabled="false" class="form-control txtbox" Height="28px"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR"
                                                                                            ErrorMessage="Please Enter Principal amount become DUE before this HALF YEAR" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>No of installments completed Months</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:HiddenField ID="hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths" runat="server" />
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths"
                                                                                            ErrorMessage="Please Enter No of installments completed" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>For Previous Financial Year is Moratorium Applicable</b>
                                                                                        <asp:CheckBox ID="chk_claimeglibleincenloanwisepreviousfymot" Enabled="false" AutoPostBack="true" OnCheckedChanged="chk_claimeglibleincenloanwisepreviousfymot_CheckedChanged" runat="server" />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <b>Moratorium Applicable for this claim Period</b>
                                                                                        <asp:CheckBox ID="chk_moratiumapplforthisclaimperiod" Enabled="false" AutoPostBack="true" OnCheckedChanged="chk_moratiumapplforthisclaimperiod_CheckedChanged" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri">
                                                                                        <b>Rows Installment is not applicable</b>
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:CheckBoxList ID="chk_grdclaimegliblerowstodisable" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="chk_grdclaimegliblerowstodisable_SelectedIndexChanged" TextAlign="Right" RepeatDirection="Horizontal" runat="server">
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                                                        </asp:CheckBoxList>
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>


                                                                                <tr>
                                                                                    <td colspan="4">
                                                                                        <table border="1" width="100%" align="center" cellpadding="10" cellspacing="5">
                                                                                            <tr style="column-rule-style: solid">
                                                                                                <th style="font-family: Calibri">Sr.#	</th>
                                                                                                <th style="font-family: Calibri">Period of Claim</th>
                                                                                                <th style="font-family: Calibri">Principal amounnt due</th>

                                                                                                <th style="font-family: Calibri">No of Installment</th>
                                                                                                <th style="font-family: Calibri">Rate of Interest</th>
                                                                                                <th style="font-family: Calibri">Interest due</th>

                                                                                                <th style="font-family: Calibri">75% on interest due</th>
                                                                                                <th style="font-family: Calibri">interest due @ 8%</th>
                                                                                                <th style="font-family: Calibri">Eligible Interest Amount</th>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="font-family: Calibri">1</td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:HiddenField ID="hfgrd_monthoneid" runat="server" />
                                                                                                    <asp:Label ID="lbl_grd_monthonename" runat="server"></asp:Label>

                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthnonePrincipalamounntdue" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthoneNoofInstallment" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:TextBox ID="lbl_grd_monthoneRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthoneRateofinterest_TextChanged"
                                                                                                        class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lbl_grd_monthoneRateofinterest"
                                                                                                        ErrorMessage="Please Enter Rate of interest Month1" Display="Dynamic"></asp:RequiredFieldValidator>

                                                                                                    <%-- <asp:Label ID="lbl_grd_monthoneRateofinterest"  runat="server"></asp:Label>--%>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthoneInterestamount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthoneUnitHolderContribution" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthoneEligibleRateofinterest" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthoneEligibleInterestAmount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="font-family: Calibri">2</td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:HiddenField ID="hfgrd_monthtwoid" runat="server" />
                                                                                                    <asp:Label ID="lbl_grd_monthtwoname" runat="server"></asp:Label>

                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthtwoPrincipalamounntdue" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthtwoNoofInstallment" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <%--   <asp:Label ID="lbl_grd_monthtwoRateofinterest"  runat="server"></asp:Label>--%>
                                                                                                    <asp:TextBox ID="lbl_grd_monthtwoRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthtwoRateofinterest_TextChanged"
                                                                                                        class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lbl_grd_monthtwoRateofinterest"
                                                                                                        ErrorMessage="Please Enter Rate of interest Month2" Display="Dynamic"></asp:RequiredFieldValidator>

                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthtwoInterestamount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthtwoUnitHolderContribution" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthtwoEligibleRateofinterest" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthtwoEligibleInterestAmount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="font-family: Calibri">3</td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:HiddenField ID="hfgrd_monththreeid" runat="server" />
                                                                                                    <asp:Label ID="lbl_grd_monththreename" runat="server"></asp:Label>

                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monththreePrincipalamounntdue" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monththreeNoofInstallment" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <%-- <asp:Label ID="lbl_grd_monththreeRateofinterest"  runat="server"></asp:Label>--%>
                                                                                                    <asp:TextBox ID="lbl_grd_monththreeRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monththreeRateofinterest_TextChanged"
                                                                                                        class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="lbl_grd_monththreeRateofinterest"
                                                                                                        ErrorMessage="Please Enter Rate of interest Month3" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monththreeInterestamount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monththreeUnitHolderContribution" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monththreeEligibleRateofinterest" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monththreeEligibleInterestAmount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="font-family: Calibri">4</td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:HiddenField ID="hfgrd_monthfourid" runat="server" />
                                                                                                    <asp:Label ID="lbl_grd_monthfourname" runat="server"></asp:Label>

                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfourPrincipalamounntdue" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfourNoofInstallment" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <%-- <asp:Label ID="lbl_grd_monthfourRateofinterest"  runat="server"></asp:Label>--%>
                                                                                                    <asp:TextBox ID="lbl_grd_monthfourRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthfourRateofinterest_TextChanged"
                                                                                                        class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="lbl_grd_monthfourRateofinterest"
                                                                                                        ErrorMessage="Please Enter Rate of interest Month4" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfourInterestamount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfourUnitHolderContribution" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfourEligibleRateofinterest" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfourEligibleInterestAmount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="font-family: Calibri">5</td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:HiddenField ID="hfgrd_monthfiveid" runat="server" />
                                                                                                    <asp:Label ID="lbl_grd_monthfivename" runat="server"></asp:Label>

                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfivePrincipalamounntdue" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfiveNoofInstallment" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <%-- <asp:Label ID="lbl_grd_monthfiveRateofinterest"  runat="server"></asp:Label>--%>
                                                                                                    <asp:TextBox ID="lbl_grd_monthfiveRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthfiveRateofinterest_TextChanged"
                                                                                                        class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="lbl_grd_monthfiveRateofinterest"
                                                                                                        ErrorMessage="Please Enter Rate of interest Month5" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfiveInterestamount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfiveUnitHolderContribution" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfiveEligibleRateofinterest" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthfiveEligibleInterestAmount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="font-family: Calibri">6</td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:HiddenField ID="hfgrd_monthsixid" runat="server" />
                                                                                                    <asp:Label ID="lbl_grd_monthsixname" runat="server"></asp:Label>

                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthsixPrincipalamounntdue" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthsixNoofInstallment" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <%--  <asp:Label ID="lbl_grd_monthsixRateofinterest"  runat="server"></asp:Label>--%>
                                                                                                    <asp:TextBox ID="lbl_grd_monthsixRateofinterest" runat="server" AutoPostBack="true" OnTextChanged="lbl_grd_monthsixRateofinterest_TextChanged"
                                                                                                        class="form-control txtbox" Height="28px" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="lbl_grd_monthsixRateofinterest"
                                                                                                        ErrorMessage="Please Enter Rate of interest Month5" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthsixInterestamount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthsixUnitHolderContribution" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthsixEligibleRateofinterest" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_monthsixEligibleInterestAmount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="font-family: Calibri">6</td>
                                                                                                <td style="font-family: Calibri"></td>
                                                                                                <td style="font-family: Calibri"></td>
                                                                                                <td style="font-family: Calibri"></td>
                                                                                                <td style="font-family: Calibri">Total Interest Amount:
                                                                                                </td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_totmonthsInterestamount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                                <td style="font-family: Calibri"></td>
                                                                                                <td style="font-family: Calibri">Total Eligible Interest Amount:</td>
                                                                                                <td style="font-family: Calibri">
                                                                                                    <asp:Label ID="lbl_grd_totmonthsEligibleInterestAmount" runat="server"></asp:Label>
                                                                                                </td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>

                                                                                    <td style="font-family: Calibri"><b>Eligible period in months</b>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <br />
                                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiEligibleperiodinmonths" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiEligibleperiodinmonths_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ControlToValidate="txt_grdeglibilepallavaddiEligibleperiodinmonths"
                                                                                            ErrorMessage="Please Enter Eligible period in months" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Insert amount to be paid as per calculations</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ControlToValidate="txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations"
                                                                                            ErrorMessage="Please Enter Insert amount to be paid as per calculations" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Actual interest amount paid</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiActualinterestamountpaid" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiActualinterestamountpaid_TextChanged"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator124" runat="server" ControlToValidate="txt_grdeglibilepallavaddiActualinterestamountpaid"
                                                                                            ErrorMessage="Please Enter Actual interest amount paid" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Rate of Interest</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseRateofInterest" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseRateofInterest_TextChanged"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator107" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseRateofInterest"
                                                                                            ErrorMessage="Please Enter Rate of Interest" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Eligible rate of reimbursement</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator108" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement"
                                                                                            ErrorMessage="Please Enter Eligible rate of reimbursement" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>

                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Considered Amount for Interest 75%</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10111" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest"
                                                                                            ErrorMessage="Please Enter Considered Amount for Interest" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri">&nbsp;&nbsp;&nbsp; &nbsp;<b>Considered Amount for Interest 8%</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest8" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_claimeglibleincentivesloanwiseConsideredAmountforInterest8"
                                                                                            ErrorMessage="Please Enter Considered Amount for Interest 8%" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Interst reimbursement calculated</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiInsertreimbursementcalculated" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiInsertreimbursementcalculated_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator125" runat="server" ControlToValidate="txt_grdeglibilepallavaddiInsertreimbursementcalculated"
                                                                                            ErrorMessage="Please Enter Interst reimbursement calculated" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Eligible Type</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:RadioButtonList ID="rbtgrdeglibilepallavaddi_isbelated" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Height="33px" OnSelectedIndexChanged="rbtgrdeglibilepallavaddi_isbelated_SelectedIndexChanged"
                                                                                            TabIndex="1" Width="200px">
                                                                                            <asp:ListItem Value="Y">Regular</asp:ListItem>
                                                                                            <asp:ListItem Value="N">Belated</asp:ListItem>
                                                                                            <asp:ListItem Value="0">1 Year</asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Interst reimbursement(After selecting the eglible Type)</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype_TextChanged"
                                                                                            Enabled="false" TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator126" runat="server" ControlToValidate="txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype"
                                                                                            ErrorMessage="Please Enter Interst reimbursement(After selecting the eglible Type)" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>GM recommended amount</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiGMrecommendedamount" Text='<%# Eval("GM_Rcon_Amount") %>'
                                                                                            Enabled="false" runat="server" class="form-control txtbox" Height="28px" AutoPostBack="true" OnTextChanged="txt_grdeglibilepallavaddiGMrecommendedamount_TextChanged"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator127" runat="server" ControlToValidate="txt_grdeglibilepallavaddiGMrecommendedamount"
                                                                                            ErrorMessage="Please Enter GM recommended amount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="font-family: Calibri"><b>Eligible amount</b></td>
                                                                                    <td style="font-family: Calibri">
                                                                                        <asp:TextBox ID="txt_grdeglibilepallavaddiEligibleamount" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                                                            TabIndex="10" Width="180px"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator128" runat="server" ControlToValidate="txt_grdeglibilepallavaddiEligibleamount"
                                                                                            ErrorMessage="Please Enter Eligible amount" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                                        <br />
                                                                                    </td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                    <td style="font-family: Calibri"></td>
                                                                                </tr>
                                                                            </table>


                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                                <PagerStyle CssClass="gridview"></PagerStyle>
                                                            </asp:GridView>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                                        <td style="padding: 5px; margin: 5px;">Insert amount to be paid as per calculations</td>
                                                        <td style="padding: 5px; margin: 5px;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                            <asp:TextBox ID="txt_Insertamounttobepaidaspercalculations" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_Insertamounttobepaidaspercalculations"
                                                                ErrorMessage="Please Enter Insert amount to be paid as per calculations" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                                        <td style="padding: 5px; margin: 5px;"></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                                        <td style="padding: 5px; margin: 5px;">Actual interest amount paid<font
                                                            color="red">*</font></td>
                                                        <td style="padding: 5px; margin: 5px;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                            <asp:TextBox ID="txt_Actualinterestamountpaid" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txt_Actualinterestamountpaid"
                                                                ErrorMessage="Please Enter Actual interest amount paid" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                                        <td style="padding: 5px; margin: 5px;"></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                                        <td style="padding: 5px; margin: 5px;">Considered Amount of Interest<font color="red">*</font></td>
                                                        <td style="padding: 5px; margin: 5px;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                            <asp:TextBox ID="txt_ConsideredAmountofInterest" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_ConsideredAmountofInterest"
                                                                ErrorMessage="Please Enter Considered Amount of Interest" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                                        <td style="padding: 5px; margin: 5px;"></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                                        <td style="padding: 5px; margin: 5px;">Interst reimbursement calculated<font color="red">*</font></td>
                                                        <td style="padding: 5px; margin: 5px;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                            <asp:TextBox ID="txt_Insertreimbursementcalculated" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txt_Insertreimbursementcalculated"
                                                                ErrorMessage="Please Enter Interst reimbursement calculated" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                                        <td style="padding: 5px; margin: 5px;"></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                                        <td style="padding: 5px; margin: 5px;">Interst reimbursement(After selecting the eglible Type)<font color="red">*</font></td>
                                                        <td style="padding: 5px; margin: 5px;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                            <asp:TextBox ID="txt_eglibleamountofreimbursementbyeglibletype" runat="server" class="form-control txtbox" Height="28px" Enabled="false"
                                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_eglibleamountofreimbursementbyeglibletype"
                                                                ErrorMessage="Please Enter Interst reimbursement(After selecting the eglible Type)" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                                        <td style="padding: 5px; margin: 5px;"></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                                        <td style="padding: 5px; margin: 5px;">GM recommended amount<font color="red">*</font></td>
                                                        <td style="padding: 5px; margin: 5px;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                            <asp:TextBox ID="txt_GMrecommendedamount" runat="server" class="form-control txtbox" Enabled="true" Height="28px" AutoPostBack="true" OnTextChanged="txt_GMrecommendedamount_TextChanged"
                                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txt_GMrecommendedamount"
                                                                ErrorMessage="Please Enter GM recommended amount" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                                        <td style="padding: 5px; margin: 5px;"></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                                        <td style="padding: 5px; margin: 5px;">Eligible amount</td>
                                                        <td style="padding: 5px; margin: 5px;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                            <asp:TextBox ID="txt_Eligibleamount" runat="server" class="form-control txtbox" Height="28px" Enabled="true"
                                                                TabIndex="10" ValidationGroup="group" Width="180px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txt_Eligibleamount"
                                                                ErrorMessage="Please Enter Eligible amount" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                                        <td style="padding: 5px; margin: 5px;"></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                                        <td style="padding: 5px; margin: 5px;">Forward To</td>
                                                        <td style="padding: 5px; margin: 5px;">:
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                                            <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox">
                                                                <asp:ListItem Text="--Select--" Value="Select"></asp:ListItem>
                                                                <asp:ListItem Text="SUPDT" Value="SUPDT"></asp:ListItem>
                                                                <asp:ListItem Text="AD" Value="AD"></asp:ListItem>
                                                                <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                                                                <asp:ListItem Text="JD" Value="JD"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_Eligibleamount"
                                                                ErrorMessage="Please Enter Eligible amount" Display="Dynamic" ValidationGroup="group"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                                        <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                                        <td style="padding: 5px; margin: 5px;"></td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp; 
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px;">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-family: Calibri"><b>Remarks</b></td>
                                                        <td style="font-family: Calibri">
                                                            <asp:TextBox ID="txt_TotalRemarks" runat="server" class="form-control txtbox" Height="28px"
                                                                ValidationGroup="group" TabIndex="10" Width="300px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_TotalRemarks"
                                                                ErrorMessage="Please Enter Remarks" ValidationGroup="group" Display="Dynamic"></asp:RequiredFieldValidator>
                                                            <br />
                                                        </td>
                                                        <td style="font-family: Calibri"></td>
                                                        <td style="font-family: Calibri"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                        <tr id="trsubmit" runat="server" visible="true">
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="32px" OnClick="BtnSave_Click" TabIndex="24" Text="Save" ValidationGroup="group" Width="90px" />
                                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="BtnClearall" runat="server" CausesValidation="False" CssClass="btn btn-warning" OnClick="BtnClearall_Click" Height="32px" Text="Clear" ToolTip="To Clear  the Screen" Width="90px" />
                                                &nbsp;&nbsp;&nbsp; &nbsp;<asp:Button ID="btm_previous" runat="server" CausesValidation="False" CssClass="btn btn-primary" OnClick="btm_previous_Click" Height="32px" TabIndex="25" Text="Previous" ToolTip="Payment" Width="90px" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" class="alert alert-success" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                </div>
                                                <div id="Failure" runat="server" class="alert alert-danger" visible="false">
                                                    <a aria-label="close" class="close" data-dismiss="alert" href="#">×</a> <strong>Warning!</strong>
                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
