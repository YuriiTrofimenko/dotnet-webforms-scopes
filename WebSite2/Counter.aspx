<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Counter.aspx.cs" Inherits="Counter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="increment" runat="server" Text="+1" OnClick="increment_Click"/>
            <span><%= count %></span>
        </div>
        <div>
            <asp:Button ID="send" runat="server" Text="SendData"  OnClick="send_Click" />
        </div>
        <div>
            <span><%= visits %></span>
        </div>
    </form>
</body>
</html>
