<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="UserDashBoard.aspx.cs" Inherits="TTAP.UI.UserDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard</title>

    <%-- <link href="../../assets/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="../../assets/css/custom.css" rel="stylesheet" />
    <link href="../../assets/plugins/morris/morris-0.4.3.min.css" rel="stylesheet" />--%>
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.7.1.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">

    <style>
        .row {
            margin-left: -5px;
            margin-right: -5px;
        }

        .column {
            float: left;
            width: 50%;
            padding: 22px;
            border: solid #356fc5;
            border-radius: 20px;
            border-style: double;
        }

        .row::after {
            content: "";
            clear: both;
            display: table;
        }

        table {
            border-collapse: collapse;
            border-spacing: 0;
            width: 100%;
            border: 1px solid #ddd;
        }

        th, td {
            text-align: left;
            padding: 16px;
        }

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .FontHead {
            color: blue;
            font-family: 'Montserrat-SemiBold';
        }

        .blink {
            animation: blinker 1.2s linear infinite;
            color: #1120d7;
            /*font-size: 30px;
        font-family: sans-serif;*/
            font-weight: bold;
        }

        .blinka {
            animation: blinker 1.5s linear infinite;
            color: #1120d7;
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
            if ($('#ContentPlaceHolder1_hdnEligibility').val() == "N") {
                $('#navbarDropdownMenuLink2').hide();
                $('#applyincentive').hide();
            }
        });

    </script>
    <div id="content">
        <%-- <div id="content-header" class="d-none">
            <div id="breadcrumb">
                <a href="#" title="Go to Home" class="tip-bottom" runat="server" id="ehome"><i class="icon-home"></i>Home</a>
              
            </div>
         
        </div>--%>
        <div class="breadcrumb-bg">
            <ul class="breadcrumb font-medium title5 container">
                <li class="breadcrumb-item"><i class="fa fa-home title4" aria-hidden="true"></i>Home</li>
                <%--  <li class="breadcrumb-item">Dashboard</li>--%>
            </ul>
        </div>
        <%--  <div class="container mt-4 pb-4" id="Receipt" runat="server">--%>
        <%--     <div class="w-100 px-4 frm-form box-content py-4 font-medium title5 mt-sm-5">--%>
        <%-- <h5 class="text-blue mt-1 mb-3 font-SemiBold h2 text-center"><i class="fa fa-tachometer" aria-hidden="true"></i></h5>--%>
        <div class="widget-content nopadding">
            <div class="row" style="margin: -13px 16px 0px 17px;">
                <div id="scroll-container">
                    <div id="scroll-text">
                        <h5 runat="server" id="scrolltext">Responses to the queries raised to be replied in 20 days from the date of query raised to avoid Rejection.</h5>
                    </div>
                </div>

                <div class="row">
                    <div class="column">
                        <h3 align="center">WELCOME</h3>
                        <p style="font-family: 'Montserrat-SemiBold';">
                            The Department of Handlooms and Textiles is concerned with Handlooms, 
                                Powerlooms in the Co-operative and decentralized sector and setting up of Apparel 
                                and Textile Parks in the Garment sector.
                        </p>
                        <p></p>
                        <p style="font-family: 'Montserrat-SemiBold';">
                            Several Centrally Sponsored Schemes as well as State Schemes are being implemented for the socio-economic development 
                                of Handloom Weavers in Telangana including schemes with matching share of Central and State Governments.
                        </p>

                    </div>
                    <div class="column">
                        <div id="divAdmin" runat="server">
                            <div>
                                <p class="blinka">
                                    <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>The operative period of T-TAP policy is extended beyond 17-08-2022.
                                </p>
                            </div>
                            <div>
                                <p style="color: red;">
                                    <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>Unit Holders cannot go forward to their application if they do not upload newly added Plant and Machinary Payment Proofs
                                </p>
                            </div>
                            <div>
                                <h5 style="text-decoration-line: underline; color: red;">Timelines for submisssion of Incentive Claims</h5>
                                <p>
                                    <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>The applicants applying for T-TAP incentives shall invariably follow the conditions stipulated at para no:12 of T-TAP operational Guidelines
                                </p>
                            </div>
                            <div>
                                <h5 class="blinka" style="text-decoration-line: underline; color: red;">Addendum</h5>
                                <p>
                                    <i class="fa fa-hand-o-right" style="font-size: 20px; color: #1b00ff"></i>Clause 8(c) of the T-TAP Operational Guidelines is deleted as per Government Memo No. 42/TEX.1/2016-13, dated 04-01-2023
                                </p>
                            </div>
                            <div id="divpendingappspmnt" visible="true" runat="server">
                                <%--<h5 style="color: red;">Applications</h5>--%>
                                <p class="blink" id="pendingapps" runat="server">
                                </p>
                            </div>
                            <div id="divReminders" visible="false" runat="server">
                                <p class="blink" style="color: forestgreen;" id="NewReminders" runat="server">
                                </p>
                            </div>
                        </div>
                        <div id="divHO" runat="server" visible="false">
                            <div id="div1" visible="true" runat="server">
                                <a href="Pages/CommissionerDashboard.aspx">
                                    <p class="blink" style="color:red;" id="PDLOPending" runat="server">
                                    </p>
                                </a>
                            </div>
                            <div id="div2" visible="true" runat="server">
                                <a href="Pages/CommissionerDashboard.aspx">
                                    <p class="blink" style="color:red;" id="PInspectionPending" runat="server">
                                    </p>
                                </a>
                            </div>
                            <div id="div3" visible="false" runat="server">
                                <p class="blink" id="PRevisedInspectionPending" runat="server">
                                </p>
                            </div>
                            <div id="div4" visible="false" runat="server">
                                <p class="blink" id="PPendingforReferencetoDLCHO" runat="server">
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 text-center">
                    <span style="color: orangered !important; font-size: 20px; display: none;">The operative period of T-TAP policy is extended beyond 17-08-2022 </span>
                </div>
            </div>
        </div>
        <%-- </div>--%>
        <%--        </div>--%>
    </div>
    <asp:HiddenField runat="server" ID="hdnEligibility" />
</asp:Content>
