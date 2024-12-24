<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FrmNatureWiseReportAbstract.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.FrmNatureWiseReportAbstract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Abstract</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="../frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="frmIncentiveReports.aspx">Reports</a></li>
                            <li class="breadcrumb-item">Type of Textile/Nature of Industry/Category Wise Abstract Report</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>

                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Type of Textile/Nature of Industry/Category Wise Abstract Report</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                 <div runat="server" id="divCats" style="font-family: 'Montserrat-SemiBold';"
                                    class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                            <td>
                                                <label style="display: block;">
                                                    Abstract Type : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rdbType" OnSelectedIndexChanged="rdbType_SelectedIndexChanged"  Style="display: block;"
                                                    runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="T">Textile Type Wise</asp:ListItem>
                                                    <asp:ListItem Value="N">Nature of Industry Wise</asp:ListItem>
                                                    <asp:ListItem Value="C">Category Wise</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="DivNature" runat="server" class="col-sm-12 table-responsive">
                                    <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" ShowFooter="true"
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
                                            <asp:BoundField DataField="DISTNAME" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units"
                                                DataTextField="NoOfUnits">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Ginning"
                                                DataTextField="Ginning">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Spinning"
                                                DataTextField="Spinning">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Weaving"
                                                DataTextField="Weaving">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Garmenting"
                                                DataTextField="Garmenting">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Processing"
                                                DataTextField="Processing">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Pressing Mills"
                                                DataTextField="PressingMills">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Others"
                                                DataTextField="Others">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="DistrictId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistrictId" Text='<%#Eval("DISTID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                 <div id="DivTextile" runat="server" class="col-sm-12 table-responsive">
                                    <asp:GridView ID="GvTextileGrid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" ShowFooter="true"
                                        PageSize="20" GridLines="Both" OnRowDataBound="GvTextileGrid_RowDataBound">
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
                                            <asp:BoundField DataField="DISTNAME" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units"
                                                DataTextField="NoOfUnits">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Technical Textile"
                                                DataTextField="Technical">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Conventional Textile"
                                                DataTextField="Conventional">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            
                                            <asp:TemplateField HeaderText="DistrictId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistrictId" Text='<%#Eval("DISTID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                 <div id="DivCategory" runat="server" class="col-sm-12 table-responsive">
                                    <asp:GridView ID="GvCategoryGrid" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" ShowFooter="true"
                                        PageSize="20" GridLines="Both" OnRowDataBound="GvCategoryGrid_RowDataBound">
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
                                            <asp:BoundField DataField="DISTNAME" ItemStyle-Width="15%" ControlStyle-Font-Bold="true" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="15%"  HeaderText="No of Units"
                                                DataTextField="NoOfUnits">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="A1"
                                                DataTextField="A1Category">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="A2"
                                                DataTextField="A2Category">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="A3"
                                                DataTextField="A3Category">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="A4"
                                                DataTextField="A4Category">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="A5"
                                                DataTextField="A5Category">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            
                                            <asp:TemplateField HeaderText="DistrictId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDistrictId" Text='<%#Eval("DISTID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>
                        </div>
                    </div>
                    <asp:Button Text="Print" ID="btnprint" runat="server" Style="margin: 0px 0px 0px 630px; background: chartreuse; width: 8%;" OnClientClick="return Print();" />
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hdnRoleCode" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery.sticky/1.0.4/jquery.sticky.min.js"></script>--%>

    <script src="../../../NewCss/js/jquery.min.js"></script>

    <script type="text/javascript">
        function Print() {
            $('#ContentPlaceHolder1_btnprint').hide();
            $('#ContentPlaceHolder1_lbtnback').hide();
            window.print();
            $('#ContentPlaceHolder1_btnprint').show();
            $('#ContentPlaceHolder1_lbtnback').show();
            return false;
        }

        $(function () {
            $('#search').val('');
            $('#search1').val('');



            if ($('table.floatingTable1').not('thead')) {
                var len = $('table.floatingTable1 tr').has('th').length;
                $('table.floatingTable1').prepend('<thead></thead>')
                for (i = 0; i < len; i += 1) {
                    $('table.floatingTable1').find('thead').append($('table.floatingTable1').find("tr:eq(" + i + ")"));
                }
            }



            var $table = $('table.floatingTable1');
            $table.floatThead();
            $table.floatThead({ position: 'fixed' });
            $table.floatThead({ autoReflow: 'true' });


        });

        $('#search').keyup(function () {
            var value = $(this).val();
            var patt = new RegExp(value, "i");

            $('#ContentPlaceHolder1_gvdetailsnew tbody').find('tr').each(function () {
                if (!($(this).find('td').text().search(patt) >= 0)) {
                    $(this).not('thead').hide();
                }
                if (($(this).find('td').text().search(patt) >= 0)) {
                    $(this).show();
                }
            });

        });

        $('#clear').click(function () {

            $('#search').val('');
            $('#ContentPlaceHolder1_gvdetailsnew tbody tr').show();
        });
    </script>
</asp:Content>
