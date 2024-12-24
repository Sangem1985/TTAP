<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="TypeOfIncentivesNew1.aspx.cs" Inherits="TTAP.UI.Pages.TypeOfIncentivesNew1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Js/validations.js"></script>
    <script src="../../Js/jquery-latest.min.js"></script>
    <script src="../../Js/jquery-ui.min.js"></script>
    <script src="../../Js/jquery.min.js"></script>
    <script type="text/javascript" language="javascript">
        

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }

    </script>
    <style>
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../images/ajax-loaderblack.gif");
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
    <%-- <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>--%>

    <script>
        $(document).ready(function () {

            $("#blinkchk").click(function () {
                var a = $("#text").val();
                a.blink();
            });
            
        });
    </script>
    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>

            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Incentive Types</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Incentive Types</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container mt-4 pb-4">
                    <div class="row">
                        <div class="col-sm-12 offset-md-1 col-md-10 col-lg-8 offset-lg-2 frm-form box-content py-3 font-medium title5">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-2 font-SemiBold">Incentive Types</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="panel-body">
                                                <table cellpadding="10" cellspacing="5" style="width: 100%">
                                                    <%-- <tr>
                                                        <th style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                            <asp:RadioButtonList ID="rblSelection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblSelection_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">
                                                            New / Existing Entreprenuer
                                                                </asp:ListItem>
                                                                <asp:ListItem Value="2">
                                                            Expansion / Diversification Entreprenuer
                                                                </asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </th>
                                                    </tr>--%>
                                                    <tr id="trVehIncentive" runat="server" visible="false">
                                                        <th style="padding: 5px; margin: 5px" valign="top" colspan="3">
                                                            <asp:RadioButtonList ID="rblVehicleIncetive" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblVehicleIncetive_SelectedIndexChanged">
                                                                <asp:ListItem Value="1">
                                                            Vehicle Incentive
                                                                </asp:ListItem>
                                                                <asp:ListItem Value="0" Selected="True">
                                                            Other than Vehicle Incentive
                                                                </asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </th>
                                                    </tr>
                                                    <%--added for  2nd time applying--%>
                                                    <tr id="trApplyNew" runat="server" visible="false">
                                                        <td align="right">
                                                            <asp:CheckBox ID="chkApplyAgainNew" runat="server" Visible="false" Text="Apply Again"
                                                                Font-Bold="true" Font-Size="Small" OnCheckedChanged="chkApplyAgainNew_CheckedChanged"
                                                                Style="margin-left: 15px"
                                                                AutoPostBack="true"></asp:CheckBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="trApplyAgainNote" runat="server" visible="false">
                                                        <td>
                                                            <br />
                                                            <b>Note:</b>
                                                            <b>
                                                                <asp:Label ID="lblApplyAgainNewText" runat="server" ForeColor="Red"
                                                                    Text="To Apply Again for another claim application, Please Click on 'Apply Again' check box and continue as fresh application. In the final page you will get new application number and new acknowledgement."></asp:Label></b>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr id="trOnetime" runat="server" visible="false">
                                                        <td style="padding: 5px; margin: 5px" colspan="3">
                                                            <div style="font-weight: bold;" class="text-blue mb-1">Incentives</div>
                                                            <asp:GridView ID="gvSingleTerm" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                                                                CellPadding="2" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowDataBound="gvSingleTerm_RowDataBound">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex +1 %>.
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="20px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox CssClass="incsize" ID="cbIncentive" runat="server" Text='<%#Eval("IncentiveName")%>' Checked='<%# Convert.ToBoolean(Eval("Validate")) %>'
                                                                                Enabled='<%# Convert.ToBoolean(Eval("Enabled")) %>' />
                                                                            <asp:Label ID="lblIncentiveId" runat="server" Text='<%#Eval("IncentiveID") %>' Visible="false" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle CssClass="text-left p-2" />
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIncentive_Type" runat="server" Text='<%#Eval("Incentive_Type") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="20px" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                 
                                                    <tr id="trNoIncentives" runat="server" visible="false">
                                                        <th align="center">
                                                            <span style="background-color: Yellow;">There are no Incentives available for you.</span>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                                            <%--<asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-warning" Height="32px"
                                                        Text="Previous" PostBackUrl="../../UI/Pages/IncetivesNewForm2.aspx" />--%>
                                                            <asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-blue m-2"
                                                                Text="Previous" PostBackUrl="~/UI/Pages/frmNewIncentive.aspx" />
                                                            <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                                TabIndex="10" Text="Cancel" Visible="false" ToolTip="To Clear  the Screen" />
                                                            <asp:Button ID="btnNext" runat="server" CssClass="btn btn-success m-2"
                                                                Text="Save & Next" Enabled="true" OnClick="btnNext_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" style="padding: 5px; margin: 5px">
                                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong></strong>
                                                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                            </div>
                                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="3" style="padding: 5px; margin: 5px; display: none">
                                                            <div class="alert alert-success">
                                                                <strong>Note:</strong>
                                                                <br />
                                                                <ul>
                                                                    <li style="text-align: left">Large Industries are not Eligible for Land Conversion Incentive</li>
                                                                    <li style="text-align: left">Projects Proposed to be set up under T-PRIDE in Municipal
                                                                Corporation limits of Greater Hyderabad shall obtain pollution clearences where
                                                                ever neccessary</li>
                                                                    <li style="text-align: left">Textile Units other than Large industries may select Sector
                                                                type as Manufacture for applying eligible Incentives</li>
                                                                </ul>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <asp:HiddenField ID="hdnEligibility" runat="server" />
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upd1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
