<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="GMUnitwiseList.aspx.cs" Inherits="TTAP.UI.Pages.GMUnitwiseList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>

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

    .CS {
        background-color: #abcdef;
        color: Yellow;
        border: 1px solid #1d9a5b;
        font: Verdana 10px;
        padding: 1px 4px;
        font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
    }

    .update {
        position: fixed;
        top: 0px;
        left: 0px;
        min-height: 100%;
        min-width: 100%;
        background-image: url("../../Images/ajax-loaderblack.gif");
        /*background-image: url("Images/spinner_60.gif");*/
        background-position: center center;
        background-repeat: no-repeat;
        /*background-color: #e4e4e6;*/
        background-color: #535252;
        z-index: 500 !important;
        opacity: 0.6;
        overflow: hidden;
    }

    .style7 {
        color: #FF3300;
    }

    .style8 {
        color: #FF0000;
        font-weight: bold;
    }

    .GRD {
        width: 800px;
        height: auto;
        border-color: #013161;
        border-style: solid;
        border-width: 1px;
        text-transform: capitalize;
        padding: 5px;
    }

    .GRDHEADER {
        border: 1px solid #1d9a5b;
        color: #1d9a5b;
        vertical-align: middle;
        text-align: center;
        height: 25px;
        width: 50px;
        padding: 10px;
        font-size: 12px;
        font-weight: bold;
        text-transform: capitalize;
        font-family: Verdana;
        background-image: url('../../Resource/Styles/images/bg_blue_grd.gif');
    }

    .GRDITEM {
        /*background-color: WHITE;*/
        color: black;
        font-size: 12px;
        font-weight: normal;
        font-family: Verdana;
        padding: 10px; /*text-decoration:none;*/ /*border-color:#013161;*/ /*border-style:solid;*/
        text-transform: uppercase; /*border-width:1px;*/ /*height:23px;*/ /*text-indent:5px;*/ /*BACKGROUND-IMAGE: url(../images/grid_bg_.gif);*/
    }

    .LBLBLACK {
    }
</style>

<script type="text/javascript" language="javascript">

    function OpenPopup() {

        window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

        return false;
    }
</script>


<link href="assets/css/basic.css" rel="stylesheet" />
<%--  <asp:UpdatePanel ID="upd1" runat="server">
    <ContentTemplate>--%>
<div align="left">
    <ol class="breadcrumb">
        You are here &nbsp;!&nbsp; &nbsp; &nbsp;
                <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
        <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
        <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a> </li>
    </ol>
</div>
<div align="left">
    <div class="row" align="left">
        <div class="col-lg-12">          
            <table style="width: 100%">
                <tr>
                    <td>
                        <div class="col-md-12">
                            <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading">List of cases sanctioned incentives </h1>
                        </div>

                        <div class="panel-body">
                            <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                <tr id="trno" runat="server">
                                    <td style="padding: 5px; margin: 5px; color: blue; font-weight: bold" valign="top" colspan="12" runat="server" id="tdinvestments">List of cases sanctioned incentives
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                                        <div style="width: 100%">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                CssClass="GRD" ForeColor="#333333" Height="62px"
                                                PageSize="15" ShowFooter="false" Width="100%" CellSpacing="4">
                                                <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                     <asp:BoundField DataField="NameofUnitAddress" ItemStyle-HorizontalAlign="Center" HeaderText="Name of Unit & Address">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="DateofReceipt" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Receipt">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="RecommendedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Recommended Amount">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="AllotedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                     <asp:BoundField DataField="SanctionedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SLCNumer" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Numer">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="SLCDate">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MobileNumber" ItemStyle-HorizontalAlign="Center" HeaderText="MobileNumber">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                     <asp:BoundField DataField="LAPSEDDATA" ItemStyle-HorizontalAlign="Center" HeaderText="Rollbacked(Lapsed Cheque)">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEnterperIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="SLCNumer" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSLCNumernor" Text='<%#Eval("SLCNumer") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Intimation Letter" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="anchortagGMCertificate" Target="_blank" runat="server" Text="Intimation Letter"></asp:HyperLink>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Update Working Status">
                                                        <ItemTemplate>
                                                            <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Process" Width="150px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                </Columns>
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#B9D684" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td align="center" style="padding: 5px; margin: 5px; text-align: center;">&nbsp;&nbsp;&nbsp;</td>
                </tr>

                <tr>
                    <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
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
        </div>
    </div>
</div>
<link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
<script src="../../js/jquery-1.7.2.min.js"></script>
<script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>

<link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
<script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>

<script type="text/javascript">
    function pageLoad() {
        var date = new Date();
        var currentMonth = date.getMonth();
        var currentDate = date.getDate();
        var currentYear = date.getFullYear();

        $("input[id$='txtGodate']").datepicker(
          {
              dateFormat: "dd/mm/yy",
              //  maxDate: new Date(currentYear, currentMonth, currentDate)
          }); // Will run at every postback/AsyncPostback
        $("input[id$='txtLocdate']").datepicker(
          {
              dateFormat: "dd/mm/yy",
              //  maxDate: new Date(currentYear, currentMonth, currentDate)
          }); // Will run at every postback/AsyncPostback
    }
    $(function () {
        var date = new Date();
        var currentMonth = date.getMonth();
        var currentDate = date.getDate();
        var currentYear = date.getFullYear();

        $("input[id$='txtGodate']").datepicker(
         {
             dateFormat: "dd/mm/yy",
             //  maxDate: new Date(currentYear, currentMonth, currentDate)
         }); // Will run at every postback/AsyncPostback
        $("input[id$='txtLocdate']").datepicker(
          {
              dateFormat: "dd/mm/yy",
              //  maxDate: new Date(currentYear, currentMonth, currentDate)
          }); // Will run at every postback/AsyncPostback
    });
</script>
<style type="text/css">
    .ui-datepicker {
        font-size: 8pt !important;
        height: 250px;
        padding: 0.2em 0.2em 0;
    }
</style>
</asp:Content>
