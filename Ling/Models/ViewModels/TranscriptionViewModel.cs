using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ling.Models.ViewModels
{
    public class TranscriptionViewModel
    {
        /// <summary>
        /// Gets or sets the transcript.
        /// </summary>
        /// <value>
        /// The transcript.
        /// </value>
        public string Transcript{ get; set; }
        /// <summary>
        /// Gets or sets the confidence.
        /// </summary>
        /// <value>
        /// The confidence.
        /// </value>
        public float Confidence { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language { get; set; }

    }
}
