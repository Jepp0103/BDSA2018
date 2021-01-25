using BDSA2018.Assignment04.Entities;
using System;

namespace BDSA2018.Assignment04
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceInfo actual;
            using (var query = new Queries(new SlotCarContext(SlotCarContext.GetInMemoryDbOptions("Track_Info_Test"))))
            {
                actual = query.GetRaceInfo(6);
            }
            System.Console.WriteLine(TimeSpan.FromTicks(10000000000));
        }
    }
}
