<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="TypeOfIncentivesNew.aspx.cs" Inherits="TTAP.UI.Pages.TypeOfIncentivesNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_container {
            background-color: #DEF1F4;
            border: solid 1px #77D5F7;
        }

        .cal_Theme1 .ajax__calendar_header {
            background-color: #ffffff;
            es margin-bottom: 4px;
        }

        .cal_Theme1 .ajax__calendar_title, .cal_Theme1 .ajax__calendar_next, .cal_Theme1 .ajax__calendar_prev {
            color: #004080;
            padding-top: 3px;
        }

        .cal_Theme1 .ajax__calendar_body {
            background-color: #ffffff;
            border: solid 1px #77D5F7;
        }

        .cal_Theme1 .ajax__calendar_dayname {
            text-align: center;
            font-weight: bold;
            margin-bottom: 4px;
            margin-top: 2px;
            color: #004080;
        }

        .cal_Theme1 .ajax__calendar_day {
            color: #004080;
            text-align: center;
        }

        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year, .cal_Theme1 .ajax__calendar_active {
            color: #004080;
            font-weight: bold;
            background-color: #DEF1F4;
        }

        .cal_Theme1 .ajax__calendar_today {
            font-weight: bold;
        }

        .cal_Theme1 .ajax__calendar_other, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title {
            color: #bbbbbb;
        }

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

        .vAlign {
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

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
             <div class="container">
        <div class="row mt-4">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item active"><a href="Home.aspx">Home</a></li>
                    <li class="breadcrumb-item">TYPE OF INCENTIVE</li>
                </ol>
            </nav>
        </div>
            
            <div align="left">
                <div class="row" align="left">
                    <div class="col-lg-11">
                        <div class="panel panel-primary">
                            <div class="panel-heading" align="center">
                                <h3 class="panel-title">Incentive Types
                                </h3>
                            </div>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 90%">
                                            <tr>
                                                <th style="background: #fff !important;padding: 5px; margin: 5px" valign="top" colspan="3">
                                                    <asp:RadioButtonList ID="rblSelection" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rblSelection_SelectedIndexChanged">
                                                        <asp:ListItem Value="1">
                                                            New / Existing Entreprenuer
                                                        </asp:ListItem>
                                                        <asp:ListItem Value="2">
                                                            Expansion / Diversification Entreprenuer
                                                        </asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </th>
                                            </tr>
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
                                            <%--<tr id="trTpride" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                    <span style="font-weight: bold;">Tpride Incentives</span><br />
                                                    <asp:GridView ID="gvTpride" runat="server" AutoGenerateColumns="False"
                                                        BorderWidth="1px" CellPadding="2" Font-Names="Verdana" Font-Size="13px" ForeColor="#333333"
                                                        Width="100%">
                                                        <RowStyle BackColor="#EFF3FB" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex +1 %>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="20px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbIncentive" runat="server" Text='<%#Eval("IncentiveName")%>'
                                                                        CssClass="vAlign" AutoPostBack="true" OnCheckedChanged="cbIncentive_CheckedChanged"/>
                                                                    <asp:Label ID="lblIncentiveId" runat="server" Text='<%#Eval("IncentiveID") %>' 
                                                                        Visible="false" ToolTip='<%#Eval("Validate") %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#093461" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#093461" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>--%>
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
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center" >
                                                    <span style="font-weight: bold;">One time Incentives</span><br />
                                                    <asp:GridView ID="gvSingleTerm" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                                                        CellPadding="2" Font-Names="Verdana" Font-Size="13px" Width="100%" OnRowDataBound="gvSingleTerm_RowDataBound">
                                                        <RowStyle BackColor="#EFF3FB" />
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
                                                                    <asp:CheckBox ID="cbIncentive" runat="server" Text='<%#Eval("IncentiveName")%>' Checked='<%# Convert.ToBoolean(Eval("Validate")) %>'
                                                                        Enabled='<%# Convert.ToBoolean(Eval("Enabled")) %>' />
                                                                    <asp:Label ID="lblIncentiveId" runat="server" Text='<%#Eval("IncentiveID") %>' Visible="false" />
                                                                </ItemTemplate>
                                                                <ItemStyle Height="30px" />
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#093461" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#093461" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr id="trRegularIncentive" visible="false" runat="server">
                                                <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                    <span style="font-weight: bold;">Regular Incentives</span><br />
                                                    <asp:GridView ID="gvRepetitive" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                                                        CellPadding="2" Font-Names="Verdana" Font-Size="13px" ForeColor="#333333" GridLines="Both"
                                                        OnRowDataBound="gvRepetitive_RowDataBound">
                                                        <RowStyle BackColor="#EFF3FB" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex +1 %>.
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="20px" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDropdown" runat="server" Text='<%# Eval("FromDate") %>' ToolTip='<%# Eval("ToDate") %>'
                                                                        Visible="false" />
                                                                    <asp:Label ID="lbl" runat="server" Text='<%# Eval("AlreadyApplied") %>' Visible="false"
                                                                        ToolTip='<%# Eval("Validate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbIncentiveCheck" runat="server" Text='<%#Eval("IncentiveName")%>' />
                                                                    <asp:Label ID="lblIncentiveId" runat="server" Text='<%#Eval("IncentiveID") %>' Visible="false" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" 
                                                                HeaderText="Whether have you already applied?">
                                                                <ItemTemplate>
                                                                    <asp:RadioButtonList ID="rblYesNo" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Period From">
                                                                <ItemTemplate>
                                                                    <%--<asp:DropDownList ID="ddlPassingYearFrom" runat="server" TabIndex="1" Width="100px">
                                                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                                                    </asp:DropDownList>--%>
                                                                    <asp:TextBox ID="txtFrom" runat="server" AutoPostBack="true" OnTextChanged="txtFrom_TextChanged" />
                                                                    <cc1:CalendarExtender ID="ctefrom" runat="server" TargetControlID="txtFrom" Format="dd-MMM-yyyy"
                                                                        CssClass="cal_Theme1">
                                                                    </cc1:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Period To">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTo" runat="server" AutoPostBack="true" OnTextChanged="txtTo_TextChanged"></asp:TextBox>
                                                                    <cc1:CalendarExtender ID="cteTo" runat="server" TargetControlID="txtTo" Format="dd-MMM-yyyy"
                                                                        CssClass="cal_Theme1">
                                                                    </cc1:CalendarExtender>
                                                                    <%--<asp:DropDownList ID="ddlPassingYearTo" runat="server" TabIndex="1" Width="100px">
                                                                        <asp:ListItem>--SELECT--</asp:ListItem>
                                                                    </asp:DropDownList>--%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#093461" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#093461" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr id="trSkillset" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                                    <span style="font-weight: bold;">Skill Set Incentives</span><br />
                                                    <asp:GridView ID="gvskillSet" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                                                        CellPadding="2" Font-Names="Verdana" Font-Size="13px" ForeColor="#333333" Width="100%" OnRowDataBound="gvskillSet_RowDataBound">
                                                        <RowStyle BackColor="#EFF3FB" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="Sl.No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex +1 %>.
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="20px" HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="cbIncentive" runat="server" Checked='<%# Convert.ToBoolean(Eval("Validate")) %>' Enabled='<%# Convert.ToBoolean(Eval("Enabled")) %>' />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Incentive Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIncentiveName" runat="server" Text='<%#Eval("IncentiveName")%>' />
                                                                    <asp:Label ID="lblIncentiveId" runat="server" Text='<%#Eval("IncentiveID") %>' Visible="false" />
                                                                </ItemTemplate>
                                                                <ItemStyle Height="30px" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#093461" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#093461" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <AlternatingRowStyle BackColor="White" />
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
                                                    <span style="padding-left: 10px;">
                                                        <%--<asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-warning" Height="32px"
                                                            Text="Previous" PostBackUrl="../../UI/Tsipass/IncetivesNewForm2.aspx" />--%>
                                                        <asp:Button ID="btnPrevious" runat="server" CssClass="btn btn-warning" Height="32px"
                                                            Text="Previous" PostBackUrl="IncentivesCheckSlip.aspx" />
                                                    </span><span style="padding-left: 10px;">
                                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Height="32px"
                                                            TabIndex="10" Text="Save" Width="90px" OnClick="btnSave_Click" />
                                                    </span><span style="padding-left: 10px;">
                                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                                            Height="32px" TabIndex="10" Text="Cancel" ToolTip="To Clear  the Screen" Width="90px" />
                                                    </span><span style="padding-left: 10px;">
                                                        <asp:Button ID="btnNext" runat="server" CssClass="btn btn-warning" Height="32px"
                                                            Text="Next" Enabled="true" OnClick="btnNext_Click" />
                                                    </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="3" style="padding: 5px; margin: 5px">
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
                                                <td align="left" colspan="3" style="padding: 5px; margin: 5px">
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
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                    <%-- <div class="overlay">
                        <div style="z-index: 1000; margin-top: 100px; opacity: 1; -moz-opacity: 1;">
                            <img alt="" src="../../Resource/Images/Processing.gif" />
                        </div>
                    </div>--%>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <br />
            <br />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
