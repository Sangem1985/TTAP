<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmIncentiveCAFDetails.aspx.cs" Inherits="TTAP.UI.Pages.frmIncentiveCAFDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Js/validations.js" type="text/javascript"></script>

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

        .blink_me {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>
    <script type="text/javascript" language="javascript">
        function OpenPopup() {
            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");
            return false;
        }
    </script>

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
        </div>
        <div class="container mt-4 pb-4" id="Receipt" runat="server">
            <div class="row">
                <div class="col-sm-12 offset-md-1 col-md-10 col-lg-8 offset-lg-2 frm-form box-content py-3 font-medium title5">
                    <div class="widget-box">
                        <div class="widget-title">
                            <span class="icon">
                                <i class="icon-info-sign"></i>
                            </span>
                            <h5 class="text-blue mb-3 font-SemiBold">Selected Incentive(s)</h5>
                        </div>
                        <div id="divPercentage" runat="server" visible="false">
                            <label class="blink_me text-danger font-weight-bold">You are applying after 6 months from your Date of Commencement of Production so you will get 50% of subsidy to this Incentive</label>
                        </div>
                        <div class="widget-content nopadding">
                            <table style="width: 100%" align="center">
                                <tr>
                                    <td valign="top">
                                        <div style="width: 100%">
                                            <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                PageSize="50" ShowFooter="false" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" CellSpacing="4">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                            <asp:HiddenField ID="HdfQueid" runat="server" />
                                                            <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                            <asp:HiddenField ID="HdfDeptid" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="70px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="cbIncentive" runat="server" Text='<%#Eval("IncentiveName")%>' />
                                                            <asp:Label ID="lblIncentiveId" runat="server" Text='<%#Eval("IncentiveID") %>' Visible="false" />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="hdfID" runat="server" />
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="group" />
                                        <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                            ShowSummary="False" ValidationGroup="child" />
                                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-blue m-2 px-4"
                                            OnClick="BtnSave_Click" TabIndex="10" Text="Next" ValidationGroup="group" />
                                        <asp:Button ID="BtnDelete" Visible="False" runat="server" CausesValidation="False" CssClass="btn btn-success m-2 px-3"
                                            OnClick="BtnClear0_Click" TabIndex="10" Text="Submit" />
                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning m-2" Visible="false"
                                            OnClick="BtnClear_Click" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen" />
                                    </td>
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
            </div>
        </div>
        <div id="card">
            <div class="row" id="divNewExpInvDetails" visible="false" runat="server">
                <div class="col-sm-12 text-danger font-SemiBold border-danger text-center" id="divNewExpInvDetails1" runat="server" style="font-size: 16px; margin-bottom: 15px;">
                    <asp:HyperLink ID="HplNewExpInvDetails" CssClass="blink_me text-danger font-weight-bold" NavigateUrl="~/UI/Pages/frmNewIncentive.aspx?IsAllowModify=Y" runat="server">Click here for Add new Plant & Machinary Details</asp:HyperLink>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="hdnUserID" runat="server" />
    </div>
</asp:Content>
