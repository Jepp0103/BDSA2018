using BDSA2018.Assignment08.Entities;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using BDSA2018.Assignment08.Shared;

namespace BDSA2018.Assignment08.Models
{
    public class TrackRepository : ITrackRepository
    {
        private readonly ISlotCarContext _context;

        public TrackRepository(ISlotCarContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(TrackCreateDTO track)
        {
            var entity = new Track
            {
                Name = track.Name,
                LengthInMeters = track.LengthInMeters,
                MaxCars = track.MaxCars
            };

            _context.Tracks.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<TrackDTO> FindAsync(int trackId)
        {
            var tracks = from t in _context.Tracks
                         where t.Id == trackId
                         select new TrackDTO
                         {
                             Id = t.Id,
                             Name = t.Name,
                             LengthInMeters = t.LengthInMeters,
                             BestLap = t.BestLapInTicks.HasValue
                                ? TimeSpan.FromTicks(t.BestLapInTicks.Value)
                                : default(TimeSpan?),
                             MaxCars = t.MaxCars,
                             NumberOfRaces = t.Races.Count()
                         };

            return await tracks.FirstOrDefaultAsync();
        }

        public IQueryable<TrackDTO> Read()
        {
           return from t in _context.Tracks
                  select new TrackDTO
                  {
                      Id = t.Id,
                      Name = t.Name,
                      LengthInMeters = t.LengthInMeters,
                      BestLap = t.BestLapInTicks.HasValue
                         ? TimeSpan.FromTicks(t.BestLapInTicks.Value)
                         : default(TimeSpan?),
                      MaxCars = t.MaxCars,
                      NumberOfRaces = t.Races.Count()
                  };
        }

        public async Task<bool> UpdateAsync(TrackUpdateDTO track)
        {
            var entity = await _context.Tracks.FindAsync(track.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = track.Name;
            entity.LengthInMeters = track.LengthInMeters;
            entity.BestLapInTicks = track.BestLap?.Ticks;
            entity.MaxCars = track.MaxCars;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int trackId)
        {
            var track = await _context.Tracks.FindAsync(trackId);

            if (track == null)
            {
                return false;
            }

            _context.Tracks.Remove(track);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
