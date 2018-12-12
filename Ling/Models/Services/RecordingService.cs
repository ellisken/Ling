using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Core;
using Ling.Data;
using Ling.Models.Interfaces;
using Ling.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Auth;
using static Google.Cloud.Speech.V1.RecognitionConfig.Types;
using Google.Api.Gax.Grpc;
using Google.Cloud.Translation.V2;

namespace Ling.Models.Services
{
    public class RecordingService : IRecording
    {
        public LingDbContext _context { get; set; }
        private readonly GoogleCredential _googleCredential;

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
        public async Task<IEnumerable<Recording>> GetRecordings()
        {
            return await _context.Recordings.ToListAsync();
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
        public async Task<TranscriptionViewModel> Transcribe(string url, string languageCode = "en-US")
        {
         
            // Initialize GA Speech Client
            Channel channel = new Channel(
            SpeechClient.DefaultEndpoint.Host, _googleCredential.ToChannelCredentials());
            SpeechClient speech =  SpeechClient.Create(channel);
            TranslationClient client = TranslationClient.Create(_googleCredential);

            RecognitionAudio audio = await RecognitionAudio.FetchFromUriAsync(url);
            RecognitionConfig config = new RecognitionConfig
            {
                Encoding = AudioEncoding.Linear16,
                LanguageCode = languageCode
            };

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
            }
            // If we have a transcript, attempt to identify the language
            if (confidence > 0)
            {
                Detection detection = await client.DetectLanguageAsync(text: transcript);
                language = detection.Language;
            }
            await channel.ShutdownAsync();
            return new TranscriptionViewModel() { Transcript = transcript, Confidence = confidence, Language = language };
        }
    }
}
