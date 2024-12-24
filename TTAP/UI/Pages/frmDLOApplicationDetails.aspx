<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmDLOApplicationDetails.aspx.cs" Inherits="TTAP.UI.Pages.frmDLOApplicationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="http://code.jquery.com/Jquery.min.js" charset="utf-8"></script>
        <script src="../../Js/validations.js" type="text/javascript"></script>
    <style type="text/css">
        .modalBackground {
            background-color: #4e5e6a;
            border-color: Blue;
            border: 1px;
            filter: alpha(opacity=70);
            opacity: 0.4;
            z-index: 10000;
        }
    </style>
    <style type="text/css" media="print">
        @page {
            size: landscape;
        }
    </style>
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
            -moz-opacity: 8pt;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }

        /* END EXTERNAL SOURCE */
    </style>
    <%-- Date Picker Starts --%>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateofInspection']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            
        }
    </script>
      <script type="text/javascript">
    $(function () {
        $('.date').datepicker();
    });
     </script>  
       <script type="text/javascript">
       Sys.WebForms.PageRequestManager.getInstance().add_endRequest(getme);
        function getme() {
        $('.date').datepicker();
     }
    </script> 
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }
    </style>
    <%-- Date Picker End --%>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Application Details</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item">Application Details</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Div43" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Application Summery</h5>
                        <div class="widget-content no-padding">

                            <div id="accordion">
                                <div class="card">
                                    <div class="card-header p-0">
                                        <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse1">Enterprise Details
                                            <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                        </a>
                                    </div>
                                    <div id="collapse1" class="collapse" data-parent="#accordion">
                                        <div class="card-body">
                                            <table class="table table-bordered title6 alternet-table w-100 app-table" valign="middle">
                                                <tr>
                                                    <td colspan="6" class="list-heading-bg font-SemiBold title5 text-blue">A.
                                                        <asp:Label ID="lblIndustries1" runat="server">COMMON DETAILS OF THE ENTREPRENUER</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="2%" class="text-center"></td>
                                                    <td width="28%">ApplicationNo</td>
                                                    <td width="20%">
                                                        <asp:Label ID="lblApplicationNo" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="2%" class="text-center">1. </td>
                                                    <td width="28%">IEM/IL No</td>
                                                    <td width="20%">
                                                        <asp:Label ID="txtudyogAadharNo" runat="server"></asp:Label>
                                                    </td>
                                                    <td width="2%" class="text-center">2. </td>
                                                    <td width="28%">Unit Name</td>
                                                    <td width="20%">
                                                        <span>
                                                            <asp:Label ID="txtUnitname" runat="server"></asp:Label>
                                                        </span>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">3. </td>
                                                    <td>Name of the  Managing Director /Managing Partner / Proprietor</td>

                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtApplicantName" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">4. </td>
                                                    <td>GST</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtTinNumber" runat="server"></asp:Label>
                                                        </span>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">5. </td>
                                                    <td>PAN Number of the  Managing Director /Managing Partner / Proprietor</td>

                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtPanNumber" runat="server"></asp:Label>
                                                        </span></td>
                                                    <td class="text-center">6. </td>
                                                    <td>Category</td>
                                                    <td>
                                                        <asp:Label ID="ddlCategory" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">7. </td>
                                                    <td>Type of Organization</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="ddltypeofOrg" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">8. </td>
                                                    <td>Industry Status 
                                                    </td>
                                                    <td><span>
                                                        <asp:Label ID="ddlindustryStatus" runat="server"></asp:Label>
                                                    </span>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="text-center">9. </td>
                                                    <td>Date of commencement for Production</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtDateofCommencement" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">10. </td>
                                                    <td>Social Status</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="rblCaste" runat="server"></asp:Label>
                                                        </span>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="text-center">11. </td>
                                                    <td>Physically Handicapped</td>
                                                    <td colspan="4">
                                                        <span>
                                                            <asp:Label ID="lblPhc" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr id="trEmPartNo11" runat="server" visible="false">
                                                    <td class="text-center">11. </td>
                                                    <td>EM Part - II/IEM/IL No:
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="lblEMPartNo" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="list-heading-bg font-SemiBold title5 text-blue" colspan="6">
                                                        <asp:Label ID="Label4" runat="server">B. UNIT ADDRESS</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">1. </td>
                                                    <td>District</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="ddldistrictunit" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">2.</td>
                                                    <td>Survey No
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtunitaddhno" runat="server"></asp:Label>
                                                        </span>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">3. </td>
                                                    <td>Taluk</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="ddlUnitMandal" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">4. </td>
                                                    <td>Street</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtstreetunit" runat="server"></asp:Label>
                                                        </span>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">5. </td>
                                                    <td>Village</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="ddlVillageunit" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">6. </td>
                                                    <td>Mobile Number
                                                    </td>
                                                    <td colspan="4">
                                                        <span>
                                                            <asp:Label ID="txtunitmobileno" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">7. </td>
                                                    <td>Email Id</td>
                                                    <td style="text-align: left; padding: 10px; margin: 5px; width: 250px">
                                                        <span>
                                                            <asp:Label ID="txtunitemailid" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="list-heading-bg font-SemiBold title5 text-blue" colspan="6">
                                                        <asp:Label ID="Label5" runat="server" Font-Bold="True">C. OFFICE ADDRESS</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">1. </td>
                                                    <td>District</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="ddldistrictoffc" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">2. </td>
                                                    <td>Survey No
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtoffaddhnno" runat="server"></asp:Label>
                                                        </span>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">3. </td>
                                                    <td>Taluk</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="ddloffcmandal" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">4. </td>
                                                    <td>Street
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtstreetoffice" runat="server"></asp:Label>
                                                        </span>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">5. </td>
                                                    <td>Village</td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="ddlvilloffc" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                    <td class="text-center">6. </td>
                                                    <td>Mobile Number
                                                    </td>
                                                    <td>
                                                        <span>
                                                            <asp:Label ID="txtOffcMobileNO" runat="server"></asp:Label>
                                                        </span>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-center">7. </td>
                                                    <td>Email Id</td>
                                                    <td colspan="4">
                                                        <span>
                                                            <asp:Label ID="txtOffcEmail" runat="server"></asp:Label>
                                                        </span>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                                <div class="card">
                                    <div class="card-header p-0">
                                        <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse2">Application
                                            <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                        </a>
                                    </div>
                                    <div id="collapse2" class="collapse">
                                        <div class="card-body">
                                            <div class="row" id="Receipt" runat="server">
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
                                           
                                                <table width="100%" id="tblSubsidy" runat="server">
                                                    <tr>
                                                        <td colspan="10">Incentive wise Attachments</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvSubsidy" runat="server" AutoGenerateColumns="False"
                                                                CssClass="table table-bordered title6 alternet-table mb-0 w-100 NewEnterprise" HorizontalAlign="Left" ShowHeader="true">
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
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Verified" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verified")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>

                                                    <tr id="trQueryResponceAttachments" runat="server" visible="false">
                                                        <td colspan="10" class="pt-4">Query Responce Attachments
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvqquryresponceattachment" runat="server" AutoGenerateColumns="False"
                                                                CssClass="table table-bordered title6 alternet-table mb-0 w-100 NewEnterprise" HorizontalAlign="Left" ShowHeader="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="text-center" HeaderText="S No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="60px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachments">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="View">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbluploadeddate" Text='<%#Eval("UploadedDate")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="150px" />
                                                                    </asp:TemplateField>
                                                                    <%--<asp:TemplateField HeaderText="Verified">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblverified" Text='<%#Eval("Verified")%>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                        </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr id="gvsupportingdocshead" runat="server" visible="false">
                                                        <td colspan="10">Inspection Report - Supporting Documents
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gvsupportingdocs" runat="server" AutoGenerateColumns="False"
                                                                CssClass="table table-bordered title6 alternet-table mb-0 w-100 NewEnterprise" HorizontalAlign="Left" ShowHeader="true">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <ItemStyle Width="60px" CssClass="text-center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Attachments">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl" runat="server" Text='<%# Eval("AttachmentName")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="View">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLinkSubsidy" Text="view" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Verified" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblverified" Text='<%#Eval("Verified")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr19" runat="server" visible="false">
                                                        <td colspan="10" class="pt-4">Attachments - Uploaded By JD</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="GridView14" runat="server" AutoGenerateColumns="False"
                                                                CssClass="table table-bordered title6 alternet-table mb-0 w-100 NewEnterprise" HorizontalAlign="Left" ShowHeader="true">
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
                                                                            <asp:HyperLink ID="HyperLinkSubsidy" CssClass="btn btn-blue py-1 title7" Text="View" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded Date">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbluploadeddate" Text='<%#Eval("UploadedDate")%>' runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="150px" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                               <div class="row">
                                <div class="col-ms-12">
                                    <asp:GridView ID="grdInspections" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" Height="62px"
                                        Width="100%" Font-Names="Verdana" Font-Size="12px">
                                        <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
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
                              <div class="row">
                                <div class="col-ms-12">
                                    <asp:GridView ID="grdQueries" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" Height="62px"
                                        Width="100%" Font-Names="Verdana" Font-Size="12px">
                                        <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                            <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="QueryStatus" HeaderText="Query Status" />
                                          <asp:BoundField DataField="OfficerQuery" HeaderText="Officer Query" />
                                            <asp:BoundField DataField="QryDate" HeaderText="Query sent on" />
                                            <asp:BoundField DataField="QryResponse" HeaderText="Investor Response" />
                                            <asp:BoundField DataField="ResponseDate" HeaderText="Responded ON" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-ms-12">
                                    <asp:GridView ID="grdIncentives" runat="server" AutoGenerateColumns="False"
                                        CellPadding="4" Height="62px"
                                        Width="100%" Font-Names="Verdana" Font-Size="12px">
                                        <HeaderStyle VerticalAlign="Middle" Height="40px" CssClass="GridviewScrollC1HeaderWrap" />
                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                        <FooterStyle BackColor="#013161" Height="40px" CssClass="GridviewScrollC1Header" />
                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1%>
                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Width="50px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="IncentiveName" HeaderText="Incentives" />
                                            <asp:TemplateField HeaderText="SubIncentiveId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSubIncentiveId" Text='<%#Eval("SubIncentiveId") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="SubIncentiveId">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlAction" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged">
                                                        <asp:ListItem Text="--Select--" Value="0" Selected="False"></asp:ListItem>
                                                        <asp:ListItem Text="--Send Query--" Value="1" ></asp:ListItem>
                                                         <asp:ListItem Text="--Schedule Inspection--" Value="2" ></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                        <asp:TextBox ID="txtQuery" runat="server" TextMode="MultiLine" class="form-control" Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="txtDateofInspection" runat="server"  class="date form-control" Visible="false"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>
                                                         <asp:Button ID="btnSubmit" runat="server" Text="Process" CssClass="btn btn-blue py-1 title7" onclick="btnSubmit_Click"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../../Js/jquery-latest.min.js"></script>
    <script src="../../Js/jquery-ui.min.js"></script>
    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
</asp:Content>

