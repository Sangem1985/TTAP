<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmPlantandMachinery.aspx.cs" Inherits="TTAP.UI.Pages.frmPlantandMachinery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">--%>




    <script type="text/javascript" language="javascript">
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
         function inputOnlyDecimals(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 47) {
                return true;
            }
            return false;
        }
    </script>
    <%-- Date Picker Starts --%>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtMachineLoadingDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtVaivleDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtInitiationDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
        }
    </script>
    <%-- Date Picker End --%>
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPandMAdd" />
        </Triggers>
        <ContentTemplate>
            <div class="container">
                <div class="row mt-4">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item active"><a href="Home.aspx">Home</a></li>
                            <li class="breadcrumb-item">Plant and Machinery</li>
                        </ol>
                    </nav>
                </div>
                <div align="left">
                    <div class="row" align="left">
                        <div class="col-lg-12">
                            <div class="panel panel-primary">
                                <div class="panel-heading" align="center" style="background-color: cornflowerblue; margin: 2px; padding: 10px;">
                                    <h3 style="color: white">Plant and Machinery</h3>
                                </div>
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div class="panel-body">

                                            <div class="row">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Name of the Machine</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtMachineName" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Name of the Vendor</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtVendorName" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Type of the Machine</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:RadioButtonList ID="rdlMachineType" runat="server" RepeatDirection="Horizontal" CssClass="spaced123" AutoPostBack="true">
                                                        <asp:ListItem Text="Imported" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Local" Value="2" Selected="True"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Name of the Manufacturer</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtManufacturerName" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Invoice Number</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtInvoiceNo" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Machine Loading Date</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtMachineLoadingDate" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        vaivle Number</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtVaivleNo" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Vaivle Date</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtVaivleDate" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Initiation Date
                                                    </label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtInitiationDate" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Cost of the Machine</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:TextBox ID="txtCostofMachine" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label label-required">
                                                        Eligibility</label>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <asp:DropDownList ID="ddlEligibility" runat="server" class="form-control">
                                                        <asp:ListItem Text="--Select--" Value="0" Selected="False"></asp:ListItem>
                                                    </asp:DropDownList>

                                                </div>
                                                <div class="col-sm-6 form-group">
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-12 form-group" align="center">
                                                    <asp:Button Text="Add" CssClass="btn btn-blue px-4 title5" ID="btnPandMAdd" runat="server" OnClick="btnPandMAdd_Click" />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-12 form-group">
                                                    <asp:GridView runat="server" ID="grdPandM" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" HorizontalAlign="Center" Width="100%" HeaderStyle-Height="50px"
                                                        HeaderStyle-HorizontalAlign="center" RowStyle-HorizontalAlign="center" OnRowCommand="grdPandM_RowCommand" OnRowDataBound="grdPandM_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="6%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PMId" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPMId" Text='<%#Eval("PMId") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Machine Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMachineName" Text='<%#Eval("MachineName") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Vendor Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVendorName" Text='<%#Eval("VendorName") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Type of Machine">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTypeofMachine" Text='<%#Eval("TypeofMachine") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Manufacturer Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblManufacturerName" Text='<%#Eval("ManufacturerName") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Invoice Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInvoiceNo" Text='<%#Eval("InvoiceNo") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Machine Landing Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMahineLandingDate" Text='<%#Eval("MahineLandingDate") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Vaivle Number">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVaivleNo" Text='<%#Eval("VaivleNo") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Vaivle Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblVaivleDate" Text='<%#Eval("VaivleDate") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Initiation Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIntiationDate" Text='<%#Eval("IntiationDate") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Machine Cost">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMachineCost" Text='<%#Eval("MachineCost") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Eligibility">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblEligibility" Text='<%#Eval("Eligibility") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" class="btn btn-link btn-sm" OnClick="btnEdit_Click"></asp:Button>
                                                                    <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" runat="server" Text="Delete" class="btn btn-link btn-sm" OnClick="btnDelete_Click"></asp:Button>

                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                        <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                        <RowStyle BackColor="White" ForeColor="#003399" />
                                                    </asp:GridView>

                                                </div>
                                            </div>

                                            <table style="width: 900px; text-align: center">
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" visible="false" class="alert alert-success">

                                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                        </div>
                                                        <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                            <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                            <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
                <ProgressTemplate>
                    <div class="update">
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
