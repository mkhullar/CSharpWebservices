<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="weatherCookie.aspx.cs" Inherits="Assignment5.weatherCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
      <asp:Label ID="WeatherLabel" runat="server" Text="Weather Details"></asp:Label><br /><br />

        
        <p>
            <asp:Label ID="temp" runat="server" Text="Today : "></asp:Label>
            <asp:Label ID="day0" runat="server" Text="NAN"></asp:Label>
            
        </p>
        <asp:Label ID="Day1Label" runat="server" Text="Day1 :"></asp:Label>
        <asp:Label ID="day1" runat="server" Text="NAN"></asp:Label>
        <p>
            <asp:Label ID="dayTemp" runat="server" Text="Day2 : "></asp:Label>
            <asp:Label ID="day2" runat="server" Text="NAN"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Sunset" runat="server" Text="Day3 : "></asp:Label>
            <asp:Label ID="day3" runat="server" Text="NAN"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label1" runat="server" Text="Day4 : "></asp:Label>
            <asp:Label ID="day4" runat="server" Text="NAN"></asp:Label>

        </p>
         <br /><br /><br />
         <asp:Button ID="getWeather" runat="server" OnClick="getWeather_Click" Text="Main Page" />
    </div>
    </form>
</body>
</html>
