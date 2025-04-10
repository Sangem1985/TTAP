<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="CommissionerApplications.aspx.cs" Inherits="TTAP.UI.Pages.COI.CommissionerApplications" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #search {
            position: unset !important;
        }
    </style>
    <style>
        #divGrid {
            position: relative;
            max-height: 400px;
            overflow-y: auto;
        }

        .sticky-header th {
            position: sticky;
            top: 0;
            z-index: 10;
            background-color: #ffffff;
            border: 1px solid #282222;
            box-shadow: 0 2px 3px rgba(0, 0, 0, 0.1);
            padding: 10px;
            text-align: center;
        }
    </style>

    <script>

    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Applications</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Applications</li>
                        </ul>
                    </div>
                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                       
                        <div class="widget-content nopadding">
                            <div class="row">
                                <div class="col-sm-12 text-right pr-5" runat="server">
                                    <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                                </div>
                                <div class="col-sm-12 mb-3 d-flex" runat="server" visible="false">
                                    <asp:TextBox ID="txtsearch" runat="server" class="form-control w-sm-50 w-75" Style="max-width: 400px;" placeholder="Type to search"></asp:TextBox>
                                    <asp:Button Text="Search" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server"  />
                                    <asp:Button Text="Reset" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnReset" runat="server"  />
                                </div>
                                <div class="table-responsive" id="divGrid">
                                    <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                        CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"
                                        PageSize="20" GridLines="Both">
                                        <HeaderStyle VerticalAlign="Middle" CssClass="sticky-header text-center" />
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
                                            <asp:TemplateField HeaderText="Application No.">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblApplicationNo" Text='<%#Eval("ApplicationNumber") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="View Application">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="hypViewApplication" Text="View Application" NavigateUrl='<%#Eval("ViewApplication") %>' Target="_blank"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Appraisal Note">
                                                <ItemTemplate>
                                                    <asp:HyperLink runat="server" ID="hypViewAppraisal" Text="View Appraisal" NavigateUrl='<%#Eval("ViewAppraisalNote") %>' Target="_blank"></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUnit" Text='<%#Eval("UnitName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Incentive Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveName" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Social Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSocailStatus" Text='<%#Eval("SocialStatusText") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Application Recieved Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAppRcvdDate" Text='<%#Eval("ApplicationFiledDate") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Recommended Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRecommendedAmount" Text='<%#Eval("AddlDirector_Rec_Amount") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Additional Director Recommended Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAdRecomDate" Text='<%#Eval("AddlDirector_Process_Date") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Verify Application" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:RadioButtonList ID="rdbVerify" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Approve</asp:ListItem>
                                                        <asp:ListItem Value="2">Return</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Process Application" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnProcess" runat="server" Text="Submit" CssClass="btn btn-blue py-1 title7" OnClick="btnProcess_Click" ></asp:Button>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Commissioner Approved Date" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblApprovedDate" Text='<%#Eval("Commissioner_Processed_Dt") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Commissioner Returned Date" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReturnedDate" Text='<%#Eval("Commissioner_Processed_Dt") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="SubIncentive Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnDistrictId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>