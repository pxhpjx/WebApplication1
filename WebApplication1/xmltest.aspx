<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xmltest.aspx.cs" Inherits="WebApplication1.xmltest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Write" runat="server" Text="Write" OnClick="Write_Click" />
        <asp:Button ID="Read" runat="server" Text="Read" OnClick="Read_Click" />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div>
                    <textarea id="TextArea1" cols="50" rows="7"><%#((string)Container.DataItem)%></textarea>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
    </form>
</body>
</html>
