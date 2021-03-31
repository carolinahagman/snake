using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;

namespace Snake
{
    public static class HttpService
    {
        private static RestClient _client = new RestClient("http://localhost:5000");

        public static void GetLeaderboard()
        {
            var request = new RestRequest("Leaderboard", Method.GET).AddQueryParameter("count", "10");
            var response = _client.Get<LeaderboardModel>(request);

            LeaderboardExtensions.PrintLeaderboard(response.Data.Scores);
        }

        public static void PostScore(int score, string name)
        {
            var request = new RestRequest("Leaderboard", Method.POST).AddJsonBody(new ScoreModel(name, score));
            var response = _client.Post<ScoreModel>(request);
            GetLeaderboard();
        }
    }
}