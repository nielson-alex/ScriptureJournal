using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScriptureJournalAlexNielson.Models;

namespace ScriptureJournalAlexNielson.Pages.Scriptures
{
    public class EditModel : PageModel
    {
        private readonly ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext _context;

        public EditModel(ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ScriptureJournal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScriptureJournalExists(ScriptureJournal.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScriptureJournalExists(int id)
        {
            return _context.ScriptureJournal.Any(e => e.ID == id);
        }
    }
}
