<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="CapitalAssistanceCreationEnergy.aspx.cs" Inherits="TTAP.UI.Pages.CapitalAssistanceCreationEnergy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <asp:PostBackTrigger ControlID="btnDocumentaryproof" />
            <asp:PostBackTrigger ControlID="btnProjectCompletion" />
            <asp:PostBackTrigger ControlID="btnCopyofdocuments" />
            <asp:PostBackTrigger ControlID="btnCopyofApproval" />
            <asp:PostBackTrigger ControlID="btnClearanceLocal" />
            <asp:PostBackTrigger ControlID="btnConsenttoEstablish" />
            <asp:PostBackTrigger ControlID="btnDetailedProject" />
            <asp:PostBackTrigger ControlID="btnLandregistration" />
            <asp:PostBackTrigger ControlID="btnCharteredEngineerCertificate" />
            <asp:PostBackTrigger ControlID="btnProjectCertificate" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Capital Assistance</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <div class="row-fluid">
                            <%-- <div class="col-sm-12 offset-md-1 col-md-10 col-lg-8 offset-lg-2 frm-form box-content py-3 font-medium title5">--%>
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – III: Capital Assistance for Creation of Energy, Water and Environmental Conservation Infrastructure</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label1" runat="server">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2" runat="server">Common Application Number</label>
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
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <label class="control-label label-required" id="Label9" runat="server">Type of Infrastructure Created</label>
                                            <asp:CheckBoxList ID="chkTypeofInfrastructure" runat="server" CssClass="checkbox" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Energy Conservation" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Water Conservation" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Environmental Conservation" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Common Effluent Treatment Plant at Cluster / Industrial Park" Value="4"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <div class="row">
                                                <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="control-label label-required" id="Label10" runat="server">Is the CETP created</label>
                                                </div>
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:RadioButtonList ID="RbtnCETPcreated" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Yes" Selected="True" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <div class="row">
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                    <label class="control-label label-required" id="Label4" runat="server">TextTile Type</label>
                                                </div>
                                                <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:RadioButtonList ID="RbtnTextTileType" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server">
                                                        <asp:ListItem Text="Handloom" Selected="True" Value="HD"></asp:ListItem>
                                                        <asp:ListItem Text="Others" Value="OT"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Government Scheme for CETP</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">Total Cost – Capital (In Rs)</label>
                                            <asp:TextBox ID="txtTotalCostCapital" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">Operational Cost per MLD of Input Water (In Rs)</label>
                                            <asp:TextBox ID="txtMLDofInputWater" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Percentage Share</h6>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">GOI %</label>
                                            <asp:TextBox ID="txtGOI" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">State Govt %</label>
                                            <asp:TextBox ID="txtStateGovt" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Beneficiary %</label>
                                            <asp:TextBox ID="txtBeneficiary" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Bank %</label>
                                            <asp:TextBox ID="txtBank" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                    </div>
                                   
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <asp:Label ID="lblDetailsofPatners" runat="server" CssClass="label-required text-blue" Font-Bold="True">
                                              Details of Equipment Purchased for Cleaner Production Measures</asp:Label>
                                        </div>
                                        <div class="row w-100 m-0" id="DivDirectorDetails" runat="server">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Type of the Equipment</label>
                                                <asp:DropDownList runat="server" ID="ddlTypeofEquipment" class="form-control">
                                                    <asp:ListItem Value="0" Selected="True">--Select--</asp:ListItem>
                                                    <asp:ListItem Value="1">Energy Conservation Infra</asp:ListItem>
                                                    <asp:ListItem Value="2">Water Conservation Infra</asp:ListItem>
                                                    <asp:ListItem Value="3">Environmental Conservation Infra</asp:ListItem>
                                                    <asp:ListItem Value="4">Common Effluent Treatment Plant at Industrial Park / Cluster</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Name of the Equipment</label>
                                                <asp:TextBox ID="txtNameoftheEquipment" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Name & Address of Supplier</label>
                                                <asp:TextBox ID="txtEquipmentNameAddressofSupplier" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Invoice No</label>
                                                <asp:TextBox ID="txtEquipmentInvoiceNo" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Invoice Date</label>
                                                <asp:TextBox ID="txtEquipmentInvoiceDate" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Date Of Landing</label>
                                                <asp:TextBox ID="txtEquipmentDateOfLanding" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Date of Commissioning</label>
                                                <asp:TextBox ID="txtEquipmentDateOfCommissioning" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Way Bill Number</label>
                                                <asp:TextBox ID="txtEquipmentWayBillNumber" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Way Bill Date</label>
                                                <asp:TextBox ID="txtEquipmentDateOfWayBill" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Cost of Equipment(in Rs)</label>
                                                <asp:TextBox ID="txtCostofEquipment" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                     ValidationGroup="group"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">CGST(in Rs)</label>
                                                <asp:TextBox ID="txtEquipmentcgst" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                     ValidationGroup="group" ></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">SGST(in Rs)</label>
                                                <asp:TextBox ID="txtEquipmentsgst" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                     ValidationGroup="group" ></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Freight Charges(in Rs)</label>
                                                <asp:TextBox ID="txtEquipmentFreightCharges" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                     ValidationGroup="group" ></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Initiation Charges(in Rs)</label>
                                                <asp:TextBox ID="txtEquipmentInitiationCharges" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                     ValidationGroup="group" AutoPostBack="true" OnTextChanged="txtCostofEquipment_TextChanged"></asp:TextBox>
                                            </div>
                                             <div class="col-sm-3 form-group">
                                                <label class="control-label label-required">Total Cost(in Rs)</label>
                                                <asp:TextBox ID="txttotal" runat="server" ReadOnly="true" class="form-control" onkeypress="DecimalOnly()"
                                                     ValidationGroup="group"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnEquipmentDtls" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnEquipmentDtls_Click" />
                                                <asp:Button ID="btnClearEquipmentDtlsDtls" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="GvEquipmentDtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowDataBound="GvEquipmentDtls_RowDataBound" OnRowCommand="GvEquipmentDtls_RowCommand">
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
                                                    <asp:TemplateField HeaderText="Type of the Equipment">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTypeoftheEquipment" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                                            <asp:Label ID="lblTypeofEquipmentId" Visible="false" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name & Address of Supplier">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentNameAddressofSupplier" runat="server" Text='<%# Bind("EquipmentNameAddressofSupplier") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
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
                                                    <asp:TemplateField HeaderText="Date Of Landing">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEquipmentDateOfLanding" runat="server" Text='<%# Bind("EquipmentDateOfLanding") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Of Commissioning">
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
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total (Rs)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
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
                                                            <asp:Label ID="lblEquipment_ID" runat="server" Text='<%# Bind("Equipment_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                     <div class="row" runat="server" id="divClaimAmount">
                                        <h6 class="text-blue font-bold col col-sm-12 mt-3">Eligible Investment for Capital Subsidy (Amount in Rupees) Subsidy 40% of the cost and restricted to Rs. 50 lakhs)</h6>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Cost of Equipment for Energy Conservation Infra</label>
                                            <asp:TextBox ID="txtEnergyEquipment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" style="color: black;font-family: 'Montserrat-Bold';background-color: darkseagreen;" Enabled="false" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Cost of Equipment for Water Conservation Infra</label>
                                            <asp:TextBox ID="txtWaterEquipment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" style="color: black;font-family: 'Montserrat-Bold';background-color: gainsboro;" Enabled="false" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Cost of Equipment for Environmental Conservation Infra</label>
                                            <asp:TextBox ID="txtEnvironmentalEquipment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" style="color: black;font-family: 'Montserrat-Bold';background-color: darkkhaki;" Enabled="false" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Cost of Common Effluent Treatment Plant at Industrial Park / Cluster</label>
                                            <asp:TextBox ID="txtEffluentTreatment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" style="color: black;font-family: 'Montserrat-Bold';background-color: darkgrey;" Enabled="false" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-12 form-group">
                                            <b>Note : 1). Handloom:</b> 70% restricted to Rs. 2 Cr. <b> 2). Others: </b> 50% restricted to Rs. 10 Cr.
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-7 form-group">
                                            <label class="control-label label-required">Amount of Subsidy Claimed for Creation of Energy, Water and Environmental Conservation Infrastructure</label>
                                            <asp:TextBox ID="txtSubsidyClaimedEnergyWaterEnvironmental" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-5 form-group">
                                            <label class="control-label label-required">Amount of Subsidy Claimed for Common Effluent Treatment Plant</label>
                                            <asp:TextBox ID="txtSubsidyClaimedforCommonEffluentTreatment" runat="server" class="form-control"
                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
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
                                                <tr id="trEnclosures" runat="server" class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 50%">Land registration and Land Use documents.</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuLandregistration" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                               <asp:Button ID="btnLandregistration" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnLandregistration_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyLandregistration" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr id="tr1" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Detailed Project Report for CETP  ETP  wastewater recycling and cost of pollution control devices .<br />
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuDetailedProject" runat="server" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnDetailedProject" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnDetailedProject_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyDetailedProject" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>

                                                <tr id="tr2" runat="server" class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Consent to Establish and Operate from Pollution Control Board .
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuConsenttoEstablish" runat="server" CssClass="CS" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnConsenttoEstablish" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnConsenttoEstablish_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyConsenttoEstablish" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr id="tr4" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Clearance from Local Authority.</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuClearanceLocal" runat="server" CssClass="CS" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnClearanceLocal" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnClearanceLocal_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyClearanceLocal" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>

                                                <tr id="tr3" runat="server" class="GridviewScrollC1Item">
                                                    <td align="center">5</td>
                                                    <td align="left">Copy of Approval letter from Government of India, (if applicable) .
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCopyofApproval" runat="server" CssClass="CS" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCopyofApproval" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnCopyofApproval_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyCopyofApproval" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>

                                                <tr id="tr5" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">6</td>
                                                    <td align="left">Copy of documents (Receipts, Bills, Vouchers etc.) indicating the Payments towards Components for setting up Energy, Water and Environmental Conservation Infrastructure
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCopyofdocuments" runat="server" CssClass="CS" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnCopyofdocuments" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnCopyofdocuments_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyCopyofdocuments" runat="server" CssClass="LBLBLACK"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr id="tr6" runat="server" class="GridviewScrollC1Item">
                                                    <td align="center">7</td>
                                                    <td align="left">Project Completion Certificate from concerned Agencies  Departments
                                    
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuProjectCompletion" runat="server" CssClass="CS" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnProjectCompletion" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnProjectCompletion_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyProjectCompletion" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr7" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">Documentary proof of nature of activity  business in case of Handloom Cluster</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuDocumentaryproof" runat="server" CssClass="CS" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnDocumentaryproof" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnDocumentaryproof_Click" Text="Upload" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyDocumentaryproof" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr8" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">9</td>
                                                    <td align="left">Chartered Engineer Certificate for valuation of construction value of project</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCharteredEngineerCertificate" runat="server" CssClass="CS" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnCharteredEngineerCertificate" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnCharteredEngineerCertificate_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyCharteredEngineerCertificate" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr id="tr9" runat="server" class="GridviewScrollC1Item2">
                                                    <td align="center">10</td>
                                                    <td align="left">Completion of Project Certificate from concerned authority</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuProjectCertificate" runat="server" CssClass="CS" />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:Button ID="btnProjectCertificate" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnProjectCertificate_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyProjectCertificate" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
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
                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success" TabIndex="10" Visible="false" Text="Submit" ValidationGroup="group" />
                                        <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-blue m-2" OnClick="BtnPrevious_Click" TabIndex="10" Text="Previous" />
                                        <asp:Button ID="BtnNext" runat="server" CssClass="btn btn-success m-2" Enabled="true" OnClick="BtnNext_Click" TabIndex="10" Text="Save & Next" ValidationGroup="group" />
                                        <%-- &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Enabled="false" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />--%>
                                    </div>
                                    <div class="row">
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
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtEquipmentInvoiceDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfLanding']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfCommissioning']").keydown(function () {
            return false;
        });

        $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfWayBill']").keydown(function () {
            return false;
        });



        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[type=text]").attr('autocomplete', 'off');
            $("input[id$='ContentPlaceHolder1_txtEquipmentInvoiceDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfLanding']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
            $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfCommissioning']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });

            $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfWayBill']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtEquipmentInvoiceDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });

            $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfLanding']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
            $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfCommissioning']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });

            $("input[id$='ContentPlaceHolder1_txtEquipmentDateOfWayBill']").datepicker(
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

