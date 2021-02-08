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

        public int GetPoints()
        {
            return points;
        }

        public void SetPoints(int teamPoints)
        {
            this.points = teamPoints;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string teamName)
        {
            this.name = teamName;
        }
    }
}
