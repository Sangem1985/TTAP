<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmCommonAttachments.aspx.cs" Inherits="TTAP.UI.Pages.frmCommonAttachments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link href="assets/css/basic.css" rel="stylesheet" />

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
            background-image: url("../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .style5 {
            color: #FF0000;
        }
    </style>
     <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <asp:UpdatePanel ID="upd1" runat="server">
       
        <Triggers>
            <asp:PostBackTrigger ControlID="Button201" />
            <asp:PostBackTrigger ControlID="Button202" />
            <asp:PostBackTrigger ControlID="Button203" />
            <asp:PostBackTrigger ControlID="Button204" />
            <asp:PostBackTrigger ControlID="Button205" />
            <asp:PostBackTrigger ControlID="Button206" />
        </Triggers>
        
       
    <ContentTemplate>
    <div align="left">
        <ol class="breadcrumb">
            You are here
        &nbsp;!&nbsp; &nbsp; &nbsp; 
                            <li>
                                <i class="fa fa-dashboard"></i><a href="Home.aspx"></a>
                            </li>
            <li class="">
                <i class="fa fa-fw fa-edit"></i>
            </li>
        </ol>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading" style="background-color: #339966">
                    <table class="nav-justified">
                        <tr>
                            <td style="font-weight: bold;">Common Attachments</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div align="left">
        <div class="row" align="left">
            <div class="col-lg-11">
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                <div class="panel-body" align="left">
                    <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">
                        <tr>
                            <td style="padding: 5px; margin: 5px" valign="top">
                                <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid">                                
                        <tr>
                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; margin: 5px" valign="top">
                                <table cellpadding="4" cellspacing="5" style="width: 100ds
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center; font-weight: bold"></td>
                                        <td colspan="6" style="font: bold; font-weight: bold"></td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">1
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 1500px;" valign="top">Approval of Director of Factories.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; width: 192px; text-align: left;" valign="top">
                                            <asp:DropDownList ID="ddlCSApprovalDirectorFactories" runat="server" AutoPostBack="True" class="form-control txtbox" Height="32px"
                                                MaxLength="40" TabIndex="1" ValidationGroup="group" Width="100px" OnSelectedIndexChanged="ddlCSApprovalDirectorFactories_SelectedIndexChanged">
                                                <asp:ListItem Value="S">--Select--</asp:ListItem>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                <asp:ListItem Value="I">NA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <%-- NumberOnly()--%>
                                        <td style="padding: 5px; margin: 5px; width: 10px;" valign="top">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCSApprovalDirectorFactories" InitialValue="S"
                                                ErrorMessage="Please select File Upload Slno 1" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="width: 50px; vertical-align: top">
                                            <asp:FileUpload ID="FileUpload201" runat="server" Visible="false" />
                                            <asp:Button ID="Button201" runat="server" Visible="false" Text="Click here to Upload" OnClick="Button201_Click" />
                                        </td>
                                        <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                            <asp:HyperLink ID="HyperLink201" runat="server" Visible="false" CssClass="LBLBLACK" Width="100px" Target="_blank"></asp:HyperLink>
                                            <asp:Label ID="Label201" runat="server" Font-Bold="true" ForeColor="Green"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">2
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Boilers Certificate.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:DropDownList ID="ddlCSBoilersCertificate" runat="server" AutoPostBack="True" class="form-control txtbox" Height="32px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="100px" OnSelectedIndexChanged="ddlCSBoilersCertificate_SelectedIndexChanged">
                                                <asp:ListItem Value="S">--Select--</asp:ListItem>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                <asp:ListItem Value="I">NA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlCSBoilersCertificate" InitialValue="S"
                                                ErrorMessage="Please select File Upload Slno 2" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="width: 50px; vertical-align: top">
                                            <asp:FileUpload ID="FileUpload202" runat="server" Visible="false" />
                                            <asp:Button ID="Button202" runat="server" Visible="false" Text="Click here to Upload" OnClick="Button202_Click" />
                                        </td>
                                        <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                            <asp:HyperLink ID="HyperLink202" runat="server" Visible="false" CssClass="LBLBLACK" Width="100px" Target="_blank"></asp:HyperLink>
                                            <asp:Label ID="Label202" runat="server" Font-Bold="true" ForeColor="Green"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">3
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Approval of Director of Town & Country Planning / UDA.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlCSApprovalDirectorTownCountryPlanningUDA" runat="server" AutoPostBack="True" class="form-control txtbox" Height="32px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="100px" OnSelectedIndexChanged="ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged">
                                                <asp:ListItem Value="S">--Select--</asp:ListItem>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                <asp:ListItem Value="I">NA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCSApprovalDirectorTownCountryPlanningUDA" InitialValue="S"
                                                ErrorMessage="Please select File Upload Slno 3" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="width: 50px; vertical-align: top">
                                            <asp:FileUpload ID="FileUpload203" runat="server" Visible="false" />
                                            <asp:Button ID="Button203" runat="server" Visible="false" Text="Click here to Upload" OnClick="Button203_Click" />
                                        </td>
                                        <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                            <asp:HyperLink ID="HyperLink203" runat="server" Visible="false" CssClass="LBLBLACK" Width="100px" Target="_blank"></asp:HyperLink>
                                            <asp:Label ID="Label203" runat="server" Font-Bold="true" ForeColor="Green"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">4
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Regular building plans approval of Municipality or Gram Panchayat.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat" runat="server" AutoPostBack="True" class="form-control txtbox" Height="32px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="100px" OnSelectedIndexChanged="ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged">
                                                <asp:ListItem Value="S">--Select--</asp:ListItem>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                <asp:ListItem Value="I">NA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat" InitialValue="S"
                                                ErrorMessage="Please select File Upload Slno 4" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="width: 50px; vertical-align: top">
                                            <asp:FileUpload ID="FileUpload204" runat="server" Visible="false" Style="height: 22px" />
                                            <asp:Button ID="Button204" runat="server" Visible="false" Text="Click here to Upload" OnClick="Button204_Click" />
                                        </td>
                                        <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                            <asp:HyperLink ID="HyperLink204" runat="server" Visible="false" CssClass="LBLBLACK" Width="100px" Target="_blank"></asp:HyperLink>
                                            <asp:Label ID="Label204" runat="server" Font-Bold="true" ForeColor="Green"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="middle">5
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Consent for Operation from TSPCB/Acknowledgement from the General Manager, DIC concerned.
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:DropDownList ID="ddlCSOperationTSPCBAcknowledgementGM" runat="server" AutoPostBack="True" class="form-control txtbox" Height="32px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="100px" OnSelectedIndexChanged="ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged">
                                                <asp:ListItem Value="S">--Select--</asp:ListItem>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                <asp:ListItem Value="I">NA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlCSOperationTSPCBAcknowledgementGM" InitialValue="S"
                                                ErrorMessage="Please select File Upload Slno 5" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="width: 50px; vertical-align: top">
                                            <asp:FileUpload ID="FileUpload205" runat="server" Visible="false" />
                                            <asp:Button ID="Button205" runat="server" Visible="false" Text="Click here to Upload" OnClick="Button205_Click" />
                                        </td>
                                        <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                            <asp:HyperLink ID="HyperLink205" runat="server" Visible="false" CssClass="LBLBLACK" Width="100px" Target="_blank"></asp:HyperLink>
                                            <asp:Label ID="Label205" runat="server" Font-Bold="true" ForeColor="Green"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: center;" valign="top">6
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">Power release Certificate from TSTRANSCO/DISCOM.
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px" valign="top">
                                            <asp:DropDownList ID="ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM" runat="server" AutoPostBack="True" class="form-control txtbox" Height="32px" MaxLength="40" TabIndex="1" ValidationGroup="group" Width="100px" OnSelectedIndexChanged="ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged">
                                                <asp:ListItem Value="S">--Select--</asp:ListItem>
                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                <asp:ListItem Value="I">NA</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM" InitialValue="S"
                                                ErrorMessage="Please select File Upload Slno 6" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center" style="width: 50px; vertical-align: top">
                                            <asp:FileUpload ID="FileUpload206" runat="server" Visible="false" />
                                            <asp:Button ID="Button206" runat="server" Visible="false" Text="Click here to Upload" OnClick="Button206_Click" />
                                        </td>
                                        <td align="left" class="auto-style1" style="width: 50px; vertical-align: top">
                                            <asp:HyperLink ID="HyperLink206" runat="server" Visible="false" CssClass="LBLBLACK" Width="100px" Target="_blank"></asp:HyperLink>
                                            <asp:Label ID="Label206" runat="server" Font-Bold="true" ForeColor="Green"
                                                Visible="false" />
                                        </td>
                                    </tr>
                                   
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" style="padding: 5px; margin: 5px; text-align: center;"></td>
                        </tr>
                        <tr><td align="center" colspan="3" style="padding: 5px; margin: 5px; text-align: center;">
                                        <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary"  Height="32px"
                                            TabIndex="10" Text="Save" Width="90px" ValidationGroup="group" OnClick="BtnSave_Click" />
                             &nbsp;
                              <asp:Button ID="BtnPrevious" runat="server" CssClass="btn btn-danger"  Height="32px"
                                                        TabIndex="10" Text="Previous" Width="90px" OnClick="BtnPrevious_Click" Visible="true" />
                                        &nbsp;
                                        
                                                    
                                                    
                                        <asp:Button ID="BtnNext" runat="server" CssClass="btn btn-danger"  Height="32px"
                                                        TabIndex="10" Text="Next" Width="90px"  OnClick="BtnNext_Click" />

                                        &nbsp; &nbsp;<asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                             Height="32px" TabIndex="10" Text="ClearAll" ToolTip="To Clear  the Screen"
                                            Width="90px" OnClick="BtnClear_Click" />

                            </td></tr>
                        
                        <tr>
                            <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                    <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                    <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:HiddenField ID="hdfID" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                    ShowSummary="False" ValidationGroup="group" />

                            </td>
                        </tr>
                    </table>
                </div>
                <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                <%--  </div>--%>
            </div>
        </div>
    </div>
         </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="upd1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />    
</asp:Content>
