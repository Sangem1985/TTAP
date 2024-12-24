<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmDLOApplicationDetailsNew.aspx.cs" Inherits="TTAP.UI.frmDLOApplicationDetailsNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="http://code.jquery.com/Jquery.min.js" charset="utf-8"></script>

    <script src="../../Js/validations.js" type="text/javascript"></script>

    <%-- <script type="text/javascript" src="https://code.jquery.com/jquery-latest.js" charset="utf-8"></script>
    <link href="../dist/css/theme.default.min.css" rel="stylesheet">
    <script src="../dist/js/jquery.tablesorter.min.js"></script>
    <script>  
        $(document).ready(function () {
            $("#grdPandM").tablesorter();
        });
    </script>--%>

    <style type="text/css" media="print">
        @page {
            size: landscape;
        }
    </style>
    <script type="text/javascript">

        $('.date').keydown(function () {
            //code to not allow any changes to be made to input field 
            return false;
        });
        function pageLoad() {
            att
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateofInspection']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtReInspectionDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('.date').datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                    //yearRange: "1930:2017",
                    // changeYear: true
                    // maxDate: new Date(currentYear, currentMonth, currentDate) txtinspectiondate
                });
        });
    </script>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(getme);
        function getme() {
            $('.date').datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                    //yearRange: "1930:2017",
                    // changeYear: true
                    // maxDate: new Date(currentYear, currentMonth, currentDate) txtinspectiondate
                });
        }
    </script>
    <script type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
                return true;
            }
            return false;
        }


    </script>
    <%-- <script>  
        $(document).ready(function () {
            $("#grdPandM").tablesorter();
        });
    </script>--%>

    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 112px;
            background-color: Gray;
            filter: alpha(opacity=60);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../Images/ajax-loaderblack.gif"); /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat; /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
        }
    </script>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnProcessApplication" />
            <asp:PostBackTrigger ControlID="BtnadminProcess" />
            <asp:PostBackTrigger ControlID="btnJDHeadOffice" />
            <asp:PostBackTrigger ControlID="A2" />
            <%--<asp:PostBackTrigger ControlID="btnShowPM" />--%>
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Preview</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Preview</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Div43" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <%--<h6 class="text-blue mt-1 mb-3 font-SemiBold">Application</h6>--%>

                        <h6 class="text-success mb-2 font-SemiBold" id="mainheading" runat="server"></h6>

                        <div class="widget-content">
                            <div class="col-sm-12 text-right pr-5">
                                <asp:LinkButton ID="lbtnback" CssClass="text-right" runat="server">Back</asp:LinkButton>
                            </div>
                            <div id="accordion">
                                <div class="card">
                                    <div class="card-header p-0">
                                        <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse2">Common Application Form
                                           
                                            <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                        </a>
                                    </div>
                                    <div id="collapse2" class="collapse">
                                        <div class="card-body">
                                            <div class="row" id="Receipt" runat="server">
                                                <iframe id="iframeapplication1" runat="server"></iframe>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" id="divMainOldApplications" runat="server" visible="false">
                                    <div class="card-header p-0" id="AccordianOldApplications">
                                        <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#DivAccordianOldApplications">Previous Applications
			                               
                                            <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                        </a>
                                    </div>
                                    <div id="DivAccordianOldApplications" class="collapse">
                                        <div class="card-body">
                                            <asp:GridView ID="GvOldApplications" runat="server" AutoGenerateColumns="False"
                                                CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                                    <asp:BoundField DataField="Uid_NO" HeaderText="TsIpass UID No" />
                                                    <asp:BoundField DataField="ApplicationNumber" HeaderText="ApplicationNO" />
                                                    <asp:BoundField DataField="ApplicationFiledDate" HeaderText="Application Date" />
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="anchortaglinkOldapplication" runat="server" Text="View" NavigateUrl='<%#Eval("ApplicationUrl") %>' Font-Bold="true" ForeColor="Green" Target="_blank" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" id="divplantandmachinaryview" runat="server">
                                    <div class="card-header p-0" id="headerplantandmachinaryview">
                                        <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#plantandmachinaryviewcollapse">Plant & Machinary Details
			                               
                                            <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                        </a>
                                    </div>
                                    <div id="plantandmachinaryviewcollapse" class="collapse">
                                        <div class="card-body">
                                            <div class="row">
                                                <a id="A2" href="#" onserverclick="BtnExportExcel_Click" runat="server">
                                                    <img src="../images/Excel-icon.png" width="20px;" height="20px;" style="float: right;"
                                                        alt="Excel" /></a>
                                                <asp:Button ID="btnShowPM" runat="server" class="btn btn-blue btn" Text="Show Grid" OnClick="btnShowPM_Click" />
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" style="height: 300px !important" id="divPMprint" runat="server">
                                                <asp:GridView runat="server" ID="grdPandM" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise tablesorter" OnRowDataBound="grdPandM_RowDataBound">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No" ItemStyle-Width="6%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="P&M Id">
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
                                                        <asp:TemplateField HeaderText="Entire/Parts of Machine">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMachinaryParts" Text='<%#Eval("MachinaryPartstext") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Custom Country">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCustomCountry" Text='<%#Eval("CustomCountry") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Custom Paid (Rs.)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCustomPaid" Text='<%#Eval("CustomPaid") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Import Duty (Rs.)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblImportduty" Text='<%#Eval("Importduty") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Port Charges (Rs.)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPortcharges" Text='<%#Eval("Portcharges") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Statutory Taxes (Rs.)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbStatutorytaxes" Text='<%#Eval("Statutorytaxes") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Installed Machinery">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInstalledMachineryText" Text='<%#Eval("InstalledMachineryText") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Installed Machinery Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInstalledMachinerytypeText" Text='<%#Eval("InstalledMachinerytypetext") %>' runat="server" />
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
                                                        <asp:TemplateField HeaderText="Invoice Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInvoiceDate" Text='<%#Eval("InvoiceDate") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Shipping Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIntiationDate" Text='<%#Eval("IntiationDate") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Machine Landing Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMahineLandingDate" Text='<%#Eval("MahineLandingDate") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Way Bill Number">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVaivleNo" Text='<%#Eval("VaivleNo") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Way Bill Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblVaivleDate" Text='<%#Eval("VaivleDate") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Actual Machine Cost (In Rs)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblActualMachineCost" Text='<%#Eval("ActualMachineCost") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Freight Charges (In Rs)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFreightCharges" Text='<%#Eval("FreightCharges") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Transport Charges (In Rs)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTransportCharges" Text='<%#Eval("TransportCharges") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CGST Amount(In Rs)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCgst" Text='<%#Eval("Cgst") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SGST Amount(In Rs)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSgst" Text='<%#Eval("Sgst") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="IGST Amount(In Rs)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIgst" Text='<%#Eval("Igst") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Total Machine Cost(Including GST,Freight Charges,Transport Charges) (In Rs)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMachineCost" Text='<%#Eval("MachineCost") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Machine Cost (In Foreign Currency)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblForeignMachineCost" Text='<%#Eval("ForeignMachineCost") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Foreign Currency">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblForeignCurrencyid" Text='<%#Eval("ForeignCurrency") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Eligibility Category">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblEligibility" Text='<%#Eval("Eligibility") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Classification of Machinery">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblClassificationofMachinery" Text='<%#Eval("ClassificationMachineryText") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Phase">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPhase" Text='<%#Eval("Phase") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Invoice">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hyFilePathMerge2" Text="view" NavigateUrl='<%#Eval("FilePathMerge2")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="row mt-4">
                                                <div class="col-sm-6 form-group">
                                                    <div class="row">
                                                        <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                            <label class="control-label label" id="Label10" runat="server">Actual Total Value of New Machinery (In Rs.):</label>
                                                        </div>
                                                        <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                            <label class="form-control" runat="server" id="lblTotalValueofNewMachinery"></label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-sm-6 form-group">
                                                    <div class="row">
                                                        <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12">
                                                            <label class="control-label label" id="Label4" runat="server">Actual Total value of 2nd hand machinery (In Rs.):</label>
                                                        </div>
                                                        <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                            <label class="form-control" runat="server" id="lblSecondhandmachinery"></label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" runat="server" id="divPMRatio" visible="false">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label" id="Label25" runat="server">Total Value of Textile Products (in Rs)</label>
                                                    <label class="form-control" id="lblTotalValueofTextileProducts" runat="server"></label>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label" id="Label27" runat="server">Total value of Non Textile products (in Rs)</label>
                                                    <label class="form-control" id="lblTotalValueofNonTextileProducts" runat="server"></label>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label" id="Label29" runat="server">Total value of machinery (in Rs)</label>
                                                    <label class="form-control" id="lblTotalValueofAllTextileProducts" runat="server"></label>
                                                </div>

                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label" id="Label26" runat="server">Textile Products (%)</label>
                                                    <label class="form-control" id="lblValueofTextileProductsPercentage" runat="server"></label>
                                                </div>
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label" id="Label30" runat="server">Non Textile products (%)</label>
                                                    <label class="form-control" id="lblValueofNonTextileProductsPercentage" runat="server"></label>
                                                </div>
                                            </div>
                                            <div class="col-sm-12 text-black font-SemiBold mb-1" id="DivPhaseDetails" visible="false" runat="server">Phase wise Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" runat="server">
                                                <asp:GridView runat="server" ID="gvPhaseView" AutoGenerateColumns="False" Width="100%" CellPadding="4" ShowFooter="true"
                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise tablesorter" OnRowDataBound="gvPhaseView_RowDataBound">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <%--<asp:TemplateField HeaderText="S.No" ItemStyle-Width="6%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Phase">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPMId" Text='<%#Eval("Phase") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No of Textile Machines">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPMId" Text='<%#Eval("TextileMachines") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Textile Machines Value">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPMId" Text='<%#Eval("TextileMachinesValue") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No of Non Textile Machines">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPMId" Text='<%#Eval("NontextileMachines") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Non Textile Machines Value">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPMId" Text='<%#Eval("NontextileMachinesValue") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total Machines Value">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPMId" Text='<%#Eval("TotalMachinaryValue") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card" id="div1" runat="server">
                                <div class="card-header p-0" id="headerAnnexures">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#DivAnnexurecollapse">Applied Incentives - Annexures
			                               
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="DivAnnexurecollapse" class="collapse">
                                    <div class="card-body">
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divviewpaymentDtls" runat="server" visible="false">
                                            <asp:HyperLink ID="HypPayment" Target="_blank" runat="server">Click Here to View Payment Details</asp:HyperLink>
                                        </div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="GvAnnexures" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Incentives">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("IncentiveName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Claim Period">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("ClaimPeriod")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="Print" NavigateUrl='<%#Eval("AnnexureURL")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card" id="div4" runat="server">
                                <div class="card-header p-0" id="headerTsipassApprovals">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#DivTsipassApprovals">TS-IPASS CFE Approvals
			                               
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="DivTsipassApprovals" class="collapse">
                                    <div class="card-body">
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvtsipassapprovals" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvtsipassapprovals_RowDataBound"
                                                EnableModelValidation="True" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S.No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Name of Approval">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hplkapprovalsname" Text='<%#Eval("Name of the approval")%>' NavigateUrl='<%#Eval("Approvalnfo")%>'
                                                                Target="_blank" runat="server" />
                                                            <asp:Label ID="lblapprovalname" Text='<%#Eval("Name of the approval")%>' runat="server"
                                                                Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:BoundField DataField="Name of the approval" HeaderText="Name of Approval" />--%>
                                                    <asp:BoundField DataField="Approval Application Date" HeaderText="Approval Applied Date" />
                                                    <asp:BoundField DataField="Actual Date of Approval Rejection" HeaderText="Date of Approval" />
                                                    <asp:TemplateField HeaderText="Approval Letter">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="View"
                                                                NavigateUrl='<%#Eval("ApprovalDoc")%>' Target="_blank" runat="server" />
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Status of Approval Approved Rejected")%>'
                                                                runat="server" Visible="false"></asp:Label>
                                                            <asp:Label ID="lblText" Text='<%#Eval("ApprovalDoc")%>'
                                                                runat="server" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approval Letter </br>(Alternate Link)">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidyAlterNate" runat="server" Text="View" NavigateUrl='<%# string.Format("~/UI/Pages/FileApi.aspx?filepath={0}&cfeid={1}&module={2}",
                                                             HttpUtility.UrlEncode(Eval("ApprovalDoc").ToString()), HttpUtility.UrlEncode(Eval("INTCFEENTERPID").ToString()), "CFE") %>'
                                                                Target="_blank"></asp:HyperLink>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfilepath" Text='<%#Eval("ApprovalDoc") %>' runat="server" />
                                                            <asp:Label ID="lblcfeid" Text='<%#Eval("INTCFEENTERPID") %>' runat="server" />
                                                            <asp:Label ID="lblmodule" Text="CFE" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card" id="divlastattachemntold" runat="server">
                                <div class="card-header p-0" id="headingTwo">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse5">Attachments
			                               
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapse5" class="collapse">
                                    <div class="card-body">
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="gvSubsidy_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divNotUploaded" runat="server" visible="false">
                                            <span class="font-SemiBold text-blue">Not Uploaded Documents</span>
                                            <asp:GridView ID="gvnotuploaded" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>


                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divQueryUploads" runat="server" visible="false">
                                            <span class="font-SemiBold text-blue">Query Uploads</span>
                                            <asp:GridView ID="gvQueryUploads" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="QueryUploads_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyQueryUploads" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divUploadedInspection" runat="server" visible="false">
                                            <span class="font-SemiBold text-blue">Uploaded Inspection Report(s)</span>
                                            <asp:GridView ID="GVInspectionReport" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="GVInspectionReport_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divUploadedRevisedInspections" runat="server" visible="false">
                                            <span class="font-SemiBold text-blue">Uploaded Revised Inspection Report(s)</span>
                                            <asp:GridView ID="GVReInspectionReport" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="GVReInspectionReport_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divRevisedInspectionMemo" runat="server" visible="false">
                                            <span class="font-SemiBold text-blue">Uploaded Revised Inspection Report Memo(s)</span>
                                            <asp:GridView ID="GVRevisedInspectionMemo" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="GVRevisedInspectionMemo_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divJointInspectionReport" runat="server" visible="false">
                                            <span class="font-SemiBold text-blue">Joint Inspection Report</span>
                                            <asp:GridView ID="gvJointInspectionReport" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="gvJointInspectionReport_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>

                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" id="divInspectionImages" runat="server" visible="false">
                                            <span class="font-SemiBold text-blue">Inspection Photos</span>
                                            <asp:GridView ID="GVInspectionImages" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" OnRowDataBound="GVReInspectionReport_RowDataBound">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verifieddate")%>' runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card" id="divcommhistory" runat="server" visible="false">
                                <div class="card-header p-0" id="commheadingQueryHistory">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#commhistorycollapse3">
                                        <span id="Span2" runat="server">Applcation Status History (Commissioner H&T)</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>

                                <div id="commhistorycollapse3" class="collapse">
                                    <div class="card-body">
                                        <div class="row" id="Divcommcompleted" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Sent to DLO</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvcommcompletedverification" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="UnitName" HeaderText="Unit Name" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Scrutiny Completed Date" />
                                                        <%--<asp:BoundField DataField="ReportUpdateDate" HeaderText="Inspection Report Uploaded Date" />
                                                            <asp:BoundField DataField="SystemRecommended" HeaderText="System Recommended Amount" />
                                                            <asp:BoundField DataField="OfficerRecommendedAmount" HeaderText="Officer Recommended Amount" />--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivcommQueryYetRespond" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details - Yet to Respond by Applicant</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="GvcommQueryYetRespondDetails" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Query" HeaderText="Query" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Query Letter">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hyQueryLetter" Text="View" NavigateUrl='<%#Eval("QueryLetterPath")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivcommQueryRespond" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details - Responded by Applicant</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="GvCommQueryRespondDetails" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Query" HeaderText="Query" />
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Query Letter">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hyQueryLetter" Text="View" NavigateUrl='<%#Eval("QueryLetterPath")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                        <asp:BoundField DataField="Responce" HeaderText="Query Responce" />
                                                        <asp:BoundField DataField="ResponseDate" HeaderText="Date Of Response" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="row" id="DivcommRejected" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Rejected Applications</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvCommRejected" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RejectionRemarks" HeaderText="Rejection Remarks" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Rejected By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Date of Rejection" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card" id="divcomm" runat="server" visible="false">
                                <div class="card-header p-0" id="divcommheading">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapsedivcomm">
                                        <span id="Span1" runat="server">Verification of Applcation (Admin)</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapsedivcomm" class="collapse show">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-sm-6 form-group">
                                                <label class="control-label label-required" id="Label5" runat="server">Status</label>
                                                <asp:RadioButtonList ID="RbtnCommstatus" runat="server" AutoPostBack="True" class="custom-radio" OnSelectedIndexChanged="RbtnCommstatus_SelectedIndexChanged">
                                                    <asp:ListItem Text="Send to DLO" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Raise Query" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Reject" Value="3"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-8 form-group" id="divadminquery" runat="server" visible="false">
                                                <label class="control-label label-required" id="lblcommQuery" runat="server">Query</label>
                                                <asp:TextBox ID="txtcommquery" runat="server" Style="height: 170px;" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row" id="divQueryLetterComm" runat="server" visible="false">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label8" runat="server">Any Query Letter</label>
                                                <asp:FileUpload ID="fuQueryLetterComm" runat="server" CssClass="file-browse" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 text-center">
                                                <asp:Button Text="Submit" CssClass="btn btn-blue mx-2" ID="BtnadminProcess" runat="server" OnClick="BtnadminProcess_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card" id="divQueries" runat="server" visible="false">
                                <div class="card-header p-0" id="headingQueryHistory">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse3">
                                        <span id="SpanApplcationStatusHistory" runat="server">Applcation Status History (DLO)</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapse3" class="collapse">
                                    <div class="card-body">
                                        <div class="row" id="DivInspectionDetails" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Inspection Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvInspectionStatus" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px" OnRowDataBound="gvInspectionStatus_RowDataBound">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="SchduledDate" HeaderText="Inspection Scheduled Date" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Scheduled By" />
                                                        <asp:BoundField DataField="InspectionDoneOn" HeaderText="Inspection Completed Date" />
                                                        <asp:BoundField DataField="ReportUpdateDate" HeaderText="Inspection Report Uploaded Date" />
                                                        <asp:BoundField DataField="SystemRecommended" HeaderText="System Recommended Amount" />
                                                        <%-- <asp:BoundField DataField="OfficerRecommendedAmount" HeaderText="Officer Recommended Amount" />--%>
                                                        <asp:BoundField DataField="Status" HeaderText="Status of Inspection" />
                                                        <asp:TemplateField HeaderText="Inspection Report">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkView" runat="server" Text="View" Font-Bold="true" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-- <asp:TemplateField HeaderText="Download Draft Inspection Report">
                                                                <ItemTemplate>
                                                                   <asp:HyperLink ID="anchDownloadDraftInspectionReport" runat="server" Text="Download" Font-Bold="true" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInspflag" Text='<%#Eval("Inspflag") %>' runat="server" />
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivReInspectionDetails" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Revised Inspection Report Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvReInspectionStatus" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px" OnRowDataBound="gvReInspectionStatus_RowDataBound">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="SchduledDate" HeaderText="Raised Date" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Raised By" />
                                                        <asp:BoundField DataField="ReportUpdateDate" HeaderText="Revised Inspection Report Uploaded Date" />
                                                        <asp:BoundField DataField="ReportUpdatedBy" HeaderText="Revised Inspection Report Uploaded By" />
                                                        <asp:BoundField DataField="SystemRecommended" HeaderText="System Recommended Amount" />
                                                        <%-- <asp:BoundField DataField="OfficerRecommendedAmount" HeaderText="Officer Recommended Amount" />--%>
                                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                                        <asp:TemplateField HeaderText="Revised Inspection Report">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkViewRep" runat="server" Text="View" Font-Bold="true" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-- <asp:TemplateField HeaderText="Download Draft Inspection Report">
                                                                <ItemTemplate>
                                                                   <asp:HyperLink ID="anchDownloadDraftInspectionReport" runat="server" Text="Download" Font-Bold="true" Target="_blank" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblInspflag" Text='<%#Eval("Inspflag") %>' runat="server" />
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivQueryDetails" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details - Yet to Respond by Applicant</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="grdQueries" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px" OnRowDataBound="grdQueries_RowDataBound">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="Query" HeaderText="Query" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                                <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Query Letter">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hyQueryLetter" Text="View" NavigateUrl='<%#Eval("QueryLetterPath")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Reminder Details">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hyQueryReminders" Text="Go to Reminders" Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivQueryResponse" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details - Responded by Applicant</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="grdQueriesResponse" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="Query" HeaderText="Query" />
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Query Letter">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hyrespQueryLetter" Text="View" NavigateUrl='<%#Eval("QueryLetterPath")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                        <asp:BoundField DataField="Responce" HeaderText="Query Responce" />
                                                        <asp:BoundField DataField="ResponseDate" HeaderText="Date Of Response" />
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Query Attachments Uploaded by User">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="hyrespAttachmentsPath" Text="View" NavigateUrl='<%#Eval("AttachmentsPath")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="row" id="DivRejectedApplications" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Rejected Applications</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvRejectedApplications" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RejectionRemarks" HeaderText="Rejection Remarks" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Rejected By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Date of Rejection" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card" id="divGMVerification" runat="server" visible="false">
                                <div class="card-header p-0" id="headerGM1">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#DivCollapseYettoAssign">Verification of Application(GM)
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="DivCollapseYettoAssign" class="collapse show">
                                    <div class="card-body">
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="GvYetAssign" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentive">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:RadioButtonList ID="rdbyesno" CssClass="form-check form-check-inline" RepeatLayout="Flow" RepeatDirection="Horizontal" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbyesno_SelectedIndexChanged">
                                                                <asp:ListItem class="form-check-input" Text="Yes" Value="Y"></asp:ListItem>
                                                                <asp:ListItem class="form-check-input" Text="No" Value="N"></asp:ListItem>
                                                                <asp:ListItem class="form-check-input" Text="Reject" Value="R"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 text-center">
                                                <asp:Button Text="Next" CssClass="btn btn-blue mx-2" ID="btnNext" OnClick="btnNext_Click" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" runat="server">
                                            <asp:GridView ID="gvYes" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentives in Full Shape">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="row" runat="server" id="divYesControls" visible="false">
                                            <div class="col-sm-4 form-group" style="margin-left: 18px;">
                                                <label class="control-label label-required" id="Label14" runat="server">Inspecting Officer</label>
                                                <asp:DropDownList ID="ddlOfficer" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-8 text-left" style="margin: -78px 0px 0px 511px;">
                                                <br />
                                                <asp:Button Text="Assign" CssClass="btn btn-blue mx-2" ID="btnAssign" OnClick="btnAssign_Click" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" runat="server">
                                            <asp:GridView ID="gvNo" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentives not in Full Shape">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Query Description" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtQuery" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="row" runat="server" id="divQueryControl" visible="false">
                                            <div class="col-sm-12 text-center">
                                                <asp:Button Text="Raise Query" CssClass="btn btn-blue mx-2" ID="btnQuery" OnClick="btnQuery_Click" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" runat="server">
                                            <asp:GridView ID="gvReject" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rejected Incentives">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Reject Reason" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtReasons" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" Text='<%#Eval("EnterperIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("MstIncentiveId") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="row" runat="server" id="divRejectControl" visible="false">
                                            <div class="col-sm-12 text-center">
                                                <asp:Button Text="Reject" CssClass="btn btn-blue mx-2" ID="btnReject" OnClick="btnReject_Click" runat="server" />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                             <div class="card" id="divGMHistory" runat="server" visible="false">
                                <div class="card-header p-0" id="HistoryGM1">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#DivCollapseGMHist">Application Status History(GM)
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="DivCollapseGMHist" class="collapse">
                                    <div class="card-body">
                                         <div class="row" id="divAssignedDtls" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Assigned to Inspecting Officer</div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvGMAssigned" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentive">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Inspecting Officer">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInspectingOfficer" Text='<%#Eval("InspectingOfficer") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Assigned By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssignedBy" Text='<%#Eval("AssignedBy") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Assigned Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAssignedDate" Text='<%#Eval("InspectionAssignedDate") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                             </div>
                                         <div class="row" id="divGMQuery" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">GM Query Details</div>
                                        <div class="card-body">
                                            <asp:GridView ID="gvGMQuery" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentive">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Query Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQuery" Text='<%#Eval("Query") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Query Raised By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQueryRaisedBy" Text='<%#Eval("QueryRaisedBy") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Query Responce">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQueryResponce" Text='<%#Eval("Responce") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Response Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblResponseDate" Text='<%#Eval("ResponseDate") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Query Raised Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblQueryDate" Text='<%#Eval("QueryDate") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                             </div>
                                         <div class="row" id="divGMReject" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">GM Rejected Details</div>
                                        <div class="col-lg-10 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                            <asp:GridView ID="gvGMReject" runat="server" AutoGenerateColumns="False"
                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                HorizontalAlign="Left" ShowHeader="true">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentive">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveName" Text='<%#Eval("IncentiveName") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rejection Reason">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRejectionRemarks" Text='<%#Eval("RejectionRemarks") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rejected By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRejectedBy" Text='<%#Eval("RejectedBy") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Rejected Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRejectedDate" Text='<%#Eval("RejectedDate") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                             </div>
                                    </div>
                                </div>
                            </div>


                            <div class="card" id="div2" runat="server" visible="false">
                                <div class="card-header p-0" id="headingThree">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapseDLOStage1">
                                        <span id="SpanDLOApplcation" runat="server">Verification of Applcation(DLO)</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapseDLOStage1" class="collapse show">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label1" runat="server">Applied Incentives</label>
                                                <asp:DropDownList ID="ddlAppliedIncenties" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-1 form-group">
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="lblstatus" runat="server">Status </label>
                                                <asp:RadioButtonList ID="Rbtnstatus" runat="server" AutoPostBack="True" class="custom-radio" OnSelectedIndexChanged="Rbtnstatus_SelectedIndexChanged">
                                                    <asp:ListItem Text="Schedule Inspection" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Raise Query" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Reject" Value="3"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4 form-group" id="divQuery" runat="server" visible="false">
                                                <label class="control-label label-required" id="lblQueryStatus" runat="server">Query</label>
                                                <asp:TextBox ID="txtQueryRemarks" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-sm-4 form-group" id="divInspectionDate" runat="server">
                                                <label class="control-label label-required" id="Label2" runat="server">Inspection Date</label>
                                                <asp:TextBox ID="txtAppDateofInspection" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row" id="divQueryLetter" runat="server" visible="false">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label7" runat="server">Any Query Letter</label>
                                                <asp:FileUpload ID="fuQueryLetter" runat="server" CssClass="file-browse" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 text-center">
                                                <asp:Button Text="Process" CssClass="btn btn-blue mx-2" ID="btnProcessApplication" runat="server" OnClick="btnProcessApplication_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card" id="divmainUpdateInspectionDetails" runat="server" visible="false">
                                <div class="card-header p-0" id="headingInspectionReport">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapseInspectionReport">
                                        <span id="SpanInspectionReport" runat="server">Update Inspection Report</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapseInspectionReport" class="collapse show">
                                    <div class="card-body">
                                        <div class="row" id="DivUpdateInspectionDetails" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Scheduled Inspection Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvUpdateInspectionDetails" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px" OnRowDataBound="gvUpdateInspectionDetails_RowDataBound">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="SchduledDate" HeaderText="Inspection Scheduled Date" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Scheduled By" />
                                                        <asp:BoundField DataField="Status" HeaderText="Status of Inspection" />
                                                        <asp:TemplateField HeaderText="Download Draft Inspection Report">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchDownloadDraftInspectionReport" runat="server" Text="Download" Font-Bold="true" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Upload Inspection Report">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkView" runat="server" Text="Upload" Font-Bold="true" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Send to Industires" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnIndustries" runat="server" Text="Send to Industires Dept" Visible='<%# Eval("SubIncentiveId").ToString() == "1" ? true : false %>' CssClass="btn btn-blue py-1 title7" OnClick="btnIndustries_Click"></asp:Button>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Inspection Delay Notes" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchortaglinkInspDelay" runat="server" Text="Inspection Delay Notes" Font-Bold="true" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                                <asp:Label ID="lblInspflag" Text='<%#Eval("Inspflag") %>' runat="server" />
                                                                <asp:Label ID="lblIndDeptFlag" Text='<%#Eval("IndDeptFlag") %>' runat="server" />
                                                                <asp:Label ID="lblInspectionId" Text='<%#Eval("InsId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivUpdateReInspectionDetails" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Revised Inspection Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvUpdateReInspectionDetails" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px" OnRowDataBound="gvUpdateReInspectionDetails_RowDataBound">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="SchduledDate" HeaderText="Date of Revised Report Raised" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Raised By" />
                                                        <asp:BoundField DataField="Status" HeaderText="Status of Revised Report" />
                                                        <asp:TemplateField HeaderText="Download Draft Inspection Report">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="anchDownloadDraftInspectionReport" runat="server" Text="Download" Font-Bold="true" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Upload Inspection Report">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="ReanchortaglinkView" runat="server" Text="Upload" Font-Bold="true" Target="_blank" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                                <asp:Label ID="lblInspflag" Text='<%#Eval("Inspflag") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="card" id="div3" runat="server" visible="false">
                                <div class="card-header p-0" id="headingInspectionReportold">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse6">Inspection Report
			                               
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapse6" class="collapse">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-sm-12 table-responsive">
                                                <asp:GridView ID="grdInspections" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="SchduledDate" HeaderText="Inspection Scheduled On" />
                                                        <asp:BoundField DataField="OfficerId" HeaderText="Scheduled By" />
                                                        <asp:BoundField DataField="InspectionStatus" HeaderText="Status of Inspection" />
                                                        <asp:BoundField DataField="InspectionDoneOn" HeaderText="Inspection Completed On" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>



                                    </div>
                                </div>
                            </div>

                            <div class="card" id="divQueriesAfterInspection" runat="server" visible="false">
                                <div class="card-header p-0" id="headingQueryHistoryAfterInspection">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapseAfterInspection">
                                        <span id="SpanApplcationStatusHistoryAfterInspection" runat="server">Applcation Status History - After Inspection (DLO)</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapseAfterInspection" class="collapse">
                                    <div class="card-body">
                                        <div class="row" id="DivRefferedApplicationDetails" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Reffered Application Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvRefferedApplicationStatus" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RefferedTo" HeaderText="Reffered To" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Reffered By" />
                                                        <asp:BoundField DataField="RefferedDate" HeaderText="Reffered Date" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" runat="server" id="divDLOCoveringLetter">
                                                DLO - Covering Letter :
                                                   
                                                <asp:HyperLink ID="HyCoveringLetter" Target="_blank" runat="server">Click Here</asp:HyperLink>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" id="DivRefferedApplicationDetailsReInspection" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Reffered Application Details after Revised Inspection</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvRefferedApplicationStatusReInspection" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RefferedTo" HeaderText="Reffered To" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Reffered By" />
                                                        <%-- <asp:BoundField DataField="RefferedDate" HeaderText="Reffered Date (Revised Inspection Report Uploaded Date)" />--%>
                                                        <asp:TemplateField HeaderText="Reffered Date </br> (Revised Inspection Report Uploaded Date)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Slno" runat="server" Text='<%# Bind("RefferedDate") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" runat="server" id="div6">
                                                DLO - Covering Letter :
                                                   
                                                <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server">Click Here</asp:HyperLink>
                                            </div>
                                        </div>
                                        <div class="row" id="DivQueryDetailsAfterInspection" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details - Yet to Respond by Applicant</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="grdQueriesAfterInspection" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="Query" HeaderText="Query" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivQueryResponseAfterInspection" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details - Responded by Applicant</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="grdQueriesResponseAfterInspection" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="Query" HeaderText="Query" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                        <asp:BoundField DataField="Responce" HeaderText="Query Responce" />
                                                        <asp:BoundField DataField="ResponseDate" HeaderText="Date Of Response" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="row" id="DivRejectedApplicationsAfterInspection" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Rejected Applications</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvRejectedApplicationsAfterInspection" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RejectionRemarks" HeaderText="Rejection Remarks" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Rejected By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Date of Rejection" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card" id="divInspectionCompleted" runat="server" visible="false">
                                <div class="card-header p-0" id="headingfour">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapseDLOStage2">
                                        <span id="SpnAfterInspection" runat="server">Verification of Applcation(DLO)- After Inspection</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapseDLOStage2" class="collapse show">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label3" runat="server">Inspection Completed Incentives</label>
                                                <asp:DropDownList ID="ddlInspectionCompletedIncentives" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlInspectionCompletedIncentives_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-1 form-group">
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="lblAfterInspectionstatus" runat="server">Status</label>
                                                <asp:RadioButtonList ID="RbtnAfterInspectionstatus" runat="server" AutoPostBack="True" class="custom-radio" OnSelectedIndexChanged="RbtnAfterInspectionstatus_SelectedIndexChanged">
                                                    <asp:ListItem Text="Recommend" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Raise Query" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Reject" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Upload Revised Inspection Report" Value="4"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4 form-group" id="divReInspectionDate" runat="server" visible="false">
                                                <label class="control-label label-required" id="Label6" runat="server">Re-Inspection Date</label>
                                                <asp:TextBox ID="txtReInspectionDate" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-4 form-group" id="divAfterInspectionQuery" runat="server" visible="false">
                                                <label class="control-label label-required" id="lblAfterInspectionQueryStatus" runat="server">Query</label>
                                                <asp:TextBox ID="txtAfterInspectionQueryRemarks" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 text-center">
                                                <asp:Button Text="Process" CssClass="btn btn-blue mx-2" ID="btnAfterInspection" runat="server" OnClick="btnAfterInspection_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card" id="divQueriesJD" runat="server" visible="false">
                                <div class="card-header p-0" id="headingQueryHistoryJD">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapseJD">
                                        <span id="SpanApplcationStatusHistoryJD" runat="server">Applcation Status History - Head Office (JD)</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapseJD" class="collapse">
                                    <div class="card-body">
                                        <div class="row" id="DivRefferedApplicationDetailsJD" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Reffered Application Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvRefferedApplicationStatusJD" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RefferedTo" HeaderText="Reffered To" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Reffered By" />
                                                        <asp:BoundField DataField="RefferedDate" HeaderText="Reffered Date" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="divJDSenttoDLOforReInspect" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Applications Sent to DLO for Revised Inspection Report</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvSentDloRevisedInsp" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RefferedTo" HeaderText="Sent To" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Sent By" />
                                                        <asp:BoundField DataField="RefferedDate" HeaderText="Sent Date" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="divJDtoDLC" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Applications Sent to DLC(Below 25 Lakhs)</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvJDtoDLC" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RefferedTo" HeaderText="Sent To" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Sent By" />
                                                        <asp:BoundField DataField="RefferedDate" HeaderText="Sent Date" />
                                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivQueryDetailsJD" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details - Yet to Respond by Applicant</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="grdQueriesJD" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="Query" HeaderText="Query" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivQueryResponseJD" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Query Details - Responded by Applicant</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="grdQueriesResponseJD" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="Query" HeaderText="Query" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Query Raised By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Query Raised Date" />
                                                        <asp:BoundField DataField="Responce" HeaderText="Query Responce" />
                                                        <asp:BoundField DataField="ResponseDate" HeaderText="Date Of Response" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>

                                        <div class="row" id="DivRejectedApplicationsJD" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Rejected Applications</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvRejectedApplicationsJD" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RejectionRemarks" HeaderText="Rejection Remarks" />
                                                        <asp:BoundField DataField="Emp_Name" HeaderText="Rejected By" />
                                                        <asp:BoundField DataField="CreatedDate" HeaderText="Date of Rejection" />
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card" id="divJDVerificationOfapplication" runat="server" visible="false">
                                <div class="card-header p-0" id="headingfive">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapsejdStage2">
                                        <span id="SpnJDVerificationOfapplication" runat="server">Verification of Applcation(JD)- Head Office</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapsejdStage2" class="collapse show">
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="lblDLORecommended" runat="server">DLO Recommended Incentives</label>
                                                <asp:DropDownList ID="ddlDLORecommendedIncentives" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDLORecommendedIncentives_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div id="divrdbHalfyear" runat="server" visible="false" class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="Label13" runat="server">Application Process Type</label>
                                                <asp:RadioButtonList ID="rdbFullPartial" RepeatDirection="Vertical" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rdbFullPartial_SelectedIndexChanged">
                                                    <asp:ListItem Value="F" Selected="True">Full Application</asp:ListItem>
                                                    <asp:ListItem Value="P">Partial Application</asp:ListItem>
                                                    <asp:ListItem Value="CP">Balance Partial Application</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="col-sm-2 form-group" runat="server" visible="false" id="divFullPartialRemarks">
                                                <label class="control-label label-required" id="Label15" runat="server">JD Recommended Amount</label>
                                                <asp:TextBox ID="txtPartialRecommendedAmount" onkeypress="return DecimalOnly();" runat="server"></asp:TextBox>
                                                <label class="control-label label-required" id="Label12" runat="server">Remarks</label>
                                                <asp:TextBox ID="txtFullPartialRemarks" TextMode="MultiLine" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-sm-4 form-group">
                                                <label class="control-label label-required" id="lblHeadOfficestatus" runat="server">Status</label>
                                                <asp:RadioButtonList ID="RbtnHeadOfficestatus" runat="server" AutoPostBack="True" class="custom-radio" OnSelectedIndexChanged="RbtnHeadOfficestatus_SelectedIndexChanged">
                                                    <asp:ListItem Text="Recommend to SVC" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Raise Query" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="Reject" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="Send to DLO for Revised Inspection Report" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="Send to DLC" Value="5"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-7 form-group" id="divHeadOfficeJdQuery" runat="server" visible="false">
                                                <label class="control-label label-required" id="lblvHeadOfficeJdQueryStatus" runat="server">Query</label>
                                                <asp:TextBox ID="txtvHeadOfficeJdQueryRemarks" runat="server" Rows="6" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                            </div>
                                            <div class="row" id="divMemoLetter" runat="server" visible="false">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required" id="Label9" runat="server">Any Memo Letter</label>
                                                    <asp:FileUpload ID="fuMemoLetter" runat="server" CssClass="file-browse" />
                                                </div>
                                            </div>
                                            <div class="row" id="divJointInspReport" runat="server" visible="false">
                                                <div class="col-sm-4 form-group">
                                                    <label class="control-label label-required" id="Label11" runat="server">Joint Inspection Report </label>
                                                    <asp:FileUpload ID="fuJointInspReport" runat="server" CssClass="file-browse" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12 text-center">
                                                <asp:Button Text="Process" CssClass="btn btn-blue mx-2" ID="btnJDHeadOffice" runat="server" OnClick="btnJDHeadOffice_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card" id="divSVCStatus" runat="server" visible="false">
                                <div class="card-header p-0" id="headingSVCStatus">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapseSVCStatus">
                                        <span id="SpanApplcationStatusSVCStatus" runat="server">Applcation Status History - DL SVC (DLO)</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapseSVCStatus" class="collapse">
                                    <div class="card-body">
                                        <div class="row" id="DivApprovedApplicationDetailsSVC" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Approved Application Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvApprovedApplicationDetailsSVC" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="ActualRecommendedAmount" HeaderText="SVC Recommended Amount" />
                                                        <%--<asp:BoundField DataField="SVC_FinalSanctionedAmount" HeaderText="Sanctioned Amount" />--%>
                                                        <asp:BoundField DataField="SVC_Meeting_No" HeaderText="Meeting Number" />
                                                        <asp:BoundField DataField="Actual_Meeting_Date" HeaderText="Meeting Date" />
                                                        <asp:BoundField DataField="Sanctioned_By" HeaderText="Action Taken By" />
                                                        <asp:BoundField DataField="Actual_Meeting_Date" HeaderText="Recommended Date" />
                                                        <%--  <asp:BoundField DataField="StageDescription" HeaderText="Status" />--%>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Minutes Document">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivRejectedApplicationsSVC" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Rejected Applications</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvRejectedApplicationsSVC" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="ActualRecommendedAmount" HeaderText="DLO Recommended Amount" />
                                                        <asp:BoundField DataField="SVC_Meeting_No" HeaderText="DLSVC Meeting Number" />
                                                        <asp:BoundField DataField="Actual_Meeting_Date" HeaderText="DLSVC Meeting Date" />
                                                        <asp:BoundField DataField="Remarks" HeaderText="Rejection Remarks" />
                                                        <asp:BoundField DataField="Sanctioned_By" HeaderText="Actione Taken By" />
                                                        <asp:BoundField DataField="SVC_Sanctioned_Date" HeaderText="Date of Rejection" />
                                                        <asp:BoundField DataField="StageDescription" HeaderText="Status" />
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="DLSVC Meeting Document">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card" id="divDLCStatus" runat="server" visible="false">
                                <div class="card-header p-0" id="headingDLCStatus">
                                    <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapseDLCStatus">
                                        <span id="SpanApplcationStatusDLCStatus" runat="server">Applcation Status History - DLC (DLO)</span>
                                        <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                    </a>
                                </div>
                                <div id="collapseDLCStatus" class="collapse">
                                    <div class="card-body">
                                        <div class="row" id="DivApprovedApplicationDetailsDLC" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Approved Application Details</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvApprovedApplicationDetailsDLC" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RecommendedAmounttoMeeting" HeaderText="SVC Recommended Amount" />
                                                        <%--  <asp:BoundField DataField="SVC_FinalSanctionedAmount" HeaderText="DL SVC Recommended Amount" />--%>
                                                        <asp:BoundField DataField="FinalSanctionedAmount" HeaderText="SLC Sanctioned Amount" />
                                                        <asp:BoundField DataField="Meeting_No" HeaderText="Meeting Number" />
                                                        <asp:BoundField DataField="Actual_Meeting_Date" HeaderText="Meeting Date" />
                                                        <asp:BoundField DataField="Sanctioned_By" HeaderText="Action Taken By" />
                                                        <asp:BoundField DataField="Actual_Meeting_Date" HeaderText="Date of Sanction" />
                                                        <asp:BoundField DataField="StageDescription" HeaderText="Status" />
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Minutes Document">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLinkSubsidy" Text="View" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Sanction Letter">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLinkSanction" Text="View" NavigateUrl='<%#Eval("SanctionOrderFilePath")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="row" id="DivRejectedApplicationsDLC" runat="server" visible="false">
                                            <div class="col-sm-12 text-black font-SemiBold mb-1">Rejected Applications</div>
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                <asp:GridView ID="gvRejectedApplicationsDLC" runat="server" AutoGenerateColumns="False"
                                                    CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                    Width="100%" Font-Names="Verdana" Font-Size="12px">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1%>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle Width="60px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                                        <asp:BoundField DataField="RecommendedAmounttoMeeting" HeaderText="Recommended Amount" />
                                                        <asp:BoundField DataField="Meeting_No" HeaderText="DLC Meeting Number" />
                                                        <asp:BoundField DataField="Actual_Meeting_Date" HeaderText="DLC Meeting Date" />
                                                        <asp:BoundField DataField="Remarks" HeaderText="Rejection Remarks" />
                                                        <asp:BoundField DataField="Sanctioned_By" HeaderText="ActioneTaken By" />
                                                        <asp:BoundField DataField="Sanctioned_Date" HeaderText="Date of Rejection" />
                                                        <asp:BoundField DataField="StageDescription" HeaderText="Status" />
                                                        <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="DLC Meeting Document">
                                                            <ItemTemplate>
                                                                <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <table bgcolor="White" width="100%" style="font-family: Verdana;">
                    <tr>
                        <td align="left" colspan="3">
                            <div id="success" runat="server" visible="false" class="alert alert-success">
                                <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </div>
                            <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                            </div>
                        </td>
                    </tr>

                </table>
            </div>
            </div>
            </div>
           
            <div id="dialog" style="display: none">
            </div>
            <asp:HiddenField ID="hdnInspection" runat="server" />
            <asp:HiddenField ID="hdnUserRole" runat="server" />
            <asp:HiddenField ID="hdnDistId" runat="server" />
            <asp:HiddenField ID="hdnUID" runat="server" />
            <asp:HiddenField ID="hdnIndusType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../Js/jquery-latest.min.js"></script>
    <script src="../Js/jquery-ui.min.js"></script>
    <link href="../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='ContentPlaceHolder1_txtAppDateofInspection']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtReInspectionDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');

            $("input[id$='ContentPlaceHolder1_txtAppDateofInspection']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='ContentPlaceHolder1_txtReInspectionDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $('.Inspdate').datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                });
        }
        $(function () {

            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $('.Inspdate').datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                });
            $("input[id$='ContentPlaceHolder1_txtAppDateofInspection']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                });
            $("input[id$='ContentPlaceHolder1_txtReInspectionDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                });
        });
        function getParameterByName(name) {
            //debugger;
            name = name.replace(/[[]/, "\[").replace(/[]]/, "\]");
            var regexS = "[\?&]" + name + "=([^&#]*)";
            var regex = new RegExp(regexS);
            var results = regex.exec(window.location.href);
            if (results == null)
                return "";
            else
                return decodeURIComponent(results[1].replace(/\+/g, ' '));
        }
        function mydata() {
            alert('Jai Balayya');
        }
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }
    </style>
</asp:Content>
