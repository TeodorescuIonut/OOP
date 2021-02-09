using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    class Team
    {
        private readonly string name;
        private int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public bool CompareTo(Team otherTeam)
        {
            return this.points < otherTeam.points;
        }

        public void UpdatePoints(int increment)
        {
            this.points += increment;
        }
    }
}
