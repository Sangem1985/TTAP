<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"  CodeBehind="VisitorsList.aspx.cs" Inherits="TTAP.UI.Pages.VisitorsList" %>

<!DOCTYPE html>
<link href="../../../assets/css/jquery-ui-1.8.19.custom.css" rel="stylesheet" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
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
            font-size: 25px;
        }

        .header1 {
            background-color: white;
            color: black;
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
            background-color: #077a16;
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
         .tableFixHead {
            overflow: auto;
        }

            .tableFixHead th {
                position: sticky;
                top: 0;
            }

        /* Just common table stuff. */
        table {
            border-collapse: collapse;
            width: 100%;
        }

        th, td {
            padding: 8px 16px;
        }

        th {
            /*background: #eee;*/
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="divGridVisitors" runat="server" >
                <div class="header" align="center">ARTIGIANO IN FIERA – 2023 <br /> Milan, Italy – 2nd-10th  December, 2023</div>
                <div class="header1" align="center">MADE BEST IN INDIA <br /> Dedicated to Geographical Indications (GI) Tagged Products of Telangana</div>
                <div class="header2" runat="server" align="center">Visitors List
                    <td>
                         <a id="A2" href="#" class="tags" onserverclick="BtnExportExcel_Click" gloss="Export to Excel" runat="server" style="float: right">
                                                    <img src="../../../images/Excel-icon.png" style="margin: -7px 0px 0px 0px;" width="30px" height="30px"
                                                        alt="Excel" /></a>
                    </td>
                </div>
               
                <asp:GridView ID="gvVisitors" align="center" runat="server" AutoGenerateColumns="False" CellPadding="4" Width="100%"
                    EmptyDataText="No Data Found" AlternatingRowStyle-BackColor="#999968" HeaderStyle-BackColor="#e68b8b">
                    <HeaderStyle HorizontalAlign="Center" />
                    <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                    <RowStyle CssClass="GridviewScrollC1Item" />
                    <PagerStyle CssClass="GridviewScrollC1Pager" />
                    <FooterStyle CssClass="GridviewScrollC1Footer" />
                    <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" ItemStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="Slno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="VisitorCode" HeaderText="Registration No" />
                        <asp:BoundField DataField="VisitorName" HeaderText="Visitor Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                        <asp:BoundField DataField="Country" HeaderText="Country" />
                        <asp:BoundField DataField="Organization" HeaderText="Organization" />
                        <asp:BoundField DataField="Products" HeaderText="Products" />
                        <asp:BoundField DataField="Suggestions" HeaderText="Suggestions" />
                        <asp:BoundField DataField="Created_dt" HeaderText="Registered Date" DataFormatString="{0:dd/MMM/yyyy}" />
                    </Columns>
                </asp:GridView>
                  
            </div>
        </div>
    </form>
</body>
</html>
