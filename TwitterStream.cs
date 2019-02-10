using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

//form application resource : https://www.youtube.com/watch?v=3KnDstiN6qc
namespace TwitterStream
{
    class TwitterStream
    {
        static void Main(string[] args)
        {
            //Authentication
            Auth.SetUserCredentials(ConfigurationManager.AppSettings["ConsumerKey"], ConfigurationManager.AppSettings["ConsumerSecret"], ConfigurationManager.AppSettings["AccessToken"],
                ConfigurationManager.AppSettings["AccessTokenSecret"]);

            //Create the Stream
            var stream = Stream.CreateFilteredStream();

            //Keywords to Track 
            stream.AddTrack("disney");

            //Limit to English
            stream.AddTweetLanguageFilter(LanguageFilter.English);

            //Message so you know its running
            Console.Write("I am listening to Twitter");

            stream.MatchingTweetReceived += (sender, arguments) =>
            {
                Console.WriteLine(arguments.Tweet.Text);
            };

            stream.StartStreamMatchingAllConditions();

            
            Console.ReadKey();
        }
    }
}
