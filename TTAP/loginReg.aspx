<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="loginReg.aspx.cs" Inherits="TTAP.loginReg" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
        <link rel="stylesheet" href="https://e6t7a8v2.stackpathcdn.com/tutorial/css/fontawesome-all.min.css">
        <%-- <script src="https://www.google.com/recaptcha/api.js" async defer></script>--%>
        <script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit"
            async defer></script>
        <script type="text/javascript">

            var site_key = '<%= ConfigurationManager.AppSettings["GCaptchSiteKey"]%>';

            var recaptchres = "";
            var onloadCallback = function () {
                loadgrecaptchaexplicit();
            }
            function loadgrecaptchaexplicit() {
                try {
                    grecaptcha.render('dvCaptcha', {
                        'sitekey': site_key,
                        'callback': function (response) {
                            recaptchres = response;
                            jQuery('#lblMessage').html("");
                            //jQuery('#lblMessage').css('color', 'green').html('Success');
                            //alert(recaptchres);
                        }
                        //theme: 'light', //light or dark    
                        //type: 'image',// image or audio    
                        //size: 'normal'//normal or compact  
                    });
                }
                catch (Error) {
                    jQuery('#lblMessage').html("Captcha Image Not Showing");
                }

            }

            <%--$(function () {
                $('#<%=lnkbtnLogin.ClientID%>').click(function () {
                   
                    
                    if ($('#ContentPlaceHolder1_txtuname').val() == "" || $('#ContentPlaceHolder1_txtpsw').val() == "") {
                        var message1 = 'Please Enter User Name & Password.';
                        jQuery('#lblMessage').html(message1);
                        jQuery('#lblMessage').css('color', (message1.toLowerCase() == 'success!') ? "green" : "red");
                        return false;
                    }
                    else if (recaptchres == "") {
                        var message = 'Please verify that you are not a robot.';
                        jQuery('#lblMessage').html(message);
                        jQuery('#lblMessage').css('color', (message.toLowerCase() == 'success!') ? "green" : "red");
                        return false;
                    }
                    
                });
            });--%>
        </script>
        <div class="row">
            <div class="col-sm-6 offset-sm-3 mt-sm-2 p-sm-4 mt-3">
                <div class="box-content p-4 bg-white">

                    <div class="form-icon"><i class="fa fa-lock"></i></div>
                    <h2 class="mb-3 text-blue font-SemiBold">Login</h2>
                    <div class="modal-body align-w3">
                        <%--<form action="#" method="post" class="p-sm-3">--%>
                        <div class="form-group">
                            <i class="fa fa-user"></i>
                            <label for="recipient-name" class="col-form-label">Username</label>

                            <asp:TextBox ID="txtuname" runat="server" placeholder="User name" class="form-control"
                                required="" autofocus="true"></asp:TextBox>

                        </div>
                        <div class="form-group">
                            <i class="fa fa-lock"></i>
                            <label for="password" class="col-form-label">Password</label>
                            <asp:TextBox ID="txtpsw" TextMode="Password" runat="server" placeholder="Password"
                                class="form-control" required=""></asp:TextBox>
                        </div>
                        <%--<div class="form-group">
                            <div class="g-recaptcha" data-sitekey="6Lc2Dj4cAAAAACWbQ_jfdwIOJzD_T8_yoeb-ViYw"></div>
                        </div>--%>
                        <div class="form-row">
                            <div class="my-2 col-12">
                                <div id="dvCaptcha">
                                </div>
                            </div>
                            <label id="lblMessage" runat="server" clientidmode="static"></label>
                        </div>

                        <div class="right-w3l">
                            <asp:Button ID="lnkbtnLogin" TabIndex="3" title="Login" class="btn btn-blue px-5 float-right" data-loading-text="Loading..."
                                runat="server" Text="Login" OnClick="lnkbtnLogin_Click" />
                            <!--<input type="submit" class="form-control bg-theme" value="Login">-->
                        </div>


                        <%-- </form>--%>
                    </div>
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <div id="success" runat="server" visible="false" class="alert alert-success m-0">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong>
                                    <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                </div>
                                <div id="Failure" runat="server" visible="false" class="alert alert-danger m-0">
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
    <style>
        .main {
            background: #f3f8ff;
        }

        input#ContentPlaceHolder1_lnkbtnLogin {
            border: 2px solid #009688;
            border-radius: 0px !important;
            color: #000;
            font-weight: 900;
            
        }

        .box-content.p-4.bg-white {
            font-family: 'Rubik', sans-serif;
            padding: 20px !important;
            box-shadow: 0 0 3px #505050;
            border-radius: 0px !important;
            position: relative;
        }

        h2.mb-3.text-blue.font-SemiBold {
            text-align: center !important;
            font-weight: 600;
        }

        .form-icon {
            color: #009688;
            font-size: 50px;
            text-align: center;
            line-height: 50px;
            text-shadow: 5px 5px 3px #0E7886;
        }

        form#form1 {
            background: #0096881a;
        }
    </style>

</asp:Content>
