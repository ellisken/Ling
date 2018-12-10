using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ling.Models
{
    public class Recording
    {
        public int ID { get; set; }
        [ForeignKey(name: Language.ID)]
        public int LanguageID { get; set; }
        public byte Audio { get; set; }
        public List<string> AlternateLanguages { get; set; }
        public decimal Length { get; set; }

        // Navigation prop
        public Language Language { get; set; }
    }
}
