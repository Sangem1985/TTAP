<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Launchingpage.aspx.cs" Inherits="TTAP.Launchingpage" %>

<!DOCTYPE html>

<html>
    <head>
        <title>Department of Handlooms & Textiles | Government of Telangana</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta charset="utf-8" />
        <meta name="keywords" content="Intense Responsive web template, Bootstrap Web Templates, Flat Web Templates, Android Compatible web template,
	SmartPhone Compatible web template, free WebDesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola web design" />
        <script>
            addEventListener("load", function () {
                setTimeout(hideURLbar, 0);
            }, false);

            function hideURLbar() {
                window.scrollTo(0, 1);
            }
        </script>
        <!-- Custom Theme files -->
        <link href="css/bootstrap.css" type="text/css" rel="stylesheet" media="all">

        <link href="css/style.css" type="text/css" rel="stylesheet" media="all">
        <!-- font-awesome icons -->
        <link href="css/font-awesome.min.css" rel="stylesheet">
        <!-- //Custom Theme files -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
        <!-- online-fonts -->
        <link rel="icon" href="images/favicon.png" type="image/gif" sizes="16x16">
        <style>
            * {
                box-sizing: border-box
            }

            .mySlides {
                display: none
            }

            img {
                vertical-align: middle;
            }

            /* Slideshow container */
            .slideshow-container {
                max-width: 1000px;
                position: relative;
                margin: auto;
            }

            /* Next & previous buttons */
            .prev, .next {
                cursor: pointer;
                position: absolute;
                top: 50%;
                width: auto;
                padding: 16px;
                margin-top: -22px;
                color: white;
                font-weight: bold;
                font-size: 18px;
                transition: 0.6s ease;
                border-radius: 0 3px 3px 0;
                user-select: none;
            }

            /* Position the "next button" to the right */
            .next {
                right: 0;
                border-radius: 3px 0 0 3px;
            }

                /* On hover, add a black background color with a little bit see-through */
                .prev:hover, .next:hover {
                    background-color: rgba(0,0,0,0.8);
                }

            /* Caption text */
            .text {
                color: #f2f2f2;
                font-size: 15px;
                padding: 8px 12px;
                position: absolute;
                bottom: 8px;
                width: 100%;
                text-align: center;
            }

            /* Number text (1/3 etc) */
            .numbertext {
                color: #f2f2f2;
                font-size: 12px;
                padding: 8px 12px;
                position: absolute;
                top: 0;
            }

            /* The dots/bullets/indicators */
            .dot {
                cursor: pointer;
                height: 15px;
                width: 15px;
                margin: 0 2px;
                background-color: #bbb;
                border-radius: 50%;
                display: inline-block;
                transition: background-color 0.6s ease;
            }

                .active, .dot:hover {
                    background-color: #717171;
                }

            /* Fading animation */
            .fade {
                -webkit-animation-name: fade;
                -webkit-animation-duration: 1.5s;
                animation-name: fade;
                animation-duration: 1.5s;
            }

            @-webkit-keyframes fade {
                from {
                    opacity: .4
                }

                to {
                    opacity: 1
                }
            }

            @keyframes fade {
                from {
                    opacity: .4
                }

                to {
                    opacity: 1
                }
            }

            /* On smaller screens, decrease text size */
            @media only screen and (max-width: 300px) {
                .prev, .next, .text {
                    font-size: 11px
                }
            }


            .pricingTable {
                color: #fff;
                font-family: 'Kodchasan', sans-serif;
                padding: 15px;
                border: 1px solid rgba(0,0,0,0.05);
                transition: all 0.3s;
            }

                .pricingTable:hover {
                    box-shadow: 0 0 5px #000 inset;
                    border-radius: 10px;
                }

                .pricingTable .pricingTable-header {
                    background-color: #e42574;
                    text-align: center;
                    padding: 0 0 15px;
                    margin-bottom: 10px;
                    border-radius: 10px;
                }

                .pricingTable .title {
                    font-size: 25px;
                    font-weight: 700;
                    letter-spacing: 1px;
                    text-transform: capitalize;
                    padding: 10px 0;
                    margin: 0;
                    border-bottom: 2px solid rgba(0,0,0,0.2);
                }

                .pricingTable .price-value {
                    padding: 30px 0 40px;
                    margin: 0 0 15px;
                    border-bottom: 2px solid rgba(0,0,0,0.2);
                }

                .pricingTable .amount {
                    font-size: 50px;
                    font-weight: 700;
                    line-height: 70px;
                    display: block;
                }

                .pricingTable .month {
                    font-size: 18px;
                    font-weight: 600;
                    line-height: 10px;
                    text-transform: capitalize;
                }

                .pricingTable .pricingTable-signup {
                    color: #fff;
                    background-color: #2C2829;
                    font-size: 18px;
                    font-weight: 600;
                    text-transform: uppercase;
                    width: 80%;
                    padding: 12px 20px 12px 60px;
                    margin: 0 auto;
                    border-radius: 5px;
                    display: block;
                    position: relative;
                    transition: all 0.3s;
                }

                    .pricingTable .pricingTable-signup:hover {
                        color: #e42574;
                        background-color: #fff;
                        box-shadow: 0 0 5px #000 inset;
                    }

                    .pricingTable .pricingTable-signup:after {
                        content: "\f07a";
                        color: #fff;
                        background-color: rgba(0,0,0,0.2);
                        font-family: "Font Awesome 5 Free";
                        font-weight: 900;
                        font-size: 25px;
                        height: 50px;
                        width: 50px;
                        padding: 7px;
                        position: absolute;
                        top: 0;
                        left: 0;
                        transition: all 0.3s;
                    }

                .pricingTable .pricing-content {
                    background-color: #E5E5E5;
                    padding: 15px;
                    border-radius: 15px;
                }

                    .pricingTable .pricing-content h4 {
                        color: #303030;
                        font-size: 18px;
                        font-weight: 600;
                        text-transform: uppercase;
                        padding: 10px;
                        margin: 0;
                        border-bottom: 2px solid rgba(0,0,0,0.1);
                    }

                    .pricingTable .pricing-content ul {
                        padding: 0;
                        margin: 0;
                        list-style: none;
                    }

                    .pricingTable .pricing-content li {
                        color: #404040;
                        font-size: 16px;
                        line-height: 45px;
                        border-bottom: 2px solid rgba(0,0,0,0.1);
                    }

                        .pricingTable .pricing-content li:last-child {
                            border: none;
                        }

                        .pricingTable .pricing-content li i {
                            color: #80A811;
                            font-size: 14px;
                            margin: 0 10px 0 0;
                        }

                            .pricingTable .pricing-content li i.fa-times {
                                color: #e74c3c;
                            }

                .pricingTable.purple .pricingTable-header {
                    background: #bb37fd;
                }

                .pricingTable.purple .pricingTable-signup:hover {
                    color: #bb37fd;
                }

                .pricingTable.red .pricingTable-header {
                    background: #ff4f4f;
                }

                .pricingTable.red .pricingTable-signup:hover {
                    color: #ff4f4f;
                }

            @media only screen and (max-width: 990px) {
                .pricingTable {
                    margin: 0 0 30px;
                }
            }
            #error_ {
    display: none;
}
            .carousel-control.right {
    background-image: none !important;
}
            div#aside nav {
    display: block;
    width: 100%;
    margin-bottom: 20px;
}
            div#aside nav ul {
    margin: 0;
    padding: 0;
    list-style: none;
}
            div#aside nav li {
    margin: 0 0 3px 0;
    padding: 0;
}
            div#aside nav a {
    display: block;
    margin: 0;
    padding: 5px 10px 5px 20px;
    color: #1c546c;
    background-color: inherit;
    background: url(images/orange_file.gif) no-repeat 10px center;
    text-decoration: none;
    border-bottom: 1px dotted #666666;
}
            .vertical-menu {
  *width: 200px;
}

.vertical-menu a {
  background-color: #ffffff;
  color: black;
  display: block;
  padding: 10px;
  text-decoration: none;
  border-bottom: 1px dotted #666666;
}

.vertical-menu a:hover {
  background-color: #ccc;
}

.vertical-menu a.active {
  background-color: #ffffff;
  color: #000000;
}
button {
    padding: 0;
    margin: 165px 55px;
    color: #fff;
    font-weight: 900;
    font-size: 32px;
    background-color: #1c87c9;
        -webkit-border-radius: 60px;
        border-radius:4px;
        border: none;
        color: #eeeeee;
        cursor: pointer;
        display: inline-block;
        font-family: sans-serif;
        font-size: 20px;
        padding: 20px 36px;
        text-align: center;
        text-decoration: none;
       
        animation: blinker 1s linear infinite;
}
@keyframes glowing {
        0% {
          background-color: #2ba805;
          box-shadow: 0 0 5px #2ba805;
          
        }
        50% {
          background-color: #9c27b0;
          box-shadow: 0 0 20px #49e819;
         
        }
        100% {
          background-color: #2ba805;
          box-shadow: 0 0 5px #2ba805;
         
        }
      }
      .button {
        animation: glowing 1300ms infinite;
      }
      div#imaglaun img {
    padding: 10px 10px;
    margin: 9px 3px;
}
        </style>
    </head>

<body>

   
    
    <header id="home">
        <div class="container">
            <div class="header d-lg-flex justify-content-between align-items-center py-sm-0 py-0 px-sm-0 px-0">
               <a href="#"><img src="images/logo.png" style="hight: 150px; width: 150px;" /></a> 
                <div id="logo" style="margin-right: 250px;">
                    <h1><a href="#" style="font-size: 42px;font-weight: 500;">Department of Handlooms &amp; Textiles</a></h1>
                    <h4 style="text-align: left;color: #fff !important;margin-top: 80px !important;font-weight: 300;font-size: 32px;">Government of Telangana</h4>
                </div>
              
             
            </div>

        </div>
    </header>
   
  
    <br />
    <form id="form1" runat="server">
        <section id="bodypart" class="launching">
            <div class="container">
                <div class="row">
                    <div class="col-md-4">
                        <div id="logo">
                            
                    <img src="images/kcr.jpg" style="margin-left: 50px;">
                    <p style="text-align: center; color: #000 !important;"><b>Sri. K.Chandrashekar Rao</b><br />
                        Hon'ble Chief Minister</p>
                </div>
                    </div>
                    <div class="col-md-4" style="background-color: white;text-align: center;display: grid;">
                       <a href="home.aspx"> <button type="button" class="button"> <img src="images/launicon.png" /> <span style="text-decoration: underline;">Launch</span></button></a>
                    </div>
                    <div class="col-md-4">
                        <div id="logo">
                            
                    <img src="images/ktr.jpeg" style="margin-left: 50px;">
                    <p style="text-align: center; color: #000 !important;"><b>Sri. K.Taraka Rama Rao</b><br />
                        Hon'ble Minister for Handlooms & Textiles</p>
                </div>
                    </div>
                </div>
            </div>
        </section>
        <section id="scrollgarllery" class="gallery">
            <div class="container">
                <div class="row" id="imaglaun" style="display:contents">
                    
                         <img src="images/launh1.jpg">
                         <img src="images/launh2.jpg">
                         <img src="images/launh3.jpg">
                         <img src="images/launh4.jpg" />
                         <img src="images/launh5.jpg" />
                        <img src="images/launh6.jpg" />
                    
                </div>
            </div>
        </section>
    </form>
  
    <div class="cpy-right text-center">
        <div class="col-lg-12">
            <div class="col-lg-12" style="text-align:center"><p style="text-align:center !important;">
                Designed, Developed and Hosted by CMS, Hyderabad. Content owned, Maintained and Updated by Department of Handlooms & Textiles, Government of Telangana.
            
        </p></div>
            <%--<div class="col-lg-2"><p align="right" style="color:#fff;font-weight:600;">Visitors Count : 0000</p></div>--%>
        </div>
        
        <%--<a href='https://embedmap.org/'>embed google maps in wordpress</a> --%>
    </div>
    <!-- //copyright -->
    <!-- move top icon -->
    <a href="#home" class="move-top text-center">
        <span class="fa fa-level-up" aria-hidden="true"></span>
    </a>
    <!-- //move top icon -->
    <script type="text/javascript">
        var dt = new Date();
        document.getElementById("datetime").innerHTML = dt.toLocaleString();
    </script>
    
</body>
    <script>
      var $affectedElements = $("p,marquee,li"); // Can be extended, ex. $("div, p, span.someClass")


 $affectedElements.each( function(){
  var $this = $(this);
  $this.data("orig-size", $this.css("font-size") );
});

$("#btn-increase").click(function(){
  changeFontSize(1);
})

$("#btn-decrease").click(function(){
  changeFontSize(-1);
})

$("#btn-orig").click(function(){
  $affectedElements.each( function(){
        var $this = $(this);
        $this.css( "font-size" , $this.data("orig-size") );
   });
})

function changeFontSize(direction){
    $affectedElements.each( function(){
        var $this = $(this);
        $this.css( "font-size" , parseInt($this.css("font-size"))+direction );
    });
}
    </script>
</html>
