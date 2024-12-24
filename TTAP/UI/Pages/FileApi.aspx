<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileApi.aspx.cs" Inherits="TTAP.UI.Pages.FileApi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>  
        <script type="text/javascript">
            $(document).ready(function () {
               $("#nonseamless").submit();
           });
        </script>
</head>
<body>
    <form id="nonseamless" method="post" name="redirect" action="https://ipass.telangana.gov.in/departmentView.aspx?accessCode=AVCZ02FI27BC93ZCCB">
        <input type="hidden" runat="server" id="module" name="module" value=""/>
        <input type="hidden" runat="server" name="filepath" id="filepath" value=""/>
        <input type="hidden" runat="server" name="cfeid" id="cfeid" value=""/>
    </form>
</body>
</html>