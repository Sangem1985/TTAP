<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="TransportSubsidyAppraisalNote.aspx.cs" Inherits="TTAP.UI.Pages.TransportSubsidyAppraisalNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Js/validations.js"></script>
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
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Appraisal Note of Transport Subsidy to Export Intensive Textile Units</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Appraisal Note of Transport Subsidy to Export Intensive Textile Units</h5>
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
                                    <div runat="server" id="divNewUnit" visible="false">
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Total Revenue of the Unit</label>
                                                <asp:TextBox ID="txtRevenueOfUnit" runat="server" class="form-control" OnTextChanged="CalucalteNewUnitSubsidy"
                                                    MaxLength="40" onkeypress="DecimalOnly()" AutoPostBack="true" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Total Export Value of the Unit</label>
                                                <asp:TextBox ID="txtExportValueOfUnit" runat="server" class="form-control" OnTextChanged="CalucalteNewUnitSubsidy"
                                                    MaxLength="40" onkeypress="DecimalOnly()" AutoPostBack="true" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div runat="server" id="divExpansion" visible="false">
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Average Revenue(Last Three Years)</label>
                                                <asp:TextBox ID="txtAverageRevenue" runat="server" OnTextChanged="CalucalteExpansionSubsidy" AutoPostBack="true"
                                                    MaxLength="40" onkeypress="DecimalOnly()" class="form-control" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Revenue After Expansion</label>
                                                <asp:TextBox ID="txtRevenueAfterExpansion" runat="server" class="form-control" OnTextChanged="CalucalteExpansionSubsidy" AutoPostBack="true"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Incremental Revenue</label>
                                                <asp:TextBox ID="txtIncrementalRevenue" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" Enabled="false" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Average Fright Charges(Last Three Years)</label>
                                                <asp:TextBox ID="txtAverageFrightCharges" runat="server" class="form-control" OnTextChanged="CalucalteExpansionSubsidy" AutoPostBack="true"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Total Freight Charges After Expansion</label>
                                                <asp:TextBox ID="txtFreightChargesAfterExpansion" runat="server" class="form-control" OnTextChanged="CalucalteExpansionSubsidy" AutoPostBack="true"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Calculated Subsisdy Amount</label>
                                            <asp:TextBox ID="txtCalcSubsidyAmount" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">GM Recommended Amount</label>
                                            <asp:TextBox ID="txtGMRecommendedAmount" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" OnTextChanged="rdbEligbleType_SelectedIndexChanged" AutoPostBack="true" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="div3">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Eligible Subsidy Amount</label>
                                            <asp:TextBox ID="txtEligibleAmount" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Eligibility Type</label>
                                            <asp:RadioButtonList ID="rdbEligbleType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdbEligbleType_SelectedIndexChanged" AutoPostBack="true" Height="33px"
                                                TabIndex="1" Width="200px" CssClass="form-control">
                                                <asp:ListItem Value="1">Regular</asp:ListItem>
                                                <asp:ListItem Value="2">Belated</asp:ListItem>
                                                <asp:ListItem Value="3">1 Year</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Final Subsidy Amount</label>
                                            <asp:TextBox ID="txtFinalSubsidyAmount" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Forward To</label>
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
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Remarks</label>
                                            <asp:TextBox ID="txtRemarks" runat="server" class="form-control" TextMode="MultiLine"
                                                TabIndex="5" ValidationGroup="group"></asp:TextBox>
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

                                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
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
