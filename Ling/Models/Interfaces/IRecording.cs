using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ling.Models.Interfaces
{
    interface IRecording
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
    }
}
