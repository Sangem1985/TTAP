<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TGVehicleData.aspx.cs" Inherits="TTAP.TGVehicleData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <button type="submit" id="btnSubmit" runat="server" >Get Token</button>
           
            <input type="text" id="txtbox" runat="server" />
        </div>
         <div>
             <asp:Label runat="server" ID="lblMessage"></asp:Label>
         </div>
    </form>
</body>
</html>
