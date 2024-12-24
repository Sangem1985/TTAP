<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmPartiallyReleasedApplications.aspx.cs" Inherits="TTAP.UI.Pages.Releases.frmPartiallyReleasedApplications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script src="../../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../Js/validations.js"></script>
     
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
    </style>


    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <%-- <Triggers>
            <asp:PostBackTrigger ControlID="btnPaymentProof" />
        </Triggers>--%>
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
                            <li class="breadcrumb-item">Partial Released Incentives</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">List of Cases Partial Released Incentives</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-6 col-md-3 form-group">
                                            <label>Type of Application</label>
                                            <asp:DropDownList runat="server" ID="ddlApplicationMode" class="form-control" TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddlApplicationMode_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="--All--"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="SLC"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="DLC"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 col-md-3 form-group">
                                            <label runat="server" id="tdworkstatus">Category</label>
                                            <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control" TabIndex="1">
                                                <asp:ListItem Value="0">--All--</asp:ListItem>
                                                <asp:ListItem Value="1">General</asp:ListItem>
                                                <asp:ListItem Value="2">OBC</asp:ListItem>
                                                <asp:ListItem Value="3">SC</asp:ListItem>
                                                <asp:ListItem Value="4">ST</asp:ListItem>
                                                <asp:ListItem Value="5">Minority</asp:ListItem>
                                                <asp:ListItem Value="101">Category Wise</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-6 col-md-3 form-group">
                                            <label>Incentives</label>
                                            <asp:DropDownList runat="server" ID="ddlIncentives" class="form-control" TabIndex="1">
                                                <asp:ListItem Value="0" Text="--All--"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-12 form-group text-center">
                                            <asp:Button ID="btnget" CssClass="btn btn-blue m-2" runat="server"
                                                Text="Get List" OnClick="btnget_Click" />
                                           <%-- <asp:Button ID="Button3" CssClass="btn btn-warning m-2 px-3" runat="server"
                                                Text="Clear" OnClick="Button3_Click" />--%>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"
                                                PageSize="20" GridLines="Both"
                                                OnRowDataBound="gvdetailsnew_RowDataBound">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Header" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Incentive Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" runat="server" Text='<%#Eval("IncentiveName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="400px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="No. of Claims">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNoClaims" runat="server" Text='<%#Eval("Noincentives") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                   
                                                    <asp:TemplateField HeaderText="Action">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnGenerate" CssClass="btn btn-primary" runat="server" Text="Process" Width="100px" OnClick="btnGenerate_Click" />
                                                            <asp:Label ID="lblSubIncentiveID" runat="server" Visible="false" Text='<%#Eval("SubIncentiveID") %>'></asp:Label>
                                                            <asp:Label ID="lblCategoryid" runat="server" Visible="false" Text='<%#Eval("Categoryid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            </div>
                                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
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

    <link href="../../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtProposedDLCDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtProposedDLCDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtProposedDLCDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });

    </script>

    <style type="text/css">
        font- 8pt; i o; d n 0 2 em x e8 {
            x;
        }

        11 {
            ;
            6;
        }

        .auto- e12 {
            height:;
        }

        {
            width: 175p .auo-stye1 wid h: 250;
        }
    </style>
    <style type="text/css">
        .ui-da font-size: 8pt !important; padding: 0.2em 0.2em 0; width: 250px; color: Black;
        }

        select {
            color: Black !important;
        }

        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
