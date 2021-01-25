using BDSA2018.Assignment04.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BDSA2018.Assignment04.Tests
{
    public class CarCRUDTests
    {
        [Fact]
        public void CRUDCreationExplicitIDTest()
        {
            int actualID;

            using (var testContext = new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("Explicit_test")))
            {
                var testCRUD = new CarCRUD(testContext);
                testCRUD.Create(new Car { Id = 1, DriverName = "Dandy Danny", Name = "aCar" });

                actualID = (from cars in testContext.Cars
                            where cars.Id == 1
                            select cars.Id).FirstOrDefault();
            }

            Assert.Equal(1, actualID);
        }

        [Fact]
        public void CRUDCreationCanInsertMoreElementstest()
        {
            int actualSize;

            using (var testContext = new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("Insert_More_Elements_Test")))
            {
                var testCRUD = new CarCRUD(testContext);
                testCRUD.Create(new Car { DriverName = "Dandy Danny", Name = "aCar" });
                testCRUD.Create(new Car { DriverName = "Dandy Danny The First", Name = "aCar1" });
                testCRUD.Create(new Car { DriverName = "Dandy Danny The Second", Name = "aCar2" });
                testCRUD.Create(new Car { DriverName = "Dandy Danny The Third", Name = "aCar3" });
                testCRUD.Create(new Car { DriverName = "Dandy Danny The Fourth", Name = "aCar4" });
                testCRUD.Create(new Car { DriverName = "Dandy Danny The Fifth", Name = "aCar5" });


                actualSize = (from cars in testContext.Cars
                              select cars).Count();
            }
            Assert.Equal(6, actualSize);
        }

        [Fact]
        public void CRUDFindByIdTest()
        {
            var expectedCar = new Car { Id = 4, DriverName = "Dandy Danny The Third", Name = "aCar3" };
            Car actualCar;

            using (var testContext = new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("Find_Car_Test")))
            {
                var testCRUD = new CarCRUD(testContext);
                testCRUD.Create(new Car { Id = 1, DriverName = "Dandy Danny", Name = "aCar" });
                testCRUD.Create(new Car { Id = 2, DriverName = "Dandy Danny The First", Name = "aCar1" });
                testCRUD.Create(new Car { Id = 3, DriverName = "Dandy Danny The Second", Name = "aCar2" });
                testCRUD.Create(new Car { Id = 4, DriverName = "Dandy Danny The Third", Name = "aCar3" });
                testCRUD.Create(new Car { Id = 5, DriverName = "Dandy Danny The Fourth", Name = "aCar4" });
                testCRUD.Create(new Car { Id = 6, DriverName = "Dandy Danny The Fifth", Name = "aCar5" });


                actualCar = testCRUD.FindById(4);
            }
            Assert.Equal(expectedCar, actualCar);
        }

        [Fact]
        public void CRUDAllTest()
        {
            var expectedList = new List<Car> {
                new Car { Id = 1, DriverName = "Dandy Danny", Name = "aCar" },
                new Car { Id = 2, DriverName = "Dandy Danny The First", Name = "aCar1" },
                new Car { Id = 3, DriverName = "Dandy Danny The Second", Name = "aCar2" },
                new Car { Id = 4, DriverName = "Dandy Danny The Third", Name = "aCar3" },
                new Car { Id = 5, DriverName = "Dandy Danny The Fourth", Name = "aCar4" },
                new Car { Id = 6, DriverName = "Dandy Danny The Fifth", Name = "aCar5" }};
            ICollection<Car> actualList;

            using (var testContext = new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("All_Cars_Test")))
            {
                var testCRUD = new CarCRUD(testContext);
                testCRUD.Create(new Car { Id = 1, DriverName = "Dandy Danny", Name = "aCar" });
                testCRUD.Create(new Car { Id = 2, DriverName = "Dandy Danny The First", Name = "aCar1" });
                testCRUD.Create(new Car { Id = 3, DriverName = "Dandy Danny The Second", Name = "aCar2" });
                testCRUD.Create(new Car { Id = 4, DriverName = "Dandy Danny The Third", Name = "aCar3" });
                testCRUD.Create(new Car { Id = 5, DriverName = "Dandy Danny The Fourth", Name = "aCar4" });
                testCRUD.Create(new Car { Id = 6, DriverName = "Dandy Danny The Fifth", Name = "aCar5" });


                actualList = testCRUD.All();
            }
            Assert.True(expectedList.SequenceEqual(actualList));
        }

        [Fact]
        public void CRUDUpdateTest()
        {
            var expectedList = new List<Car> {
                new Car { Id = 1, DriverName = "Dandy Danny", Name = "aCar" },
                new Car { Id = 2, DriverName = "Dandy Danny The First", Name = "aCar1" },
                new Car { Id = 3, DriverName = "Dandy Danny The Second", Name = "aCar2" },
                new Car { Id = 4, DriverName = "Dandy Danny The Third", Name = "aCar3" },
                new Car { Id = 5, DriverName = "Dandy Danny The DopeyBoy", Name = "aCar4" },
                new Car { Id = 6, DriverName = "Dandy Danny The Fifth", Name = "aCar5" }};
            ICollection<Car> actualList;

            using (var testContext = new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("Update_Cars_Test")))
            {
                var testCRUD = new CarCRUD(testContext);
                testCRUD.Create(new Car { Id = 1, DriverName = "Dandy Danny", Name = "aCar" });
                testCRUD.Create(new Car { Id = 2, DriverName = "Dandy Danny The First", Name = "aCar1" });
                testCRUD.Create(new Car { Id = 3, DriverName = "Dandy Danny The Second", Name = "aCar2" });
                testCRUD.Create(new Car { Id = 4, DriverName = "Dandy Danny The Third", Name = "aCar3" });
                testCRUD.Create(new Car { Id = 5, DriverName = "Dandy Danny The Fourth", Name = "aCar4" });
                testCRUD.Create(new Car { Id = 6, DriverName = "Dandy Danny The Fifth", Name = "aCar5" });

                testCRUD.Update(new Car { Id = 5, DriverName = "Dandy Danny The DopeyBoy", Name = "aCar4" });


                actualList = testCRUD.All();
            }
            Assert.True(expectedList.SequenceEqual(actualList));
        }

        [Fact]
        public void CRUDDeleteTest()
        {
            var expectedList = new List<Car> {
                new Car { Id = 1, DriverName = "Dandy Danny", Name = "aCar" },
                new Car { Id = 2, DriverName = "Dandy Danny The First", Name = "aCar1" },
                new Car { Id = 3, DriverName = "Dandy Danny The Second", Name = "aCar2" },
                new Car { Id = 4, DriverName = "Dandy Danny The Third", Name = "aCar3" },
                new Car { Id = 6, DriverName = "Dandy Danny The Fifth", Name = "aCar5" }};
            ICollection<Car> actualList;

            using (var testContext = new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("Delete_Car_5_Test")))
            {
                var testCRUD = new CarCRUD(testContext);
                testCRUD.Create(new Car { Id = 1, DriverName = "Dandy Danny", Name = "aCar" });
                testCRUD.Create(new Car { Id = 2, DriverName = "Dandy Danny The First", Name = "aCar1" });
                testCRUD.Create(new Car { Id = 3, DriverName = "Dandy Danny The Second", Name = "aCar2" });
                testCRUD.Create(new Car { Id = 4, DriverName = "Dandy Danny The Third", Name = "aCar3" });
                testCRUD.Create(new Car { Id = 5, DriverName = "Dandy Danny The Fourth", Name = "aCar4" });
                testCRUD.Create(new Car { Id = 6, DriverName = "Dandy Danny The Fifth", Name = "aCar5" });

                testCRUD.Delete(5);

                actualList = testCRUD.All();
            }
            Assert.True(expectedList.SequenceEqual(actualList));
        }
    }
}

