using System.Collections.Generic;
using Xunit;

namespace BDSA2018.Assignment08.Entities.Tests
{
    public class TrackTests
    {
        [Fact]
        public void Races_is_instance_of_HashSet_of_Race()
        {
            var track = new Track();

            var races = track.Races as HashSet<Race>;

            Assert.NotNull(races);
        }
    }
}
