<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FrmUnitWiseReportAbstract.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.FrmUnitWiseReportAbstract" %>

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
                            <li class="breadcrumb-item">District Wise Unit/Incentive Abstract</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">R4.District Wise Unit/Incentive Abstract</h5>
                                  
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
                                                <asp:RadioButtonList ID="rdbOrderby" OnSelectedIndexChanged="rdbOrderby_SelectedIndexChanged" Style="display: block;"
                                                    runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="I">Incentives Wise</asp:ListItem>
                                                    <asp:ListItem Value="U">Units Wise</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                 <a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: left">
                                            <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                                alt="Excel" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                
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
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Sanctioned  Units"
                                                DataTextField="NoOfUnitsSanctioned">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Rejected Units"
                                                DataTextField="NoOfRejectedUnits">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Pending at Applicant"
                                                DataTextField="NoOfUnitsatApplicant">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Pending at DLO"
                                                DataTextField="NoOfUnitsatDLO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Pending at Head Office"
                                                DataTextField="NoOfUnitsatHO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Pending at Payment"
                                                DataTextField="NoOfUnitsPendingatPayment">
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
                                <div id="DivIncentive" class="col-sm-12 table-responsive" runat="server">
                                    <asp:GridView ID="gvdetailsInc" runat="server" OnRowDataBound="gvdetailsInc_RowDataBound" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" Font-Bold="true" ShowFooter="true"
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
                                            <asp:BoundField DataField="DISTNAME" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total No of Incentives"
                                                DataTextField="TotalNoOfIncentives">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units"
                                                DataTextField="NoOfUnits">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center"  CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText=" No of Incentives Pending at Payment"
                                                DataTextField="NoOfIncentivesatPayment">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText=" No of Units Pending at Payment"
                                                DataTextField="NoOfUnitsPendingatPayment">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pedning at DLO"
                                                DataTextField="NoOfIncentivesatDLO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Pedning at DLO"
                                                DataTextField="NoOfUnitsatDLO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pedning at Applicant"
                                                DataTextField="NoOfIncentivesatApplicant">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Pedning at Applicant"
                                                DataTextField="NoOfUnitsatApplicant">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pending at HO"
                                                DataTextField="NoOfIncentivesatHO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Pending at HO"
                                                DataTextField="NoOfUnitsatHO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Rejected"
                                                DataTextField="NoOfIncentivesRejected">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Rejected"
                                                DataTextField="NoOfRejectedUnits">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Sanctioned"
                                                DataTextField="TotalNoOfIncentivesSanctioned">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units Sanctioned"
                                                DataTextField="NoOfUnitsSanctioned">
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
                    <asp:Button Text="Print" ID="btnprint" runat="server" Style="margin: 0px 0px 0px 630px; background: chartreuse; width: 8%;" OnClientClick="return Print();return false;" />
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
            var divContents = '';
            
            if (document.getElementById('ContentPlaceHolder1_rdbOrderby_0').checked == true) {
                divContents = document.getElementById("ContentPlaceHolder1_DivIncentive").innerHTML;
            }
            if (document.getElementById('ContentPlaceHolder1_rdbOrderby_1').checked == true) {
                 divContents = document.getElementById("ContentPlaceHolder1_DivUnit").innerHTML;
            }
            var a = window.open('', '', 'height=500, width=500');
            a.document.write('<html>');
            if (document.getElementById('ContentPlaceHolder1_rdbOrderby_0').checked == true) {
                 a.document.write('<body > <h1> District wise Incentive Abstract <br>');
            }
            if (document.getElementById('ContentPlaceHolder1_rdbOrderby_1').checked == true) {
                 a.document.write('<body > <h1> District wise Unit Abstract <br>');
            }
            a.document.write(divContents);
            a.document.write('</body></html>');
            a.document.close();
            a.print();
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
