using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using entity_core.Models;

namespace entity_core.Views.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly entity_core.Models.BloggingContext _context;

        public DetailsModel(entity_core.Models.BloggingContext context)
        {
            _context = context;
        }

        public Blog Blog { get; set; }
        public IList<Post> Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Blog = await _context.Blogs.FirstOrDefaultAsync(m => m.BlogId == id);
            Post = await _context.Posts
               .Include(p => p.Blog).ToListAsync();

            if (Blog == null)
            {
                return NotFound();
            }
            return Page();
        } 
    }
}
