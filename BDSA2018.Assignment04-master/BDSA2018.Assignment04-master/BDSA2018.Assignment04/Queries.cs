using BDSA2018.Assignment04.Entities;
using System;
using System.Linq;


namespace BDSA2018.Assignment04
{
    public class Queries : IDisposable
    {
        private SlotCarContext ctx;

        public Queries(SlotCarContext context)
        {
            ctx = context;
            ctx.Seed();
        }

        public TrackInfo GetTrackInfo(int trackId)
        {
            TrackInfo selectedTrackInfo = new TrackInfo();
            Track track = (from trk in ctx.Tracks
                           where trk.Id == trackId
                           select trk).FirstOrDefault()
                           ?? throw new NotSupportedException();
            selectedTrackInfo.Id = track.Id;
            selectedTrackInfo.Name = track.Name;
            selectedTrackInfo.FastestLap = TimeSpan.FromTicks((long)track.BestLapTime);

            int numberOfRaces = (from race in ctx.Races
                                 join trk in ctx.Tracks on race.Track.Id equals trk.Id
                                 where trk.Id == trackId
                                 select race).Count();
            selectedTrackInfo.NumberOfRaces = numberOfRaces;

            // Assumes that the fastest record from the track is also in the database as a car - ie. the fastest lap can not surpass the fastest driver
            // Else we would just have to find the minimum in this query instead of comparing it with the fastestlap time.
            Car fastestCar = (from car in ctx.Cars
                              from trk in ctx.Tracks
                              join cir in ctx.CarsInRaces on car.Id equals cir.CarId
                              join race in ctx.Races on cir.Race.Id equals race.Id
                              where track.BestLapTime == cir.BestLap && trk.Id == trackId
                              select car).FirstOrDefault() 
                              ?? throw new NotSupportedException();
            selectedTrackInfo.FastestsDriver = fastestCar.DriverName;
            selectedTrackInfo.FastestsCar = fastestCar.Name;

            return selectedTrackInfo;
        }

        public RaceInfo GetRaceInfo(int raceId)
        {
            RaceInfo selectedRaceInfo = new RaceInfo();
            Race race = (from rc in ctx.Races
                         where rc.Id == raceId
                         select rc).FirstOrDefault()
                         ?? throw new NotSupportedException();
            selectedRaceInfo.RaceId = race.Id;
            selectedRaceInfo.TrackId = race.Track.Id;
            selectedRaceInfo.TrackName = race.Track.Name;
            selectedRaceInfo.NumberOfLaps = race.NumberOfLaps;

            CarInfo[] carsInRace = ctx.CarsInRaces
                .Where(cirs => cirs.RaceId == raceId)
                .Join(ctx.Cars, cirs => cirs.CarId, crs => crs.Id, (cirs, crs) =>
                new CarInfo
                {
                    CarId = crs.Id,
                    CarName = crs.Name,
                    DriverName = crs.DriverName,
                    StartPosition = cirs.StartPosition,
                    EndPosition = cirs.EndPosition,
                    BestLapInTicks = cirs.BestLap,
                    TotalRaceTimeInTicks = cirs.TotalRaceTime
                }).ToArray();
            selectedRaceInfo.Cars = carsInRace;

            return selectedRaceInfo;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
        }
    }

}
