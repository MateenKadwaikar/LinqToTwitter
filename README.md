# Linq2Twitter
Sample code for Linq2Twitter in Console application.

It just give you an overview how to use Linq2Twitter API in C#.

LINQ to Twitter is an open source 3rd party LINQ Provider for the Twitter micro-blogging service. It uses standard LINQ syntax for queries and includes method calls for changes via the Twitter API.
 

It will ask for your accessToken , accessTokenSecret,  
consumerKey, consumerSecret ,twitterAccountToDisplay to get all this start by creating a twitter account that your application will be using to access Twitter. This is easy-peasy. Log on to https://twitter.com/ and setup your account.

Once your account is setup, navigate to https://dev.twitter.com and sign in with your twitter credentails. 

You need to enter your application details. You need a Name, Description & a Website (Your application's publicly accessible home page). You can add a Callback URL but its not really required. (Note: The name can't include the word "twitter".)

Remember to agree to the terms and conditions.
You should now get directed to the application page. By default, the first tab ("Details" tab) is visible. You must click the "Api Keys" tab and then click the "Create my access token" button (you will need to scroll down). This in turn generates the access tokens (you may need to refresh the page). Your Keys and Access Tokens should now be available for use.



Once created, navigate to the "OAutth tool" tab to view your OAuth Settings. We will need the generated tokens for our applications. (Note: My tokens are crossed out to maintain their integrity.)
Take note of the following tokens as we will need these later:
Consumer key
Consumer secret
Access token
Access token secret