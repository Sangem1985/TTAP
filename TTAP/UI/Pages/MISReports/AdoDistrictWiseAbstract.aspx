<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AdoDistrictWiseAbstract.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.AdoDistrictWiseAbstract" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        a {
            color: blue;
            text-decoration:none;
            background-color: transparent;
            
        }

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
        .masking {
            display: none;
            z-index: 999999;
            top: 0px;
            left: 0px;
            height: 100%;
            width: 100%;
            border-radius: 3px;
            position: fixed;
        }

        .cmask, .modalBackground {
            position: fixed;
            width: 100%;
            height: 100%;
            left: 0px;
            top: 0px;
            z-index: 9999;
        }

        .clientpopup {
            position: fixed;
            left: 50%;
            top: 50%;
            border-radius: 5px;
            background: #fff;
            -moz-box-shadow: 1px 0 7px #000;
            -webkit-box-shadow: 1px 0 7px #000;
            box-shadow: 1px 0 7px #000;
            z-index: 999999;
        }

        0% {
            transform: translateX(0px) translateY(-100px);
            transition: opacity 400ms, transform 400ms;
        }

        10% {
            transform: translateX(0px) translateY(0);
            transition: opacity 400ms, transform 400ms;
        }

        100% {
            transform: translateX(0px) translateY(0);
            transition: opacity 400ms, transform 400ms;
        }

        .pop-header {
            height: 36px px;
            clear: both;
            border-radius: 5px 5px 0 0;
        }

        .Button {
            color: #FFF;
            border: 0 !important;
            background: #d80101;
            border-radius: 3px;
            background-position: -5px -33px;
            border-radius: 3px;
        }

        .pop-header input {
            float: right;
            width: 29px;
            margin: -34px 4px 3px 3px;
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
                            <li class="breadcrumb-item">AD Wise Incentive Abstract</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <table>
                            <tr>
                                <td>
                                    <h5 id="header" runat="server" class="text-blue mt-1 mb-3 font-SemiBold">R11. AD Wise Incentive Abstract</h5>
                                </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                <td><a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: left">
                                    <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                        alt="Excel" /></a>  </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                <td>
                                    <asp:Label Visible="true" runat="server">Only Active Districts</asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox AutoPostBack="true" OnCheckedChanged="ckhActive_CheckedChanged" Checked="true" Visible="true" ID="ckhActive" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div runat="server" visible="false" class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div runat="server" id="divCats" visible="false" style="font-family: 'Montserrat-SemiBold';"
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
                                        </tr>
                                    </table>
                                </div>
                                <div runat="server" id="div1" style="font-family: 'Montserrat-SemiBold';"
                                    class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="DivUnit" class="col-sm-12 table-responsive" runat="server">
                                    <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"  ShowFooter="true"
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
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" Font-Bold="true"  ShowFooter="true"
                                        PageSize="20"  OnPreRender="gvdetailsInc_PreRender">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="15%" DataField="ADO_DIST_NAME"  ItemStyle-HorizontalAlign="Center" HeaderText="AD(H&T) Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                          <%--  <asp:BoundField DataField="DISTNAME" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                              <asp:TemplateField HeaderText="District Name" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="#/" onclick="javascript:GetIncentives(<%# Eval("DISTID") %>,this);"><%# Eval("DISTNAME") %></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Units"
                                                DataTextField="NoOfUnits">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total No of Incentives"
                                                DataTextField="TotalNoOfIncentives">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Sanctioned"
                                                DataTextField="TotalNoOfIncentivesSanctioned">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pending at DLO (DLC)"
                                                DataTextField="PendingatDLODLC">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pending at DLO (SLC)"
                                                DataTextField="PendingatDLOSLC">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pedning at DLO(Upto DLO Recommendation to DLC/HO)"
                                                DataTextField="NoOfIncentivesatDLO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pedning at DL-SVC & DLC"
                                                DataTextField="PendingAtDLSVCDLC">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <%--<asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Incentives Longest Pending Day Count at DLO"
                                                DataTextField="DLOLongPendingDayCount" ItemStyle-ForeColor="Red" Visible="false">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>--%>
                                             <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pending at Head Office"
                                                DataTextField="NoOfIncentivesatHO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives returned to the Applicant for rectification"
                                                DataTextField="NoOfIncentivesatApplicant">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Pending at DLO for Revised Inspection"
                                                DataTextField="PendingRevisedInspectionIncentives">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Rejected"
                                                DataTextField="NoOfIncentivesRejected">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                           
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="No of Incentives Released"
                                                DataTextField="TotalNoOfIncentivesReleased">
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
                    <%--<asp:Label runat="server">Note :-  </asp:Label>--%>
                    <asp:Button Text="Print" ID="btnprint" runat="server" Style="margin: 0px 0px 0px 630px; background: chartreuse; width: 8%;" OnClientClick="return Print();return false;" />
                </div>
            </div>
              <div class="masking" id="centreDetPopup" style="display: none;">
                <div class="cmask">
                </div>
                <div class="clientpopup" style="width: 966px; height: 600px; margin-left: -475px; margin-top: -307px;overflow:scroll;">
                    <div class="pop-header">
                        <h4 id="headerDistname" style="margin: 7px 0px 2px 254px;">Incentive Details</h4>
                        <input type="submit" value="×" onclick="return ClosingCentreDetails();" id="Button4" class="Button">
                    </div>
                    <div id="divpopupdata" runat="server">
                    <table id="tbldata" class="table table-bordered" style="margin: 10px 0px 0px 4px;width: 99%;" border="1">
                        <thead class="bg-danger text-center text-white">
                            <tr>
                                <th align="left">S No</th>
                                <th align="left">Incentive Name</th>
                                <th align="left">No of Claims</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                        </div>
                    <asp:Button Text="Print" ID="btnPopupPrint" runat="server" Style="margin: 19px 0px 0px 443px; background: aquamarine; width: 8%;" OnClientClick="return PrintPopup();return false;" />
                </div>
            </div>
            <asp:HiddenField ID="hdnDistId" runat="server" />
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
            $('.breadcrumb-bg').hide();
            $('#ContentPlaceHolder1_A2').hide();
            window.print();
            $('#ContentPlaceHolder1_btnprint').show();
            $('#ContentPlaceHolder1_lbtnback').show();
            $('.breadcrumb-bg').show();
            $('#ContentPlaceHolder1_A2').show();
            return false;
        }

        function PrintPopup() {
            var divContents = '';
            divContents = document.getElementById("ContentPlaceHolder1_divpopupdata").innerHTML;
            var a = window.open('', '', 'height=500, width=500');
            a.document.write('<html>');
            a.document.write('<body > <h1 align="center"> '+ $('#headerDistname').html().trim()+' <br>');
            a.document.write(divContents);
            a.document.write('</body></html>');
            a.document.close();
            a.print();
            return false;
        }

        function Print() {
             $('#ContentPlaceHolder1_btnprint').hide();
            $('#ContentPlaceHolder1_lbtnback').hide();
            $('.breadcrumb-bg').hide();
            $('#ContentPlaceHolder1_A2').hide();
            var Todaydate = new Date().format('dd-MMM-yyyy');
            var TextContent = "R11. AD Wise Incentive Abstract as on - " + Todaydate;
            var divContents = '';
            divContents = document.getElementById("ContentPlaceHolder1_DivIncentive").innerHTML;
            var a = window.open('', '', 'height=500, width=500');
            a.document.write('<html>');
            a.document.write('<body > <h1 align="center"> ' + TextContent + ' <br>');
            a.document.write(divContents);
            a.document.write('</body></html>');
            a.document.close();
            a.print();
            $('#ContentPlaceHolder1_btnprint').show();
            $('#ContentPlaceHolder1_lbtnback').show();
            $('.breadcrumb-bg').show();
            $('#ContentPlaceHolder1_A2').show();
            return false;
        }

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
        function GetAbstract() {
            alert('Jai Balayya');
        }
        var Distname = "";
        function GetIncentives(Id, Name) {
            Distname = Name.innerHTML;
            $.ajax({
                type: "POST",
                url: "AdoDistrictWiseAbstract.aspx/GetIncentives",
                data: '{DistId: ' + Id + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: ViewClick,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        function ViewClick(response) {
          
            var Data = $.parseJSON(response.d);
            $('#tbldata tbody').empty();
            var HeaderText = Distname + "-" + "Incentive Abstract";
            $('#headerDistname').html(HeaderText);
            if (Data.length > 0) {
                for (var i = 0; i < Data.length; i++) {
                    var _tr1 = '<tr id=' + i + '><td>' + (i + 1) + ' </td><td>' + Data[i].IncentiveName + ' </td><td> ' + Data[i].NoofClaims + '</td></tr>';
                    $('#tbldata tbody').append(_tr1);
                }
            }

            $("#centreDetPopup").show();
            return false;
        }
    </script>
</asp:Content>
