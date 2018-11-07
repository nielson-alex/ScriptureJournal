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
    public class DeleteModel : PageModel
    {
        private readonly ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext _context;

        public DeleteModel(ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScriptureJournal ScriptureJournal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptureJournal = await _context.ScriptureJournal.FirstOrDefaultAsync(m => m.ID == id);

            if (ScriptureJournal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScriptureJournal = await _context.ScriptureJournal.FindAsync(id);

            if (ScriptureJournal != null)
            {
                _context.ScriptureJournal.Remove(ScriptureJournal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
