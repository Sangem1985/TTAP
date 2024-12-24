<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FinalPage.aspx.cs" Inherits="TTAP.UI.Pages.FinalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }
    </style>
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
                            <div class="row" id="divheadermsg" runat="server" visible="false">
                                <h3 class="text-blue mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Incentive Applied Successfully and Application has been Submitted to Respective DLO</h3>
                            </div>
                        </div>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-2 form-group">
                                </div>
                                <div class="col-sm-8 form-group" id="divdraftpage" runat="server" visible="false">

                                    <table cellpadding="10px" style="width: 100%; height: 80px; border-color: black; border-style: solid; font-weight: bold" border="2px">
                                        <tr>
                                            <td align="left">Incentives Application Form</td>

                                            <td>
                                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Acknowledgement</asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="LinkDraftCopy" runat="server" OnClick="LinkDraftCopy_Click">DraftCopy</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="col-sm-2 form-group">
                                </div>
                            </div>
                            <div class="row" id="Div2" runat="server">
                                <div class="col-sm-2 form-group">
                                </div>
                                <div class="col-sm-8 form-group">
                                    <div class="col-sm-12 text-blue font-SemiBold mb-1">Annexures</div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                        <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                            CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                            HorizontalAlign="Left" ShowHeader="true">
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
                                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Incentives">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl" runat="server" Text='<%# Eval("IncentiveName")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLinkSubsidy" Text="Print" NavigateUrl='<%#Eval("AnnexureURL")%>' Target="_blank" runat="server" />
                                                    </ItemTemplate>
                                                    <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div class="col-sm-2 form-group">
                                </div>
                            </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
  

    <div>
        <table style="width: 100%">
            <%-- <tr>
                <td style="width: 65%; color: green; font-weight: bold; font-size: x-large; height: 200px" align="center" id="tdmsg" runat="server">Incentives Applied Successfully</td>
            </tr>--%>
            <tr id="tr1" runat="server" visible="false" style="height: 40px" width="65%">
                <td align="center" colspan="4"></td>
            </tr>
            <tr>
                <td>
                   <asp:Label runat="server" ID="lblFails"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="align: center">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 table-responsive mt-2">
                    </div>
                </td>
            </tr>
           
            <tr>
                <td></td>
            </tr>

        </table>
    </div>
</asp:Content>
