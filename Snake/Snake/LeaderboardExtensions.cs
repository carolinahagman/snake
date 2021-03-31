using System;
using System.Collections.Generic;

namespace Snake
{
    public static class LeaderboardExtensions
    {
        public static void PrintLeaderboard(List<ScoreModel> scores)
        {
            const string title = @"

  _     _       _                              
 | |   (_)     | |                             
 | |__  _  __ _| |__    ___  ___ ___  _ __ ___ 
 | '_ \| |/ _` | '_ \  / __|/ __/ _ \| '__/ _ \
 | | | | | (_| | | | | \__ \ (_| (_) | | |  __/
 |_| |_|_|\__, |_| |_| |___/\___\___/|_|  \___|
           __/ |                               
          |___/                                ";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine(title);
            Console.WriteLine("================================");
            foreach (var score in scores)
            {
                Console.WriteLine($"{score.Name}: {score.Points}");
            }
            Console.WriteLine("================================");

        }
    }
}