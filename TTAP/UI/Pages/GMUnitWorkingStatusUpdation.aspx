<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="GMUnitWorkingStatusUpdation.aspx.cs" Inherits="TTAP.UI.Pages.GMUnitWorkingStatusUpdation" %>

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
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
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

        table#ContentPlaceHolder1_rblBankDetails tr td {
            margin: 10px !important;
            padding: 0px 13px;
        }

            table#ContentPlaceHolder1_rblBankDetails tr td input {
                margin: 0px 5px;
            }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <link href="assets/css/basic.css" rel="stylesheet" />
    <div align="left">
        <ol class="breadcrumb">
            You are here &nbsp;!&nbsp; &nbsp; &nbsp;
         <li><i class="fa fa-dashboard"></i><a href="Home.aspx"></a></li>
            <li class=""><i class="fa fa-fw fa-edit">CAF</i> </li>
            <li class="active"><i class="fa fa-edit"></i>&nbsp; &nbsp;<a href="#">Departments</a>
            </li>
        </ol>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-12">
                <table style="width: 100%">
                    <tr>
                        <td>
                            <div class="col-md-12">
                                <h1 class="page-head-line" align="left" style="font-size: large" runat="server" id="h1heading">List of cases sanctioned incentives
                                </h1>
                            </div>
                            <div class="panel-body">
                                <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                    <tr id="trno" runat="server">
                                        <td style="padding: 5px; margin: 5px; color: blue; font-weight: bold" valign="top"
                                            colspan="12" runat="server" id="tdinvestments">List of cases sanctioned incentives
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="12">
                                            <div style="width: 100%">
                                                <asp:GridView ID="GVDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px" OnRowDataBound="GVDetails_RowDataBound"
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

                                                        <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Name of Unit">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <%--<asp:BoundField DataField="DateofReceipt" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Receipt">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>--%>
                                                        <%--<asp:BoundField DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>--%>
                                                        <asp:BoundField DataField="FinalSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Recommended Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TotalReleasedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="SanctionedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Meeting_No" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Numer">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="MEETINGDATE" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <%--<asp:BoundField DataField="SLCDate" ItemStyle-HorizontalAlign="Center" HeaderText="SLCDate">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="MobileNumber" ItemStyle-HorizontalAlign="Center" HeaderText="MobileNumber">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>
                                                     <asp:BoundField DataField="LAPSEDDATA" ItemStyle-HorizontalAlign="Center" HeaderText="Rollbacked(Lapsed Cheque)">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:BoundField>--%>
                                                        <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubincentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Social Status" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStatus" Text='<%#Eval("SocialStatus") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SLC No" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSLCNumber" Text='<%#Eval("Meeting_No") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Intimation Letter"
                                                            Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagGMCertificate" Target="_blank" runat="server" Text="Intimation Letter"></asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Release Doc">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="lnkFile" Target="_blank" NavigateUrl='<%# Eval("filePath") %>'
                                                                    runat="server" Text="Release Order"></asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Release Doc">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="lnkFile" Text="View" NavigateUrl='<%#Eval("filePath")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Attachment" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileName" runat="server" Text='<%#Eval("FILENAMES") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
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
                                    <tr style="height: 25px">
                                        <td></td>
                                    </tr>
                                    <%-- <tr id="trrollbackeddata" runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px; color: blue; font-weight: bold" valign="top"
                                            colspan="12" runat="server" id="td1">Rollbacked data
                                        </td>
                                    </tr>
                                    <tr id="trrollbackedgrid" runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px; width: 100%" valign="top" colspan="44">
                                            <div style="width: 100%">
                                                <asp:GridView ID="grdlapseddata" runat="server" AutoGenerateColumns="false" CellPadding="10"
                                                    CssClass="GRD" ForeColor="#333333" Height="62px"
                                                    PageSize="15" ShowFooter="false" Width="100%" CellSpacing="10">
                                                    <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="2%" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="NameofUnitAddress" ItemStyle-HorizontalAlign="Center"
                                                            HeaderText="Name of Unit & Address">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemStyle Width="90%" />
                                                        </asp:BoundField>
                                                        <asp:BoundField Visible="false" DataField="DateofReceipt" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Receipt">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField Visible="false" DataField="Scheme" ItemStyle-HorizontalAlign="Center" HeaderText="Scheme">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField Visible="false" DataField="RecommendedAmount" ItemStyle-HorizontalAlign="Center"
                                                            HeaderText="Recommended Amount">
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
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Intimation Letter"
                                                            Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortagGMCertificate" Target="_blank" runat="server" Text="Intimation Letter"></asp:HyperLink>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Working Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" Text='<%#Eval("WorkingStatus") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account No">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAccno" Text='<%#Eval("NewAccNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBnkAccName" Text='<%#Eval("BankAccountName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Account Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAccType" Text='<%#Eval("NewAccountType") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bank Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBankName" Text='<%#Eval("NewBankName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Branch Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBranchName" Text='<%#Eval("NewBranchName") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IFSC Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIFSCCode" Text='<%#Eval("NewIFSCCode") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Remarks">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBankAccountRemarks" Text='<%#Eval("BankAccountRemarks") %>' runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle Width="90%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CheckPrintedDate">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCheckPrintedDate" Text='<%#Eval("CheckPrintedDate") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Working Status Updated Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="LBLWORKINGSTATUSUPDATEDDATE" Text='<%#Eval("WorkingStatusUpdtaedDate") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CheckDate" ItemStyle-HorizontalAlign="Center" HeaderText="Cheque Date">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CheckAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Cheque Amount">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CheckNO" ItemStyle-HorizontalAlign="Center" HeaderText="Cheque Number">
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>
                                                    </Columns>
                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                    <EditRowStyle BackColor="#B9D684" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>--%>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <%--<tr style="height: 25px">
                        <td>
                            <tr id="trAgreementBondAttachments" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: 13pt" colspan="12"
                                    align="left">Agreement Bond Attachments
                                </td>
                            </tr>
                        </td>
                    </tr>--%>
                    <%-- <tr id="trAgreementBondCopy" runat="server" visible="false">
                        <td>
                            <div>
                                Agreement Bond Copy :
                             <asp:HyperLink ID="lblFileName2" runat="server" CssClass="LBLBLACK" Visible="false"
                                 Target="_blank"></asp:HyperLink>
                            </div>
                        </td>
                    </tr>
                    <tr id="trAssignmentLetter" runat="server" visible="false">
                        <td>Assignment Letter :
                         <asp:HyperLink runat="server" ID="lnkAssignmentLetter" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                        </td>
                    </tr>--%>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="margin: 5px; padding: 5px" align="left"><b>A.Working Status</b>
                                    </td>
                                    <td style="margin: 5px; padding: 5px">:
                                    </td>
                                    <td style="padding: 30px; margin: 30px" align="left">
                                        <asp:DropDownList ID="ddlworkingstatus" class="form-control txtbox" runat="server">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <%--<asp:ListItem Value="1" Text="Working"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Closed"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Abeyance"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    <%--    <td style="margin: 5px; padding: 5px" align="left" runat="server" visible="false" id="tdROLL1">IF you want to continue with above rollbacked working status details
                                    </td>
                                    <td style="margin: 5px; padding: 5px" runat="server" visible="false" id="tdROLL2">:
                                    </td>
                                    <td style="padding: 30px; margin: 30px" align="left" runat="server" visible="false" id="tdROLL3">
                                        <asp:RadioButtonList ID="RBTYESORNO" runat="server" RepeatDirection="Horizontal" Width="116px" AutoPostBack="true">
                                            <asp:ListItem Value="Y">YES</asp:ListItem>
                                            <asp:ListItem Value="N">NO</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trBankDetails1" runat="server">
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                            <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: 13pt" colspan="12"
                                        align="left"><b>B.Bank Details</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style21" style="padding: 5px; margin: 5px;">1
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" align="left">Name of the Bank
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                        <asp:Label ID="lblbankname" runat="server"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                    <td class="style21" style="padding: 5px; margin: 5px;">2
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" align="left">Branch Name
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                        <asp:Label ID="lblBranchName" runat="server"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr>
                                    <td class="style21" style="padding: 5px; margin: 5px;">3
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" align="left">Account Number
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                        <asp:Label ID="lblAccountNumber" runat="server"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                    <td class="style21" style="padding: 5px; margin: 5px;">4
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" align="left">IFSC Code
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                        <asp:Label ID="lblIFSC" runat="server" align="left"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                </tr>
                                <tr>
                                    <td class="style21" style="padding: 5px; margin: 5px;">5
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" align="left">Account Type
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                        <asp:Label ID="lblaccounttype" runat="server"></asp:Label>
                                    </td>
                                    <td style="padding: 5px; margin: 5px"></td>
                                    <td class="style21" style="padding: 5px; margin: 5px;">6
                                    </td>
                                    <td style="padding: 5px; margin: 5px;" align="left">Loan/Agreement Account No
                                    </td>
                                    <td>:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                        <asp:Label ID="lblLoanAggrementAcNo" runat="server" align="left"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trBankDetails2" runat="server">
                        <td>
                            <table align="left" cellpadding="10" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td style="width: 25%;">
                                        <label class="fw-bold d-block mb-2"><b>C. Above Mentioned Bank Details are?</b></label></td>
                                    <td>
                                        <asp:RadioButtonList ID="rblBankDetails" runat="server" CssClass="form-check form-check-inline"
                                            RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblBankDetails_SelectedIndexChanged">
                                            <asp:ListItem Value="Y">Correct</asp:ListItem>
                                            <asp:ListItem Value="N">Not Correct</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                </tr>
                            </table>

                        </td>
                    </tr>

                    <tr id="trBankDetails3" runat="server">
                        <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                            <table cellpadding="4" cellspacing="5" style="width: 100%">
                                <tr>
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">1
                                    </td>
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">Name of the Bank
                                    </td>
                                    <td class="style21" style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:DropDownList ID="ddlBank" AutoPostBack="true" runat="server" class="form-control txtbox"
                                            TabIndex="5" Width="250px" ValidationGroup="group" OnSelectedIndexChanged="ddlBank_SelectedIndexChanged1">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvBank" runat="server" InitialValue="-- SELECT --"
                                            ControlToValidate="ddlBank" ErrorMessage="Please Select Bank Name" ValidationGroup="group"
                                            SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                    </td>

                                </tr>
                                <tr id="trNBFC" runat="server">
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">NBFC Name
                                    </td>
                                    <td>:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNBFCName" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="200" TabIndex="5" ValidationGroup="group" Width="250px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">2
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">Branch Name<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtBranchName" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="40" TabIndex="5" ValidationGroup="group" Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtBranchName"
                                            ErrorMessage="Please Enter Bank Name" ValidationGroup="group" SetFocusOnError="true"
                                            Display="None"></asp:RequiredFieldValidator>
                                    </td>

                                    <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">3
                                    </td>
                                    <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                    </td>
                                    <td class="style21" style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtAccNumber" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="25" TabIndex="5" ValidationGroup="group" Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAcNo" runat="server" ControlToValidate="txtAccNumber"
                                            ErrorMessage="Please Enter Bank Account Number" ValidationGroup="group" SetFocusOnError="true"
                                            Display="None" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">4
                                    </td>
                                    <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">IFSC Code<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtIfscCode" runat="server" class="form-control txtbox" Height="28px"
                                            MaxLength="12" TabIndex="5" ValidationGroup="group" Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvIFSCCode" runat="server" ControlToValidate="txtIfscCode"
                                            ErrorMessage="Please Enter IFSC Code" ValidationGroup="group" SetFocusOnError="true"
                                            Display="None" />
                                    </td>
                                    <td colspan="5">
                                        <a href="https://www.bankifsccode.com/" target="_blank">Find IFSC code</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">5
                                    </td>
                                    <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Account Type<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px" align="left">
                                        <asp:DropDownList ID="ddlaccounttype" class="form-control txtbox" Width="250px" runat="server">
                                            <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Savings Account"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Current Account"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="Term Loan Account"></asp:ListItem>
                                            <asp:ListItem Value="5" Text="Corporate Account"></asp:ListItem>
                                            <asp:ListItem Value="4" Text="Non Operative Account"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>

                                    <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">6
                                    </td>
                                    <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Loan/Aggrement Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%>
                                    </td>
                                    <td style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtLoanAggrementAcNo" runat="server" class="form-control txtbox"
                                            Height="28px" MaxLength="30" TabIndex="5" ValidationGroup="group" Width="246px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvLoanAggrementAcNo" runat="server" ControlToValidate="txtLoanAggrementAcNo"
                                            ErrorMessage="Please Enter Loan/Aggrement Account Number" ValidationGroup="group"
                                            SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">7
                                    </td>
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">Upload the letter from Banker indication Account Details
                                    </td>
                                    <td class="style21" style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left; display: flex;">
                                        <asp:FileUpload ID="fupBankDet" runat="server" CssClass="CS" Height="28px" />
                                        <asp:HyperLink ID="hypBankDet" runat="server" CssClass="LBLBLACK" Width="165px"
                                            Visible="false" Target="_blank"></asp:HyperLink>&nbsp;&nbsp;
                                        
                                        <asp:Label ID="lblAttachment" runat="server" Visible="False"></asp:Label>
                                        <asp:Button ID="btnBankAccountDet" runat="server" CssClass="btn btn-xs btn-warning" Height="28px"
                                            TabIndex="10" Text="Upload" Width="92px" OnClick="btnBankAccountDet_Click" />
                                    </td>
                                    <td colspan="4">
                                        <a href="DisplayDocs/certificatefrombanker.pdf" target="_blank">Certificate from Banker</a>
                                    </td>
                                </tr>
                                <tr id="troptpbutton" runat="server" visible="false">
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                    <td class="style21" style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-xs btn-warning" Height="30px"
                                            Text="Please Click Here to Confirm Entered Details" Width="300px"
                                            ValidationGroup="group" />
                                    </td>
                                </tr>
                                <tr id="trotp" runat="server" visible="false">
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;"></td>
                                    <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">Please Enter OTP Recieved on your phone
                                    </td>
                                    <td class="style21" style="padding: 5px; margin: 5px">:
                                    </td>
                                    <td class="style6" style="padding: 5px; margin: 5px; text-align: left;">
                                        <asp:TextBox ID="txtOTPVerify" Enabled="false" runat="server" class="form-control txtbox"
                                            MaxLength="6" Height="28px" Width="180px" ToolTip="Please enter OTP Rcvd on your phone here"
                                            AutoPostBack="true"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; margin: 5px" align="center" class="style7"></td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="margin: 5px; padding: 5px" align="left">Remarks
                                    </td>
                                    <td style="margin: 5px; padding: 5px">:
                                    </td>
                                    <td style="padding: 30px; margin: 30px" align="left">
                                        <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control txtbox"
                                            Height="60px" MaxLength="12" TabIndex="5" ValidationGroup="group" Width="300px"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="style7" style="padding: 5px; margin: 5px;">
                            <div style="display: flex; justify-content: center;">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" Enabled="false" OnClick="btnSubmit_Click" />
                                <asp:HiddenField ID="HDFmsgOTP" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <br />
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
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
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
