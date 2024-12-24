<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="VisitorRegistration.aspx.cs" Inherits="TTAP.UI.Pages.VisitorRegistration" %>

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <style>
        * {
            box-sizing: border-box;
        }

        .row::after {
            content: "";
            clear: both;
            display: block;
        }

        [class*="col-"] {
            float: left;
            padding: 15px;
        }

        html {
            font-family: "Lucida Sans", sans-serif;
        }

        .header {
            background-color: #e00e29;
            color: #ffffff;
            padding: 15px;
        }

        .header1 {
            background-color: white;
            color: #ffffff;
            padding: 10px;
        }
        .header2 {
            background-color: #0b8c0d;
            color: #ffffff;
            padding: 10px;
        }

        .menu ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
        }

        .menu li {
            padding: 8px;
            margin-bottom: 7px;
            background-color: #33b5e5;
            color: #ffffff;
            box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
        }

            .menu li:hover {
                background-color: #0099cc;
            }

        .aside {
            background-color: #33b5e5;
            padding: 15px;
            color: #ffffff;
            text-align: center;
            font-size: 14px;
            box-shadow: 0 1px 3px rgba(0,0,0,0.12), 0 1px 2px rgba(0,0,0,0.24);
        }

        .footer {
            background-color: #274c43;
            color: #ffffff;
            text-align: center;
            font-size: 12px;
            padding: 15px;
        }

        /* For desktop: */
        .col-1 {
            width: 8.33%;
        }

        .col-2 {
            width: 16.66%;
        }

        .col-3 {
            width: 25%;
        }

        .col-4 {
            width: 33.33%;
        }

        .col-5 {
            width: 41.66%;
        }

        .col-6 {
            width: 50%;
        }

        .col-7 {
            width: 58.33%;
        }

        .col-8 {
            width: 66.66%;
        }

        .col-9 {
            width: 75%;
        }

        .col-10 {
            width: 83.33%;
        }

        .col-11 {
            width: 91.66%;
        }

        .col-12 {
            width: 100%;
        }

        @media only screen and (max-width: 768px) {
            /* For mobile phones: */
            [class*="col-"] {
                width: 100%;
            }
        }
    </style>
    <script type="text/javascript">

        function inputOnlyNumbers(evt) {
            var e = window.event || evt; // for trans-browser compatibility 
            var charCode = e.which || e.keyCode;
            if (((charCode > 45 && charCode < 58) || charCode == 8 || charCode == 9) && charCode != 46 && charCode != 47) {
                return true;
            }
            return false;
        }
        function CheckMobileNo() {
            if (document.getElementById('txtMobile').value != "") {
                if (document.getElementById('txtMobile').value.length < 10) {
                    alert('Please enter 10 digit mobile number');
                }
            }
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
    </script>
</head>
<body>
    <form runat="server">

    <div class="header" align="center">
        <h2>ARTIGIANO IN FIERA – 2023</h2>
        <h4>Milan, Italy – 2nd-10th  December, 2023</h4>
    </div>
    <div class="header1" align="center">
        <h2 style="color: red;">MADE BEST IN INDIA </h2>
        <h4 style="color: black;">Dedicated to Geographical Indications (GI) Tagged Products of Telangana</h4>
    </div>
        <div  align="center">
    <table>
        <tr>
            <td>
                <img src="<%=Page.ResolveUrl("../../images/tsco.jpg")%>" width="80" height="80" alt="" class="img-fluid" />
            </td>
            <td>
                <img src="<%=Page.ResolveUrl("../../images/logo.png")%>" width="90" height="90" alt="" class="img-fluid" />
            </td>
            <td>
                <img src="<%=Page.ResolveUrl("../../images/Golkonda.jpg")%>" width="80" height="80" alt="" class="img-fluid" />
            </td>
        </tr>
    </table>
        </div>
       
        <div class="header2" align="center">
        <h4>Visitor Registration</h4>
    </div>
    <div class="row" id="divMain" align="center" runat="server">
        <div class="col-3 menu">
            <table>
                <tr>
                    <td>
                        <input type="text" class="col-16" id="txtName" runat="server" placeholder="Name" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" class="col-16" id="txtEmail" onblur="validateEmail(this);" runat="server" placeholder="Email Id" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" class="col-16" id="txtMobile" onkeypress="return inputOnlyNumbers(event)" onblur="return CheckMobileNo()" maxlength="12" runat="server" placeholder="Enter Mobile Number" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" class="col-16" id="txtCountry" runat="server" placeholder="Country" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" class="col-16" id="txtCity" runat="server" placeholder="Organization" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" class="col-16" id="txtProduct" runat="server" placeholder="Products" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" class="col-16" id="txtSuggestion" runat="server" placeholder="Suggestions" />
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Button runat="server" CssClass="col-12" Text="Submit" style="background: green;color: white;" ID="btnAdd" OnClick="btnSubmit_ServerClick"  />
                    </td>
                </tr>
            </table>

        </div>
    </div>
    <div class="footer" id="divFooter" runat="server" visible="false">
  <p>Details Submitted Successfully</p>
</div>
        </form>
</body>
</html>
