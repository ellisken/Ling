using Ling.Data;
using Ling.Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ling.Models.Services
{
    public class RecordingService : IRecording
    {
        public LingDbContext _context { get; set; }

        public RecordingService(LingDbContext context)
        {
            _context = context;
        }

        public async Task AddRecording(Recording recording)
        {
            _context.Recordings.Add(recording);
            await _context.SaveChangesAsync();
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
