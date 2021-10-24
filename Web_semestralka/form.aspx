<%@ Page Language="C#" AutoEventWireup="true" CodeFile="form.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>WEB form</title>
    <style>     
        div 
        {
        }
        div.aspNetHidden 
        {
            visibility: hidden;
        }
        .background
        {
            background-color: lightgoldenrodyellow;
        }
        .background2
        {
            background-color: blueviolet;
        }
        .auto-style1 {
            width: auto; 
            height: auto;
            vertical-align:top;
        }
        .auto-style2 {
            width: auto; 
            height: auto;
            vertical-align:top;
        }

        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="background" >
        <div class="background">
       <h1>
           <asp:Label ID="Label1" runat="server" Text="Graf teploty:" Font-Italic="False" Font-Names="Bahnschrift"></asp:Label>
      </h1>
        </div>
        
        <table class="background">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Stanice: " Font-Names="Bahnschrift">

                    </asp:Label><asp:Button ID="button" runat="server" Text="1907" OnClick="Button_Click" Font-Names="Bahnschrift" />
            </td>
            </tr>
            <tr> <!-- tr = sloupec, td = radek -->
            <td class="auto-style2">
            <asp:Chart ID="chart" runat="server" OnLoad="Chart1_Load" Width="1184px" BorderlineColor="LightGoldenrodYellow" Height="472px" Palette="SemiTransparent" BackColor="LightGoldenrodYellow">
                <Series>
                    <asp:Series Name="Teplota"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

            </td>
                

            <td>
           <div class="auto-style1" >
            <asp:Calendar ID="calendar" runat="server" BackColor="LightGoldenrodYellow" BorderColor="LightGoldenrodYellow" BorderWidth="1px" Font-Names="Bahnschrift" Font-Size="9pt" ForeColor="Black" Height="470px" NextPrevFormat="FullMonth" Width="470px"  CssClass="auto-style5" OnSelectionChanged="calendar_SelectionChanged">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor= "black" />
                <SelectedDayStyle BackColor="Maroon"  ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="Black" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
        </div>
            </td>
            </tr>
        </table>
               
    </form>
</body>
</html>


        