using System;

namespace BDSA2018.Assignment04
{
    public class TrackInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfRaces { get; set; }
        public string FastestsCar { get; set; }
        public string FastestsDriver { get; set; }
        public TimeSpan FastestLap { get; set; }

        public override bool Equals(object obj)
        {
            var OtherTrackInfo = obj as TrackInfo;

            bool isEqual =
                this.Id == OtherTrackInfo.Id &&
                this.Name.Equals(OtherTrackInfo.Name) &&
                this.NumberOfRaces == OtherTrackInfo.NumberOfRaces &&
                this.FastestsCar.Equals(OtherTrackInfo.FastestsCar) &&
                this.FastestsDriver.Equals(OtherTrackInfo.FastestsDriver) &&
                this.FastestLap.Equals(OtherTrackInfo.FastestLap);

            return isEqual;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, NumberOfRaces, FastestsCar, FastestsDriver, FastestLap);
        }
    }
}