<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="CapitalSubsidyDetailedReport.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.CapitalSubsidyDetailedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        #search {
            position: unset !important;
        }

        .SetgridWidth {
            width: 548px;
        }

        .ScrollStyle {
            max-height: 150px;
            overflow-y: scroll;
        }

        .tags {
            display: inline;
            position: relative;
        }

            .tags:hover:after {
                background: #333;
                background: rgba(0, 0, 0, .8);
                border-radius: 5px;
                bottom: -34px;
                color: #fff;
                content: attr(gloss);
                left: 20%;
                padding: 5px 15px;
                position: absolute;
                z-index: 98;
                width: 150px;
            }

            .tags:hover:before {
                border: solid;
                border-color: #333 transparent;
                border-width: 0 6px 6px 6px;
                bottom: -4px;
                content: "";
                left: 50%;
                position: absolute;
                z-index: 99;
            }

        .tableFixHead {
            overflow: auto;
        }

            .tableFixHead th {
                position: sticky;
                top: 0;
            }

        /* Just common table stuff. */
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px 16px;
        }

        th {
            /*background: #eee;*/
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
                        <a href="#" class="current" runat="server" id="acurrentpage">Unit Report</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="../frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="frmIncentiveReports.aspx">Reports</a></li>
                            <li class="breadcrumb-item">Unit Report</li>
                        </ul>
                    </div>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <table>
                            <tr>
                                <td>
                                    <h5 id="header" runat="server" class="text-blue mt-1 mb-3 font-SemiBold">Capital Subsidy Applied Units Report</h5>
                                </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                <td><a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: left">
                                    <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                        alt="Excel" /></a>  </td>
                                <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                            </tr>
                        </table>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5" style="display: block;">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div runat="server" id="divddl" style="display: none;">
                                    <td>
                                        <asp:Label ID="Label1" Style="margin: 0px 0px 0px 30px;"
                                            runat="server">District : </asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDistrict" class="form-control" runat="server">
                                            <asp:ListItem Value="0">-All Districts-</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </div>
                                <div class="tableFixHead" style="overflow-y: hidden">
                                    <div style="text-align-last: center; font-size: large; font-weight: 900; color: green; margin: 0px 0px 8px 0px;">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblHeader" runat="server">Header</asp:Label>
                                            </td>
                                        </tr>
                                    </div>
                                    <div runat="server" id="TotalGrid" class="col-sm-12 table-responsive">

                                        <div id="container" style="overflow: scroll; overflow-x: hidden;">
                                        </div>
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
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="UnitNameAddress" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name & Address">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                  <asp:BoundField DataField="DistrictName" ItemStyle-HorizontalAlign="Center" HeaderText="District">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="UID_No" ItemStyle-HorizontalAlign="Center" HeaderText="UID No">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Textile Process Name">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DCP" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Commencement of Production">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TypeofTexttileText" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Texttile">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TechnicalTextile" ItemStyle-HorizontalAlign="Center" HeaderText="Technical Textile">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CurrentInvestment" ItemStyle-HorizontalAlign="Center" HeaderText="Total Investment(in Crores)">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="ClaimAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Claim Amount">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ApplicationNO" ItemStyle-HorizontalAlign="Center" HeaderText="Application No">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SubmittedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Submitted Date">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DLOReceivedDate" ItemStyle-HorizontalAlign="Center" HeaderText="DLOReceivedDate">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                 <asp:BoundField DataField="DLOPendingDays" ItemStyle-HorizontalAlign="Center" HeaderText="DLO Pending Days">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QueryRaisedDate" ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised Date">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="QueryPendingDays" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Pending Days">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="InspScheduledDt" ItemStyle-HorizontalAlign="Center" HeaderText="Inspection Scheduled Date">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="InspCompletedDt" ItemStyle-HorizontalAlign="Center" HeaderText="Inspection Completed Date">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="InspReportUploadedDt" ItemStyle-HorizontalAlign="Center" HeaderText="Inspection Report Uploaded Date">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Status" ItemStyle-HorizontalAlign="Center" HeaderText="Status">
                                                    <ItemStyle CssClass="text-left" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="IncentiveID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                <div align="center">No Data Found</div>
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnStatus" runat="server" />
            <asp:HiddenField ID="hdnDateFlag" runat="server" />
            <asp:HiddenField ID="hdnFromDate" runat="server" />
            <asp:HiddenField ID="hdnToDate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../../../Js/jquery-latest.min.js"></script>
    <script src="../../../Js/jquery-ui.min.js"></script>
    <script src="../../../Js/jquery.min.js"></script>
    <script src="../../../js/jquery.floatThead.js"></script>
    <script type="text/javascript">

        function pageLoad() {
            /*var width = new Array();
            var table = $("table[id*=gvdetailsnew]");
            table.find("th").each(function (i) {
                width[i] = $(this).width();
            });
            headerRow = table.find("tr:first");
            headerRow.find("th").each(function (i) {
                $(this).width(width[i]);
            });
            firstRow = table.find("tr:first");
            firstRow.find("td").each(function (i) {
                $(this).width(width[i]);
            });
            var header = table.clone();
            header.empty();
            header.append(headerRow);
            header.append(firstRow);
            header.css("width", width);
            $("#container").before(header);
            table.find("tr:first td").each(function (i) {
                $(this).width(width[i]);
            });
            $("#container").height(300);
            $("#container").width(table.width() + 20);
            $("#container").append(table);*/

            var Count = $('#ContentPlaceHolder1_TotalGrid').find('tr').length - 1;
            var Status = "";
            if (Count > 0) {
                var STAT = $('#ContentPlaceHolder1_hdnStatus').val();
                if (STAT == "1") {
                    Status = "Total No of Units Applied for Capital Subsidy";
                }
                if (STAT == "2") {
                    Status = "No of Units Pending at Payment Verification";
                }
                if (STAT == "3") {
                    Status = "No of Units Pending at DLO";
                }
                if (STAT == "4") {
                    Status = "No of Units Pending at Applicant";
                }
                if (STAT == "5") {
                    Status = "No of Units Pending at Head Office";
                }
                if (STAT == "6") {
                    Status = "No of Units Rejected";
                }
                if (STAT == "7") {
                    Status = "No of Units Pending at DLO for Revised Inspection";
                }
                if (STAT == "8") {
                    Status = "No of Units Sanctioned";
                }
                if (STAT == "9") {
                    Status = "No of Units Released";
                }
                var TotalCount = "";
                if ($('#ContentPlaceHolder1_ddlDistrict').val() == "0") {
                    TotalCount = Status + " - " + Count;
                }
                else {
                    var DistName = $("#ContentPlaceHolder1_ddlDistrict option:selected").text();
                    TotalCount = DistName + " - " + Status + " - " + Count;
                }
                $('#ContentPlaceHolder1_lblHeader').html(TotalCount);
                $('#ContentPlaceHolder1_lblHeader').show();
            }
            else {
                $('#ContentPlaceHolder1_lblHeader').hide();
            }
        }
    </script>
</asp:Content>
