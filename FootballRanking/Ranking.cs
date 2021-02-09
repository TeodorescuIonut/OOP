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

        public Team[] AddNewTeam(Team team)
        {
            int length = this.teams.Length;
            Array.Resize(ref this.teams, this.teams.Length + 1);
            this.teams[this.teams.Length - 1] = team;
            return this.teams;
        }

        public Team[] SortTeam()
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

            return this.teams;
        }

        public Team ReturnTeam(int position)
        {
            Team newTeam = new Team(" ", 0);
            for (int i = 0; i < this.teams.Length; i++)
            {
                if (i + 1 == position)
                {
                    newTeam = this.teams[i];
                }
            }

            return newTeam;
        }

        public int ReturnPosition(Team newTeam)
        {
            int position = 0;
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
            const int increment = 1;
            if (awayGoals > homeGoals)
            {
                awayTeam.UpdatePoints(increment);
            }

            homeTeam.UpdatePoints(increment);
        }
    }
}
