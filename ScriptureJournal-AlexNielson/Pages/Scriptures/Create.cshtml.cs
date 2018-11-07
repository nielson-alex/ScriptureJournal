using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ScriptureJournalAlexNielson.Models;

namespace ScriptureJournalAlexNielson.Pages.Scriptures
{
    public class CreateModel : PageModel
    {
        private readonly ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext _context;

        public CreateModel(ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ScriptureJournal ScriptureJournal { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ScriptureJournal.Add(ScriptureJournal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}