using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptureJournalAlexNielson.Models
{
    public class ScriptureJournal
    {
        public int ID { get; set; }
        public int VerseNumber { get; set; }
        public int ChapterNumber { get; set; }
        public string Book { get; set; }
        [Display(Name="Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
        public string Note { get; set; }
    }
}
