<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="continualGet.aspx.cs" Inherits="WebApplication1.continualGet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                </ContentTemplate>
            </asp:UpdatePanel>
            <div style="width: 1000px; background-color: black">
                <div id="p" style="width: 0px; background-color: yellow; text-align: center">
                    <span id="qqq">0%</span>
                </div>
            </div>
            <%--<input type="button" onclick="abc()" />--%>
        </div>
    </form>
    <script type="text/javascript">
        abc = function () {
            setInterval(function () {
                $.ajax({
                    type: "post",
                    contentType: "application/json",
                    url: "/continualGet.aspx/Get",
                    data: "",
                    dataType: "json",
                    success: function (m) {
                        $("#qqq").html(m.d.a)
                        $("#p").css("width", m.d.b + "px")
                    },
                    error: function (m) {
                        $("#qqq").html("Error")
                    }
                })
            }, 500, null)
        }
        $("#Button1").click(abc);
        setTimeout(function () {
            $("#Button1")[0].click();
        }, 2000, null);
    </script>
</body>
</html>
