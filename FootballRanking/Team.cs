using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    class Team
    {
        private string name;
        private int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public void SetPoints(int teamPoints)
        {
            this.points = teamPoints;
        }

        public bool CompareTo(Team otherTeam)
        {
            return this.points < otherTeam.points;
        }

        public void SetName(string teamName)
        {
            this.name = teamName;
        }
    }
}
