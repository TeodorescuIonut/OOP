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
                while (j >= 0 && teams[j].CompareTo(key))
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
            string teamDetail = " ";
            for (int i = 0; i < teams.Length; i++)
            {
                if (i + 1 == position)
                {
                    teamDetail = teams[i].ReturnDetail(teams[i]);
                }
            }

            return teamDetail;
        }

        public int ReturnPosition(Team[] teams, Team newTeam)
        {
            int position = 0;
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].CheckName(newTeam))
                {
                    position = i + 1;
                }
            }

            return position;
        }
    }
}
