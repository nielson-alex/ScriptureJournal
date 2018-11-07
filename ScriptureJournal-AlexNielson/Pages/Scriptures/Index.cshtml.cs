using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScriptureJournalAlexNielson.Models;

namespace ScriptureJournalAlexNielson.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext _context;

        public IndexModel(ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext context)
        {
            _context = context;
        }

        public IList<ScriptureJournal> ScriptureJournal { get;set; }

        public async Task OnGetAsync()
        {
            ScriptureJournal = await _context.ScriptureJournal.ToListAsync();
        }
    }
}
