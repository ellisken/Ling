using Ling.Data;
using Ling.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Recording> GetRecording(int id)
        {
            return await _context.Recordings.FirstOrDefaultAsync(r => r.ID == id);
        }

        public async Task<IEnumerable<Recording>> GetRecordings()
        {
            return await _context.Recordings.ToListAsync();
        }

        public async Task UpdateRecording(Recording recording)
        {
            _context.Recordings.Update(recording);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRecording(int id)
        {
            var recording = await GetRecording(id);
            _context.Recordings.Remove(recording);
            await _context.SaveChangesAsync();
        }
    }
}
