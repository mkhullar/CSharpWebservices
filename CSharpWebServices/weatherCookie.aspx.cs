using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment5
{
    public partial class weatherCookie : System.Web.UI.Page
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
            }else
            {
                day0.Text = "No Cookies Found";
                day1.Text = "No Cookies Found";
                day2.Text = "No Cookies Found";
                day3.Text = "No Cookies Found";
                day4.Text = "No Cookies Found";
            }

        }

        protected void getWeather_Click(object sender, EventArgs e)
        {
            Response.Redirect("News.aspx");
        }
    }
}