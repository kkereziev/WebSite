using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Jewelry;

namespace ProjectShop.Pages.CategoriesAndStyles.JewelryCategory
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DeleteModel(ProjectShop.Data.ProjectShopContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryOfJewelry = await _context.CategoryOfJewelry.FindAsync(id);

            if (CategoryOfJewelry != null)
            {
                _context.CategoryOfJewelry.Remove(CategoryOfJewelry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
