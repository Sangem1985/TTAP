<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormOTPCheck.aspx.cs" Inherits="TTAP.UI.Pages.FormOTPCheck" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department of Handlooms & Textiles | Government of Telangana</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <%--Added by Pramod--%>
    <link rel="stylesheet" href="../../AssetsNew/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/style.css" />
    <link rel="stylesheet" href="../../AssetsNew/css/media.css" />

    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>
    
    <style>
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .main {
            min-height: 595px;
            min-height: 75.4vh;
            /*background: #f3f8ff;*/
        }

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        #collapsibleNavbar .navbar-nav.d-flex.w-50.m-auto {
            margin: 0px !important;
        }

        div#ContentPlaceHolder1_Receipt, .container.mt-4.pb-4, .col-sm-12.offset-md-1.col-md-10.col-lg-10.offset-lg-1.p-4.pb-0.mt-3.frm-form.box-content {
            max-width: 1165px !important;
        }

        div#card {
            padding: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
            margin: 10px 0px 0px 0px;
            border: 1px solid #000;
        }
    </style>
   
    <script type="text/javascript">

        
    </script>
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
    </script>
</head>
<body>
   <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="toolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="updatepnl">
            <ProgressTemplate>
                <div class="update">
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="updatepnl" runat="server" UpdateMode="Conditional">
            <Triggers>
                <%--<asp:PostBackTrigger ControlID="btnPandMAdd" />--%>
            </Triggers>
            <ContentTemplate>
                <div class="main">
                    <div id="content">
                        <div id="content-header">
                            <div class="breadcrumb-bg">
                            </div>
                        </div>
                        <div class="container mt-4 pb-4" runat="server">
                            <div class="w-100 px-3 frm-form py-3 font-medium title5" runat="server" id="divheader">
                                <div class="row-fluid">
                                    <div class="widget-box">
                                        <div class="widget-title">
                                            <span class="icon">
                                                <i class="icon-info-sign"></i>
                                            </span>
                                            <div class="row">
                                                <h4 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Mobile Number Correction</h4>
                                            </div>
                                        </div>
                                        <div class="widget-content nopadding">
                                            <div class="row">
                                                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                                            </div>
                                           
                                            <div class="row">
                                                <div class="col-sm-11 form-group" align="center">
                                                    <asp:Button Text="Save" CssClass="btn btn-blue px-4 title5" ID="btnSave" runat="server" />
                                                </div>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <asp:HiddenField ID="hdnUIDNo" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
