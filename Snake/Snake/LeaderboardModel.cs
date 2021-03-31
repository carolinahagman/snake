using System.Collections.Generic;

namespace Snake
{
    public class LeaderboardModel
    {
        public List<ScoreModel> Scores { get; set; }

        public LeaderboardModel()
        {
        }
    }

    public class ScoreModel
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public ScoreModel(string name, int points)
        {
            Name = name;
            Points = points;
        }

        public ScoreModel()
        {
        }
    }
}