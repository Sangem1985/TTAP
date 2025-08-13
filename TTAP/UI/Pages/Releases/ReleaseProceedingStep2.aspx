<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="ReleaseProceedingStep2.aspx.cs" Inherits="TTAP.UI.Pages.Releases.ReleaseProceedingStep2" %>

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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGovermentOrder" />
        </Triggers>
        <ContentTemplate>
            <div id="content">

                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="row">
                        <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold">LIST OF CASES SANCTIONED INCENTIVES</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <asp:CheckBox ID="chkIsSpecialUnit" Font-Size="Medium" Font-Bold="true" runat="server"
                                                Text="Is Special Release Units" AutoPostBack="true" OnCheckedChanged="chkIsSpecialUnit_CheckedChanged" />
                                        </div>
                                        <div class="col-sm-12 table-responsive" id="divSacnctionINC" runat="server" visible="true">
                                            <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"
                                                PageSize="20" GridLines="Both" OnRowDataBound="gvdetailsnew_RowDataBound" ShowFooter="true">
                                                <FooterStyle BackColor="#e1ceab" Font-Bold="True" />
                                                <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Name of Unit">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblNameofUnit" runat="server" Text='<%#Eval("NameofUnit") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Name of Unit">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Release Pending Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSanctionedAmount" runat="server" Text='<%#Eval("SanctionedAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Sanctioned Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSanctionedDate" Text='<%#Eval("SanctionedDate") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Allotted Amount">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtReleaseAmount" Text='<%#Eval("SanctionedAmount") %>' Style="margin: 5px auto;" class="form-control txtbox" Height="28px"
                                                                TabIndex="1" Width="150px" AutoPostBack="true" OnTextChanged="txtReleaseAmount_TextChanged"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="SLC Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSLCNumber" Text='<%#Eval("SLCNumer") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="SLC Number" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" Text='<%#Eval("EnterperIncentiveID") %>' runat="server"></asp:Label>
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server"></asp:Label>
                                                            <asp:Label ID="lblIsPartial" Text='<%#Eval("IsPartial") %>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                <EditRowStyle BackColor="#B9D684" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row" style="color: red; font-family: 'Montserrat-SemiBold';" id="divRemaining" runat="server" visible="true">
                                        <td>&nbsp;&nbsp;&nbsp; Remaining Amount : &nbsp;
                                           
                                            <asp:Label ID="lblRemainingAmount" runat="server"></asp:Label>
                                        </td>
                                    </div>
                                    <br />
                                    <div class="row" id="divReleaseProceeding" runat="server" visible="true">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Release Proceeding No</label>
                                            <asp:TextBox ID="txtReleaseProceedingNumber" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Release Proceeding Date</label>
                                            <asp:TextBox ID="txtReleaseProceedingDate" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label label-required">Release Proceeding Copy(Pdf Only)</label>
                                            <asp:FileUpload ID="fuGovermentOrder" runat="server" CssClass="file-browse" />
                                        </div>
                                        <div class="col-sm-3 form-group  text-left">
                                            <br />
                                            <asp:Button ID="btnGovermentOrder" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnGovermentOrder_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                
                                            <asp:HyperLink ID="hyGovermentOrder" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                        </div>
                                        <%--<div class="col-sm-12 mt-sm-3 text-left">
                                            <p><strong>Note : </strong>File Size should be 1MB only.</p>
                                        </div>--%>
                                        <div class="col-sm-12 text-center">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-blue mx-2"
                                                TabIndex="5" Text="Submit" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>

                                    <div class="row" id="divSpecialCase" runat="server" visible="false">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">District</label>
                                            <asp:DropDownList ID="ddlDistrict" runat="server" class="form-control">
                                                <asp:ListItem Value="0">-All Districts-</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">SLC Number	</label>
                                            <asp:DropDownList ID="ddlSLCNO" runat="server" class="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required">Unit Name	</label>
                                            <asp:TextBox ID="txtUnitName" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group  text-left">
                                            <br />
                                        </div>
                                        <%--<div class="col-sm-12 mt-sm-3 text-left">
                                            <p><strong>Note : </strong>File Size should be 1MB only.</p>
                                        </div>--%>
                                        <div class="col-sm-12 text-center">
                                            <asp:Button ID="btnSpecialCase" runat="server" CssClass="btn btn-blue mx-2"
                                                TabIndex="5" Text="Submit" />
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <tr id="tr1" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; text-align: left; height: 10px; font-weight: bold">Please Select Special Case Units
                                                </td>
                                            </tr>
                                        </div>
                                        <div class="col-sm-12 table-responsive" id="div1" runat="server" visible="true">
                                            <tr id="trsearchresult" runat="server" visible="false">
                                                <td style="padding: 5px; margin: 5px; width: 100%" valign="top">
                                                    <div id="Div2" style="width: 100%" runat="server">
                                                        <asp:GridView ID="gvData2" runat="server" AutoGenerateColumns="false" CellPadding="4"
                                                            CssClass="GRD" ForeColor="#333333" Height="62px" PageSize="15" ShowFooter="True"
                                                            Width="100%" CellSpacing="4" EmptyDataText="No Results Found">
                                                            <%-- <FooterStyle BackColor="#be8c2f" Font-Bold="True" ForeColor="White" />--%>
                                                            <RowStyle BackColor="#EBF2FE" CssClass="GRDITEM" HorizontalAlign="Left" VerticalAlign="Middle" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Select">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="chkSameUnit" Text="" AutoPostBack="true" OnCheckedChanged="chkSameUnit_CheckedChanged" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No.">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex + 1%>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="NameofUnit" HeaderText="Name of Unit" />
                                                                <asp:BoundField DataField="Address" HeaderText="Address" />
                                                                <asp:BoundField DataField="DCP" HeaderText="DCP" />
                                                                <asp:BoundField DataField="SanctionedAmount" HeaderText="Sanctioned Amount" />
                                                                <asp:BoundField DataField="SanctionedDate" HeaderText="Sanctioned Date" />
                                                                <%--<asp:BoundField DataField="AllotedAmount" HeaderText="Alloted Amount" />--%>
                                                                <asp:TemplateField HeaderText="Alloted Amount">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAllotedAmount" Text='<%#Eval("AllotedAmount") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Masterincentiveid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMstIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblIncentiveID" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="SLCNumer" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSLCNumer" Text='<%#Eval("SLCNumer") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="MobileNo" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitMObileNo" Text='<%#Eval("UnitMObileNo") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Applicationno" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApplicationno" Text='<%#Eval("Applicationno") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ApplicantName" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblApplicantName" Text='<%#Eval("ApplicantName") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="anchortaglinkAdd" runat="server" Text="ADD" Font-Bold="true" ForeColor="Green"
                                                                            Target="_blank" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <HeaderStyle BackColor="#1d9a5b" CssClass="GRDHEADER" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#B9D684" />
                                                            <AlternatingRowStyle BackColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                            </tr>
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

        $("input[id$='ContentPlaceHolder1_txtReleaseProceedingDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtReleaseProceedingDate']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtReleaseProceedingDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });
        function CalcTotalAllottedAmount() {
            var $dataRows = $("#ContentPlaceHolder1_gvdetailsnew tr:not('.totalColumn')");

            $dataRows.each(function () {
                debugger;
                $(this).find("[id*=txtReleaseAmount]").each(function (i) {
                    if ($(this).html() != '') {
                        totals[i] += parseInt(parseFloat($(this).html()) * 100, 10) / 100;
                    }
                });
            });
            $("#ContentPlaceHolder1_gvdetailsnew td.totalCol").each(function (i) {

                $(this).html(NumberToIndianRupees(totals[i].toFixed(2)));
            });
        }
        function NumberToIndianRupees(x) {
            x = x.toString();
            var afterPoint = '';
            if (x.indexOf('.') > 0)
                afterPoint = x.substring(x.indexOf('.'), x.length);
            x = Math.floor(x);
            x = x.toString();
            var lastThree = x.substring(x.length - 3);
            var otherNumbers = x.substring(0, x.length - 3);
            if (otherNumbers != '')
                lastThree = ',' + lastThree;
            var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree + afterPoint;
            return res;
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
