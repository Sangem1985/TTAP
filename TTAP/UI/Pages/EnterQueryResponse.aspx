<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="EnterQueryResponse.aspx.cs" Inherits="TTAP.UI.Pages.EnterQueryResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Js/validations.js" type="text/javascript"></script>
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

        .style8 {
            color: #FF0000;
            font-weight: bold;
        }

        .GRD {
            height: auto;
            border-color: #013161;
            border-style: solid;
            border-width: 1px;
            text-transform: capitalize;
            padding: 10px;
        }

        .GRDITEM {
            /*background-color: WHITE;*/
            color: black;
            font-size: 12px;
            font-weight: normal;
            font-family: Verdana;
            padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
            text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/
            padding: 10px; /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
        }

        .GRDHEADER {
            color: #0E2A46;
            vertical-align: middle;
            text-align: center;
            height: 25px;
            width: 50px;
            padding: 10px;
            font-size: 12px;
            font-weight: bold;
            text-transform: capitalize;
            font-family: Verdana;
            background-image: url(../images/bg_blue_grd.gif);
            border-color: #ffffff;
            border-style: solid;
            border-width: 1px;
        }
    </style>

    <script type="text/javascript" language="javascript">

       /* $(document).ready(function () {
            var gridrows = $("#ContentPlaceHolder1_grdDetails tbody tr");
            if ($('#ContentPlaceHolder1_hdnQuery').val() == 'H') {
                for (var i = 0; i < gridrows.length; i++) {
                    gridrows[i].cells[6].style.display = "none";
                }
            }
        });*/

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
        function hideColumn() {
        
        return false;

    };
    </script>

    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>

    <asp:UpdatePanel ID="upd1" runat="server">
        <ContentTemplate>
            <div id="content">


                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="A1" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="a2">Dashboard</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Dashboard</li>
                        </ul>
                    </div>
                </div>


                <%--<div id="content-header">
            <div id="breadcrumb">
                <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current" runat="server" id="acurrentpage">Query Details</a>
            </div>
           <h1>Fill Industry Details</h1>
        </div>--%>
                <div class="container mt-4 pb-4" id="Div1" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Query Details </h5>

                        <div class="widget-content nopadding">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="panel-body">
                                        <table align="center" cellpadding="10" cellspacing="5" style="width: 95%">
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; text-align: center;" valign="top" class="style8"
                                                    align="center">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" class="style8" style="padding: 5px; margin: 5px; text-align: center;"
                                                    valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"
                                                        CellPadding="4" Height="62px"
                                                        OnRowDataBound="grdDetails_RowDataBound"
                                                        Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                        <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="50px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Left" HeaderText="Incentives" />
                                                            <asp:BoundField DataField="QueryDescription" ItemStyle-HorizontalAlign="Left" HeaderText="Query Description" />
                                                          <%--  <asp:BoundField DataField="QueryDescription" HeaderText="Query" />--%>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Query Letter">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hyQueryLetter" Text="View" NavigateUrl='<%#Eval("QueryLetterPath")%>' Target="_blank" runat="server" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                            <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                            <asp:TemplateField HeaderText="Masterincentiveid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="JdOrGMflag" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblJdOrGMflag" Text='<%#Eval("JdOrGMflag") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Respond">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="anchortaglink" runat="server" Text="Respond to Query" Font-Bold="true" ForeColor="Green" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;" valign="top">&nbsp;
                                                </td>
                                            </tr>
                                            <tr id="trprintack" runat="server" visible="false">
                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;" valign="top">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdnQuery" runat="server" />
</asp:Content>
