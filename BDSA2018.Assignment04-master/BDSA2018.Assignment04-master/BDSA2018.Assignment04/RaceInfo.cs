using System;
using System.Collections.Generic;
using System.Linq;

namespace BDSA2018.Assignment04
{
    public class RaceInfo
    {
        public int RaceId { get; set; }
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public int NumberOfLaps { get; set; }
        public IEnumerable<CarInfo> Cars { get; set; }

        public override bool Equals(object obj)
        {
            var OtherRaceInfo = obj as RaceInfo;

            bool isEqual =
                this.RaceId == OtherRaceInfo.RaceId &&
                this.TrackId == OtherRaceInfo.TrackId &&
                this.TrackName.Equals(OtherRaceInfo.TrackName) &&
                this.NumberOfLaps == OtherRaceInfo.NumberOfLaps &&
                this.Cars.SequenceEqual(OtherRaceInfo.Cars);

            return isEqual;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RaceId, TrackId, TrackName, NumberOfLaps, Cars);
        }
    }
}