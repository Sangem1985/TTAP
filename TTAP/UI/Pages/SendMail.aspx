<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="TTAP.UI.Pages.SendMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard</title>

    <%-- <link href="../../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../../assets/css/custom.css" rel="stylesheet" />
    <link href="../../assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />--%>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.7.1.min.js"></script>

    <style>
        .blink {
            animation: blinker 0.6s linear infinite;
            color: #d71111;
            /*font-size: 30px;
        font-family: sans-serif;*/
            font-weight: bold;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }

        #scroll-container {
            /*border: 3px solid black;
            border-radius: 5px;*/
            overflow: hidden;
            width: 100%;
            color: orangered !important;
            font-family: 'Montserrat-SemiBold';
        }

        #scroll-text {
            /* animation properties */
            -moz-transform: translateX(100%);
            -webkit-transform: translateX(100%);
            transform: translateX(100%);
            -moz-animation: my-animation 15s linear infinite;
            -webkit-animation: my-animation 15s linear infinite;
            animation: my-animation 15s linear infinite;
        }

        /* for Firefox */
        @-moz-keyframes my-animation {
            from {
                -moz-transform: translateX(100%);
            }

            to {
                -moz-transform: translateX(-100%);
            }
        }

        /* for Chrome */
        @-webkit-keyframes my-animation {
            from {
                -webkit-transform: translateX(100%);
            }

            to {
                -webkit-transform: translateX(-100%);
            }
        }

        @keyframes my-animation {
            from {
                -moz-transform: translateX(100%);
                -webkit-transform: translateX(100%);
                transform: translateX(100%);
            }

            to {
                -moz-transform: translateX(-100%);
                -webkit-transform: translateX(-100%);
                transform: translateX(-100%);
            }
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
    <script type="text/javascript">
        $(document).ready(function () {
            var f = document.getElementById('Alert');
            setInterval(function () {
                f.style.display = (f.style.display == 'none' ? '' : 'none');
            }, 1000);

        });

    </script>
    <div id="content">
        <div id="content-header" class="d-none">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom" runat="server" id="ehome"><i class="icon-home"></i>Home</a>
                <%-- <a href="#" class="current">Dashboard1</a>--%>
            </div>
            <%--  <h1>Fill Industry Details</h1>--%>
        </div>
        <div class="breadcrumb-bg">
            <ul class="breadcrumb font-medium title5 container">
                <li class="breadcrumb-item"><i class="fa fa-home title4" aria-hidden="true"></i>Home</li>
                <%--  <li class="breadcrumb-item">Dashboard</li>--%>
            </ul>
        </div>
        <div class="container mt-4 pb-4" id="Receipt" runat="server">
            <div class="w-100 px-4 frm-form box-content py-4 font-medium title5 mt-sm-5">
                <%-- <h5 class="text-blue mt-1 mb-3 font-SemiBold h2 text-center"><i class="fa fa-tachometer" aria-hidden="true"></i></h5>--%>
                <div class="widget-content nopadding">
                    <div class="row">
                        <div class="col-sm-12 text-center mt-3" runat="server" id="divbuttons">
                            
                            <asp:Button ID="btnRemainderMail" runat="server" CssClass="btn btn-success m-2" TabIndex="10" Text="Send" OnClick="btnRemainderMail_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
