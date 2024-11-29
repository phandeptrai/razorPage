using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageHW.Context;
using RazorPageHW.Models;

namespace RazorPageHW.Pages.Categoriss
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageHW.Context.DBContext _context;

        public IndexModel(RazorPageHW.Context.DBContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
