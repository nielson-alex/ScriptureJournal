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
    public class IndexModel : PageModel
    {
        private readonly ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext _context;

        public IndexModel(ScriptureJournalAlexNielson.Models.ScriptureJournalAlexNielsonContext context)
        {
            _context = context;
        }

        public IList<ScriptureJournal> ScriptureJournal { get;set; }
        public string SearchStringBook { get; set; }
        public SelectList Books { get; set; }
        public string ScripturesBooks { get; set; }
        public string SearchStringNote { get; set; }
        public SelectList Notes { get; set; }
        public string ScriptureNotes { get; set; }
        public string SortDate { get; set; }
        public async Task OnGetAsync(string book, string note, string searchStringBook, string searchStringNote)
        {
            // Use LINQ to get list of books.
            IQueryable<string> bookQuery = from s in _context.ScriptureJournal
                                           orderby SortDate
                                           select s.Book;

            IQueryable<string> noteQuery = from s in _context.ScriptureJournal
                                           orderby s.Note
                                           select s.Note;

            var scriptures = from s in _context.ScriptureJournal
                         select s;


            if (!String.IsNullOrEmpty(searchStringBook))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(searchStringBook));
            }

            if (!String.IsNullOrEmpty(book))
            {
                scriptures = scriptures.Where(x => x.Book == book);
            }

            if (!String.IsNullOrEmpty(searchStringNote))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(searchStringNote));
            }

            if (!String.IsNullOrEmpty(note))
            {
                scriptures = scriptures.Where(x => x.Note == note);
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Notes = new SelectList(await noteQuery.Distinct().ToListAsync());
            ScriptureJournal = await scriptures.ToListAsync();
            SearchStringBook = searchStringBook;
            SearchStringNote = searchStringNote;
        }
    }
}
