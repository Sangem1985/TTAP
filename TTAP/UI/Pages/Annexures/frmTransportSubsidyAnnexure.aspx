<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmTransportSubsidyAnnexure.aspx.cs" Inherits="TTAP.UI.Pages.Annexures.frmTransportSubsidyAnnexure" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department of Handlooms & Textiles | Government of Telangana</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--Added by Pramod--%>
    <link rel="stylesheet" href="../../../AssetsNew/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/style.css" />
    <link rel="stylesheet" href="../../../AssetsNew/css/media.css" />

    <%--  <link href="../../../AssetsNew/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>


    <style>
        .main {
            min-height: 595px;
            min-height: 75.4vh;
            /*background: #f3f8ff;*/
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        #collapsibleNavbar .navbar-nav.d-flex.w-50.m-auto {
            margin: 0px !important;
        }

        div#ContentPlaceHolder1_Receipt, .container.mt-4.pb-4, .col-sm-12.offset-md-1.col-md-10.col-lg-10.offset-lg-1.p-4.pb-0.mt-3.frm-form.box-content {
            max-width: 1140px !important;
        }
    </style>
    <%-- <script type="text/javascript">
        $(function () {
            $('#datetimepicker').datetimepicker();
        });
        </script>--%>
    <script type="text/javascript">

        function myFunction() {

            //document.getElementById("Div2").style.visibility = "hidden";
            document.getElementById("DivPrint").style.display = "none";
            //$("#Button2").hide();
            window.print();
            // $("#Button2").show();
            document.getElementById("DivPrint").style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <%--  <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Concession on SGST</li>
                        </ul>--%>
                    </div>
                </div>
                <div class="container mt-4 pb-4" runat="server">
                    <%--<div class="w-100 px-3 frm-form box-content py-3 font-medium title5">--%>
                    <div class="w-100 px-3 frm-form py-3 font-medium title5" runat="server" id="divheader">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <div class="row">
                                        <h3 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Form – X : Transport Subsidy to Export Intensive Textile Units</h3>
                                    </div>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 50%">Name of The Enterprise</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtUnitName" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">2</td>
                                                    <td align="left" style="width: 50%">UID Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTSIPassUIDNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">3</td>
                                                    <td align="left">Common Application Number </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblCommonApplicationNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Type of Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTypeofApplicant" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Commencement of Commercial Production </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblDCPdate" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">6</td>
                                                    <td align="left">Category of New Unit as per T-TAP Policy </td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblCategoryofUnit"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Activity of the Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblActivityoftheUnit"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">Date Of Incorporation of Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtDateofEstablishmentofUnit" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">9</td>
                                                    <td align="left">Nature of Business/Business Type</td>
                                                    <td align="left">
                                                        <asp:CheckBoxList ID="chkNatureofBusiness" runat="server" CssClass="checkbox" Enabled="false" RepeatDirection="Vertical">
                                                            <asp:ListItem Text="Export Oriented Unit" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Supplier to export oriented Industry/Enterprise(Final product to be exported)" Value="2"></asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">10</td>
                                                    <td align="left">Percentage of Total Revenue as Exports</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtPercentageTotalRevenue" runat="server"></label>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">11</td>
                                                    <td align="left">Nearest Airport
                                                    </td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNearestAirport" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left">Nearest Seaport</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNearestSeaport" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left">Nearest Dry Port</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNearestDryPort" runat="server"></label>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">12</td>
                                                    <td align="left">Type of Export</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlTypeofExport" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">13</td>
                                                    <td align="left">Mode of Transport</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblModeofTransport" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <%--<tr class="GridviewScrollC1Item2">
                                                    <td align="center">12</td>
                                                    <td align="left">Detail of Export Revenue for Last 3 Years and its Average</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtExportRevenue" runat="server"></label>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="center">14</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div2" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Detail of Export Revenue for Last 3 Years and its Average</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="gvExportRevenueDetails" runat="server" CssClass="table table-bordered title6 pro-detail w-100 NewEnterprise" AutoGenerateColumns="false">
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
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">15</td>
                                                    <td align="left">Details of Raw Materials i.e. (Imported)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtDetailsRawMaterialsImported" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">16</td>
                                                    <td align="left">Details of Finished Products i.e. (Exported by your Unit/Industry/Enterprise etc)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtFinishedProducts" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">17</td>
                                                    <td align="left">Details of Finished Products Exported by the Unit/Industry/Enterprise etc.(To which your Unit is the supplies the materials)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtFinishedProductsExported" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">18</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div1" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Transport Subsidy reimbursement already availed by Enterprise from the Date ofCommencement of Production</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="grdSGSTReimbursement" runat="server" CssClass="table table-bordered title6 pro-detail w-100 NewEnterprise" AutoGenerateColumns="false">
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
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td align="center">19</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div3" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Current Financial Year </div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="GvCurrentClaimPeriod" runat="server" CssClass="table table-bordered title6 pro-detail w-100 NewEnterprise" AutoGenerateColumns="false">
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
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">20</td>
                                                    <td align="left">Current Total Claim (In Rupees)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtCurrentClaim" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="2">
                                                        <div class="row" id="Div4" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">List of Enclosures Attached</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                                    HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="gvSubsidy_RowDataBound">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle Width="60px" CssClass="text-center" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Status" ItemStyle-Width="200px" ControlStyle-Width="200px">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNoofmachines" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <div class="col-sm-12 py-4">
                                                            <b>Note : </b>1). If any further information/documents required by the department, the same shall be furnished by the entrepreneur.
                                                            <br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        2). If any errors found in the data, the same will have to be rectified by the entrepreneurs, then only the provisional incentive will be finalized.
                                                        </div>
                                                        <div class="col-sm-12">
                                                            <b>DECLARATION : </b>
                                                            <br />
                                                            I / We hereby confirm that to the best of my / our knowledge and belief, information given herein before and other papers enclosed are true and correct in all respects. I / We further undertake to substantiate the particulars about promoter(s) and other details with documentary evidence as and when called for.<br />
                                                            <br />
                                                            I/We hereby agree that I/We shall forthwith repay the amount disbursed to me/us under the scheme, if the amount of Reimbursement is found to be disbursed in excess of the amount actually admissible whatsoever the reason.
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="container" id="DivPrint" runat="server" style="text-align: center; vertical-align: bottom">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                                            <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../NewCss/js/excanvas.min.js"></script>
    <script src="../../../NewCss/js/jquery.ui.custom.js"></script>
    <script src="../../../NewCss/js/bootstrap.min.js"></script>
    <script src="../../../NewCss/js/jquery.flot.min.js"></script>
    <script src="../../../NewCss/js/jquery.flot.resize.min.js"></script>
    <script src="../../../NewCss/js/jquery.peity.min.js"></script>
    <script src="../../../NewCss/js/maruti.js"></script>
    <script src="../../../NewCss/js/maruti.dashboard.js"></script>
    <script src="../../../NewCss/js/maruti.chat.js"></script>
    <%-- <script src="Scripts/bootstrap.min.js"></script>
        <script src="../../../Scripts/jquery-3.3.1.min.js"></script>
        <script src="../../../Scripts/jquery-3.3.1.js"></script>
        <script src="../../../AssetsNew/js/bootstrap-datetimepicker.min.js"></script>--%>
    <script type="text/javascript">
        // This function is called from the pop-up menus to transfer to
        // a different page. Ignore if the value returned is a null string:
        function goPage(newURL) {

            // if url is empty, skip the menu dividers and reset the menu selection to default
            if (newURL != "") {

                // if url is "-", it is this page -- reset the menu:
                if (newURL == "-") {
                    resetMenu();
                }
                // else, send page to designated URL            
                else {
                    document.location.href = newURL;
                }
            }
        }

        // resets the menu selection upon entry to this page:
        function resetMenu() {
            document.gomenu.selector.selectedIndex = 2;
        }
    </script>
    <script src="../../../AssetsNew/js/popper.min.js"></script>
    <script src="../../../AssetsNew/js/bootstrap.min.js"></script>
    <script src="../../../AssetsNew/js/floating.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $(function () {
                var url = window.location.pathname,
                    urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");
                // now grab every link from the navigation
                $('.navbar a, footer a').each(function () {
                    // and test its normalized href against the url pathname regexp
                    if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
                        $(this).addClass('active');
                    }
                });
            });
        });
    </script>
</body>
</html>
