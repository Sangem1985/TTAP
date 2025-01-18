<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmIntimationLetter.aspx.cs" Inherits="TTAP.UI.Pages.RecommendationLetters.frmIntimationLetter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%-- <link href="../../css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
    <title>Intimation Letter</title>
    <style type="text/css">
        .leftalign {
            text-align: left;
        }

        .rightalign {
            text-align: right;
        }

        .floatleft {
            float: left;
        }

        body {
            background-color: #ffffff;
        }
    </style>
    <style type="text/css">
        .auto-style3 {
            text-align: justify;
        }

        .auto-style4 {
            text-align: left;
        }

        /*.auto-style5 {
            text-align: center;
        }*/

        .auto-style6 {
            text-decoration: underline;
        }

        .table-bordered > tbody > tr > td, .table-bordered > tbody > tr > th, .table-bordered > tfoot > tr > td, .table-bordered > tfoot > tr > th, .table-bordered > thead > tr > td, .table-bordered > thead > tr > th {
            border: 1px solid #000000 !important;
        }
    </style>
    <script type="text/javascript">

        function myFunction() {
            //document.getElementById("Div2").style.visibility = "hidden";
            document.getElementById("Div2").style.display = "none";
            //$("#Button2").hide();
            window.print();
            // $("#Button2").show();
            document.getElementById("Div2").style.display = "block";
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="Receipt" runat="server" style="border: 3px solid #000000; text-align: center;margin-top: 25px;">
            <div style="padding-top: 6px">
            </div>
            <img src="../../../images/logo.png" style="width: 75px; height: 75px;" />
            <asp:Label Font-Bold="true" Font-Size="12pt" runat="server">
            <h3 style="color: #0000FF;">GOVERNMENT OF TELANGANA <br /> HANDLOOMS AND TEXTILES DEPARTMENT</h3></asp:Label>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                <div class="row">
                    <%--<div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <span style="float: left;"><span style="float: left;"><b>From</b></span><br />
                            The Assistant Director (H&T)/,<br />
                            District Level Officer,<br />
                            <asp:Label ID="lblletterFrom" runat="server"></asp:Label>.</span>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"></div>--%>
                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                        <span style="float: right;"><span style="float: left;"><b>To</b></span>
                            <br />
                            M/s. 
                            <asp:Label ID="lblUnitName" runat="server"></asp:Label>,<br />
                            UID No :
                            <asp:Label ID="lblUidNO" runat="server"></asp:Label>.<%--,<br />--%>
                           <%-- CAF No :
                            <asp:Label ID="lblapplicationnumber" runat="server"></asp:Label>--%>
                        </span>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; font-weight: bold">
                <span class="auto-style6">Lr.Rc.No : </span>
                <asp:Label ID="lblLetterNo" runat="server" CssClass="auto-style6"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="auto-style6">Dated: </span>
                <asp:Label ID="lblLetterDate" runat="server" CssClass="auto-style6"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-15">
                <span class="floatleft" style="font-weight: bold">Madam/Sir,</span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px">
                <span class="floatleft auto-style3"><span style="font-weight: bold">Sub :-  </span>
                    H&T Dept. – T-TAP Policy 2017-2022 – Sanction of 
                    <asp:Label ID="lblIncentiveName" Font-Bold="true" runat="server"></asp:Label>
                    in respect of M/s. 
                    <asp:Label ID="lblEnterpreneurDetails" Font-Bold="true" runat="server"></asp:Label>
                    – Intimation  – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 11px">
                <span class="floatleft auto-style3">Ref :- <br /> 1. G.O Ms No. 59, Ind. & Com (Tex) Dept.,  Dt: 18.08.2017.
                    <br />
                    2. G.O.Ms.No.14, Ind. & Com. (Tex) Dept., dt: 15.11.2019.
                    <br />
                    3. Proceedings Rc.No.2072/2014-Parks, dated: 6.12.2019 of the Director H&T & AEPs, TS, Hyderabad.
                    <br />
                    4. T-TAP Online Incentive Claims Application No. 
                                  &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;, dt: &nbsp;
                               <span style="font-weight: bold">
                                   <asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span>
                    of M/s.
                    <asp:Label ID="lblEnterpreneurDetails1" Font-Bold="true" runat="server"></asp:Label>.
                    <br />
                    5. Minutes of the
                    <asp:Label ID="lblMeetingNumber" Font-Bold="true" runat="server"></asp:Label>
                    meeting held on 
                    <asp:Label ID="lblMeetingdate" Font-Bold="true" runat="server"></asp:Label>.
                    <%--<br />
                    5. Inspection Report dated:<span style="font-weight: bold"><asp:Label ID="lblInspectionReportdated" runat="server"></asp:Label></span> .--%>
                </span>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 2px">
                <b>******* </b>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <span class="floatleft auto-style3">I invite kind attention to the captioned subject and references cited.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <span class="floatleft auto-style3">In the reference 4th cited,&nbsp;
                    <%--M/s. &nbsp;<asp:Label ID="lblEnterpreneurDetails2" Font-Bold="true" runat="server"></asp:Label>&nbsp;has submitted --%>
                    we are pleased to inform you that you have been sanctioned the
                    <asp:Label ID="lblIncentiveName1" Font-Bold="true" runat="server"></asp:Label>
                    for an amount of Rs.<asp:Label ID="lblAMount" Font-Bold="true" runat="server"></asp:Label>
                    (<asp:Label ID="lblAmountinrupees" Font-Bold="true" runat="server"></asp:Label>)

                </span>
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 11px">
                <span class="floatleft auto-style3">This amount will be released as and when your unit’s turn comes as per seriatim for disbursement of available funds
                </span>
            </div>
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 11px">
                 <span class=" pull-left">Enclosures : As above.  
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; padding-bottom: 5px; text-align: left">
                <span class=" pull-right"><span style="font-weight: bold">Yours faithfully,</span><br />
                    <asp:Label ID="lblGMname" runat="server"></asp:Label><br />
                    <%--Asst. Director (H&T)<br />
                    <asp:Label ID="lbldist3" runat="server"></asp:Label>--%>
                </span>
                <span class=" pull-left">This is computer generated document.
                </span>
            </div>
            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; padding-bottom: 5px; text-align: left">
                <span class=" pull-left"><span style="font-weight: bold">Copy to the RDD (H&T) </span>&nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblRDDname" runat="server"></asp:Label><br />
                    <br />
                </span>
            </div>--%>
        </div>
        <div class="container" id="Div2" runat="server" style="text-align: center; vertical-align: bottom">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
                
            </div>
           
        </div>
    </form>
</body>
</html>
