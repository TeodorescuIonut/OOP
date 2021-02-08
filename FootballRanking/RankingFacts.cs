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
            Ranking britishRanking = new Ranking(britishTeams);
            britishTeams = britishRanking.AddNewTeam(teamArsenal, britishTeams);
            britishTeams = britishRanking.AddNewTeam(teamChelsea, britishTeams);
            britishTeams = britishRanking.AddNewTeam(teamManchester, britishTeams);
            int rankingSize = britishTeams.Length;
            Assert.Equal(3, rankingSize);
        }

        [Fact]
        public void AddPositionShouldReturnNameDetail()
        {
            Team teamArsenal = new Team("Arsenal", 45);
            Team teamChelsea = new Team("Chelsea", 49);
            Team teamManchester = new Team("Manchester", 5);
            Team teamLiverpool = new Team("Liverpool", 15);
            Team[] britishTeams = { teamArsenal, teamChelsea, teamManchester, teamLiverpool };
            Ranking britishRanking = new Ranking(britishTeams);
            britishRanking.SortTeam(britishTeams);
            string teamName = britishRanking.ReturnTeamName(britishTeams, 5);
            Assert.Equal("Team name: Manchester Total points: 5", teamName);
        }

        [Fact]
        public void AddNameShouldReturnPositionNumber()
        {
            Team teamArsenal = new Team("Arsenal", 45);
            Team teamChelsea = new Team("Chelsea", 49);
            Team teamManchester = new Team("Manchester", 5);
            Team teamLiverpool = new Team("Liverpool", 15);
            Team[] britishTeams = { teamArsenal, teamChelsea, teamManchester, teamLiverpool };
            Ranking britishRanking = new Ranking(britishTeams);
            britishRanking.SortTeam(britishTeams);
            int positionNo = britishRanking.ReturnPosition(britishTeams, teamManchester);
            Assert.Equal(4, positionNo);
        }
    }
}
