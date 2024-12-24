<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="PaymentFailedTransactions.aspx.cs" Inherits="TTAP.UI.Pages.PaymentFailedTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="http://code.jquery.com/Jquery.min.js" charset="utf-8"></script>
    <script src="../../Js/validations.js" type="text/javascript"></script>
    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Dashboard</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Transactions Tracker</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Transactions Tracker</h5>
                        <tr>
                            <td>
                                <label style="margin: 6px 4px 5px 16px;">
                                    Search By : 
                               
                                </label>
                            </td>
                            <div class="col-sm-12 mb-3 d-flex">
                                <asp:TextBox ID="txtsearch" runat="server" class="form-control w-sm-50 w-75" Style="max-width: 400px;" placeholder="Type to search"></asp:TextBox>
                                <asp:Button Text="Search" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
                            </div>
                        </tr>
                        <div class="widget-content nopadding">
                            <div id="divbank" runat="server">
                                <div class="row">
                                    <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px !important; margin-bottom: 10px;">Transaction Details</div>
                                </div>
                                <div class="row" runat="server" id="divSuccess" visible="false">
                                    <div class="col-sm-4 form-group">
                                         <div class="col-sm-4 form-group">
                                        <label class="control-label label-required" id="Label14" runat="server">Status</label>
                                        <asp:TextBox ID="txtStatus" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                    </div>
                                        <label class="control-label label-required" id="Label16" runat="server">Online Bill Number</label>
                                        <asp:TextBox ID="txtBillNo" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4 form-group">
                                        <label class="control-label label-required" id="Label15" runat="server">Bill No.</label>
                                        <asp:TextBox ID="txtRequestId" runat="server" Enabled="false" class="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4 form-group">
                                        <label class="control-label label-required" id="Label19" runat="server">Payment Reference No.</label>
                                        <asp:TextBox ID="txtPgRefNo" runat="server" Enabled="false" class="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4 form-group">
                                        <label class="control-label label-required" id="Label18" runat="server">Base Amount</label>
                                        <asp:TextBox ID="txtBaseAmount" Enabled="false" runat="server" class="form-control" ></asp:TextBox>
                                    </div>
                                    <div class="col-sm-4 form-group">
                                        <label class="control-label label-required" id="Label20" runat="server">Charges</label>
                                        <asp:TextBox ID="txtCharges" Enabled="false" runat="server" class="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row" runat="server" id="divFailed" visible="false">
                                    <div class="col-sm-4 form-group">
                                        <label class="control-label label-required" id="Label13" runat="server">Status</label>
                                        <asp:TextBox ID="txtFailStatus" Enabled="false" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="row" runat="server" id="divBtn" visible="false">
                                    <div class="col-sm-4 form-group">
                                        <asp:Button Text="Update Payment" CssClass="btn btn-blue ml-2 px-4 py-1 title5" ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" />
                                    </div>
                                </div>
                            </div>
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
</asp:Content>
