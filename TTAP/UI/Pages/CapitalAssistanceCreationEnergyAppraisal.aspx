<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="CapitalAssistanceCreationEnergyAppraisal.aspx.cs" Inherits="TTAP.UI.Pages.CapitalAssistanceCreationEnergyAppraisal" %>

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
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Appraisal Note of Capital Assistance for Creation of Energy, Water and Environmental Conservation Infrastructure</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Appraisal Note of Capital Assistance for <br />Creation of Energy, Water and Environmental Conservation Infrastructure</h5>
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
                                            <label class="form-control" id="lblAddress" aria-multiline="true" runat="server"></label>
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
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label4" runat="server">TextTile Type</label>
                                            <label class="form-control" id="lblTextTileType" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Promoter details in case eligible for additional subsidy</label>
                                            <label class="form-control" id="lblcategory" runat="server"></label>
                                        </div>
                                    </div>

                                    <h6 style="margin-left: 13px;"><b>Details of Equipment Purchased for Cleaner Production Measures</b></h6>
                                    <div class="row">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="GvEquipmentDtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowDataBound="GvEquipmentDtls_RowDataBound">
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
                                                    <asp:TemplateField HeaderText="Name of the Equipment">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNameoftheEquipment" runat="server" Text='<%# Bind("NameoftheEquipment") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type of the Equipment" ItemStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTypeoftheEquipment" Visible="false" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                            <asp:Label ID="lblTypeofEquipmentId" Visible="false" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                            <asp:DropDownList runat="server" ID="ddlTypeofEquipment" OnSelectedIndexChanged="ddlTypeofEquipment_SelectedIndexChanged" AutoPostBack="true" class="form-control">
                                                                <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="1">Energy Conservation Infra</asp:ListItem>
                                                                <asp:ListItem Value="2">Water Conservation Infra</asp:ListItem>
                                                                <asp:ListItem Value="3">Environmental Conservation Infra</asp:ListItem>
                                                                <asp:ListItem Value="4">Common Effluent Treatment Plant at Industrial Park / Cluster</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Name & Address of Supplier">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentNameAddressofSupplier" runat="server" Text='<%# Bind("EquipmentNameAddressofSupplier") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Invoice No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentInvoiceNo" runat="server" Text='<%# Bind("EquipmentInvoiceNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="InvoiceDate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentInvoiceDate" runat="server" Text='<%# Bind("EquipmentInvoiceDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Date Of Landing">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentDateOfLanding" runat="server" Text='<%# Bind("EquipmentDateOfLanding") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <%-- <asp:TemplateField HeaderText="Date Of Commissioning">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentDateOfCommissioning" runat="server" Text='<%# Bind("EquipmentDateOfCommissioning") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Way Bill Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentWayBillNumber" runat="server" Text='<%# Bind("EquipmentWayBillNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Way Bill Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentDateOfWayBill" runat="server" Text='<%# Bind("EquipmentDateOfWayBill") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Cost of Equipment">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCostofEquipment" runat="server" Text='<%# Bind("CostofEquipment") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="CGST (Rs)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentcgst" runat="server" Text='<%# Bind("Equipmentcgst") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SGST (Rs)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentsgst" runat="server" Text='<%# Bind("Equipmentsgst") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Freight Charges (Rs)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentFreightCharges" runat="server" Text='<%# Bind("EquipmentFreightCharges") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Initiation Charges (Rs)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentInitiationCharges" runat="server" Text='<%# Bind("EquipmentInitiationCharges") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Total (Rs)">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>--%>
                                                            <asp:TextBox ID="txtTotal" onkeypress="DecimalOnly()" CssClass="form-control" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Remarks If any">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtEqpRemarks" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Equipment ID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipment_ID" runat="server" Text='<%# Bind("Equipment_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="div1">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Total Cost of Equipment for Energy Conservation Infra</label>
                                            <asp:TextBox ID="txtEnergyEquipmentTotal" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Total Cost of Equipment for Water Conservation Infra</label>
                                            <asp:TextBox ID="txtWaterEquipmentTotal" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Total Cost of Equipment for Environmental Conservation Infra</label>
                                            <asp:TextBox ID="txttxtEnvironmentalEquipmentTotal" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Total Cost of CET Plant at Industrial Park / Cluster</label>
                                            <asp:TextBox ID="txttxtEffluentTreatmentCotal" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="divClaimAmount">
                                        <h6 class="text-blue font-bold col col-sm-12 mt-3">Eligible Subsidy 40% of the cost and restricted to Rs. 50 lakhs(Energy, Water and Environmental Conservation Infrastructure)</h6>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Cost of Equipment for Energy Conservation Infra</label>
                                            <asp:TextBox ID="txtEnergyEquipment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Cost of Equipment for Water Conservation Infra</label>
                                            <asp:TextBox ID="txtWaterEquipment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Cost of Equipment for Environmental Conservation Infra</label>
                                            <asp:TextBox ID="txtEnvironmentalEquipment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="div4">
                                        <h6 class="text-blue font-bold col col-sm-12 mt-3">Amount of Subsidy Claimed for Common Effluent Treatment Plant </h6>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Cost of Common Effluent Treatment Plant at Industrial Park / Cluster</label>
                                            <asp:TextBox ID="txtEffluentTreatment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-12 form-group">
                                            <b>Note : 1). Handloom:</b> 70% restricted to Rs. 2 Cr. <b>2). Others: </b>50% restricted to Rs. 10 Cr.
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="div2">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Total Calculated Subsidy Amount</label>
                                            <asp:TextBox ID="txtSysCalculatedAmount" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">GM Recommended Amount</label>
                                            <asp:TextBox ID="txtGMRecommendedAmount" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" Text="5000000" TabIndex="5" Enabled="false" ValidationGroup="group"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row" runat="server" id="div3">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Eligibility Type</label>
                                            <asp:RadioButtonList ID="rdbEligbleType" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="ddlTypeofEquipment_SelectedIndexChanged" AutoPostBack="true" Height="33px"
                                                TabIndex="1" Width="200px" CssClass="form-control">
                                                <asp:ListItem Value="Y">Regular</asp:ListItem>
                                                <asp:ListItem Value="N">Belated</asp:ListItem>
                                                <asp:ListItem Value="0">1 Year</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Eligible Subsidy Amount</label>
                                            <asp:TextBox ID="txtEligibleAmount" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" id="div5">
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
                                            <asp:TextBox ID="txtRemarks" runat="server" class="form-control"
                                                MaxLength="40"  TextMode="MultiLine"></asp:TextBox>
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
                                                    <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-xs btn-warning" Height="29px"
                                                        TabIndex="10" Text="Upload" Width="80px" OnClick="btnUpload_Click" />
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
            <asp:HiddenField runat="server" ID="hdnTextileType" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
