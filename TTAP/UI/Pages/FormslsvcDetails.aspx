<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FormslsvcDetails.aspx.cs" Inherits="TTAP.UI.Pages.FormslsvcDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">SLC Details</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">SLC Details</li>
                        </ul>
                    </div>
                    <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                        <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                            <div class="widget-content nopadding">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div>
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="grdDetails_RowCommand">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="50px">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSlno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SLC No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSlcNo" runat="server" Text='<%# Bind("SLC_NO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SLC Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSlcDate" runat="server" Text='<%# Bind("SlcDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnAdd" CommandName="RowAdd" runat="server" Text="Add" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="100px">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnView" CommandName="RowView" runat="server" Text="View" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="false" HeaderText="Incentive">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSlc_No" runat="server" Text='<%# Bind("SlcNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div style="display:none">
                                            <asp:Button Text="Add New" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnAdd" runat="server" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
