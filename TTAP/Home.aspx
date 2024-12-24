<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TTAP.Home" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .blink {
            animation: blink-animation 1s steps(5, start) infinite;
            -webkit-animation: blink-animation 1s steps(5, start) infinite;
        }

        @keyframes blink-animation {
            to {
                visibility: hidden;
            }
        }

        @-webkit-keyframes blink-animation {
            to {
                visibility: hidden;
            }
        }
    </style>
    <div>
        <section class="single_grid_w3_main">
            <div class="container1">
                <div class="row">
                    <div class="col-lg-5" style="margin-bottom: 10px; margin-top: 10px;">
                        <!-- <div class="slide-img">

                    </div> -->

                        <div id="myCarousel" class="carousel slide" data-ride="carousel">
                            <!-- Indicators -->
                            <%--<ol class="carousel-indicators">
                                <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
                                <li data-target="#myCarousel" data-slide-to="1"></li>
                                <li data-target="#myCarousel" data-slide-to="2"></li>
                            </ol>--%>

                            <!-- Wrapper for slides -->
                            <div class="carousel-inner">
                                <div class="item active">
                                    <img src="images/slider1.png" alt="Los Angeles" style="width: 100%;">
                                </div>

                                <div class="item">
                                    <img src="images/slider2.jpg" alt="Chicago" style="width: 100%;">
                                </div>

                                <div class="item">
                                    <img src="images/slider3.jpg" alt="New york" style="width: 100%;">
                                </div>
                                <div class="item">
                                    <img src="images/slider4.jpg" alt="New york" style="width: 100%;">
                                </div>
                                <div class="item">
                                    <img src="images/slider5.jpg" alt="New york" style="width: 100%;">
                                </div>
                                <div class="item">
                                    <img src="images/slider6.jpg" alt="New york" style="width: 100%;">
                                </div>
                                <div class="item">
                                    <img src="images/slider7.jpg" alt="New york" style="width: 100%;">
                                </div>
                                <div class="item">
                                    <img src="images/slider8.jpg" alt="New york" style="width: 100%;">
                                </div>
                            </div>

                            <!-- Left and right controls -->
                            <a class="left carousel-control" href="#myCarousel" data-slide="prev">
                                <span class="glyphicon glyphicon-chevron-left"></span>
                                <span class="sr-only">Previous</span>
                            </a>
                            <a class="right carousel-control" href="#myCarousel" data-slide="next">
                                <span class="glyphicon glyphicon-chevron-right"></span>
                                <span class="sr-only">Next</span>
                            </a>
                        </div>




                    </div>
                    <div class="col-lg-4">
                        <div class="wthree_pvt_title  mb-3">
                            <h4 class="w3pvt-title">About Handlooms & Textiles
                            </h4>

                        </div>
                        <div class="single_grid_text pt-lg-3" id="headpara">
                            <p>
                                The Department of Handlooms and Textiles is concerned with Handlooms, Powerlooms in the Co-operative and decentralized sector and setting up of Apparel and Textile Parks in the Garment sector. 
                                Telangana is one of the important States in the Handloom Industry.
                            </p>
                            <p class="my-2">
                                There are about 40,533 Handloom weavers including ancillary workers. There are about 35,762 Powerlooms working in the State there are 615 Weavers 
                                Cooperative Societies in the State consisting of Cotton-259, Silk-33, and Wool-44. Besides this, there are 157- Powerlooms and Garments/Tailors-122 other 
                                societies.
                            </p>

                            <a class="btn bg-theme mt-2 wthree-link-bnr" href="about.html">view more
                            </a>
                        </div>
                    </div>
                    <%--  <div class="col-lg-3" id="aside">
                        <h4 class="w3pvt-title">Latest</h4>
                        <div class="vertical-menu">
                            <a href="DeptDocs/TTAP EXTENSION UPTO 30.09.2021_1.jpg" target="_blank"><i class="fa fa-caret-right" aria-hidden="true"></i>Extension of Time Period for Submission of TTAP Incentive Claim Applications</a>
                        </div>
                    </div>--%>
                    <div class="col-lg-3" id="aside">
                        <h4 class="w3pvt-title">Latest</h4>
                        <div class="vertical-menu">
                            <p class="blink" style="color:#ff3333">The last date for filing applications for all types of TTAP incentives is extended to 31.12.2021</p>
                            <%-- <a href="DeptDocs/TTAP EXTENSION UPTO 30.09.2021_1.jpg" target="_blank"><i class="fa fa-caret-right" aria-hidden="true"></i>Extension of Time Period for Submission of TTAP Incentive Claim Applications</a>--%>
                        </div>

                        <h4 class="w3pvt-title">Other Links
                        </h4>
                        <%--<nav>
<ul>


<li><a href="content.php?U=9 &amp;&amp; T=Schemes">Schemes</a></li>
<li><a href="content.php?U=10 &amp;&amp; T=Events">Events</a></li>
<li><a href="content.php?U=11 &amp;&amp; T=District Information">District Information</a></li>
<li><a href="content.php?U=12 &amp;&amp; T=Related Links">Related Links</a></li>
<li><a href="content.php?U=13 &amp;&amp; T=Budget">Budget</a></li>
<li><a href="content.php?U=14 &amp;&amp; T=Textiles and Apparel Parks">Textiles and Apparel Parks</a></li>
<li><a href="http://tshandloomsurvey.umon.in/Handlooms" target="blank">Handlooms Census Data</a></li>
<li><a href="http://tshandloom.kdms.in/index" target="blank">Chenetha Mithra</a></li>
<li><a href="feedback.php">Feedback</a></li>




<li><a href="Admin/" target="_blank">Dept. Login </a></li>
</ul>

</nav>--%>

                        <div class="vertical-menu">
                            <a href="http://csb.gov.in" target="_blank"><i class="fa fa-caret-right" aria-hidden="true"></i>Central Slik Board</a>
                            <a href="http://finmin.nic.in" target="_blank"><i class="fa fa-caret-right" aria-hidden="true"></i>Ministry of Finance Government of India</a>
                            <a href="http://textilescommittee.nic.in" target="_blank"><i class="fa fa-caret-right" aria-hidden="true"></i>Ministry of Textiles Committee</a>
                            <a href="http://texmin.nic.in" target="_blank"><i class="fa fa-caret-right" aria-hidden="true"></i>Ministry of Textiles Government of India</a>
                            <a href="http://handlooms.nic.in" target="_blank"><i class="fa fa-caret-right" aria-hidden="true"></i>Office of the Development Commissioner Handlooms</a>
                        </div>

                        <%--<div class="abt-grid">
                            <div class="row">
                                <div class="col-2"></div>
                                <div class="col-1">
                                    <div class="abt-icon">
                                        <span class="fa fa-external-link"></span>
                                    </div>
                                </div>
                                <div class="col-9">
                                    <div class="abt-txt">
                                        <h4><a href="https://www.telangana.gov.in/" target="_blank">Telangana State Portal</a></h4>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="abt-grid">
                            <div class="row">

                                <div class="col-2"></div>
                                <div class="col-1">
                                    <div class="abt-icon">
                                        <span class="fa fa-external-link"></span>
                                    </div>
                                </div>
                                <div class="col-9">
                                    <div class="abt-txt">
                                        <h4><a href="https://ipass.telangana.gov.in/" target="_blank">TS-iPass</a></h4>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="abt-grid">
                            <div class="row">

                                <div class="col-2"></div>
                                <div class="col-1">
                                    <div class="abt-icon">
                                        <span class="fa fa-external-link"></span>
                                    </div>
                                </div>
                                <div class="col-9">
                                    <div class="abt-txt">
                                        <h4><a href="http://www.industries.telangana.gov.in/" target="_blank">Commissioner of Industries</a></h4>

                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="abt-grid">
                            <div class="row">

                               <div class="col-2"></div>
                                <div class="col-1">
                                    <div class="abt-icon">
                                        <span class="fa fa-external-link"></span>
                                    </div>
                                </div>
                                <div class="col-9">
                                    <div class="abt-txt">
                                        <h4><a href="Library/Textile policy.pdf">Textile Policy</a></h4>

                                    </div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>

            </div>
        </section>
        <div class="topvar1">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <!-- Codes by HTMLcodes.ws -->
                        <marquee behavior="alternate" onmouseover="this.stop();" onmouseout="this.start();" style="font-size: 18px;"><span style="color:orangered !important;">Handlooms Census Data <u><a href="http://tshandloomsurvey.umon.in/Handlooms" target="blank" style="color:orangered">Click Here</a></u></span> <span style="color: !important;">&</span> <span style="color:green !important;">Chenetha Mithra <u><a href="http://tshandloom.kdms.in/index" target="blank" style="color:green">Click Here</a></u></span></marquee>

                        <%-- <marquee style="color: #800000; font-weight: 900;" behavior="alternate"></marquee>--%>
                    </div>

                </div>
            </div>
        </div>
        <div class="bg-colors py-4">
            <div class="container py-2">
                <p class="text-bg-click text-left text-red">
                    The Government of Telangana has launched Department of Handlooms &
                 Textiles program to improve the quality of life in the rural areas. To monitor the activities and works under the Department of Handlooms &
                 Textiles Program, Government have constituted 50 Flying Squads (FSO) consisting of Senior Officers of the State Government.
                </p>
            </div>
        </div>
    </div>
</asp:Content>
