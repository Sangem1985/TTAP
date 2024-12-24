<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmRebateCharges.aspx.cs" Inherits="TTAP.UI.Pages.frmRebateCharges" %>

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
            <asp:PostBackTrigger ControlID="btnOperatorRate" />
            <asp:PostBackTrigger ControlID="btnEffulent" />
            <asp:PostBackTrigger ControlID="btnOtherRelevant" />
            <asp:PostBackTrigger ControlID="btnBills" />
            <asp:PostBackTrigger ControlID="btnUtilisation" />
            <asp:PostBackTrigger ControlID="btnCharteredEngineerCETPETP" />

        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Rebate in O&M Charges for CETP /ETP</li>
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
                                    <h5 class="text-blue mb-3 font-SemiBold">Form – XV : Rebate in O&M Charges for CETP /ETP (Environment Infrastructure)</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row">
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="LabeTSIPassl2" runat="server">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="LabeCAFl3" runat="server">Common Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-2 form-group">
                                            <label class="control-label label-required" id="LabeTypeofUnitl4" runat="server">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label label-required" id="Label7" runat="server">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-8 form-group">
                                            <label class="control-label" id="Label6" runat="server">Type of Effluent Treatment Plant (ETP)/Common Effluent Treatment Plant (CETP).</label>
                                            <asp:RadioButtonList ID="RbtnTypeofETP" CssClass="radio-inline" RepeatDirection="Horizontal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RbtnTypeofETP_SelectedIndexChanged">
                                                <asp:ListItem Text="Zero Liquid Discharge" Selected="True" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Others (please specify)" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-4 form-group" id="divETPOthers" runat="server" visible="false">
                                            <label class="control-label" id="Label8" runat="server">Others (please specify)</label>
                                            <asp:TextBox ID="txtOtherETP" class="form-control" runat="server"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label4" runat="server">Utilization of ETP/CETP</label>
                                            <asp:DropDownList ID="ddlUtilizationETPCETP" AutoPostBack="true" class="form-control" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="ddlUtilizationETPCETP_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                <asp:ListItem Value="1">Common</asp:ListItem>
                                                <asp:ListItem Value="2">Individual</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div3" runat="server">
                                            <label class="control-label" id="Label1" runat="server">Approved Project Cost (In Rs)-CETP/ETP</label>
                                            <asp:TextBox ID="txtApprovedProjectCost" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div5" runat="server">
                                            <label class="control-label" id="Label10" runat="server">Actual Cost Invested (In Rs)-CETP/ETP</label>
                                            <asp:TextBox ID="txtActualCostInvested" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Details of the CETP/ETP -O&M Operator/Agency/Firm</label>
                                            <asp:TextBox ID="txtCETPETPDetails" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="divcommon1" runat="server">
                                        <div class="col-sm-4 form-group" id="divEarlierYear" runat="server">
                                            <label class="control-label" id="lblyear" runat="server">Captive or Common ETP</label>
                                            <asp:TextBox ID="txtCaptiveCommonETP" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="divEarlieramount" runat="server">
                                            <label class="control-label" id="lblamountclaimed" runat="server">Cost of the ETP</label>
                                            <asp:TextBox ID="txtETPCost" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblCurrentClaim" runat="server">Rebate Claimed</label>
                                            <asp:TextBox ID="txtRebateClaimed" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row" id="divcommon2" runat="server">
                                        <div class="col-sm-4 form-group" id="div1" runat="server">
                                            <label class="control-label" id="lblYearoftheClaim" runat="server">Year of the Claim</label>
                                            <asp:TextBox ID="txtYearoftheClaim" MaxLength="4" onkeypress="return inputOnlyNumbers(event)" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group" id="div2" runat="server">
                                            <label class="control-label" id="Label2">Government (State, Central, Govt Agency, Financial Institution) Constructed or SPV (In Rupees)</label>
                                            <asp:TextBox ID="txtAnyGovtAgency" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label3">Years of Commercial Production</label>
                                            <asp:TextBox ID="txtYearsCommercialProduction" MaxLength="4" onkeypress="return inputOnlyNumbers(event)" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <div class="col-sm-12 text-blue label-required font-SemiBold">Details of Effluent Treatment Charges(O&M charges) during last 6 months(half year)</div>
                                        </div>
                                        <div class="row w-100 m-0" id="DivPowerutilizeLast3yrsdDetails" runat="server">
                                            <%--<div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label10" runat="server">Month & Year</label>
                                                <asp:TextBox ID="txtMonthYear" class="form-control" runat="server"></asp:TextBox>
                                            </div>--%>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="ClaimLabel13" runat="server">Financial Year</label>
                                                <asp:DropDownList ID="ddlFinYear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="ClaimLabel16" runat="server">1st/2nd half Year</label>
                                                <asp:DropDownList ID="ddlFin1stOr2ndHalfyear" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="1st half Year"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="2nd half Year"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label13" runat="server">O&M Components</label>
                                                <asp:DropDownList ID="ddlOMComponents" runat="server" class="form-control txtbox">
                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label11" runat="server">Effluent Treated (in KL)</label>
                                                <asp:TextBox ID="txtEffluentTreated" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label" id="Label12" runat="server">Effluent Treatment Charges (Rs)</label>
                                                <asp:TextBox ID="txtEffluentTreatmentCharges" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-12 text-center">
                                                <asp:Button ID="btnPowerutilizedadd" runat="server" CssClass="btn btn-blue mx-2"
                                                    TabIndex="5" Text="Add New" OnClick="btnPowerutilizedadd_Click" />
                                                <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="grdETPDetails" runat="server" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                AutoGenerateColumns="false" OnRowCommand="grdETPDetails_RowCommand">
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
                                                   <%-- <asp:TemplateField HeaderText="Month & Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMonthYear" runat="server" Text='<%#Eval("MonthYear") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
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
                                                    <asp:TemplateField HeaderText="O&M Components">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblOMComponents" runat="server" Text='<%#Eval("Component") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Effluent Treated (in KL)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffluentTreated" runat="server" Text='<%#Eval("EffluentTreated") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Amount Paid (In Rupees)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblEffluentTreatmentCharges" runat="server" Text='<%#Eval("EffluentTreatmentCharges") %>'></asp:Label>
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
                                                            <asp:Label ID="lblETPChargesID" runat="server" Text='<%# Bind("ETPCharges_ID") %>'></asp:Label>
                                                            <asp:Label ID="lblEnergyFinancialYearID" runat="server" Visible="false" Text='<%# Bind("FinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblTypeOfFinancialYear" runat="server" Visible="false" Text='<%# Bind("TypeOfFinancialYear") %>'></asp:Label>
                                                            <asp:Label ID="lblComponentId" runat="server" Visible="false" Text='<%# Bind("ComponentId") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row" id="divSubsidyAvailed" runat="server">
                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Details of Subsidy Sanctioned / Availed so far with sanction order no & date, if any from Govt. of India or any other Agency</h6>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Amount Availed</label>
                                            <asp:TextBox ID="txtAmountAvailed" onkeypress="DecimalOnly()" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Sanction Order No</label>
                                            <asp:TextBox ID="txtSanctionOrderNo" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Date Availed:</label>
                                            <asp:TextBox ID="txtDateAvailed" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group" id="div4" runat="server">
                                            <label class="control-label" id="Labelwe2" runat="server">Commencement of Commercial Operation of Industry/Enterprise</label>
                                            <asp:TextBox ID="txtCommencementCommercialOperation" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Labelsd9" runat="server">Date of Commencement of Utilization of CETP/ETP</label>
                                            <asp:TextBox ID="txtDateofCommencementUtilization" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="lblClaim" runat="server">Current Claim (In Rupees)</label>
                                            <asp:TextBox ID="txtCurrentClaim" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-12 mt-sm-3 text-left">
                                        <p>
                                            <strong>Note : </strong>1). Rebate Claimed (50% of the cost with CAP of Rs. 10.00 Cr.
                                            <br />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2). Rebate in the O&M Charges in the following scale: Year 1 and 2 – 75%, Year 3 and 4 – 50%, Year 5 – 25%.
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
                                                    <td align="left" style="width: 50%">Operator Rate chart duly certified/approved by relevant authorities</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuOperatorRate" runat="server" />
                                                        <asp:Button ID="btnOperatorRate" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnOperatorRate_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyOperatorRate" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">2</td>
                                                    <td align="left">Record of Inflow and outflow of effluent/treated discharge should be certified by TSPCB or any relevant authorit
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fluEffluent" runat="server" />
                                                        <asp:Button ID="btnEffulent" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnEffulent_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyEffulent" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>

                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">3</td>
                                                    <td align="left">Bills generated by CETP O&M operator duly specifying the quantum of effluent discharge and rate charges for treating effluent specific to the Industry/Enterprise unit (Rs/kL)
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuBills" runat="server" />
                                                        <asp:Button ID="btnBills" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnBills_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyBills" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item2">
                                                    <td align="center">4</td>
                                                    <td align="left">Date of Commencement of utilisation of CETP, if different from the date of commencement of commercial operation, is to be certified by TSPCB
                                                    </td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuUtilisation" runat="server" />
                                                        <asp:Button ID="btnUtilisation" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnUtilisation_Click" Text="Upload" /></td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyUtilisation" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">5</td>
                                                    <td align="left">Other relevant Utilization Certificates (if any)</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuOtherRelevant" runat="server" />
                                                        <asp:Button ID="btnOtherRelevant" runat="server" CssClass="btn btn-info btn-sm mx-2" OnClick="btnOtherRelevant_Click" Text="Upload" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyOtherRelevant" runat="server" Target="_blank"></asp:HyperLink>
                                                    </td>
                                                </tr>
                                                <tr class="GridviewScrollC1Item">
                                                    <td align="center">6</td>
                                                    <td align="left">Certification from Chartered Engineer for construction of value of CETP/ETP</td>
                                                    <td align="left">
                                                        <asp:FileUpload ID="fuCharteredEngineerCETPETP" runat="server" />
                                                        <asp:Button ID="btnCharteredEngineerCETPETP" runat="server" CssClass="btn btn-info btn-sm mx-2" Text="Upload" OnClick="btnCharteredEngineerCETPETP_Click" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:HyperLink ID="hyCharteredEngineerCETPETP" runat="server" Target="_blank"></asp:HyperLink>
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

        $("input[id$='ContentPlaceHolder1_txtCommencementCommercialOperation']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtDateofCommencementUtilization']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtMonthYear']").keydown(function () {
            return false;
        });
         $("input[id$='ContentPlaceHolder1_txtDateAvailed']").keydown(function () {
            return false;
        });
        
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');

            $("input[id$='ContentPlaceHolder1_txtCommencementCommercialOperation']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtDateofCommencementUtilization']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
            $("input[id$='ContentPlaceHolder1_txtMonthYear']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
            $("input[id$='ContentPlaceHolder1_txtDateAvailed']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtCommencementCommercialOperation']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtDateofCommencementUtilization']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
            $("input[id$='ContentPlaceHolder1_txtMonthYear']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                });
             $("input[id$='ContentPlaceHolder1_txtDateAvailed']").datepicker(
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

