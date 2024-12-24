<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCapitalAssistanceExistingAnnexure.aspx.cs" Inherits="TTAP.UI.Pages.Annexures.frmCapitalAssistanceExistingAnnexure" %>

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
        .table-responsive {
            display: block;
            width: 100%;
            overflow-x: auto;
            -webkit-overflow-scrolling: touch;
        }

        .w-100 {
            width: 100% !important;
        }

        .col-sm-10 {
            -ms-flex: 0 0 83.333333%;
            flex: 0 0 84.333333%;
            max-width: 58.333333%;
        }

        .col {
            -ms-flex-preferred-size: 0;
            flex-basis: 0;
            -ms-flex-positive: 1;
            flex-grow: 1;
            max-width: 76%;
        }

        .row {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-wrap: wrap;
            flex-wrap: wrap;
            margin-right: -500px;
            margin-left: -15px;
        }

        .container {
            width: 100%;
            padding-right: 3px;
            padding-left: 11px;
            margin-right: auto;
            margin-left: 39px;
        }

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
            document.getElementById("DivPrint").style.display = "none";
            window.print();
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
                                        <h3 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Form – II : Reimbursement Capital Subsidy for Existing Unit</h3>
                                    </div>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 40%">Name of The Enterprise</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtUnitName" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">2</td>
                                                    <td align="left" style="width: 40%">UID Number</td>
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
                                                        <label class="control-label" runat="server" id="lblTypeofUnit"></label>
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
                                                    <td align="left">Type of Textile</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblTypeofUnitTechnicalOrConventional"></label>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Category of New Unit as per T-TAP Policy </td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblCategoryofUnit"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">Promoter details in case eligible for additional subsidy</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblcategory"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">9</td>
                                                    <td align="left">Approved Project Cost(In Rs.)</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblProjectCost"></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">10</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div1" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Land Details</div>
                                                            <div class="col-sm-10 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>S.No</th>
                                                                        <th>Type of Land</th>
                                                                        <th>Extent in Acre</th>
                                                                        <th>Cost Per Acre (In Rs)</th>
                                                                        <th>Value Of Land (In Rs)</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center" style="width: 5%">1</td>
                                                                        <td align="left" style="width: 57%">Purchased Land </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtPLExtent" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtPLValue" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblPLTotalValue" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td align="center">2</td>
                                                                        <td align="left">Leased Land</td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtLLExtent" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtLLValue" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblLLTotalValue" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td align="center">3</td>
                                                                        <td align="left">Inhertied Land</td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtILExtent" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtILValue" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblILTotalValue" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td align="center">4</td>
                                                                        <td align="left">Govt Land (TSIIC developed IEs/IDA/Industrial Parks)</td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtGLExtent" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtGLValue" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblGLTotalValue" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td align="center"></td>
                                                                        <td align="left">Total</td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="lblTotalExtentinAcre" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="Label3" runat="server"></label>
                                                                        </td>
                                                                        <td align="left">
                                                                            <label id="lblTotalValueOfLand" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">11</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div2" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Buliding Details</div>
                                                            <div class="col-sm-10 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td style="width: 5%">1</td>
                                                                        <td align="left" style="width: 50%">Type of Building</td>
                                                                        <td align="left">
                                                                            <label class="control-label" runat="server" id="lblBuliding_Type"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <div class="col-sm-10 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>S.No</th>
                                                                        <th>Item of Civil works</th>
                                                                        <th>Plinth Area (In Square Meters)</th>
                                                                        <th>Cost (In Rs)</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td style="width: 5%">1</td>
                                                                        <td align="left" style="width: 50%">Main Factory Shed </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtMFSArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtMFSCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="left">Warehouse for Raw Material and finished goods </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtWarehouseArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtWarehouseCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>3</td>
                                                                        <td align="left">Office room and Lab room </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtOfficeArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtOfficeCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>4</td>
                                                                        <td align="left">Cooling water ponds </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtCWPArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtCWPCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>5</td>
                                                                        <td align="left">Boiler shed and generator room </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtBoilerArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtBoilerCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>6</td>
                                                                        <td align="left">Effluent treatment ponds etc. </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtETPArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtETPCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>7</td>
                                                                        <td align="left">Overhead Tank,bore-wells and pump house and sump </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtOTArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtOTACost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item font-SemiBold">
                                                                        <td></td>
                                                                        <td align="left">Total (1-7) </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="totalarea1to7" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="totalcost1to7" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>8</td>
                                                                        <td align="left">Fencing and Gate </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtFGArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtFGCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>9</td>
                                                                        <td align="left">Architect fee and supervision charges </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtAFArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtAFCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>10</td>
                                                                        <td align="left">Compound wall </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtCWArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtCWCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>11</td>
                                                                        <td align="left">Workers Quarters/ workers housing </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtWQArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtWQCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>12</td>
                                                                        <td align="left">Canteen </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtCanteenArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtCanteenCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>13</td>
                                                                        <td align="left">Rest House </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtRHArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtRHCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>14</td>
                                                                        <td align="left">Time Office </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtTOArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtTOCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>15</td>
                                                                        <td align="left">Cycle/Vehicle Stand </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtCSArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtCSCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>16</td>
                                                                        <td align="left">Security Shed </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtSSArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtSSCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>17</td>
                                                                        <td align="left">Toilet room and sanitary fittings </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtToiletArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtToiletCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>18</td>
                                                                        <td align="left">Roads with in factory premises </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtRoadsArea" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="txtRoadsCost" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item font-SemiBold">
                                                                        <td></td>
                                                                        <td align="left">Total (8-18) </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="totalarea8to18" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="totalcost8to18" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item font-SemiBold">
                                                                        <td></td>
                                                                        <td align="left">Grand Total (1-18) </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="totalarea1to18" runat="server"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label class="control-label" id="totalcost1to18" runat="server"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">12</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div3" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Plant and Machinery Details</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="grdPandM" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    CssClass="table table-bordered title6 w-100 NewEnterprise">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" ItemStyle-Width="6%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="P&M Id">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMId" Text='<%#Eval("PMId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineName" Text='<%#Eval("MachineName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Vendor Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVendorName" Text='<%#Eval("VendorName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Type of Machine">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTypeofMachine" Text='<%#Eval("TypeofMachine") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Entire/Parts of Machine">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachinaryParts" Text='<%#Eval("MachinaryPartstext") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Custom Country">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCustomCountry" Text='<%#Eval("CustomCountry") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Custom Paid (Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCustomPaid" Text='<%#Eval("CustomPaid") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Import Duty (Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblImportduty" Text='<%#Eval("Importduty") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>

                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="grdPandM2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    CssClass="table table-bordered title6  w-100 NewEnterprise">
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
                                                                        <asp:TemplateField HeaderText="Machine Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineName2" Text='<%#Eval("MachineName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Port Charges (Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPortcharges" Text='<%#Eval("Portcharges") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Statutory Taxes (Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbStatutorytaxes" Text='<%#Eval("Statutorytaxes") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installed Machinery">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstalledMachineryText" Text='<%#Eval("InstalledMachineryText") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installed Machinery Type">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstalledMachinerytypeText" Text='<%#Eval("InstalledMachinerytypetext") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Manufacturer Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblManufacturerName" Text='<%#Eval("ManufacturerName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Invoice Number">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInvoiceNo" Text='<%#Eval("InvoiceNo") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Invoice Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInvoiceDate" Text='<%#Eval("InvoiceDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Landing Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMahineLandingDate" Text='<%#Eval("MahineLandingDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="grdPandM3" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    CssClass="table table-bordered title6 w-100 NewEnterprise">
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
                                                                        <asp:TemplateField HeaderText="Machine Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineName3" Text='<%#Eval("MachineName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Way Bill Number">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVaivleNo" Text='<%#Eval("VaivleNo") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Way Bill Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblVaivleDate" Text='<%#Eval("VaivleDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Shipping Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIntiationDate" Text='<%#Eval("IntiationDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Cost (In Rs)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineCost" Text='<%#Eval("MachineCost") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Cost (In Foreign Currency)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblForeignMachineCost" Text='<%#Eval("ForeignMachineCost") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Eligibility Category">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEligibility" Text='<%#Eval("Eligibility") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installed Machinery" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstalledMachineryText" Text='<%#Eval("InstalledMachineryText") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label10" runat="server">Actual Total Value of New Machinery (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label" runat="server" id="lblTotalValueofNewMachinery"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label2" runat="server">Actual Total value of 2nd hand machinery (In Rs.):</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label" runat="server" id="lblSecondhandmachinery"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trPMPaymentDetails" runat="server">
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div16" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">PM Payemnt Details</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="GvPMPaymentDtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="50px">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMTMId" runat="server" Text='<%# Bind("PMTMId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="P&M ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMId" runat="server" Text='<%# Bind("PMId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Trnsaction ID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMTrnsactionID" runat="server" Text='<%# Bind("PMTrnsactionID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Trnsaction Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTrnsactionDate" runat="server" Text='<%# Bind("TrnsactionDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Remitting bank">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRemittingbank" runat="server" Text='<%# Bind("Remittingbank") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Beneficiary bank">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBeneficiarybank" runat="server" Text='<%# Bind("Beneficiarybank") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Transaction Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTrnsactionAmount" runat="server" Text='<%# Bind("TrnsactionAmount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machinary Trnsaction Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMAmount" runat="server" Text='<%# Bind("PMAmount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machinary Original Cost">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineCost" runat="server" Text='<%# Bind("MachineCost") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachment">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="hyFilePathMerge" Text="view" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="PMAbstractID" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMTMIdNew" runat="server" Text='<%# Bind("PMTMId") %>'></asp:Label>
                                                                                <asp:Label ID="lblPMPFIdNew" runat="server" Text='<%# Bind("PMPFId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left">New Technologies for textile processing, enhancement of capacities or diversification (In Rs)</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="txtNewTechnologiesfortextileprocessing"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left">Total (In Rs)</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="txtTotal"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">13</td>
                                                    <td align="left" colspan="2">
                                                        <h6 class="text-black font-SemiBold mb-1" style="font-size: small;">Amount of subsidy already claimed earlier, if any</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left">Amount Availed  (In Rs)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtAmountAvailed" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left">Sanction Order No</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtSanctionOrderNo" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left">Date Availed</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtDateAvailed" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">14</td>
                                                    <td align="left">Current Claim Amount (In Rs)
                                                        <br />
                                                        (20% of the cost of plant and machinery limited to Rs 5 crores) SC/ST/Women/PWD additional 5%)</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblCurrentClaimAmount"></label>
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
                                                            <b>Note : </b>1). (20% of the cost of plant and machinery limited to Rs 5 crores) SC/ST/Women/PWD additional 5%
                                                            <br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        2). If any further information/documents required by the department, the same shall be furnished by the entrepreneur.
                                        <br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        3). If any errors found in the data, the same will have to be rectified by the entrepreneurs, then only the provisional incentive will be finalized.
                                                        </div>
                                                        <div class="col-sm-12 py-4">
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
