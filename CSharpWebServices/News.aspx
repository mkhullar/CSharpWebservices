<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Assignment5.News" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
     <asp:Label ID="Label6" runat="server" Text="Caching is Implemented on Headlines"></asp:Label><br /><br />
    <asp:Button ID="getHeadlines" runat="server" OnClick="getHeadlines_Click" Text="Get Headlines" />
    <br />
     <asp:Label ID="headlinesText" runat="server" Text="Headlines"></asp:Label>
            <br /><br /><br />
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Get Tweets for a Topic"></asp:Label><br/><br/>
     <asp:TextBox ID="tweetText" runat="server"></asp:TextBox>
     <asp:Button ID="tweetButton" runat="server" OnClick="tweetButton_Click" Text="Tweet" /><br/><br />
     <asp:Label ID="resultText" runat="server" Text="NAN"></asp:Label>
            
      </div>
         <div>
    
        <asp:Label ID="Label3" runat="server" Text="Description: This service extracts the top 10 words from the website whose url is provided. Link: http://localhost:2914/ServiceTop10Words.svc?wsdl"></asp:Label>
        <br />
        topWords getTop10Words(String str);<br />
        <br />
    
        <asp:Label ID="Label2" runat="server" Text="Enter URL of the webpage you want to extract words of:"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Note: DON'T put http:// in front. Example: www.google.com, www.asu.edu"></asp:Label>
        <br />
        <asp:TextBox ID="TextBoxURL" runat="server" Width="706px"></asp:TextBox>
        <asp:Button ID="ButtonExtractWords" runat="server" OnClick="ButtonExtractWords_Click" Text="Extract Words" Width="120px" />
        <br />
        <br />
        <br />
        <asp:Label ID="LabelOutput" runat="server"></asp:Label>
    
    &nbsp;</div>
         <div>
    <asp:Button ID="sportsBtn" runat="server" Text="Get Sports News" OnClick="sportsBtn_Click" />
        <br />
        <asp:Label ID="sportsText" runat="server" Text="Sports News"></asp:Label>
             <br />
    </div>
        <div>
      <asp:Label ID="WeatherLabel" runat="server" Text="Weather Details"></asp:Label><br /><br />

     <asp:Label ID="ZipLabel" runat="server" Text="Zip Code: "></asp:Label>
        <asp:TextBox ID="ZipCode" runat="server"></asp:TextBox>
        <asp:Button ID="getWeather" runat="server" OnClick="getWeather_Click" Text="Get" />
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
    </div>
    </form>
</body>
</html>
