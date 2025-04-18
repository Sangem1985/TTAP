﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="PowerCostAppraisalNote.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="TTAP.UI.Pages.PowerCostAppraisalNote" %>

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
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Apprisal Note of Reimbursement of Power Consumption Charges</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Apprisal Note of Reimbursement of Power Consumption Charges</h5>
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
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label8" runat="server">Type of Textile as Per Inspection</label>
                                            <asp:RadioButtonList ID="rdbTypeofTextile" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rdbTypeofTextile_SelectedIndexChanged">
                                                <asp:ListItem Value="1">Conventional</asp:ListItem>
                                                <asp:ListItem Value="2">Technical</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label13" runat="server">Category as Per Inspection</label>
                                            <asp:RadioButtonList ID="rdbCategory" runat="server" RepeatDirection="Horizontal"
                                                AutoPostBack="True" OnSelectedIndexChanged="rdbTypeofTextile_SelectedIndexChanged">
                                                <asp:ListItem Value="A1">A1</asp:ListItem>
                                                <asp:ListItem Value="A2">A2</asp:ListItem>
                                                <asp:ListItem Value="A3">A3</asp:ListItem>
                                                <asp:ListItem Value="A4">A4</asp:ListItem>
                                                <asp:ListItem Value="A5">A5</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label15" runat="server">Nature of Industry as per Inspection</label>
                                            <asp:DropDownList ID="ddlNature" runat="server" AutoPostBack="true" class="form-control txtbox" OnSelectedIndexChanged="rdbTypeofTextile_SelectedIndexChanged">
                                                <asp:ListItem Text="Ginning" Value="Ginning"></asp:ListItem>
                                                <asp:ListItem Text="Spinning" Value="Spinning"></asp:ListItem>
                                                <asp:ListItem Text="Weaving" Value="Weaving"></asp:ListItem>
                                                <asp:ListItem Text="Garmenting" Value="Garmenting"></asp:ListItem>
                                                <asp:ListItem Text="Processing" Value="Processing"></asp:ListItem>
                                                <asp:ListItem Text="Pressing Mills" Value="Pressing Mills"></asp:ListItem>
                                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <table tyle="width: 100%">

                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <b>CLAIM PERIOD : </b></td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <asp:Label runat="server" ID="lblClaimPeroid" Style="font-weight: bold;">Cliam Peroid</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row" runat="server" id="divLastThreeDtls" visible="false">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px"></td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <b>Last Three Years Details</b></td>

                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <table runat="server" bgcolor="White" width="100%" style="font-family: Verdana; border: solid;">
                                                        <tr>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Financial Year
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">No of Units Utilised
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Rate per Unit
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Total Paid by the unit in Rs
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:DropDownList ID="ddlFinYear1" CssClass="form-control" runat="server">
                                                                    <asp:ListItem Value="1" Text="2024-2025"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtUtilizedUnits1" onkeypress="return isDecimal(event)" AutoPostBack="true" OnTextChanged="CalLastThree" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtRatePerUnit1" onkeypress="return isDecimal(event)" AutoPostBack="true" OnTextChanged="CalLastThree" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtTotalPaid1" onkeypress="return isDecimal(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:DropDownList ID="ddlFinYear2" CssClass="form-control" runat="server">
                                                                    <asp:ListItem Value="1" Text="2024-2025"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtUtilizedUnits2" AutoPostBack="true" onkeypress="return isDecimal(event)" OnTextChanged="CalLastThree" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtRatePerUnit2" onkeypress="return isDecimal(event)" AutoPostBack="true" OnTextChanged="CalLastThree" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtTotalPaid2" onkeypress="return isDecimal(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:DropDownList ID="ddlFinYear3" CssClass="form-control" runat="server">
                                                                    <asp:ListItem Value="1" Text="2024-2025"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtUtilizedUnits3" onkeypress="return isDecimal(event)" AutoPostBack="true" OnTextChanged="CalLastThree" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtRatePerUnit3" onkeypress="return isDecimal(event)" AutoPostBack="true" OnTextChanged="CalLastThree" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txtTotalPaid3" onkeypress="return isDecimal(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <br />
                                    <div class="row" runat="server" id="divExpansionDtls" visible="false">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label21" runat="server">Total units consumed prior to 3 Years </label>
                                            <asp:TextBox runat="server" CssClass="form-control" onkeypress="return isDecimal(event)" ID="txtPrior3Yrs"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label22" runat="server">Average units EM </label>
                                            <asp:TextBox runat="server" CssClass="form-control" onkeypress="return isDecimal(event)" ID="txtAvgUnitsEM"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label23" runat="server">Base power consumption fixed per year </label>
                                            <asp:TextBox runat="server" onkeypress="return isDecimal(event)" CssClass="form-control" ID="txtBasePower"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label24" runat="server">Per month</label>
                                            <asp:TextBox runat="server" onkeypress="return isDecimal(event)" CssClass="form-control" ID="txtPerMonth"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="divNewMonth" runat="server" visible="false">
                                        <table style="width: 100%">
                                            <tr>
                                                <asp:Repeater ID="rptFinancialYears" runat="server">
                                                    <ItemTemplate>
                                                        <h5>Month Wise Details - <%# Eval("FinancialYearText") %></h5>
                                                        <asp:TextBox runat="server" ID="txtFinYear" Text='<%# Eval("FinancialYearId") %>' Visible="false" CssClass="form-control"></asp:TextBox>
                                                        <asp:TextBox runat="server" ID="txtHalfYearType" Text='<%# Eval("HalfYearType") %>' Visible="false" CssClass="form-control"></asp:TextBox>
                                                        <asp:Repeater ID="rptMonths" runat="server" OnItemDataBound="rptMonths_ItemDataBound" DataSource='<%# Eval("Months") %>'>
                                                            <HeaderTemplate>
                                                                <table class="table table-bordered">
                                                                    <tr>
                                                                        <th>Month</th>
                                                                        <th>Financial Year</th>
                                                                        <th>Units Consumed</th>
                                                                        <th>Amount Paid as per Bill</th>
                                                                        <asp:PlaceHolder ID="phThBaseFixed" runat="server">
                                                                            <th>Base fixed per month in units</th>
                                                                        </asp:PlaceHolder>
                                                                        <asp:PlaceHolder ID="phThEligibleUnitsBase" runat="server">
                                                                            <th>Eligible Units i.e over & above Base</th>
                                                                        </asp:PlaceHolder>
                                                                        <th>Eligible rate Re-imbursement</th>
                                                                        <th>Eligible amount Re-imbursement</th>
                                                                    </tr>
                                                            </HeaderTemplate>

                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="txtMonth" Enabled="false" runat="server" CssClass="form-control" Text='<%# Eval("Month") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtYear" ReadOnly="true" runat="server" CssClass="form-control" Text='<%# Eval("FinancialYear") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtUnits" OnTextChanged="txtUnits_TextChanged" onkeypress="return isDecimal(event)" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox></td>
                                                                    <asp:PlaceHolder ID="phTdBaseFixed" runat="server">
                                                                        <td>
                                                                            <asp:TextBox ID="txtBaseFixed" OnTextChanged="txtUnits_TextChanged" onkeypress="return isDecimal(event)" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </asp:PlaceHolder>
                                                                    <asp:PlaceHolder ID="phTdEligibleUnitsBase" runat="server">
                                                                        <td>
                                                                            <asp:TextBox ID="txtEligibleUnitsBase" OnTextChanged="txtUnits_TextChanged" onkeypress="return isDecimal(event)" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </asp:PlaceHolder>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEligibleRate" OnTextChanged="txtUnits_TextChanged"  onkeypress="return isDecimal(event)" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtEligibleAmount" runat="server" AutoPostBack="true" onkeypress="return isDecimal(event)" OnTextChanged="txtEligibleAmount_TextChanged" CssClass="form-control"></asp:TextBox></td>
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
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tr>
                                            <tr>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label" id="Label4" runat="server">Total Amount</label>
                                                    <%--<label class="form-control" id="lblTotalAmount" runat="server"></label>--%>
                                                    <asp:TextBox ID="lblTotalAmount" Enabled="true" onkeypress="return isDecimal(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                </div>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="row">

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Eligibility Type</label>
                                            <asp:RadioButtonList ID="rdbEligibleType" OnSelectedIndexChanged="rdbEligibleType_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true"
                                                RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Text="Regular" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Belated" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="One year" Value="3"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label14" runat="server">Total Eligible Amount</label>

                                            <asp:TextBox ID="lblEligibleAmount" Enabled="true" onkeypress="return isDecimal(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label11" runat="server">GM Recommended Amount</label>
                                            <label class="form-control" id="lblGMAmount" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label16" runat="server">Final Eligible Subsidy Amount in Rs</label>

                                            <asp:TextBox ID="lblFinalElgAmount" Enabled="true" onkeypress="return isDecimal(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label17" runat="server">Remarks</label>
                                            <asp:TextBox ID="txtRemarks" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label20" runat="server">Forward To</label>
                                            <asp:DropDownList ID="ddlDepartment" runat="server" class="form-control txtbox">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="SUPDT" Value="SUPDT"></asp:ListItem>
                                                <asp:ListItem Text="AD" Value="AD"></asp:ListItem>
                                                <asp:ListItem Text="DD" Value="DD"></asp:ListItem>
                                                <asp:ListItem Text="JD" Value="JD"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
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
                                                    <asp:Button ID="btnUpload" OnClick="btnUpload_Click" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
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

                                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
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
