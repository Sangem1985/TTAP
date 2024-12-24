<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="FormIncentiveWiseAbstract.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.FormIncentiveWiseAbstract" %>

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
                        <a href="#" class="current" runat="server" id="acurrentpage">Abstract</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="../frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="frmIncentiveReports.aspx">Reports</a></li>
                            <li class="breadcrumb-item">Incentive Wise Abstract</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        
                        <table>
                            <tr>
                                <td><h5 class="text-blue mt-1 mb-3 font-SemiBold">R3. Incentive Wise Abstract</h5></td><td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                <td>
                                <a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: left">
                                    <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                        alt="Excel" /></a></td>
                            </tr>
                        </table>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                 <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="Header" style="margin: 0px 0px 0px 480px;"
                            runat="server"> Report as on</h5>
                                <div id="DivUnit" class="col-sm-12 table-responsive" runat="server">
                                    <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" ShowFooter="true"
                                        PageSize="20" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="S No </br> (1)">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name </br> (2)">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name </br> (2)"
                                                DataTextField="IncentiveName">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>

                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Claims Received </br> (3)"
                                                DataTextField="NoofClaims">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Total Amount Claimed </br> (4)"
                                                DataTextField="TotalAmountClaimed">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Claims Rejected </br> (5)"
                                                DataTextField="NoofIncentivesRejected">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Total Claim Amount Rejected </br> (6)"
                                                DataTextField="TotalRejectedAmount">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Total Sanctioned Claims by SLC </br> (7)"
                                                DataTextField="TotalSanctioned">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Total Amount Sanctioned by SLC </br> (8)"
                                                DataTextField="TotalAmountSanctioned">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                            </div>
                        </div>
                    </div>
                    <asp:Button Text="Print" ID="btnprint" runat="server" Style="margin: 0px 0px 0px 700px; background: chartreuse; width: 8%;" OnClientClick="return Print();return false;" />
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

    <script type="text/javascript">
        function Print1() {
            $('#ContentPlaceHolder1_btnprint').hide();
            $('#ContentPlaceHolder1_lbtnback').hide();
            window.print();
            $('#ContentPlaceHolder1_btnprint').show();
            $('#ContentPlaceHolder1_lbtnback').show();
            return false;
        }


        function Print() {
            $('#ContentPlaceHolder1_btnprint').hide();
            $('#ContentPlaceHolder1_lbtnback').hide();
            $('#ContentPlaceHolder1_A2').hide();
             $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 320px");
            /*var divContents = document.getElementById("ContentPlaceHolder1_gvdetailsnew").innerHTML;
            var a = window.open('', '', 'height=500, width=500');
            a.document.write('<html>');
            a.document.write('<body > <h1> Incentive wise Abstract <br>');
            a.document.write(divContents);
            a.document.write('</body></html>');
            a.document.close();
            a.print();
            return false;*/
            window.print();
            $('#ContentPlaceHolder1_btnprint').show();
            $('#ContentPlaceHolder1_lbtnback').show();
            $('#ContentPlaceHolder1_A2').show();
             $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 480px");
            return false;

        }
        /*document.onkeypress = function (e) {
            var evt = window.event || e;
            if (evt.keyCode == 71 && evt.altKey) {
                Print();
            }
        }*/

        jQuery(document).bind("keyup keydown", function (e) {
            if (e.ctrlKey && e.keyCode == 80) {
                Print();
                return false;
            }
        });

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
