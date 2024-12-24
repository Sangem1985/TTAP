<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmTransportSubsidy.aspx.cs" Inherits="TTAP.UI.Pages.frmTransportSubsidy" %>

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
            <asp:PostBackTrigger ControlID="btnStatementofrawmaterialspurchased" />
            <asp:PostBackTrigger ControlID="btnutilizationRawMaterials" />
            <asp:PostBackTrigger ControlID="btnStatementFinishedProducts" />
            <asp:PostBackTrigger ControlID="btnIECImportIndustrialInvoice" />
            <asp:PostBackTrigger ControlID="btnRCvehiclestransportingrawmaterials" />
            <asp:PostBackTrigger ControlID="btnTrucksTransportcompanies" />
            <asp:PostBackTrigger ControlID="btnpaymentmadetoTransporters" />
            <asp:PostBackTrigger ControlID="btnBankACNoName" />
            <asp:PostBackTrigger ControlID="btnBillsChallanconsignment" />
            <asp:PostBackTrigger ControlID="btnRailwayfreightcertificate" />
            <asp:PostBackTrigger ControlID="btnRoaddistancecertificate" />
            <asp:PostBackTrigger ControlID="btnBankStatement" />
            <asp:PostBackTrigger ControlID="btnBillsChallanconsignmentfinishedgoods" />
            <asp:PostBackTrigger ControlID="btntransportersforcarryingFP" />
            <asp:PostBackTrigger ControlID="btnCertificatefromExciseDept" />
            <asp:PostBackTrigger ControlID="btnconsignmentsoldtotheparty" />
            <asp:PostBackTrigger ControlID="btnaddressofpurchasers" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Export Intensive Textile / Apparel Units</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – X : Transport Subsidy to Export Intensive Textile Units</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2" runat="server">TSIPass-UID Number</label>
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
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label12" runat="server">Date Of Incorporation of Unit</label>
                                            <asp:TextBox ID="txtDateofEstablishmentofUnit" Enabled="false" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-9 form-group">
                                            <label class="control-label" id="Label5" runat="server">Nature of Business/Business Type</label>
                                            <asp:CheckBoxList ID="chkNatureofBusiness" runat="server" CssClass="checkbox" RepeatDirection="Horizontal">
                                                <asp:ListItem Text="Export Oriented Unit" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Supplier to export oriented Industry/Enterprise(Final product to be exported)" Value="2"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label13" runat="server">Nearest Airport</label>
                                            <asp:TextBox ID="txtNearestAirport" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label17" runat="server">Nearest Seaport</label>
                                            <asp:TextBox ID="txtNearestSeaport" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Nearest Dry Port</label>
                                            <asp:TextBox ID="txtNearestDryPort" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label11" runat="server">Percentage of Total Revenue as Exports</label>
                                            <asp:TextBox ID="txtPercentageTotalRevenue" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1556" runat="server">Type of Export</label>
                                            <asp:DropDownList ID="ddlTypeofExport" runat="server" class="form-control txtbox">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Direct"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Merchant"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Deemed"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label21" runat="server">Mode of Transport</label>
                                            <asp:DropDownList ID="ddlModeofTransport" runat="server" class="form-control txtbox">
                                                <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="By Road"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="By Rail"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="By Air"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="By Sea"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <%--<div class="col-sm-5 form-group">
                                            <label class="control-label" id="Label1" runat="server">Detail of Export Revenue for Last 3 Years and its Average</label>
                                            <asp:TextBox ID="txtExportRevenue" TextMode="MultiLine" Height="50px" class="form-control" runat="server"></asp:TextBox>
                                        </div>--%>
                                    </div>

                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Total Revenue for the Current Financial Year</h6>
                                        <div class="row w-100 m-0" id="DivCurrentFinancialYear" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label1" runat="server">Financial Year</label>
                                                <asp:DropDownList ID="ddlCurrentClaimFinancialYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label19" runat="server">1st/2nd Half Year</label>
                                                <asp:DropDownList ID="ddlCurrentClaimhalfYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label20" runat="server">Claim made for the Year</label>
                                                <asp:DropDownList ID="ddlCurrentClaimmadeYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st Year"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd Year"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="3rd Year"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="4th Year"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="5th Year"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label18" runat="server">Total Production (in Rs.)</label>
                                                <asp:TextBox ID="txtCurrentTotalproduction" runat="server" onkeypress="DecimalOnly()" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Total Sale Revenue (in Rs.)</label>
                                                <asp:TextBox ID="txtCurrentTotalSaleRevenue" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Total Export Revenue (in Rs.)</label>
                                                <asp:TextBox ID="txtCurrentTotalExportRevenue" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Freight Charges on Purchase of Raw Material (in Rs.)</label>
                                                <asp:TextBox ID="txtCurrentFreightPurchaseRawMaterial" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Freight Charges on Export of Finished Goods (in Rs.)</label>
                                                <asp:TextBox ID="txtCurrentFreightExportFinishedGoods" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnCurrentClaimadd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnCurrentClaimadd_Click" />
                                                <asp:Button ID="btnCurrentClaimClear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="GvCurrentClaimPeriod" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="GvCurrentClaimPeriod_RowCommand">
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
                                                    <asp:TemplateField HeaderText="Financial Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCurrentFinancialYearText" runat="server" Text='<%#Eval("FinancialYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="1st/2nd half Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCurrentTypeOfFinancialYearText" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Claim Made for the Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblClaimMadefortheYear" runat="server" Text='<%#Eval("CurrentClaimmadeYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Production (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalProductionValue" runat="server" Text='<%#Eval("Totalproduction") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Sale Revenue (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalSaleRevenue" runat="server" Text='<%#Eval("TotalSaleRevenue") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Export Revenue (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalExportRevenue" runat="server" Text='<%#Eval("TotalExportRevenue") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Freight Charges on Purchase of Raw Material (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFreightPurchaseRawMaterial" runat="server" Text='<%#Eval("FreightPurchaseRawMaterial") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Freight Charges on Export of Finished Goods (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFreightChargesFinishedGoods" runat="server" Text='<%#Eval("FreightExportFinishedGoods") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnCurrentFinancialEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlCurrentFinancialDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCurrentFinancialYearID" runat="server" Visible="false" Text='<%# Bind("FinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblCurrentTypeOfFinancialYear" runat="server" Visible="false" Text='<%# Bind("TypeOfFinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblClaimMadefortheYearID" runat="server" Visible="false" Text='<%# Bind("CurrentClaimmadeYear") %>'></asp:Label>
                                                            <asp:Label ID="lblCurrentClaimFinanciaID" runat="server" Text='<%# Bind("CurrentClaimFinancialID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Export Revenue for Last 3 Years and its Average</h6>
                                        <div class="row w-100 m-0" id="DivExportRevenueDetails" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label9" runat="server">Year</label>
                                                <asp:DropDownList ID="ddlLast3Years" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label14" runat="server">Production Value (in Rs.)</label>
                                                <asp:TextBox ID="txtProductionValue" runat="server" onkeypress="DecimalOnly()" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Sale Revenue (in Rs.)</label>
                                                <asp:TextBox ID="txtSaleRevenue" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Export Sales Value (in Rs.)</label>
                                                <asp:TextBox ID="txtExportSalesValue" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Freight Charges (in Rs.)</label>
                                                <asp:TextBox ID="txtFreightCharges" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnExportRevenueAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnExportRevenueAdd_Click" />
                                                <asp:Button ID="btnExportRevenueClear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvExportRevenueDetails" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="gvExportRevenueDetails_RowCommand">
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
                                                    <asp:TemplateField HeaderText="Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExportRevenueYearText" runat="server" Text='<%#Eval("FinancialYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Production Value (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProductionValue" runat="server" Text='<%#Eval("ProductionValue") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sale Revenue (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSaleRevenue" runat="server" Text='<%#Eval("SaleRevenue") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Export Sales Value (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExportSalesValue" runat="server" Text='<%#Eval("ExportSalesValue") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Freight Charges (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFreightCharges" runat="server" Text='<%#Eval("FreightCharges") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlExportRevenueEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlExportRevenueDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblExportRevenueYear" runat="server" Visible="false" Text='<%# Bind("FinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblExportRevenueID" runat="server" Text='<%# Bind("ExportRevenueID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lbl" runat="server">Details of Raw Materials i.e. (Imported)</label>
                                            <asp:TextBox ID="txtDetailsRawMaterialsImported" TextMode="MultiLine" Height="50px" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="LabelDetails1" runat="server">Details of Finished Products i.e. (Exported by your Unit/Industry/Enterprise etc)</label>
                                            <asp:TextBox ID="txtFinishedProducts" TextMode="MultiLine" Height="50px" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <label class="control-label" id="Label8" runat="server">
                                                Details of Finished Products Exported by the Unit/Industry/Enterprise etc.( to which your Unit is the supplies the materials)</label>
                                            <asp:TextBox ID="txtFinishedProductsExported" TextMode="MultiLine" Height="50px" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Transport Subsidy reimbursement already availed by Enterprise from the Date of Commencement of Production</div>
                                        </div>
                                        <div class="row w-100 m-0" id="DivSGSTReimbursement" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="lblfinyr" runat="server">Financial Year</label>
                                                <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label16" runat="server">1st/2nd half Year</label>
                                                <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label15" runat="server">Amount(In Rupees)</label>
                                                <asp:TextBox ID="txtAmountPaid" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnSGSTReimbursementAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnSGSTReimbursementAdd_Click" />
                                                <asp:Button ID="Button3" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="grdSGSTReimbursement" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="grdSGSTReimbursement_RowCommand">
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
                                                    <asp:TemplateField HeaderText="Financial Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEnergyConsumedFinancialYear" runat="server" Text='<%#Eval("FinancialYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="1st/2nd half Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount (In Rupees)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEnergyConsumedAmountPaid" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
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
                                                            <asp:Label ID="lblEnergyFinancialYearID" runat="server" Visible="false" Text='<%# Bind("FinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblTypeOfFinancialYear" runat="server" Visible="false" Text='<%# Bind("TypeOfFinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblEnergyconsumedID" runat="server" Text='<%# Bind("Export_Intensive_Textile_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Total Claim Amount (In Rs)</label>
                                            <asp:TextBox ID="txtCurrentClaim" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
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
                                                    <td align="left" style="width: 50%">Statement of raw materials purchased (imported) during the period (as per Annexure-I)</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuStatementofrawmaterialspurchased" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                         <asp:Button ID="btnStatementofrawmaterialspurchased" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnStatementofrawmaterialspurchased_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyStatementofrawmaterialspurchased" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Particulars of utilization of Raw Materials(RM) and Finished Products (FM) manufactured during the claim period (as per Annexure II)</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuutilizationRawMaterials" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                         <asp:Button ID="btnutilizationRawMaterials" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnutilizationRawMaterials_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyutilizationRawMaterials" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Statement of Finished Products (exported) during the period (as per Annexure-III)</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuStatementFinishedProducts" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                   <asp:Button ID="btnStatementFinishedProducts" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnStatementFinishedProducts_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyStatementFinishedProducts" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">IEC Registration/Import License/Industrial License/Commercial Invoice/Purchase order / Letter of Credit/Bill of Lading / Airway Bill / Road Transport Receipt/Insurance Certificate/Bill of Entry/Technical Write Up for specific goods/Registration Cum Membership Certificate, if necessary/Test Reports for the raw materials(if any)/DEEC/DEPB/ECGC documents(if any)/Central Excise documents(if any)/GATT/DGFT declaration</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuIECImportIndustrialInvoice" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                      <asp:Button ID="btnIECImportIndustrialInvoice" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnIECImportIndustrialInvoice_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyIECImportIndustrialInvoice" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>

                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Attested copies of RC of vehicles transporting raw materials and finished goods to and from the factory and road permit issued by the Transport Department or authentic Government Document incorporating the vehicle/truck no</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuRCvehiclestransportingrawmaterials" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnRCvehiclestransportingrawmaterials" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnRCvehiclestransportingrawmaterials_Click" />

                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyRCvehiclestransportingrawmaterials" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">6</td>
                                                    <td align="left">Affidavit By Trucks Owners/ Transport companies/ Transport Firms certifying the registration numbers of Trucks carrying Raw materials and Finished Goods TO & FORM the factory on quarterly claim basis in favour of the concerned Industrial unit</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuTrucksTransportcompanies" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnTrucksTransportcompanies" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnTrucksTransportcompanies_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyTrucksTransportcompanies" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Bank Statement for payment made to Transporters during the period (payment only by Cheque)</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fupaymentmadetoTransporters" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnpaymentmadetoTransporters" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnpaymentmadetoTransporters_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hypaymentmadetoTransporters" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">Bank A/C No. & Name</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuBankACNoName" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnBankACNoName" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnBankACNoName_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyBankACNoName" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">9</td>
                                                    <td align="left">Bills & Challan consignment note for finished goods dispatched</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuBillsChallanconsignment" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnBillsChallanconsignment" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnBillsChallanconsignment_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyBillsChallanconsignment" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">10</td>
                                                    <td align="left">Railway freight certificate for relevant period</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuRailwayfreightcertificate" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnRailwayfreightcertificate" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnRailwayfreightcertificate_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyRailwayfreightcertificate" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">11</td>
                                                    <td align="left">Road distance certificate form Competent Authority</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuRoaddistancecertificate" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnRoaddistancecertificate" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnRoaddistancecertificate_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyRoaddistancecertificate" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">12</td>
                                                    <td align="left">Bank Statement for payment made to Transporters during the period</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuBankStatement" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnBankStatement" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnBankStatement_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyBankStatement" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">13</td>
                                                    <td align="left">Bills & Challan consignment note for finished goods dispatched</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuBillsChallanconsignmentfinishedgoods" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnBillsChallanconsignmentfinishedgoods" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnBillsChallanconsignmentfinishedgoods_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyBillsChallanconsignmentfinishedgoods" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">14</td>
                                                    <td align="left">Receipt from transporters for carrying FP(Finished Products)</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="futransportersforcarryingFP" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btntransportersforcarryingFP" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btntransportersforcarryingFP_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hytransportersforcarryingFP" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">15</td>
                                                    <td align="left">In case of excisable goods produced by the unit
                                                        <br />
                                                        a) Certificate from Excise Deptt. Showing the quantity cleared on quarterly basis.
                                                        <br />
                                                        b) Excise Payment challan/ Refund statement showing quantity & value </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCertificatefromExciseDept" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnCertificatefromExciseDept" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnCertificatefromExciseDept_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyCertificatefromExciseDept" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">16</td>
                                                    <td align="left">In case of Finished Products sold outside Country/Exported
                                                        <br />
                                                        a) Copy of C-Form against the consignment sold to the party.<br />
                                                        b) Photocopy of consignment note duly signed and sealed in the cross Border Check gate and consignment note to be acknowledged by the purchasers.</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuconsignmentsoldtotheparty" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnconsignmentsoldtotheparty" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnconsignmentsoldtotheparty_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyconsignmentsoldtotheparty" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">17</td>
                                                    <td align="left">Details address of purchasers with payment receipt details (cash/cheque etc) CA Certificate on the body of the Statement</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuaddressofpurchasers" runat="server" CssClass="form-control-file border" />&nbsp;&nbsp;
                                                        <asp:Button ID="btnaddressofpurchasers" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnaddressofpurchasers_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyaddressofpurchasers" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
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
