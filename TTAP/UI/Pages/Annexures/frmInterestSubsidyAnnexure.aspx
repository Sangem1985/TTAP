<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmInterestSubsidyAnnexure.aspx.cs" Inherits="TTAP.UI.Pages.Annexures.frmInterestSubsidyAnnexure" %>

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

        #collapsibleNavbar .navbar-nav.d-flex.w-50.m-auto {
            margin: 0px !important;
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
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
                                        <h3 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Form – IV: Reimbursement of Interest Subsidy</h3>
                                    </div>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 50%">Name of the Enterprise</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtUnitName" runat="server"></label>
                                                    </td>
                                                </tr>
                                                 <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">2</td>
                                                    <td align="left" style="width: 50%">Address of the Enterprise</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblAddress" runat="server"></label>
                                                    </td>
                                                </tr>
                                                 <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">3</td>
                                                    <td align="left" style="width: 50%">Name of the Proprietor</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblProprietor" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">4</td>
                                                    <td align="left" style="width: 50%">Constitution of Organization</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblOrganization" runat="server"></label>
                                                    </td>
                                                </tr>
                                                  <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">5</td>
                                                    <td align="left" style="width: 50%">Social Status</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblSocialStatus" runat="server"></label>
                                                    </td>
                                                </tr>
                                                 <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">6</td>
                                                    <td align="left" style="width: 50%">Share of SC/ST/Women Enterprenuer</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblShareofSCSTWomenEnterprenue" runat="server"></label>
                                                    </td>
                                                </tr>
                                                 <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">7</td>
                                                    <td align="left" style="width: 50%">Registration Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblRegistrationNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                  <tr class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">Type of Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTypeofApplicant" runat="server"></label>
                                                    </td>
                                                </tr>
                                                  <tr class="GridviewScrollC1Item2">
                                                    <td align="center">9</td>
                                                    <td align="left">Category of New Unit as per T-TAP Policy </td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblCategoryofUnit"></label>
                                                    </td>
                                                </tr>
                                                 <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">10</td>
                                                    <td align="left" style="width: 50%">Type of Sector</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTypeofSector" runat="server"></label>
                                                    </td>
                                                </tr>
                                                 <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">11</td>
                                                    <td align="left" style="width: 50%">Type of Textile</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTypeofTextile" runat="server"></label>
                                                    </td>
                                                </tr>
                                                 <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">12</td>
                                                    <td align="left" style="width: 50%">Technical Textile Type</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTechnicalTextileType" runat="server"></label>
                                                    </td>
                                                </tr>
                                                   <tr class="GridviewScrollC1Item2">
                                                    <td align="center">13</td>
                                                    <td align="left">Activity of the Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblActivityoftheUnit"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">14</td>
                                                    <td align="left" style="width: 50%">UID Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTSIPassUIDNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">15</td>
                                                    <td align="left">Incentive Application Number </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblCommonApplicationNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">16</td>
                                                    <td align="left">Date of Power Connection Release </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblPowerConnectionReleaseDate" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">17</td>
                                                    <td align="left">Commencement of Commercial Production </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblDCPdate" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">18</td>
                                                    <td align="left">Date of Receipt of Claim Application </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblApplicationDt" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">19</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div3" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Approved Project Cost(In Rs.)</div>
                                                            <div class="col-sm-10 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
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
                                                                        <td id="trFixedCapitalland" runat="server" align="center" visible="false">
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
                                                                        <td id="Td3" runat="server" align="center" visible="false">
                                                                            <label id="lblexpinv" runat="server" font-bold="True"></label>
                                                                        </td>
                                                                        <td id="Td4" runat="server" align="center" visible="false">
                                                                            <label id="lbltotperinv" runat="server" font-bold="True"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="center">20</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div10" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Fixed Capital Investment(In Rs.)</div>
                                                            <div class="col-sm-10 table-responsive">
                                                                     <table class="table table-bordered title6 alternet-table w-100 NewEnterprise" border="1">
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
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td align="center">7</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div1" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Details of Term Loan availed with Amount, Date - FI / Bank wise</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="grdTermLoanAvailed" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No" ItemStyle-Width="6%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="ISId" Visible="false">
                                                                            <ItemTemplate>
                                                                                <label id="lblISId" text='<%#Eval("ISId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                                            <ItemTemplate>
                                                                                <label id="lblIncentiveId" text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <label id="lblbankTermLoan" text='<%#Eval("BankName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Branch Name" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <label id="lblb" text='<%#Eval("BranchName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="IFS Code" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <label id="lblc" text='<%#Eval("IFSCode") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Loan Account No" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <label id="lbld" text='<%#Eval("LoanAccNo") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sanction Order No" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <label id="lble" text='<%#Eval("SanctionOrderNo") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sanction Order Date" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <label id="lblf" text='<%#Eval("SanctionOrderDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <label id="lblg" text='<%#Eval("SanctionedAmount") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Released Date" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <label id="lblh" text='<%#Eval("ReleasedDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">21</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div4" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Details of Term Loan availed with Amount, Date - FI / Bank wise</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="GVTermLoandtls" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                        <asp:TemplateField HeaderText="Term Loan">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAvailedTermLoan" runat="server" Text='<%# Bind("AvailedTermLoan") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date of Application for Term Loan">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanApplDate" runat="server" Text='<%# Bind("TermLoanApplDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="InstitutionName">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstitutionName" runat="server" Text='<%# Bind("BankName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="TermLoanSancRefNo">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanSancRefNo" runat="server" Text='<%# Bind("TermLoanSancRefNo") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="TermloanSandate">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermloanSandate" runat="server" Text='<%# Bind("TermloanSandate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="TermLoanReleaseddate">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanReleaseddate" runat="server" Text='<%# Bind("TermLoanReleaseddate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                    <%--<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                    <RowStyle BackColor="White" ForeColor="#003399" />--%>
                                                                </asp:GridView>
                                                            </div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="GVTermLoandtls2" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                        <asp:TemplateField HeaderText="Term Loan">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAvailedTermLoan" runat="server" Text='<%# Bind("AvailedTermLoan") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="No.Of Installments">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanInstallments" runat="server" Text='<%# Bind("Installments") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Rate Of Interest (%)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRateOfInterest" runat="server" Text='<%# Bind("RateOfInterest") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sanctioned Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSanctionedAmount" runat="server" Text='<%# Bind("SanctionedAmount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="TermLoan Period From Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanPeriodFromDate" runat="server" Text='<%# Bind("TermLoanPeriodFromDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="TermLoan Period To Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanPeriodToDate" runat="server" Text='<%# Bind("TermLoanPeriodToDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstitutionNameid" runat="server" Visible="false" Text='<%# Bind("InstitutionName") %>'></asp:Label>
                                                                                <asp:Label ID="lblTermLoanId" runat="server" Text='<%# Bind("TermLoanId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">22</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div2" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Details of Term loan repaid (Financial year-wise) FI/Bank wise- Curren Claim Period</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="grdTermLoanRepaid" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No" ItemStyle-Width="6%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Financial Year" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFinYear" Text='<%#Eval("FinancialYearText") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="1st/2nd half Year" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRepaidTypeOfFinancialYearText" Text='<%#Eval("TypeOfFinancialYearText") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Principal Amount" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPrincipalAmt" Text='<%#Eval("PrincipalAmt") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Rate Of Interest (%)" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRateOfInterest" Text='<%#Eval("RateOfInterest") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Interest Amount" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInterestAmt" Text='<%#Eval("InterestAmt") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Payment Date" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPaymentDate" Text='<%#Eval("PaymentDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <%--<FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                    <RowStyle BackColor="White" ForeColor="#003399" />--%>
                                                                </asp:GridView>
                                                            </div>

                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">23</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div7" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Total Loan Amount Repaid</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="grdTotalTermLoanRepaid" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 alternet-table w-100 NewEnterprise" CellSpacing="4">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No" ItemStyle-Width="6%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex + 1%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total No.Of Installments">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTermLoanInstallments" runat="server" Text='<%# Bind("TotalNoofInstallments") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installment Amount (Rs.)" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstallmentAmount" Text='<%#Eval("InstallmentAmount") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total Amount Repaid (Interest + Principal) (Rs.)" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTotalAmountRepaid" Text='<%#Eval("TotalAmountRepaid") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                    <RowStyle BackColor="White" ForeColor="#003399" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">24</td>
                                                    <td align="left" colspan="1">
                                                        <h6 class="text-black font-bold mb-1" style="font-size: small;">Whether the Unit has availed Interest Subsidy from GOI or any other Agency</h6>
                                                    </td>
                                                     <td align="left">
                                                        <asp:Label runat="server" ID="lblAgency">Yes</asp:Label>
                                                    </td>
                                                </tr>
                                                <div runat="server" id="divAgency" visible="false">
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
                                                    </div>
                                                 <tr class="GridviewScrollC1Item2">
                                                    <td align="center">25</td>
                                                    <td align="left" colspan="1">
                                                        <h6 class="text-black font-bold mb-1" style="font-size: small;">Whether the Unit has availed Mortorium period for repayment of Loan</h6>
                                                    </td>
                                                      <td align="left">
                                                        <asp:Label runat="server" ID="lblMoratorium">No</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="trMoratorium" runat="server">
                                                    <td align="center"></td>
                                                    <%-- <td align="left">Moratorium Period for RePayment of Loan</td>--%>
                                                    <td align="left" colspan="2">
                                                        <%-- <label class="control-label" id="txtCCPFrom" runat="server"></label>--%>
                                                        <div class="row" id="Div8" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Moratorium Period for RePayment of Loan</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="GvMoratoriumPeriod" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                                    AutoGenerateColumns="false">
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
                                                                        <asp:TemplateField HeaderText="1st/2nd half Year">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="From Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFromDate" runat="server" Text='<%#Eval("FromDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="To Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblToDate" runat="server" Text='<%#Eval("ToDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblBankName" Text='<%#Eval("BankName") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Rate Of Interest (%)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMoratoriumRateOfInterest" runat="server" Text='<%# Bind("RateOfInterest") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <%--<tr class="GridviewScrollC1Item2">
                                                    <td align="center">10</td>
                                                    <td align="left">First / Second Half Year</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlCCPType" runat="server"></label>
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="center">26</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div5" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Current Claim Period</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="GvInterestSubsidyPeriod" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                                <asp:Label ID="lblFinancialYear" runat="server" Text='<%#Eval("FinancialYearText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="1st/2nd half Year">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount (In Rupees)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAmountPaid" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-12 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label10" runat="server">Current Total Claim Amount (In Rs.) (75% of the interest rate applicable on the loans with a cap of 8% per annum) </label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        : 
                                                                        <label class="control-label" runat="server" id="txtCCA"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">27</td>
                                                    <td colspan="2">
                                                        <div class="row" id="Div6" runat="server">
                                                            <div class="col-sm-12 text-black font-bold mb-1">Additional information</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="gvAdditionalInformation" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                        <asp:TemplateField HeaderText="Month & Year">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAmountDueDate" runat="server" Text='<%#Eval("AmountDueDate") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="1st/2nd half Year">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTypeOfFinancialYearText" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="T.L. Amount/ O.B (In Rupees)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTearmLoanAmount" runat="server" Text='<%#Eval("TearmLoanAmount") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="No Of Installments">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNoOfInstallments" runat="server" Text='<%#Eval("NoOfInstallments") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Rate of interest (%)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRateofInterestAmountDue" runat="server" Text='<%#Eval("RateofInterestAmountDue") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Interest Due">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInterestDue" runat="server" Text='<%#Eval("InterestDue") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unit holder contribution">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnitHolderContribution" runat="server" Text='<%#Eval("UnitHolderContribution") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Eligible rate of interest">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEligibleRateInterest" runat="server" Text='<%#Eval("EligibleRateInterest") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Eligible interest">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEligibleInterest" runat="server" Text='<%#Eval("EligibleInterest") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">28</td>
                                                    <td align="left" colspan="2">
                                                        <div class="row" id="Div9" runat="server">
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
