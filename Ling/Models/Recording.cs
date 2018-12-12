using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ling.Models
{
    public class Recording
    {
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public string FileName { get; set; }
        public string AlternateLanguages { get; set; }
        public decimal Length { get; set; }

        // Navigation prop
        public Language Language { get; set; }
    }
}
