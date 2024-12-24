<%@ Page Title="" Language="C#" MasterPageFile="~/UI/UserMaster.Master" AutoEventWireup="true" CodeBehind="frmUnitSanctionLetters.aspx.cs" Inherits="TTAP.UI.Pages.frmUnitSanctionLetters" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../../Js/validations.js"></script>

    <script language="javascript" type="text/javascript">
        function Panel1() {


            

            var panel = document.getElementById("<%=divPrint.ClientID %>");
            // var printWindow = window.open('', '', 'height=400,width=800');
            // printWindow.document.write('<html><head><h3 style="width: 100%;text-align: center;">Government of Telangana</h3>');
            // printWindow.document.write('</head><body style="width: 100%;text-align: center;">');

            var printWindow = window.open('', '', 'height=500,width=900');
            printWindow.document.write('<html><head><div><table style="width:100%"> <tr> <td align="center"> <img alt="" align="center" style="width:15%; height:15%" src="../../../images/logo.png"/> </td> <td> <div style="float: right; text-align: center; padding: 10px 0;"> <div style="float: left; margin-right: 30px;"> <h5 style="font-size: 14px; margin-bottom: 0px;"></h5> <p style="font-size: 14px; margin-bottom: 0px;"></p> </div> <div style="float:left"> <h5 style="font-size: 14px; margin-bottom: 0px;"></h5> <p style="font-size: 14px; margin-bottom: 0px;"></p> </div> </div> </td> </tr> </table> </div><h3 style="width: 100%; text-align: center;">Government of Telangana</h3>');
            printWindow.document.write('</head><body style="width:1200px;margin:0 auto;">');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            setTimeout(function () {
                printWindow.print();
                //location.reload(true);
                printWindow.close();
            }, 1000);
            return false;

        }

        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            var WinPrint = window.open('', '', 'letf=0,top=0,width=0,height=0,toolbar=0,scrollbars=1,status=0');
            var strOldOne = prtContent.innerHTML;
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>

    <style type="text/css">
        .update {
            position: fixed;
            top: 0px;
            left: 0px;
            min-height: 100%;
            min-width: 100%;
            background-image: url("../../../Images/ajax-loaderblack.gif");
            /*background-image: url("Images/spinner_60.gif");*/
            background-position: center center;
            background-repeat: no-repeat;
            /*background-color: #e4e4e6;*/
            background-color: #535252;
            z-index: 500 !important;
            opacity: 0.6;
            overflow: hidden;
        }

        .fa.fa-hand-o-right {
            margin-right: 12px;
        }

        .head2 {
            font-weight: bold;
            color: tomato;
            font-size: 16px;
        }

        .page-head-line {
            font-size: 30px;
            text-transform: uppercase;
            color: #000;
            font-weight: 800;
            padding-bottom: 20px;
            border-bottom: 2px solid #00CA79;
            margin-bottom: 10px;
        }

        .page-subhead-line {
            font-size: 14px;
            padding-top: 5px;
            padding-bottom: 20px;
            font-style: italic;
            margin-bottom: 30px;
            border-bottom: 1px dashed #00CA79;
        }
    </style>


    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel4">
        <ProgressTemplate>
            <div class="update">
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
       
        <ContentTemplate>
            <div id="content">
                <div id="content-header">
                    <div id="breadcrumb" class="d-none">
                        <a href="#" runat="server" id="ehome" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                        <a href="#" class="current" runat="server" id="acurrentpage">Incentive Types</a>
                    </div>
                    <div class="breadcrumb-bg">
                        <ul class="breadcrumb font-medium title5 container">
                            <li class="breadcrumb-item"><a href="frmDashBoard.aspx">Home</a></li>
                            <li class="breadcrumb-item">Sanctioned Letters</li>
                        </ul>
                    </div>
                </div>
                <div class="container mt-4 pb-4" id="Receipt" runat="server">
                    <div class="row">
                        <div class="w-100 px-3 frm-form box-content py-3 font-medium title5">
                            <div class="widget-box">
                                <div class="widget-title">
                                    <span class="icon">
                                        <i class="icon-info-sign"></i>
                                    </span>
                                </div>
                                <div class="widget-content nopadding">
                                    <div class="row" id="divPrint" runat="server">
                                       
                                        <div class="col-sm-12 table-responsive">
                                            <asp:GridView ID="gvdetailsnew" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                CssClass="table table-bordered mb-0 title6 alternet-table w-100 NewEnterprise"
                                                PageSize="20" GridLines="Both">
                                                <HeaderStyle VerticalAlign="Middle" CssClass="text-center" />
                                                <RowStyle CssClass="GridviewScrollC1Item" />
                                                <PagerStyle CssClass="GridviewScrollC1Pager" />
                                                <FooterStyle CssClass="GridviewScrollC1Header" />
                                                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                                                <Columns>
                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5%" HeaderText="S No">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1%>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="ApplicationNumber" ItemStyle-HorizontalAlign="Center" HeaderText="Application Number">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IncentiveName" ItemStyle-HorizontalAlign="Center" HeaderText="Incentive Name">
                                                        <ItemStyle CssClass="text-left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ApplicationFiledDate" ItemStyle-HorizontalAlign="Center" HeaderText="Application Date" DataFormatString="{0:dd-M-yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                      <asp:BoundField DataField="SanctionedLetter_Issued_On" ItemStyle-HorizontalAlign="Center" HeaderText="Sanctioned Letter Issued on" DataFormatString="{0:dd-M-yyyy}">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderStyle-CssClass="text-center" HeaderText="Sanctioned Letter">
                                                        <ItemTemplate>
                                                            <asp:HyperLink ID="hyIssueLetterPath" Text="View" NavigateUrl='<%#Eval("SanctionLetterPath")%>' Target="_blank" runat="server" />
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left" CssClass="text-center" Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Incentiveid" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIncentiveID" Text='<%#Eval("IncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblSubIncentiveID" Text='<%#Eval("SubIncentiveID") %>' runat="server" />
                                                            <asp:Label ID="lblSanctionStatus" Text='<%#Eval("Sanctioned_Status") %>' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div id="divNoData" style="color: red;"
                                            runat="server" visible="false">
                                            No Data Found
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdnUserId" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
