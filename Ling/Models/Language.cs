using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ling.Models
{
    public class Language
    {
        public int ID { get; set; }
        public string EnglishName { get; set; }
        public string OriginalName { get; set; }
        public string Romanized { get; set; }
        public string ISOCode { get; set; }

        public ICollection<Recording> Recordings { get; set; }
    }
}
