<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmUnitsDetailedReport.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.frmUnitsDetailedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <style>
        #search {
            position: unset !important;
        }

        .SetgridWidth {
            width: 548px;
        }

        .ScrollStyle {
            max-height: 150px;
            overflow-y: scroll;
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
                        <a href="#" class="current" runat="server" id="acurrentpage">Unit Wise Report</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="../frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="frmIncentiveReports.aspx">Reports</a></li>
                            <li class="breadcrumb-item">Unit Wise Report</li>
                        </ul>
                    </div>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 id="head" runat="server" class="text-blue mt-1 mb-3 font-SemiBold">Unit Wise Report</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div class="col-sm-12 mb-3 d-flex">
                                    <asp:TextBox ID="txtsearch" runat="server" class="form-control w-sm-50 w-75" Style="max-width: 400px;" placeholder="Type to search"></asp:TextBox>
                                    <asp:Button Text="Search" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                    <asp:Button Text="Reset" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnReset" runat="server" OnClick="btnReset_Click" />
                                    
                                    <label style="margin: 6px 4px 5px 16px; display: none;">
                                        Order By : 
                                    </label>
                                    <asp:RadioButtonList ID="rdbOrderby" Style="margin: 0px 0px 0px 11px; display: none;"
                                        runat="server" AutoPostBack="true" OnSelectedIndexChanged="Order_Changed" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="D">Date</asp:ListItem>
                                        <asp:ListItem Value="N">Name</asp:ListItem>
                                    </asp:RadioButtonList>
                                    <label style="margin: 6px 4px 5px 16px; display: none;">
                                        District : 
                                    </label>
                                    <asp:DropDownList ID="ddlDistrict" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Style="display: none;" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-sm-12 mb-3  text-right">
                                    <a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: right">
                                        <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                            alt="Excel" /></a>
                                </div>
                                <div runat="server" id="TotalGrid" class="col-sm-12 table-responsive">
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
                                         
                                            <asp:BoundField DataField="UNIT_NAME" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="District_Name" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ADDRESS" ItemStyle-HorizontalAlign="Center" HeaderText="Address">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CATEGORY" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCP" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Commencement of Production">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DirectEmployees" ItemStyle-HorizontalAlign="Center" HeaderText="Employment">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Actual_Investment" ItemStyle-HorizontalAlign="Center" HeaderText="Total Investment(Rs)">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="FirstInvestment" ItemStyle-HorizontalAlign="Center" HeaderText="Date of First Investment">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="LastInvestment" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Last Investment">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TYPE_OF_INDUSTRY" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TEXTILE_PROCESS_NAME" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeofTexttileText" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Textile">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TechnicalTextile" ItemStyle-HorizontalAlign="Center" HeaderText="Technical Textile Type">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="APPLICANT_NAME" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MOBILE_NO" ItemStyle-HorizontalAlign="Center" HeaderText="Mobile No">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Incentives Details" ControlStyle-CssClass="SetgridWidth" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:GridView ID="gvIncentives" CssClass="SetgridWidth" ShowHeader="true"
                                                        runat="server">
                                                    </asp:GridView>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Create By" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreateBy" Text='<%#Eval("CreatedBy") %>' runat="server" />
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
            <asp:HiddenField ID="hdnDistName" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../../../Js/jquery-latest.min.js"></script>
    <script src="../../../Js/jquery-ui.min.js"></script>
    <script src="../../../Js/jquery.min.js"></script>
    <%--<script src="../../../Js/table2excel.js"></script>--%>

    <script src="../../../js/jquery.floatThead.js"></script>



    <script type="text/javascript">
       
       /* function Export() {
            event.preventDefault();
            var file_name = "UnitWiseReport.xls";
            $("#ContentPlaceHolder1_gvdetailsnew").table2excel({
                filename: file_name

            });
        }*/
    </script>
</asp:Content>
