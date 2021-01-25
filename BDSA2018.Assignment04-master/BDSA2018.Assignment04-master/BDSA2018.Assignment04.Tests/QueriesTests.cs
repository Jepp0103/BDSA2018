using BDSA2018.Assignment04.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace BDSA2018.Assignment04.Tests
{
    public class QueriesTests
    {
        [Fact]
        public void GetTrackInfoTest()
        {
            TrackInfo expected = new TrackInfo
            {
                Id = 1,
                Name = "Short track",
                NumberOfRaces = 1,
                FastestsCar = "Fast car",
                FastestsDriver = "Danny",
                FastestLap = TimeSpan.FromTicks(10000000000)
            };
            TrackInfo actual;
            using (var query = new Queries(new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("Track_Info_Test"))))
            {
                actual = query.GetTrackInfo(1);
            }

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetRaceInfoTest()
        {
            RaceInfo expected = new RaceInfo
            {
                RaceId = 6,
                TrackId = 3,
                TrackName = "Long track",
                NumberOfLaps = 12,
                Cars = new CarInfo[]
                {
                    new CarInfo
                    {
                        CarId = 3,
                        CarName = "Kicked car",
                        DriverName = "Theodor",
                        StartPosition = 2,
                        EndPosition = 1,
                        BestLapInTicks = 99000000000,
                        TotalRaceTimeInTicks = 250000000000
                    },
                    new CarInfo
                    {
                        CarId = 4,
                        CarName = "Lore car",
                        DriverName = "Historian",
                        StartPosition = 1,
                        EndPosition = 2,
                        BestLapInTicks = 96000000000,
                        TotalRaceTimeInTicks = 320000000000
                    }
                }
            };
            RaceInfo actual;

            using (var query = new Queries(new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("Race_Info_Test"))))
            {
                actual = query.GetRaceInfo(6);
            }

            Assert.Equal(expected, actual);
        }
    }
}
