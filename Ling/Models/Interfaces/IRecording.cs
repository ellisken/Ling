using Ling.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ling.Models.Interfaces
{
    public interface IRecording
    {
        // Create
        Task AddRecording(Recording recording);

        // Read
        Task<Recording> GetRecording(int id);
        Task<IEnumerable<Recording>> GetRecordings();

        // Update
        Task UpdateRecording(Recording recording);

        // Delete
        Task DeleteRecording(int id);

        // Transcribe Recording
        Task<TranscriptionViewModel> Transcribe(string url, string languageCode = "en-US");
    }
}
