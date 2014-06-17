<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chartfix.aspx.cs" Inherits="WebApplication1.chartdemo.chartfix" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="../js/sea.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="position: absolute; top: 0px; left: 0px; background-color: white; z-index: 22222; text-align: left">
                7日年化收益率：
                <span class="bold f14"><span id="week2year-syl">-.-</span>%</span>
                <span id="week2year-date" class="gray">(--)</span>
                &nbsp;&nbsp;是活期存款的<span id="compare" class="bold f14">--</span>倍
                <asp:HiddenField ID="hfBankRate" runat="server" />
                <asp:HiddenField ID="hfHeight" runat="server" />
                <div>
                    <div id="week2year-chart" style="text-align: center; width: 430px">
                    </div>
                    <script type="text/javascript">
                        var tradeData = { list: [<% =chartdata %>] };
                    </script>
                    <script type="text/javascript" src="chartfix.js"></script>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
