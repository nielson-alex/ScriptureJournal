using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ScriptureJournalAlexNielson.Models
{
    public class ScriptureJournalAlexNielsonContext : DbContext
    {
        public ScriptureJournalAlexNielsonContext (DbContextOptions<ScriptureJournalAlexNielsonContext> options)
            : base(options)
        {
        }

        public DbSet<ScriptureJournalAlexNielson.Models.ScriptureJournal> ScriptureJournal { get; set; }
    }
}
