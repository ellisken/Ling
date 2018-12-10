using System.Collections.Generic;

namespace Ling.Models
{
    public class Recording
    {
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public byte Audio { get; set; }
        public List<string> AlternateLanguages { get; set; }
        public decimal Length { get; set; }

        // Navigation prop
        public ICollection<Language> Languages { get; set; }
    }
}
