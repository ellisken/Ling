using Ling.Data;
using Ling.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ling.Models.Services
{
    public class RecordingService : IRecording
    {
        public LingDbContext _context { get; set; }

        public Task AddRecording(Recording recording)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteRecording(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Recording> GetRecording(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Recording>> GetRecordings()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateRecording(Recording recording)
        {
            throw new System.NotImplementedException();
        }
    }
}
