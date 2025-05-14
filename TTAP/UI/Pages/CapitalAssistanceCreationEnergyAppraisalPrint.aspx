<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CapitalAssistanceCreationEnergyAppraisalPrint.aspx.cs" Inherits="TTAP.UI.Pages.CapitalAssistanceCreationEnergyAppraisalPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Appraisal Note</title>
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
    </style>
    <script>

        function PrintScreen() {
            document.getElementById("btnPrint").style.display = 'none';
            print();
            document.getElementById("btnPrint").style.display = 'block';
        }
        document.addEventListener("keydown", function (e) {
            if (e.ctrlKey && e.key === "p") {
                e.preventDefault();
                PrintScreen();
            }
        });
    </script>
</head>
<body style="border: groove;">
    <form id="form1" runat="server">
        <div align="center">
            <div align="center" style="text-align: center">
                <div align="center">
                    <center>
                        <img src="../../../images/logo.png" width="75px" height="75px" />
                    </center>
                    <%--<h3>TTAP CAPITAL APPRAISAL NOTE FORM</h3>--%>
                </div>
                <br />
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
                                  Appraisal Note of Capital Assistance for Creation of Energy, Water and Environmental Conservation Infrastructure<br />

                                    <asp:Label ID="lblSancIncentiveName" runat="server"></asp:Label>
                                </b></u>
                            </td>
                        </tr>
                    </table>
                    <table bgcolor="White" width="100%" style="font-family: Verdana; font-size: small;">
                        <tr>
                            <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12"><b></b>
                            </td>
                            <td colspan="4" style="padding: 5px; margin: 5px;">
                                <b>INDUSTRY DETAILS</b> </td>
                            <td class="auto-style25">&nbsp;
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td style="font: bolder; font-size: small" class="auto-style1">1. Unit Name
                            </td>
                            <td>

                                <asp:Label ID="lblUnitName" runat="server"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">2. Address
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">3. Name of the Proprietor
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblProprietor" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">4. Constitution of Organization
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblConstitutionOfIndustrial" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">5. Social Status
                            </td>
                            <td>
                                <asp:Label ID="lblSocialStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr runat="server" visible="false">
                            <td style="width: 2%"></td>
                            <td class="auto-style1">6. Share of SC/ST/Women Enterpreneur
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblShareofSCSTWomenEnterprenue" runat="server"></asp:Label>

                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">6. Registration Number
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblRegistrationNumber" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">7. Type of Unit
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblTypeofApplicant" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">8. Category of Unit as per Application
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblCategoryofUnit" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">9. Type of Sector
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblApplicationDateDIC" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">10. Type of Textile as per Application
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblTypeofTexttile" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">11. Technical Textile Type
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblTechnicalTextileType" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">12.  Activity of the Unit
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblActivityoftheUnit" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">13. UID Number
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblUIDNumber" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">14.  Incentive Application Number
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblCommonApplicationNumber" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">15.  Date of Power Connection Release
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblPowerConnectionReleaseDate" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">16.  Commencement of Commercial Production
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblDCPdate" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 2%"></td>
                            <td class="auto-style1">17.  Date of Receipt of Claim Application
                            </td>
                            <td>
                                <span>
                                    <asp:Label ID="lblReceiptDate" runat="server"></asp:Label>
                                </span>
                            </td>
                        </tr>


                    </table>
                    <div class="row">
                        <table>
                            <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12"><b></b>
                                </td>
                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                    <b>Eqipment Details</b> </td>
                                <td class="auto-style25">&nbsp;
                                </td>

                            </tr>
                        </table>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                            <asp:GridView ID="GvEquipmentDtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
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
                                    <asp:TemplateField HeaderText="Name of the Equipment">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNameoftheEquipment" runat="server" Text='<%# Bind("EquipmentName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("CategoryName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEquipmentInvoiceNo" runat="server" Text='<%# Bind("EquipmentInvoiceNo") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEquipmentInvoiceDate" runat="server" Text='<%# Bind("EquipmentInvoiceDate") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="IPO Recommended Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDLORecommendedEqipmentCost" runat="server" Text='<%# Bind("DLORecommendedEqipmentCost") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Recommended Amount">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecommendedEqipmentCost" runat="server" Text='<%# Bind("RecommendedEqipmentCost") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="Total (Rs)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTotal" onkeypress="DecimalOnly()" CssClass="form-control" runat="server" Text='<%# Bind("Total") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Equipment ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEquipment_ID" runat="server" Text='<%# Bind("EqipmentID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="row">
                        <table>
                            <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12"><b></b>
                                </td>
                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                    <b>Total Amounts</b> </td>
                                <td class="auto-style25">&nbsp;
                                </td>

                            </tr>
                        </table>
                    </div>
                    <div class="row" runat="server">
                        <table style="width: 93%">
                            <tr id="tr1" runat="server" visible="true">
                                <td></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Total Cost of Equipment for Energy Conservation Infra</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblEnergyEquipmentTotal" runat="server" Text="[Guideline Value]"
                                        Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                </td>
                                <td></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Total Cost of Equipment for Water Conservation Infra</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblWaterEquipmentTotal" runat="server" Text="[Guideline Value]"
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
                            <tr id="tr2" runat="server" visible="true">
                                <td></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Total Cost of Equipment for Environmental Conservation Infra</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblEnvironmentalEquipmentTotal" runat="server" Text="[Guideline Value]"
                                        Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                </td>
                                <td></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Total Cost of CET Plant at Industrial Park / Cluster</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblEffluentTreatmentCotal" runat="server" Text="[Guideline Value]"
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
                        </table>
                    </div>
                    <div class="row">
                        <table>
                            <tr>
                                <td style="padding: 5px; margin: 5px; font-weight: bold;" valign="top" class="auto-style12"><b></b>
                                </td>
                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                    <b>Eligible Subsidy Amount</b> </td>
                                <td class="auto-style25">&nbsp;
                                </td>

                            </tr>
                        </table>
                    </div>
                    <div class="row" runat="server">
                        <table style="width: 93%">
                            <tr id="tr4" runat="server" visible="true">
                                <td></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Eligible Cost of Equipment for Energy Conservation Infra</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblEligibleEnergy" runat="server" Text="[Guideline Value]"
                                        Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                </td>
                                <td></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Eligible Cost of Equipment for Water Conservation Infra</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblEligibleWater" runat="server" Text="[Guideline Value]"
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
                            <tr id="tr5" runat="server" visible="true">
                                <td></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Eligible Cost of Equipment for Environmental Conservation Infra</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblEligibleEnvironmental" runat="server" Text="[Guideline Value]"
                                        Height="30px" MaxLength="80" Enabled="false" TabIndex="34" Width="150px"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">&nbsp;
                                </td>
                                <td></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Eligible Cost of CET Plant at Industrial Park / Cluster</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblEligibleCET" runat="server" Text="[Guideline Value]"
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
                        </table>
                    </div>
                    <br />
                    <div>
                        <div class="col-sm-12 form-group" >
                            <b>Note : 1). Handloom:</b> 70% restricted to Rs. 2 Cr. <b>2). Others: </b>50% restricted to Rs. 10 Cr.
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <table style="width: 100%">
                            <tr id="tr4231" runat="server" visible="true">
                                <td class="auto-style56"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style57">Calculated Subsidy Amount</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style56">:</td>
                                <td class="auto-style56">
                                    <asp:Label ID="lblCalculatedSubsidyAmount" runat="server" Text="[Guideline Value]"
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
                            <tr>
                                <td class="auto-style55"></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style55">GM Recommended Amount</td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style55">:</td>
                                <td class="auto-style55">
                                    <asp:Label ID="lblGMAmount" runat="server" CssClass="form-control txtbox txtcomn"
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
                            <tr runat="server" visible="false">
                                <td></td>
                                <td style="padding: 5px; margin: 5px;">Eligible Subsidy Amount</td>
                                <td style="padding: 5px; margin: 5px;">:</td>
                                <td>&nbsp;
                           <asp:Label ID="lblEligibletotal" runat="server" CssClass="form-control txtbox txtcomn"
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
                            <tr>
                                <td></td>
                                <td style="padding: 5px; margin: 5px;">Eligibility Type</td>
                                <td style="padding: 5px; margin: 5px;">:</td>
                                <td>&nbsp;
                           <asp:Label ID="lblEligibilityType" runat="server" CssClass="form-control txtbox txtcomn"
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
                                <td style="padding: 5px; margin: 5px;">Final Subsidy Amount</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="lblFinalSubsudyAmount" runat="server" CssClass="form-control txtbox" Text="[Department]"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                            <tr runat="server" visible="false">
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
                            <tr runat="server" visible-="false" id="trRemarks">
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Remarks</td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:Label ID="lblRemarks" runat="server" CssClass="form-control txtbox" Text="[Department]"></asp:Label>
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style20"><strong></strong></td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style29"></td>
                                <td style="padding: 5px; margin: 5px;"></td>
                                <td style="padding: 5px; margin: 5px;">&nbsp; 
                                </td>
                                <td style="padding: 5px; margin: 5px;">&nbsp;
                                </td>
                            </tr>
                            <tr id="worksheet" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px;" class="ui-priority-primary"></td>
                                <td style="padding: 5px; margin: 5px;">Work Sheet </td>
                                <td style="padding: 5px; margin: 5px;">:
                                </td>
                                <td style="padding: 5px; margin: 5px;" class="auto-style28">
                                    <asp:HyperLink ID="hypworksheet" Text="View" runat="server"></asp:HyperLink>
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
                    type="button" value="Print" onclick="return PrintScreen();" />
                &nbsp;&nbsp;&nbsp; <a href="HomeDashboard.aspx" runat="server" visible="false">HOME</a>
            </div>
        </div>
    </form>
</body>
</html>
