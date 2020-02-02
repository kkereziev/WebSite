using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Watches;

namespace ProjectShop.Pages.CategoriesAndStyles.WatchesStyles
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public EditModel(ProjectShop.Data.ProjectShopContext context)
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
           ViewData["WatchId"] = new SelectList(_context.Watches, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StylesOfWatches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StylesOfWatchesExists(StylesOfWatches.Id))
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

        private bool StylesOfWatchesExists(Guid id)
        {
            return _context.StylesOfWatches.Any(e => e.Id == id);
        }
    }
}
