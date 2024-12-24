<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmChangePassword.aspx.cs" Inherits="TTAP.UI.Pages.frmChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Change Password</title>

  <%--  <link href="../../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../../assets/css/custom.css" rel="stylesheet" />
    <link href="../../assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />--%>
    <style>
        /*#content {
            margin-top: 27px !important;
        }*/

        /*.col-md-3 {
            padding-right: 37px !important;
            padding-left: 80px !important;
            padding-top: 80px !important;
            width: 16% !important;
            float: left !important;
        }*/
    </style>
      <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        #ContentPlaceHolder1_Button8 {
            background: none !important;
            border: 0px !important;
            color: #fff !important;
            font-weight: 900;
            font-family: revert !important;
        }
    </style>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
    <!-- Core CSS - Include with every page -->

    <%-- <link href="assets/plugins/bootstrap/bootstrap.css" rel="stylesheet" />--%>
    <link href="../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />

    <link href="../assets/plugins/pace/pace-theme-big-counter.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <link href="../assets/css/main-style.css" rel="stylesheet" />
    <link href="../assets/css/custom.css" rel="stylesheet" />
    <!-- Page-Level CSS -->
    <link href="../assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <style>
        /*#content {
            margin-top: 27px !important;
        }*/
        .row {
            margin-right: -15px;
            margin-left: -15px;
        }

        /*a {
            color: black !important;
        }*/

        .panel-footer {
            padding: 10px 15px;
            background-color: #f5f5f5;
            border-top: 1px solid #ddd;
            border-bottom-right-radius: 3px;
            border-bottom-left-radius: 3px;
        }

        .panel-body {
            padding: 15px;
        }



        .panel {
            margin-bottom: 20px;
            background-color: #fff;
            border: 1px solid transparent;
            border-radius: 4px;
            -webkit-box-shadow: 0 1px 1px rgba(0, 0, 0, .05);
            box-shadow: 0 1px 1px rgba(0, 0, 0, .05);
        }

        @media (min-width: 992px) {
            .col-md-1, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-md-10, .col-md-11, .col-md-12 {
                float: left;
            }

            .col-md-12 {
                width: 100%;
            }

            .col-md-11 {
                width: 91.66666667%;
            }

            .col-md-10 {
                width: 83.33333333%;
            }

            .col-md-9 {
                width: 75%;
            }

            .col-md-8 {
                width: 66.66666667%;
            }

            .col-md-7 {
                width: 58.33333333%;
            }

            .col-md-6 {
                width: 50%;
            }

            .col-md-5 {
                width: 41.66666667%;
            }

            .col-md-4 {
                width: 30%;
            }

            .col-md-3 {
                width: 21% !important;
            }

            .col-md-2 {
                width: 16.66666667%;
            }

            .col-md-1 {
                width: 8.33333333%;
            }

            .col-md-pull-12 {
                right: 100%;
            }

            .col-md-pull-11 {
                right: 91.66666667%;
            }

            .col-md-pull-10 {
                right: 83.33333333%;
            }

            .col-md-pull-9 {
                right: 75%;
            }

            .col-md-pull-8 {
                right: 66.66666667%;
            }

            .col-md-pull-7 {
                right: 58.33333333%;
            }

            .col-md-pull-6 {
                right: 50%;
            }

            .col-md-pull-5 {
                right: 41.66666667%;
            }

            .col-md-pull-4 {
                right: 33.33333333%;
            }

            .col-md-pull-3 {
                right: 25%;
            }

            .col-md-pull-2 {
                right: 16.66666667%;
            }

            .col-md-pull-1 {
                right: 8.33333333%;
            }

            .col-md-pull-0 {
                right: 0;
            }

            .col-md-push-12 {
                left: 100%;
            }

            .col-md-push-11 {
                left: 91.66666667%;
            }

            .col-md-push-10 {
                left: 83.33333333%;
            }

            .col-md-push-9 {
                left: 75%;
            }

            .col-md-push-8 {
                left: 66.66666667%;
            }

            .col-md-push-7 {
                left: 58.33333333%;
            }

            .col-md-push-6 {
                left: 50%;
            }

            .col-md-push-5 {
                left: 41.66666667%;
            }

            .col-md-push-4 {
                left: 33.33333333%;
            }

            .col-md-push-3 {
                left: 25%;
            }

            .col-md-push-2 {
                left: 16.66666667%;
            }

            .col-md-push-1 {
                left: 8.33333333%;
            }

            .col-md-push-0 {
                left: 0;
            }

            .col-md-offset-12 {
                margin-left: 100%;
            }

            .col-md-offset-11 {
                margin-left: 91.66666667%;
            }

            .col-md-offset-10 {
                margin-left: 83.33333333%;
            }

            .col-md-offset-9 {
                margin-left: 75%;
            }

            .col-md-offset-8 {
                margin-left: 66.66666667%;
            }

            .col-md-offset-7 {
                margin-left: 58.33333333%;
            }

            .col-md-offset-6 {
                margin-left: 50%;
            }

            .col-md-offset-5 {
                margin-left: 41.66666667%;
            }

            .col-md-offset-4 {
                margin-left: 33.33333333%;
            }

            .col-md-offset-3 {
                margin-left: 25%;
            }

            .col-md-offset-2 {
                margin-left: 16.66666667%;
            }

            .col-md-offset-1 {
                margin-left: 8.33333333%;
            }

            .col-md-offset-0 {
                margin-left: 0;
            }
        }

        @media (min-width: 1200px) {
            .col-lg-1, .col-lg-2, .col-lg-3, .col-lg-4, .col-lg-5, .col-lg-6, .col-lg-7, .col-lg-8, .col-lg-9, .col-lg-10, .col-lg-11, .col-lg-12 {
                float: left;
            }

            .col-lg-12 {
                width: 100%;
            }

            .col-lg-11 {
                width: 91.66666667%;
            }

            .col-lg-10 {
                width: 83.33333333%;
            }

            .col-lg-9 {
                width: 75%;
            }

            .col-lg-8 {
                width: 66.66666667%;
            }

            .col-lg-7 {
                width: 58.33333333%;
            }

            .col-lg-6 {
                width: 50%;
            }

            .col-lg-5 {
                width: 41.66666667%;
            }

            .col-lg-4 {
                width: 33.33333333%;
            }

            .col-lg-3 {
                width: 21% !important;
            }

            .col-lg-2 {
                width: 16.66666667%;
            }

            .col-lg-1 {
                width: 8.33333333%;
            }

            .col-lg-pull-12 {
                right: 100%;
            }

            .col-lg-pull-11 {
                right: 91.66666667%;
            }

            .col-lg-pull-10 {
                right: 83.33333333%;
            }

            .col-lg-pull-9 {
                right: 75%;
            }

            .col-lg-pull-8 {
                right: 66.66666667%;
            }

            .col-lg-pull-7 {
                right: 58.33333333%;
            }

            .col-lg-pull-6 {
                right: 50%;
            }

            .col-lg-pull-5 {
                right: 41.66666667%;
            }

            .col-lg-pull-4 {
                right: 33.33333333%;
            }

            .col-lg-pull-3 {
                right: 25%;
            }

            .col-lg-pull-2 {
                right: 16.66666667%;
            }

            .col-lg-pull-1 {
                right: 8.33333333%;
            }

            .col-lg-pull-0 {
                right: 0;
            }

            .col-lg-push-12 {
                left: 100%;
            }

            .col-lg-push-11 {
                left: 91.66666667%;
            }

            .col-lg-push-10 {
                left: 83.33333333%;
            }

            .col-lg-push-9 {
                left: 75%;
            }

            .col-lg-push-8 {
                left: 66.66666667%;
            }

            .col-lg-push-7 {
                left: 58.33333333%;
            }

            .col-lg-push-6 {
                left: 50%;
            }

            .col-lg-push-5 {
                left: 41.66666667%;
            }

            .col-lg-push-4 {
                left: 33.33333333%;
            }

            .col-lg-push-3 {
                left: 25%;
            }

            .col-lg-push-2 {
                left: 16.66666667%;
            }

            .col-lg-push-1 {
                left: 8.33333333%;
            }

            .col-lg-push-0 {
                left: 0;
            }

            .col-lg-offset-12 {
                margin-left: 100%;
            }

            .col-lg-offset-11 {
                margin-left: 91.66666667%;
            }

            .col-lg-offset-10 {
                margin-left: 83.33333333%;
            }

            .col-lg-offset-9 {
                margin-left: 75%;
            }

            .col-lg-offset-8 {
                margin-left: 66.66666667%;
            }

            .col-lg-offset-7 {
                margin-left: 58.33333333%;
            }

            .col-lg-offset-6 {
                margin-left: 50%;
            }

            .col-lg-offset-5 {
                margin-left: 41.66666667%;
            }

            .col-lg-offset-4 {
                margin-left: 33.33333333%;
            }

            .col-lg-offset-3 {
                margin-left: 25%;
            }

            .col-lg-offset-2 {
                margin-left: 16.66666667%;
            }

            .col-lg-offset-1 {
                margin-left: 8.33333333%;
            }

            .col-lg-offset-0 {
                margin-left: 0;
            }
        }

        .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12 {
            position: relative;
            min-height: 1px;
            padding-right: 15px;
            padding-left: 15px;
        }
        /*#democss #ContentPlaceHolder1_lblapplicantname, #ContentPlaceHolder1_lblUnitname, #ContentPlaceHolder1_lblMandal,
      #ContentPlaceHolder1_lblMobileNumber,#ContentPlaceHolder1_lblsubmodule,#ContentPlaceHolder1_lblreuestid,#ContentPlaceHolder1_lblMainModule
      {
           border: 0px !important;
       }*/
        #ContentPlaceHolder1_lblForwardedRemarks, #ContentPlaceHolder1_lblusercomments,#ContentPlaceHolder1_DivSolustionDevTeamComments {
            padding: 5px;
        }
    </style>
    <div id="content">
        <div id="content-header" class="d-none">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom" runat="server" id="ehome"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Change Password</a>
            </div>
            <%--  <h1>Fill Industry Details</h1>--%>
        </div>
        <div class="breadcrumb-bg">
            <ul class="breadcrumb font-medium title5 container">
                <li class="breadcrumb-item"><i class="fa fa-home title4" aria-hidden="true"></i>Home</li>
                <li class="breadcrumb-item">Change Password</li>
            </ul>
        </div>
        <div class="container mt-4 pb-4" id="Receipt" runat="server">
            <div class="row">
                <div class="col-sm-12 offset-md-1 col-md-10 col-lg-8 offset-lg-2 px-4 pt-4 mt-3 frm-form box-content">
                    <h5 class="text-blue  mb-4 font-SemiBold">Change Password</h5>
                    <div class="widget-content nopadding">
                        <div class="row mb-3">
                            <div class="col-sm-6">
                                <asp:Label ID="Label349" runat="server" CssClass="LBLBLACK" Width="165px">User ID</asp:Label>
                            </div>
                            <div class="font-SemiBold col-sm-6">
                                <asp:Label ID="lbluserid" runat="server" CssClass="LBLBLACK"></asp:Label>
                            </div>
                        </div>
                       <div class="row mb-3"  style="display:none">
                            <div class="col-sm-6">
                                <asp:Label ID="Label1" runat="server" CssClass="LBLBLACK" Width="165px">User Name</asp:Label>
                            </div>
                            <div class="font-SemiBold col-sm-6">
                                <asp:TextBox ID="txtuserName" Visible="false" runat="server" class="form-control" MaxLength="50" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" id="hidetable" runat="server">

                            <div class="col-sm-6 form-group mb-0">
                                <asp:Label ID="Label298" runat="server" CssClass="LBLBLACK">New Password</asp:Label>
                                <asp:TextBox ID="TxtNpwd" runat="server" class="form-control txtbox"
                                    MaxLength="100" oncopy="return false" oncut="return false"
                                    onpaste="return false" TabIndex="1" ValidationGroup="group"
                                    TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                    ControlToValidate="TxtNpwd" ErrorMessage="Please Enter New Password"
                                    ValidationGroup="group" CssClass="text-danger">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Display="Dynamic" ErrorMessage="<br/>Password must be at least 4 characters, no more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric digit." ForeColor="Red"
                                  ValidationGroup="group"   ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$" ControlToValidate="TxtNpwd" runat="server"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-sm-6 form-group mb-0">
                                <asp:Label ID="Label303" runat="server" CssClass="LBLBLACK">Confirm New Password</asp:Label>
                                <asp:TextBox ID="txtPwd" runat="server" class="form-control txtbox"
                                    MaxLength="50" oncopy="return false" oncut="return false"
                                    onkeypress="Names()" onpaste="return false" TabIndex="1"
                                    ValidationGroup="group" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtPwd" ErrorMessage="Please Enter Confirm Password"
                                    ValidationGroup="group" CssClass="text-danger">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="group"
                                    ControlToValidate="txtPwd" ControlToCompare="TxtNpwd"   Display="Dynamic" ForeColor="Red"
                                    ErrorMessage="New Password and Confirm Password should be same"></asp:CompareValidator>
                            </div>
                            <div class="col-sm-6 form-group pt-sm-3 mt-sm-1">
                                <asp:UpdatePanel ID="UP1" runat="server">
                                    <ContentTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Image ID="imgCaptcha"  runat="server" />
                                                </td>
                                                <td style="width: 5px"></td>
                                                <td style="padding: 5px; margin: 5px" valign="middle">
                                                    <asp:ImageButton ID="btnRefresh" ImageUrl="~/images/refresh.png" Height="30px" Width="30px" runat="server" AlternateText="Refresh" OnClick="btnRefresh_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-sm-6 form-group">
                                <label>Enter Captcha Code </label>
                                <asp:TextBox ID="txtCaptcha" class="form-control" TabIndex="1" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <table cellpadding="10" cellspacing="5" class="w-100">
                            <tr id="hidetablepassword" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px; font-weight: bold; font-size: larger" colspan="3" align="center" class="blink">&nbsp;
                                           <%-- Your Default Password : TSIPASS123--%>
                                </td>
                            </tr>
                            <tr id="trsubmittion" runat="server">
                                <td align="center" colspan="3"
                                    style="padding: 5px; margin: 5px; text-align: center;">
                                    <asp:Button ID="BtnSave1" runat="server" CssClass="btn btn-blue m-2"
                                        OnClick="BtnSave_Click" TabIndex="10" Text="Submit"
                                        ValidationGroup="group" />
                                    <asp:Button ID="BtnClear" runat="server" CausesValidation="False"
                                        CssClass="btn btn-warning m-2" OnClick="BtnClear_Click" TabIndex="10"
                                        Text="Clear All" ToolTip="To Clear  the Screen" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <div id="success" runat="server" visible="false" class="alert alert-success mb-0">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                    </div>
                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger mb-0">
                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                        <strong>Warning!</strong> Invalid UserID/Password.
                                    </div>
                                </td>
                            </tr>
                            <tr id="trchangepewmessage" runat="server" visible="false">
                                <td style="padding: 5px; margin: 5px" colspan="3" align="center">
                                    <span style="font-weight: bold; font-size: 15pt">Please Click Here 
                                                <asp:HyperLink ID="HyperLink1" NavigateUrl="~/loginReg.aspx" runat="server">Click </asp:HyperLink>
                                        &nbsp;to Login Again </span>
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hdfID" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                            ShowMessageBox="True" ShowSummary="False" ValidationGroup="group" />
                        <asp:HiddenField ID="hdfFlagID" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
