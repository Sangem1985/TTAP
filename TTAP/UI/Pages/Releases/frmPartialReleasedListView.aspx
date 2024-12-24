<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmPartialReleasedListView.aspx.cs" Inherits="TTAP.UI.Pages.Releases.frmPartialReleasedListView" %>

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

        .masking {
            display: none;
            z-index: 999999;
            top: 0px;
            left: 0px;
            height: 100%;
            width: 100%;
            border-radius: 3px;
            position: fixed;
        }

        .cmask, .modalBackground {
            position: fixed;
            width: 100%;
            height: 100%;
            left: 0px;
            top: 0px;
            z-index: 9999;
        }

        .clientpopup {
            position: fixed;
            left: 50%;
            top: 50%;
            border-radius: 5px;
            background: #fff;
            -moz-box-shadow: 1px 0 7px #000;
            -webkit-box-shadow: 1px 0 7px #000;
            box-shadow: 1px 0 7px #000;
            z-index: 999999;
        }

        0% {
            transform: translateX(0px) translateY(-100px);
            transition: opacity 400ms, transform 400ms;
        }

        10% {
            transform: translateX(0px) translateY(0);
            transition: opacity 400ms, transform 400ms;
        }

        100% {
            transform: translateX(0px) translateY(0);
            transition: opacity 400ms, transform 400ms;
        }

        .pop-header {
            height: 36px px;
            clear: both;
            border-radius: 5px 5px 0 0;
        }

        .Button {
            color: #FFF;
            border: 0 !important;
            background: #d80101;
            border-radius: 3px;
            background-position: -5px -33px;
            border-radius: 3px;
        }

        .pop-header input {
            float: right;
            width: 29px;
            margin: -34px 4px 3px 3px;
        }
    </style>


    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnDLCProceedings" />
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
                                    <h5 class="text-blue mb-3 font-SemiBold">List of Partial Released Incentives</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div runat="server" visible="false" class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label3" runat="server">Incentive</label>
                                            <label class="form-control" id="lblIncentives" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2" runat="server">Type of Application</label>
                                            <label class="form-control" id="lblTypeofApplication" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label1" runat="server">Category</label>
                                            <label class="form-control" id="lblIncCategory" runat="server"></label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12 table-responsive">
                                            <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CssClass="table table-bordered mb-0 alternet-table w-100 NewEnterprise"
                                                PageSize="20" GridLines="Both">
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
                                                    <%--<asp:BoundField DataField="ApplicationNumber" onserverclick="App_ServerClick" ItemStyle-HorizontalAlign="Center" onclick="javascript:GetIncentives(<%# Eval("IncentiveID") %>);" HeaderText="Application Number">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>--%>
                                                    <asp:TemplateField HeaderText="Application Number" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <a href="#/" onclick="javascript:GetIncentives(<%# Eval("IncentiveID") %>,<%# Eval("SubIncentiveID") %>);"><%# Eval("ApplicationNumber") %></a>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="UnitName" HeaderText="Name of Unit">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Address" HeaderText="Address">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                     <asp:BoundField DataField="IncentiveName" HeaderText="Incentive Name">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Ids" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblAllotedAmount" Text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row pt-4" style="display:none;">
                                        <div class="col-sm-12 text-center">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-blue"
                                                TabIndex="10" Text="Print" OnClick="btnSubmit_Click" ValidationGroup="group" />
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
            <div class="masking" id="centreDetPopup" style="display: none;">
                <div class="cmask">
                </div>
                <div class="clientpopup" style="width: 966px; height: 465px; margin-left: -475px; margin-top: -233px;">
                    <div class="pop-header">
                        <h4 id="hdrApplicationNumber" style="margin: 7px 0px 2px 4px;"></h4>
                        <label id="lblUnitName" style="margin: 0px 0px 0px 5px; color: red;">
                        </label>
                        <label>----></label>
                        <label id="lblIncentiveName" style="color: forestgreen;"></label>
                        <br />
                        <label id="lblSanctionedAmount" style="margin: 0px 0px 0px 5px; color: red;"></label>
                        <input type="submit" value="×" style="margin: -58px 3px 0px 0px;"
                            onclick="return ClosingCentreDetails();" id="Button4" class="Button">
                    </div>
                    <div class="col-sm-12 table-responsive" runat="server" visible="false">
                        <asp:GridView ID="GvDetails" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                            CssClass="table table-bordered mb-0 alternet-table w-100 NewEnterprise"
                            PageSize="20" GridLines="Both">
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
                                <asp:BoundField DataField="ReleasedAmount" HeaderText="Released Amount">
                                    <ItemStyle CssClass="text-left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReleaseProcedingNo" HeaderText="Release Proceding No">
                                    <ItemStyle CssClass="text-left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Released_Date" ItemStyle-HorizontalAlign="Center" HeaderText="Released Date">
                                    <ItemStyle CssClass="text-left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="GONo" ItemStyle-HorizontalAlign="Center" HeaderText="GONo">
                                    <ItemStyle CssClass="text-left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Proceeding">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("ReleaseProcedingFilePath")%>' Target="_blank" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ids" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                        <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <table id="tbldata" class="table table-bordered" style="margin: 10px 0px 0px 4px; width: 99%;">
                        <thead class="bg-danger text-center text-white">
                            <tr>
                                <th align="left">S No</th>
                                <th align="left">Released Amount</th>
                                <th align="left">Release Proceding No</th>
                                <th align="left">Released Date</th>
                                <th align="left">GO Number</th>
                                <%--<th align="left">View</th>--%>
                            </tr>
                        </thead>
                        <tbody></tbody>
                    </table>
                </div>
            </div>
            <asp:HiddenField ID="hdnSubIncentiveId" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>

    <link href="../../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        function ClientSideClick(myButton) {
            // Client side validation
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false) { return false; }
            }

            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // diable the button
                myButton.disabled = true;
                myButton.className = "btn-inactive";
                myButton.value = "Processing...";
            }
            return true;
        }

        $("input[id$='ContentPlaceHolder1_txtReleaseProcedingDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtReleaseProcedingDate']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtReleaseProcedingDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });
        function ClosingCentreDetails() {
            $("#centreDetPopup").hide();
        }
        function FileOpen(Path) {
            window.open(Path);
        }
        function MyFunction(res) {
            $.ajax({
                type: "POST",
                url: "frmPartialReleasedListView.aspx/GetPath",
                data: '{TIPRID: ' + res + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OpenFile,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });

        }
        function OpenFile(response) {
            var PathD = $.parseJSON(response.d);
            var Path = PathD[0].ReleaseProcedingFilePath;
            window.open(Path);
        }
        function ViewClick(response) {

            var Data = $.parseJSON(response.d);
            $('#tbldata tbody').empty();
            $('#lblIncentiveName').text(Data[0].IncentiveName);
            $('#lblUnitName').text(Data[0].UnitName);
            $('#hdrApplicationNumber').text(Data[0].ApplicationNumber);
            $('#lblSanctionedAmount').text(Data[0].ApplicationNumber);
            var SanctionedAmount = "Sanctioned Amount - " + Data[0].SanctionedAmount;
            $('#lblSanctionedAmount').text(SanctionedAmount);
            if (Data.length > 0) {
                for (var i = 0; i < Data.length; i++) {
                    var Path = Data[i].ReleaseProcedingFilePath;
                    var ReleaseDate = new Date(Data[i].Released_Date).format('dd-MMM-yyyy');
                    /*<td><a href="#" onclick="return MyFunction(' + Data[i].TIPRID + ');" title="tooltip">text</a></td>*/
                    var _tr1 = '<tr id=' + i + '><td>' + (i + 1) + ' </td><td>' + Data[i].ReleasedAmount + ' </td><td> ' + Data[i].ReleaseProcedingNo + '</td><td> ' + Data[i].ReleaseProcedingDate + '</td><td> ' + Data[i].GONo + '</td></tr>';
                    $('#tbldata tbody').append(_tr1);
                }
            }

            $("#centreDetPopup").show();
            return false;
        }
        function GetIncentives(IId,SId) {
            //var IncentiveId=
            $.ajax({
                type: "POST",
                url: "frmPartialReleasedListView.aspx/GetIncentives",
                data: '{IncentiveId: ' + IId + ',SubIncentiveId:' + SId + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: ViewClick,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }

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
