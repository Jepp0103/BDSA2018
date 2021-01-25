using System.Collections.Generic;
using Xunit;

namespace BDSA2018.Assignment08.Entities.Tests
{
    public class CarTests
    {
        [Fact]
        public void CarsInRace_is_instance_of_HashSet_of_CarInRace()
        {
            var car = new Car();

            var carsInRace = car.CarsInRace as HashSet<CarInRace>;

            Assert.NotNull(carsInRace);
        }
    }
}
