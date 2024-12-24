<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="PowerTariffSubsidy.aspx.cs" Inherits="TTAP.UI.Pages.PowerTariffSubsidy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>
    <%-- <link href="../../Models/bootstrap.css" rel="stylesheet" />--%>
    <script type="text/javascript">
        function ValidateRemove(x) {
            var result = confirm('Are you sure want to delete Record?');
            if (result) {
                return true;
            }
            else {
                return false;
            }
        }

    </script>
    <style>
        .radio, .checkbox {
            display: block;
            min-height: 20px;
            padding-left: 20px;
            margin-top: 10px;
            margin-bottom: 10px;
        }

            .radio input[type="radio"], .radio-inline input[type="radio"], .checkbox input[type="checkbox"], .checkbox-inline input[type="checkbox"] {
                float: left;
                margin-left: 20px;
            }

        input[type="radio"], input[type="checkbox"] {
            margin: 4px 0 0;
            line-height: normal;
        }

        input[type="checkbox"], input[type="radio"] {
            box-sizing: border-box;
            padding: 0;
        }
    </style>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPowerrelease" />
            <asp:PostBackTrigger ControlID="btnPowerBill" />
            <asp:PostBackTrigger ControlID="btnValidConsent" />
            <asp:PostBackTrigger ControlID="btnPowerutilization" />
            <asp:PostBackTrigger ControlID="btnrelevantelectricity" />
            <asp:PostBackTrigger ControlID="btnCopyofRent" />
            <asp:PostBackTrigger ControlID="btnCACertificate" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Power Tariff Subsidy</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – V: Reimbursement of Power Consumption Charges</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label1" runat="server">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2" runat="server">Common Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <label class="control-label label-required" id="Label3" runat="server">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label7" runat="server">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label4" runat="server">Category of Unit as per T-TAP Policy</label>
                                            <label class="form-control" id="lblCategoryofUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label5" runat="server">Nature of the Industry</label>
                                            <label class="form-control" id="lblActivityoftheUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label20" runat="server">Type Of Textile</label>
                                            <label class="form-control" id="lblTextileType" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Existing Power Connection in KVA (base)</label>
                                            <asp:TextBox ID="txtExistingPower" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label8" runat="server">New Power Connection in KVA</label>
                                            <asp:TextBox ID="txtNewPower" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Date of New Power Connection Released</label>
                                            <asp:TextBox ID="txtDateofNewpower" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label22" runat="server">Total No. of Power connections including Industry, colonies, Residential & street/parks etc</label>
                                            <asp:TextBox ID="txtTotalPowerconnections" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label23" runat="server">No. of Power connections exclusively for Industry use</label>
                                            <asp:TextBox ID="txtIndustryPowerconnections" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Power Utilized During Previous Three Financial Years Before this expansion/ diversification project</div>
                                        </div>
                                        <div class="row w-100 m-0" id="DivPowerutilizeLast3yrsdDetails" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label10" runat="server">Financial Year</label>
                                                <asp:DropDownList ID="ddlFinYearPower" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label11" runat="server">Total Untis Consumed</label>
                                                <asp:TextBox ID="txtTotalUnits" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label12" runat="server">Total Amount Paid(In Rupees)</label>
                                                <asp:TextBox ID="txtTotalAmount" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnPowerutilizedadd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnPowerutilizedadd_Click" />
                                                <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="grdPowerutilized" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="grdPowerutilized_RowCommand">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Financial Year ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFinancialYear" runat="server" Text='<%#Eval("FinancialYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Units Consumed">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalUnits" runat="server" Text='<%#Eval("TotalUnitsConsumed") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Amount Paid (In Rupees)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTotalAmount" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFinancialYearID" runat="server" Visible="false" Text='<%# Bind("FinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblPowerutilizedID" runat="server" Text='<%# Bind("Powerutilized_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Details of Energy consumed from the date of commencement of production and amount claimed for the Half year</div>
                                        </div>
                                        <div class="row w-100 m-0" id="DivEnergyconsumed" runat="server">
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label13" runat="server">Financial Year</label>
                                                <asp:DropDownList ID="ddlFinYearEnergy" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label16" runat="server">1st/2nd half Year</label>
                                                <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label26" runat="server">Purpose of Connection</label>
                                                <asp:TextBox ID="txtPurposeofConnection" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label21" runat="server">Service No/Unique ID</label>
                                                <asp:TextBox ID="txtServiceNo" class="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label14" runat="server">Number of Units Consumed</label>
                                                <asp:TextBox ID="txtNoofUnits" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label27" runat="server">From Reading Number</label>
                                                <asp:TextBox ID="txtReadingNumberFrom" class="form-control" onkeypress="return inputOnlyNumbers(event)" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label28" runat="server">To Reading Number</label>
                                                <asp:TextBox ID="txtReadingNumberTo" class="form-control" onkeypress="return inputOnlyNumbers(event)" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label24" runat="server">Rate of Unit (In Rupees)</label>
                                                <asp:TextBox ID="txtRateofUnit" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label25" runat="server">Other Charges (In Rupees)</label>
                                                <asp:TextBox ID="txtOtherCharges" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-3 form-group">
                                                <label class="control-label" id="Label15" runat="server">Amount Paid(In Rupees)</label>
                                                <asp:TextBox ID="txtAmountPaid" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnEnergyConsumedAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnEnergyConsumedAdd_Click" />
                                                <asp:Button ID="Button3" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="grdEnergyConsumed" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="grdEnergyConsumed_RowCommand">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Financial Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEnergyConsumedFinancialYear" runat="server" Text='<%#Eval("FinancialYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="1st/2nd half Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("TypeOfFinancialYearText") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="ServiceNo">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblServiceNo" runat="server" Text='<%#Eval("ServiceNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Purpose of Connection">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPurposeofConnection" runat="server" Text='<%#Eval("PurposeofConnection") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Number of Units Consumed">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEnergyConsumedNoofUnits" runat="server" Text='<%#Eval("TotalUnitsConsumed") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Reading Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFromReadingNumber" runat="server" Text='<%#Eval("FromReadingNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Reading Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblToReadingNumber" runat="server" Text='<%#Eval("ToReadingNumber") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate of Unit (In Rupees)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRateofUnit" runat="server" Text='<%#Eval("RateofUnit") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Other Charges (In Rupees)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOtherCharges" runat="server" Text='<%#Eval("OtherCharges") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount Paid (In Rupees)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEnergyConsumedAmountPaid" runat="server" Text='<%#Eval("TotalAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnDelete" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEnergyFinancialYearID" runat="server" Visible="false" Text='<%# Bind("FinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblTypeOfFinancialYear" runat="server" Visible="false" Text='<%# Bind("TypeOfFinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblEnergyconsumedID" runat="server" Text='<%# Bind("EnergyConsumed_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Current Claim Period</h5>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label17" runat="server">From Date</label>
                                            <asp:TextBox ID="txtCurrentClaimPeriodfrom" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label19" runat="server">To Date</label>
                                            <asp:TextBox ID="txtCurrentClaimPeriodto" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label18" runat="server">Current Claim Amount (In Rs)</label>
                                            <asp:TextBox ID="txtCurrentClaimAmount" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12 text-blue font-SemiBold mb-1">Enclosures</div>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                <tr align="center">
                                                    <th>Sl.No </th>
                                                    <th>Document Name </th>
                                                    <th>Upload Document </th>
                                                    <th>File Name </th>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center" style="width: 5%">1</td>
                                                    <td align="left" style="width: 50%">Power release certificate issued by DISCOM concerned for the first time of the claim </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPowerrelease" runat="server" />

                                                        <asp:Button ID="btnPowerrelease" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnPowerrelease_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyPowerrelease" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Power Bill and Payment Proof</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPowerBill" runat="server" />

                                                        <asp:Button ID="btnPowerBill" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnPowerBill_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyPowerBill" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink></td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Valid Consent for Operation (CFO) from TSPCB/Acknowledgement from General Manager, District Industries  Centre concerned on pollution angle
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuValidConsent" runat="server" />

                                                        <asp:Button ID="btnValidConsent" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnValidConsent_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyValidConsent" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink></td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Power utilization Particulars for the last –3 years and Column No. 4 & 5 of the application duly certified by Chartered Accountant for the first time of the claim if it is Expansion/Diversification Project</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPowerutilization" runat="server" />

                                                        <asp:Button ID="btnPowerutilization" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnPowerutilization_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyPowerutilization" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">5</td>
                                                    <td align="left">Copies of all relevant electricity bills'(to be submitted as and when received                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="furelevantelectricity" runat="server" />

                                                        <asp:Button ID="btnrelevantelectricity" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnrelevantelectricity_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyrelevantelectricity" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink></td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">6</td>
                                                    <td align="left">Copy of Rent / Lease Deed as the case may be</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCopyofRent" runat="server" />

                                                        <asp:Button ID="btnCopyofRent" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnCopyofRent_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyCopyofRent" runat="server" CssClass="LBLBLACK" Width="165px"
                                                            Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">7</td>
                                                    <td align="left">CA Certificate with details of products produced</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCACertificate" runat="server" />

                                                        <asp:Button ID="btnCACertificate" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnCACertificate_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="HyCACertificate" runat="server" CssClass="LBLBLACK" Width="165px" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 py-4">
                                        <b>Note : </b>1). If any further information/documents required by the department, the same shall be furnished by the entrepreneur.
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        2). If any errors found in the data, the same will have to be rectified by the entrepreneurs, then only the provisional incentive will be finalized.
                                    </div>
                                    <div class="col-sm-12">
                                        <b>DECLARATION : </b>
                                        <br />
                                        I / We hereby confirm that to the best of my / our knowledge and belief, information given herein before and other papers enclosed are true and correct in all respects. I / We further undertake to substantiate the particulars about promoter(s) and other details with documentary evidence as and when called for.
                                <br />
                                        <br />
                                        I/We hereby agree that I/We shall forthwith repay the amount disbursed to me/us under the scheme, if the amount of Reimbursement is found to be disbursed in excess of the amount actually admissible whatsoever the reason.
                                    </div>
                                    <div class="col-sm-12 text-center mt-3">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-success" TabIndex="10" Visible="false" Text="Submit" ValidationGroup="group" />
                                        <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-blue m-2" OnClick="BtnPrevious_Click" TabIndex="10" Text="Previous" />
                                        <asp:Button ID="BtnNext" runat="server" CssClass="btn btn-success m-2" Enabled="true" OnClick="BtnNext_Click" TabIndex="10" Text="Save & Next" ValidationGroup="group" />
                                        <%-- &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Enabled="false" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />--%>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12 form-group">
                                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong></strong>
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
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtDateofNewpower']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtCurrentClaimPeriodfrom']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtCurrentClaimPeriodto']").keydown(function () {
            return false;
        });


        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');

            $("input[id$='ContentPlaceHolder1_txtDateofNewpower']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtCurrentClaimPeriodfrom']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
            $("input[id$='ContentPlaceHolder1_txtCurrentClaimPeriodto']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtDateofNewpower']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });

            $("input[id$='ContentPlaceHolder1_txtCurrentClaimPeriodfrom']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
            $("input[id$='ContentPlaceHolder1_txtCurrentClaimPeriodto']").datepicker(
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
