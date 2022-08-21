using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class TwitterDataModel
    {
        public Data data { get; set; }
        public Includes includes { get; set; }
    }

    public class Attachments
    {
        public List<string> media_keys { get; set; }
    }

    public class Data
    {
        public Attachments attachments { get; set; }
        public string author_id { get; set; }
        public string conversation_id { get; set; }
        public DateTime created_at { get; set; }
        public Entities entities { get; set; }
        public Geo geo { get; set; }
        public string id { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public List<ReferencedTweet> referenced_tweets { get; set; }
        public string reply_settings { get; set; }
        public string source { get; set; }
        public string text { get; set; }
    }

    public class Entities
    {
        public List<Hashtag> hashtags { get; set; }
        public List<Mention> mentions { get; set; }
        public List<Url> urls { get; set; }
    }

    public class Geo
    {
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Includes
    {
        public List<User> users { get; set; }
        public List<Tweet> tweets { get; set; }
    }

    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
        public string id { get; set; }
    }

    public class PublicMetrics
    {
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
    }

    public class ReferencedTweet
    {
        public string type { get; set; }
        public string id { get; set; }
    }

    public class Tweet
    {
        public Attachments attachments { get; set; }
        public string author_id { get; set; }
        public string conversation_id { get; set; }
        public DateTime created_at { get; set; }
        public Entities entities { get; set; }
        public Geo geo { get; set; }
        public string id { get; set; }
        public string in_reply_to_user_id { get; set; }
        public string lang { get; set; }
        public bool possibly_sensitive { get; set; }
        public PublicMetrics public_metrics { get; set; }
        public List<ReferencedTweet> referenced_tweets { get; set; }
        public string reply_settings { get; set; }
        public string source { get; set; }
        public string text { get; set; }
    }

    public class Url
    {
        public int start { get; set; }
        public int end { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string media_key { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
    }





}
