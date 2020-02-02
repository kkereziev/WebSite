using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Watches;

namespace ProjectShop.Pages.CategoriesAndStyles.WatchesStyles
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StylesOfWatches StylesOfWatches { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StylesOfWatches = await _context.StylesOfWatches
                .Include(s => s.Watch).FirstOrDefaultAsync(m => m.Id == id);

            if (StylesOfWatches == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StylesOfWatches = await _context.StylesOfWatches.FindAsync(id);

            if (StylesOfWatches != null)
            {
                _context.StylesOfWatches.Remove(StylesOfWatches);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
