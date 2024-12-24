<%@ Page Title="Unit Report" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="FormUnitReport.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.FormUnitReport" %>

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
                        <h5 id="head" runat="server" class="text-blue mt-1 mb-3 font-SemiBold">R5.Unit Report</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5" style="display: block;">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div runat="server" id="divCats" class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                            <td>
                                                <label style="display: none;">
                                                    Order By : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rdbOrderby" Style="display: none;"
                                                    runat="server" AutoPostBack="true" OnSelectedIndexChanged="Order_Changed" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True" Value="D">Date</asp:ListItem>
                                                    <asp:ListItem Value="N">Name</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td>
                                                <label style="display: block;">
                                                    District : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlDistrict" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Style="display: block;" runat="server"></asp:DropDownList>
                                            </td>
                                            <td>
                                                <label style="display: block;">
                                                    Category : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCategory" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" Style="display: block;" runat="server">
                                                    <asp:ListItem Value="">All</asp:ListItem>
                                                    <asp:ListItem Value="A1">A1</asp:ListItem>
                                                    <asp:ListItem Value="A2">A2</asp:ListItem>
                                                    <asp:ListItem Value="A3">A3</asp:ListItem>
                                                    <asp:ListItem Value="A4">A4</asp:ListItem>
                                                    <asp:ListItem Value="A5">A5</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <label>
                                                    Industry Type : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlIndustryType" runat="server" class="form-control"
                                                    TabIndex="5" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlIndustryType_SelectedIndexChanged">
                                                    <asp:ListItem Value="">All</asp:ListItem>
                                                    <asp:ListItem Value="1">New Industry</asp:ListItem>
                                                    <asp:ListItem Value="2">Expansion</asp:ListItem>
                                                    <asp:ListItem Value="3">Diversification</asp:ListItem>
                                                    <asp:ListItem Value="4">Modernization</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <label style="display: block;">
                                                    Industry Nature : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlIndustryNature" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlIndustryNature_SelectedIndexChanged">
                                                    <asp:ListItem Value="" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Ginning"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Spinning"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Weaving"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Garmenting"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="Processing"></asp:ListItem>
                                                    <asp:ListItem Value="6" Text="Pressing Mills"></asp:ListItem>
                                                    <asp:ListItem Value="18" Text="Others"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <label>
                                                    Type of Textile : 
                                                </label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlTechnicalNatureOfIndustry" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTechnicalNatureOfIndustry_SelectedIndexChanged">
                                                    <asp:ListItem Value="" Text="All"></asp:ListItem>
                                                    <asp:ListItem Value="0" Text="Conventional Textile"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Technical Textile"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div align="center" class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Button Text="Get Report" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                            </td>
                                            <td>
                                                <asp:Button Text="Reset" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnReset" runat="server" OnClick="btnReset_Click" />
                                            </td>
                                            <td>
                                                <a id="A2" href="#" class="tags" onserverclick="BtnExportExcel_Click" gloss="Export to Excel" runat="server" style="float: right">
                                                    <img src="../../../images/Excel-icon.png" style="margin: 0px 0px 0px 15px;" width="30px" height="30px"
                                                        alt="Excel" /></a>
                                            </td>
                                            <td>
                                                <label id="lbltotalcount" style="color: red; font-size: large; font-family: 'Montserrat-SemiBold'; margin-left: 315px; display: none;"
                                                    runat="server">
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div runat="server" visible="false" id="divHeader" align="center" class="col-sm-12 mb-3 d-flex">
                                    <table>
                                        <tr>
                                            <td>
                                                <label id="lblDist" style="color: red; font-size: large; font-family: 'Montserrat-SemiBold'; margin-left: 315px;"
                                                    runat="server">
                                                </label>
                                            </td>
                                            <td>
                                                <label id="lblNature" style="color: red; font-size: large; font-family: 'Montserrat-SemiBold'; margin-left: 254px;"
                                                    runat="server">
                                                </label>
                                            </td>
                                        </tr>
                                    </table>
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

                                            <asp:BoundField DataField="UNIT_NAME" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="District_Name" ItemStyle-HorizontalAlign="Center" HeaderText="District Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ADDRESS" ItemStyle-HorizontalAlign="Center" HeaderText="Address">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="UID_NO" ItemStyle-HorizontalAlign="Center" HeaderText="UID No">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CATEGORY" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCP" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Commencement of Production">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DirectEmployees_Local" ItemStyle-HorizontalAlign="Center" HeaderText="Local Employment">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="DirectEmployees_Nonlocal" ItemStyle-HorizontalAlign="Center" HeaderText="Nonlocal Employment">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Actual_Investment" ItemStyle-HorizontalAlign="Center" HeaderText="Total Investment(Rs)">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="FirstInvestment" ItemStyle-HorizontalAlign="Center" HeaderText="Date of First Investment">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="LastInvestment" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Last Investment">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TYPE_OF_INDUSTRY" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Industry">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TEXTILE_PROCESS_NAME" ItemStyle-HorizontalAlign="Center" HeaderText="Nature of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeofTexttileText" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Textile">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TechnicalTextile" ItemStyle-HorizontalAlign="Center" HeaderText="Technical Textile Type">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>

                                            <asp:TemplateField HeaderText="Create By" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreateBy" Text='<%#Eval("CreatedBy") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <div align="center" style="color:red;">No Data Found</div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnDistName" runat="server" />
            <asp:HiddenField ID="hdnDateFlag" runat="server" />
            <asp:HiddenField ID="hdnFromDate" runat="server" />
            <asp:HiddenField ID="hdnToDate" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
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
            if (Count > 1) {
                var TotalCount = "Total Units - " + Count;
                if ($('#ContentPlaceHolder1_hdnDateFlag').val() == "D") {
                     TotalCount = "Total Units - " + Count + " From " + $('#ContentPlaceHolder1_hdnFromDate').val() + " - " + $('#ContentPlaceHolder1_hdnToDate').val();
                }
                $('#ContentPlaceHolder1_lbltotalcount').html(TotalCount);
                $('#ContentPlaceHolder1_lbltotalcount').show();
            }
            else {
                $('#ContentPlaceHolder1_lbltotalcount').hide();
            }
        }
    </script>
</asp:Content>
