<%@ Page Language="C#" AutoEventWireup="true" CodeFile="form.aspx.cs" Inherits="form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ASE form</title>
    <style>
        div {
            background-color: aquamarine;
            border: solid 1px black;
        }
            div.aspNetHidden {
            visibility: hidden;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Form stranka KAE/ASE
       </h1>
        <div>
            <asp:Button id="btnTest" runat="server" text="Stiskni mě" onclick="btnTest_Click" BackColor="#336699" BorderColor="#66FF33" Font-Names="Arial Black" Height="49px" />
            <asp:Label ID ="lblTest" runat="server" ForeColor="#000099"></asp:Label>
        </div>
        <div style="font-style: italic; background-color: #808080; border-style: groove">
            <asp:Literal id="ltrInfo" runat="server" text="?"/>
        </div>

        <table>
            <tr> <!-- tr = sloupec, td = radek -->
            <td><asp:TextBox ID ="txA" runat="server"></asp:TextBox></td>
            <td><asp:TextBox ID ="txB" runat="server"></asp:TextBox></td>
            <td><asp:Button ID ="btnCalc" runat="server" Text="Spocitej" OnClick="btnCalc_Click"></asp:Button></td>
            <td><asp:Label ID ="lblVysledek" runat="server">Vysledek</asp:Label></td>
            </tr>
        </table>

            <table>
                <tr>
                    <td>

                        
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="teplota" HeaderText="teplota" SortExpression="teplota" />
        <asp:BoundField DataField="cas" HeaderText="cas" SortExpression="cas" />
        <asp:BoundField DataField="stanice" HeaderText="stanice" SortExpression="stanice" />
        <asp:BoundField DataField="poznamka" HeaderText="poznamka" SortExpression="poznamka" />
    </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>


                    </td>

                    <td>

                         <asp:GridView ID="gvMoje" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                             <EditRowStyle BackColor="#999999" />
                             <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                             <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                             <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                             <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                             <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                             <SortedAscendingCellStyle BackColor="#E9E7E2" />
                             <SortedAscendingHeaderStyle BackColor="#506C8C" />
                             <SortedDescendingCellStyle BackColor="#FFFDF8" />
                             <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                         </asp:GridView>

                    </td>

                </tr>

            </table>
    </form>
</body>
</html>
