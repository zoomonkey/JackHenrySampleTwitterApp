# JackHenrySampleTwitterApp
DESCRIPTION  
This is a .Net Winforms app written in VS 2019 .Net Core 3.1.
To run this, get the code, then modify the app.config to have your own Live Twitter Bearer Token it in.  I put app.config in my .gitignore file so I wouldn't accidentally check in my Bearer token/key.

COMMENTARY
This was a fun project!  I love getting a chance to put some code together to show and talk about beforehand.  Plus this was interesting looking at Twitter data.
That being said, the challenge I had with this is the persistence part of the connection.  It's the first time I've ever worked with a persistent data connection.
I couldn't find much documentation on it...until I found the .Net Progress/Report on a YouTube video and implemented it for the first time.
As primarily a web developer, I don't often work with multi threaded / async apps so I had to dig a little deeper than what I'm used to.

This app could easily be ported to a web application or a console app, or a windows service.  I chose Winforms because it's the easiest way to get 
an app up and running without having to worry about a web/server, html and state management.  I wanted to focus on the connection and the logic.

I could spend a lot more time on this app, but given what my assumptions are correct about what defines 'Trending' I would start using this today. 
This app contains: 
Interfaces, Basic error handling, Basic logging, basic Unit tests, and the entire Twitter Response model (even though hardly
any of it is used) as well.

I didn't know how to define what a 'trend' is, so I made the assumption that it is a snapshot in time, of a set of hashtags.  The  hashtags that are repeated indicate a 'trend'.
That's my take on it.  The variable is just how often or how big is the sample size.  I used a sample of 500, or 1000 tweets for testing, but this thing could run for hours and probably get millions of Tweets I imagine.

Known issues & TODO's
Need to store the Bearer key/token somewhere more secure like Vault, not in a config file
Needs more unit tests and integration tests.
Needs more testing by other people (than me) in general.

Notes, to get every field append to URL.
// get every field
//url += "?tweet.fields=attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,";
//url += "organic_metrics,possibly_sensitive,promoted_metrics,public_metrics,referenced_tweets,reply_settings,source,text,withheld&expansions=attachments.media_keys,attachments.poll_ids,author_id,entities.mentions.username,geo.place_id,in_reply_to_user_id,";
//url += "referenced_tweets.id,referenced_tweets.id.author_id";

RESOURCES:
https://developer.twitter.com/en/docs/twitter-api/tweets/volume-streams/introduction
https://developer.twitter.com/en/portal/petition/essential/basic-info
https://developer.twitter.com/en/docs/twitter-api/tweets/volume-streams/api-reference/get-tweets-sample-stream
https://www.youtube.com/watch?v=zQMNFEz5IVU
