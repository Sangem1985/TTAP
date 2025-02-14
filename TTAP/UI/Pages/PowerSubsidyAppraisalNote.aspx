<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="PowerSubsidyAppraisalNote.aspx.cs" Inherits="TTAP.UI.Pages.PowerSubsidyAppraisalNote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upd1" runat="server">
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="btnUpload" />--%>
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item" id="Sublinkname" runat="server">Inspection Report</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-4 frm-form box-content py-4 font-medium title5">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                    <h5 class="text-blue mb-3 font-SemiBold  col col-sm-12 mt-3 text-center" runat="server" id="HMainheading">Inspection Report</h5>
                                </div>
                                <div class="widget-content nopadding">
                                    <table runat="server" visible="false">
                                        <tr>
                                            <td>

                                                <asp:TextBox ID="txtIncID" runat="server" TextMode="Number"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_schemetide" class="form-control txtbox" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Button runat="server" Text="Search" CssClass="btn-blue" ID="btnsub" />
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label12" runat="server">Unit Name</label>
                                            <label class="form-control" id="lblUnitName" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label26" runat="server">Address</label>
                                            <label class="form-control" id="lblAddress" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label27" runat="server">Name of the Proprietor</label>
                                            <label class="form-control" id="lblProprietor" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label28" runat="server">Constitution of Organization</label>
                                            <label class="form-control" id="lblOrganization" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label29" runat="server">Social Status</label>
                                            <label class="form-control" id="lblSocialStatus" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label30" runat="server">Share of SC/ST/Women Enterprenuer</label>
                                            <label class="form-control" id="lblShareofSCSTWomenEnterprenue" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label31" runat="server">Registration Number</label>
                                            <label class="form-control" id="lblRegistrationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label3" runat="server">Type of Unit</label>
                                            <label class="form-control" id="lblTypeofApplicant" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label19" runat="server">Category of Unit as per Application</label>
                                            <label class="form-control" id="lblCategoryofUnit" runat="server"></label>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label32" runat="server">Type of Sector</label>
                                            <label class="form-control" id="lblTypeofSector" runat="server">Textiles</label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label18" runat="server">Type of Textile as per Application</label>
                                            <label class="form-control" id="lblTypeofTexttile" runat="server"></label>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label33" runat="server">Technical Textile Type</label>
                                            <label class="form-control" id="lblTechnicalTextileType" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label5" runat="server">Activity of the Unit</label>
                                            <label class="form-control" id="lblActivityoftheUnit" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label1" runat="server">TSIPass-UID Number</label>
                                            <label class="form-control" id="lblTSIPassUIDNumber" runat="server"></label>
                                        </div>

                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label2" runat="server">Incentive Application Number</label>
                                            <label class="form-control" id="lblCommonApplicationNumber" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label34" runat="server">Date of Power Connection Release</label>
                                            <label class="form-control" id="lblPowerConnectionReleaseDate" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label7" runat="server">Commencement of Commercial Production</label>
                                            <label class="form-control" id="lblDCPdate" runat="server"></label>
                                        </div>
                                        <div class="col-sm-3 form-group">
                                            <label class="control-label" id="Label6" runat="server">Date of Receipt of Claim Application</label>
                                            <label class="form-control" id="lblReceiptDate" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label9" runat="server">Promoter details in case eligible for additional subsidy</label>
                                            <label class="form-control" id="lblcategory" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <table tyle="width: 100%">
                                            <tr style="height: 30px">
                                                <td colspan="9" style="height: 20px"></td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px">
                                                </td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <b>CLAIM PERIOD</b></td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px">
                                                </td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <asp:Label runat="server" ID="lblClaimPeroid" style="font-weight: bold;">Cliam Peroid</asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>
                                    <div class="row">
                                        <table style="width: 100%">
                                            <tr style="height: 30px">
                                                <td colspan="9" style="height: 20px"></td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 5px; margin: 5px; font-weight: bold; width: 10px">
                                                </td>
                                                <td colspan="4" style="padding: 5px; margin: 5px;">
                                                    <b>ELEGIBLE INCENTIVES</b></td>

                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <table id="tblNewUnit" runat="server"  bgcolor="White" width="100%" style="font-family: Verdana;">
                                                        <tr>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Month-year
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Units Consumed
                                                                                    <br />
                                                                in Nos.
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Amount Paid as per Bill in Rs.
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Eligible rate Re-imbursement<br /> per units
                                                            </th>
                                                            <th style="padding: 10px; margin: 5px; font-weight: bold;">Eligible amount Re-imbursement <br /> per units
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear1New" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear1NewFinyear" CssClass="form-control" AutoPostBack="true"  runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox23" AutoPostBack="true" CssClass="form-control" runat="server" ></asp:TextBox>
                                                            </td>
                                                            
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox25" CssClass="form-control"  runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox21" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear2New" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear2NewFinyear" CssClass="form-control" AutoPostBack="true"  runat="server"></asp:TextBox>
                                                            </td>
                                                           
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox51" AutoPostBack="true" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox52" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox22" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                           
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear3New" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear3NewFinyear" CssClass="form-control" AutoPostBack="true"  runat="server"></asp:TextBox>
                                                            </td>
                                                           
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox64" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox65" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox26" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear4New" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear4NewFinyear" CssClass="form-control" AutoPostBack="true"  runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox71" CssClass="form-control" AutoPostBack="true" runat="server" ></asp:TextBox>
                                                            </td>
                                                           
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox73" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox27" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear5New" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear5NewFinyear" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox79" CssClass="form-control" AutoPostBack="true" runat="server" ></asp:TextBox>
                                                            </td>
                                                            
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox81" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox95" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear6New" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="txt_grdmonthyear6NewFinyear" CssClass="form-control" AutoPostBack="true"  runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox87" CssClass="form-control" AutoPostBack="true" runat="server"></asp:TextBox>
                                                            </td>
                                                            
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox89" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td style="padding: 10px; margin: 5px; font-weight: bold;">
                                                                <asp:TextBox ID="TextBox96" CssClass="form-control" runat="server"></asp:TextBox>
                                                            </td>
                                                            
                                                        </tr>
                                                    </table>
                                                    </table>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label4" runat="server">Total Amount</label>
                                            <label class="form-control" id="Label8" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label10" runat="server">Is Belated</label>
                                             <asp:RadioButtonList ID="RadioButtonList1" CssClass="form-control" AutoPostBack="true" 
                                                 RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Text="Regular" Value="Y"></asp:ListItem>
                                                <asp:ListItem Text="Belated" Value="N"></asp:ListItem>
                                                <asp:ListItem Text="One year" Value="R"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label14" runat="server">Total Eligible Amount :</label>
                                            <label class="form-control" id="Label15" runat="server"></label>
                                        </div>
                                         <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label11" runat="server">GM Recommended Amount :</label>
                                            <label class="form-control" id="Label13" runat="server"></label>
                                        </div>
                                        <div class="col-sm-4 form-group">
                                            <label class="control-label" id="Label16" runat="server">If amount is belated then total Eligible amount for Reiembursement in Rs :</label>
                                            <label class="form-control" id="Label17" runat="server"></label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <table width="100%;">
                                            <tr id="trsubmit" runat="server" visible="true" align="center">
                                                <td colspan="9">

                                                    <asp:Button ID="btnSubmit" CssClass="btn btn-success" runat="server" Text="Submit" />
                                                    &nbsp; &nbsp;<asp:Button ID="btnback" runat="server"
                                                        CssClass="btn btn-warning" TabIndex="10"
                                                        Text="Go to Dashboard" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="9">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                                </div>
                                                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="lblAllwomen" runat="server" />
                                                    <%--<asp:Label ID="lblAllwomen" runat="server" Visible="true" Text="Industry Status"></asp:Label>--%>
                                                </td>

                                            </tr>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField runat="server" ID="hdnApplication" />
            <asp:HiddenField runat="server" ID="hdnActualCategory" />
            <asp:HiddenField runat="server" ID="hdnActualTextile" />
            <asp:HiddenField runat="server" ID="hdnTypeOfIndustry" />
            <asp:HiddenField ID="HiddenFieldEnterpriseCategory" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
