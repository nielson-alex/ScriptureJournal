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
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        public string ScripturesBooks { get; set; }

        public async Task OnGetAsync(string book, string searchString)
        {
            //// Use LINQ to get list of genres.
            //IQueryable<string> bookQuery = from s in _context.ScriptureJournal
            //                                orderby s.Book
            //                                select s.Book;

            var scriptures = from s in _context.ScriptureJournal
                         select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                scriptures = scriptures.Where(s => s.Book.Contains(searchString));
            }

            //if (!String.IsNullOrEmpty(book))
            //{
            //    books = books.Where(x => x.Book == book);
            //}

            //Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            ScriptureJournal = await scriptures.ToListAsync();
            SearchString = searchString;
        }
    }
}
