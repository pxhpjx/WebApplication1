<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication1.WebForm2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="jquery.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="width: 100%; text-align: center;">
        <div style="margin: 30px; padding: 0px; color: #000080; font-size: xx-large">百分比饼图和XML输出</div>
        <div style="margin: auto; text-align: left; width: 700px;">
            类型：
            <asp:DropDownList ID="ddlPersonalRiskType" runat="server">
                <asp:ListItem>安全型</asp:ListItem>
                <asp:ListItem>保守型</asp:ListItem>
                <asp:ListItem>稳健型</asp:ListItem>
                <asp:ListItem>积极型</asp:ListItem>
                <asp:ListItem>进取型</asp:ListItem>
            </asp:DropDownList>
            <br />
            风险：
            <asp:CheckBox ID="chkFundRisk1" runat="server" />低风险
            <asp:CheckBox ID="chkFundRisk2" runat="server" />较低风险
            <asp:CheckBox ID="chkFundRisk3" runat="server" />中风险
            <asp:CheckBox ID="chkFundRisk4" runat="server" />较高风险
            <asp:CheckBox ID="chkFundRisk5" runat="server" />高风险
            <br />
            描述：
            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="200px" Width="600px"></asp:TextBox>
            <br />
            <table style="margin: auto; text-align: center;">
                <tr>
                    <td>配置：</td>

                    <td>货币型：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCurrencyPer" runat="server">11</asp:TextBox>%
                        <br />
                        股票型：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtStockPer" runat="server">22</asp:TextBox>%
                        <br />
                        债券型：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtBondPer" runat="server">33</asp:TextBox>%
                        <br />
                        <asp:TextBox ID="txtSelf1" runat="server" Width="80px">自定义</asp:TextBox>型：
                        <asp:TextBox ID="txtSelf1Per" runat="server">0</asp:TextBox>%
                        <br />
                        <asp:TextBox ID="txtSelf2" runat="server" Width="80px">自定义</asp:TextBox>型：
                        <asp:TextBox ID="txtSelf2Per" runat="server">0</asp:TextBox>%
                        <br />
                    </td>
                    <td>
                        <asp:Chart ID="ChartFundRate" runat="server" BackColor="White" Height="300px" Width="300px" BorderDashStyle="Solid" BorderWidth="1" BorderColor="255, 255, 255">
                            <Series>
                                <asp:Series Name="Default" ChartType="Pie" BorderColor="255, 255, 255, 255" ChartArea="ChartArea1" LabelForeColor="White" Font="微软雅黑,14pt"></asp:Series>
                            </Series>
                            <ChartAreas>
                                <asp:ChartArea Name="ChartArea1">
                                </asp:ChartArea>
                            </ChartAreas>
                        </asp:Chart>
                    </td>
                </tr>
            </table>
            <br />
            <div style="text-align: center; margin: auto;">
                <asp:Button ID="btnMakePic" runat="server" Text="吃饼" OnClick="btnMakePic_Click" />
                <asp:Button ID="btnUpdate" runat="server" Text="全部更新" OnClick="btnUpdate_Click" />
                <br />
                <br />
                <asp:TextBox ID="txtPath" runat="server">D:\Output</asp:TextBox>
                <asp:Button ID="btnSave" runat="server" Text="保存图片和XML" OnClick="btnSave_Click" />
                <asp:CheckBox ID="chkView" runat="server" Text="保存后打开文件夹" />
                <br />
                <asp:Label ID="lblTip" runat="server" ForeColor="#FF3300"></asp:Label>
                <br />
                <br />
                Xml:
                <br />
                <asp:TextBox ID="txtOutputXml" runat="server" TextMode="MultiLine" Width="600px" Height="400px" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
<script type="text/javascript" src="CoffeeScript2.js"></script>
</html>
