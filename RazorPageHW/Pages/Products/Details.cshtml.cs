using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageHW.Context;
using RazorPageHW.Models;

namespace RazorPageHW.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPageHW.Context.DBContext _context;

        public DetailsModel(RazorPageHW.Context.DBContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include hình ảnh liên quan (ImgProducts)
            Product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ImgProducts) // Bao gồm hình ảnh của sản phẩm
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
