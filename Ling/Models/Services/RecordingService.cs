using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1P1Beta1;
using Grpc.Core;
using Ling.Data;
using Ling.Models.Interfaces;
using Ling.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Auth;
using static Google.Cloud.Speech.V1P1Beta1.RecognitionConfig.Types;
using System.Linq;

namespace Ling.Models.Services
{
    public class RecordingService : IRecording
    {
        public LingDbContext _context { get; set; }
        private readonly GoogleCredential _googleCredential;

        /// <summary>
        /// Initializes a new instance of the <see cref="RecordingService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="googleCredential">The google credential.</param>
        public RecordingService(LingDbContext context, GoogleCredential googleCredential)
        {
            _context = context;
            _googleCredential = googleCredential;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="recording">Recording object</param>
        /// <returns></returns>
        public async Task AddRecording(Recording recording)
        {
            _context.Recordings.Add(recording);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id">ID of recording to find</param>
        /// <returns>Recording object</returns>
        public async Task<Recording> GetRecording(int id)
        {
            return await _context.Recordings.FirstOrDefaultAsync(r => r.ID == id);
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <returns>All Recordings in db</returns>
        public async Task<IEnumerable<Recording>> GetRecordings(int take = 20, int skip = 0)
        {
            IEnumerable<Recording> recordings = await _context.Recordings.Include(x => x.Language).Take(take).Skip(skip).ToListAsync();
            return recordings;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="recording">Recording object</param>
        /// <returns></returns>
        public async Task UpdateRecording(Recording recording)
        {
            _context.Recordings.Update(recording);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">ID of Recording to delete</param>
        /// <returns></returns>
        public async Task DeleteRecording(int id)
        {
            var recording = await GetRecording(id);
            _context.Recordings.Remove(recording);
            await _context.SaveChangesAsync();
        }

        // https://developers.google.com/admin-sdk/directory/v1/languages
        /// <summary>
        /// Transcribes the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="languageCode">The language code.</param>
        /// <returns></returns>
        public async Task<TranscriptionViewModel> Transcribe(string url, string languageCode = "en-US", List<string> altLanguages = null)
        {
         
            // Initialize GA Speech Client
            Channel channel = new Channel(
            SpeechClient.DefaultEndpoint.Host, _googleCredential.ToChannelCredentials());
            SpeechClient speech =  SpeechClient.Create(channel);

            RecognitionAudio audio = await RecognitionAudio.FetchFromUriAsync(url);
            RecognitionConfig config = new RecognitionConfig
            {
                Encoding = AudioEncoding.Linear16,
                LanguageCode = languageCode,
            };

            if (altLanguages != null)
            {
                foreach (string altLang in altLanguages)
                {
                    config.AlternativeLanguageCodes.Add(altLang);
                }
            }

            RecognizeResponse response = speech.Recognize(config, audio);

            string transcript = "";
            float confidence = 0f;
            string language = "";
            // Parse results
            foreach (var res in response.Results)
            {
                // Take only the highest confidence transcription
                foreach (var alternative in res.Alternatives)
                {
                    if (alternative.Confidence > confidence)
                    {
                        transcript = alternative.Transcript;
                        confidence = alternative.Confidence;
                    }

                }
                language = res.LanguageCode;
            }
 
            await channel.ShutdownAsync();
            return new TranscriptionViewModel() { Transcript = transcript, Confidence = confidence, Language = language };
        }
    }
}
