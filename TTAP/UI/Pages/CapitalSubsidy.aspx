<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapitalSubsidy.aspx.cs" Inherits="TTAP.UI.Pages.CapitalSubsidy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Capital Appraisal Note</title>
    <style>
        .div3 {
            /*-webkit-column-count: 3;
    -moz-column-count: 3; 
    column-count: 3; */
            -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
            -moz-column-gap: 40px; /* Firefox */
            column-gap: 40px;
        }

        .w3-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 17px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        .w4-code {
            border-left: 5px solid #73AD21 !important;
            font-size: 14px;
            padding: 5px;
            font-weight: bold;
            color: #082ea2;
        }

        ol.u {
            list-style-type: none;
            ;
            font-size: 13px;
            padding: 10px 10px 10px 10px;
        }

        ol.v {
            list-style-type: inherit;
            font-size: 17px;
            font-weight: bold;
            padding: 10px 10px 10px 10px;
        }

        .table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            text-align: left;
            border: 2px solid ActiveCaptionText;
            padding: 8px;
        }

        }

        .auto-style1 {
            width: 333px;
        }

        .auto-style2 {
            height: 50px;
        }

        .auto-style4 {
            height: 34px;
        }

        .auto-style8 {
            width: 38%;
        }

        .auto-style18 {
            height: 34px;
            width: 38%;
        }

        .auto-style19 {
            width: 142px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/telanganalogo.png" width="75px" height="75px" />
                    </center>
                    <%--<h3>TTAP CAPITAL APPRAISAL NOTE FORM</h3>--%>
                </div>
                <br />
                <div>
                    <div>
                        <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                            <tr id="tideaTr" runat="server" visible="false">
                                <td style="text-align: left; font-weight: bold;">
                                    <asp:Label ID="lblTideaTpride" runat="server" Visible="false" Text="Label"></asp:Label>
                                    Telangana State Industrial Development and Entrepreneur Advancement - G.O M.S. NO
                                29, Industries &amp; Commerce (IP &amp; INF) Department,
                                <br />
                                    Dated : 29/11/2014
                                </td>
                            </tr>
                            <tr id="tprideTr" runat="server" visible="false">
                                <td style="text-align: center; font-weight: bold;">T-PRIDE -
                                <asp:Label ID="lblCaste" runat="server" Visible="false" Text="Label"></asp:Label>
                                    - G.O M.S. NO 29, Industries &amp; Commerce (IP &amp; INF) Department,
                                <br />
                                    Dated : 29/11/2014
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; vertical-align: middle">
                                    <u><b>
                                        <%--Telangana State Industrial Development and Entrepreneur Advancement - GO MS. NO 28, Industries & Commerce (IP & INF) Department, Dated : 29/11/2014--%>
                                  Reimbursement of Capital Subsidy	<br />

                                        <asp:Label ID="lblSancIncentiveName" runat="server"></asp:Label>
                                    </b></u>
                                </td>
                            </tr>
                        </table>
                        <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">Application no
                                </td>
                                <td>
                                    <asp:Label ID="lblApplication_no" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td style="font: bolder; font-size: small" class="auto-style1">
                                    <b>1 Name of Industrial Concern</b>
                                </td>
                                <td>
                                    <b>
                                        <asp:Label ID="lblUnitname" runat="server"></asp:Label></b> &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">2 Location of the Industrial concern
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblLocaddress" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">3 Name of Promoter
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblPromoterName" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">4 Constitution of the Industrial Concern
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblConstitutionOfIndustrial" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">5 Social Status
                                </td>
                                <td>
                                    <asp:Label ID="lblSocialStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">6 Share of SC/ST/Women Enterpreneur
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblEntrprName" runat="server"></asp:Label>
                                        <b>
                                            <asp:Label ID="lblwomen" runat="server" Visible="false"></asp:Label></b>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">7 PMT SSI Registration. No. &amp; Date
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblSSIRegn" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">8 New/Expansion/Diversification Unit
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblNewExpnDiver" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">9 Date of commencement of production
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblCommencmentOfCommrclProdcn_Date" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">10 Date of filing of claim application in DIC
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblApplicationDateDIC" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">11 Name of Financing Institution in case of Aided Units
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblFinInstn" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="TRCLAIMPERIOD" runat="server" visible="false">
                                <td style="width: 2%"></td>
                                <td class="auto-style1">12 Claim Period
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblclaimperiod" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="TRSCHEME" runat="server" visible="false">
                                <td style="width: 2%"></td>
                                <td class="auto-style1">13 Scheme
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblScheme" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 2%"></td>
                                <td class="auto-style1">Confirmed Details by GM
                                </td>
                                <td>
                                    <span>
                                        <asp:Label ID="lblDetailsConfirmed" runat="server"></asp:Label>
                                    </span>
                                </td>
                            </tr>
                            <tr id="clerkattachment" runat="server" visible="false">
                                <td style="width: 2%"></td>
                                <td class="auto-style1">Clerk Worksheet
                                </td>
                                <td>
                                    <span>
                                        <asp:HyperLink ID="hylinkattachment" Text="View" runat="server" Visible="false"></asp:HyperLink>
                                    </span>
                                </td>
                            </tr>

                        </table>
                        <div>
                            <%--//style="font-family: Verdana; font-size: small;"--%>
                            <table style="width: 100%; font-family: Verdana; font-size: small">
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <u><b>Line of Activity</b></u>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 2%"></td>
                                    <td>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divLineNew" runat="server" visible="false">
                                            <asp:GridView ID="GvLineOfactivityDetails" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
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
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLineUnitID" runat="server" Text='<%# Bind("UnitID") %>'></asp:Label>
                                                            <asp:Label ID="lblLineofActivityId" runat="server" Text='<%# Bind("Line_of_Activity_Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divLineExp" runat="server" visible="false">
                                            <asp:GridView ID="GvLineOfactivityExpnsionDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
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
                                                            <asp:Label ID="lblExpValuePerUnitRs" runat="server" Text='<%# Bind("ValuePerUnit") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Value (in Rs.)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblValueRs" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLineUnitID" runat="server" Text='<%# Bind("UnitID") %>'></asp:Label>
                                                            <asp:Label ID="lblLineofActivityId" runat="server" Text='<%# Bind("Line_of_Activity_Id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <%--</table>--%>
                        <%-- capital subsidy appraisal --%>
                        <div class="row">
                            <table style="width: 74%">
                                <tr style="height: 30px">
                                    <td colspan="10" style="padding: 5px; margin: 5px; font-weight: bold; font-size: medium">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12"><b></b>
                                    </td>
                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                        <b>ABSTRACT</b> </td>



                                    <td class="auto-style25">&nbsp;
                                    </td>

                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style13">i)&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style11">Land</td>
                                    
                                    <td style="margin: 5px;" class="auto-style6">
                                        <asp:Label ID="lblLand" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                    
                                    <td style="margin: 5px;" class="auto-style23">
                                        <asp:Label ID="lblLandValue" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style49">ii).</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style50">Building</td>
                                    
                                    <td style="margin: 5px;" class="auto-style52">
                                        <asp:Label ID="lblBuilding" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                    
                                    <td style="margin: 5px;" class="auto-style39">
                                        <asp:Label ID="lblBuildingValue" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style43">iii).</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style44">Plant and Machinery</td>
                                    
                                    <td style="margin: 5px;" class="auto-style46">
                                        <asp:Label ID="lblPlantMachinery" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                    
                                    <td style="margin: 5px;" class="auto-style41">
                                        <asp:Label ID="lblPlantMachineryValue" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style14">iv).</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style10">Technical Know-how feasibility study and turn Key Charges</td>
                                    
                                    <td style="margin: 5px;" class="auto-style5">
                                        <asp:Label ID="lblTechnicalKnowhow" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                    
                                    <td style="margin: 5px;" class="auto-style24">
                                        <asp:Label ID="lblTechnicalKnowhowValue" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="padding: 5px; margin: 5px;" valign="top" class="auto-style14">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style10">
                                        <b>Total</b>
                                    </td>
                                    
                                    <td style="margin: 5px;" class="auto-style5">
                                        <asp:Label ID="lbltotal" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                    
                                    <td style="margin: 5px;" valign="top" class="auto-style24">
                                        <asp:Label ID="lbltotalValue" runat="server" CssClass="form-control txtbox"></asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </div>

                        <%-- sec --%>
                        <div class="row">
                            <table style="width: 100%">
                                
                                <tr>
                                    <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px">4.2.3
                                    </td>
                                    <td colspan="4" style="padding: 5px; margin: 5px;">
                                        <b>ELEGIBLE INCENTIVES</b></td>

                                </tr>
                                <tr id="trIndustryStatus" runat="server" visible="true">
                                    <td class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Industry Status</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblIndustryStatus" runat="server" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trCONVENTIONALTECHNICAL" runat="server">
                                    <td class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Select</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblConventionalTech" runat="server" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="tr1" runat="server" visible="true">
                                    <td class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Nature Of Industry</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblTextileProcessType" runat="server" CssClass="form-control"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trCategory" runat="server" visible="true">
                                    <td class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Category of Unit</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td style="padding: 5px; margin: 5px;">
                                        <asp:Label ID="lblCategory" runat="server" Text="[Guideline Value]" CssClass="form-label"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trcaste" runat="server" visible="true">
                                    <td class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Select</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblCatCaste" runat="server" Text="[Selected Category]" CssClass="form-label"></asp:Label>
                                    </td>

                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                </tr>
                                <tr id="trmenwomen" runat="server">
                                    <td class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Select Men/Women</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblGender" runat="server" Text="[Selected Gender]" CssClass="form-label"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;</td>
                                </tr>

                                <tr id="treligibility" runat="server">
                                    <td class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">Select Type</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56" colspan="3">
                                        <asp:Label ID="lblEligibility" runat="server" Text="[Selected Eligibility]" CssClass="form-label"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                </tr>


                                <tr id="trEligible" runat="server">
                                    <td class="auto-style48"></td>
                                    <td class="auto-style48">Eligible %
                                    </td>
                                    <td class="auto-style48">:</td>
                                    <td class="auto-style48">

                                        <asp:Label ID="lblEligibilitySub" runat="server" CssClass="form-control txtbox txtcomn" Text="[Value]"></asp:Label>

                                    </td>
                                </tr>
                                <tr id="tr4231" runat="server" visible="true">
                                    <td class="auto-style56">4.1</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style57">State Investment Subsidy in Rs.</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                    <td class="auto-style56">
                                        <asp:Label ID="lblSubsidyAmount" runat="server" Text="[Guideline Value]"
                                            Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                    </td>
                                </tr>
                                <tr id="tr4232" runat="server" visible="true">
                                    <td class="auto-style55">4.2</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">Addl Sub. for Women in Rs.</td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">:</td>
                                    <td class="auto-style55">
                                        <asp:Label ID="lblAddSubAmount" runat="server" CssClass="form-control txtbox txtcomn"
                                            Height="30px" MaxLength="80" TabIndex="36" Width="150px" Text="[TSSFC Norms]"></asp:Label>

                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55"></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style55">&nbsp;
                                    </td>
                                </tr>
                                <tr id="tr4233" runat="server" visible="true">
                                    <td>4.3</td>
                                    <td style="padding: 5px; margin: 5px;">TOTAL SUBSIDY(4.1 + 4.2)</td>
                                    <td style="padding: 5px; margin: 5px;">:</td>
                                    <td>&nbsp;
                           <asp:Label ID="lblTotalSubAmt" runat="server" CssClass="form-control txtbox txtcomn"
                               Height="30px" MaxLength="80" TabIndex="37" Width="150px" Text="[Value 424]"></asp:Label>

                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>
                                <tr id="tradremarks" runat="server" visible="true">
                                    <td>4.4</td>
                                    <td style="padding: 5px; margin: 5px;">Remarks</td>
                                    <td style="padding: 5px; margin: 5px;">:</td>
                                    <td>&nbsp;
                           <asp:Label ID="lblRemarks" runat="server" CssClass="form-control txtbox txtcomn"
                               Height="30px" TabIndex="37" Width="150px" Text="[Remarks]"></asp:Label>

                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;</td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                    <td style="padding: 5px; margin: 5px;">Forward To</td>
                                    <td style="padding: 5px; margin: 5px;">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                        <asp:Label ID="lblDepartment" runat="server" CssClass="form-control txtbox" Text="[Department]"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                    <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                    <td style="padding: 5px; margin: 5px;"></td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp; 
                                    </td>
                                    <td style="padding: 5px; margin: 5px;">&nbsp;
                                    </td>
                                </tr>                            

                                
                            </table>
                        </div>
                    </div>

                </div>
                <br />
                <div>
                    <br />
                    <br />
                    <input id="btnPrint" style="border-right: thin solid; border-top: thin solid; border-left: thin solid; border-bottom: thin solid"
                        type="button" value="Print" />
                    &nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx">HOME</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
