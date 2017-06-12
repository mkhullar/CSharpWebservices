using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TweetsWs
{

    public class TweetData
    {
        public Tweet[] tweet { get; set; }
    }

    public class Tweet
    {
        public string URL { get; set; }
        public string imgURL { get; set; }
        public string screenName { get; set; }
        public string statusText { get; set; }
        public Umentioned[] uMentioned { get; set; }
        public string uname { get; set; }
    }

    public class Umentioned
    {
        public string screenName { get; set; }
        public string uname { get; set; }
    }

}