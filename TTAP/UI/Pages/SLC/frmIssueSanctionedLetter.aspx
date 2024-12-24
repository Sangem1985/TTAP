<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmIssueSanctionedLetter.aspx.cs" Inherits="TTAP.UI.Pages.SLC.frmIssueSanctionedLetter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <script src="../../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../Js/validations.js"></script>

    <script language="javascript" type="text/javascript">
        function Panel1() {


            // document.getElementById('<%=tblselection.ClientID %>').style.display = "none";

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            // var printWindow = window.open('', '', 'height=400,width=800');
            // printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');
            // printWindow.document.write('</head><body style="width: 100%;text-align: center;">');

            var printWindow = window.open('', '', 'height=500,width=900');
            printWindow.document.write('<html><head><div><table style="width:100%"> <tr> <td align="center"> <img alt="" align="center" style="width:15%; height:15%" src="../../../images/logo.png"/> </td> <td> <div style="float: right; text-align: center; padding: 10px 0;"> <div style="float: left; margin-right: 30px;"> <h5 style="font-size: 14px; margin-bottom: 0px;"></h5> <p style="font-size: 14px; margin-bottom: 0px;"></p> </div> <div style="float:left"> <h5 style="font-size: 14px; margin-bottom: 0px;"></h5> <p style="font-size: 14px; margin-bottom: 0px;"></p> </div> </div> </td> </tr> </table> </div><h3 style="width: 100%; text-align: center;">Government of Telangana</h3>');
            printWindow.document.write('</head><body style="width:1200px;margin:0 auto;">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                //location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }

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
                        <a href="#" class="current" runat="server" id="acurrentpage">Incentive Types</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Issue Sanctioned Letter</li>
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
                                    <%--<h5 class="text-blue mb-3 font-SemiBold">Generate DLC Agenda</h5>--%>
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
                                                    <asp:BoundField DataField="ApplicationNumber" ItemStyle-HorizontalAlign="Center" HeaderText="Application Number">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="UnitName" ItemStyle-HorizontalAlign="Center" HeaderText="Unit Name">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Category" ItemStyle-HorizontalAlign="Center" HeaderText="Category">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ApplicantName" ItemStyle-HorizontalAlign="Center" HeaderText="Applicant Name">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Address" ItemStyle-HorizontalAlign="Center" HeaderText="Address">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SocialStatusText" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderText="Social Status">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TypeOfIndustryText" ItemStyle-HorizontalAlign="Center" HeaderText="Type Of Industry">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="TextileProcessName" ItemStyle-HorizontalAlign="Center" HeaderText="Nature Of Industry">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                     <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SLCDLCRecommended_date" ItemStyle-HorizontalAlign="Center" HeaderText="JD Recommended Date to SVC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ActualRecommendedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="JD Recommended Amount to SVC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Svc_TextileRecommendedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Textile Dept Recommended Amount">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Svc_IndustryRecommendedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="Industries Dept Recommended Amount">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SVC_FinalSanctionedAmount" ItemStyle-HorizontalAlign="Center" HeaderText="SVC Recommended Amount to SLC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SVC_Sanctioned_Date" ItemStyle-HorizontalAlign="Center" HeaderText="SVC Recommended Date to SLC">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Sanctioned Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblsactionnedAmount" Text='<%#Eval("SVC_FinalSanctionedAmount") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                 
                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div class="row" runat="server" >
                                        <div class="col-sm-12 text-blue font-SemiBold mb-1">Upload Sanctioned Letter</div>
                                        <div class="col-sm-12 table-responsive">
                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                <tr align="center">
                                                    <th>Sl.No </th>
                                                    <th>Document Name </th>
                                                    <th>Upload Document </th>
                                                    <th>File Name </th>
                                                </tr>
                                                
                                                 <tr class="GridviewScrollC1Item" id="tr1" runat="server">
                                                    <td align="center" style="width: 5%" id="Td1" runat="server">1</td>
                                                    <td align="left" style="width: 50%">Sanctioned Letter</td>
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
                                        <div class="col-sm-12 form-group">
                                            <span style="color: red">Note : </span>
                                            <br />
                                            Upload “PDF” files only <%--Max size of each file 2 MB--%>
                                        </div>
                                    </div>

                                    
                                    
                                    <div class="row">
                                        <div class="col-sm-12 text-center">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-blue" OnClientClick="ClientSideClick(this)"
                                                TabIndex="10" Text="Issue Sanctioned Letter" OnClick="btnSubmit_Click" ValidationGroup="group" />
                                        </div>
                                        <div class="col-sm-12 text-center" id="tblselection" runat="server" visible="false">

                                            <asp:Button ID="btnprint" runat="server" CssClass="btn btn-blue m-2" Visible="false" Text="Print Agenda" OnClientClick="javascript:Panel1()" />
                                            <asp:Button ID="btnDownloadPdf" CssClass="btn btn-primary m-2" Visible="false" runat="server" Text="Download PDF" OnClick="btnDownloadPdf_Click" />
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

        $("input[id$='ContentPlaceHolder1_txtDLCdate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_txtDLCdate']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtDLCdate']").datepicker(
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