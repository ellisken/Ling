using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ling.Models
{
    public class Recording
    {
        public int ID { get; set; }
        public int LanguageID { get; set; } = 1;
        public string FileName { get; set; }
        public string URI { get; set; }
        public string Transcription { get; set; }

        // Navigation prop
        public Language Language { get; set; }
    }
}
