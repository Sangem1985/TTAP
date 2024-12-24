<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="PlantandMachinerySearch.aspx.cs" Inherits="TTAP.UI.Pages.PlantandMachinerySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>
    <style>
        /* Fix table head */
        .tableFixHead {
            overflow: auto;
        }

            .tableFixHead th {
                position: sticky;
                top: 0;
            }

        /* Just common table stuff. */
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px 16px;
        }

        th {
            /*background: #eee;*/
        }

        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }
    </style>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        </Triggers>
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Plant and Machinary</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Plant and Machinary</li>
                        </ul>
                    </div>

                </div>
                <div class="container-fluid mt-4 pb-4" id="Receipt" runat="server">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">

                        <div class="widget-content nopadding">
                            <div>

                                <div class="col-sm-6 form-group">
                                    <table>
                                        <div id="divDtls" runat="server">
                                            <tr runat="server" id="trUnitName">
                                                <td>
                                                    <asp:Label runat="server">Application No</asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtApplicationNumber" placeholder="Enter Application No" class="form-control" Width="100%" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <input type="button" id="btn" value="Search" class="btn btn-success  m-2" onclick="return GetPlantMachinary()" />
                                                </td>
                                                
                                            </tr>
                                            <tr runat="server" style="display: none;" id="tr1" onchange="return ChangePlaceholder();">
                                                <td>
                                                    <asp:DropDownList runat="server" ID="ddlSearch" class="form-control">
                                                        <asp:ListItem Selected="True" Value="PMID">PMID</asp:ListItem>
                                                        <asp:ListItem Value="MachineName">MachineName</asp:ListItem>
                                                        <asp:ListItem Value="InvoiceNo">InvoiceNo</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td id="td2" style="display: none;">
                                                    <asp:TextBox ID="txts" Width="100%" placeholder="Enter PMId" onkeyup="return FilterService();" class="form-control" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <a id="A2" href="#" onclick="return Export();" runat="server" style="float: left;display:none">
                                                        <img src="../../../images/Excel-icon.png" width="30px" height="30px"
                                                            alt="Excel" /></a>
                                                </td>
                                            </tr>
                                        </div>
                                    </table>
                                </div>
                                <div id="divMain">
                                    <h5 id="Header" style="text-align: center;font-family: 'Montserrat-SemiBold';color: crimson;">CHANIKYA HANDLOOMS</h5>
                                    <div class="tableFixHead" id="divpopupdata" style="height: 300px !important" runat="server">
                                        <table id="tbldata" class="table table-bordered" style="margin: 10px 0px 0px 4px; width: 99%;">
                                            <thead>
                                                <tr>
                                                    <th align="left">S No</th>
                                                    <th align="left">PM Id</th>
                                                    <th align="left">Machine Name</th>
                                                    <th align="left">Vendor Name</th>
                                                    <th align="left">Type of Machine</th>
                                                    <th align="left">Entire/Parts of Machine</th>
                                                    <th align="left">Custom Country</th>
                                                    <th align="left">Custom Paid (Rs.)</th>
                                                    <th align="left">Import Duty (Rs.)</th>
                                                    <th align="left">Port Charges (Rs.)</th>
                                                    <th align="left">Statutory Taxes(Rs.)</th>
                                                    <th align="left">Installed Machinery</th>
                                                    <th align="left">InstalledcMachinery Type</th>
                                                    <th align="left">Manufacturer Name</th>
                                                    <th align="left">Invoice No</th>
                                                    <th align="left">Invoice Date</th>
                                                    <th align="left">Shipping Date</th>
                                                    <th align="left">Machine Landing Date</th>
                                                    <th align="left">Way Bill Number</th>
                                                    <th align="left">Way Bill Date</th>
                                                    <th align="left">Actual Machine Cost(Rs.)</th>
                                                    <th align="left">Freight Charges(Rs.)</th>
                                                    <th align="left">Transport Charges(Rs.)</th>
                                                    <th align="left">Cgst(Rs.)</th>
                                                    <th align="left">Sgst(Rs.)</th>
                                                    <th align="left">Igst(Rs.)</th>
                                                    <th align="left">Total Machine Cost(Rs.)</th>
                                                    <th align="left">Foreign Machine Cost(In Foreign Currency)</th>
                                                    <th align="left">Foreign Currency</th>
                                                    <th align="left">Eligibility Category</th>
                                                    <th align="left">Classification of Machinery</th>
                                                    <th align="left">Phase</th>
                                                    <th align="left">View Invoice</th>
                                                </tr>
                                            </thead>
                                            <tbody></tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnIncentiveId" runat="server" />
            <asp:HiddenField ID="hdnSubIncentiveId" runat="server" />
            <asp:HiddenField ID="hdnUserId" runat="server" />
            <asp:HiddenField ID="hdnUnitId" runat="server" />
            <asp:HiddenField ID="hdnRolecode" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <link href="../../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../NewCss/js/jquery.min.js"></script>
    <script src="../../Js/table2excel.js"></script>
    <style type="text/css">
        
    </style>
    <script type="text/javascript">
        
        function GetPlantMachinary() {
            $('#ContentPlaceHolder1_UpdateProgress').show();
            $('#divMain').hide();
            $('#ContentPlaceHolder1_tr1').hide();
            $('#ContentPlaceHolder1_td2').hide();
            $('#ContentPlaceHolder1_A2').hide();
            $('#tbldata tbody').empty();
            var ApNo = $('#ContentPlaceHolder1_txtApplicationNumber').val();
            $.ajax({
                type: "POST",
                url: "PlantandMachinerySearch.aspx/GetPlantMachinary",
                data: '{AppNo:"' + ApNo + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: ViewClick,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        function ViewClick(response) {
            var Data = $.parseJSON(response.d);
            if (Data.length > 0) {
                UnitName = Data[0].UnitName;
                $('#Header').text(Data[0].UnitName);
                for (var i = 0; i < Data.length; i++) {
                    var _tr1 = '<tr class=Drag id=' + i + '><td>' + (i + 1) + ' </td><td><span id=lblpmid>' + Data[i].PMId + '</span></td><td><span id=lblmachinename>' + Data[i].MachineName +
                        '</span></td><td><label >' + Data[i].VendorName + '</label></td><td><label >' + Data[i].TypeofMachine +
                        '</label></td><td><label >' + Data[i].MachinaryPartstext + '</label></td><td><label >' + Data[i].CustomCountry + '</label></td><td><label >' + Data[i].CustomPaid +
                        '</label></td><td><label >' + Data[i].Importduty + '</label></td><td><label >' + Data[i].Portcharges + '</label></td><td><label >' + Data[i].Statutorytaxes +
                        '</label></td><td><label >' + Data[i].InstalledMachineryText + '</label></td><td><label >' + Data[i].InstalledMachinerytypetext + '</label></td><td><label >' + Data[i].ManufacturerName +
                        '</label></td><td><span id=lblinvoiceno>' + Data[i].InvoiceNo + '</span></td><td><label >' + Data[i].InvoiceDate + '</label></td><td><label >' + Data[i].IntiationDate +
                        '</label></td><td><label >' + Data[i].MahineLandingDate + '</label></td><td><label >' + Data[i].VaivleNo + '</label></td><td><label >' + Data[i].VaivleDate +
                        '</label></td><td><label >' + Data[i].ActualMachineCost + '</label></td><td><label >' + Data[i].FreightCharges + '</label></td><td><label >' + Data[i].TransportCharges +
                        '</label></td><td><label >' + Data[i].Cgst + '</label></td><td><label >' + Data[i].Sgst + '</label></td><td><label >' + Data[i].Igst +
                        '</label></td><td><label >' + Data[i].MachineCost + '</label></td><td><label >' + Data[i].ForeignMachineCost + '</label></td><td><label >' + Data[i].ForeignCurrency +
                        '</label></td><td><label >' + Data[i].Eligibility + '</label></td><td><label >' + Data[i].ClassificationMachineryText +
                        '</label></td><td><label >' + Data[i].Phase + '</label></td><td><a target="_blank" href="' + Data[i].FilePathMerge2 + '">View</a></td></tr>';
                    $('#tbldata tbody').append(_tr1);
                }
                $('#divMain').show();
                $('#ContentPlaceHolder1_tr1').show();
                $('#ContentPlaceHolder1_td2').show();
                $('#ContentPlaceHolder1_A2').show();
            }

            $('#ContentPlaceHolder1_UpdateProgress').hide();
        }
        function FilterService() {
            var root = 'tbldata';
            var Filter_Data = $('#ContentPlaceHolder1_txts').val().trim();
            /*if (Filter_Data != "" && Filter_Data != undefined) {*/
            $("#tbldata tr.Drag").each(function (i, j) {
                var _val = "";
                if ($('#ContentPlaceHolder1_ddlSearch').val() == "PMID") {
                    _val = $(this).find("#lblpmid").text();
                }
                else if ($('#ContentPlaceHolder1_ddlSearch').val() == "MachineName") {
                     _val = $(this).find("#lblmachinename").text();
                }
                else if ($('#ContentPlaceHolder1_ddlSearch').val() == "InvoiceNo") {
                     _val = $(this).find("#lblinvoiceno").text();
                }
                if (_val.toLowerCase().indexOf(Filter_Data.toLowerCase()) != -1)
                    $(this).show();
                else
                    $(this).hide();
            });
            /*}*/
        }

        $(document).ready(function () {
            $('#divMain').hide();
            var UnitName = "";
        });

        function Export() {
            var Filename = UnitName + "_PlantandMachinery.xls";
            $("[id*=tbldata]").table2excel({
                filename: Filename
            });
        }
        function ChangePlaceholder() {
            if ($('#ContentPlaceHolder1_ddlSearch').val() == "PMID") {
                $('#ContentPlaceHolder1_txts').prop('placeholder', 'Enter PMId');
            }
            if ($('#ContentPlaceHolder1_ddlSearch').val() == "MachineName") {
                $('#ContentPlaceHolder1_txts').prop('placeholder', 'Enter Machine Name');
            }
            if ($('#ContentPlaceHolder1_ddlSearch').val() == "InvoiceNo") {
                $('#ContentPlaceHolder1_txts').prop('placeholder', 'Enter Invoice Number');
            }
        }

    </script>

</asp:Content>
