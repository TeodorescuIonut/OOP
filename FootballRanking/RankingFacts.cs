using System;
using Xunit;

namespace FootballRanking
{
    public class RankingFacts
    {
        [Fact]
        public void AddTeamsShouldReturnCorrectNoOfTeams()
        {
            Team[] britishTeams = { };
            Team teamArsenal = new Team("Arsenal", 45);
            Team teamChelsea = new Team("Chelsea", 49);
            Team teamManchester = new Team("Manchester", 5);
            Ranking teamRanking = new Ranking(britishTeams);
            teamRanking.AddNewTeam(teamArsenal);
            teamRanking.AddNewTeam(teamChelsea);
            teamRanking.AddNewTeam(teamManchester);
            Team checkTeam = teamRanking.TeamAtPosition(3);
            Assert.Equal(teamManchester, checkTeam);
        }

        [Fact]
        public void AddPositionShouldReturnNameDetail()
        {
            Team teamArsenal = new Team("Arsenal", 45);
            Team teamChelsea = new Team("Chelsea", 49);
            Team teamManchester = new Team("Manchester", 5);
            Team teamLiverpool = new Team("Liverpool", 15);
            Team[] britishTeams = { teamArsenal, teamChelsea, teamManchester, teamLiverpool };
            Ranking teamRanking = new Ranking(britishTeams);
            Team checkTeam = teamRanking.TeamAtPosition(4);
            Assert.Equal(teamManchester, checkTeam);
        }

        [Fact]
        public void AddNameShouldReturnPositionNumber()
        {
            Team teamArsenal = new Team("Arsenal", 45);
            Team teamChelsea = new Team("Chelsea", 49);
            Team teamManchester = new Team("Manchester", 5);
            Team teamLiverpool = new Team("Liverpool", 15);
            Team[] britishTeams = { teamArsenal, teamChelsea, teamManchester, teamLiverpool };
            Ranking teamRanking = new Ranking(britishTeams);
            int positionNo = teamRanking.TeamPosition(teamManchester);
            Assert.Equal(4, positionNo);
        }

        [Fact]
        public void AddAMatchScore()
        {
            Team teamArsenal = new Team("Arsenal", 45);
            Team teamChelsea = new Team("Chelsea", 45);
            Team teamManchester = new Team("Manchester", 5);
            Team teamLiverpool = new Team("Liverpool", 15);
            Team[] britishTeams = { teamArsenal, teamChelsea, teamManchester, teamLiverpool };
            Ranking teamRanking = new Ranking(britishTeams);
            teamRanking.TeamMatch(teamArsenal, teamChelsea, 1, 2);
            int positionNo = teamRanking.TeamPosition(teamChelsea);
            Assert.Equal(1, positionNo);
        }
    }
}
