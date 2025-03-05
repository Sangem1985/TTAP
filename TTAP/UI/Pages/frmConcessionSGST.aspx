<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmConcessionSGST.aspx.cs" Inherits="TTAP.UI.Pages.frmConcessionSGST" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
            <asp:PostBackTrigger ControlID="btnSaleInvoice" />
            <asp:PostBackTrigger ControlID="btnconcernedCTo" />
            <asp:PostBackTrigger ControlID="btnproductionParticulars" />
            <asp:PostBackTrigger ControlID="btnTSPCBOperation" />
            <asp:PostBackTrigger ControlID="btnFormACommercialTaxDept" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Reimbursement of Tax</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – VII : Reimbursement of Tax</h5>
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
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label13" runat="server">GST Identification Number</label>
                                            <asp:TextBox ID="txtGSTIdentificationNumber" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Date Of Incorporation of Unit</label>
                                            <asp:TextBox ID="txtDateofEstablishmentofUnit" Enabled="false" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Installed Capacity of the existing Enterprise as certified by the financial institution/ chartered accountant</label>
                                            <asp:TextBox ID="txtInstalledcapacity" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="trFixedcap" runat="server" visible="true">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Approved Project Cost(In Rs.))</h6>
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
                                                    <th>Approved Project Cost(In Rs.)
                                                        <br />
                                                        Certified by Chartered Accoutant
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
                                                    <td align="center">
                                                        <asp:Label ID="lblApprovedProjectCostLand" runat="server" CssClass="form-control"></asp:Label>
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
                                                    <td align="center">
                                                        <asp:Label ID="lblApprovedProjectCostBuilding" runat="server" CssClass="form-control"></asp:Label>
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
                                                    <td align="center">
                                                        <asp:Label ID="lblApprovedProjectCostPlantMachinery" runat="server" CssClass="form-control"></asp:Label>
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
                                                    <td align="center">
                                                        <asp:Label ID="lblApprovedProjectCostTotal" runat="server" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <%--<div class="row">
                                        <div class="col-sm-12 text-blue label-required font-SemiBold">Production details preceding three years before expansion / diversification project as certified by the financial institution/ chartered accountant</div>
                                    </div>--%>
                                    <div class="row" id="Div1" runat="server">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Production & Sales details preceding three years before expansion / diversification project as certified by the financial institution/ chartered accountant</h6>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                    <th>Sl.No</th>
                                                    <th>Year</th>
                                                    <th>Qunatity (Total Products)</th>
                                                    <%--<th>Enterprises</th>--%>
                                                    <th>Total Production Value</th>
                                                    <th>Tax Paid(VAT/GST)</th>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td>1</td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtYear1" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)" MaxLength="4" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtEnterprises1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtTotalProduction1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtTaxPaid1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td>2</td>

                                                    <td align="center">
                                                        <asp:TextBox ID="txtYear2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtEnterprises2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtTotalProduction2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtTaxPaid2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td>3</td>

                                                    <td align="center">
                                                        <asp:TextBox ID="txtYear3" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)" MaxLength="4" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtEnterprises3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtTotalProduction3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                    <td align="center">
                                                        <asp:TextBox ID="txtTaxPaid3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Sales Details </h6>
                                        <div class="row w-100 m-0" id="DivSalesDetails" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label1" runat="server">Year</label>
                                                <asp:TextBox ID="txtSaleYear" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)" MaxLength="4" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label11" runat="server">Name of the product</label>
                                                <asp:TextBox ID="txtNameoftheproduct" runat="server" CssClass="form-control" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Quantity</label>
                                                <asp:TextBox ID="txtSaleQuantity" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Unit</label>
                                                <asp:DropDownList ID="ddlSaleUnit" runat="server" class="form-control" TabIndex="5" Visible="true">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required">Total Value (in Rs.)</label>
                                                <asp:TextBox ID="txtTotalSaleValue" runat="server" class="form-control"
                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnSGSTSalesAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnSGSTSalesAdd_Click" />
                                                <asp:Button ID="btnSGSTSalesClear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvsalesDetails" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="gvsalesDetails_RowCommand">
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
                                                            <asp:Label ID="lblSaleYear" runat="server" Text='<%#Eval("SaleYear") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name of the Product">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNameoftheproduct" runat="server" Text='<%#Eval("Nameoftheproduct") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Quantity">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSaleQuantity" runat="server" Text='<%#Eval("SaleQuantity") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Unit">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSaleUnitText" runat="server" Text='<%#Eval("SaleUnitText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Value (In Rs)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalSaleValue" runat="server" Text='<%#Eval("TotalSaleValue") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlSaleEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnlSaleDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSaleUnit" runat="server" Visible="false" Text='<%# Bind("SaleUnit") %>'></asp:Label>
                                                            <asp:Label ID="lblSaleID" runat="server" Text='<%# Bind("SaleID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">SGST Reimbursement already availed by Enterprise from the Date of Commencement of Production (Maximum for 7 years)</h6>
                                        <%-- <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">SGST Reimbursement already availed by Enterprise from the Date of Commencement of Production (Maximum for 7 years)</div>
                                        </div>--%>
                                        <div class="row w-100 m-0" id="DivSGSTReimbursement" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label6" runat="server">Financial Year</label>
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
                                                            <asp:Label ID="lblEnergyconsumedID" runat="server" Text='<%# Bind("SGSTReimbursement_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Moratorium Period For Investment as Per Approved DPR</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">From</label>
                                            <asp:TextBox ID="txtMoratoriumFrom" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">To</label>
                                            <asp:TextBox ID="txtMoratoriumTo" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">Investment  Amount</label>
                                            <asp:TextBox ID="txtMoratoriumInvestmentAmount" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                         <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Tax paid by the Enterprise during the 1st Half Year/2nd half year as certified by the Commercial Tax Department (In Rs)</label>
                                            <asp:TextBox ID="txtTaxpaid" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Current Claim Peroid and Amount Details</h6>
                                        <div class="col-sm-4 form-group" runat="server" visible="false">
                                            <label class="control-label" id="Label8" runat="server">Financial Year</label>
                                            <asp:TextBox ID="txtClaimApplicationsubmitted" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label17" runat="server">Financial Year</label>
                                                <asp:DropDownList ID="ddlClaimFinYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                         <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label14" runat="server">Half Year</label>
                                                <asp:DropDownList ID="ddlHalfYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Current Claim Amount (In Rs)</label>
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
                                                    <td align="left" style="width: 50%">First Sale Invoice</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuSaleInvoice" runat="server" />
                                                        <asp:Button ID="btnSaleInvoice" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnSaleInvoice_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hySaleInvoice" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Certificate from concerned CTO/Commercial Tax Dept as prescribed at Form No A</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuconcernedCTo" runat="server" />
                                                        <asp:Button ID="btnconcernedCTo" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnconcernedCTo_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hypconcernedCTo" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Production Particulars for the last –3- years and Column No. 10,12 & 13 of the application duly certified by Chartered Accountant for the first time of the claim, if it is Expansion/Diversification Project</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuProductionParticulars" runat="server" />
                                                        <asp:Button ID="btnproductionParticulars" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnproductionParticulars_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyroductionParticulars" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Valid Consent for Operation (CFO) from TSPCB/Acknowledgement from General Manager, District Industries Centre concerned on pollution angle</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuTSPCBOperation" runat="server" />
                                                        <asp:Button ID="btnTSPCBOperation" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnTSPCBOperation_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyTSPCBOperation" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Form A certification from Commercial Tax Dept</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuFormACommercialTaxDept" runat="server" />
                                                        <asp:Button ID="btnFormACommercialTaxDept" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnFormACommercialTaxDept_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyFormACommercialTaxDept" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
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
        $("input[id$='ContentPlaceHolder1_txtMoratoriumFrom']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtMoratoriumTo']").keydown(function () {
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
            $("input[id$='ContentPlaceHolder1_txtMoratoriumFrom']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtMoratoriumTo']").datepicker(
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
            $("input[id$='ContentPlaceHolder1_txtMoratoriumFrom']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtMoratoriumTo']").datepicker(
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

