<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FormUpdateWorkingStatus.aspx.cs" Inherits="TTAP.UI.Pages.FormUpdateWorkingStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../Js/validations.js"></script>

    <script language="javascript" type="text/javascript">
        

        
    </script>

    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .fa.fa-hand-o-right {
            margin-right: 12px;
        }

        .head2 {
            font-weight: bold;
            color: tomato;
            font-size: 16px;
        }

        .page-head-line {
            font-size: 30px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 20px;
            border-bottom: 2px solid #00CA79;
            margin-bottom: 10px;
        }

        .page-subhead-line {
            font-size: 14px;
            padding-top: 5px;
            padding-bottom: 20px;
            font-style: italic;
            margin-bottom: 30px;
            border-bottom: 1px dashed #00CA79;
        }
    </style>


    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">

        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Incentive Types</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Update Unit Working Status</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="row">
                        <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>

                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row" id="divPrint" runat="server">
                                        <div class="row col-sm-12">
                                            <div class="col-sm-6 col-md-3 form-group" runat="server" visible="false">
                                                <label runat="server" id="tdworkstatus">Incentives</label>
                                                <asp:DropDownList runat="server" ID="ddlIncentives" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>

                                            <div class="col-sm-6 col-md-3 form-group" runat="server" visible="false">
                                                <label runat="server" id="td1">SLC No</label>
                                                <asp:DropDownList runat="server" ID="ddlslc" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-6 col-md-3 form-group" runat="server" visible="false">
                                                <label runat="server" id="Label1">Partial Sanctions</label>
                                                <asp:CheckBox runat="server" ID="chkPartial"  CssClass="form-control" />
                                            </div>
                                            <div class="col-sm-6 col-md-3 form-group" style="margin-top: 13px;" runat="server" visible="false">

                                                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-blue m-2" Text="Get Data" />
                                            </div>
                                        </div>
                                        <div class="col-sm-12 table-responsive">
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
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ApplicationNumber" ItemStyle-HorizontalAlign="Center" HeaderText="Application Number">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SocialStatusText" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="Social Status">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Meeting_No" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Meeting No">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                   <%-- <asp:BoundField DataField="Actual_Meeting_Date" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Meeting Date">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>--%>
                                                    <%--<asp:BoundField DataField="FinalSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>--%>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Working Status">
                                                        <ItemTemplate>
                                                            <asp:RadioButtonList ID="rbtnStatus" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="Y" Selected="True" Text="Working"></asp:ListItem>
                                                                <asp:ListItem Value="N" Text="Not Working"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                            <asp:Label ID="lblremarks" runat="server"> Remarks : </asp:Label>
                                                            <asp:TextBox ID="txtremarks" Visible="true"  class="form-control" TextMode="MultiLine" runat="server" Height="100px"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="text-center" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="280px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Process Application" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnProcess" runat="server" Text="Process" CssClass="btn btn-blue py-1 title7" OnClick="btnProcess_Click"></asp:Button>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblTISId" Text='<%#Eval("TISID") %>' runat="server" />
                                                            <asp:Label ID="lblIsPartial" Text='<%#Eval("IsPartial") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div id="divNoData" style="color: red;"
                                            runat="server" visible="false">
                                            No Data Found
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField runat="server" ID="hdndist" />
    <asp:HiddenField runat="server" ID="hdnUserId" />
</asp:Content>