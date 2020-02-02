using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Jewelry;

namespace ProjectShop.Pages.CategoriesAndStyles.JewelryCategory
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public EditModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryOfJewelry CategoryOfJewelry { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryOfJewelry = await _context.CategoryOfJewelry
                .Include(c => c.Jewelry).FirstOrDefaultAsync(m => m.Id == id);

            if (CategoryOfJewelry == null)
            {
                return NotFound();
            }
           ViewData["JewelryId"] = new SelectList(_context.Jewelry, "Id", "Id");
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

            _context.Attach(CategoryOfJewelry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryOfJewelryExists(CategoryOfJewelry.Id))
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

        private bool CategoryOfJewelryExists(Guid id)
        {
            return _context.CategoryOfJewelry.Any(e => e.Id == id);
        }
    }
}
