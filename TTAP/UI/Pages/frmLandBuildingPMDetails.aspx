<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLandBuildingPMDetails.aspx.cs" Inherits="TTAP.UI.Pages.frmLandBuildingPMDetails" %>

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
    <%--  <link href="../../AssetsNew/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />--%>


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
    <%-- <script type="text/javascript">
        $(function () {
            $('#datetimepicker').datetimepicker();
        });
        </script>--%>
    <script type="text/javascript">

        function myFunction() {
            document.getElementById("DivPrint").style.display = "none";
            window.print();
            document.getElementById("DivPrint").style.display = "block";
        }
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
        function inputOnlyDecimals(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            //            if ((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) {
            //                return true;
            //            }
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 47) {
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
                <asp:PostBackTrigger ControlID="btnPandMAdd" />
                <asp:PostBackTrigger ControlID="btnpmpaymentAdd" />
            </Triggers>
            <ContentTemplate>
                <div class="main">
                    <div id="content">
                        <div id="content-header">
                            <div class="breadcrumb-bg">
                            </div>
                        </div>
                        <div class="container mt-4 pb-4" runat="server">
                            <%--<div class="w-100 px-3 frm-form box-content py-3 font-medium title5">--%>
                            <div class="w-100 px-3 frm-form py-3 font-medium title5" runat="server" id="divheader">
                                <div class="row-fluid">
                                    <div class="widget-box">
                                        <div class="widget-title">
                                            <span class="icon">
                                                <i class="icon-info-sign"></i>
                                            </span>
                                            <div class="row">
                                                <h4 class="text-black mb-3 col font-SemiBold text-center" runat="server" id="h3heading">Land & Building Details</h4>
                                            </div>
                                        </div>
                                        <div class="widget-content nopadding">
                                            <div class="row">

                                                <div class="col-sm-12 text-blue label-required font-SemiBold">Land Details</div>
                                            </div>
                                            <div class="row" id="Div1" runat="server">
                                                <div class="col-sm-11 table-responsive">
                                                    <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                        <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                            <th>S.No</th>
                                                            <th>Type of Land</th>
                                                            <th>Extent in Acre</th>
                                                            <th>Cost Per Acre (In Rs)</th>
                                                            <th>Value Of Land (In Rs)</th>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>1</td>
                                                            <td align="left">Purchased Land </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtPLExtent" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)" AutoPostBack="True" OnTextChanged="txtPLExtent_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtPLValue" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)" AutoPostBack="True" OnTextChanged="txtPLValue_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblPLTotalValue" runat="server" class="form-control"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item2">
                                                            <td>2</td>
                                                            <td align="left">Leased Land</td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtLLExtent" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)" AutoPostBack="True" OnTextChanged="txtLLExtent_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtLLValue" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)" AutoPostBack="True" OnTextChanged="txtLLValue_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblLLTotalValue" runat="server" class="form-control"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>3</td>
                                                            <td align="left">Inhertied Land</td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtILExtent" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)" AutoPostBack="True" OnTextChanged="txtILExtent_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtILValue" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)" AutoPostBack="True" OnTextChanged="txtILValue_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblILTotalValue" runat="server" class="form-control"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item2">
                                                            <td>4</td>
                                                            <td align="left">Govt Land (TSIIC developed IEs/IDA/Industrial Parks)</td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtGLExtent" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)" AutoPostBack="True" OnTextChanged="txtGLExtent_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtGLValue" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)" AutoPostBack="True" OnTextChanged="txtGLValue_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblGLTotalValue" runat="server" class="form-control"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-12 text-blue label-required font-SemiBold">Buliding Details</div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-6 form-group">
                                                    <label class="control-label label-required">Buliding Type</label>
                                                    <asp:RadioButtonList ID="rdl_Buliding_Type" Enabled="false" runat="server" CssClass="radio-inline" RepeatDirection="Horizontal">
                                                        <asp:ListItem Text="Constructed" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Leased" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Rented" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="Hired" Value="3"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <%-- Building --%>
                                            <div class="row" id="Div2" runat="server">
                                                <div class="col-sm-11 table-responsive">
                                                    <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                        <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                            <th>S.No</th>
                                                            <th>Item of Civil works</th>
                                                            <th>Plinth Area (In Square Meters)</th>
                                                            <th>Cost (In Rs)</th>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>1</td>
                                                            <td align="left">Main Factory Shed </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtMFSArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtMFSCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item2">
                                                            <td>2</td>
                                                            <td align="left">Warehouse for Raw Material and finished goods </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtWarehouseArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtWarehouseCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>3</td>
                                                            <td align="left">Office room and Lab room </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtOfficeArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtOfficeCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>4</td>
                                                            <td align="left">Cooling water ponds </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtCWPArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtCWPCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>5</td>
                                                            <td align="left">Boiler shed and generator room </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtBoilerArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtBoilerCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>6</td>
                                                            <td align="left">Effluent treatment ponds etc. </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtETPArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtETPCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>7</td>
                                                            <td align="left">Overhead Tank,bore-wells and pump house and sump </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtOTArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtOTACost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>8</td>
                                                            <td align="left">Fencing and Gate </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtFGArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtFGCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>9</td>
                                                            <td align="left">Architect fee and supervision charges </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtAFArea" runat="server" ReadOnly="true" Enabled="false" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtAFCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>10</td>
                                                            <td align="left">Compound wall </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtCWArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtCWCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>11</td>
                                                            <td align="left">Workers Quarters/ workers housing </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtWQArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtWQCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>12</td>
                                                            <td align="left">Canteen </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtCanteenArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtCanteenCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>13</td>
                                                            <td align="left">Rest House </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtRHArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtRHCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>14</td>
                                                            <td align="left">Time Office </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtTOArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtTOCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>15</td>
                                                            <td align="left">Cycle/Vehicle Stand </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtCSArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtCSCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>16</td>
                                                            <td align="left">Security Shed </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtSSArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtSSCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>17</td>
                                                            <td align="left">Toilet room and sanitary fittings </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtToiletArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtToiletCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr class="GridviewScrollC1Item">
                                                            <td>18</td>
                                                            <td align="left">Roads with in factory premises </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtRoadsArea" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                            <td align="center">
                                                                <asp:TextBox ID="txtRoadsCost" runat="server" class="form-control" onkeypress="return inputOnlyDecimals(event)"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div id="card" runat="server" visible="false">
                                                <div id="DivPMDtls" runat="server">
                                                    <div class="row" id="DivMachineryDetails1" runat="server">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px; margin-bottom: 10px;">
                                                            Plant and Machinery Details
                                                        </div>
                                                    </div>
                                                    <div class="row m-0" id="DivMachineryDetails" runat="server">
                                                        <div class="row">
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Name of the Machine</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtMachineName" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Name of the Vendor</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtVendorName" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Type of the Machine</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:RadioButtonList ID="rdlMachineType" runat="server" RepeatDirection="Horizontal" CssClass="spaced123" AutoPostBack="true" OnSelectedIndexChanged="rdlMachineType_SelectedIndexChanged">
                                                                    <asp:ListItem Text="Imported" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Local" Value="2" Selected="True"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Name of the Manufacturer</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtManufacturerName" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-12 form-group">
                                                                <div class="row m-0" id="divImported" runat="server" visible="false">
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Entire/Parts of Machine</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:RadioButtonList ID="RdlMachinaryParts" runat="server" RepeatDirection="Horizontal" CssClass="spaced123">
                                                                            <asp:ListItem Text="Entire Machine" Value="1" Selected="True"></asp:ListItem>
                                                                            <asp:ListItem Text="Parts of Machinery" Value="2"></asp:ListItem>
                                                                        </asp:RadioButtonList>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Country Name</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtCustomCountryName" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Custom Paid(In Rs.)</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtCustomPaid" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Import duty(In Rs.)</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtImportduty" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label">
                                                                            Port charges(In Rs.)</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtportcharges" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label">
                                                                            Statutory taxes etc (In Rs.)</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtstatutorytaxesetc" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Amount of the Machine (in foreign currency)</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:TextBox ID="txtCostoftheMachineforeign" runat="server" onkeypress="DecimalOnly()" class="form-control"></asp:TextBox>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <label class="control-label label-required">
                                                                            Foreign Currency</label>
                                                                    </div>
                                                                    <div class="col-sm-3 form-group">
                                                                        <asp:DropDownList ID="ddlForeignCurrency" runat="server" class="form-control">
                                                                            <asp:ListItem Text="--Select--" Value="0" Selected="False"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Installed Machinery
                                                                </label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:RadioButtonList ID="RbtnInstalledMachinery" runat="server" RepeatDirection="Horizontal" CssClass="spaced123" AutoPostBack="True" OnSelectedIndexChanged="RbtnInstalledMachinery_SelectedIndexChanged">
                                                                    <asp:ListItem Text="New" Selected="True" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Secondhand" Value="2"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>
                                                            <div class="col-sm-3 form-group" id="divInstalledMachinerytype" runat="server">
                                                                <label class="control-label label-required">
                                                                    Installed Machinery Type
                                                                </label>
                                                            </div>
                                                            <div class="col-sm-3 form-group" id="divInstalledMachinerytype1" runat="server">
                                                                <asp:RadioButtonList ID="rbtnInstalledMachinerytype" runat="server" RepeatDirection="Horizontal" CssClass="spaced123">
                                                                    <asp:ListItem Text="Unassembled" Selected="True" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Assembled" Value="2"></asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </div>

                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Invoice Number</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtInvoiceNo" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Invoice Date</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtInvoiceDate" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Shipping Date
                                                                </label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtInitiationDate" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Machine Landing Date</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtMachineLoadingDate" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Way Bill Number</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtVaivleNo" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Way Bill Date</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtVaivleDate" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Actual Cost of the Machine(In Rs.)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtActMachineCost" runat="server" class="form-control" onblur="return Calculate();" onkeypress="DecimalOnly()"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Freight Charges(In Rs.)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtFreightCharges" runat="server" class="form-control" onkeypress="DecimalOnly()" onblur="return Calculate();"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Transport Charges(In Rs.)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtTransportCharges" runat="server" class="form-control" onkeypress="DecimalOnly()" onblur="return Calculate();"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    CGST(In Rs.)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtcgst" runat="server" class="form-control" onkeypress="DecimalOnly()" onblur="return Calculate();"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    SGST(In Rs.)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtsgst" runat="server" class="form-control" onkeypress="DecimalOnly()" onblur="return Calculate();"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    IGST(In Rs.)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtigst" runat="server" class="form-control" onkeypress="DecimalOnly()" onblur="return Calculate();"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Total GST Paid(In Rs.)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txttotalGst" ReadOnly="true" runat="server" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
                                                            </div>

                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Cost of the Machine(In Rs.)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtCostofMachine" runat="server" class="form-control" ReadOnly="true" onkeypress="DecimalOnly()"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Eligibility Category of Plant and Machinery</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:DropDownList ID="ddlEligibility" runat="server" class="form-control">
                                                                    <asp:ListItem Text="--Select--" Value="0" Selected="False"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3 form-group" id="divPMunitType" runat="server" visible="false">
                                                                <label class="control-label label-required">
                                                                    Classification of Machinery
                                                                </label>
                                                            </div>
                                                            <div class="col-sm-3 form-group" id="divPMunitType1" runat="server" visible="true">
                                                                <asp:DropDownList ID="ddlpmtype" runat="server" class="form-control">
                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Textile Products(TP)" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="Non Textile Products(NTP)" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label">
                                                                    Remarks(if required)</label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtReqRemarks" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div runat="server" id="divPrevcost" visible="true" class="col-sm-3 form-group">
                                                                <label class="control-label">
                                                                    Prevoius Cost of the Machine</label>
                                                            </div>
                                                            <div runat="server" id="divPrevcosttxt" visible="true" class="col-sm-3 form-group">
                                                                <asp:TextBox ID="txtPrvCostOftheMachine" runat="server" ReadOnly="true" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
                                                            </div>
                                                            <div>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required">Invoice Bills (Pdf Only)</label>
                                                                <asp:FileUpload ID="fuInvoiceBills" runat="server" CssClass="file-browse" />
                                                                <asp:HyperLink ID="hyInvoiceBills" Visible="false" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                            </div>
                                                            <div class="col-sm-6 form-group">
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-12 text-center">
                                                            <asp:Button Text="Add New" CssClass="btn btn-blue mx-2" ID="btnPandMAdd" runat="server" OnClick="btnPandMAdd_Click" />
                                                            <asp:Button ID="btnmachinaryclear" runat="server" CssClass="btn btn-warning mx-2" Text="Cancel" ToolTip="Clear " />
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" style="height: 300px !important">
                                                        <asp:GridView runat="server" ID="grdPandM" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                            CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                            OnRowCommand="grdPandM_RowCommand" OnRowDataBound="grdPandM_RowDataBound">
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
                                                                <asp:TemplateField HeaderText="Machine Cost (In Rs)">
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
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Invoice">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="hyFilePathMerge2" Text="view" NavigateUrl='<%#Eval("FilePathMerge2")%>' Target="_blank" runat="server" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-warning" OnClick="btnEdit_Click" Enabled='<%# Eval("Is_Allow_Modify").ToString() == "Y" ? true : false %>'></asp:Button>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" runat="server" Text="Delete" CssClass="btn btn-warning" Enabled='<%# Eval("Is_Allow_Modify").ToString() == "Y" ? true : false %>' OnClick="btnDelete_Click"></asp:Button>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField Visible="true" HeaderText="Cost Edit">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnEditCost" runat="server" Text="Edit Cost" CssClass="btn btn-warning" OnClick="btnEditCost_Click" Enabled='<%# Eval("Allow_PM_Cost_Edit").ToString() == "Y" ? true : false %>'></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label" id="Label2" runat="server">Actual Total Value of New Machinery (in Rs)</label>
                                                            <label class="form-control" id="lblTotalValueofNewMachinery" runat="server"></label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label" id="Label3" runat="server">Actual Total value of 2nd hand machinery (in Rs)</label>
                                                            <label class="form-control" id="lblSecondhandmachinery" runat="server"></label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label" id="Label22" runat="server">Actual Total value of machinery (in Rs)</label>
                                                            <label class="form-control" id="lblTotalvaluemachinery" runat="server"></label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label" id="Label23" runat="server">2nd hand machinery %</label>
                                                            <label class="form-control" id="lblsechandmachineryPer" runat="server"></label>
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
                                                            <label class="control-label" id="Label13" runat="server">Total value of machinery (in Rs)</label>
                                                            <label class="form-control" id="lblTotalValueofAllTextileProducts" runat="server"></label>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label" id="Label26" runat="server">Textile Products (%)</label>
                                                            <label class="form-control" id="lblValueofTextileProductsPercentage" runat="server"></label>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label" id="Label14" runat="server">Non Textile products (%)</label>
                                                            <label class="form-control" id="lblValueofNonTextileProductsPercentage" runat="server"></label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div id="divPMPaymentDetails" runat="server" visible="true">
                                                <div id="card">
                                                    <div class="row">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px; margin-bottom: 10px;">
                                                            PM Payemnt Details
                                                        </div>
                                                    </div>
                                                    <div class="row m-0" id="divPMPaymentDetails1" runat="server">
                                                        <div class="row">
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required" id="Label28" runat="server">Plant & Machinary</label>
                                                                <asp:DropDownList ID="ddlPlantMachinaryPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlPlantMachinaryPayment_SelectedIndexChanged">
                                                                    <%--<asp:ListItem Text="--Select--" Value="0"></asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Original Machinary Cost</label>
                                                                <label class="form-control  font-bold" id="lblPMMachinaryCost" runat="server"></label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Transaction Details Updated for the Cost of Rs.</label>
                                                                <label class="form-control  font-bold" id="lblPMCostUpdated" runat="server"></label>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Yet to Update the Transaction Details for the Cost of Rs.</label>
                                                                <label class="form-control font-bold" id="lblYetPMCostUpdate" runat="server"></label>
                                                            </div>

                                                            <div class="col-sm-3 form-group" id="divRegistredTrnsactionID" runat="server" visible="false">
                                                                <label class="control-label label-required" id="Label31" runat="server">Registred Trnsaction ID</label>
                                                                <asp:DropDownList ID="ddlPMTrnsactionIDPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlPMTrnsactionIDPayment_SelectedIndexChanged">
                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3 form-group" id="divRegistredTrnsactionID1" runat="server" visible="false">
                                                                <label class="control-label label-required">Used Transaction Amount Rs.</label>
                                                                <label class="form-control font-bold" id="lblUsedTransactionAmount" runat="server"></label>
                                                            </div>
                                                            <div class="col-sm-3 form-group" id="divRegistredTrnsactionID2" runat="server" visible="false">
                                                                <label class="control-label label-required">
                                                                    Pending Transaction Amount Rs.</label>
                                                                <label class="form-control font-bold" id="lblPendingTransactionAmount" runat="server"></label>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Trnsaction ID</label>
                                                                <asp:TextBox ID="txtTrnsactionID" runat="server" CssClass="form-control" MaxLength="30" TabIndex="5"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Trnsaction Date</label>
                                                                <asp:TextBox ID="txtPMPaymentTrnsactionDate" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Remitting bank</label>
                                                                <asp:TextBox ID="txtremittingbank" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Beneficiary bank</label>
                                                                <asp:TextBox ID="txtbeneficiarybank" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Trnsaction  Amount (In Rs.)</label>
                                                                <asp:TextBox ID="txtPmtransactionAmount" runat="server" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">
                                                                    Machinary Cost Included (In Rs.)</label>
                                                                <asp:TextBox ID="txtPMMachinaryCost" runat="server" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required">Payment Proof (Pdf Only)</label>
                                                                <asp:FileUpload ID="FUPMPaymentProof" runat="server" CssClass="file-browse" />
                                                                <asp:HyperLink ID="HypmPaymentProof" Visible="false" runat="server" Text="View" CssClass="form-control text-success font-weight-bold" Target="_blank"></asp:HyperLink>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-12 text-center">
                                                            <asp:Button Text="Add New" CssClass="btn btn-blue mx-2" ID="btnpmpaymentAdd" runat="server" OnClick="btnpmpaymentAdd_Click" />
                                                            <asp:Button ID="btnpmpaymentclear" runat="server" CssClass="btn btn-warning mx-2" Text="Cancel" ToolTip="Clear " OnClick="btnpmpaymentclear_Click" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" style="height: 300px">
                                                        <asp:GridView ID="GvPMPaymentDtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="GvPMPaymentDtls_RowCommand">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No" ItemStyle-Width="50px">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPMTMId" runat="server" Text='<%# Bind("PMTMId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="P&M ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPMId" runat="server" Text='<%# Bind("PMId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Trnsaction ID">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPMTrnsactionID" runat="server" Text='<%# Bind("PMTrnsactionID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Trnsaction Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTrnsactionDate" runat="server" Text='<%# Bind("TrnsactionDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remitting bank">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRemittingbank" runat="server" Text='<%# Bind("Remittingbank") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Beneficiary bank">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblBeneficiarybank" runat="server" Text='<%# Bind("Beneficiarybank") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Transaction Amount">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTrnsactionAmount" runat="server" Text='<%# Bind("TrnsactionAmount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Machinary Trnsaction Amount">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPMAmount" runat="server" Text='<%# Bind("PMAmount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Machinary Original Cost">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblMachineCost" runat="server" Text='<%# Bind("MachineCost") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Attachment">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="hyFilePathMerge" Text="view" NavigateUrl='<%#Eval("FilePath")%>' Target="_blank" runat="server" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" Enabled='<%# Eval("Is_Allow_Modify").ToString() == "Y" ? true : false %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PMAbstractID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPMTMIdNew" Visible="false" runat="server" Text='<%# Bind("PMTMId") %>'></asp:Label>
                                                                        <asp:Label ID="lblPMPFIdNew" Visible="false" runat="server" Text='<%# Bind("PMPFId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-sm-12 text-blue label-required font-SemiBold">Other Details</div>
                                            </div>
                                            <div class="row" id="divNewIndustry" runat="server" visible="false">
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label8" runat="server">Laboratories for Research & Quality Control (In Rs)</label>
                                                    <asp:TextBox ID="txtLaboratoriesforResearchQualityControl" AutoPostBack="true" class="form-control" onkeypress="DecimalOnly()" runat="server" OnTextChanged="txtLaboratoriesforResearchQualityControl_TextChanged"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label9" runat="server">Utilities – Power, Water (In Rs)</label>
                                                    <asp:TextBox ID="txtUtilitiesPowerWater" class="form-control" AutoPostBack="true" onkeypress="DecimalOnly()" runat="server" OnTextChanged="txtLaboratoriesforResearchQualityControl_TextChanged"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label10" runat="server">Other Fixed Assets (In Rs)</label>
                                                    <asp:TextBox ID="txtOtherFixedAssets" class="form-control" AutoPostBack="true" onkeypress="DecimalOnly()" runat="server" OnTextChanged="txtLaboratoriesforResearchQualityControl_TextChanged"></asp:TextBox>
                                                </div>
                                                <div class="col-sm-3 form-group">
                                                    <label class="control-label" id="Label11" runat="server">Total (In Rs)</label>
                                                    <asp:TextBox ID="txtTotal" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row" id="divExpIndustry" runat="server" visible="false">
                                                <div class="col-sm-8 form-group">
                                                    <label class="control-label" id="Label1" runat="server">New Technologies for textile processing, enhancement of capacities or diversification (In Rs)</label>
                                                    <asp:TextBox ID="txtNewTechnologiesfortextileprocessing" AutoPostBack="true" class="form-control" onkeypress="DecimalOnly()" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-sm-11 form-group" align="center">
                                                    <asp:Button Text="Save" CssClass="btn btn-blue px-4 title5" ID="btnSave" runat="server" OnClick="btnSave_Click" />
                                                    <%-- <asp:Button Text="Close" CssClass="btn btn-blue px-4 title5" ID="btnClose" runat="server" />--%>
                                                </div>
                                            </div>
                                            <table style="width: 100%; text-align: center">
                                                <tr>
                                                    <td align="center" colspan="3" style="padding: 5px; margin: 5px">
                                                        <div id="success" runat="server" visible="false" class="alert alert-success">
                                                            <a href="AddQualification.aspx" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong></strong>
                                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                            </div>
                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hdnUserID" runat="server" />
                <asp:HiddenField ID="hdnUIDNo" runat="server" />
                 <asp:HiddenField ID="hdnPMCostEdit" runat="server" />
                <asp:HiddenField ID="hdnMachineCostN" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>

    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../NewCss/js/excanvas.min.js"></script>
    <script src="../../NewCss/js/jquery.ui.custom.js"></script>
    <script src="../../NewCss/js/bootstrap.min.js"></script>
    <script src="../../NewCss/js/jquery.flot.min.js"></script>
    <script src="../../NewCss/js/jquery.flot.resize.min.js"></script>
    <script src="../../NewCss/js/jquery.peity.min.js"></script>
    <script src="../../NewCss/js/maruti.js"></script>
    <script src="../../NewCss/js/maruti.dashboard.js"></script>
    <script src="../../NewCss/js/maruti.chat.js"></script>
    <%-- <script src="Scripts/bootstrap.min.js"></script>
        <script src="../../Scripts/jquery-3.3.1.min.js"></script>
        <script src="../../Scripts/jquery-3.3.1.js"></script>
        <script src="../../AssetsNew/js/bootstrap-datetimepicker.min.js"></script>--%>
    <script type="text/javascript">
        // This function is called from the pop-up menus to transfer to
        // a different page. Ignore if the value returned is a null string:
        function goPage(newURL) {

            // if url is empty, skip the menu dividers and reset the menu selection to default
            if (newURL != "") {

                // if url is "-", it is this page -- reset the menu:
                if (newURL == "-") {
                    resetMenu();
                }
                // else, send page to designated URL            
                else {
                    document.location.href = newURL;
                }
            }
        }

        // resets the menu selection upon entry to this page:
        function resetMenu() {
            document.gomenu.selector.selectedIndex = 2;
        }
    </script>
    <script src="../../AssetsNew/js/popper.min.js"></script>
    <script src="../../AssetsNew/js/bootstrap.min.js"></script>
    <script src="../../AssetsNew/js/floating.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $(function () {
                var url = window.location.pathname,
                    urlRegExp = new RegExp(url.replace(/\/$/, '') + "$");
                // now grab every link from the navigation
                $('.navbar a, footer a').each(function () {
                    // and test its normalized href against the url pathname regexp
                    if (urlRegExp.test(this.href.replace(/\/$/, ''))) {
                        $(this).addClass('active');
                    }
                });
            });
        });
    </script>

    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script type="text/javascript">

        $("input[id$='txtDateAvailed']").keydown(function () {
            return false;
        });

        $("input[id$='txtPMPaymentTrnsactionDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[type=text]").attr('autocomplete', 'off');

            $("input[id$='ContentPlaceHolder1_txtDateAvailed']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='txtMachineLoadingDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtVaivleDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='txtInitiationDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='txtInvoiceDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='txtPMPaymentTrnsactionDate']").datepicker(
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

            $("input[id$='ContentPlaceHolder1_txtDateAvailed']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='txtMachineLoadingDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                }); // Will run at every postback/AsyncPostback
            $("input[id$='txtVaivleDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='txtInitiationDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='txtInvoiceDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='txtPMPaymentTrnsactionDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });
         function Calculate() {
            
            var ActualMachineCost = 0, FreightCharges = 0, TransportCharges = 0, Cgst = 0, Sgst = 0, Igst = 0;
            if ($('#txtActMachineCost').val() != "") {
                ActualMachineCost = parseFloat($('#txtActMachineCost').val());
            }
            if ($('#txtFreightCharges').val() != "") {
                FreightCharges = parseFloat($('#txtFreightCharges').val());
            }
            if ($('#txtTransportCharges').val() != "") {
                TransportCharges = parseFloat($('#txtTransportCharges').val());
            }
            if ($('#txtcgst').val() != "") {
                Cgst = parseFloat($('#txtcgst').val());
            }
            if ($('#txtsgst').val() != "") {
                Sgst = parseFloat($('#txtsgst').val());
            }
            if ($('#txtigst').val() != "") {
                Igst = parseFloat($('#txtigst').val());
            }

            $('#txttotalGst').val(Cgst + Sgst + Igst);
            $('#txtCostofMachine').val(ActualMachineCost + FreightCharges + TransportCharges + Cgst + Sgst + Igst);
            $('#hdnMachineCostN').val(ActualMachineCost + FreightCharges + TransportCharges + Cgst + Sgst + Igst);
            
        }
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
</body>
</html>
