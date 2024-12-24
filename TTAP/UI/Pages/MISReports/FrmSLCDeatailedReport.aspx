<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="FrmSLCDeatailedReport.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.FrmSLCDeatailedReport" %>

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
                            <li class="breadcrumb-item">SLC Detailed Report</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">

                        <table>
                            <tr>
                                <td>
                                    <h5 class="text-blue mt-1 mb-3 font-SemiBold">R10. SLC Detailed Report</h5>
                                </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                <td>
                                    <a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: left">
                                        <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                            alt="Excel" /></a></td>
                            </tr>
                        </table>
                         <table id="tblDateSelect" runat="server" visible="false" style="margin: 0px 0px 0px 300px;">
                            <tr>
                                <td>From Date</td>
                                <td>
                                    <input type="date" runat="server" id="Fromdate" />
                                </td>
                                <td>To Date</td>
                                <td>
                                    <input type="date" runat="server" id="Todate" />
                                </td>
                                <td>
                                    <asp:Button Text="Get Report" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click"/>
                                </td>
                                <td>
                                    <input type="checkbox" runat="server" id="chkDate" />
                                </td>
                                <td>Date Wise</td>
                            </tr>
                        </table>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>

                                <div align="center">
                                    <table>
                                        <tr>
                                            <td>
                                                <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="Header" style="margin: 0px 0px 0px 500px;"
                                                    runat="server">Report as on</h5>
                                            </td>
                                        </tr>
                                    </table>
                                    <h5 id="CountHeader" style="margin: 0px 0px 0px 486px; color: #d00bca; font-family: 'Montserrat-SemiBold';"
                                        runat="server">Report as on</h5>
                                </div>
                                <div id="DivUnit" class="col-sm-12 table-responsive" runat="server">
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
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SLC_NO" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Center" HeaderText="SLC No">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SlcDate" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SLCAmount" HeaderStyle-Width="30%" ItemStyle-HorizontalAlign="Center" HeaderText="Total SLC Amount">
                                                <ItemStyle CssClass="text-right" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Details" HeaderStyle-Width="30%" ControlStyle-CssClass="SetgridWidth" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:GridView ID="gvList" CssClass="SetgridWidth" ShowHeader="true" AutoGenerateColumns="False"
                                                        runat="server">
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="50%" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="UnitName" ItemStyle-Width="100%" HeaderText="Name of the Unit ">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Name of the Incentive">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PeriodFromDate" ItemStyle-HorizontalAlign="Center" HeaderText="Period From Date">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="PeriodToDate" ItemStyle-HorizontalAlign="Center" HeaderText="Period To Date">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TextileDeptAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Carpet Textiles(88.20%)">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="IndustriesDeptAmount" ItemStyle-HorizontalAlign="Center" HeaderText="LVT(11.80%)">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Slc_Approved_Amount" ItemStyle-HorizontalAlign="Center" HeaderText="Slc Total Approved Amount">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="SanctionedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Amount Released">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Released Date">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                            <asp:BoundField ItemStyle-HorizontalAlign="Center" HeaderText="Letter No & Date">
                                                                <ItemStyle CssClass="text-left" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>

                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Slc Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("SlcId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center">No Data Found</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                                <div id="DivIncentive" class="col-sm-12 table-responsive" visible="false" runat="server">
                                    <asp:GridView ID="gvIncentive" runat="server" AllowPaging="false" AutoGenerateColumns="False"
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
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SlcNo" ItemStyle-HorizontalAlign="Center" HeaderText="Slc No">
                                                <ItemStyle CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SlcDate" ItemStyle-HorizontalAlign="Center" HeaderText="SLC/Sanctioned Date">
                                                <ItemStyle CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PeriodFromDate" ItemStyle-HorizontalAlign="Center" HeaderText="Period From Date">
                                                <ItemStyle CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="PeriodToDate" ItemStyle-HorizontalAlign="Center" HeaderText="Period To Date">
                                                <ItemStyle CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TextileDeptAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Textile Dept Amount">
                                                <ItemStyle CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IndustriesDeptAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Industries Dept Amount">
                                                <ItemStyle CssClass="text-center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Slc_Approved_Amount" ItemStyle-HorizontalAlign="Center" HeaderText="Slc Approved Amount">
                                                <ItemStyle CssClass="text-right" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Slc Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
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
                    <asp:Button Text="Print" ID="btnprint" runat="server" Style="margin: 0px 0px 0px 630px; background: chartreuse; width: 8%;" OnClientClick="return Print();return false;" />
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hfnflag" Value="N" />
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
            $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 400px");
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
            $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 500px");
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
        
        $(document).ready(function () {

        });
        function pageLoad() {
            var text = "";

            var Total = 0;
        if ($('#ContentPlaceHolder1_hfnflag').val() == "Y") {
            $('#ContentPlaceHolder1_gvIncentive tbody').find('.text-right').each(function () {
                Total += parseFloat($(this)[0].innerText);
            });
        }
        else {
            $('#ContentPlaceHolder1_gvdetailsnew tbody').find('.text-right').each(function () {
                Total += parseFloat($(this)[0].innerText);
            });
        }

            text = " Total Sanctioned Amount -  ₹ " + Total;
            $('#ContentPlaceHolder1_CountHeader').html(text);
        }

        /*$('#search').keyup(function () {
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

        });*/


    </script>
</asp:Content>
