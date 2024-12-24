<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmDraftApplicationsDrill.aspx.cs" Inherits="TTAP.UI.Pages.frmDraftApplicationsDrill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
        #search {
            position: unset !important;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Applications</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Applications</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Applications</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <%--<div class="col-sm-12 mb-3 d-flex">
                                    <input type="text" id="search" class="form-control w-sm-50 w-75" style="max-width: 400px;" placeholder="Type to search" />
                                    <input type="button" value="Clear" id="clear" class="btn btn-blue ml-2 px-4 py-1 title5" />
                                </div>--%>
                                 <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div class="col-sm-12 mb-3 d-flex">
                                    <asp:TextBox ID="txtsearch" runat="server" class="form-control w-sm-50 w-75" Style="max-width: 400px;" placeholder="Type to search"></asp:TextBox>
                                    <asp:Button Text="Search" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                    <asp:Button Text="Reset" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnReset" runat="server" OnClick="btnReset_Click" />

                                </div>
                                <div class="col-sm-12 table-responsive">
                                    <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"
                                        PageSize="20" GridLines="Both">
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
                                             <asp:BoundField DataField="ApplicationNumber" ItemStyle-HorizontalAlign="Center" HeaderText="Application Number">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicantName" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OffcMobileNO" ItemStyle-HorizontalAlign="Center" HeaderText="Mobile No.">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SocialStatusText" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="Social Status">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Address" ItemStyle-HorizontalAlign="Center" HeaderText="Address">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Created Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IncentiveCount" ItemStyle-HorizontalAlign="Center" HeaderText="No. of Incentives">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           <%-- <asp:TemplateField HeaderText="Verify" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnProcess" runat="server" Text="Process" CssClass="btn btn-blue py-1 title7" OnClick="btnProcess_Click"></asp:Button>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
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

        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery.sticky/1.0.4/jquery.sticky.min.js"></script>--%>

<%--    <script src="../../NewCss/js/jquery.min.js"></script>
    <script type="text/javascript">
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
    </script>--%>
</asp:Content>
