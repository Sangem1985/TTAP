<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormAutoMessages.aspx.cs" Inherits="TTAP.UI.Pages.FormAutoMessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" CssClass="col-12" Text="Send" style="background: green;color: white;" ID="btnAdd" OnClick="btnAdd_Click"  />
        </div>
        <input type="hidden" id="hdnMSG" value="N" runat="server" />
        <input type="hidden" id="hdnReminder1" value="N" runat="server" />
        <input type="hidden" id="hdnReminder2" value="N" runat="server" />
        <input type="hidden" id="hdnReminder3" value="N" runat="server" />
        <input type="hidden" id="hdnRDD" value="N" runat="server" />
        <input type="hidden" id="hdnADD" value="N" runat="server" />
    </form>
</body>
</html>
