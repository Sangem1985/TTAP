<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmDraftApplication.aspx.cs" Inherits="TTAP.UI.Pages.frmDraftApplication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department of Handlooms & Textiles | Government of Telangana</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--Added by Pramod--%>
    <link rel="stylesheet" href="../../AssetsNew/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/style.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/media.css" />
    <%--  <link href="../../AssetsNew/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>


    <style>
         .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
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

        .table-responsive {
            overflow-x: unset !important;
            width: 99% !important;
        }
        /*div#ContentPlaceHolder1_Receipt, .container.mt-4.pb-4, .col-sm-12.offset-md-1.col-md-10.col-lg-10.offset-lg-1.p-4.pb-0.mt-3.frm-form.box-content {
            max-width: 1165px !important;
        }*/
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
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                        <h4 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Incentive Common Application</h4>
                                    </div>
                                </div>
                                <div class="widget-content">
                                    <div class="row">
                                        <h5 class="text-black font-SemiBold mb-1" style="font-size: small;">I. Enterprise Details</h5>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 3%">1</td>
                                                    <td align="left" style="width: 22%">Name of The Enterprise</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="txtUnitName" runat="server"></label>
                                                    </td>
                                                    <td align="center" style="width: 3%">2</td>
                                                    <td align="left" style="width: 22%">TSIPASS - UID Number</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="lblTSIPassUIDNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">3</td>
                                                    <td align="left">Common Application Number </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblCommonApplicationNumber" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Type of Unit</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblTypeofUnit"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="divIndustryTSIPASS" runat="server" visible="false">
                                                    <td align="center">4</td>
                                                    <td align="left">Type of Unit As per TSIPASS</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblTypeofUnitTsipassold"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Category of New Unit as per T-TAP Policy </td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="lblCategoryofUnit"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">Type of Textile</td>
                                                    <td align="left">
                                                        <label class="control-label" id="rdl_TypeofUnit" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Type of Sector</td>
                                                    <td align="left">
                                                        <label class="control-label" id="rblSector" runat="server"></label>
                                                    </td>

                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">Country of Origin (In case of MNC)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtCountryofOrigin" runat="server"></label>
                                                    </td>
                                                    <td align="center">9</td>
                                                    <td align="left">Date Of Incorporation</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtDateOfIncorporation" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">10</td>
                                                    <td align="left">Incorporation Registration No</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtIncorpRegistranNumber" runat="server"></label>
                                                    </td>
                                                    <td align="center">11</td>
                                                    <td align="left">GST Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtTinNO" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">12</td>
                                                    <td align="left">PAN Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtPanNo" runat="server"></label>
                                                    </td>
                                                    <td align="center">13</td>
                                                    <td align="left">EIN/IEM/IL Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtEINIEMILNumber" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">14</td>
                                                    <td align="left">Date of EIN/IEM/IL Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtEINIEMILDate" runat="server"></label>
                                                    </td>
                                                    <td align="center">15</td>
                                                    <td align="left">Constitution of Organization</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlOrgType" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">16</td>
                                                    <td align="left">Social Status</td>
                                                    <td align="left">
                                                        <label class="control-label" id="rblCaste" runat="server"></label>
                                                    </td>
                                                    <td align="center">17</td>
                                                    <td align="left">Applicant Name</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtApplciantName" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">18</td>
                                                    <td align="left">Gender</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlgender" runat="server"></label>
                                                    </td>
                                                    <td align="center">19</td>
                                                    <td align="left">No of Years of Experience in Textiles</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtYearsOfExpinTexttile" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">20</td>
                                                    <td align="left">Physically handicapped</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlDifferentlyabled" runat="server"></label>
                                                    </td>
                                                    <td align="center">21</td>
                                                    <td align="left">Nature Of Industry</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlTextileProcessType" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">22</td>
                                                    <td align="left">Technical Textile Type</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblTechnicalTextileType" runat="server"></label>
                                                    </td>
                                                    <td align="center">23</td>
                                                    <td align="left" runat="server" id="tdexistingunit">Commencement of Commercial Production </td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblDCPdate" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" runat="server" id="trDCPExp">
                                                    <td align="center">24</td>
                                                    <td align="left">Commencement of Commercial Production of Expansion/Diversification/Modernization</td>
                                                    <td align="left">
                                                        <label class="control-label" id="lblDCPexpdate" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" style="font-size: small;">Special Incentive Scheme</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">24</td>
                                                    <td align="left">Goverment Order Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtGovermentOrderNumber" runat="server"></label>
                                                    </td>
                                                    <td align="center">25</td>
                                                    <td align="left">Goverment Order Date</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtGovermentOrderDate" runat="server"></label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" style="font-size: small;">Registered Address of Enterprise</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">1</td>
                                                    <td align="left">State</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlUnitstate" runat="server"></label>
                                                    </td>
                                                    <td align="center">2</td>
                                                    <td align="left">District</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlUnitDIst" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">3</td>
                                                    <td align="left">Mandal</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlUnitMandal" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Village</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlVillageunit" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Grampanchayat/IE/IDA</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtUnitStreet" runat="server"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">Survey/Plot No</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtUnitHNO" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Aadhar Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtadhar1" runat="server"></label>
                                                    </td>
                                                    <td align="center">8</td>
                                                    <td align="left">Mobile Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtunitmobileno" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">9</td>
                                                    <td align="left">Email Id</td>
                                                    <td align="left" colspan="4">
                                                        <label class="control-label" id="txtunitemailid" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center" style="height: 30px" colspan="6"></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" style="font-size: small;">Correspondence Address</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">1</td>
                                                    <td align="left">State</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddloffcstate" runat="server"></label>
                                                    </td>
                                                    <td align="center">2</td>
                                                    <td align="left">District</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlOffcDIst" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">3</td>
                                                    <td align="left">Mandal</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlOffcMandal" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Village</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlOffcVil" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Grampanchayat/IE/IDA</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtOffcStreet" runat="server"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">Survey/Plot No</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtOffSurveyNo" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Mobile Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtOffcMobileNO" runat="server"></label>
                                                    </td>
                                                    <td align="center">8</td>
                                                    <td align="left">Email Id</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtOffcEmail" runat="server"></label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h5 class="text-black font-SemiBold mb-1" style="font-size: small;">II. Project Details</h5>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr>
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="trNewIndustry" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1" id="lblIndustryHeading" runat="server">New Enterprise Line of Activity</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="GvLineOfactivityDetails" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" class="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                        <asp:TemplateField HeaderText="Type Of Product">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLineofActivity" runat="server" Text='<%# Bind("LineofActivity") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installed Capacity">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstalledCapacity" runat="server" Text='<%# Bind("InstalledCapacity") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unit">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Value Per Unit (in Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblValuePerUnitRs" runat="server" Text='<%# Bind("ValuePerUnit") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total Value (in Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblValueRs" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                        <div class="row" id="trexpansionnew" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1" id="lblexpansionnewHeading" runat="server">New Enterprise Line of Activity</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="GvLineOfactivityExpnsionDetails" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" class="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                        <asp:TemplateField HeaderText="Type Of Product">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLineofActivity" runat="server" Text='<%# Bind("LineofActivity") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installed Capacity">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstalledCapacity" runat="server" Text='<%# Bind("InstalledCapacity") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unit">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Value Per Unit (in Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblValuePerUnitRs" runat="server" Text='<%# Bind("ValuePerUnit") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total Value (in Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblValueRs" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div1" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1" id="lblDetailsofPatners" runat="server">Details of Proprietor/Managing Partner/ Managing Director</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="GvPartnerDetails" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" class="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                        <asp:TemplateField HeaderText="Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDirectorName" runat="server" Text='<%# Bind("DirectorName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="DisignationName">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDisignationName" runat="server" Text='<%# Bind("DisignationName") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Qualification">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblQualification" runat="server" Text='<%# Bind("QualificationText") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Years of Experience In Texttiles">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblYearsofExperience" runat="server" Text='<%# Bind("YearsofExperience") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Share">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblShare" runat="server" Text='<%# Bind("Share") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="PAN Number">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPANNumber" runat="server" Text='<%# Bind("PANNumber") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Mobile Number">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Email Id">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEmailId" runat="server" Text='<%# Bind("EmailId") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" style="font-size: small;">Authorised Signatory/Contact Person Details</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 3%">1</td>
                                                    <td align="left" style="width: 22%">Name</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="txtAuthorisedPerson" runat="server"></label>
                                                    </td>
                                                    <td align="center" style="width: 3%">2</td>
                                                    <td align="left" style="width: 22%">Designation</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="ddlAuthorisedSignDesignation" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">3</td>
                                                    <td align="left">PAN Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtPanNoAuthorised" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Mobile Number</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtMobileNumberAuthorised" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Email Id</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtemailAuthorised" runat="server"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">Correspondence Address</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtCorrespondenceAddress" runat="server"></label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h5 class="text-black font-SemiBold mb-1" style="font-size: small;">III. Project Financials</h5>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <%-- <table>--%>
                                                <tr>
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div2" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Direct Employment</div>
                                                            <div class="col-sm-12 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th></th>
                                                                        <th></th>
                                                                        <th colspan="3">Local</th>
                                                                        <th colspan="3">Non-Local</th>
                                                                        <th></th>
                                                                    </tr>
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>Sl.No</th>
                                                                        <th>Cadre</th>
                                                                        <th>Male(Nos) </th>
                                                                        <th>Female(Nos) </th>
                                                                        <th class="font-SemiBold">Total</th>
                                                                        <th>Male(Nos) </th>
                                                                        <th>Female(Nos) </th>
                                                                        <th class="font-SemiBold">Total</th>
                                                                        <th class="font-SemiBold">Grand Total</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td>Management & Staff</td>
                                                                        <td align="center" valign="center">
                                                                            <label id="txtstaffMale" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtfemale" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblDirectStaffTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center" valign="center">
                                                                            <label id="txtstaffMaleNonLocal" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtfemaleNonLocal" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblInDirectStaffTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblStaffgrandTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td style="width: 20px;">2
                                                                        </td>
                                                                        <td style="width: 250px;">Supervisory
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtsupermalecount" runat="server" class="control-label" align="center"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtsuperfemalecount" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblDirectSupervisoryTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtsupermalecountNonLocal" runat="server" class="control-label" align="center"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtsuperfemalecountNonLocal" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblInDirectSupervisoryTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblSupervisoryGrandTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>3</td>
                                                                        <td>Skilled workers </td>
                                                                        <td align="center">
                                                                            <label id="txtSkilledWorkersMale" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtSkilledWorkersFemale" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblDirectSkilledworkersTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtSkilledWorkersMaleNonLocal" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtSkilledWorkersFemaleNonLocal" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblInDirectSkilledworkersTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblSkilledworkersGrandTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>4</td>
                                                                        <td>Semi-skilled workers
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtSemiSkilledWorkersMale" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtSemiSkilledWorkersFemale" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblDirectSemiSkilledworkersTotal" runat="server" class="control-label font-SemiBold"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtSemiSkilledWorkersMaleNonLocal" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtSemiSkilledWorkersFemaleNonLocal" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblInDirectSemiSkilledworkersTotal" runat="server" class="control-label font-SemiBold"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblSemiSkilledworkersGrandTotal" runat="server" class="control-label font-SemiBold"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>5</td>
                                                                        <td>Others/Un-Skilled
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtEmpDirectLocalMaleOther" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtEmpDirectLocalFemaleOther" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblDirectUnSkilledworkersTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtEmpDirectNonLocalMaleOther" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtEmpDirectNonLocalFemaleOther" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblInDirectUnSkilledworkersTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblUnSkilledworkersGrandTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td class="auto-style2"></td>
                                                                        <td class="auto-style2" style="font-weight: bold">Total</td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblDirectMale" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblDirectFeMale" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblDirectGrandTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblDirectMaleNonLocal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblDirectFeMaleNonLocal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblInDirectGrandTotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblgrandemptotal" runat="server" class="control-label font-SemiBold">
                                                                            </label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>

                                                        <div class="row" id="DivIndirectEmp" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1" id="Div4" runat="server">Indirect Employment</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="gvIndirectEmployment" AutoGenerateColumns="False" CellPadding="4"
                                                                    PageSize="50" ShowFooter="false" class="table table-bordered title6 w-100 NewEnterprise" CellSpacing="4">
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
                                                                        <asp:TemplateField HeaderText="Category">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Male">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMale" runat="server" Text='<%# Bind("IndirectMale") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unit">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFemale" runat="server" Text='<%# Bind("IndirectFemale") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="IndirectEMPId" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIndirectEmploymentID" runat="server" Text='<%# Bind("IndirectEmploymentID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr>
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div3" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Approved Project Cost(In Rs.)</div>
                                                            <div class="col-sm-10 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>Sl.No</th>
                                                                        <th>Nature of Assets</th>
                                                                        <th id="thApprovedProjectCost" runat="server">Value (in Rs.)</th>
                                                                        <th id="trFixedCapitalexpansion" runat="server" visible="false">Under Expansion/ Diversification/ Modification Project</th>
                                                                        <th id="trFixedCapitalexpnPercent" runat="server" visible="false">% of increase under
                                                                            <br />
                                                                            Expansion/Diversification/Modification
                                                                        </th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td align="left">Land</td>
                                                                        <td align="center">
                                                                            <label id="txtlandexisting" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td id="trFixedCapitalland" runat="server" align="center"
                                                                            visible="false">
                                                                            <label id="txtlandcapacity" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td id="txtbuildcapacityPercet" runat="server" align="center" visible="false">
                                                                            <label id="txtlandpercentage" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="left">Building </td>
                                                                        <td align="center">
                                                                            <label id="txtbuildingexisting" runat="server" class="control-label"></label>
                                                                        </td>

                                                                        <td id="trFixedCapitalBuilding" runat="server" align="center" visible="false">
                                                                            <label id="txtbuildingcapacity" runat="server" class="control-label"></label>
                                                                        </td>

                                                                        <td id="trFixedCapitBuildPercent" runat="server" align="center" visible="false">
                                                                            <label id="txtbuildingpercentage" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>3</td>
                                                                        <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtplantexisting" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td id="trFixedCapitalMach" runat="server" align="center" visible="false">
                                                                            <label id="txtplantcapacity" runat="server" class="control-label"></label>

                                                                        </td>
                                                                        <td id="trFixedCapitMachPercent" runat="server" align="center" visible="false">
                                                                            <label id="txtplantpercentage" runat="server" class="control-label"></label>
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
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div12" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Actual Investment Details (In Rs.)</div>
                                                        </div>
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
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 3%">1</td>
                                                    <td align="left" style="width: 22%">Is power applicable</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="ddlIspowApplicable" runat="server"></label>
                                                    </td>
                                                    <td align="center" style="width: 3%">2</td>
                                                    <td align="left" style="width: 22%">Is Water applicable</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="ddlWaterSource" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="trpowerSpace" runat="server" visible="false">
                                                    <td align="center" style="height: 30px" colspan="6"></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="trpower" runat="server" visible="false">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" runat="server" id="lblpowerHEAD" style="font-size: small;">Power Details - New Enterprise</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower1" runat="server" visible="false">
                                                    <td align="center">1</td>
                                                    <td align="left">Connection Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNewPowerUniqueID" runat="server"></label>
                                                    </td>
                                                    <td align="center">2</td>
                                                    <td align="left">Power Company</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtNewPowerCompany" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower1A" runat="server" visible="false">
                                                    <td align="center">3</td>
                                                    <td align="left">Power Release Date</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNewPowerReleaseDate" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Connected Load (in KVA)</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtPowerConnectedLoad" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower1B" runat="server" visible="false">
                                                    <td align="center">5</td>
                                                    <td align="left">Contracted Load (in KVA)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtNewContractedLoad" runat="server"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">Rate per unit(in Rs)</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtServiceRateUnit" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower1C" runat="server" visible="false">
                                                    <td align="center" style="height: 30px" colspan="6"></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower2" runat="server" visible="false">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" runat="server" id="lblexistingpower" style="font-size: small;">Power Details</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower2A" runat="server" visible="false">
                                                    <td align="center">1</td>
                                                    <td align="left">Connection Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtExistingPowerUniqueID" runat="server"></label>
                                                    </td>
                                                    <td align="center">2</td>
                                                    <td align="left">Power Company</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtExistingPowerCompany" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower2B" runat="server" visible="false">
                                                    <td align="center">3</td>
                                                    <td align="left">Power Release Date</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtExistingPowerReleaseDate" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Connected Load (in KVA)</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtExistingPowerConnectedLoad" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower2C" runat="server" visible="false">
                                                    <td align="center">5</td>
                                                    <td align="left">Contracted Load (in KVA)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtExistingContractedLoad" runat="server"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">Rate per unit(in Rs)</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtExistingRateUnit" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower2D" runat="server" visible="false">
                                                    <td align="center" style="height: 30px" colspan="6"></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower3" runat="server" visible="false">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" runat="server" id="lblexpandiverpower" style="font-size: small;"></h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower3A" runat="server" visible="false">
                                                    <td align="center">1</td>
                                                    <td align="left">Connection Number</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtExpanDiverPowerUniqueID" runat="server"></label>
                                                    </td>
                                                    <td align="center">2</td>
                                                    <td align="left">Power Company</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtExpanDiverPowerCompany" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower3B" runat="server" visible="false">
                                                    <td align="center">3</td>
                                                    <td align="left">Power Release Date</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtExpanDiverPowerReleaseDate" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Connected Load (in KVA)</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtExpanDiverPowerConnectedLoad" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower3C" runat="server" visible="false">
                                                    <td align="center">5</td>
                                                    <td align="left">Contracted Load (in KVA)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtExpanDiverContractedLoad" runat="server"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">Rate per unit(in Rs)</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtExpanDiverRateUnit" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblpower3D" runat="server" visible="false">
                                                    <td align="center" style="height: 30px" colspan="6"></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="DivWater" runat="server" visible="false">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" runat="server" id="H1" style="font-size: small;">Water Source Details (per Day)</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="TrWater1" runat="server" visible="false">
                                                    <td align="center">1</td>
                                                    <td align="left">Source</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtwaterSource" runat="server"></label>
                                                    </td>
                                                    <td align="center">2</td>
                                                    <td align="left">Requirement Per day (In Litre)</td>
                                                    <td align="left" colspan="3">
                                                        <label class="control-label" id="txtwaterRequirement" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="TrWater2" runat="server" visible="false">
                                                    <td align="center">3</td>
                                                    <td align="left">Rate Per Litre(in Rs)</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtwaterRateperunit" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="Tr1" runat="server">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" runat="server" id="H2" style="font-size: small;">Abstract - Plant and Machinery Details</h6>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row">
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label1" runat="server">No.of Type of Machinaries:</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label" runat="server" id="lbltotalMachinaries"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                                <div class="row">
                                                                    <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label label" id="Label4" runat="server">Total No of Machines:</label>
                                                                    </div>
                                                                    <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                                        <label class="control-label" runat="server" id="lblTotalMachines"></label>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row" id="Div10" runat="server">
                                                            <%-- <div class="col-sm-12 text-black font-SemiBold mb-1" id="Div11" runat="server">Abstract - Plant and Machinery Details</div>--%>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="gvPMAbstract" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                                                        <asp:TemplateField HeaderText="Type Of Machinery">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTypeOfMachinery" runat="server" Text='<%# Bind("TypeOfMachinery") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="No of Machines">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNoofmachines" runat="server" Text='<%# Bind("Noofmachines") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Is Photograph Uploaded" ItemStyle-Width="200px" ControlStyle-Width="200px">
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
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 3%"></td>
                                                    <td align="left" style="width: 22%">Total No.of Machines</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="lblNoofMachines" runat="server"></label>
                                                    </td>
                                                    <td align="center" style="width: 3%"></td>
                                                    <td align="left" style="width: 22%">Total Machinary Value</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="lblMachinaryValue" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" id="trShowMachine">
                                                    <td align="center"></td>
                                                    <td>
                                                        <asp:Button ID="btnShow" runat="server" CssClass="btn btn-blue btn" Text="Show Machine List" OnClick="btnShow_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    
                                    <div class="row" runat="server" id="divMachinary" visible="false">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6 w-100 NewEnterprise">
                                                <tr id="trpmdetails" runat="server">
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div5" runat="server">
                                                             
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Plant and Machinery Details</div>
                                                           
                                                            <%--CssClass="table table-bordered title6 w-100 NewEnterprise"--%>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="grdPandM" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="S.No" ItemStyle-Width="6%">
                                                                            <HeaderStyle HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" Width="10px" />
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
                                                                                <asp:Label ID="lblMachineName" Width="180px" Text='<%#Eval("MachineName") %>' runat="server" />
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
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                        <div class="row" id="Div15" runat="server">
                                                            <%--CssClass="table table-bordered title6  w-100 NewEnterprise"--%>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="grdPandM2" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%">
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
                                                                        <asp:TemplateField HeaderText="P&M Id">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMId" Text='<%#Eval("PMId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineName2" Text='<%#Eval("MachineName") %>' runat="server" />
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
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                            <%--CssClass="table table-bordered title6 w-100 NewEnterprise"--%>
                                                        </div>
                                                        <div class="row" id="Div14" runat="server">
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="grdPandM3" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%">
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
                                                                        <asp:TemplateField HeaderText="P&M Id">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPMId" Text='<%#Eval("PMId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Machine Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblMachineName3" Text='<%#Eval("MachineName") %>' runat="server" />
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
                                                                        <asp:TemplateField HeaderText="Foreign Currency">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblForeignCurrencyid" Text='<%#Eval("ForeignCurrency") %>' runat="server" />
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
                                                                        <asp:TemplateField HeaderText="Classification of Machinery">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblClassificationofMachinery" Text='<%#Eval("ClassificationMachineryText") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Invoice">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="hyFilePathMerge2" Text="view" NavigateUrl='<%#Eval("FilePathMerge2")%>' Target="_blank" runat="server" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
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
                                                        <div class="row" runat="server" id="divPMRatio" visible="false">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label" id="Label25" runat="server">Total Value of Textile Products (in Rs)</label>
                                                                <label class="form-control" id="lblTotalValueofTextileProducts" runat="server"></label>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label" id="Label27" runat="server">Total value of Non Textile products (in Rs)</label>
                                                                <label class="form-control" id="lblTotalValueofNonTextileProducts" runat="server"></label>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label" id="Label29" runat="server">Total value of machinery (in Rs)</label>
                                                                <label class="form-control" id="lblTotalValueofAllTextileProducts" runat="server"></label>
                                                            </div>

                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label" id="Label26" runat="server">Textile Products (%)</label>
                                                                <label class="form-control" id="lblValueofTextileProductsPercentage" runat="server"></label>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label" id="Label30" runat="server">Non Textile products (%)</label>
                                                                <label class="form-control" id="lblValueofNonTextileProductsPercentage" runat="server"></label>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trGrosblockdetails" runat="server">
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div13" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Gross Block Details</div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView runat="server" ID="gvGrossblockPandM" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
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
                                                                        <asp:TemplateField HeaderText="G.B Id">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblGBId" Text='<%#Eval("GBId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Audited Balance Sheet Year">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAuditedBalanceSheetYear" Text='<%#Eval("AuditedBalanceSheetYear") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount Gross Block (In Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAmountGrossBlock" Text='<%#Eval("AmountGrossBlock") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Certified By">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCertifiedBy" Text='<%#Eval("CertifiedBy") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Certified Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCertifiedDate" Text='<%#Eval("CertifiedDate") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded File">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="hyFilePathMerge2" Text="view" NavigateUrl='<%#Eval("FilePathMerge2")%>' Target="_blank" runat="server" />
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>

                                                <tr id="trPMPaymentDetails" runat="server" visible="false">
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
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h5 class="text-black font-SemiBold mb-1" style="font-size: small;">IV. Loan Details</h5>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr>
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div6" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Financials of the Enterprise (Last 3 years in Rs Crores)</div>
                                                            <div class="col-sm-12 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>Sl.No</th>
                                                                        <th>Financial Indicator</th>
                                                                        <th id="thYear1" runat="server">Year 1 (Rs in Crores)</th>
                                                                        <th id="thYear2" runat="server">Year 2 (Rs in Crores)</th>
                                                                        <th id="thYear3" runat="server">Year 3 (Rs in Crores)</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td align="left">Turnover</td>
                                                                        <td align="center">
                                                                            <label id="txtTurnoverYear1" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtTurnoverYear2" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtTurnoverYear3" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="left">EBITDA </td>
                                                                        <td align="center">
                                                                            <label id="txtEBITDAYear1" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtEBITDAYear2" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtEBITDAYear3" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>3</td>
                                                                        <td align="left" style="text-align: left">Networth</td>
                                                                        <td align="center">
                                                                            <label id="txtNetworthYear1" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtNetworthYear2" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtNetworthYear3" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>4</td>
                                                                        <td align="left" style="text-align: left">Reserves & Surplus</td>
                                                                        <td align="center">
                                                                            <label id="txtReservesYear1" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtReservesYear2" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtReservesYear3" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>5</td>
                                                                        <td align="left" style="text-align: left">Share Capital of the Promoter</td>
                                                                        <td align="center">
                                                                            <label id="txtShareCapitalYear1" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtShareCapitalYear2" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtShareCapitalYear3" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center" style="height: 30px" colspan="6"></td>
                                                </tr>
                                                <tr>
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div9" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Production Details Preceding Three Years Before Expansion/Diversification/Modernization Project as Certified by the Financial Institution/Chartered Accountant</div>
                                                            <div class="col-sm-12 table-responsive">
                                                                <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                    <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                        <th>Sl.No</th>
                                                                        <th>Year</th>
                                                                        <th>Quantity</th>
                                                                        <th>Value</th>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>1</td>
                                                                        <td align="center">
                                                                            <label id="lblProductionYear1" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtProductionQuantity1" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtProductionValue1" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>2</td>
                                                                        <td align="center">
                                                                            <label id="lblProductionYear2" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtProductionQuantity2" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtProductionValue2" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>3</td>
                                                                        <td align="center">
                                                                            <label id="lblProductionYear3" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtProductionQuantity3" runat="server" class="control-label"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="txtProductionValue3" runat="server" class="control-label"></label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td></td>
                                                                        <td align="center" class="control-label font-SemiBold">Total
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblProductionQuantityTotal" runat="server" class="control-label font-SemiBold"></label>
                                                                        </td>
                                                                        <td align="center">
                                                                            <label id="lblProductionValueTotal" runat="server" class="control-label font-SemiBold"></label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>

                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center" style="height: 30px" colspan="6"></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" style="font-size: small;">Means Of Finance (In Rs.)</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 3%">1</td>
                                                    <td align="left" style="width: 22%">Promoter's Equity</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="txtPromoterEquity" runat="server"></label>
                                                    </td>
                                                    <td align="center" style="width: 3%">2</td>
                                                    <td align="left" style="width: 22%">Institutional/Public Investors</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="txtInstitutionsEquity" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Term Loans</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtTearmLoans" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Seed Capital</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtSeedCapital" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">5</td>
                                                    <td align="left">Subsidy/Grants through other agencies</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtSubsidyagencies" runat="server"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">Finance From Others Sources</td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtMeansFinanceOthers" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center" style="height: 30px" colspan="6"></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center"></td>
                                                    <td align="left">Have you availed Term Loan</td>
                                                    <td align="left" colspan="4">
                                                        <label class="control-label" id="ddlIsTermLoanAvailed" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2" id="tblTermLoanDtls" runat="server" visible="false">
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div7" runat="server">
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
                                                    <td align="center"></td>
                                                    <td colspan="5">
                                                        <div class="row" id="Div8" runat="server">
                                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Financials of the Enterprise (Last 3 years in Rs Crores)</div>
                                                            <div class="col-sm-12 table-responsive">
                                                                <table class="table table-bordered title6 w-100 NewEnterprise">
                                                                    <tr class="GridviewScrollC1HeaderWrap v">
                                                                        <th align="center">Name of Asset
                                                                        </th>
                                                                        <th align="center">Approved Project
                                                                            <br />
                                                                            Cost (In Rs.)
                                                                        </th>
                                                                        <th align="center" id="thLoanSanctioned" runat="server">Loan Sanctioned
                                                                            <br />
                                                                            (In Rs.)
                                                                        </th>
                                                                        <th align="center">Equity from
                                                                            <br />
                                                                            the promoters
                                                                            <br />
                                                                            (In Rs.)
                                                                        </th>
                                                                        <th align="center" id="thLoanAmount" runat="server">Loan Amount
                                                                            <br />
                                                                            Released (In Rs.)
                                                                        </th>
                                                                        <th align="center" id="thLoanassetsfinancial" runat="server">Value of assets (as
                                                                            <br />
                                                                            certified by financial<br />
                                                                            institution) (In Rs.)
                                                                        </th>
                                                                        <th align="center">Value of assets certified
                                                                            <br />
                                                                            by Chartered Accoutant
                                                                            <br />
                                                                            (In Rs.)
                                                                        </th>

                                                                    </tr>

                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>Land
                                                                        </td>
                                                                        <td style="padding-top: 5px;">
                                                                            <label id="txtLand2" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td style="padding-top: 5px;" id="tdLand3" runat="server">
                                                                            <label id="txtLand3" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td style="padding-top: 5px;">
                                                                            <label id="txtLand4" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td style="padding-top: 5px;" id="tdLand5" runat="server">
                                                                            <label id="txtLand5" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td style="padding-top: 5px;" id="tdLand6" runat="server">
                                                                            <label id="txtLand6" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td style="padding-top: 5px;">
                                                                            <label id="txtLand7" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>Buildings
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtBuilding2" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdBuilding3" runat="server">
                                                                            <label id="txtBuilding3" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtBuilding4" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdBuilding5" runat="server">
                                                                            <label id="txtBuilding5" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdBuilding6" runat="server">
                                                                            <label id="txtBuilding6" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtBuilding7" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td class="auto-style1">Plant & Machinery
                                                                        </td>
                                                                        <td class="auto-style1">
                                                                            <label id="txtPM2" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td class="auto-style1" id="tdPM3" runat="server">
                                                                            <label id="txtPM3" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td class="auto-style1">
                                                                            <label id="txtPM4" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td class="auto-style1" id="tdPM5" runat="server">
                                                                            <label id="txtPM5" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td class="auto-style1" id="tdPM6" runat="server">
                                                                            <label id="txtPM6" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td class="auto-style1">
                                                                            <label id="txtPM7" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>Contingencies
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtMCont2" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdMCont3" runat="server">
                                                                            <label id="txtMCont3" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtMCont4" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdMCont5" runat="server">
                                                                            <label id="txtMCont5" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdMCont6" runat="server">
                                                                            <label id="txtMCont6" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtMCont7" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>Erection
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtErec2" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdErec3" runat="server">
                                                                            <label id="txtErec3" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtErec4" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdErec5" runat="server">
                                                                            <label id="txtErec5" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdErec6" runat="server">
                                                                            <label id="txtErec6" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtErec7" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">
                                                                        <td>Technical know-how,<br />
                                                                            feasibility study
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtTFS2" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdTFS3" runat="server">
                                                                            <label id="txtTFS3" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtTFS4" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdTFS5" runat="server">
                                                                            <label id="txtTFS5" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdTFS6" runat="server">
                                                                            <label id="txtTFS6" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtTFS7" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item">
                                                                        <td>Working Capital Margin
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtWC2" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdWC3" runat="server">
                                                                            <label id="txtWC3" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtWC4" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdWC5" runat="server">
                                                                            <label id="txtWC5" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td id="tdWC6" runat="server">
                                                                            <label id="txtWC6" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>
                                                                        <td>
                                                                            <label id="txtWC7" runat="server" class="control-label">
                                                                            </label>
                                                                        </td>

                                                                    </tr>
                                                                    <tr class="GridviewScrollC1Item2">

                                                                        <td>Total</td>
                                                                        <td>
                                                                            <asp:Label ID="lbltotal2" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td id="tdtotal3" runat="server">
                                                                            <asp:Label ID="lbltotal3" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lbltotal4" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td id="tdtotal5" runat="server">
                                                                            <asp:Label ID="lbltotal5" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td id="tdtotal6" runat="server">
                                                                            <asp:Label ID="lbltotal6" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lbltotal7" runat="server" Text=""></asp:Label>
                                                                        </td>

                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h5 class="text-black font-SemiBold mb-1" style="font-size: small;">V. Bank Details</h5>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" style="font-size: small;">Unit Main Operation Bank Details</h6>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 3%">1</td>
                                                    <td align="left" style="width: 22%">Name of the Unit/Enterprise</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="txtAccountName" runat="server"></label>
                                                    </td>
                                                    <td align="center" style="width: 3%">2</td>
                                                    <td align="left" style="width: 22%">Name of the Bank</td>
                                                    <td align="left" style="width: 25%">
                                                        <label class="control-label" id="ddlBank" runat="server"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">3</td>
                                                    <td align="left">Branch Name </td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtBranchName" runat="server"></label>
                                                    </td>
                                                    <td align="center">4</td>
                                                    <td align="left">Account Number</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="txtAccNumber"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">5</td>
                                                    <td align="left">Account Type</td>
                                                    <td align="left">
                                                        <label class="control-label" id="ddlAccountType" runat="server"></label>
                                                    </td>
                                                    <td align="center">6</td>
                                                    <td align="left">IFSC Code</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="txtIfscCode"></label>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Name of the authorized Person for operating the account </td>
                                                    <td align="left">
                                                        <label class="control-label" id="txtaccountauthorizedPerson" runat="server"></label>
                                                    </td>
                                                    <td align="center">8</td>
                                                    <td align="left">Designation</td>
                                                    <td align="left">
                                                        <label class="control-label" runat="server" id="txtaccountauthorizedPersonDesignation"></label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6  w-100 NewEnterprise">
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center"></td>
                                                    <td align="left" colspan="5">
                                                        <h6 class="text-black font-SemiBold mb-1" style="font-size: small;">List of Enclosures Attached</h6>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center"></td>
                                                    <td>
                                                        <div class="row" id="Div11" runat="server">
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
                                            </table>
                                        </div>
                                    </div>
                                    <div class="container" id="DivPrint" runat="server" style="text-align: center; vertical-align: bottom">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                                            <asp:Button ID="btnInstalledcap" runat="server" CssClass="btn btn-blue btn-lg" Text="Home" OnClick="btnInstalledcap_Click" />
                                            <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
                                            <%--<input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="return PrintPopup();" />--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnIncentiveId" Value="0" runat="server" />
            <asp:HiddenField ID="hdnTypeOfIndustry" Value="0" runat="server" />
        </div>
             </ContentTemplate>
    </asp:UpdatePanel>
         <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
    <script src="../../Js/jquery-latest.min.js"></script>
    <%--  <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>--%>
    <script src="../../NewCss/js/excanvas.min.js"></script>
    <script src="../../NewCss/js/jquery.ui.custom.js"></script>
    <script src="../../NewCss/js/bootstrap.min.js"></script>
    <script src="../../NewCss/js/jquery.flot.min.js"></script>
    <script src="../../NewCss/js/jquery.flot.resize.min.js"></script>
    <script src="../../NewCss/js/jquery.peity.min.js"></script>
    <script src="../../NewCss/js/maruti.js"></script>
    <script src="../../NewCss/js/maruti.dashboard.js"></script>
    <script src="../../NewCss/js/maruti.chat.js"></script>
    <%-- <script src="Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/jquery-3.3.1.min.js"></script>
        <script src="../../Scripts/jquery-3.3.1.js"></script>
        <script src="../../AssetsNew/js/bootstrap-datetimepicker.min.js"></script>--%>
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
        function PrintPopup() {
            var divContents = '';
            divContents = document.getElementById("Div16").innerHTML;
            var a = window.open('', '', 'height=500, width=500');
            a.document.write('<html>');
            a.document.write('<body > <h1 align="center">  <br>');
            a.document.write(divContents);
            a.document.write('</body></html>');
            a.document.close();
            a.print();
            return false;
        }
    </script>
    <script src="../../AssetsNew/js/popper.min.js"></script>
    <script src="../../AssetsNew/js/bootstrap.min.js"></script>
    <script src="../../AssetsNew/js/floating.js"></script>
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
