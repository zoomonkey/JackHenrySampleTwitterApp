# JackHenrySampleTwitterApp
This is a .Net Winforms app written in VS 2019.
To run this, get the code, then modify the app.config to have your own Twitter Bearer Token it in.





























Known issues & TODO's
Need to store the Bearer key/token somewhere more secure like Vault, not in a config file





Notes, to get every field append to URL.
// get every field
//url += "?tweet.fields=attachments,author_id,context_annotations,conversation_id,created_at,entities,geo,id,in_reply_to_user_id,lang,non_public_metrics,";
//url += "organic_metrics,possibly_sensitive,promoted_metrics,public_metrics,referenced_tweets,reply_settings,source,text,withheld&expansions=attachments.media_keys,attachments.poll_ids,author_id,entities.mentions.username,geo.place_id,in_reply_to_user_id,";
//url += "referenced_tweets.id,referenced_tweets.id.author_id";
