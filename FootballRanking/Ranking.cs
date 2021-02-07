using System;
using System.Collections.Generic;
using System.Text;

namespace FootballRanking
{
    class Ranking
    {
        private readonly Team[] teams;

        public Ranking(Team[] teams)
        {
            this.teams = teams;
        }

        public Team[] AddNewTeam(Team team, Team[] teams)
        {
            Team[] newArray = new Team[teams.Length + 1];
            int i;
            for (i = 0; i < teams.Length; i++)
            {
                newArray[i] = teams[i];
            }

            newArray[i] = team;
            return newArray;
        }

        public Team[] SortTeam(Team[] teams)
        {
            int n = teams.Length;
            for (int i = 1; i < n; ++i)
            {
                Team key = teams[i];
                int j = i - 1;
                while (j >= 0 && teams[j].Points() < key.Points())
                {
                    teams[j + 1] = teams[j];
                    j--;
                }

                teams[j + 1] = key;
            }

            return teams;
        }

        public string ReturnTeamName(Team[] teams, int position)
        {
            string name = "";
            for (int i = 0; i < teams.Length; i++)
            {
                if (i + 1 == position)
                {
                    name = teams[i].Name();
                }
            }

            return name;
        }

        public int ReturnPosition(Team[] teams, string teamName)
        {
            int position = 0;
            for (int i = 0; i < teams.Length; i++)
            {
                if (teamName == teams[i].Name())
                {
                    position = i + 1;
                }
            }

            return position;
        }
    }
}
