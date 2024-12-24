<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="IncentiveFormTTap.aspx.cs" Inherits="TTAP.UI.Pages.IncentiveFormTTap" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../NewJs/validations.js"></script>
    <script type="text/javascript" language="javascript">
        function pageLoad(sender, args) {

            var f = $('#ctl00_ContentPlaceHolder1_hdnfocus').val();
            if (f != "") {
                $('#' + f).focus();
            }
        }
        function ConfirmSave() {
            var x = confirm("Please Confirm whether the Entered Details are Correct");
            if (x)
                return true;
            else
                return false;
        }

        function onlyAlphabets(e, t) {
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123))
                    return true;
                else
                    return false;
            }
            catch (err) {
                alert(err.Description);
            }
        }

        function checkField(fieldname) {
            if (/[^0-9a-bA-B\s]/gi.test(fieldname.value)) {
                alert("Only alphanumeric characters and spaces are valid in this field");
                fieldname.value = "";
                fieldname.focus();
                return false;
            }
        }

        function alphanumeric(alphane) {
            var numaric = alphane;
            for (var j = 0; j < numaric.length; j++) {
                var alphaa = numaric.charAt(j);
                var hh = alphaa.charCodeAt(0);
                if ((hh > 47 && hh < 58) || (hh > 64 && hh < 91) || (hh > 96 && hh < 123)) {
                }
                else {
                    alert("Enter Alpha Numerics Only");
                    return false;
                }
            }
            //alert("Your Alpha Numeric Test Passed");
            return true;
        }




    </script>
    <script type="text/javascript">
        var newWindow = null;
        function PopupCenter(url, title, w, h) {
            if (newWindow == null) {
                // Fixes dual-screen position                         Most browsers      Firefox  
                var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
                var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

                width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
                height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

                var left = ((width / 2) - (w / 2)) + dualScreenLeft;
                var top = ((height / 2) - (h / 2)) + dualScreenTop;
                newWindow = window.open(url, title, 'scrollbars=yes,status=no,toolbar=no,menubar=no,location=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);

                // Puts focus on the newWindow  
                if (window.focus) {
                    newWindow.focus();
                }
                freezeParentPage();
            }
        }
        function freezeParentPage() {
            var divRef = document.getElementById('ModalBackgroundDiv');

            if (divRef != null) {
                divRef.style.display = 'block';

                if (document.body.clientHeight > document.body.scrollHeight) {
                    divRef.style.height = document.body.clientHeight + 'px';
                }
                else {
                    divRef.style.height = document.body.scrollHeight + 'px';
                }
                divRef.style.width = '100%';
            }
        }

    </script>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- BOOTSTRAP STYLES-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <script src="../../Resource/Scripts/js/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/balloon-css/0.4.0/balloon.min.css">
    <style type="text/css">
        .nav-pills.nav-wizard > li {
            position: relative;
            overflow: visible;
            border-right: 15px solid transparent;
            border-left: 15px solid transparent;
        }


            .nav-pills.nav-wizard > li + li {
                margin-left: 0;
            }

            .nav-pills.nav-wizard > li:first-child {
                border-left: 0;
            }

                .nav-pills.nav-wizard > li:first-child a {
                    border-radius: 5px 0 0 5px;
                }

            .nav-pills.nav-wizard > li:last-child {
                border-right: 0;
            }

                .nav-pills.nav-wizard > li:last-child a {
                    border-radius: 0 5px 5px 0;
                }

            .nav-pills.nav-wizard > li a {
                border-radius: 0;
                background-color: #eee;
            }

            .nav-pills.nav-wizard > li:not(:last-child) a:after {
                position: absolute;
                content: "";
                top: -4px;
                right: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 20px 0 20px 20px;
                border-color: transparent transparent transparent #eee;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:not(:first-child) a:before {
                position: absolute;
                content: "";
                top: 0px;
                left: -20px;
                width: 0px;
                height: 0px;
                border-style: solid;
                border-width: 16px 0 16px 20px;
                border-color: #eee #eee #eee transparent;
                z-index: 150;
            }

            .nav-pills.nav-wizard > li:hover:not(:last-child) a:after {
                border-color: transparent transparent transparent #aaa;
            }

            .nav-pills.nav-wizard > li:hover:not(:first-child) a:before {
                border-color: #aaa #aaa #aaa transparent;
            }

            .nav-pills.nav-wizard > li:hover a {
                background-color: #aaa;
                color: #fff;
            }

            .nav-pills.nav-wizard > li.active:not(:last-child) a:after {
                border-color: transparent transparent transparent #428bca;
            }

            .nav-pills.nav-wizard > li.active:not(:first-child) a:before {
                border-color: #428bca #428bca #428bca transparent;
            }

            .nav-pills.nav-wizard > li.active a {
                background-color: #428bca;
            }



        .button {
            background-color: #004A7F;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: none;
            color: #FFFFFF;
            cursor: pointer;
            display: inline-block;
            font-family: Arial;
            font-size: 15px;
            padding: 5px 10px;
            text-align: center;
            text-decoration: none;
        }
        /*Newly Added*/
        .rightAlign {
            text-align: right;
        }

        .tdh {
            border-bottom: solid thin black;
            border-top: solid thin black;
            border-left: solid thin black;
            border-right: solid thin white;
        }

        .td {
            border-bottom: solid thin black;
            border-top: solid thin black;
            border-left: solid thin black;
            border-right: solid thin black;
        }
        /*End*/

        @-webkit-keyframes glowing {
            0% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -webkit-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -webkit-box-shadow: 0 0 1px #337ab7;
            }
        }

        @-moz-keyframes glowing {
            0% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                -moz-box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                -moz-box-shadow: 0 0 1px #337ab7;
            }
        }



        @keyframes glowing {
            0% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }

            50% {
                background-color: #204d74;
                box-shadow: 0 0 20px #204d74;
            }

            100% {
                background-color: #337ab7;
                box-shadow: 0 0 1px #337ab7;
            }
        }

        .button {
            -webkit-animation: glowing 1500ms infinite;
            -moz-animation: glowing 1500ms infinite;
            -o-animation: glowing 1500ms infinite;
            animation: glowing 1500ms infinite;
        }

        .wizard > .content {
            height: 850px;
            width: 1085px;
        }

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

        .lblinv {
            font-weight: bolder;
            color: Red;
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

        .textboxPge {
            border: 1px solid #c4c4c4;
            height: 30px;
            width: 140px;
            font-size: 13px;
            padding: 4px 4px 4px 4px;
            border-radius: 4px;
            -moz-border-radius: 4px;
            -webkit-border-radius: 4px;
            box-shadow: 0px 0px 8px #d9d9d9;
            -moz-box-shadow: 0px 0px 8px #d9d9d9;
            -webkit-box-shadow: 0px 0px 8px #d9d9d9;
        }

            .textboxPge:focus {
                outline: none;
                border: 1px solid #7bc1f7;
                box-shadow: 0px 0px 8px #7bc1f7;
                -moz-box-shadow: 0px 0px 8px #7bc1f7;
                -webkit-box-shadow: 0px 0px 8px #7bc1f7;
            }
    </style>
    <style type="text/css">
        .tooltipDemo {
            position: relative;
            display: inline;
            text-decoration: none;
            left: 0px;
            top: 0px;
        }

            .tooltipDemo:hover:before {
                border: solid;
                border-color: transparent rgb(111, 13, 53);
                border-width: 6px 6px 6px 0px;
                bottom: 21px;
                content: "";
                left: 35px;
                top: 5px;
                position: absolute;
                z-index: 95;
            }

            .tooltipDemo:hover:after {
                /*background: rgb(111, 13, 53);*/
                background: #2184be;
                border-radius: 5px;
                color: #fff;
                width: 300px;
                left: 40px;
                top: -5px;
                content: attr(alt);
                position: absolute;
                padding: 5px 15px;
                z-index: 95;
            }

        .LBLBLACK {
            top: 0px;
            left: 0px;
        }


        /*.auto-style1 {
            width: 288px;
        }

        .auto-style2 {
            width: 277px;
        }*/

        .auto-style6 {
            width: 213px;
        }

        .auto-style7 {
            width: 375px;
        }
        tr {
    font-weight: 100 !important;
    font-size:15px !important;
    text-align:center !important;
}
        th{
            font-size:15px !important;
    text-align:center !important;
        }
        .btn {
    border-radius: 0px !important;
}
    </style>
    <script type="text/javascript" language="javascript">

        function OpenPopup() {

            window.open("Lookups/LookupBDC.aspx", "List", "scrollbars=yes,resizable=yes,width=1000,height=650;display = block;position=absolute");

            return false;
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
    </script>
    <script type="text/javascript" language="javascript">
        function Names() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 65 && AsciiValue <= 90) || (AsciiValue >= 97 && AsciiValue <= 122) || (AsciiValue == 46) || (AsciiValue == 32))
                event.returnValue = true;
            else {
                event.returnValue = false;

                alert("Enter Alphabets, '.' and Space Only");
            }
        }


    </script>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <input type="hidden" id="hdnfocus" value="" runat="server" />
            <div id="innerpagew">
                <div id="content-header" class="d-none">
                    <div id="breadcrumb">
                        <a href="#" title="Go to Home" class="tip-bottom" runat="server" id="ehome"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current">Incentive Application</a>
                    </div>
                    <%--  <h1>Fill Industry Details</h1>--%>
                </div>
                <div class="breadcrumb-bg">
                    <ul class="breadcrumb font-medium title5 container" id="innerpagew">
                        <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                        <li class="breadcrumb-item">Incentive Application</li>
                    </ul>
                </div>
                <div class="container mt-4 pb-4">
                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                        <br />
                        <ul class="nav nav-pills nav-wizard">
                            <li class="active" id="Tab1" runat="server"><a href="#" data-toggle="tab">1. Enterprise Details</a></li>
                            <li id="Tab2" runat="server"><a href="#" data-toggle="tab">2. Project Financials</a></li>
                            <li id="Tab3" runat="server"><a href="#" data-toggle="tab">3. Project Details</a></li>
                            <li id="Tab4" runat="server"><a href="#" data-toggle="tab">4. Loan Details</a></li>
                            <li id="Tab5" runat="server"><a href="#" data-toggle="tab">5. Bank Details</a></li>
                        </ul>
                        <br />
                        <asp:MultiView ID="MainView" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="box-body">
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">1. Type Of Sector:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="rblSector" runat="server" RepeatDirection="Horizontal" Enabled="false" OnSelectedIndexChanged="rblSector_SelectedIndexChanged"
                                                    class="form-control txtbox" AutoPostBack="true">
                                                    <asp:ListItem Value="3" Selected="True">Textiles</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvSector" runat="server" ControlToValidate="rblSector"
                                                    ErrorMessage="Please Select Type of Sector" SetFocusOnError="true" InitialValue="--Select--"
                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">2. UID No:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtuidno" runat="server" class="form-control txtbox" OnTextChanged="txtuidno_TextChanged" AutoPostBack="true"
                                                    ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtuidno" runat="server" ControlToValidate="txtuidno"
                                                    ErrorMessage="Please Enter UID No" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">3. Date Of Incorporation:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtudyogAadharNo" runat="server" class="form-control txtbox" ValidationGroup="group" Visible="false"></asp:TextBox>

                                                <asp:TextBox ID="txtDateOfIncorporation" runat="server" class="form-control txtbox" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDateOfIncorporation" runat="server" ControlToValidate="txtDateOfIncorporation"
                                                    ErrorMessage="Please Enter Date Of Incorporation" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>

                                                <asp:DropDownList runat="server" ID="ddlUdyogAadharType" Visible="false"></asp:DropDownList>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">4. Incorporation Registration No:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtIncorpRegistranNumber" runat="server" class="form-control txtbox" ValidationGroup="group" MaxLength="80"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtIncorpRegistranNumber" runat="server" ControlToValidate="txtIncorpRegistranNumber"
                                                    ErrorMessage="Please Enter Incorporation Registration No" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None" class="form-control txtbox">*</asp:RequiredFieldValidator>

                                                <asp:TextBox ID="txtUdyogAadhaarRegdDate" runat="server" class="form-control txtbox" ValidationGroup="group" MaxLength="80" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">5. Unit Name:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtUser_Id" runat="server" class="form-control txtbox" onkeypress="return alphanumeric(this)" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvUnitName" runat="server" ControlToValidate="txtUser_Id"
                                                    ErrorMessage="Please Enter Unit Name" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">6. Applicant Name:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtApplciantName" runat="server" class="form-control txtbox" onkeypress="Names()" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtApplciantName" runat="server" ControlToValidate="txtApplciantName"
                                                    ErrorMessage="Please Enter Applicant Name" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">7. TIN/ VAT/ CST/ GST Number:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtTinNO" runat="server" class="form-control txtbox" MaxLength="100" ValidationGroup="group" OnTextChanged="txtTinNO_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtTinNO" runat="server" ControlToValidate="txtTinNO"
                                                    ErrorMessage="Please Enter TIN Number" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">8. PAN Number:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtPanNo" runat="server" class="form-control txtbox" MaxLength="40" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtPanNo" runat="server" ControlToValidate="txtPanNo"
                                                    ErrorMessage="Please Enter PAN Number" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">9. Other Details:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:CheckBox ID="cbDiffAbled" runat="server" AutoPostBack="true" OnCheckedChanged="cbDiffAbled_CheckedChanged"
                                                    Text="Physically handicapped" />
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">10. Date of commencement for Production:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtDateofCommencement" runat="server" class="form-control txtbox" AutoPostBack="true" OnTextChanged="txtDateofCommencement_TextChanged"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtDateofCommencement" runat="server" ControlToValidate="txtDateofCommencement"
                                                    ErrorMessage="Please Select Commenecement Date" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">11. Gender:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlgender" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0">--Gender--</asp:ListItem>
                                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                                    <asp:ListItem Value="T">Transgender</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlgender" runat="server" ControlToValidate="ddlgender"
                                                    ErrorMessage="Please Select Gender" SetFocusOnError="true" InitialValue="--Gender--"
                                                    ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">12. Country of Origin (In case of MNC):</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtCountryOrigin" runat="server" class="form-control txtbox" MaxLength="40" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtCountryOrigin" runat="server" ControlToValidate="txtCountryOrigin"
                                                    ErrorMessage="Please Enter Country of Origin" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">13. Textile Process Type:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlTextileProcessType" runat="server" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Ginning"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Spinning"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Weaving"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Garmenting"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlTextileProcessType" runat="server" ControlToValidate="ddlTextileProcessType"
                                                    ErrorMessage="Please select Textile Process Type" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">14. No of Years of Experience in Textiles:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtYearsOfExpinTexttile" runat="server" class="form-control txtbox"
                                                    MaxLength="40" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtYearsOfExpinTexttile" runat="server" ControlToValidate="txtYearsOfExpinTexttile"
                                                    ErrorMessage="Please Enter No of Years of Experience in Textiles" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">15. Educational Qualification:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtEducationalQual" runat="server" class="form-control txtbox" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtEducationalQual" runat="server" ControlToValidate="txtEducationalQual"
                                                    ErrorMessage="Please Enter Educational Qualification" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">16. Social Status:</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="rblCaste" runat="server" class="form-control txtbox" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblCaste_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                    <asp:ListItem Value="1">General</asp:ListItem>
                                                    <asp:ListItem Value="2">OBC</asp:ListItem>
                                                    <asp:ListItem Value="3">SC</asp:ListItem>
                                                    <asp:ListItem Value="4">ST</asp:ListItem>
                                                    <asp:ListItem Value="5">Minority</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvrblCaste" runat="server" ControlToValidate="rblCaste"
                                                    ErrorMessage="Please Select Caste" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12" id="divsubcaste" runat="server" visible="false">
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Sub Caste</div>
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:DropDownList ID="ddlsubcaste" runat="server" Height="33px" Width="180px" RepeatDirection="Horizontal"
                                                        OnSelectedIndexChanged="rblCaste_SelectedIndexChanged">
                                                        <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                        <asp:ListItem Value="1">BC-A</asp:ListItem>
                                                        <asp:ListItem Value="2">BC-B</asp:ListItem>
                                                        <asp:ListItem Value="3">BC-C</asp:ListItem>
                                                        <asp:ListItem Value="4">BC-D</asp:ListItem>
                                                        <asp:ListItem Value="5">BC-E</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="rfvddlsubcaste" runat="server" ControlToValidate="ddlsubcaste"
                                                        ErrorMessage="Please Select Sub Caste" SetFocusOnError="true" ValidationGroup="group"
                                                        Display="None">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12" id="divrblVeh" runat="server" visible="false">
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:RadioButtonList ID="rblVeh" runat="server" RepeatDirection="Horizontal" TabIndex="5"
                                                        OnSelectedIndexChanged="rblVeh_SelectedIndexChanged" AutoPostBack="True">
                                                        <asp:ListItem Value="1">Transport allied activities</asp:ListItem>
                                                        <asp:ListItem Value="0">Other Service Sector</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <asp:RequiredFieldValidator ID="rfvrblVeh" runat="server" ControlToValidate="rblVeh"
                                                        ErrorMessage="Please Select Transport allied activities" SetFocusOnError="true"
                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12" id="divvehicleno" runat="server" visible="false">
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Vehicle Number</div>
                                                <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                    <asp:TextBox ID="txtregistrationno" runat="server" class="form-control txtbox" MaxLength="10" ValidationGroup="group"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtregistrationno" runat="server" ControlToValidate="txtregistrationno"
                                                        ErrorMessage="Please Enter Vehicle Number" SetFocusOnError="true" ValidationGroup="group"
                                                        Display="None">*</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
                                                <h4>17. Registered Address of Enterprise:</h4>
                                            </div>
                                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
                                                <h4>18. Correspondence Address:</h4>
                                            </div>

                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">State</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlUnitstate" runat="server" class="form-control txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitstate_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlUnitstate" runat="server" ControlToValidate="ddlUnitstate"
                                                    SetFocusOnError="true" ErrorMessage="Please Select State" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">State</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddloffcstate" runat="server" class="form-control txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddloffcstate_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddloffcstate" runat="server" ControlToValidate="ddloffcstate"
                                                    SetFocusOnError="true" ErrorMessage="Please Select State" InitialValue="--Select--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">District</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlUnitDIst" runat="server" class="form-control txtbox" Visible="true" AutoPostBack="True" OnSelectedIndexChanged="ddldistrictunit_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlUnitDIst" runat="server" ControlToValidate="ddlUnitDIst"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Unit District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">District</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlOffcDIst" runat="server" AutoPostBack="True" class="form-control txtbox" Visible="true" OnSelectedIndexChanged="ddldistrictoffc_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtofficedist" runat="server" class="form-control txtbox" Visible="false" MaxLength="30" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtofficedist" runat="server" ControlToValidate="txtofficedist"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Office District" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="rfvddlOffcDIst" runat="server" ControlToValidate="ddlOffcDIst"
                                                    SetFocusOnError="true" ErrorMessage="Please Select Office District" InitialValue="--District--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Mandal</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control txtbox" Visible="true" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlUnitMandal" runat="server" ControlToValidate="ddlUnitMandal"
                                                    SetFocusOnError="true" ErrorMessage="Please Select Unit Mandal" InitialValue="--Mandal--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Mandal</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlOffcMandal" runat="server" AutoPostBack="True" Visible="true" class="form-control txtbox" OnSelectedIndexChanged="ddloffcmandal_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtoffcicemandal" runat="server" class="form-control txtbox"
                                                    Visible="false" MaxLength="30" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtoffcicemandal" runat="server" ControlToValidate="txtoffcicemandal"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Office Mandal" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="rfvddlOffcMandal" runat="server" ControlToValidate="ddlOffcMandal"
                                                    SetFocusOnError="true" ErrorMessage="Please Select Office Mandal" InitialValue="--Mandal--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Village</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control txtbox" Visible="true" AutoPostBack="True" OnSelectedIndexChanged="ddlVillageunit_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlVillageunit" runat="server" ControlToValidate="ddlVillageunit"
                                                    SetFocusOnError="true" ErrorMessage="Please Select Unit Village" InitialValue="--Village--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Village</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlOffcVil" runat="server" AutoPostBack="True" class="form-control txtbox" Visible="true">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtofficeviiage" runat="server" class="form-control txtbox"
                                                    Visible="false" MaxLength="30" TabIndex="4" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtofficeviiage" runat="server" ControlToValidate="txtofficeviiage"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Office Village" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="rfvddlOffcVil" runat="server" ControlToValidate="ddlOffcVil"
                                                    SetFocusOnError="true" ErrorMessage="Please Select Office Village" InitialValue="--Village--"
                                                    ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Grampanchayat/IE/IDA</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtUnitStreet" runat="server" class="form-control txtbox" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtUnitStreet" runat="server" ControlToValidate="txtUnitStreet"
                                                    SetFocusOnError="true" ErrorMessage="Please enter Unit Street" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Grampanchayat/IE/IDA</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtOffcStreet" runat="server" class="form-control txtbox" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtOffcStreet" runat="server" ControlToValidate="txtOffcStreet"
                                                    SetFocusOnError="true" ErrorMessage="Please enter Office Street" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Survey/Plot No.</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtUnitHNO" runat="server" class="form-control txtbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtUnitHNO" runat="server" ControlToValidate="txtUnitHNO"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Unit Survey Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Survey/Plot No.</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtoffaddhnno" runat="server" class="form-control txtbox"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtoffaddhnno" runat="server" ControlToValidate="txtoffaddhnno"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Office Survey Number" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Mobile Number</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtunitmobileno" runat="server" class="form-control txtbox"
                                                    MaxLength="10" onkeypress="return inputOnlyNumbers(event)" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtunitmobileno" runat="server" ControlToValidate="txtunitmobileno"
                                                    SetFocusOnError="true" ErrorMessage="Please enter Unit Mobile Number" ValidationGroup="group"
                                                    Display="None">*
                                                </asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Mobile Number</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtOffcMobileNO" runat="server" class="form-control txtbox"
                                                    MaxLength="10" onkeypress="return inputOnlyNumbers(event)" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtOffcMobileNO" runat="server" ControlToValidate="txtOffcMobileNO"
                                                    SetFocusOnError="true" ErrorMessage="Please enter Office Mobile Number" ValidationGroup="group"
                                                    Display="None">*
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Email Id</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtunitemailid" runat="server" class="form-control txtbox" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtunitemailid" runat="server" ControlToValidate="txtunitemailid"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Unit Email" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revtxtunitemailid" runat="server" ControlToValidate="txtunitemailid"
                                                    ErrorMessage="Please Enter Unit Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">Email Id</div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12">
                                                <asp:TextBox ID="txtOffcEmail" runat="server" class="form-control txtbox" ValidationGroup="group"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtOffcEmail"
                                                    SetFocusOnError="true" ErrorMessage="Please Enter Office Email" ValidationGroup="group"
                                                    Display="None">*
                                                </asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtOffcEmail"
                                                    ErrorMessage="Please Enter Office Correct Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="form-group" runat="server">
                                        <div class="row">
                                            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">19. Constitution of Organization:</div>
                                            <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlOrgType" runat="server" class="form-control txtbox" ValidationGroup="group" AutoPostBack="True" OnSelectedIndexChanged="ddlOrgType_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlOrgType" runat="server" ControlToValidate="ddlOrgType"
                                                    ErrorMessage="Please select Type of Organization" ValidationGroup="group" SetFocusOnError="true"
                                                    InitialValue="--Select--" Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">20. </div>
                                            <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                                                <asp:RadioButtonList ID="rblGHMC" Enabled="false" runat="server" TabIndex="5" RepeatDirection="Horizontal"
                                                    OnSelectedIndexChanged="rblGHMC_SelectedIndexChanged">
                                                    <asp:ListItem Value="1">GHMC & other Municipal Corporations in the state</asp:ListItem>
                                                    <asp:ListItem Value="0">Other areas in the state</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="rfvrblGHMC" runat="server" ControlToValidate="rblGHMC"
                                                    ErrorMessage="Please Select GHMC/Other Area" SetFocusOnError="true" ValidationGroup="group"
                                                    Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row" id="divIsIALA" runat="server" visible="false">
                                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">21. Whether Unit Located in TSIIC</div>
                                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
                                                <asp:RadioButtonList ID="rdIaLa_Lst" runat="server" RepeatDirection="Horizontal"
                                                    AutoPostBack="True" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged">
                                                    <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                    <asp:ListItem Value="N">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:RequiredFieldValidator ID="rfvrdIaLa_Lst" runat="server" ControlToValidate="rdIaLa_Lst"
                                                    ErrorMessage="Please select whether the unit is located in TSIIC or not" ValidationGroup="group"
                                                    SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row" id="divIndusParkList" runat="server" visible="false">
                                            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">Name of the Industrial Park</div>
                                            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlIndustrialParkName" runat="server" AutoPostBack="true" class="form-control txtbox">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="rfvddlIndustrialParkName" runat="server" ControlToValidate="ddlIndustrialParkName"
                                                    ErrorMessage="Please select Industrial Park" ValidationGroup="group" SetFocusOnError="true"
                                                    InitialValue="--Select--" Display="None">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row" id="divLineofActivity" runat="server" visible="false">
                                            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">Nature of Activity</div>
                                            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DropDownList ID="ddlintLineofActivity" runat="server" class="form-control txtbox" ValidationGroup="group">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txtBussinessActivity" runat="server" class="form-control txtbox"
                                                    MaxLength="250" ValidationGroup="group" Visible="false"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="rfvLineOfAct" runat="server" InitialValue="--Select--"
                                                    ControlToValidate="ddlintLineofActivity" ErrorMessage="Please select Nature of Activity"
                                                    ValidationGroup="group" SetFocusOnError="true" Display="None">*
                                                </asp:RequiredFieldValidator>
                                                <asp:RequiredFieldValidator ID="rfvtxtBussinessActivity" runat="server" ControlToValidate="txtBussinessActivity"
                                                    ErrorMessage="Please enter Nature of Activity" ValidationGroup="group" SetFocusOnError="true"
                                                    Display="None">*
                                                </asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-11 col-md-12 col-sm-12 col-xs-12" style="text-align:right;">
                                                <asp:Button Text="Next" CssClass="btn btn-warning" Font-Size="Large" ForeColor="White" Height="50px" width="150px" 
                                                    TabIndex="5" ID="btntab1next" runat="server" OnClick="btntab1next_Click" />
                                            </div>
                                           <div class="col-lg-1 col-md-12 col-sm-12 col-xs-12"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12"></div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12"></div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12"></div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12"></div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12"></div>
                                            <div class="col-lg-4 col-md-12 col-sm-12 col-xs-12"></div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="form-group" runat="server">
                                    <div class="row">
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblIndStatus" runat="server" Visible="true" Text="Industry Status"></asp:Label>
                                                        <span style="font-weight: bold; color: Red;">*</span></div>
                                            <div class="col-lg-3 col-md-12 col-sm-12 col-xs-12"><asp:DropDownList ID="ddlIndustryStatus" runat="server" class="form-control txtbox"
                                                            Height="35px" TabIndex="5" Width="180px" ValidationGroup="group" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlindustryStatus_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                            <asp:ListItem Value="1">New Industry</asp:ListItem>
                                                            <asp:ListItem Value="2">Expansion</asp:ListItem>
                                                            <asp:ListItem Value="3">Diversification</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlIndustryStatus"
                                                            ErrorMessage="Please select Industry Status" InitialValue="-- Select --" ValidationGroup="group"
                                                            SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator></div>
                                        <div id="divIndustryExpansionType" runat="server" visible="false" class="col-lg-6 col-md-12 col-sm-12 col-xs-12">
                                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12" visible="false"><asp:Label ID="Label9" runat="server" Visible="true" Text="Expansion Type"></asp:Label>
                                                        <span style="font-weight: bold; color: Red;">*</span></div>
                                            <div class="col-lg-6 col-md-12 col-sm-12 col-xs-12"> <asp:DropDownList ID="ddlInustryExpansionType" runat="server" class="form-control txtbox"
                                                            Height="35px" TabIndex="5" Width="180px" ValidationGroup="group">
                                                            <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                                            <asp:ListItem Value="1">Expansion1</asp:ListItem>
                                                            <asp:ListItem Value="2">Expansion2</asp:ListItem>
                                                            <asp:ListItem Value="3">Expansion3</asp:ListItem>
                                                        </asp:DropDownList>
                                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator79" runat="server" ControlToValidate="ddlInustryExpansionType"
                                                            ErrorMessage="Please select Industry Expansion Type" InitialValue="-- Select --"
                                                            ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator></div>
                                            </div>
                                        </div>
                                   
                                    </div>
                                <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                                    <tr>
                                        <td width="100%">
                                            <table style="width: 100%; font-weight: bold;">
                                                
                                              
                                                <tr id="trNewIndustry" runat="server" visible="false" align="center">
                                                    <td colspan="9" align="center">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr> 
                                                                <td style="padding: 0px; margin: 5px" valign="top" colspan="9" align="left">
                                                                    <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="465px">New Enterprise Line of Activity<font color="red">*</font></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr id="trlineofactivityNew" runat="server">
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="center">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label2" runat="server">Line of Activity<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtLOActivity" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label3" runat="server">Unit<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:DropDownList ID="ddlquantityin" runat="server" class="form-control txtbox" TabIndex="5"
                                                                                    Height="33px" Width="180px" AutoPostBack="True" Visible="true" OnSelectedIndexChanged="ddlquantityin_SelectedIndexChanged">
                                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                                    <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                                    <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:TextBox ID="txtunit" runat="server" class="form-control txtbox" Visible="false"
                                                                                    Height="43px" MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group"
                                                                                    Width="180px"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="txtunit" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>&nbsp;
                                                                </td>
                                                                <td valign="top" align="center">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px">2
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="Label4" runat="server" CssClass="LBLBLACK" Width="165px">Installed Capacity<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                <asp:TextBox ID="txtinstalledccap" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="180px"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                        ControlToValidate="txtinstalledccap" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px">4
                                                                            </td>
                                                                            <td style="width: 200px;">
                                                                                <asp:Label ID="Label5" runat="server">Value (in Rs.)<font color="red">*</font></asp:Label>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">
                                                                                <asp:TextBox ID="txtvalue" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="180px"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                        ControlToValidate="txtvalue" ErrorMessage="Please enter Value"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td align="center">
                                                                                <asp:Button ID="btnInstalledcap" runat="server" CssClass="btn btn-xs btn-warning"
                                                                                    Height="28px" TabIndex="5" Text="Add New" Width="72px" OnClick="btnInstalledcap_Click" />
                                                                            </td>
                                                                            <td align="right">&nbsp;
                                                                            </td>
                                                                            <td>
                                                                                <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                                                    Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px"
                                                                                    OnClick="Button2_Click" />
                                                                            </td>
                                                                            <td align="left">&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3" width="100%">
                                                                    <asp:GridView ID="gvInstalledCap" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                        GridLines="Both" Visible="false" Width="90%" DataKeyNames="intLineofActivityMid"
                                                                        OnRowDataBound="gvInstalledCap_RowDataBound" OnRowDeleting="gvInstalledCap_RowDeleting">
                                                                        <RowStyle BackColor="#ffffff" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Column1" HeaderText="Line of Activity" />
                                                                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                            <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                            HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr align="center">
                                                                <td style="padding: 5px; margin: 5px;" valign="top" align="center" colspan="9" width="100%">
                                                                    <center>
                                                                                    <asp:GridView ID="gvInstalledCapNew" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                                                        GridLines="Both" Visible="false" Width="90%">
                                                                                        <RowStyle BackColor="#ffffff" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:BoundField DataField="Column1" HeaderText="Line of Activity" />
                                                                                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                            <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                                                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                        </Columns>
                                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                                            HorizontalAlign="Center" />
                                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                                    </asp:GridView>
                                                                                </center>
                                                                </td>
                                                            </tr>
                                                            <%-- <tr>
                                                                            <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="3">
                                                                                <asp:GridView ID="gvInstalledCap1" runat="server" AutoGenerateColumns="False"
                                                                                    BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4"
                                                                                    CssClass="GRD" ForeColor="#333333" GridLines="None"
                                                                                    Width="100%">
                                                                                    <RowStyle BackColor="#ffffff" />
                                                                                    <Columns>
                                                                                        <asp:BoundField DataField="Column1" HeaderText="Line Of Activity" />
                                                                                        <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                                        <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                                        <asp:BoundField DataField="Column4" HeaderText="Value" />
                                                                                        <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                                        <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                                    </Columns>
                                                                                    <FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                                    <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                                    <EditRowStyle BackColor="#013161" />
                                                                                    <AlternatingRowStyle BackColor="White" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>--%>
                                                        </table>
                                                    </td>
                                                </tr>





                                                <tr id="trexpansionnew" runat="server" visible="false">
                                                    <td colspan="9" align="center">



                                                        
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="9">
                                                                    <asp:Label ID="Label18" runat="server" CssClass="LBLBLACK" Font-Bold="True" Width="465px">Expansion of Enterprise<font color="red">*</font></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr id="trlineofactivityexpansion" runat="server">
                                                                <td style="padding: 5px; margin: 5px" valign="top">



                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                           
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">1. 
                                                                                <asp:Label ID="Label19" runat="server">Line of Activity<font color="red">*</font></asp:Label>:
                                                                            </td>
                                                                           
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtLOActivityExpan" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                        ControlToValidate="txtLOActivity" ErrorMessage="Please enter Line Of Activity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                           
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">3. 
                                                                                <asp:Label ID="Label20" runat="server">Unit<font color="red">*</font></asp:Label>:
                                                                            </td>
                                                                           
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:DropDownList ID="ddlquantityinExpan" runat="server" class="form-control txtbox"
                                                                                    TabIndex="5" Height="33px" Width="180px" AutoPostBack="True" Visible="true" OnSelectedIndexChanged="ddlquantityinExpan_SelectedIndexChanged">
                                                                                    <asp:ListItem>--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                                    <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                                    <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:TextBox ID="txtunitExpan" runat="server" class="form-control txtbox" Visible="false"
                                                                                    Height="28px" MaxLength="40" TabIndex="5" onkeypress="Names()" ValidationGroup="group"
                                                                                    Width="180px"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server"
                                                                        ControlToValidate="txtunit" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td ></td>
                                                                            <td align="center"><br />
                                                                                <asp:Button ID="btnInstalledcapExpan" runat="server" class="btn bg-blue text-white"
                                                                                     Text="Add New"  OnClick="btnInstalledcapExpan_Click" />
                                                                            </td>
                                                                           
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td>&nbsp;
                                                                </td>
                                                                <td valign="top">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                           
                                                                             <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label21" runat="server" CssClass="LBLBLACK">2. Installed Capacity<font color="red">*</font></asp:Label>:
                                                                            </td>
                                                                            
                                                                             <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtinstalledccapExpan" runat="server" class="form-control txtbox"
                                                                                    Height="28px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="180px"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server"
                                                                        ControlToValidate="txtinstalledccap" ErrorMessage="Please enter Installed Capacity"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                           
                                                                             <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:Label ID="Label22" runat="server">4. Value (in Rs.)<font color="red">*</font></asp:Label>:
                                                                            </td>
                                                                            
                                                                             <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtvalueExpan" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="180px" Visible="true"></asp:TextBox>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server"
                                                                        ControlToValidate="txtvalue" ErrorMessage="Please enter Value"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                             <td><br />
                                                                                <asp:Button ID="Button3" runat="server" CausesValidation="False" CssClass="btn bg-blue text-white"
                                                                                    Text="Cancel" ToolTip="To Clear  the Screen" 
                                                                                    OnClick="Button3_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                                                    <asp:GridView ID="gvInstalledCapExpan" runat="server" AutoGenerateColumns="False"
                                                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                                                        ForeColor="#333333" GridLines="Both" Visible="false" Width="90%" DataKeyNames="intLineofActivityMid"
                                                                        OnRowDataBound="gvInstalledCapExpan_RowDataBound" OnRowDeleting="gvInstalledCapExpan_RowDeleting">
                                                                        <RowStyle BackColor="#ffffff" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Column1" HeaderText="Line of Activity" />
                                                                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                            <asp:BoundField DataField="Column4" HeaderText="Value (in Rs.)" />
                                                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                            HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="3">
                                                                    <asp:GridView ID="gvInstalledCapExpanNew" runat="server" AutoGenerateColumns="False"
                                                                        BorderColor="#003399" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD"
                                                                        ForeColor="#333333" GridLines="Both" Visible="false" Width="90%">
                                                                        <RowStyle BackColor="#ffffff" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Column1" HeaderText="Line of Activity" />
                                                                            <asp:BoundField DataField="Column3" HeaderText="Installed Capacity" />
                                                                            <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                            <asp:BoundField DataField="Column4" HeaderText="Value" />
                                                                            <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                            <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                            HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="trexpansion" runat="server" visible="false">
                                                    <td colspan="9" align="center">
                                                        <table style="width: 100%; font-weight: bold;" id="tblexpsnsion" runat="server" visible="false">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top" colspan="4">
                                                                    <asp:Label ID="lblexpan1" runat="server"></asp:Label>
                                                                    &nbsp; PROJECT(In Rs.)<font color="red">*</font>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: solid thin white; background: #013161; color: white" align="center"></td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white"
                                                                    class="auto-style6">Line Of Activity
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white"
                                                                    class="auto-style7">Installed Capacity
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">% of increase under
                                                                                <br />
                                                                    <asp:Label ID="lblexpan2" runat="server"></asp:Label>
                                                                </td>
                                                                <%--Expansion--%>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white"></td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white"></td>
                                                                <td align="center" style="padding: 5px; margin: 5px; border: solid thin white; background: #013161; color: white">
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td align="center" style="background: #013161; color: white; width: 50%">Quantity
                                                                            </td>
                                                                            <td align="center" style="background: #013161; color: white; width: 50%">Unit
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white"></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="border: solid thin black; background: white; color: black">&nbsp;&nbsp;Existing Enterprise
                                                                </td>
                                                                <td align="left" style="border: solid thin black; width: 180px;">
                                                                    <asp:TextBox ID="txteeploa" runat="server" class="form-control txtbox"
                                                                        MaxLength="40" onkeypress="Names()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td align="center" style="border: solid thin black" class="auto-style7">
                                                                    <%--<asp:TextBox ID="txteepinscap" runat="server" class="form-control txtbox" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>--%>
                                                                    <table style="font-weight: bold; width: 90%;">
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin black; width: 50%" class="auto-style6">
                                                                                <asp:TextBox ID="txteepinscap" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="100px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="center" style="text-align: center; width: 50%">
                                                                                <asp:DropDownList ID="ddleepinscap" runat="server" class="form-control txtbox"
                                                                                    TabIndex="5" Width="150px">
                                                                                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Liters</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Kg</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Tones</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator66" runat="server" ControlToValidate="ddleepinscap"
                                                                                    ErrorMessage="Please select Installed Capacity Unit" InitialValue="-- Select --"
                                                                                    SetFocusOnError="true" ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="center" style="border: solid thin black">
                                                                    <asp:TextBox ID="txteeppercentage" runat="server" class="form-control txtbox"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" style="border: solid thin black; background: white; color: black">&nbsp;&nbsp;<asp:Label ID="lblexpan3" runat="server"></asp:Label>&nbsp;Project
                                                                </td>
                                                                <td align="center" style="border: solid thin black; width: 180px;">
                                                                    <asp:TextBox ID="txtedploa" runat="server" class="form-control txtbox"
                                                                        MaxLength="40" onkeypress="Names()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td align="center" style="border: solid thin black" class="auto-style7">
                                                                    <table style="width: 90%; font-weight: bold;">
                                                                        <tr>
                                                                            <td align="center" class="auto-style6" style="border: solid thin black; width: 50%">
                                                                                <asp:TextBox ID="txtedpinscap" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    Width="100px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="center" style="text-align: center; border: solid thin black; width: 50%">
                                                                                <asp:DropDownList ID="ddledpinscap" runat="server" class="form-control txtbox"
                                                                                    TabIndex="5" Width="150px">
                                                                                    <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Liters</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Kg</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Tones</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Other</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator67" runat="server" ControlToValidate="ddledpinscap"
                                                                                    Display="None" ErrorMessage="Please Select Installed Capacity Unit" InitialValue="-- Select --"
                                                                                    SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtedppercentage" runat="server" class="form-control txtbox"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="Tr1" runat="server" visible="false">
                                                    <td align="center" colspan="9" style="padding: 5px; margin: 5px" valign="top" width="100%">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                            GridLines="Both" Visible="true" Width="90%">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Column1" HeaderText="Line of Activity" ItemStyle-HorizontalAlign="Left" />
                                                                <asp:BoundField DataField="Column3" HeaderText="Installed Capacity">
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Column2" HeaderText="Unit" />
                                                                <asp:BoundField DataField="Column4" HeaderText="Value" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                            <RowStyle BackColor="#F7F6F3" Font-Names="Arial" Font-Size="12px" ForeColor="#333333"
                                                                HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" Font-Names="Arial" Font-Size="9px"
                                                                ForeColor="White" HorizontalAlign="Center" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table style="font-weight: bold;" align="left" width="100%">
                                                            <tr>
                                                                <td colspan="9" style="padding: 5px; margin: 5px; width: 100%;" valign="top"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="9" style="padding: 5px; margin: 5px; text-align: left; width: 100%;"
                                                                    valign="top">
                                                                    <asp:Label ID="Label23" runat="server" CssClass="LBLBLACK" Font-Bold="True">FIXED CAPITAL INVESTMENT (In Rs.)<font color="red">*</font></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <%--Fixed Investment--%>
                                                <%--<table style="width: 100%;  font-weight: bold;">--%>
                                                <tr id="trFixedcap" runat="server" visible="true" align="center">
                                                    <td colspan="9" style="width: 80%;">
                                                        <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                            <tr class="GridviewScrollC1HeaderWrap">
                                                                <td>Sl.No
                                                                </td>
                                                                <td>Nature of Assets
                                                                </td>
                                                                <td>Value (in Rs.)
                                                                </td>
                                                                <td id="trFixedCapitalexpansion" runat="server" align="center"
                                                                    visible="false">Under Expansion/ Diversification Project
                                                                </td>
                                                                <td id="trFixedCapitalexpnPercent" runat="server" align="center"
                                                                    visible="false">% of increase under
                                                                                <br />
                                                                    Expansion/Diversification
                                                                </td>
                                                            </tr>
                                                            <tr class="GridviewScrollC1Item">
                                                                <td rowspan="4">1
                                                                </td>
                                                                <td style="text-align: left;">Land
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtlandexisting" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"
                                                                        AutoPostBack="True" OnTextChanged="txtlandexisting_TextChanged"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator63" runat="server" ControlToValidate="txtlandexisting"
                                                                        ErrorMessage="Please enter Land Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>



                                                                <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                    </td>--%>
                                                                <td id="trFixedCapitalland" runat="server" align="center" 
                                                                    visible="false">
                                                                    <asp:TextBox ID="txtlandcapacity" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group" AutoPostBack="True" OnTextChanged="txtlandcapacity_TextChanged"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator62" runat="server" ControlToValidate="txtlandcapacity"
                                                                        ErrorMessage="Please enter Land Under Expansion/Diversification Project" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td style="border-bottom: solid thin black; width: 1px">
                                                                    </td>--%>
                                                                <td id="txtbuildcapacityPercet" runat="server" align="center" 
                                                                    visible="false">
                                                                    <asp:TextBox ID="txtlandpercentage" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator61" runat="server" ControlToValidate="txtlandpercentage"
                                                                        ErrorMessage="Please enter Land Percentage of increase under Expansion/Diversification"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <%--<td style="border-bottom: solid thin black; border-right: solid thin black; width: 1px">
                                                                    </td>--%>
                                                            </tr>
                                                            <tr class="GridviewScrollC1Item2">
                                                                <td style="text-align: left;">Five times Plinth area of the Factory Building Constructed (In Acres)</td>

                                                                <td align="center">
                                                                    <asp:TextBox ID="txtPlinthArea" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator93" runat="server" ControlToValidate="txtPlinthArea"
                                                                        ErrorMessage="Please enter Plinth area" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr class="GridviewScrollC1Item">
                                                                <td style="text-align: left;">Rate per Acre(In Rupees)</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtRateperAcre" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator97" runat="server" ControlToValidate="txtRateperAcre"
                                                                        ErrorMessage="Please enter Rate per Acre" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>

                                                            </tr>
                                                            <tr class="GridviewScrollC1Item2">
                                                                <td style="text-align: left;">Total Investment in Land</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtTotalInvestment" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator128" runat="server" ControlToValidate="txtTotalInvestment"
                                                                        ErrorMessage="Please enter Total Investment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>

                                                            </tr>

                                                            <tr class="GridviewScrollC1Item2">
                                                                <td rowspan="5">2
                                                                </td>
                                                                <td style="text-align: left;">Building
                                                                </td>
                                                                <td>Built up Area (In sq.ft)</td>
                                                                <td>Rate per Sq.ft (In Rupees)</td>
                                                                <td>Total (In Rupees)</td>


                                                            </tr>
                                                            <tr>
                                                               <td style="text-align: left;">Factory Building</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtbuildingexisting" runat="server" CssClass="text-sm-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group" AutoPostBack="True" OnTextChanged="txtbuildingexisting_TextChanged"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator60" runat="server" ControlToValidate="txtbuildingexisting"
                                                                        ErrorMessage="Please enter Building Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td id="trFixedCapitalBuilding" runat="server" visible="false">
                                                                    <asp:TextBox ID="txtbuildingcapacity" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        AutoPostBack="True" ValidationGroup="group" OnTextChanged="txtbuildingcapacity_TextChanged"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator59" runat="server" ControlToValidate="txtbuildingcapacity"
                                                                        ErrorMessage="Please enter Building Under Expansion/Diversification Project"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td id="trFixedCapitBuildPercent" runat="server" visible="false">
                                                                    <asp:TextBox ID="txtbuildingpercentage" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator58" runat="server" ControlToValidate="txtbuildingpercentage"
                                                                        ErrorMessage="Please enter Building Percentage of increase under Expansion/Diversification"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Infrastructure (Other than Land & Land Development)</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtInfrastructure1" runat="server" CssClass="text-sm-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator129" runat="server" ControlToValidate="txtInfrastructure1"
                                                                        ErrorMessage="Please enter Infrastructure" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtInfrastructure2" runat="server" CssClass="text-sm-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator130" runat="server" ControlToValidate="txtInfrastructure2"
                                                                        ErrorMessage="Please enter Infrastructure" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtInfrastructure3" runat="server" CssClass="text-sm-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator132" runat="server" ControlToValidate="txtInfrastructure3"
                                                                        ErrorMessage="Please enter Infrastructure" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Other Productive Assets (Specify)</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtOtherProductive1" runat="server" CssClass="text-sm-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator131" runat="server" ControlToValidate="txtOtherProductive1"
                                                                        ErrorMessage="Please enter Other Productive Assets" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtOtherProductive2" runat="server" CssClass="text-sm-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator133" runat="server" ControlToValidate="txtOtherProductive2"
                                                                        ErrorMessage="Please enter Other productive Assets" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtOtherProductive3" runat="server" CssClass="text-sm-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator134" runat="server" ControlToValidate="txtOtherProductive3"
                                                                        ErrorMessage="Please enter Other Productive Assets" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Total Investment in Building (In Rupees)</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtTotalInvestmentBuilding" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator135" runat="server" ControlToValidate="txtTotalInvestmentBuilding"
                                                                        ErrorMessage="Please enter Total Investment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>

                                                            <tr>
                                                                <td rowspan="7">3                                                                            
                                                                </td>
                                                                <td align="left">Plant &amp; Machinery
                                                                </td>
                                                                <td align="left">Amount in Rupees
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                <td align="left">Plant and Machinery and Other Productive Assets
                                                                </td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtplantexisting" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group" OnTextChanged="txtplantexisting_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator57" runat="server" ControlToValidate="txtplantexisting"
                                                                        ErrorMessage="Please enter Plant &amp; Machinery Existing Enterprise" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>

                                                                <td id="trFixedCapitalMach" runat="server" align="center" 
                                                                    visible="false">
                                                                    <asp:TextBox ID="txtplantcapacity" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group" AutoPostBack="True" OnTextChanged="txtplantcapacity_TextChanged"></asp:TextBox>
                                                                    <asp:RegularExpressionValidator ID="revMemComment" runat="server" CssClass="validatorMemComment"
                                                                        ControlToValidate="txtplantcapacity" ValidationExpression="^[a-zA-Z0-9]*$" Text="*"
                                                                        ErrorMessage="Invalid character" ForeColor="Red" Display="Dynamic" />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator56" runat="server" ControlToValidate="txtplantcapacity"
                                                                        ErrorMessage="Please enter Plant &amp; Machinery Under Expansion/Diversification Project"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>

                                                                <td id="trFixedCapitMachPercent" runat="server" align="center" 
                                                                    visible="false">
                                                                    <asp:TextBox ID="txtplantpercentage" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" onkeypress="NumberOnly()" TabIndex="5"
                                                                        ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator55" runat="server" ControlToValidate="txtplantpercentage"
                                                                        ErrorMessage="Please enter Plant &amp; Machinery Percentage of increase under Expansion/Diversification"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Transportation</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtTransportation" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator136" runat="server" ControlToValidate="txtTransportation"
                                                                        ErrorMessage="Please ennter Transportation" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Erection</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtErection" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator137" runat="server" ControlToValidate="txtErection"
                                                                        ErrorMessage="Please enter Erection" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Electrification</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtElectrification" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator138" runat="server" ControlToValidate="txtElectrification"
                                                                        ErrorMessage="Please enter Electrification" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Other Assets</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtOtherAssets" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator139" runat="server" ControlToValidate="txtOtherAssets"
                                                                        ErrorMessage="Please enter Other Assets" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align: left;">Total Investment in Plant & Machinery (In Rupees)</td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtTotalPlantMechinery" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator140" runat="server" ControlToValidate="txtTotalPlantMechinery"
                                                                        ErrorMessage="Please enter Total Investment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>4                                                                           
                                                                </td>
                                                                <td align="left">Total Fixed Capital Investment in Land,Building and Pland & Machinery (In Rupees)
                                                                </td>
                                                                <td align="center">
                                                                    <asp:TextBox ID="txtTotalCapitalInvestment" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                        Height="25px" Width="100px" MaxLength="80" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator142" runat="server" ControlToValidate="txtTotalCapitalInvestment"
                                                                        ErrorMessage="Please enter Total Capital Investment" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%;">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Category&nbsp;: <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="text-align: left;" align="left">&nbsp;&nbsp;
                                                                                <asp:Label ID="lblEnterpriseCategory" runat="server" Visible="false"> </asp:Label>
                                                                    <asp:Label ID="lblEnterpriseCategoryTTAP" runat="server"> </asp:Label>
                                                                    <asp:HiddenField ID="HiddenFieldEnterpriseCategory" runat="server" />
                                                                    <asp:DropDownList ID="ddlCategory" runat="server" class="form-control txtbox" Height="33px"
                                                                        TabIndex="5" ValidationGroup="group" Width="180px" Visible="false">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCategory"
                                                                        ErrorMessage="Please select Category" InitialValue="-- SELECT --" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Percentage increase in A over existing Fixed Capital Investment&nbsp;: <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="text-align: left;" align="left">&nbsp;&nbsp;
                                                                               
                                                                                 <asp:TextBox ID="txtPercentge_FixedCapitalInvestment" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                     Height="25px" Width="190px" MaxLength="80" TabIndex="5"
                                                                                     ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator123" runat="server" ControlToValidate="ddlCategory"
                                                                        ErrorMessage="Please select Category" InitialValue="-- SELECT --" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Nature of Industry &nbsp;: <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="text-align: left;" align="left">&nbsp;&nbsp;
                                                                               
                                                                                 <asp:TextBox ID="txtNature_Industry" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                     Height="25px" Width="190px" MaxLength="80" TabIndex="5"
                                                                                     ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator124" runat="server" ControlToValidate="ddlCategory"
                                                                        ErrorMessage="Please select Category" InitialValue="-- SELECT --" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Installed Capacity / Annum &nbsp;: <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="text-align: left;" align="left">&nbsp;&nbsp;
                                                                               
                                                                                 <asp:TextBox ID="txtInstalledCapacityperAnnum" runat="server" CssClass="text-center" class="form-control txtbox"
                                                                                     Height="25px" Width="190px" MaxLength="80" TabIndex="5"
                                                                                     ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator125" runat="server" ControlToValidate="ddlCategory"
                                                                        ErrorMessage="Please select Category" InitialValue="-- SELECT --" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Whether allotted by the Government &nbsp;: <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:RadioButtonList ID="rdWhetherAllotedByGovt" runat="server" RepeatDirection="Horizontal"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="rdIaLa_Lst_SelectedIndexChanged">
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="N">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator126" runat="server" ControlToValidate="ddlCategory"
                                                                        ErrorMessage="Please select Category" InitialValue="-- SELECT --" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Category of New Unit as per TTAP Policy  &nbsp;: <span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="text-align: left;" align="left">&nbsp;&nbsp;
                                                                               
                                                                                  <asp:DropDownList ID="ddlCategoryTTAP" runat="server" class="form-control txtbox" Height="33px"
                                                                                      TabIndex="5" ValidationGroup="group" Width="180px" Visible="true">
                                                                                      <asp:ListItem Value="1">Category1</asp:ListItem>
                                                                                      <asp:ListItem Value="2">Category2</asp:ListItem>
                                                                                  </asp:DropDownList>
                                                                </td>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator127" runat="server" ControlToValidate="ddlCategory"
                                                                        ErrorMessage="Please select Category" InitialValue="-- SELECT --" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                                <caption>
                                                    <br />
                                                    <br />
                                                    <tr align="left">
                                                        <td align="right" style="width: 100%;">
                                                            <table align="center" style="width: 100%;">
                                                                <tr>
                                                                    <%-- <td colspan="3" width="100%" ></td>--%>
                                                                    <td align="right">
                                                                        <asp:Button ID="btntab2previous" runat="server" CssClass="btn btn-warning" Font-Size="Large" ForeColor="White" Height="50px" OnClick="btntab2previous_Click" TabIndex="5" Text="Previous" Width="150px" />
                                                                        &nbsp;&nbsp;&nbsp;
                                                                                    <asp:Button ID="btntab2next" runat="server" CssClass="btn btn-warning" Font-Size="Large" ForeColor="White" Height="50px" OnClick="btntab2next_Click" TabIndex="5" Text="Next" Width="150px" />
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 20px; font-weight: bold;"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </caption>
                                            </table>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                                    <tr>
                                        <td>
                                            <table style="width: 100%; font-weight: bold;" id="tblview3" runat="server" visible="false">
                                                
                                                <tr id="trLabel12" runat="server">
                                                    <td style="padding: 5px; margin: 5px" valign="top" colspan="9">
                                                        <asp:Label ID="Label12" runat="server" Font-Bold="True">Details of the Director(s)/ Partner(s) : <font color="red">*</font></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" colspan="9"></td>
                                                </tr>
                                                <tr id="trdirectordetails" runat="server" visible="true">
                                                    <td style="padding: 5px; margin: 5px" valign="top" align="left" colspan="4">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">1
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label13" runat="server">Name <font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtnamedparter" runat="server" class="form-control txtbox"
                                                                        TabIndex="5" onkeypress="Names()" Width="180px" ValidationGroup="group">
                                                                    </asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server"
                                                            ControlToValidate="txtnamedparter" ErrorMessage="Please enter Existing Enterprise"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">3
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label14" runat="server">Community<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlcommunity" runat="server" class="txtalignright" TabIndex="5"
                                                                        Height="40px">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="1">General</asp:ListItem>
                                                                        <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                        <asp:ListItem Value="3">SC</asp:ListItem>
                                                                        <asp:ListItem Value="4">ST</asp:ListItem>
                                                                        <asp:ListItem Value="5">Minority</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <%--<asp:TextBox ID="txtcommunity" runat="server" class="form-control txtbox"
                                                                                    Height="28px" MaxLength="40" TabIndex="5" onkeypress="Names()" Width="180px"
                                                                                    ValidationGroup="group"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server"
                                                            ControlToValidate="txtcommunity" ErrorMessage="Please enter Under Expansion/Diversification Project"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">5&nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label11" runat="server">Designation<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                    <asp:DropDownList ID="ddlAuthorisedDesignation" runat="server" class="form-control txtbox"
                                                                        TabIndex="5" Height="33px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlAuthorisedDesignation_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Designation--</asp:ListItem>
                                                                        <asp:ListItem Value="GM">GM</asp:ListItem>
                                                                        <asp:ListItem Value="AGM">AGM</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="ddlAuthorisedDesignation"
                                                                                    ErrorMessage="Please Select Authorised Designation" SetFocusOnError="true" InitialValue="--Designation--" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr2" runat="server">
                                                                <td style="padding: 5px; margin: 5px">7&nbsp;
                                                                </td>
                                                                <td style="width: 200px;">
                                                                    <asp:Label ID="Label31" runat="server">Mobile No</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtDirectorMobNo" runat="server" class="form-control txtbox"
                                                                        Height="28px" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                            ControlToValidate="txtpercentage" ErrorMessage="Please enter Quantity"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr id="trdesignation" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px">&nbsp;
                                                                </td>
                                                                <td style="width: 200px;">
                                                                    <asp:Label ID="lbldesignationOther" runat="server">Other</asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtdesignationOther" runat="server" class="form-control txtbox"
                                                                        Height="28px" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                            ControlToValidate="txtpercentage" ErrorMessage="Please enter Quantity"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>


                                                        </table>
                                                    </td>
                                                    <td valign="top" colspan="4">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">2
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label15" runat="server">Share %<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtshare" runat="server" class="form-control txtbox"
                                                                        TabIndex="5" onkeypress="NumberOnly()" ValidationGroup="group"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server"
                                                            ControlToValidate="txtshare" ErrorMessage="Please enter Existing Enterprise"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">4
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label8" runat="server">Gender<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                                    <asp:DropDownList ID="ddlgender2" runat="server" class="form-control txtbox" TabIndex="5"
                                                                        Height="33px">
                                                                        <asp:ListItem Value="0">--Gender--</asp:ListItem>
                                                                        <asp:ListItem Value="M">Male</asp:ListItem>
                                                                        <asp:ListItem Value="F">Female</asp:ListItem>
                                                                        <asp:ListItem Value="T">Transgender</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="ddlgender2"
                                                                                    ErrorMessage="Please Select Gender" SetFocusOnError="true" InitialValue="--Gender--" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">6
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label32" runat="server">Email<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtDirecEmail" runat="server" class="form-control txtbox"
                                                                        onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                            ControlToValidate="txtpercentage" ErrorMessage="Please enter Quantity"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">8
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:Label ID="Label33" runat="server">PAN NO<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtDirectPAN" runat="server" class="form-control txtbox"
                                                                        onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                            ControlToValidate="txtpercentage" ErrorMessage="Please enter Quantity"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr id="trdirpercent" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px">6
                                                                </td>
                                                                <td style="width: 200px;">
                                                                    <asp:Label ID="Label16" runat="server">%<font color="red">*</font></asp:Label>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:TextBox ID="txtpercentage" runat="server" class="form-control txtbox"
                                                                        onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server"
                                                            ControlToValidate="txtpercentage" ErrorMessage="Please enter Quantity"
                                                            ValidationGroup="group">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 55px"></td>
                                                                <td align="center">
                                                                    <asp:Button ID="Button5" runat="server" CssClass="btn btn-xs btn-warning"
                                                                        TabIndex="5" Text="Add New" Width="72px" OnClick="Button5_Click" />
                                                                </td>
                                                                <td align="right">&nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="Button6" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                                        Height="28px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="8">
                                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="Both"
                                                            Width="90%" Visible="false" DataKeyNames="intLineofActivityMid" OnRowDataBound="GridView3_RowDataBound"
                                                            OnRowDeleting="GridView3_RowDeleting">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Column1" HeaderText="Name" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column2" HeaderText="Community" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column7" HeaderText="Gender" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column3" HeaderText="Share %" HeaderStyle-HorizontalAlign="Center" />
                                                                <%--<asp:BoundField DataField="Column5" HeaderText="Authorised Signatory" HeaderStyle-HorizontalAlign="Center" />--%>
                                                                <asp:BoundField DataField="Column6" HeaderText="Designation" HeaderStyle-HorizontalAlign="Center" />

                                                                <asp:BoundField DataField="Column9" HeaderText="Mobile NO" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column10" HeaderText="EMAIL ID" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column11" HeaderText="PAN NO" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column4" HeaderText="%" Visible="false" />
                                                                <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                <asp:BoundField DataField="Created_by" HeaderText="Created By" Visible="false" />
                                                                <asp:BoundField DataField="IncentiveId" HeaderText="Incentive Id" Visible="false" />
                                                                <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                            </Columns>
                                                            <%--<FooterStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <EditRowStyle BackColor="#013161" />
                                                                        <AlternatingRowStyle BackColor="White" />--%>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                Font-Names="Arial" Font-Size="9px" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px"></td>
                                                </tr>
                                            </table>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="height: 10px">
                                                        <asp:Label ID="lblpartner" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="8">
                                                        <asp:GridView ID="gvdirector2" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" CssClass="GRD" ForeColor="#333333"
                                                            GridLines="Both" Width="90%">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Column1" HeaderText="Name" />
                                                                <asp:BoundField DataField="Column2" HeaderText="Community" />
                                                                <asp:BoundField DataField="Column7" HeaderText="Gender" />
                                                                <asp:BoundField DataField="Column3" HeaderText="Share %" />
                                                                <%-- <asp:BoundField DataField="AuthorisedSign" HeaderText="Authorised Signatory" /> --%>
                                                                <asp:BoundField DataField="Authdesignation" HeaderText="Designation" />
                                                                <asp:BoundField DataField="Column4" HeaderText="%" Visible="false" />
                                                                <asp:BoundField DataField="MobileNo" HeaderText="Mobile NO" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Email" HeaderText="EMAIL ID" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="PanNO" HeaderText="PAN NO" HeaderStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                Font-Names="Arial" Font-Size="9px" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label10" runat="server">Authorised Signatory<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtAuthorisedSign" runat="server" class="txtalignright" TabIndex="5"
                                                            Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                    </td>
                                                    <%--check--%>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label25" runat="server">Mobile No<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtAuthorized_MobileNo" runat="server" class="txtalignright" TabIndex="5"
                                                            Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label26" runat="server">Email Address<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtAuthorized_EmailId" runat="server" class="txtalignright" TabIndex="5"
                                                            Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                    </td>
                                                    <%--check--%>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:Label ID="Label27" runat="server">PAN Number<font color="red">*</font></asp:Label>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:TextBox ID="txtAuthorized_PAN_NO" runat="server" class="txtalignright" TabIndex="5"
                                                            Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <caption>
                                                    <br />
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp; </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label6" runat="server">Authorised Signatory Designation<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">: </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">
                                                            <asp:DropDownList ID="ddlAuthorisedSignDesignation" runat="server" AutoPostBack="True" class="form-control txtbox" style="height:33px;border-radius: 0px !important;border: 1px solid #aaa;" OnSelectedIndexChanged="ddlAuthorisedSignDesignation_SelectedIndexChanged" TabIndex="5">
                                                                <asp:ListItem Value="NULL">--Designation--</asp:ListItem>
                                                                <asp:ListItem Value="GM">GM</asp:ListItem>
                                                                <asp:ListItem Value="AGM">AGM</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="ddlAuthorisedDesignation"
                                                                                    ErrorMessage="Please Select Authorised Designation" SetFocusOnError="true" InitialValue="--Designation--" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>--%></td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp; </td>
                                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                                            <asp:Label ID="Label28" runat="server">Correspondence Address<font color="red">*</font></asp:Label>
                                                        </td>
                                                        <td style="padding: 5px; margin: 5px">: </td>
                                                        <td class="auto-style16">
                                                            <asp:TextBox ID="txtAuthorized_CorresponAdderess" runat="server" class="form-control txtbox" Height="50px" MaxLength="500" TabIndex="5" TextMode="MultiLine" ValidationGroup="group" style="width: 180px;margin-left: 5px;border-radius: 0px !important;border: 1px solid #aaa;"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </caption>
                                        </td>

                                    </tr>
                                    <tr id="trAuthSignatoryDesignation" runat="server" visible="false">
                                        <td style="padding: 5px; margin: 5px">&nbsp;
                                        </td>
                                        <td style="width: 200px;">
                                            <asp:Label ID="Label24" runat="server">Other</asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px">
                                            <asp:TextBox ID="txtAuthSignOtherDesignation" runat="server" class="form-control txtbox"
                                                Height="28px" onkeypress="DecimalOnly()" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="Label29" runat="server">Products Manufactured <font color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:TextBox ID="txtProducts_Manufactured" runat="server" class="txtalignright" TabIndex="5"
                                                Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                        </td>
                                        <%--check--%>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="Label30" runat="server">Number of Other Existing Establishments  with Location <font color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:TextBox ID="txtNO_OtherEstablishments" runat="server" class="txtalignright" TabIndex="5"
                                                Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="Label34" runat="server">Year of Establishment<font color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:TextBox ID="txtEstablishment" runat="server" class="txtalignright" TabIndex="5"
                                                Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                        </td>
                                        <%--check--%>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">&nbsp;
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:Label ID="Label35" runat="server">Number of Employees (on Rolls and Contract)<font color="red">*</font></asp:Label>
                                        </td>
                                        <td style="padding: 5px; margin: 5px">:
                                        </td>
                                        <td style="padding: 5px; margin: 5px; text-align: left;">
                                            <asp:TextBox ID="txtNumberofEmployees" runat="server" class="txtalignright" TabIndex="5"
                                                Height="30px" Width="180px" ValidationGroup="group"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>

                                <br />
                                <table style="width: 100%; font-weight: bold;">
                                    <tr>
                                        <td colspan="8">
                                            <table style="width: 100%;" align="center">
                                                <tr>
                                                    <%--<td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" align="center" colspan="9">Employment
                                                                            </td>--%>
                                                    <td style="background: white; color: black; font-weight: bold; width: 100px; height: 30px"
                                                        align="left" colspan="9">BACKGROUND OF THE ENTERPRISE / PROMOTER
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 60px;"
                                                        align="center">Sl.No
                                                    </td>
                                                    <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 250px;"
                                                        align="center">Last 3 years in Rs Crores 
                                                    </td>
                                                    <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 200px;"
                                                        align="left">Year 1
                                                    </td>
                                                    <td style="border: solid thin white; background: #013161; color: white; border: solid thin black; width: 200px;"
                                                        align="left">Year 2  
                                                    </td>
                                                    <td style="border: solid thin white; background: #013161; color: white; border: solid thin black; width: 200px;"
                                                        align="left">Year 3 
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">1
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 250px;">Turnover
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtTurnOver_1stYear" runat="server" TabIndex="5" Width="200px"
                                                            onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator100" runat="server" ControlToValidate="txtstaffMale"
                                                            ErrorMessage="Please Enter Number of Male Staff" SetFocusOnError="true" ValidationGroup="group"
                                                            Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtTurnOver_2ndYear" runat="server" class="txtalignright" Width="200px"
                                                            onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator101" runat="server" ControlToValidate="txtfemale"
                                                            ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                            Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtTurnOver_3rdYear" runat="server" class="txtalignright" Width="200px"
                                                            onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator108" runat="server" ControlToValidate="txtfemale"
                                                            ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                            Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">2
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 250px;">EBITDA
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtEBITDA_1stYear" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" align="center"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator102" runat="server" ControlToValidate="txtsupermalecount"
                                                            ErrorMessage="Please Enter Number of Supervisory Male" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtEBITDA_2ndYear" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator103" runat="server" ControlToValidate="txtsuperfemalecount"
                                                            ErrorMessage="Please Enter Number of Supervisory FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtEBITDA_3rdYear" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator109" runat="server" ControlToValidate="txtsuperfemalecount"
                                                            ErrorMessage="Please Enter Number of Supervisory FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">3
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 250px;">Networth
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtNetworth_1stYear" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator104" runat="server" ControlToValidate="txtSkilledWorkersMale"
                                                            ErrorMessage="Please Enter Number of Skilled workers Male" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtNetworth_2ndYear" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator105" runat="server" ControlToValidate="txtSkilledWorkersFemale"
                                                            ErrorMessage="Please Enter Number of Skilled workers FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtNetworth_3rdYear" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator110" runat="server" ControlToValidate="txtSkilledWorkersFemale"
                                                            ErrorMessage="Please Enter Number of Skilled workers FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">4
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">Reserves & Surplus
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtReservesSurplus_1stYear" runat="server" class="txtalignright"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator106" runat="server" ControlToValidate="txtSemiSkilledWorkersMale"
                                                            ErrorMessage="Please Enter Number of Semi-skilled workers Male" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtReservesSurplus_2ndYear" runat="server" class="txtalignright"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator107" runat="server" ControlToValidate="txtSemiSkilledWorkersFemale"
                                                            ErrorMessage="Please Enter Number of Semi-skilled workers FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtReservesSurplus_3rdYear" runat="server" class="txtalignright"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator111" runat="server" ControlToValidate="txtSemiSkilledWorkersFemale"
                                                            ErrorMessage="Please Enter Number of Semi-skilled workers FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">5
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">Share Capital
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtShare_Capital_1stYear" runat="server" class="txtalignright"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator112" runat="server" ControlToValidate="txtSemiSkilledWorkersMale"
                                                            ErrorMessage="Please Enter Number of Semi-skilled workers Male" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtShare_Capital_2ndYear" runat="server" class="txtalignright"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator113" runat="server" ControlToValidate="txtSemiSkilledWorkersFemale"
                                                            ErrorMessage="Please Enter Number of Semi-skilled workers FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtShare_Capital_3rdYear" runat="server" class="txtalignright"
                                                            Height="28px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator114" runat="server" ControlToValidate="txtSemiSkilledWorkersFemale"
                                                            ErrorMessage="Please Enter Number of Semi-skilled workers FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; font-weight: bold;"></td>
                                    </tr>
                                </table>
                                <br />
                                <table style="width: 100%; font-weight: bold;" id="Table1" runat="server" align="center">
                                    <tr>
                                        <td style="width: 20px"></td>
                                        <td style="padding: 5px; margin: 5px; text-align: left; width: 250px" align="left">Is Power and Water applicable
                                        </td>
                                        <td align="left">:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlIspowApplicable" runat="server" Visible="true"
                                                Width="180px" Height="40px" TabIndex="5" AutoPostBack="True" OnSelectedIndexChanged="ddlIspowApplicable_SelectedIndexChanged">
                                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator87" runat="server" ControlToValidate="ddlIspowApplicable"
                                                ErrorMessage="Please select is power applicable" InitialValue="-- Select --"
                                                ValidationGroup="group" SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trpower" runat="server" visible="false">
                                       
                                        <td style="padding: 0px; margin: 5px; text-align: left; width: 250px">
                                            <strong>Power and Water Details</strong>
                                        </td>
                                        
                                        <td>
                                            <asp:DropDownList ID="ddlPowerStatus" runat="server" Visible="false" Height="55px"
                                                Width="180px" TabIndex="5" AutoPostBack="True" OnSelectedIndexChanged="ddlPowerStatus_SelectedIndexChanged1">
                                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                <asp:ListItem Value="1" Text="New Industry"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Expansion/Diversification"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="ddlPowerStatus"
                                                ErrorMessage="Please select Power Status" InitialValue="-- Select --" ValidationGroup="group"
                                                SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%; font-weight: bold;" id="tblpower1" runat="server" visible="false" padding
                                    align="center">
                                    
                                    <tr>
                                        <td colspan="7" style="border: solid thin black; background: #013161; color: white; height: 40px"
                                            align="left">
                                            <asp:Label ID="lblpowerHEAD" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; border: solid thin black; color: black; border: solid thin black"
                                            align="center">1
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left; width: 150px;">Power Released Date <span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtNewPowerReleaseDate" runat="server" class="txtalignright" TabIndex="5"
                                                Height="43px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="txtNewPowerReleaseDate"
                                                ErrorMessage="Please Select Power Release Date" SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        
                                        <td style="border: solid thin black; width: 10px; color: black; text-align: center;">2
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left; width: 130px;">Contracted load <span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtNewContractedLoad" runat="server" class="txtalignright"
                                                MaxLength="40" TabIndex="5" ValidationGroup="group" onkeypress="DecimalOnly()"
                                                Width="180px" Height="43px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtNewContractedLoad"
                                                ErrorMessage="Please Enter Contracted load " SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">Unit 
                                                                    <asp:DropDownList ID="ddlContractpowerunit" runat="server" TabIndex="5" Height="43px">
                                                                        <asp:ListItem Value="0">-- Select Unit --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                                                    </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator81" runat="server" ControlToValidate="ddlContractpowerunit"
                                                ErrorMessage="Please select Power Unit " SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        
                                    </tr>
                                    <tr>
                                        <td style="border: solid thin black; color: black; text-align: center;">3
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">Service Connection Number<span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtServiceConnectionNumber" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtServiceConnectionNumber"
                                                ErrorMessage="Please Enter Service Connection Number" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: center;">4
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">Connected load <span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtNewConnectedLoad" runat="server" class="txtalignright"
                                                TabIndex="5" Width="180px" onkeypress="DecimalOnly()" ValidationGroup="group" Height="43px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator77" runat="server" ControlToValidate="txtNewConnectedLoad"
                                                ErrorMessage="Please Enter Connected load (In HP)" SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">Unit 
                                                                    <asp:DropDownList ID="ddlConnectPowUnit" runat="server" Height="43px">
                                                                        <asp:ListItem Value="0">-- Select Unit --</asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                                                    </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator82" runat="server" ControlToValidate="ddlConnectPowUnit"
                                                ErrorMessage="Please select Connected Power Unit " SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="border: solid thin black; width: 30px; color: black; text-align: center;">5
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 130px;">Water<span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: solid thin black; color: black; text-align: left; width: 130px;">Source<span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtSource" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator141" runat="server" ControlToValidate="txtSource"
                                                ErrorMessage="Please Enter Source" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left; width: 130px;">Requirement (In Unit)<span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtRequirement" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator143" runat="server" ControlToValidate="txtRequirement"
                                                ErrorMessage="Please Enter Requirement" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left; width: 130px;">Rate per unit in Rupees<span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtRateperUnit" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator144" runat="server" ControlToValidate="txtRateperUnit"
                                                ErrorMessage="Please Enter Rate per unit" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: solid thin black; width: 30px; color: black; text-align: center;">6
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left; width: 130px;">Subsidies / Incentives availed from other State or Central Government Schemes<span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:RadioButtonList ID="rbtnIsSubsidiesIncentives" runat="server" AutoPostBack="true" OnSelectedIndexChanged="IsSubsidiesIncentives_SelectedIndexChanged">
                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator145" runat="server" ControlToValidate="rbtnIsSubsidiesIncentives"
                                                ErrorMessage="Please Enter Source" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <td id="tdIsSubsidiesIncentiveslabel" runat="server" visible="false" style="border: solid thin black; color: black; text-align: left; width: 130px;">Amount in Rupees<span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td id="tdIsSubsidiesIncentives" runat="server" visible="false" style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtIsSubsidiesIncentivesAmount" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator146" runat="server" ControlToValidate="txtIsSubsidiesIncentivesAmount"
                                                ErrorMessage="Please Enter Amount in Rupees" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: solid thin black; width: 30px; color: black; text-align: center;">7
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left; width: 130px;">Name of the Scheme,Agency/Department/Ministry<span style="font-weight: normal; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:TextBox ID="txtNameoftheScheme" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator147" runat="server" ControlToValidate="txtNameoftheScheme"
                                                ErrorMessage="Please Enter Name of the Scheme" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="border: solid thin white; color: black; text-align: left;"></td>
                                    </tr>
                                </table>
                                <table style="width: 90%; font-weight: bold;" id="tblpower2" runat="server" visible="false"
                                    align="center">
                                    <tr>
                                        <td colspan="10" style="border: solid thin black; background: #013161; color: white; height: 40px"
                                            align="left">
                                            <asp:Label ID="lblexistingpower" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 30px; text-align: center; border: solid thin black; color: black;">1
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">Power Released Date <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">
                                            <asp:TextBox ID="txtExistingPowerReleaseDate" runat="server" class="txtalignright"
                                                Height="43px" Width="180px" TabIndex="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txtExistingPowerReleaseDate"
                                                ErrorMessage="Please Select Existing Power Release Date" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; width: 30px; text-align: center;">2
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">Contracted load <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">
                                            <asp:TextBox ID="txtExistingContractedLoad" runat="server" class="txtalignright"
                                                Height="43px" MaxLength="40" TabIndex="5" ValidationGroup="group" onkeypress="DecimalOnly()"
                                                Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtExistingContractedLoad"
                                                ErrorMessage="Please Enter Contracted load (In HP)" SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:DropDownList ID="ddlExsitContractPowerUnit" runat="server" TabIndex="5">
                                                <asp:ListItem>-- Select Unit --</asp:ListItem>
                                                <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator83" runat="server" ControlToValidate="ddlExsitContractPowerUnit"
                                                ErrorMessage="Please select expansion Power Unit " SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td style="border: solid thin black; color: black; text-align: center;">
                                                                    </td>--%>
                                    </tr>
                                    <tr>
                                        <td style="border: solid thin black; color: black; text-align: center;" class="auto-style11">3
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;" class="auto-style12">Service Connection Number<span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;" class="auto-style12">
                                            <asp:TextBox ID="txtExistingServiceConnectionNO" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtExistingServiceConnectionNO"
                                                ErrorMessage="Please Enter Service Connection Number" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td class="auto-style12">
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: center;" class="auto-style11">4
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;" class="auto-style12">Connected load <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;" class="auto-style12">
                                            <asp:TextBox ID="txtExistingConnectedLoad" runat="server" class="txtalignright"
                                                TabIndex="5" Width="180px" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator49" runat="server" ControlToValidate="txtExistingConnectedLoad"
                                                ErrorMessage="Please Enter Existing Contracted loan" SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td class="auto-style12">
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: center;" class="auto-style13">
                                            <asp:DropDownList ID="ddlExistConnectPowerUnit" runat="server">
                                                <asp:ListItem>-- Select Unit --</asp:ListItem>
                                                <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator84" runat="server" ControlToValidate="ddlExistConnectPowerUnit"
                                                ErrorMessage="Please select expansion Power Unit " SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td class="auto-style12">
                                                                    </td>--%>
                                    </tr>
                                    <tr>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td colspan="8" style="border: solid thin black; background: #013161; color: white; height: 40px"
                                            align="left">
                                            <asp:Label ID="lblexpandiverpower" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border: solid thin black; color: black; text-align: left;">1
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">Power Released Date <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">
                                            <asp:TextBox ID="txtExpanDiverPowerReleaseDate" runat="server" class="txtalignright"
                                                Height="43px" Width="180px" TabIndex="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txtExpanDiverPowerReleaseDate"
                                                ErrorMessage="Please Select Existing Power Release Date" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: left;">2
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">Contracted load <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">
                                            <asp:TextBox ID="txtExpanDiverContractedLoad" runat="server" class="txtalignright"
                                                Height="43px" MaxLength="40" TabIndex="5" ValidationGroup="group" onkeypress="DecimalOnly()"
                                                Width="180px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtExpanDiverContractedLoad"
                                                ErrorMessage="Please Enter Diversification Contracted loan" SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:DropDownList ID="ddlDiversPowContrUnit" runat="server">
                                                <asp:ListItem Value="0">-- Select Unit --</asp:ListItem>
                                                <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator85" runat="server" ControlToValidate="ddlDiversPowContrUnit"
                                                ErrorMessage="Please select Diversification Power Unit " SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                    </tr>
                                    <tr>
                                        <td style="border: solid thin black; color: black; text-align: left;">3
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">Service Connection Number<span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">
                                            <asp:TextBox ID="txtExpanDiverServiceConnectionNO" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txtExpanDiverServiceConnectionNO"
                                                ErrorMessage="Please Enter Service Connection No." SetFocusOnError="true" ValidationGroup="group"
                                                Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: left;">4&nbsp;
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">Connected load <span style="font-weight: bold; color: Red;">*</span>
                                        </td>
                                        <td style="border: solid thin black; color: black; text-align: left;">
                                            <asp:TextBox ID="txtExpanDiverConnectedLoad" runat="server" class="txtalignright"
                                                Height="43px" TabIndex="5" Width="180px" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator48" runat="server" ControlToValidate="txtExpanDiverConnectedLoad"
                                                ErrorMessage="Please Enter Diversification Connected Load." SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                        <td style="border: solid thin black; color: black; text-align: center; width: 180px;">
                                            <asp:DropDownList ID="ddlDiverpowConnectUnit" runat="server">
                                                <asp:ListItem Value="0">-- Select Unit --</asp:ListItem>
                                                <asp:ListItem Value="1" Text="HP"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="KVA"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator86" runat="server" ControlToValidate="ddlDiverpowConnectUnit"
                                                ErrorMessage="Please select Diversification Power Unit " SetFocusOnError="true"
                                                ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                        </td>
                                        <%--<td>
                                                                    </td>--%>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px; margin: 5px; vertical-align: middle;"></td>
                                    </tr>
                                </table>
                                <br />
                                <table style="width: 100%; font-weight: bold;">
                                    <tr>
                                        <td colspan="8">
                                            <table style="width: 100%;" align="center">
                                                <tr>
                                                    <%--<td style="padding: 5px; margin: 5px; text-align: left; font-weight: bold; height: 50px" align="center" colspan="9">Employment
                                                                            </td>--%>
                                                    <td style="background: white; color: black; font-weight: bold; width: 100px; height: 30px"
                                                        align="left" colspan="9">Employment
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 60px;"
                                                        align="center">Sl.No
                                                    </td>
                                                    <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 250px;"
                                                        align="center">Cadare
                                                    </td>
                                                    <td style="border: solid thin black; border-top: solid thin black; border-right: solid thin white; background: #013161; color: white; width: 200px;"
                                                        align="left">Male(Nos)
                                                    </td>
                                                    <td style="border: solid thin white; background: #013161; color: white; border: solid thin black; width: 200px;"
                                                        align="left">Female(Nos)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">1
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 250px;">Management & Staff
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtstaffMale" runat="server" TabIndex="5" Width="200px"
                                                            onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="txtstaffMale"
                                                            ErrorMessage="Please Enter Number of Male Staff" SetFocusOnError="true" ValidationGroup="group"
                                                            Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtfemale" runat="server" class="txtalignright" Width="200px"
                                                            onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="txtfemale"
                                                            ErrorMessage="Please Enter Number of FeMale Staff" SetFocusOnError="true" ValidationGroup="group"
                                                            Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">2
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 250px;">Supervisory
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtsupermalecount" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" align="center"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="txtsupermalecount"
                                                            ErrorMessage="Please Enter Number of Supervisory Male" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtsuperfemalecount" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator39" runat="server" ControlToValidate="txtsuperfemalecount"
                                                            ErrorMessage="Please Enter Number of Supervisory FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">3
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 250px;">Skilled workers
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtSkilledWorkersMale" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="txtSkilledWorkersMale"
                                                            ErrorMessage="Please Enter Number of Skilled workers Male" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtSkilledWorkersFemale" runat="server" class="txtalignright"
                                                            Width="200px" onkeypress="return inputOnlyNumbers(event)" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="txtSkilledWorkersFemale"
                                                            ErrorMessage="Please Enter Number of Skilled workers FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 20px;">4
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">Semi-skilled workers
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;"
                                                        align="center">
                                                        <asp:TextBox ID="txtSemiSkilledWorkersMale" runat="server" class="txtalignright"
                                                            Height="43px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="txtSemiSkilledWorkersMale"
                                                            ErrorMessage="Please Enter Number of Semi-skilled workers Male" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; border: solid thin black; width: 200px;">
                                                        <asp:TextBox ID="txtSemiSkilledWorkersFemale" runat="server" class="txtalignright"
                                                            Height="43px" onkeypress="return inputOnlyNumbers(event)" Width="200px" TabIndex="5"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator47" runat="server" ControlToValidate="txtSemiSkilledWorkersFemale"
                                                            ErrorMessage="Please Enter Number of Semi-skilled workers FeMale" SetFocusOnError="true"
                                                            ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; font-weight: bold;"></td>
                                    </tr>
                                </table>
                                <table style="width: 100%; font-weight: bold;">
                                    <tr>
                                        <td colspan="9"></td>
                                        <td align="right">
                                            <asp:Button Text="Previous" CssClass="btn btn-warning" Height="50px" Width="150px"
                                                Font-Size="Large" ForeColor="White" TabIndex="5" ID="btntab3previous" runat="server"
                                                OnClick="btntab3previous_Click" />
                                            &nbsp;&nbsp;&nbsp
                                                                    <asp:Button Text="Next" CssClass="btn btn-warning" Height="50px" Width="150px" Font-Size="Large"
                                                                        TabIndex="5" ForeColor="White" ID="btntab3next" runat="server" OnClick="btntab3next_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 20px; font-weight: bold;"></td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View4" runat="server">

                                <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                                    <tr>
                                        <td>
                                            <table style="width: 100%; font-weight: bold;">
                                                <tr>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <span style="font-weight: bold;">MEANS OF FINANCE (IN RUPEES)</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">1
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Promoter’s Equity<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtPromotersEquity_MF" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator115" runat="server" ControlToValidate="txtBranchName"
                                                                                    ErrorMessage="Please Enter Bank Name" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">2
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Institution Equity<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtInstitutionEquity_MF" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator122" runat="server" ControlToValidate="ddlAccountType"
                                                                                    ErrorMessage="Please Enter Account Type" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">3
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Term Loans<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtTermsLoans_MF" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator116" runat="server" ControlToValidate="txtBranchName"
                                                                                    ErrorMessage="Please Enter Bank Name" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">4
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Others<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtOthers_MF" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator117" runat="server" ControlToValidate="ddlAccountType"
                                                                                    ErrorMessage="Please Enter Account Type" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">5
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Seed Capital<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtSeedCapital_MF" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator118" runat="server" ControlToValidate="txtAccountName"
                                                                                    ErrorMessage="Please Enter Account Name" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">6
                                                                            </td>
                                                                            <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">Subsidy / Grants through other agencies<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtSubsidyGrantsAgencies_MF" runat="server" class="form-control txtbox"
                                                                                    MaxLength="25" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator119" runat="server" ControlToValidate="txtAccNumber"
                                                                                    ErrorMessage="Please Enter Bank Account Number" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px; font-weight: bold;"></td>
                                                </tr>
                                            </table>

                                        </td>
                                    </tr>
                                </table>
                                <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">


                                    <tr>
                                        <td colspan="9">
                                            <table style="width: 100%; font-weight: bold;">
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" colspan="9">Implementation Steps Taken - Project Finance
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left; width: 100%;" colspan="9">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Have you availed Term Loan:<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlIsTermLoanAvailed" runat="server" class="form-control txtbox"
                                                                        Height="33px" MaxLength="80" TabIndex="5" ValidationGroup="Save" Width="180px"
                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddlIsTermLoanAvailed_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator91" runat="server" ControlToValidate="ddlIsTermLoanAvailed"
                                                                        InitialValue="0" ErrorMessage="Please Select Term Loan Availability" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Subsidies / Incentives availed from other State or Central Government Schemes:<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList  Width="180px" ID="ddlIncentivesAvaild_StateCentrlGovt" runat="server" class="form-control txtbox"
                                                                        Height="33px" MaxLength="80" TabIndex="5" ValidationGroup="Save">
                                                                        <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="2">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator120" runat="server" ControlToValidate="ddlIsTermLoanAvailed"
                                                                        InitialValue="0" ErrorMessage="Please Select Term Loan Availability" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Name of the Scheme, Agency / Department / Ministry:<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px;">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtNameOfScheme_Agency" runat="server" class="form-control txtbox"
                                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator121" runat="server" ControlToValidate="ddlIsTermLoanAvailed"
                                                                        InitialValue="0" ErrorMessage="Please Select Term Loan Availability" SetFocusOnError="true"
                                                                        ValidationGroup="group" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100%;" colspan="9">
                                                        <table style="width: 100%; font-weight: bold;" id="tblTermLoanDtls" runat="server"
                                                            visible="false">
                                                            <tr id="trTermLoanLine1" runat="server">
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="auto-style17">1
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Term Loan No<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:DropDownList ID="ddlTermLoanNo" runat="server" class="form-control txtbox" Height="33px"
                                                                        MaxLength="40" TabIndex="5" ValidationGroup="group">
                                                                        <asp:ListItem Value="--Select--" Text="Select Term Loan Type"></asp:ListItem>
                                                                        <asp:ListItem Value="TermLoan1" Text="Term Loan1"></asp:ListItem>
                                                                        <asp:ListItem Value="TermLoan2" Text="Term Loan2"></asp:ListItem>
                                                                        <asp:ListItem Value="TermLoan3" Text="Term Loan3"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator89" runat="server" ControlToValidate="ddlTermLoanNo"
                                                                        ErrorMessage="Please Select Term Loan No ." SetFocusOnError="true" ValidationGroup="group1"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;">2
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 25%">Date of application for Term Loan<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txttermload" runat="server" class="form-control txtbox"
                                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator40" runat="server" ControlToValidate="txttermload"
                                                                        ErrorMessage="Please Enter Term Loan Application Date." SetFocusOnError="true"
                                                                        ValidationGroup="group1" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trTermLoanLine2" runat="server">
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style17">3
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Name of the Institution<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtnmofinstitution" runat="server" class="form-control txtbox"
                                                                        MaxLength="80" TabIndex="5" onkeypress="Names()" ValidationGroup="Save"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtnmofinstitution"
                                                                        ErrorMessage="Please Enter Name of the Institution" SetFocusOnError="true" ValidationGroup="group1"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;">4
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Term Loan Sanctioned reference No.<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtsactionedloan" runat="server" class="form-control txtbox" TabIndex="5"
                                                                        Height="43px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator50" runat="server" ControlToValidate="txtsactionedloan"
                                                                        ErrorMessage="Please Enter Term Loan Sanctioned reference No." SetFocusOnError="true"
                                                                        ValidationGroup="group1" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trTermLoanLine3" runat="server">
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="auto-style17">5
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">Term Loan Sanctioned Date<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">:
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <asp:TextBox ID="txtdatesome" runat="server" class="form-control txtbox"
                                                                        MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator51" runat="server" ControlToValidate="txtdatesome"
                                                                        ErrorMessage="Please Enter Term Loan Sanctioned Date." SetFocusOnError="true"
                                                                        ValidationGroup="group1" Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;">6
                                                                </td>
                                                                <td align="left">Term Loan 1ST Released Date<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td align="right">&nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTermLoanReleasedDate" runat="server" class="form-control txtbox"
                                                                        Height="43px" MaxLength="40" onkeypress="NumberOnly()" TabIndex="5" ValidationGroup="group"
                                                                        Width="180px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px">
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator78" runat="server" ControlToValidate="txtTermLoanReleasedDate"
                                                                        ErrorMessage="Please Enter Term Loan Released Date." SetFocusOnError="true" ValidationGroup="group1"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trTermLoanLine6" runat="server">
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;" class="auto-style17">&nbsp;
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                <td style="padding: 5px; margin: 5px"></td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                                <td></td>
                                                                <td style="padding: 5px; margin: 5px; vertical-align: middle;"></td>
                                                                <td align="center">
                                                                    <asp:Button ID="btnTermloanAdd" runat="server" CssClass="btn btn-xs btn-warning"
                                                                        Height="43px" TabIndex="5" Text="Add New" Width="72px" OnClick="btnTermloanAdd_Click" />
                                                                </td>
                                                                <td align="right">&nbsp;
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnTermLoanClear" runat="server" CausesValidation="False" CssClass="btn btn-xs btn-danger"
                                                                        Height="43px" TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" Width="73px" />
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px"></td>
                                                            </tr>
                                                            <tr id="trTermLoanLine4" runat="server">
                                                                <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="9">
                                                                    <asp:GridView ID="GVTermLoandtls" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="Both"
                                                                        Width="90%" Visible="false" OnRowDataBound="GVTermLoandtls_RowDataBound" DataKeyNames="intLineofActivityMid"
                                                                        OnRowDeleting="GVTermLoandtls_RowDeleting">
                                                                        <RowStyle BackColor="#ffffff" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField DataField="Column1" HeaderText="Term Loan No" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column2" HeaderText="Application Date" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column3" HeaderText="Institute Name" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column4" HeaderText="Term Loan Sanctioned Date" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column7" HeaderText="Term Loan Sanctioed Reference No"
                                                                                HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:BoundField DataField="Column6" HeaderText="Term Loan Released Date" HeaderStyle-HorizontalAlign="Center" />
                                                                            <asp:CommandField HeaderText="Delete" ShowDeleteButton="True" />
                                                                            <asp:BoundField DataField="Createdby" HeaderText="Created By" Visible="false" />
                                                                            <asp:BoundField DataField="IncentveID" HeaderText="Incentive Id" Visible="false" />
                                                                            <asp:CommandField HeaderText="Edit" ShowSelectButton="True" Visible="False" />
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                                        <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                            HorizontalAlign="Center" />
                                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                                        <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                            Font-Names="Arial" Font-Size="9px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="trTermLoanLine5" runat="server">
                                                    <td style="padding: 5px; margin: 5px" valign="top" align="center" colspan="9">
                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderColor="#003399"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="#333333" GridLines="Both"
                                                            Width="90%" Visible="false">
                                                            <RowStyle BackColor="#ffffff" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Column1" HeaderText="Term Loan No" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column2" HeaderText="Application Date" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column3" HeaderText="Institute Name" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column4" HeaderText="Term Loan Sanctioned Date" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column7" HeaderText="Term Loan Sanctioed Reference No"
                                                                    HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Column6" HeaderText="Term Loan Released Date" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Createdby" HeaderText="Created By" Visible="false" />
                                                                <asp:BoundField DataField="IncentveID" HeaderText="Incentive Id" Visible="false" />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#013161" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#013161" ForeColor="White" HorizontalAlign="Center" />
                                                            <AlternatingRowStyle BackColor="#D5E6F9" ForeColor="#284775" />
                                                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" Font-Size="12px"
                                                                HorizontalAlign="Center" />
                                                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                            <FooterStyle HorizontalAlign="Center" BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"
                                                                Font-Names="Arial" Font-Size="9px" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr id="tris1" runat="server" visible="false">
                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">Have you availed subsidy earlier<span style="font-weight: bold; color: Red;">*</span>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlsubsidy" runat="server" class="form-control txtbox"
                                                            MaxLength="80" TabIndex="5" ValidationGroup="Save" Width="180px" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlsubsidy_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="ddlsubsidy"
                                                            ErrorMessage="Please Select availed subsidy" SetFocusOnError="true" ValidationGroup="group"
                                                            Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="9">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px;text-align:left; margin: 5px" valign="top" colspan="10" >
                                                                    <asp:Label ID="Label17" runat="server" CssClass="LBLBLACK" Font-Bold="True">Approved/Estimated projected cost, term loan sanctioned and released, assets acquired etc<font color="red">*</font></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="9" valign="top">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">&nbsp;&nbsp;&nbsp;Name of Asset&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Approved Project
                                                                                            <br />
                                                                                Cost (In Rs.)
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Loan Sanctioned
                                                                                            <br />
                                                                                (In Rs.)
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Equity from
                                                                                            <br />
                                                                                the promoters
                                                                                            <br />
                                                                                (In Rs.)
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Loan Amount
                                                                                            <br />
                                                                                Released (In Rs.)
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Value of assets (as
                                                                                            <br />
                                                                                certified by financial<br />
                                                                                institution) (In Rs.)
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">Value of assets certified
                                                                                            <br />
                                                                                by Chartered Accoutant
                                                                                            <br />
                                                                                (In Rs.)
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">1
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">2&nbsp;
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">3
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">4
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">5
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">6
                                                                            </td>
                                                                            <td align="center" style="border: solid thin white; background: #013161; color: white">7
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black; background: white; color: black">Land
                                                                            </td>
                                                                            <td style="padding-top: 5px; border: solid thin black; background: white; color: black;">
                                                                                <asp:TextBox ID="txtLand2" runat="server" class="form-control txtbox"
                                                                                    TabIndex="5" onkeypress="DecimalOnly()" ValidationGroup="group" ></asp:TextBox>
                                                                            </td>
                                                                            <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtLand3" runat="server" class="form-control txtbox"
                                                                                    TabIndex="5" onkeypress="DecimalOnly()" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtLand4" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtLand5" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtLand6" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="padding-top: 5px; border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtLand7" runat="server" class="form-control txtbox"
                                                                                    AutoPostBack="false" onkeypress="DecimalOnly()" MaxLength="40" TabIndex="5" OnTextChanged="txtLand7_TextChanged"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black; background: white; color: black">Buildings
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtBuilding2" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtBuilding3" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtBuilding4" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtBuilding5" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtBuilding6" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtBuilding7" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    OnTextChanged="txtBuilding7_TextChanged"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black; background: white; color: black">Plant & Machinery
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtPM2" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtPM3" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtPM4" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtPM5" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtPM6" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtPM7" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                                    OnTextChanged="txtPM7_TextChanged"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black; background: white; color: black">Machinery Contingencies
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtMCont2" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtMCont3" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtMCont4" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtMCont5" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtMCont6" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtMCont7" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black; background: white; color: black">Erection
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtErec2" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtErec3" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtErec4" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtErec5" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtErec6" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtErec7" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black; background: white; color: black">Technical know-how,<br />
                                                                                feasibility study
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtTFS2" runat="server" class="form-control txtbox" Height="40px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtTFS3" runat="server" class="form-control txtbox" Height="40px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtTFS4" runat="server" class="form-control txtbox" Height="40px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtTFS5" runat="server" class="form-control txtbox" Height="40px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtTFS6" runat="server" class="form-control txtbox" Height="40px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtTFS7" runat="server" class="form-control txtbox" Height="40px"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border: solid thin black; background: white; color: black">Working Capital
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtWC2" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtWC3" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtWC4" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtWC5" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtWC6" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td style="border: solid thin black; background: white; color: black">
                                                                                <asp:TextBox ID="txtWC7" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <%--<tr>
                                                                    <td style="border:solid thin black; background: white; color:black">Total</td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal2" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal3" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal4" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal5" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal6" runat="server"></asp:Label></td>
                                                                    <td style="border:solid thin black; background: white; color:black">
                                                                        <asp:Label ID="lbltotal7" runat="server"></asp:Label></td>                                                                                    
                                                                </tr>--%>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px" valign="top">
                                                                    <table style="width: 100%; font-weight: bold;">
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; width: 100%" valign="top">
                                                                                <strong>Note :</strong> The data on the above should be prior to date of filing
                                                                                            of claim or within 6 months of Commencement of Production, whichever is earlier
                                                                                            in case of aided Enterprise/Industry. If it is self financed Enterprise/Industry,
                                                                                            the data on the above should be prior to date of commencement of Commercial Production.
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px"></td>
                                                </tr>
                                                <tr>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;"></td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;" width="300px;">Have you Installed Secondhand machinery<span style="font-weight: bold; color: Red;">*</span>
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; width: 1px">:
                                                    </td>
                                                    <td style="padding: 5px; margin: 5px; text-align: left;">
                                                        <asp:DropDownList ID="ddlHvuInstalledScndhndMech" runat="server" class="form-control txtbox"
                                                            Height="33px" MaxLength="80" TabIndex="5" ValidationGroup="group" Width="180px"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlHvuInstalledScndhndMech_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlHvuInstalledScndhndMech"
                                                            ErrorMessage="Please Select subsidy" SetFocusOnError="true" ValidationGroup="group"
                                                            InitialValue="-- SELECT --" Display="None">*</asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px"></td>
                                                </tr>
                                                <tr id="trSecondhandmachinery" runat="server" visible="false">
                                                    <td colspan="9">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="border: solid thin white; background: #013161; color: white" align="center">Second hand machinery
                                                                                <br />
                                                                    value in Rs
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">New machinery value in Rs
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">Total value in Rs<br />
                                                                    (1+2)
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">% of second hand machinery
                                                                                <br />
                                                                    value in total machinery value
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">Value of the machinery
                                                                                <br />
                                                                    purchaced from TSIDC<br />
                                                                    /TSSFC/Bank in Rs
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">Total value in Rs
                                                                                <br />
                                                                    (2+5)
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">1
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">2
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">3
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">4
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">5
                                                                </td>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white">6
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="border: solid thin white; background: #013161; color: white">
                                                                    <asp:TextBox ID="txtsecondhndmachine" runat="server" class="form-control txtbox"
                                                                        Height="43px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                        AutoPostBack="True" OnTextChanged="txtsecondhndmachine_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="border: solid thin white; background: #013161; color: white">
                                                                    <asp:TextBox ID="txtnewmachine" runat="server" class="form-control txtbox"
                                                                        Height="43px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                        AutoPostBack="True" OnTextChanged="txtnewmachine_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="border: solid thin white; background: #013161; color: white">
                                                                    <asp:TextBox ID="txtTotalvalue12" runat="server" class="form-control txtbox"
                                                                        Height="43px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                        AutoPostBack="True" Enabled="False" OnTextChanged="txtTotalvalue12_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="border: solid thin white; background: #013161; color: white">
                                                                    <asp:TextBox ID="txtpercentage12" runat="server" class="form-control txtbox"
                                                                        Height="43px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td style="border: solid thin white; background: #013161; color: white">
                                                                    <asp:TextBox ID="txtmachinepucr" runat="server" class="form-control txtbox"
                                                                       Height="43px" MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                        AutoPostBack="True" OnTextChanged="txtmachinepucr_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="border: solid thin white; background: #013161; color: white">
                                                                    <asp:TextBox ID="txttotal25" runat="server" class="form-control txtbox"
                                                                      Height="43px"  MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" ValidationGroup="group"
                                                                        Enabled="False"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="border: solid thin white; background: #013161; color: white; height: 1px"
                                                                    colspan="6"></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px" colspan="9"></td>
                                                </tr>
                                                <tr>
                                                    
                                                    <td colspan="9" style="text-align:left;"><strong>Registration with Commercial taxes Department Registration</strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="9">
                                                        <table style="width: 100%; font-weight: bold;">
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">1
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 200px">TIN/ VAT/ CST/ GST No.<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td>:
                                                                </td>
                                                                <td class="auto-style16">
                                                                    <asp:TextBox ID="txtvatno" runat="server" class="form-control txtbox"
                                                                        MaxLength="100" TabIndex="5" Width="150px" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td></td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">2
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 200px">Registration Date.<span style="font-weight: bold; color: Red;"></span>
                                                                </td>
                                                                <td>:
                                                                </td>
                                                                <td class="auto-style16">
                                                                    <asp:TextBox ID="txtCSTRegDate" runat="server" class="form-control txtbox"
                                                                        MaxLength="100" TabIndex="5" Width="150px"> </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="txtCSTRegDate"
                                                                                    ErrorMessage="Please Select Registration Date." SetFocusOnError="true" ValidationGroup="group"
                                                                                    Display="None">*</asp:RequiredFieldValidator>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td  colspan="9"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">3
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 200px">Registring Authority<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCSTRegAuthority" runat="server" class="form-control txtbox"
                                                                        MaxLength="100" TabIndex="5" Width="150px" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator53" runat="server" ControlToValidate="txtCSTRegAuthority"
                                                                        ErrorMessage="Please Enter Registration Authority." SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">4
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 200px">Registering Authority Address.<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td>:
                                                                </td>
                                                                <td class="auto-style16">
                                                                    <asp:TextBox ID="txtCSTRegAuthAddress" runat="server" class="form-control txtbox"
                                                                        Height="50px" MaxLength="500" TabIndex="5" TextMode="MultiLine" ValidationGroup="group"
                                                                        Width="200px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator52" runat="server" ControlToValidate="txtCSTRegAuthAddress"
                                                                        Display="None" ErrorMessage="Please Enter Registration Authority Address." SetFocusOnError="true"
                                                                        ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <caption>
                                                                &nbsp;</caption>
                                                            <tr id="trEMpartNo1" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">6
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left;" class="auto-style15">GST No.<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtGSTNo" runat="server" class="form-control txtbox"
                                                                        MaxLength="100" TabIndex="5" ValidationGroup="group" Width="150px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator76" runat="server" ControlToValidate="txtGSTNo"
                                                                        Display="None" ErrorMessage="Please Enter GST No." SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">7
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: left; width: 100px">GST Date.<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td>:
                                                                </td>
                                                                <td class="auto-style16">
                                                                    <asp:TextBox ID="txtGSTDate" runat="server" class="form-control txtbox"
                                                                        MaxLength="100" TabIndex="5" ValidationGroup="group" Width="150px"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator65" runat="server" ControlToValidate="txtGSTDate"
                                                                        Display="None" ErrorMessage="Please Enter GST Date." SetFocusOnError="true" ValidationGroup="group">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trEMpartNo" runat="server" visible="false">
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">8
                                                                </td>
                                                                <td>EM Part - II/IEM/IL No.
                                                                </td>
                                                                <td>:
                                                                </td>
                                                                <td class="auto-style16">
                                                                    <asp:TextBox ID="txtEmpart" runat="server" class="form-control txtbox"
                                                                        MaxLength="100" TabIndex="5" ValidationGroup="group" Width="150px"></asp:TextBox>
                                                                </td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px"></td>
                                                                <td style="padding: 5px; margin: 5px; text-align: center; width: 20px">2&nbsp;
                                                                </td>
                                                                <td class="auto-style15">&nbsp; CST No.<span style="font-weight: bold; color: Red;">*</span>
                                                                </td>
                                                                <td>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtcstno" runat="server" class="form-control txtbox"
                                                                        MaxLength="100" TabIndex="5" Width="150px" ValidationGroup="group"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator80" runat="server" ControlToValidate="txtcstno"
                                                                        ErrorMessage="Please Enter CST No." SetFocusOnError="true" ValidationGroup="group"
                                                                        Display="None">*</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <caption>
                                                    <b>Term Loan details:</b>
                                                    <br />
                                                </caption>
                                            </table>



                                            <table style="width: 100%; font-weight: bold;">
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td align="right"></td>
                                                   <td align="right" style="padding-right: 50px !important;">
                                                        <asp:Button ID="btntab4previous" runat="server" CssClass="btn btn-warning" Font-Size="Large"
                                                            ForeColor="White" Height="50px" OnClick="btntab4previous_Click" TabIndex="5"
                                                            Text="Previous" Width="150px" />
                                                        &nbsp;&nbsp;&nbsp;
                                                                    <asp:Button ID="btntab4next" runat="server" CssClass="btn btn-warning" Font-Size="Large"
                                                                        ForeColor="White" Height="50px" OnClick="btntab4next_Click" TabIndex="5" Text="Next"
                                                                        Width="150px"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px; font-weight: bold;"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                            <asp:View ID="View6" runat="server">
                                <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                                    <tr>
                                        <td>
                                            <table style="width: 100%; font-weight: bold;">
                                                <tr>
                                                    <td>
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td align="left" style="padding: 5px; margin: 5px; text-align: left;">
                                                                    <span style="font-weight: bold;">Bank Details</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                                                    <table cellpadding="4" cellspacing="5" style="width: 100%">
                                                                        <tr>
                                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">1
                                                                            </td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">Name of the Bank
                                                                            </td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;" colspan="6">
                                                                                <asp:DropDownList ID="ddlBank" runat="server" class="form-control txtbox" TabIndex="5"
                                                                                    ValidationGroup="group">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvBank" runat="server" InitialValue="-- SELECT --"
                                                                                    ControlToValidate="ddlBank" ErrorMessage="Please Select Bank Name" ValidationGroup="group"
                                                                                    SetFocusOnError="true" Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">2
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Branch Name<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtBranchName" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator54" runat="server" ControlToValidate="txtBranchName"
                                                                                    ErrorMessage="Please Enter Bank Name" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: center; vertical-align: middle;">3
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Account Type<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:DropDownList ID="ddlAccountType" runat="server" class="form-control txtbox"
                                                                                    Height="33px" MaxLength="40" TabIndex="5" ValidationGroup="group">
                                                                                    <asp:ListItem Value="0" Text="-- SELECT --"> </asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator88" runat="server" ControlToValidate="ddlAccountType"
                                                                                    ErrorMessage="Please Enter Account Type" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left; vertical-align: middle;">4
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">Account Holder Name<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtAccountName" runat="server" class="form-control txtbox"
                                                                                    MaxLength="40" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator90" runat="server" ControlToValidate="txtAccountName"
                                                                                    ErrorMessage="Please Enter Account Name" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px; vertical-align: middle;">5
                                                                            </td>
                                                                            <td class="style23" style="padding: 5px; margin: 5px; text-align: left;">Account Number<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td class="style21" style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtAccNumber" runat="server" class="form-control txtbox"
                                                                                    MaxLength="25" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvAcNo" runat="server" ControlToValidate="txtAccNumber"
                                                                                    ErrorMessage="Please Enter Bank Account Number" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">6
                                                                            </td>
                                                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">IFSC Code<%--<span style="font-weight: bold; color: Red;">*</span>--%></td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="txtIfscCode" runat="server" class="form-control txtbox"
                                                                                    MaxLength="12" TabIndex="5" ValidationGroup="group"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="rfvIFSCCode" runat="server" ControlToValidate="txtIfscCode"
                                                                                    ErrorMessage="Please Enter IFSC Code" ValidationGroup="group" SetFocusOnError="true"
                                                                                    Display="None">*</asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td colspan="3">
                                                                                <a href="https://www.bankifsccode.com/" target="_blank">Find IFSC code</a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" id="powertr1" visible="false">
                                                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">&nbsp;
                                                                            </td>
                                                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Whether you have Power Connection Incentive
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:DropDownList ID="ddlPower" runat="server" AutoPostBack="True" class="form-control txtbox"
                                                                                    OnSelectedIndexChanged="ddlPower_SelectedIndexChanged" TabIndex="5">
                                                                                    <asp:ListItem Value="-1">-- Select --</asp:ListItem>
                                                                                    <asp:ListItem Value="0">No</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator72" runat="server" InitialValue="-- Select --"
                                                                                    ControlToValidate="ddlPower" ErrorMessage="Please Select Power" ValidationGroup="group"
                                                                                    SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                                                            </td>
                                                                            <td colspan="3">&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" id="powertr" visible="false">
                                                                            <td style="padding: 5px; margin: 5px; width: 10px; vertical-align: middle;">&nbsp;
                                                                            </td>
                                                                            <td class="style20" style="padding: 5px; margin: 5px; text-align: left;">Request to Department
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px">:
                                                                            </td>
                                                                            <td style="padding: 5px; margin: 5px; text-align: left;">
                                                                                <asp:TextBox ID="TxtRequesttoDepartment" runat="server" class="form-control txtbox"
                                                                                    Height="72px" MaxLength="450" TabIndex="5" ValidationGroup="Save"></asp:TextBox>
                                                                            </td>
                                                                            <td colspan="3" style="color: #FF0000">Please contact Industry Department for futher process and Register this in help
                                                                                            desk
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px; font-weight: bold;"></td>
                                                </tr>
                                            </table>
                                            <table style="width: 100%; font-weight: bold;">
                                                <tr>
                                                    <td></td>
                                                    <td colspan="8" align="right">
                                                        <asp:Button Text="Previous" CssClass="btn btn-warning" Height="50px" TabIndex="5"
                                                            Width="150px" Font-Size="Large" ValidationGroup="group" ForeColor="White" BorderStyle="Solid"
                                                            ID="btntab6previous" runat="server" OnClick="btntab6previous_Click" />&nbsp;&nbsp;&nbsp
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 20px; font-weight: bold;"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:View>
                        </asp:MultiView>
                        <table style="width: 100%; border-width: 1px; border-color: #666; border-style: solid; font-weight: bold;">
                            <tr>
                                <td align="center" style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave" runat="server" CssClass="btn btn-primary" Height="40px"
                                        Visible="false" Width="190px" TabIndex="5" Text="Submit" OnClick="BtnSave_Click" />
                                    <span style="padding-left: 5px;">
                                        <asp:Button ID="BtnClear" runat="server" CausesValidation="False" CssClass="btn btn-warning"
                                            Height="40px" TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" Width="190px"
                                            OnClick="BtnClear_Click" />
                                    </span><span style="padding-left: 5px;">
                                        <asp:Button ID="btnNext" runat="server" CssClass="btn btn-warning" Height="40px"
                                            Width="190px" Text="Next" Visible="false" OnClick="btnNext_Click" TabIndex="5" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100%">
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
                                    <div>
                                        <h1 class="page-subhead-line">
                                            <asp:HiddenField ID="hdnfldtsiic" runat="server" />
                                        </h1>
                                    </div>
                                </td>
                            </tr>
                            </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HiddenField ID="hdfID" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="group" />
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="child" />
                            <asp:HiddenField ID="hdfFlagID" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                ShowSummary="False" ValidationGroup="group1" />
                        </td>
                    </tr>
                        </table>


                    </div>
                </div>
            </div>


            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
   
<%--    <script src="../../Resource/Scripts/js/jquery.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../Resource/Scripts/js/plugins/morris/raphael.min.js"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris.min.js" type="text/javascript"></script>
    <script src="../../Resource/Scripts/js/plugins/morris/morris-data.js" type="text/javascript"></script>
    <link href="../../Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/sb-admin.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/css/plugins/morris.css" rel="stylesheet" type="text/css" />
    <link href="../../Resource/Styles/font-awesome/css/font-awesome.css" rel="stylesheet" />--%>
    <link href="../../css/ui-lightness/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
    <script src="../../js/jquery-1.7.2.min.js"></script>
    <script src="../../js/jquery-ui-1.8.19.custom.min.js"></script>
    <link href="<%= ResolveUrl("css/ui-lightness/jquery-ui-1.8.19.custom.css") %>" rel="stylesheet"
        type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("js/jquery-1.7.2.min.js") %>"></script>
    <script src="<%= ResolveUrl("js/jquery-ui-1.8.19.custom.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript">
        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='txtDateofCommencement']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtDateOfIncorporation']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback



            $("input[id$='txtNewPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

            $("input[id$='txttermload']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtdatesome']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

            $("input[id$='txtCSTRegDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            //added newly
            $("input[id$='txtUdyogAadhaarRegdDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtGSTDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

        }
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $("input[id$='txtDateofCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='txtNewPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback   

            $("input[id$='txtExistingPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtExpanDiverPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txttermload']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='txtdatesome']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtCSTRegDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 
            //added newly
            $("input[id$='txtGSTDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtdateofreg']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback 

            $("input[id$='txtTermLoanReleasedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback  

        });
    </script>
    <style type="text/css">
        .ui at k r font- 8pt; i or eight: 250px; d n 0.2 em 0 dth; 2 px; .auto-style8 {
            height: 29px;
        }

        .auto-style8 {
            width: 150px;
            height: 40px;
        }

        .auto-style9 {
            width: 2px;
            height: 40px;
        }

        .auto-style10 {
            height: 40px;
        }

        .auto-style11 {
            width: 30px;
            height: 62px;
        }

        .auto-style12 {
            height: 62px;
        }

        .auto-style13 {
            width: 180px;
            height: 62px;
        }

        .auto-style15 {
            width: 175px;
        }

        .auto-style16 {
            width: 250px;
        }

        .auto-style12 {
        }
    </style>

</asp:Content>
