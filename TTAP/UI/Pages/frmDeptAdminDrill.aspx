<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmDeptAdminDrill.aspx.cs" Inherits="TTAP.UI.Pages.frmDeptAdminDrill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #search {
            position: unset !important;
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
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold" id="pageheader" runat="server">Applications</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <%-- <div class="col-sm-12 mb-3 d-flex">
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
                                     <a id="A2" href="#" class="tags" onserverclick="BtnExportExcel_Click" gloss="Export to Excel" runat="server" style="float: right">
                                                    <img src="../../../images/Excel-icon.png" style="margin: 0px 0px 0px 15px;" width="30px" height="30px"
                                                        alt="Excel" /></a>
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
                                            <%-- <asp:BoundField DataField="ApplicationNumber" ItemStyle-HorizontalAlign="Center" HeaderText="Application Number">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Application Number" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="#/" onclick="javascript:GetIncentives(<%# Eval("IncentiveId") %>);"><%# Eval("ApplicationNumber") %></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Incentives" ItemStyle-HorizontalAlign="Center" HeaderText="Incentives">
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
                                             <asp:BoundField DataField="ApplicationSubmittedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Submitted Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Payment Verified Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <%-- <asp:BoundField DataField="AppStatus" ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                            <asp:BoundField DataField="IncentiveCount" ItemStyle-HorizontalAlign="Center" HeaderText="No. of Incentives">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Verify" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnProcess" runat="server" Text="Process" CssClass="btn btn-blue py-1 title7" OnClick="btnProcess_Click"></asp:Button>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
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
            <div class="masking" id="centreDetPopup" style="display: none;">
                <div class="cmask">
                </div>
                <div class="clientpopup" style="width: 966px; height: 465px; margin-left: -475px; margin-top: -233px;">
                    <div class="pop-header">
                        <h4 style="margin: 7px 0px 2px 4px;">Incentive Details
                        </h4>
                        <label id="lblApplicationNo" style="margin: 0px 0px 0px 5px; color: red;">
                        </label>
                        <label><----></label>
                        <label id="lblUnitName" style="color: forestgreen;"></label>
                        <input type="submit" value="×" onclick="return ClosingCentreDetails();" id="Button4" class="Button">
                    </div>
                    <table id="tbldata" class="table table-bordered" style="margin: 10px 0px 0px 4px;width: 99%;">
                        <thead class="bg-danger text-center text-white">
                            <tr>
                                <th align="left">S No</th>
                                <th align="left">Incentive Name</th>
                                <th align="left">Claim Period</th>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<script src="http://cdnjs.cloudflare.com/ajax/libs/jquery.sticky/1.0.4/jquery.sticky.min.js"></script>--%>

    <script src="../../NewCss/js/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=gvdetailsnew]").find('tr td')[1].click(function () {
                DisplayDetails($(this).closest("tr"));
            });
        });
        function DisplayDetails(row) {
            var AppNo = "";
            AppNo = $("td", row).eq(1).html();
            alert(AppNo);
        }

        function ViewClick(response) {
          
            var Data = $.parseJSON(response.d);
            $('#tbldata tbody').empty();
            $('#lblApplicationNo').text(Data[0].ApplicationNumber);
            $('#lblUnitName').text(Data[0].UnitName);
            if (Data.length > 0) {
                for (var i = 0; i < Data.length; i++) {
                    var _tr1 = '<tr id=' + i + '><td>' + (i + 1) + ' </td><td>' + Data[i].IncentiveName + ' </td><td> ' + Data[i].ClaimPeriod + '</td></tr>';
                    $('#tbldata tbody').append(_tr1);
                }
            }

            $("#centreDetPopup").show();
            return false;
        }
        function ClosingCentreDetails() {
            $("#centreDetPopup").hide();
        }
        function XMLToString(oXML) {

            return (new XMLSerializer()).serializeToString(oXML);
        }

        function GetIncentives(Id) {
            $.ajax({
                type: "POST",
                url: "frmDeptAdminDrill.aspx/GetIncentives",
                data: '{IncentiveId: ' + Id + '}',
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
    </script>
    <%--  <script type="text/javascript">
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
