<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FormSanctionReport.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.FormSanctionReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #search {
            position: unset !important;
        }

        .SetgridWidth {
            width: 548px;
        }

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
        .tableFixHead {
            overflow: auto;
        }

            .tableFixHead th {
                position: sticky;
                top: 0;
            }

        /* Just common table stuff. */
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px 16px;
        }

        th {
            /*background: #eee;*/
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="A2" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Applications</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="../frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="frmIncentiveReports.aspx">Reports</a></li>
                            <li class="breadcrumb-item">R13.Sanctioned/Released Incentives</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <table>
                            <tr>
                                <td>
                                    <h5 id="header" runat="server" class="text-blue mt-1 mb-3 font-SemiBold">R13.Sanctioned/Released Incentives-Detailed Report</h5>
                                </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                <td><a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: left">
                                    <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                        alt="Excel" /></a>  </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                            </tr>
                        </table>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                            <td>
                                                <label style="margin: 6px 4px 5px 16px; display: block;">
                                                    District : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistrict" Style="display: block;" CssClass="form-control" runat="server"></asp:DropDownList></td>
                                            <td>
                                                <label style="margin: 6px 4px 5px 16px; display: block;">
                                                    Unit : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlUnits" Style="display: block;" CssClass="form-control" runat="server"></asp:DropDownList></td>
                                            <td>
                                                <asp:Button Text="Search" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                            </td>
                                        </tr>
                                    </table>


                                </div>
                                <div class="tableFixHead" style="overflow-y:hidden">
                                  <div style="text-align-last: center; font-size: large; font-weight: 900; color: green; margin: 0px 0px 8px 0px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblHeader" runat="server">Chanikya Gopal Katakamsetti</asp:Label>
                                    </td>
                                </tr>
                            </div>
                                    <div class="col-sm-12 table-responsive">
                                        <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                            CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"
                                            PageSize="20" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound">
                                            <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                            <FooterStyle CssClass="GridviewScrollC1Header" />
                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                            <Columns>
                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="S No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1%>
                                                        <asp:HiddenField ID="HdfQueid" runat="server" />
                                                        <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name & Address">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TYPE_OF_INDUSTRY" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Industry">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DCP" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Commencement of Production">
                                                    <ItemStyle CssClass="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Details" ControlStyle-CssClass="SetgridWidth" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:GridView ID="gvIncentives" AutoGenerateColumns="false" CssClass="SetgridWidth" ShowHeader="true"
                                                            runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="ApplicationNo" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ApplicationDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Submission Date">
                                                                    <ItemStyle CssClass="Center" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ClaimAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Claim Amount">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ClaimPeriod" ItemStyle-HorizontalAlign="Center" HeaderText="Claim Period">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Eligible_for_DLC_SLC" ItemStyle-HorizontalAlign="Center" HeaderText="Eligible for DLC/SLC">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SVC_Actual_Meeting_Date" ItemStyle-HorizontalAlign="Center" HeaderText="Date of DLSVC/SL SVC">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TextileSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Carpet Textiles @ 88.20%(SVC)">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="IndustrySanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="LVT @ 11.80%(SVC)">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SVC_FinalSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Total Recommdation of SVC">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="TextileSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Carpet Textiles @ 88.20%">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="IndustrySanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="LVT @ 11.80%">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SLCSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Total SLC Sanctioned Amount">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SanctionedLetterIssuedOn" ItemStyle-HorizontalAlign="Center" HeaderText="Sanction Letter Issued Date">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Carpet Textiles @ 88.20%(Released)">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="LVT @ 11.80%(Released)">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ReleasedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Amount Released">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ReleaseProcedingNo" ItemStyle-HorizontalAlign="Center" HeaderText="Release Proceding No">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="ReleaseProcedingDate" ItemStyle-HorizontalAlign="Center" HeaderText="Release Proceeding Date">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Carpet Textiles @ 88.20%(Balance)">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="LVT @ 11.80%(Balance)">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="BalanceAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Total Balance to be released">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Remarks">
                                                                    <ItemStyle CssClass="text-left" />
                                                                </asp:BoundField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblUnitId" Text='<%#Eval("UnitId") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div align="center">No Data Found</div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery.sticky/1.0.4/jquery.sticky.min.js"></script>--%>

    <script src="../../../NewCss/js/jquery.min.js"></script>
    <script src="../../../js/jquery.floatThead.js"></script>

</asp:Content>
