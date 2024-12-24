<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="frmIncentiveWiseRpt.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.frmIncentiveWiseRpt" %>

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
            background-image: url("../../../Images/ajax-loaderblack.gif");
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
                        <a href="#" class="current" runat="server" id="acurrentpage">Applications</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="../frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="frmIncentiveReports.aspx">Reports</a></li>
                            <li class="breadcrumb-item">Incentive Wise Detailed Application Report</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">R3.Incentive Wise Detailed Application Report</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div class="col-sm-12  form-group">
                                    <table>
                                        <tr>
                                            <td>
                                                <label>Incentives : </label> </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlIncentives" class="form-control" TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddlIncentives_SelectedIndexChanged">
                                                    <asp:ListItem Value="0" Text="-- All Incentives --"></asp:ListItem>
                                                </asp:DropDownList>
                                           </td>
                                              <td runat="server" visible="false">
                                                <asp:DropDownList ID="ddlDistrict" class="form-control" AutoPostBack="true"  runat="server"></asp:DropDownList>
                                            </td>
                                            <td></td>
                                            <td>
                                                  <a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: right">
                                        <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                            alt="Excel" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                              
                                <h6 class="text-blue font-SemiBold col col-sm-12 mt-3" runat="server" id="hincentiveName"></h6>
                                <%-- <div class="col-sm-12 mb-3 d-flex">
                                    <input type="text" id="search" class="form-control w-sm-50 w-75" style="max-width: 400px;" placeholder="Type to search" />
                                    <input type="button" value="Clear" id="clear" class="btn btn-blue ml-2 px-4 py-1 title5" />
                                </div>--%>

                                <div class="col-sm-12 table-responsive" id="divPMprint" runat="server">

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
                                            <asp:BoundField DataField="UnitNameAddress" ItemStyle-HorizontalAlign="Center" HeaderText="Nameof the Unit & Address">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeofTexttileText" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Textile">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TechnicalTextile" ItemStyle-HorizontalAlign="Center" HeaderText="Technical Textile Type">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DateOfIncorporation" ItemStyle-HorizontalAlign="Center" HeaderText="Year of Establishment">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCP" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Commencement of Production">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CurrentInvestment" ItemStyle-HorizontalAlign="Center" HeaderText="Current Investment Rs.in Crores">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           <%-- <asp:BoundField DataField="ApplicationNO" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>--%>
                                              <asp:TemplateField HeaderText="Application Number" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <a href="#/"  onclick="javascript:Navigate(<%# Eval("IncentiveID") %>);"><%# Eval("ApplicationNO") %></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SubmittedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Submitted on">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Acknowledgement Issued on">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ClaimPeriod" ItemStyle-HorizontalAlign="Center" HeaderText="Period Claimed">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ClaimAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Amount Claimed(Rs.in Lakhs)">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="SanctionedAmount" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="Amount Sanctioned(Rs.in Lakhs)">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DateOfRelease" ItemStyle-HorizontalAlign="Center" HeaderText="Date Of Release">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="Stage" ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                    <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
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
    <script src="../../../js/jquery.floatThead.js"></script>
    <%--<script src="<%= Page.ResolveUrl("~/Js/jquery.floatThead.js")%>"></script>--%>

      <script type="text/javascript">

          function Navigate(Id) {
            if (Id != undefined) {
                window.open("../../frmDLOApplicationDetailsNew.aspx?Id=" + Id + "&Sts=11");
            }
            return false;
        }

      /*  $(function () {
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
        });*/
    </script>
</asp:Content>
