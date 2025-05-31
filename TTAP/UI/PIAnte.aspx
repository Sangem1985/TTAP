<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PIAnte.aspx.cs" Inherits="TTAP.UI.PIAnte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card-body">
            <asp:GridView ID="gvAPIData" runat="server" AutoGenerateColumns="False"
                CellPadding="4" Height="62px" CssClass="table table-bordered title6 alternet-table pro-detail w-100 NewEnterprise"
                Width="100%" Font-Names="Verdana" Font-Size="12px">
                <HeaderStyle HorizontalAlign="Center" />
                <HeaderStyle CssClass="GridviewScrollC1HeaderWrap" />
                <RowStyle CssClass="GridviewScrollC1Item" />
                <PagerStyle CssClass="GridviewScrollC1Pager" />
                <FooterStyle CssClass="GridviewScrollC1Footer" />
                <AlternatingRowStyle CssClass="GridviewScrollC1Item2" />
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="S No">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="60px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="VisitorName" HeaderText="Visitor Name" />
                    <asp:BoundField DataField="VisitorCity" HeaderText="Visitor City" />
                    <asp:BoundField DataField="MobileNumber" HeaderText="Mobile Number" />
                    <asp:BoundField DataField="VisitorCode" HeaderText="VisitorCode" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Country" HeaderText="Country" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
