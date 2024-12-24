<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmRentalSubsidy.aspx.cs" Inherits="TTAP.UI.Pages.frmRentalSubsidy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <asp:PostBackTrigger ControlID="btnRentagrement" />
            <asp:PostBackTrigger ControlID="btnBankCertificate" />
            <asp:PostBackTrigger ControlID="btnPowerCertificate" />
            <asp:PostBackTrigger ControlID="btnPaymentProof" />
            <asp:PostBackTrigger ControlID="btnRentedLayout" />
            <asp:PostBackTrigger ControlID="btnProofClaim" />
            <asp:PostBackTrigger ControlID="btnProductionSalesCA" />
            <asp:PostBackTrigger ControlID="btnRentalCertified" />
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Rental / Lease Subsidy for Built up Space</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – XIII: Rental / Lease Subsidy for Built up Space</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label2">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label3">Common Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <label class="control-label label-required" id="Label4">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label7">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Labelpolicy1" runat="server">Category of Unit as per T-TAP Policy</label>
                                            <label class="form-control" id="lblCategoryofUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label5" runat="server">Activity of the Unit</label>
                                            <label class="form-control" id="lblActivityoftheUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label17" runat="server">Purpose Of Use</label>
                                            <asp:DropDownList ID="ddlTypeOfUse" class="form-control" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="ddlTypeOfUse_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Production</asp:ListItem>
                                                <%-- <asp:ListItem Value="2">Training Purpose</asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="lblProductionPersonsTrained" runat="server">Production/Persons Trained</label>
                                            <asp:TextBox ID="txtProductionPersonsTrained" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label6" runat="server">Date Of Incorporation of Unit</label>
                                            <asp:TextBox ID="txtDateofEstablishmentofUnit" Enabled="false" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-8 form-group">
                                            <label class="control-label" id="Label9" runat="server">Whether the unit is located in the Textile /Apparel Park declared by the Government of Telangana</label>
                                            <asp:RadioButtonList ID="RbtnTextileOrApparelArea" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label23" runat="server">Whether the Rental / Lease deed is registered</label>
                                            <asp:RadioButtonList ID="RbtnRentalLeasedeed" CssClass="radio-inline" AutoPostBack="true" RepeatDirection="Horizontal" runat="server" OnSelectedIndexChanged="RbtnRentalLeasedeed_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-3 form-group" id="RentalLeasedeed1" runat="server" visible="false">
                                            <label class="control-label" id="Label22" runat="server">Deed Number</label>
                                            <asp:TextBox ID="txtDeedNumber" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group" id="RentalLeasedeed2" runat="server" visible="false">
                                            <label class="control-label" id="Label24" runat="server">Deed date</label>
                                            <asp:TextBox ID="txtDeedDate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label label-required" id="Label1">Rental Information</label>
                                            <asp:CheckBoxList ID="chkRentalInformationType" runat="server" CssClass="checkbox" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="chkRentalInformationType_SelectedIndexChanged">
                                                <asp:ListItem Text="Leased commercially" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Some other Leasing Arrangement ,if so specify" Value="2"></asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                        <div class="col-sm-4 form-group" id="divotherLeasingArrangement" runat="server" visible="false">
                                            <label class="control-label" id="Label8">Other Leasing Arrangement</label>
                                            <asp:TextBox ID="txtOtherLeasingArrangement" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblyear" runat="server">Built up space occupied by the Industry/Enterprise in the Textile /Apparel park ( in Sq Meters)</label>
                                            <asp:TextBox ID="txtBuiltUpSpaceOccupied" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblamountclaimed" runat="server">Rent/Lease Amount (per Sq Meter) (In Rupees)</label>
                                            <asp:TextBox ID="txtRentLeaseAmountPerSqMtr" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblCurrentClaim" runat="server">Total Monthly net rent (In Rupees)</label>
                                            <asp:TextBox ID="txtTotalMonthlyNetRent" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <asp:Label ID="lblDetailsofPatners" runat="server" CssClass="label-required text-blue" Font-Bold="True">Period of Lease (Regd. Lease Deed for Min. period of 10 years )</asp:Label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Labelwe2" runat="server">From</label>
                                            <asp:TextBox ID="txtPeriodofLeaseFromDate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Labelsd9" runat="server">To</label>
                                            <asp:TextBox ID="txtPeriodofLeaseToDate" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label11" runat="server">Any other subsidy from another source</label>
                                            <asp:RadioButtonList ID="RbtnIsAnyothersubsidy" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RbtnIsAnyothersubsidy_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-sm-4 form-group" id="divSubsidy" runat="server" visible="false">
                                            <label class="control-label" id="Label10" runat="server">Subsidy Source</label>
                                            <asp:TextBox ID="txtSubsidySource" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="divAmount" runat="server" visible="false">
                                            <label class="control-label" id="Label12" runat="server">Amount (In Rupees)</label>
                                            <asp:TextBox ID="txtSubsidySourceAmount" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Rental Subsidy reimbursement already availed by Enterprise from the Date of Commencement of Production</div>
                                        </div>
                                        <div class="row w-100 m-0" id="DivSGSTReimbursement" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label13" runat="server">Financial Year</label>
                                                <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label16" runat="server">1st/2nd half Year</label>
                                                <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label15" runat="server">Amount(In Rupees)</label>
                                                <asp:TextBox ID="txtAmountPaid" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnSGSTReimbursementAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnSGSTReimbursementAdd_Click" />
                                                <asp:Button ID="Button3" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="grdSGSTReimbursement" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="grdSGSTReimbursement_RowCommand">
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
                                                    <asp:TemplateField HeaderText="Amount (In Rupees)">
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
                                                            <asp:Label ID="lblEnergyconsumedID" runat="server" Text='<%# Bind("Rental_SubsidyAvailed_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label14" runat="server">Claim Application submitted by the Enterprise/Industry for the 1st Half Yare/2nd Half Year:</label>
                                            <asp:TextBox ID="txtClaimApplicationsubmitted" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Period of claim amount</div>
                                        </div>
                                        <div class="row w-100 m-0" id="DivSGSTReimbursementClaim" runat="server">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="ClaimLabel13" runat="server">Financial Year</label>
                                                <asp:DropDownList ID="ddlClaimFinYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="ClaimLabel16" runat="server">1st/2nd half Year</label>
                                                <asp:DropDownList ID="ddlClaimFin1stOr2ndHalfyear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="ClaimLabel15" runat="server">Amount(In Rupees)</label>
                                                <asp:TextBox ID="txtClaimAmountPaid" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnSGSTReimbursementClaimAdd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnSGSTReimbursementClaimAdd_Click" />
                                                <asp:Button ID="btnClaimclear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="grdSGSTReimbursementClaim" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="grdSGSTReimbursementClaim_RowCommand">
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
                                                    <asp:TemplateField HeaderText="Amount (In Rupees)">
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
                                                            <asp:Label ID="lblEnergyconsumedID" runat="server" Text='<%# Bind("Rental_SubsidyAvailed_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <%--<div class="col-sm-12">
                                            <asp:Label ID="Label19" runat="server" CssClass="label-required text-blue" Font-Bold="True">Period of claim amount</asp:Label>
                                        </div>
                                        <div class="col-sm-3 form-group" id="div1" runat="server">
                                            <label class="control-label" id="Label20" runat="server">From</label>
                                            <asp:TextBox ID="txtFromDateOfClaimAmount" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label21" runat="server">To</label>
                                            <asp:TextBox ID="txtToDateOfClaimAmount" class="form-control" runat="server"></asp:TextBox>
                                        </div>--%>
                                        <div class="col-sm-6 form-group">
                                            <label class="control-label" id="Label18" runat="server">Reimbursement Amount claimed by the Industry/Enterprise (In Rs)</label>
                                            <asp:TextBox ID="txtReimbursementAmountClaimed" Enabled="false" ReadOnly="true" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-12 mt-sm-3 text-left">
                                        <p>
                                            <strong>Note : </strong>1). Half year means every 6 months from the financial year beginning from 1st April to 31st March.
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2). Current Claim - 25% of the net rent value per the first five years of operation period
                                        </p>
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
                                                    <td align="left" style="width: 50%">Copy of the rent /lease agreement</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuRentagrement" runat="server" />
                                                        <asp:Button ID="btnRentagrement" runat="server" OnClick="btnRentagrement_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyRentagrement" runat="server" Target="_blank"></asp:HyperLink>
                                                        <asp:Label ID="lblRentagrement" runat="server" Font-Bold="true" ForeColor="Green" Visible="false" />
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Certificate from Bank/ Financial Institutions (FI) justifying deposit of monthly rent amount</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fluBankCertificate" runat="server" />
                                                        <asp:Button ID="btnBankCertificate" runat="server" OnClick="btnBankCertificate_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyBankCertificate" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Power release certificate issued by DISCOM concerned</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPowerCertificate" runat="server" />
                                                        <asp:Button ID="btnPowerCertificate" runat="server" OnClick="btnPowerCertificate_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyPowerCertificate" runat="server" Target="_blank"></asp:HyperLink></td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Power Bill and Payment Proof Receipts from DISCOM concerned.Valid conscent of operation(CFO) from TSPCB /Acknowledgement from General Manager,District Industries Centre concerned on pollution angle.(if any)</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuPaymentProof" runat="server" />
                                                        <asp:Button ID="btnPaymentProof" runat="server" OnClick="btnPaymentProof_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyPaymentProof" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">5</td>
                                                    <td align="left">Layout demarcating the rented/leased built up space occupied by the Unit/Entrprise/Industry</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuRentedLayout" runat="server" />
                                                        <asp:Button ID="btnRentedLayout" runat="server" OnClick="btnRentedLayout_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyRentedLayout" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">6</td>
                                                    <td align="left">Any other valid documents to substantiate proof of claim amount</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuProofClaim" runat="server" />
                                                        <asp:Button ID="btnProofClaim" runat="server" OnClick="btnProofClaim_Click" CssClass="btn btn-info btn-sm mx-2" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyProofClaim" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">7</td>
                                                    <td align="left">Current Rental Value per sq.mts to be Certified by Concerned Authority</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuRentalCertified" runat="server" />
                                                        <asp:Button ID="btnRentalCertified" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnRentalCertified_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyRentalCertified" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">8</td>
                                                    <td align="left">Production & Sales Details of Claim Period Certified by Concerned Chartered Accountant</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuProductionSalesCA" runat="server" />
                                                        <asp:Button ID="btnProductionSalesCA" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnProductionSalesCA_Click" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyProductionSalesCA" runat="server" Target="_blank"></asp:HyperLink>
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
                                        I / We hereby confirm that to the best of my / our knowledge and belief, information given herein before and other papers enclosed are true and correct in all respects. I / We further undertake to substantiate the particulars about promoter(s) and other details with documentary evidence as and when called for.<br />
                                        <br />
                                        I/We hereby agree that I/We shall forthwith repay the amount disbursed to me/us under the scheme, if the amount of Reimbursement is found to be disbursed in excess of the amount actually admissible whatsoever the reason.
                                    </div>
                                    <div class="col-sm-12 text-center mt-3">

                                        <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-blue m-2" OnClick="BtnPrevious_Click" TabIndex="10" Text="Previous" />
                                        <asp:Button ID="BtnNext" runat="server" CssClass="btn btn-success m-2" Enabled="true" OnClick="BtnNext_Click" TabIndex="10" Text="Save & Next" ValidationGroup="group" />
                                        <%-- &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-success" Height="32px" OnClick="BtnClear_Click" TabIndex="10" Enabled="false" Text="ClearAll" ToolTip="To Clear  the Screen" Width="90px" />--%>
                                    </div>
                                    <div class="col-sm-12">
                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
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
                <asp:HiddenField ID="hdnUserID" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtDateofEstablishmentofUnit']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtFromDateOfClaimAmount']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtToDateOfClaimAmount']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtPeriodofLeaseFromDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtPeriodofLeaseToDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtDeedDate']").keydown(function () {
            return false;
        });
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');
            $("input[id$='ContentPlaceHolder1_txtDeedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtDateofEstablishmentofUnit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtFromDateOfClaimAmount']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtToDateOfClaimAmount']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtPeriodofLeaseFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtPeriodofLeaseToDate']").datepicker(
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
            $("input[id$='ContentPlaceHolder1_txtDeedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtDateofEstablishmentofUnit']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtFromDateOfClaimAmount']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtToDateOfClaimAmount']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtPeriodofLeaseFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtPeriodofLeaseToDate']").datepicker(
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
