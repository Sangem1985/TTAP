<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="FormIssueSanctionLetter.aspx.cs" Inherits="TTAP.UI.Pages.SLC.FormIssueSanctionLetter" %>

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
          <Triggers>
            <asp:PostBackTrigger ControlID="btnSanctionLetter" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Issue Sanction Letter</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Issue Sanction Letter</li>
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
                                                    <asp:BoundField DataField="Actual_Meeting_Date" ItemStyle-HorizontalAlign="Center" HeaderText="SLC Meeting Date">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FinalSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Amount">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="PartialSanction" ItemStyle-HorizontalAlign="Center" HeaderText="Is Partial Sanction">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblTISId" Text='<%#Eval("TISId") %>' runat="server" />
                                                            <asp:Label ID="lblMeeting_No" Text='<%#Eval("Meeting_No") %>' runat="server" />
                                                            <asp:Label ID="lblActual_Meeting_Date" Text='<%#Eval("Actual_Meeting_Date") %>' runat="server" />
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
                                    <div runat="server" class="row">
                                        <div class="col-sm-3 col-md-3 form-group">
                                            <label runat="server">Sanction Letter</label>
                                            <asp:RadioButtonList ID="rbtnStatus" runat="server" AutoPostBack="true" RepeatDirection="Vertical" OnSelectedIndexChanged="rbtnStatus_SelectedIndexChanged">
                                                <asp:ListItem Value="S" Selected="True" Text="Issue"></asp:ListItem>
                                                <asp:ListItem Value="U" Text="Upload File"></asp:ListItem>
                                                <asp:ListItem Value="R" Text="Reject"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-3 col-md-3 form-group">
                                            <asp:Label ID="lblremarks" runat="server"> Remarks : </asp:Label>
                                            <asp:TextBox ID="txtremarks" Visible="true" class="form-control" TextMode="MultiLine" runat="server" Height="100px"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 col-md-8 form-group" runat="server" id="divFileUpload" visible="false">
                                            <div class="col-sm-8 table-responsive">
                                                <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                    <tr align="center">
                                                        <th>Upload Document </th>
                                                        <th>File Name </th>
                                                    </tr>
                                                    <tr class="GridviewScrollC1Item" id="tr1" visible="true" runat="server">
                                                        <td align="left">
                                                            <asp:FileUpload ID="fuSanctionLetter" runat="server" TabIndex="64" />
                                                            <asp:Button ID="btnSanctionLetter" TabIndex="65" CssClass="btn btn-info btn-sm mx-2" runat="server" Text="Upload" OnClick="btnSanctionLetter_Click" /></td>
                                                        <td align="center">
                                                            <asp:HyperLink ID="lblSanctionLetter" runat="server" Target="_blank"></asp:HyperLink>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <asp:LinkButton ID="lbtnSanctionLetterDelete" Text="Delete" runat="server" Visible="false" OnClick="lbtnSanctionLetterDelete_Click"
                                                                    OnClientClick="if (!confirm('Are you sure you want delete?')) return false;"></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div class="col-sm-3 col-md-3 form-group" style="margin-top: 37px;">
                                            <asp:Button ID="btnProcess" runat="server" CssClass="btn btn-blue m-2" OnClick="btnProcess_Click" Text="Process" />
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
    <asp:HiddenField runat="server" ID="hdnFilePath" Value="" />
</asp:Content>
