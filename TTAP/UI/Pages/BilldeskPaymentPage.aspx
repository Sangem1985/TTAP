<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BilldeskPaymentPage.aspx.cs" Inherits="TTAP.UI.Pages.BilldeskPaymentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../js/jquery-latest.min.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../../Js/validations.js"></script>
    <script>
        function AutoSubmit() {
            //Submit your form
            document.forms[0].submit();
        }
        //Submit your form after 10000
        //window.setInterval("AutoSubmit();", 1);
    </script>
</head>
<body onload="AutoSubmit()">
    <form id="form1" action='<%= Session["BuildDeskNewUrl"].ToString() %>' method="post">
        <div>
            <input id="res" type="hidden" value='<%=Session["msg"].ToString() %>' name="CheckSumValue" />

            <input style="border-top-width: thin; font-weight: bold; border-left-width: thin; font-size: 12px; border-left-color: #ffffff; border-bottom-width: thin; border-bottom-color: #ffffff; color: #ffffff; border-top-color: #ffffff; font-family: Tahoma, Verdana, Arial, Helvetica, sans-serif; background-color: #7f853d; border-right-width: thin; border-right-color: #ffffff"
                type="submit" value="PAY NOW" id="btnpaynow" runat="server" />
        </div>
    </form>
</body>
</html>
