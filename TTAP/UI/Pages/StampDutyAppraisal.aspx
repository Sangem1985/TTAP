<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="StampDutyAppraisal.aspx.cs" Inherits="TTAP.UI.Pages.StampDutyAppraisal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Apprisal Note of Reimbursement of Stamp Duty/Transfer Duty/Mortgage and Hypothecation Duty</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Apprisal Note of Reimbursement of Stamp Duty/Transfer Duty/Mortgage and Hypothecation Duty</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <table runat="server" visible="false">
                                        <tr>
                                            <td>

                                                <asp:TextBox ID="txtIncID" runat="server" TextMode="Number"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">

                                        <tr>
                                            <td style="width: 2%"></td>
                                            <td style="font: bolder; font-size: small" class="auto-style1">
                                                <b>1. Unit Name</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_schemetide" class="form-control txtbox" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 2%"></td>
                                            <td class="auto-style1">2. Address
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
                                                                    <td>
                                                                        <span>
                                                                            <asp:Label ID="lblUIDNumber" runat="server"></asp:Label>
                                                                        </span>
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
                                    <div class="row">
                                        <table style="width: 100%">
                                            <tr style="height: 30px">
                                                <td colspan="9" style="height: 20px"></td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px">4.2.3
                                                </td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <b>STAMP DUTY</b></td>
                                                <b>STAMP DUTY</b></td>

                                            </tr>

                                            <tr id="TRSCHEME" runat="server">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">SCHEME</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">

                                                    <asp:DropDownList ID="DDLSCHEME" runat="server" class="form-control txtbox" TabIndex="5"
                                                        Height="33px" Width="180px" AutoPostBack="True" Enabled="false" Visible="true" OnSelectedIndexChanged="DDLSCHEME_SelectedIndexChanged">
                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                        <asp:ListItem Value="IIPP 2010-15">IIPP 2010-15</asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="T-IDEA">TTAP</asp:ListItem>
                                                        <asp:ListItem Value="T-PRIDE">T-PRIDE</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txtPlintharea423" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="35" onkeypress="return inputOnlyNumbers(event)"  Width="150px"></asp:TextBox>
                    </td>--%>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                                </td>
                                            </tr>
                                            <tr id="TRTYPE" runat="server">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Select Type</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">

                                                    <asp:RadioButtonList ID="RBTTYPE" runat="server" RepeatDirection="Horizontal"
                                                        AutoPostBack="True" OnSelectedIndexChanged="RBTTYPE_SelectedIndexChanged">
                                                        <asp:ListItem Value="NEW/REGULAR">NEW/REGULAR</asp:ListItem>

                                                        <asp:ListItem Value="EXPANSION">EXPANSION</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txtPlintharea423" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="35" onkeypress="return inputOnlyNumbers(event)"  Width="150px"></asp:TextBox>
                    </td>--%>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">&nbsp;&nbsp;Land Measuring in Sq. Mts.</td>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">

                                                    <asp:TextBox ID="txtland" runat="server" class="form-control txtbox txtcomn" onkeypress="return inputOnlyNumbers(event)" oncopy="return false" onpaste="return false" oncut="return false"
                                                        Height="30px" MaxLength="80" TabIndex="34" Width="150px" AutoPostBack="true" OnTextChanged="txtland_TextChanged"></asp:TextBox>

                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">&nbsp;&nbsp;Stamp Duty paid by the unit in Rs.</td>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">

                                                    <asp:TextBox ID="txtstampduty" runat="server" class="form-control txtbox txtcomn" onkeypress="return inputOnlyNumbers(event)" oncopy="return false" onpaste="return false" oncut="return false"
                                                        Height="30px" MaxLength="80" TabIndex="34" Width="150px" AutoPostBack="true" OnTextChanged="txtstampduty_TextChanged"></asp:TextBox>

                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">&nbsp;&nbsp;Building plinth area in Sq.Mts.</td>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">

                                                    <asp:TextBox ID="txtplinth" runat="server" class="form-control txtbox txtcomn" onkeypress="return inputOnlyNumbers(event)" oncopy="return false" onpaste="return false" oncut="return false"
                                                        Height="30px" MaxLength="80" TabIndex="34" Width="150px" AutoPostBack="true" OnTextChanged="txtplinth_TextChanged"></asp:TextBox>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">&nbsp;&nbsp;Building plinth area 5 times(Sq. Mts.)</td>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">

                                                    <asp:TextBox ID="txtplinth5" runat="server" class="form-control txtbox txtcomn" onkeypress="return inputOnlyNumbers(event)" oncopy="return false" onpaste="return false" oncut="return false"
                                                        Height="30px" MaxLength="80" TabIndex="34" Width="150px" AutoPostBack="true" OnTextChanged="txtplinth5_TextChanged"></asp:TextBox>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">&nbsp;&nbsp;Proportionate value for the area in Rs.</td>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">

                                                    <asp:TextBox ID="txtproportionate" runat="server" class="form-control txtbox txtcomn" onkeypress="return inputOnlyNumbers(event)" oncopy="return false" onpaste="return false" oncut="return false"
                                                        Height="30px" MaxLength="80" TabIndex="34" Width="150px" AutoPostBack="true" OnTextChanged="txtproportionate_TextChanged"></asp:TextBox>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">&nbsp;&nbsp;Value Recommended by G.M. DIC in Rs.</td>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">

                                                    <asp:TextBox ID="txtGmRecom" runat="server" class="form-control txtbox txtcomn" onkeypress="return inputOnlyNumbers(event)" oncopy="return false" onpaste="return false" oncut="return false"
                                                        Height="30px" MaxLength="80" TabIndex="34" Width="150px"></asp:TextBox>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">&nbsp;&nbsp;Value Computed in Rs.</td>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">

                                                    <asp:TextBox ID="txtvaluecomputed" runat="server" class="form-control txtbox txtcomn" onkeypress="return inputOnlyNumbers(event)" oncopy="return false" onpaste="return false" oncut="return false"
                                                        Height="30px" MaxLength="80" TabIndex="34" Width="150px"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr id="treligibility" runat="server">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Select Type</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">

                                                    <asp:RadioButtonList ID="rdeligibility" runat="server" RepeatDirection="Horizontal"
                                                        AutoPostBack="True" OnSelectedIndexChanged="rdeligibility_SelectedIndexChanged">
                                                        <asp:ListItem Value="Regular">REGULAR</asp:ListItem>
                                                        <asp:ListItem Value="Belated">BELATED</asp:ListItem>
                                                        <asp:ListItem Value="OneYear">BEYOND ONE YEAR</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txtPlintharea423" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="35" onkeypress="return inputOnlyNumbers(event)"  Width="150px"></asp:TextBox>
                    </td>--%>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">&nbsp;&nbsp;Eligible Amount in Rs.</td>
                                                <td class="auto-style48">&nbsp;</td>
                                                <td class="auto-style48">

                                                    <asp:TextBox ID="txtEligible" runat="server" class="form-control txtbox txtcomn" onkeypress="return inputOnlyNumbers(event)" oncopy="return false" onpaste="return false" oncut="return false"
                                                        Height="30px" MaxLength="80" TabIndex="34" Width="150px"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr id="tradremarks" runat="server" visible="true">
                                                <td></td>
                                                <td style="padding: 5px; margin: 5px;">Remarks</td>
                                                <td style="padding: 5px; margin: 5px;">:</td>
                                                <td>&nbsp;
                            <asp:TextBox ID="txtremarks" runat="server" TextMode="MultiLine" class="form-control txtbox txtcomn" Height="30px" TabIndex="37" Width="150px"></asp:TextBox>
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                                </td>
                                                <td style="padding: 5px; margin: 5px;">&nbsp;</td>
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
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="SUPDT" Value="SUPDT"></asp:ListItem>
                                                        <asp:ListItem Text="AD" Value="AD"></asp:ListItem>
                                                        <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                                                        <asp:ListItem Text="JD" Value="JD"></asp:ListItem>
                                                    </asp:DropDownList>
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
                                                    <asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                        TabIndex="10" Text="Upload" Width="72px" />
                                                </td>
                                                <td></td>
                                            </tr>

                                        </table>
                                        <table width="100%;">
                                            <tr id="trsubmit" runat="server" visible="true" align="center">
                                                <td colspan="9">

                                                    <asp:Button ID="btnsubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnsubmit_Click" />
                                                    &nbsp; &nbsp;<asp:Button ID="btnback" runat="server"
                                                        CssClass="btn btn-warning" TabIndex="10"
                                                        Text="Go to Dashboard" OnClick="btnback_Click" />
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
                                                <td>
                                                    <asp:HiddenField ID="hdfID" runat="server" />
                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" />
                                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="child" />
                                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                                    &nbsp;<asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="group1" />
                                                    <asp:HiddenField ID="hdfincentiveid" runat="server" />
                                                    <asp:ValidationSummary ID="ValidationSummary4" runat="server" ShowMessageBox="True"
                                                        ShowSummary="False" ValidationGroup="group1" />
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
            </div>
            <asp:HiddenField runat="server" ID="hdnApplication" />
            <asp:HiddenField runat="server" ID="hdnActualCategory" />
            <asp:HiddenField runat="server" ID="hdnActualTextile" />
            <asp:HiddenField runat="server" ID="hdnTypeOfIndustry" />
            <asp:HiddenField ID="HiddenFieldEnterpriseCategory" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
