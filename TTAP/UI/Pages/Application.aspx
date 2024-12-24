<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Application.aspx.cs" Inherits="TTAP.UI.Pages.Application" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= div_app.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();
            var prtWindow = window.open(windowUrl, windowName,
                'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style=”background:none !important”>');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
    <style>
        table.example-table, .example-table td {
            border: 1px solid green;
            border-collapse: collapse;
        }

        .GridviewScrollC1HeaderWrapblue TH, .GridviewScrollC1HeaderWrapblue TD {
            padding: 5px;
            font-weight: normal;
            /*white-space: nowrap;*/
            border-left: 1px solid #F0F0F0;
            border-right: 1px solid #F0F0F0;
            border-bottom: 1px solid #F0F0F0;
            background-color: #013161;
            color: #FFFFFF;
            text-align: center;
            vertical-align: bottom;
        }

        .scorecard {
            background-image: url(../images/doc-border.jpg);
            background-position: left bottom;
            background-repeat: repeat-x;
            padding: 10px;
            width: 90%;
            display: inline-block
        }

        .scorecard-left {
            color: #717171;
            float: left
        }

        .view-report-colour {
            color: #305491;
            float: right;
            font-weight: 700
        }

        .tab_table {
            border: 1px solid #ffa010;
            border-radius: 0 5px 5px;
            padding: 10px
        }

        .view-report-row {
            background-color: #fff;
            border: 5px solid #dfeaf1;
            overflow: hidden;
            padding: 20px 0;
            width: auto
        }

        .view-report-coloumn {
            float: left;
            margin: 0 0 0 5px;
            width: 49%
        }

        .scorecard-left {
            color: #717171;
            float: left
        }

        .view-report-colour {
            color: #305491;
            float: right;
            font-weight: 700
        }

        .dropcontent {
            width: auto
        }

        table.radio tr td {
            display: inline-flex !important
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel runat="server" ID="div_app">
            <div class="table-responsive" data-pattern="priority-columns" data-focus-btn-icon="fa-asterisk" data-sticky-table-header="true" data-add-display-all-btn="true" data-add-focus-btn="true" style="overflow-x: auto;">


                <table id="tbl_data1" class="view-report-row" cellpadding="0" cellspacing="0" border="1" style="width: 100%">
                    <tbody class="view-report-row">
                        <tr align="center">
                            <td colspan="2">
                                <h3 style="color: cornflowerblue">Incentive Application</h3>
                            </td>
                        </tr>
                        <tr align="center">
                            <td>1</td>
                            <td>
                                <h5 style="color: cornflowerblue">Industry Details</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            TSIPass-UID Number :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_TSIPassUIDNumber" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Type of Sector :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_TypeofSector" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Name of The Enterprise:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_NameofTheEnterprise" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Country of Origin (In case of MNC):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CountryofOrigin" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Date Of Incorporation :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_DateOfIncorporation" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Incorporation Registration No:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_IncorporationRegistrationNo" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            GST Number :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_GSTNumber" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            PAN Number :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_PANNumber" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            EIN/IEM/IL Number :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_EIN_IEM_ILNumber" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Date :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_date" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Constitution of Organization:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_constitutionoforganization" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Social Status :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_SocialStatus" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Applicant Name :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lblApplicantName" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Gender(M:Male; F:Female; T:Transgender):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            No of Years of Experience in Textiles:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_noofyearExpinTextiles" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Physically handicapped(Y:yes; N:No):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_Physicallyhandicapped" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">2</td>
                            <td>
                                <h5 style="color: cornflowerblue">Registered Address of Enterprise</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            State:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_RAEState" runat="server"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            District:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_RAEDistrict" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Mandal:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_RAEmandal" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Village:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_RAEVillage" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Grampanchayat/IE/IDA:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_RAEGrampanchayat_IE_IDA" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Survey/Plot No.:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_RAESurveyPlotNo" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Mobile Number:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_RAEMobileNo" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Email Id:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_RAEEmailid" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">3</td>
                            <td>
                                <h5 style="color: cornflowerblue">Correspondence Address</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            State:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CAState" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            District:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CADistrict" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Mandal:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CAMandal" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Village:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CAVillage" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Grampanchayat/IE/IDA:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CAGrampanchayat_IE_IDA" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Survey/Plot No:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CASurveyplotno" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Mobile Number:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CAMobileNo" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Email Id :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_CAEmailID" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <h3 style="color: cornflowerblue">Project Details</h3>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">1</td>
                            <td>
                                <h5 style="color: cornflowerblue">Project Information</h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Industry Status:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_IndustryStatusName" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px"></td>
                            <td>
                                <h5 style="color: cornflowerblue">
                                    <asp:Label ID="lblhead_industryname" runat="server" />
                                </h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Date of Commencement
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_DateofCommencement" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Nature Of Industry
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_NatureOfIndustry" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center" runat="server" id="div_expan" visible="false">
                            <td style="padding-left: 10px"></td>
                            <td>
                                <h5 style="color: cornflowerblue">
                                    <asp:Label ID="lbl_headexmoddivname" runat="server" />
                                </h5>
                            </td>
                        </tr>
                        <tr runat="server" id="div_expandata">
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="view-report-coloumn" id="div_projecrdetailsexpdivmod" visible="false" runat="server">
                                        <div class="scorecard">
                                            <div class="scorecard-left">
                                                Expansion Type:
                                            </div>
                                            <div class="view-report-colour">
                                                <asp:Label ID="lbl_ExpansionType" runat="server"></asp:Label>
                                            </div>
                                            <div class="clearfix">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Expansion Enterprise Date of Commencement:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ExpansionEnterpriseDateofCommencement" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Expanision Nature Of Industry:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ExpanisionNatureOfIndustry" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>


                        <tr align="center">
                            <td style="padding-left: 10px">2</td>
                            <td>
                                <h5 style="color: cornflowerblue">
                                    <asp:Label runat="server" ID="lbl_headofgridallindu" />
                                </h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td></td>
                            <td>
                                <asp:GridView ID="GvLineOfactivityExpnsionDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
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
                                        <asp:TemplateField HeaderText="Value (in Rs.)">
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

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr align="center" runat="server" id="div_existingdata" visible="false">
                            <td style="padding-left: 10px">3</td>
                            <td>
                                <h5 style="color: cornflowerblue">Existing Enterprise Product Details</h5>
                            </td>
                        </tr>
                        <tr align="center" runat="server" id="div_existgriddata" visible="false">
                            <td></td>
                            <td>
                                <asp:GridView ID="GvLineOfactivityDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
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
                                        <asp:TemplateField HeaderText="Value (in Rs.)">
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

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">4</td>
                            <td>
                                <h5 style="color: cornflowerblue">Details of Proprietor/Managing Partner/ Managing Director</h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td></td>
                            <td>
                                <asp:GridView ID="GvPartnerDetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
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
                                        <asp:TemplateField HeaderText="DisignationName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDisignationName" runat="server" Text='<%# Bind("DisignationName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qualification">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQualification" runat="server" Text='<%# Bind("Qualification") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Years of Experience In Texttiles">
                                            <ItemTemplate>
                                                <asp:Label ID="lblYearsofExperience" runat="server" Text='<%# Bind("YearsofExperience") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Share">
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
                                                <asp:Label ID="lblDesignationid" runat="server" Visible="false" Text='<%# Bind("Designation") %>'></asp:Label>
                                                <asp:Label ID="lblDirectorPartnerID" runat="server" Text='<%# Bind("Director_Partner_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">5</td>
                            <td>
                                <h5 style="color: cornflowerblue">Authorised Signatory/Contact Person Details</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Name:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ASCPName" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Designation:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ASCPDesignation" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            PAN Number:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ASCPPANNumber" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Mobile Number:
                                        </div>
                                        <div class="view-report-clolour">
                                            <asp:Label ID="lbl_ASCPMobileNumber" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Email Id:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ASCPEmailID" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Correspondence Address :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ASCpCorrespAddress" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <h3 style="color: cornflowerblue">Project Finanicals</h3>
                            </td>
                        </tr>
                        <tr>
                            <td>1</td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Category:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_industryCategory" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>

                                </div>

                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">2</td>
                            <td>
                                <h5 style="color: cornflowerblue">Employment</h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td></td>
                            <td>
                                <div class="table-responsive">
                                    <table class="table table-bordered title6 alternet-table w-100 NewEnterprise" cellpadding="0" cellspacing="0" border="1">
                                        <tr align="center">
                                            <th></th>
                                            <th></th>
                                            <th colspan="2">Direct</th>
                                            <th colspan="2">In-direct</th>
                                        </tr>
                                        <tr align="center">
                                            <th>Sl.No</th>
                                            <th>Cadre</th>
                                            <th>Male(Nos) </th>
                                            <th>Female(Nos) </th>
                                            <th>Male(Nos) </th>
                                            <th>Female(Nos) </th>
                                        </tr>
                                        <tr>
                                            <td>1</td>
                                            <td>Management & Staff</td>
                                            <td align="center" valign="center">
                                                <asp:Label ID="lbl_staffMale" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_female" runat="server" />

                                            </td>
                                            <td align="center" valign="center">
                                                <asp:Label ID="lbl_staffMaleInDirect" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_femaleInDirect" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20px;">2
                                            </td>
                                            <td style="width: 250px;">Supervisory
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_supermalecount" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_superfemalecount" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_supermalecountInDirect" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_superfemalecountInDirect" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td>Skilled workers </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_SkilledWorkersMale" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_SkilledWorkersFemale" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_SkilledWorkersMaleInDirect" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_SkilledWorkersFemaleInDirect" runat="server" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>4</td>
                                            <td>Semi-skilled workers
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_SemiSkilledWorkersMale" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_SemiSkilledWorkersMaleIndirect" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_SemiSkilledWorkersFemale" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_SemiSkilledWorkersFemaleIndirect" runat="server" />

                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">4</td>
                            <td>
                                <h5 style="color: cornflowerblue">Industry Investment & Power Details Fixed Capital Investment(In Rs.)</h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td></td>
                            <td>
                                <table class="table table-bordered title6 alternet-table w-100 NewEnterprise" cellpadding="0" cellspacing="0" border="1">
                                    <tr align="center">
                                        <th>Sl.No</th>
                                        <th>Nature of Assets</th>
                                        <th>Value (in Rs.)</th>
                                        <th>Under Expansion/ Diversification/
                                            <br />
                                            Modification Project
                                        </th>
                                        <th>% of increase under
                                                                            <br />
                                            Expansion/Diversification/Modification
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>1</td>
                                        <td align="left">Land</td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_landexisting" />

                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_landcapacity" />

                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_landpercentage" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>2</td>
                                        <td align="left">Building </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_buildingexisting" />
                                        </td>

                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_buildingcapacity" />
                                        </td>

                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_buildingpercentage" />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>3</td>
                                        <td align="left" style="text-align: left">Plant &amp; Machinery &nbsp;&nbsp;&nbsp;

                                                                    
                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_plantexisting" />

                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_plantcapacity" />

                                        </td>
                                        <td align="center">
                                            <asp:Label runat="server" ID="lbl_plantpercentage" />

                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">3</td>
                            <td>
                                <h3 style="color: cornflowerblue">Project Finanicals</h3>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <h5 style="color: cornflowerblue">Power Details</h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">1</td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Is power applicable:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_Ispowerapplicable" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="clearfix">
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">2</td>
                            <td>
                                <h5 style="color: cornflowerblue">Existing Enterprise production details</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Power Release Date:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_PowerReleaseDate" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Connected Load (in KVA):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_powerConnectedLoad" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Contracted Load (in KVA) :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_powerContractedLoad" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Rate per unit(in Rs):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ServiceRateUnit" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">2</td>
                            <td>
                                <h5 style="color: cornflowerblue">Expansion/Diversification/Modification details</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Power Release Date :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ExistingPowerReleaseDate" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Connected Load (in KVA)
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ExistingPowerConnectedLoad" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Contracted Load (in KVA)  :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ExistingContractedLoad" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Rate per unit(in Rs):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_ExistingRateUnit" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">2</td>
                            <td>
                                <h5 style="color: cornflowerblue">New  Enterprise production details</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Power Release Date:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_newpowereleasedate" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Connected Load (in KVA):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_newConnectedLoad" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Contracted Load (in KVA) :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_newcontractedload" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Rate per unit(in Rs):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_newrateperunit" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <h3 style="color: cornflowerblue">Water Source Details</h3>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">1</td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Is Water applicable :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_IsWaterapplicable" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Source:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_waterSource" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Requirement (In Unit):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_waterRequirement" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Rate Per Unit(in Rs):
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_waterRateperunit" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <h3 style="color: cornflowerblue">Loan Details</h3>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">1</td>
                            <td>

                                <h5 style="color: cornflowerblue">Background of the Enterprise/Promoter (Last 3 years in Rs Crores)</h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td></td>
                            <td>
                                <div class="table-responsive">
                                    <table class="table table-bordered title6 alternet-table w-100 NewEnterprise" cellpadding="0" cellspacing="0" border="1">
                                        <tr align="center">
                                            <th>Sl.No</th>
                                            <th>Financial Indicator</th>
                                            <th>Year 1 (Rs in Crores)</th>
                                            <th>Year 2 (Rs in Crores)</th>
                                            <th>Year 3 (Rs in Crores)</th>
                                        </tr>
                                        <tr>
                                            <td>1</td>
                                            <td align="left">Turnover</td>
                                            <td align="center">
                                                <asp:Label ID="lbl_TurnoverYear1" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_TurnoverYear2" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_TurnoverYear3" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td align="left">EBITDA </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_EBITDAYear1" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_EBITDAYear2" runat="server" />
                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_EBITDAYear3" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td align="left" style="text-align: left">Networth</td>
                                            <td align="center">
                                                <asp:Label ID="lbl_NetworthYear1" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_NetworthYear2" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_NetworthYear3" runat="server" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>4</td>
                                            <td align="left" style="text-align: left">Reserves & Surplus</td>
                                            <td align="center">
                                                <asp:Label ID="lbl_ReservesYear1" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_ReservesYear2" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_ReservesYear3" runat="server" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>5</td>
                                            <td align="left" style="text-align: left">Share Capital</td>
                                            <td align="center">
                                                <asp:Label ID="lbl_ShareCapitalYear1" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_ShareCapitalYear2" runat="server" />

                                            </td>
                                            <td align="center">
                                                <asp:Label ID="lbl_ShareCapitalYear3" runat="server" />

                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">2</td>
                            <td>
                                <h5 style="color: cornflowerblue">Means Of Finance (In Rs.)</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Promoter's Equity:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_PromoterEquity" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Institutions Equity:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_InstitutionsEquity" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Term Loans :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_TearmLoans" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Seed Capital:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_SeedCapital" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Subsidy/Grants through other agencies:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_Subsidyagencies" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Others:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_MeansFinanceOthers" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                </div>

                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">3</td>
                            <td>
                                <h5 style="color: cornflowerblue">Approved/Estimated projected cost and assets acquired etc</h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td></td>
                            <td>
                                <div class="table-responsive">
                                    <table class="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise" cellpadding="0" cellspacing="0" border="1">
                                        <tr>
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
                                        <tr>
                                            <td>Land
                                            </td>
                                            <td style="padding-top: 5px;">
                                                <asp:Label ID="lbl_Land2" runat="server" />

                                            </td>
                                            <td style="padding-top: 5px;" id="tdLand3" runat="server">
                                                <asp:Label ID="lbl_Land3" runat="server" />

                                            </td>
                                            <td style="padding-top: 5px;">
                                                <asp:Label ID="lbl_Land4" runat="server" />

                                            </td>
                                            <td style="padding-top: 5px;" id="tdLand5" runat="server">
                                                <asp:Label ID="lbl_Land5" runat="server" />

                                            </td>
                                            <td style="padding-top: 5px;" id="tdLand6" runat="server">
                                                <asp:Label ID="lbl_Land6" runat="server" />

                                            </td>
                                            <td style="padding-top: 5px;">
                                                <asp:Label ID="lbl_Land7" runat="server" />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Buildings
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Building2" runat="server" />

                                            </td>
                                            <td id="tdBuilding3" runat="server">
                                                <asp:Label ID="lbl_Building3" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Building4" runat="server" />

                                            </td>
                                            <td id="tdBuilding5" runat="server">
                                                <asp:Label ID="lbl_Building5" runat="server" />

                                            </td>
                                            <td id="tdBuilding6" runat="server">
                                                <asp:Label ID="lbl_Building6" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Building7" runat="server" />

                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="auto-style1">Plant & Machinery
                                            </td>
                                            <td class="auto-style1">
                                                <asp:Label ID="lbl_PM2" runat="server" />

                                            </td>
                                            <td class="auto-style1" id="tdPM3" runat="server">
                                                <asp:Label ID="lbl_PM3" runat="server" />

                                            </td>
                                            <td class="auto-style1">
                                                <asp:Label ID="lbl_PM4" runat="server" />

                                            </td>
                                            <td class="auto-style1" id="tdPM5" runat="server">
                                                <asp:Label ID="lbl_PM5" runat="server" />

                                            </td>
                                            <td class="auto-style1" id="tdPM6" runat="server">
                                                <asp:Label ID="lbl_PM6" runat="server" />

                                            </td>
                                            <td class="auto-style1">
                                                <asp:Label ID="lbl_PM7" runat="server" />

                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Contingencies
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_MCont2" runat="server" />

                                            </td>
                                            <td id="tdMCont3" runat="server">
                                                <asp:Label ID="lbl_MCont3" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_MCont4" runat="server" />

                                            </td>
                                            <td id="tdMCont5" runat="server">
                                                <asp:Label ID="lbl_MCont5" runat="server" />

                                            </td>
                                            <td id="tdMCont6" runat="server">
                                                <asp:Label ID="lbl_MCont6" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_MCont7" runat="server" />

                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Erection
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Erec2" runat="server" />

                                            </td>
                                            <td id="tdErec3" runat="server">
                                                <asp:Label ID="lbl_Erec3" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Erec4" runat="server" />

                                            </td>
                                            <td id="tdErec5" runat="server">
                                                <asp:Label ID="lbl_Erec5" runat="server" />

                                            </td>
                                            <td id="tdErec6" runat="server">
                                                <asp:Label ID="lbl_Erec6" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_Erec7" runat="server" />

                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Technical know-how,<br />
                                                feasibility study
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_TFS2" runat="server" />

                                            </td>
                                            <td id="tdTFS3" runat="server">
                                                <asp:Label ID="lbl_TFS3" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_TFS4" runat="server" />

                                            </td>
                                            <td id="tdTFS5" runat="server">
                                                <asp:Label ID="lbl_TFS5" runat="server" />

                                            </td>
                                            <td id="tdTFS6" runat="server">
                                                <asp:Label ID="lbl_TFS6" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_TFS7" runat="server" />

                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Working Capital Margin
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_WC2" runat="server" />

                                            </td>
                                            <td id="tdWC3" runat="server">
                                                <asp:Label ID="lbl_WC3" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_WC4" runat="server" />

                                            </td>
                                            <td id="tdWC5" runat="server">
                                                <asp:Label ID="lbl_WC5" runat="server" />

                                            </td>
                                            <td id="tdWC6" runat="server">
                                                <asp:Label ID="lbl_WC6" runat="server" />

                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_WC7" runat="server" />

                                            </td>

                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">4</td>
                            <td>
                                <h5 style="color: cornflowerblue">Term Loan details</h5>

                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Have you availed Term Loan
                                        </div>
                                        <div class="view-report-colour">
                                            <b>
                                                <asp:Label ID="lbl_IsTermLoanAvailed" runat="server" /></b>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">5</td>
                            <td>
                                <h5 style="color: cornflowerblue">Implementation Steps Taken - Project Finance</h5>
                            </td>
                        </tr>
                        <tr align="center">
                            <td></td>
                            <td>
                                <asp:GridView ID="GVTermLoandtls" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                    CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise">
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
                                        <asp:TemplateField HeaderText="IncentiveId" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInstitutionNameid" runat="server" Visible="false" Text='<%# Bind("InstitutionName") %>'></asp:Label>
                                                <asp:Label ID="lblTermLoanId" runat="server" Text='<%# Bind("TermLoanId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 10px">6</td>
                            <td>
                                <h5 style="color: cornflowerblue">Bank Details</h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Name of the Bank:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_NametheBank" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Account Type:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_AccountType" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Branch Name:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_BranchName" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>

                                </div>
                                <div class="view-report-coloumn">
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Account Holder Name:
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_AccountHolderName" runat="server"></asp:Label>
                                        </div>
                                        <div class="clearfix">
                                        </div>
                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            Account Number :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_AccountNumber" runat="server"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="scorecard">
                                        <div class="scorecard-left">
                                            IFSC Code :
                                        </div>
                                        <div class="view-report-colour">
                                            <asp:Label ID="lbl_IFSCCode" runat="server"></asp:Label>
                                        </div>

                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </asp:Panel>



        <asp:LinkButton ID="lnk_print" OnClientClick="printGrid()" runat="server" ToolTip="Print">
                                                   <span>Print</span> </asp:LinkButton>

    </form>
</body>
</html>
