<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GMCoveringLetter.aspx.cs" Inherits="TTAP.UI.Pages.RecommendationLetters.GMCoveringLetter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <%-- <link href="../../css/bootstrap.min.css" rel="stylesheet" />--%>
    <link href="../../../css/bootstrap.min.css" rel="stylesheet" />
    <title>Covering Letter</title>
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
            document.getElementById("Div2").style.display = "none";
            window.print();
            document.getElementById("Div2").style.display = "block";
        }
        document.addEventListener("keydown", function (e) {
            if (e.ctrlKey && e.keyCode == 80) {
                myFunction();
                e.preventDefault();
            }
        });
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="Receipt" runat="server" style="border: 3px solid #000000; text-align: center;margin-top: 50px;">
            <div style="padding-top: 6px">
            </div>
            <img src="../../../images/logo.png" style="width: 75px; height: 75px;" />
            <asp:Label Font-Bold="true" Font-Size="12pt" runat="server">
            <h3 style="color: #0000FF;">GOVERNMENT OF TELANGANA <br /> COMMISSIONERATE OF INDUSTRIES</h3></asp:Label>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align: left">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <span style="float: left;"><span style="float: left;"><b>From</b></span><br />
                            The General Manager,<br />
                            District Industries Centre,<br />
                            <asp:Label ID="lblletterFrom" runat="server"></asp:Label>.</span>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3"></div>
                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                        <span style="float: right;"><span style="float: left;"><b>To</b></span>
                            <br />
                            The Commissioner of Industries,<br />
                            Government of Telangana,<br />
                            Chirag Ali Lane, Abids,<br />
                            Hyderabad.</span>
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
                    H&T Dept. – T-TAP Policy 2017-2022 – Incentive claim applications received in respect of M/s. 
                    <asp:Label ID="lblEnterpreneurDetails" Font-Bold="true" runat="server"></asp:Label>
                    – Incentive Claim Applications Verified and Scrutinized – Submission of Inspection, Verification and Recommendation Report – Reg.
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 11px">
                <span class="floatleft auto-style3">Ref :- 1. G.O Ms No. 59, Ind. & Com (Tex) Dept.,  Dt: 18.08.2017 <br />
                           2. G.O.Ms.No.14, Ind. & Com. (Tex) Dept., dt: 15.11.2019. <br />
                           3. Proceedings Rc.No.2072/2014-Parks, dated: 6.12.2019 of the Director H&T & AEPs, TS, Hyderabad. <br />
                           4. T-TAP Online Incentive Claims Application No. 
                                  &nbsp;<span style="font-weight: bold"><asp:Label ID="lblRefApplicationNo" runat="server"></asp:Label></span>&nbsp;, dt: &nbsp;
                               <span style="font-weight: bold">
                                   <asp:Label ID="lblRefApplnDate" runat="server"></asp:Label></span>
                    of M/s.
                    <asp:Label ID="lblEnterpreneurDetails1" Font-Bold="true" runat="server"></asp:Label> <br />
                    5. Inspection Report dated:<span style="font-weight: bold"><asp:Label ID="lblInspectionReportdated" runat="server"></asp:Label></span> .
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
                <span class="floatleft auto-style3">In the reference 4th cited,&nbsp;M/s. &nbsp;<asp:Label ID="lblEnterpreneurDetails2" Font-Bold="true" runat="server"></asp:Label>&nbsp;has submitted 
                    <b><asp:Label ID="lblincentivesCount" Font-Bold="true" runat="server"></asp:Label></b> T-TAP Incentives claim applications through online. The details of which along with the amount recommended is as below : 
                </span>
            </div>
           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 6px">
                <div class="col-sm-12 text-black font-SemiBold mb-1"></div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 table-responsive mt-2">
                    <asp:GridView ID="gvappliedsubsides" runat="server" CssClass="table table-bordered title6 pro-detail w-100 NewEnterprise"
                        AutoGenerateColumns="false">
                        <HeaderStyle HorizontalAlign="Center" />
                        <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                        <RowStyle CssClass="GridviewScrollC1Item" HorizontalAlign="Left" />
                        <PagerStyle CssClass="GridviewScrollC1Pager" />
                        <FooterStyle CssClass="GridviewScrollC1Footer" />
                        <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                        <Columns>
                            <asp:TemplateField HeaderText="S No.">
                                <ItemTemplate>
                                    <asp:Label ID="SNo" runat="server" Text='<%#Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Form No.">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnergyConsumedFinancialYear" runat="server" Text='<%#Eval("FormNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name of the Incentive">
                                <ItemTemplate>
                                    <asp:Label ID="lblHalfYearFlag" runat="server" Text='<%#Eval("NameoftheIncentive") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount Recommended Rs.">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnergyConsumedAmountPaid" runat="server" Text='<%#Eval("AmountRecommended") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Date of Recommended">
                                <ItemTemplate>
                                    <asp:Label ID="lblEnergyConsumedAmountPaid" runat="server" Text='<%#Eval("Recommendeddate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 11px">
                <span class="floatleft auto-style3">The above said 
                   <b><asp:Label ID="lblincentivesCount1" Font-Bold="true" runat="server"></asp:Label></b>
                    Incentives claim applications have been scrutinized and verified as per T-TAP Modified Operational Guidelines. I have physically inspected the unit/company on 
                    <span style="font-weight: bold"><asp:Label ID="lblInspectionReportdated1" runat="server"></asp:Label></span>
                    and verified the line of activity and all the investments made by the company in Land, Building, 
                    Plant and Machinery, etc. The above 
                     <span style="font-weight: bold"><asp:Label ID="lblincentivesCount2" runat="server"></asp:Label></span>&nbsp; 
                    Incentives Claim applications in Part-A along with the Inspection and Verification Report in Part-B is enclosed herewith 
                    along with the copies of attachments. Since the incentive claims of the unit/company is above Rs.25.00 lakhs, 
                    the same has been forwarded to the Head office duly recommending the claims for placing before the State Level 
                    SVC and SLC of T-Idea, for approval and for further necessary action as per T-TAP Operational Guidelines. 
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; padding-bottom: 5px; text-align: left">
                <span class=" pull-right"><span style="font-weight: bold">Yours faithfully,</span><br />
                    <asp:Label ID="lblGMname" runat="server"></asp:Label><br />
                    <%--Asst. Director (H&T)<br />
                    <asp:Label ID="lbldist3" runat="server"></asp:Label>--%>
                </span>
                <span class=" pull-left">Enclosures : As above.  
                </span>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px; padding-bottom: 5px; text-align: left" runat="server" visible="false">
                <span class=" pull-left"><span style="font-weight: bold">Copy to the RDD (H&T) </span> &nbsp; &nbsp; &nbsp;
                    <asp:Label ID="lblRDDname" runat="server"></asp:Label><br /><br />
                </span>
            </div>
        </div>
        <div class="container" id="Div2" runat="server" style="text-align: center; vertical-align: bottom">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 19px; padding-bottom: 19px">
                <input id="Button2" type="button" value="Print" class="btn btn-warning btn-lg" onclick="javascript: myFunction()" />
            </div>
        </div>
    </form>
</body>
</html>