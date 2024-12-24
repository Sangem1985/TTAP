<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmIncentiveProcess.aspx.cs" Inherits="TTAP.UI.frmIncentiveProcess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Js/validations.js" type="text/javascript"></script>

    <style type="text/css" media="print">
        @page {
            size: landscape;
        }
    </style>
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
    <%-- <link href="assets/css/basic.css" rel="stylesheet" />--%>
    <%--  <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">--%>
    <%--<div class="panel panel-primary">
                           <div class="panel-heading" align="center">
                                <h3 class="panel-title">
                                    Entrepreneur Details</h3>
                            </div>--%>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                        <h5 class="text-blue mt-1 mb-3 font-SemiBold">Applications</h5>
                        <div class="widget-content">
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
                                <div class="card" id="divgm" runat="server">
                                    <div class="card-header p-0" id="headingThree">
                                        <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse6">
                                            <span id="spnjdlevel1" runat="server">Verification of Applcation(JD - DIC)</span>
                                            <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                        </a>
                                    </div>
                                    <div id="collapse6" class="collapse show">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-sm-12 table-responsive" id="trYettobeassign2" runat="server">
                                                    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False"
                                                        CssClass="table table-bordered title6 alternet-table w-100 NewEnterprise">
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
                                                                <ItemStyle Width="60px" CssClass="text-center" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="IncentiveName" HeaderStyle-VerticalAlign="Top" HeaderText="Incentives" ItemStyle-Width="500px">
                                                                <HeaderStyle VerticalAlign="Top" />
                                                                <ItemStyle Width="500px" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="Status" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:RadioButtonList ID="rdbyesno" RepeatDirection="Horizontal" Width="180px" CssClass="table-radio" runat="server" >
                                                                        <asp:ListItem Text="Forward" Value="Y"></asp:ListItem>
                                                                        <%-- <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                                <asp:ListItem Text="Reject" Value="R"></asp:ListItem>--%>
                                                                    </asp:RadioButtonList>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Remarks" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtremarks" TextMode="MultiLine" Rows="2" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
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
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                               
                                             
                                            </div>
                                          
                                        </div>
                                    </div>
                                </div>
                                <div class="card" runat="server" id="trgmhistory">
                                    <div class="card-header p-0" id="Div6">
                                        <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse1">
                                            <span id="Spangmdicquery" runat="server">Query History</span>
                                            <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                        </a>
                                    </div>
                                    <div id="collapse1" class="collapse show">
                                        <div class="card-body">
                                            <div class="row">
                                                <%--<span class="col-sm-12">G.M Query History</span>--%>
                                                <div class="col-sm-12 table-responsive">
                                                    <asp:GridView ID="gvquery" runat="server" AutoGenerateColumns="true"
                                                        CssClass="table table-bordered title6 alternet-table mb-0 w-100 NewEnterprise">
                                                        <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                        <FooterStyle CssClass="GridviewScrollC1Header" />
                                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex + 1%>
                                                                    <asp:HiddenField ID="HdfQueid" runat="server" />
                                                                    <asp:HiddenField ID="HdfApprovalid" runat="server" />
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle Width="60px" CssClass="text-center" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="card" id="tripo1" runat="server" visible="false">
                                    <div class="card-header p-0">
                                        <a class="card-link d-block p-2 px-3 font-SemiBold text-blue" data-toggle="collapse" href="#collapse8">
                                            <span id="Span1" runat="server">Verification of application (Assistant Director-DIC)</span>
                                            <span class="pull-right"><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                                        </a>
                                    </div>
                                    <div id="collapse8" class="collapse show">
                                        <div class="card-body">
                                            <table bgcolor="White" width="100%">
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:GridView ID="gvdicinspection" runat="server" AutoGenerateColumns="False"
                                                            CellPadding="4" Height="62px"
                                                            Width="80%" Font-Names="Verdana" Font-Size="12px">
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
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr style="height: 30px" id="tripoinsp1button0" runat="server" visible="false">
                                                    <td style="width: 250px; font-weight: bold">1). Inspection Date : &nbsp;
                                                    </td>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="txtinspectiondate" autocomplete="off" class="form-control txtbox" Width="150px" Height="30px" runat="server" />
                                                    </td>
                                                </tr>

                                               
                                            </table>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>

    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtinspectiondate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                    //yearRange: "1930:2017",
                    //changeYear: true
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
        }
        $(function () {
            $("input[id$='txtinspectiondate']").keydown(function () {
                //code to not allow any changes to be made to input field 
                return false;
            });
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtinspectiondate']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    minDate: 0,
                    //yearRange: "1930:2017",
                    // changeYear: true
                    // maxDate: new Date(currentYear, currentMonth, currentDate) txtinspectiondate
                });
           
            // 

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
    </script>
    <style type="text/css">
        .ui-datepicker {
            font-size: 8pt !important;
            height: 250px;
            padding: 0.2em 0.2em 0;
        }
    </style>
</asp:Content>
