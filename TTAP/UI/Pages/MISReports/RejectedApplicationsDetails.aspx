<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master"  AutoEventWireup="true" EnableEventValidation="false" CodeBehind="RejectedApplicationsDetails.aspx.cs" Inherits="TTAP.UI.Pages.MISReports.RejectedApplicationsDetails" %>

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
                        <a href="#" class="current" runat="server" id="acurrentpage">Rejected Applications</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="../frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item"><a href="frmIncentiveReports.aspx">Reports</a></li>
                            <li class="breadcrumb-item">Rejected Applications</li>
                        </ul>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Rejected Applications</h5>
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div class="col-sm-12 mb-3 d-flex">
                                    <asp:TextBox ID="txtsearch" runat="server" class="form-control w-sm-50 w-75" Style="max-width: 400px;" placeholder="Type to search"></asp:TextBox>
                                    <asp:Button Text="Search" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                                    <asp:Button Text="Reset" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnReset" runat="server" OnClick="btnReset_Click" />
                                    <label style="margin: 6px 4px 5px 16px;display:none;">
                                        Rejected By : 
                                    </label>
                                    <asp:RadioButtonList ID="rdbOrderby" Style="margin: 0px 0px 0px 11px;display:none;"
                                        runat="server" AutoPostBack="true" OnSelectedIndexChanged="Order_Changed" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="D">Date</asp:ListItem>
                                        <asp:ListItem Value="AR">Name</asp:ListItem>
                                    </asp:RadioButtonList>
                                     <label style="margin: 6px 4px 5px 16px;">
                                        Only Auto Rejected
                                    </label>
                                    <asp:CheckBox ID="chkAutoList" runat="server" AutoPostBack="true" OnCheckedChanged="chkAutoList_CheckedChanged" />
                                     <label style="margin: 6px 4px 5px 16px;display:none;">
                                        District : 
                                    </label>
                                    <asp:DropDownList ID="ddlDistrict" style="display:none;" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-sm-12 mb-3  text-right">
                                        <a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server" style="float: right">
                                            <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                                alt="Excel" /></a>
                                    </div>

                                <%--  <div class="col-sm-12 mb-3 d-flex">
                                    <input type="text" id="search" class="form-control w-sm-50 w-75" style="max-width: 400px;" placeholder="Type to search" />
                                    <input type="button" value="Clear" id="clear" class="btn btn-blue ml-2 px-4 py-1 title5" />
                                </div>--%>

                                <div class="col-sm-12 table-responsive">
                                    

                                    <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"
                                        PageSize="20" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="Address" ItemStyle-HorizontalAlign="Center" HeaderText="Address">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                           
                                            <asp:BoundField DataField="SubmissionDate" ItemStyle-HorizontalAlign="Center" HeaderText="Submitted Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Date">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                           
                                            <asp:BoundField DataField="ApplicationNumber" ItemStyle-HorizontalAlign="Center" HeaderText="Application Number">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TypeofTexttileText" ItemStyle-HorizontalAlign="Center" HeaderText="Type of Textile">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RejectedAt" ItemStyle-HorizontalAlign="Center" HeaderText="Rejected At">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RejectedBy" ItemStyle-HorizontalAlign="Center" HeaderText="Rejected By">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="QueryDt" ItemStyle-HorizontalAlign="Center" HeaderText="Query Raised Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RejectedDt" ItemStyle-HorizontalAlign="Center" HeaderText="Rejected Date">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="RejectionRemarks" ItemStyle-HorizontalAlign="Center" HeaderText="Rejection Remarks">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="DCP" ItemStyle-HorizontalAlign="Center" HeaderText="Date of Commencement of Production">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ApplicantName" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Name">
                                                <ItemStyle CssClass="text-left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Status" ControlStyle-CssClass="SetgridWidth" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:GridView ID="gvIncentives" CssClass="SetgridWidth" ShowHeader="false"
                                                        runat="server">
                                                    </asp:GridView>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
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

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
   

    <script src="../../../NewCss/js/jquery.min.js"></script>
    <script src="../../../js/jquery.floatThead.js"></script>
    <script type="text/javascript">
        function OncheckAuto() {
            if ($('#ContentPlaceHolder1_chkAutoList').is(':Checked') == true) {
                $('#ContentPlaceHolder1_rdbOrderby_0').attr('checked', false);
                $('#ContentPlaceHolder1_rdbOrderby_1').attr('checked', true);
            }
            else {
                $('#ContentPlaceHolder1_rdbOrderby_0').attr('checked', true);
                $('#ContentPlaceHolder1_rdbOrderby_1').attr('checked', false);
            }
            
            $('#ContentPlaceHolder1_btnSearch').click();
        }

    </script>
    
</asp:Content>