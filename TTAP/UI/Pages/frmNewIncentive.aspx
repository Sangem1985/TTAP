<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="frmNewIncentive.aspx.cs" Inherits="TTAP.UI.Pages.frmNewIncentive" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>

    <style>
        #ContentPlaceHolder1_headingNewIndustry, #ContentPlaceHolder1_lblIndustryHeading, #ContentPlaceHolder1_lblDetailsofPatners, #ContentPlaceHolder1_DivWater {
            font-size: 20px !important;
        }

        #ContentPlaceHolder1_lblindustryTypeHeader {
            margin-top: -34px;
            margin-right: 20px;
            background: #fff !important;
        }

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

        .pro-detail td, .pro-detail th {
            text-align: left !important;
        }

        div#card {
            padding: 10px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
            margin: 10px 0px 0px 0px;
            border: 1px solid #000;
        }

        input[type="radio"] {
            margin-left: 10px;
            margin-right: 3px;
        }

        #ContentPlaceHolder1_trexpansionnew {
            width: 100%;
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

        .tags {
            display: inline;
            position: relative;
        }

            .tags:hover:after {
                background: #333;
                background: rgba(0, 0, 0, .8);
                border-radius: 5px;
                bottom: -34px;
                color: #fff;
                content: attr(gloss);
                left: 20%;
                padding: 5px 15px;
                position: absolute;
                z-index: 98;
                width: 150px;
            }

            .tags:hover:before {
                border: solid;
                border-color: #333 transparent;
                border-width: 0 6px 6px 6px;
                bottom: -4px;
                content: "";
                left: 50%;
                position: absolute;
                z-index: 99;
            }

        .masking {
            display: none;
            z-index: 999999;
            top: 0px;
            left: 0px;
            height: 100%;
            width: 100%;
            border-radius: 3px;
            position: fixed;
        }

        .cmask, .modalBackground {
            position: fixed;
            width: 100%;
            height: 100%;
            left: 0px;
            top: 0px;
            z-index: 9999;
        }

        .clientpopup {
            position: fixed;
            left: 50%;
            top: 50%;
            border-radius: 5px;
            background: #fff;
            -moz-box-shadow: 1px 0 7px #000;
            -webkit-box-shadow: 1px 0 7px #000;
            box-shadow: 1px 0 7px #000;
            z-index: 999999;
        }

        0% {
            transform: translateX(0px) translateY(-100px);
            transition: opacity 400ms, transform 400ms;
        }

        10% {
            transform: translateX(0px) translateY(0);
            transition: opacity 400ms, transform 400ms;
        }

        100% {
            transform: translateX(0px) translateY(0);
            transition: opacity 400ms, transform 400ms;
        }

        .pop-header {
            height: 36px px;
            clear: both;
            border-radius: 5px 5px 0 0;
        }

        .Button {
            color: #FFF;
            border: 0 !important;
            background: #d80101;
            border-radius: 3px;
            background-position: -5px -33px;
            border-radius: 3px;
        }

        .pop-header input {
            float: right;
            width: 29px;
            margin: -34px 4px 3px 3px;
        }
    </style>
    <style type="text/css">
        .Background {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .Popup {
            /*background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;*/
            padding-top: 2px;
            padding-left: 10px;
            width: 90%;
            height: 85%;
        }

        .blink_me {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>
    <script type="text/javascript">

        function ValidateGSTIN(Obj) {
            if (Obj == null) Obj = window.event.srcElement;
            var gstResult = checksum(Obj.value);
            alert(gstResult);
            if (gstResult == false) {
                Obj.value = "";
                Obj.focus();
                alert("Invalid GST No");
                return false;
            }
        }
        function checksum(g) {
            let a = 65, b = 55, c = 36;
            return Array['from'](g).reduce((i, j, k, g) => {
                p = (p = (j.charCodeAt(0) < a ? parseInt(j) : j.charCodeAt(0) - b) * (k % 2 + 1)) > c ? 1 + (p - c) : p;
                return k < 14 ? i + p : j == ((c = (c - (i % c))) < 10 ? c : String.fromCharCode(c + b));
            }, 0);
        }
        function IsMobileNumber(obj) {
            var mob = /^[1-9]{1}[0-9]{9}$/;
            var txtMobile = obj;
            if (mob.test(txtMobile.value) == false && obj.value != "") {
                obj.value = "";
                alert("Please enter valid mobile number.");
                obj.focus();
                return false;
            }
            return true;
        }
        function validateEmail(emailField) {
            var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

            if (reg.test(emailField.value) == false && emailField.value != "") {
                emailField.value = "";
                alert('Invalid Email Address');
                return false;
            }
            return true;
        }

        var d = [[0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
        [1, 2, 3, 4, 0, 6, 7, 8, 9, 5],
        [2, 3, 4, 0, 1, 7, 8, 9, 5, 6],
        [3, 4, 0, 1, 2, 8, 9, 5, 6, 7],
        [4, 0, 1, 2, 3, 9, 5, 6, 7, 8],
        [5, 9, 8, 7, 6, 0, 4, 3, 2, 1],
        [6, 5, 9, 8, 7, 1, 0, 4, 3, 2],
        [7, 6, 5, 9, 8, 2, 1, 0, 4, 3],
        [8, 7, 6, 5, 9, 3, 2, 1, 0, 4],
        [9, 8, 7, 6, 5, 4, 3, 2, 1, 0]];


        // The permutation table
        var p = [
            [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
            [1, 5, 7, 6, 2, 8, 3, 0, 9, 4],
            [5, 8, 0, 3, 7, 9, 6, 1, 4, 2],
            [8, 9, 1, 6, 0, 4, 3, 5, 2, 7],
            [9, 4, 5, 3, 1, 2, 6, 8, 7, 0],
            [4, 2, 8, 6, 5, 7, 3, 9, 0, 1],
            [2, 7, 9, 3, 8, 0, 6, 4, 1, 5],
            [7, 0, 4, 6, 9, 1, 3, 2, 5, 8]];


        // The inverse table
        var inv = [0, 4, 3, 2, 1, 5, 6, 7, 8, 9];

        function validateVerhoeff() {
            //document.getElementById('txtadhar1'+'txtadhar2'+'txtadhar3').value

            var num = document.getElementById("<%=txtadhar1.ClientID %>").value + document.getElementById("<%=txtadhar2.ClientID %>").value + document.getElementById("<%=txtadhar3.ClientID %>").value;
            //alert(num);
            //alert('hi');
            var num;
            var cc;
            var c = 0;
            var myArray = StringToReversedIntArray(num);

            for (var i = 0; i < myArray.length; i++) {

                c = d[c][p[(i % 8)][myArray[i]]];

            }

            cc = c;
            if (cc == 0) {
                //alert("Valid UID");
            }
            else {

                alert("This is not Valid Aadhar Number");
                document.getElementById("<%=txtadhar1.ClientID %>").value = "";
                document.getElementById("<%=txtadhar2.ClientID %>").value = "";
                document.getElementById("<%=txtadhar3.ClientID %>").value = "";
            }
        }
        /*
       * Converts a string to a reversed integer array.
       */
        function StringToReversedIntArray(num) {

            var myArray = [num.length];

            for (var i = 0; i < num.length; i++) {

                myArray[i] = (num.substring(i, i + 1));

            }

            myArray = Reverse(myArray);


            return myArray;

        }

        /*
        * Reverses an int array
        */
        function Reverse(myArray) {

            var reversed = [myArray.length];

            for (var i = 0; i < myArray.length; i++) {
                reversed[i] = myArray[myArray.length - (i + 1)];

            }

            return reversed;
        }
    </script>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">

        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload1" />
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="btnSpecimenSignatureOperation" />
            <asp:PostBackTrigger ControlID="btnGovermentOrder" />
            <asp:PostBackTrigger ControlID="btnabstractadd" />
            <asp:PostBackTrigger ControlID="btnPandMAdd" />
            <asp:PostBackTrigger ControlID="btnGrossPandMAdd" />
            <asp:PostBackTrigger ControlID="btnpmpaymentAdd" />
            <asp:PostBackTrigger ControlID="A2" />
        </Triggers>
        <ContentTemplate>
            <div id="innerpagew">
                <div class="breadcrumb-bg">
                    <ul class="breadcrumb font-medium title5 container" id="innerpagew">
                        <li class="breadcrumb-item"><a id="anchbreadgrrom" runat="server" href="frmDashBoard.aspx">Home</a></li>
                        <li class="breadcrumb-item">Incentive Application</li>
                    </ul>
                </div>
                <div class="pr-5">
                    <div class="row float-right">
                        <label id="lblindustryTypeHeader" runat="server" class="form-control text-primary font-bold">
                        </label>
                    </div>
                </div>
                <div class="container mt-4 pb-4">

                    <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">

                        <ul class="nav nav-pills nav-wizard title7">
                            <li class="active" id="Tab1" runat="server"><a href="#" id="AnchTab1" runat="server" data-toggle="tab">1. Enterprise Details</a></li>
                            <li id="Tab2" runat="server"><a id="AnchTab2" runat="server" data-toggle="tab">2. Project Details</a></li>
                            <li id="Tab3" runat="server"><a id="AnchTab3" runat="server" data-toggle="tab">3. Project Financials</a></li>
                            <li id="Tab4" runat="server"><a id="AnchTab4" runat="server" data-toggle="tab">4. Loan Details</a></li>
                            <li id="Tab5" runat="server"><a id="AnchTab5" runat="server" data-toggle="tab">5. Bank Details</a></li>
                            <li id="Tab6" runat="server"><a id="AnchTab6" runat="server" data-toggle="tab">6. Attachments</a></li>
                        </ul>
                        <asp:MultiView ID="MainView" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-content nopadding">
                                                <div id="home" class="container- tab-pane active">
                                                    <div class="row" id="card">
                                                        <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Industry Details</h5>
                                                        <div class="col-sm-12 form-group">
                                                            <label class="control-label label-required" id="IEMorUdyog" runat="server">TSIPass-UID Number</label>
                                                            <asp:TextBox ID="TxtUidNumber" runat="server" class="form-control"> </asp:TextBox>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required" id="Label1" runat="server">Type of Sector</label>
                                                            <asp:DropDownList ID="rblSector" runat="server" RepeatDirection="Horizontal" Enabled="false" class="form-control" AutoPostBack="true">
                                                                <asp:ListItem Value="3" Selected="True">Textiles</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required" id="Label2" runat="server">Name of The Enterprise</label>
                                                            <asp:TextBox ID="txtUnitName" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label" id="Label3" runat="server">Country of Origin (In case of MNC)</label>
                                                            <asp:TextBox ID="txtCountryofOrigin" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required" id="Label5" runat="server">Date Of Incorporation</label>
                                                            <asp:TextBox ID="txtDateOfIncorporation" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required" id="Label6" runat="server">Incorporation Registration No</label>
                                                            <asp:TextBox ID="txtIncorpRegistranNumber" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">GST Number</label>
                                                            <asp:TextBox ID="txtTinNO" runat="server" class="form-control"
                                                                MaxLength="100" TabIndex="1" onblur="fnValidateGSTIN(this);"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">PAN Number</label>
                                                            <asp:TextBox ID="txtPanNo" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="1" onblur="fnValidatePAN(this);"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">EIN/IEM/IL Number</label>
                                                            <asp:TextBox ID="txtEINIEMILNumber" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Date of EIN/IEM/IL Number</label>
                                                            <asp:TextBox ID="txtEINIEMILDate" runat="server" class="form-control" TabIndex="1"></asp:TextBox>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Constitution of Organization</label>
                                                            <asp:DropDownList ID="ddlOrgType" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlOrgType_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Social Status</label>
                                                            <asp:DropDownList ID="rblCaste" runat="server" class="form-control" RepeatDirection="Horizontal"
                                                                TabIndex="1" OnSelectedIndexChanged="rblCaste_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                                <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                                <asp:ListItem Value="1">General</asp:ListItem>
                                                                <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                <asp:ListItem Value="3">SC</asp:ListItem>
                                                                <asp:ListItem Value="4">ST</asp:ListItem>
                                                                <asp:ListItem Value="5">Minority</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group" id="divsubcaste" runat="server" visible="false">
                                                            <label class="control-label label-required">Sub Category</label>
                                                            <asp:DropDownList ID="ddlsubcaste" class="form-control" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                                <asp:ListItem Value="1">BC-A</asp:ListItem>
                                                                <asp:ListItem Value="2">BC-B</asp:ListItem>
                                                                <asp:ListItem Value="3">BC-C</asp:ListItem>
                                                                <asp:ListItem Value="4">BC-D</asp:ListItem>
                                                                <asp:ListItem Value="5">BC-E</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-12 form-group">
                                                            <label class="control-label label-required">Applicant Name</label>
                                                            <asp:TextBox ID="txtApplciantName" runat="server" class="form-control"></asp:TextBox>
                                                        </div>

                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Gender</label>
                                                            <asp:DropDownList ID="ddlgender" runat="server" class="form-control">
                                                                <asp:ListItem Value="0">--Gender--</asp:ListItem>
                                                                <asp:ListItem Value="M">Male</asp:ListItem>
                                                                <asp:ListItem Value="F">Female</asp:ListItem>
                                                                <asp:ListItem Value="T">Transgender</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">No of Years of Experience in Textiles</label>
                                                            <asp:TextBox ID="txtYearsOfExpinTexttile" onkeypress="return inputOnlyNumbers(event)" MaxLength="2" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Physically handicapped</label>
                                                            <asp:DropDownList ID="ddlDifferentlyabled" runat="server" class="form-control">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                <asp:ListItem Value="N">No</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>

                                                        <div class="col-sm-12 form-group">
                                                            <label class="control-label label-required">Type of Textile</label>
                                                            <asp:RadioButtonList ID="rdl_TypeofUnit" runat="server" AutoPostBack="true" CssClass="radio-inline" RepeatDirection="Horizontal" OnSelectedIndexChanged="rdl_TypeofUnit_SelectedIndexChanged">
                                                                <asp:ListItem Text="Conventional Textile Unit" Value="0" Selected="True"></asp:ListItem>
                                                                <asp:ListItem Text="Technical Textile Unit" Value="1"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                    <div class="row" id="card">
                                                        <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Registered Address of Enterprise</h5>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">State</label>
                                                            <asp:DropDownList ID="ddlUnitstate" runat="server" class="form-control"
                                                                AutoPostBack="True" TabIndex="2" OnSelectedIndexChanged="ddlUnitstate_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">District</label>
                                                            <asp:DropDownList ID="ddlUnitDIst" runat="server" class="form-control" Visible="true"
                                                                TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="ddldistrictunit_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Mandal</label>
                                                            <asp:DropDownList ID="ddlUnitMandal" runat="server" class="form-control" Visible="true"
                                                                TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="ddlUnitMandal_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Village</label>
                                                            <asp:DropDownList ID="ddlVillageunit" runat="server" class="form-control" Visible="true" TabIndex="3">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList><br />
                                                            <asp:Label ID="lblzonename" runat="server" Text=""></asp:Label>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Grampanchayat/IE/IDA</label>
                                                            <asp:TextBox ID="txtUnitStreet" runat="server" class="form-control"
                                                                TabIndex="3"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Survey/Plot No.</label>
                                                            <asp:TextBox ID="txtUnitHNO" runat="server" class="form-control"
                                                                TabIndex="3"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label">Aadhar Number</label>
                                                            <div class="row">
                                                                <div class="col-sm-4 form-group">
                                                                    <asp:TextBox ID="txtadhar1" TabIndex="1" onpaste="return false"
                                                                        runat="server" class="form-control" MaxLength="4"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <asp:TextBox ID="txtadhar2" TabIndex="1" onpaste="return false"
                                                                        runat="server" class="form-control" MaxLength="4"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <asp:TextBox onblur="validateVerhoeff();" TabIndex="1" ID="txtadhar3"
                                                                        onpaste="return false" runat="server" class="form-control" MaxLength="4"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Mobile Number</label>
                                                            <asp:TextBox ID="txtunitmobileno" runat="server" class="form-control"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" onblur="IsMobileNumber(this)" TabIndex="3"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Email Id</label>
                                                            <asp:TextBox ID="txtunitemailid" onblur="validateEmail(this);" runat="server" class="form-control"
                                                                TabIndex="3"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="row" id="card">
                                                        <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Correspondence Address</h5>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">State</label>
                                                            <asp:DropDownList ID="ddloffcstate" runat="server" class="form-control"
                                                                AutoPostBack="True" TabIndex="4" OnSelectedIndexChanged="ddloffcstate_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">District</label>
                                                            <asp:DropDownList ID="ddlOffcDIst" runat="server" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddldistrictoffc_SelectedIndexChanged"
                                                                TabIndex="4" Visible="true">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtofficedist" runat="server" class="form-control"
                                                                Visible="false" MaxLength="30" TabIndex="4"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Mandal</label>
                                                            <asp:DropDownList ID="ddlOffcMandal" runat="server" AutoPostBack="True" Visible="true" class="form-control" OnSelectedIndexChanged="ddloffcmandal_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtoffcicemandal" runat="server" class="form-control" Visible="false" MaxLength="30"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Village</label>
                                                            <asp:DropDownList ID="ddlOffcVil" runat="server" class="form-control" Visible="true">
                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtofficeviiage" runat="server" class="form-control"
                                                                Visible="false" MaxLength="30" TabIndex="4"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Grampanchayat/IE/IDA</label>
                                                            <asp:TextBox ID="txtOffcStreet" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Survey/Plot No</label>
                                                            <asp:TextBox ID="txtOffSurveyNo" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Mobile Number</label>
                                                            <asp:TextBox ID="txtOffcMobileNO" runat="server" class="form-control"
                                                                MaxLength="10" onkeypress="return inputOnlyNumbers(event)" onblur="IsMobileNumber(this)" TabIndex="4"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Email Id</label>
                                                            <asp:TextBox ID="txtOffcEmail" onblur="validateEmail(this);" runat="server" class="form-control"
                                                                TabIndex="4"></asp:TextBox>
                                                        </div>
                                                        <%-- <div class="col-sm-4 form-group">
                                                            <label class="control-label label">Landline Number</label>
                                                            <asp:TextBox ID="txtUnitLandlinenumber" onkeypress="return inputOnlyNumbers(event)" MaxLength="15" runat="server" class="form-control"
                                                                TabIndex="3" ></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label">FAX</label>
                                                            <asp:TextBox ID="txtUnitFAX" runat="server" class="form-control"
                                                                TabIndex="3" ></asp:TextBox>
                                                        </div>--%>
                                                    </div>
                                                  <div class="row" id="card">
                                                        <div runat="server" id="divOtp" visible="false">
                                                            <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Mobile Number Verification</h5>
                                                            <div class="col-sm-12 form-group">
                                                                <label class="control-label label-required">Authorised Person Mobile Number</label>
                                                                <asp:TextBox ID="txtVerifiedMobile" runat="server" class="form-control"
                                                                    MaxLength="10" onkeypress="return inputOnlyNumbers(event)" onblur="IsMobileNumber(this)"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-4 form-group" runat="server" id="divSendOTPBtn">
                                                                <asp:Button Text="Send OTP" CssClass="btn btn-blue px-4 title5" ID="btnSendOTP" OnClick="btnSendOTP_Click" runat="server" />
                                                            </div>
                                                            <div class="col-sm-12 form-group" id="divOTPTBox" runat="server">
                                                                <label class="control-label label-required">OTP</label>
                                                                <asp:TextBox ID="txtOTP" Enabled="false" runat="server" class="form-control"
                                                                    MaxLength="6" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-12 form-group" id="divVerifiedLabel" visible="false" runat="server">
                                                                <label runat="server" id="lblOTPVerified" style="font-size: medium; color: green; font-family: 'Montserrat-Bold';"
                                                                    class="control-label">
                                                                </label>
                                                            </div>
                                                            <div class="col-sm-4 form-group" runat="server" id="divVerifyOtpBtn" visible="false">
                                                                <asp:Button Text="Verify OTP" CssClass="btn btn-blue px-4 title5" ID="btnVerifyOTP" OnClick="btnVerifyOTP_Click" runat="server" />
                                                            </div>

                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col cos-sm-12 text-right" style="padding-top: 15px">
                                                            <asp:Button Text="Next" CssClass="btn btn-blue px-4 title5" ID="btntab1next" runat="server" OnClick="btntab1next_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <%--<div class="widget-title">
                                                <h5 class="text-blue my-3 font-SemiBold">Project Information</h5>
                                            </div>--%>
                                            <div class="widget-content nopadding">
                                                <div id="home" class="container- tab-pane active">
                                                    <div class="row" id="card">
                                                        <div class="col-sm-7 form-group" id="divIndustryTSIPASS" runat="server" visible="false">
                                                            <label class="control-label">Industry Status as per TS-Ipass</label>
                                                            <label class="form-control" id="lblIndustryStatusTsipassOld" runat="server"></label>
                                                        </div>
                                                        <div class="col-sm-6 form-group">
                                                            <label class="control-label label-required">Industry Status as Approved by TTAP</label>
                                                            <asp:DropDownList ID="ddlIndustryStatus" runat="server" class="form-control"
                                                                TabIndex="5" AutoPostBack="true"
                                                                OnSelectedIndexChanged="ddlindustryStatus_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                <asp:ListItem Value="1">New Industry</asp:ListItem>
                                                                <asp:ListItem Value="2">Expansion</asp:ListItem>
                                                                <asp:ListItem Value="3">Diversification</asp:ListItem>
                                                                <asp:ListItem Value="4">Modernization</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-6 form-group" id="trIndustryExpansionType" runat="server" visible="false">
                                                            <label class="control-label label-required">Expansion Type</label>
                                                            <asp:DropDownList ID="ddlInustryExpansionType" runat="server" class="form-control"
                                                                Height="35px" TabIndex="5">
                                                                <asp:ListItem Value="0" Text="-- Select --"></asp:ListItem>
                                                                <asp:ListItem Value="1">Expansion1</asp:ListItem>
                                                                <asp:ListItem Value="2">Expansion2</asp:ListItem>
                                                                <asp:ListItem Value="3">Expansion3</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-12 mt-sm-3 text-left text-blue" id="DivIndsStatusNote" runat="server" visible="false">
                                                            <p><strong>Note : </strong>If you want to change Industry Status to Diversification/Modernization, Please Send a mail to ttaphead@gmail.com.</p>
                                                        </div>
                                                    </div>
                                                    <div class="row" id="card">
                                                        <div class="col-sm-12 form-group" id="Div3" runat="server">
                                                            <div class="row">
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label label-required">Special Incentive Scheme</label>
                                                                    <asp:DropDownList ID="ddlSpecialIncentive" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlSpecialIncentive_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="N" Selected="True">No</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-12 form-group" id="DivSpecialIncentive" runat="server" visible="false">
                                                            <div class="row">
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label-required">Goverment Order Number</label>
                                                                    <asp:TextBox ID="txtGovermentOrderNumber" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label-required">Goverment Order Date</label>
                                                                    <asp:TextBox ID="txtGovermentOrderDate" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label-required">Goverment Order (Pdf Only)</label>
                                                                    <asp:FileUpload ID="fuGovermentOrder" runat="server" CssClass="file-browse" />
                                                                </div>
                                                                <div class="col-sm-3 form-group  text-left">
                                                                    <br />
                                                                    <asp:Button ID="btnGovermentOrder" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnGovermentOrder_Click" />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hyGovermentOrder" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                                </div>
                                                                <div class="col-sm-12 mt-sm-3 text-left">
                                                                    <p><strong>Note : </strong>File Size should be 1MB only.</p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" id="card">
                                                        <div class="col-sm-12 form-group" id="DivNewIndustry" runat="server">
                                                            <div class="row">
                                                                <h6 class="text-blue font-SemiBold col col-sm-12 mt-3" runat="server" id="headingNewIndustry">New Industry</h6>
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label-required">Date of Commencement of Production</label>
                                                                    <asp:TextBox ID="txtDateofCommencement" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label-required" id="Label4" runat="server">Nature Of Industry</label>
                                                                    <asp:DropDownList ID="ddlTextileProcessType" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTextileProcessType_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Ginning"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Spinning"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Weaving"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="Garmenting"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="Processing"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-sm-3 form-group" runat="server" id="divNewOtherTextileProcessType" visible="false">
                                                                    <label class="control-label label-required">Other</label>
                                                                    <asp:TextBox ID="txtNewOtherTextileProcessType" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-3 form-group" id="divTechnicalNatureOfIndustry" runat="server" visible="false">
                                                                    <label class="control-label label-required" id="Label24" runat="server">Type of Technical Textile</label>
                                                                    <asp:DropDownList ID="ddlTechnicalNatureOfIndustry" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTextileProcessType_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="col-sm-12 form-group" id="DivExpIndustry" runat="server" visible="false">
                                                            <div class="row">
                                                                <h6 class="text-blue font-SemiBold col col-sm-12 mt-3" runat="server" id="headingExpIndustry">New Industry</h6>
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label label-required">Date of Commencement of Production</label>
                                                                    <asp:TextBox ID="txtDateofCommencementExp" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-4 form-group">
                                                                    <label class="control-label label-required" id="Label7" runat="server">Nature Of Industry</label>
                                                                    <asp:DropDownList ID="ddlTextileProcessTypeExp" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTextileProcessTypeExp_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                                        <asp:ListItem Value="1" Text="Ginning"></asp:ListItem>
                                                                        <asp:ListItem Value="2" Text="Spinning"></asp:ListItem>
                                                                        <asp:ListItem Value="3" Text="Weaving"></asp:ListItem>
                                                                        <asp:ListItem Value="4" Text="Garmenting"></asp:ListItem>
                                                                        <asp:ListItem Value="5" Text="Processing"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </div>
                                                                <div class="col-sm-4 form-group" runat="server" id="divExistOtherTextileProcessType" visible="false">
                                                                    <label class="control-label label-required">Other</label>
                                                                    <asp:TextBox ID="txtExistOtherTextileProcessType" MaxLength="50" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" id="card">
                                                        <div id="trNewIndustry" runat="server" visible="false">
                                                            <div class="col-sm-12">
                                                                <asp:Label ID="lblIndustryHeading" runat="server" Font-Size="Small" CssClass="text-blue" Font-Bold="True">New Enterprise Line of Activity<font color="red">*</font></asp:Label>
                                                            </div>
                                                            <div class="row w-100 m-0" id="trlineofactivityNew" runat="server">
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label-required">Type Of Product</label>
                                                                    <asp:TextBox ID="txtLOActivity" runat="server" class="form-control"
                                                                        MaxLength="40" TabIndex="5" onkeypress="Names()"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2 form-group">
                                                                    <label class="control-label label-required">Unit</label>
                                                                    <asp:DropDownList ID="ddlquantityin" runat="server" class="form-control" TabIndex="5"
                                                                        Visible="true">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                        <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                        <asp:ListItem Value="Meters">Meters</asp:ListItem>
                                                                        <%-- <asp:ListItem Value="Others">Others</asp:ListItem>--%>
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtunit" runat="server" class="form-control" Visible="false"
                                                                        MaxLength="40" TabIndex="5" onkeypress="Names()"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2 form-group">
                                                                    <label class="control-label label-required">Installed Capacity</label>
                                                                    <asp:TextBox ID="txtinstalledccap" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtinstalledccap_TextChanged"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2 form-group">
                                                                    <label class="control-label label-required">Value Per Unit (in Rs.)</label>
                                                                    <asp:TextBox ID="txtValuePerUnit" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtValuePerUnit_TextChanged"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2 form-group">
                                                                    <label class="control-label label-required">Total Value (in Rs.)</label>
                                                                    <asp:TextBox ID="txtvalue" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12 text-center">
                                                                    <asp:Button ID="btnInstalledcap" runat="server" CssClass="btn btn-blue mx-2"
                                                                        TabIndex="5" Text="Add New" OnClick="btnInstalledcap_Click" />
                                                                    <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                                        TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen"
                                                                        OnClick="Button2_Click" />
                                                                </div>
                                                                <div class="col-sm-12 mt-sm-3 text-left">
                                                                    <p><strong>Note : </strong>Installed Capacity --> Maximum of Last 3 Years of Production</p>
                                                                </div>
                                                            </div>
                                                            <div class="container-fluid">
                                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                    <asp:GridView ID="GvLineOfactivityDetails" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                        CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="GvLineOfactivityDetails_RowCommand">
                                                                        <HeaderStyle HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                        <RowStyle CssClass="GridviewScrollC1Item" />
                                                                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                        <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Type Of Product">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblLineofActivity" runat="server" Text='<%# Bind("LineofActivity") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Installed Capacity">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblInstalledCapacity" runat="server" Text='<%# Bind("InstalledCapacity") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Unit">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Value Per Unit (in Rs.)">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblValuePerUnitRs" runat="server" Text='<%# Bind("ValuePerUnit") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Total Value (in Rs.)">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblValueRs" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblLineUnitID" runat="server" Text='<%# Bind("UnitID") %>'></asp:Label>
                                                                                    <asp:Label ID="lblLineofActivityId" runat="server" Text='<%# Bind("Line_of_Activity_Id") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Edit">
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Delete">
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <%--  <div class="row" style="margin: 0px;">--%>
                                                    <div id="trexpansionnew" runat="server" visible="false">
                                                        <div id="card">
                                                            <div class="col-sm-12">
                                                                <asp:Label ID="lblexpansionnewHeading" runat="server" CssClass="label-required text-blue" Font-Bold="True">Expansion of Enterprise</asp:Label>
                                                            </div>
                                                            <div class="row w-100 m-0" id="trlineofactivityexpansion" runat="server">
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label-required">Type Of Product</label>
                                                                    <asp:TextBox ID="txtLOActivityExpan" runat="server" class="form-control"
                                                                        MaxLength="40" TabIndex="5" onkeypress="Names()"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2 form-group">
                                                                    <label class="control-label label-required">Unit</label>
                                                                    <asp:DropDownList ID="ddlquantityinExpan" runat="server" class="form-control"
                                                                        TabIndex="5" Visible="true">
                                                                        <asp:ListItem>--Select--</asp:ListItem>
                                                                        <asp:ListItem Value="KG">KG</asp:ListItem>
                                                                        <asp:ListItem Value="Tone">Tonnes</asp:ListItem>
                                                                        <asp:ListItem Value="Liters">Litres</asp:ListItem>
                                                                        <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtunitExpan" runat="server" class="form-control" Visible="false"
                                                                        MaxLength="40" TabIndex="5" onkeypress="Names()"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2 form-group">
                                                                    <label class="control-label label-required">Installed Capacity</label>
                                                                    <asp:TextBox ID="txtinstalledccapExpan" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtinstalledccapExpan_TextChanged"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2 form-group">
                                                                    <label class="control-label label-required">Value Per Unit (in Rs.)</label>
                                                                    <asp:TextBox ID="txtvalueExpanPerUnit" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtvalueExpanPerUnit_TextChanged"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-2 form-group">
                                                                    <label class="control-label label-required">Total Value (in Rs.)</label>
                                                                    <asp:TextBox ID="txtvalueExpan" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-12 text-center">
                                                                    <asp:Button ID="btnInstalledcapExpan" runat="server" CssClass="btn btn-blue mx-2"
                                                                        TabIndex="5" Text="Add New" OnClick="btnInstalledcapExpan_Click" />
                                                                    <asp:Button ID="Button3" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                                        TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen"
                                                                        OnClick="Button3_Click" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                                <asp:GridView ID="GvLineOfactivityExpnsionDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="GvLineOfactivityExpnsionDetails_RowCommand">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                    <RowStyle CssClass="GridviewScrollC1Item" />
                                                                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Sl.No">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Type Of Product">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLineofActivity" runat="server" Text='<%# Bind("LineofActivity") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Installed Capacity">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblInstalledCapacity" runat="server" Text='<%# Bind("InstalledCapacity") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Unit">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnit" runat="server" Text='<%# Bind("Unit") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Value Per Unit (in Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExpValuePerUnitRs" runat="server" Text='<%# Bind("ValuePerUnit") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Total Value (in Rs.)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblValueRs" runat="server" Text='<%# Bind("Value") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLineUnitID" runat="server" Text='<%# Bind("UnitID") %>'></asp:Label>
                                                                                <asp:Label ID="lblLineofActivityId" runat="server" Text='<%# Bind("Line_of_Activity_Id") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row" id="card">
                                                        <div class="col-sm-12">
                                                            <asp:Label ID="lblDetailsofPatners" runat="server" CssClass="label-required text-blue" Font-Bold="True">Details of the Director(s)/ Partner(s)</asp:Label>
                                                        </div>
                                                        <div class="row w-100 m-0" id="DivDirectorDetails" runat="server">
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Name</label>
                                                                <asp:TextBox ID="txtNameofDirector" runat="server" class="form-control" MaxLength="40" TabIndex="5" onkeypress="Names()"></asp:TextBox>
                                                            </div>
                                                            <%--   <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Social Status</label>
                                                            <asp:DropDownList ID="ddlDirectorSocialStatus" runat="server" class="form-control" RepeatDirection="Horizontal" TabIndex="1">
                                                                <asp:ListItem Value="0">SELECT</asp:ListItem>
                                                                <asp:ListItem Value="1">General</asp:ListItem>
                                                                <asp:ListItem Value="2">OBC</asp:ListItem>
                                                                <asp:ListItem Value="3">SC</asp:ListItem>
                                                                <asp:ListItem Value="4">ST</asp:ListItem>
                                                                <asp:ListItem Value="5">Minority</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Gender</label>
                                                            <asp:DropDownList ID="ddlgender2" runat="server" class="form-control" TabIndex="5">
                                                                <asp:ListItem Value="0">--Gender--</asp:ListItem>
                                                                <asp:ListItem Value="M">Male</asp:ListItem>
                                                                <asp:ListItem Value="F">Female</asp:ListItem>
                                                                <asp:ListItem Value="T">Transgender</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>--%>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Designation</label>
                                                                <asp:DropDownList ID="ddlDirectorDesignation" runat="server" class="form-control" RepeatDirection="Horizontal"
                                                                    TabIndex="1">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Educational Qualification</label>
                                                                <asp:DropDownList ID="ddlEducationalQualificationPatners" runat="server" RepeatDirection="Horizontal" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlEducationalQualificationPatners_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtEducationalQual" Visible="false" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">No of Years of Exp in Textiles</label>
                                                                <asp:TextBox ID="txtYearsOfExpinTexttileDirector" onkeypress="return inputOnlyNumbers(event)" MaxLength="2" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">% Of Shares</label>
                                                                <asp:TextBox ID="txtshare" onkeypress="DecimalOnly()" MaxLength="6" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">PAN Number</label>
                                                                <asp:TextBox ID="txtPanNoDirector" runat="server" class="form-control"
                                                                    MaxLength="40" TabIndex="1" onblur="fnValidatePAN(this);"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Mobile Number</label>
                                                                <asp:TextBox ID="txtunitmobilenoDirector" runat="server" class="form-control"
                                                                    MaxLength="10" onkeypress="return inputOnlyNumbers(event)" onblur="IsMobileNumber(this)" TabIndex="3"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Email Id</label>
                                                                <asp:TextBox ID="txtunitemailidDirector" onblur="validateEmail(this);" runat="server" class="form-control"
                                                                    TabIndex="3"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-12 text-center">
                                                                <asp:Button ID="btnSaveDirectorDtls" runat="server" CssClass="btn btn-blue mx-2"
                                                                    TabIndex="5" Text="Add New" OnClick="btnSaveDirectorDtls_Click" />
                                                                <asp:Button ID="btnClearDirectorDtls" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                                    TabIndex="5" Text="Clear" ToolTip="To Clear  the Screen" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <asp:GridView ID="GvPartnerDetails" ShowHeaderWhenEmpty="true" runat="server" AutoGenerateColumns="False" CellPadding="10"
                                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="GvPartnerDetails_RowCommand">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                                <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl.No">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDirectorName" runat="server" Text='<%# Bind("DirectorName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Disignation">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDisignationName" runat="server" Text='<%# Bind("DisignationName") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Qualification">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQualification" runat="server" Text='<%# Bind("QualificationText") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Years of Experience In Texttiles">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblYearsofExperience" runat="server" Text='<%# Bind("YearsofExperience") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="% Of Shares">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblShare" runat="server" Text='<%# Bind("Share") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="PAN Number">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblPANNumber" runat="server" Text='<%# Bind("PANNumber") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mobile Number">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMobileNumber" runat="server" Text='<%# Bind("MobileNumber") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblEmailId" runat="server" Text='<%# Bind("EmailId") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDesignationid" runat="server" Text='<%# Bind("Designation") %>'></asp:Label>
                                                                            <asp:Label ID="lblDirectorPartnerID" runat="server" Text='<%# Bind("Director_Partner_ID") %>'></asp:Label>
                                                                            <asp:Label ID="lblQualificationID" runat="server" Text='<%# Bind("Qualification") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>

                                                    <div class="row" id="card">
                                                        <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Authorised Signatory/Contact Person Details</h5>
                                                        <div class="row w-100 m-0" id="Div2" runat="server">
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required" id="Label9" runat="server">Name</label>
                                                                <asp:TextBox ID="txtAuthorisedPerson" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required" id="Label8" runat="server">Designation</label>
                                                                <asp:DropDownList ID="ddlAuthorisedSignDesignation" runat="server" RepeatDirection="Horizontal" class="form-control">
                                                                    <asp:ListItem Value="0">--Designation--</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">PAN Number</label>
                                                                <asp:TextBox ID="txtPanNoAuthorised" runat="server" class="form-control"
                                                                    MaxLength="40" TabIndex="1" onblur="fnValidatePAN(this);"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Mobile Number</label>
                                                                <asp:TextBox ID="txtMobileNumberAuthorised" runat="server"  class="form-control"
                                                                    MaxLength="10" onkeypress="return inputOnlyNumbers(event)" onblur="IsMobileNumber(this)"  TabIndex="3"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Email Id</label>
                                                                <asp:TextBox ID="txtemailAuthorised" onblur="validateEmail(this);" runat="server" class="form-control"
                                                                    TabIndex="3"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Correspondence Address</label>
                                                                <asp:TextBox ID="txtCorrespondenceAddress" runat="server" class="form-control" TextMode="MultiLine" Height="50px"
                                                                    TabIndex="3"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Specimen Signature (Pdf Only)</label>
                                                                <asp:FileUpload ID="fpdSpecimen" runat="server" CssClass="file-browse" />
                                                            </div>
                                                            <div class="col-sm-3 form-group  text-left">
                                                                <br />
                                                                <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnUpload_Click" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hySpecimenproject" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                            </div>
                                                            <div class="col-sm-12 mt-sm-3 text-left">
                                                                <p><strong>Note : </strong>File Size should be 1MB only.</p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    
                                                    <%--  </div>--%>

                                                    <div class="row">
                                                        <div class="col-lg-6 text-left" style="padding-top: 15px">
                                                            <asp:Button Text="Previous" CssClass="btn btn-blue px-4 title5" ID="btnPrevious2" runat="server" OnClick="btnPrevious2_Click" />
                                                        </div>
                                                        <div class="col-lg-6 text-right" style="padding-top: 15px">
                                                            <asp:Button Text="Save & Next" CssClass="btn btn-blue px-4 title5" ID="btnNext2" runat="server" OnClick="btnNext2_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="View3" runat="server">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <%-- <div class="widget-title">
                                                <span class="icon">
                                                    <i class="icon-info-sign"></i>
                                                </span>
                                                <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Employment</h5>
                                            </div>--%>
                                            <div class="widget-content nopadding">
                                                <div id="card">
                                                    <div class="row">
                                                        <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Employment</h5>
                                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Direct Employment</h6>
                                                        <div class="col-sm-12 table-responsive">
                                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                <%-- <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th></th>
                                                                    <th></th>
                                                                    <th colspan="4">Direct</th>
                                                                    <th colspan="4">In-direct</th>
                                                                </tr>--%>
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th></th>
                                                                    <th></th>
                                                                    <th colspan="2">Local</th>
                                                                    <th colspan="2">Non-Local</th>
                                                                    <%--<th></th>
                                                                    <th></th>--%>
                                                                </tr>
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Cadre</th>
                                                                    <th>Male(Nos) </th>
                                                                    <th>Female(Nos) </th>
                                                                    <th>Male(Nos) </th>
                                                                    <th>Female(Nos) </th>
                                                                    <%--  <th>Male(Nos) </th>
                                                                    <th>Female(Nos) </th>--%>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td>Management & Staff</td>
                                                                    <td align="center" valign="center">
                                                                        <asp:TextBox ID="txtstaffMale" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtfemale" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtfemale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center" valign="center">
                                                                        <asp:TextBox ID="txtstaffMaleNonLocal" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtfemaleNonLocal" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtfemaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <%-- <td align="center" valign="center">
                                                                        <asp:TextBox ID="txtstaffMaleInDirect" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtfemaleInDirect" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtfemaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>--%>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td style="width: 20px;">2
                                                                    </td>
                                                                    <td style="width: 250px;">Supervisory
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtsupermalecount" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" align="center" AutoPostBack="True" OnTextChanged="txtstaffMale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtsuperfemalecount" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtfemale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtsupermalecountNonLocal" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" align="center" AutoPostBack="True" OnTextChanged="txtstaffMaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtsuperfemalecountNonLocal" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtfemaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <%-- <td align="center">
                                                                        <asp:TextBox ID="txtsupermalecountInDirect" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" align="center" AutoPostBack="True" OnTextChanged="txtstaffMaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtsuperfemalecountInDirect" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtfemaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>--%>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td>Skilled workers </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSkilledWorkersMale" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtstaffMale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSkilledWorkersFemale" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtfemale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSkilledWorkersMaleNonLocal" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtstaffMaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSkilledWorkersFemaleNonLocal" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtfemaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <%-- <td align="center">
                                                                        <asp:TextBox ID="txtSkilledWorkersMaleInDirect" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtstaffMaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSkilledWorkersFemaleInDirect" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)" TabIndex="5" AutoPostBack="True" OnTextChanged="txtfemaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>--%>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>4</td>
                                                                    <td>Semi-skilled workers
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSemiSkilledWorkersMale" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSemiSkilledWorkersFemale" runat="server"
                                                                            onkeypress="return inputOnlyNumbers(event)" class="form-control" AutoPostBack="True" OnTextChanged="txtfemale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSemiSkilledWorkersMaleNonLocal" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSemiSkilledWorkersFemaleNonLocal" runat="server"
                                                                            onkeypress="return inputOnlyNumbers(event)" class="form-control" AutoPostBack="True" OnTextChanged="txtfemaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <%-- <td align="center">
                                                                        <asp:TextBox ID="txtSemiSkilledWorkersMaleIndirect" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtSemiSkilledWorkersFemaleIndirect" runat="server"
                                                                            onkeypress="return inputOnlyNumbers(event)" class="form-control" AutoPostBack="True" OnTextChanged="txtfemaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>--%>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>5</td>
                                                                    <td>Others/Un-Skilled
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtEmpDirectLocalMaleOther" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtEmpDirectLocalFemaleOther" runat="server"
                                                                            onkeypress="return inputOnlyNumbers(event)" class="form-control" AutoPostBack="True" OnTextChanged="txtfemale_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtEmpDirectNonLocalMaleOther" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtEmpDirectNonLocalFemaleOther" runat="server"
                                                                            onkeypress="return inputOnlyNumbers(event)" class="form-control" AutoPostBack="True" OnTextChanged="txtfemaleNonLocal_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <%--<td align="center">
                                                                        <asp:TextBox ID="txtEmpIndirectMaleOther" runat="server" class="form-control"
                                                                            onkeypress="return inputOnlyNumbers(event)" AutoPostBack="True" OnTextChanged="txtstaffMaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtEmpIndirectFemaleOther" runat="server"
                                                                            onkeypress="return inputOnlyNumbers(event)" class="form-control" AutoPostBack="True" OnTextChanged="txtfemaleInDirect_TextChanged"></asp:TextBox>
                                                                    </td>--%>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td class="auto-style2"></td>
                                                                    <td class="auto-style2" style="font-weight: bold">Total</td>
                                                                    <td class="auto-style2">
                                                                        <asp:Label ID="lblDirectMale" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                    </td>

                                                                    <td class="auto-style2">
                                                                        <asp:Label ID="lblDirectFeMale" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style2">
                                                                        <asp:Label ID="lblDirectMaleNonLocal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style2">
                                                                        <asp:Label ID="lblDirectFeMaleNonLocal" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <%--<td class="auto-style2">
                                                                        <asp:Label ID="lblInDirectMale" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td class="auto-style2">
                                                                        <asp:Label ID="lblInDirectFeMale" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                    </td>--%>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Indirect Employment</h6>
                                                        <div class="row w-100 m-0" id="DivIndirectEmployment" runat="server">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required">Category</label>
                                                                <asp:TextBox ID="txtCategory" runat="server" class="form-control"
                                                                    MaxLength="40" TabIndex="5"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required">Male</label>
                                                                <asp:TextBox ID="txtIndirectMale" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required">Female</label>
                                                                <asp:TextBox ID="txtIndirectFemale" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-12 text-center">
                                                                <asp:Button ID="btnIndirectEmploymentadd" runat="server" CssClass="btn btn-blue mx-2"
                                                                    TabIndex="5" Text="Add New" OnClick="btnIndirectEmploymentadd_Click" />
                                                                <asp:Button ID="btnIndirectEmploymentclear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                                    TabIndex="5" Text="Cancel" ToolTip="Clear" OnClick="btnIndirectEmploymentclear_Click" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                            <asp:GridView ID="gvIndirectEmployment" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                                CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="gvIndirectEmployment_RowCommand">
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
                                                                    <asp:TemplateField HeaderText="Category">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Male">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblMale" runat="server" Text='<%# Bind("IndirectMale") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Female">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFemale" runat="server" Text='<%# Bind("IndirectFemale") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="IndirectEMPId" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblIndirectEmploymentID" runat="server" Text='<%# Bind("IndirectEmploymentID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit" ItemStyle-Width="100px">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete" ItemStyle-Width="100px">
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
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
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-title">
                                                <span class="icon">
                                                    <i class="icon-info-sign"></i>
                                                </span>
                                                <h5 class="text-blue my-3 font-SemiBold">Industry Investment & Power Details</h5>
                                            </div>
                                            <div class="widget-content nopadding">
                                                <div id="card">
                                                    <div class="row">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px; margin-bottom: 10px;">
                                                            Approved Project Cost(In Rs.)
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-12 text-blue" style="font-size: 12px; margin-bottom: 10px;">
                                                            <asp:CheckBox ID="chkApproveCost" AutoPostBack="true" Text="Check the Check box if you want to Change Approved Project Cost" OnCheckedChanged="chkApproveCost_CheckedChanged" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="row" id="trFixedcap" runat="server" visible="true">
                                                        <div class="col-sm-12 table-responsive">
                                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Nature of Assets</th>
                                                                    <th id="Th1" runat="server" visible="true">Approved Cost as per TSiPass
                                                                    </th>
                                                                    <th id="thIpassExp" runat="server" visible="false">Approved Cost as per TSiPass(Expansion)
                                                                    </th>
                                                                    <th id="thApprovedProjectCost" runat="server">Value (in Rs.)</th>
                                                                    <th id="trFixedCapitalexpansion" runat="server"
                                                                        visible="false">Under Expansion/ Diversification/ Modification Project
                                                                    </th>
                                                                    <th id="trFixedCapitalexpnPercent" runat="server" visible="false">% of increase under
                                                                            <br />
                                                                        Expansion/Diversification/Modification
                                                                    </th>

                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="left">Land</td>
                                                                    <td id="Td1" runat="server" align="center" visible="true">
                                                                        <asp:TextBox ID="txtIpassLand" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false"></asp:TextBox>
                                                                    </td>
                                                                    <td id="tdIpassLandExp" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtIpassLandExp" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtlandexisting" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            AutoPostBack="True" OnTextChanged="txtlandexisting_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td id="trFixedCapitalland" runat="server" align="center"
                                                                        visible="false">
                                                                        <asp:TextBox ID="txtlandcapacity" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            AutoPostBack="True" OnTextChanged="txtlandcapacity_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td id="txtbuildcapacityPercet" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtlandpercentage" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false" OnTextChanged="txtlandpercentage_TextChanged"></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>2</td>
                                                                    <td align="left">Building </td>
                                                                    <td id="Td2" runat="server" align="center" visible="true">
                                                                        <asp:TextBox ID="txtIpassBuilding" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false"></asp:TextBox>
                                                                    </td>
                                                                    <td id="tdIpassBuildingExp" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtIpassBuildingExp" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtbuildingexisting" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            AutoPostBack="True" OnTextChanged="txtbuildingexisting_TextChanged"></asp:TextBox>
                                                                    </td>

                                                                    <td id="trFixedCapitalBuilding" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtbuildingcapacity" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            AutoPostBack="True" OnTextChanged="txtbuildingcapacity_TextChanged"></asp:TextBox>
                                                                    </td>

                                                                    <td id="trFixedCapitBuildPercent" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtbuildingpercentage" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false" OnTextChanged="txtbuildingpercentage_TextChanged"></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;</td>
                                                                    <td id="Td5" runat="server" align="center" visible="true">
                                                                        <asp:TextBox ID="txtIpassPlantMachine" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false"></asp:TextBox>
                                                                    </td>
                                                                    <td id="tdIpassPlantMachineExp" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtIpassPlantMachineExp" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtplantexisting" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            OnTextChanged="txtplantexisting_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                    </td>
                                                                    <td id="trFixedCapitalMach" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtplantcapacity" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            AutoPostBack="True" OnTextChanged="txtplantcapacity_TextChanged"></asp:TextBox>

                                                                    </td>
                                                                    <td id="trFixedCapitMachPercent" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtplantpercentage" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" Enabled="false"
                                                                            AutoPostBack="false" OnTextChanged="txtplantpercentage_TextChanged"></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <%--<tr class="GridviewScrollC1Item">
                                                                    <td>4</td>
                                                                    <td align="left" style="text-align: left">Others &nbsp;&nbsp;&nbsp;</td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtnewothers" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5" AutoPostBack="True" OnTextChanged="txtnewothers_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td id="Td1" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtexistother" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            AutoPostBack="True" OnTextChanged="txtexistother_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                    <td id="Td2" runat="server" align="center" visible="false">
                                                                        <asp:TextBox ID="txtotherpersangage" runat="server" CssClass="form-control" onkeypress="DecimalOnly()"
                                                                            MaxLength="80" TabIndex="5" AutoPostBack="True" OnTextChanged="txtotherpersangage_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="left" style="text-align: left; font-weight: bold">Total</td>
                                                                    <td id="Td6" runat="server" align="center" visible="true">
                                                                        <asp:Label ID="lbltotIpass" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td id="tdtotIpassExp" runat="server" align="center" visible="false">
                                                                        <asp:Label ID="lbltotIpassExp" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblnewinv" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td id="Td3" runat="server" align="center" visible="false">
                                                                        <asp:Label ID="lblexpinv" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                    <td id="Td4" runat="server" align="center" visible="false">
                                                                        <asp:Label ID="lbltotperinv" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Category</label>
                                                            <asp:Label Visible="true" ID="lblEnterpriseCategory" class="col-form-label font-bold" runat="server"> </asp:Label>
                                                            <asp:HiddenField ID="HiddenFieldEnterpriseCategory" runat="server" />
                                                            <%-- <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" Visible="false">
                                                        </asp:DropDownList>--%>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Is power applicable</label>
                                                            <asp:DropDownList ID="ddlIspowApplicable" runat="server" Visible="true"
                                                                class="form-control" TabIndex="5" AutoPostBack="True" OnSelectedIndexChanged="ddlIspowApplicable_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Is Water applicable</label>
                                                            <asp:DropDownList ID="ddlWaterSource" runat="server" Visible="true"
                                                                class="form-control" TabIndex="5" AutoPostBack="True" OnSelectedIndexChanged="ddlWaterSource_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">-- Select --</asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                                                <asp:ListItem Value="2" Text="No"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="row" id="Div_CurrentInvestment1" runat="server" visible="true">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px; margin-bottom: 10px;">
                                                            Existing Actual Investment Details (In Rs.)
                                                            
                                                        </div>
                                                    </div>
                                                    <div class="row" id="Div_CurrentInvestment" runat="server" visible="true">
                                                        <div class="col-sm-12 table-responsive">
                                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Nature of Assets</th>
                                                                    <th>Value (in Rs.)</th>

                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="left">Land</td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtcurrInvLandValue" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            AutoPostBack="True" OnTextChanged="txtcurrInvLandValue_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>2</td>
                                                                    <td align="left">Building </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtcurrInvBuldvalue" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            AutoPostBack="True" OnTextChanged="txtcurrInvLandValue_TextChanged"></asp:TextBox>
                                                                    </td>


                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;</td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtcurrInvplantMechValue" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5"
                                                                            OnTextChanged="txtcurrInvLandValue_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>4</td>
                                                                    <td align="left" style="text-align: left">Others &nbsp;&nbsp;&nbsp;</td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtcurrentInvothers" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                            MaxLength="80" TabIndex="5" AutoPostBack="True" OnTextChanged="txtcurrInvLandValue_TextChanged"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td align="left" style="text-align: left; font-weight: bold">Total</td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblCurrInvTot" runat="server" Font-Bold="True"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>


                                                </div>
                                                <div id="card">
                                                    <div class="col-sm-12 text-blue pt-2 pb-1 title4 font-SemiBold" id="trpower" runat="server" visible="false">
                                                        <h5 class="text-blue font-SemiBold col col-sm-12 mt-3">Power Details</h5>
                                                    </div>

                                                    <div class="w-100 row m-0" id="tblpower1" runat="server" visible="false">
                                                        <div class="col-sm-12">
                                                            <asp:Label ID="lblpowerHEAD" CssClass="font-SemiBold d-block py-1 px-2 alert-primary mb-2" runat="server">New Enterprise</asp:Label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Connection Number</label>
                                                            <asp:TextBox ID="txtNewPowerUniqueID" runat="server" class="form-control"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Power Company</label>
                                                            <asp:TextBox ID="txtNewPowerCompany" runat="server" class="form-control"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Power Release Date </label>
                                                            <asp:TextBox ID="txtNewPowerReleaseDate" runat="server" class="form-control" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Connected Load (in KVA)</label>
                                                            <asp:TextBox ID="txtPowerConnectedLoad" runat="server" onkeypress="DecimalOnly()" class="form-control" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Contracted Load (in KVA)</label>
                                                            <asp:TextBox ID="txtNewContractedLoad" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5" onkeypress="DecimalOnly()"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Rate per unit(in Rs)</label>
                                                            <asp:TextBox ID="txtServiceRateUnit" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>

                                                    </div>
                                                    <div class="w-100 row m-0" id="tblpower2" runat="server" visible="false">
                                                        <div class="col-sm-12">
                                                            <asp:Label ID="lblexistingpower" CssClass="font-SemiBold d-block py-1 px-2 alert-primary mb-2" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Connection Number</label>
                                                            <asp:TextBox ID="txtExistingPowerUniqueID" runat="server" class="form-control"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Power Company</label>
                                                            <asp:TextBox ID="txtExistingPowerCompany" runat="server" class="form-control"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Power Release Date </label>
                                                            <asp:TextBox ID="txtExistingPowerReleaseDate" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Connected Load (in KVA)</label>
                                                            <asp:TextBox ID="txtExistingPowerConnectedLoad" runat="server" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Contracted Load (in KVA) </label>
                                                            <asp:TextBox ID="txtExistingContractedLoad" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5" onkeypress="DecimalOnly()"></asp:TextBox>

                                                        </div>

                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Rate per unit(in Rs)</label>
                                                            <asp:TextBox ID="txtExistingRateUnit" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>

                                                        <div class="col-sm-12">
                                                            <asp:Label ID="lblexpandiverpower" CssClass="font-SemiBold d-block py-1 px-2 alert-primary mb-2" runat="server"></asp:Label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Connection Number</label>
                                                            <asp:TextBox ID="txtExpanDiverPowerUniqueID" runat="server" class="form-control"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Power Company</label>
                                                            <asp:TextBox ID="txtExpanDiverPowerCompany" runat="server" class="form-control"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Power Release Date </label>
                                                            <asp:TextBox ID="txtExpanDiverPowerReleaseDate" runat="server" class="form-control" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Connected Load (in KVA)</label>
                                                            <asp:TextBox ID="txtExpanDiverPowerConnectedLoad" runat="server" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Contracted Load (in KVA) </label>
                                                            <asp:TextBox ID="txtExpanDiverContractedLoad" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5" onkeypress="DecimalOnly()"></asp:TextBox>
                                                        </div>

                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Rate per unit(in Rs)</label>
                                                            <asp:TextBox ID="txtExpanDiverRateUnit" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                                TabIndex="5"></asp:TextBox>
                                                        </div>

                                                    </div>

                                                    <div class="col-sm-12 text-blue pt-2 pb-1 title4 font-SemiBold" id="DivWater" runat="server" visible="false">Water Source Details (per Day)</div>

                                                    <div class="w-100 row m-0" id="DivWater1" runat="server" visible="false">
                                                        <%-- <div class="col-sm-12">
                                                            <asp:Label ID="Label10" CssClass="font-SemiBold d-block py-1 px-2 alert-primary mb-2" runat="server"></asp:Label>
                                                        </div>--%>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Source</label>
                                                            <asp:TextBox ID="txtwaterSource" runat="server" class="form-control" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Requirement Per day (In Litre)</label>
                                                            <asp:TextBox ID="txtwaterRequirement" onkeypress="DecimalOnly()" runat="server" class="form-control" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Rate Per Litre(in Rs)</label>
                                                            <asp:TextBox ID="txtwaterRateperunit" runat="server" class="form-control"
                                                                TabIndex="5" onkeypress="DecimalOnly()"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="card" runat="server">
                                                <div class="row">
                                                    <h6 class="text-blue font-SemiBold col col-sm-12 mt-3" id="hAbstractheader" runat="server">Abstract - Plant and Machinery Details</h6>
                                                    <div class="row w-100 m-0" id="Div5" runat="server">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Type Of Machinery</label>
                                                            <asp:TextBox ID="txtTypeOfMachinery" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">No of machines</label>
                                                            <asp:TextBox ID="txtNoofmachines" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Photograph of Machinary & its Products (Pdf Only)</label>
                                                            <asp:FileUpload ID="fuPhotographMachinary" runat="server" CssClass="file-browse" />
                                                            <asp:HyperLink ID="hyPmAbstractLink" Visible="false" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                        </div>

                                                        <div class="col-sm-12 text-center">
                                                            <asp:Button ID="btnabstractadd" runat="server" CssClass="btn btn-blue mx-2"
                                                                TabIndex="5" Text="Add New" OnClick="btnabstractadd_Click" />
                                                            <asp:Button ID="btnabstractclear" runat="server" CausesValidation="False" CssClass="btn btn-warning mx-2"
                                                                TabIndex="5" Text="Cancel" ToolTip="Clear" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" style="height: 300px">
                                                        <asp:GridView ID="gvPMAbstract" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="gvPMAbstract_RowCommand">
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
                                                                <asp:TemplateField HeaderText="Type Of Machinery">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTypeOfMachinery" runat="server" Text='<%# Bind("TypeOfMachinery") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="No of Machines">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNoofmachines" runat="server" Text='<%# Bind("Noofmachines") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Photograph">
                                                                    <ItemTemplate>
                                                                        <asp:HyperLink ID="hyFilePathMerge" Text="view" NavigateUrl='<%#Eval("FilePathMerge")%>' Target="_blank" runat="server" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Edit" ItemStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" Enabled='<%# Eval("Is_Allow_Modify").ToString() == "Y" ? true : false %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="100px">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" CommandName="RowDdelete" Enabled='<%# Eval("Is_Allow_Modify").ToString() == "Y" ? true : false %>' CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PMAbstractID" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblPMAbstractID" runat="server" Text='<%# Bind("PMAbstractID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Modify" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblisallowmodify" runat="server" Text='<%# Bind("Is_Allow_Modify") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="card_PMD" runat="server">
                                                <div class="row">
                                                    <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px; margin-bottom: 10px;">
                                                        Plant and Machinery Details
                                                    </div>
                                                    <div class="col-sm-12 text-blue" style="font-size: 18px; margin-bottom: 10px;">
                                                        <asp:Button Text="Show List" CssClass="btn btn-blue px-4 title5" ID="btnShowPlantMachine" runat="server" OnClick="btnShowPlantMachine_Click" />
                                                    </div>
                                                    <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 12px; margin-bottom: 10px;" runat="server" visible="false" id="divpmnote">
                                                        Note : Please Add Exsting Plant & Machinary Details Only
                                                    </div>
                                                </div>
                                                <div class="row" id="DivInvoiceTypes" runat="server" visible="false">
                                                    <div class="col-sm-6 form-group">
                                                        <asp:RadioButtonList ID="rbtnInvoiceTypes" runat="server" RepeatDirection="Horizontal" CssClass="spaced123" AutoPostBack="true" OnSelectedIndexChanged="rbtnInvoiceTypes_SelectedIndexChanged">
                                                            <asp:ListItem Text="Invoice Wise" Selected="True" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="Gross Block Wise" Value="2"></asp:ListItem>
                                                        </asp:RadioButtonList>
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
                                                            <asp:RadioButtonList ID="rdlMachineType" runat="server" RepeatDirection="Horizontal" onchange="return Calculate();" CssClass="spaced123" AutoPostBack="true" OnSelectedIndexChanged="rdlMachineType_SelectedIndexChanged">
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
                                                                    <asp:TextBox ID="txtCustomPaid" onblur="return Calculate();" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label-required">
                                                                        Import duty(In Rs.)</label>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <asp:TextBox ID="txtImportduty" onblur="return Calculate();" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label">
                                                                        Port charges(In Rs.)</label>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <asp:TextBox ID="txtportcharges" onblur="return Calculate();" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <label class="control-label label">
                                                                        Statutory taxes etc (In Rs.)</label>
                                                                </div>
                                                                <div class="col-sm-3 form-group">
                                                                    <asp:TextBox ID="txtstatutorytaxesetc" onblur="return Calculate();" onkeypress="DecimalOnly()" runat="server" class="form-control"></asp:TextBox>
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
                                                                Cost of the Machine(Including GST,Freight Charges,Transport Charges)(In Rs.)</label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <asp:TextBox ID="txtCostofMachine" runat="server" ReadOnly="true" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
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
                                                        <div class="col-sm-3 form-group" id="divPMunitType" runat="server" visible="true">
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
                                                            <label class="control-label label-required">
                                                                Prevoius Cost of the Machine</label>
                                                        </div>
                                                        <div runat="server" id="divPrevcosttxt" visible="true" class="col-sm-3 form-group">
                                                            <asp:TextBox ID="txtPrvCostOftheMachine" runat="server" ReadOnly="true" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
                                                        </div>
                                                        <div>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Invoice Bills (Pdf Only)</label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
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
                                                <a id="A2" href="#" class="tags" onserverclick="BtnExportExcel_Click" visible="false" gloss="Export to Excel" runat="server" style="float: left">
                                                    <img src="../../../images/Excel-icon.png" style="margin: 0px 0px 10px 18px;" width="30px" height="30px"
                                                        alt="Excel" /></a>
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" style="height: 300px !important" id="DivMachineryDetails1" runat="server">

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
                                                                    <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" runat="server" Text="Delete" CssClass="btn btn-warning" OnClick="btnDelete_Click" Enabled='<%# Eval("Is_Allow_Modify").ToString() == "Y" ? true : false %>'></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="true" HeaderText="Cost Edit">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnEditCost" runat="server" Text="Edit Cost" CssClass="btn btn-warning" OnClick="btnEditCost_Click" Enabled='<%# Eval("Allow_PM_Cost_Edit").ToString() == "Y" ? true : false %>'></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField Visible="false" HeaderText="Textile Edit">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnEditTextile" runat="server" Text="Edit Textile" CssClass="btn btn-warning" OnClick="btnEditTextile_Click" Enabled='<%# Eval("Is_Edit_PM").ToString() == "Y" ? true : false %>'></asp:Button>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>

                                                <div class="row" id="DivMachineryDetails2" runat="server">
                                                    <div class="col-sm-3 form-group">
                                                        <label class="control-label" id="Label10" runat="server">Actual Total Value of New Machinery (in Rs)</label>
                                                        <label class="form-control" id="lblTotalValueofNewMachinery" runat="server"></label>
                                                    </div>
                                                    <div class="col-sm-3 form-group">
                                                        <label class="control-label" id="Label12" runat="server">Actual Total value of 2nd hand machinery (in Rs)</label>
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

                                                <div class="row m-0" id="DivGrossMachineryDetails" runat="server" visible="false">
                                                    <div class="row">
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">
                                                                Audited Balance Sheet Year</label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <asp:TextBox ID="txtAuditedBalanceYear" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="4" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">
                                                                Amount Gross Block (In Rs.)</label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <asp:TextBox ID="txtAmountGrossBlock" runat="server" class="form-control" onkeypress="DecimalOnly()"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">
                                                                Certified By</label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <asp:TextBox ID="txtCertifiedBy" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">
                                                                Certified Date</label>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <asp:TextBox ID="txtCertifiedDate" runat="server" class="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Upload file (Pdf Only)</label>
                                                            <asp:FileUpload ID="fuGrossBlock" runat="server" CssClass="file-browse" />
                                                            <asp:HyperLink ID="HyGrossBlock" Visible="false" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                    <div class="col-sm-12 text-center">
                                                        <asp:Button Text="Add New" CssClass="btn btn-blue mx-2" ID="btnGrossPandMAdd" runat="server" OnClick="btnGrossPandMAdd_Click" />
                                                        <asp:Button ID="btnGrossmachinaryclear" runat="server" CssClass="btn btn-warning mx-2" Text="Cancel" ToolTip="Clear " />
                                                    </div>
                                                </div>
                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2" style="height: 300px !important" id="DivGrossblockMachineryDetails1" runat="server">
                                                    <asp:GridView runat="server" ID="gvGrossblockPandM" AutoGenerateColumns="False" Width="100%" CellPadding="4"
                                                        CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                                                        OnRowCommand="gvGrossblockPandM_RowCommand">
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
                                                            <asp:TemplateField HeaderText="G.B Id">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblGBId" Text='<%#Eval("GBId") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Audited Balance Sheet Year">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAuditedBalanceSheetYear" Text='<%#Eval("AuditedBalanceSheetYear") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount Gross Block (In Rs.)">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblAmountGrossBlock" Text='<%#Eval("AmountGrossBlock") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Certified By">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCertifiedBy" Text='<%#Eval("CertifiedBy") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Certified Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCertifiedDate" Text='<%#Eval("CertifiedDate") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Uploaded File">
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="hyFilePathMerge2" Text="view" NavigateUrl='<%#Eval("FilePathMerge2")%>' Target="_blank" runat="server" />
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Edit">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnlGrossblockEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Delete">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnlGrossblockDelete" CommandName="RowDdelete" OnClientClick="return confirm('Are you sure want to Delete');" CssClass="btn btn-danger" Enabled='<%# Eval("Is_Allow_Modify").ToString() == "Y" ? true : false %>' runat="server" Text="Delete" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Incentive Id" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblIncentiveId" Text='<%#Eval("IncentiveId") %>' runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>


                                            </div>
                                            <div id="divPMPaymentDetails" runat="server" visible="true">
                                                <div id="card">
                                                    <div class="row">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px; margin-bottom: 10px;">
                                                            PM Payemnt Details
                                                        </div>
                                                        <div class="col-sm-12 text-blue" style="font-size: 18px; margin-bottom: 10px;">
                                                            <asp:Button Text="Show List" CssClass="btn btn-blue px-4 title5" ID="btnShowPayments" runat="server" OnClick="btnShowPayments_Click" />
                                                        </div>
                                                    </div>
                                                    <div class="row m-0" id="divPMPaymentDetails1" runat="server">
                                                        <div class="row">
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required" id="Label28" runat="server">Plant & Machinary</label>
                                                                <asp:DropDownList ID="ddlPlantMachinaryPayment" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlPlantMachinaryPayment_SelectedIndexChanged">
                                                                    <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
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
                                            <div id="card">
                                                <div class="row" id="divNewExpInvDetails" runat="server">
                                                    <div class="col-sm-12 text-danger font-SemiBold border-danger text-center" id="divNewExpInvDetails1" runat="server" style="font-size: 16px; margin-bottom: 15px;">
                                                        <asp:HyperLink ID="HplNewExpInvDetails" CssClass="blink_me text-danger font-weight-bold" NavigateUrl="#" runat="server">New Or Expansion Actual Investment Details</asp:HyperLink>
                                                        <%--<asp:Button ID="Button4" runat="server" Text="Fill Form in Popup" />--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col cos-sm-12 text-left" style="padding-top: 15px">
                                                    <asp:Button Text="Previous" CssClass="btn btn-blue px-4 title5" ID="btnPrevious3" runat="server" OnClick="btnPrevious3_Click" />
                                                </div>
                                                <div class="col cos-sm-12 text-right" style="padding-top: 15px">
                                                    <asp:Button Text="Save & Next" CssClass="btn btn-blue px-4 title5" ID="btnNext3" runat="server" OnClick="btnNext3_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </asp:View>
                            <asp:View ID="View4" runat="server">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-content nopadding">
                                                <div id="card">
                                                    <div class="row">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px; margin-bottom: 10px;">
                                                            Financials of the Enterprise (Last 3 years in Rs Crores)
                                                        </div>
                                                    </div>
                                                    <div class="row" id="Div1" runat="server">
                                                        <div class="col-sm-12 table-responsive">
                                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Financial Indicator</th>
                                                                    <th id="thYear1" runat="server">Year 1 (Rs in Crores)</th>
                                                                    <th id="thYear2" runat="server">Year 2 (Rs in Crores)</th>
                                                                    <th id="thYear3" runat="server">Year 3 (Rs in Crores)</th>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="left">Turnover</td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtTurnoverYear1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtTurnoverYear2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtTurnoverYear3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>2</td>
                                                                    <td align="left">EBITDA </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtEBITDAYear1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtEBITDAYear2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtEBITDAYear3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="left" style="text-align: left">Networth</td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtNetworthYear1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtNetworthYear2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtNetworthYear3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>4</td>
                                                                    <td align="left" style="text-align: left">Reserves & Surplus</td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtReservesYear1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtReservesYear2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtReservesYear3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>5</td>
                                                                    <td align="left" style="text-align: left">Share Capital of the Promoter</td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtShareCapitalYear1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtShareCapitalYear2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtShareCapitalYear3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>

                                                    <div class="row" id="Div4" runat="server">
                                                        <h6 class="text-blue font-SemiBold col col-sm-12 mt-3">Production Details Preceding Three Years Before Expansion/Diversification/Modernization Project as Certified by the Financial Institution/Chartered Accountant</h6>
                                                        <div class="col-sm-12 table-responsive">
                                                            <table class="table table-bordered title6 alternet-table w-100 NewEnterprise">
                                                                <tr align="center" class="GridviewScrollC1HeaderWrap">
                                                                    <th>Sl.No</th>
                                                                    <th>Year</th>
                                                                    <th>Quantity</th>
                                                                    <th>Value</th>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>1</td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblProductionYear1" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)" MaxLength="4" TabIndex="5"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtProductionQuantity1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtProductionValue1" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item2">
                                                                    <td>2</td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblProductionYear2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtProductionQuantity2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtProductionValue2" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="GridviewScrollC1Item">
                                                                    <td>3</td>
                                                                    <td align="center">
                                                                        <asp:Label ID="lblProductionYear3" runat="server" CssClass="form-control" onkeypress="return inputOnlyNumbers(event)" MaxLength="4" TabIndex="5"></asp:Label>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtProductionQuantity3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                    <td align="center">
                                                                        <asp:TextBox ID="txtProductionValue3" runat="server" CssClass="form-control" onkeypress="DecimalOnly()" MaxLength="80" TabIndex="5"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="card">
                                                    <div class="row">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px; margin-bottom: 10px;">
                                                            Means Of Finance (In Rs.)
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Promoter's Equity</label>
                                                            <asp:TextBox ID="txtPromoterEquity" runat="server" class="form-control"
                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Institutional/Public Investors</label>
                                                            <asp:TextBox ID="txtInstitutionsEquity" runat="server" class="form-control"
                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Term Loans</label>
                                                            <asp:TextBox ID="txtTearmLoans" runat="server" class="form-control"
                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Seed Capital</label>
                                                            <asp:TextBox ID="txtSeedCapital" runat="server" class="form-control"
                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Subsidy/Grants through other agencies</label>
                                                            <asp:TextBox ID="txtSubsidyagencies" runat="server" class="form-control"
                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-4 form-group">
                                                            <label class="control-label label-required">Finance From Others Sources</label>
                                                            <asp:TextBox ID="txtMeansFinanceOthers" runat="server" class="form-control"
                                                                MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-title">
                                                <h5 class="text-blue my-3 font-SemiBold">Term Loan details</h5>

                                            </div>
                                            <div class="widget-content nopadding">
                                                <div class="row" id="card">
                                                    <div class="col-sm-12 form-group">
                                                        <div class="text-blue font-SemiBold pb-2" style="font-size: 18px; margin-bottom: 10px;">Implementation Steps Taken - Project Finance</div>
                                                    </div>
                                                    <div class="col-sm-6 form-group">
                                                        <label class="label-required">Have you availed Term Loan</label>
                                                        <asp:DropDownList ID="ddlIsTermLoanAvailed" runat="server" class="form-control"
                                                            MaxLength="80" TabIndex="5" ValidationGroup="Save"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlIsTermLoanAvailed_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">-- SELECT --</asp:ListItem>
                                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                                            <asp:ListItem Value="2">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="row m-0" id="tblTermLoanDtls" runat="server" visible="false">
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">Availed Term Loan</label>
                                                            <asp:DropDownList ID="ddlTermLoanNo" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5">
                                                                <asp:ListItem Value="0" Text="Select Term Loan Number"></asp:ListItem>
                                                                <asp:ListItem Value="TermLoan1" Text="Term Loan1"></asp:ListItem>
                                                                <asp:ListItem Value="TermLoan2" Text="Term Loan2"></asp:ListItem>
                                                                <asp:ListItem Value="TermLoan3" Text="Term Loan3"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">Date of application for Term Loan</label>
                                                            <asp:TextBox ID="txtTermLoanDate" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">Name of the Institution</label>
                                                            <asp:DropDownList ID="ddltermloanbank" runat="server" class="form-control" TabIndex="5">
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div class="col-sm-3 form-group" runat="server">
                                                            <label class="label-required">Term Loan Sanctioned reference No.</label>
                                                            <asp:TextBox ID="txtsactionedloanreferenceNo" runat="server" class="form-control" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">Term Loan Sanctioned Date</label>
                                                            <asp:TextBox ID="txtTeamloanSanctionedDate" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">Term Loan Released Date</label>
                                                            <asp:TextBox ID="txtTermLoanReleasedDatea" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">No Of Installments</label>
                                                            <asp:TextBox ID="txtInstallments" runat="server" class="form-control" onkeypress="return inputOnlyNumbers(event)"
                                                                MaxLength="40" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">Rate Of Interest (%)</label>
                                                            <asp:TextBox ID="txttermloanRateOfInterest" runat="server" class="form-control" onkeypress="DecimalOnly()"
                                                                MaxLength="40" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="control-label label-required">Amount Sanctioned (Rs.)</label>
                                                            <asp:TextBox ID="txtSanctionedAmount" runat="server" class="form-control"
                                                                MaxLength="10" onkeypress="DecimalOnly()" TabIndex="3"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">Term Loan Period - From Date</label>
                                                            <asp:TextBox ID="txtTermLoanPeriodFromDate" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-3 form-group">
                                                            <label class="label-required">Term Loan Period - To Date</label>
                                                            <asp:TextBox ID="txtTermLoanPeriodToDate" runat="server" class="form-control"
                                                                MaxLength="40" TabIndex="5"></asp:TextBox>
                                                        </div>
                                                        <div class="col-sm-12 text-center mb-4">
                                                            <asp:Button ID="btnTermloanAdd" runat="server" CssClass="btn btn-blue m-2"
                                                                TabIndex="5" Text="Add New" OnClick="btnTermloanAdd_Click" />
                                                            <asp:Button ID="btnTermLoanClear" runat="server" CausesValidation="False" CssClass="btn btn-warning m-2"
                                                                TabIndex="5" Text="Cancel" ToolTip="To Clear  the Screen" OnClick="btnTermLoanClear_Click" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                                                        <asp:GridView ID="GVTermLoandtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                            CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" OnRowCommand="GVTermLoandtls_RowCommand">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                                                            <RowStyle CssClass="GridviewScrollC1Item" />
                                                            <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                            <FooterStyle CssClass="GridviewScrollC1Footer" />
                                                            <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Term Loan">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAvailedTermLoan" runat="server" Text='<%# Bind("AvailedTermLoan") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date of Application for Term Loan">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermLoanApplDate" runat="server" Text='<%# Bind("TermLoanApplDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="InstitutionName">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInstitutionName" runat="server" Text='<%# Bind("BankName") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TermLoanSancRefNo">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermLoanSancRefNo" runat="server" Text='<%# Bind("TermLoanSancRefNo") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TermloanSandate">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermloanSandate" runat="server" Text='<%# Bind("TermloanSandate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TermLoanReleaseddate">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermLoanReleaseddate" runat="server" Text='<%# Bind("TermLoanReleaseddate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="No.Of Installments">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermLoanInstallments" runat="server" Text='<%# Bind("Installments") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Rate Of Interest (%)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRateOfInterest" runat="server" Text='<%# Bind("RateOfInterest") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Sanctioned Amount">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblSanctionedAmount" runat="server" Text='<%# Bind("SanctionedAmount") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TermLoan Period From Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermLoanPeriodFromDate" runat="server" Text='<%# Bind("TermLoanPeriodFromDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="TermLoan Period To Date">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblTermLoanPeriodToDate" runat="server" Text='<%# Bind("TermLoanPeriodToDate") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblInstitutionNameid" runat="server" Visible="false" Text='<%# Bind("InstitutionName") %>'></asp:Label>
                                                                        <asp:Label ID="lblTermLoanId" runat="server" Text='<%# Bind("TermLoanId") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnEdit" CommandName="Rowedit" CssClass="btn btn-warning" runat="server" Text="Edit" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Delete">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="btnDelete" OnClientClick="return confirm('Are you sure want to Delete');" CommandName="RowDdelete" CssClass="btn btn-danger" runat="server" Text="Delete" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>

                                                    <div class="col-sm-12 mt-3">
                                                        <asp:Label ID="Label17" runat="server" CssClass="label-required" Font-Bold="True">Approved/Estimated projected cost and assets acquired etc</asp:Label>
                                                    </div>
                                                    <div class="col-sm-12 table-responsive">
                                                        <table class="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
                                                            <tr class="GridviewScrollC1HeaderWrap v">
                                                                <th align="center">Name of Asset
                                                                </th>
                                                                <th align="center">Approved Project
                                                                            <br />
                                                                    Cost (In Rs.)
                                                                </th>
                                                                <th align="center" id="thLoanSanctioned" runat="server">Loan Sanctioned
                                                                            <br />
                                                                    (In Rs.)
                                                                </th>
                                                                <th align="center">Equity from
                                                                            <br />
                                                                    the promoters
                                                                            <br />
                                                                    (In Rs.)
                                                                </th>
                                                                <th align="center" id="thLoanAmount" runat="server">Loan Amount
                                                                            <br />
                                                                    Released (In Rs.)
                                                                </th>
                                                                <th align="center" id="thLoanassetsfinancial" runat="server">Value of assets (as
                                                                            <br />
                                                                    certified by financial<br />
                                                                    institution) (In Rs.)
                                                                </th>
                                                                <th align="center">Value of assets certified
                                                                            <br />
                                                                    by Chartered Accoutant
                                                                            <br />
                                                                    (In Rs.)
                                                                </th>

                                                            </tr>

                                                            <tr class="GridviewScrollC1Item">
                                                                <td>Land
                                                                </td>
                                                                <td style="padding-top: 5px;">
                                                                    <asp:TextBox ID="txtLand2" runat="server" class="form-control" Width="110px"
                                                                        TabIndex="5" onkeypress="DecimalOnly()" AutoPostBack="True" OnTextChanged="txtLand2_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding-top: 5px;" id="tdLand3" runat="server">
                                                                    <asp:TextBox ID="txtLand3" runat="server" class="form-control" Width="110px"
                                                                        TabIndex="5" onkeypress="DecimalOnly()" AutoPostBack="True" OnTextChanged="txtLand3_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding-top: 5px;">
                                                                    <asp:TextBox ID="txtLand4" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand4_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding-top: 5px;" id="tdLand5" runat="server">
                                                                    <asp:TextBox ID="txtLand5" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand5_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding-top: 5px;" id="tdLand6" runat="server">
                                                                    <asp:TextBox ID="txtLand6" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand6_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td style="padding-top: 5px;">
                                                                    <asp:TextBox ID="txtLand7" runat="server" class="form-control" Width="110px"
                                                                        AutoPostBack="True" onkeypress="DecimalOnly()" MaxLength="40" TabIndex="5" OnTextChanged="txtLand7_TextChanged1"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr class="GridviewScrollC1Item2">
                                                                <td>Buildings
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBuilding2" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" Width="110px" AutoPostBack="True" OnTextChanged="txtLand2_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdBuilding3" runat="server">
                                                                    <asp:TextBox ID="txtBuilding3" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand3_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBuilding4" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand4_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdBuilding5" runat="server">
                                                                    <asp:TextBox ID="txtBuilding5" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand5_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdBuilding6" runat="server">
                                                                    <asp:TextBox ID="txtBuilding6" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand6_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtBuilding7" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"
                                                                        OnTextChanged="txtLand7_TextChanged1" AutoPostBack="True"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr class="GridviewScrollC1Item">
                                                                <td class="auto-style1">Plant & Machinery
                                                                </td>
                                                                <td class="auto-style1">
                                                                    <asp:TextBox ID="txtPM2" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" Width="110px" AutoPostBack="True" OnTextChanged="txtLand2_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td class="auto-style1" id="tdPM3" runat="server">
                                                                    <asp:TextBox ID="txtPM3" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand3_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td class="auto-style1">
                                                                    <asp:TextBox ID="txtPM4" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand4_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td class="auto-style1" id="tdPM5" runat="server">
                                                                    <asp:TextBox ID="txtPM5" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand5_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td class="auto-style1" id="tdPM6" runat="server">
                                                                    <asp:TextBox ID="txtPM6" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand6_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td class="auto-style1">
                                                                    <asp:TextBox ID="txtPM7" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5"
                                                                        OnTextChanged="txtLand7_TextChanged1" AutoPostBack="True"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr class="GridviewScrollC1Item2">
                                                                <td>Contingencies
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMCont2" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand2_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdMCont3" runat="server">
                                                                    <asp:TextBox ID="txtMCont3" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand3_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMCont4" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand4_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdMCont5" runat="server">
                                                                    <asp:TextBox ID="txtMCont5" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand5_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdMCont6" runat="server">
                                                                    <asp:TextBox ID="txtMCont6" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand6_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMCont7" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand7_TextChanged1"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr class="GridviewScrollC1Item">
                                                                <td>Erection
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtErec2" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand2_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdErec3" runat="server">
                                                                    <asp:TextBox ID="txtErec3" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand3_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtErec4" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand4_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdErec5" runat="server">
                                                                    <asp:TextBox ID="txtErec5" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand5_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdErec6" runat="server">
                                                                    <asp:TextBox ID="txtErec6" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand6_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtErec7" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand7_TextChanged1"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr class="GridviewScrollC1Item2">
                                                                <td>Technical know-how,<br />
                                                                    feasibility study
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTFS2" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" Width="110px" AutoPostBack="True" OnTextChanged="txtLand2_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdTFS3" runat="server">
                                                                    <asp:TextBox ID="txtTFS3" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand3_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTFS4" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand4_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdTFS5" runat="server">
                                                                    <asp:TextBox ID="txtTFS5" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand5_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdTFS6" runat="server">
                                                                    <asp:TextBox ID="txtTFS6" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand6_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtTFS7" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand7_TextChanged1"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr class="GridviewScrollC1Item">
                                                                <td>Working Capital Margin
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtWC2" runat="server" class="form-control"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" Width="110px" AutoPostBack="True" OnTextChanged="txtLand2_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdWC3" runat="server">
                                                                    <asp:TextBox ID="txtWC3" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand3_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtWC4" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand4_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdWC5" runat="server">
                                                                    <asp:TextBox ID="txtWC5" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand5_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td id="tdWC6" runat="server">
                                                                    <asp:TextBox ID="txtWC6" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand6_TextChanged"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtWC7" runat="server" class="form-control" Width="110px"
                                                                        MaxLength="40" onkeypress="DecimalOnly()" TabIndex="5" AutoPostBack="True" OnTextChanged="txtLand7_TextChanged1"></asp:TextBox>
                                                                </td>

                                                            </tr>
                                                            <tr class="GridviewScrollC1Item2">
                                                                <td>Total</td>
                                                                <td>
                                                                    <asp:Label ID="lbltotal2" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td id="tdtotal3" runat="server">
                                                                    <asp:Label ID="lbltotal3" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbltotal4" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td id="tdtotal5" runat="server">
                                                                    <asp:Label ID="lbltotal5" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td id="tdtotal6" runat="server">
                                                                    <asp:Label ID="lbltotal6" runat="server" Text=""></asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lbltotal7" runat="server" Text=""></asp:Label>
                                                                </td>

                                                            </tr>
                                                        </table>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col cos-sm-12 text-left" style="padding-top: 15px">
                                                        <asp:Button Text="Previous" CssClass="btn btn-blue px-4 title5" ID="btnPrevious4" runat="server" OnClick="btnPrevious4_Click" />
                                                    </div>
                                                    <div class="col cos-sm-12 text-right" style="padding-top: 15px">
                                                        <asp:Button Text="Save & Next" CssClass="btn btn-blue px-4 title5" ID="btnNext4" runat="server" OnClick="btnNext4_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </asp:View>
                            <asp:View ID="View5" runat="server">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-content nopadding">
                                                <div id="home" class="container-fluid tab-pane active">
                                                    <div id="card">
                                                        <div id="divbank" runat="server">
                                                        <div class="row">
                                                            <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px !important; margin-bottom: 10px;">Unit Main Operation Bank Details</div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required" id="Label16" runat="server">Name of the Unit/Enterprise</label>
                                                                <asp:TextBox ID="txtAccountName" runat="server" Enabled="false" ReadOnly="true" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required" id="Label14" runat="server">Name of the Bank</label>
                                                                <asp:DropDownList ID="ddlBank" runat="server" RepeatDirection="Horizontal" Enabled="false" class="form-control" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required" id="Label15" runat="server">Branch Name</label>
                                                                <asp:TextBox ID="txtBranchName" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required" id="Label19" runat="server">Account Number</label>
                                                                <asp:TextBox ID="txtAccNumber" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required" id="Label18" runat="server">Account Type</label>
                                                                <asp:DropDownList ID="ddlAccountType" runat="server" RepeatDirection="Horizontal" Enabled="false" class="form-control" AutoPostBack="true">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required" id="Label20" runat="server">IFSC Code</label>
                                                                <asp:TextBox ID="txtIfscCode" runat="server" class="form-control" onkeypress="return alphanumeric(this)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required" id="Label13" runat="server">Name of the authorized Person for operating the account </label>
                                                                <asp:TextBox ID="txtaccountauthorizedPerson" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                            <div class="col-sm-4 form-group">
                                                                <label class="control-label label-required" id="Label21" runat="server">Designation</label>
                                                                <asp:TextBox ID="txtaccountauthorizedPersonDesignation" runat="server" class="form-control"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-sm-3 form-group">
                                                                <label class="control-label label-required">Specimen Signature (Pdf Only)</label>
                                                                <asp:FileUpload ID="FuSpecimenSignatureOperation" runat="server" CssClass="file-browse" />
                                                            </div>
                                                            <div class="col-sm-3 form-group  text-left">
                                                                <br />
                                                                <asp:Button ID="btnSpecimenSignatureOperation" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" Text="Upload" OnClick="btnSpecimenSignatureOperation_Click" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                 <asp:HyperLink ID="hySpecimenSignatureOperation" runat="server" CssClass="LBLBLACK" Target="_blank"></asp:HyperLink>
                                                            </div>
                                                        </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col cos-sm-12 text-left" style="padding-top: 15px">
                                                            <asp:Button Text="Previous" CssClass="btn btn-blue px-4 title5" ID="btnPrevious5" runat="server" OnClick="btnPrevious5_Click" />
                                                        </div>
                                                        <div class="col cos-sm-12 text-right" style="padding-top: 15px">
                                                            <asp:Button Text="Next" CssClass="btn btn-blue px-4 title5" ID="btnNext5" runat="server" OnClick="btnNext5_Click" />
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="View6" runat="server">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-content nopadding">
                                                <div id="card">
                                                    <div class="row">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="margin-bottom: 5px; margin-top: 20px;">TSIPASS CFE APPROVALS</div>
                                                    </div>
                                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">

                                                        <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdDetails_RowDataBound"
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
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Left" Width="200px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget-box">
                                            <div class="widget-content nopadding">
                                                <div id="card">
                                                    <div class="row w-100 m-0">
                                                        <div class="col-sm-12 text-blue label-required font-SemiBold" style="font-size: 18px !important; margin-bottom: 10px;">List of Documents to Upload</div>
                                                    </div>
                                                    <div class="row w-100 m-0">
                                                        <div class="col-sm-8 form-group">
                                                            <label class="control-label label-required" id="Label11" runat="server">Type of Document</label>
                                                            <asp:DropDownList ID="ddltypeofDocuments" runat="server" RepeatDirection="Horizontal" class="form-control">
                                                                <asp:ListItem Value="0" Selected="True">--Select Document---</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="row w-100 m-0">
                                                        <div class="col-sm-3 form-group">
                                                            <asp:FileUpload ID="fuDocuments1" runat="server" CssClass="file-browse" />
                                                        </div>
                                                        <div class="col-sm-2 form-group  text-left">
                                                            <asp:Button ID="btnUpload1" runat="server" CssClass="btn btn-blue py-1 title7 mt-1" OnClick="btnUpload1_Click" Text="Upload" />
                                                        </div>
                                                    </div>
                                                    <%-- <div class="col-sm-12 mt-sm-3 text-left">
                                                        <p><strong>Note : </strong>The Uploaded File Size Should be Less Than or Equal to 1MB Only.</p>
                                                    </div>--%>
                                                    <div class="col-lg-9 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
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
                                                </div>
                                                <div class="row" style="padding-top: 30px">
                                                    <div class="col cos-sm-12 text-left">
                                                        <asp:Button Text="Previous" CssClass="btn btn-blue px-4 title5" ID="btnPrevious6" runat="server" OnClick="btnPrevious6_Click" />
                                                    </div>
                                                    <div class="col cos-sm-12 text-right">
                                                        <asp:Button Text="Submit CAF" CssClass="btn btn-blue px-4 title5" ID="btnNext6" runat="server" OnClick="btnNext6_Click" />
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:View>

                        </asp:MultiView>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 100%">
                                    <table style="width: 100%">
                                        <tr>
                                            <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                                                <div id="success" runat="server" visible="false" class="alert alert-success">
                                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
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
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hdfID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" />
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="child" />
                                    <asp:HiddenField ID="hdfFlagID" runat="server" />
                                    <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                                        ShowSummary="False" ValidationGroup="group1" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td style="font-weight: bold">Instructions to the applicant :
                                </td>
                            </tr>
                            <tr>
                                <td>Fields marked by asterisk (<span class="label-required"></span>) are mandatory
                                    <asp:HiddenField ID="hdnUserID" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnShowGrid" runat="server" />
            <asp:HiddenField ID="hdnPMEdit" runat="server" />
            <asp:HiddenField ID="hdnPMCostEdit" runat="server" />
            <asp:HiddenField ID="hdnMachineCostN" runat="server" />
            <asp:HiddenField ID="hdnIsFirstTime" Value="N" runat="server" />
            <asp:HiddenField ID="hdnVerified" Value="N" runat="server" />
            <asp:HiddenField ID="hdnApprovedLand" runat="server" />
            <asp:HiddenField ID="hdnApprovedBuilding" runat="server" />
            <asp:HiddenField ID="hdnApprovedPlant" runat="server" />
            <asp:HiddenField ID="hdnApprovedLandExp" runat="server" />
            <asp:HiddenField ID="hdnApprovedBuildingExp" runat="server" />
            <asp:HiddenField ID="hdnApprovedPlantExp" runat="server" />

            <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="HplNewExpInvDetails"
                CancelControlID="btnPopupClose" BackgroundCssClass="Background">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe style="width: 100%; height: 100%;" id="irm1" src="frmLandBuildingPMDetails.aspx" runat="server"></iframe>
                <br />
                <asp:ImageButton ID="btnPopupClose" Height="50px" Width="50px" ImageUrl="~/images/CloseButtonimg4.png" runat="server" AlternateText="Close" />
                <%-- <button type="button" id="btnPopupClose" runat="server" class="btn-close" aria-label="Close"></button>
                <asp:Button ID="Button1" runat="server" Text="Close" />--%>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>


    <link href="../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />

    <%--<script src="../..Js/jquery.min.js"></script>--%>
    <link href="../../Js/ddlsearch/jquery-customselect.css" rel="stylesheet" />
    <script src="../../Js/ddlsearch/jquery-customselect.js"></script>
    <script src="../../Js/table2excel.js"></script>

    <script type="text/javascript">

        function Export() {
            $("[id*=grdPandM]").table2excel({
                filename: "PlantMachineryList.xls"
            });
        }

        $("input[type=text]").attr('autocomplete', 'off');
        $("input[id$='ContentPlaceHolder1_txtDateofCommencement']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtDateofCommencementExp']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtDateOfIncorporation']").keydown(function () {
            return false;
        });

        $("input[id$='ContentPlaceHolder1_txtEINIEMILDate']").keydown(function () {
            return false;
        });


        $("input[id$='ContentPlaceHolder1_txtExpanDiverPowerReleaseDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtNewPowerReleaseDate']").keydown(function () {
            return false;
        });
        //$("input[id$='ContentPlaceHolder1_txtExistingPowerServiceDate']").keydown(function () {
        //    return false;
        //});
        $("input[id$='ContentPlaceHolder1_txtExistingPowerReleaseDate']").keydown(function () {
            return false;
        });


        $("input[id$='ContentPlaceHolder1_txtTermLoanDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtTeamloanSanctionedDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtTermLoanReleasedDatea']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtTermLoanPeriodFromDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtTermLoanPeriodToDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtGovermentOrderDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtInvoiceDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtMachineLoadingDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtVaivleDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtInitiationDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtCertifiedDate']").keydown(function () {
            return false;
        });
        $("input[id$='ContentPlaceHolder1_txtPMPaymentTrnsactionDate']").keydown(function () {
            return false;
        });

        function pageLoad() {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();

            $("input[id$='ContentPlaceHolder1_ddltypeofDocuments']").customselect();

            $("input[type=text]").attr('autocomplete', 'off');

            $("input[id$='ContentPlaceHolder1_txtTermLoanPeriodToDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='ContentPlaceHolder1_txtTermLoanPeriodFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='ContentPlaceHolder1_txtEINIEMILDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtDateofCommencement']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback
            $("input[id$='ContentPlaceHolder1_txtDateofCommencementExp']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtDateOfIncorporation']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtExpanDiverPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback   
            $("input[id$='ContentPlaceHolder1_txtNewPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback


            $("input[id$='ContentPlaceHolder1_txtExistingPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtTermLoanDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtTeamloanSanctionedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtTermLoanReleasedDatea']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtMachineLoadingDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                }); // Will run at every postback/AsyncPostback
            $("input[id$='ContentPlaceHolder1_txtVaivleDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtInitiationDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtGovermentOrderDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtInvoiceDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtCertifiedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtPMPaymentTrnsactionDate']").datepicker(
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
            $("input[id$='ContentPlaceHolder1_ddltypeofDocuments']").customselect();
            $("input[id$='ContentPlaceHolder1_txtTermLoanPeriodToDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='ContentPlaceHolder1_txtTermLoanPeriodFromDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                });

            $("input[id$='ContentPlaceHolder1_txtEINIEMILDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback

            $("input[id$='ContentPlaceHolder1_txtDateofCommencement']").datepicker(
                {
                    //dateFormat: "dd/mm/yy",
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //maxDate: new Date(currentYear, currentMonth, currentDate)
                });
            $("input[id$='ContentPlaceHolder1_txtDateOfIncorporation']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback   
            $("input[id$='ContentPlaceHolder1_txtExpanDiverPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                    //  maxDate: new Date(currentYear, currentMonth, currentDate)
                }); // Will run at every postback/AsyncPostback   
            $("input[id$='ContentPlaceHolder1_txtNewPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,

                })
            $("input[id$='ContentPlaceHolder1_txtExistingPowerReleaseDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtTermLoanDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtTeamloanSanctionedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtTermLoanReleasedDatea']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtMachineLoadingDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                }); // Will run at every postback/AsyncPostback
            $("input[id$='ContentPlaceHolder1_txtVaivleDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtInitiationDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtGovermentOrderDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtInvoiceDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
            $("input[id$='ContentPlaceHolder1_txtCertifiedDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });

            $("input[id$='ContentPlaceHolder1_txtPMPaymentTrnsactionDate']").datepicker(
                {
                    dateFormat: "dd/mm/yy",
                    changeMonth: true,
                    changeYear: true,
                });
        });

        function Calculate() {
            /*
             Double ActualMachineCost = 0, FreightCharges = 0, TransportCharges = 0, Cgst = 0, Sgst = 0, Igst = 0;
            ActualMachineCost= Convert.ToDouble(GetDecimalNullValue(txtActMachineCost.Text.TrimStart().TrimEnd()));
            FreightCharges = Convert.ToDouble(GetDecimalNullValue(txtFreightCharges.Text.TrimStart().TrimEnd()));
            TransportCharges = Convert.ToDouble(GetDecimalNullValue(txtTransportCharges.Text.TrimStart().TrimEnd()));
            Cgst = Convert.ToDouble(GetDecimalNullValue(txtcgst.Text.TrimStart().TrimEnd()));
            Sgst = Convert.ToDouble(GetDecimalNullValue(txtsgst.Text.TrimStart().TrimEnd()));
            Igst = Convert.ToDouble(GetDecimalNullValue(txtigst.Text.TrimStart().TrimEnd()));

            txttotalGst.Text = (Cgst + Sgst + Igst).ToString();
            txtCostofMachine.Text = (ActualMachineCost + FreightCharges + TransportCharges + Cgst + Sgst + Igst).ToString();
             */
            //ContentPlaceHolder1_txtActMachineCost
            var ActualMachineCost = 0, FreightCharges = 0, TransportCharges = 0, Cgst = 0, Sgst = 0, Igst = 0, CustomPaid = 0, Importduty = 0, Portcharges = 0, Statutorytaxes = 0;
            if ($('#ContentPlaceHolder1_txtActMachineCost').val() != "") {
                ActualMachineCost = parseFloat($('#ContentPlaceHolder1_txtActMachineCost').val());
            }
            if ($('#ContentPlaceHolder1_txtFreightCharges').val() != "") {
                FreightCharges = parseFloat($('#ContentPlaceHolder1_txtFreightCharges').val());
            }
            if ($('#ContentPlaceHolder1_txtTransportCharges').val() != "") {
                TransportCharges = parseFloat($('#ContentPlaceHolder1_txtTransportCharges').val());
            }
            if ($('#ContentPlaceHolder1_txtcgst').val() != "") {
                Cgst = parseFloat($('#ContentPlaceHolder1_txtcgst').val());
            }
            if ($('#ContentPlaceHolder1_txtsgst').val() != "") {
                Sgst = parseFloat($('#ContentPlaceHolder1_txtsgst').val());
            }
            if ($('#ContentPlaceHolder1_txtigst').val() != "") {
                Igst = parseFloat($('#ContentPlaceHolder1_txtigst').val());
            }
            if ($('#ContentPlaceHolder1_rdlMachineType_0').is(':checked') == true) {
                if ($('#ContentPlaceHolder1_txtCustomPaid').val() != "") {
                    CustomPaid = parseFloat($('#ContentPlaceHolder1_txtCustomPaid').val());
                }
                if ($('#ContentPlaceHolder1_txtImportduty').val() != "") {
                    Importduty = parseFloat($('#ContentPlaceHolder1_txtImportduty').val());
                }
                if ($('#ContentPlaceHolder1_txtportcharges').val() != "") {
                    Portcharges = parseFloat($('#ContentPlaceHolder1_txtportcharges').val());
                }
                if ($('#ContentPlaceHolder1_txtstatutorytaxesetc').val() != "") {
                    Statutorytaxes = parseFloat($('#ContentPlaceHolder1_txtstatutorytaxesetc').val());
                }
            }

            $('#ContentPlaceHolder1_txttotalGst').val(Cgst + Sgst + Igst);
            $('#ContentPlaceHolder1_txtCostofMachine').val(ActualMachineCost + FreightCharges + TransportCharges + Cgst + Sgst + Igst + CustomPaid + Importduty + Portcharges + Statutorytaxes);
            $('#ContentPlaceHolder1_hdnMachineCostN').val(ActualMachineCost + FreightCharges + TransportCharges + Cgst + Sgst + Igst + CustomPaid + Importduty + Portcharges + Statutorytaxes);

        }

    </script>


    <%--<style type="text/css">
        .ui-da font-size: 8pt !important; padding: 0.2em 0.2em 0; width: 250px; color: Black;
        }

        select {
            color: Black !important;
        }

        .auto-style1 {
            height: 26px;
        }

        .auto-style2 {
            height: 22px;
        }
    </style>--%>
</asp:Content>
