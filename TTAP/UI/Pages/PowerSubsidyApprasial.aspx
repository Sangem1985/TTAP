<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="PowerSubsidyApprasial.aspx.cs" Inherits="TTAP.UI.Pages.PowerSubsidyApprasial" %>

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
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Inspection Report</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Inspection Report</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <table>
                                        <tr>
                                            <td>

                                                <asp:TextBox ID="txtIncID" runat="server" TextMode="Number"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSchemeName" class="form-control txtbox" runat="server"></asp:Label>
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
                                    <div class="row">
                                        <table style="width: 100%">
                                            <tr style="height: 30px">
                                                <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12">D<b>. </b>
                                                </td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <b>ABSTRACT</b> </td>



                                                <td class="auto-style25">&nbsp;
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style10">&nbsp;</td>



                                                <td class="auto-style18">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style5">
                                                    <b>As per approved costs</b></td>

                                                <td class="auto-style15"></td>
                                                <td class="auto-style25">
                                                    <b>Computed as eligible Investment</b>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style13">i)&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style11">Land</td>
                                                <td style="margin: 5px;" class="auto-style19"></td>
                                                <td style="margin: 5px;" class="auto-style6">
                                                    <asp:TextBox ID="TextBox33" runat="server" AutoPostBack="true" onkeypress="DecimalOnly()" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" Width="150px" OnTextChanged="TextBox33_TextChanged"></asp:TextBox>
                                                    <%--txtLand2--%>
                                                </td>

                                                <td style="margin: 5px; font-weight: bold;" valign="top" class="auto-style16">&nbsp;</td>
                                                <td style="margin: 5px;" class="auto-style23">
                                                    <asp:TextBox ID="TextBox56" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" OnTextChanged="TextBox56_TextChanged" TabIndex="6" Width="150px"></asp:TextBox>
                                                </td>
                                                <td style="margin: 5px;" class="auto-style1"></td>
                                                <td style="margin: 5px;" class="auto-style1">&nbsp;</td>
                                                <td class="auto-style1">&nbsp;
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style49">ii).</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style50">Building</td>
                                                <td style="margin: 5px;" class="auto-style51"></td>
                                                <td style="margin: 5px;" class="auto-style52">
                                                    <asp:TextBox ID="TextBox37" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox37_TextChanged"></asp:TextBox>
                                                    <%--txtBuilding2--%>

                                                </td>
                                                <td style="margin: 5px;" class="auto-style53">&nbsp;
                                                </td>

                                                <td style="margin: 5px;" class="auto-style39">
                                                    <asp:TextBox ID="TextBox57" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" OnTextChanged="TextBox57_TextChanged" TabIndex="6" Width="150px"></asp:TextBox>
                                                </td>
                                                <td style="margin: 5px;" class="auto-style54"></td>
                                                <td style="margin: 5px;" class="auto-style54"></td>
                                                <td class="auto-style54">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style43">iii).</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style44">Plant and Machinery</td>
                                                <td style="margin: 5px;" class="auto-style45"></td>
                                                <td style="margin: 5px;" class="auto-style46">
                                                    <asp:TextBox ID="TextBox41" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox41_TextChanged"></asp:TextBox>
                                                    <%--txtPM2--%>

                                                </td>
                                                <td style="margin: 5px;" class="auto-style47">&nbsp;
                                                </td>
                                                <td style="margin: 5px;" class="auto-style41">
                                                    <asp:TextBox ID="TextBox58" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox58_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="margin: 5px;" class="auto-style42"></td>
                                                <td style="margin: 5px;" class="auto-style48"></td>
                                                <td style="margin: 5px;" class="auto-style48"></td>
                                                <td class="auto-style48">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style14">iv).</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style10">Technical Know-how feasibility study and turn Key Charges</td>
                                                <td style="margin: 5px;" class="auto-style18"></td>
                                                <td style="margin: 5px;" class="auto-style5">
                                                    <asp:TextBox ID="TextBox44" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox44_TextChanged"></asp:TextBox>
                                                    <%--txtTFS2--%>

                                                </td>
                                                <td style="margin: 5px;" class="auto-style20">&nbsp;
                                                </td>
                                                <td style="margin: 5px;" class="auto-style24">
                                                    <asp:TextBox ID="TextBox45" Text="0" AutoPostBack="true" runat="server" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox45_TextChanged"></asp:TextBox>
                                                </td>
                                                <td style="margin: 5px;" class="auto-style4">&nbsp;</td>
                                                <td style="margin: 5px;"></td>
                                                <td style="margin: 5px;">&nbsp;</td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style14">&nbsp;</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style10">
                                                    <b>Total</b></td>
                                                <td style="margin: 5px;" class="auto-style18"></td>
                                                <td style="margin: 5px;" class="auto-style5">
                                                    <asp:TextBox ID="TextBox1" runat="server" Enabled="false" class="form-control txtbox" Height="28px" MaxLength="100" TabIndex="6" onkeypress="DecimalOnly()" Width="150px"></asp:TextBox>


                                                </td>
                                                <td style="margin: 5px;" class="auto-style20">&nbsp;
                                                </td>
                                                <td style="margin: 5px;" valign="top" class="auto-style24">
                                                    <asp:TextBox ID="TextBox2" runat="server" Enabled="false" class="form-control txtbox" onkeypress="DecimalOnly()" Height="28px" MaxLength="100" TabIndex="6" Width="150px"></asp:TextBox>
                                                </td>
                                                <td style="margin: 5px;" class="auto-style4">&nbsp;</td>
                                                <td style="margin: 5px;"></td>
                                                <td style="margin: 5px;">&nbsp;</td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="auto-style14" style="padding: 5px; margin: 5px;" valign="top">&nbsp;</td>
                                                <td class="auto-style10" style="padding: 5px; margin: 5px;">Employment</td>
                                                <td class="auto-style18" style="margin: 5px;">&nbsp;</td>
                                                <td class="auto-style5" style="margin: 5px;">
                                                    <asp:TextBox ID="txtemployement" runat="server" AutoPostBack="true" class="form-control txtbox" Height="28px" MaxLength="100" onkeypress="DecimalOnly()" OnTextChanged="txtemployement_TextChanged" TabIndex="6" Text="0" Width="150px"></asp:TextBox>
                                                </td>
                                                <td class="auto-style20" style="margin: 5px;">&nbsp;</td>
                                                <td class="auto-style24" style="margin: 5px;" valign="top">&nbsp;</td>
                                                <td class="auto-style4" style="margin: 5px;">&nbsp;</td>
                                                <td style="margin: 5px;">&nbsp;</td>
                                                <td style="margin: 5px;">&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>

                                        </table>
                                    </div>
                                    <div class="row">
                                        <table style="width: 100%">
                                            <tr style="height: 30px">
                                                <td colspan="10" style="height: 20px"></td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px">4.2.3
                                                </td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <b>ELEGIBLE INCENTIVES</b></td>

                                            </tr>
                                            <tr id="trIndustryStatus" runat="server" visible="true">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Industry Status</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">

                                                    <asp:DropDownList ID="ddlIndustryStatus" runat="server" class="form-control"
                                                        TabIndex="5" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlIndustryStatus_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                        <asp:ListItem Value="1">New Industry</asp:ListItem>
                                                        <asp:ListItem Value="2">Expansion</asp:ListItem>
                                                        <asp:ListItem Value="3">Diversification</asp:ListItem>
                                                        <asp:ListItem Value="4">Modernization</asp:ListItem>
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
                                            <tr id="trCONVENTIONALTECHNICAL" runat="server">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Select</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">

                                                    <asp:RadioButtonList ID="rdcoventinaltech" runat="server" RepeatDirection="Horizontal"
                                                        AutoPostBack="True" OnSelectedIndexChanged="rdcoventinaltech_SelectedIndexChanged">
                                                        <asp:ListItem Value="Conventional Textile Unit">Conventional Textile Unit</asp:ListItem>
                                                        <asp:ListItem Value="Technical Textile Unit">Technical Textile Unit</asp:ListItem>
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
                                            <tr id="tr1" runat="server" visible="true">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Nature Of Industry</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">
                                                    <asp:DropDownList ID="ddlTextileProcessType" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTextileProcessType_SelectedIndexChanged">
                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Ginning"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Spinning"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Weaving"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Garmenting"></asp:ListItem>
                                                        <asp:ListItem Value="5" Text="Processing"></asp:ListItem>
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
                                            <tr id="trCATEORY" runat="server" visible="true">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Category of Unit</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">

                                                    <asp:RadioButtonList ID="rdcategoryofunit" runat="server" RepeatDirection="Horizontal"
                                                        AutoPostBack="True" OnSelectedIndexChanged="rdcategoryofunit_SelectedIndexChanged">
                                                        <asp:ListItem Value="A1">A1</asp:ListItem>
                                                        <asp:ListItem Value="A2">A2</asp:ListItem>
                                                        <asp:ListItem Value="A3">A3</asp:ListItem>
                                                        <asp:ListItem Value="A4">A4</asp:ListItem>
                                                        <asp:ListItem Value="A5">A5</asp:ListItem>
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
                                            <tr id="trcaste" runat="server" visible="true">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Select</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">

                                                    <asp:RadioButtonList ID="rdlmv" runat="server" RepeatDirection="Horizontal"
                                                        AutoPostBack="True" OnSelectedIndexChanged="rdlmv_SelectedIndexChanged">
                                                        <asp:ListItem Value="GENERAL">GENERAL</asp:ListItem>
                                                        <asp:ListItem Value="SC">SC</asp:ListItem>
                                                        <asp:ListItem Value="ST">SC</asp:ListItem>
                                                        <asp:ListItem Value="PHC">PWD</asp:ListItem>
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


                                            <tr id="trmenwomen" runat="server">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Select Men/Women</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56">

                                                    <asp:RadioButtonList ID="rdmenwomen" runat="server" RepeatDirection="Horizontal"
                                                        AutoPostBack="True" OnSelectedIndexChanged="rdmenwomen_SelectedIndexChanged">
                                                        <asp:ListItem Value="Men">MEN</asp:ListItem>
                                                        <asp:ListItem Value="Women">WOMEN</asp:ListItem>
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

                                            <tr id="treligibility" runat="server">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Select Type</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56" colspan="3">

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
                                            <tr id="Tr3" runat="server">
                                                <td colspan="3">
                                                    <b>Base power consumption fixed per year
                                                        <asp:TextBox ID="TextBox98" runat="server"></asp:TextBox>
                                                        &nbsp;Per month&nbsp;
                                                    </b>

                                                    <asp:TextBox ID="TextBox7775" AutoPostBack="true" runat="server" OnTextChanged="TextBox7775_TextChanged"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr id="trfinancial" runat="server">
                                                <td class="auto-style56"></td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Select Financial Year Both/Not</td>
                                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                <td class="auto-style56" colspan="3">
                                                    <asp:RadioButtonList ID="rdbFinYearBothList" RepeatDirection="Horizontal" AutoPostBack="true" runat="server" OnSelectedIndexChanged="rdbFinYearBothList_SelectedIndexChanged">
                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                        <asp:ListItem Value="N">No</asp:ListItem>
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
                                                <td colspan="8">
                                                    <table id="tbl_monthyeardataExpansion" runat="server" visible="false" bgcolor="White" width="100%" style="font-family: Verdana;">
                                                        <tr>
                                                            <td></td>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Month-year
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Units Consumed
                                                                                    <br />
                                                                in Nos.
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Rate per
                                                                                    <br />
                                                                Units
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Amount Paid as per Bill in Rs.
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Base fixed per month in units
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Eligible Units i.e over & above Base
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Eligible Rate for
                                                                <br />
                                                                Reimbursement per units
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Eligible amount for 
                                                                    <br />
                                                                Reiembursement in Rs.
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear1" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear1unitsconsumed" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear1rateperunit" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear1rateperunit_TextChanged1"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear1amountpaid" AutoPostBack="true" OnTextChanged="txt_grdyear1amountpaid_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear1basefixedunitspermonth" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear1eligibleunits" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear1eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear1eligibleamountforreimbursement" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear1eligibleamountforreimbursement_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBox75" runat="server"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear2" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear2unitsconsumed" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear2rateperunit" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear2rateperunit_TextChanged1"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear2amountpaid" AutoPostBack="true" OnTextChanged="txt_grdyear2amountpaid_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear2basefixedunitspermonth" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear2eligibleunits" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear2eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear2eligibleamountforreimbursement" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear2eligibleamountforreimbursement_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBox76" runat="server"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear3" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear3unitsconsumed" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear3rateperunit" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear3rateperunit_TextChanged1"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear3amountpaid" AutoPostBack="true" OnTextChanged="txt_grdyear3amountpaid_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear3basefixedunitspermonth" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear3eligibleunits" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear3eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear3eligibleamountforreimbursement" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear3eligibleamountforreimbursement_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBox77" runat="server"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear4" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear4unitsconsumed" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear4rateperunit" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear4rateperunit_TextChanged1"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear4amountpaid" AutoPostBack="true" OnTextChanged="txt_grdyear4amountpaid_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear4basefixedunitspermonth" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear4eligibleunits" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear4eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear4eligibleamountforreimbursement" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear4eligibleamountforreimbursement_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBox78" runat="server"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear5" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear5unitsconsumed" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear5rateperunit" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear5rateperunit_TextChanged1"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear5amountpaid" AutoPostBack="true" OnTextChanged="txt_grdyear5amountpaid_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear5basefixedunitspermonth" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear5eligibleunits" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear5eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear5eligibleamountforreimbursement" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear5eligibleamountforreimbursement_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBox82" runat="server"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear6" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear6unitsconsumed" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear6rateperunit" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear6rateperunit_TextChanged1"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear6amountpaid" AutoPostBack="true" OnTextChanged="txt_grdyear6amountpaid_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear6basefixedunitspermonth" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear6eligibleunits" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear6eligiblerateofreimbursement" Text='<%#Eval("reimbursementrateperunit") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdyear6eligibleamountforreimbursement" AutoPostBack="true" runat="server" OnTextChanged="txt_grdyear6eligibleamountforreimbursement_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="TextBox83" runat="server"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="lbl_grdtoteligibleamount" runat="server"></asp:TextBox>
                                                                <asp:Label ID="lblGmAmount0" runat="server"></asp:Label>
                                                                <asp:Label ID="lblGmAmount" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <table id="tblNewUnit" runat="server" visible="false" bgcolor="White" width="100%" style="font-family: Verdana;">
                                                        <tr>
                                                            <td></td>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Month-year
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Units Consumed
                                                                                    <br />
                                                                in Nos.
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Rate per
                                                                                    <br />
                                                                Units
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Amount Paid as per Bill in Rs.
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Eligible rate Re-imbursement per units
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Eligible amount Re-imbursement per units
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">&nbsp;</th>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear1New" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear1NewFinyear" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox23" AutoPostBack="true" Text='<%#Eval("rateperunit") %>' runat="server" OnTextChanged="TextBox23_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox24" AutoPostBack="true" OnTextChanged="TextBox24_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox25" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox28" runat="server"></asp:TextBox>
                                                            </td>

                                                            
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear2New" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear2NewFinyear" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox50" AutoPostBack="true" Text='<%#Eval("rateperunit") %>' runat="server" OnTextChanged="TextBox50_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox51" AutoPostBack="true" OnTextChanged="TextBox51_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox52" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox29" runat="server"></asp:TextBox>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear3New" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear3NewFinyear" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox63" AutoPostBack="true" Text='<%#Eval("rateperunit") %>' runat="server" OnTextChanged="TextBox63_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox64" AutoPostBack="true" OnTextChanged="TextBox64_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox65" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox26" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox49" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear4New" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear4NewFinyear" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox71" AutoPostBack="true" runat="server" OnTextChanged="TextBox71_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox72" AutoPostBack="true" OnTextChanged="TextBox72_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox73" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox27" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox53" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear5New" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear5NewFinyear" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox79" AutoPostBack="true" runat="server" OnTextChanged="TextBox79_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox80" AutoPostBack="true" OnTextChanged="TextBox80_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox81" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox95" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox54" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear6New" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear6NewFinyear" AutoPostBack="true" OnTextChanged="txt_grdyear1unitsconsumed_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox87" AutoPostBack="true" runat="server" OnTextChanged="TextBox87_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox88" AutoPostBack="true" OnTextChanged="TextBox88_TextChanged" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox89" Text='<%#Eval("basefixedunitspermonth") %>' runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox96" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox55" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;"></td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;"></td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;"></td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;"></td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;"></td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;"></td>

                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <div id="Eligible" runat="server">
                                                <tr id="trEligible" runat="server">
                                                    <td class="auto-style48"></td>
                                                    <td class="auto-style48">Eligible %
                                                    </td>
                                                    <td class="auto-style48">:</td>
                                                    <td class="auto-style48">

                                                        <asp:TextBox ID="TextBox59" AutoPostBack="true" runat="server" class="form-control txtbox txtcomn"
                                                            Height="30px" MaxLength="80" TabIndex="34" Enabled="false" onkeypress="DecimalOnly()" Width="150px" OnTextChanged="TextBox59_TextChanged"></asp:TextBox>

                                                    </td>
                                                </tr>

                                                <tr id="tr4231" runat="server" visible="true">
                                                    <td class="auto-style56"></td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">State Investment Subsidy in Rs.</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                                    <%--  <td style="padding: 5px; margin: 5px; ">
                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn" Height="30px" MaxLength="80" TabIndex="34"  Width="150px" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                    </td>--%>
                                                    <td class="auto-style56">

                                                        <asp:TextBox ID="txt423guideline" runat="server" class="form-control txtbox txtcomn"
                                                            Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:TextBox>
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
                                                <tr id="tr4232" runat="server" visible="true">
                                                    <td class="auto-style55"></td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">Addl Sub. for Women in Rs.</td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">:</td>
                                                    <td class="auto-style55">
                                                        <asp:TextBox ID="txtTSSFCnorms423" AutoPostBack="true" runat="server" class="form-control txtbox txtcomn"
                                                            Height="30px" onkeypress="return inputOnlyNumbers(event)" Enabled="false" MaxLength="80" TabIndex="36"
                                                            Width="150px" OnTextChanged="txtTSSFCnorms423_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="tr4233" runat="server" visible="true">
                                                    <td></td>
                                                    <td style="padding: 5px; margin: 5px;">TOTAL SUBSIDY</td>
                                                    <td style="padding: 5px; margin: 5px;">:</td>
                                                    <td>&nbsp;
                            <asp:TextBox ID="txtvalue424" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" onkeypress="return inputOnlyNumbers(event)" TabIndex="37" Width="150px"></asp:TextBox>
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
                                                <tr id="tr2" runat="server" visible="true">
                                                    <td></td>
                                                    <td style="padding: 5px; margin: 5px;">GM-Recommended Amount</td>
                                                    <td style="padding: 5px; margin: 5px;">:</td>
                                                    <td>&nbsp;
                            <asp:TextBox ID="txtGMAmount" runat="server" class="form-control txtbox txtcomn"
                                Height="30px" MaxLength="80" onkeypress="return inputOnlyNumbers(event)" TabIndex="37" Width="150px"></asp:TextBox>
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

                                                <tr id="tradremarks" runat="server" visible="true">
                                                    <td>4.4</td>
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
                                                            <asp:ListItem Text="--Select--" Value="Select"></asp:ListItem>
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
                                                        <br />
                                                        <asp:Label ID="Label444" runat="server" Visible="False"></asp:Label>
                                                        <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                                            TabIndex="10" Text="Upload" Width="72px" OnClick="btnUpload_Click" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                            </div>
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
            </div>
            <asp:HiddenField runat="server" ID="hdnApplication" />
            <asp:HiddenField runat="server" ID="hdnActualCategory" />
            <asp:HiddenField runat="server" ID="hdnActualTextile" />
            <asp:HiddenField runat="server" ID="hdnTypeOfIndustry" />
            <asp:HiddenField ID="HiddenFieldEnterpriseCategory" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
