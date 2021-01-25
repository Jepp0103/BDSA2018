using System.Collections.Generic;
using Xunit;

namespace BDSA2018.Assignment08.Entities.Tests
{
    public class RaceTests
    {
        [Fact]
        public void CarsInRace_is_instance_of_HashSet_of_CarInRace()
        {
            var race = new Race();

            Assert.IsType<HashSet<CarInRace>>(race.CarsInRace);
        }
    }
}
