using System;
using Xunit;

namespace FootballRanking
{
    public class TeamFacts
    {
        [Fact]
        public void TwoDifferentTeamsAreNotEqual()
        {
            Team teamArsenal = new Team("Arsenal", 45);
            Team teamChelsea = new Team("Chelsea", 45);
            Assert.NotEqual(teamArsenal, teamChelsea);
        }

        [Fact]
        public void TwoDifferentTeamsButSamePoints()
        {
            Team teamArsenal = new Team("Arsenal", 45);
            Team teamChelsea = new Team("Chelsea", 45);
            Assert.Equal(teamArsenal.GetPoints(), teamChelsea.GetPoints());
        }
    }
}
