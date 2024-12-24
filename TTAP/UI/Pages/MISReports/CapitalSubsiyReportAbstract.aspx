<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CapitalSubsiyReportAbstract.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.CapitalSubsiyReportAbstract" %>

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
            <asp:PostBackTrigger ControlID="A2" />
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
                            <li class="breadcrumb-item">Capital Subsidy Applied Units Status Abstract</li>
                        </ul>
                    </div>

                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <table runat="server" id="tblHead">
                            <tr>
                                <td>
                                    <h5 class="text-blue mt-1 mb-3 font-SemiBold" style="margin: 0px 35px 0px 0px;">R12. Capital Subsidy Applied Units Status Abstract</h5>
                                </td>
                                <td>
                                    <asp:Label ID="lbl" runat="server">GridView</asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkView" class="text-blue mt-1 mb-3 font-SemiBold" Style="margin: 0px 0px 8px 7px;"
                                        runat="server" OnCheckedChanged="chkView_CheckedChanged" AutoPostBack="true" />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" Style="margin: 0px 0px 0px 30px;"
                                        runat="server">District : </asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDistrict" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Style="display: block;" runat="server"></asp:DropDownList>
                                </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                <td runat="server" visible="false" id="trExcel">
                                    <a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: left">
                                        <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                            alt="Excel" /></a></td>
                            </tr>
                        </table>
                        <div class="widget-content">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div> 
                                <div class="tableFixHead" style="overflow-y:hidden">
                                <div style="text-align-last: center; font-size: large; font-weight: 900; color: green; margin: 0px 0px 8px 0px;" runat="server" visible="false" id="divGridHead">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblHeader" runat="server">Header</asp:Label>
                                        </td>
                                    </tr>
                                </div>
                                <div id="DivGridView" class="col-sm-12 table-responsive" runat="server" visible="false">
                                    <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise" ShowFooter="False"
                                        PageSize="20" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>

                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" HeaderText="Total No of Units in TTAP"
                                                DataTextField="TotalUnits">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="Total No of Units Applied for Capital Subsidy"
                                                DataTextField="NoofClaims">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Units Pending at Payment Verification"
                                                DataTextField="NoOfIncentivesatPayment">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Units Pending at DLO"
                                                DataTextField="NoOfIncentivesatDLO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Units Pending at Applicant"
                                                DataTextField="NoOfIncentivesatApplicant">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Units Pending at Head Office"
                                                DataTextField="NoOfIncentivesatHO">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Units Rejected"
                                                DataTextField="NoOfIncentivesRejected">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Units Pending at DLO for Revised Inspection"
                                                DataTextField="PendingRevisedInspectionIncentives">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Units Sanctioned"
                                                DataTextField="TotalNoOfIncentivesSanctioned">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField ItemStyle-HorizontalAlign="Center" Target="_blank" HeaderText="No of Units Released"
                                                DataTextField="TotalNoOfIncentivesReleased">
                                                <FooterStyle HorizontalAlign="Center" Font-Underline="false" Font-Bold="true" CssClass="text-center" />
                                                <ItemStyle Font-Underline="false" HorizontalAlign="Center" CssClass="text-center" />
                                            </asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                      </div>

                                <div class="col-sm-8 table-responsive" id="divNormalView" runat="server" style="margin: 3px 3px 18px 210px;">
                                    <div style="text-align-last: center; font-size: large; font-weight: 900; color: green; margin: 0px 0px 8px 0px;" runat="server" id="divNormalHead">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblHeader2" runat="server">Header</asp:Label>
                                        </td>
                                    </tr>
                                </div>
                                    <table class="table table-bordered title6 alternet-table w-80 NewEnterprise">
                                       
                                        <tr>
                                            <td>1</td>
                                            <td runat="server" width="80%">
                                                <asp:Label runat="server">Total No of Units in TTAP</asp:Label>
                                            </td>
                                            <td width="20%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalUnits" ToolTip="Click here to get Break up Report" onclick="return Navigate('T')" CssClass="font-weight-bold" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td runat="server" width="80%">
                                                <asp:Label runat="server">Total No of Units Applied for Capital Subsidy</asp:Label>
                                            </td>
                                            <td width="20%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdTotalClaims" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('1')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td width="40%">No of Units Pending at Payment Verification</t>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdPendingPayment" ToolTip="Click here to get Break up Report" onclick="return Navigate('2')" CssClass="font-weight-bold" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>4</td>
                                            <td width="40%">No of Units Pending at DLO</t>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdPendingDLO" ToolTip="Click here to get Break up Report" onclick="return Navigate('3')" CssClass="font-weight-bold" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>5</td>
                                            <td width="40%">No of Units Pending at Applicant</td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdPendingApplicant" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('4')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>6</td>
                                            <td width="40%">No of Units Pending at Head Office</td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdPendingHO" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('5')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>7</td>
                                            <td width="40%">No of Units Rejected</td>
                                            <td style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdReject" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('6')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trSanctionedInc">
                                            <td>8</td>
                                            <td width="40%">No of Units Pending at DLO for Revised Inspection</td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdRevisedInspection" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('7')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        <tr runat="server" id="trSanctionedAmount">
                                            <td>9</td>
                                            <td width="40%">No of Units Sanctioned </td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdSanctionioned" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('8')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                        </tr>
                                        <tr runat="server" id="tr1">
                                            <td>10</td>
                                            <td width="40%">No of Units Released</td>
                                            <td width="40%" style="color: blue; cursor: pointer;">
                                                <asp:HyperLink ID="tdReleased" ToolTip="Click here to get Break up Report" CssClass="font-weight-bold" onclick="return Navigate('9')" runat="server"></asp:HyperLink>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                  
                                <div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Button Text="Print" ID="btnprint" runat="server" Style="margin: 0px 0px 0px 630px; background: chartreuse; width: 8%;" OnClientClick="return Print();return false;" />
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

        function Print() {
            $('#ContentPlaceHolder1_lbtnback').hide();
            $('#ContentPlaceHolder1_btnprint').hide();
            $('#ContentPlaceHolder1_tblHead').hide();
            $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 190px");
            window.print();
            $('#ContentPlaceHolder1_lbtnback').show();
            $('#ContentPlaceHolder1_btnprint').show();
            $('#ContentPlaceHolder1_tblHead').show();
            $("#ContentPlaceHolder1_Header").css("margin", "0px 0px 0px 325px");
            return false;
        }
        jQuery(document).bind("keyup keydown", function (e) {
            if (e.ctrlKey && e.keyCode == 80) {
                Print();
                return false;
            }
        });
        function Navigate(res) {
            var DistId = $('#ContentPlaceHolder1_ddlDistrict').val();
            if (DistId == "0") { DistId = ""; }
            if (res == "T") {
                window.open("FormUnitReport.aspx?Level=0&Flag=Z&DistrictId=" + DistId);
                return false;
            }
            else {
                window.open("CapitalSubsidyDetailedReport.aspx?Status=" + res + "&DistId=" + DistId);
                return false;
            }

        }
    </script>
</asp:Content>
