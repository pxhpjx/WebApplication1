<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wcf.aspx.cs" Inherits="WebApplication1.wcf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Width="111px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="296px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Width="219px"></asp:TextBox>
        <br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>


        <br />


        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />




        <br />





        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
