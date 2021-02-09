using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    class Ranking
    {
        private Team[] teams;

        public Ranking(Team[] teams)
        {
            this.teams = teams;
        }

        public void AddNewTeam(Team team)
        {
            int length = this.teams.Length;
            Array.Resize(ref this.teams, this.teams.Length + 1);
            this.teams[this.teams.Length - 1] = team;
            this.SortTeam();
        }

        public Team TeamAtPosition(int position)
        {
            this.SortTeam();
            return this.teams[position - 1];
        }

        public int TeamPosition(Team newTeam)
        {
            int position = 0;
            this.SortTeam();
            for (int i = 0; i < this.teams.Length; i++)
            {
                if (this.teams[i] == newTeam)
                {
                    position = i + 1;
                }
            }

            return position;
        }

        public void TeamMatch(Team awayTeam, Team homeTeam, int awayGoals, int homeGoals)
        {
            int increment;
            if (awayGoals > homeGoals)
            {
                increment = 3;
                awayTeam.UpdatePoints(increment);
                increment = 0;
                homeTeam.UpdatePoints(increment);
            }

            if (awayGoals < homeGoals)
            {
                increment = 0;
                awayTeam.UpdatePoints(increment);
                increment = 3;
                homeTeam.UpdatePoints(increment);
            }

            if (awayGoals == homeGoals)
            {
                increment = 1;
                awayTeam.UpdatePoints(increment);
                homeTeam.UpdatePoints(increment);
            }

            this.SortTeam();
        }

        private void SortTeam()
        {
            int n = this.teams.Length;
            for (int i = 1; i < n; ++i)
            {
                Team key = this.teams[i];
                int j = i - 1;
                while (j >= 0 && this.teams[j].CompareTo(key))
                {
                    this.teams[j + 1] = this.teams[j];
                    j--;
                }

                this.teams[j + 1] = key;
            }
        }
    }
}
