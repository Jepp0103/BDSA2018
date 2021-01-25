using BDSA2018.Assignment08.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2018.Assignment08.Models
{
    public interface ITrackRepository
    {
        Task<int> CreateAsync(TrackCreateDTO track);

        Task<TrackDTO> FindAsync(int trackId);

        IQueryable<TrackDTO> Read();

        Task<bool> UpdateAsync(TrackUpdateDTO track);

        Task<bool> DeleteAsync(int trackId);
    }
}
