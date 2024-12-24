<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="InspectionsReportAbstract.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.InspectionsReportAbstract" %>

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
            <%-- <asp:PostBackTrigger ControlID="A2" />--%>
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
                            <li class="breadcrumb-item">District Wise Incentive Inspection Abstract</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">R14.District Wise Incentive Inspection Abstract</h5>
                        <asp:DropDownList runat="server" ID="ddlIncentives" class="form-control" Width="50%" AutoPostBack="True" OnSelectedIndexChanged="ddlIncentives_SelectedIndexChanged">
                            <asp:ListItem Value="0" Text="-- All Incentives --"></asp:ListItem>
                        </asp:DropDownList>

                        <div class="widget-content nopadding">
                            <div class="row">
                                <div id="TotalGrid" runat="server" class="col-sm-12 mb-4 table-flex">
                                    <div class="row">
                                        <div class="tableFixHead" style="overflow: auto">
                                            <%-- <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>--%>
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
                                                            <asp:RadioButtonList ID="rdbOrderby" Style="display: block;"
                                                                runat="server" RepeatDirection="Horizontal" onclick="return ChangeDiv();">
                                                                <asp:ListItem Selected="True" Value="P">Pending Data</asp:ListItem>
                                                                <asp:ListItem  Value="A">All</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div style="text-align-last: center; font-size: large; font-weight: 900; color: orangered;" runat="server" id="divGridHead">
                                                <tr>
                                                    <td>
                                                        <label runat="server" id="Header"></label>
                                                    </td>
                                                </tr>
                                                <br />
                                                <tr>
                                                    <td>
                                                        <label runat="server" id="NameHeader"></label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <div id="DivPending" class="col-sm-12 table-responsive" runat="server">
                                                <asp:GridView ID="gvdetailsInc" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                    CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" Font-Bold="true" ShowFooter="true"
                                                    PageSize="20" GridLines="Both" OnRowDataBound="gvdetailsInc_RowDataBound">
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
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Incentive Applications Received"
                                                            DataTextField="NoofIncentivesRcvd">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Incentives not attended by DLO so far"
                                                            DataTextField="NoOfIncentivesPending">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Incentives DLO waiting for Query Response"
                                                            DataTextField="DLOQueryAwaiting">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" BackColor="aquamarine" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Incentives Yet To Update Scheduled Inspection Report"
                                                            DataTextField="NoofInspectionScheduled">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Incentives Yet To Update Scheduled Revised Inspection Report"
                                                            DataTextField="NoofRevisedInspectionScheduled">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Incentives Pending for Reference To Head Office/DLC"
                                                            DataTextField="NoofIncentivesPendingforReferenceToHO">
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
                                            <div id="DivAll" class="col-sm-12 table-responsive" runat="server" style="display:none;">
                                                <asp:GridView ID="GvAllStages" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                    CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" Font-Bold="true" ShowFooter="true"
                                                    PageSize="20" GridLines="Both" OnRowDataBound="GvAllStages_RowDataBound">
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
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Incentive Applications Received"
                                                            DataTextField="NoofIncentivesRcvd">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Yet to Process"
                                                            DataTextField="NoOfIncentivesPending">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                         <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Scrutiny Completed"
                                                            DataTextField="ScrutinyCompleted">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="DLO Query Raised Before Inspection"
                                                            DataTextField="DLOQueryRaised">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Query(Before Inspection) Response within"
                                                            DataTextField="DLOQueryResponseWithin">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine"/>
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Awaiting for DLO Query(Before Inspection) Response"
                                                            DataTextField="DLOQueryAwaiting">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Yet To Update Scheduled Inspection Reports"
                                                            DataTextField="NoofInspectionScheduled">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Completed Inspection Reports"
                                                            DataTextField="NoofInspectionCompleted">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                         <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="DLO Query Raised After Inspection"
                                                            DataTextField="DLOQueryRaisedAfterInspection">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                         <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Query Response After Inspection"
                                                            DataTextField="QueryResponseWithinAfterInspection">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                          <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Awaiting for Query Response After Inspection"
                                                            DataTextField="DLOQueryAwaitingAfterInspection">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Yet To Update Revised Inspection Reports"
                                                            DataTextField="NoofRevisedInspectionScheduled">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center"  />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Completed Revised Inspection Reports"
                                                            DataTextField="NoofRevisedInspectionCompleted">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Pending for Reference to DLC/Head Office"
                                                            DataTextField="NoofIncentivesPendingforReferenceToHO">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center"  />
                                                        </asp:HyperLinkField>
                                                        <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Forwarded to DLC/Head Office"
                                                            DataTextField="NoofIncentivesForwardedtoHO">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
                                                        </asp:HyperLinkField>
                                                         <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="DLO Rejected Before Inspection"
                                                            DataTextField="DLORejectedBeforeInspection">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                                        </asp:HyperLinkField>
                                                         <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="DLO Rejected After Inspection"
                                                            DataTextField="DLORejectedAfterInspection">
                                                            <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                            <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" BackColor="aquamarine" />
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

                            </div>
                        </div>
                    </div>
                    <asp:Button Text="Print" ID="btnprint" runat="server" Style="margin: 0px 0px 0px 630px; background: chartreuse; width: 8%;" OnClientClick="return PrintPage();return false;" />
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

        function pageLoad() {
            ChangeDiv();
        }
        function PrintP() {
            $('#ContentPlaceHolder1_ddlIncentives').hide();
            $('#ContentPlaceHolder1_btnprint').hide();
            $('#ContentPlaceHolder1_lbtnback').hide();
            $('#ContentPlaceHolder1_NameHeader').show();
            window.print();
            $('#ContentPlaceHolder1_btnprint').show();
            $('#ContentPlaceHolder1_lbtnback').show();
            $('#ContentPlaceHolder1_ddlIncentives').show();
            $('#ContentPlaceHolder1_NameHeader').hide();
            return false;
        }
        function ChangeDiv()
        {
            if ($('#ContentPlaceHolder1_rdbOrderby_0').is(':checked') == true) {
                $('#ContentPlaceHolder1_DivAll').hide();
                $('#ContentPlaceHolder1_DivPending').show();
            }
            else {
                $('#ContentPlaceHolder1_DivPending').hide();
                $('#ContentPlaceHolder1_DivAll').show();
            }
        }
        
        function PrintA() {
            $('#ContentPlaceHolder1_ddlIncentives').hide();
            $('#ContentPlaceHolder1_btnprint').hide();
            $('#ContentPlaceHolder1_lbtnback').hide();
            $('#ContentPlaceHolder1_NameHeader').show();
            var Todaydate = new Date().format('dd-MMM-yyyy');
            var TextContent = "R14.District Wise DLO Received Applications Abstract as on - " + Todaydate;
            var divContents = '';
            divContents = document.getElementById("ContentPlaceHolder1_GvAllStages").innerHTML;
            var a = window.open('', '', 'height=500, width=500');
            a.document.write('<html>');
            a.document.write('<body > <h1 align="center"> ' + TextContent + ' <br>');
            a.document.write(divContents);
            a.document.write('</body></html>');
            a.document.close();
            a.print();
            $('#ContentPlaceHolder1_btnprint').show();
            $('#ContentPlaceHolder1_lbtnback').show();
            $('#ContentPlaceHolder1_ddlIncentives').show();
            $('#ContentPlaceHolder1_NameHeader').hide();
            return false;
        }
       

        jQuery(document).bind("keyup keydown", function (e) {
            if (e.ctrlKey && e.keyCode == 80) {
                if ($('#ContentPlaceHolder1_rdbOrderby_0').is(':checked') == true) {
                    PrintP();
                }
                else {
                    PrintA();
                }
                return false;
            }
        });
        function PrintPage() {
            if ($('#ContentPlaceHolder1_rdbOrderby_0').is(':checked') == true) {
                PrintP();
            }
            else {
                PrintA();
            }
            return false;
        }
       
    </script>
</asp:Content>
