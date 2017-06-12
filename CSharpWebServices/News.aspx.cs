using GetWeatherWs;
using HeadlinesWS;
using Newtonsoft.Json;
using SportsWs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweetsWs;

namespace Assignment5
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if (myCookies != null)
            {
                day0.Text = myCookies["day0"];
                day1.Text = myCookies["day1"];
                day2.Text = myCookies["day2"];
                day3.Text = myCookies["day3"];
                day4.Text = myCookies["day4"];
            }
        }

        protected void getWeather_Click(object sender, EventArgs e)
        {
            HttpCookie myCookies = Request.Cookies["myCookieId"];
            if (myCookies == null)
            {
                weather();
                HttpCookie myCookie = new HttpCookie("myCookieId");
                myCookie["day0"] = day0.Text;
                myCookie["day1"] = day1.Text;
                myCookie["day2"] = day2.Text;
                myCookie["day3"] = day3.Text;
                myCookie["day4"] = day4.Text;
                myCookie.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(myCookie);
                myCookies = myCookie;
                Response.Redirect("weatherCookie.aspx");
            }
            else
            {
                day0.Text = myCookies["day0"];
                day1.Text = myCookies["day1"];
                day2.Text = myCookies["day2"];
                day3.Text = myCookies["day3"];
                day4.Text = myCookies["day4"];
            }
        }

        protected void weather()
        {
            WeatherData wData = weatherData(ZipCode.Text);
            if (wData != null)
            {
                day0.Text = "" + (Math.Round(System.Convert.ToDouble(wData.list[0].main.temp.ToString()) - 273.15, 2)) + " C";
                day1.Text = "" + (Math.Round(System.Convert.ToDouble(wData.list[1].main.temp.ToString()) - 273.15, 2)) + " C";
                day2.Text = "" + (Math.Round(System.Convert.ToDouble(wData.list[2].main.temp.ToString()) - 273.15, 2)) + " C";
                day3.Text = "" + (Math.Round(System.Convert.ToDouble(wData.list[3].main.temp.ToString()) - 273.15, 2)) + " C";
                day4.Text = "" + (Math.Round(System.Convert.ToDouble(wData.list[4].main.temp.ToString()) - 273.15, 2)) + " C";
            }
            else
            {
                day0.Text = "Incorrect ZIP";
                day1.Text = "Incorrect ZIP";
                day2.Text = "Incorrect ZIP";
                day3.Text = "Incorrect ZIP";
                day4.Text = "Incorrect ZIP";
            }
        }
        protected static WeatherData weatherData(String zipCode)
        {
            if (String.IsNullOrEmpty(zipCode))
            {
                return null;

            }

            String URI = "http://localhost:50314/Weather.svc/GetWeather/" + zipCode;
            var request = (HttpWebRequest)WebRequest.Create(URI);
            var result = "";
            request.Accept = "application/json";
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream stream = response.GetResponseStream();
                StreamReader stread = new StreamReader(stream, Encoding.UTF8);
                result = stread.ReadToEnd();
            }
            catch (WebException)
            {
                return null;
            }


            if (!result.Contains("Error"))
            {
                WeatherData wData = JsonConvert.DeserializeObject<WeatherData>(result);
                return wData;
            }
            return null;
        }

        protected void getHeadlines_Click(object sender, EventArgs e)
        {
            if (Cache["cachedData"] == null)
            {
                headLines();
                File.WriteAllText(Server.MapPath("cacheData.txt"), headlinesText.Text);
                string d = File.ReadAllText(Server.MapPath("cacheData.txt"));
                Cache.Insert("cachedData", d, new CacheDependency(Server.MapPath("cacheData.txt")),
               DateTime.Now.AddSeconds(10), Cache.NoSlidingExpiration);
            }
            else
            {
                headlinesText.Text = Cache["cachedData"].ToString();
            }
            
        }

        protected void headLines()
        {
            String URI = "http://localhost:61153/Headlines.svc/Headlines";
            var request = (HttpWebRequest)WebRequest.Create(URI);
            request.Accept = "application/json";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream stream = response.GetResponseStream();
            StreamReader stread = new StreamReader(stream, Encoding.UTF8);
            var result = stread.ReadToEnd();

            HeadLines hData = JsonConvert.DeserializeObject<HeadLines>(result);
            String retStr = "<h1> Headlines</h1><h3>Author : " + hData.articles[0].author + "</h3><ol>";
            foreach (HeadlinesWS.Article atricle in hData.articles)
            {

                retStr += "<li><a href='" + atricle.url + "' target ='_blank'>" + atricle.title + "</a><ul>"
                    + atricle.description + "</ul></li>";
            }
            headlinesText.Text = retStr + "</ol>";
        }

       
        protected void topTen()
        {
            String str = TextBoxURL.Text;
            string url = @"http://localhost:2914/ServiceTop10Words.svc/url=" + str;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            string json = reader.ReadToEnd();
            processJsonNewtonSoft(json);
        }

        protected void ButtonExtractWords_Click(object sender, EventArgs e)
        {
            topTen();
        }
        void processJsonNewtonSoft(String data)
        {
            topWords tw = JsonConvert.DeserializeObject<topWords>(data);
            LabelOutput.Text = "";
            for (int i = 0; i < 10; i++)
            {
                LabelOutput.Text = LabelOutput.Text + "Word is: " + tw.words[i] + "\t";
                LabelOutput.Text = LabelOutput.Text + "Frequency is: " + tw.frequencies[i] + "<br />";
            }

        }
        public class topWords
        {
            public string[] words { get; set; }
            public int[] frequencies { get; set; }
        }

        protected void tweets()
        {
            if (String.IsNullOrEmpty(tweetText.Text.ToString()))
            {
                resultText.Text = "Please Enter a value to Search";
                return;
            }
            String URI = "http://localhost:55213/Service1.svc/Tweets/" + tweetText.Text;
            var request = (HttpWebRequest)WebRequest.Create(URI);
            request.Accept = "application/json";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream stream = response.GetResponseStream();
            StreamReader stread = new StreamReader(stream, Encoding.UTF8);
            var result = stread.ReadToEnd();
            TweetData tData = JsonConvert.DeserializeObject<TweetData>(result);
            String style = " style='border-collapse: collapse; background-color: #1dcaff; color: white; border: 1px solid black'";
            String retStr = "<table style='border-collapse: collapse; border: 1px solid black'><tr><th" + style +
                " >User Name</th><th" + style +
                ">Tweet</th><th" + style +
                ">Media</th><th" + style +
                ">Users Mentioned</th></tr>";

            for (int i = 0; i < tData.tweet.Length; i++)
            {

                String statusText = tData.tweet[i].statusText;
                retStr += "<tr>";
                retStr += "<td><a href='https://twitter.com/" +
                        tData.tweet[i].screenName +
                        "'target='_blank'>" + tData.tweet[i].uname +
                        "</a></td>";

                if (!String.IsNullOrEmpty(tData.tweet[i].URL))
                {
                    retStr += "<td><a href='" + tData.tweet[i].URL + "'target='_blank'> "
                  + statusText + "</a></td>";
                }
                else
                {
                    retStr += "<td>" + statusText + "</td>";
                }
                if (!String.IsNullOrEmpty(tData.tweet[i].imgURL))
                {
                    retStr += "<td><img src='" + tData.tweet[i].imgURL + ":large' height='150' width='150'>";
                }
                else
                {
                    retStr += "<td>No Content</td>";
                }
                retStr += "<td><ul>";
                foreach (Umentioned userMen in tData.tweet[i].uMentioned)
                {
                    retStr += "<li><a href='https://twitter.com/" +
                       userMen.screenName +
                       "'target='_blank'>" + userMen.uname +
                       "</a></li>";
                }
                retStr += "</ul></td>";
                retStr += "</tr>";
            }
            retStr = retStr.Replace("<td>", "<td style ='border-collapse: collapse; border: 1px solid black'>");
            resultText.Text = retStr + "</table>";
        }

        protected void tweetButton_Click(object sender, EventArgs e)
        {
            tweets();
        }

        protected void sports()
        {
            String URI = "http://localhost:61549/Sports.svc/Sports";
            var request = (HttpWebRequest)WebRequest.Create(URI);
            request.Accept = "application/json";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream stream = response.GetResponseStream();
            StreamReader stread = new StreamReader(stream, Encoding.UTF8);
            var result = stread.ReadToEnd();

            Sports hData = JsonConvert.DeserializeObject<Sports>(result);
            String retStr = "<h1> Sports Talks </h1><h3>Author : " + hData.source.ToUpper() + "</h3><ol>";
            foreach (SportsWs.Article atricle in hData.articles)
            {

                retStr += "<li><a href='" + atricle.url +
                    "' target ='_blank'>" + atricle.title + "</a><ul>"
                    + atricle.description + "</ul></li>";
            }
            sportsText.Text = retStr + "</ol>";
        }
        protected void sportsBtn_Click(object sender, EventArgs e)
        {
            sports();
        }
    }
}