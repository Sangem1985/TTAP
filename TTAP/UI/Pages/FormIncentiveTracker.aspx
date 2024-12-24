<%@ Page Title="Unit and Incentive Tracker" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FormIncentiveTracker.aspx.cs" Inherits="TTAP.UI.Pages.FormIncentiveTracker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <script src="../../Js/jquery.min.js"></script>
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
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
    <script type="text/javascript" language="javascript">


</script>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="A2" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Dashboard</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Unit and Incentive Tracker</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Unit and Incentive Trackerr</h5>
                        <table>
                            <tr>
                                <td>
                                    <label style="margin: 6px 4px 5px 16px;">
                                        Incentive : 
                                    </label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlIncentives" class="form-control">
                                        <asp:ListItem Value="0" Text="-- All Incentives --"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label style="margin: 6px 4px 5px 16px;">
                                        Unit Name : 
                                    </label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rdbSelection" Style="margin: 5px 550px 11px 15px; display: none;"
                                        runat="server" AutoPostBack="false" onchange="return fn_ChangeSrch();" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="U">UID No</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="UN">Unit Name</asp:ListItem>
                                        <%--  <asp:ListItem Value="AN">Application No</asp:ListItem>--%>
                                    </asp:RadioButtonList>
                                    <asp:DropDownList runat="server" ID="ddlUnits" class="form-control">
                                        <asp:ListItem Value="0" Text="-- All Units --"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button Text="Search" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                </td>
                                <td>
                                    <asp:Button Text="Reset" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnReset" runat="server" OnClick="btnReset_Click" />
                                </td>
                                <td>
                                    <a id="A2" href="#" class="tags" onserverclick="BtnExportExcel_Click" gloss="Export to Excel" visible="false" runat="server" style="float: right">
                                        <img src="../../../images/Excel-icon.png" style="margin: 0px 0px 0px 15px;" width="30px" height="30px"
                                            alt="Excel" /></a>
                                </td>
                            </tr>
                        </table>
                        <div id="divConent" runat="server">
                            <div style="text-align-last: center; font-size: large; font-weight: 900; color: green; margin: 29px 0px 8px 0px;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblUnitHeader" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </div>
                            <div style="text-align-last: center; font-size: large; font-weight: 900; color: blue;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIncentiveHeader" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </div>
                            <div style="text-align-last: center; font-size: large; font-weight: 900; color: blue;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbldate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </div>
                            <div class="col-sm-16 table-responsive">
                                <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"
                                    OnRowDataBound="grdDetails_RowDataBound"
                                    Font-Size="12px">
                                    <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                    <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                      <%--  <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>--%>
                                          <asp:TemplateField HeaderText="Application Number" ItemStyle-ForeColor="Black" ItemStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <a href="#/" style="color:black" onclick="javascript:Navigate(<%# Eval("IncentiveID") %>);"><%# Eval("IncentiveName") %></a>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Application Submitted on">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSubmittedDate" Text='<%#Eval("SubmittedDate") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Acknowledgement Issued on">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAcknowledgeDate" Text='<%#Eval("AcknowledgeDate") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="State level Commette Meeting Date">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Claim Details" ControlStyle-CssClass="SetgridWidth" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:GridView ID="gvClaim" AutoGenerateColumns="false" CssClass="SetgridWidth" ShowHeader="true"
                                                    runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="FinancialYear" ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Center" HeaderText="Financial Year">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TypeOfFinancialYear" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Financial Year">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="ClaimAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Claim Amount">
                                                            <ItemStyle CssClass="text-left" />
                                                        </asp:BoundField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ClaimAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Total Cliam Amount">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="TextileSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Textile Dept Sanctioned Amount">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IndustrySanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Industries Dept Sanctioned Amount">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Total Sanctioned Amount">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SanctionedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ReleasedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Released Date">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ReleasedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Released Amount">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PendingReleaseAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Amount Due to be Released">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CurrentStatus" ItemStyle-HorizontalAlign="Center" HeaderText="Application Status">
                                            <ItemStyle CssClass="text-left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div id="divnodata" visible="false" style="text-align-last: center; color: red;"
                                runat="server">
                                No Data Found
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdndcp" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <script type="text/javascript">
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
        function Navigate(Id) {
            if (Id != undefined) {
                window.open("../frmDLOApplicationDetailsNew.aspx?Id=" + Id + "&Sts=11");
            }
            return false;
        }
    </script>
</asp:Content>
