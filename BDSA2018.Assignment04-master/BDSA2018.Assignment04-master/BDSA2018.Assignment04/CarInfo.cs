using System;

namespace BDSA2018.Assignment04
{
    public class CarInfo
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string DriverName { get; set; }
        public int StartPosition { get; set; }
        public int? EndPosition { get; set; }
        public long? BestLapInTicks { get; set; }
        public long? TotalRaceTimeInTicks { get; set; }
        public TimeSpan? BestLap => BestLapInTicks.HasValue ? TimeSpan.FromTicks(BestLapInTicks.Value) : default(TimeSpan?);
        public TimeSpan? TotalRaceTime => TotalRaceTimeInTicks.HasValue ? TimeSpan.FromTicks(TotalRaceTimeInTicks.Value) : default(TimeSpan?);

        public override bool Equals(object obj)
        {
            var OtherCarInfo = obj as CarInfo;

            bool isEqual =
                this.CarId == OtherCarInfo.CarId &&
                this.CarName.Equals(OtherCarInfo.CarName) &&
                this.DriverName.Equals(OtherCarInfo.DriverName) &&
                this.StartPosition == OtherCarInfo.StartPosition &&
                this.EndPosition == OtherCarInfo.EndPosition &&
                this.BestLapInTicks == OtherCarInfo.BestLapInTicks &&
                this.TotalRaceTimeInTicks == OtherCarInfo.TotalRaceTimeInTicks;

            return isEqual;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CarId, CarName, DriverName, StartPosition, EndPosition, BestLapInTicks, TotalRaceTimeInTicks);
        }
    }
}