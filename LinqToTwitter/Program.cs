using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LinqToTwitter
{
    class Program
    {
        //TODO
        static void Main(string[] args)
        {
            Console.WriteLine("Section A: Initialise local variables");

            Console.WriteLine("Enter your access token");
            var accessToken = Console.ReadLine();

            Console.WriteLine("Enter your access token Secret ");
            var accessTokenSecret = Console.ReadLine();

            Console.WriteLine("Enter your access consumer Key ");
            var consumerKey = Console.ReadLine();

            Console.WriteLine("Enter your access token Secret");
            var consumerSecret = Console.ReadLine();

            Console.WriteLine("Enter your access twitterAcccountToDisplay");
            var twitterAcccountToDisplay = Console.ReadLine();

            Console.WriteLine("Search for the tweet ");
            var searchTweet = Console.ReadLine();

            Console.WriteLine("Tweet Count");
            var tweetCount = Convert.ToInt32(Console.ReadLine());

            // SECTION B: Setup Single User Authorisation
            Console.WriteLine("SECTION B: Setup Single User Authorisation");
            var authorizer = new SingleUserAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore()
                {
                    ConsumerKey = consumerKey,
                    ConsumerSecret = consumerSecret,
                    OAuthToken = accessToken,
                    OAuthTokenSecret = accessTokenSecret,
                    ScreenName = twitterAcccountToDisplay,
                    UserID = 12345  // Your UserID
                }
            };

            // SECTION C: Generate the Twitter Context
            Console.WriteLine("SECTION C: Generate the Twitter Context");
            var twitterContext = new TwitterContext(authorizer);

            var statusTweets = new List<Search>();

            // SECTION D: Get Tweets for user
            Console.WriteLine("SECTION D: Get Tweets for user");
            try
            {
                statusTweets = (from tweet in twitterContext.Search
                                where tweet.Type == SearchType.Search && tweet.Query == searchTweet
                                && tweet.Count == tweetCount
                                select tweet).ToList();
            }
            catch (AggregateException e)
            {

                Console.WriteLine("AggregateException {0}", e.InnerExceptions[0]);
            }

            // SECTION E: Print Tweets
            Console.WriteLine("SECTION E: Print Tweets");
            PrintTweets(statusTweets);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the tweets.
        /// </summary>
        /// <param name="statusTweets">The status tweets.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void PrintTweets(IEnumerable<Search> statusTweets)
        {
            foreach (var statusTweet in statusTweets)
            {

                statusTweet.Statuses.ForEach(tweet =>
                   Console.WriteLine(
                       "User: {0}, Tweet: {1} \n",
                       tweet.User.ScreenNameResponse,
                       tweet.Text));

                Thread.Sleep(1000);
            }
        }
    }
}
